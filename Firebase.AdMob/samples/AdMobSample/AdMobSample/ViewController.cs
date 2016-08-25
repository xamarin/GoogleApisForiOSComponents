using System;

using UIKit;

using Firebase.InstanceID;
using Firebase.Analytics;
using Google.MobileAds;

namespace AdMobSample
{
	public partial class ViewController : UIViewController
	{
		protected ViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			var type1 = typeof (InstanceId);
			var type2 = typeof (Analytics);
			var type3 = typeof (MobileAds);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

