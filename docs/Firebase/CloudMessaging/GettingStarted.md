# Firebase Cloud Messaging on iOS

## Table of content

- [Firebase Cloud Messaging on iOS](#firebase-cloud-messaging-on-ios)
	- [Table of content](#table-of-content)
	- [About Firebase Cloud Messaging](#about-firebase-cloud-messaging)
	- [Method swizzling in Firebase Cloud Messaging](#method-swizzling-in-firebase-cloud-messaging)
- [Setting Up a Firebase Cloud Messaging Client App on iOS](#setting-up-a-firebase-cloud-messaging-client-app-on-ios)
	- [Prerequisites](#prerequisites)
	- [Add Firebase to your app](#add-firebase-to-your-app)
	- [Configure Cloud Messaging in your app](#configure-cloud-messaging-in-your-app)
		- [Register for remote notifications](#register-for-remote-notifications)
	- [Access the registration token](#access-the-registration-token)
		- [Set the Messaging Delegate property](#set-the-messaging-delegate-property)
		- [Receive the current registration token](#receive-the-current-registration-token)
		- [Monitor token generation](#monitor-token-generation)
			- [Swizzling disabled: mapping your APNs token and registration token](#swizzling-disabled--mapping-your-apns-token-and-registration-token)
		- [Import existing user APNs tokens](#import-existing-user-apns-tokens)
	- [Prevent auto initialization](#prevent-auto-initialization)
- [Send your First Message to a Backgrounded App](#send-your-first-message-to-a-backgrounded-app)
	- [Send a notification message](#send-a-notification-message)
- [Send Messages to Multiple Devices](#send-messages-to-multiple-devices)
	- [Subscribe a client app to a topic](#subscribe-a-client-app-to-a-topic)
	- [Receive and handle topic messages](#receive-and-handle-topic-messages)
	- [Build send requests](#build-send-requests)
- [Receive Messages](#receive-messages)
	- [Handle messages received through the FCM APNs interface](#handle-messages-received-through-the-fcm-apns-interface)
		- [Interpreting notification message payload](#interpreting-notification-message-payload)
	- [Handle data messages in foregrounded apps](#handle-data-messages-in-foregrounded-apps)
		- [Handle messages with method swizzling disabled](#handle-messages-with-method-swizzling-disabled)
		- [Interpreting data message payload](#interpreting-data-message-payload)
		- [Handle queued and deleted messages](#handle-queued-and-deleted-messages)
- [Topic Messaging](#topic-messaging)
	- [Subscribe the client app to a topic](#subscribe-the-client-app-to-a-topic)
	- [Manage topic subscriptions on the server](#manage-topic-subscriptions-on-the-server)
	- [Receive and handle topic messages](#receive-and-handle-topic-messages)
	- [Build send requests](#build-send-requests)
- [Device Group Messaging](#device-group-messaging)
	- [Managing device groups](#managing-device-groups)
	- [Sending downstream messages to device groups](#sending-downstream-messages-to-device-groups)
	- [Sending upstream messages to device groups](#sending-upstream-messages-to-device-groups)
- [Sending Upstream Messages](#sending-upstream-messages)
	- [Send an upstream message](#send-an-upstream-message)
		- [Handle upstream message callbacks](#handle-upstream-message-callbacks)
	- [Receive XMPP messages on the app server](#receive-xmpp-messages-on-the-app-server)
- [Send Messages with the Firebase Console](#send-messages-with-the-firebase-console)

## About Firebase Cloud Messaging

Firebase Cloud Messaging offers a broad range of messaging options and capabilities. I invite you to read the following [documentation][1] to have a better understanding about notification messages and data messages and what you can do with them using FCM's options.

## Method swizzling in Firebase Cloud Messaging

One important thing you should know before start using FCM is that FCM API performs method swizzling in two key areas: mapping your APNs token to the FCM registration token and capturing analytics data during downstream message callback handling. Developers who prefer not to use swizzling can disable it by adding the flag `FirebaseAppDelegateProxyEnabled` in the app’s Info.plist file and setting it to `No` (boolean value). If you decided to disable swizzling, the docs provide example for both scenarios, with and without method swizzling enabled.

---

# Setting Up a Firebase Cloud Messaging Client App on iOS

You can implement Firebase Cloud Messaging in two complementary ways:

* Receive basic push messages up to 2KB over the Firebase Cloud Messaging APNs interface.
* Send messages upstream and/or receive downstream payloads up to 4KB.

## Prerequisites

* A physical iOS device
* A project targeting iOS 8 or above
* If you want to enable Notifications specifically, you'll need to create an [Apple Push Notification Authentication Key][2], an **App Id** and a **Provisioning Profile**, then [upload the key to Firebase][3] and finally enable the app for remote notifications.
	* Open Entitlements.plist and check **Enable Push Notifications**

> ![note_icon] _**Support for iOS 7 deprecated:**_ _As of v4.5.0 of the Firebase SDK for iOS, support for iOS 7 is deprecated. Upgrade your apps to target iOS 8 or above. To see the breakdown of worldwide iOS versions, go to [Apple’s App Store support page][4]._

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][5], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][6].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][6] again at any time.

> ![note_icon] **_Note:_** _If you have multiple build variants with different bundle IDs defined, each app must be added to your project in Firebase console._

## Configure Cloud Messaging in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Open `GoogleService-Info.plist` file and change `IS_GCM_ENABLED` value to `Yes`. 
4. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
Firebase.Core.App.Configure();
```

### Register for remote notifications

Either at startup, or at the desired point in your application flow, register your app for remote notifications. Call `RegisterForRemoteNotifications` method as shown:

```csharp
// Register your app for remote notifications.
if (UIDevice.CurrentDevice.CheckSystemVersion (10, 0)) {
	
	// For iOS 10 display notification (sent via APNS)
	UNUserNotificationCenter.Current.Delegate = this;

	var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
	UNUserNotificationCenter.Current.RequestAuthorization (authOptions, (granted, error) => {
		Console.WriteLine (granted);
	});
} else {
	// iOS 9 or before
	var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
	var settings = UIUserNotificationSettings.GetSettingsForTypes (allNotificationTypes, null);
	UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);
}

UIApplication.SharedApplication.RegisterForRemoteNotifications ();
```

> ![advice_icon] For devices running iOS 10 and above, you must assign your delegate object to the `UNUserNotificationCenter` object to receive display notifications, and the `Messaging` object to receive data messages, before your app finishes launching. For example, in an iOS app, you must assign it in the `WillFinishLaunching` or `FinishedLaunching` method.

## Access the registration token

By default, the FCM SDK generates a registration token for the client app instance on initial startup of your app. Similar to the APNs device token, this token allows you to target notification messages to this particular instance of the app.

In the same way that iOS typically delivers an APNs device token on app start, FCM provides a registration token via the `DidReceiveRegistrationToken` method of the `Messaging` delegate on each app startup. During the first app start, and in all situations where the registration token is changed, the FCM SDK retrieves the token. In both cases, the FCM SDK calls `DidReceiveRegistrationToken` found in the `IMessageDelegate` interface.

The registration token may change when:

* The app is restored on a new device
* The user uninstalls/reinstall the app
* The user clears app data.

### Set the Messaging Delegate property

To receive registration tokens on app start, implement the `IMessagingDelegate` interface in a class and provide it to `Messaging`’s `Delegate` property after calling `App.Configure ()` method. For example, if your application delegate conforms to the `IMessagingDelegate` interface, you can set the delegate on `FinishedLaunching` to itself:

```csharp
Messaging.SharedInstance.Delegate = this;
```

### Receive the current registration token

Registration tokens are delivered via the `IMessagingDelegate` method `DidReceiveRegistrationToken`. This method is called generally once per app start with an FCM token. When this method is called, it is the ideal time to:

* If the registration token is new, send it to your application server (it's recommended to implement server logic to determine whether the token is new).
* Subscribe the registration token to topics. This is required only for new subscriptions or for situations where the user has re-installed the app.

```csharp
var token = Messaging.SharedInstance.FcmToken ?? "";
Console.WriteLine ($"FCM token: {token}");
```

After this delegate method is called, the registration token is available via the `FcmToken` property of `Messaging` class. Prior to this delegate method call, the property may be `null`.

### Monitor token generation

To be notified whenever the token is updated, supply a class conforming to the `IMessagingDelegate` interface and set it to `Messaging` `Delegate` property. The following example registers the delegate and adds the proper interface method:

```csharp
[Export ("messaging:didReceiveRegistrationToken:")]
public void DidReceiveRegistrationToken (Messaging messaging, string fcmToken)
{
	Console.WriteLine ($"Firebase registration token: {fcmToken}");

	// TODO: If necessary send token to application server.
	// Note: This callback is fired at each app startup and whenever a new token is generated.
}
```

Alternatively, you can listen for an `NSNotification` named `RegistrationTokenRefreshedNotification` rather than supplying a interface method. The `Messaging.SharedInstance.FcmToken` property always has the current token value.

#### Swizzling disabled: mapping your APNs token and registration token

If you have disabled method swizzling, you'll need to explicitly map your APNs token to the FCM registration token. Override the `AppDelegate`'s method `RegisteredForRemoteNotifications` to retrieve the APNs token, and then use the `ApnsToken` property.

Provide your APNs token using the `ApnsToken` property:

```csharp
public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
{
	Messaging.SharedInstance.ApnsToken = deviceToken;
}
```

After the FCM registration token is generated, you can access it and listen for refresh events using the same methods as with swizzling enabled.

### Import existing user APNs tokens

If you have an existing user base that you want to onboard to an FCM client app, use the [batchImport][7] API provided by Instance ID. With this API, you can bulk import existing iOS APNs tokens into FCM, mapping them to new, valid registration tokens.

## Prevent auto initialization

FCM generates an Instance ID, which is used as a registration token within FCM. When an Instance ID is generated the library will upload the identifier and configuration data to Firebase. If you want to get an explicit opt-in before using Instance ID, you can prevent generation at configure time by disabling FCM. To do this, add a metadata value to your `Info.plist` (not your `GoogleService-Info.plist`):

`FirebaseMessagingAutoInitEnabled = NO`

To re-enable FCM, you can make a runtime call:

```csharp
Messaging.SharedInstance.AutoInitEnabled = true;
```

This value persists across app restarts once set.

---

# Send your First Message to a Backgrounded App

To get started with FCM, build out the simplest use case: sending a notification message from the [Notifications composer][8] to a specific user's device when the app is in the background on the device.

## Send a notification message

1. Install and run the app on the target device. You'll need to accept the request for permission to receive remote notifications.
2. Make sure the app is in the background on the device.
3. Open the [Notifications composer][8] and select **New Message**.
4. Enter the message text.
5. Select **Single Device** for the message target.
6. In the field labeled FCM Registration Token, enter the registration token you obtained in a previous section of this guide.

After you click **Send Message**, targeted client devices that have the app in the background receive the notification in the notification center.

---

# Send Messages to Multiple Devices

Firebase Cloud Messaging provides two ways to target a message to multiple devices:

* [Topic messaging](#topic-messaging), which allows you to send a message to multiple devices that have opted in to a particular topic.
* [Device group messaging](#device-group-messaging), which allows you to send a single message to multiple instances of an app running on devices belonging to a group.

This part focuses on sending topic messages from your app server using the HTTP or XMPP protocols for FCM, and receiving and handling them in an iOS app.

## Subscribe a client app to a topic

Client apps can subscribe to any existing topic, or they can create a new topic. To learn more about this, go to [Topic Messaging](#subscribe-the-client–app-to-a-topic) section below.

## Receive and handle topic messages

FCM delivers topic messages in the same way as other downstream messages. To learn how to receive and handle messages, go to [Receive Messages](#receive-messages) section below.

## Build send requests

Sending messages to a Firebase Cloud Messaging topic is very similar to sending messages to an individual device or to a user group. To learn more about this, please, read the following [documentation][9].

---

# Receive Messages

Once your client app is installed on a device, it can receive messages through the FCM APNs interface. You can immediately start sending notifications to user segments with the Notifications composer, or your application server can send messages with a notification payload through the APNs interface.

Handling messages received through the FCM APNs interface is likely to cover most typical use cases. You can also [send upstream messages](#sending-upstream-messages), or [receive data messages in foregrounded apps](#handle-data-messages-in-foregrounded-apps).

## Handle messages received through the FCM APNs interface

When your app is in the background, iOS directs messages with the `notification` key to the system tray. A tap on a notification opens the app, and the content of the notification is passed to the `DidReceiveRemoteNotification` method in the `AppDelegate`.

Implement AppDelegate `DidReceiveRemoteNotification` as shown:

```csharp
public override void ReceivedRemoteNotification (UIApplication application, NSDictionary userInfo)
{
	// If you are receiving a notification message while your app is in the background,
	// this callback will not be fired till the user taps on the notification launching the application.
	// TODO: Handle data of notification

	// With swizzling disabled you must let Messaging know about the message, for Analytics
	//Messaging.SharedInstance.AppDidReceiveMessage (userInfo);

	// Print full message.
	Console.WriteLine (userInfo);
}

public override void DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
{
	// If you are receiving a notification message while your app is in the background,
	// this callback will not be fired till the user taps on the notification launching the application.
	// TODO: Handle data of notification

	// With swizzling disabled you must let Messaging know about the message, for Analytics
	//Messaging.SharedInstance.AppDidReceiveMessage (userInfo);

	// Print full message.
	Console.WriteLine (userInfo);

	completionHandler (UIBackgroundFetchResult.NewData);
}
```

If you want to open your app and perform a specific action, set `click_action` in the [notification payload][10]. Use the value that you would use for the `category` key in the APNs payload.

When overriding `DidReceiveRemoteNotification` method, you need to add "**remote-notification**" to the list of your **Required background modes** in your Info.plist

### Interpreting notification message payload

The payload of notification messages is a dictionary of keys and values. Notification messages sent through APNs follow the APNs payload format as below:

```json
{
  "aps" : {
    "alert" : {
      "body" : "great match!",
      "title" : "Portugal vs. Denmark",
    },
    "badge" : 1,
  },
  "customKey" : "customValue"
}
```

## Handle data messages in foregrounded apps

To receive data-only messages directly from FCM (as opposed to via APNs) when the app is in the foreground, you'll need to connect to the FCM service and handle messages with `IMessagingDelegate` `DidReceiveMessage` interface method.

To connect, set the `ShouldEstablishDirectChannel` property to `true` in the `AppDelegate`. FCM manages the connection, closing it when your app goes into the background and reopening it whenever the app is foregrounded.

To receive data messages when your app is in the foreground, implement `DidReceiveMessage`. Your app can still receive data messages when it is in the background without this callback, but for foreground cases you'll need to handle it.

### Handle messages with method swizzling disabled

If you disable method swizzling, you'll need to call method `Messaging` `AppDidReceiveMessage` method. This lets FCM track message delivery and analytics, which is performed automatically with method swizzling enabled:

```csharp
// With "FirebaseAppDelegateProxyEnabled": NO
public override void DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
{
	// Let FCM know about the message for analytics etc.
	Messaging.SharedInstance.AppDidReceiveMessage (userInfo);

	// Do your magic to handle the notification data
}
```

Since iOS 10, you can set `UNUserNotificationCenter` `Delegate` to receive display notifications from Apple and `Messaging`s `Delegate` to receive data messages from FCM. If you do not set these two delegates with `AppDelegate`, method swizzling for message handling is disabled. You'll need to call method `AppDidReceiveMessage` to track message delivery and analytics.

```csharp
// Receive displayed notifications for iOS 10 devices.
// Handle incoming notification messages while app is in the foreground.
[Export ("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
public void WillPresentNotification (UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
{
	var userInfo = notification.Request.Content.UserInfo;

	// With swizzling disabled you must let Messaging know about the message, for Analytics
	//Messaging.SharedInstance.AppDidReceiveMessage (userInfo);

	// Print full message.
	Console.WriteLine (userInfo);

	// Change this to your preferred presentation option
	completionHandler (UNNotificationPresentationOptions.None);
}

// Handle notification messages after display notification is tapped by the user.
[Export ("userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
public void DidReceiveNotificationResponse (UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
{
	var userInfo = response.Notification.Request.Content.UserInfo;

	// Print full message.
	Console.WriteLine (userInfo);

	completionHandler ();
}
```

### Interpreting data message payload

The payload of data messages is a dictionary of keys and values. Data messages sent to the devices directly by FCM server are expressed in the format of a dictionary as below:

```json
{
  "body" : "great match!",
  "title" : "Portugal vs. Denmark",
  "icon" : "myicon"
}
```

### Handle queued and deleted messages

Apps that connect to FCM to receive data messages should handle `Messaging.MessagesDeletedNotification` with `NSNotificationCenter` or with `Messaging.Notifications.ObserveMessagesDeleted`. You may receive this callback when there are too many messages (>100) pending for your app on a particular device at the time it connects, or if the device hasn't connected to FCM for more than one month. When the app instance receives this callback, it should perform a full sync with your app server.

---

# Topic Messaging

Based on the publish/subscribe model, FCM topic messaging allows you to send a message to multiple devices that have opted in to a particular topic. You compose topic messages as needed, and FCM handles routing and delivering the message reliably to the right devices.

For example, users of a local weather forecasting app could opt in to a "severe weather alerts" topic and receive notifications of storms threatening specified areas. Users of a sports app could subscribe to automatic updates in live game scores for their favorite teams.

Some things to keep in mind about topics:

* Topic messaging supports unlimited topics and subscriptions for each app.
* Topic messaging is best suited for content such as news, weather, or other publicly available information.
* Topic messages are optimized for throughput rather than latency. For fast, secure delivery to single devices or small groups of devices, [target messages to registration tokens][11], not topics.
* If you need to send messages to multiple devices per user, consider [device group messaging][12] for those use cases.

## Subscribe the client app to a topic

Client apps can subscribe to any existing topic, or they can create a new topic. When a client app subscribes to a new topic name (one that does not already exist for your Firebase project), a new topic of that name is created in FCM and any client can subsequently subscribe to it.

The `Messaging` class handles topic messaging functionality. To subscribe to a topic, call `Subscribe` method from your application's main thread (FCM is not thread-safe):

```csharp
Messaging.SharedInstance.Subscribe ("topic", (error) => {
	// ...
});
Console.WriteLine ("Subscribed to topic");

// async/away Version

try {
	await Messaging.SharedInstance.SubscribeAsync ("topic");
	Console.WriteLine ("Subscribed to topic");
} catch (NSErrorException ex) {
	// ...
}
```

This makes an asynchronous request to the FCM backend and subscribes the client to the given topic. Before calling `Subscribe` method, make sure that the client app instance has already received a registration token via the callback `IMessagingDelegate` `DidReceiveRegistrationToken` method.

If the subscription request fails initially, FCM retries until it can subscribe to the topic successfully. Each time the app starts, FCM makes sure that all requested topics have been subscribed.

To unsubscribe, call `Unsubscribe` method, and FCM unsubscribes from the topic in the background.

```csharp
Messaging.SharedInstance.Unsubscribe ("topic", (error) => {
	// ...
});
Console.WriteLine ("Unsubscribed to topic");

// async/away Version

try {
	await Messaging.SharedInstance.UnsubscribeAsync ("topic");
	Console.WriteLine ("Unsubscribed to topic");
} catch (NSErrorException ex) {
	// ...
}
```

## Manage topic subscriptions on the server

You can take advantage of [Instance ID APIs][13] to perform basic topic management tasks from the server side. Given the registration token(s) of client app instances, you can do the following:

* Find out details about a client app instance's subscriptions, including each topic name and subscribe date. See [Get information about app instances][14].
* Subscribe or unsubscribe an app instance to a topic. See [Create a relationship mapping for an app instance][15].
* Subscribe or unsubscribe multiple app instances to a topic. See [Manage relationship maps for multiple app instances][16].

## Receive and handle topic messages

FCM delivers topic messages in the same way as other downstream messages. To learn how to receive and handle messages, go to [Receive Messages](#receive-messages) section above.

## Build send requests

Sending messages to a Firebase Cloud Messaging topic is very similar to sending messages to an individual device or to a user group. To learn more about this, please, read the following [documentation][9].

---

# Device Group Messaging

With device group messaging, you can send a single message to multiple instances of an app running on devices belonging to a group. Typically, "group" refers a set of different devices that belong to a single user. All devices in a group share a common notification key, which is the token that FCM uses to fan out messages to all devices in the group.

You can use device group messaging with the [Admin SDKs][17], or by implementing the [XMPP][18] or [HTTP][19] protocols on your app server. The maximum number of members allowed for a notification key is 20.

## Managing device groups

To learn about this, please, read the following [documentation][20].

## Sending downstream messages to device groups

To learn about this, please, read the following [documentation][21].

## Sending upstream messages to device groups

To send upstream messages to device groups on iOS, the iOS client app needs to call `Messaging.SendMessage` method.

---

# Sending Upstream Messages

If your app server implements the [XMPP Connection Server][18] protocol, it can receive upstream messages from a user's device to the cloud. To initiate an upstream message, the client app sends a request containing the following:

* The address of the receiving app server in the format **SENDER_ID@gcm.googleapis.com**.
* A message ID that should be unique for each [sender ID][22].
* The message data comprising the key-value pairs of the message's payload.

When it receives this data, FCM builds an XMPP stanza to send to the app server, adding some additional information about the sending device and app.

## Send an upstream message

To send messages upstream to the server, an iOS client app composes a message, connects to FCM, and calls `SendMessage` method.

To connect, set the `ShouldEstablishDirectChannel` property to `true` in the `AppDelegate`. FCM manages the connection, closing it when your app goes into the background and reopening it whenever the app is foregrounded.

Configure the call to SendMessage method as shown:

```csharp
Messaging.SharedInstance.SendMessage (message, to, messageId, ttl);
```

where:

* `message` is a `Dictionary<object, object>` or `NSDictionary` of keys and values as strings. Any key-value pair that is not a string is ignored.
* `to` is the address of the receiving app server in the format **SENDER_ID@gcm.googleapis.com**.
* `messageId` is a unique message identifier. All the message receiver callbacks are identified on the basis of this message ID.
* `ttl` is the time to live. If FCM can't deliver the message before this expiration is reached, it sends a notification back to the client.

The FCM client library caches the message on the client app and sends it when the client has an active server connection. On receiving the message, the FCM connection server sends it to the app server.

### Handle upstream message callbacks

Handle upstream callbacks by adding observers that listen for `SendErrorNotification` and `SendSuccessNotification`, and then retrieve error information from the methods. In this example, `HandleSendMessageError` is the method used to handle the callback:

```csharp
var sendSuccessToken = Messaging.Notifications.ObserveSendSuccess (HandleSendMessageSuccess);
var sendErrorToken = Messaging.Notifications.ObserveSendError (HandleSendMessageError);

void HandleSendMessageSuccess(object sender, NSNotificationEventArgs e)
{
	var messageId = e.Notification.Object.ToString ();
}

void HandleSendMessageError (object sender, NSNotificationEventArgs e)
{
	var messageId = e.Notification.Object.ToString ();
	var userInfo = e.Notification.UserInfo; // contains error info etc
}

// Call this lines to stop receiving notifications
sendSuccessToken.Dispose ();
sendErrorToken.Dispose ();

// Or

var sendSuccessToken = NSNotificationCenter.DefaultCenter.AddObserver (Messaging.SendSuccessNotification, HandleSendMessageSuccess);
var sendErrorToken = NSNotificationCenter.DefaultCenter.AddObserver (Messaging.SendSuccessNotification, HandleSendMessageError);

void HandleSendMessageSuccess (NSNotification notification)
{
	var messageId = notification.Object.ToString ();
}

void HandleSendMessageError (NSNotification notification)
{
	var messageId = notification.Object.ToString ();
	var userInfo = notification.UserInfo; // contains error info etc
}

// Call this lines to stop receiving notifications
NSNotificationCenter.DefaultCenter.RemoveObserver (sendSuccessToken);
NSNotificationCenter.DefaultCenter.RemoveObserver (sendErrorToken);
```

To optimize network usage, FCM batches responses to `HandleSendMessageError` and `HandleSendMessageSuccess`, so the acknowledgement may not be immediate for each message.

## Receive XMPP messages on the app server

To learn about this, please, read the following [documentation][23].

---

# Send Messages with the Firebase Console

You can send notification messages to iOS and Android devices using the Notifications composer in the Firebase console. To learn more about this, please, read the following [documentation][24].

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/cloud-messaging/ios/client) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/docs/cloud-messaging/concept-options
[2]: https://firebase.google.com/docs/cloud-messaging/ios/certs
[3]: https://firebase.google.com/docs/cloud-messaging/ios/client#upload_your_apns_authentication_key
[4]: https://developer.apple.com/support/app-store/
[5]: https://firebase.google.com/console/
[6]: http://support.google.com/firebase/answer/7015592
[7]: https://developers.google.com/instance-id/reference/server#create_registration_tokens_for_apns_tokens
[8]: https://console.firebase.google.com/project/_/notification
[9]: https://firebase.google.com/docs/cloud-messaging/send-message#send_messages_to_topics_1
[10]: https://firebase.google.com/docs/cloud-messaging/http-server-ref#notification-payload-support
[11]: https://firebase.google.com/docs/cloud-messaging/send-message#send_messages_to_specific_devices
[12]: https://firebase.google.com/docs/cloud-messaging/send-message#send_messages_to_device_groups
[13]: https://developers.google.com/instance-id/
[14]: https://developers.google.com/instance-id/reference/server#get_information_about_app_instances
[15]: https://developers.google.com/instance-id/reference/server#create_a_relation_mapping_for_an_app_instance
[16]: https://developers.google.com/instance-id/reference/server#manage_relationship_maps_for_multiple_app_instances
[17]: https://firebase.google.com/docs/cloud-messaging/admin/
[18]: https://firebase.google.com/docs/cloud-messaging/server#implementing-the-xmpp-server-protocol
[19]: https://firebase.google.com/docs/cloud-messaging/server#implementing-the-http-server-protocol
[20]: https://firebase.google.com/docs/cloud-messaging/ios/device-group#managing_device_groups
[21]: https://firebase.google.com/docs/cloud-messaging/ios/device-group#sending_downstream_messages_to_device_groups
[22]: https://firebase.google.com/docs/cloud-messaging/concept-options#senderid
[23]: https://firebase.google.com/docs/cloud-messaging/ios/upstream#receive_xmpp_messages_on_the_app_server
[24]: https://firebase.google.com/docs/cloud-messaging/send-with-console
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[advice_icon]: https://cdn1.iconfinder.com/data/icons/nuove/22x22/actions/messagebox_warning.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
