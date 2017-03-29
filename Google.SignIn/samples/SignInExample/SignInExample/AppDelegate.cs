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

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// You can get the GoogleService-Info.plist file at https://developers.google.com/mobile/add
			var googleServiceDictionary = NSDictionary.FromFile ("GoogleService-Info.plist");
			SignIn.SharedInstance.ClientID = googleServiceDictionary ["CLIENT_ID"].ToString ();

			return true;
		}

		// For iOS 9 or newer
		public override bool OpenUrl (UIApplication app, NSUrl url, NSDictionary options)
		{
			var openUrlOptions = new UIApplicationOpenUrlOptions (options);
			return SignIn.SharedInstance.HandleUrl (url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);
		}

		// For iOS 8 and older
		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			return SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);
		}
	}
}


