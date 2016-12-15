using System;

using UIKit;
using CoreGraphics;
using Firebase.Database;
using System.Collections.Generic;
using Foundation;

namespace DatabaseSample
{
	public partial class NotesViewController : UITableViewController
	{
		UIBarButtonItem space;
		UIActivityIndicatorView indicatorView;
		UIBarButtonItem btnNewNote;
		UILabel lblNotesCount;

		// Reference that points to folder's notes count node.
		// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»/notesCount
		DatabaseReference notesCountNode;

		// Reference that points to user's notes.
		// Points to https://MyDatabaseId.firebaseio.com/notes/«userUid»/«folderUid»/
		DatabaseReference notesNode;

		// Get all user's notes ordered by "negativeLastModified" node.
		// Why we negative the last modified value? Because sorted values are in ascending order, from the lowest value to the highest.
		// In other words, in the first position comes the oldest modified note and in the last position comes the most recent modified note.
		// Firebase doesn't have a way to get list is descending order.
		// With this hack we invert the list, making notes to be sorted in "descending" order.
		DatabaseQuery notesByDate;

		List<Note> notes;
		nuint notesCount;

		public Folder Folder { get; set; }

		protected NotesViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			InitializeComponents ();
		}

		public override void ViewWillAppear (bool animated)
		{
			CreateNodes ();
			GetNotesCount ();

			base.ViewWillAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			RemoveObserversFromNodes ();

			base.ViewWillDisappear (animated);
		}

		void InitializeComponents ()
		{
			notes = new List<Note> ();

			space = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);

			indicatorView = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.White) {
				Frame = new CGRect (0, 0, 20, 20),
				HidesWhenStopped = true
			};
			var btnIndicator = new UIBarButtonItem (indicatorView);

			var count = Folder.NotesCount;
			lblNotesCount = new UILabel (new CGRect (0, 0, 50, 15)) {
				Font = UIFont.SystemFontOfSize (12)
			};
			lblNotesCount.Text = $"{count} note{count != 1 ? "s" : ""}";
			var btnNotesCount = new UIBarButtonItem (lblNotesCount);

			btnNewNote = new UIBarButtonItem (UIBarButtonSystemItem.Compose, btnNewNote_Clicked) {
				TintColor = UIColor.White
			};

			SetToolbarItems (new [] { space, space, btnIndicator, btnNotesCount, space, space, btnNewNote }, false);
		}

		void CreateNodes ()
		{
			var folderNode = AppDelegate.RootNode.GetChild ("folders").GetChild (AppDelegate.UserUid).GetChild (Folder.Node);
			// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»/notesCount
			notesCountNode = folderNode.GetChild ("notesCount");
			// Points to https://MyDatabaseId.firebaseio.com/notes/«userUid»/«folderUid»/
			notesNode = AppDelegate.RootNode.GetChild ("notes").GetChild (AppDelegate.UserUid).GetChild (Folder.Node);
			// Points to https://MyDatabaseId.firebaseio.com/notes/«userUid»/«folderUid»/ but sorted by "negativeLastModified" value
			notesByDate = notesNode.GetQueryOrderedByChild ("negativeLastModified");
		}

		// Clean node observers to avoid leaks of memory 
		void RemoveObserversFromNodes ()
		{
			notesCountNode.RemoveAllObservers ();
			notesNode.RemoveAllObservers ();
		}

		// Go to next View Controller to write a note
		void btnNewNote_Clicked (object sender, EventArgs e)
		{
			var viewController = Storyboard.InstantiateViewController ("NoteViewControllerID") as NoteViewController;
			viewController.Folder = Folder;
			viewController.NotesCount = notesCount;
			NavigationController.PushViewController (viewController, true);
		}

		void GetNotesCount ()
		{
			indicatorView.StartAnimating ();

			// Get notes count to know when to stop and refresh the table view when we get notes sorted by "negativeLastModified"
			notesCountNode.ObserveEvent (DataEventType.Value, (snapshot) => {
				notesCount = snapshot.GetValue<NSNumber> ().NUIntValue;
				GetNotes ();
			}, (error) => {
				Console.WriteLine (error.LocalizedDescription);
			});
		}

		// Get notes's data to be shown in TableView
		void GetNotes ()
		{
			// Clean folders list
			notes.Clear ();

			// If we don't have notes to show, refresh the table to show nothing
			if (notesCount == 0) {
				TableView.ReloadData ();
				return;
			}

			// Get notes ordered by "negativeLastModified" value
			notesByDate.ObserveEvent (DataEventType.ChildAdded, (snapshot, prevKey) => {
				var data = snapshot.GetValue<NSDictionary> ();
				var content = data ["content"]?.ToString ();
				var created = (data ["created"] as NSNumber).StringValue;
				var lastModified = (data ["lastModified"] as NSNumber).StringValue;
				var title = data ["title"]?.ToString ();

				notes.Add (new Note {
					Node = snapshot.Key,
					Content = content,
					Created = AppDelegate.ConvertUnformattedUtcDateToCurrentDate (created),
					CreatedUnformatted = created,
					LastModified = AppDelegate.ConvertUnformattedUtcDateToCurrentDate (lastModified),
					LastModifiedUnformatted = lastModified,
					Title = title
				});

				// If we finished reading folders, refresh the Table View
				if (notes.Count == (int)notesCount)
					TableView.ReloadData ();
			});
		}

		// Erase all data from a note node
		void DeleteNote (Note note)
		{
			notesNode.GetChild (note.Node).RemoveValue ();
			notesCountNode.SetValue (NSNumber.FromNUInt (--notesCount));
			notes.Remove (note);
		}

		#region UITableView DataSource

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			indicatorView.StopAnimating ();

			return notes.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var note = notes [indexPath.Row];

			var cell = tableView.DequeueReusableCell (NoteCell.Key) as NoteCell;
			cell.TitleText = note.Title ?? "<No Title>";
			cell.SubtitleText = note.LastModified;

			var content = note.Content ?? "<No content>";
			var textLength = content.Length > 70 ? 70 : content.Length; 
			cell.PreviewText = content.Substring (0, textLength);

			return cell;
		}

		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
		{
			return true;
		}

		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			switch (editingStyle) {
			case UITableViewCellEditingStyle.Delete:
				var note = notes [indexPath.Row];
				DeleteNote (note);
				tableView.DeleteRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);
				break;
			default:
				break;
			}
		}

		#endregion

		#region UITableView Delegate

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var note = notes [indexPath.Row];

			var viewController = Storyboard.InstantiateViewController ("NoteViewControllerID") as NoteViewController;
			viewController.Folder = Folder;
			viewController.Note = note;
			viewController.NotesCount = notesCount;
			NavigationController.PushViewController (viewController, true);
		}

		#endregion
	}
}
