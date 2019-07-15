// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AppInviteSample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton disconnectButton { get; set; }

		[Outlet]
		UIKit.UIButton inviteButton { get; set; }

		[Outlet]
		Google.SignIn.SignInButton signInButton { get; set; }

		[Outlet]
		UIKit.UIButton signOutButton { get; set; }

		[Outlet]
		UIKit.UILabel statusText { get; set; }

		[Action ("disconnectTapped:")]
		partial void disconnectTapped (Foundation.NSObject sender);

		[Action ("inviteTapped:")]
		partial void inviteTapped (Foundation.NSObject sender);

		[Action ("signOutTapped:")]
		partial void signOutTapped (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (disconnectButton != null) {
				disconnectButton.Dispose ();
				disconnectButton = null;
			}

			if (signOutButton != null) {
				signOutButton.Dispose ();
				signOutButton = null;
			}

			if (signInButton != null) {
				signInButton.Dispose ();
				signInButton = null;
			}

			if (inviteButton != null) {
				inviteButton.Dispose ();
				inviteButton = null;
			}

			if (statusText != null) {
				statusText.Dispose ();
				statusText = null;
			}
		}
	}
}
