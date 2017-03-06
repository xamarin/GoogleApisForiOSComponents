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

Add a crash code right after Firebase initialization call in your AppDelegate's `FinishedLaunching` method to cause a crash when the app launches:

```csharp
App.Configure ();

// Cause crash code
var crash = new NSObject ();
crash.PerformSelector (new Selector ("doesNotRecognizeSelector"), crash, 0);
```

Don't run the app yet, please read **Upload symbol files** before running.

## Upload symbol files

In order to view human-readable crash reports, you will need to upload symbol files to Firebase Console after each build. To achieve this, you will need to upload the executable of your app that is generated after each build (the executable file lives inside of **Your.app** that is generated commonly inside of **bin** folder of your project). But first, you will need to download the **service account key** to authenticate your uploads:

1. Go to [Firebase Console][1] and select your project.
2. Open **project settings** and go to **Service Accounts** tab.
3. Select **Crash Reporting** and click on **Generate New Private Key** button.
4. Name the file as **service-account.json** and save it in the root of your project folder.

### Upload symbol files with Xamarin Studio

Follow these steps to upload your app symbols with Xamarin Studio:

* In Xamarin Studio, open **Project Options** of your app and go to **Build** > **Custom Commands**.
* Double check that **Debug** configuration is selected (Platform can be device or simulator).
* In Combobox select **After Build** option.
* Paste the following command in **Command** text field:

```
sh ${ProjectDir}/scripts/FirebaseCrashReporting/batch-upload -p ${ProjectDir}/GoogleService-Info.plist -i ${ProjectDir}/Info.plist ${ProjectDir}/service-account.json ${TargetDir}/${ProjectName}.app/${ProjectName}
```

* Save options changed.
* Now, build your app with **Debug** configuration.

Depending of your internet connection, the build can take some minutes because the script is uploading your symbols to Firebase.

> ***Note:*** *If you don't want to keep uploading your symbols after each build, just remove the **After Build** command.*

### Upload symbol files with Terminal

Follow these steps to upload your app symbols with Terminal:

* In Xamarin Studio, select **Debug** configuration (Platform can be device or simulator) and build the app (cmd + k) (don't run it).
* In Terminal, go to your project folder and run the following command:
  * If you built your project with iPhoneSimulator Target:

```
# Don't forget to replace [YourAppName] value
sh scripts/FirebaseCrashReporting/batch-upload -p GoogleService-Info.plist -i Info.plist service-account.json bin/iPhoneSimulator/Debug/[YourAppName].app/[YourAppName]
```

  * If you built your project with iPhone Target:

```
# Don't forget to replace [SDKVersion] and [YourAppName] values
sh scripts/FirebaseCrashReporting/batch-upload -p GoogleService-Info.plist -i Info.plist service-account.json bin/iPhone/Debug/device-builds/iphone[SDKVersion]/[YourAppName].app/[YourAppName]
```

* Depending of your internet connection, the script can take some minutes because it's uploading your symbols to Firebase.

## Upload your first error to Firebase

After you uploaded your symbol files to Firebase, do the following steps to view your crash in Firebase Console:

1. Launch the app from Xamarin Studio.
2. Wait until your app crashes, then, stop the debugging.
3. Launch the app directly from the home screen on the device or simulator.
4. Wait until your app crashes.
5. Remove the crashing line so your app can start successfully.
6. Run your app again.
7. Within 20 minutes your crash should show up in **Crash Reporting** section of Firebase Console.

## Create custom logs

You can use `Log` method to create custom log messages that are included in your crash reports. The following example demonstrates creating a log message:

```csharp
using Firebase.CrashReporting;

// ...

CrashReporting.Log ("Cause Crash button clicked");

// Cause crash code
var crash = new NSObject ();
crash.PerformSelector (new Selector ("doesNotRecognizeSelector"), crash, 0);
```

### Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][3])
* The Firebase SDK does not currently support using the `NSException` class in the Xcode simulator. If you use this class, it will result in malformed stack traces in the Firebase console. As a workaround, either use a physical device or test with a different type of exception.
* Crash Reporting uses a unique ID to identify each user. Due to a known bug in Xcode 8.1, creating this ID fails on iOS 10 simulators, preventing the upload of error reports. To work around this in Xcode 8.1, you can run tests on a device, or turn on **Keychain Sharing** in your **Entitlements.plist** file. This bug has been addressed in the beta release of Xcode 8.2.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/crash/ios) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
