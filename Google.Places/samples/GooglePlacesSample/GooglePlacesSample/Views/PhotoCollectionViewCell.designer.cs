// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace GooglePlacesSample
{
    [Register ("PhotoCollectionViewCell")]
    partial class PhotoCollectionViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView DownloadActivity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImgPlace { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblPlace { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DownloadActivity != null) {
                DownloadActivity.Dispose ();
                DownloadActivity = null;
            }

            if (ImgPlace != null) {
                ImgPlace.Dispose ();
                ImgPlace = null;
            }

            if (LblPlace != null) {
                LblPlace.Dispose ();
                LblPlace = null;
            }
        }
    }
}