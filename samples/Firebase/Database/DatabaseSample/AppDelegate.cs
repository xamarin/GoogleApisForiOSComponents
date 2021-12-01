using Foundation;
using UIKit;
using Firebase.Core;
using Firebase.Database;
using System;
using System.Collections.Generic;
using Xamarin.iOS.Shared.Helpers;

namespace DatabaseSample
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

		public static string UserUid { get; set; }
		public static DatabaseReference RootNode { get; set; }

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

			UINavigationBar.Appearance.TintColor = UIColor.White;
			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

			App.Configure ();

			Database.DefaultInstance.PersistenceEnabled = true;
			RootNode = Database.DefaultInstance.GetRootReference ();

			return true;
		}

		public static double GetUtcTimestamp ()
		{
			return double.Parse (DateTime.UtcNow.ToString ("yyyyMMddHHmmss"));
		}

		public static string ConvertUnformattedUtcDateToCurrentDate (string utcDate)
		{
			var date = System.DateTime.ParseExact (utcDate, "yyyyMMddHHmmss", System.Globalization.CultureInfo.GetCultureInfo ("en-US"));
			return date.ToString ("MM/dd/yy");
		}
	}
}

