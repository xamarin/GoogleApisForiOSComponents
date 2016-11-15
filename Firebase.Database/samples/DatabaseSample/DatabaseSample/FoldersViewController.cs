using System;

using UIKit;
using CoreGraphics;
using Foundation;
using Firebase.Auth;
using System.Collections.Generic;
using Firebase.Database;
using System.Text.RegularExpressions;

namespace DatabaseSample
{
	public partial class FoldersViewController : UITableViewController
	{
		UIBarButtonItem space;
		UIActivityIndicatorView indicatorView;
		UIBarButtonItem btnNewFolder;
		UIBarButtonItem btnRefresh;

		// Reference that points to user data.
		// Points to https://MyDatabaseId.firebaseio.com/users
		DatabaseReference userNode;

		// Reference that points to total of folders that user has.
		// Points to https://MyDatabaseId.firebaseio.com/users/«userUid»/foldersCount
		DatabaseReference foldersCountNode;

		// Reference that points to user's folders.
		// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/
		DatabaseReference foldersNode;

		// Get all user's folder ordered by "negativeLastModified" node.
		// Why we negative the last modified value? Because sorted values are in ascending order, from the lowest value to the highest.
		// In other words, in the first position comes the oldest modified folder and in the last position comes the most recent modified folder.
		// Firebase doesn't have a way to get list is descending order.
		// With this hack we invert the list, making folders to be sorted in "descending" order.
		DatabaseQuery foldersByDate;

		List<Folder> folders;
		nuint foldersCount;
		Auth auth;

		protected FoldersViewController (IntPtr handle) : base (handle)
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
			// If is the first time that view will appear, means you need to login anonymously,
			// otherwise, refresh the table
			if (string.IsNullOrWhiteSpace (AppDelegate.UserUid)) {
				auth.SignInAnonymously (SignInAnonymouslyCompleted);
			} else {
				GetFoldersCount ();
			}

			base.ViewWillAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			// Everytime that you change of view controller, clean node observers to avoid leaks of memory
			RemoveObserversFromNodes ();

			base.ViewWillDisappear (animated);
		}

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

			btnRefresh = new UIBarButtonItem (UIBarButtonSystemItem.Refresh);
			btnRefresh.Clicked += BtnRefresh_Clicked;
			NavigationItem.RightBarButtonItem = btnRefresh;

			indicatorView.StartAnimating ();
		}

		// Clean node observers to avoid leaks of memory 
		void RemoveObserversFromNodes ()
		{
			userNode.RemoveAllObservers ();
			foldersCountNode.RemoveAllObservers ();
			foldersNode.RemoveAllObservers ();
			foldersByDate.RemoveAllObservers ();
		}

		// If for some reason you cannot login anonymously, you have a refresh button to try again
		void BtnRefresh_Clicked (object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace (AppDelegate.UserUid)) {
				auth.SignInAnonymously (SignInAnonymouslyCompleted);
			} else {
				GetFoldersCount ();
			}
		}

		// Gets the folder name and verifies that folder name is written correctly
		void btnNewFolder_Clicked (object sender, EventArgs e)
		{
			UIAlertHelper.ShowMessage ("Create a new folder",
						   "Type a folder name.\nName can contain letters, numbers, spaces, dashes and underscores only",
						   NavigationController,
						   "Create",
						   new [] { "Folder name" },
						   (alertCanceled, textfieldInputs) => {
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

							   CreateFolder (folderName);
						   });
		}

		// Sign in Anonymously
		void SignInAnonymouslyCompleted (User user, NSError error)
		{
			if (error == null) {
				AppDelegate.UserUid = user.Uid;

				// Points to https://MyDatabaseId.firebaseio.com/users
				userNode = AppDelegate.RootNode.GetChild ("users").GetChild (AppDelegate.UserUid);

				VerifyIfUserExists ();
			} else {
				AuthErrorCode errorCode;
				if (IntPtr.Size == 8) // 64 bits devices
					errorCode = (AuthErrorCode)((long)error.Code);
				else // 32 bits devices
					errorCode = (AuthErrorCode)((int)error.Code);

				var title = "Anonymous sign-in failed!";

				// Posible error codes that SignInAnonymously method could throw
				// Visit https://firebase.google.com/docs/auth/ios/errors for more information
				switch (errorCode) {
				case AuthErrorCode.OperationNotAllowed:
					UIAlertHelper.ShowMessage (title,
								   "The app uses Anonymous sign-in to work correctly and seems to be disabled…\n" +
								   "Please, go to Firebase console and enable Anonymous login.\n" +
								   "Open «Application Output» in Xamarin Studio for more information.",
								   NavigationController,
								   "Ok, let me enable it!");
					Console.WriteLine ("Anonymous sign-in seems to be disabled. Please, visit the following link to know how " +
					                   "to enable it: https://firebase.google.com/docs/auth/ios/anonymous-auth#before-you-begin");
					break;
				case AuthErrorCode.NetworkError:
					UIAlertHelper.ShowMessage (title,
								   "Seems to be the first time that you run the sample and you don't have access to internet.\n" +
								   "The sample needs to run with internet at least once so you can create an Anonymous user.",
								   NavigationController,
					                           "Ok");
					break;
				default:
					UIAlertHelper.ShowMessage (title,
								   "An unknown error has ocurred…",
								   NavigationController,
					                           "Ok");
					break;
				}

				indicatorView.StopAnimating ();
			}
		}

		// Check in Firebase Database if user exists
		void VerifyIfUserExists ()
		{
			// Get value of user with ObserveEvent method
			userNode.ObserveEvent (DataEventType.Value, (snapshot) => {
				if (!snapshot.Exists) {
					CreateUser ();
				} else {
					// Points to https://MyDatabaseId.firebaseio.com/users/«userUid»/foldersCount
					foldersCountNode = userNode.GetChild ("foldersCount");
					// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/
					foldersNode = AppDelegate.RootNode.GetChild ("folders").GetChild (AppDelegate.UserUid);
					// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/ but sorted by "negativeLastModified" value
					foldersByDate = foldersNode.GetQueryOrderedByChild ("negativeLastModified");

					GetFoldersCount ();
				}
			});
		}

		// Create user in Firebase Database
		void CreateUser ()
		{
			// Create data to be saved in node
			var created = AppDelegate.GetUtcTimestamp ();
			foldersCount = 0;
			object [] keys = { "created", "foldersCount" };
			object [] values = { created, foldersCount };
			var data = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);

			// Keep data offline
			userNode.KeepSynced (true);
			// Save data in user node
			userNode.SetValue (data);

			// Points to https://MyDatabaseId.firebaseio.com/users/«userUid»/foldersCount
			foldersCountNode = userNode.GetChild ("foldersCount");
			// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/
			foldersNode = AppDelegate.RootNode.GetChild ("folders").GetChild (AppDelegate.UserUid);
			// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/ but sorted by "negativeLastModified" value
			foldersByDate = foldersNode.GetQueryOrderedByChild ("negativeLastModified");
		}
			                          
		// Creates the folder in Firebase Database
		void CreateFolder (string folderName)
		{
			// Create folder key node
			var folderNodeName = folderName.Replace (' ', '_');
			folderNodeName = char.ToLower (folderNodeName [0]) + folderNodeName.Substring (1, folderNodeName.Length - 1);

			// Create data to be saved in node
			var created = AppDelegate.GetUtcTimestamp ();
			object [] keys = { "created", "lastModified", "name", "negativeLastModified", "notesCount" };
			object [] values = { created, created, folderName, -created, 0 };
			var data = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);

			// Points to https://MyDatabaseId.firebaseio.com/folders/«userUid»/«folderUid»
			DatabaseReference folderNode = foldersNode.GetChild (folderNodeName);
			// Keep data offline
			folderNode.KeepSynced (true);
			// Save data in folder node 
			folderNode.SetValue (data);

			// Increment folders count in Firebase Database
			foldersCountNode.SetValue (NSNumber.FromNUInt (++foldersCount));

			GetFolders ();
		}

		void GetFoldersCount ()
		{
			indicatorView.StartAnimating ();

			// Get folders count to know when to stop and refresh the table view when we get folders sorted by "negativeLastModified"
			foldersCountNode.ObserveEvent (DataEventType.Value, (snapshot) => {
				foldersCount = snapshot.GetValue<NSNumber> ().NUIntValue;
				GetFolders ();
			});
		}

		// Get folder's data to be shown in TableView
		void GetFolders ()
		{
			// Clean folders list
			folders.Clear ();

			// If we don't have folders to show, refresh the table to show nothing
			if (foldersCount == 0) {
				btnNewFolder.Enabled = true;
				btnRefresh.Enabled = false;
				indicatorView.StopAnimating ();
				TableView.ReloadData ();
				return;
			}

			// Get folders ordered by "negativeLastModified" value
			foldersByDate.ObserveEvent (DataEventType.ChildAdded, (snapshot, prevKey) => {
				var data = snapshot.GetValue<NSDictionary> ();
				var created = (data ["created"] as NSNumber).StringValue;
				var lastModified = (data ["lastModified"] as NSNumber).StringValue;
				var name = data ["name"].ToString ();
				var notesCount = (data ["notesCount"] as NSNumber).UInt32Value;

				folders.Add (new Folder {
					Node = snapshot.Key,
					Name = name,
					Created = AppDelegate.ConvertUnformattedUtcDateToCurrentDate (created),
					CreatedUnformatted = created,
					LastModified = AppDelegate.ConvertUnformattedUtcDateToCurrentDate (lastModified),
					LastModifiedUnformatted = lastModified,
					NotesCount = notesCount
				});

				// If we finished reading folders, refresh the Table View
				if (folders.Count == (int)foldersCount) {
					btnNewFolder.Enabled = true;
					btnRefresh.Enabled = false;
					indicatorView.StopAnimating ();
					TableView.ReloadData ();
				}
			});
		}

		// Erase all data from a folder node
		void DeleteFolder (Folder folder)
		{
			foldersNode.GetChild (folder.Node).RemoveValue ();
			foldersCountNode.SetValue (NSNumber.FromNUInt (--foldersCount));
			folders.Remove (folder);
		}

		bool VerifyIfFolderExists (string name)
		{
			return folders.Exists (f => f.Name == name);
		}

		// Verifies that name only contains alphanumeric, dashes, underscores and spaces
		bool VerifyFolderName (string name)
		{
			return Regex.IsMatch (name, @"^[\w -]+$");
		}

		#region UITableView DataSource

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return Auth.DefaultInstance.CurrentUser != null ? folders.Count : 0;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var folder = folders [indexPath.Row]; 

			var cell = tableView.DequeueReusableCell (FolderCell.Key) as FolderCell;
			cell.TextLabel.Text = folder.Name;
			cell.DetailTextLabel.Text = folder.NotesCount.ToString ();

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
				var folder = folders [indexPath.Row];
				DeleteFolder (folder);
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
			var folder = folders [indexPath.Row];

			var viewController = Storyboard.InstantiateViewController ("NotesViewControllerID") as NotesViewController;
			viewController.Folder = folder;
			NavigationController.PushViewController (viewController, true);
		}

		#endregion
	}
}

