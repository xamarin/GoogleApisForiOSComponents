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
    [Register ("PlacePickerViewController")]
    partial class PlacePickerViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtnPopover { get; set; }

        [Action ("BtnModel_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnModel_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnNavigation_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnNavigation_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnPopover_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnPopover_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BtnPopover != null) {
                BtnPopover.Dispose ();
                BtnPopover = null;
            }
        }
    }
}