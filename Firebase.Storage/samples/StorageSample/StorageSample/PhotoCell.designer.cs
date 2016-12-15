// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace StorageSample
{
	[Register ("PhotoCell")]
	partial class PhotoCell
	{
		[Outlet]
		UIKit.UIImageView ImgThumbnail { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImgThumbnail != null) {
				ImgThumbnail.Dispose ();
				ImgThumbnail = null;
			}
		}
	}
}
