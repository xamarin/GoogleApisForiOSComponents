# Xamarin Components for Google APIs for iOS

Xamarin creates and maintains Xamarin.iOS bindings for the Google APIs for iOS Libraries, including:

**Active Libraries**

| Package Id                                       | NuGet          |
|--------------------------------------------------|----------------|
| [Xamarin.Firebase.iOS.Core][1]                   | [4.0.13.0][51] |
| [Xamarin.Firebase.iOS.DynamicLinks ][2]          | [2.1.0.1][52]  |
| [Xamarin.Firebase.iOS.Storage][3]                | [2.0.2.1][53]  |
| [Xamarin.Google.iOS.InstanceID][4]               | [1.2.1.11][54] |
| [Xamarin.Google.iOS.Cast][6]                     | [4.0.2.0][56]  |
| [Xamarin.Firebase.iOS.CloudMessaging][7]         | [2.0.4.1][57]  |
| [Xamarin.Firebase.iOS.RemoteConfig][8]           | [2.0.3.1][58]  |
| [Xamarin.Google.iOS.Core][9]                     | [3.1.0.1][59]  |
| [Xamarin.Firebase.iOS.AdMob][10]                 | [7.27.0.0][60] |
| [Xamarin.Google.iOS.SignIn][11]                  | [4.1.0.1][61]  |
| [Xamarin.Google.iOS.MobileAds][12]               | [7.27.0.0][62] |
| [Xamarin.Firebase.iOS.Auth][14]                  | [4.2.1.1][64]  |
| [Xamarin.Google.iOS.TagManager][15]              | [6.0.0.2][65]  |
| [Xamarin.Google.iOS.Maps][16]                    | [2.5.0.0][66]  |
| [Xamarin.Google.iOS.AppIndexing][17]             | [2.0.3.4][67]  |
| [Xamarin.Firebase.iOS.Invites][18]               | [2.0.1.1][68]  |
| [Xamarin.Google.iOS.PlayGames][19]               | [5.1.1.10][69] |
| [Xamarin.Firebase.iOS.CrashReporting][20]        | [2.0.0.4][70]  |
| [Xamarin.Google.iOS.Analytics][21]               | [3.17.0.2][71] |
| [Xamarin.Google.iOS.Places][22]                  | [2.5.0.0][72]  |
| [Xamarin.Firebase.iOS.InstanceID][23]            | [2.0.8.0][73]  |
| [Xamarin.Firebase.iOS.PerformanceMonitoring][24] | [1.1.0.0][74]  |
| [Xamarin.Firebase.iOS.Analytics][25]             | [4.0.5.0][75]  |
| [Xamarin.Firebase.iOS.Database][26]              | [4.1.0.1][76]  |

**Deprecated Libraries**

| Package Id                                       | NuGet          |
|--------------------------------------------------|----------------|
| [Xamarin.Google.iOS.GoogleCloudMessaging][5]     | [1.2.0.1][55]  |
| [Xamarin.Google.iOS.AppInvite][13]               | [1.0.2.4][63]  |

## Building

Before building you will need to have [CocoaPods][101] installed on your OS X system.

The build script for this project uses [Cake][102].  To run the build, you can use the bootstrapper file for OS X:

**Mac**:

```
cd Google.Core
sh ../build.sh --target libs
```

The bootstrapper script will automatically download Cake.exe and all the required tools and files into the `./tools/` folder.

The following targets can be specified:

 - `libs` builds the class library bindings (depends on `externals`)
 - `externals` downloads and builds the external dependencies
 - `samples` builds all of the samples (depends on `libs`)
 - `nuget` builds the nuget packages (depends on `libs`)
 - `component` builds the xamarin components (depends on `samples` and `nuget`)
 - `clean` cleans up everything


### Working in Xamarin Studio

Before the `.sln` files will compile in Xamarin Studio, the external dependencies need to be downloaded.  This can be done by running the `build.sh` or `build.ps1` with the target `externals`.  After the externals are setup, the `.sln` files should compile in an IDE.


## License

The license for this repository is specified in 
[License.md](License.md)

## Contribution Guidelines

You will need to complete a Contribution License Agreement before your pull request can be accepted. You can complete the CLA by going through the steps at [https://cla2.dotnetfoundation.org/][103].

## .NET Foundation
This project is part of the [.NET Foundation][104]

[1]: Firebase.Core
[2]: Firebase.DynamicLinks
[3]: Firebase.Storage
[4]: Google.InstanceID
[5]: Google.GoogleCloudMessaging
[6]: Google.Cast
[7]: Firebase.CloudMessaging
[8]: Firebase.RemoteConfig
[9]: Google.Core
[10]: Firebase.AdMob
[11]: Google.SignIn
[12]: Google.MobileAds
[13]: Google.AppInvite
[14]: Firebase.Auth
[15]: Google.TagManager
[16]: Google.Maps
[17]: Google.AppIndexing
[18]: Firebase.Invites
[19]: Google.PlayGames
[20]: Firebase.CrashReporting
[21]: Google.Analytics
[22]: Google.Places
[23]: Firebase.InstanceID
[24]: Firebase.PerformanceMonitoring
[25]: Firebase.Analytics
[26]: Firebase.Database


[51]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Core/
[52]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.DynamicLinks/
[53]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Storage/
[54]: https://www.nuget.org/packages/Xamarin.Google.iOS.InstanceID/
[55]: https://www.nuget.org/packages/Xamarin.Google.iOS.GoogleCloudMessaging/
[56]: https://www.nuget.org/packages/Xamarin.Google.iOS.Cast/
[57]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.CloudMessaging/
[58]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.RemoteConfig/
[59]: https://www.nuget.org/packages/Xamarin.Google.iOS.Core/
[60]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.AdMob/
[61]: https://www.nuget.org/packages/Xamarin.Google.iOS.SignIn/
[62]: https://www.nuget.org/packages/Xamarin.Google.iOS.MobileAds/
[63]: https://www.nuget.org/packages/Xamarin.Google.iOS.AppInvite/
[64]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Auth/
[65]: https://www.nuget.org/packages/Xamarin.Google.iOS.TagManager/
[66]: https://www.nuget.org/packages/Xamarin.Google.iOS.Maps/
[67]: https://www.nuget.org/packages/Xamarin.Google.iOS.AppIndexing/
[68]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Invites/
[69]: https://www.nuget.org/packages/Xamarin.Google.iOS.PlayGames/
[70]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.CrashReporting/
[71]: https://www.nuget.org/packages/Xamarin.Google.iOS.Analytics/
[72]: https://www.nuget.org/packages/Xamarin.Google.iOS.Places/
[73]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.InstanceID/
[74]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.PerformanceMonitoring/
[75]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Analytics/
[76]: https://www.nuget.org/packages/Xamarin.Firebase.iOS.Database/

[101]: https://cocoapods.org/
[102]: http://cakebuild.net
[103]: https://cla2.dotnetfoundation.org/
[104]:http://www.dotnetfoundation.org/projects

