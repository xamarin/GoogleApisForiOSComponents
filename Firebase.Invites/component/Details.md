Firebase Invites is a cross-platform solution for sending personalized email and SMS invitations, on-boarding users, and measuring the impact of invitations.

Firebase Invites builds on Firebase Dynamic Links. While Dynamic Links ensure that recipients of links have the best possible experience for their platform and the apps they have installed, Firebase Invites ensures the best possible experience for sending links.

## Key capabilities

* **Rich sharing that's easy for users:** Firebase Invites makes it simple for users to send content to their friends, over both SMS and email, by ensuring that referral codes, recipe entries, or other shared content gets passed along with the invitation—no cutting-and-pasting required.
* **Rich sharing that's easy to implement:** Firebase Invites handles the invitation flow for you, allowing you to deliver a straightforward user experience without taking engineering time away from the rest of your app.
* **Invitations that survive the installation process:** Because Firebase Invites is built on Dynamic Links, invitations work across the App Store and Play Store installation processes and ensure that recipients get the referral code or shared content, whether or not they have your app installed.

## How does it work?

![FirebaseInvites_HowItWorks](https://firebase.google.com/docs/invites/images/send-invitations.png)

When a user taps one of your app's Share buttons and chooses the Firebase Invites channel—usually named "Email and SMS"—the Firebase Invites sharing screen opens. From the sharing screen, the user selects recipients from their Google contacts and contacts stored locally on the device, optionally customizes the invitation message and sends the invitations. Invitations are sent by email or SMS, depending on the available contact information, and contain a Dynamic Link to your app.

When the invitation's recipients open the Dynamic Link in the invitation, they are sent to the Play Store or App Store if they need to install your app; then, your app opens and can retrieve and handle the link.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/invites/) to see original Firebase documentation._</sub>