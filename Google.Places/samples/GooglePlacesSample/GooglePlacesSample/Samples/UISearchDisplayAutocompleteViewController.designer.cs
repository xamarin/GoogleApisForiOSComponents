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
    [Register ("UISearchDisplayAutocompleteViewController")]
    partial class UISearchDisplayAutocompleteViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblInformation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchDisplayController searchDisplayController { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar SrcPlace { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LblInformation != null) {
                LblInformation.Dispose ();
                LblInformation = null;
            }

            if (searchDisplayController != null) {
                searchDisplayController.Dispose ();
                searchDisplayController = null;
            }

            if (SrcPlace != null) {
                SrcPlace.Dispose ();
                SrcPlace = null;
            }
        }
    }
}