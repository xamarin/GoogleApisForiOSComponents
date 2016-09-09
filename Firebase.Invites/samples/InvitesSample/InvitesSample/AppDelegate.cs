using Foundation;
using UIKit;
using Firebase.Analytics;
using Firebase.Invites;
using Google.SignIn;

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
			// Handle App Invite requests
			var invite = Invites.HandleUrl (url, sourceApplication, annotation);

			if (invite != null) {
				var matchType = invite.MatchType == ReceivedInviteMatchType.Weak ? "Weak" : "Strong";
				var message = $"Deep link from {sourceApplication}\nInvite ID: {invite.InviteId}\nApp Url: {invite.DeepLink}\nMatch Type: {matchType}";
				ShowMessage ("Depp-Link Data", message, Window.RootViewController);

				return true;
			}

			// Handle Sign In
			return SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);
		}

		public static void ShowMessage (string title, string message, UIViewController fromViewController)
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
				alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, (obj) => { }));
				fromViewController.PresentViewController (alert, true, null);
			} else {
				new UIAlertView (title, message, null, "Ok", null).Show ();
			}
		}
	}
}


