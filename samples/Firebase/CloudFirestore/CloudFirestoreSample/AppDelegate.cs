using Foundation;
using UIKit;

using Firebase.Core;
using Firebase.CloudFirestore;
using Xamarin.iOS.Shared.Helpers;

namespace CloudFirestoreSample
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
		public static Firestore Database { get; set; }

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

			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

			App.Configure ();
			Database = Firestore.SharedInstance;

			return true;
		}

		public static string GetFormattedDate (NSDate date)
		{
			if (date == null)
				return null;

			var dateFormatter = new NSDateFormatter {
				Locale = new NSLocale ("en_US_POSIX"),
				DateFormat = "MM/dd/yy"
			};
			return dateFormatter.ToString (date);
		}
	}
}

