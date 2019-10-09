/////////////////////////////////////
// Xamarin.Google.iOS.Cast         //
/////////////////////////////////////

Google has released two versions of Google Cast framework; one that references
CoreBluetooth framework and other one that doesn't. For more info about the
differences, please, visit this link:

https://developers.google.com/cast/docs/ios_sender/#cocoapods_setup

The framework that references CoreBluetooth is embedded by default.
If you wish to use the framework without the CoreBluetooth framework,
define the following property anywhere in your .csproj before the
Xamarin.Google.iOS.Cast.targets import:

```
<PropertyGroup>
	<GoogleCastBluetoothEnabled>False</GoogleCastBluetoothEnabled>
</PropertyGroup>
```

If you choose to switch between frameworks, please, do a clean on Visual Studio
and delete bin and obj folders before building again. This to prevent
issues with some kind of cache on bin and obj folders.
