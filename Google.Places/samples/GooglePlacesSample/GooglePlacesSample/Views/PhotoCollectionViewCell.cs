using System;

using Foundation;
using UIKit;
using System.Threading;

namespace GooglePlacesSample
{
	public partial class PhotoCollectionViewCell : UICollectionViewCell
	{
		#region Cell Identifier

		public static readonly NSString Key = new NSString ("PhotoCollectionViewCell");

		#endregion

		#region Properties

		public UIImage PlaceImage {
			get => ImgPlace.Image;
			set => ImgPlace.Image = value;
		}

		public NSAttributedString PlaceName {
			get => LblPlace.AttributedText;
			set => LblPlace.AttributedText = value;
		}

		public CancellationTokenSource CancellationTokenSource { get; set; }

		#endregion

		#region Constructors

		protected PhotoCollectionViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		#endregion

		#region Activity Indicator

		public void StartActivity () => DownloadActivity.StartAnimating ();
		public void StopActivity () => DownloadActivity.StopAnimating ();

		#endregion
	}
}
