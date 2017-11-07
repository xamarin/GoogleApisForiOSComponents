using System;

using UIKit;
using Google.Places.Picker;
using Google.Places;
using Foundation;
using CoreGraphics;
using System.Threading;
using System.Threading.Tasks;

namespace GooglePlacesSample
{
	public partial class PhotosViewController : UIViewController, IUICollectionViewSource, IUICollectionViewDelegateFlowLayout, IPlacePickerViewControllerDelegate
	{
		#region Fields

		PlacePickerViewController placePickerViewController;
		PlacesClient placesClient;
		PlacePhotoMetadata [] photosMetadata;

		#endregion

		#region Constructors

		public PhotosViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			var config = new PlacePickerConfig (null);
			placePickerViewController = new PlacePickerViewController (config) {
				Delegate = this,
				ModalPresentationStyle = UIModalPresentationStyle.Popover
			};
			placesClient = PlacesClient.SharedInstance;
			photosMetadata = new PlacePhotoMetadata [0];
		}

		public override void ViewWillLayoutSubviews ()
		{
			PhotosCollectionView.CollectionViewLayout.InvalidateLayout ();
		}

		#endregion

		#region User Interactions

		partial void BtnSelect_Tapped (UIBarButtonItem sender)
		{
			placePickerViewController.PopoverPresentationController.BarButtonItem = NavigationItem.RightBarButtonItem;
			PresentViewController (placePickerViewController, true, null);
		}

		#endregion

		#region CollectionView Data Source

		[Export ("numberOfSectionsInCollectionView:")]
		public nint NumberOfSections (UICollectionView collectionView) => 1;
		public nint GetItemsCount (UICollectionView collectionView, nint section) => photosMetadata.Length;

		public UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var photoMetadata = photosMetadata [indexPath.Row];
			var cell = collectionView.DequeueReusableCell (PhotoCollectionViewCell.Key, indexPath) as PhotoCollectionViewCell;
			cell.PlaceImage = UIImage.FromFile ("thumbnail.png");

			if (cell.CancellationTokenSource != null &&
			   !cell.CancellationTokenSource.IsCancellationRequested)
				cell.CancellationTokenSource.Cancel ();

			var cancellationTokenSource = new CancellationTokenSource ();
			cell.CancellationTokenSource = cancellationTokenSource;
			cell.PlaceName = photoMetadata.Attributions;

			var cancellationToken = cancellationTokenSource.Token;

			DownloadPlacePhoto (cell, photoMetadata, cancellationToken);

			return cell;
		}

		#endregion

		#region PlacePickerViewController Delegate

		public void DidPickPlace (PlacePickerViewController viewController, Place place)
		{
			DismissViewController (true, null);
			placesClient.LookUpPhotos (place.Id, LookUpPhotosResult);

			void LookUpPhotosResult (PlacePhotoMetadataList photos, NSError error)
			{
				if (error != null) {
					AppDelegate.ShowMessage ("Error", error.LocalizedDescription, NavigationController);
					return;
				}

				photosMetadata = photos.Results;
				PhotosCollectionView.ReloadData ();
			}
		}

		#endregion

		#region CollectionView Delegate Flow Layout

		[Export ("collectionView:layout:sizeForItemAtIndexPath:")]
		public CGSize GetSizeForItem (UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
		{
			return new CGSize (collectionView.Bounds.Width, collectionView.Bounds.Height);
		}

		#endregion

		#region Internal Functionality

		void DownloadPlacePhoto (PhotoCollectionViewCell cell, PlacePhotoMetadata photoMetadata, CancellationToken cancellationToken)
		{
			cell.StartActivity ();
			Task.Factory.StartNew (() => placesClient.LoadPlacePhoto (photoMetadata, AssignPhoto), cancellationToken);

			void AssignPhoto (UIImage photo, NSError error)
			{
				try {
					cancellationToken.ThrowIfCancellationRequested ();
					cell.PlaceImage = photo;
				} catch (OperationCanceledException ex) {
					Console.WriteLine ($"Get Thumbnail cancelled: {ex.Message}");
				} catch (Exception ex) {
					Console.WriteLine (ex.Message);
				} finally {
					cell.StopActivity ();
				}
			}
		}

		#endregion
	}
}

