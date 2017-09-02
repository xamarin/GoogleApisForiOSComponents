Change the behavior and appearance of your app without publishing an app update.

Firebase Remote Config is a cloud service that lets you change the behavior and appearance of your app without requiring users to download an app update. When using Remote Config, you create in-app default values that control the behavior and appearance of your app. Then, you can later use the Firebase console to override in-app default values for all app users or for segments of your userbase. Your app controls when updates are applied, and it can frequently check for updates and apply them with a negligible impact on performance.

## Key capabilities

|  |  |
|-:|--|
| **Quickly roll out changes to your app's userbase** | You can make changes to your app's default behavior and appearance by changing server-side parameter values. For example, you could change your app's layout or color theme to support a seasonal promotion, with no need to publish an app update. |
| **Customize your app for segments of your userbase** | You can use Remote Config to provide variations on your app's user experience to different segments of your userbase by app version, by Firebase Analytics audience, by language, and more. |
| **Run A/B tests to improve your app** | You can use Remote Config random percentile targeting with Firebase Analytics to A/B test improvements to your app across different segments of your userbase so that you can validate improvements before rolling them out to your entire userbase. |

## How does it work?

Remote Config includes a client library that handles important tasks like fetching parameter values and caching them, while still giving you control over when new values are activated so that they affect your app's user experience. This lets you safeguard your app experience by controlling the timing of any changes.

The Remote Config client library get methods provide a single access point for parameter values. Your app gets server-side values using the same logic it uses to get in-app default values, so you can add the capabilities of Remote Config to your app without writing a lot of code.

To override in-app default values, you use the Firebase console to create parameters with the same names as the parameters used in your app. For each parameter, you can set a server-side default value to override the in-app default value, and you can also create conditional values to override the in-app default value for app instances that meet certain conditions.

## Policies and limits

Note the following policies:

* Don't use Remote Config to make app updates that should require a user's authorization. This could cause your app to be perceived as untrustworthy.
* Don't store confidential data in Remote Config parameter keys or parameter values. It is possible to decode any parameter keys or values stored in the Remote Config settings for your project.
* Don't attempt to circumvent the requirements of your app's target platform using Remote Config.

Remote Config parameters and conditions are subject to certain limits. To learn more, see [Limits on parameters and conditions](https://firebase.google.com/docs/remote-config/parameters#limits_on_parameters_and_conditions).

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/remote-config/) to see original Firebase documentation._</sub>