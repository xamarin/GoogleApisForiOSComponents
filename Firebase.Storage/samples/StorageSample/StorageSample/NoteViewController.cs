using System;
using System.Collections.Generic;

using UIKit;
using CoreGraphics;
using Firebase.Database;
using Foundation;
using Firebase.Storage;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace StorageSample
{
	public partial class NoteViewController : UIViewController, IUITextViewDelegate
	{
		NSObject willShowNotificationHandle;
		NSObject willHideNotificationHandle;

		UIBarButtonItem space;
		UIBarButtonItem btnDone;
		UIBarButtonItem btnAddPhoto;
		UIBarButtonItem btnDeleteNote;
		UITextField txtTitle;

		// Reference that points to user's notes count node.
		// Points to https://MyDatabaseId.firebaseio.com/storage/users/«userUid»/notesCount
		DatabaseReference notesCountNode;

		// Reference that points to current note data.
		// Points to https://MyDatabaseId.firebaseio.com/storage/notes/«userUid»/«notesUid»
		DatabaseReference noteNode;

		// Reference that points to current note images.
		// Points to gs://MyDatabaseId.appspot.com/users/«userUid»/«noteUid»
		StorageReference storageImagesNode;

		bool photosAreVisible;
		bool deleteNote;

		public Note Note { get; set; }
		public nuint NotesCount { get; set; }

		public NoteViewController (IntPtr handle) : base (handle)
		{
		}

		#region View Lifecicle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			InitializeComponents ();
			RegisterToKeyboardNotifications ();
		}

		public override void ViewWillAppear (bool animated)
		{
			// If we are returning from picking a photo, we don't have to create anything again
			if (photosAreVisible) {
				photosAreVisible = false;
				base.ViewWillAppear (animated);
				return;
			}

			// If we are going to create a new note, generate a new note node
			if (Note == null) {
				CreateNote ();
			}

			// Show note data in UI
			txtTitle.Text = Note.Title;
			TxtContent.Text = Note.Content;
			CreateNodes ();

			LoadImagesInTextView ();

			base.ViewWillAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			// Lost focus in TextView to hide the keyboard
			TxtContent.ResignFirstResponder ();

			// Means that photos will appear, we are not closing the note UI
			// to execute Save or Delete task
			if (photosAreVisible) {
				base.ViewWillDisappear (animated);
				return;
			}

			var title = txtTitle.Text;
			var content = TxtContent.Text;

			// If we tap the delete button or we delete the content of note means that we need to delete the note.
			if (deleteNote || (string.IsNullOrWhiteSpace (title) && string.IsNullOrWhiteSpace (content)))
				DeleteNote ();
			else if (title != Note.Title || content != Note.Content) // If we made some change to note, update it
				SaveNote ();

			DeregisterToKeyboardNotifications ();

			base.ViewWillDisappear (animated);
		}

		#endregion

		// Initialize UI
		void InitializeComponents ()
		{
			TxtContent.Delegate = this;

			btnDone = new UIBarButtonItem ("Done", UIBarButtonItemStyle.Plain, btnDone_Clicked) {
				TintColor = UIColor.White
			};

			txtTitle = new UITextField (new CGRect (0, 0, NavigationController.NavigationBar.Bounds.Width, 22)) {
				Placeholder = "Type your title here",
				TextColor = UIColor.White,
				TextAlignment = UITextAlignment.Center
			};
			NavigationItem.TitleView = txtTitle;

			space = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace);

			btnAddPhoto = new UIBarButtonItem (UIBarButtonSystemItem.Camera, btnAddPhoto_Clicked) {
				TintColor = UIColor.White
			};

			btnDeleteNote = new UIBarButtonItem (UIBarButtonSystemItem.Trash, btnDeleteNote_Clicked) {
				TintColor = UIColor.White
			};

			SetToolbarItems (new [] { btnAddPhoto, space, btnDeleteNote }, false);
		}

		#region Keyboard Handle

		void RegisterToKeyboardNotifications ()
		{
			willShowNotificationHandle = NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.WillShowNotification, OnKeyboardNotification);
			willHideNotificationHandle = NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.WillHideNotification, OnKeyboardNotification);
		}

		void DeregisterToKeyboardNotifications ()
		{
			NSNotificationCenter.DefaultCenter.RemoveObserver (willShowNotificationHandle);
			NSNotificationCenter.DefaultCenter.RemoveObserver (willHideNotificationHandle);
		}

		// Resize the view depending on keyboard
		void OnKeyboardNotification (NSNotification notification)
		{
			if (!IsViewLoaded)
				return;

			// Check if the keyboard is becoming visible
			bool visible = notification.Name == UIKeyboard.WillShowNotification;

			// Start an animation, using values from the keyboard
			UIView.BeginAnimations ("AnimateForKeyboard");
			UIView.SetAnimationBeginsFromCurrentState (true);
			UIView.SetAnimationDuration (UIKeyboard.AnimationDurationFromNotification (notification));
			UIView.SetAnimationCurve ((UIViewAnimationCurve)UIKeyboard.AnimationCurveFromNotification (notification));

			// Pass the notification, calculating keyboard height, etc.
			if (visible) {
				CGRect keyboardFrame = UIKeyboard.FrameEndFromNotification (notification);
				//BtnKeyboardBottom.Constant = -keyboardFrame.Height;
				var navigationFrame = NavigationController.View.Frame;
				var newFrame = new CGRect (0, 0, navigationFrame.Width, UIScreen.MainScreen.Bounds.Height - keyboardFrame.Height);
				NavigationController.View.Frame = newFrame;
			} else {
				//BtnKeyboardBottom.Constant = 0;
				var navigationFrame = NavigationController.View.Frame;
				var newFrame = new CGRect (0, 0, navigationFrame.Width, UIScreen.MainScreen.Bounds.Height);
				NavigationController.View.Frame = newFrame;
			}

			View.LayoutIfNeeded ();

			// Commit the animation
			UIView.CommitAnimations ();
		}

		#endregion

		void CreateNodes ()
		{
			// Points to https://MyDatabaseId.firebaseio.com/storage/users/«userUid»/
			var userNode = AppDelegate.RootNode.GetChild ("users").GetChild (AppDelegate.UserUid);
			// Points to https://MyDatabaseId.firebaseio.com/storage/users/«userUid»/notesCount
			notesCountNode = userNode.GetChild ("notesCount");
			// Points to https://MyDatabaseId.firebaseio.com/storage/notes/«userUid»/«notesUid»
			noteNode = noteNode ?? AppDelegate.RootNode.GetChild ("notes").GetChild (AppDelegate.UserUid).GetChild (Note.Node);

			// Points to gs://MyDatabaseId.appspot.com/users/«userUid»/«noteUid»
			storageImagesNode = Storage.DefaultInstance.GetReferenceFromPath ($"users/{AppDelegate.UserUid}/{Note.Node}");
		}

		#region Controls Events

		// Hide keyboard
		void btnDone_Clicked (object sender, EventArgs e)
		{
			TxtContent.ResignFirstResponder ();
		}

		// A button to open photos to pick one
		void btnAddPhoto_Clicked (object sender, EventArgs e)
		{
			photosAreVisible = true;

			var viewController = Storyboard.InstantiateViewController ("PhotosViewControllerID") as PhotosViewController;
			viewController.ImageSelected += PhotoViewController_ImageSelected;
			var navigationController = new UINavigationController (viewController);
			navigationController.NavigationBar.BarTintColor = NavigationController.NavigationBar.BarTintColor;
			navigationController.NavigationBar.TintColor = NavigationController.NavigationBar.TintColor;
			navigationController.NavigationBar.TitleTextAttributes = NavigationController.NavigationBar.TitleTextAttributes;
			NavigationController.PresentViewController (navigationController, true, null);
		}

		// A button to delete the current note
		void btnDeleteNote_Clicked (object sender, EventArgs e)
		{
			deleteNote = true;
			NavigationController.PopViewController (true);
		}

		// When user picks a photo, add it to TextView
		void PhotoViewController_ImageSelected (object sender, PhotoEventArgs e)
		{
			
			var image = e.Image;

			// Get the location where we are going to insert the image
			var cursorLocation = TxtContent.SelectedRange.Location;

			// Resize the image if it's to big, to display it nicely in TextView
			nfloat sideLimit = UIScreen.MainScreen.Bounds.Width - 10;
			if (!VerifyImageSides (image, sideLimit))
				image = ResizeImage (image, sideLimit);

			// Save image location to update it if user types more text later.
			Note.ImagesInfo.Add (new ImageInfo {
				Id = e.ImageId,
				Location = cursorLocation
			});

			// Save the image in Firebase Storage
			SaveImageToStorage (e.ImageId, e.Image);
			// Save image in disk to load it in TextView more quickly
			SaveImageToDisk (e.ImageId, e.Image);

			// Insert image in TextView, adding 1 to text length
			InsertImageInText (TxtContent, e.ImageId, image, cursorLocation, false);

			// If text have an image after this location, we need to add 1 to their locations
			// because we have just inserted 1 char to text
			UpdateImagesLocation (cursorLocation, 1);
		}

		#endregion

		// Creates the note data, but not in Firebase Database, just in memory.
		void CreateNote ()
		{
			noteNode = AppDelegate.RootNode.GetChild ("notes").GetChild (AppDelegate.UserUid).GetChildByAutoId ();
			Note = new Note {
				Node = noteNode.Key,
				ImagesInfo = new List<ImageInfo> ()
			};
			++NotesCount;
		}

		// Save the data in Firebase Database.
		void SaveNote ()
		{
			ReplaceImagesWithinTextWithImagesIds ();

			// Create data to be saved in FIrebase Database.
			var title = txtTitle.Text.Trim ();
			var content = TxtContent.Text;
			var lastModified = AppDelegate.GetUtcTimestamp ();
			var created = Note.CreatedUnformatted ?? lastModified.ToString ();

			title = string.IsNullOrWhiteSpace (title) ? null : title;
			content = string.IsNullOrWhiteSpace (content) ? null : content;

			var imagesInfo = new NSMutableDictionary ();

			foreach (var imageInfo in Note.ImagesInfo) {
				var location = NSNumber.FromNInt (imageInfo.Location);
				imagesInfo [imageInfo.Id] = NSDictionary.FromObjectAndKey (location, new NSString ("location"));
			}

			object [] keys = { "content", "created", "lastModified", "negativeLastModified", "title", "imagesInfo" };
			object [] values = { content, double.Parse (created), lastModified, -lastModified, title, imagesInfo };
			var data = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);

			// Save data in note node.
			noteNode.SetValue (data);
			// Increment notes count in folder.
			notesCountNode.SetValue (NSNumber.FromNUInt (NotesCount));
		}

		// Erase all data from a note node and from Storage.
		void DeleteNote ()
		{
			noteNode.RemoveValue ();
			notesCountNode.SetValue (NSNumber.FromNUInt (--NotesCount));

			foreach (var imageInfo in Note.ImagesInfo)
				storageImagesNode.GetChild (imageInfo.Id).Delete ((error) => { });
		}

		// Replace the image ids with the original image.
		void LoadImagesInTextView ()
		{
			// Replace Ids with one space, to not modify images locations.
			// Later, that space will be replaced with the image.
			ReplaceImageIdsWithinTextWithSpaces ();

			foreach (var imageInfo in Note.ImagesInfo) {
				// Get image path on disk
				var imageFullPath = Path.Combine (GetTempFolderToNote (), imageInfo.Id);

				// Load image in TextView from disk, if not, download image from storage.
				if (File.Exists (imageFullPath))
					LoadImageFromDisk (imageInfo.Id, imageFullPath, imageInfo.Location);
				else
					LoadImageFromStorage (imageInfo.Id, imageFullPath, imageInfo.Location);
			}
		}

		// Get image from disk and add it to TextView.
		void LoadImageFromDisk (string imageId, string filePath, nint atLocation)
		{
			var image = UIImage.FromFile (filePath);

			// Resize image if it's to big, to display it nicely in TextView.
			nfloat sideLimit = UIScreen.MainScreen.Bounds.Width - 10;
			if (!VerifyImageSides (image, sideLimit))
				image = ResizeImage (image, sideLimit);

			// Insert image in TextView, but replacing the space where image id was.
			InsertImageInText (TxtContent, imageId, image, atLocation, true);
		}

		// Download image and save it on disk, then, load image from disk.
		void LoadImageFromStorage (string imageId, string imageFullPath, nint atLocation)
		{
			storageImagesNode.GetChild (imageId).WriteToFile (new NSUrl (imageFullPath, false), (url, error) => {
				if (error == null)
					LoadImageFromDisk (imageId, url.Path, atLocation);
			});
		}

		// Upload image to Firebase Storage.
		void SaveImageToStorage (string imageId, UIImage image)
		{
			var imageMetadata = new StorageMetadata {
				ContentType = "image/jpeg"
			};
			StorageReference storageImageNode = storageImagesNode.GetChild (imageId);
			storageImageNode.PutData (image.AsJPEG (), imageMetadata, (metadata, error) => {
				if (error != null) {
					Console.WriteLine (error.LocalizedDescription);
				}
			});
		}

		// Save the uploaded image to disk.
		void SaveImageToDisk (string imageId, UIImage image)
		{
			string imageFullPath = Path.Combine (GetTempFolderToNote (), imageId);

			NSData imageData = image.AsJPEG ();

			NSError error;
			imageData.Save (imageFullPath, false, out error);
		}

		// Create a temp folder to save note images.
		string GetTempFolderToNote ()
		{
			var path = Path.Combine (Path.GetTempPath (), Note.Node);

			if (!Directory.Exists (path))
				Directory.CreateDirectory (path);

			return path;
		}

		// Resize image proportionally to a nice size.
		UIImage ResizeImage (UIImage image, nfloat sideLimit)
		{
			var width = image.Size.Width;
			var height = image.Size.Height;
			var biggestSide = width > height ? width : height;
			var scale = biggestSide / sideLimit;

			return UIImage.FromImage (image.CGImage, scale, UIImageOrientation.Up);
		}

		// Verify if image is too big to be displayed nicely in TextView.
		bool VerifyImageSides (UIImage image, nfloat sideLimit)
		{
			return image.Size.Width <= sideLimit && image.Size.Height <= sideLimit;
		}

		// Insert desired image in text, generating length or by replacing a character.
		void InsertImageInText (UITextView textView, string filename, UIImage image, nint position, bool replaceCharacter)
		{
			var attachment = new NSCustomTextAttachment {
				Image = image,
				Name = filename
			};

			var attributedImage = NSAttributedString.FromAttachment (attachment);
			var textWithImage = new NSMutableAttributedString (textView.AttributedText);
			textWithImage.Replace (new NSRange (position, replaceCharacter ? 1 : 0), attributedImage);

			textView.AttributedText = textWithImage;
		}

		// When user deletes/replaces text, we need to verify
		// if deleted/replaced text contained a image.
		// If yes, we need to remove it from Storage and disk.
		void RemoveImagesIfExist (NSRange range)
		{
			var imagesInfo = Note.ImagesInfo.ToArray ();
			foreach (var imageInfo in imagesInfo) {
				if (imageInfo.Location >= range.Location && 
				    imageInfo.Location <= range.Location + range.Length - 1) {
					RemoveImage (imageInfo.Id);
				}
			}
		}

		// Removes image from Storage and disk.
		void RemoveImage (string imageId)
		{
			storageImagesNode.GetChild (imageId).Delete ((error) => { });
			Note.ImagesInfo.Remove (Note.ImagesInfo.Find (i => i.Id == imageId));

			var imageFullPath = Path.Combine (GetTempFolderToNote (), imageId);
			if (File.Exists (imageFullPath))
				File.Delete (imageFullPath);
		}

		// Updates images location if user typed or inserted text.
		void UpdateImagesLocation (nint afterThisLocation, nint valueToAdd)
		{
			foreach (var imageInfo in Note.ImagesInfo)
				if (imageInfo.Location > afterThisLocation)
					imageInfo.Location += valueToAdd;
		}

		// Replaces images with their ids in descending order.
		// This converts the Attributed Text to Plain text, 
		// so can be stored in Database without a problem
		void ReplaceImagesWithinTextWithImagesIds ()
		{
			Note.ImagesInfo = Note.ImagesInfo.OrderByDescending (i => i.Location).ToList ();

			foreach (var imageInfo in Note.ImagesInfo) {
				var attributedText = new NSMutableAttributedString (TxtContent.AttributedText);
				attributedText.Replace (new NSRange (imageInfo.Location, 1), $"[{imageInfo.Id}]");
				TxtContent.AttributedText = attributedText;
			}
		}

		// Replaces images Ids with spaces
		void ReplaceImageIdsWithinTextWithSpaces ()
		{
			foreach (var imageInfo in Note.ImagesInfo)
				TxtContent.Text = TxtContent.Text.Replace ($"[{imageInfo.Id}]", " ");
		}

		#region UITextView Delegate

		[Export ("textViewShouldBeginEditing:")]
		public bool ShouldBeginEditing (UITextView textView)
		{
			// Adds a button to resign TextView
			NavigationItem.RightBarButtonItem = btnDone;
			return true;
		}

		[Export ("textViewShouldEndEditing:")]
		public bool ShouldEndEditing (UITextView textView)
		{
			// Removes a button to resign TextView
			NavigationItem.RightBarButtonItem = null;
			return true;
		}

		[Export ("textView:shouldChangeTextInRange:replacementText:")]
		public bool ShouldChangeText (UITextView textView, NSRange range, string text)
		{
			// If user is deleting/replacing/adding text, 
			// verify if he/she deleted an image when deleting/replacing.
			// If so, delete the image from Storage.

			// Verify if we need to delete images when user delete text
			// Update images locations
			if (text == string.Empty) {
				RemoveImagesIfExist (range);
				UpdateImagesLocation (range.Location, -range.Length);
			} else if (range.Length > 0) {
				// Verify if we need to delete images when user replaces text
				// Update images locations
				RemoveImagesIfExist (range);
				UpdateImagesLocation (range.Location, text.Length - range.Length);
			} else {
				// If user is adding text, just update images locations
				UpdateImagesLocation (range.Location, text.Length);
			}

			return true;
		}

		#endregion
	}

	public class NSCustomTextAttachment : NSTextAttachment
	{
		public string Name { get; set; }
	}
}

