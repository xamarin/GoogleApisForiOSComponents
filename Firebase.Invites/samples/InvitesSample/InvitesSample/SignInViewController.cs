using System;

using UIKit;
using Google.SignIn;
using Firebase.Analytics;
using Foundation;

namespace InvitesSample
{
	public partial class SignInViewController : UIViewController, ISignInDelegate, ISignInUIDelegate
	{
		public SignInViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			// Before a user can send Invites, the user must be signed in with their Google Account.
			BtnSignIn.Enabled = false;
			SignIn.SharedInstance.ClientID = App.DefaultInstance.Options.ClientId;
			SignIn.SharedInstance.Delegate = this;
			SignIn.SharedInstance.UIDelegate = this;
			SignIn.SharedInstance.SignInUserSilently ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public void DidSignIn (SignIn signIn, GoogleUser user, NSError error)
		{
			if (error == null && user != null) {
				NavigationController.PushViewController (new InviteViewController (), true);
			} else {
				BtnSignIn.Enabled = true;
			}
		}

		[Export ("signIn:didDisconnectWithUser:withError:")]
		public void DidDisconnect (SignIn signIn, GoogleUser user, NSError error)
		{
			NavigationController.PopToRootViewController (true);
		}
	}
}


