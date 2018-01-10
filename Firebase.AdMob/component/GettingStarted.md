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

## Table of content 

- [Banner Ads](#banner-ads)
- [Interstitial Ads](#interstitial-ads)
- [Native Ads Express](#native-ads-express) ![deprecated_icon]
- [Native Ads Advanced](#native-ads-advanced)
- [Rewarded Video Ads](#rewarded-video-ads)
- [Known issues](#known-issues)

## Banner Ads

Banner ads are rectangular image or text ads that occupy a spot within an app's layout. They stay on screen while users are interacting with the app, and can refresh automatically after a certain period of time. If you're new to mobile advertising, they're a great place to start.

This guide shows you how to integrate banner ads from AdMob into an iOS app. In addition to code snippets and instructions, it includes information about sizing banners properly and links to additional resources.

### Create a BannerView

AdMob banners are displayed in `BannerView` objects, so the first step toward integrating AdMob ads is to include a `BannerView` in your view hierarchy. This is typically done in one of two ways.

#### Interface Builder

A `BannerView` can be added to a storyboard or xib file like any typical view. When using this method, be sure to add **width** and **height** constraints to match the ad size you'd like to display. For example, when displaying a standard banner (320x50), use a width constraint of 320 points, and a height constraint of 50 points.

#### Programmatically

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

### Configure BannerView properties

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

### Call LoadRequest method

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

### Ad events

Through the use of `IBannerViewDelegate` interface or `BannerView` object events, you can listen for lifecycle events, such as when an ad is closed or the user leaves the app. If you decide to use Ad events, you must use the `IBannerViewDelegate` interface or `BannerView` object events, you cannot use both or create a mix of them. If you plan to use `BannerView` object events, you can jump to [Implementing banner events section](#Implementing-banner-events) directly.

#### Registering for banner events using IBannerViewDelegate interface

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

#### Implementing banner events

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

### Use cases

Here are some example use cases for these ad event methods.

#### Adding a banner to the view hierarchy once an ad is received

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

#### Animating a banner ad

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

#### Third-party analytics

The SDK automatically tracks clicks and impressions, but if you're also using a third-party analytics solution, you can also track each of the `IBannerViewDelegate` calls separately.

#### Pausing and resuming the app

The `IBannerViewDelegate` interface has methods to notify you of events such as when a click causes an overlay to be presented or dismissed, or invokes an external browser. Same functionality applies for `BannerView` events. If you want to know that these events happened because of ads, then register for these `IBannerViewDelegate` methods or `BannerView` events.

But to catch all types of overlay presentations or external browser invocations, not just ones that come from ad clicks, your app is better off listening for the equivalent methods on `UIViewController` or `UIApplication`. Here is a table showing the equivalent iOS methods that are invoked at the same time as GADBannerViewDelegate methods:

| IBannerViewDelegate method/BannerView event       | iOS method                                     |
|:-------------------------------------------------:|:----------------------------------------------:|
| **WillPresentScreen**/**WillPresentScreen**       | UIViewController's **ViewWillDisappear**       |
| **WillDismissScreen**/**WillDismissScreen**       | UIViewController's **ViewWillAppear**          |
| **DidDismissScreen**/**ScreenDismissed**          | UIViewController's **ViewDidAppear**           |
| **WillLeaveApplication**/**WillLeaveApplication** | UIApplicationDelegate's **DidEnterBackground** |

### Banner sizes

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

### Smart Banners

Smart Banners are ad units that render screen-wide banner ads on any screen size across different devices in either orientation. Smart Banners help deal with increasing screen fragmentation across different devices by "smartly" detecting the width of the phone in its current orientation, and making the ad view that size.

Three ad heights are implemented in Smart Banners:

| Ad height | Screen height       |
|:---------:|---------------------|
| **32dp**  | ≤ 400dp             |
| **50dp**  | > 400dp and ≤ 720dp |
| **90dp**  | > 720               |

For some devices, such as phones, the height of the device varies with its orientation. Typically, Smart Banner ads on phones are full width x 50dp in portrait and full width x 32dp in landscape, while on tablets, ads are full width x 90dp in both orientations.

When an image ad isn't large enough to take up the entire allotted space, the image is centered and the space on either side is filled in.

To use Smart Banners, just specify `AdSizeCons.SmartBannerPortrait` for the ad size:

```csharp
BannerView bannerView = new BannerView (AdSizeCons.SmartBannerPortrait);
```

## Interstitial Ads

Interstitial ads are full-screen ads that are overlaid on top of an app. They are generally displayed at natural app transition points such as in between game levels. When an app shows an interstitial ad, the user has the choice to either tap on the ad and continue to its destination or close it and return to the app.

This guide shows you how to integrate interstitials from AdMob into an iOS app.

### Create a Interstitial object

AdMob interstitials are requested and shown by `Interstitial` objects. The first step in using one is to instantiate it and set its ad unit ID. For example, here's how to create an `Interstitial` in the `ViewDidLoad` method of a `UIViewController`:

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

### Load an ad

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

### Show the ad

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

### Use IInterstitialDelegate interface or Interstitial events to reload

`Interstitial` is a one time use object. That means once an interstitial is shown, `HasBeenUsed` property returns `true` and the interstitial can't be used to load another ad. To request another interstitial, you'll need to create a new `Interstitial` object.

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

### Ad events

Through the use of `IInterstitialDelegate` interface or `Interstitial` object events, you can listen for lifecycle events, such as when an ad is closed or the user leaves the app. If you decide to use Ad events, you must use the `IInterstitialDelegate` interface or `Interstitial` object events, you cannot use both or create a mix of them. If you plan to use `Interstitial` object events, you can jump to [Implementing interstitial events section](#Implementing-interstitial-events) directly.

#### Registering for interstitial events using IInterstitialDelegate interface

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

#### Implementing interstitial events

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

### Some best practices

#### Consider whether interstitial ads are the right type of ad for your app.

Interstitial ads work best in apps with natural transition points. The conclusion of a task within an app, like sharing an image or completing a game level, creates such a point. Because the user is expecting a break in the action, it's easy to present an interstitial ad without disrupting their experience. Make sure you consider at which points in your app's workflow you'll display interstitial ads and how the user is likely to respond.

#### Remember to pause the action when displaying an interstitial ad.

There are a number of different types of interstitial ads: text, image, video, and more. It's important to make sure that when your app displays an interstitial ad, it also suspends its use of some resources to allow the ad to take advantage of them. For example, when you make the call to display an interstitial ad, be sure to pause any audio output being produced by your app. You can resume playing sounds in the `DidDismissScreen` method of `IInterstitialDelegate` interface or in the `ScreenDismissed` event handler, which will be invoked when the user has finished interacting with the ad. In addition, consider temporarily halting any intense computation tasks (such as a game loop) while the ad is being displayed. This will make sure the user doesn't experience slow or unresponsive graphics or stuttered video.

#### Allow for adequate loading time.

Just as it's important to make sure you display interstitial ads at an appropriate time, it's also important to make sure the user doesn't have to wait for them to load. Loading the ad in advance by calling `LoadRequest` method before you intend to call `PresentFromRootViewController` can ensure that your app has a fully loaded interstitial ad at the ready when the time comes to display one.

#### Don't flood the user with ads.

While increasing the frequency of interstitial ads in your app might seem like a great way to increase revenue, it can also degrade the user experience and lower clickthrough rates. Make sure that users aren't so frequently interrupted that they're no longer able to enjoy the use of your app.

## Native Ads Express

> ![warning_icon] **The native express ad format is being discontinued. Starting October 23, 2017, you'll no longer be able to create new native express ad units. Existing native express ad units will stop serving ads on March 1, 2018.**

Native Express ads are similar to banners in that they're rectangular ads that you can drop into a storyboard and size how you like. The key difference is that you, the publisher, can control the ad's presentation details (things like image sizes, fonts, colors, and so on) by uploading a CSS template for your ad unit. AdMob combines that template with advertiser assets like icons, images, and text, and displays the resulting HTML in a `NativeExpressAdView`. This approach minimizes the amount of mobile code needed for a Native Express ad, while helping publishers display ads that look natural in their app.

This guide shows you how to integrate Native Ads Express from AdMob into an iOS app. In addition to code snippets and instructions, it includes information about how to choose the correct size category for your ad units.

### NativeExpressAdView

The `NativeExpressAdView` class is responsible for requesting and displaying Native Express ads. You can add one to a storyboard and assign constraints to it, much as one would with a [`BannerView`](#Interface-Builder).

### Choose a size

Rather than forcing publishers to choose between fixed sizes, Native Express ads offer several template sizes (chosen when creating an ad unit), each with a range of height and width values:

| Template size | Min width | Max width | Min height | Max height |
|:-------------:|:---------:|:---------:|:----------:|:----------:|
| Small         | 280       | 1200      | 80         | 612        |
| Medium        | 280       | 1200      | 132        | 1200       |
| Large         | 280       | 1200      | 250        | 1200       |

A publisher who wants to display a "Medium" template size can use widths between 280 and 1200 dp, and heights from 132 to 1200 dp. That means that 300 by 200, 450 by 150, and 613 by 572 are all valid for the Medium template size. Bear in mind, though, that not all sizes are likely to make for a good presentation. While it's technically possible to request a "Small" template with a size of 1200 by 80, it's probably not the best choice. Also, be sure to consider the screen dimensions of the device on which you're displaying the ad. Larger sizes should generally be reserved for presentation on tablets.

Apps aren't required to use the same size for every request. The same ad unit could be requested with one size in portrait orientation and another in landscape, or in different sizes according to the particular device it's running on. In the event that an app makes a request with an ad size that falls outside the range for the ad unit's template, though, an error is returned.

Publishers can also use the `AdSizeCons.GetFullWidthPortrait (nfloat)` and `AdSizeCons.GetFullWidthLandscape (nfloat)` methods when programmatically creating a `AdSize` for a `NativeExpressAdView`. In this case, the ad occupies the entire width of the device screen.

> _**Note**_: _At this time, the Fluid size should not be used with Native Ads Express_.

### Load an Ad

Loading ads is done through the `LoadRequest` method in the `NativeExpressAdView` class. Before calling it, make sure the AdUnitID and rootViewController properties have been assigned prior to loading an ad.

If you have a UIViewController with a GADNativeExpressAdView in its storyboard, here's how you can set the properties and load an ad:

```csharp
// For Outlet Attribute
using Foundation;
using Google.MobileAds;

namespace YourNamespace
{
	public class YourViewController : UIViewController
	{
		[Outlet]
		NativeExpressAdView NativeExpressAdView { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			NativeExpressAdView.AdUnitID = "ca-app-pub-3940256099942544/2562852117";
			NativeExpressAdView.RootViewController = this;
			NativeExpressAdView.LoadRequest (Request.GetDefaultRequest ());
		}
	}
}
```

### Native Video

In addition to images, text, and numbers, some native ads contain video assets. At the current time, this is limited to the App Install format, but may be extended to Content ads in the future.

To simplify the configuration and display of video, the Mobile Ads SDK provides the following video-related classes for Native Ads Express:

#### VideoOptions

The `VideoOptions` class allows apps to configure how native video assets should behave. `VideoOptions` objects can be assigned to a `NativeExpressAdView` via the `SetAdOptions` method:

```csharp
var videoOptions = new VideoOptions {
	StartMuted = true
};
NativeExpressAdView.SetAdOptions (new [] { videoOptions });
```

The `VideoOptions` class currently offers one property, `StartMuted`, which tells the SDK whether video assets should start in a muted state. The default value is `true`.

#### VideoController

The `VideoController` class is used to retrieve information about video assets. `NativeExpressAdView` offers a `VideoController` property that exposes the `VideoController` for its ads. This property is never `null`, even when the ad doesn't contain a video asset.

`VideoController` offers the following methods for querying video state:

* `HasVideoContent` - True if the ad includes a video asset, false otherwise.
* `AspectRatio` - The aspect ratio of the video (width/height), or zero if no video asset is present.

In addition, apps can set a `IVideoControllerDelegate` for the `VideoController` to be notified of events in the lifecycle of a video asset, also, you can use `VideoController` events instead of `IVideoControllerDelegate` methods. `IVideoControllerDelegate` offers a single optional method, `DidEndVideoPlayback`, as well as `VideoController` offers a `VideoPlaybackEnded` event, which is sent when a video completes playback.

Here's an example of `IViewControllerDelegate` in action:

```csharp
public class YourViewController : UIViewController, IVideoControllerDelegate
{
	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
		NativeExpressAdView.VideoController.Delegate = this;
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
		NativeExpressAdView.VideoController.VideoPlaybackEnded += (sender, e) => {
			// Here apps can take action knowing video playback is finished.
			// This is handy for things like unmuting audio, and so on.
		};
	}
}
```
## Native Ads Advanced

> ![note_icon] **_Note:_** _Native Ads Advanced is currently in a limited beta release. If you are interested in participating, reach out to your account manager to discuss the possibility. This feature will be made available to all publishers at the conclusion of the beta._

Native Ads Advanced is a format in which ad assets are presented to users via UI components that are native to the platform. They're shown using the same classes you already use in your storyboards, and can be formatted to match your app's visual design. When an ad loads, your app receives an ad object that contains its assets, and the app (rather than the SDK) is then responsible for displaying them.

There are two [system-defined formats for native ads][4]: app install and content. App install ads are represented by `NativeAppInstallAd`, and content ads are represented by `NativeContentAd`. Instances of the classes contain the assets for the native ad.

This guide shows you how to integrate Native Ads Advanced from AdMob into an iOS app.

### Load an ad

Native Advanced ads are loaded via `AdLoader` objects, which send messages to their delegates according to the `IAdLoaderDelegate` interface.

#### Initialize a AdLoader

The following code demonstrates how to initialize a `AdLoader` for an app install ad:

```csharp
var adLoader = new AdLoader ("ca-app-pub-3940256099942544/3986624511", 
			     this, 
			     new NSObject [] { /* ad type constants */ }, 
			     new AdLoaderOptions [] { /* ad loader options objects */ });
adLoader.Delegate = this;
```

The ad types array parameter allows your app to pass in constants that specify which native formats it wants to request. The array should contain one or both of the following constants:

* AdLoaderType.NativeAppInstall
* AdLoaderType.NativeContent

#### Request the ad

Once your `AdLoader` is initialized, call its `LoadRequest` method to request an ad:

```csharp
adLoader.LoadRequest (Request.GetDefaultRequest ());
```

The `LoadRequest` method in `AdLoader` accepts the same `Request` objects as banners and interstitials. You can use request objects to add targeting information just as you would with other ad types.

> ![note_icon] **_Note:_** _A single `AdLoader` can make multiple requests, but only if they're done one at a time. When reusing a `AdLoader`, make sure you wait for each request to finish before calling `LoadRequest` method again to begin the next. If you need to request multiple ads in parallel, you can always use multiple `AdLoader` objects._

#### IAdLoaderDelegate interfaces

For each ad format you request, the ad loader delegate needs to implement a corresponding interface:

##### INativeAppInstallAdLoaderDelegate

This interface includes a method that's sent to the delegate when an app install ad has loaded:

```csharp
public void DidReceiveNativeAppInstallAd (AdLoader adLoader, NativeAppInstallAd nativeAppInstallAd) { }
```

##### INativeContentAdLoaderDelegate

This one defines a message sent when a content ad has loaded:

```csharp
public void DidReceiveNativeContentAd (AdLoader adLoader, NativeContentAd nativeContentAd) { }
```

#### Handle a failed request

The above interfaces extend the `IAdLoaderDelegate` interface, which defines a message sent when ads fail to load:

```csharp
public void DidFailToReceiveAd (AdLoader adLoader, RequestError error) { }
```

You can use the `RequestError` object to determine the cause of the error.

#### Ad options

The last parameter included in the creation of the `AdLoader` above is an optional array of objects:

```csharp
var adLoader = new AdLoader ("ca-app-pub-3940256099942544/3986624511", 
			     this, 
			     new NSObject [] { /* ad type constants */ }, 
			 --> new AdLoaderOptions [] { /* ad loader options objects */ });
```

This optional array holds one or more instances of a `AdLoaderOptions` subclass, objects that an app can use to indicate its preferences for how native ads should be loaded and behave.

#### NativeAdImageAdLoaderOptions

`NativeAdImageAdLoaderOptions` contains properties relating to images in Native Advanced ads. Apps can control how a `AdLoader` handles Native Ads Advanced image assets by creating a `NativeAdImageAdLoaderOptions` object, setting its properties (DisableImageLoading, PreferredImageOrientation, and ShouldRequestMultipleImages), and passing it in during initialization.

##### DisableImageLoading

Image assets for ads are returned via instances of `NativeAdImage`, which contains `Image` and `ImageUrl` properties. If `DisableImageLoading` is set to `false` (default), the SDK fetches image assets automatically and populates both the `Image` and the `ImageUrl` properties for you. If it's set to true, however, the SDK only populates `ImageUrl`, allowing you to download the actual images at your discretion.

##### PreferredImageOrientation

Some creatives have multiple available images to match different device orientations. Apps can request images for a particular orientation by setting this property to one of the orientation constants:

* `NativeAdImageAdLoaderOptionsOrientation.Any`
* `NativeAdImageAdLoaderOptionsOrientation.Landscape`
* `NativeAdImageAdLoaderOptionsOrientation.Portrait`

> ![note_icon] **_Note:_** _If you use `PreferredImageOrientation` to specify a preference for landscape or portrait image orientation, the SDK places images matching that orientation first in image asset arrays and place non-matching images after them. Since some ads only have one orientation available, publishers should make sure that their apps can handle both landscape and portrait images._

If this method is not called, the default value of `NativeAdImageAdLoaderOptionsOrientation.Any` is used.

##### ShouldRequestMultipleImages

Some image assets contain a series of images rather than just one. By setting this value to true, your app indicates that it's prepared to display all the images for any assets that have more than one. By setting it to false (default) your app instructs the SDK to provide just the first image for any assets that contain a series.

If no `AdLoaderOptions` objects are passed in when initializing a `AdLoader`, the default value for each option is used.

#### NativeAdViewOptions

`NativeAdViewAdOptions` objects are used to indicate preferences for how native ad views should represent ads. They have a single property: `PreferredAdChoicesPosition`.

This property indicates in which corner of the ad view the AdChoices attribution icon should appear. The possible values for this property are:

* `AdChoicesPosition.TopRightCorner`
* `AdChoicesPosition.TopLeftCorner`
* `AdChoicesPosition.BottomRightCorner`
* `AdChoicesPosition.BottomLeftCorner`

#### GADVideoOptions

`VideoOptions` objects are used to indicate how native video assets should be displayed. They offer a single property: `StartMuted`.

This boolean indicates whether video assets should begin playback in a muted state. The default value is `true`.

### When to request ads

Applications displaying Native Advanced ads are free to request them in advance of when they'll actually be displayed. In many cases, this is the recommended practice. An app displaying a list of items with ads mixed in, for example, can load ads for the whole list, knowing that some are shown only after the user scrolls the view and some may not be displayed at all.

> ![note_icon] **_Note:_** _While prefetching ads is a great technique, it's important that publishers not keep old ads around forever without displaying them. Any native ad objects that have been held without display for longer than an hour should be discarded and replaced with new ads from a new request._

### Display an ad

When an ad loads, your app receives an ad object via one of the `IAdLoaderDelegate` protocol messages. Your app is then responsible for displaying the ad (though it doesn't necessarily have to do so immediately). To make displaying system-defined ad formats easier, the SDK offers some useful resources.

#### The ad view classes

For each of the system-defined formats, there is a corresponding "ad view" class: `NativeAppInstallAdView` for app install ads, and `NativeContentAdView` for content ads. These ad view classes are `UIView`s that publishers should use to display ads of the corresponding format. A single `NativeAppInstallAdView`, for example, can display a single instance of a `NativeAppInstallAd`. Each of the `UIView`s used to display that ad's assets should be children of that `NativeAppInstallAdView` object.

If you were displaying an app install ad in a `UITableView`, for example, the view hierarchy for one of the cells might look like this:

![UITable](https://developers.google.com/admob/images/ios_app_install_layout.png)

The ad view classes also provide `Outlet` attributes used to register the view used for each individual asset, and a method to register the `NativeAd` object itself. Registering the views in this way allows the SDK to automatically handle tasks such as:

* Recording clicks.
* Recording impressions (when the first pixel is visible on the screen).
* Displaying the AdChoices overlay.

#### The AdChoices overlay

An AdChoices overlay is added to each ad view by the SDK. Leave space in [your preferred corner](#NativeAdViewOptions) of your native ad view for the automatically inserted AdChoices logo. Also, it's important that the AdChoices overlay be easily seen, so choose background colors and images appropriately. For more information on the overlay's appearance and function, see [Guidelines for programmatic native ads using native styles][5].

### Native video

In addition to images, text, and numbers, some native ads contain video assets. Not every ad will have one and apps are not required to display videos when they're included with an ad.

#### MediaView

Video assets are displayed to users via `MediaView`. This is a `UIView` that can be defined in a nib file or constructed dynamically. It should be placed within the view hierarchy of a `NativeAdView`, as with any other asset view.

Unlike other asset views, however, apps do not need to manually populate a `MediaView` with its asset. The SDK handles this automatically as follows:

* If a video asset is available, it is buffered and starts playing inside the MediaView.
* If the ad does not contain a video asset, the first image asset is downloaded and placed inside the `MediaView` instead.

While apps that don't intend to display video assets aren't required to include a `MediaView` in their layouts, it's recommended that they do.

#### VideoController

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

## Rewarded Video Ads

Rewarded video ads are full-screen video ads that users have the option of watching in full in exchange for in-app rewards.

This guide shows you how to integrate rewarded video ads from AdMob into an iOS app.

### Request rewarded video

`RewardBasedVideoAd` has a singleton design, so the following example shows a request to load an ad being made to the shared instance:

```csharp
RewardBasedVideoAd.SharedInstance.LoadRequest (Request.GetDefaultRequest (), "ca-app-pub-3940256099942544/1712485313");
```

To allow videos to be preloaded, we recommend calling `LoadRequest` method as early as possible (for example, in your app delegate's `FinishedLaunching` method).

### Set up event notifications

To set up event notification, you can use `RewardBasedVideoAd` events or implement the `IRewardBasedVideoAdDelegate` interface.

If you plan to implement `IRewardBasedVideoAdDelegate` interface instead of `RewardBasedVideoAd` events, you are required to set the `Delegate` prior to loading an ad. Insert the line shown before your `LoadRequest` call:

```csharp
RewardBasedVideoAd.SharedInstance.Delegate = this;
```

The most important method in `IRewardBasedVideoAdDelegate` interface is `DidRewardUser` or `UserRewarded` if you are using `RewardBasedVideoAd` events, which is called when the user should be rewarded for watching a video. You may optionally implement other methods or events.

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

### Display rewarded video

It is a best practice to ensure a rewarded video ad has completed loading before attempting to display it. The `IsReady` property indicates that a rewarded video ad request has been successfully fulfilled:

```csharp
if (RewardBasedVideoAd.SharedInstance.IsReady) {
	RewardBasedVideoAd.SharedInstance.PresentFromRootViewController (this);
}
```

## Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][6])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/admob/ios/quick-start) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://apps.admob.com/#account/appmgmt:
[4]: https://support.google.com/admob/answer/6240809
[5]: https://support.google.com/dfp_premium/answer/6075370
[6]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
[deprecated_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/16/519643-144_Forbidden-20.png "Deprecated"
