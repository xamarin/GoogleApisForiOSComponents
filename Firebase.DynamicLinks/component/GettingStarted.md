# Firebase Dynamic Links on iOS

With Firebase Dynamic Links, you can give new users of your app a personalized onboarding experience, and thus increase user sign-ups, user retention, and long-term user engagement.

Dynamic Links are links into an app that work whether or not users have installed the app yet. When users open a Dynamic Link into an app that is not installed, the app's App Store page opens, where users can install the app. After users install and open the app, the app handles the link.

An app might handle the link by opening the app's content using custom URL schemes on iOS 8, or handling Universal Links on iOS 9 and newer. Or, an app could handle the link by initiating some app-specific logic such as crediting the user with a coupon, or displaying a specific welcome screen.

## Prerequisites

Firebase Dynamic Links requires iOS 8 or newer. You can target iOS 7 in your app, but all Firebase Dynamic Links SDK calls will be no-ops if the app isn't running on iOS 8 or newer.

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
7. Add the following lines of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Analytics` namespace):

```csharp
// Set DeepLinkUrlScheme to the custom URL scheme you defined in your
// Info.plist.
Options.DefaultInstance.DeepLinkUrlScheme = "CUSTOM_URL_SCHEME";
App.Configure ();
```

## Create a Dynamic Link

To create a Dynamic Link follow this [documentation][4]

## Handle Dynamic Links in your app

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

Override `ContinueUserActivity (UIApplication, NSUserActivity, UIApplicationRestorationHandler)` method to handle links received as [Universal Links][5] on iOS 9 and newer:

```
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

### Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][6])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/dynamic-links/ios) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://developer.apple.com/account/#/membership
[4]: https://firebase.google.com/docs/dynamic-links/ios#create-a-dynamic-link
[5]: https://developer.apple.com/library/ios/documentation/General/Conceptual/AppSearch/UniversalLinks.html
[6]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689