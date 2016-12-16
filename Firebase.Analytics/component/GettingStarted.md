# Get Started with Firebase Analytics for iOS

Firebase Analytics collects usage and behavior data for your app. The SDK logs two primary types of information:

* **Events:** What is happening in your app, such as user actions, system events, or errors.
* **User properties:** Attributes you define to describe segments of your userbase, such as language preference or geographic location.

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

## Log events

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

**_Note: Data logged to Analytics can take hours to be refreshed on reports._**

## View events in the dashboard

You can view aggregrated statistics about your Analytics events in the Firebase console dashboards. These dashboards update periodically throughout the day.

You can access this data in the Firebase console as follows:

1. In the [Firebase console][1], open your project.
2. Select **Analytics** from the menu to view the Analytics reporting dashboard.

The **Events** tab shows the [event reports][10] that are automatically created for each distinct type of Analytics event logged by your app. Read more about the [Analytics reporting dashboard][11] in the Firebase Help Center.

## Set User Properties

User properties are attributes you define to describe segments of your userbase, such as language preference or geographic location.

Analytics automatically logs some [user properties][6]; you don't need to add any code to enable them. If your app needs to collect additional data, you can set up to 25 different Analytics User Properties in your app.

**_Note: The Age, Gender, and Interests properties are automatically collected only if your app links to the Ad Support framework. Linking to this framework also automatically collects the Advertising Identifier (IDFA)._**

To set a user property you need to:

1. [Register][7] the property in the **Analytics** page of the [Firebase console][1].
2. Add code to set an Analytics user property with the `Analytics.SetUserProperty` method. You can use the name and value of your choosing for each property (don't forget to import `Firebase.Analytics` namespace):

```csharp
// Pass null as value if you want to remove a registered user property
Analytics.SetUserProperty ("your value", "your property name");
```

***Note:*** *Once the property is registered, it can take several hours for data collected with the property to be included in reports. When the new data is available, the user property can be used as a report filter or audience definition.*

You can access this data in the Firebase console as follows:

1. In the [Firebase console][1], open your project.
2. Select **Analytics** from the menu to view the Analytics reporting dashboard.

The **User Properties** tab shows a list of user properties that you have defined for your app. You can use these properties as a filter on many of the reports available in Firebase Analytics. Read more about the [Analytics reporting dashboard][11] in the Firebase Help Center.

### Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][8])
* Passing `-FIRAnalyticsDebugEnabled` to Run arguments doesn't enable debug console. (Bug [#43899][9])

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
