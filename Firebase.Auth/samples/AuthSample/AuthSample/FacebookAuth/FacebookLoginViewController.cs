using System;

using UIKit;
using System.Collections.Generic;
using Firebase.Auth;
using Facebook.CoreKit;
using Foundation;
using Facebook.LoginKit;

namespace AuthSample
{
	public partial class FacebookLoginViewController : UIViewController
	{
		// This permission is set by default, even if you don't add it, but FB recommends to add it anyway
		List<string> readPermissions = new List<string> { "public_profile" };

		public FacebookLoginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			// Handle actions once the user is logged in
			BtnLogin.Completed += BtnLogin_Completed;
			BtnLogin.ReadPermissions = readPermissions.ToArray ();

			if (AccessToken.CurrentAccessToken != null) {
				var credential = FacebookAuthProvider.GetCredential (AccessToken.CurrentAccessToken.TokenString);
				Auth.DefaultInstance.SignIn (credential, SignInOnCompletion);
			}
		}

		void BtnLogin_Completed (object sender, LoginButtonCompletedEventArgs e)
		{
			if (e.Error != null) {
				// Handle if there was an error
				AppDelegate.ShowMessage ("Could not login!", e.Error.Description, NavigationController);
				return;
			}

			if (e.Result.IsCancelled) {
				// Handle if the user cancelled the login request
				AppDelegate.ShowMessage ("Could not login!", "The user cancelled the login", NavigationController);
				return;
			}

			// Get access token for the signed-in user and exchange it for a Firebase credential
			var credential = FacebookAuthProvider.GetCredential (AccessToken.CurrentAccessToken.TokenString);

			// Authenticate with Firebase using the credential
			Auth.DefaultInstance.SignIn (credential, SignInOnCompletion);
		}

		void SignInOnCompletion (User user, NSError error)
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

			NavigationController.PushViewController (new UserViewController ("Facebook"), true);
		}
	}
}

