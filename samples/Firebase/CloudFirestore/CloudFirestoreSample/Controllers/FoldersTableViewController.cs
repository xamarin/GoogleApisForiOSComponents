using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using CoreGraphics;
using Foundation;
using UIKit;

using Firebase.Auth;
using Firebase.CloudFirestore;

namespace CloudFirestoreSample
{
	public partial class FoldersTableViewController : UITableViewController
	{
		#region Class Variables

		UIBarButtonItem space;
		UIBarButtonItem btnNewFolder;
		UIRefreshControl refreshControl;
		UIActivityIndicatorView indicatorView;

		Auth auth;
		List<Folder> folders;

		// Reference that points to user data.
		DocumentReference userDocument;

		// Reference that points to user's folders
		CollectionReference foldersCollection;

		#endregion

		#region Constructors

		public FoldersTableViewController (IntPtr handle) : base (handle)
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

			LoadFolders ();
		}

		#endregion

		#region User Interaction

		// If for some reason you cannot login anonymously, you can try again by pulling down the Table View
		void RefreshControl_ValueChanged (object sender, EventArgs e)
		{
			TableView.UserInteractionEnabled = false;
			LoadFolders ();
		}

		// Gets the folder name and verifies that folder name is written correctly
		void btnNewFolder_Clicked (object sender, EventArgs e)
		{
			indicatorView.StartAnimating ();

			UIAlertHelper.ShowMessage ("Create a new folder",
						   "Type a folder name.\nName can contain letters, numbers, spaces, dashes and underscores only",
						   NavigationController,
						   "Create",
						   new [] { "Folder name" },
						   HandleUIAlertControllerTextFieldResult);

			void HandleUIAlertControllerTextFieldResult (bool alertCanceled, string [] textfieldInputs)
			{
				if (alertCanceled) {
					indicatorView.StopAnimating ();
					return;
				}

				var folderName = textfieldInputs [0].Trim ();

				if (string.IsNullOrWhiteSpace (folderName)) {
					UIAlertHelper.ShowMessage ("Empty name!", "A folder name cannot be a space or an empty name.", NavigationController, "Ok");
					return;
				}

				if (!VerifyFolderName (folderName)) {
					UIAlertHelper.ShowMessage ("Bad folder name!", "A name can contain letters, numbers, spaces, dashes and underscores only.", NavigationController, "Ok");
					return;
				}

				if (VerifyIfFolderExists (folderName)) {
					UIAlertHelper.ShowMessage ("Folder exists!", "A folder with that name already exists.", NavigationController, "Ok");
					return;
				}

				Task.Factory.StartNew (async () => {
					try {
						await CreateFolder (folderName);
					} catch (NSErrorException ex) {
						InvokeOnMainThread (() => {
							UIAlertHelper.ShowMessage ("Error while creating new folder", ex.Error.LocalizedDescription, NavigationController, "Ok");
						});
					} finally {
						InvokeOnMainThread (() => indicatorView.StopAnimating ());
					}
				});
			}
		}

		#endregion

		#region Navigation

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			if (segue.Identifier != "DefaultSegue")
				return;

			var notesTableViewController = segue.DestinationViewController as NotesTableViewController;
			notesTableViewController.Folder = folders [TableView.IndexPathForSelectedRow.Row];
			notesTableViewController.FoldersCollection = foldersCollection;
		}

		#endregion

		#region UITableView Data Source

		public override nint NumberOfSections (UITableView tableView) => 1;
		public override nint RowsInSection (UITableView tableView, nint section) => folders.Count == 0 ? 1 : folders.Count;

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			if (folders.Count == 0)
				return tableView.DequeueReusableCell ("DefaultTableViewCell", indexPath);

			var folder = folders [indexPath.Row];
			var cell = tableView.DequeueReusableCell (FolderTableViewCell.Key, indexPath);
			cell.TextLabel.Text = folder.Name;
			cell.DetailTextLabel.Text = folder.NotesCount.ToString ();

			return cell;
		}

		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath) => true;

		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			indicatorView.StartAnimating ();

			if (editingStyle != UITableViewCellEditingStyle.Delete)
				return;

			// Delete the folder from the TableView so user cannot get access to it while deleting
			var folder = folders [indexPath.Row];
			folders.Remove (folder);

			if (folders.Count == 0)
				tableView.ReloadRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);
			else
				tableView.DeleteRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);

			Task.Factory.StartNew (async () => {
				try {
					// Remove the folder from the Cloud Firestore
					await DeleteFolder (folder);
				} catch (NSErrorException ex) {
					// If something fails while deleting the folder, add it again to the TableView
					folders.Insert (indexPath.Row, folder);
					InvokeOnMainThread (() => {
						UIAlertHelper.ShowMessage ("Error while deleting the folder", ex.Error.LocalizedDescription, NavigationController, "Ok", () => {
							// Due subcollections (in this case, the folder's notes) must be manually deleted,
							// some of them could have been deleted when we were trying to delete the folder
							UIAlertHelper.ShowMessage ("Error while deleting the folder", "Some notes could have been deleted during the process.\nTry deleting the folder again to finish the process.", NavigationController, "Ok");
						});

						if (folders.Count == 1)
							tableView.ReloadRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);
						else
							tableView.InsertRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);
					});
				} finally {
					folder = null;
					InvokeOnMainThread (() => indicatorView.StopAnimating ());
				}
			});
		}

		#endregion

		#region Internal Functionality

		void InitializeComponents ()
		{
			folders = new List<Folder> ();
			auth = Auth.DefaultInstance;

			space = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);

			indicatorView = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.White) {
				Frame = new CGRect (0, 0, 20, 20),
				HidesWhenStopped = true
			};
			var btnIndicator = new UIBarButtonItem (indicatorView);

			btnNewFolder = new UIBarButtonItem ("New Folder", UIBarButtonItemStyle.Plain, btnNewFolder_Clicked) {
				TintColor = UIColor.White,
			};

			SetToolbarItems (new [] { space, btnIndicator, space, btnNewFolder }, false);

			refreshControl = new UIRefreshControl ();
			refreshControl.AddTarget (RefreshControl_ValueChanged, UIControlEvent.ValueChanged);
			TableView.RefreshControl = refreshControl;
		}

		void LoadFolders ()
		{
			indicatorView.StartAnimating ();
			btnNewFolder.Enabled = false;
			Task.Factory.StartNew (LoadFoldersAsync);

			async Task LoadFoldersAsync ()
			{
				// Verify if you have already logged in to Firebase Anonymously
				if (string.IsNullOrWhiteSpace (AppDelegate.UserUid))
					if (!await SignIn ())
						return;

				InitializeFirestoreReferences ();

				try {
					await AddUserToFirestoreIfNeeded ();
					await GetFolders ();
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
						btnNewFolder.Enabled = true;
						TableView.UserInteractionEnabled = true;
					});
				}
			}
		}

		async Task<bool> SignIn ()
		{
			try {
				AuthDataResult authData = await auth.SignInAnonymouslyAsync ();
				AppDelegate.UserUid = authData.User.Uid;
				return true;

			} catch (NSErrorException ex) {
				AuthErrorCode errorCode;
				if (IntPtr.Size == 8) // 64 bits devices
					errorCode = (AuthErrorCode)((long)ex.Error.Code);
				else // 32 bits devices
					errorCode = (AuthErrorCode)((int)ex.Error.Code);

				var title = "Anonymous sign-in failed!";
				var buttonTitle = "Ok";
				var message = new StringBuilder ();

				// Posible error codes that SignInAnonymously method could throw
				// Visit https://firebase.google.com/docs/auth/ios/errors for more information
				switch (errorCode) {
				case AuthErrorCode.OperationNotAllowed:
					message.AppendLine ("The app uses Anonymous sign-in to work correctly and seems to be disabled…");
					message.AppendLine ("Please, go to Firebase console and enable Anonymous login.");
					message.Append ("Open «Application Output» in Xamarin Studio for more information.");
					buttonTitle = "Ok, let me enable it!";
					Console.WriteLine ("Anonymous sign-in seems to be disabled. Please, visit the following link to know how " +
							   "to enable it: https://firebase.google.com/docs/auth/ios/anonymous-auth#before-you-begin");
					break;
				case AuthErrorCode.NetworkError:
					message.AppendLine ("Seems to be the first time that you run the sample and you don't have access to internet.");
					message.Append ("The sample needs to run with internet at least once so you can create an Anonymous user.");
					break;
				default:
					message.Append ("An unknown error has ocurred…");
					break;
				}

				InvokeOnMainThread (() => {
					indicatorView.StopAnimating ();
					UIAlertHelper.ShowMessage (title, message.ToString (), NavigationController, buttonTitle);
				});

				return false;
			}
		}

		void InitializeFirestoreReferences ()
		{
			userDocument = AppDelegate.Database.GetDocument ($"notes_app/{AppDelegate.UserUid}");
			foldersCollection = userDocument.GetCollection ("folders");
		}

		// Create user in Firebase Cloud Firestore if not exist
		async Task AddUserToFirestoreIfNeeded ()
		{
			var user = await userDocument.GetDocumentAsync ();
			if (user.Exists) return;

			var userData = new Dictionary<object, object> { { "created", FieldValue.ServerTimestamp } };
			await userDocument.SetDataAsync (userData);
		}

		// Get folders data to be shown in TableView
		async Task GetFolders ()
		{
			folders.Clear ();

			var foldersQuery = await foldersCollection.OrderedBy ("lastModified", true)
								  .GetDocumentsAsync ();

			foreach (var folder in foldersQuery.Documents) {
				var data = folder.Data;
				var created = data ["created"] as NSDate;
				var lastModified = data ["lastModified"] as NSDate;
				var name = data ["name"].ToString ();
				var notesCount = (data ["notesCount"] as NSNumber).NUIntValue;

				folders.Add (new Folder {
					Id = folder.Id,
					Name = name,
					Created = AppDelegate.GetFormattedDate (created),
					LastModified = AppDelegate.GetFormattedDate (lastModified),
					NotesCount = notesCount
				});
			}

			// If we finished reading folders, refresh the Table View
			InvokeOnMainThread (() => TableView.ReloadData ());
		}

		// Creates the folder in Firebase Firestore
		async Task CreateFolder (string folderName)
		{
			// Create folder key node
			var folderId = folderName.Replace (' ', '_');
			folderId = char.ToLower (folderId [0]) + folderId.Substring (1, folderId.Length - 1);

			// Create data to be saved in node
			var created = FieldValue.ServerTimestamp;
			var folderData = new Dictionary<object, object> {
				{ "created", created },
				{ "lastModified", created },
				{ "name", folderName },
				{ "notesCount", 0 }
			};

			// Save data in folders collection
			await foldersCollection.GetDocument (folderId).SetDataAsync (folderData);
			await GetFolders ();
		}

		// Erase all data from a folder document
		async Task DeleteFolder (Folder folder)
		{
			var folderDocument = foldersCollection.GetDocument (folder.Id);

			// Note: Deleting a document does not delete its subcollections!
			// If you want to delete documents in subcollections when 
			// deleting a document, you must do so manually.
			var notesCollection = folderDocument.GetCollection ("notes");
			await DeleteNotes (folder, folderDocument, notesCollection, 10);

			await folderDocument.DeleteDocumentAsync ();
		}

		async Task DeleteNotes (Folder folder, DocumentReference folderDocument, CollectionReference notesCollection, int batchSize)
		{
			// Limit query to avoid out-of-memory errors on large collections.
			// When deleting a collection guaranteed to fit in memory, batching can be avoided entirely.
			var notes = await notesCollection.LimitedTo (batchSize).GetDocumentsAsync ();

			// There's nothing to delete.
			if (notes.Count == 0)
				return;

			var batch = notesCollection.Firestore.CreateBatch ();

			foreach (var note in notes.Documents)
				batch.DeleteDocument (note.Reference);

			var folderData = new Dictionary<object, object> {
				{ "notesCount", folder.NotesCount - (nuint)notes.Count }
			};
			batch.UpdateData (folderData, folderDocument);

			await batch.CommitAsync ();

			folder.NotesCount -= (nuint)notes.Count;

			await DeleteNotes (folder, folderDocument, notesCollection, batchSize);
		}

		bool VerifyIfFolderExists (string name) => folders.Exists (f => f.Name == name);

		// Verifies that name only contains alphanumeric, dashes, underscores and spaces
		bool VerifyFolderName (string name) => Regex.IsMatch (name, @"^[\w -]+$");

		#endregion
	}
}
