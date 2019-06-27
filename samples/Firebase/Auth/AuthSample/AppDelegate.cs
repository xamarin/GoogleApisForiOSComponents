using System;

using Foundation;
using UIKit;
using UserNotifications;

using Facebook.CoreKit;
using Firebase.Auth;
using Firebase.Core;
using Google.SignIn;

namespace AuthSample
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

		// Replace here you own Facebook App Id and App Name, if you don't have one go to
		// https://developers.facebook.com/apps
		string appId = "Your_Id_Here";
		string appName = "Your_App_Display_Name";

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
			(Window.RootViewController as UINavigationController).PushViewController (new MenuViewController (), true);

			App.Configure ();

			Settings.AppID = appId;
			Settings.DisplayName = appName;

			// This method verifies if you have been logged to Facebook into the app before, and keep you logged in after you reopen or kill your app.
			return ApplicationDelegate.SharedInstance.FinishedLaunching (application, launchOptions);
		}

		// Support for iOS 9 or later
		public override bool OpenUrl (UIApplication app, NSUrl url, NSDictionary options)
		{
			var openUrlOptions = new UIApplicationOpenUrlOptions (options);
			return OpenUrl (app, url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);
		}

		// Support for iOS 8 or before
		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// Handle Sign In
			var result = SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);

			if (result)
				return result;
			
			// We need to handle URLs by passing them to their own OpenUrl in order to make the SSO authentication works.
			return ApplicationDelegate.SharedInstance.OpenUrl (application, url, sourceApplication, annotation);
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

