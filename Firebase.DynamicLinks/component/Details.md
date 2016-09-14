Firebase Dynamic Links are smart URLs that dynamically change behavior to provide the best experience across different platforms.

## Key capabilities

* **Dynamic Links are durable and survive app installs:** Delight users by personalizing the first-open experience. Avoid losing conversions when potential users don't already have your app installed.
* **Dynamically control the user experience:** Dynamic Links work seamlessly across iOS, Android, and desktop and mobile web. Dynamic Links can be configured to provide the best possible user experience, whether that's a personalized app launch, a fast interstitial, or opening your mobile website.
* **Know which content and campaigns are working:** Use Dynamic Links in marketing campaigns and for content sharing to know exactly which campaigns and content drive growth.

## How does it work?

You create a Dynamic Link either by using the Firebase console or by forming a URL by adding Dynamic Link parameters to a domain specific to your app. These parameters specify the links you want to open, depending on the user's platform and whether your app is installed.

When a user opens one of your Dynamic Links, if your app isn't yet installed, the user is sent to the Play Store or App Store to install your app (unless you specify otherwise), and your app opens. You can then retrieve the link that was passed to your app and handle the link as appropriate for your app.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/dynamic-links/) to see original Firebase documentation._</sub>