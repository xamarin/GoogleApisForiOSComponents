using System;
using MonoTouch.Dialog;
using UIKit;
using Foundation;
using Firebase.Auth;
using CoreGraphics;

namespace AuthSample
{
	public class VerificationCodeViewController : DialogViewController
	{
		EntryElement txtVerificationCode;
		StyledStringElement btnLogin;
		UIActivityIndicatorView indicatorView;

		public VerificationCodeViewController () : base (UITableViewStyle.Grouped, null, true)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			txtVerificationCode = new EntryElement ("Code", "Enter the verification code", string.Empty) {
				TextAlignment = UITextAlignment.Left,
				KeyboardType = UIKeyboardType.NumberPad
			};
			btnLogin = new StyledStringElement ("Log in", LogIn) {
				Alignment = UITextAlignment.Center,
				Font = UIFont.FromName ("System-Bold", 13),
				BackgroundColor = UIColor.White
			};

			Root = new RootElement ("Verification Code") {
				new Section {
					txtVerificationCode,
					btnLogin
				}
			};

			indicatorView = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge) {
				Frame = new CGRect (0, 0, 128, 128),
				BackgroundColor = UIColor.FromRGBA (127, 127, 127, 127),
				HidesWhenStopped = true,
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			View.Add (indicatorView);
			ApplyContraintsToIndicator ();
		}

		void LogIn ()
		{
			var verificationCode = txtVerificationCode.Value;

			if (string.IsNullOrWhiteSpace (verificationCode)) {
				AppDelegate.ShowMessage ("Invalid Code", "Please, enter a valid code.", NavigationController);
				return;
			}

			View.EndEditing (true);

			indicatorView.StartAnimating ();

			var verificationId = NSUserDefaults.StandardUserDefaults.StringForKey ("AuthVerificationID");
			var credential = PhoneAuthProvider.DefaultInstance.GetCredential (verificationId, verificationCode);

			Auth.DefaultInstance.SignIn (credential, SignInOnCompletion);
		}

		void SignInOnCompletion (User user, NSError error)
		{
			indicatorView.StopAnimating ();

			if (error != null) {
				AuthErrorCode errorCode;
				if (IntPtr.Size == 8) // 64 bits devices
					errorCode = (AuthErrorCode)((long)error.Code);
				else // 32 bits devices
					errorCode = (AuthErrorCode)((int)error.Code);

				// Posible error codes that SignIn method with email and password could throw
				// Visit https://firebase.google.com/docs/auth/ios/errors for more information
				switch (errorCode) {
				case AuthErrorCode.OperationNotAllowed:
				case AuthErrorCode.InvalidEmail:
				case AuthErrorCode.UserDisabled:
				case AuthErrorCode.WrongPassword:
				default:
					AppDelegate.ShowMessage ("Could not login!", error.LocalizedDescription, NavigationController);
					break;
				}

				return;
			}

			NSUserDefaults.StandardUserDefaults.RemoveObject ("AuthVerificationID");

			NavigationController.PushViewController (new UserViewController ("Firebase2"), true);
		}

		void ApplyContraintsToIndicator ()
		{
			View.AddConstraint (NSLayoutConstraint.Create (indicatorView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, View, NSLayoutAttribute.Width, 1, 0));
			View.AddConstraint (NSLayoutConstraint.Create (indicatorView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, View, NSLayoutAttribute.Height, 1, 0));
			View.AddConstraint (NSLayoutConstraint.Create (indicatorView, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, View, NSLayoutAttribute.CenterX, 1, 0));
			View.AddConstraint (NSLayoutConstraint.Create (indicatorView, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, View, NSLayoutAttribute.CenterY, 1, 0));
		}
	}
}
