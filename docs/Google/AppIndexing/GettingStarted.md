## Support HTTP URLs

App Indexing for iOS 9 uses HTTP URLs to direct users to content in your app. If you’ve already followed the instructions to [support universal links][1] in your app, you can skip this section. Otherwise, do the following:

### Create the app-to-site association.

This involves two things:

- Add a `com.apple.developer.associated-domains` entitlement in entitlement.plist file that lists each domain associated with your app.
- Create an `apple-app-site-association` file for each associated domain with the content your app supports and host it at the root level.

*Note: The association file must be hosted on a domain that supports HTTPS/TLS, even if the HTTP deep links are not themselves served via HTTPS.*

#### Preparing Your Website

1. Create a apple-app-site-association file. Note that there’s no .json file type
2. Place the apple-app-site-association file and identify app IDs and paths on your website. You can define several apps in this file and iOS will follow the app order when looking for a match so you can specify different apps to handle different paths on your website.

Here's an example of file's content:

```
{
    "applinks": {
        "apps": [],
        "details": [
            {
                "appID": "9JA89QQLNQ.com.apple.wwdc",
                "paths": [ "/wwdc/news/", "/videos/wwdc/2015/*"]
            },
            {
                "appID": "TeamID.BundleID2",
                "paths": [ "*" ]
            }
        ]
    }
}
```

The apps key in an apple-app-site-association file must be present and its value must be an empty array. The value of the details key is an array of dictionaries, one dictionary per app that your website supports. The order of the dictionaries in the array determines the order the system follows when looking for a match, so you can specify an app to handle a particular part of your website.

Each app-specific dictionary contains an appID key and a paths key. The value of the appID key is the app’s team ID and the bundle ID; the value of the paths key is an array of strings that specify the parts of your website that are supported by the app and the parts of your website that you don’t want to associate with the app. To specify an area that should not be handled as a universal link, add “NOT ” (including a space after the T) to the beginning of the path string. For example:

```
"paths": [ "/wwdc/news/", "NOT /videos/wwdc/2010/*", "/videos/wwdc/201?/*"]
```

Upload the apple-app-site-association file in the root of your HTTPS web server. The file should be accessible without redirects at http://<domain>/apple-app-site-association

### Preparing your App

#### Creating an App ID and provisioning profile

To make Universal Links works, you need to create a Provisioning Profile with an Explicit App Id with Associated Domains Services enabled. To achieve this, follow this steps:

1. On the Apple Developer Member Center home page, click Certificates, Identifiers & Profiles.
2. On the Certificates, Identifiers & Profiles page, under the iOS Apps column, click Identifiers.
3. On the iOS App IDs page, click on the **+** button.
4. On the Registering an App ID page, enter an App ID Description/Name, select **Explicit App ID**, enter your app’s Bundle ID, enable **Associated Domains
** Service and then click Continue.
5. On the Confirm your App ID page, click Submit.
6. On the Registration complete page, click Done.
7. Create a provisioning profile with the new App ID.

#### Enabling Associated Domains in your app

1. In you Xamarin iOS project, open the Entitlements.plist file
2. Open the Associated Domains header and check **Enable Associated Domains**
3. Add your domains starting with `applinks:`, for example: `applinks:xamarin.com`

#### Add handling for universal links to your app.

Adopt the [UIApplicationDelegate][2] methods so that your app opens the appropriate app content in response to the user’s click from search results.

```csharp
public override bool ContinueUserActivity (UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
{
	if (userActivity.ActivityType == NSUserActivityType.BrowsingWeb) {
		// Do your magic here.
	}

	return true;
}
```

[1]: https://developer.apple.com/library/prerelease/ios/documentation/General/Conceptual/AppSearch/UniversalLinks.html#//apple_ref/doc/uid/TP40016308-CH12-SW1
[2]: https://developer.apple.com/library/prerelease/ios/documentation/UIKit/Reference/UIApplicationDelegate_Protocol/index.html#//apple_ref/occ/intf/UIApplicationDelegate

## Register your app to Google system

Call the `RegisterApp` method in your `FinishedLaunching` method.

```csharp
AppIndexing.SharedInstance.RegisterApp ("YOUR_ITUNES_ID");
```

You're all set! Once Google's crawlers discover the the URLs in your association file, Google will automatically start indexing any existing or new HTTP deep links to your app.

## Check Your Implementation

Once you've completed setup for App Indexing, you can verify your universal links prior to their appearance in Google Search by tapping a universal link in Safari on your device and making sure that it takes you to the right place in the app.

*Note: You cannot test universal links on simulator.*

## Enhance Your Search Performance

A key way to enhance your app's ranking is to provide high-quality content in your site and your app. Specifically, keep in mind the following:

- Make sure your associated site meets Google's [design and content guidelines][3].
- Follow the same layout practices recommended for your [mobile-friendly homepage][4]. For example, keep your titles short and avoid full-width menus.

In order to ensure a great search experience for users, Google may take corrective action in cases where they see abuse, deception, or other actions that hurt the search experience for users. This can include actions such as demoting or removing your app deep links from Google Search results.

[3]: https://support.google.com/webmasters/answer/35769?vid=1-635785548570479109-2344616627#design_and_content_guidelines
[4]: https://developers.google.com/web/fundamentals/layouts/principles/