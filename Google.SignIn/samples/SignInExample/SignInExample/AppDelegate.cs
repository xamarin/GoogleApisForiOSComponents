using System;
using Foundation;
using UIKit;
using Google.Core;
using Google.SignIn;

namespace SignInExample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		// ClientID can be found in the GoogleService-Info.plist file
		// You can get the GoogleService-Info.plist file at https://developers.google.com/mobile/add
		const string clientId = "1028405910307-am33jrsno99vde2ff7aa8bm29eqt08nb.apps.googleusercontent.com";

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			NSError configureError;
			Context.SharedInstance.Configure (out configureError);
			if (configureError != null) {
				// If something went wrong, assign the clientID manually
				Console.WriteLine ("Error configuring the Google context: {0}", configureError);
				SignIn.SharedInstance.ClientID = clientId;
			}

			return true;
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			return SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);
		}
	}
}


