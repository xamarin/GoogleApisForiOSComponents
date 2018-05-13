using System;
using System.Collections.Generic;
using System.Linq;

using CoreGraphics;
using Foundation;
using UIKit;

using Firebase.Crashlytics;

namespace CrashlyticsSample {
	public partial class ViewController : UIViewController {
		protected ViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			var button = new UIButton (UIButtonType.RoundedRect) {
				Frame = new CGRect (0, 0, 100, 30),
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			button.SetTitle ("Crash", UIControlState.Normal);
			button.TouchUpInside += Button_TouchUpInside;
			View.AddSubview (button);

			View.AddConstraint (NSLayoutConstraint.Create (button, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal,
								       View, NSLayoutAttribute.CenterX,
								       1, 0));
			View.AddConstraint (NSLayoutConstraint.Create (button, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal,
								       View, NSLayoutAttribute.CenterY,
								       1, 0));
		}

		void Button_TouchUpInside (object sender, EventArgs e)
		{
			var data = new Dictionary<object, object> {
				{ "Class name", nameof (ViewController)},
				{ "Method name", nameof (Button_TouchUpInside) }
			};
			var nsData = NSDictionary.FromObjectsAndKeys (data.Values.ToArray (), data.Keys.ToArray (), data.Keys.Count);

			Logging.NSLogCallerInformation ($"Hi! Maybe I'm about to crash! Here's some data: {nsData}", nameof (ViewController));
			Crashlytics.SharedInstance.SetObjectValue (nsData, "data");

			Crashlytics.SharedInstance.Crash ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
