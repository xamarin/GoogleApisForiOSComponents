Using Firebase Cloud Messaging, you can notify a client app that new email or other data is available to sync. You can send notification messages to drive user reengagement and retention. For use cases such as instant messaging, a message can transfer a payload of up to 4KB to a client app.

## Key capabilities

* **Send notification messages or data messages:** Send notification messages that are displayed to your user. Or send data messages and determine completely what happens in your application code. See Message types.
* **Versatile message targeting:** Distribute messages to your client app in any of three ways — to single devices, to groups of devices, or to devices subscribed to topics.
* **Send messages from client apps:** Send acknowledgments, chats, and other messages from devices back to your server over FCM’s reliable and battery-efficient connection channel.

## How does it work?

![FirebaseCloudMessaging_HowItWorks](https://firebase.google.com/docs/cloud-messaging/images/messaging-overview.png)

A Firebase Cloud Messaging implementation includes an app server that interacts with FCM via HTTP or XMPP protocol, and a client app.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/cloud-messaging/) to see original Firebase documentation._</sub>