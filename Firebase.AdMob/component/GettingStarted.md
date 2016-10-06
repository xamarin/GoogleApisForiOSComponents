# Get Started

AdMob uses the Google Mobile Ads SDK. The Google Mobile Ads SDK helps app developers gain insights about their users, drives more in-app purchases, and maximizes ad revenue. To do so, the default integration of the Mobile Ads SDK collects information such as device information, publisher-provided location information, and general in-app purchase information (such as item purchase price and currency).

**_Note: The Mobile Ads SDK does not collect payment card information._**

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
4. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Analytics` namespace):

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

## Banner Ads

### Banner sizes

| Size (WxH)              | Description          | Availability         | AdSize constant                                               |
|:-----------------------:|:--------------------:|:--------------------:|:-------------------------------------------------------------:|
| 320x50                  | Standard banner      | Phones and tablets   | kGADAdSizeBanner                                              |
| 320x100                 | Large banner         | Phones and tablets   | kGADAdSizeLargeBanner                                         |
| 300x250                 | IAB medium rectangle | Phones and tablets   | kGADAdSizeMediumRectangle                                     |
| 468x60                  | IAB full-size banner | Tablets              | kGADAdSizeFullBanner                                          |
| 728x90                  | IAB leaderboard      | Tablets              | kGADAdSizeLeaderboard                                         |
| Screen width x 32,50,90 | Smart banner         | Phones and tablets   | kGADAdSizeSmartBannerPortrait, kGADAdSizeSmartBannerLandscape |

### Smart Banners

Smart Banners are ad units that render screen-wide banner ads on any screen size across different devices in either orientation. Smart Banners help deal with increasing screen fragmentation across different devices by "smartly" detecting the width of the phone in its current orientation, and making the ad view that size.

Three ad heights (in density-independent pixel [dp]) are implemented in Smart Banners:

* **32:** Device screen height <= 400
* **50:** 400 < Device screen height <= 720
* **90:** Device screen height > 720

For some devices, such as phones, the height of the device varies with its orientation. Typically, Smart Banner ads on phones are full width x 50dp in portrait and full width x 32dp in landscape, while on tablets, ads are full width x 90dp in both orientations.

When an image ad isn't large enough to take up the entire allotted space, the image is centered and the space on either side is filled in.

### Ad lifecycle events

You may optionally track ad lifecycle events like request failures or "click-through" by implementing all or part of `BannerView` events or `IBannerViewDelegate` interface.

* **AdReceived Event or DidReceiveAd method:** This is called when `LoadRequest` method has succeeded. This is a good opportunity to show the ad.

* **ReceiveAdFailed event or DidFailToReceiveAd method:** This is called when `LoadRequest` method has failed, typically because of network failure, an app configuration error, or a lack of ad inventory.

* **WillPresentScreen event or method:** This callback is sent immediately before the user is presented with a full-screen ad UI in response to their touching the ad. At this point, you should pause any animations, timers, or other activities that assume user interaction and save app state.

* **WillDismissScreen event or method:** Sent immediately before the ad's full-screen UI is dismissed, restoring your app and the root view controller. At this point, you should restart any foreground activities paused.

* **ScreenDismissed event or DidDismissScreen method:** Sent when the user has exited the ad's full-screen UI.

* **WillLeaveApplication event or method:** Sent just before the app gets backgrounded or terminated as a result of the user touching a Click-to-App-Store or Click-to-iTunes banner. The normal `UIApplicationDelegate` notifications like `DidEnterBackground` arrive immediately before this.

**_Note: Do not request an ad in `WillEnterForeground` method, as the request will be ignored. Place the request in `OnActivated` method instead._**

### Create a Banner

To create a banner ad unit you can use the following code in a similar way:

```csharp
using Google.MobileAds;
...

const string bannerId = "<Get your ID at google.com/ads/admob>";

BannerView adView;
bool viewOnScreen = false;

public void AddBanner ()
{
	// Setup your BannerView, review AdSizeCons class for more Ad sizes. 
	adView = new BannerView (size: AdSizeCons.Banner, origin: new CGPoint (0, 0)) {
		AdUnitID = bannerId,
		RootViewController = this
	};
	
	// Wire AdReceived event to know when the Ad is ready to be displayed
	adView.AdReceived += (object sender, EventArgs e) => {
		if (!viewOnScreen) {
			View.AddSubview (adView);
			viewOnScreen = true;
		}
	};

	var request = Request.GetDefaultRequest ();
	// Requests test ads on devices you specify. Your test device ID is printed to the console when
	// an ad request is made. GADBannerView automatically returns test ads when running on a
	// simulator. After you get your device ID, add it here
	request.TestDevices = new [] { Request.SimulatorId.ToString () };
  	
	// Request an ad
	adView.LoadRequest (request);
}
```

## Interstitial Ads

Interstitial ads are full-screen ads that are overlaid on top of an app. They are generally displayed at natural app transition points such as in between game levels.

### Add interstitial ads to your project

The recommended lifecycle for a Interstitial is to preload it when the app starts and show it at an appropriate time in your app when it's ready:

```csharp
using Google.MobileAds;
...

const string intersitialId = "<Get your ID at google.com/ads/admob>";

Interstitial adInterstitial;

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	
	CreateAndRequestInterstitial ();
}

public void AfterSomeTime ()
{	
	if (adInterstitial.IsReady)
		adInterstitial.PresentFromRootViewController (navController);
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
	
	var request = Request.GetDefaultRequest ();
	// Requests test ads on devices you specify. Your test device ID is printed to the console when
	// an ad request is made. GADBannerView automatically returns test ads when running on a
	// simulator. After you get your device ID, add it here
	request.TestDevices = new [] { Request.SimulatorId.ToString () };

	adInterstitial.LoadRequest (request);
}

```

### Only show GADInterstitial once

`Interstitial` is a one time use object. That means once an interstitial is shown, HasBeenUsed returns true and the interstitial can't be used to load another ad. To request another interstitial, you'll need to create a new `Interstitial` object. The best practice, as shown above, is to have a helper method to handle creating and loading an interstitial.

The best place to allocate another interstitial is in the `Interstitial.ScreenDismissed` event or `DidDismissScreen` method if you implemented `IInterstitialDelegate` interface so that the next interstitial starts loading as soon as the previous one is dismissed.

## iOS 9 Considerations

App Transport Security (ATS) is a privacy feature introduced in iOS 9. It's enabled by default for new applications and enforces secure connections. This may affect your app's integration with the Google Mobile Ads SDK. See the [NSAppTransportSecurity][4] documentation for details.

This change affects all iOS 9 devices running apps built with Xcode 7 that don't disable ATS. The following log message appears when a non-ATS-compliant app attempts to serve an ad via HTTP on iOS 9:

```
App Transport Security has blocked a cleartext HTTP (http://)
resource load since it is insecure. Temporary exceptions can be
configured via your app's Info.plist file.
```

To ensure your ads are not impacted by ATS, Apple has provided the following exception that you can add to your app's Info.plist file:

```
<key>NSAppTransportSecurity</key>
<dict>
    <key>NSAllowsArbitraryLoads</key>
    <true/>
</dict>
```

### Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][5])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/admob/ios/quick-start) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://apps.admob.com/#account/appmgmt:
[4]: https://developer.apple.com/library/ios/documentation/General/Reference/InfoPlistKeyReference/Articles/CocoaKeys.html#//apple_ref/doc/plist/info/NSAppTransportSecurity
[5]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689