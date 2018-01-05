# Get Started with Firebase Analytics for iOS

Firebase Analytics collects usage and behavior data for your app. The SDK logs two primary types of information:

* **Events:** What is happening in your app, such as user actions, system events, or errors.
* **User properties:** Attributes you define to describe segments of your userbase, such as language preference or geographic location.

## Table of Content

- [Get Started with Firebase Analytics for iOS](#get-started-with-firebase-analytics-for-ios)
	- [Table of Content](#table-of-content)
	- [Add Firebase to your app](#add-firebase-to-your-app)
	- [Configure Analytics in your app](#configure-analytics-in-your-app)
- [Log events](#log-events)
		- [View events in the dashboard](#view-events-in-the-dashboard)
- [Set User Properties](#set-user-properties)
- [Use Analytics in a WebView on iOS](#use-analytics-in-a-webview-on-ios)
		- [Implement Javascript handler](#implement-javascript-handler)
		- [Implement native interface](#implement-native-interface)
- [Debugging Events](#debugging-events)
		- [Enabling debug mode](#enabling-debug-mode)
- [Track Screenviews](#track-screenviews)
		- [Automatically track screens](#automatically-track-screens)
		- [Manually track screens](#manually-track-screens)
- [Extend Google Analytics for Firebase with Cloud Functions](#extend-google-analytics-for-firebase-with-cloud-functions)
- [Known issues](#known-issues)

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
4. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
App.Configure ();
```

---

# Log events

Events provide insight on what is happening in your app, such as user actions, system events, or errors.

Analytics automatically logs some [events][3] for you; you don't need to add any code to receive them. If your app needs to collect additional data, you can log up to 500 different Analytics Event types in your app. There is no limit on the total volume of events your app logs.

After you have configured Analytics in your app, you can begin to log events with the `Analytics.LogEvent` method. You can find some constants names ready to be used with your log:

* Suggested events: see the `EventNamesConstants` class.
* Prescribed parameters: see the `ParameterNamesConstants` class.

It is very easy to log an event, the following example demonstrates how to log an event with constants values (don't forget to import `Firebase.Analytics` namespace):

```csharp
NSString [] keys = { ParameterNamesConstants.ContentType, ParameterNamesConstants.ItemId };
NSObject [] values = { new NSString ("cont"), new NSString ("1") };
var parameters = NSDictionary<NSString, NSObject>.FromObjectsAndKeys (keys, values, keys.Length);
Analytics.LogEvent (EventNamesConstants.SelectContent, parameters);
```

Or without constants values:

```csharp
NSString [] keys = { new NSString ("Name") };
NSObject [] values = { new NSString ("Image name") };
var parameters = NSDictionary<NSString, NSObject>.FromObjectsAndKeys (keys, values, keys.Length);
Analytics.LogEvent ("share_image", parameters);
```

One important thing to know about custom parameters is that they are not represented directly in your Analytics reports but they can be used as filters in [audience][4] definitions that can be applied to every report. Custom parameters are also included in data [exported to BigQuery][5] if your app is linked to a BigQuery project.

Also, `ParameterNamesConstants.Value` is a general purpose parameter that is useful for accumulating a key metric that pertains to an event. Examples include revenue, distance, time, and points.

> ![note_icon] **_Note: Data logged to Analytics can take hours to be refreshed on reports._**

### View events in the dashboard

You can view aggregrated statistics about your Analytics events in the Firebase console dashboards. These dashboards update periodically throughout the day.

You can access this data in the Firebase console as follows:

1. In the [Firebase console][1], open your project.
2. Select **Analytics** from the menu to view the Analytics reporting dashboard.

The **Events** tab shows the [event reports][10] that are automatically created for each distinct type of Analytics event logged by your app. Read more about the [Analytics reporting dashboard][11] in the Firebase Help Center.

---

# Set User Properties

User properties are attributes you define to describe segments of your userbase, such as language preference or geographic location.

Analytics automatically logs some [user properties][6]; you don't need to add any code to enable them. If your app needs to collect additional data, you can set up to 25 different Analytics User Properties in your app.

> ![note_icon] **_Note: The Age, Gender, and Interests properties are automatically collected only if your app links to the Ad Support framework. Linking to this framework also automatically collects the Advertising Identifier (IDFA)._**

To set a user property you need to:

1. [Register][7] the property in the **Analytics** page of the [Firebase console][1].
2. Add code to set an Analytics user property with the `Analytics.SetUserProperty` method. You can use the name and value of your choosing for each property (don't forget to import `Firebase.Analytics` namespace):

```csharp
// Pass null as value if you want to remove a registered user property
Analytics.SetUserProperty ("your value", "your property name");
```

> ![note_icon] ***Note:*** *Once the property is registered, it can take several hours for data collected with the property to be included in reports. When the new data is available, the user property can be used as a report filter or audience definition.*

You can access this data in the Firebase console as follows:

1. In the [Firebase console][1], open your project.
2. Select **Analytics** from the menu to view the Analytics reporting dashboard.

The **User Properties** tab shows a list of user properties that you have defined for your app. You can use these properties as a filter on many of the reports available in Firebase Analytics. Read more about the [Analytics reporting dashboard][11] in the Firebase Help Center.

> ![note_icon] _**Note:**_ _Data in the Analytics reporting dashboard refreshes periodically throughout the day._

---

# Use Analytics in a WebView on iOS

Calls to log events or set user properties fired from within a WebView must be forwarded to native code before they can be sent to Firebase Analytics.

### Implement Javascript handler

The first step in using Google Analytics for Firebase in a WebView is to create JavaScript functions to forward events and user properties to native code. The following example shows how to do this in a way that is compatible with both Android and iOS native code:

```javascript
function logEvent(name, params) {
  if (!name) {
    return;
  }

  if (window.AnalyticsWebInterface) {
    // Call Android interface
    window.AnalyticsWebInterface.logEvent(name, JSON.stringify(params));
  } else if (window.webkit
      && window.webkit.messageHandlers
      && window.webkit.messageHandlers.firebase) {
    // Call iOS interface
    var message = {
      command: 'logEvent',
      name: name,
      parameters: params
    };
    window.webkit.messageHandlers.firebase.postMessage(message);
  } else {
    // No Android or iOS interface found
    console.log("No native APIs found.");
  }
}

function setUserProperty(name, value) {
  if (!name || !value) {
    return;
  }

  if (window.AnalyticsWebInterface) {
    // Call Android interface
    window.AnalyticsWebInterface.setUserProperty(name, value);
  } else if (window.webkit
      && window.webkit.messageHandlers
      && window.webkit.messageHandlers.firebase) {
    // Call iOS interface
    var message = {
      command: 'setUserProperty',
      name: name,
      value: value
   };
    window.webkit.messageHandlers.firebase.postMessage(message);
  } else {
    // No Android or iOS interface found
    console.log("No native APIs found.");
  }
}
```

### Implement native interface

To invoke native iOS code from JavaScript, create a message handler class conforming to the `IWKScriptMessageHandler` interface. You can make Firebase Analytics calls inside of the `DidReceiveScriptMessage` callback:

```csharp
public void DidReceiveScriptMessage (WKUserContentController userContentController, WKScriptMessage message)
{
	var messageBody = message.Body as NSDictionary;

	switch (messageBody ["command"].ToString ()) {
	case "setUserProperty":
		Analytics.SetUserProperty (messageBody ["value"].ToString (), messageBody ["name"].ToString ());
		break;
	case "logEvent":
		Analytics.LogEvent (messageBody ["name"].ToString (), messageBody ["parameters"] as NSDictionary<NSString, NSObject>);
		break;
	}
}
```

Finally, add the message handler to the webview's user content controller:

```csharp
webView.Configuration.UserContentController.AddScriptMessageHandler (this, "firebase");
```

---

# Debugging Events

DebugView enables you to see the raw event data logged by your app on development devices in near real-time. This is very useful for validation purposes during the instrumentation phase of development and can help you discover errors and mistakes in your analytics implementation and confirm that all events and user properties are being logged correctly.

### Enabling debug mode

Generally, events logged by your app are batched together over the period of approximately one hour and uploaded together. This approach conserves the battery on end users’ devices and reduces network data usage. However, for the purposes of validating your analytics implementation (and, in order to view your analytics in the DebugView report), you can enable Debug mode on your development device to upload events with a minimal delay.

To enable Analytics Debug mode on your development device, follow these steps:

* Visual Studio for Mac
  * Open your project settings
  * Go to Run/Configuration and select your desired configuration
  * In **Extra mlaunch Arguments**, type the command line showed below.

* Visual Studio for Windows
  * Open your project settings
  * Go **iOS Run Options**
  * In **Extra mlaunch Arguments**, type the command line showed below.

```
--argument=-FIRDebugEnabled
```

This behavior persists until you explicitly disable Debug mode by specifying the following command line argument:

```
--argument=-FIRDebugDisabled
```

To learn more about this, please, read the following [documentation][12].

---

# Track Screenviews

Google Analytics for Firebase tracks screen transitions and attaches information about the current screen to events, enabling you to track metrics such as user engagement or user behavior per screen. Much of this data collection happens automatically, but you can also manually track screen names. Manually tracking screens is useful if your app does not use a separate `UIViewController` for each screen you may wish to track, such as in a game.

### Automatically track screens

Analytics automatically tracks some information about screens in your application, such as the class name of the `UIViewController` that is currently in focus. When a screen transition occurs, Analytics logs a `screen_view` event that identifies the new screen. Events that occur on these screens are automatically tagged with the parameter `firebase_screen_class` (for example, `MenuViewController`) and a generated `firebase_screen_id`. If your app uses a distinct `UIViewController` for each screen, Analytics can automatically track every screen transition and generate a report of user engagement broken down by screen. If your app doesn't, you can still get these reports by manually setting the screen name with the API.

### Manually track screens

You can manually set the screen name and optionally override the class name when screen transitions occur. After setting the screen name, events that occur on these screens are additionally tagged with the parameter `firebase_screen`. For example, you could name a screen "Main Menu" or "Friends List". The following example shows how to manually set the screen name:

```csharp
Firebase.Analytics.Analytics.SetScreenNameAndClass (screenName:, screenClass);
```

The screen name and screen class stay the same until the `UIViewController` changes or you make a new call to `SetScreenNameAndClass`.

---

# Extend Google Analytics for Firebase with Cloud Functions

Google Analytics for Firebase provides event reports that help you understand how users interact with your app. With Cloud Functions, you can access conversion events you have logged and trigger functions based on those events.

> ![note_icon] _Only events marked as conversion events are currently supported by Cloud Functions. You can specify which events are conversion events in the [Events][13] tab of the Firebase console **Analytics** pane._

To learn more about this, please, read the following [documentation][14].

---

# Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][8])
* Passing `-FIRDebugEnabled` to Extra mlaunch Arguments doesn't enable debug console. (Bug [#43899][9])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/analytics/ios/start) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://support.google.com/firebase/answer/6317485
[4]: https://support.google.com/firebase/answer/6317509?hl=en&ref_topic=6317489
[5]: https://support.google.com/firebase/answer/6318765
[6]: https://support.google.com/firebase/answer/6317486
[7]: https://support.google.com/firebase/answer/6317519?hl=en&ref_topic=6317489#create-property
[8]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
[9]: https://bugzilla.xamarin.com/show_bug.cgi?id=43899
[10]: https://support.google.com/firebase/answer/6317522?hl=en&ref_topic=6317489
[11]: https://support.google.com/firebase/answer/6317517?hl=en&ref_topic=6317489
[12]: https://firebase.google.com/docs/analytics/debugview
[13]: https://console.firebase.google.com/project/_/analytics/app/_/events
[14]: https://firebase.google.com/docs/analytics/extend-with-functions
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
