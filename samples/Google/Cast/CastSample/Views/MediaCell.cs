using System;

using Foundation;
using UIKit;

namespace CastSample
{
	public partial class MediaCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("MediaCellId");

		#region Properties

		public string Title { 
			get { return LblTitle.Text; }
			set { LblTitle.Text = value; }
		}

		public string Studio { 
			get { return LblStudio.Text; } 
			set { LblStudio.Text = value; }
		}

		public UIImage Thumbnail { 
			get { return ImgThumbnail.Image; }
			set { ImgThumbnail.Image = value; }
		}

		#endregion

		protected MediaCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
