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

namespace InstanceIDSample
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonDeleteInstanceId { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonGenerateInstanceId { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelInstanceId { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (buttonDeleteInstanceId != null) {
				buttonDeleteInstanceId.Dispose ();
				buttonDeleteInstanceId = null;
			}
			if (buttonGenerateInstanceId != null) {
				buttonGenerateInstanceId.Dispose ();
				buttonGenerateInstanceId = null;
			}
			if (labelInstanceId != null) {
				labelInstanceId.Dispose ();
				labelInstanceId = null;
			}
		}
	}
}
