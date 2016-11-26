using System;

using UIKit;
using Foundation;
using Photos;
using CoreGraphics;

namespace StorageSample
{
	public partial class PhotosViewController : UICollectionViewController, IUICollectionViewDelegateFlowLayout
	{
		UIBarButtonItem btnClose;

		PHFetchResult images;
		PHImageManager imageManager;
		CGSize thumbnailSize;

		public event EventHandler<PhotoEventArgs> ImageSelected;

		public PhotosViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			InitializeComponents ();

			var scale = UIScreen.MainScreen.Scale;
			var cellSize = (Layout as UICollectionViewFlowLayout).ItemSize;
			var width = UIScreen.MainScreen.Bounds.Width * cellSize.Width / 320;
			thumbnailSize = new CGSize (width, width);

			GetPhotos ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			ClearEvent (ImageSelected);

			base.ViewDidDisappear (animated);
		}

		void InitializeComponents ()
		{
			btnClose = new UIBarButtonItem ("Close", UIBarButtonItemStyle.Plain, (sender, e) => {
				DismissViewController (true, null);
			});
			NavigationItem.RightBarButtonItem = btnClose;
			Title = "Pick a photo";
		}

		void GetPhotos ()
		{
			if (PHPhotoLibrary.AuthorizationStatus == PHAuthorizationStatus.Authorized) {
				imageManager = PHImageManager.DefaultManager;

				PHFetchOptions options = new PHFetchOptions {
					SortDescriptors = new [] { new NSSortDescriptor ("creationDate", false) }
				};
				images = PHAsset.FetchAssets (PHAssetMediaType.Image, options);
				CollectionView.ReloadData ();
			}
		}

		async void RequestAccessToPhotoLibrary ()
		{
			switch (PHPhotoLibrary.AuthorizationStatus) {
			case PHAuthorizationStatus.NotDetermined:
				await PHPhotoLibrary.RequestAuthorizationAsync ();
				GetPhotos ();
				break;

			case PHAuthorizationStatus.Authorized:
				break;

			default:
				UIAlertHelper.ShowMessage ("Cannot access to Photo Library!",
							   "Please, check in Settings app that you have permission to access to Photos.",
							   NavigationController,
							   "Ok",
							   null,
							   null,
							   null,
							   new [] { "Go to settings" },
				                           new Action[] { OpenSettings });
				break;
			}
		}

		void OpenSettings ()
		{
			UIApplication.SharedApplication.OpenUrl (new NSUrl (UIApplication.OpenSettingsUrlString));
		}

		void ClearEvent<T> (EventHandler<T> eventToClear) where T : EventArgs
		{
			var eventList = eventToClear.GetInvocationList ();
			foreach (var anEvent in eventList)
				eventToClear -= (EventHandler<T>)anEvent;
		}

		#region UITableView DataSource

		public override nint NumberOfSections (UICollectionView collectionView)
		{
			return 1;
		}

		public override nint GetItemsCount (UICollectionView collectionView, nint section)
		{
			return PHPhotoLibrary.AuthorizationStatus == PHAuthorizationStatus.Authorized ? images.Count : 1;
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			if (PHPhotoLibrary.AuthorizationStatus == PHAuthorizationStatus.Authorized) {
				var asset = images [indexPath.Item] as PHAsset;

				var cell = collectionView.DequeueReusableCell (PhotoCell.Key, indexPath) as PhotoCell;
				cell.AssetId = asset.LocalIdentifier;

				imageManager.RequestImageForAsset (asset, thumbnailSize, PHImageContentMode.AspectFill, null, (result, info) => {
					// The cell may have been recycled by the time this handler gets called;
					// set the cell's thumbnail image only if it's still showing the same asset.
					if (cell.AssetId == asset.LocalIdentifier)
						cell.Image = result;
				});

				return cell;
			}

			return collectionView.DequeueReusableCell ("PermissionCell", indexPath) as UICollectionViewCell;
		}

		#endregion

		#region UITableView Delegate

		public override void ItemSelected (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = collectionView.CellForItem (indexPath) as PhotoCell;

			if (cell != null) {
				var asset = images [indexPath.Item] as PHAsset;
				imageManager.RequestImageForAsset (asset, PHImageManager.MaximumSize, PHImageContentMode.AspectFill, null, (result, info) => {
					var args = new PhotoEventArgs {
						Image = result,
						ImageId = AppDelegate.GetUtcTimestamp ().ToString ()
					};

					ImageSelected?.Invoke (this, args);
					DismissViewController (true, null);
				});
			} else {
				RequestAccessToPhotoLibrary ();
			}
		}

		#endregion

		#region UITableView Delegate Flow Layout

		[Export ("collectionView:layout:insetForSectionAtIndex:")]
		public UIEdgeInsets GetInsetForSection (UICollectionView collectionView, UICollectionViewLayout layout, nint section)
		{
			return new UIEdgeInsets (0, 0, 0, 0);
		}

		[Export ("collectionView:layout:sizeForItemAtIndexPath:")]
		public CGSize GetSizeForItem (UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
		{
			return thumbnailSize;
		}

		#endregion
	}

	public class PhotoEventArgs : EventArgs
	{
		public UIImage Image { get; set; }
		public string ImageId { get; set; }
	}
}
