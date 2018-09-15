# Xamarin Components for Google APIs for iOS

Xamarin creates and maintains Xamarin.iOS bindings for the Google APIs for iOS Libraries, including:

**Active Libraries**

| Package Id                                                                 | NuGet                                      |
|----------------------------------------------------------------------------|--------------------------------------------|
| [Xamarin.Firebase.iOS.ABTesting][F.ABTesting.Name]                         | [2.0.0.1][F.ABTesting.Package]             |
| [Xamarin.Firebase.iOS.AdMob][F.AdMob.Name]                                 | [7.31.0.3][F.AdMob.Package]                |
| [Xamarin.Firebase.iOS.Analytics][F.Analytics.Name]                         | [5.1.1.0][F.Analytics.Package]             |
| [Xamarin.Firebase.iOS.Auth][F.Auth.Name]                                   | [5.0.2.1][F.Auth.Package]                  |
| [Xamarin.Firebase.iOS.CloudFirestore][F.CloudFirestore.Name]               | [0.12.5.1][F.CloudFirestore.Package]       |
| [Xamarin.Firebase.iOS.CloudMessaging][F.CloudMessaging.Name]               | [3.0.3.1][F.CloudMessaging.Package]        |
| [Xamarin.Firebase.iOS.Core][F.Core.Name]                                   | [5.1.2.0][F.Core.Package]                  |
| [Xamarin.Firebase.iOS.Crashlytics][F.Crashlytics.Name]                     | [3.10.3.1][F.Crashlytics.Package]          |
| [Xamarin.Firebase.iOS.Database][F.Database.Name]                           | [5.0.2.1][F.Database.Package]              |
| [Xamarin.Firebase.iOS.DynamicLinks][F.DynamicLinks.Name]                   | [3.0.2.0][F.DynamicLinks.Package]          |
| [Xamarin.Firebase.iOS.InstanceID][F.InstanceID.Name]                       | [3.2.1.0][F.InstanceID.Package]            |
| [Xamarin.Firebase.iOS.Invites][F.Invites.Name]                             | [3.0.0.1][F.Invites.Package]               |
| [Xamarin.Firebase.iOS.PerformanceMonitoring][F.PerformanceMonitoring.Name] | [2.1.1.0][F.PerformanceMonitoring.Package] |
| [Xamarin.Firebase.iOS.RemoteConfig][F.RemoteConfig.Name]                   | [3.0.1.0][F.RemoteConfig.Package]          |
| [Xamarin.Firebase.iOS.Storage][F.Storage.Name]                             | [3.0.0.1][F.Storage.Package]               |
| [Xamarin.Google.iOS.Analytics][G.Analytics.Name]                           | [3.17.0.3][G.Analytics.Package]            |
| [Xamarin.Google.iOS.AppIndexing][G.AppIndexing.Name]                       | [2.0.3.5][G.AppIndexing.Package]           |
| [Xamarin.Google.iOS.Cast][G.Cast.Name]                                     | [4.1.0.1][G.Cast.Package]                  |
| [Xamarin.Google.iOS.InstanceID][G.InstanceID.Name]                         | [1.2.1.14][G.InstanceID.Package]           |
| [Xamarin.Google.iOS.Maps][G.Maps.Name]                                     | [2.5.0.1][G.Maps.Package]                  |
| [Xamarin.Google.iOS.MobileAds][G.MobileAds.Name]                           | [7.31.0.3][G.MobileAds.Package]            |
| [Xamarin.Google.iOS.Places][G.Places.Name]                                 | [2.5.0.1][G.Places.Package]                |
| [Xamarin.Google.iOS.PlayGames][G.PlayGames.Name]                           | [5.1.1.10][G.PlayGames.Package]            |
| [Xamarin.Google.iOS.SignIn][G.SignIn.Name]                                 | [4.1.2.1][G.SignIn.Package]                |
| [Xamarin.Google.iOS.TagManager][G.TagManager.Name]                         | [7.0.0.1][G.TagManager.Package]            |

**Deprecated Libraries**

| Package Id                                                                 | NuGet                                      |
|----------------------------------------------------------------------------|--------------------------------------------|
| [Xamarin.Google.iOS.AppInvite][G.AppInvite.Name]                           | [1.0.2.4][G.AppInvite.Package]             |
| [Xamarin.Google.iOS.Core][G.Core.Name]                                     | [3.1.0.1][G.Core.Package]                  |
| [Xamarin.Google.iOS.GoogleCloudMessaging][G.GoogleCloudMessaging.Name]     | [1.2.0.1][G.GoogleCloudMessaging.Package]  |
| [Xamarin.Firebase.iOS.CrashReporting][F.CrashReporting.Name]               | [2.0.0.6][F.CrashReporting.Package]        |

## Firebase APIs for iOS current global version

Here's a table that shows in which global version is located each component of Firebase at this point of history:

| Component Name                  | Component Version | Global Version |
|---------------------------------|:-----------------:|:--------------:|
| Firebase A/B Testing            | **2.0.0.1**       | **5.7.0**      |
| Firebase AdMob                  | **7.31.0.3**      | **5.4.0**      |
| Firebase Analytics              | **5.1.1.0**       | **5.7.0**      |
| Firebase Auth                   | **5.0.2.1**       | **5.4.0**      |
| Firebase Cloud Firestore        | **0.12.5.1**      | **5.4.0**      |
| Firebase Cloud Messaging        | **3.0.3.1**       | **5.4.0**      |
| Firebase Core                   | **5.1.2.0**       | **5.7.0**      |
| Firebase Database               | **5.0.2.1**       | **5.4.0**      |
| Firebase Dynamic Links          | **3.0.2.0**       | **5.7.0**      |
| Firebase Instance ID            | **3.2.1.0**       | **5.7.0**      |
| Firebase Invites                | **3.0.0.1**       | **5.4.0**      |
| Firebase Performance Monitoring | **2.1.1.0**       | **5.7.0**      |
| Firebase RemoteConfig           | **3.0.1.0**       | **5.7.0**      |
| Firebase Storage                | **3.0.0.1**       | **5.4.0**      |
| Google Sign-In                  | **4.1.2.1**       | **5.4.0**      |
| Google Tag Manager              | **7.0.0.1**       | **5.4.0**      |

## Building

Before building you will need to have [CocoaPods][101] installed on your OS X system.

The build script for this project uses [Cake][102].  To run the build, you can use the bootstrapper file for OS X:

**Mac**:

```
cd Firebase.Core
sh ../build.sh --target=libs
```

The bootstrapper script will automatically download Cake.exe and all the required tools and files into the `./tools/` folder.

The following targets can be specified:

 - `libs` builds the class library bindings (depends on `externals`)
 - `externals` downloads and builds the external dependencies
 - `samples` builds all of the samples (depends on `libs`)
 - `nuget` builds the nuget packages (depends on `libs`)
 - `component` builds the xamarin components (depends on `samples` and `nuget`)
 - `clean` cleans up everything

### Working in Visual Studio

Before the `.sln` files will compile in Visual Studio, the external dependencies need to be downloaded.  This can be done by running the `build.sh` or `build.ps1` with the target `externals`.  After the externals are setup, the `.sln` files should compile in an IDE.

## License

The license for this repository is specified in 
[License.md](License.md)

## Contribution Guidelines

You will need to complete a Contribution License Agreement before your pull request can be accepted. You can complete the CLA by going through the steps at [https://cla2.dotnetfoundation.org/][103].

## .NET Foundation

This project is part of the [.NET Foundation][104]


[comment]: # (Path for active Firebase component folders)

[F.ABTesting.Name]: Firebase.ABTesting
[F.AdMob.Name]: Firebase.AdMob
[F.Analytics.Name]: Firebase.Analytics
[F.Auth.Name]: Firebase.Auth
[F.CloudFirestore.Name]: Firebase.CloudFirestore
[F.CloudMessaging.Name]: Firebase.CloudMessaging
[F.Core.Name]: Firebase.Core
[F.Crashlytics.Name]: Firebase.Crashlytics
[F.Database.Name]: Firebase.Database
[F.DynamicLinks.Name]: Firebase.DynamicLinks
[F.InstanceID.Name]: Firebase.InstanceID
[F.Invites.Name]: Firebase.Invites
[F.PerformanceMonitoring.Name]: Firebase.PerformanceMonitoring
[F.RemoteConfig.Name]: Firebase.RemoteConfig
[F.Storage.Name]: Firebase.Storage

[comment]: # (URL for active Firebase component NuGets)

[F.ABTesting.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.ABTesting/
[F.AdMob.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.AdMob/
[F.Analytics.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Analytics/
[F.Auth.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Auth/
[F.CloudFirestore.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.CloudFirestore/
[F.CloudMessaging.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.CloudMessaging/
[F.Core.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Core/
[F.Crashlytics.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Crashlytics/
[F.Database.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Database/
[F.DynamicLinks.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.DynamicLinks/
[F.InstanceID.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.InstanceID/
[F.Invites.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Invites/
[F.PerformanceMonitoring.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.PerformanceMonitoring/
[F.RemoteConfig.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.RemoteConfig/
[F.Storage.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Storage/


[comment]: # (Path for active Google component folders)

[G.Analytics.Name]: Google.Analytics
[G.AppIndexing.Name]: Google.AppIndexing
[G.Cast.Name]: Google.Cast
[G.InstanceID.Name]: Google.InstanceID
[G.Maps.Name]: Google.Maps
[G.MobileAds.Name]: Google.MobileAds
[G.Places.Name]: Google.Places
[G.PlayGames.Name]: Google.PlayGames
[G.SignIn.Name]: Google.SignIn
[G.TagManager.Name]: Google.TagManager

[comment]: # (URL for active Google component NuGets)

[G.Analytics.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.Analytics/
[G.AppIndexing.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.AppIndexing/
[G.Cast.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.Cast/
[G.InstanceID.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.InstanceID/
[G.Maps.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.Maps/
[G.MobileAds.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.MobileAds/
[G.Places.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.Places/
[G.PlayGames.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.PlayGames/
[G.SignIn.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.SignIn/
[G.TagManager.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.TagManager/


[comment]: # (Path for deprecated Firebase component folders)

[F.CrashReporting.Name]: Firebase.CrashReporting

[comment]: # (URL for deprecated Firebase component NuGets)

[F.CrashReporting.Package]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.CrashReporting/


[comment]: # (Path for deprecated Google component folders)

[G.AppInvite.Name]: Google.AppInvite
[G.Core.Name]: Google.Core
[G.GoogleCloudMessaging.Name]: Google.GoogleCloudMessaging

[comment]: # (URL for deprecated Google component NuGets)

[G.AppInvite.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.AppInvite/
[G.Core.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.Core/
[G.GoogleCloudMessaging.Package]: https://www.nuget.org/packages/Xamarin.Google.iOS.GoogleCloudMessaging/


[101]: https://cocoapods.org/
[102]: http://cakebuild.net
[103]: https://cla2.dotnetfoundation.org/
[104]: http://www.dotnetfoundation.org/projects

