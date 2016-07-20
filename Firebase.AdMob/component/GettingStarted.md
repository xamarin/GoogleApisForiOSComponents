Quickly monetize your app with Google AdMob, one of the world's largest mobile
advertising platforms. This SDK features:

* Simplified APIs
* Access to the latest HTML5 ad units from AdMob

With this component, developers can easily incorporate Google AdMob ads into their mobile
apps. Mobile-friendly text and image banners are available, along with rich, full-screen
web apps known as interstitials. An ever-growing set of "calls-to-action" are supported
in response to user-generated events, including redirection to the App Store, iTunes,
mapping applications, videos, and the dialer. Ads can be targeted by location and
demographic data.

## Banners

Creating a banner ad unit and loading the request:

```csharp
using Google.MobileAds;
...

const string bannerId = "<Get your ID at google.com/ads/admob>";

BannerView adView;
bool viewOnScreen = false;

public void AddBanner ()
{
	// Setup your BannerView, review AdSizeCons class for more Ad sizes. 
	adView = new BannerView (size: AdSizeCons.Banner, origin: new CGPoint (-10, 0)) {
		AdUnitID = bannerId,
		RootViewController = this
	};
	
	// Wire AdReceived event to know when the Ad is ready to be displayed
	adView.AdReceived += (object sender, EventArgs e) => {
		if (!viewOnScreen) View.AddSubview (adView);
		viewOnScreen = true;
	};

	adView.LoadRequest (Request.GetDefaultRequest ());
}
```

## Interstitial Ad

Creating an Interstitial ad and loading the request:

```csharp
using Google.MobileAds;
...

const string intersitialId = "<Get your ID at google.com/ads/admob>";

Interstitial adInterstitial;

public void AddInterstitial ()
{
	adInterstitial = new Interstitial (intersitialId);
	adInterstitial.LoadRequest (Request.GetDefaultRequest ());
	
	// We need to wait until the Intersitial is ready to show
	do {
		await Task.Delay (100);
	} while (!adInterstitial.IsReady);

	// Once is ready, show the ad on Main thread
	InvokeOnMainThread (() => adInterstitial.PresentFromRootViewController (navController));
}

```