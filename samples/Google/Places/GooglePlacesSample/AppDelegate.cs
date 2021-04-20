using Foundation;
using UIKit;
using System;
using Google.Places;
using Google.Maps;

namespace GooglePlacesSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate, IUISplitViewControllerDelegate
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

			if (string.IsNullOrWhiteSpace (GoogleApiKey.Key)) {
				var message = $"Configure the Key property inside GoogleApiKey class for your bundle {NSBundle.MainBundle.BundleIdentifier}";
				ShowMessage ("Google API Key is missing...", message, Window.RootViewController);
			}

			// Provide the Places API with your API key.
			PlacesClient.ProvideApiKey (GoogleApiKey.Key);

			// Provide the Maps API with your API key. You may not need
			// this in your app, however we do need this for the demo 
			// app as it uses Maps.
			MapServices.ProvideApiKey (GoogleApiKey.Key);

			var splitViewController = UIStoryboard.FromName ("Main", null).InstantiateViewController (nameof (UISplitViewController)) as UISplitViewController;
			splitViewController.Delegate = this;
			splitViewController.PreferredDisplayMode = UISplitViewControllerDisplayMode.PrimaryOverlay;

			Window = new UIWindow (UIScreen.MainScreen.Bounds) {
				RootViewController = splitViewController
			};
			Window.MakeKeyAndVisible ();

			return true;
		}

		#region UISplitViewController Delegate

		[Export ("splitViewController:collapseSecondaryViewController:ontoPrimaryViewController:")]
		public bool CollapseSecondViewController (UISplitViewController splitViewController, UIViewController secondaryViewController, UIViewController primaryViewController)
		{
			return UIDevice.CurrentDevice.UserInterfaceIdiom != UIUserInterfaceIdiom.Pad;
		}

		#endregion

		public static void ShowMessage (string title, string message, UIViewController fromViewController)
		{
			var alertController = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
			alertController.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Cancel, null));

			fromViewController.PresentViewController (alertController, true, null);
		}
	}
}

