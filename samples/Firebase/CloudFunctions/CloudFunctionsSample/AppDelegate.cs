using System;

using Foundation;
using UIKit;
using UserNotifications;

using Firebase.CloudFunctions;
using Firebase.Core;

namespace CloudFunctionsSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate, IUNUserNotificationCenterDelegate
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

			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
			(Window.RootViewController as UINavigationController).PushViewController (new MenuViewController (), true);

			App.Configure ();

			return true;
		}

		public static void ShowMessage (string title, string message, UIViewController fromViewController, Action okAction = null)
		{
			var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
			alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, (obj) => okAction?.Invoke ()));
			fromViewController.PresentViewController (alert, true, null);
		}

		public static void ShowMessage (string title, string message, UIViewController fromViewController, string cancelTitle, Action cancelAction, string otherTitle, Action otherAction)
		{
			var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
			var btnCancel = UIAlertAction.Create (cancelTitle, UIAlertActionStyle.Default, (obj) => cancelAction?.Invoke ());
			var btnOther = UIAlertAction.Create (otherTitle, UIAlertActionStyle.Default, (obj) => otherAction?.Invoke ());

			alert.AddAction (btnCancel);
			alert.AddAction (btnOther);
			alert.PreferredAction = btnOther;

			fromViewController.PresentViewController (alert, true, null);
		}
	}
}

