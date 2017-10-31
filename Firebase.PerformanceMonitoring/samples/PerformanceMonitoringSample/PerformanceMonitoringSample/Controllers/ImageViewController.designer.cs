// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PerformanceMonitoringSample
{
    [Register ("ImageViewController")]
    partial class ImageViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView ActIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BtnRetry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImgPicture { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ActIndicator != null) {
                ActIndicator.Dispose ();
                ActIndicator = null;
            }

            if (BtnRetry != null) {
                BtnRetry.Dispose ();
                BtnRetry = null;
            }

            if (ImgPicture != null) {
                ImgPicture.Dispose ();
                ImgPicture = null;
            }
        }
    }
}