// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MLKitVisionSample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIImageView ImgSample { get; set; }

		[Outlet]
		UIKit.UITextView TxtData { get; set; }

		[Action ("BtnCamera_Clicked:")]
		partial void BtnCamera_Clicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ImgSample != null) {
				ImgSample.Dispose ();
				ImgSample = null;
			}

			if (TxtData != null) {
				TxtData.Dispose ();
				TxtData = null;
			}
		}
	}
}
