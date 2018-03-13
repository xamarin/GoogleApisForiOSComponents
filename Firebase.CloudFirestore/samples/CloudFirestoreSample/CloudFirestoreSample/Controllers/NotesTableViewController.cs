using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CoreGraphics;
using Foundation;
using UIKit;

using Firebase.CloudFirestore;

namespace CloudFirestoreSample
{
	public partial class NotesTableViewController : UITableViewController
	{
		#region Class Variables

		UIBarButtonItem space;
		UIActivityIndicatorView indicatorView;
		UILabel lblNotesCount;
		UIBarButtonItem btnNewNote;
		UIRefreshControl refreshControl;

		List<Note> notes;

		IListenerRegistration pendingChangesListener;

		// Reference that points to folder data.
		DocumentReference folderDocument;

		// Reference that points to user folder's notes
		CollectionReference notesCollection;

		#endregion

		#region Properties

		public Folder Folder { get; set; }
		public CollectionReference FoldersCollection { get; set; }

		#endregion

		#region Constructors

		public NotesTableViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			InitializeComponents ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			LoadNotes ();
		}

		#endregion

		#region User Interaction

		// Pull to refresh notes
		void RefreshControl_ValueChanged (object sender, EventArgs e)
		{
			TableView.UserInteractionEnabled = false;
			LoadNotes ();
		}

		void btnNewNote_Clicked (object sender, EventArgs e)
		{
			var noteViewController = Storyboard.InstantiateViewController (nameof (NoteViewController)) as NoteViewController;
			noteViewController.Folder = Folder;
			noteViewController.IsNewNote = true;
			noteViewController.FolderDocument = folderDocument;
			noteViewController.NotesCollection = notesCollection;

			NavigationController.PushViewController (noteViewController, true);
		}

		#endregion

		#region Navigation

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			if (segue.Identifier != "DefaultSegue")
				return;
			
			var noteViewController = segue.DestinationViewController as NoteViewController;
			noteViewController.Folder = Folder;
			noteViewController.Note = notes [TableView.IndexPathForSelectedRow.Row];
			noteViewController.FolderDocument = folderDocument;
			noteViewController.NotesCollection = notesCollection;
		}

		#endregion

		#region TableView Data Source

		public override nint NumberOfSections (UITableView tableView) => 1;
		public override nint RowsInSection (UITableView tableView, nint section) => notes.Count == 0 ? 1 : notes.Count;

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			if (notes.Count == 0)
				return tableView.DequeueReusableCell ("DefaultTableViewCell", indexPath);

			var note = notes [indexPath.Row];

			var cell = tableView.DequeueReusableCell (NoteTableViewCell.Key, indexPath) as NoteTableViewCell;
			cell.Title = string.IsNullOrWhiteSpace (note.Title) ? "<No Title>" : note.Title;
			cell.Subtitle = note.LastModified;

			var content = string.IsNullOrWhiteSpace (note.Content) ? "<No content>" : note.Content;
			cell.Preview = content.Length <= 70 ? content : content.Substring (0, 70);

			return cell;
		}

		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath) => true;

		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			indicatorView.StartAnimating ();

			if (editingStyle != UITableViewCellEditingStyle.Delete)
				return;

			// Delete the note from the TableView so user cannot get access to it while deleting
			var note = notes [indexPath.Row];
			notes.Remove (note);

			if (notes.Count == 0)
				tableView.ReloadRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);
			else
				tableView.DeleteRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);

			UpdateNotesCountLabel ();

			Task.Factory.StartNew (async () => {
				try {
					// Remove the note from the Cloud Firestore
					await DeleteNote (note);
				} catch (NSErrorException ex) {
					// If something fails while deleting the note, add it again to the TableView
					notes.Insert (indexPath.Row, note);
					InvokeOnMainThread (() => {
						UIAlertHelper.ShowMessage ("Error while deleting the note", ex.Error.LocalizedDescription, NavigationController, "Ok");

						if (notes.Count == 1)
							tableView.ReloadRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);
						else
							tableView.InsertRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);

						UpdateNotesCountLabel ();
					});
				} finally {
					note = null;
					InvokeOnMainThread (() => indicatorView.StopAnimating ());
				}
			});
		}

		#endregion

		#region Internal Functionality

		void InitializeComponents ()
		{
			notes = new List<Note> ();

			space = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);

			indicatorView = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.White) {
				Frame = new CGRect (0, 0, 20, 20),
				HidesWhenStopped = true
			};
			var btnIndicator = new UIBarButtonItem (indicatorView);

			lblNotesCount = new UILabel (new CGRect (0, 0, 50, 15)) {
				Font = UIFont.SystemFontOfSize (12),
				TextColor = UIColor.White
			};
			var btnNotesCount = new UIBarButtonItem (lblNotesCount);

			btnNewNote = new UIBarButtonItem (UIBarButtonSystemItem.Compose, btnNewNote_Clicked) {
				TintColor = UIColor.White,
			};

			SetToolbarItems (new [] { space, space, btnIndicator, btnNotesCount, space, space, btnNewNote }, false);

			refreshControl = new UIRefreshControl ();
			refreshControl.AddTarget (RefreshControl_ValueChanged, UIControlEvent.ValueChanged);
			TableView.RefreshControl = refreshControl;
		}

		void LoadNotes ()
		{
			TableView.UserInteractionEnabled = false;
			indicatorView.StartAnimating ();
			btnNewNote.Enabled = false;

			UpdateNotesCountLabel ();
			Task.Factory.StartNew (LoadNotesAsync);

			async Task LoadNotesAsync ()
			{
				InitializeFirestoreReferences ();

				try {
					await GetNotes ();
				} catch (NSErrorException ex) {
					InvokeOnMainThread (() => {
						UIAlertHelper.ShowMessage ("An error has ocurred...", ex.Error.LocalizedDescription, NavigationController, "Ok");
					});
				} catch (Exception ex) {
					Console.WriteLine (ex.Message);
				} finally {
					InvokeOnMainThread (() => {
						indicatorView.StopAnimating ();
						refreshControl.EndRefreshing ();
						btnNewNote.Enabled = true;
						TableView.UserInteractionEnabled = true;
					});
				}
			}
		}

		void InitializeFirestoreReferences ()
		{
			folderDocument = FoldersCollection.GetDocument (Folder.Id);
			notesCollection = folderDocument.GetCollection ("notes");
		}

		// Get notes data to be shown in TableView
		async Task GetNotes ()
		{
			// Stop listening for changes from Firebase Cloud Firestore
			pendingChangesListener?.Remove ();
			pendingChangesListener?.Dispose ();
			pendingChangesListener = null;

			notes.Clear ();

			var notesQuery = await notesCollection.OrderedBy ("lastModified", true)
			                                      .GetDocumentsAsync ();

			foreach (var note in notesQuery.Documents) {
				// When you create a new note, sometimes the data hasn't
				// been written in Firestore yet, so, we keep listening
				// until the data is written.
				if (note.Metadata.HasPendingWrites) {
					pendingChangesListener = note.Reference.AddSnapshotListener (DataSavedOnFirestore);
					return;
				}

				var data = note.Data;
				var title = data ["title"]?.ToString ();
				var content = data ["content"]?.ToString ();
				var created = data ["created"] as NSDate;
				var lastModified = data ["lastModified"] as NSDate;

				notes.Add (new Note {
					Id = note.Id,
					Title = title,
					Content = content,
					Created = AppDelegate.GetFormattedDate (created),
					LastModified = AppDelegate.GetFormattedDate (lastModified)
				});
			}

			InvokeOnMainThread (() => TableView.ReloadData ());
		}

		async Task DeleteNote (Note note)
		{
			var batch = AppDelegate.Database.CreateBatch ();
			var noteDocument = notesCollection.GetDocument (note.Id);
			var folderData = new Dictionary<object, object> {
				{ "notesCount", --Folder.NotesCount },
				{ "lastModified", FieldValue.ServerTimestamp }
			};

			await batch.DeleteDocument (noteDocument)
			           .UpdateData (folderData, folderDocument)
			           .CommitAsync ();
		}

		void UpdateNotesCountLabel ()
		{
			var count = Folder.NotesCount;
			lblNotesCount.Text = $"{count} note{(count != 1 ? "s" : "")}";
		}

		void DataSavedOnFirestore (DocumentSnapshot snapshot, NSError error)
		{
			if (error != null) {
				UIAlertHelper.ShowMessage ("An error has occurred…", error.LocalizedDescription, NavigationController, "Ok");
				TableView.ReloadData ();
				indicatorView.StopAnimating ();
				return;
			}

			LoadNotes ();
		}

		#endregion
	}
}

