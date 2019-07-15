using System;

using UIKit;
using CoreTelephony;

using MonoTouch.Dialog;
using Firebase.Auth;
using Foundation;
using CoreGraphics;
using UserNotifications;

namespace AuthSample
{
	public class PhoneNumberViewController : DialogViewController
	{
		StringElement lblCountry;
		EntryElement txtPhoneNumber;
		StyledStringElement btnVerify;
		CountriesViewController countriesViewController;
		UIActivityIndicatorView indicatorView;

		public PhoneNumberViewController () : base (UITableViewStyle.Grouped, null, true)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitializeComponents ();
			ShowInformationMessage ();
		}

		void InitializeComponents ()
		{
			countriesViewController = new CountriesViewController ();
			countriesViewController.CountrySelected += CountriesViewController_CountrySelected;

			var networkInfo = new CTTelephonyNetworkInfo ();
			var carrier = networkInfo.SubscriberCellularProvider;

			var countryCode = carrier.IsoCountryCode.ToUpper ();
			var countryName = CountriesManager.SharedInstance.Countries [countryCode];
			var countryFlag = CountriesManager.SharedInstance.CountryFlags [countryCode];
			var phoneCode = CountriesManager.SharedInstance.PhoneCodes [countryCode];
			phoneCode = phoneCode == string.Empty ? "" : $"+{phoneCode}";

			lblCountry = new StringElement ($"{countryFlag} {countryName}", () => OpenViewController (countriesViewController)) {
				Alignment = UITextAlignment.Center
			};
			txtPhoneNumber = new EntryElement (phoneCode, "Enter you phone number", string.Empty) {
				TextAlignment = UITextAlignment.Left,
				KeyboardType = UIKeyboardType.PhonePad
			};
			btnVerify = new StyledStringElement ("Send Verification Code", SendVerificationCode) {
				Alignment = UITextAlignment.Center,
				Font = UIFont.FromName ("System-Bold", 13),
				BackgroundColor = UIColor.White
			};

			Root = new RootElement ("Phone Number Authentication") {
				new Section ("Tap to change the country") {
					lblCountry,
					txtPhoneNumber
				},
				new Section {
					btnVerify
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

		void ShowInformationMessage ()
		{
			AppDelegate.ShowMessage ("Warning!",
						 "If you use phone sign-in, you might receive an SMS message for verification and standard rates apply.",
						 NavigationController);
		}

		void SendVerificationCode ()
		{
			var phoneCode = txtPhoneNumber.Caption;
			var phoneNumber = txtPhoneNumber.Value;

			if (string.IsNullOrWhiteSpace (phoneNumber)) {
				AppDelegate.ShowMessage ("Invalid Phone Number",
							 "Please, enter a number.",
							 NavigationController);
				return;
			}

			View.EndEditing (true);

			indicatorView.StartAnimating ();

			PhoneAuthProvider.DefaultInstance.VerifyPhoneNumber ($"{phoneCode}{phoneNumber}", null, VerifyPhoneNumberOnCompletion);
		}

		void VerifyPhoneNumberOnCompletion (string verificationId, NSError error)
		{
			indicatorView.StopAnimating ();

			if (error != null) {
				AppDelegate.ShowMessage ("An error has ocurred...", error.LocalizedDescription, NavigationController);
				return;
			}

			NSUserDefaults.StandardUserDefaults.SetString (verificationId, "AuthVerificationID");
			OpenViewController (new VerificationCodeViewController ());
		}

		void OpenViewController (UIViewController viewController)
		{
			NavigationController.PushViewController (viewController, true);
		}

		void CountriesViewController_CountrySelected (object sender, CountrySelectedEventArgs e)
		{
			lblCountry.Caption = e.CountryFlag;
			lblCountry.Value = e.CountryName;
			txtPhoneNumber.Caption = e.PhoneCode == string.Empty ? "" : $"+{e.PhoneCode}";
			ReloadData ();
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
