using System;
using MonoTouch.Dialog;
using UIKit;
using Firebase.Auth;
using CoreGraphics;
using Foundation;

namespace AuthSample
{
	public class PasswordLoginViewController : DialogViewController
	{
		PasswordContext passwordData;
		BindingContext context;
		UIActivityIndicatorView indicatorView;
		Auth auth;

		public PasswordLoginViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			passwordData = new PasswordContext ();
			context = new BindingContext (this, passwordData, "Password Login");

			Root = context.Root;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			auth = Auth.DefaultInstance;

			indicatorView = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge) {
				Frame = new CGRect (0, 0, 128, 128),
				BackgroundColor = UIColor.FromRGBA (127, 127, 127, 127),
				HidesWhenStopped = true,
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			View.Add (indicatorView);
			ApplyContraintsToIndicator ();
		}

		public void Login ()
		{
			context.Fetch ();

			var email = passwordData.Email;
			var password = passwordData.Password;

			if (string.IsNullOrWhiteSpace (email) ||
			    string.IsNullOrWhiteSpace (password)) {
				AppDelegate.ShowMessage ("Hey!", "Seems that some information is missing...", NavigationController);
				return;
			}

			indicatorView.StartAnimating ();
			View.EndEditing (true);

			auth.SignIn (email, password, SignInOnCompletion);
		}

		public void RegisterNewAccount ()
		{
			NavigationController.PushViewController (new NewAccountViewController (), true);
		}

		public void SendPasswordReset ()
		{
			context.Fetch ();

			var email = passwordData.Email;

			if (string.IsNullOrWhiteSpace (email)) {
				AppDelegate.ShowMessage ("Hey!", "Please, enter an email!", NavigationController);
				return;
			}

			indicatorView.StartAnimating ();
			View.EndEditing (true);

			auth.SendPasswordReset (email, SendPasswordResetOnCompletion);
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

			NavigationController.PushViewController (new UserViewController ("Firebase"), true);
		}

		void SendPasswordResetOnCompletion (NSError error)
		{
			indicatorView.StopAnimating ();

			if (error != null)
				AppDelegate.ShowMessage ("Email sent failed!", error.LocalizedDescription, NavigationController);
			else
				AppDelegate.ShowMessage ("Email sent!", $"An email has been sent to {passwordData.Email}", NavigationController);
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
