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

		DatabaseReference userNode;
		DatabaseReference foldersCountNode;
		DatabaseReference foldersNode;
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
			if (string.IsNullOrWhiteSpace (AppDelegate.UserUid)) {
				auth.SignInAnonymously (SignInAnonymouslyCompleted);
			} else {
				GetFoldersCount ();
			}

			base.ViewWillAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
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

		void RemoveObserversFromNodes ()
		{
			userNode.RemoveAllObservers ();
			foldersCountNode.RemoveAllObservers ();
			foldersNode.RemoveAllObservers ();
			foldersByDate.RemoveAllObservers ();
		}

		void BtnRefresh_Clicked (object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace (AppDelegate.UserUid)) {
				auth.SignInAnonymously (SignInAnonymouslyCompleted);
			} else {
				GetFoldersCount ();
			}
		}

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

		void SignInAnonymouslyCompleted (User user, NSError error)
		{
			if (error == null) {
				AppDelegate.UserUid = user.Uid;
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
			                           
		void VerifyIfUserExists ()
		{
			userNode.ObserveEvent (DataEventType.Value, (snapshot) => {
				if (!snapshot.Exists) {
					CreateUser ();
				} else {
					foldersCountNode = userNode.GetChild ("foldersCount");
					foldersNode = AppDelegate.RootNode.GetChild ("folders").GetChild (AppDelegate.UserUid);
					foldersByDate = foldersNode.GetQueryOrderedByChild ("negativeLastModified");
					GetFoldersCount ();
				}
			});
		}

		void CreateUser ()
		{
			var created = AppDelegate.GetUtcTimestamp ();
			foldersCount = 0;
			object [] keys = { "created", "foldersCount" };
			object [] values = { created, foldersCount };
			var data = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);

			userNode.KeepSynced (true);
			userNode.SetValue (data);

			foldersCountNode = userNode.GetChild ("foldersCount");
			foldersNode = AppDelegate.RootNode.GetChild ("folders").GetChild (AppDelegate.UserUid);
			foldersByDate = foldersNode.GetQueryOrderedByChild ("negativeLastModified");
		}
			                           
		void CreateFolder (string folderName)
		{
			var folderNodeName = folderName.Replace (' ', '_');
			folderNodeName = char.ToLower (folderNodeName [0]) + folderNodeName.Substring (1, folderNodeName.Length - 1);

			var created = AppDelegate.GetUtcTimestamp ();
			object [] keys = { "created", "lastModified", "name", "negativeLastModified", "notesCount" };
			object [] values = { created, created, folderName, -created, 0 };
			var data = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);

			DatabaseReference folderNode = foldersNode.GetChild (folderNodeName);
			folderNode.KeepSynced (true);
			folderNode.SetValue (data);

			foldersCountNode.SetValue (NSNumber.FromNUInt (++foldersCount));

			GetFolders ();
		}

		void GetFoldersCount ()
		{
			indicatorView.StartAnimating ();

			foldersCountNode.ObserveEvent (DataEventType.Value, (snapshot) => {
				foldersCount = snapshot.GetValue<NSNumber> ().NUIntValue;
				GetFolders ();
			});
		}

		void GetFolders ()
		{
			folders.Clear ();

			if (foldersCount == 0) {
				btnNewFolder.Enabled = true;
				btnRefresh.Enabled = false;
				indicatorView.StopAnimating ();
				TableView.ReloadData ();
				return;
			}

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

				if (folders.Count == (int)foldersCount) {
					btnNewFolder.Enabled = true;
					btnRefresh.Enabled = false;
					indicatorView.StopAnimating ();
					TableView.ReloadData ();
				}
			});
		}

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

