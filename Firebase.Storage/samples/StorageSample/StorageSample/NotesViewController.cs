using System;

using UIKit;
using CoreGraphics;
using Firebase.Database;
using Firebase.Auth;
using System.Collections.Generic;
using Foundation;
using Firebase.Storage;

namespace StorageSample
{
	public partial class NotesViewController : UITableViewController
	{
		UIBarButtonItem space;
		UIActivityIndicatorView indicatorView;
		UIBarButtonItem btnNewNote;
		UILabel lblNotesCount;
		UIBarButtonItem btnRefresh;

		// Reference that points to user data.
		// Points to https://MyDatabaseId.firebaseio.com/storage/users/
		DatabaseReference userNode;

		// Reference that points to folder's notes count node.
		// Points to https://MyDatabaseId.firebaseio.com/storage/users/«userUid»/notesCount
		DatabaseReference notesCountNode;

		// Reference that points to user's notes.
		// Points to https://MyDatabaseId.firebaseio.com/storage/notes/«userUid»/
		DatabaseReference notesNode;

		// Get all user's notes ordered by "negativeLastModified" node.
		// Why we negative the last modified value? Because sorted values are in ascending order, from the lowest value to the highest.
		// In other words, in the first position comes the oldest modified note and in the last position comes the most recent modified note.
		// Firebase doesn't have a way to get list is descending order.
		// With this hack we invert the list, making notes to be sorted in "descending" order.
		DatabaseQuery notesByDate;

		// Reference that points to current note images.
		// Points to gs://MyDatabaseId.appspot.com/users/«userUid»/«noteUid»
		StorageReference storageImagesNode;

		List<Note> notes;
		nuint notesCount;
		Auth auth;

		public NotesViewController (IntPtr handle) : base (handle)
		{
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
				GetNotesCount ();
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
			notes = new List<Note> ();

			auth = Auth.DefaultInstance;

			space = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);

			indicatorView = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.White) {
				Frame = new CGRect (0, 0, 20, 20),
				HidesWhenStopped = true
			};
			var btnIndicator = new UIBarButtonItem (indicatorView);

			lblNotesCount = new UILabel (new CGRect (0, 0, 50, 15)) {
				Font = UIFont.SystemFontOfSize (12)
			};

			lblNotesCount.Text = $"0 notes";
			var btnNotesCount = new UIBarButtonItem (lblNotesCount);

			btnNewNote = new UIBarButtonItem (UIBarButtonSystemItem.Compose, btnNewNote_Clicked) {
				TintColor = UIColor.White,
				Enabled = false
			};

			SetToolbarItems (new [] { space, space, btnIndicator, btnNotesCount, space, space, btnNewNote }, false);

			btnRefresh = new UIBarButtonItem (UIBarButtonSystemItem.Refresh);
			btnRefresh.Clicked += BtnRefresh_Clicked;
			NavigationItem.RightBarButtonItem = btnRefresh;

			indicatorView.StartAnimating ();
		}

		void CreateNodes ()
		{
			// Points to https://MyDatabaseId.firebaseio.com/storage/users/«userUid»/notesCount
			notesCountNode = userNode.GetChild ("notesCount");
			// Points to https://MyDatabaseId.firebaseio.com/storage/notes/«userUid»/
			notesNode = AppDelegate.RootNode.GetChild ("notes").GetChild (AppDelegate.UserUid);
			// Points to https://MyDatabaseId.firebaseio.com/storage/notes/«userUid»/ but sorted by "negativeLastModified" value
			notesByDate = notesNode.GetQueryOrderedByChild ("negativeLastModified");
		}

		// Clean node observers to avoid leaks of memory 
		void RemoveObserversFromNodes ()
		{
			userNode.RemoveAllObservers ();
			notesNode.RemoveAllObservers ();
			notesCountNode.RemoveAllObservers ();
			notesByDate.RemoveAllObservers ();
		}

		// If for some reason you cannot login anonymously, you have a refresh button to try again
		void BtnRefresh_Clicked (object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace (AppDelegate.UserUid)) {
				auth.SignInAnonymously (SignInAnonymouslyCompleted);
			} else {
				GetNotesCount ();
			}
		}

		// Go to next View Controller to write a note
		void btnNewNote_Clicked (object sender, EventArgs e)
		{
			var viewController = Storyboard.InstantiateViewController ("NoteViewControllerID") as NoteViewController;
			viewController.NotesCount = notesCount;
			NavigationController.PushViewController (viewController, true);
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
								   "The sample needs internet to create an Anonymous user.",
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
					CreateNodes ();
					GetNotesCount ();
				}
			});
		}

		// Create user in Firebase Database
		void CreateUser ()
		{
			// Create data to be saved in node
			var created = AppDelegate.GetUtcTimestamp ();
			notesCount = 0;
			object [] keys = { "created", "notesCount" };
			object [] values = { created, notesCount };
			var data = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);

			// Save data in user node
			userNode.SetValue (data);

			CreateNodes ();
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

			lblNotesCount.Text = $"{notesCount} note{notesCount != 1 ? "s" : ""}";

			btnNewNote.Enabled = true;

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
				var info = data ["imagesInfo"] as NSDictionary;

				var imagesInfo = new List<ImageInfo> ();

				if (info != null) {
					foreach (NSObject key in info.Keys) {
						var id = key.ToString ();
						var imageInfo = info [key] as NSDictionary;
						var location = imageInfo ["location"] as NSNumber;
						imagesInfo.Add (new ImageInfo {
							Id = id,
							Location = location.NIntValue
						});
					}
				}

				notes.Add (new Note {
					Node = snapshot.Key,
					Content = content,
					Created = AppDelegate.ConvertUnformattedUtcDateToCurrentDate (created),
					CreatedUnformatted = created,
					LastModified = AppDelegate.ConvertUnformattedUtcDateToCurrentDate (lastModified),
					LastModifiedUnformatted = lastModified,
					Title = title,
					ImagesInfo = imagesInfo
				});

				// If we finished reading folders, refresh the Table View
				if (notes.Count == (int)notesCount)
					TableView.ReloadData ();
			});
		}

		// Erase all data from a note node and Storage
		void DeleteNote (Note note)
		{
			// Points to gs://MyDatabaseId.appspot.com/users/«userUid»/«noteUid»
			storageImagesNode = Storage.DefaultInstance.GetReferenceFromPath ($"users/{AppDelegate.UserUid}/{note.Node}");

			foreach (var imageInfo in note.ImagesInfo)
				storageImagesNode.GetChild (imageInfo.Id).Delete ((error) => { });

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
			cell.DateText = note.LastModified;

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
			viewController.Note = note;
			viewController.NotesCount = notesCount;
			NavigationController.PushViewController (viewController, true);
		}

		#endregion
	}
}

