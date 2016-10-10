using System;
using System.Linq;
using System.Threading.Tasks;

using MonoTouch.Dialog;
using UIKit;
using CoreGraphics;

using Google.MobileAds;

namespace AdMobSample
{
	public class AdsViewController : DialogViewController
	{
		BannerView adViewTableView;
		BannerView adViewWindow;
		Interstitial adInterstitial;

		bool adOnTable = false;
		bool adOnWindow = false;
		bool interstitialRequested = false;

		// Get you own AdmobId from: http://www.google.com/ads/admob/
		// These IDs are provided by Google and come in your GoogleService-Info.plist
		const string bannerId = "ca-app-pub-3940256099942544/2934735716";
		const string intersitialId = "ca-app-pub-3940256099942544/4411468910";

		public AdsViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			Root = new RootElement ("AdMob Sample") {
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
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			CreateAndRequestInterstitial ();
		}

		void AddToTableView ()
		{
			if (adViewTableView == null) {
				// Setup your BannerView, review AdSizeCons class for more Ad sizes. 
				adViewTableView = new BannerView (size: AdSizeCons.SmartBannerPortrait) {
					AdUnitID = bannerId,
					RootViewController = NavigationController
				};

				// Wire AdReceived event to know when the Ad is ready to be displayed
				adViewTableView.AdReceived += (object sender, EventArgs e) => {
					if (!adOnTable) {
						Root.Add (new Section (caption: "Ad Section") {
							new UIViewElement (caption: "Ad", view: adViewTableView, transparent: true)
						});
						adOnTable = true;
					}
				};
			}
			adViewTableView.LoadRequest (GetRequest ());
		}

		void RemoveAdFromTableView ()
		{
			if (adViewTableView != null) {
				if (adOnTable) {
					Root.RemoveAt (idx: 2, anim: UITableViewRowAnimation.Fade);
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
				adViewWindow = new BannerView (size: AdSizeCons.SmartBannerPortrait,
				                               origin: new CGPoint (0, UIScreen.MainScreen.Bounds.Size.Height - AdSizeCons.Banner.Size.Height)) {
					AdUnitID = bannerId,
					RootViewController = NavigationController
				};

				// Wire AdReceived event to know when the Ad is ready to be displayed
				adViewWindow.AdReceived += (object sender, EventArgs e) => {
					if (!adOnWindow) {
						NavigationController.View.Subviews.First ().Frame = new CGRect (0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - 50);
						NavigationController.View.AddSubview (adViewWindow);
						adOnWindow = true;
					}
				};
			}
			adViewWindow.LoadRequest (GetRequest ());
		}

		void RemoveAdFromWindow ()
		{
			if (adViewWindow != null) {
				if (adOnWindow) {
					NavigationController.View.Subviews.First ().Frame = new CGRect (0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
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
			if (!adInterstitial.IsReady)
				return;

			adInterstitial.PresentFromRootViewController (NavigationController);
		}

		void CreateAndRequestInterstitial ()
		{
			adInterstitial = new Interstitial (intersitialId);
			adInterstitial.ScreenDismissed += (sender, e) => {
				// Interstitial is a one time use object. That means once an interstitial is shown, HasBeenUsed 
				// returns true and the interstitial can't be used to load another ad. 
				// To request another interstitial, you'll need to create a new Interstitial object.
				adInterstitial.Dispose ();
				adInterstitial = null;
				CreateAndRequestInterstitial ();
			};
			adInterstitial.LoadRequest (GetRequest ());
		}

		Request GetRequest ()
		{
			var request = Request.GetDefaultRequest ();
			// Requests test ads on devices you specify. Your test device ID is printed to the console when
			// an ad request is made. GADBannerView automatically returns test ads when running on a
			// simulator. After you get your device ID, add it here
			request.TestDevices = new [] { Request.SimulatorId.ToString () };
			return request;
		}
	}
}
