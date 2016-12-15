using System;

using Foundation;
using UIKit;

using Firebase.Analytics;
using Firebase.RemoteConfig;

namespace RemoteConfigSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			// Use Firebase library to configure APIs
			App.Configure ();
			// Enabling developer mode, allows for frequent refreshes of the cache
			RemoteConfig.SharedInstance.ConfigSettings = new RemoteConfigSettings (true);

			// You can set default parameter values using an NSDictionary object or a plist file.
			var defaultPlist = NSBundle.MainBundle.PathForResource ("RemoteConfigDefaults", "plist");

			if (defaultPlist != null) {
				RemoteConfig.SharedInstance.SetDefaults ("RemoteConfigDefaults");
			} else {
				object [] values = { 5, 20 };
				object [] keys = { "times_table", "from_zero_to" };
				var defaultValues = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);
				RemoteConfig.SharedInstance.SetDefaults (defaultValues);
			}

			(Window.RootViewController as UINavigationController).PushViewController (new RemoteConfigViewController (), true);

			return true;
		}

		public static void ShowMessage (string title, string message, UIViewController fromViewController, Action actionForOk = null)
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
				alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, (obj) => {
					if (actionForOk != null) {
						actionForOk ();
					}
				}));
				fromViewController.PresentViewController (alert, true, null);
			} else {
				new UIAlertView (title, message, null, "Ok", null).Show ();
			}
		}
	}
}

