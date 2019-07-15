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
	[Register ("AutocompleteBaseViewController")]
    partial class AutocompleteBaseViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblInformation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl SgmColors { get; set; }

        [Action ("BtnShow_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnShow_TouchUpInside (UIKit.UIButton sender);

        [Action ("SgmColors_ValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SgmColors_ValueChanged (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (LblInformation != null) {
                LblInformation.Dispose ();
                LblInformation = null;
            }

            if (SgmColors != null) {
                SgmColors.Dispose ();
                SgmColors = null;
            }
        }
    }
}