With the Google Maps SDK for iOS, you can add maps based on Google maps data to your application.  The SDK automatically handles access to the Google Maps servers, map display, and response to user gestures such as clicks and drags. You can also add markers, polylines, ground overlays and info windows to your map.  These objects provide additional information for map locations, and allow user interaction with the map.

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
	
	CameraPosition camera = CameraPosition.FromCamera (latitude: 37.797865, 
			                                           longitude: -122.402526, 
			                                           zoom: 6);
	mapView = MapView.FromCamera (CGRect.Empty, camera);
	mapView.MyLocationEnabled = true;

	View = mapView;
}

public override void ViewWillAppear (bool animated)
{
	base.ViewWillAppear (animated);
	mapView.StartRendering ();
}

public override void ViewWillDisappear (bool animated)
{	
	mapView.StopRendering ();
	base.ViewWillDisappear (animated);
}
```

Attribution Requirements
========================

If you use the Google Maps SDK for iOS in your application, you must include the attribution text as part of a legal notices section in your application. Including legal notices as an independent menu item, or as part of an "About" menu item, is recommended.

You can get the attribution text by making a call to `Google.Maps.MapServices.OpenSourceLicenseInfo`
 
*Screenshots assembled with [PlaceIt](http://placeit.breezi.com/).*
