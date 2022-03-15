using Foundation;
using UIKit;
using Firebase.Core;
using System;
using Xamarin.iOS.Shared.Helpers;

namespace MLKitVisionSample {
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate {
		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			// You can download your GoogleService-Info.plist file following the next link:
			// https://firebase.google.com/docs/ios/setup
			if (!GoogleServiceInfoPlistHelper.FileExist ()) {
				Window = GoogleServiceInfoPlistHelper.CreateWindowWithFileNotFoundMessage ();
				return true;
			}

			App.Configure ();

			return true;
		}

		public static void ShowMessage (string title, string message, UIViewController fromViewController, string okTitle = "Ok", Action okAction = null, string cancelTitle = "Cancel", Action cancelAction = null)
		{
			var alertController = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
			alertController.AddAction (UIAlertAction.Create (okTitle, UIAlertActionStyle.Default, (obj) =>  okAction?.Invoke ()));
			alertController.AddAction (UIAlertAction.Create (cancelTitle, UIAlertActionStyle.Cancel, (obj) => cancelAction?.Invoke ()));

			fromViewController.PresentViewController (alertController, true, null);
		}
	}
}

