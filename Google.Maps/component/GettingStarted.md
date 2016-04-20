Showing a Map
=============

### AppDelegate

```csharp
using Google.Maps;
...

const string MapsApiKey = "<Get your ID at https://code.google.com/apis/console/>";

public override bool FinishedLaunching (UIApplication app, NSDictionary options)
{
	MapServices.ProvideAPIKey (MapsApiKey);
	...
}
```

### Your View Controller

```csharp
using Google.Maps;
...

MapView mapView;

public override void LoadView ()
{
	base.LoadView ();
	
	// Create a GMSCameraPosition that tells the map to display the
  	// coordinate 37.79,-122.40 at zoom level 6.
	var camera = CameraPosition.FromCamera (latitude: 37.79, 
			                                longitude: -122.40, 
			                                zoom: 6);
	mapView = MapView.FromCamera (CGRect.Empty, camera);
	mapView.MyLocationEnabled = true;
	View = mapView;
}
```

Attribution Requirements
========================

If you use the Google Maps SDK for iOS in your application, you must include the attribution text as part of a legal notices section in your application.  Including legal notices as an independent menu item, or as part of an "About" menu item, is recommended.

You can get the attribution text by making a call to `Google.Maps.MapServices.OpenSourceLicenseInfo`

Enable the required APIs on the Google Developers Console
===

You need to activate the Google Maps SDK for iOS, and optionally the Google Places API for iOS, in your project on the Google Developers Console.

If you want to be guided through the process and activate both the APIs automatically, click [this link][1].

Alternatively, you can activate the APIs yourself in the Developers Console, by doing the following:

- Go to the [Google Developers Console][2].
- Select a project, or create a new one.
- Enable the **Google Maps SDK for iOS**, and optionally the **Google Places API for iOS**: [Open the API Library][3] in the Google Developers Console. If prompted, select a project or create a new one. Select the **Enabled APIs** link in the API section to see a list of all your enabled APIs. Make sure that the API is on the list of enabled APIs. If you have not enabled it, select the API from the list of APIs, then select the **Enable API** button for the API.
 
The Google Maps API Key
=======================

Using an API key enables you to monitor your application's Maps API usage, and ensures that Google can contact you about your application if necessary. The key is free, you can use it with any of your applications that call the Maps API, and it supports an unlimited number of users. You obtain a Maps API key from the Google APIs Console by providing your application's bundle identifier. Once you have the key, you add it to your AppDelegate as described in the next section.

### Obtaining an API Key

You can obtain a key for your app in the [Google APIs Console](https://code.google.com/apis/console/).

1. Click on "Use Google APIs" blue card.
2. In the sidebar on the left, select Credentials.
3. If your project doesn't already have an iOS API key, create one now by selecting **Add credentials** > **API key** > **iOS key**.
4. In the resulting dialog, enter your app's bundle identifier, such as `com.example.myapp`.
5. Click **Create**.  Your new iOS API key appears in the list of API keys for your project.
6. Add your API key to your `AppDelegate` class as follows:

```csharp
using Google.Maps;
...

[Register ("AppDelegate")]
public partial class AppDelegate : UIApplicationDelegate
{
	const string MapsApiKey = "<Get your ID at https://code.google.com/apis/console/>";
	
	public override bool FinishedLaunching (UIApplication app, NSDictionary options)
	{
		MapServices.ProvideAPIKey (MapsApiKey);
		...
	}
}
```

Declare the URL schemes used by the API
===

With iOS 9, apps must declare the URL schemes that they intend to open, by specifying the schemes in the app's Info.plist file. The Google Maps SDK for iOS opens the Google Maps mobile app when the user clicks the Google logo on the map, and your app therefore needs to declare the relevant URL schemes.

To declare the URL schemes used by the Google Maps SDK for iOS, add the following lines to your Info.plist:

```xml
<key>LSApplicationQueriesSchemes</key>
<array>
    <string>googlechromes</string>
    <string>comgooglemaps</string>
</array>
```

[1]: https://console.developers.google.com/flows/enableapi?apiid=placesios,maps_ios_backend&keyType=CLIENT_SIDE_IOS
[2]: https://console.developers.google.com/
[3]: https://console.developers.google.com/project/_/apiui/apis/library