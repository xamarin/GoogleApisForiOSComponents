// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DynamicLinksSample
{
    [Register ("InitialViewController")]
    partial class InitialViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtnLink1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtnLink2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtnLink3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblCopied { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BtnLink1 != null) {
                BtnLink1.Dispose ();
                BtnLink1 = null;
            }

            if (BtnLink2 != null) {
                BtnLink2.Dispose ();
                BtnLink2 = null;
            }

            if (BtnLink3 != null) {
                BtnLink3.Dispose ();
                BtnLink3 = null;
            }

            if (LblCopied != null) {
                LblCopied.Dispose ();
                LblCopied = null;
            }
        }
    }
}