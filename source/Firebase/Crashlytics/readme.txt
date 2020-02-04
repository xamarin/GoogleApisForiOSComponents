//////////////////////////////////////
// Xamarin.Firebase.iOS.Crashlytics //
//////////////////////////////////////

Xamarin.Firebase.iOS.Crashlytics NuGet has an MSBuild task that uploads the
dSYM symbols of your app to Firebase Console at build time.

This upload process happens only when building on Release.
If you want to upload the dSYM regardless of the configuration,
define the following property anywhere in your .csproj but before of the
Xamarin.Firebase.iOS.Crashlytics.targets import:

```
<PropertyGroup>
	<FirebaseCrashlyticsUploadSymbolsEnabled>True</FirebaseCrashlyticsUploadSymbolsEnabled>
</PropertyGroup>
```

If you want to disable the upload dSYM process, regardless of the configuration,
change the value from 'True' to 'False'.

Also, there's a property that helps you to keep building your app even if the
upload process fails. This is 'True' by default and the error will be treated as
a warning, but if you want it to be treated as an error, define the following
property anywhere in your .csproj but before of the
Xamarin.Firebase.iOS.Crashlytics.targets import:

```
<PropertyGroup>
	<FirebaseCrashlyticsUploadSymbolsContinueOnError>False</FirebaseCrashlyticsUploadSymbolsContinueOnError>
</PropertyGroup>
```
