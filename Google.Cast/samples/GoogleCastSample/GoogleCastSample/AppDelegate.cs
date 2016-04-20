using Foundation;
using UIKit;

namespace GoogleCastSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		UINavigationController navController;
		CastViewController viewController;

		// You can add your own app id here that you get by registering
		// with the Google Cast SDK Developer Console https://cast.google.com/publish
		public static string ReceiverApplicationId = "CC1AD845";

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			viewController = new CastViewController ();
			navController = new UINavigationController (viewController);
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();

			return true;
		}
	}
}