using System;
using System.Linq;
using System.Threading.Tasks;

using MonoTouch.Dialog;
using UIKit;
using CoreGraphics;

using Google.MobileAds;
using Foundation;

namespace AdMobSample
{
	public class AdsViewController : DialogViewController {
		BannerView adViewTableView;
		BannerView adViewWindow;
		InterstitialAd adInterstitial;

		bool adOnTable;
		bool adOnWindow;

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
					
					RootViewController = NavigationController
				};
				adViewTableView.AdUnitId = AdMobConstants.BannerId;

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
					
					RootViewController = NavigationController
				};
				adViewWindow.AdUnitId = AdMobConstants.BannerId;
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
			if (adInterstitial?.CanPresent (NavigationController, out _) == true) {				
				adInterstitial.DismissedContent += (sender, args) => {
					// Interstitial is a one time use object. That means once an interstitial is shown, HasBeenUsed 
					// returns true and the interstitial can't be used to load another ad. 
					// To request another interstitial, you'll need to create a new Interstitial object.
					adInterstitial.Dispose ();
					adInterstitial = null;
					CreateAndRequestInterstitial ();
				};

				adInterstitial.Present (NavigationController);
			}
		}

		void CreateAndRequestInterstitial ()
		{
			if (adInterstitial == null) {
				InterstitialAd.Load (AdMobConstants.IntersitialId, GetRequest (), (ad, err) => {
					if (ad != null) {
						adInterstitial = ad;
					}
				});				
			}
		}

		Request GetRequest ()
		{
			var request = Request.GetDefaultRequest ();
			return request;
		}
	}	
}
