# Use Firebase Remote Config on iOS

You can use Firebase Remote Config to define parameters in your app and update their values in the cloud, allowing you to modify the appearance and behavior of your app without distributing an app update.

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure Remote Config in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Analytics` namespace):

```csharp
App.Configure ();
```

## Add Settings to Remote Config class

Create settings for `RemoteConfig` class, you can enable developer mode to allow for frequent refreshes of the cache (don't forget to import `Firebase.RemoteConfig` namespace):

```csharp
// Enabling developer mode, allows for frequent refreshes of the cache
RemoteConfig.SharedInstance.ConfigSettings = new RemoteConfigSettings (true);
```

## Set in-app default parameter values

You can set in-app default parameter values in the Remote Config object, so that your app behaves as intended before it connects to the Remote Config Server, and so that default values are available if none are set on the server. You can achieve this with a **.plist** file or with an **NSDictionary** variable.

### Set in-app default parameter values with .plist file

In your Xamarin Studio app project do the following steps to add default parameters with .plist file:

1. In your project app name do Right click/Add/New File...
2. In **New File** dialog, select iOS tab and choose Property List
3. Name the Property List as you want and click **New**
4. Change the **Build ACtion** of your just created file to **BundleResource** by Right clicking it/Build Action
5. Open your **.plist** file and add all the parameters that you want.

After you have setup all your default parameters, set the **.plist** to the `RemoteConfig` class:

```csharp
RemoteConfig.SharedInstance.SetDefaults ("<Your plist name here>");
```

### Set in-app default parameter values with a NSDictionary

Instead of using a **.plist file** to load default parameter values to your app, you can create a `NSDictionary` to load them:

```csharp
object [] values = { 5, 20 };
object [] keys = { "times_table", "from_zero_to" };
var defaultValues = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);
RemoteConfig.SharedInstance.SetDefaults (defaultValues);
```

## Set parameter values in Firebase Console

1. In the [Firebase console][1], open your project.
2. Select **Remote Config** from the menu to view the Remote Config dashboard.
3. Define parameters with the same names as the parameters that you defined in your **.plist** file or in your **NSDictionary**. For each parameter, you can set a default value (which will eventually override the in-app default value) and you can also set conditional values. To learn more, see [Remote Config Parameters and Conditions][3].

## Fetch and activate values from the server

After you have setup your parameter values in your app and in your server, you are ready to fetch those values in your app from the server so you can override your local values. Call `RemoteConfig.Fetch` instance method to retrieve values from server and call `RemoteConfig.ActivateFetched` instance method to make fetched parameter values available to your app:

```csharp
// CacheExpirationSeconds is set to CacheExpiration here, indicating that any previously
// fetched and cached config would be considered expired because it would have been fetched
// more than CacheExpiration seconds ago. Thus the next fetch would go to the server unless
// throttling is in progress. The default expiration duration is 43200 (12 hours).
RemoteConfig.SharedInstance.Fetch (10, (status, error) => {
	switch (status) {
	case RemoteConfigFetchStatus.Success:
		Console.WriteLine ("Config Fetched!");
		
		// Call this method to make fetched parameter values available to your app
		RemoteConfig.SharedInstance.ActivateFetched ();
		
		// Update your UI from here
		...
		break;

	case RemoteConfigFetchStatus.Throttled:
	case RemoteConfigFetchStatus.NoFetchYet:
	case RemoteConfigFetchStatus.Failure:
		Console.WriteLine ("Config not fetched...");
		break;
	}
});
```

## Use parameter values

The way you can use parameter values in your app is by calling `RemoteConfig.GetConfigValue` instance method or using `RemoteConfig` indexer method:

```csharp
var myValue = RemoteConfig.SharedInstance ["myKey"].NumberValue;
var myOtherValue = RemoteConfig.SharedInstance.GetConfigValue ("myOtherKey").StringValue;
```

## Caching and throttling

Remote Config caches values locally after the first successful request. By default the cache expires after 12 hours, but you can change the cache expiration for a specific request by passing the desired cache expiration, in seconds, to `Fetch` method. If the values in the cache are older than the desired cache expiration, Remote Config will request fresh config values from the server. If your app requests fresh values using `Fetch` several times, requests are throttled and your app is provided with a cached value.

During app development, you might want to refresh the cache very frequently (many times per hour) to let you rapidly iterate as you develop and test your app. To accommodate rapid iteration on a project with up to 10 developers, you can temporarily add a `RemoteConfigSettings` property with `IsDeveloperModeEnabled` set to true to your app, changing the caching settings of the `RemoteConfig` object.

### Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][4])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/remote-config/use-config-ios) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://firebase.google.com/docs/remote-config/parameters
[4]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
