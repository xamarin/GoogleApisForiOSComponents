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

namespace GooglePlacesSample
{
    [Register ("PhotosViewController")]
    partial class PhotosViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BtnSelect { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImgSelected { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblInformation { get; set; }

        [Action ("BtnSelect_Tapped:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSelect_Tapped (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (BtnSelect != null) {
                BtnSelect.Dispose ();
                BtnSelect = null;
            }

            if (ImgSelected != null) {
                ImgSelected.Dispose ();
                ImgSelected = null;
            }

            if (LblInformation != null) {
                LblInformation.Dispose ();
                LblInformation = null;
            }
        }
    }
}