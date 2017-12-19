// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace PerformanceMonitoringSample
{
	[Register ("ImageViewController")]
	partial class ImageViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIActivityIndicatorView ActIndicator { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem BtnDownloadRetry { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIImageView ImgPicture { get; set; }

		[Outlet]
		UIKit.UISegmentedControl SgmDownloadTool { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ActIndicator != null) {
				ActIndicator.Dispose ();
				ActIndicator = null;
			}

			if (BtnDownloadRetry != null) {
				BtnDownloadRetry.Dispose ();
				BtnDownloadRetry = null;
			}

			if (ImgPicture != null) {
				ImgPicture.Dispose ();
				ImgPicture = null;
			}

			if (SgmDownloadTool != null) {
				SgmDownloadTool.Dispose ();
				SgmDownloadTool = null;
			}
		}
	}
}
