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

namespace AppIndexingSample
{
	[Register ("DetailsViewController")]
	partial class DetailsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelGizmo { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (labelGizmo != null) {
				labelGizmo.Dispose ();
				labelGizmo = null;
			}
		}
	}
}
