using System;

using UIKit;
using Google.SignIn;
using Foundation;
using Firebase.Core;
using Firebase.Auth;

namespace AuthSample
{
	public partial class SignInLoginViewController : UIViewController, ISignInDelegate
	{
		public SignInLoginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			BtnSignIn.Enabled = false;
			SignIn.SharedInstance.PresentingViewController = this;
			SignIn.SharedInstance.ClientId = App.DefaultInstance.Options.ClientId;
			SignIn.SharedInstance.Delegate = this;

			if (SignIn.SharedInstance.HasPreviousSignIn)
				SignIn.SharedInstance.RestorePreviousSignIn ();
			else
				BtnSignIn.Enabled = true;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public void DidSignIn (SignIn signIn, GoogleUser user, NSError error)
		{
			if (error == null && user != null) {
				// Get Google ID token and Google access token and exchange them for a Firebase credential
				var authentication = user.Authentication;
				var credential = GoogleAuthProvider.GetCredential (authentication.IdToken, authentication.AccessToken);

				// Authenticate with Firebase using the credential
				Auth.DefaultInstance.SignInAndRetrieveDataWithCredential (credential, SignInOnCompletion);
			} else {
				BtnSignIn.Enabled = true;
				AppDelegate.ShowMessage ("Could not login!", error.LocalizedDescription, NavigationController);
			}
		}

		[Export ("signIn:didDisconnectWithUser:withError:")]
		public void DidDisconnect (SignIn signIn, GoogleUser user, NSError error)
		{
			NavigationController.PopToRootViewController (true);
		}

		void SignInOnCompletion (AuthDataResult authResult, NSError error)
		{
			if (error != null) {
				AuthErrorCode errorCode;
				if (IntPtr.Size == 8) // 64 bits devices
					errorCode = (AuthErrorCode)((long)error.Code);
				else // 32 bits devices
					errorCode = (AuthErrorCode)((int)error.Code);

				// Posible error codes that SignIn method with credentials could throw
				// Visit https://firebase.google.com/docs/auth/ios/errors for more information
				switch (errorCode) {
				case AuthErrorCode.InvalidCredential:
				case AuthErrorCode.InvalidEmail:
				case AuthErrorCode.OperationNotAllowed:
				case AuthErrorCode.EmailAlreadyInUse:
				case AuthErrorCode.UserDisabled:
				case AuthErrorCode.WrongPassword:
				default:
					AppDelegate.ShowMessage ("Could not login!", error.LocalizedDescription, NavigationController);
					break;
				}

				return;
			}

			NavigationController.PushViewController (new UserViewController ("Google"), true);
		}
	}
}

