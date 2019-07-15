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
    [Register ("UISearchAutocompleteViewController")]
    partial class UISearchAutocompleteViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblInformation { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LblInformation != null) {
                LblInformation.Dispose ();
                LblInformation = null;
            }
        }
    }
}