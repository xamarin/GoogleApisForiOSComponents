using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Foundation;
using UIKit;
using CoreGraphics;

using MonoTouch.Dialog;

using Google.MobileAds;

namespace MobileAdsExample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController navController;
		DialogViewController dvcDialog;

		BannerView adViewTableView;
		BannerView adViewWindow;
		Interstitial adInterstitial;

		bool adOnTable = false;
		bool adOnWindow = false;
		bool interstitialRequested = false;

		// Get you own AdmobId from: http://www.google.com/ads/admob/
		// These IDs are provided by Google
		const string bannerId = "ca-app-pub-3940256099942544/2934735716";
		const string intersitialId = "ca-app-pub-3940256099942544/4411468910";

		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var root = new RootElement ("GoogleAdmobSample") {
				new Section ("Insert Ad") {
					new StringElement ("Banner on TableView", AddToTableView),
					new StringElement ("Banner on Window", AddToWindow),
					new StringElement ("Interstitial on Window", AddToView)
				},
				new Section ("Remove Ad") {
					new StringElement ("from TableView", RemoveAdFromTableView),
					new StringElement ("from Window", RemoveAdFromWindow),
				}
			};

			dvcDialog = new DialogViewController (UITableViewStyle.Grouped, root, false);
			navController = new UINavigationController (dvcDialog);

			window.RootViewController = navController;
			window.MakeKeyAndVisible ();

			return true;
		}

		void AddToTableView ()
		{
			if (adViewTableView == null) {

				// Setup your BannerView, review AdSizeCons class for more Ad sizes. 
				adViewTableView = new BannerView (size: AdSizeCons.Banner, origin: new CGPoint (-10, 0)) {
					AdUnitID = bannerId,
					RootViewController = navController
				};

				// Wire AdReceived event to know when the Ad is ready to be displayed
				adViewTableView.AdReceived += (object sender, EventArgs e) => {
					if (!adOnTable) {
						dvcDialog.Root.Add (new Section (caption: "Ad Section") {
							new UIViewElement (caption: "Ad", view: adViewTableView, transparent: true)
						});
						adOnTable = true;
					}
				};
			}
			adViewTableView.LoadRequest (Request.GetDefaultRequest ());
		}

		void RemoveAdFromTableView ()
		{
			if (adViewTableView != null) {
				if (adOnTable) {
					dvcDialog.Root.RemoveAt (idx: 2, anim: UITableViewRowAnimation.Fade);
				}
				adOnTable = false;

				// You need to explicitly Dispose BannerView when you dont need it anymore
				// to avoid crashes if pending request are in progress
				adViewTableView.Dispose ();
				adViewTableView = null;
			}
		}

		void AddToWindow ()
		{
			if (adViewWindow == null) {

				// Setup your GADBannerView, review AdSizeCons class for more Ad sizes. 
				adViewWindow = new BannerView (size: AdSizeCons.Banner, 
					origin: new CGPoint (0, window.Bounds.Size.Height - AdSizeCons.Banner.Size.Height)) {
					AdUnitID = bannerId,
					RootViewController = navController
				};

				// Wire AdReceived event to know when the Ad is ready to be displayed
				adViewWindow.AdReceived += (object sender, EventArgs e) => {
					if (!adOnWindow) {
						navController.View.Subviews.First ().Frame = new CGRect (0, 0, 320, UIScreen.MainScreen.Bounds.Height - 50);
						navController.View.AddSubview (adViewWindow);
						adOnWindow = true;
					}
				};
			}
			adViewWindow.LoadRequest (Request.GetDefaultRequest ());
		}

		void RemoveAdFromWindow ()
		{
			if (adViewWindow != null) {
				if (adOnWindow) {
					navController.View.Subviews.First ().Frame = new CGRect (0, 0, 320, UIScreen.MainScreen.Bounds.Height);
					adViewWindow.RemoveFromSuperview ();
				}
				adOnWindow = false;

				// You need to explicitly Dispose BannerView when you dont need it anymore
				// to avoid crashes if pending request are in progress
				adViewWindow.Dispose ();
				adViewWindow = null;
			}
		}

		void AddToView ()
		{
			if (interstitialRequested)
				return;

			if (adInterstitial == null) {
				adInterstitial = new Interstitial (intersitialId);
						
				adInterstitial.ScreenDismissed += (sender, e) => { 
					interstitialRequested = false;

					// You need to explicitly Dispose Interstitial when you dont need it anymore
					// to avoid crashes if pending request are in progress
					adInterstitial.Dispose ();
					adInterstitial = null;
				};
			}

			interstitialRequested = true;
			adInterstitial.LoadRequest (Request.GetDefaultRequest ());

			ShowInterstitial ();
		}

		async void ShowInterstitial ()
		{
			// We need to wait until the Intersitial is ready to show
			do {
				await Task.Delay (100);
			} while (!adInterstitial.IsReady);

			// Once is ready, show it
			InvokeOnMainThread (() => adInterstitial.PresentFromRootViewController (navController));
		}

	}
}

