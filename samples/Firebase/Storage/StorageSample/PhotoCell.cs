using System;

using Foundation;
using UIKit;

namespace StorageSample
{
	public partial class PhotoCell : UICollectionViewCell
	{
		public static readonly NSString Key = new NSString ("PhotoCell");

		public UIImage Image {
			get { return ImgThumbnail.Image; }
			set { ImgThumbnail.Image = value; }
		}

		public string AssetId { get; set; }

		protected PhotoCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void PrepareForReuse ()
		{
			base.PrepareForReuse ();

			ImgThumbnail.Image = null;
			Image = null;
		}
	}
}
