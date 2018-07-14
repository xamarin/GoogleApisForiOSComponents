# Table of content

- [Table of content](#table-of-content)
- [Get Started](#get-started)
	- [Use Google Mobile Ads SDK without Firebase](#use-google-mobile-ads-sdk-without-firebase)
	- [Add Firebase to your app](#add-firebase-to-your-app)
	- [Configure AdMob in your app](#configure-admob-in-your-app)
	- [Initialize the Google Mobile Ads SDK](#initialize-the-google-mobile-ads-sdk)
		- [Always test with test ads](#always-test-with-test-ads)
- [Banner Ads](#banner-ads)
	- [Create a BannerView](#create-a-bannerview)
		- [Interface Builder](#interface-builder)
		- [Programmatically](#programmatically)
	- [Configure BannerView properties](#configure-bannerview-properties)
	- [Call LoadRequest method](#call-loadrequest-method)
	- [Ad events](#ad-events)
		- [Registering for banner events using IBannerViewDelegate interface](#registering-for-banner-events-using-ibannerviewdelegate-interface)
		- [Implementing banner events](#implementing-banner-events)
	- [Use cases](#use-cases)
		- [Adding a banner to the view hierarchy once an ad is received](#adding-a-banner-to-the-view-hierarchy-once-an-ad-is-received)
		- [Animating a banner ad](#animating-a-banner-ad)
		- [Pausing and resuming the app](#pausing-and-resuming-the-app)
	- [Banner sizes](#banner-sizes)
	- [Smart Banners](#smart-banners)
- [Interstitial Ads](#interstitial-ads)
	- [Create a Interstitial object](#create-a-interstitial-object)
	- [Load an ad](#load-an-ad)
	- [Show the ad](#show-the-ad)
	- [Use IInterstitialDelegate interface or Interstitial events to reload](#use-iinterstitialdelegate-interface-or-interstitial-events-to-reload)
	- [Ad events](#ad-events)
		- [Registering for interstitial events using IInterstitialDelegate interface](#registering-for-interstitial-events-using-iinterstitialdelegate-interface)
		- [Implementing interstitial events](#implementing-interstitial-events)
	- [Some best practices](#some-best-practices)
		- [Consider whether interstitial ads are the right type of ad for your app.](#consider-whether-interstitial-ads-are-the-right-type-of-ad-for-your-app)
		- [Remember to pause the action when displaying an interstitial ad.](#remember-to-pause-the-action-when-displaying-an-interstitial-ad)
		- [Allow for adequate loading time.](#allow-for-adequate-loading-time)
		- [Don't flood the user with ads.](#dont-flood-the-user-with-ads)
		- [Don't use the `InterstitialDelegate.DidReceiveAd` or `Interstitial.AdReceived` events to show the interstitial.](#dont-use-the-interstitialdelegatedidreceivead-or-interstitialadreceived-events-to-show-the-interstitial)
- [Native Ads Advanced (Unified)](#native-ads-advanced-unified)
	- [Loading ads](#loading-ads)
		- [Initialize the ad loader](#initialize-the-ad-loader)
		- [Implement the ad loader delegate](#implement-the-ad-loader-delegate)
		- [Request the ad](#request-the-ad)
		- [When to request ads](#when-to-request-ads)
		- [Determining when loading has finished](#determining-when-loading-has-finished)
		- [Handling failed requests](#handling-failed-requests)
		- [Get notified of native ad events](#get-notified-of-native-ad-events)
	- [Native ad options](#native-ad-options)
		- [`NativeAdViewOptions`](#nativeadviewoptions)
		- [`VideoOptions`](#videooptions)
		- [`MultipleAdsAdLoaderOptions`](#multipleadsadloaderoptions)
	- [Displaying a system-defined native ad format](#displaying-a-system-defined-native-ad-format)
		- [UnifiedNativeAdView](#unifiednativeadview)
		- [The AdChoices overlay](#the-adchoices-overlay)
		- [Ad attribution](#ad-attribution)
	- [Native video](#native-video)
		- [MediaView](#mediaview)
		- [VideoController](#videocontroller)
- [Native Ads Advanced](#native-ads-advanced)
	- [Loading ads](#loading-ads)
		- [Initialize a AdLoader](#initialize-a-adloader)
		- [Implement the ad loader delegate](#implement-the-ad-loader-delegate)
		- [Request the ad](#request-the-ad)
		- [When to request ads](#when-to-request-ads)
		- [Determining when loading has finished](#determining-when-loading-has-finished)
		- [Handling failed requests](#handling-failed-requests)
		- [Get notified of native ad events](#get-notified-of-native-ad-events)
	- [Native ad options](#native-ad-options)
		- [`NativeAdViewOptions`](#nativeadviewoptions)
		- [`VideoOptions`](#videooptions)
		- [`MultipleAdsAdLoaderOptions`](#multipleadsadloaderoptions)
	- [Displaying a system-defined native ad format](#displaying-a-system-defined-native-ad-format)
		- [The ad view classes](#the-ad-view-classes)
		- [The AdChoices overlay](#the-adchoices-overlay)
		- [Ad attribution](#ad-attribution)
	- [Native video](#native-video)
		- [MediaView](#mediaview)
		- [VideoController](#videocontroller)
- [Rewarded Video Ads](#rewarded-video-ads)
	- [Request rewarded video](#request-rewarded-video)
	- [Set up event notifications](#set-up-event-notifications)
	- [Display rewarded video](#display-rewarded-video)
	- [Reload a rewarded video](#reload-a-rewarded-video)
- [Targeting](#targeting)
	- [Request](#request)
		- [Location](#location)
		- [Child-directed setting](#child-directed-setting)
		- [Users under the age of consent](#users-under-the-age-of-consent)
		- [Ad content filtering](#ad-content-filtering)
		- [Content URL](#content-url)
	- [Load an ad with targeting](#load-an-ad-with-targeting)
	- [FAQ](#faq)
- [Reporting](#reporting)
- [Global Settings](#global-settings)
	- [Video ad volume control](#video-ad-volume-control)
	- [Changing audio session](#changing-audio-session)
	- [In-app purchase reporting](#in-app-purchase-reporting)
	- [Crash reporting](#crash-reporting)
- [Requesting Consent from European Users](#requesting-consent-from-european-users)
	- [Tips for using the Consent SDK](#tips-for-using-the-consent-sdk)
		- [If you select 12 or fewer ad technology providers and don't use mediation](#if-you-select-12-or-fewer-ad-technology-providers-and-dont-use-mediation)
		- [If you select more than 12 ad technology providers and don't use mediation](#if-you-select-more-than-12-ad-technology-providers-and-dont-use-mediation)
		- [If you use AdMob mediation](#if-you-use-admob-mediation)
	- [Update consent status](#update-consent-status)
	- [Collect consent](#collect-consent)
		- [Google-rendered consent form](#google-rendered-consent-form)
		- [Load consent form](#load-consent-form)
		- [Show consent form](#show-consent-form)
		- [Publisher-managed consent collection](#publisher-managed-consent-collection)
		- [Storing publisher managed consent](#storing-publisher-managed-consent)
		- [Change or revoke consent](#change-or-revoke-consent)
		- [Users under the age of consent](#users-under-the-age-of-consent)
	- [Testing](#testing)
	- [Forward consent to the Google Mobile Ads SDK](#forward-consent-to-the-google-mobile-ads-sdk)
	- [FAQ](#faq)

# Get Started

AdMob uses the Google Mobile Ads SDK. The Google Mobile Ads SDK helps app developers gain insights about their users, drives more in-app purchases, and maximizes ad revenue. To do so, the default integration of the Mobile Ads SDK collects information such as device information, publisher-provided location information, and general in-app purchase information (such as item purchase price and currency).

> ![note_icon] **_Note: The Mobile Ads SDK does not collect payment card information._**

## Use Google Mobile Ads SDK without Firebase

If you don't plan to include Firebase in your app, you can use Google Mobile Ads SDK as standalone. To do so, just jump to [Initialize the Google Mobile Ads SDK section](#Initialize-the-Google-Mobile-Ads-SDK) directly.

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.
5. In [Firebase console][1], go to AdMob section and link your recently created app to AdMob.

## Configure AdMob in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Open `GoogleService-Info.plist` file and change `IS_ADS_ENABLED` value to `Yes`. 
4. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
App.Configure ();
```

## Initialize the Google Mobile Ads SDK

At app launch, initialize the Google Mobile Ads SDK by calling `Configure` method:

```csharp
// Get your Application Id here: https://apps.admob.com/#account/appmgmt:
MobileAds.Configure ("ca-app-pub-XXXXXXXXXXXXXXXX~NNNNNNNNNN");
```

Initializing the Google Mobile Ads SDK at app launch allows the SDK to fetch app-level settings and perform configuration tasks as early as possible. This can help reduce latency for the initial ad request. Initialization requires an app ID. App IDs are unique identifiers given to mobile apps when they're registered in the AdMob console.

To find your app ID, click the [App management][3] option under the settings dropdown (located in the upper right hand corner) on the AdMob account page. App IDs have the form **ca-app-pub-XXXXXXXXXXXXXXXX~NNNNNNNNNN**.

### Always test with test ads

The sample code in these guides contains an ad unit ID and you're free to request ads with it. It's been specially configured to return test ads rather than production ads for every request, which makes it safe to use.

However, once you register an app in the AdMob UI and create your own ad unit IDs for use in your app, you'll need to explicitly configure your device as a test device when you're developing. **This is extremely important**. Testing with real ads (even if you never tap on them) is against AdMob policy and can cause your account to be suspended. See Test Ads for information on how you can make sure you always get test ads when developing.

---

# Banner Ads

Banner ads are rectangular image or text ads that occupy a spot within an app's layout. They stay on screen while users are interacting with the app, and can refresh automatically after a certain period of time. If you're new to mobile advertising, they're a great place to start.

This guide shows you how to integrate banner ads from AdMob into an iOS app. In addition to code snippets and instructions, it includes information about sizing banners properly and links to additional resources.

## Create a BannerView

AdMob banners are displayed in `BannerView` objects, so the first step toward integrating AdMob ads is to include a `BannerView` in your view hierarchy. This is typically done in one of two ways.

### Interface Builder

A `BannerView` can be added to a storyboard or xib file like any typical view. When using this method, be sure to add **width** and **height** constraints to match the ad size you'd like to display. For example, when displaying a standard banner (320x50), use a width constraint of 320 points, and a height constraint of 50 points.

### Programmatically

A BannerView can also be instantiated directly. Here's an example of how to create a BannerView with the standard banner size of 320x50:

```csharp
using Google.MobileAds;

namespace YourNamespace
{
	public class YourViewController
	{
		BannerView bannerView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			bannerView = new BannerView (AdSizeCons.Banner);
			View.AddSubview (bannerView);
		}
	}
}
```

## Configure BannerView properties

In order to load and display ads, `BannerView` requires a few properties be set.

* RootViewController: This view controller is used to present an overlay when the ad is clicked. It should normally be set to the view controller that contains the `BannerView`.
* AdUnitID: This is the AdMob ad unit ID from which the `BannerView` should load ads.

Here's a code example showing how to set the two properties in the `ViewDidLoad` method of a `UIViewController`:

```csharp
public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	///
	bannerView = new BannerView (AdSizeCons.Banner) {
		AdUnitID = "ca-app-pub-3940256099942544/2934735716",
		RootViewController = this
	};
	///
	
	View.AddSubview (bannerView);
}
```

> ![note_icon] Note: Ad unit IDs are created in the AdMob UI, and represent a place in your app where ads appear. If you show banner ads in two view controllers, for example, you can create an ad unit for each one.

## Call LoadRequest method

Once the `BannerView` is in place and its properties configured, it's time to load an ad. This is done by calling the `LoadRequest` method, which takes a `Request` object as its argument:

```csharp
public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	bannerView = new BannerView (AdSizeCons.Banner) {
		AdUnitID = "ca-app-pub-3940256099942544/2934735716",
		RootViewController = this
	};
	View.AddSubview (bannerView);

	///
	bannerView.LoadRequest (Request.GetDefaultRequest ());
	///
}
```

`Request` objects represent a single ad request, and contain properties for things like targeting information.

## Ad events

Through the use of `IBannerViewDelegate` interface or `BannerView` object events, you can listen for lifecycle events, such as when an ad is closed or the user leaves the app. If you decide to use Ad events, you must use the `IBannerViewDelegate` interface or `BannerView` object events, you cannot use both or create a mix of them. If you plan to use `BannerView` object events, you can jump to [Implementing banner events section](#Implementing-banner-events) directly.

### Registering for banner events using IBannerViewDelegate interface

To register for banner ad events using `IBannerViewDelegate` interface, set the `Delegate` property on `BannerView` to an object that implements the `IBannerViewDelegate` interface. Generally, the class that implements banner ads also acts as the delegate class, in which case, the `Delegate` property can be set to `this`:

```csharp
public class YourViewController : UIViewController, IBannerViewDelegate
{
	BannerView bannerView;

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

		bannerView = new BannerView (AdSizeCons.Banner) {
			AdUnitID = "ca-app-pub-3940256099942544/2934735716",
			RootViewController = this
		};
		View.AddSubview (bannerView);

		///
		bannerView.Delegate = this;
		///
	}
}
```

### Implementing banner events

Each of the methods in `IBannerViewDelegate` interface are marked as **optional**, so you only need to implement the methods you need. This also applies for `BannerView` object events, you only need to implement the events you need. This example implements each method and event and logs a message to the console:

```csharp
// For Console class
using System;
// For Export attribute
using Fundation;

/// Tells the delegate an ad request loaded an ad.
[Export ("adViewDidReceiveAd:")]
public void DidReceiveAd (BannerView view) 
{
	Console.WriteLine ($"{nameof (DidReceiveAd)} method.");
}

bannerView.AdReceived += (sender, e) => {
	Console.WriteLine ("AdReceived event.");
};

/// Tells the delegate an ad request failed.
[Export ("adView:didFailToReceiveAdWithError:")]
public void DidFailToReceiveAd (BannerView view, RequestError error)
{
	Console.WriteLine ($"{nameof (DidFailToReceiveAd)} method with error: {error.LocalizedDescription}.");
}

bannerView.ReceiveAdFailed += (sender, e) => {
	Console.WriteLine ($"ReceiveAdFailed event with error: {e.Error.LocalizedDescription}.");
};

/// Tells the delegate that a full screen view will be presented in response
/// to the user clicking on an ad.
[Export ("adViewWillPresentScreen:")]
public void WillPresentScreen (BannerView adView)
{
	Console.WriteLine ($"{nameof (WillPresentScreen)} method.");
}

bannerView.WillPresentScreen += (sender, e) => {
	Console.WriteLine ("WillPresentScreen event.");
};

/// Tells the delegate that the full screen view will be dismissed.
[Export ("adViewWillDismissScreen:")]
public void WillDismissScreen (BannerView adView)
{
	Console.WriteLine ($"{nameof (WillDismissScreen)} method.");
}

bannerView.WillDismissScreen += (sender, e) => {
	Console.WriteLine ("WillDismissScreen event.");
};

/// Tells the delegate that the full screen view has been dismissed.
[Export ("adViewDidDismissScreen:")]
public void DidDismissScreen (BannerView adView)
{
	Console.WriteLine ($"{nameof (DidDismissScreen)} method.");
}

bannerView.ScreenDismissed += (sender, e) => {
	Console.WriteLine ("ScreenDismissed event.");
};

/// Tells the delegate that a user click will open another app (such as
/// the App Store), backgrounding the current app.
[Export ("adViewWillLeaveApplication:")]
public void WillLeaveApplication (BannerView adView)
{
	Console.WriteLine ($"{nameof (WillLeaveApplication)} method.");
}

bannerView.WillLeaveApplication += (sender, e) => {
	Console.WriteLine ("WillLeaveApplication event.");
};
```

## Use cases

Here are some example use cases for these ad event methods.

### Adding a banner to the view hierarchy once an ad is received

You may choose to hold off on adding a `BannerView` to the view hierarchy until an ad is received. You can do this by listening for the `DidReceiveAd`/`AdReceived` event:

```csharp
[Export ("adViewDidReceiveAd:")]
public void DidReceiveAd (BannerView view) 
{
	View.AddSubview (bannerView);
}

// or

bannerView.AdReceived += (sender, e) => {
	View.AddSubview (bannerView);
};
```

The `AddSubview` method automatically removes a view from its parent if it already has one, so it's safe to make this call every time.

### Animating a banner ad

You can also use the `DidReceiveAd`/`AdReceived` event to animate a banner ad once it's returned as shown in the following example:

```csharp
[Export ("adViewDidReceiveAd:")]
public void DidReceiveAd (BannerView view) 
{
	bannerView.Alpha = 0;
	UIView.Animate (1, () => bannerView.Alpha = 1);
}

// or

bannerView.AdReceived += (sender, e) => {
	bannerView.Alpha = 0;
	UIView.Animate (1, () => bannerView.Alpha = 1);
};
```

### Pausing and resuming the app

The `IBannerViewDelegate` interface has methods to notify you of events such as when a click causes an overlay to be presented or dismissed, or invokes an external browser. Same functionality applies for `BannerView` events. If you want to know that these events happened because of ads, then register for these `IBannerViewDelegate` methods or `BannerView` events.

But to catch all types of overlay presentations or external browser invocations, not just ones that come from ad clicks, your app is better off listening for the equivalent methods on `UIViewController` or `UIApplication`. Here is a table showing the equivalent iOS methods that are invoked at the same time as GADBannerViewDelegate methods:

| IBannerViewDelegate method/BannerView event       | iOS method                                     |
|:-------------------------------------------------:|:----------------------------------------------:|
| **WillPresentScreen**/**WillPresentScreen**       | UIViewController's **ViewWillDisappear**       |
| **WillDismissScreen**/**WillDismissScreen**       | UIViewController's **ViewWillAppear**          |
| **DidDismissScreen**/**ScreenDismissed**          | UIViewController's **ViewDidAppear**           |
| **WillLeaveApplication**/**WillLeaveApplication** | UIApplicationDelegate's **DidEnterBackground** |

## Banner sizes

The following banner sizes are supported:

| Size (WxH)              | Description          | Availability         | AdSize constant                                               |
|:-----------------------:|:--------------------:|:--------------------:|:-------------------------------------------------------------:|
| 320x50                  | Standard banner      | Phones and tablets   | kGADAdSizeBanner                                              |
| 320x100                 | Large banner         | Phones and tablets   | kGADAdSizeLargeBanner                                         |
| 300x250                 | IAB medium rectangle | Phones and tablets   | kGADAdSizeMediumRectangle                                     |
| 468x60                  | IAB full-size banner | Tablets              | kGADAdSizeFullBanner                                          |
| 728x90                  | IAB leaderboard      | Tablets              | kGADAdSizeLeaderboard                                         |
| Screen width x 32,50,90 | Smart banner         | Phones and tablets   | kGADAdSizeSmartBannerPortrait, kGADAdSizeSmartBannerLandscape |

If an app tries to load a banner that's too big for its layout, the SDK won't display it. Instead, an error message will be written to the log.

## Smart Banners

Smart Banners are ad units that render screen-wide banner ads on any screen size across different devices in either orientation. Smart Banners help deal with increasing screen fragmentation across different devices by "smartly" detecting the width of the phone in its current orientation, and making the ad view that size.

Smart Banners on iPhones have a height of 50 points in portrait and 32 points in landscape. On iPads, height is 90 points in both portrait and landscape.

When an image ad isn't large enough to take up the entire allotted space, the image will be centered, and the space on either side will be filled in.

To use Smart Banners, just specify `AdSizeCons.SmartBannerPortrait` or `AdSizeCons.SmartBannerLandscape` for the ad size:

```csharp
BannerView bannerView = new BannerView (AdSizeCons.SmartBannerPortrait);
```

Since the addition of the safe area for iOS 11, for full-width banners you should also add constraints for the edges of the banner to the edges of the safe area.

---

# Interstitial Ads

Interstitial ads are full-screen ads that are overlaid on top of an app. They are generally displayed at natural app transition points such as in between game levels. When an app shows an interstitial ad, the user has the choice to either tap on the ad and continue to its destination or close it and return to the app.

This guide shows you how to integrate interstitials from AdMob into an iOS app.

## Create a Interstitial object
Interstitials ads are requested and shown by `Interstitial` objects. The first step in using one is to instantiate it and set its ad unit ID. For example, here's how to create an `Interstitial` in the `ViewDidLoad` method of a `UIViewController`:

```csharp
using Google.MobileAds;

namespace YourNamespace
{
	public class YourViewController : UIViewController
	{
		Interstitial interstitial;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			interstitial = new Interstitial ("ca-app-pub-3940256099942544/4411468910");
		}
	}
}
```

`Interstitial` is a single-use object that will load and display one interstitial ad. To display multiple interstitial ads, an app needs to create an `Interstitial` object for each one.

## Load an ad

To load an interstitial, call the `Interstitial` object's `LoadRequest` method. This method accepts a `Request` object as its single argument:

```csharp
public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	interstitial = new Interstitial ("ca-app-pub-3940256099942544/4411468910");
	
	///
	interstitial.LoadRequest (Request.GetDefaultRequest ());
	///
}
```

## Show the ad

Interstitials should be displayed during natural pauses in the flow of an app. Between levels of a game is a good example, or after the user completes a task. To show an interstitial, check the `IsReady` property on `Interstitial` instance to verify that it's done loading, then call `PresentFromRootViewController` method. Here's an example of how to do this in one of the action methods in a `UIViewController`:

```csharp
public void DoSomething (NSObject sender)
{
	// ...

	if (interstitial.IsReady)
		interstitial.PresentFromRootViewController (this);
	else
		Console.WriteLine ("Ad wasn't ready...");
}
```

The message **"Cannot present interstitial. It is not ready"** indicates that the interstitial is still loading or has failed to load. To avoid this warning, use the `IsReady` property to check if the interstitial ad is ready to be presented prior to calling `PresentFromRootViewController` method.

## Use IInterstitialDelegate interface or Interstitial events to reload

`Interstitial` is a one-time-use object. That means once an interstitial is shown, `HasBeenUsed` property returns `true` and the interstitial can't be used to load another ad. To request another interstitial, you'll need to create a new `Interstitial` object. If you try to re-use an interstitial object, you'll get the error **"Request Error: Will not send request because interstitial object has been used"**.

The best place to allocate another interstitial is in the `DidDismissScreen` method of the `IInterstitialDelegate` interface so that the next interstitial starts loading as soon as the previous one is dismissed. You may even consider breaking out interstitial initialization into its own helper method:

```csharp
// For Export attribute
using Foundation;
using Google.MobileAds;

namespace YourNamespace
{
	public class YourViewController : UIViewController, IInterstitialDelegate
	{
		Interstitial interstitial;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			interstitial = CreateAndLoadInterstitial ();
		}

		Interstitial CreateAndLoadInterstitial ()
		{
			var newInterstitial = new Interstitial ("ca-app-pub-3940256099942544/4411468910") {
				Delegate = this
			};
			newInterstitial.LoadRequest (Request.GetDefaultRequest ());
			return newInterstitial;
		}

		[Export ("interstitialDidDismissScreen:")]
		public void DidDismissScreen (Interstitial ad)
		{
			interstitial = CreateAndLoadInterstitial ();
		}
	}
}
```

You can achieve the same result using `Interstitial` events:

```csharp
using Google.MobileAds;

namespace YourNamespace
{
	public class YourViewController : UIViewController
	{
		Interstitial interstitial;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			interstitial = CreateAndLoadInterstitial ();
		}

		Interstitial CreateAndLoadInterstitial ()
		{
			var newInterstitial = new Interstitial ("ca-app-pub-3940256099942544/4411468910");
			newInterstitial.ScreenDismissed += NewInterstitial_ScreenDismissed;
			newInterstitial.LoadRequest (Request.GetDefaultRequest ());
			return newInterstitial;
		}

		void NewInterstitial_ScreenDismissed (object sender, EventArgs e)
		{
			interstitial = CreateAndLoadInterstitial ();
		}
	}
}
```

By preloading another interstitial immediately after the previous one is dismissed, your app is prepared to show an interstitial again at the next logical break point.

## Ad events

Through the use of `IInterstitialDelegate` interface or `Interstitial` object events, you can listen for lifecycle events, such as when an ad is closed or the user leaves the app. If you decide to use Ad events, you must use the `IInterstitialDelegate` interface or `Interstitial` object events, you cannot use both or create a mix of them.

### Registering for interstitial events using IInterstitialDelegate interface

To register for interstitial ad events, set the `Delegate` property on `Interstitial` to an object that implements the `IInterstitialDelegate`interface. Generally, the class that implements interstitial ads also acts as the delegate class, in which case the `Delegate` property can be set to `this` as follows:

```csharp
// For Export attribute
using Google.MobileAds;

namespace YourNamespace
{
	public class YourViewController : UIViewController, IInterstitialDelegate
	{
		Interstitial interstitial;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			interstitial = new Interstitial ("ca-app-pub-3940256099942544/4411468910") {
				Delegate = this
			};
		}
	}
}
```

### Implementing interstitial events

Each of the methods in `IInterstitialDelegate` interface are marked as **optional**, so you only need to implement the methods you need. This also applies for `Interstitial` object events, you only need to implement the events you need. This example implements each method and logs a message to the console:

```csharp
// For Console class
using System;
// For Export attribute
using Fundation;

/// Tells the delegate an ad request succeeded.
[Export ("interstitialDidReceiveAd:")]
public void DidReceiveAd (Interstitial ad)
{
	Console.WriteLine ($"{nameof (DidReceiveAd)} method.");
}

interstitial.AdReceived += (sender, e) => {
	Console.WriteLine ("AdReceived event.");
};

/// Tells the delegate an ad request failed.
[Export ("interstitial:didFailToReceiveAdWithError:")]
public void DidFailToReceiveAd (Interstitial sender, RequestError error)
{
	Console.WriteLine ($"{nameof (DidFailToReceiveAd)} method with error: {error.LocalizedDescription}.");
}

interstitial.ReceiveAdFailed += (sender, e) => {
	Console.WriteLine ($"ReceiveAdFailed event with error: {e.Error.LocalizedDescription}.");
};

/// Tells the delegate that an interstitial will be presented.
[Export ("interstitialWillPresentScreen:")]
public void WillPresentScreen (Interstitial ad)
{
	Console.WriteLine ($"{nameof (WillPresentScreen)} method.");
}

interstitial.WillPresentScreen += (sender, e) => {
	Console.WriteLine ("WillPresentScreen event.");
};

/// Tells the delegate the interstitial failed to present.
[Export ("interstitialDidFailToPresentScreen:")]
public void DidFailToPresentScreen (Interstitial ad)
{
	Console.WriteLine ($"{nameof (DidFailToPresentScreen)} method.");
}

interstitial.FailedToPresentScreen += (sender, e) => {
	Console.WriteLine ("FailedToPresentScreen event.");
};

/// Tells the delegate the interstitial is to be animated off the screen.
[Export ("interstitialWillDismissScreen:")]
public void WillDismissScreen (Interstitial ad)
{
	Console.WriteLine ($"{nameof (WillDismissScreen)} method.");
}

interstitial.WillDismissScreen += (sender, e) => {
	Console.WriteLine ("WillDismissScreen event.");
};

/// Tells the delegate the interstitial had been animated off the screen.
[Export ("interstitialDidDismissScreen:")]
public void DidDismissScreen (Interstitial ad)
{
	Console.WriteLine ($"{nameof (DidDismissScreen)} method.");
}

interstitial.ScreenDismissed += (sender, e) => {
	Console.WriteLine ("ScreenDismissed event.");
};

/// Tells the delegate that a user click will open another app
/// (such as the App Store), backgrounding the current app.
[Export ("interstitialWillLeaveApplication:")]
public void WillLeaveApplication (Interstitial ad)
{
	Console.WriteLine ($"{nameof (WillLeaveApplication)} method.");
}

interstitial.WillLeaveApplication += (sender, e) => {
	Console.WriteLine ("WillLeaveApplication event.");
};
```

## Some best practices

### Consider whether interstitial ads are the right type of ad for your app.

Interstitial ads work best in apps with natural transition points. The conclusion of a task within an app, like sharing an image or completing a game level, creates such a point. Because the user is expecting a break in the action, it's easy to present an interstitial ad without disrupting their experience. Make sure you consider at which points in your app's workflow you'll display interstitial ads and how the user is likely to respond.

### Remember to pause the action when displaying an interstitial ad.

There are a number of different types of interstitial ads: text, image, video, and more. It's important to make sure that when your app displays an interstitial ad, it also suspends its use of some resources to allow the ad to take advantage of them. For example, when you make the call to display an interstitial ad, be sure to pause any audio output being produced by your app. You can resume playing sounds in the `DidDismissScreen` method of `IInterstitialDelegate` interface or in the `ScreenDismissed` event handler, which will be invoked when the user has finished interacting with the ad. In addition, consider temporarily halting any intense computation tasks (such as a game loop) while the ad is being displayed. This will make sure the user doesn't experience slow or unresponsive graphics or stuttered video.

### Allow for adequate loading time.

Just as it's important to make sure you display interstitial ads at an appropriate time, it's also important to make sure the user doesn't have to wait for them to load. Loading the ad in advance by calling `LoadRequest` method before you intend to call `PresentFromRootViewController` can ensure that your app has a fully loaded interstitial ad at the ready when the time comes to display one.

### Don't flood the user with ads.

While increasing the frequency of interstitial ads in your app might seem like a great way to increase revenue, it can also degrade the user experience and lower clickthrough rates. Make sure that users aren't so frequently interrupted that they're no longer able to enjoy the use of your app.

### Don't use the `InterstitialDelegate.DidReceiveAd` or `Interstitial.AdReceived` events to show the interstitial.

This can cause a poor user experience. Instead, pre-load the ad before you need to show it. Then check the `IsReady` method on `Interstitial` to find out if it is ready to be shown.

---

# Native Ads Advanced (Unified)

> ![note_icon] _Native Ads Advanced is currently in a limited beta release. If you are interested in participating, reach out to your account manager._

Native ads are ad assets that are presented to users via UI components that are native to the platform. They're shown using the same classes you already use in your storyboards, and can be formatted to match your app's visual design. When an ad loads, your app receives an ad object that contains its assets, and the app (rather than the SDK) is then responsible for displaying them.

This guide will show you how to use the Google Mobile Ads SDK to implement [native ads][6] in an iOS application, as well as some important things to consider along the way.

## Loading ads

There are two [system-defined formats for native ads][7]: app install and content.

Both types of ads are represented by one class: `UnifiedNativeAd`. An instance of this class contains the assets for the native ad. Note that depending on the type of ad represented by the `UnifiedNativeAd`, some fields will not be populated (i.e., they will be `null`).

Native ads are loaded via `AdLoader` objects, which send messages to their delegates according to the `IAdLoaderDelegate` interface.

### Initialize the ad loader

Before you can load an ad, you have to initialize the ad loader. The following code demonstrates how to initialize a `AdLoader`:

```csharp
adLoader = new AdLoader ("ca-app-pub-3940256099942544/3986624511",
			 this,
			 new [] { AdLoaderType.UnifiedNative },
			 new [] { /* ad loader options objects */ }) {
	Delegate = this
};
```

You'll need an ad unit ID (you can use the test ID), constants to pass in the `adTypes` array to specify which native formats you want to request, and any options you wish to set in the options parameter. The list of possible values for the `options` parameter can be found below in the Setting **native ad options** section below.

The adTypes array should contain the following constant:

* AdLoaderType.UnifiedNative

### Implement the ad loader delegate

The ad loader delegate needs to implement protocols specific your ad type. For unified native ads:

* `IUnifiedNativeAdLoaderDelegate`: This protocol includes a message that's sent to the delegate when a unified native ad has loaded:

	```csharp
	public void DidReceiveUnifiedNativeAd (AdLoader adLoader, UnifiedNativeAd nativeAd);
	```

### Request the ad

Once your `AdLoader` is initialized, call its `LoadRequest` method to request an ad:

```csharp
adLoader.LoadRequest (Request.GetDefaultRequest ());
```

The `LoadRequest` method in `AdLoader` accepts the same `Request` objects as banners and interstitials. You can use request objects to [add targeting information][8], just as you would with other ad types.

### When to request ads

Apps displaying native ads are free to request them in advance of when they'll actually be displayed. In many cases, this is the recommended practice. An app displaying a list of items with native ads mixed in, for example, can load native ads for the whole list, knowing that some will be shown only after the user scrolls the view and some may not be displayed at all.

> ![note_icon] _While prefetching ads is a great technique, it's important that you don't keep old ads around forever without displaying them. Any native ad objects that have been held without display for longer than an hour should be discarded and replaced with new ads from a new request_

> ![note_icon] _**Note:**_ _When reusing a `AdLoader`, make sure you wait for each request to complete before calling `LoadRequest` again._

### Determining when loading has finished

After an app calls `LoadRequest`, it can get the results of the request via calls to:

* `DidFailToReceiveAd` in `IAdLoaderDelegate`
* `DidReceiveUnifiedNativeAd` in `IUnifiedNativeAdLoaderDelegate`

A request for a single ad will result in one call to one of those methods.

A request for multiple ads will result in at least one callback to the above methods, but no more than the maximum number of ads requested.

> ![note_icon] _**Note:**_ _Requests for multiple native ads don't currently work for AdMob ad unit IDs that have been configured for mediation. Publishers using mediation should avoid using the `MultipleAdsAdLoaderOptions` class when making requests._

In addition, `IAdLoaderDelegate` offers the `DidFinishLoading` callback. This delegate method indicates that an ad loader has finished loading ads and no other ads or errors will be reported for the request. Here's an example of how to use it when loading several native ads at one time:

```csharp
using Google.MobileAds

public partial class ViewController : UIViewController, IUnifiedNativeAdLoaderDelegate, IVideoControllerDelegate {
	AdLoader adLoader;

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

		var multipleAdsOptions = new MultipleAdsAdLoaderOptions { NumberOfAds = 5 };
		adLoader = new AdLoader ("YOUR_AD_UNIT_ID", this, new [] { AdLoaderType.UnifiedNative }, new [] { multipleAdsOptions }) {
			Delegate = this
		};
		adLoader.LoadRequest (Request.GetDefaultRequest ());
	}

	public void DidReceiveUnifiedNativeAd (AdLoader adLoader, UnifiedNativeAd nativeAd)
	{
		// A unified native ad has loaded, and can be displayed.
	}

	// @optional - (void)adLoaderDidFinishLoading:(GADAdLoader *)adLoader;
	[Export ("adLoaderDidFinishLoading:")]
	void DidFinishLoading (AdLoader adLoader)
	{
		// The adLoader has finished loading ads, and a new request can be sent.
	}
}
```

### Handling failed requests

The above protocols extend the `IAdLoaderDelegate` protocol, which defines a message sent when ads fail to load. You can use the `RequestError` object to determine the cause of the error.

```csharp
public void DidFailToReceiveAd (AdLoader adLoader, RequestError error);
```

### Get notified of native ad events

To be notified of events related to the native ad interactions, you can use the `IUnifiedNativeAdDelegate` interface methods by setting the `UnifiedNativeAd.Delegate` property or use the `UnifiedNativeAd` events but you cannot use both or create a mix of them:

```csharp
// If you decide to implement the IUnifiedNativeAdDelegate interface
nativeAd.Delegate = this;
```

Then implement `IUnifiedNativeAdDelegate` interface or set the `UnifiedNativeAd` events to receive the following calls:

```csharp
[Export ("nativeAdDidRecordImpression:")]
void DidRecordImpression (UnifiedNativeAd nativeAd)
{
	// The native ad was shown.
}

nativeAd.ImpressionRecorded += (sender, e) => {
	// The native ad was shown.
};

[Export ("nativeAdDidRecordClick:")]
void DidRecordClick (UnifiedNativeAd nativeAd)
{
	// The native ad was clicked on.
}

nativeAd.ClickRecorded += (sender, e) => {
	// The native ad was clicked on.
};

[Export ("nativeAdWillPresentScreen:")]
void WillPresentScreen (UnifiedNativeAd nativeAd)
{
	// The native ad will present a full screen view.
}

nativeAd.WillPresentScreen += (sender, e) => {
	// The native ad will present a full screen view.
};

// @optional -(void)nativeAdWillDismissScreen:(GADUnifiedNativeAd * _Nonnull)nativeAd;
void WillDismissScreen (UnifiedNativeAd nativeAd)
{
	// The native ad will dismiss a full screen view.
}

nativeAd.WillDismissScreen += (sender, e) => {
	// The native ad will dismiss a full screen view.
};

[Export ("nativeAdDidDismissScreen:")]
void DidDismissScreen (UnifiedNativeAd nativeAd)
{
	// The native ad did dismiss a full screen view.
}

nativeAd.ScreenDismissed += (sender, e) => {
	// The native ad did dismiss a full screen view.
};

[Export ("nativeAdWillLeaveApplication:")]
void WillLeaveApplication (UnifiedNativeAd nativeAd)
{
	// The native ad will cause the application to become inactive and
	// open a new application.
}

nativeAd.WillLeaveApplication += (sender, e) => {
	// The native ad will cause the application to become inactive and
	// open a new application.
};
```

## Native ad options

The last parameter included in the creation of the `AdLoader` above is an optional array of objects.

```csharp
adLoader = new AdLoader ("ca-app-pub-3940256099942544/3986624511",
			 this,
			 new [] { AdLoaderType.UnifiedNative },
		     --> new [] { /* ad loader options objects */ });
```

This optional array holds one or more instances of a `AdLoaderOptions` subclass (`NativeAdImageAdLoaderOptions`), which are objects that an app can use to indicate its preferences for how native ads should be loaded and behave.

`NativeAdImageAdLoaderOptions` contains properties relating to images in Native Advanced ads. Apps can control how a `AdLoader` handles Native Ads Advanced image assets by creating a `NativeAdImageAdLoaderOptions` object, setting its properties (`DisableImageLoading`, `PreferredImageOrientation`, and `HhouldRequestMultipleImages`), and passing it in during initialization.

`NativeAdImageAdLoaderOptions` has the following propeties:

* `DisableImageLoading`

	Image assets for native ads are returned via instances of `NativeAdImage`, which contains `Image` and `ImageUrl` properties. If `DisableImageLoading` is set to `false`, which is the default, the SDK will fetch image assets automatically and populate both the `Image` and the `ImageUrl` properties for you. If it's set to `true`, the SDK will only populate `ImageUrl`, allowing you to download the actual images at your discretion.

* `PreferredImageOrientation`

	Some creatives have multiple images available to match different device orientations. Apps can request images for a particular orientation by setting this property to one of the orientation constants:

	* `NativeAdImageAdLoaderOptionsOrientation.Any`
	* `NativeAdImageAdLoaderOptionsOrientation.Landscape`
	* `NativeAdImageAdLoaderOptionsOrientation.Portrait`

	> ![note_icon] `If you use `PreferredImageOrientation` to specify a preference for landscape or portrait image orientation, the SDK will place images matching that orientation first in image asset arrays and place non-matching images after them. Since some ads will only have one orientation available, publishers should make sure that their apps can handle both landscape and portrait images.`

	If this property is not set, the default value of `NativeAdImageAdLoaderOptionsOrientation.Any` will be used.

* `ShouldRequestMultipleImages`

	Some image assets will contain a series of images rather than just one. By setting this value to `true`, your app indicates that it's prepared to display all the images for any assets that have more than one. By setting it to `false` (the default) your app instructs the SDK to provide just the first image for any assets that contain a series.

	If no `AdLoaderOptions` objects are passed in when initializing a `AdLoader`, the default value for each option will be used.

### `NativeAdViewOptions`

`NativeAdViewAdOptions` objects are used to indicate preferences for how native ad views should represent ads. They have a single property: `PreferredAdChoicesPosition`, which you can use to specify the location where the AdChoices icon should be placed. The icon can appear at any corner of the ad, and defaults to `AdChoicesPosition.TopRightCorner`. The possible values for this property are:

* AdChoicesPosition.TopRightCorner
* AdChoicesPosition.TopLeftCorner
* AdChoicesPosition.BottomRightCorner
* AdChoicesPosition.BottomLeftCorner

Here's an example showing how to place the AdChoices icon in the top left corner of an ad:

```csharp
NativeAdViewAdOptions adViewAdOptions = new NativeAdViewAdOptions { PreferredAdChoicesPosition = AdChoicesPosition.TopLeftCorner };
adLoader = new AdLoader ("YOUR_AD_UNIT_ID", this, new [] { AdLoaderType.UnifiedNative }, new [] { adViewAdOptions });
```

### `VideoOptions`

`VideoOptions` objects are used to indicate how native video assets should be displayed. They offer a single property: `StartMuted`.

This boolean indicates whether video assets should begin playback in a muted state. The default value is `true`.

### `MultipleAdsAdLoaderOptions`

`MultipleAdsAdLoaderOptions` objects allow publishers to instruct an ad loader to load multiple ads in a single request. Ads loaded in this way are guaranteed to be unique. `MultipleAdsAdLoaderOptions` has a single property, `NumberOfAds`, which represents the number of ads the ad loader should attempt to return for the request. By default this value is one, and it's capped at a maximum of five (even if an app requests more ads, at most five will be returned). The actual number of ads returned is not guaranteed, but will be between zero and `NumberOfAds`.

## Displaying a system-defined native ad format

When an ad loads, your app receives an ad object via one of the `IAdLoaderDelegate` protocol messages. Your app is then responsible for displaying the ad (though it doesn't necessarily have to do so immediately). To make displaying system-defined ad formats easier, the SDK offers some useful resources.

### UnifiedNativeAdView

For the `UnifiedNativeAd`, there is a corresponding "ad view" class: `UnifiedNativeAdView`. This ad view class is a `UIView` that publishers should use to display the ad. A single `UnifiedNativeAdView`, for example, can display a single instance of a `UnifiedNativeAd`. Each of the `UIView` objects used to display that ad's assets should be subviews of that `UnifiedNativeAdView` object.

If you were displaying an app install ad in a `UITableView`, for example, the view hierarchy for one of the cells might look like this:

![UITable](https://developers.google.com/admob/images/ios_app_install_layout.png)

The `UnifiedNativeAdView` class also provides `IBOutlets` used to register the view used for each individual asset, and a method to register the `UnifiedNativeAd` object itself. Registering the views in this way allows the SDK to automatically handle tasks such as:

* Recording clicks.
* Recording impressions (when the first pixel is visible on the screen).
* Displaying the AdChoices overlay.

### The AdChoices overlay

For indirect native ads (delivered via AdMob backfill or through Ad Exchange or AdSense), an AdChoices overlay is added by the SDK. Please, leave space in [your preferred corner](#NativeAdViewOptions) of your native ad view for the automatically inserted AdChoices logo. Also, it's important that the AdChoices overlay be easily seen, so choose background colors and images appropriately. For more information on the overlay's appearance and function, see [Guidelines for programmatic native ads using native styles][5].

### Ad attribution

When displaying programmatic native ads, you must display an ad attribution to denote that the view is an advertisement.

## Native video

In addition to images, text, and numbers, some native ads contain video assets. Not every ad will have one and apps are not required to display videos when they're included with an ad.

### MediaView

Video assets are displayed to users via `MediaView`. This is a `UIView` that can be defined in a xib file or constructed dynamically. It should be placed within the view hierarchy of a `NativeAdView`, as with any other asset view.

Unlike other asset views, however, apps do not need to manually populate a `MediaView` with its asset. The SDK handles this automatically as follows:

* If a video asset is available, it is buffered and starts playing inside the MediaView.
* If the ad does not contain a video asset, the first image asset is downloaded and placed inside the `MediaView` instead.

This autopopulation of the `MediaView` with an available image asset does not always work when you're using mediation. Because not all mediation adapters guarantee that they'll create a media view for every ad, it's possible for a blank one to be returned for mediated ads. If you're using mediation, you should check the `HasVideoContent` property of an ad's `VideoController` to see if it contains a video asset, before displaying the `MediaView`. If there is no video content, you should display an image view that you populate manually with a relevant image.

### VideoController

The `VideoController` class is used to retrieve information about video assets. `NativeAppInstallAd` and `NativeContentAd` both offer a `VideoController` property that exposes the `VideoController` for each ad:

```csharp
VideoController vc1 = myAppInstallAd.VideoController;
VideoController vc2 = myContentAd.VideoController;
```

This property is never `null`, even when the ad doesn't contain a video asset.

`VideoController` offers the following methods for querying video state:

* HasVideoContent - True if the ad includes a video asset, false otherwise.
* AspectRatio - The aspect ratio of the video (width/height) or zero (if no video asset is present).

Apps can also set a `IVideoControllerDelegate` for the `VideoController` to be notified of events in the lifecycle of a video asset, also, you can use `VideoController` events instead of `IVideoControllerDelegate` methods. `IVideoControllerDelegate` offers a single optional method, `DidEndVideoPlayback`, as well as `VideoController` offers a `VideoPlaybackEnded` event, which is sent when a video completes playback.

Here's an example of `IViewControllerDelegate` in action:

```csharp
public class YourViewController : UIViewController, IUnifiedNativeAdLoaderDelegate, IVideoControllerDelegate
{
	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
	}

	public void DidReceiveUnifiedNativeAd (AdLoader adLoader, UnifiedNativeAd nativeAd)
	{
		nativeAppInstallAd.VideoController.Delegate = this;
	}

	[Export ("videoControllerDidEndVideoPlayback:")]
	public void DidEndVideoPlayback (VideoController videoController)
	{
		// Here apps can take action knowing video playback is finished.
		// This is handy for things like unmuting audio, and so on.
	}
}
```

Here's an example of `ViewController` events in action:

```csharp
public class YourViewController : UIViewController, IUnifiedNativeAdLoaderDelegate
{
	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
		nativeAppInstallAd.VideoController.VideoPlaybackEnded += (sender, e) => {
			// Here apps can take action knowing video playback is finished.
			// This is handy for things like unmuting audio, and so on.
		};
	}

	public void DidReceiveUnifiedNativeAd (AdLoader adLoader, UnifiedNativeAd nativeAd)
	{
		
	}
}
```

---

# Native Ads Advanced

> ![note_icon] **_Note:_** _Native Ads Advanced is currently in a limited beta release. If you are interested in participating, reach out to your account manager to discuss the possibility. This feature will be made available to all publishers at the conclusion of the beta._

Native ads are ad assets that are presented to users via UI components that are native to the platform. They're shown using the same classes you already use in your storyboards, and can be formatted to match your app's visual design. When an ad loads, your app receives an ad object that contains its assets, and the app (rather than the SDK) is then responsible for displaying them.

## Loading ads

There are two [system-defined formats for native ads][4]: app install and content. 

App install ads are represented by `NativeAppInstallAd`, and content ads are represented by `NativeContentAd`. Instances of the classes contain the assets for the native ad.

Native Advanced ads are loaded via `AdLoader` objects, which send messages to their delegates according to the `IAdLoaderDelegate` interface.

### Initialize a AdLoader

Before you can load an ad, you have to initialize the ad loader. The following code demonstrates how to initialize a `AdLoader` for an app install ad:

```csharp
var adLoader = new AdLoader ("ca-app-pub-3940256099942544/3986624511", 
			     this, 
			     new NSObject [] { /* ad type constants */ }, 
			     new AdLoaderOptions [] { /* ad loader options objects */ });
adLoader.Delegate = this;
```

You'll need an ad unit ID (you can use the test ID), constants to pass in the `adTypes` array to specify which native formats you want to request, and any options you wish to set in the options parameter. The list of possible values for the `options` parameter can be found below in the Setting **native ad options** section below.

The adTypes array should contain one or more of the following constants:

* AdLoaderType.NativeAppInstall
* AdLoaderType.NativeContent

### Implement the ad loader delegate

The ad loader delegate needs to implement protocols specific your ad type. For native ads:

* `INativeAppInstallAdLoaderDelegate`: This interface includes a message that's sent to the delegate when an app install ad has loaded:

	```csharp
	public void DidReceiveNativeAppInstallAd (AdLoader adLoader, NativeAppInstallAd nativeAppInstallAd);
	```

* `INativeContentAdLoaderDelegate` This protocol defines a message sent when a content ad has loaded:

	```csharp
	public void DidReceiveNativeContentAd (AdLoader adLoader, NativeContentAd nativeContentAd);
	```

### Request the ad

Once your `AdLoader` is initialized, call its `LoadRequest` method to request an ad:

```csharp
adLoader.LoadRequest (Request.GetDefaultRequest ());
```

The `LoadRequest` method in `AdLoader` accepts the same `Request` objects as banners and interstitials. You can use request objects to add targeting information just as you would with other ad types.

### When to request ads

Apps displaying native ads are free to request them in advance of when they'll actually be displayed. In many cases, this is the recommended practice. An app displaying a list of items with native ads mixed in, for example, can load native ads for the whole list, knowing that some will be shown only after the user scrolls the view and some may not be displayed at all.

> ![note_icon] _While prefetching ads is a great technique, it's important that you don't keep old ads around forever without displaying them. Any native ad objects that have been held without display for longer than an hour should be discarded and replaced with new ads from a new request._

> ![note_icon] **_Note:_** _When reusing a `AdLoader`, make sure you wait for each request to complete before calling `LoadRequest` again._

### Determining when loading has finished

After an app calls `LoadRequest`, it can get the results of the request via calls to:

* `DidFailToReceiveAd` in `IAdLoaderDelegate`
* `DidReceiveNativeAppInstallAd` in `INativeAppInstallAdLoaderDelegate`
* `DidReceiveNativeContentAd` in `INativeContentAdLoaderDelegate`

A request for a single ad will result in one call to one of those methods.

A request for multiple ads will result in at least one callback to the above methods, but no more than the maximum number of ads requested.

> ![note_icon] _**Note:**_ _Requests for multiple native ads don't currently work for AdMob ad unit IDs that have been configured for mediation. Publishers using mediation should avoid using the `MultipleAdsAdLoaderOptions` class when making requests._

In addition, `IAdLoaderDelegate` offers the `DidFinishLoading` callback. This delegate method indicates that an ad loader has finished loading ads and no other ads or errors will be reported for the request. Here's an example of how to use it when loading several native ads at one time:

```csharp
using Google.MobileAds

public partial class ViewController : UIViewController, INativeAppInstallAdLoaderDelegate, INativeContentAdLoaderDelegate, IVideoControllerDelegate {
	AdLoader adLoader;

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

		var multipleAdsOptions = new MultipleAdsAdLoaderOptions { NumberOfAds = 5 };
		adLoader = new AdLoader ("YOUR_AD_UNIT_ID", this, new [] { AdLoaderType.UnifiedNative }, new [] { multipleAdsOptions }) {
			Delegate = this
		};
		adLoader.LoadRequest (Request.GetDefaultRequest ());
	}

	public void DidReceiveNativeAppInstallAd (AdLoader adLoader, NativeAppInstallAd nativeAppInstallAd)
	{
		// An app install ad has loaded, and can be displayed.
	}

	public void DidReceiveNativeContentAd (AdLoader adLoader, NativeContentAd nativeContentAd)
	{
		// A content ad has loaded, and can be displayed.
	}

	// @optional - (void)adLoaderDidFinishLoading:(GADAdLoader *)adLoader;
	[Export ("adLoaderDidFinishLoading:")]
	void DidFinishLoading (AdLoader adLoader)
	{
		// The adLoader has finished loading ads, and a new request can be sent.
	}
}
```

### Handling failed requests

The above protocols extend the `IAdLoaderDelegate` protocol, which defines a message sent when ads fail to load. You can use the `RequestError` object to determine the cause of the error.

```csharp
public void DidFailToReceiveAd (AdLoader adLoader, RequestError error);
```

### Get notified of native ad events

To be notified of events related to the native ad interactions, you can use the `IUnifiedNativeAdDelegate` interface methods by setting the `UnifiedNativeAd.Delegate` property or use the `UnifiedNativeAd` events but you cannot use both or create a mix of them:

```csharp
// If you decide to implement the IUnifiedNativeAdDelegate interface
nativeAd.Delegate = this;
```

Then implement `IUnifiedNativeAdDelegate` interface or set the `UnifiedNativeAd` events to receive the following calls:

```csharp
[Export ("nativeAdDidRecordImpression:")]
void DidRecordImpression (UnifiedNativeAd nativeAd)
{
	// The native ad was shown.
}

nativeAd.ImpressionRecorded += (sender, e) => {
	// The native ad was shown.
};

[Export ("nativeAdDidRecordClick:")]
void DidRecordClick (UnifiedNativeAd nativeAd)
{
	// The native ad was clicked on.
}

nativeAd.ClickRecorded += (sender, e) => {
	// The native ad was clicked on.
};

[Export ("nativeAdWillPresentScreen:")]
void WillPresentScreen (UnifiedNativeAd nativeAd)
{
	// The native ad will present a full screen view.
}

nativeAd.WillPresentScreen += (sender, e) => {
	// The native ad will present a full screen view.
};

// @optional -(void)nativeAdWillDismissScreen:(GADUnifiedNativeAd * _Nonnull)nativeAd;
void WillDismissScreen (UnifiedNativeAd nativeAd)
{
	// The native ad will dismiss a full screen view.
}

nativeAd.WillDismissScreen += (sender, e) => {
	// The native ad will dismiss a full screen view.
};

[Export ("nativeAdDidDismissScreen:")]
void DidDismissScreen (UnifiedNativeAd nativeAd)
{
	// The native ad did dismiss a full screen view.
}

nativeAd.ScreenDismissed += (sender, e) => {
	// The native ad did dismiss a full screen view.
};

[Export ("nativeAdWillLeaveApplication:")]
void WillLeaveApplication (UnifiedNativeAd nativeAd)
{
	// The native ad will cause the application to become inactive and
	// open a new application.
}

nativeAd.WillLeaveApplication += (sender, e) => {
	// The native ad will cause the application to become inactive and
	// open a new application.
};
```

## Native ad options

The last parameter included in the creation of the `AdLoader` above is an optional array of objects:

```csharp
var adLoader = new AdLoader ("ca-app-pub-3940256099942544/3986624511", 
			     this, 
			     new NSObject [] { /* ad type constants */ }, 
			 --> new AdLoaderOptions [] { /* ad loader options objects */ });
```

This optional array holds one or more instances of a `AdLoaderOptions` subclass, objects that an app can use to indicate its preferences for how native ads should be loaded and behave.

`NativeAdImageAdLoaderOptions` contains properties relating to images in Native Advanced ads. Apps can control how a `AdLoader` handles Native Ads Advanced image assets by creating a `NativeAdImageAdLoaderOptions` object, setting its properties (DisableImageLoading, PreferredImageOrientation, and ShouldRequestMultipleImages), and passing it in during initialization.

* `DisableImageLoading`

	Image assets for native ads are returned via instances of `NativeAdImage`, which contains `Image` and `ImageUrl` properties. If `DisableImageLoading` is set to `false`, which is the default, the SDK will fetch image assets automatically and populate both the `Image` and the `ImageUrl` properties for you. If it's set to `true`, the SDK will only populate `ImageUrl`, allowing you to download the actual images at your discretion.

* `PreferredImageOrientation`

	Some creatives have multiple images available to match different device orientations. Apps can request images for a particular orientation by setting this property to one of the orientation constants:

	* `NativeAdImageAdLoaderOptionsOrientation.Any`
	* `NativeAdImageAdLoaderOptionsOrientation.Landscape`
	* `NativeAdImageAdLoaderOptionsOrientation.Portrait`

	> ![note_icon] `If you use `PreferredImageOrientation` to specify a preference for landscape or portrait image orientation, the SDK will place images matching that orientation first in image asset arrays and place non-matching images after them. Since some ads will only have one orientation available, publishers should make sure that their apps can handle both landscape and portrait images.`

	If this property is not set, the default value of `NativeAdImageAdLoaderOptionsOrientation.Any` will be used.

* `ShouldRequestMultipleImages`

	Some image assets will contain a series of images rather than just one. By setting this value to `true`, your app indicates that it's prepared to display all the images for any assets that have more than one. By setting it to `false` (the default) your app instructs the SDK to provide just the first image for any assets that contain a series.

	If no `AdLoaderOptions` objects are passed in when initializing a `AdLoader`, the default value for each option will be used.

### `NativeAdViewOptions`

`NativeAdViewAdOptions` objects are used to indicate preferences for how native ad views should represent ads. They have a single property: `PreferredAdChoicesPosition`, which you can use to specify the location where the AdChoices icon should be placed. The icon can appear at any corner of the ad, and defaults to `AdChoicesPosition.TopRightCorner`. The possible values for this property are:

* AdChoicesPosition.TopRightCorner
* AdChoicesPosition.TopLeftCorner
* AdChoicesPosition.BottomRightCorner
* AdChoicesPosition.BottomLeftCorner

Here's an example showing how to place the AdChoices icon in the top left corner of an ad:

```csharp
NativeAdViewAdOptions adViewAdOptions = new NativeAdViewAdOptions { PreferredAdChoicesPosition = AdChoicesPosition.TopLeftCorner };
adLoader = new AdLoader ("YOUR_AD_UNIT_ID", this, new [] { AdLoaderType.UnifiedNative }, new [] { adViewAdOptions });
```

### `VideoOptions`

`VideoOptions` objects are used to indicate how native video assets should be displayed. They offer a single property: `StartMuted`.

This boolean indicates whether video assets should begin playback in a muted state. The default value is `true`.

### `MultipleAdsAdLoaderOptions`

`MultipleAdsAdLoaderOptions` objects allow publishers to instruct an ad loader to load multiple ads in a single request. Ads loaded in this way are guaranteed to be unique. `MultipleAdsAdLoaderOptions` has a single property, `NumberOfAds`, which represents the number of ads the ad loader should attempt to return for the request. By default this value is one, and it's capped at a maximum of five (even if an app requests more ads, at most five will be returned). The actual number of ads returned is not guaranteed, but will be between zero and `NumberOfAds`.

## Displaying a system-defined native ad format

When an ad loads, your app receives an ad object via one of the `IAdLoaderDelegate` protocol messages. Your app is then responsible for displaying the ad (though it doesn't necessarily have to do so immediately). To make displaying system-defined ad formats easier, the SDK offers some useful resources.

### The ad view classes

For each of the system-defined formats, there is a corresponding "ad view" class: `NativeAppInstallAdView` for app install ads, and `NativeContentAdView` for content ads. These ad view classes are `UIView`s that publishers should use to display ads of the corresponding format. A single `NativeAppInstallAdView`, for example, can display a single instance of a `NativeAppInstallAd`. Each of the `UIView`s used to display that ad's assets should be children of that `NativeAppInstallAdView` object.

If you were displaying an app install ad in a `UITableView`, for example, the view hierarchy for one of the cells might look like this:

![UITable](https://developers.google.com/admob/images/ios_app_install_layout.png)

The ad view classes also provide `Outlet` attributes used to register the view used for each individual asset, and a method to register the `NativeAd` object itself. Registering the views in this way allows the SDK to automatically handle tasks such as:

* Recording clicks.
* Recording impressions (when the first pixel is visible on the screen).
* Displaying the AdChoices overlay.

### The AdChoices overlay

An AdChoices overlay is added to each ad view by the SDK. Leave space in [your preferred corner](#NativeAdViewOptions) of your native ad view for the automatically inserted AdChoices logo. Also, it's important that the AdChoices overlay be easily seen, so choose background colors and images appropriately. For more information on the overlay's appearance and function, see [Guidelines for programmatic native ads using native styles][5].

### Ad attribution

When displaying programmatic native ads, you must display an ad attribution to denote that the view is an advertisement.

## Native video

In addition to images, text, and numbers, some native ads contain video assets. Not every ad will have one and apps are not required to display videos when they're included with an ad.

### MediaView

Video assets are displayed to users via `MediaView`. This is a `UIView` that can be defined in a xib file or constructed dynamically. It should be placed within the view hierarchy of a `NativeAdView`, as with any other asset view.

Unlike other asset views, however, apps do not need to manually populate a `MediaView` with its asset. The SDK handles this automatically as follows:

* If a video asset is available, it is buffered and starts playing inside the MediaView.
* If the ad does not contain a video asset, the first image asset is downloaded and placed inside the `MediaView` instead.

This autopopulation of the `MediaView` with an available image asset does not always work when you're using mediation. Because not all mediation adapters guarantee that they'll create a media view for every ad, it's possible for a blank one to be returned for mediated ads. If you're using mediation, you should check the `HasVideoContent` property of an ad's `VideoController` to see if it contains a video asset, before displaying the `MediaView`. If there is no video content, you should display an image view that you populate manually with a relevant image.

### VideoController

The `VideoController` class is used to retrieve information about video assets. `NativeAppInstallAd` and `NativeContentAd` both offer a `VideoController` property that exposes the `VideoController` for each ad:

```csharp
VideoController vc1 = myAppInstallAd.VideoController;
VideoController vc2 = myContentAd.VideoController;
```

This property is never `null`, even when the ad doesn't contain a video asset.

`VideoController` offers the following methods for querying video state:

* HasVideoContent - True if the ad includes a video asset, false otherwise.
* AspectRatio - The aspect ratio of the video (width/height) or zero (if no video asset is present).

Apps can also set a `IVideoControllerDelegate` for the `VideoController` to be notified of events in the lifecycle of a video asset, also, you can use `VideoController` events instead of `IVideoControllerDelegate` methods. `IVideoControllerDelegate` offers a single optional method, `DidEndVideoPlayback`, as well as `VideoController` offers a `VideoPlaybackEnded` event, which is sent when a video completes playback.

Here's an example of `IViewControllerDelegate` in action:

```csharp
public class YourViewController : UIViewController, IVideoControllerDelegate
{
	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
		nativeAppInstallAd.VideoController.Delegate = this;
	}

	[Export ("videoControllerDidEndVideoPlayback:")]
	public void DidEndVideoPlayback (VideoController videoController)
	{
		// Here apps can take action knowing video playback is finished.
		// This is handy for things like unmuting audio, and so on.
	}
}
```

Here's an example of `ViewController` events in action:

```csharp
public class YourViewController : UIViewController
{
	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
		nativeAppInstallAd.VideoController.VideoPlaybackEnded += (sender, e) => {
			// Here apps can take action knowing video playback is finished.
			// This is handy for things like unmuting audio, and so on.
		};
	}
}
```

---

# Rewarded Video Ads

Rewarded video ads are full-screen video ads that users have the option of watching in full in exchange for in-app rewards.

This guide shows you how to integrate rewarded video ads from AdMob into an iOS app.

## Request rewarded video

`RewardBasedVideoAd` has a singleton design, so the following example shows a request to load an ad being made to the shared instance:

```csharp
RewardBasedVideoAd.SharedInstance.LoadRequest (Request.GetDefaultRequest (), "ca-app-pub-3940256099942544/1712485313");
```

To allow videos to be preloaded, we recommend calling `LoadRequest` method as early as possible (for example, in your app delegate's `FinishedLaunching` method).

## Set up event notifications

To set up event notification, you can use `RewardBasedVideoAd` events or implement the `IRewardBasedVideoAdDelegate` interface.

If you plan to implement the `RewardBasedVideoAd` events, you are required to set the events prior to loading an ad. If you plan to implement `IRewardBasedVideoAdDelegate` interface instead of `RewardBasedVideoAd` events, you are required to set the `Delegate` prior to loading an ad. Insert the line shown before your `LoadRequest` call:

```csharp
RewardBasedVideoAd.SharedInstance.Delegate = this;
```

`IRewardBasedVideoAdDelegate` notifies you of rewarded video lifecycle events. You are required to set the delegate prior to loading an ad. The most important method in this interface is `DidRewardUser` or `UserRewarded` if you are using `RewardBasedVideoAd` events, which is called when the user should be rewarded for watching a video. You may optionally implement other methods or events.

Here is an example that logs each method available in `IRewardBasedVideoAdDelegate` interface, as well as each event in `RewardBasedVideoAd` class:

```csharp
// For Export attribute
using Foundation;

public void DidRewardUser (RewardBasedVideoAd rewardBasedVideoAd, AdReward reward)
{
	Console.WriteLine ($"Reward received with currency {reward.Type}, amount {reward.Amount}");
}

RewardBasedVideoAd.SharedInstance.UserRewarded += (sender, e) => {
	Console.WriteLine ($"Reward received with currency {e.Reward.Type}, amount {e.Reward.Amount}");
};

///

[Export ("rewardBasedVideoAd:didFailToLoadWithError:")]
public void DidFailToLoad (RewardBasedVideoAd rewardBasedVideoAd, NSError error)
{
	Console.WriteLine ($"Reward based video ad failed to load with error: {error.LocalizedDescription}.");
}

RewardBasedVideoAd.SharedInstance.FailedToLoad += (sender, e) => {
	Console.WriteLine ($"Reward based video ad failed to load with error: {e.Error.LocalizedDescription}.");
};

///

[Export ("rewardBasedVideoAdDidReceiveAd:")]
public void DidReceiveAd (RewardBasedVideoAd rewardBasedVideoAd)
{
	Console.WriteLine ("Reward based video ad is received.");
}

RewardBasedVideoAd.SharedInstance.AdReceived += (sender, e) => {
	Console.WriteLine ("Reward based video ad is received.");
};

///

[Export ("rewardBasedVideoAdDidOpen:")]
public void DidOpen (RewardBasedVideoAd rewardBasedVideoAd)
{
	Console.WriteLine ("Opened reward based video ad.");
}

RewardBasedVideoAd.SharedInstance.Opened += (sender, e) => {
	Console.WriteLine ("Opened reward based video ad.");
};

///

[Export ("rewardBasedVideoAdDidStartPlaying:")]
public void DidStartPlaying (RewardBasedVideoAd rewardBasedVideoAd)
{
	Console.WriteLine ("Reward based video ad started playing.");
}

RewardBasedVideoAd.SharedInstance.PlayingStarted += (sender, e) => {
	Console.WriteLine ("Reward based video ad started playing.");
};

///

[Export ("rewardBasedVideoAdDidClose:")]
public void DidClose (RewardBasedVideoAd rewardBasedVideoAd)
{
	Console.WriteLine ("Reward based video ad is closed.");
}

RewardBasedVideoAd.SharedInstance.Closed += (sender, e) => {
	Console.WriteLine ("Reward based video ad is closed.");
};

///

[Export ("rewardBasedVideoAdWillLeaveApplication:")]
public void WillLeaveApplication (RewardBasedVideoAd rewardBasedVideoAd)
{
	Console.WriteLine ("Reward based video ad will leave application.");
}

RewardBasedVideoAd.SharedInstance.WillLeaveApplication += (sender, e) => {
	Console.WriteLine ("Reward based video ad will leave application.");
};
```

## Display rewarded video

It is a best practice to ensure a rewarded video ad has completed loading before attempting to display it. The `IsReady` property indicates that a rewarded video ad request has been successfully fulfilled:

```csharp
if (RewardBasedVideoAd.SharedInstance.IsReady) {
	RewardBasedVideoAd.SharedInstance.PresentFromRootViewController (this);
}
```

## Reload a rewarded video

A handy place to load a new rewarded video ad after the previous one is in `DidClose` interface method or `Closed` event:

```csharp
[Export ("rewardBasedVideoAdDidClose:")]
public void DidClose (RewardBasedVideoAd rewardBasedVideoAd)
{
	RewardBasedVideoAd.SharedInstance.LoadRequest (Request.GetDefaultRequest (), "ca-app-pub-3940256099942544/1712485313");
}

RewardBasedVideoAd.SharedInstance.Closed += (sender, e) => {
	RewardBasedVideoAd.SharedInstance.LoadRequest (Request.GetDefaultRequest (), "ca-app-pub-3940256099942544/1712485313");
};
```

---
 
 # Targeting

This guide explains how to provide targeting information to an ad request.

## Request

The `Request` object collects targeting information to be sent with an ad request.

### Location

If a user has granted your app location permissions, location data is automatically passed to the SDK. The SDK uses this data to improve ad targeting without requiring any code changes in your app. You can, of course, [enable or disable location data for ads][9].

Autopopulated location information is not forwarded to mediation networks and it may also be disabled entirely. Therefore, the SDK provides the ability to set location manually.

After [getting the user's location][10], you can specify location-targeting information in the `Request` as follows:

```csharp
var request = Request.GetDefaultRequest ();

if (locationManager.Location != null) {
	var currentLocation = locationManager.Location;
	request.SetLocation ((nfloat)currentLocation.Coordinate.Latitude, (nfloat)currentLocation.Coordinate.Longitude, (nfloat)currentLocation.HorizontalAccuracy);
}
```

Out of respect for user privacy, Google asks that you only specify location if that information is already used by your app.

### Child-directed setting

For purposes of the Children's Online Privacy Protection Act (COPPA), there is a method called `Tag`.

As an app developer, you can indicate whether you want Google to treat your content as child-directed when you make an ad request. When you indicate that you want Google to treat your content as child-directed, we take steps to disable IBA and remarketing ads on that ad request. The setting options are as follows:

* Set `Tag` to `true` to indicates that you want your content treated as child-directed for purposes of COPPA.
* Set `Tag` to `false` to indicate that you don't want your content treated as child-directed for purposes of COPPA.
* Do not set `Tag` if you do not wish to indicate how you would like your content treated with respect to COPPA.

```csharp
var request = Request.GetDefaultRequest ();
request.Tag (true);
```

By setting this tag, you certify that this notification is accurate and you are authorized to act on behalf of the owner of the app. You understand that abuse of this setting may result in termination of your Google account.

### Users under the age of consent

You can mark your ad requests to receive treatment for users in the European Economic Area (EEA) under the age of consent. This feature is designed to help facilitate compliance with the[ General Data Protection Regulation (GDPR)][11]. Note that you may have other legal obligations under GDPR. Please review the European Union’s guidance and consult with your own legal counsel. Please remember that Google's tools are designed to facilitate compliance and do not relieve any particular publisher of its obligations under the law. [Learn more about how the GDPR affects publishers][12].

When using this feature, a Tag For Users under the Age of Consent in Europe (TFUA) parameter will be included in the ad request. This parameter disables personalized advertising, including remarketing, for that specific ad request. It also disables requests to third-party ad vendors, such as ad measurement pixels and third-party ad servers.

The setting can be used with all versions of the Google Mobile Ads SDK by using the `tag_for_under_age_of_consent` network extra.

* Set `tag_for_under_age_of_consent` to `true` to indicate that you want the ad request to be handled in a manner suitable for users under the age of consent.
* Not setting `tag_for_under_age_of_consent` indicates that you don't want the ad request to be handled in a manner suitable for users under the age of consent.

The following example indicates that you want TFUA included in your ad request:

```csharp
var data = new Dictionary<object, object> () { { "tag_for_under_age_of_consent", true } };

var request = Request.GetDefaultRequest ();
var extras = new Extras ();
extras.AdditionalParameters = NSDictionary.FromObjectsAndKeys (data.Values.ToArray (), data.Keys.ToArray (), data.Keys.Count);
request.RegisterAdNetworkExtras (extras);
```

> ![note_icon] _**Note:**_ _This `tag_for_under_age_of_consent` parameter is currently NOT forwarded to ad network mediation adapters. It is your responsibility to ensure that each third-party ad network in your application serves ads that are appropriate for users under the age of consent per GDPR._

### Ad content filtering

Apps can set a maximum ad content rating for their ad requests using the max_ad_content_rating network extra. AdMob ads returned for these requests will have a content rating at or below that level. The possible values for this network extra are based on [digital content label classifications][13], and should be one of the following strings:

* G
* PG
* T
* MA

The following code configures an `Request` object to specify that ad content returned should correspond to a Digital Content Label designation no higher than G.

```csharp
var data = new Dictionary<object, object> () { { "max_ad_content_rating", "G" } };

var request = Request.GetDefaultRequest ();
var extras = new Extras ();
extras.AdditionalParameters = NSDictionary.FromObjectsAndKeys (data.Values.ToArray (), data.Keys.ToArray (), data.Keys.Count);
request.RegisterAdNetworkExtras (extras);
```

### Content URL

When requesting an ad, apps may pass the URL of the content they are serving. This enables keyword targeting to match the ad with the content.

For example, if your app serves blog articles and is requesting an ad while showing content from the article http://googleadsdeveloper.blogspot.com/2016/03/rewarded-video-support-for-admob.html, then you can pass this URL to target relevant keywords:

```csharp
var request = Request.GetDefaultRequest ();
request.ContentUrl = "http://googleadsdeveloper.blogspot.com/2016/03/rewarded-video-support-for-admob.html";
```

## Load an ad with targeting

Once all of your request targeting information is set, call `LoadRequest` on `BannerView` with your `Request` instance.

```csharp
var request = Request.GetDefaultRequest ();
request.Tag (true);
request.ContentUrl = "http://googleadsdeveloper.blogspot.com/2016/03/rewarded-video-support-for-admob.html";
adView.LoadRequest (request);
```

## FAQ

* **Can I release my app with `Request.TestDevices`?**
	* Yes. Test ads are only shown on specific devices that you specify, so all of your users will still receive production ads.

* **What targeting gets used when an ad automatically refreshes?**
	* On ad refresh, the previously specified `Request` object is used for targeting again. To set new targeting, explicitly call `LoadRequest` on `BannerView` with a new `Request` object.

---

# Reporting 

To learn more about this, please, read the following [documentation][14].

---

# Global Settings

The `MobileAds` class provides global settings for controlling certain information collected by the Mobile Ads SDK.

## Video ad volume control

If your app has its own volume controls (such as custom music or sound effect volumes), disclosing app volume to the Google Mobile Ads SDK allows video ads to respect app volume settings. This ensures users receive video ads with the expected audio volume.

The device volume, controlled through volume buttons or OS-level volume slider, determines the volume for device audio output. However, apps can independently adjust volume levels relative to the device volume to tailor the audio experience. You can report the relative app volume to the Google Mobile Ads SDK by setting the `ApplicationVolume` property. Valid ad volume values range from 0.0 (silent) to 1.0 (current device volume). Here's an example of how to report the relative app volume to the SDK:

```csharp
// Set app volume to be half of the current device volume.
MobileAds.SharedInstance.ApplicationVolume = 0.5f;
```

To inform the Google Mobile Ads SDK that the app volume has been muted, set the `ApplicationMuted` property, as shown below:

```csharp
MobileAds.SharedInstance.ApplicationMuted = true;
```

Unmuting the app volume reverts it to its previously set level. By default, the app volume for the Google Mobile Ads SDK is set to 1 (the current device volume).

> ![note_icon] _**Note:**_ _Video ads that are ineligible to be shown with muted audio are not returned for ad requests made when the app volume is reported as muted or set to a value of 0. This may restrict a subset of the broader video ads pool from serving._

## Changing audio session

Audio sessions allow you to express to the system your intentions for your app's audio behavior. Additional information on audio sessions can be found in Apple's [Audio Session Programming Guide][15]. The available options for managing the Google Mobile Ads SDK audio is via the `AudioVideoManager` property.

If you don't use audio in your app, you don't need to use these APIs. The Google Mobile Ads SDK will automatically manage the audio session category when it plays audio. If you do play audio in your app and you want tighter control of how and when Google Mobile Ads SDK plays audio, these APIs can help.

On the audio video manager, you can set the `AudioSessionIsApplicationManaged` property to `true` if you want to take responsibility for managing the audio session category yourself.

If you will manage the audio session category, you should implement `IAudioVideoManagerDelegate` and set the `Delegate` property on the audio video manager or use audio video manager to be notified of ads video and audio playback events. You should then change the audio session category to the relevant category as per Apple's Audio Session Programming Guide linked above.

> ![note_icon] **_Note:_** _By default, the Mobile Ads SDK will set the audio session category to AVAudioSessionCategoryAmbient when playing ads muted. If you prefer to have your app use `AVAudioSessionCategoryOptionDuckOthers` in this scenario, you must implement the `IAudioVideoManagerDelegate` interface and set the audio video manager `AudioSessionIsApplicationManaged` to `true`._

Here is a simplified code sample which shows the recommended approach if your app plays music, using above APIs:

```csharp
void SetUp ()
{
	// If you decide to implement IAudioVideoManagerDelegate interface
	MobileAds.SharedInstance.AudioVideoManager.Delegate = this;

	// If you decide to use events
	MobileAds.SharedInstance.AudioVideoManager.WillPlayAudio += (sender, e) => {
		// The mobile ads SDK is notifying your app that it will play audio. You
		// could optionally pause music depending on your apps design.
		MyAppObject.SharedInstance.PauseAllMusic ();
	};

	MobileAds.SharedInstance.AudioVideoManager.PlayingAudioStopped += (sender, e) => {
		// The mobile ads SDK is notifying your app that it has stopped playing
		// audio. Depending on your design, you could resume music here.
		MyAppObject.SharedInstance.ResumeAllMusic ();
	};

	MobileAds.SharedInstance.AudioVideoManager.AudioSessionIsApplicationManaged = true;
}

void MyAppWillStartPlayingMusic ()
{
	// Mutes all Google video ads.
	MobileAds.SharedInstance.AudioVideoManager.AudioSessionIsApplicationManaged = true;
	MobileAds.SharedInstance.ApplicationMuted = true;
}

void MyAppDidStopPlayingMusic ()
{
	// Un-mutes all of our video ads.
	MobileAds.SharedInstance.AudioVideoManager.AudioSessionIsApplicationManaged = false;
	MobileAds.SharedInstance.ApplicationMuted = false;
}

// If you decide to implement IAudioVideoManagerDelegate interface
#region AudioVideoManager Delegate

[Export ("audioVideoManagerWillPlayAudio:")]
public void WillPlayAudio (AudioVideoManager audioVideoManager)
{
	// The mobile ads SDK is notifying your app that it will play audio. You
	// could optionally pause music depending on your apps design.
	MyAppObject.SharedInstance.PauseAllMusic ();
}

[Export ("audioVideoManagerDidStopPlayingAudio:")]
public void DidStopPlayingAudio (AudioVideoManager audioVideoManager)
{
	// The mobile ads SDK is notifying your app that it has stopped playing
	// audio. Depending on your design, you could resume music here.
	MyAppObject.SharedInstance.ResumeAllMusic ();
}

#endregion
```

## In-app purchase reporting

To help grow your in-app purchase revenue and maximize the total revenue generated by your app, the Mobile Ads SDK now automatically collects general in-app purchase (IAP) information (such as item purchase price and currency). Now, you won't have to implement extra logic to track IAP conversions yourself. If you're an AdMob developer, we recommend that you leverage this new functionality to enjoy the benefits of AdMob's smart monetization offerings. This IAP reporting setting must always be enabled if you are running in-app purchase house ads (currently in limited beta). This is necessary for IAP house ad conversions to be reported.

In our latest SDK release, in-app purchase reporting is enabled by default. If you'd like, however, you can disable it by using the `DisableAutomatedInAppPurchaseReporting` method (unless you are running IAP house ads, as noted above). The best moment to call this method is when the app launches:

```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{
	...

	MobileAds.DisableAutomatedInAppPurchaseReporting ();
	
	return true;
}
```

## Crash reporting

The Mobile Ads SDK inspects exceptions that occur in an iOS app and records them if they are caused by the SDK. These exceptions are collected so we can prevent them in future SDK versions.

In our latest SDK release, crash reporting is enabled by default. If you don't want SDK-related exceptions to be recorded, you can disable this feature by calling the `DisableSDKCrashReporting` method. The best place to call this method is when the app launches:

```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{
	...

	MobileAds.DisableSDKCrashReporting ();
	
	return true;
}
```

---

# Requesting Consent from European Users

Under the Google [EU User Consent Policy][16], you must make certain disclosures to your users in the European Economic Area (EEA) and obtain their consent to use cookies or other local storage, where legally required, and to use personal data (such as AdID) to serve ads. This policy reflects the requirements of the EU ePrivacy Directive and the General Data Protection Regulation (GDPR).

To support publishers in meeting their duties under this policy, Google offers a Consent SDK. The Consent SDK is an open-source library that provides utility functions for collecting consent from your users.

Ads served by Google can be categorized as personalized or non-personalized, both requiring consent from users in the EEA. By default, ad requests to Google serve personalized ads, with ad selection based on the user's previously collected data. Google also supports configuring ad requests to serve non-personalized ads. [Learn more about personalized and non-personalized ads][17].

This guide describes how to use the Consent SDK to obtain consent from users. It also describes how to forward consent to the Google Mobile Ads SDK once you have obtained consent.	

## Tips for using the Consent SDK

Prior to using any other methods in the Consent SDK, you should [update consent status](#update-consent-status) to make sure the Consent SDK has the latest information regarding the ad technology providers you've selected in the AdMob UI. If the list of ad technology providers has changed since the user last provided consent, the consent state is set back to an unknown state.

### If you select 12 or fewer ad technology providers and don't use mediation

You can use the Consent SDK to present a [Google-rendered consent form](#google-rendered-consent-form) to your users. The consent form displays a list of the ad technology providers you've selected in the AdMob UI. The Consent SDK stores the user consent response.

If a user has consented to receive only non-personalized ads, you'll need to [forward consent to the Google Mobile Ads SDK](#forward-consent-to-the-google-mobile-ads-sdk).

### If you select more than 12 ad technology providers and don't use mediation

You can use the Consent SDK to dynamically retrieve the full list of ad technology providers from AdMob, as explained in [publisher-managed consent collection](#publisher-managed-consent-collection). However, you'll need to determine how the list of providers should be made available to your users and present your own consent form to your users.

Once the user has made a consent choice, you can ask the Consent SDK to store the user's consent choice as explained in [Storing publisher managed consent](#storing-publisher-managed-consent).

If a user has consented to receive only non-personalized ads, you'll need to [forward consent to the Google Mobile Ads SDK](#forward-consent-to-the-google-mobile-ads-sdk).

### If you use AdMob mediation

You can use the Consent SDK to dynamically retrieve the full list of ad technology providers from AdMob, as explained in [publisher-managed consent collection](#publisher-managed-consent-collection). You'll need to determine which additional ad technology providers from other ad networks need to be presented to your users for consent.

As an app developer, you'll need to collect user consent for both the ad technology providers returned by the Consent SDK and the providers from other ad networks. You'll also need to manually store user consent responses and [forward consent to the Google Mobile Ads SDK](#forward-consent-to-the-google-mobile-ads-sdk) if the user consented to receive only non-personalized ads.

> ![warning_icon] _**Warning:**_ _We recommend **against** using the Consent SDK to store publisher-managed consent if you collect consent for additional ad technology providers beyond those returned by the Consent SDK. The Consent SDK only tracks changes to the list of ad technology providers from AdMob, and cannot track changes to any additional providers you may add to your consent form._

Google currently is unable to obtain and handle consent for mediation networks, so you'll need to obtain and handle consent for each ad network separately. We are actively working with all of our [open source and versioned][18] mediation networks to provide updated documentation with details on how to forward consent. Documentation is already live for the following mediation networks:

* [AppLovin](https://developers.google.com/admob/ios/mediation/applovin#eu_consent_and_gdpr)
* [Chartboost](https://developers.google.com/admob/ios/mediation/chartboost#eu_consent_and_gdpr)
* [Facebook](https://developers.google.com/admob/ios/mediation/facebook#eu_consent_and_gdpr)
* [IronSource](https://developers.google.com/admob/ios/mediation/ironsource#eu_consent_and_gdpr)
* [MoPub](https://developers.google.com/admob/ios/mediation/mopub#eu_consent_and_gdpr)
* [myTarget](https://developers.google.com/admob/ios/mediation/mytarget#eu_consent_and_gdpr)
* [Tapjoy](https://developers.google.com/admob/ios/mediation/tapjoy#eu_consent_and_gdpr)
* [Unity Ads](https://developers.google.com/admob/ios/mediation/unity#eu_consent_and_gdpr)
* [Vungle](https://developers.google.com/admob/ios/mediation/vungle#eu_consent_and_gdpr)

## Update consent status

When using the Consent SDK, it is recommended that you determine the status of a user's consent at **every app launch**. To do this, call `RequestConsentInfoUpdate` method on an instance of `ConsentInformation`:

```csharp
using Google.MobileAds.Consent;

...

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	ConsentInformation.SharedInstance.RequestConsentInfoUpdate (new [] { "pub-0123456789012345" }, HandleConsentInformationUpdate;);

	void HandleConsentInformationUpdate (NSError error)
	{
		if (error != null) {
			// Consent info update failed.
			return;
		}

		// Consent info update succeeded. The shared PACConsentInformation
		// instance has been updated.
	}
}
```

The call to `RequestConsentInfoUpdate` requires two arguments:

* An array of publisher IDs that your app requests ads from. [Find your publisher ID.][19]
* A block that accepts an `NSError` as an input parameter, which provides information on a failed consent update request.

An async/await version of this:

```csharp
try {
	await ConsentInformation.SharedInstance.RequestConsentInfoUpdateAsync (new [] { "pub-0123456789012345" });

	// Consent info update succeeded. The shared PACConsentInformation
	// instance has been updated.
} catch (NSErrorException ex) {
	// Consent info update failed.
}
```

If consent information is successfully updated, `ConsentInformation.SharedInstance.ConsentStatus` provides the updated consent status. It may have the values listed below:

| Consent State                 | Definition                                                                                  |
|-------------------------------|---------------------------------------------------------------------------------------------|
| ConsentStatus.Personalized    | The user has granted consent for personalized ads.                                          |
| ConsentStatus.NonPersonalized | The user has granted consent for non-personalized ads.                                      |
| ConsentStatus.Unknown         | The user has neither granted nor declined consent for personalized or non-personalized ads. |

Once consent information is successfully updated, you can also check `ConsentInformation.SharedInstance.IsRequestLocationInEeaOrUnknown` to see if the user is located in the European Economic Area or the request location is unknown.

If the `IsRequestLocationInEeaOrUnknown` property is `false`, the user is not located in the European Economic Area and consent is not required under the [EU User Consent Policy][16]. You can make ad requests to the Google Mobile Ads SDK.

If the `IsRequestLocationInEeaOrUnknown` property is `true`:

* If the `ConsentStatus` is `ConsentStatus.Personalized` or `ConsentStatus.NonPersonalized`, the user has already provided consent. You can now [forward consent to the Google Mobile Ads SDK](#forward-consent-to-the-google-mobile-ads-sdk).
* If the user has an `ConsentStatus.Unknown` consent, see the Collect consent section below, which describes the use of utility methods to collect consent.

## Collect consent

Google's Consent SDK provides two ways to collect consent from a user:

* Present a [Google-rendered consent form](#google-rendered-consent-form) to the user.
* Request the list of ad technology providers and collect consent yourself with the [Publisher-managed consent collection](#publisher-managed-consent-collection) option.

Remember to provide users with the option to [Change or revoke consent](#change-or-revoke-consent).

### Google-rendered consent form

<img height=500 src="https://developers.google.com/admob/images/ios_eu_consent_form.png" />

The Google-rendered consent form is a full-screen configurable form that displays over your app content. You can configure the form to present the user with combinations of the following options:

* Consent to view personalized ads
* Consent to view non-personalized ads
* Use a paid version of the app instead of viewing ads

You should review the consent text carefully: what appears by default is a message that **might** be appropriate if you use Google to monetize your app; but we cannot provide legal advice on the consent text that is appropriate for you. To update consent text of the Google-rendered consent form, modify the `consentform.html` file located at Xamarin Bulld Download cache. By default, the file is located at:

* **Windows:** `$(LocalAppData)\XamarinBuildDownloadCache\GCnsnt-$(Version)\googleads-consent-sdk-ios-$(Version)\PersonalizedAdConsent\PersonalizedAdConsent\PersonalizedAdConsent.bundle`
* **Mac:** `$(HOME)\Library\Caches\XamarinBuildDownload\GCnsnt-$(Version)\googleads-consent-sdk-ios-$(Version)\PersonalizedAdConsent\PersonalizedAdConsent\PersonalizedAdConsent.bundle`

> ![note_icon] _**Important:**_ _The Google-rendered consent form is not supported if any of your publisher IDs use the commonly used set of ad technology providers. Attempting to load the Google-rendered consent form will always fail in this case._
>
> _If your publisher IDs use a custom set of providers, and the custom set of ad technology providers exceeds 12, the form removes the personalized ads option. To collect personalized consent for more than 12 ad technology providers, you must use the [Publisher-managed consent collection](#publisher-managed-consent-collection) option._

The Google rendered consent form is configured and displayed using the `ConsentForm` class. The following code demonstrates how to build a `ConsentForm` with all three form options:

```csharp
// TODO: Replace with your app's privacy policy url.
var url = new NSUrl ("https://www.your.com/privacyurl");
var form = new ConsentForm (url) {
	ShouldOfferPersonalizedAds = true,
	ShouldOfferNonPersonalizedAds = true,
	ShouldOfferAdFree = true
};
```

The properties of `ConsentForm` are described in further detail below:

* `ShouldOfferPersonalizedAds`
	* Indicates whether the consent form should show a personalized ad option. Defaults to YES.

* `ShouldOfferNonPersonalizedAds`
	* Indicates whether the consent form should show a non-personalized ad option. Defaults to YES.

* `ShouldOfferAdFree`
	* Indicates whether the consent form should show an ad-free app option. Defaults to NO.

### Load consent form

Once you have created and configured a `ConsentForm` object, load the consent form by invoking the `Load` method of `ConsentForm`, as shown below:

```csharp
form.Load (HandleLoadCompletionHandler);

void HandleLoadCompletionHandler (NSError error)
{
	if (error != null) {
		// Handle error.
		return;
	}

	// Load successful.
}

// async/await version

try {
	await form.LoadAsync ();
	// Load successful.
} catch (NSErrorException ex) {
	// Handle error.
}
```

### Show consent form

To present the user with the Google-rendered consent form, call `Present` on a loaded ConsentForm, as demonstrated below:

```csharp
form.Present (this, HandleDismissCompletion);

void HandleDismissCompletion (NSError error, bool userPrefersAdFree)
{
	if (error == null) {
		// Handle error.
		return;
	}

	if (userPrefersAdFree) {
		// User prefers to use a paid version of the app.
	} else {
		// Check the user's consent choice.
		var status = ConsentInformation.SharedInstance.ConsentStatus;
	}
}

// async/await version

var dismissCompletionResult = await form.PresentAsync (this);

if (dismissCompletionResult.Error == null) {
	// Handle error.
	return;
}

if (dismissCompletionResult.UserPrefersAdFree) {
	// User prefers to use a paid version of the app.
} else {
	// Check the user's consent choice.
	var status = ConsentInformation.SharedInstance.ConsentStatus;
}
```

The call to `Present` requires two arguments:

* A `UIViewController` to present from.
* A block that accepts an `NSError` and a `bool` as input parameters. The `NSError` provides information if there was an error showing the consent form. The `userPrefersAdFree` `bool` has a value of `true` when the user chose to use a paid version of the app in lieu of viewing ads.

After the user selects an option and closes the form, the Consent SDK saves the user's choice and calls the block. You can read the user's choice and [forward consent to the Google Mobile Ads SDK](#forward-consent-to-the-google-mobile-ads-sdk).

### Publisher-managed consent collection

If you choose to get consent yourself, you can use the `AdProviders` property of the `ConsentInformation` class to get the ad technology providers associated with the publisher IDs used in your app. Note that consent is required for the full list of ad technology providers configured for your publisher IDs.

> ![note_icon] _**Note:**_ _Before you access the `AdProviders` property of `ConsentInformation`, you must wait for the successful update of user's consent status as described in the Update consent status section._

```csharp
var adProviders = ConsentInformation.SharedInstance.AdProviders;
```

You can then use the list of ad providers to obtain consent yourself.

### Storing publisher managed consent

Upon getting consent, record the `ConsentStatus` corresponding to the user's response using the `Status` property of the `ConsentInformation` class.

```csharp
ConsentInformation.SharedInstance.ConsentStatus = ConsentStatus.Personalized;
```

After reporting consent to the Consent SDK, you can [forward consent to the Google Mobile Ads SDK](#forward-consent-to-the-google-mobile-ads-sdk).

### Change or revoke consent

> ![note_icon] _**Key Point:**_ _It is important that the user is able to change or revoke the consent they have provided at any time._

To allow users to update their consent, simply repeat the steps outlined in the [Collect consent](#collect-consent) section when the user chooses to update their consent status.

### Users under the age of consent

If a publisher is aware that the user is under the age of consent, all ad requests must set TFUA (Tag For Users under the Age of Consent in Europe). To include this tag on all ad requests made from your app, set the `TagForUnderAgeOfConsent` property to `true`. This setting takes effect for all future ad requests:

```csharp
ConsentInformation.SharedInstance.TagForUnderAgeOfConsent = true;
```

Once the TFUA setting is enabled, the Google rendered consent form will fail to load. All ad requests that include TFUA will be made ineligible for personalized advertising and remarketing. TFUA disables requests to third-party ad technology providers, such as ad measurement pixels and third-party ad servers.

To remove TFUA from ad requests, set the `TagForUnderAgeOfConsent` property to `false`.

## Testing

The Consent SDK has different behaviors depending on the value of `ConsentInformation.SharedInstance.RequestLocationInEeaOrUnknown`. For example, the consent form fails to load if the user is not located in the EEA.

To enable easier testing of your app both inside and outside the EEA, the Consent SDK supports debug options that you can set prior to calling any other methods in the Consent SDK.

1. Grab your device's advertising ID. You can write the following code to log your advertising ID:
	```csharp
	using AdSupport;

	Console.WriteLine ($"Advertising ID: {ASIdentifierManager.SharedManager.AdvertisingIdentifier.AsString ()}");
	```

	And then check the console to get it:

	```
	Advertising ID: 41E538F6-9C98-4EF2-B3EE-D7BD8CAF8339
	```
2. Whitelist your device to be a debug device using the advertising ID from the console:
	```csharp
	ConsentInformation.SharedInstance.DebugIdentifiers = new [] { "41E538F6-9C98-4EF2-B3EE-D7BD8CAF8339" };
	```
	
	> ![warning_icon] _**Warning:**_ _We highly discourage directly setting debugIdentifiers to the current device's advertising ID. You don't want to run the risk of releasing your app with code in place that overwrites every user's geography._
	
	> ![note_icon] _**Note:**_ _Simulators are automatically added as debug devices and don't need to be whitelisted._
3. Finally, set the debugGeography to your preferred geography for testing purposes
	```csharp
	// Geography appears as in EEA for debug devices.
	ConsentInformation.SharedInstance.DebugGeography = DebugGeography.Eea;

	// Geography appears as not in EEA for debug devices.
	ConsentInformation.SharedInstance.DebugGeography = DebugGeography.NotEea;
	```

After completing these steps, calls to [update consent status](#update-consent-status) will take into account your debug geography.

## Forward consent to the Google Mobile Ads SDK

> ![note_icon] _**Note:**_ _The code in this section can be used with any version of the Google Mobile Ads SDK. It can also be used regardless of whether you used the Consent SDK to gather consent._

The default behavior of the Google Mobile Ads SDK is to serve personalized ads. If a user has consented to receive only non-personalized ads, you can configure an GADRequest object with the following code to specify that only non-personalized ads should be requested:

```csharp
var data = new Dictionary<object, object> { { "npa", "1" } };

var request = Request.GetDefaultRequest ();
var extras = new Extras {
	AdditionalParameters = NSDictionary.FromObjectsAndKeys (data.Values.ToArray (), data.Keys.ToArray (), data.Keys.Count)
};
request.RegisterAdNetworkExtras (extras);
```

> ![note_icon] _**Note:**_ _Google's [EU User Consent Policy][16] requires that you collect consent for the full list of ad technology providers configured for your publisher IDs before displaying personalized ads, even if you are using a third-party mediation solution to send ad request to Google._

If non-personalized ads are requested, the ad request URL currently includes `&npa=1`. However, note that this is an internal implementation detail of the Google Mobile Ads SDK and is subject to change.

## FAQ

**How many ad technology providers does the Consent SDK support?**

The Consent SDK does not impose a limit on the number of ad technology providers a publisher chooses to enable. However, the Google-rendered consent form supports a maximum of 12 ad technology providers. Publishers with more than 12 ad technology providers can create and manage their own consent form using the ad technology partners fetched from the Consent SDK.

**Does the list of ad technology providers returned by the SDK automatically update if I change my selection in the AdMob UI?**

Yes, if you make changes to the list of ad technology providers in the AdMob UI, the changes will propagate to Google’s ad servers in approximately one hour.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/admob/ios/quick-start) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://apps.admob.com/#account/appmgmt:
[4]: https://support.google.com/admob/answer/6240809
[5]: https://support.google.com/dfp_premium/answer/6075370
[6]: https://support.google.com/admob/answer/7187428
[7]: https://support.google.com/dfp_premium/answer/6366881?visit_id=1-636620822163502235-512919786&rd=1
[8]: https://developers.google.com/mobile-ads-sdk/docs/dfp/ios/targeting
[9]: https://support.google.com/admob/answer/6373176
[10]: https://developer.apple.com/library/archive/documentation/UserExperience/Conceptual/LocationAwarenessPG/CoreLocation/CoreLocation.html
[11]: https://eur-lex.europa.eu/legal-content/EN/TXT/?uri=CELEX:32016R0679https://developer.apple.com/library/content/documentation/UserExperience/Conceptual/LocationAwarenessPG/CoreLocation/CoreLocation.html
[12]: https://support.google.com/admob/answer/7666366
[13]: https://support.google.com/admob/answer/7562142
[14]: https://developers.google.com/admob/ios/reporting
[15]: https://developer.apple.com/library/archive/documentation/Audio/Conceptual/AudioSessionProgrammingGuide/Introduction/Introduction.html
[16]: https://www.google.com/about/company/user-consent-policy.html
[17]: https://support.google.com/admob/answer/7676680
[18]: https://developers.google.com/admob/ios/mediation/#choosing_your_mediation_networks
[19]: https://support.google.com/admob/answer/2784578
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
[deprecated_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/16/519643-144_Forbidden-20.png "Deprecated"
