Firebase Invites are an out-of-the-box solution for app referrals and sharing via email or SMS.

Word of mouth is one of the most effective ways of getting users to install your app. In a [recent study](https://think.storage.googleapis.com/docs/mobile-app-marketing-insights.pdf) of thousands of smartphone users, researchers found that the #1 reason people discovered an app is because they heard about it from a friend or colleague. Firebase Invites makes it easy to turn your app's users into your app's strongest advocates.

Firebase Invites builds on Firebase Dynamic Links. which ensures that recipients of links have the best possible experience for their platform and the apps they have installed.

## Key capabilities

|  |  |
|-:|--|
| **Rich sharing that's easy for users** | Firebase Invites makes it simple for users to send content to their friends, over both SMS and email, by ensuring that referral codes, recipe entries, or other shared content gets passed along with the invitation—no cutting-and-pasting required. |
| **Rich sharing that's easy to implement** | Firebase Invites handles the invitation flow for you, allowing you to deliver a straightforward user experience without taking engineering time away from the rest of your app. |
| **Invitations that survive the installation process** | Because Firebase Invites is built on Dynamic Links, invitations work across the App Store and Play Store installation processes and ensure that recipients get the referral code or shared content, whether or not they have your app installed. |

### Complete list of features

| Sending invitations |  |
|--------------------:|--|
| **Combines the most common sharing channels** | Firebase Invites can be sent over SMS or email. |
| **Merged contacts selector** | The share screen's contact list is populated from the user's Google Contacts and the contacts stored locally on the device. |
| **Recipient recommendations** | The share screen recommends recipients based on the contacts the user communicates with frequently. |
| **Customizable invitation message** | You can set the default message to be sent with invitations. This message can be edited by the user when sending invitations. |
| **Customizable rich-text email invitations** | You can customize email invitations in either of two ways: <br /> <ul><li>Provide custom images that will be used along with additional text and graphics from the app's entry in the App Store or Play Store.</li> <br /> <li>Provide HTML for a fully customized email invitation.</li></ul> |

| Receiving invitations |  |
|----------------------:|--|
| **Installation flow initiation** | Firebase Invites smartly directs the recipient to the appropriate store when they open the link and need to install the app. iOS users are sent to the App Store, Android users are sent to the Play Store, and web users are sent to the store for the sender's platform. |
| **Installation flow survival** | Invitations use Dynamic Links, which ensure that the link information contained in the invitation doesn't get lost, even if the user has to install the app first. |
| **Low friction for users** | iOS and Android users can receive invitations without signing in to their Google Accounts. |

## How does it work?

![FirebaseInvites_HowItWorks](https://firebase.google.com/docs/invites/images/send-invitations.png)

When a user taps one of your app's Share buttons and chooses the Firebase Invites channel—usually named "Email and SMS"—the Firebase Invites sharing screen opens. From the sharing screen, the user selects recipients from their Google contacts and contacts stored locally on the device, optionally customizes the invitation message and sends the invitations. Invitations are sent by email or SMS, depending on the available contact information, and contain a Dynamic Link to your app.

When the invitation's recipients open the Dynamic Link in the invitation, they are sent to the Play Store or App Store if they need to install your app; then, your app opens and can retrieve and handle the link.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/invites/) to see original Firebase documentation._</sub>