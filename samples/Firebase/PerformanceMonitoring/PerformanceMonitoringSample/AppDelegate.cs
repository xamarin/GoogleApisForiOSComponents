using System;

using Foundation;
using UIKit;

using Firebase.Core;
using Firebase.RemoteConfig;
using Firebase.PerformanceMonitoring;

namespace PerformanceMonitoringSample
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

			var navigationController = Window.RootViewController as UINavigationController;

			if (UIDevice.CurrentDevice.CheckSystemVersion (11, 0))
				UINavigationBar.Appearance.LargeTitleTextAttributes = new UIStringAttributes { ForegroundColor = UIColor.White };

			var remoteConfig = RemoteConfig.SharedInstance;

			// You can set default parameter values using an NSDictionary object or a plist file.
			var defaultPlist = NSBundle.MainBundle.PathForResource ("RemoteConfigDefaults", "plist");

			if (defaultPlist != null) {
				// Load in-app defaults from a plist file that sets perf_enable_auto and 
				// perf_enable_manual to true until you update values in the Firebase Console.
				remoteConfig.SetDefaults ("RemoteConfigDefaults");
			} else {
				// If the plist file doesn't exist, load the values by code.
				object [] values = { true, true };
				object [] keys = { "perf_enable_auto", "perf_enable_manual" };
				var defaultValues = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);
				remoteConfig.SetDefaults (defaultValues);
			}

			// Important! This needs to be applied before App.Configure()
			var isPerformanceMonitoringInstrumentationEnabled = remoteConfig ["perf_enable_auto"].BoolValue;
			var isPerformanceMonitoringDataCollectionEnabled = remoteConfig ["perf_enable_manual"].BoolValue;

			// The following line enables/disables automatic traces and HTTP/S network monitoring
			Performance.SharedInstance.InstrumentationEnabled = isPerformanceMonitoringInstrumentationEnabled;

			// The following line enables/disables custom traces
			Performance.SharedInstance.DataCollectionEnabled = isPerformanceMonitoringDataCollectionEnabled;

			// Use Firebase library to configure APIs
			App.Configure ();

			return true;
		}

		public static void ShowMessage (string title, string message, UIViewController fromViewController, Action actionForOk = null)
		{
			var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
			alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, (obj) => {
				actionForOk?.Invoke ();
			}));
			fromViewController.PresentViewController (alert, true, null);
		}
	}
}

