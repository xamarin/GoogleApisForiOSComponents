# Firebase Dynamic Links on iOS

With Firebase Dynamic Links, you can give new users of your app a personalized onboarding experience, and thus increase user sign-ups, user retention, and long-term user engagement.

Dynamic Links are links into an app that work whether or not users have installed the app yet. When users open a Dynamic Link into an app that is not installed, the app's App Store page opens, where users can install the app. After users install and open the app, the app handles the link.

An app might handle the link by opening the app's content using custom URL schemes on iOS 8, or handling Universal Links on iOS 9 and newer. Or, an app could handle the link by initiating some app-specific logic such as crediting the user with a coupon, or displaying a specific welcome screen.

## Table of content

- [Prerequisites](#prerequisites)
- [Add Firebase to your app](#add-firebase-to-your-app)
- [Configure Dynamic Links in your app](#configure-dynamic-links-in-your-app)
- [Use the iOS Builder API](#use-the-ios-builder-api)
	- [Create a long link from parameters](#create-a-long-link-from-parameters)
	- [Set the length of a short Dynamic Link](#set-the-length-of-a-short-dynamic-link)
	- [Create a short link from a long link](#create-a-short-link-from-a-long-link)
- [Manually constructing a Dynamic Link URL](#manually-constructing-a-dynamic-link-url)
- [Open Dynamic Links in your app](#open-dynamic-links-in-your-app)
- [Known issues](#known-issues)

## Prerequisites

Firebase Dynamic Links requires iOS 8 or newer. You can target iOS 7 in your app, but Firebase Dynamic Links SDK calls only function on apps running iOS 8 or newer.

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.
5. Go to **Project settings**, in **General** tab select your recently created iOS bundle ID.
6. Set your App Store ID, you can find your App Store ID in your app’s URL. (e.g. https://itunes.apple.com/us/app/yourapp/id123456789, **123456789** is your App Store ID).
7. Set your Team ID, you can find your Team ID in the Apple Member Center under the [membership tab][3].
8. In [Firebase console][1], in your project menu go to Dynamic Links tab, accept the terms of service if you are prompted to do so, copy Url link, paste it into your Navigation bar and add **/apple-app-site-association** (e.g https://app_code.app.goo.gl//apple-app-site-association)
9. Your app is connected if the apple-app-site-association file contains a reference to your app's App Store ID and bundle ID, for example:

```
{"applinks":{"apps":[],"details":[{"appID":"1234567890.com.example.ios","paths":["/*"]}]}}
```

If the details field is empty, double-check that you specified your Team ID.

## Configure Dynamic Links in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. In your `Entitlements.plist` file, enable **Associated Domains**.
4. Add `applinks:app_code.app.goo.gl` to **Domains** where **app_code** is your Dynamic Links identifier.
5. In your `Info.plist` file, go to **Advance** and add an Url Type.
6. Set the **Identifier** field to a unique value and the **URL scheme** field to either your Bundle ID or a unique value. If you set the **URL scheme** to a value other than your Bundle ID, you must specify the Bundle ID when you create your Dynamic Links.
7. Add the following lines of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
// Set DeepLinkUrlScheme to the custom URL scheme you defined in your
// Info.plist.
Options.DefaultInstance.DeepLinkUrlScheme = "CUSTOM_URL_SCHEME";
App.Configure ();
```

## Create Dynamic Links

There are four ways you can create a Dynamic Link:

* Using the [Firebase console][4]. This is useful if you're creating one-off links to share on social media.
* Using the [Dynamic Link Builder API](#use-the-ios-builder-api). This is the preferred way to dynamically create links in your app for user-to-user sharing or in any situation that requires many links. You can track the performance of Dynamic Links created with the Builder API using the Dynamic Links [Analytics API][5].
* Using the [REST API][6]. This is the preferred way to dynamically create links on platforms that don't have a Builder API. You can track the performance of Dynamic Links created with the REST API using the Dynamic Links [Analytics API][5].
* [Manually](#manually-constructing-a-dynamic-link-url). If you don't need to track click data and you don't care if the links are long, you can manually construct Dynamic Links using URL parameters, and by doing so, avoid an extra network round trip.

## Use the iOS Builder API

You can create short or long Dynamic Links with the Firebase Dynamic Links iOS Builder API. This API accepts either a long Dynamic Link or an object containing Dynamic Link parameters, and returns a URL like the following example:

```
https://abc123.app.goo.gl/WXYZ
```

### Create a long link from parameters

You can create a Dynamic Link programmatically by setting the following parameters and getting the `DynamicLinkComponents.Url` parameter:

```csharp
var link = NSUrl.FromString (dictionary ["Link"].ToString ());
var components = DynamicLinkComponents.FromLink (link, Dynamic_Link_Domain);

var source = dictionary ["Source"].ToString ();
var medium = dictionary ["Medium"].ToString ();
var campaign = dictionary ["Campaign"].ToString ();

var analyticsParams = DynamicLinkGoogleAnalyticsParameters.FromSource (source, medium, campaign);
analyticsParams.Term = dictionary ["Term"].ToString ();
analyticsParams.Content = dictionary ["Content"].ToString ();
components.AnalyticsParameters = analyticsParams;

var bundleId = dictionary ["BundleID"].ToString ();

if (!string.IsNullOrWhiteSpace (bundleId)) {
	var iOSParams = DynamicLinkiOSParameters.FromBundleId (bundleId);
	iOSParams.FallbackUrl = NSUrl.FromString (dictionary ["FallbackURL"].ToString ());
	iOSParams.MinimumAppVersion = dictionary ["MinimumAppVersion"].ToString ();
	iOSParams.CustomScheme = dictionary ["CustomScheme"].ToString ();
	iOSParams.IPadBundleId = dictionary ["IPadBundleId"].ToString ();
	iOSParams.IPadFallbackUrl = NSUrl.FromString (dictionary ["IPadFallbackUrl"].ToString ());
	iOSParams.AppStoreId = dictionary ["AppStoreId"].ToString ();
	components.IOSParameters = iOSParams;

	var appStoreParams = DynamicLinkiTunesConnectAnalyticsParameters.Create ();
	appStoreParams.AffiliateToken = dictionary ["AffiliateToken"].ToString ();
	appStoreParams.CampaignToken = dictionary ["CampaignToken"].ToString ();
	appStoreParams.ProviderToken = dictionary ["ProviderToken"].ToString ();
	components.ITunesConnectParameters = appStoreParams;
}

var packageName = dictionary ["PackageName"].ToString ();

if (!string.IsNullOrWhiteSpace (packageName)) {
	var androidParams = DynamicLinkAndroidParameters.FromPackageName (packageName);
	androidParams.FallbackUrl = NSUrl.FromString (dictionary ["FallbackURL"].ToString ());
	androidParams.MinimumVersion = nint.Parse (dictionary ["MinimumAppVersion"].ToString ());
	components.AndroidParameters = androidParams;
}

var socialParams = DynamicLinkSocialMetaTagParameters.Create ();
socialParams.Title = dictionary ["Title"].ToString ();
socialParams.DescriptionText = dictionary ["DescriptionText"].ToString ();
socialParams.ImageUrl = NSUrl.FromString (dictionary ["ImageUrl"].ToString ());
components.SocialMetaTagParameters = socialParams;

var longLink = components.Url;
Console.WriteLine (longLink.AbsoluteString);
```

### Set the length of a short Dynamic Link

You can also set the `PathLength` parameter to specify how the path component of the short Dynamic Link is generated:

```csharp
var options = DynamicLinkComponentsOptions.Create ();
options.PathLength = ShortDynamicLinkPathLength.Unguessable;
components.Options = options;
```

By default, or if you set the parameter to `Unguessable`, the path component will be a 17-character string, like in the following example:

```
https://abc123.app.goo.gl/UVWXYZuvwxyz12345
```

Such strings are created by base62-encoding randomly generated 96-bit numbers. Use this setting to prevent your Dynamic Links URLs from being guessed and crawled, which can potentially expose sensitive information to unintended recipients.

If you set the parameter to `Short`, the path component will be a string that is only as long as needed to be unique, with a minimum length of 4 characters:

```
https://abc123.app.goo.gl/WXYZ
```

Use this method if sensitive information would not be exposed if a short Dynamic Link URL were guessed.

### Create a short link from a long link

You can use the Firebase Dynamic Links API to shorten a long Dynamic Link. To do so, call:

```csharp
components.GetShortenUrl ((shortUrl, warnings, error) => {
	// Handle shortURL or error.
	if (error != null) {
		Console.WriteLine ($"Error generating short link: {error.LocalizedDescription}");
		return;
	}

	Console.WriteLine (shortUrl.AbsoluteString);
});

// async/await way:

try {
	var result = await components.GetShortenUrlAsync ();
	Console.WriteLine (result.ShortUrl.AbsoluteString);
} catch (NSErrorException ex) {
	Console.WriteLine ($"Error generating short link: {ex.Error.LocalizedDescription}");
}
```

## Manually constructing a Dynamic Link URL

Please, read this [Firebase documentation][7] to learn how to construct a Dynamic Link URL manually.

## Open Dynamic Links in your app

You will need to override `OpenUrl (UIApplication, NSUrl, string, NSObject)` method to support iOS 8 or older and `OpenUrl (UIApplication, NSUrl, NSDictionary)` method to support iOS 9 or newer. These methods handle links received through your app's custom URL scheme. These methods are called when your app receives a link on iOS 8 and older, and when your app is opened for the first time after installation on any version of iOS:

```csharp
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
```

Override `ContinueUserActivity (UIApplication, NSUserActivity, UIApplicationRestorationHandler)` method to handle links received as [Universal Links][8] on iOS 9 and newer:

```csharp
// Handle links received as Universal Links on iOS 9 or later
public override bool ContinueUserActivity (UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
{
	return DynamicLinks.SharedInstance.HandleUniversalLink (userActivity.WebPageUrl, (dynamicLink, error) => {
		if (error != null) {
			System.Console.WriteLine (error.LocalizedDescription);
			return;
		}

		// Handle Universal Link
	});
}
```

## View Dynamic Links Analytics Data

To help you gauge the effectiveness of your promotions and campaigns, Firebase Dynamic Links provides several ways to view analytics data and integrate with analytics tools.

To learn more about this, please, read the following [documentation][10].

## Debugging Dynamic Links

To help you debug your Dynamic Links, you can preview your Dynamic Links' behavior on different platforms and configurations with an automatically-generated flowchart. Generate the flowchart by adding the d=1 parameter to any short or long Dynamic Link. For example, app_code.app.goo.gl/path?d=1 for a short Dynamic Link.

To learn more about this, please, read the following [documentation][11].

## Generate link previews with social metadata

To learn about this, please, read the following [documentation][12].

## Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][9])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/dynamic-links/ios) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://developer.apple.com/account/#/membership
[4]: https://console.firebase.google.com/project/_/durablelinks/links/
[5]: https://firebase.google.com/docs/reference/dynamic-links/analytics
[6]: https://firebase.google.com/docs/dynamic-links/rest
[7]: https://firebase.google.com/docs/dynamic-links/create-manually
[8]: https://developer.apple.com/library/ios/documentation/General/Conceptual/AppSearch/UniversalLinks.html
[9]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
[10]: https://firebase.google.com/docs/dynamic-links/analytics
[11]: https://firebase.google.com/docs/dynamic-links/debug
[12]: https://firebase.google.com/docs/dynamic-links/link-previews
