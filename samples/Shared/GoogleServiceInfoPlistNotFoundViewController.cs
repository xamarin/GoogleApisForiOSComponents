using System;

using UIKit;

namespace Xamarin.iOS.Shared.ViewControllers{
	public class GoogleServiceInfoPlistNotFoundViewController : UIViewController {
		public GoogleServiceInfoPlistNotFoundViewController ()
		{
		}

		public override void ViewDidLoad ()
		{
            base.ViewDidLoad ();

            View.BackgroundColor = UIColor.FromRGB(238, 238, 238);

			// You can download your GoogleService-Info.plist file following the next link:
			// https://firebase.google.com/docs/ios/setup
			var label = new UILabel () {
				Text = "The GoogleService-Info.plist file was not found... :(\n\n" +
				"Please, go to the Firebase console and download it into the sample folder. " +
				"There's no need to add a reference for the file into the sample project. It already has a reference for the file.\n\n" +
				"Thank you!",
				TextColor = UIColor.Black,
				Lines = 0,
				TextAlignment = UITextAlignment.Center,
				TranslatesAutoresizingMaskIntoConstraints = false
			};
            View.AddSubview (label);

			label.CenterXAnchor.ConstraintEqualTo (View.CenterXAnchor).Active = true;
			label.CenterYAnchor.ConstraintEqualTo (View.CenterYAnchor).Active = true;
			label.LeadingAnchor.ConstraintEqualTo (View.LeadingAnchor).Active = true;
			label.TrailingAnchor.ConstraintEqualTo (View.TrailingAnchor).Active = true;
        }
	}
}

