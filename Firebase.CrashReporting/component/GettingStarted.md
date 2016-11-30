# Use Firebase Crash Reporting on iOS

Firebase Crash Reporting creates detailed reports of the errors in your app. Errors are grouped into clusters of similar stack traces, and triaged by the severity of impact on your users. In addition to automatic reports, you can log custom events to help capture the steps leading up to a crash.

## User privacy

Firebase Crash Reporting does not itself collect any personally identifiable information (such as names, email addresses, or phone numbers). Developers can collect additional data using Crash Reporting with log and exception messages. Such data collected through Crash Reporting should not contain information that personally identifies an individual to Google.

Here is an example of a log message that does not contain personally identifiable information:

```csharp
Firebase.CrashReporting.CrashReporting.Log ("SQL database failed to initialize");
```

And here is another one that does contain personally identifiable information:

```csharp
Firebase.CrashReporting.CrashReporting.Log ($"{user.Email} purchased product {product.Id}");
```

If identifying a user is necessary to diagnose an issue, then you must use adequate obfuscation measures to render the data you send to Google anonymous.

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure Crash Reporting in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Analytics` namespace):

```csharp
App.Configure ();
```

## Create your first error

1. Add an assert to your AppDelegate's didFinishLaunchingWithOptions method to cause a crash when the app launches, right after the Firebase initialization call:

```csharp

```

1. Launch the app from Xamarin Studio.
2. Click Stop in Xamarin Studio to detach from the debugger.
3. Launch the app directly from the home screen on the device or emulator.
4. Wait until your app crashes.
5. Remove the crashing line so your app can start successfully.
6. Launch the quickstart from Xamarin Studio again. Within 15 secs you should see a log message indicating that the report was successfully uploaded.
7. Check the Crash Reporting section of the [Firebase console][1] to see the error. Note that it takes 1-2 minutes for errors to show there.

## Create custom logs

You can use `Log` method to create custom log messages that are included in your crash reports. The following example demonstrates creating a log message:

```csharp
using Firebase.CrashReporting;

// ...

CrashReporting.Log ("Cause Crash button clicked");
// TODO: Cause crash code
```

### Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][4])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/crash/ios) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://firebase.google.com/docs/remote-config/parameters
[4]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
