using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CoreGraphics;
using Foundation;
using UIKit;

using Firebase.CloudFirestore;

namespace CloudFirestoreSample
{
	public partial class NoteViewController : UIViewController
	{
		#region Class Variables

		UIBarButtonItem space;
		UIBarButtonItem btnDeleteNote;
		UITextField txtTitle;

		bool delete;

		DocumentReference noteDocument;

		#endregion

		#region Properties

		public Folder Folder { get; set; }
		public Note Note { get; set; }
		public CollectionReference NotesCollection { get; set; }
		public DocumentReference FolderDocument { get; set; }
		public bool IsNewNote { get; set; }

		#endregion

		#region Constructors

		public NoteViewController (IntPtr handle) : base (handle)
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
			LoadNote ();

			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			View.EndEditing (true);

			var title = txtTitle.Text;
			var content = TxtContent.Text;

			// If we tap the delete button or we delete the content of note means that we need to delete the note.
			if (delete || (string.IsNullOrWhiteSpace (title) && string.IsNullOrWhiteSpace (content)))
				DeleteNote ();
			else if (title != Note.Title || content != Note.Content) // If we made some change to note, update it
				SaveNote ();

			base.ViewWillDisappear (animated);
		}

		#endregion

		#region User Interactions

		void btnDeleteNote_Clicked (object sender, EventArgs e)
		{
			delete = true;
			NavigationController.PopViewController (true);
		}

		#endregion

		#region Internal Functionality

		void InitializeComponents ()
		{
			txtTitle = new UITextField (new CGRect (0, 0, NavigationController.NavigationBar.Bounds.Width, 22)) {
				Placeholder = "Type your title here",
				TextColor = UIColor.White,
				TextAlignment = UITextAlignment.Center
			};
			NavigationItem.TitleView = txtTitle;

			space = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);

			btnDeleteNote = new UIBarButtonItem (UIBarButtonSystemItem.Trash, btnDeleteNote_Clicked) {
				TintColor = UIColor.White
			};

			SetToolbarItems (new [] { space, btnDeleteNote }, false);
		}

		void LoadNote ()
		{
			InitializeFirestoreReferences ();

			// Show note data in UI
			txtTitle.Text = Note.Title;
			TxtContent.Text = Note.Content;
		}

		void InitializeFirestoreReferences ()
		{
			// If we are going to create a new note, generate a new note node
			if (IsNewNote) {
				noteDocument = NotesCollection.CreateDocument ();
				Note = new Note { Id = noteDocument.Id };
				Folder.NotesCount++;
			} else
				noteDocument = NotesCollection.GetDocument (Note.Id);
		}

		void SaveNote ()
		{
			var title = txtTitle.Text.Trim ();
			var content = TxtContent.Text.Trim ();

			// Execute multiple write operations as a single batch
			var batch = AppDelegate.Database.CreateBatch ();

			// Create or update note data to be saved in Firebase Cloud Firestore
			var lastModified = FieldValue.ServerTimestamp;

			var noteData = new Dictionary<object, object> {
					{ "title", title },
					{ "content", content },
					{ "lastModified", lastModified }
				};

			if (IsNewNote) {
				noteData.Add ("created", FieldValue.ServerTimestamp);
				batch.SetData (noteData, noteDocument);
			} else
				batch.UpdateData (noteData, noteDocument);

			// Update folder data
			var folderData = new Dictionary<object, object> {
					{ "lastModified", FieldValue.ServerTimestamp },
					{ "notesCount", Folder.NotesCount }
				};
			batch.UpdateData (folderData, FolderDocument);

			batch.Commit (HandleCommitCompletion);

			void HandleCommitCompletion (NSError error)
			{
				Console.WriteLine (error?.LocalizedDescription);
			}
		}

		// Erase all note data from Firebase Cloud Firestore
		void DeleteNote ()
		{
			Folder.NotesCount--;

			if (IsNewNote)
				return;

			var folderData = new Dictionary<object, object> {
				{ "lastModified", FieldValue.ServerTimestamp },
				{ "notesCount", Folder.NotesCount }
			};

			// Delete note and update folder data as a single batch
			var batch = AppDelegate.Database.CreateBatch ();
			batch.DeleteDocument (noteDocument);
			batch.UpdateData (folderData, FolderDocument);

			batch.Commit (HandleCommitCompletion);

			void HandleCommitCompletion (NSError error)
			{
				Console.WriteLine (error?.LocalizedDescription);
			}
		}

		#endregion
	}
}

