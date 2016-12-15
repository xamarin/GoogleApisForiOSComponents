using System;
using MonoTouch.Dialog;
using UIKit;
using Firebase.Auth;
using Foundation;
using CoreGraphics;

namespace AuthSample
{
	public class NewAccountViewController : DialogViewController
	{
		NewAccountContext newAccountData;
		BindingContext context;
		UIActivityIndicatorView indicatorView;

		public NewAccountViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			newAccountData = new NewAccountContext ();
			context = new BindingContext (this, newAccountData, "Register new account");

			Root = context.Root;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			indicatorView = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge) {
				Frame = new CGRect (0, 0, 128, 128),
				BackgroundColor = UIColor.FromRGBA (127, 127, 127, 127),
				HidesWhenStopped = true,
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			View.Add (indicatorView);
			ApplyContraintsToIndicator ();
		}

		public void RegisterNewAccount ()
		{
			context.Fetch ();

			var email = newAccountData.Email;
			var password = newAccountData.Password;
			var passwordVerify = newAccountData.PasswordVerify;

			if (string.IsNullOrWhiteSpace (email) ||
			    string.IsNullOrWhiteSpace (password) ||
			    string.IsNullOrWhiteSpace (passwordVerify)) {
				AppDelegate.ShowMessage ("Hey!", "Seems that some information is missing...", NavigationController);
				return;
			}

			if (password != passwordVerify) {
				AppDelegate.ShowMessage ("Hey!", "Passwords don't match. Please, verify.", NavigationController);
				return;
			}

			indicatorView.StartAnimating ();
			View.EndEditing (true);

			Auth.DefaultInstance.CreateUser (email, password, CreateUserOnCompletion);
		}

		void CreateUserOnCompletion (User user, NSError error)
		{
			indicatorView.StopAnimating ();

			if (error != null) {
				AuthErrorCode errorCode;
				if (IntPtr.Size == 8) // 64 bits devices
					errorCode = (AuthErrorCode)((long)error.Code);
				else // 32 bits devices
					errorCode = (AuthErrorCode)((int)error.Code);

				// Posible error codes that CreateUser method could throw
				// Visit https://firebase.google.com/docs/auth/ios/errors for more information
				switch (errorCode) {
				case AuthErrorCode.InvalidEmail:
				case AuthErrorCode.EmailAlreadyInUse:
				case AuthErrorCode.OperationNotAllowed:
				case AuthErrorCode.WeakPassword:
				default:
					AppDelegate.ShowMessage ("Could not login!", error.LocalizedDescription, NavigationController);
					break;
				}

				return;
			}

			NavigationController.PushViewController (new UserViewController ("Firebase"), true);
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
