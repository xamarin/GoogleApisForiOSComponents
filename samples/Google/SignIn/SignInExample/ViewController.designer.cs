// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SignInExample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton disconnectButton { get; set; }

		[Outlet]
		Google.SignIn.SignInButton signInButton { get; set; }

		[Outlet]
		UIKit.UIButton signOutButton { get; set; }

		[Outlet]
		UIKit.UILabel statusText { get; set; }

		[Action ("didTapDisconnect:")]
		partial void didTapDisconnect (Foundation.NSObject sender);

		[Action ("didTapSignOut:")]
		partial void didTapSignOut (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (signInButton != null) {
				signInButton.Dispose ();
				signInButton = null;
			}

			if (signOutButton != null) {
				signOutButton.Dispose ();
				signOutButton = null;
			}

			if (disconnectButton != null) {
				disconnectButton.Dispose ();
				disconnectButton = null;
			}

			if (statusText != null) {
				statusText.Dispose ();
				statusText = null;
			}
		}
	}
}
