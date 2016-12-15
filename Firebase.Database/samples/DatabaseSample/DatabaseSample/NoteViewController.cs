using System;

using UIKit;
using CoreGraphics;
using Firebase.Database;
using Foundation;

namespace DatabaseSample
{
	public partial class NoteViewController : UIViewController
	{
		UIBarButtonItem space;
		UIBarButtonItem btnDeleteNote;
		UITextField txtTitle;

		// Reference that points to folder's last modified node.
		// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»/lastModified
		DatabaseReference folderLastModifiedNode;

		// Reference that points to folder's negative last modified node.
		// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»/negativeLastModified
		DatabaseReference folderNegativeLastModifiedNode;

		// Reference that points to folder's notes count node.
		// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»/notesCount
		DatabaseReference notesCountNode;

		// Reference that points to current note data.
		// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»/«notesUid»
		DatabaseReference noteNode;

		bool deleteNote;

		public Folder Folder { get; set; }
		public Note Note { get; set; }
		public nuint NotesCount { get; set; }

		protected NoteViewController (IntPtr handle) : base (handle)
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
			// If we are going to create a new note, generate a new note node
			if (Note == null) {
				CreateNote ();
			}

			// Show note data in UI
			txtTitle.Text = Note.Title;
			TxtContent.Text = Note.Content;
			CreateNodes ();

			base.ViewWillAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			var title = txtTitle.Text;
			var content = TxtContent.Text;

			// If we tap the delete button or we delete the content of note means that we need to delete the note.
			if (deleteNote || (string.IsNullOrWhiteSpace (title) && string.IsNullOrWhiteSpace (content)))
				DeleteNote ();
			else if (title != Note.Title || content != Note.Content) // If we made some change to note, update it
				SaveNote ();

			base.ViewWillDisappear (animated);
		}

		void InitializeComponents ()
		{
			txtTitle = new UITextField (new CGRect (0, 0, NavigationController.NavigationBar.Bounds.Width, 22)) {
				Placeholder = "Type your title here",
				TextColor = UIColor.White,
				TextAlignment = UITextAlignment.Center,
			};
			NavigationItem.TitleView = txtTitle;

			space = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);

			btnDeleteNote = new UIBarButtonItem (UIBarButtonSystemItem.Trash, btnDeleteNote_Clicked) {
				TintColor = UIColor.White
			};

			SetToolbarItems (new [] { space, btnDeleteNote }, false);
		}

		void CreateNodes ()
		{
			var folderNode = AppDelegate.RootNode.GetChild ("folders").GetChild (AppDelegate.UserUid).GetChild (Folder.Node);
			// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»/lastModified
			folderLastModifiedNode = folderNode.GetChild ("lastModified");
			// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»/negativeLastModified
			folderNegativeLastModifiedNode = folderNode.GetChild ("negativeLastModified");
			// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»/notesCount
			notesCountNode = folderNode.GetChild ("notesCount");
			// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»/«notesUid»
			noteNode = noteNode ?? AppDelegate.RootNode.GetChild ("notes").GetChild (AppDelegate.UserUid).GetChild (Folder.Node).GetChild (Note.Node);
		}

		// A button to delete the current note
		void btnDeleteNote_Clicked (object sender, EventArgs e)
		{
			deleteNote = true;
			NavigationController.PopViewController (true);
		}

		// Creates the note data, but not in Firebase Database, just in memory
		void CreateNote ()
		{
			noteNode = AppDelegate.RootNode.GetChild ("notes").GetChild (AppDelegate.UserUid).GetChild (Folder.Node).GetChildByAutoId ();
			Note = new Note {
				Node = noteNode.Key
			};
			++NotesCount;
		}

		// Erase all data from a note node
		void DeleteNote ()
		{
			noteNode.RemoveValue ();
			notesCountNode.SetValue (NSNumber.FromNUInt (--NotesCount));
		}

		// Save the data in Firebase Database
		void SaveNote ()
		{
			// Create data to be saved in FIrebase Database
			var title = txtTitle.Text.Trim ();
			var content = TxtContent.Text.Trim ();
			var lastModified = AppDelegate.GetUtcTimestamp ();
			var created = Note.CreatedUnformatted ?? lastModified.ToString ();

			title = string.IsNullOrWhiteSpace (title) ? null : title;
			content = string.IsNullOrWhiteSpace (content) ? null : content;

			object [] keys = { "content", "created", "lastModified", "negativeLastModified", "title" };
			object [] values = { content, double.Parse (created), lastModified, -lastModified, title };
			var data = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);

			// Keep data offline
			noteNode.KeepSynced (true);
			// Save data in note node 
			noteNode.SetValue (data);
			// Increment notes count in folder
			notesCountNode.SetValue (NSNumber.FromNUInt (NotesCount));
			// Modify the last modified date to make this folder the first position in Table View
			folderLastModifiedNode.SetValue (NSNumber.FromDouble (lastModified));
			folderNegativeLastModifiedNode.SetValue (NSNumber.FromDouble (-lastModified));
		}
	}
}

