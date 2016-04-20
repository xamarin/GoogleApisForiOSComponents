using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Dialog;
using Foundation;
using UIKit;
using Google.TagManager;

namespace CuteAnimalsiOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		DVCMenu viewController;
		UINavigationController navController;

		public static Manager Manager { get; set; }

		public static Container Container { get; set; }

		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Manager = Manager.GetInstance;
			// Optional: Change the LogLevel to Verbose to enable logging at VERBOSE and higher levels.
			Manager.Logger.SetLogLevel (LoggerLogLevelType.Verbose);

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			viewController = new DVCMenu ();
			navController = new UINavigationController (viewController);
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}