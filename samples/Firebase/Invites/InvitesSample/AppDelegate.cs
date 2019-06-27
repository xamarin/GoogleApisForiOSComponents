using Foundation;
using UIKit;
using Firebase.Core;
using Firebase.Invites;
using Google.SignIn;
using Firebase.DynamicLinks;

namespace InvitesSample
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
			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

			App.Configure ();

			return true;
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
			if (SignIn.SharedInstance.HandleUrl (url, sourceApplication ?? "", annotation))
				return true;

			// Handle App Invite requests
			return Invites.HandleUniversalLink (url, HandleInvitesUniversalLink);

			void HandleInvitesUniversalLink (ReceivedInvite receivedInvite, NSError error)
			{
				if (error != null) {
					ShowMessage ("Depp-Link Data", error.LocalizedDescription, Window.RootViewController);
					return;
				}

				var message = $"Deep link from {sourceApplication}\nInvite ID: {receivedInvite.InviteId}\nApp Url: {receivedInvite.DeepLink}\nMatch Type: {receivedInvite.MatchType}";

				ShowMessage ("Depp-Link Data", message, Window.RootViewController);
			}
		}

		public static void ShowMessage (string title, string message, UIViewController fromViewController)
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
				alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
				fromViewController.PresentViewController (alert, true, null);
			} else {
				new UIAlertView (title, message, null, "Ok", null).Show ();
			}
		}
	}
}


