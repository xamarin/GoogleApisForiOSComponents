# Xamarin Components for Google APIs for iOS

Xamarin creates and maintains Xamarin.iOS bindings for the Google APIs for iOS Libraries, including:

| Name                             | Component Store            | NuGet                                         |
|----------------------------------|----------------------------|-----------------------------------------------|
| [Google.Analytics][1]            | [googleiosanalytics][21]   | [Xamarin.Google.iOS.Analytics][41]            |
| [Google.AppIndexing][2]          | [googleiosappindexing][22] | [Xamarin.Google.iOS.AppIndexing][42]          |
| [Google.AppInvite][3]            | [googleiosappinvite][23]   | [Xamarin.Google.iOS.AppInvite][43]            |
| [Google.Cast][4]                 | [googleioscast][24]        | [Xamarin.Google.iOS.Cast][44]                 |
| [Google.Core][5]                 | NA                         | [Xamarin.Google.iOS.Core][45]                 |
| [Google.GoogleCloudMessaging][6] | [googleiosgcm][26]         | [Xamarin.Google.iOS.GoogleCloudMessaging][46] |
| [Google.InstanceID][7]           | [googleiosinstanceid][27]  | [Xamarin.Google.iOS.InstanceID][47]           |
| [Google.Maps][8]                 | [googleiosmaps][28]        | [Xamarin.Google.iOS.Maps][48]                 |
| [Google.MobileAds][9]            | [googleiosmobileads][29]   | [Xamarin.Google.iOS.MobileAds][49]            |
| [Google.PlayGames][10]           | [googleiosplaygames][30]   | [Xamarin.Google.iOS.PlayGames][50]            |
| [Google.SignIn][11]              | [googleiossignin][31]      | [Xamarin.Google.iOS.SignIn][51]               |
| [Google.TagManager][12]          | [googleiostagmanager][32]  | [Xamarin.Google.iOS.TagManager][52]           |



## Building

Before building you will need to have [CocoaPods][61] installed on your OS X system.

The build script for this project uses [Cake][62].  To run the build, you can use the bootstrapper file for OS X:

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

You will need to complete a Contribution License Agreement before your pull request can be accepted. You can complete the CLA by going through the steps at [https://cla2.dotnetfoundation.org/][63].

## .NET Foundation
This project is part of the [.NET Foundation][64]


[1]: Google.Analytics
[2]: Google.AppIndexing
[3]: Google.AppInvite
[4]: Google.Cast
[5]: Google.Core
[6]: Google.GoogleCloudMessaging
[7]: Google.InstanceID
[8]: Google.Maps
[9]: Google.MobileAds
[10]: Google.PlayGames
[11]: Google.SignIn
[12]: Google.TagManager

[21]: https://components.xamarin.com/view/googleiosanalytics
[22]: https://components.xamarin.com/view/googleiosappindexing
[23]: https://components.xamarin.com/view/googleiosappinvite
[24]: https://components.xamarin.com/view/googleioscast
[26]: https://components.xamarin.com/view/googleiosgcm
[27]: https://components.xamarin.com/view/googleiosinstanceid
[28]: https://components.xamarin.com/view/googleiosmaps
[29]: https://components.xamarin.com/view/googleiosmobileads
[30]: https://components.xamarin.com/view/googleiosplaygames
[31]: https://components.xamarin.com/view/googleiossignin
[32]: https://components.xamarin.com/view/googleiostagmanager

[41]: https://www.nuget.org/packages/Xamarin.Google.iOS.Analytics/
[42]: https://www.nuget.org/packages/Xamarin.Google.iOS.AppIndexing/
[43]: https://www.nuget.org/packages/Xamarin.Google.iOS.AppInvite/
[44]: https://www.nuget.org/packages/Xamarin.Google.iOS.Cast/
[45]: https://www.nuget.org/packages/Xamarin.Google.iOS.Core/
[46]: https://www.nuget.org/packages/Xamarin.Google.iOS.GoogleCloudMessaging/
[47]: https://www.nuget.org/packages/Xamarin.Google.iOS.InstanceID/
[48]: https://www.nuget.org/packages/Xamarin.Google.iOS.Maps/
[49]: https://www.nuget.org/packages/Xamarin.Google.iOS.MobileAds/
[50]: https://www.nuget.org/packages/Xamarin.Google.iOS.PlayGames/
[51]: https://www.nuget.org/packages/Xamarin.Google.iOS.SignIn/
[52]: https://www.nuget.org/packages/Xamarin.Google.iOS.TagManager/

[61]: https://cocoapods.org/
[62]: http://cakebuild.net
[63]: https://cla2.dotnetfoundation.org/
[64]:http://www.dotnetfoundation.org/projects

