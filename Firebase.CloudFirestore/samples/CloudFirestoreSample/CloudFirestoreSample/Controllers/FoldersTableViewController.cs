using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using UIKit;
using CoreGraphics;

using Firebase.Auth;
using Foundation;
using System.Text;
using Firebase.CloudFirestore;
using System.Collections.Generic;

namespace CloudFirestoreSample
{
	public partial class FoldersTableViewController : UITableViewController
	{
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
			indicatorView.StartAnimating ();
			LoadFolders ();
			refreshControl.EndRefreshing ();
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
				if (alertCanceled)
					return;

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

		#region UITableView Data Source

		public override nint NumberOfSections (UITableView tableView) => 1;
		public override nint RowsInSection (UITableView tableView, nint section) => folders.Count;

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
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

			if (editingStyle == UITableViewCellEditingStyle.Delete) {
				Task.Factory.StartNew (async () => {
					try {
						var folder = folders [indexPath.Row];
						await DeleteFolder (folder);
						InvokeOnMainThread (() => tableView.DeleteRows (new [] { indexPath }, UITableViewRowAnimation.Automatic));
					} catch (NSErrorException ex) {
						InvokeOnMainThread (() => {
							UIAlertHelper.ShowMessage ("Error while deleting the folder", ex.Error.LocalizedDescription, NavigationController, "Ok");
						});
					} finally {
						InvokeOnMainThread (() => indicatorView.StopAnimating ());
					}
				});
			}
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
				Enabled = false
			};

			SetToolbarItems (new [] { space, btnIndicator, space, btnNewFolder }, false);

			refreshControl = new UIRefreshControl ();
			refreshControl.AddTarget (RefreshControl_ValueChanged, UIControlEvent.ValueChanged);
			TableView.RefreshControl = refreshControl;

			indicatorView.StartAnimating ();
		}

		void LoadFolders ()
		{
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
						indicatorView.StopAnimating ();
						UIAlertHelper.ShowMessage ("An error has ocurred...", ex.Error.LocalizedDescription, NavigationController, "Ok");
					});
				} catch (Exception ex) {
					Console.WriteLine (ex.Message);
				}
			}
		}

		//////////////////////
		//////////////////////
		//////////////////////
		//////////////////////

		void SignIn2 ()
		{
			auth.SignInAnonymously (HandleAuthResultHandler);

			void HandleAuthResultHandler (User user, NSError error)
			{
				if (error != null) {
					AuthErrorCode errorCode;
					if (IntPtr.Size == 8) // 64 bits devices
						errorCode = (AuthErrorCode)((long)error.Code);
					else // 32 bits devices
						errorCode = (AuthErrorCode)((int)error.Code);

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

					indicatorView.StopAnimating ();
					UIAlertHelper.ShowMessage (title, message.ToString (), NavigationController, buttonTitle);

					return;
				}

				AppDelegate.UserUid = user.Uid;
				InitializeFirestoreReferences ();
				AddUserToFirestoreIfNeeded2 ();
			}
		}

		// Create user in Firebase Cloud Firestore if not exist
		void AddUserToFirestoreIfNeeded2 ()
		{
			userDocument.GetDocument (HandleDocumentSnapshotHandler);

			void HandleDocumentSnapshotHandler (DocumentSnapshot snapshot, NSError error)
			{
				if (snapshot != null) return;

				var userData = new Dictionary<object, object> { { "created", FieldValue.ServerTimestamp } };
				userDocument.SetData (userData);
			}
		}

		//////////////////////
		//////////////////////
		//////////////////////
		//////////////////////


		async Task<bool> SignIn ()
		{
			try {
				User user = await auth.SignInAnonymouslyAsync ();
				AppDelegate.UserUid = user.Uid;
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
			if (user != null) return;

			var userData = new Dictionary<object, object> { { "created", FieldValue.ServerTimestamp } };
			await userDocument.SetDataAsync (userData);
		}

		// Get folder's data to be shown in TableView
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
			InvokeOnMainThread (() => {
				btnNewFolder.Enabled = true;
				indicatorView.StopAnimating ();
				TableView.ReloadData ();
			});
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
			await foldersCollection.GetDocument (folder.Id).DeleteDocumentAsync ();
			folders.Remove (folder);
		}

		bool VerifyIfFolderExists (string name) => folders.Exists (f => f.Name == name);

		// Verifies that name only contains alphanumeric, dashes, underscores and spaces
		bool VerifyFolderName (string name) => Regex.IsMatch (name, @"^[\w -]+$");

		#endregion
	}
}
