using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Google.Maps;

namespace GoogleMapsSample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			MapServices.ProvideApiKey ("<Get your Api Key at https://code.google.com/apis/console/>");

			window = new UIWindow (UIScreen.MainScreen.Bounds) {
				RootViewController = new MapViewController ()
			};
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

