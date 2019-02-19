# Get Started with Firebase Crashlytics for iOS

## Table of Content

- [Get Started with Firebase Crashlytics for iOS](#get-started-with-firebase-crashlytics-for-ios)
	- [Table of Content](#table-of-content)
	- [Before you begin](#before-you-begin)
	- [Add Firebase to your app](#add-firebase-to-your-app)
	- [Configure Firebase in your app](#configure-firebase-in-your-app)
- [Upgrade to Firebase Crashlytics from Firebase Crash Reporting](#upgrade-to-firebase-crashlytics-from-firebase-crash-reporting)
	- [Update project dependencies](#update-project-dependencies)
	- [Migrate logs](#migrate-logs)
	- [Set up manual initialization](#set-up-manual-initialization)
- [Test your Firebase Crashlytics implementation](#test-your-firebase-crashlytics-implementation)
	- [Force a crash to test your implementation](#force-a-crash-to-test-your-implementation)
	- [Adjust your project's debug settings](#adjust-your-projects-debug-settings)
	- [Test it out](#test-it-out)
	- [Enable Crashlytics debug mode](#enable-crashlytics-debug-mode)
- [Customize your Firebase Crashlytics crash reports](#customize-your-firebase-crashlytics-crash-reports)
	- [Enable opt-in reporting](#enable-opt-in-reporting)
	- [Add custom logs](#add-custom-logs)
	- [Add custom keys](#add-custom-keys)
	- [Set user IDs](#set-user-ids)
	- [Log non-fatal exceptions](#log-non-fatal-exceptions)
		- [Logs and custom keys](#logs-and-custom-keys)
		- [Performance considerations](#performance-considerations)
		- [What about NSExceptions?](#what-about-nsexceptions)
	- [Manage Crash Insights data](#manage-crash-insights-data)
- [Extend Firebase Crashlytics with Cloud Functions](#extend-firebase-crashlytics-with-cloud-functions)

## Before you begin

* Enable Crashlytics: Click **Set up Crashlytics** in the [Firebase console][1].

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure Firebase in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Visual Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behavior to `Bundle Resource` by Right clicking/Build Action.
3. Add the `Xamarin.Firebase.iOS.Core` NuGet to your project.
4. Add the following lines of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` and `Firebase.Crashlytics` namespace):

```csharp
App.Configure ();
Crashlytics.Configure ();
```

---

# Upgrade to Firebase Crashlytics from Firebase Crash Reporting

Crashlytics is the new, primary crash reporter for Firebase. If your app uses Firebase Crash Reporting, there's good news: Crashlytics offers enhanced crash reporting with nearly the same setup process you're used to, so upgrading is straightforward:

1. Update your project's dependencies.
2. Migrate any log calls, if you have them.
3. Set up manual initialization, if you used it.

## Update project dependencies

To update your app's depencencies for Firebase Crashlytics, swap the Xamarin.Firebase.iOS.CrashReporting NuGet with the Xamarin.Firebase.iOS.Crashlytics NuGet and remove the Firebase Crash Reporting custom command:

1. In Visual Studio, do a double click on **Packages** folder and add the Xamarin.Firebase.iOS.Crashlytics NuGet.
2. Remove Xamarin.Firebase.iOS.CrashReporting NuGet by right clicking/Remove.
3. Open your app **Project Options**, go to **Build** > **Custom Command** and delete the Crash Reporting command:

	```
	sh ${ProjectDir}/scripts/FirebaseCrashReporting/xamarin_upload_symbols.sh -n ${ProjectName} -b ${TargetDir} -i ${ProjectDir}/Info.plist -p ${ProjectDir}/GoogleService-Info.plist -s ${ProjectDir}/service-account.json
	```

## Migrate logs

If you used Firebase Crash Reporting custom logs, you have to update those for Firebase Crashlytics too:

| Firebase Crash Reporting | Firebase Crashlytics                                                                             |
|--------------------------|--------------------------------------------------------------------------------------------------|
| CrashReporting.Log       | Logging.Log / Logging.LogCallerInformation <br /> Logging.NSLog / Logging.NSLogCallerInformation |

> ![warning_icon] _**Note:**_ _The string given to these methods must be an escaped string due it will be passed to a C function and it expects an escaped string. For example, if you want to print a %, you must type %%. Passing an unescaped string may cause the termination of your app._

## Set up manual initialization

Like Firebase Crash Reporting, the Firebase Crashlytics SDK automatically initializes Crashlytics as soon as you add it to your app. If instead you initialize reporting manually, Crashlytics has a way to do that as well:

1. Turn off automatic collection with a new key to your Info.plist file:
	* Key: `firebase_crashlytics_collection_enabled`
	* Value: `false`
2. Replace the Crash Reporting initialization call with one for Crashlytics:
	```csharp
	// Delete Crash Reporting
	// CrashReporting.SharedInstance.CrashCollectionEnabled = true;

	// Add Crashlytics
	Fabric.Fabric.With (typeof (Crashlytics));
	```

---

# Test your Firebase Crashlytics implementation

## Force a crash to test your implementation

You don't have to wait for a crash to know that Crashlytics is working. You can use the SDK to force a crash by adding the following code to your app:

```csharp
using Firebase.Crashlytics;

...

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	var button = new UIButton (UIButtonType.RoundedRect) {
		Frame = new CGRect (0, 0, 100, 30),
		TranslatesAutoresizingMaskIntoConstraints = false
	};
	button.SetTitle ("Crash", UIControlState.Normal);
	button.TouchUpInside += Button_TouchUpInside;
	View.AddSubview (button);

	button.AddConstraint (NSLayoutConstraint.Create (button, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, 
							 View, NSLayoutAttribute.CenterX, 
							 1, 0));
	button.AddConstraint (NSLayoutConstraint.Create (button, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal,
							 View, NSLayoutAttribute.CenterY,
							 1, 0));
}

void Button_TouchUpInside (object sender, EventArgs e)
{
	Crashlytics.SharedInstance.Crash ();
}
```

## Adjust your project's debug settings

Crashlytics can’t capture crashes if your build attaches a debugger at launch. Adjust your build settings to change the project's debug information format:

1. In Visual Studio, open your app project settings.
	* _Mac:_ Go to **Build** > **iOS Build**
	* _Windows:_ Go to **iOS Build**
2. Select an **iPhone** platform.
2. Make sure that **Strip native debugging symbols** is unchecked.

## Test it out

The code snippet above adds a button that crashes your app when pressed. For it to work, run the app without a debugger, the debugger interferes with Crashlytics:

1. Select a physical device and Debug configuration.
2. Run the app without debugging:
	* _Mac:_ Open **Run** menu > **Start Without Debugging**
	* _Windows:_ Open **Build** menu > **Start Without Debugging**

	The build process will upload the `dSYM` file of the app to Firebase in a background process.
3. Touch Crash button to crash the app.
4. Open your app once more to let the Crashlytics API report the crash. Your crash should show up in the Firebase console within 5 minutes.

## Enable Crashlytics debug mode

If your forced crash didn't crash, crashed before you wanted it to, or you're experiencing some other issue with Crashlytics, you can enable Crashlytics debug mode to track down the problem:

```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{
	...
	Fabric.Fabric.SharedSdk.Debug = true;
	...

	return true;
}
```

---

# Customize your Firebase Crashlytics crash reports

Firebase Crashlytics can work with very little setup on your part—as soon as you add the SDK, Crashlytics gets to work sending crash reports to the Firebase console.

For more fine-grained control of your crash reports, customize your Crashlytics SDK configuration. For example, you can enable opt-in reporting for privacy-minded users, add logs to track down pesky bugs, and more.

## Enable opt-in reporting

By default, Firebase Crashlytics automatically collects crash reports for all your app's users. To give users more control over the data they send, you can enable opt-in reporting instead.

To do that, you have to disable automatic collection and initialize Crashlytics only for opt-in users.

1. Turn off automatic collection with a new key to your **Info.plist** file:
	* Key: `firebase_crashlytics_collection_enabled`
	* Value: `false`
2. Enable collection for selected users by initializing Crashlytics at runtime:
	```csharp
	Fabric.Fabric.With (typeof (Crashlytics));
	```

## Add custom logs

To give yourself more context for the events leading up to a crash, you can add custom Crashlytics logs to your app. Crashlytics associates the logs with your crash data and makes them visible in the Firebase console.

Use `LogCallerInformation` and `NSLogCallerInformation` methods to help pinpoint issues. It automatically includes information about the C# filename, method, and line number associated with the log. You can optionally pass the class name to have a better log:

* **Debug builds:** `NSLogCallerInformation` method passes through to `NSLog` method so you can see the output in Visual Studio and on the device.
* **Release builds:** To improve performance, `LogCallerInformation` method silences all other output and will be only shown on Firebase Crashlytics dashboard when a crash occurs.

```csharp
void Button_TouchUpInside (object sender, EventArgs e)
{
	var data = new Dictionary<object, object> {
		{ "A keyblade", "for a heartless" },
		{ "A heart", "for a nobody" }
	};
	var nsData = NSDictionary.FromObjectsAndKeys (data.Values.ToArray (), data.Keys.ToArray (), data.Keys.Count);

	Logging.LogCallerInformation ($"Hi! Maybe, I'm about to crash! Here's some data: {nsData}", nameof (ViewController));

	// or

	Logging.NSLogCallerInformation ($"Hi! Maybe, I'm about to crash! Here's some data: {nsData}", nameof (ViewController));

	Crashlytics.SharedInstance.Crash ();
}
```

Assuming that you are coding in a file named `MyViewController.cs`, the output will be:

```
MyViewController.cs: ViewController.Button_TouchUpInside line 47 $ Hi! Maybe I'm about to crash! Here's some data: {
    "A keyblade" = "for a heartless";
    "A heart" = "for a nobody";
}
```

If you omit the second parameter of `NSLogCallerInformation` or `LogCallerInformation` method, the output will be:

```
MyViewController.cs: Button_TouchUpInside line 47 $ Hi! Maybe I'm about to crash! Here's some data: {
    "A keyblade" = "for a heartless";
    "A heart" = "for a nobody";
}
```

> ![note_icon] _To avoid slowing down your app, Crashlytics limits logs to 64kB. Crashlytics deletes older log entries if a session's logs go over that limit._

> ![warning_icon] _**Note:**_ _The string given to these methods must be an escaped string due it will be passed to a C function and it expects an escaped string. For example, if you want to print a %, you must type %%. Passing an unescaped string may cause the termination of your app._

## Add custom keys

Custom keys help you get the specific state of your app leading up to a crash. You can associate arbitrary key/value pairs with your crash reports, and see them in the Firebase console:

```csharp
void SetObjectValue (NSObject value, string key);
void SetStringValue (string value, string key);
void SetIntValue (int value, string key);
void SetBoolValue (bool value, string key);
void SetFloatValue (float value, string key);
```

Sometimes you need to change the existing key value. Call the same key, but replace the value, for example:

```csharp
Crashlytics.SharedInstance.SetIntValue (3, "current_level");
Crashlytics.SharedInstance.SetStringValue ("logged_in", "last_UI_action");
```

> ![note_icon] _Crashlytics supports a maximum of 64 key/value pairs. Once you reach this threshold, additional values are not saved. Each key/value pair can be up to 1 kB in size_

## Set user IDs

To diagnose an issue, it’s often helpful to know which of your users experienced a given crash. Crashlytics includes a way to anonymously identify users in your crash reports.

To add user IDs to your reports, assign each user a unique identifier in the form of an ID number, token, or hashed value:

```csharp
Crashlytics.SharedInstance.SetUserIdentifier ("123456789");
```

If you ever need to clear a user identifier after you set it, reset the value to a blank string.

## Log non-fatal exceptions

In addition to automatically reporting your app’s crashes, Crashlytics lets you log non-fatal exceptions.

On iOS, you do that by recording `NSError` objects, which Crashlytics reports and groups much like crashes:

```csharp
Crashlytics.SharedInstance.RecordError (error);
```

When using the `RecordError` method, it's important to understand the `NSError` structure and how Crashlytics uses the data to group crashes. Incorrect usage of the `RecordError` method can cause unpredicatable behavior and may require Crashlytics to limit reporting of logged errors for your app.

An `NSError` object has three arguments: `NSString Domain`, `nint Code`, and `NSDictionary UserInfo`.

Unlike fatal crashes, which are grouped via stack trace analysis, logged errors are grouped by the NSError `Domain` and `Code`. This is an important distinction between fatal crashes and logged errors. For example, logging an error such as:

```csharp
var userInfo = new Dictionary<object, object> {
	{ NSError.LocalizedDescriptionKey, NSBundle.MainBundle.LocalizedString ("The request failed.", null) },
	{ NSError.LocalizedFailureReasonErrorKey, NSBundle.MainBundle.LocalizedString ("The response returned a 404.", null) },
	{ NSError.LocalizedRecoverySuggestionErrorKey, NSBundle.MainBundle.LocalizedString ("Does this page exist?", null) },
	{ "ProductId", "123456" },
	{ "UserId", "Jane Smith" }
};

var error = new NSError (new NSString ("SomeErrorDomain"), 
			 -1001, 
			 NSDictionary.FromObjectsAndKeys (userInfo.Values.ToArray (), userInfo.Keys.ToArray (), userInfo.Keys.Count));
```

Creates a new issue that is grouped by `SomeErrorDomain` and `-1001`. Additional logged errors that use the same domain and code values will be grouped under this issue.

> ![warning_icon] _Avoid using unique values, such as user ID, product ID, and timestamps in the domain and code fields. Using unique values in these fields causes a high cardinality of issues and may result in Crashlytics needing to limit the reporting of logged errors in your app. Unique values should instead be added to the `UserInfo` Dictionary object._

Data contained within the `UserInfo` object are converted to key-value pairs and displayed in the keys/logs section within an individual issue.

![note_icon] _Crashlytics only stores the most recent 8 exceptions in a given app session. If your app throws more than 8 exceptions in a session, older exceptions are lost._

### Logs and custom keys

Just like crash reports, you can embed logs and custom keys to add context to the NSError. However, there is a difference in what logs are attached to crashes versus logged errors. When a crash occurs and the app is relaunched, the logs Crashlytics retrieves from disk are those that were written right up to the time of the crash. When you log an NSError, the app does not immediately terminate. Because Crashlytics only sends the logged error report on the next app launch, and because Crashlytics must limit the amount of space allocated for logs on disk, it is possible to log enough after an NSError is recorded so that all relevant logs are rotated out by the time Crashlytics sends the report from the device. Keep this balance in mind when logging NSErrors and using `Log` and custom keys in your app.

### Performance considerations

Keep in mind that logging an NSError can be fairly expensive. At the time you make the call, Crashlytics captures the current thread’s call stack using a process called stack unwinding. This process can be CPU and I/O intensive, particularly on architectures that support DWARF unwinding (arm64 and x86). After the unwind is complete, the information is written to disk synchronously. This prevents data loss if the next line were to crash.

While it is safe to call this API on a background thread, remember that dispatching this call to another queue will lose the context of the current stack trace.

### What about NSExceptions?

Crashlytics doesn’t offer a facility for logging/recording NSException instances directly. Generally speaking, the Cocoa and Cocoa Touch APIs are not exception-safe. That means the use of `@catch` in your Objective-C library code or in a third-party Objective-C code can have very serious unintended side-effects in your process, even when used with extreme care. You should never use `@catch` statements in your Objective-C code. Please refer to Apple’s [documentation][2] on the topic.

## Manage Crash Insights data

Crash Insights helps you resolve issues by comparing your anonymized stack traces to traces from other Firebase apps and letting you know if your issue is part of a larger trend. For many issues, Crash Insights even provides resources to help you debug the crash.

Crash Insights uses aggregated crash data to identify common stability trends. If you’d prefer not to share your app's data, you can opt-out of Crash Insights from the Crash Insights menu at the top of your Crashlytics issue list in the [Firebase console][1].

---

# Extend Firebase Crashlytics with Cloud Functions

You can trigger a function in response to Crashlytics issue events including new issues, regressed issues, and velocity alerts. To learn more about this, please, read the following [documentation][3].

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/crashlytics/get-started) to see original Firebase documentation._</sub>

[1]: https://console.firebase.google.com
[2]: https://developer.apple.com/library/content/documentation/Cocoa/Conceptual/Exceptions/Articles/ExceptionsAndCocoaFrameworks.html
[3]: https://firebase.google.com/docs/crashlytics/extend-with-cloud-functions
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
