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
	[Register ("SignInViewController")]
	partial class SignInViewController
	{
		[Outlet]
		UIKit.UILabel bgText { get; set; }

		[Outlet]
		Google.SignIn.SignInButton signInButton { get; set; }

		[Action ("unwindToSignIn:")]
		partial void UnwindToSignIn (UIKit.UIStoryboardSegue sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (bgText != null) {
				bgText.Dispose ();
				bgText = null;
			}

			if (signInButton != null) {
				signInButton.Dispose ();
				signInButton = null;
			}
		}
	}
}
