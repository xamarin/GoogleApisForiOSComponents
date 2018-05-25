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

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/admob/ios/quick-start) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://apps.admob.com/#account/appmgmt:
[4]: https://support.google.com/admob/answer/6240809
[5]: https://support.google.com/dfp_premium/answer/6075370
[6]: https://support.google.com/admob/answer/7187428
[7]: https://support.google.com/dfp_premium/answer/6366881?visit_id=1-636620822163502235-512919786&rd=1
[8]: https://developers.google.com/mobile-ads-sdk/docs/dfp/ios/targeting
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
[deprecated_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/16/519643-144_Forbidden-20.png "Deprecated"
