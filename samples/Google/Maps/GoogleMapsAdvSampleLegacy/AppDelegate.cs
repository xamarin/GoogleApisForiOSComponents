using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Google.Maps;

namespace GoogleMapsAdvSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		DVCMenu dvc;
		UINavigationController navController;

		const string MapsApiKey = "<Get your ID at https://code.google.com/apis/console/>";

		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			MapServices.ProvideApiKey (MapsApiKey);

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			dvc = new DVCMenu ();
			navController = new UINavigationController (dvc);
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

