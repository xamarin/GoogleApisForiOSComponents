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

		DatabaseReference folderLastModifiedNode;
		DatabaseReference folderNegativeLastModifiedNode;
		DatabaseReference notesCountNode;
		DatabaseReference noteNode;
		DatabaseReference deletedFolderNode;

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
			if (Note == null) {
				CreateNote ();
			}

			txtTitle.Text = Note.Title;
			TxtContent.Text = Note.Content;
			CreateNodes ();

			base.ViewWillAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			var title = txtTitle.Text;
			var content = TxtContent.Text;

			if (deleteNote || (string.IsNullOrWhiteSpace (title) && string.IsNullOrWhiteSpace (content)))
				DeleteNote ();
			else if (title != Note.Title || content != Note.Content)
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
			folderLastModifiedNode = folderNode.GetChild ("lastModified");
			folderNegativeLastModifiedNode = folderNode.GetChild ("negativeLastModified");
			notesCountNode = folderNode.GetChild ("notesCount");
			noteNode = noteNode ?? AppDelegate.RootNode.GetChild ("notes").GetChild (AppDelegate.UserUid).GetChild (Folder.Node).GetChild (Note.Node);
		}

		void btnDeleteNote_Clicked (object sender, EventArgs e)
		{
			deleteNote = true;
			NavigationController.PopViewController (true);
		}

		void CreateNote ()
		{
			noteNode = AppDelegate.RootNode.GetChild ("notes").GetChild (AppDelegate.UserUid).GetChild (Folder.Node).GetChildByAutoId ();
			Note = new Note {
				Node = noteNode.Key
			};
			++NotesCount;
		}

		void DeleteNote ()
		{
			noteNode.RemoveValue ();
			notesCountNode.SetValue (NSNumber.FromNUInt (--NotesCount));
		}

		void SaveNote ()
		{
			var title = txtTitle.Text.Trim ();
			var content = TxtContent.Text.Trim ();
			var lastModified = AppDelegate.GetUtcTimestamp ();
			var created = Note.CreatedUnformatted ?? lastModified.ToString ();

			title = string.IsNullOrWhiteSpace (title) ? null : title;
			content = string.IsNullOrWhiteSpace (content) ? null : content;

			object [] keys = { "content", "created", "lastModified", "negativeLastModified", "title" };
			object [] values = { content, double.Parse (created), lastModified, -lastModified, title };
			var data = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);

			noteNode.KeepSynced (true);
			noteNode.SetValue (data);
			notesCountNode.SetValue (NSNumber.FromNUInt (NotesCount));
			folderLastModifiedNode.SetValue (NSNumber.FromDouble (lastModified));
			folderNegativeLastModifiedNode.SetValue (NSNumber.FromDouble (-lastModified));
		}
	}
}

