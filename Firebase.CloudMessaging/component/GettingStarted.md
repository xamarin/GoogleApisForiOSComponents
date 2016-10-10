# Setting Up a Firebase Cloud Messaging Client App on iOS

You can implement Firebase Cloud Messaging in two complementary ways:

* Receive basic push messages up to 2KB over the Firebase Cloud Messaging APNs interface.
* Send messages upstream and/or receive downstream payloads up to 4KB.

## Prerequisites

If you want to enable Notifications specifically, you'll need to create an [APNs SSL Certificate][3], then [upload it to Firebase][4] and finally register the app for remote notifications.

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure Cloud Messaging in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Open `GoogleService-Info.plist` file and change `IS_GCM_ENABLED` value to `Yes`. 
4. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Analytics` namespace):

```csharp
App.Configure ();
```

## Register for remote notifications

Either at startup, or at the desired point in your application flow, register your app for remote notifications. Call `RegisterForRemoteNotifications` method as shown:

```csharp
// Register your app for remote notifications.
if (UIDevice.CurrentDevice.CheckSystemVersion (10, 0)) {
	// iOS 10 or later
	var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
	UNUserNotificationCenter.Current.RequestAuthorization (authOptions, (granted, error) => {
		Console.WriteLine (granted);
	});

	// For iOS 10 display notification (sent via APNS)
	UNUserNotificationCenter.Current.Delegate = this;

	// For iOS 10 data message (sent via FCM)
	Messaging.SharedInstance.RemoteMessageDelegate = this;
} else {
	// iOS 9 or before
	var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
	var settings = UIUserNotificationSettings.GetSettingsForTypes (allNotificationTypes, null);
	UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);
}

UIApplication.SharedApplication.RegisterForRemoteNotifications ();
```

For devices running iOS 10 and above, you must assign your delegate object to the `UNUserNotificationCenter` object to receive display notifications, and the `Messaging` object to receive data messages, before your app finishes launching. 

At this point you have all set to start using Firebase Cloud Messaging component.

## Method swizzling in Firebase Cloud Messaging

One important thing you should know before start using FCM is that FCM API performs method swizzling in two key areas: mapping your APNs token to the FCM registration token and capturing analytics data during downstream message callback handling. Developers who prefer not to use swizzling can disable it by adding the flag `FirebaseAppDelegateProxyEnabled` in the app’s Info.plist file and setting it to `No` (boolean value). If you decided to disable swizzling, the docs provide example for both scenarios, with and without method swizzling enabled.

## Receive messages

Firebase notifications behave differently depending on the foreground/background state of the receiving app.

### Receive messages through FCM

To receive or send messages through FCM (not just the APNs interface), you'll need to connect to the FCM service. Connect when your application becomes active and whenever a new registration token is available. Once your app is connected, FCM ignores subsequent attempts to connect (don't forget to import `Firebase.CloudMessaging` namespace):

```csharp
Messaging.SharedInstance.Connect (error => {
	if (error != null) {
		// Handle if something went wrong while connecting
	} else {
		// Let the user know that connection was successful
	}
});
```

When your app goes into the background, disconnect from FCM:

```csharp
public override void DidEnterBackground (UIApplication application)
{
	// Use this method to release shared resources, save user data, invalidate timers and store the application state.
	// If your application supports background exection this method is called instead of WillTerminate when the user quits.
	Messaging.SharedInstance.Disconnect ();
	Console.WriteLine ("Disconnected from FCM");
}
```

### Handling messages

For devices running iOS 9 and below, override AppDelegate's `DidReceiveRemoteNotification` method **to handle notifications received when the client app is in the foreground**, and all data messages that are sent to the client. The message is a dictionary of keys and values:

```csharp
// To receive notifications in foregroung on iOS 9 and below.
// To receive notifications in background in any iOS version
public override void DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
{
	// If you are receiving a notification message while your app is in the background,
	// this callback will not be fired 'till the user taps on the notification launching the application.
	
	// Do your magic to handle the notification data
	System.Console.WriteLine (userInfo);
}
```

For devices running iOS 10 and above, implement `IUNUserNotificationCenterDelegate` interface and override `WillPresentNotification` method **to handle notifications received when the client app is in the foreground**. The message is a `UNNotification` object. Implement `IMessagingDelegate` interface and override `ApplicationReceivedRemoteMessage` to handle all data messages that are sent to the client. The message is a `RemoteMessage` object:

```csharp
// To receive notifications in foreground on iOS 10 devices.
[Export ("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
public void WillPresentNotification (UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
{
	// Do your magic to handle the notification data
	System.Console.WriteLine (notification.Request.Content.UserInfo);
}

// Receive data message on iOS 10 devices.
public void ApplicationReceivedRemoteMessage (RemoteMessage remoteMessage)
{
	Console.WriteLine (remoteMessage.AppData);
}
```

### Handling messages with method swizzling disabled

If you disable method swizzling, you'll need to call method `AppDidReceiveMessage`. This lets FCM track message delivery and analytics, which is performed automatically with method swizzling enabled.

```csharp
public override void DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
{
	// If you are receiving a notification message while your app is in the background,
	// this callback will not be fired 'till the user taps on the notification launching the application.
	
	// If you disable method swizzling, you'll need to call this method. 
	// This lets FCM track message delivery and analytics, which is performed
	// automatically with method swizzling enabled.
	Messaging.SharedInstance.AppDidReceiveMessage (userInfo);
	
	// Do your magic to handle the notification data
	System.Console.WriteLine (userInfo);
}
```

### Receive and handle messages with notification in the payload

When your app is in the background, iOS directs messages with the notification key to the system tray. A user tap on a notification opens the app, and the content of the notification is passed to the `DidReceiveRemoteNotification` method if implemented in the AppDelegate.

If you want to open your app and perform a specific action, set click_action in the [notification payload][6]. Use the value that you would use for the category key in the APNs payload.

### Known issue - iOS 10 does not call DidReceiveRemoteNotification

There's a problem with iOS 10 and handling your notifications when your app is in background state or closed. When your app is in background state or closed and you tap a notification related to your app, the expected behaviour is that your app is opened and `DidReceiveRemoteNotification` method is called to handle the notification data but it seems that `DidReceiveRemoteNotification` method is never called (this will be fixed on iOS 10.1). In the meanwhile time, you can workaround this by implementing `DidReceiveNotificationResponse` method from `IUNUserNotificationCenterDelegate` interface:

```csharp
[Export ("userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
public void DidReceiveNotificationResponse (UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
{
	// Do your magic to handle the notification data
	System.Console.WriteLine (userInfo);
}
```

## Send a message to a single device

### Access the registration token

To send a message to a specific device, you need to know that device's registration token.

By default, the FCM SDK generates a registration token for the client app instance on initial startup of your app. If you want to target single devices, or create device groups for FCM, you'll need to access this token.

Because the token could be rotated after initial startup, you are strongly recommended to retrieve the latest updated registration token unless you have a specific need to directly retrieve the current token.

The registration token may change when:

* The app deletes Instance ID
* The app is restored on a new device
* The user uninstalls/reinstall the app
* The user clears app data.

To retrieve the current token, you will need to call the following property. This property returns null if the token has not yet been generated:

```csharp
var token = InstanceId.SharedInstance.Token;
```

### Monitor token generation

To get the token when it is refreshed, you will need to register to Token Refresh Notification:

```csharp
// Monitor token generation
InstanceId.Notifications.ObserveTokenRefresh ((sender, e) => {
	// Note that this callback will be fired everytime a new token is generated, including the first
	// time. So if you need to retrieve the token as soon as it is available this is where that
	// should be done.
	var refreshedToken = InstanceId.SharedInstance.Token;
	
	// Do your magic to refresh the token where is needed
});
```

### Send a message

1. Install and run the app on the target device. You'll need to accept the request for permission to receive remote notifications.
2. Make sure the app is in the background on the device.
3. Open the **Notifications** tab of the [Firebase console][1] and select **New Message**.
4. Enter the message text.
5. Select **Single Device** for the message target.
6. In the field labeled **FCM Registration Token**, enter the registration token you obtained in a previous section of this guide.

After you click **Send Message**, targeted client devices that have the app in the background receive the notification in the notification center.

### Receive and handle a messages

To handle a message implement the method described in Handling messages and Handling messages with method swizzling disabled sections above.

## Send messages to Topics

Firebase Cloud Messaging (FCM) topic messaging allows you to send a message to multiple devices that have opted in to a particular topic. Based on the publish/subscribe model, topic messaging supports unlimited subscriptions for each app. You compose topic messages as needed, and Firebase handles message routing and delivering the message reliably to the right devices.

### Subscribe the client app to a topic

Client apps can subscribe to any existing topic, or they can create a new topic. When a client app subscribes to a new topic name (one that does not already exist for your Firebase project), a new topic of that name is created in FCM and any client can subsequently subscribe to it.

To subscribe to a topic, use the following line of code (don't forget to import `Firebase.CloudMessaging` namespace):

```csharp
Messaging.SharedInstance.Subscribe ("my/topic");
```

This makes an asynchronous request to the FCM backend and subscribes the client to the given topic. If the subscription request fails initially, FCM retries until it can subscribe to the topic successfully. Each time the app starts, FCM makes sure that all requested topics have been subscribed. To unsubscribe to a topic:

```csharp
Messaging.SharedInstance.Unsubscribe ("my/topic");
```

### Receive and handle topic messages

To handle a topic message implement the method described in Handling messages and Handling messages with method swizzling disabled sections above.

### Send a message

1. Install and run the app on the target device. You'll need to accept the request for permission to receive remote notifications.
2. Make sure the app is in the background on the device.
3. Open the **Notifications** tab of the [Firebase console][1] and select **New Message**.
4. Enter the message text.
5. Select **Topic** for the message target.
6. Choose the desired topic.

After you click **Send Message**, targeted client devices that have the app in the background receive the notification in the notification center.

If you want to build your message and send it through you app, see the following [documentation][7].

## Send messages to Device Groups

With device group messaging, app servers can send a single message to multiple instances of an app running on devices belonging to a group. Typically, "group" refers a set of different devices that belong to a single user. All devices in a group share a common notification key, which is the token that FCM uses to fan out messages to all devices in the group.

Device group messaging makes it possible for every app instance in a group to reflect the latest messaging state. In addition to sending messages downstream to a notification key, you can enable devices to send upstream messages to a device group. You can use device group messaging with either the XMPP or HTTP connection server. The limit on data payload is 2KB when sending to iOS devices, and 4KB for other platforms.

The maximum number of members allowed for a notification_key is 20.

To learn how to achieve a device group, see the following [documentation][8]. After you get the group key, use this method to send messages to your group:

```csharp
var message = NSDictionary.FromObjectAndKey (new NSString ("This is my message body"), new NSString ("message"));
Messaging.SharedInstance.SendMessage (message, groupKey, yourOwnMessageId, timeOfLive);
```

### Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][9])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/cloud-messaging/ios/client) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://firebase.google.com/docs/cloud-messaging/ios/certs
[4]: https://firebase.google.com/docs/cloud-messaging/ios/client#upload_your_apns_certificate
[5]: https://firebase.google.com/docs/cloud-messaging/ios/client#register_for_remote_notifications
[6]: https://firebase.google.com/docs/cloud-messaging/http-server-ref#notification-payload-support
[7]: https://firebase.google.com/docs/cloud-messaging/ios/topic-messaging#build_send_requests
[8]: https://firebase.google.com/docs/cloud-messaging/ios/device-group
[9]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689