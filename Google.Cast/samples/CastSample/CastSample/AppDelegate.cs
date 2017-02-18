using Foundation;
using UIKit;

using Google.Cast;
using System;

namespace CastSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate, ILoggerDelegate
	{
		// class-level declarations

		// You can add your own app id here that you get by registering
		// with the Google Cast SDK Developer Console https://cast.google.com/publish
		public static readonly string ReceiverApplicationId = "CC1AD845";

		public override UIWindow Window {
			get;
			set;
		}

		#region App Life Cycle

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			// Contains options that affect the behavior of the framework.
			var options = new CastOptions (ReceiverApplicationId);

			// CastContext coordinates all of the framework's activities.
			CastContext.SetSharedInstance (options);

			// Google Cast Logger
			Logger.SharedInstance.Delegate = this;

			// Use UICastContainerViewController as the Initial Controller.
			// Wraps our View Controllers and add a UIMiniMediaControlsViewController
			// at the bottom; a persistent bar to control remote videos.
			var appStoryboard = UIStoryboard.FromName ("Main", null);
			var navigationController = appStoryboard.InstantiateInitialViewController () as UINavigationController;
			var castContainer = CastContext.SharedInstance.CreateCastContainerController (navigationController);
			castContainer.MiniMediaControlsItemEnabled = true;

			// Used to highlight the Cast button when it is first shown to users.
			CastContext.SharedInstance.PresentCastInstructionsViewControllerOnce ();

			// Use Default Expanded Media Controls
			CastContext.SharedInstance.UseDefaultExpandedMediaControls = true;

			Window = new UIWindow (UIScreen.MainScreen.Bounds);
			Window.RootViewController = castContainer;
			Window.MakeKeyAndVisible ();

			return true;
		}

		#endregion

		#region Logger Delegate

		[Export ("logMessage:fromFunction:")]
		void LogMessage (string message, string function)
		{
			Console.WriteLine ($"{function} {message}");
		}

		#endregion
	}
}

