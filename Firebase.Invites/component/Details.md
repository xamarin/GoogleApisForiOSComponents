
App Invites provide a powerful way to organically grow your app, user-to-user. Your users recommend your app to their friends using personalized, contextual invitations powered by Google. App Invites provide a great onboarding experience to your new users. Google optimizes your app install rates by reducing friction and using relevant context at every step of the user invitation flow.

### App Invites flow

App Invites always begins with a user sending an invite from your app. The following diagram illustrates the App Invites flow.

![AppInviteFlow](https://developers.google.com/app-invites/images/ai-ios-flow.svg)

### Sending an invitation


You allow a user to send an invitation from your application by using the `IInviteBuilder` interface in your app’s ViewController file. The invite must include a title and can also include a message and deep link data.

The Open method of `IInviteBuilder` opens the contact chooser dialog where the user selects the contacts to invite. The invite can be sent via email or SMS.

### Receiving an invitation

When a user receives and choose to open an invitation URL, the invitation flow branches according to whether or not your app is already installed on the recipient’s device. If the recipient doesn’t have your app, the flow branches to let the user install it. If the recipient is already one of your users, then the optional deep link information in the invite passes to your app for processing.

**App is already installed**

If the recipient has already installed your app, the app will receive the invite URL containing the optional deep link data.

**App is not installed**

If the recipient has not yet installed the app, they can choose to install the app from the iTunes App Store. When the app is opened for the first time, the App Invites SDK will supply a deep link if one is available.
