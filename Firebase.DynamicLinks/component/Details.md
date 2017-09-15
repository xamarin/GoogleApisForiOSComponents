Firebase Dynamic Links are links that work the way you want, on multiple platforms, and whether or not your app is already installed.

With Dynamic Links, your users get the best available experience for the platform they open your link on. If a user opens a Dynamic Link on iOS or Android, they can be taken directly to the linked content in your native app. If a user opens the same Dynamic Link in a desktop browser, they can be taken to the equivalent content on your website.

In addition, Dynamic Links work across app installs: if a user opens a Dynamic Link on iOS or Android and doesn't have your app installed, the user can be prompted to install it; then, after installation, your app starts and can access the link.

## How does it work?

You create a Dynamic Link either by using the Firebase console or by forming a URL by adding Dynamic Link parameters to a domain specific to your app. These parameters specify the links you want to open, depending on the user's platform and whether your app is installed.

When a user opens one of your Dynamic Links, if your app isn't yet installed, the user is sent to the Play Store or App Store to install your app (unless you specify otherwise), and your app opens. You can then retrieve the link that was passed to your app and handle the link as appropriate for your app.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/dynamic-links/) to see original Firebase documentation._</sub>