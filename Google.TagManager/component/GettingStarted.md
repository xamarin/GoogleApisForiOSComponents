## Prerequisites

* Create a [Google Tag Manager account][3].
* [Configure a Google Tag Manager container][4].

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure Analytics in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Open `GoogleService-Info.plist` file and change `IS_ANALYTICS_ENABLED` value to `Yes`. 
4. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Analytics` namespace):

```csharp
App.Configure ();
```

## Download your container and add it to your project

1. Sign in to your [Google Tag Manager][5] account.
2. Select a mobile container.
3. Click Versions in the top navigation bar.
4. Click Actions > Download on the selected container version.
5. The name of the downloaded file is the container ID with a .json extension.
6. Add `GTM-XXXXXX.json` file to your Resources folder in your app project in Xamarin Studio.

## Log events and variables

Google Tag Manager uses Firebase Analytics' events, parameters, and user properties to trigger and build tags you've configured in the Google Tag Manager web interface. In this sense, your Firebase Analytics implementation acts as your data layer.

To learn how to log events and properties, see [Firebase Analytics for iOS Getting Started][6] guide.

### Configure variables in Tag Manager

To capture the value of Firebase event parameters and user properties for use in Google Tag Manager, you can [configure variables][7] in the Tag Manager interface.

For example, if you log the following custom event:

```csharp
NSString [] keys = { new NSString ("image_name"), new NSString ("full_text") };
NSObject [] values = { name, text };
var parameters = NSDictionary<NSString, NSObject>.FromObjectsAndKeys (keys, values, keys.Length);
Analytics.LogEvent ("share_image", parameters);
```

You could configure new **Event Parameter** variables in Google Tag Manager to capture the `image_name` and `full_text` parameter values:

* **Variable Name**: Image Name
* **Variable Type**: Event Parameter
* **Event Parameter Key Name**: image_name

and:

* **Variable Name**: Full Text
* **Variable Type**: Event Parameter
* **Event Parameter Key Name**: full_text

It is similar for user properties, for example:

```csharp
Analytics.SetUserProperty (food, "favorite_food");
```

You could configure a new **Firebase User Property** variable in Google Tag Manager to capture the `favorite_food` value:

* **Variable Name**: Favorite Food
* **Variable Type**: Firebase User Property
* **Event Parameter Key Name**: favorite_food

### Modify and block Firebase Analytics events

Google Tag Manager enables you to modify and block events before they are logged in Firebase Analytics. Modifying events can help you—without app updates—add, remove, or change the values of event parameters or adjust event names. Events that are not blocked will be logged in Firebase Analytics.

Firebase Analytics also automatically logs some [events][8] and [user properties][9]; you don't need to add any code to enable them. These automatically collected events and properties can be used in Google Tag Manager, but cannot be blocked.

## Fire tags

Firebase event name variables, Firebase event parameter variables, and other variables are used to set up [triggers][10]. Trigger conditions are evaluated whenever you log a Firebase event. By default, Firebase Analytics events automatically fire. It is possible to add a Firebase Analytics tag in Tag Manager to block events from being sent to Firebase Analytics.

## Preview, debug, and publish your container

Before publishing a version of your container, you'll want to preview it to make sure it works as intended. Google Tag Manager enables you to preview versions of your container by generating links and QR codes in the Google Tag Manager web interface and using them to open your application.

### Preview container

To preview a container, generate a preview URL in the Google Tag Manager web interface:

1. Sign in to your [Google Tag Manager][5] account.
2. Select a mobile container.
3. Click **Versions** in the top navigation bar.
4. Click **Actions > Preview** on the container version you'd like to preview.
5. Enter your application's Bundle ID.
6. Click **Generate begin preview link**.
7. Save the preview URL.

To enable container previews, you must define the Google Tag Manager preview URL scheme in your **Info.plist** file:

1. In Xamarin Studio, open your Info.plist file and go to **Advance** tab.
2. Click on **Add URL Type**.
3. As Identifer set your Bundle ID.
4. As URL Schemes set `tagmanager.c.<Your Bundle ID>`.
5. Open the preview URL on an emulator or physical device to preview the draft container in your app.

### Debug container

When you run your app in a simulator or in preview mode, Tag Manager automatically turns logging to verbose.

### Publish container

After previewing your container and verifying that it is working, you can [publish it][11]. After you have published your container, your tag configurations are available to mobile app users. When user devices are online, they typically will receive the new configurations within a day.

## Advanced Configuration

To extend the functionality of Google Tag Manager, you can add Function Call variables and Function Call tags. Function Call variables let you capture the values returned by calls to pre-registered functions. Function Call tags let you execute pre-registered functions (e.g. to trigger hits for additional measurement and remarketing tools that are not currently supported with tag templates in Google Tag Manager).

### Add custom tags and variables

To create a custom tag, create a class that implements the `ICustomFunction` interface (don't forget to import `Google.TagManager` namespace):

```csharp
public class MyCustomTag : NSObject, ICustomFunction
{
	public NSObject Execute (NSDictionary parameters)
	{
		// Add custom tag implementation here
	}
}
```

To create a custom variable, create a class that implements the `ICustomFunction` interface:

```csharp
public class MyCustomVariable : NSObject, ICustomFunction
{
	public NSObject Execute (NSDictionary parameters)
	{
		// Return the value of the custom variable.
		return NSNumber.FromNInt (42);
	}
}
```

After you finished creating your custom classes, go to Google Tag Manager's web interface and create **Tags** or **Variables** with **Function Call** as type.

### Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][12])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://developers.google.com/tag-manager/ios/v5/) to see original Google documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://www.google.com/analytics/tag-manager/
[4]: https://support.google.com/tagmanager/answer/6103696#CreatingAnAccount
[5]: https://tagmanager.google.com/
[6]: https://components.xamarin.com/gettingstarted/firebaseiosanalytics
[7]: https://support.google.com/tagmanager/answer/6106899
[8]: https://support.google.com/firebase/answer/6317485
[9]: https://support.google.com/firebase/answer/6317486
[10]: https://support.google.com/tagmanager/answer/6106961
[11]: https://support.google.com/tagmanager/answer/6107163
[12]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689