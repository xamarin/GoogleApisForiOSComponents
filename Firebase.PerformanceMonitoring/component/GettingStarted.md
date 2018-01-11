# Firebase Performance Monitoring for iOS

## Table of content

- [Prerequisites](#prerequisites)
- [Add Firebase to your app](#add-firebase-to-your-app)
- [Configure Performance Monitoring in your app](#configure-performance-monitoring-in-your-app)
	- [(Optional) Define a custom trace and one or more counters in your app](#optional-define-a-custom-trace-and-one-or-more-counters-in-your-app)
	- [Check the Firebase console for Performance Monitoring results](#check-the-firebase-console-for-performance-monitoring-results)
	- [Deploy your app and review results in the Firebase console](#deploy-your-app-and-review-results-in-the-firebase-console)
- [Automatic Traces](#automatic-traces)
	- [Automatic trace definitions](#automatic-trace-definitions)
- [Disable the Firebase Performance Monitoring SDK](#disable-the-firebase-performance-monitoring-sdk)
	- [Disable Performance Monitoring during your app build process](#disable-performance-monitoring-during-your-app-build-process)
	- [Disable your app at runtime using Remote Config](#disable-your-app-at-runtime-using-remote-config)
- [Known issues](#known-issues)

## Prerequisites

Firebase Performance Monitoring requires iOS 8 or newer.

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure Performance Monitoring in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
App.Configure ();
```

Compile your app. Automatic traces and HTTP/S network requests are now monitored.

### (Optional) Define a custom trace and one or more counters in your app

A custom trace is a report of performance data associated with some of the code in your app. You can have multiple custom traces in your app, and it is possible to have more than one custom trace running at a time. Each custom trace can have one or more counters to count performance-related events in your app, and those counters are associated with the traces that create them.

1. Add the Firebase Performance Monitoring namespace to your namespaces:

	```csharp
	using Firebase.PerformanceMonitoring;
	```

2. Just before the code where you want to start a trace in your app, add the following lines of code to start a trace called **test trace**:

	```csharp
	var trace = Performance.StartTrace ("test trace");
	```

3. To count performance-related events that occur in your app (such as cache hits or retries), add a line of code similar to the following each time that the event occurs, using a string other than retry to name that event if you are counting a different type of event:

	```csharp
	trace.IncrementCounter ("retry");
	```

4. Just after the code where you want to stop your trace, add the following line of code:

	```csharp
	trace.Stop ();
	```

### Check the Firebase console for Performance Monitoring results

1. Run your app in the simulator or device.
2. Confirm that Performance Monitoring results appear in the Firebase console. Results should appear within 12 hours.

### Deploy your app and review results in the Firebase console

After you have validated Performance Monitoring using simulators and one or more test devices, you can deploy the updated version of your app to your users and use the Firebase console to monitor performance data.

### (Optional) Add monitoring for specific network requests

Performance Monitoring collects network requests automatically. Although this includes most network requests for your app, some might not be reported. To include specific network requests in Performance Monitoring, add the following code to your app:

```csharp
var metric = new HttpMetric ("https://www.google.com", HttpMethod.Get);
metric.Start ();

var url = new NSUrl ("https://www.google.com");
var request = new NSUrlRequest (url);
var session = NSUrlSession.FromConfiguration (NSUrlSessionConfiguration.DefaultSessionConfiguration);

var dataTask = session.CreateDataTask (request, HandleNSUrlSessionResponse);
dataTask.Resume ();

void HandleNSUrlSessionResponse (NSData data, NSUrlResponse response, NSError error)
{
	if (response is NSHttpUrlResponse httpResponse)
		metric.ResponseCode = httpResponse.StatusCode;

	metric.Stop ();
}

// async/await way:

var metric = new HttpMetric ("https://www.google.com", HttpMethod.Get);
metric.Start ();

var url = new NSUrl ("https://www.google.com");
var request = new NSUrlRequest (url);
var session = NSUrlSession.FromConfiguration (NSUrlSessionConfiguration.DefaultSessionConfiguration);

try {
	var dataTaskResult = await session.CreateDataTaskAsync (request);

	if (dataTaskResult.Response is NSHttpUrlResponse httpResponse)
		metric.ResponseCode = httpResponse.StatusCode;

	metric.Stop ();
} catch (NSErrorException ex) {
	// Handle error
}
```

The HTTP/s network requests you specifically capture this way appear in the Firebase console along with the network requests Performance Monitoring captures automatically.

## Automatic Traces

A trace is a report of performance data captured between two points in time in your app. When installed, the Performance Monitoring SDK automatically provides the following types of traces:

* _App start_ traces, which measure the time between when the user opens the app and when the app is responsive.
* _App in background_ traces, which measure the time when the app is running in the background.
* _App in foreground_ traces, which measure the time when the app is running in the foreground and available to the user.

### Automatic trace definitions

Performance Monitoring uses method calls and notifications in your app to determine when each type of automatic trace starts and stops:

| Trace Name | iOS |
|------------|-----|
| App start | Starts when the application loads the first **Object** to memory and stops after the first successful run loop that occurs after the application receives the **UIApplicationDidBecomeActiveNotification** notification. |
| App in background | Starts when the application receives the **UIApplicationWillResignActiveNotification** notification and stops when it receives the **UIApplicationDidBecomeActiveNotification** notification. |
| App in foreground | Starts when the application receives the **UIApplicationDidBecomeActiveNotification** notification and stops when it receives the **UIApplicationWillResignActiveNotification** notification. |

## Monitor Custom Attributes

In Firebase Performance Monitoring, you can use attributes to segment performance data and focus on your app's performance in different real-world scenarios. A variety of attributes are available out-of-the-box, including operating system information, country, carrier, device, and app version. In addition, you can also create custom attributes, to segment data by categories specific to your app. For example, in a game, you can segment data by game level.

### Create custom attributes

You can use custom attributes on specific traces. You're limited to 5 custom attributes per trace.

To use custom attributes, add code to your app defining the attribute and applying it to a specific trace, like the following examples:

```csharp
var trace = Firebase.PerformanceMonitoring.Performance.SharedInstance.GetTrace ("myTrace");
trace.SetValue ("A", "experiment");

// Update scenario.
trace.SetValue ("B", "experiment");

// Reading scenario.
var experimentValue = trace.GetValue ("experiment");

// Delete scenario.
trace.RemoveAttribute ("experiment");

// Read attributes.
var attributes = trace.Attributes;
```

### Monitor custom attributes

In the Firebase console, go to the *Traces* tab in the [Performance section][6]. Each of your custom attributes has a card showing performance data for that segment. You can also filter by custom attributes.

## Disable the Firebase Performance Monitoring SDK

To let you users opt-in or opt-out of using Firebase Performance Monitoring, you might want to configure your app so that you can enable and disable Performance Monitoring. You might also find this capability to be useful during app development and testing.

You can disable the Performance Monitoring SDK when building your app with the option to re-enable it at runtime, or build your app with Performance Monitoring enabled and then have the option to disable it at runtime using [Firebase Remote Config][3]. You can also completely deactivate Performance Monitoring, with no option to enable it at runtime.

### Disable Performance Monitoring during your app build process

One situation where disabling Performance Monitoring during your app build process could be useful is to avoid reporting performance data from a pre-release version of your app during app development and testing.

You can add one of two keys to the property list file (**Info.plist**) for your iOS app to disable or deactivate Performance Monitoring:

* To disable Performance Monitoring, but allow your app to enable it at runtime, set `firebase_performance_collection_enabled` to `True` in your app's **Info.plist** file.
* To completely deactivate Performance Monitoring with no option to enable it at runtime, set `firebase_performance_collection_deactivated` to true in your app's **Info.plist** file. This setting overrides the `firebase_performance_collection_enabled` setting and must be removed from your app's **Info.plist** file to re-enable Performance Monitoring.

### Disable your app at runtime using Remote Config

Remote Config lets you make changes to the behavior and appearance of your app, so it provides an ideal way to let you disable Performance Monitoring in deployed instances of your app.

You can use the example code shown below to disable Performance Monitoring data collection the next time that your iOS app starts. For more information about using Remote Config in an iOS app, see [Use Firebase Remote Config on iOS][4].

1. In your project solution in Visual Studio, add **Xamarin.Firebase.iOS.RemoteConfig** NuGet package.
2. In your `AppDelegate` file, add the `Firebase.RemoteConfig` namespace.
	
	```csharp
	using Firebase.RemoteConfig;
	```

3. In your `AppDelegate` file, add the following code in `FinishedLaunching` method:

	```csharp
	var remoteConfig = RemoteConfig.SharedInstance;

	// You can change the "false" below to "true" to permit more fetches when validating
	// your app, but you should change it back to "false" or remove this statement before
	// distributing your app in production.
	remoteConfig.ConfigSettings = new RemoteConfigSettings (true);

	// You can set default parameter values using an NSDictionary object or a plist file.
	var defaultPlist = NSBundle.MainBundle.PathForResource ("RemoteConfigDefaults", "plist");

	if (defaultPlist != null) {
		// Load in-app defaults from a plist file that sets perf_enable 
		// to true until you update values in the Firebase Console.
		remoteConfig.SetDefaults ("RemoteConfigDefaults");
	} else {
		// If the plist file doesn't exist, load the value by code.
		object [] values = { true };
		object [] keys = { "perf_enable" };
		var defaultValues = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);
		remoteConfig.SetDefaults (defaultValues);
	}

	// Important! This needs to be applied before App.Configure()
	var isPerformanceMonitoringInstrumentation = remoteConfig ["perf_enable"].BoolValue;

	// The following line enables/disables automatic traces and HTTP/S network monitoring
	Performance.SharedInstance.InstrumentationEnabled = isPerformanceMonitoringInstrumentation;

	// The following line enables/disables custom traces
	Performance.SharedInstance.DataCollectionEnabled = isPerformanceMonitoringInstrumentation;

	// Use Firebase library to configure APIs
	App.Configure ();
	```

4. In your `ViewController` add the following code to fetch and activate Remote Config values:

	```csharp
	remoteConfig.Fetch (30, (status, error) => {
		switch (status) {
		case RemoteConfigFetchStatus.Success:
			Console.WriteLine ("Config fetched");
			remoteConfig.ActivateFetched ();
			break;

		case RemoteConfigFetchStatus.Throttled:
		case RemoteConfigFetchStatus.NoFetchYet:
		case RemoteConfigFetchStatus.Failure:
			Console.WriteLine ("Config not fetched...");
			Console.WriteLine ($"Error: {error.LocalizedDescription}");
			break;
		}
	});
	```

5. To disable Performance Monitoring in the Firebase console, create a `perf_enable` parameter in your app's project, and then set its value to `false`. If you set the value of `perf_enable` to `true`, Performance Monitoring will remain enabled.

#### Disable automatic or manual data collection separately

You could make some changes to the code shown above and in the Firebase console to let you disable automatic data collection (app start traces and HTTP/S network requests) separately from manual data collection (custom traces). To do this, you would add the following code to the `FinishedLaunching` method, instead of what is shown in step 3 above:

```csharp
var remoteConfig = RemoteConfig.SharedInstance;
remoteConfig.ConfigSettings = new RemoteConfigSettings (true);

var defaultPlist = NSBundle.MainBundle.PathForResource ("RemoteConfigDefaults", "plist");

if (defaultPlist != null) {
	remoteConfig.SetDefaults ("RemoteConfigDefaults");
} else {
	// If the plist file doesn't exist, load the values by code.
	object [] values = { true, true };
	object [] keys = { "perf_enable_auto", "perf_enable_manual" };
	var defaultValues = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);
	remoteConfig.SetDefaults (defaultValues);
}

// Important! This needs to be applied before App.Configure()
var isPerformanceMonitoringInstrumentationEnabled = remoteConfig ["perf_enable_auto"].BoolValue;
var isPerformanceMonitoringDataCollectionEnabled = remoteConfig ["perf_enable_manual"].BoolValue;

// The following line enables/disables automatic traces and HTTP/S network monitoring
Performance.SharedInstance.InstrumentationEnabled = isPerformanceMonitoringInstrumentationEnabled;

// The following line enables/disables custom traces
Performance.SharedInstance.DataCollectionEnabled = isPerformanceMonitoringDataCollectionEnabled;

// Use Firebase library to configure APIs
App.Configure ();
```

Then, do the following in the Firebase console:

* To disable automatic traces and HTTP/S network monitoring, create a `perf_enable_auto` parameter in your app's project, and then set its value to `false`.
* To disable custom traces, create a `perf_enable_manual` parameter in your app's project, and then set its value to `false`.

To enable either of these aspects of Performance Monitoring in your app, set the value of the corresponding parameter to `true` in the Firebase console.

## View Data in the Firebase Console

To learn how to read your data in Firebase Console, please, read the following [documentation][7].

## Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][5])
* Performance Monitoring has known compatibility issues with GTMSQLite. We recommend not using Performance Monitoring with apps that use GTMSQLite.
* Performance Monitoring does not support network requests made using either `WebClient` or `HttpClient` class.
* Method swizzling after calling `App.Configure ()` might interfere with the Performance Monitoring SDK.
* Known issues with the iOS 8.0-8.2 Simulator prevent Performance Monitoring from capturing performance events. These issues are fixed in the iOS 8.3 Simulator and later versions.
* Connections established using `NSUrlSession`'s BackgroundSessionConfiguration will exhibit longer than expected connection times. These connections are executed out-of-process and the timings reflect in-process callback events.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/dynamic-links/ios) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://components.xamarin.com/view/firebaseiosremoteconfig
[4]: https://components.xamarin.com/gettingstarted/firebaseiosremoteconfig
[5]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
[6]: https://console.firebase.google.com/project/_/performance/
[7]: https://firebase.google.com/docs/perf-mon/help
