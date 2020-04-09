using Foundation;
using UIKit;
using Firebase.Core;
using Google.MobileAds;

namespace AdMobSample
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

			(Window.RootViewController as UINavigationController).PushViewController (new AdsViewController (), true);

			App.Configure ();

			/*
			 * In your app's Info.plist file, add a GADApplicationIdentifier key
			 * with a string value of your AdMob app ID
			 * 
			 * <key>GADApplicationIdentifier</key>
			 * <string>ca-app-pub-XXXXXXXXXXXXXXXX~NNNNNNNNNN</string>
			 *
			 * Get your Application Id here: https://apps.admob.com/#account/appmgmt:
			 *
			 * If you're just looking to experiment with the SDK in a Hello World app,
			 * you can use the sample App ID shown below.
			 * 
			 * <string>ca-app-pub-3940256099942544~1458002511</string>
			 */

			MobileAds.SharedInstance.Start (status => {
				// Requests test ads on devices you specify. Your test device ID is printed to the console when
				// an ad request is made. Ads automatically returns test ads when running on a
				// simulator. After you get your device ID, add it here
				MobileAds.SharedInstance.RequestConfiguration.TestDeviceIdentifiers = new [] { Request.SimulatorId.ToString () };
			});

			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}


