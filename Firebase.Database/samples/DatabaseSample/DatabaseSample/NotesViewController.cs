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

		DatabaseReference lastModifiedNode;
		DatabaseReference negativeLastModifiedNode;
		DatabaseReference notesCountNode;
		DatabaseReference notesNode;
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
			lastModifiedNode = folderNode.GetChild ("lastModified");
			negativeLastModifiedNode = folderNode.GetChild ("negativeLastModified");
			notesCountNode = folderNode.GetChild ("notesCount");
			notesNode = AppDelegate.RootNode.GetChild ("notes").GetChild (AppDelegate.UserUid).GetChild (Folder.Node);
			notesByDate = notesNode.GetQueryOrderedByChild ("negativeLastModified");
		}

		void RemoveObserversFromNodes ()
		{
			lastModifiedNode.RemoveAllObservers ();
			negativeLastModifiedNode.RemoveAllObservers ();
			notesCountNode.RemoveAllObservers ();
			notesNode.RemoveAllObservers ();
		}

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

			notesCountNode.ObserveEvent (DataEventType.Value, (snapshot) => {
				notesCount = snapshot.GetValue<NSNumber> ().NUIntValue;
				GetNotes ();
			});
		}

		void GetNotes ()
		{
			notes.Clear ();

			if (notesCount == 0) {
				TableView.ReloadData ();
				return;
			}

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

				if (notes.Count == (int)notesCount)
					TableView.ReloadData ();
			});
		}

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
