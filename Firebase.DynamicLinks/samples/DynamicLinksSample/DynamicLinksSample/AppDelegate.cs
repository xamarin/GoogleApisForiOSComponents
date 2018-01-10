using Foundation;
using UIKit;

using Firebase.Core;
using Firebase.DynamicLinks;
using System;

namespace DynamicLinksSample
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

			UINavigationBar.Appearance.TintColor = UIColor.White;
			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

			// Set DeepLinkUrlScheme to the custom URL scheme you defined in your
			// Info.plist.
			Options.DefaultInstance.DeepLinkUrlScheme = "com.xamarin.firebase.ios.dynamiclinkssample";
			App.Configure ();

			return true;
		}

		// Handle Custom Url Schemes for iOS 9 or newer
		public override bool OpenUrl (UIApplication app, NSUrl url, NSDictionary options)
		{
			return OpenUrl (app, url, null, null);
		}

		// Handle Custom Url Schemes for iOS 8 or older
		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			Console.WriteLine ("I'm handling a link through the OpenUrl method.");
			var dynamicLink = DynamicLinks.SharedInstance?.FromCustomSchemeUrl (url);

			if (dynamicLink == null)
				return false;

			// Handle the deep link. For example, show the deep-linked content or
			// apply a promotional offer to the user's account.
			return true;
		}

		// Handle links received as Universal Links on iOS 9 or later
		public override bool ContinueUserActivity (UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
		{
			return DynamicLinks.SharedInstance.HandleUniversalLink (userActivity.WebPageUrl, (dynamicLink, error) => {
				if (error != null) {
					ShowMessage ("Seems that something wrong happened with Universal Links.", error.LocalizedDescription, application.KeyWindow.RootViewController);
					return;
				}

				if (dynamicLink.Url == null) {
					ShowMessage ("Dynamic Link Received", "But it seems that it does not have an Url to evaluate.", application.KeyWindow.RootViewController);
					return;
				}

				if (string.IsNullOrWhiteSpace (dynamicLink.Url.Path) || dynamicLink.Url.Path == "/") {
					GoToViewController (string.Empty);
				} else {
					GoToViewController (dynamicLink.Url.PathComponents [1]);
				}
			});
		}

		void GoToViewController (string path)
		{
			if (path == string.Empty) {
				(Window.RootViewController as UINavigationController).PushViewController (new MenuViewController (), true);
			} else {
				var imageViewController = Window.RootViewController.Storyboard.InstantiateViewController ("ImageViewControllerId") as ImageViewController;
				imageViewController.CompanyLogo = path == "platform" ? CompanyLogo.Xamarin : CompanyLogo.Firebase;
				(Window.RootViewController as UINavigationController).PushViewController (imageViewController, true);
			}
		}

		public static void ShowMessage (string title, string message, UIViewController fromViewController)
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
				alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, (obj) => { }));
				fromViewController.PresentViewController (alert, true, null);
			} else {
				new UIAlertView (title, message, null, "Ok", null).Show ();
			}
		}
	}
}


