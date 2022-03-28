using Foundation;
using UIKit;
using System;
using System.Linq;
using Google.AppIndexing;

namespace AppIndexingSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		#warning Remember to change yourdomain name in Entitlements.plist file
		#warning Remember to change your iTunes ID
		// Your App ID from iTunes
		static readonly nuint iTunesId = 0;

		public override UIWindow Window {
			get;
			set;
		}

		NavigationController navController;

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{            
			navController = Window.RootViewController as NavigationController;

			// Register the app to Google System
			AppIndexing.SharedInstance.RegisterApp (iTunesId);

			return true;
		}

		public override bool ContinueUserActivity (UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
		{
			if (userActivity.ActivityType == NSUserActivityType.BrowsingWeb) {
				Console.WriteLine (userActivity.WebPageUrl.AbsoluteString);

				var detailsVC = new DetailsViewController {
					Gizmo = new Gizmo {
						Id = "Special",
						Name = "Universal Link Gizmo"
					}
				};
				navController.PushViewController (detailsVC, true);
			}

			return true;
		}
	}
}