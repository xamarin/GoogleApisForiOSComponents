using System;
using Foundation;
using UIKit;
using Google.Core;
using Google.AppInvite;
using Google.SignIn;

namespace AppInviteSample
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
			NSError configureError;
			Context.SharedInstance.Configure (out configureError);
			if (configureError != null) {
				Console.WriteLine ("Error configuring the Google context: {0}", configureError);
			}

			Invite.ApplicationDidFinishLaunching ();

			return true;
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// Handle App Invite requests
			var invite = Invite.HandleUrl (url, sourceApplication, annotation);
			if (invite != null) {
				var message =string.Format ("Deep link from {0} \nInvite ID: {1}\nApp URL: {2}",
					sourceApplication, invite.InviteId, invite.DeepLink);
				new UIAlertView (@"Deep-link Data", message, null, "OK").Show ();
					
				return true;
			}

			return SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);
		}
	}
}


