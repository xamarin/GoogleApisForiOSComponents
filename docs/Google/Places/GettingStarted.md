# Get Started with the Places API for iOS

> _**Note**_: _The Google Places API for iOS enforces a default limit of 1,000 requests per 24 hour period. You can request an increase by following a simple review process. See the instructions in the [usage limits][1] guide._

## Add Google Places for iOS to your project

### Via Components Store

1. In your Visual Studio project, do double click on **Components** folder.
2. If needed, click on **Log in to your Xamarin Account** button and enter your credentials.
3. Click on **Get More Components** button
4. Search for **Google Places for iOS** and click on the result
5. Click on **Add to App** 

### Via NuGet

1. In your Visual Studio project, do double click on **Packages** folder.
2. Search for **Xamarin.Google.iOS.Places**
3. Do double click on the result to install it or check the result and click on **Add Package** button

### Get an API key

To get started using the Google Places API for iOS, follow these steps to get an API key:

1. Go to the [Google API Console][2].
2. Create or select a project.
3. Click **Continue** to enable the Google Places API for iOS.
4. On the **Credentials** page, get an **API key**.
	
	Note: If you have a key with iOS restrictions, you may use that key. You can use the same key with any of your iOS applications within the same project.

5. From the dialog displaying the API key, select **Restrict key** to set an iOS restriction on the API key.
6. In the **Restrictions** section, select **iOS apps**, then enter your app's bundle identifier. For example: `com.example.helloplaces`.
7. Click **Save**.

Your new iOS key appears in the list of API keys for your project. An API key is a string of characters, something like this:

```
AaAaAaAaAa-AaAaAaAaAaAaAaAaAaAaAaAaAaAa
```

You can also [look up an existing key][3] in the Google API Console.

For more information on using the Google API Console, see [API Console Help][4].

### Add the API key to your application

The following code examples show how to add the API key to an application:

* Add the following namespace statement:

	```csharp
	using Google.Places;
	```

* Add the following to your `FinishedLaunching` method, replacing `YOUR_API_KEY` with your API key:

	```csharp
	PlacesClient.ProvideApiKey (YOUR_API_KEY);
	```

* If you are also using the Place Picker, you will need to add the Google.Maps components or NuGet and add your key again as shown here:

	```csharp
	using Google.Maps;

	MapServices.ProvideAPIKey (YOUR_API_KEY);
	```

---

# Place Picker

> **Deprecation notice: `PlacePicker` class**
> 
> _**Notice**_: _The implementation of the place picker has changed. As of version 2.3 of the Google Places API for iOS, the `PlacePicker` class is deprecated, replaced by `PlacePickerViewController` class. Use of the `PlacePicker` class will only be supported until May 1, 2018. We recommend that you update your code to use `PlacePickerViewController` when possible._

The place picker is a simple and yet flexible built-in UI widget, part of the Google Places API for iOS.

## Introducing the place picker

The `PlacePickerViewController` class provides a UI that displays an interactive map and a list of nearby places, including places corresponding to geographical addresses and local businesses. Users can choose a place, and your app can then retrieve the details of the selected place.

The place picker provides the following advantages over developing your own UI widget:

* The user experience is consistent with other apps using the place picker, including Google apps and third parties. This means users of your app already know how to interact with the place picker.
* The map is integrated into the place picker.
* Accessibility is built in.
* It saves development time.

The place picker features autocomplete functionality, which displays place predictions based on user search input. This functionality is present in all place picker integrations, so you don't need to do anything extra to enable autocomplete. For more information about autocomplete, go to [Place Autocomplete](#place-autocomplete) section below.

## Request location authorization

If your app uses the place picker, you must request permission to use location services. First add one or both of the following keys to your **Info.plist** file, to request 'when in use' or 'always' authorization:

* `NSLocationWhenInUseUsageDescription`
* `NSLocationAlwaysUsageDescription`

For the place picker, it's enough to request 'when in use' authorization, but you may want to request 'always' authorization for other functionality in your app. For each key, add a string informing the user why you need the location services. For example:

```xml
<key>NSLocationWhenInUseUsageDescription</key>
<string>Show your location on the map</string>
```

## Add a place picker

The code snippet below shows how to create a `PlacePickerViewController` instance centered at the current device location, and display details of the selected place:

```csharp
public partial class ViewController : UIViewController, IPlacePickerViewControllerDelegate
{
	partial void BtnPickPlace_TouchUpInside (UIButton sender)
	{
		var config = new PlacePickerConfig (null);
		placePickerViewController = new PlacePickerViewController (config) { Delegate = this };
		PresentViewController (placePickerViewController, true, null);
	}

	// To receive the results from the place picker 'self' will need to conform to
	// IPlacePickerViewControllerDelegate interface and implement this code.
	public void DidPickPlace (PlacePickerViewController viewController, Place place)
	{
		// Dismiss the place picker, as it cannot dismiss itself.
		DismissViewController (true, null);

		Console.WriteLine ($"Place name: {place.Name}");
		Console.WriteLine ($"Place address: {place.FormattedAddress}");
		Console.WriteLine ($"Place attributions: {place.Attributions}");
	}

	[Export ("placePickerDidCancel:")]
	void DidCancel (PlacePickerViewController viewController)
	{
		// Dismiss the place picker, as it cannot dismiss itself.
		DismissViewController (true, null);
		Console.WriteLine ("No place selected");
	}
}
```

As shown in the above code sample, you can initalize the place picker with a given configuration using a `PlacePickerConfig` object. If a value of `null` is assigned to the viewport, the place picker will center on the current device location. To center on a specific location, specify a **viewport** containing a `CoordinateBounds` object defining the initial rectangular map area to display. The following example shows creating a `CoordinateBounds` to center the map on Sydney, Australia:

```csharp
var center = new CLLocationCoordinate2D (-33.865143, 151.2099);
var northEast = new CLLocationCoordinate2D (center.Latitude + .001, center.Longitude + .001);
var southWest = new CLLocationCoordinate2D (center.Latitude - .001, center.Longitude - .001);
var viewport = new Google.Maps.CoordinateBounds (northEast, southWest);
var config = new PlacePickerConfig (viewport);
```

To be notified when the user selects a place you must set the delegate of the place picker to be an object implementing `IPlacePickerViewControllerDelegate` interface. When you do this your app will receive a callback to the `DidPickPlace` method implemented by the delegate and is passed the place the user selected. If the user did not select a place, `DidCancel` method is called instead.

As the place picker is a normal view controller it can be displayed any way you want. For example, in a popover, fullscreen, pushed onto a navigation stack, or even as part of a custom app UI. Because of this flexibility the place picker is unable to dismiss itself, so your app must programmatically dismiss it when `DidPickPlace` is called. In some cases it may be necessary to dismiss the place picker from `DidCancel` as well.

## Display attributions in your app

When your app displays information obtained via the place picker, the app must also display attributions. See this [Attribution's documentation][8] to learn more about this.

## Old Client Libraries

Prior to version 2.3 of the Google Places API for iOS `PlacePicker` was the only available way to use the place picker. This class has now been deprecated and it is recommended that `PlacePickerViewController` is used instead. This new class is more flexible and is not limited to being displayed full-screen.

---

# Current Place

Using the Google Places API for iOS, you can discover the place where the device is currently located. That is, the place at the device's currently-reported location. Examples of places include local businesses, points of interest, and geographic locations.

## Request location authorization

If your app uses `PlacesClient` `CurrentPlace` instance method, you must request permission to use location services. Add the `NSLocationWhenInUseUsageDescription` key to your **Info.plist** file, to define the string informing the user why you need the location services. For example:

```xml
<key>NSLocationWhenInUseUsageDescription</key>
<string>Show your location on the map</string>
```

If you want to call `PlacesClient` `CurrentPlace` instance method when the app is in the background, without triggering a confirmation dialog, take the following steps prior to making the call:

1. Add the `NSLocationAlwaysUsageDescription` key to your **Info.plist** file.
2. Call `RequestAlwaysAuthorization` on any instance of `CLLocationManager` before calling the method.

Request authorization from `CLLocationManager` as follows:

```csharp
locationManager.RequestAlwaysAuthorization ();
```

## Usage limits

Use of the `PlacesClient` `CurrentPlace` instance method is subject to tiered query limits. See the documentation on [usage limits][1].

## Get the current location

To find the local business or other place where the device is currently located, call `PlacesClient.CurrentPlace`. Include a callback method to handle the results.

The API invokes the specified callback method, passing in an array of `PlaceLikelihood` objects.

Each `PlaceLikelihood` object represents a place. For each place, the result includes an indication of the likelihood that the place is the right one. A higher value means a greater probability that the place is the best match. The buffer may be empty, if there is no known place corresponding to the device location.

The following code sample retrieves the list of places where the device is most likely to be located, and logs the name, likelihood, and other details for each place:

```csharp
placesClient.CurrentPlace ((likelihoodList, error) => {
	if (error != null) {
		Console.WriteLine ($"Pick Place error: {error.LocalizedDescription}");
		return;
	}

	foreach (var likelihood in likelihoodList?.Likelihoods) {
		var place = likelihood.Place;
		Console.WriteLine ($"Current Place name: {place.Name} at likelihood: {likelihood.Likelihood}");
		Console.WriteLine ($"Current Place address: {place.FormattedAddress}");
		Console.WriteLine ($"Current Place attributions: {place.Attributions}");
		Console.WriteLine ($"Current Place Id: {place.Id}");
	}
});
```

Notes about the likelihood values:

* The likelihood provides a relative probability of the place being the best match within the list of returned places for a single request. You can't compare likelihoods across different requests.
* The value of the likelihood will be between 0 and 1.0.
* The sum of the likelihoods in a returned array of `PlaceLikelihood` objects is always less than or equal to 1.0. Note that the sum isn't necessarily 1.0.

For example, to represent a 55% likelihood that the correct place is Place A, and a 35% likelihood that it's Place B, the likelihood array has two members: Place A with a likelihood of 0.55 and Place B with a likelihood of 0.35.

## Display attributions in your app

When your app displays information obtained from `PlacesClient` `CurrentPlace` instance method, the app must also display attributions. See this [Attribution's documentation][8] to learn more about this.

---

# Place Autocomplete

The autocomplete service in the Google Places API for iOS returns place predictions in response to user search queries. As the user types, the autocomplete service returns suggestions for places such as businesses, addresses and points of interest.

You can add autocomplete to your app in the following ways:

* Add an autocomplete UI control to save development time and ensure a consistent user experience.
* Get place predictions programmatically to create a customized user experience.

## Add an autocomplete UI control

The autocomplete UI control is a search dialog with built-in autocomplete functionality. As a user enters search terms, the control presents a list of predicted places to choose from. When the user makes a selection, a `Place` instance is returned, which your app can then use to get details about the selected place.

You can add the autocomplete UI control to your app in the following ways:

* Add a full-screen control
* Add a results controller
* Use a table data source

### Add a full-screen control

Use the full-screen control when you want a modal context, where the autocomplete UI temporarily replaces the UI of your app until the user has made their selection. This functionality is provided by the `AutocompleteViewController` class. When the user selects a place, your app receives a callback.

To add a full-screen control to your app:

* Create a UI element in your main app to launch the autocomplete UI control, for example a touch handler on a `UIButton`.
* Implement the `IAutocompleteViewControllerDelegate` interface in the parent view controller.
* Create an instance of `AutocompleteViewController` and assign the parent view controller as the `Delegate` property.
* Present the `AutocompleteViewController` using `PresentViewController` method.
* Handle the user's selection in the `DidAutocomplete` interface method.
* Dismiss the controller in the `DidAutocomplete`, `DidFailAutocomplete`, and `WasCancelled` interface methods.

The following example demonstrates one possible way to launch `AutocompleteViewController` in response to the user tapping on a button:

```csharp
using UIKit;
using Foundation;
using Google.Places;

public partial class ViewController : UIViewController, IAutocompleteViewControllerDelegate
{
	partial void BtnShow_TouchUpInside (UIButton sender)
	{
		var autocompleteViewController = new AutocompleteViewController { Delegate = this };
		PresentViewController (autocompleteViewController, true, null);
	}

	#region AutocompleteViewController Delegate

	public void DidAutocomplete (AutocompleteViewController viewController, Place place)
	{
		// Handle the user's selection.
		DismissViewController (true, null);
		Console.WriteLine ($"Place name: {place.Name}");
		Console.WriteLine ($"Place address: {place.FormattedAddress}");
		Console.WriteLine ($"Place attributions: {place.Attributions}");
	}

	public void DidFailAutocomplete (AutocompleteViewController viewController, NSError error)
	{
		// TODO: handle the error.
		DismissViewController (true, null);
		Console.WriteLine ($"Error: {error.LocalizedDescription}");
	}

	// User canceled the operation.
	public void WasCancelled (AutocompleteViewController viewController)
	{
		DismissViewController (true, null);
	}

	// Turn the network activity indicator on and off again.
	[Export ("didRequestAutocompletePredictions:")]
	public void DidRequestAutocompletePredictions (AutocompleteViewController viewController)
	{
		UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
	}

	[Export ("didUpdateAutocompletePredictions:")]
	public void DidUpdateAutocompletePredictions (AutocompleteViewController viewController)
	{
		UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
	}

	#endregion
}
```

### Add a results controller

Use a results controller when you want more control over the text input UI. The results controller dynamically toggles the visibility of the results list based on input UI focus.

To add a results controller to your app:

1. Create a `AutocompleteResultsViewController`.
2. Implement the `IAutocompleteResultsViewControllerDelegate` interface in the parent view controller and assign the parent view controller as the `Delegate` property.
3. Create a `UISearchController` object, passing in the `AutocompleteResultsViewController` as the results controller argument.
4. Set the `AutocompleteResultsViewController` as the `SearchResultsUpdater` property of the `UISearchController`.
5. Add the `SearchBar` for the `UISearchController` to your app's UI.
6. Handle the user's selection in the `DidAutocomplete` interface method.

There are several ways to place the search bar of a `UISearchController` into your app's UI:

* Add a search bar to the navigation bar
* Add a search bar to the top of a view
* Add a search bar using popover results

#### Add a search bar to the navigation bar

The following code example demonstrates adding a results controller, adding the `SearchBar` to the navigation bar, and handling the user's selection:

```csharp
using UIKit;
using Foundation;
using Google.Places;

public partial class ViewController : UIViewController, IAutocompleteResultsViewControllerDelegate
{
	UISearchController searchController;
	AutocompleteResultsViewController autocompleteResultsViewController;

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

		autocompleteResultsViewController = new AutocompleteResultsViewController { Delegate = this };
		searchController = new UISearchController (autocompleteResultsViewController) {
			// Prevent the navigation bar from being hidden when searching.
			HidesNavigationBarDuringPresentation = false,
			SearchResultsUpdater = autocompleteResultsViewController
		};

		// Put the search bar in the navigation bar.
		searchController.SearchBar.SizeToFit ();
		NavigationItem.TitleView = searchController.SearchBar;
		
		// When UISearchController presents the results view, present it in
		// this view controller, not one further up the chain.
		DefinesPresentationContext = true;
	}

	#region AutocompleteResultsViewController Delegate

	// Handle the user's selection.
	public void DidAutocomplete (AutocompleteResultsViewController resultsController, Place place)
	{
		searchController.Active = false;

		// Do something with the selected place.
		Console.WriteLine ($"Place name: {place.Name}");
		Console.WriteLine ($"Place address: {place.FormattedAddress}");
		Console.WriteLine ($"Place attributions: {place.Attributions}");
	}

	public void DidFailAutocomplete (AutocompleteResultsViewController resultsController, NSError error)
	{
		searchController.Active = false;

		// TODO: handle the error.
		Console.WriteLine ($"Error: {error.LocalizedDescription}");
	}

	// Turn the network activity indicator on and off again.
	[Export ("didRequestAutocompletePredictionsForResultsController:")]
	public void DidRequestAutocompletePredictions (AutocompleteResultsViewController resultsController) 
	{
		UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
	}

	[Export ("didUpdateAutocompletePredictionsForResultsController:")]
	public void DidUpdateAutocompletePredictions (AutocompleteResultsViewController resultsController) 
	{
		UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
	}

	#endregion
}
```

> _**Note:**_ _For the search bar to display properly, your app's view controller must be enclosed within a `UINavigationController`._

#### Add a search bar to the top of a view

The following code example shows adding the `SearchBar` to the top of a view:

```csharp
using UIKit;
using Foundation;
using CoreGraphics;
using Google.Places;

public partial class ViewController : UIViewController, IAutocompleteResultsViewControllerDelegate
{
	UISearchController searchController;
	AutocompleteResultsViewController autocompleteResultsViewController;

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

		autocompleteResultsViewController = new AutocompleteResultsViewController { Delegate = this };
		searchController = new UISearchController (autocompleteResultsViewController) {
			// Prevent the navigation bar from being hidden when searching.
			HidesNavigationBarDuringPresentation = false,
			SearchResultsUpdater = autocompleteResultsViewController
		};

		var subview = new UIView (new CGRect (0, 65, 350, 45));
		subview.AddSubview (searchController.SearchBar);
		View.AddSubview (subview);
		searchController.SearchBar.SizeToFit ();
		
		// When UISearchController presents the results view, present it in
		// this view controller, not one further up the chain.
		DefinesPresentationContext = true;
	}

	#region AutocompleteResultsViewController Delegate

	// Handle the user's selection.
	public void DidAutocomplete (AutocompleteResultsViewController resultsController, Place place)
	{
		searchController.Active = false;

		// Do something with the selected place.
		Console.WriteLine ($"Place name: {place.Name}");
		Console.WriteLine ($"Place address: {place.FormattedAddress}");
		Console.WriteLine ($"Place attributions: {place.Attributions}");
	}

	public void DidFailAutocomplete (AutocompleteResultsViewController resultsController, NSError error)
	{
		searchController.Active = false;

		// TODO: handle the error.
		Console.WriteLine ($"Error: {error.LocalizedDescription}");
	}

	// Turn the network activity indicator on and off again.
	[Export ("didRequestAutocompletePredictionsForResultsController:")]
	public void DidRequestAutocompletePredictions (AutocompleteResultsViewController resultsController) 
	{
		UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
	}

	[Export ("didUpdateAutocompletePredictionsForResultsController:")]
	public void DidUpdateAutocompletePredictions (AutocompleteResultsViewController resultsController) 
	{
		UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
	}

	#endregion
}
```

By default, `UISearchController` hides the navigation bar when presenting (this can be disabled). In cases where the navigation bar is visible and opaque, `UISearchController` does not set the placement correctly. Use the following code as a workaround:

```csharp
NavigationController.NavigationBar.Translucent = false;
searchController.HidesNavigationBarDuringPresentation = false;

// This makes the view area include the nav bar even though it is opaque.
// Adjust the view placement down.
ExtendedLayoutIncludesOpaqueBars = true;
EdgesForExtendedLayout = UIRectEdge.Top;
```

#### Add a search bar using popover results

The following code example shows placing a search bar on the right side of the navigation bar, and displaying results in a popover:

> _**Caution:**_ _Popovers will only appear on iPad, and on the iPhone 6+ in landscape mode. On all other devices this will fallback to a fullscreen view controller._

```csharp
```csharp
using UIKit;
using Foundation;
using CoreGraphics;
using Google.Places;

public partial class ViewController : UIViewController, IAutocompleteResultsViewControllerDelegate
{
	UISearchController searchController;
	AutocompleteResultsViewController autocompleteResultsViewController;

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

		autocompleteResultsViewController = new AutocompleteResultsViewController { Delegate = this };
		searchController = new UISearchController (autocompleteResultsViewController) {
			// Prevent the navigation bar from being hidden when searching.
			HidesNavigationBarDuringPresentation = false,
			ModalPresentationStyle = UIModalPresentationStyle.Popover,
			SearchResultsUpdater = autocompleteResultsViewController
		};

		// Add the search bar to the right of the nav bar,
		// use a popover to display the results.
		// Set an explicit size as we don't want to use the entire nav bar.
		searchController.SearchBar.Frame = new CGRect (0, 0, 250, 44);
		NavigationItem.RightBarButtonItem = new UIBarButtonItem (searchController.SearchBar);
		
		// When UISearchController presents the results view, present it in
		// this view controller, not one further up the chain.
		DefinesPresentationContext = true;
	}

	#region AutocompleteResultsViewController Delegate

	// Handle the user's selection.
	public void DidAutocomplete (AutocompleteResultsViewController resultsController, Place place)
	{
		searchController.Active = false;

		// Do something with the selected place.
		Console.WriteLine ($"Place name: {place.Name}");
		Console.WriteLine ($"Place address: {place.FormattedAddress}");
		Console.WriteLine ($"Place attributions: {place.Attributions}");
	}

	public void DidFailAutocomplete (AutocompleteResultsViewController resultsController, NSError error)
	{
		searchController.Active = false;

		// TODO: handle the error.
		Console.WriteLine ($"Error: {error.LocalizedDescription}");
	}

	// Turn the network activity indicator on and off again.
	[Export ("didRequestAutocompletePredictionsForResultsController:")]
	public void DidRequestAutocompletePredictions (AutocompleteResultsViewController resultsController) 
	{
		UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
	}

	[Export ("didUpdateAutocompletePredictionsForResultsController:")]
	public void DidUpdateAutocompletePredictions (AutocompleteResultsViewController resultsController) 
	{
		UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
	}

	#endregion
}
```

> _**Note:**_ _For the search bar to display properly, your app's view controller must be enclosed within a `UINavigationController`._

### Use a table data source

If your app must support iOS 7, you can use the `AutocompleteTableDataSource` class to drive the table view of a `UISearchDisplayController`.

* The use of `UISearchDisplayController` is recommended only for iOS 7 support. We recommend using `UISearchController` in all other cases.
* The full-screen control is also supported in iOS 7.

To use `AutocompleteTableDataSource` to display a search controller:

1. Implement the `IAutocompleteTableDataSourceDelegate` and `IUISearchDisplayDelegate` interfaces in the parent view controller.
2. Create a `AutocompleteTableDataSource` instance and assign the parent view controller as the `Delegate` property.
3. Create an instance of `UISearchDisplayController`.
4. Add the `SearchBar` for the `UISearchController` to your app's UI.
5. Handle the user's selection in the `DidAutocomplete` interface method.
6. Dismiss the controller in the `DidAutocomplete`, `DidFailAutocomplete`, and `WasCancelled` interface methods.

The following code example demonstrates using the `AutocompleteTableDataSource` class to drive the table view of a `UISearchDisplayController`.

```csharp
using UIKit;
using Foundation;
using CoreGraphics;
using Google.Places;

public partial class ViewController : UIViewController, IAutocompleteTableDataSourceDelegate, IUISearchDisplayDelegate
{
	UISearchBar searchBar;
	AutocompleteTableDataSource autocompleteTableDataSource;
	UISearchDisplayController searchDisplayController;

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
		// Perform any additional setup after loading the view, typically from a nib.

		searchBar = new UISearchBar (new CGRect (0, 0, 250, 44));
		autocompleteTableDataSource = new AutocompleteTableDataSource { Delegate = this };
		searchDisplayController = new UISearchDisplayController (searchBar, this) {
			SearchResultsDataSource = autocompleteTableDataSource,
			SearchResultsDelegate = autocompleteTableDataSource,
			Delegate = this
		};

		View.AddSubview (searchBar);
	}

	#region UISearchDisplay Delegate

	[Export ("searchDisplayController:shouldReloadTableForSearchString:")]
	public bool ShouldReloadForSearchString (UISearchDisplayController controller, string forSearchString)
	{
		return false;
	}

	#endregion

	#region AutocompleteTable Data Source Delegate

	public void DidAutocomplete (AutocompleteTableDataSource tableDataSource, Place place)
	{
		searchDisplayController.Active = false;

		// Do something with the selected place.
		Console.WriteLine ($"Place name: {place.Name}");
		Console.WriteLine ($"Place address: {place.FormattedAddress}");
		Console.WriteLine ($"Place attributions: {place.Attributions}");
	}

	public void DidFailAutocomplete (AutocompleteTableDataSource tableDataSource, NSError error)
	{
		searchDisplayController.Active = false;

		// TODO: handle the error.
		Console.WriteLine ($"Error: {error.LocalizedDescription}");
	}

	[Export ("tableDataSource:didSelectPrediction:")]
	public bool DidSelectPrediction (AutocompleteTableDataSource tableDataSource, AutocompletePrediction prediction)
	{
		return true;
	}

	[Export ("didRequestAutocompletePredictionsForTableDataSource:")]
	public void DidRequestAutocompletePredictions (AutocompleteTableDataSource tableDataSource)
	{
		// Turn the network activity indicator on.
		UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;

		// Reload table data.
		searchDisplayController.SearchResultsTableView.ReloadData ();
	}

	[Export ("didUpdateAutocompletePredictionsForTableDataSource:")]
	public void DidUpdateAutocompletePredictions (AutocompleteTableDataSource tableDataSource)
	{
		// Turn the network activity indicator off.
		UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;

		// Reload table data.
		searchDisplayController.SearchResultsTableView.ReloadData ();
	}

	#endregion
}
```

> _**Note:**_ _The `UISearchDisplayController` API does not support the concept of asynchronous data updates, so it is necessary to force table updates by reloading table data in the `DidUpdateAutocompletePredictions` and `DidRequestAutocompletePredictions` methods of the `IAutoCompleteResultsDelegate` interface._

## Get place predictions programmatically

You can create a custom search UI as an alternative to the UI provided by the autocomplete widget. To do this, your app must get place predictions programmatically. Your app can get a list of predicted place names and/or addresses in one of the following ways:

* Call `PlacesClient`
* Use the fetcher

### Call PlacesClient

To get a list of predicted place names and/or addresses, call the `PlacesClient` `Autocomplete` instance method with the following parameters:

* An `autocompleteQuery` string containing the text typed by the user.
* A `CoordinateBounds` object biasing the results to a specific area specified by latitude and longitude bounds.
* A `AutocompleteFilter` restricting the results to a specific type of place. To retrieve all types, supply a value of `null`. The following place types are supported in the filter:
	* `PlacesAutocompleteTypeFilter.NoFilter` – An empty filter; all results are returned.
	* `PlacesAutocompleteTypeFilter.Geocode` – Returns only geocoding results, rather than businesses. Use this request to disambiguate results where the specified location may be indeterminate.
	* `PlacesAutocompleteTypeFilter.Address` – Returns only autocomplete results with a precise address. Use this type when you know the user is looking for a fully specified address.
	* `PlacesAutocompleteTypeFilter.Establishment` – Returns only places that are businesses.
	* `PlacesAutocompleteTypeFilter.Region` – Returns only places that match one of the following types:
		* locality
		* sublocality
		* postal_code
		* country
		* administrative_area_level_1
		* administrative_area_level_2
	* `PlacesAutocompleteTypeFilter.City` – Returns only results matching `locality` or `administrative_area_level_3`.

For more information, see [place types][5].

* A callback method to handle the returned predictions.

The code examples below show a simplified call to `Autocomplete` method:

```csharp
void PlaceAutocomplete ()
{
	var filter = new AutocompleteFilter { Type = PlacesAutocompleteTypeFilter.Establishment };
	PlacesClient.SharedInstance.Autocomplete ("Sydney Oper", null, filter, AutocompletePredictionsHandler);

	void AutocompletePredictionsHandler (AutocompletePrediction [] results, NSError error)
	{
		if (error != null) {
			Console.WriteLine ($"Autocomplete error: {error.LocalizedDescription}");
			return;
		}

		foreach (var result in results)
			Console.WriteLine ($"Result: {result.AttributedFullText} with Place Id: {result.PlaceId}");
	}
}
```

The API invokes the specified callback method, passing in an array of `AutocompletePrediction` objects.

Each `AutocompletePrediction` object contains the following information:

* `AttributedFullText` – The full text of the prediction, in the form of an `NSAttributedString`. For example, 'Sydney Opera House, Sydney, New South Wales, Australia'. Every text range that matches the user input has an attribute, `AutocompleteMatchAttribute`. You can use this attribute to highlight the matching text in the user's query, for example, as shown below.
* `PlaceId` – The place ID of the predicted place. A place ID is a textual identifier that uniquely identifies a place. For more information about place IDs, see the [Place ID overview][6].

The following code example illustrates how to highlight in bold text the parts of the result that match text in the user's query, using EnumerateAttribute:

```csharp
var regularFont = UIFont.SystemFontOfSize (UIFont.LabelFontSize);
var boldFont = UIFont.BoldSystemFontOfSize (UIFont.LabelFontSize);

var bolded = prediction.AttributedFullText.MutableCopy () as NSMutableAttributedString;
bolded.EnumerateAttribute (AutocompletePrediction.AutocompleteMatchAttribute, new NSRange (0, bolded.Length), 0, EnumerateAttributeCallback);
label.AttributedText = bolded;

void EnumerateAttributeCallback (NSObject value, NSRange range, ref bool stop)
{
	var font = value == null ? regularFont : boldFont;
	bolded.AddAttribute (UIStringAttributeKey.Font, font, range);
}
```

### Use the fetcher

If you want to build your own autocomplete control from scratch, you can use `AutocompleteFetcher`, which wraps the `Autocomplete` method on `PlacesClient` class. The fetcher throttles requests, returning only results for the most recently entered search text. It provides no UI elements.

To implement `AutocompleteFetcher`, take the following steps:

1. Implement the `IAutocompleteFetcherDelegate` interface.
2. Create a `AutocompleteFetcher` object.
3. Call `SourceTextHasChanged` on the fetcher as the user types.
4. Handle predictions and errors using the `DidAutcomplete` and `DidFailAutocomplete` interface methods.

The following code example demonstrates using the fetcher to take user input and display place matches in a text view. Functionality for selecting a place has been omitted. `FetcherSampleViewController` derives from `UIViewController` in FetcherSampleViewController.h.

```csharp
using UIKit;
using Foundation;
using CoreLocation;
using CoreGraphics;
using Google.Places;
using Google.Maps;

public partial class FetcherSampleViewController : UIViewController, IAutocompleteFetcherDelegate
{
	UITextField textField;
	UITextView resultText;
	AutocompleteFetcher fetcher;

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
		// Perform any additional setup after loading the view, typically from a nib.

		View.BackgroundColor = UIColor.White;
		EdgesForExtendedLayout = UIRectEdge.All;

		// Set bounds to inner-west Sydney Australia.
		var neBoundsCorner = new CLLocationCoordinate2D (-33.843366, 151.134002);
		var swBoundsCorner = new CLLocationCoordinate2D (-33.875725, 151.200349);
		var bounds = new CoordinateBounds (neBoundsCorner, swBoundsCorner);

		// Set up the autocomplete filter.
		var filter = new AutocompleteFilter { Type = PlacesAutocompleteTypeFilter.Establishment };

		// Create the fetcher.
		fetcher = new AutocompleteFetcher (bounds, filter) { Delegate = this };

		textField = new UITextField (new CGRect (5, 10, View.Bounds.Width - 5, 44)) {
			AutoresizingMask = UIViewAutoresizing.FlexibleWidth
		};
		textField.ValueChanged += TextField_ValueChanged;

		resultText = new UITextView (new CGRect (0, 45, View.Bounds.Width, View.Bounds.Height - 45)) {
			BackgroundColor = UIColor.FromWhiteAlpha (.95f, 1),
			Text = "No Results",
			Editable = false
		};

		View.AddSubview (textField);
		View.AddSubview (resultText);
	}

	void TextField_ValueChanged (object sender, EventArgs e)
	{
		fetcher.SourceTextHasChanged (textField.Text);
	}

	#region AutocompleteFetcher Delegate

	public void DidAutocomplete (AutocompletePrediction [] predictions)
	{
		var results = string.Empty;
		foreach (var prediction in predictions)
			results += prediction.AttributedPrimaryText.Value;
		resultText.Text = results;
	}

	public void DidFailAutocomplete (NSError error)
	{
		resultText.Text = error.LocalizedDescription;
	}

	#endregion
}
```

## Set the CoordinateBounds of autocomplete

You can supply a `CoordinateBounds` to autocomplete to guide the supplied completions. For example, if you already have a Google Map in your view controller, you can use the bounds of the current viewport to bias autocomplete results:

```csharp
void PlaceAutocomplete ()
{
	var visibleRegion = mapView.Projection.VisibleRegion;
	var bounds = new Google.Maps.CoordinateBounds (visibleRegion.FarLeft, visibleRegion.NearRight);

	var filter = new AutocompleteFilter { Type = PlacesAutocompleteTypeFilter.Establishment };
	PlacesClient.SharedInstance.Autocomplete ("Sydney Oper", bounds, filter, AutocompletePredictionsHandler);

	void AutocompletePredictionsHandler (AutocompletePrediction [] results, NSError error)
	{
		if (error != null) {
			Console.WriteLine ($"Autocomplete error: {error.LocalizedDescription}");
			return;
		}

		foreach (var result in results)
			Console.WriteLine ($"Result: {result.AttributedFullText} with Place Id: {result.PlaceId}");
	}
}
```

## Usage limits

Use of the `PlacesClient` `Autocomplete` instance method is subject to tiered query limits. See the documentation on [usage limits][1].

## Display attributions in your app

* If your app uses the autocomplete service programmatically, your UI must either display a 'Powered by Google' attribution, or appear within a Google-branded map.
* If your app uses the autocomplete UI control no additional action is required (the required attribution is displayed by default).
* If you retrieve and display additional place information after getting a place by ID, you must display third-party attributions too.

See this [Attribution's documentation][8] to learn more about this.

## Controlling the network activity indicator

To control the network activity indicator in the applications status bar you must implement the appropriate optional delegate methods for the autocomplete class you are using and turn the network indicator on and off yourself.

* For `AutocompleteViewController` you must implement the interface methods `DidRequestAutocompletePredictions` and `DidUpdateAutocompletePredictions`.
* For `AutocompleteResultsViewController` you must implement the interface methods `DidRequestAutocompletePredictions` and `DidUpdateAutocompletePredictions`.
* For `AutocompleteTableDataSource` you must implement the delegate methods `DidRequestAutocompletePredictions` and `DidUpdateAutocompletePredictions`.

By implementing these methods and setting `UIApplication.SharedApplication.NetworkActivityIndicatorVisible` to `true` and `false` respectively the status bar will correctly match the autocomplete UI.

## Troubleshooting

Although a wide variety of errors can occur, the majority of the errors your app is likely to experience are usually caused by configuration errors (for example, the wrong API key was used, or the API key was configured incorrectly), or quota errors (your app has exceeded its quota). See [Usage Limits][1] for more information about quotas.

Errors that occur in the use of the autocomplete controls are returned in the `DidFailAutocomplete` method of the various interface protocols. The code property of the supplied `NSError` object is set to one of the values of the `PlacesErrorCode` enumeration.

---

# Place Photos

You can use the Google Places API for iOS to request place photos to display in your application. Photos returned by the photos service come from a variety of sources, including business owners and user-contributed photos. To retrieve images for a place, you must take the following steps:

1. Call `PlacesClient` `LookUpPhotos` instance method, passing a string with a place ID and a callback. This will call the callback with a `PlacePhotoMetadataList` object.
2. On the `PlacePhotoMetadataList` object access the `Results` property and select the photos to load from the array.
3. For each `PlacePhotoMetadata` to load from this list call `PlacesClient` `LoadPlacePhoto` instance method. These will call the callback with a usable UIImage.

> _**Note:**_ _Whenever you display a place photo make sure that the attribution guidelines are being followed. See this [Attribution's documentation][8] to learn more about this._

## Sample code

The following example method takes a place ID and gets the first photo in the returned list. You can use this method as a template for the method you will create in your own app:

```csharp
void LoadFirstPlacePhoto (string placeId)
{
	PlacesClient.SharedInstance.LookUpPhotos (placeId, PlacePhotoMetadataResultHandler);

	void PlacePhotoMetadataResultHandler (PlacePhotoMetadataList photos, NSError error)
	{
		if (error != null) {
			Console.WriteLine ($"Error: {error.LocalizedDescription}");
			return;
		}

		var firstPhoto = photos.Results.FirstOrDefault ();
		if (firstPhoto != null)
			LoadImage (firstPhoto);
	}
}

void LoadImage (PlacePhotoMetadata photoMetadata)
{
	PlacesClient.SharedInstance.LoadPlacePhoto (photoMetadata, PlacePhotoImageResultHandler);

	void PlacePhotoImageResultHandler (UIImage photo, NSError error)
	{
		if (error != null) {
			Console.WriteLine ($"Error: {error.LocalizedDescription}");
			return;
		}

		imageView.Image = photo;
		attributionTextView.AttributedText = photoMetadata.Attributions;
	}
}
```

## Caching

Photos loaded using `PlacesClient` `LoadPlacePhoto` instance method are cached both on disk and in-memory by the [Foundation URL loading system][7] in the shared `NSUrlCache`.

To configure the caching behavior you can change the shared URL cache using `NSUrlCache.SharedCache` in your application delegate's `FinishedLaunching` method.

If you do not want your application to share a `NSUrlCache` with the Google Places API for iOS you can create a new `NSUrlCache` and use this exclusively within your app without setting it as the shared cache.

## Attributions

In most cases, place photos can be used without attribution, or will have the required attribution included as part of the image. However, if the returned `PlacePhotoMetadata` instance includes an attribution, you must include the additional attribution in your application wherever you display the image. Note that links in the attribution must be tappable. See this [Attribution's documentation][8] to learn more about this.

## Usage limits

Retrieving an image costs one unit of quota; there are no usage limits for retrieving photo metadata. See the documentation on [usage limits][1].

---

# Place Report

An app can report that the device is currently located at a particular place. By reporting places that users have confirmed, you can help Google build a local model of the world. You should report that a device is at a place only if you're confident that the user is at the place, at the time when you report it.

To indicate that a device is located at a specific place, call `PlacesClient` `ReportDeviceAtPlace` instance method, passing the `placeId` of the place you are reporting. You can retrieve this place ID from the `Place` object. For more information about place IDs, see the [place ID overview][6].

Reporting the location of a device is similar to a checkin. It's not possible to retrieve the report later, and the report is not linked to the user's account.

The following sample reports that the device is at Darling Island Wharf, in Pyrmont, Australia:

```csharp
// Place ID for Darling Island Wharf Pyrmont
var placeId = "ChIJO1H1TzeuEmsR5bJONIMc4jk"
PlacesClient.SharedInstance.ReportDeviceAtPlace (placeId);
```

---

# Place IDs and Details

The Google Places API for iOS provides your app with rich information about places, including the place's name and address, the geographical location specified as latitude/longitude coordinates, the type of place (such as night club, pet store, museum), and more. To access this information for a specific place, you can use the place ID, a stable identifier that uniquely identifies a place.

## Place details

The `Place` class provides information about a specific place. You can get hold of a `Place` object in the following ways:

* Call `PlacesClient` `CurrentPlace` instance method. See the guide to [getting current place](#current-place).
* Add a `PlacePicker` UI widget, which allows the user to select a place. Call `PickPlace` and supply a callback to receive the chosen place. See the guide to [adding a place picker](#place-picker).
* Call `PlacesClient` `LookUpPlaceId` instance method, passing a place ID and a callback method. See the [Get a place by ID](#get-a-place-by-id) section below.

The `Place` class provides the following information:

* `Name` – The place's name.
* `Id` – The textual identifier for the place. Read more about place IDs in the rest of this page.
* `Coordinate` – The geographical location of the place, specified as latitude and longitude coordinates.
* `OpenNowStatus` – Indicates whether the place is open at the time when the request for place information is made.
* `PhoneNumber` – The place's phone number, in international format.
* `FormattedAddress` – The human-readable address of this location. 

	Often this address is equivalent to the postal address. Note that some countries, such as the United Kingdom, do not allow distribution of true postal addresses due to licensing restrictions.

	The formatted address is logically composed of one or more address components. For example, the address "111 8th Avenue, New York, NY" consists of the following components: "111" (the street number), "8th Avenue" (the route), "New York" (the city) and "NY" (the US state).

	Do not parse the formatted address programmatically. Instead you should use the individual address components, which the API response includes in addition to the formatted address field.

* Rating – An aggregated rating of the place, returned as a float with values ranging from 1.0 to 5.0, based on aggregated user reviews.
* PriceLevel – The price level for this place, returned as an integer with values ranging from 0 (cheapest) to 4 (most expensive).
* Types – A list of place types that characterize this place. See the documentation for the [supported types][9].
* Website – The URI of the place's website, if known. This is the website maintained by the business or other entity associated with the place.
* Attributions – An `NSAttributedString` containing the attributions that you must display to the user if your app uses place details retrieved from the Google Places API for iOS. For details on retrieving and displaying attributions, See this [Attribution's documentation][8] to learn more about this.
* AddressComponents – An array of `AddressComponent` objects representing components of the address for a place. These components are provided for the purpose of extracting structured information about a place's address, for example finding the city in which a place is located. Do not use these components for address formatting; instead, use the `FormattedAddress` property, which provides a localized formatted address.

	Note the following facts about the `AddressComponents` array:

	* The array of address components may contain more components than the `FormattedAddress`.
	* The array does not necessarily include all the political entities that contain an address, apart from those included in the `FormattedAddress`.
	* The format of the response is not guaranteed to remain the same between requests. In particular, the number of `AddressComponents` varies based on the address requested and can change over time for the same address. A component can change position in the array. The type of the component can change. A particular component may be missing in a later response.

## Get a place by ID

> _**Note:**_ _Use of the `PlacesClient` `LookUpPlaceId` instance method is subject to tiered query limits. See the documentation on [usage limits][1]._

A place ID is a textual identifier that uniquely identifies a place. In the Google Places API for iOS, you can retrieve the ID of a place from a `Place` object. You can store the place ID and use it to retrieve the `Place` object again later.

To get a place by ID, call `PlacesClient` `LookUpPlaceId` instance method, passing a place ID and a callback method.

The API invokes the specified callback method, passing in a `Place` object. If the place is not found, the place object is `null`.

```csharp
// A hotel in Saigon with an attribution.
var placeId = "ChIJV4k8_9UodTERU5KXbkYpSYs";
PlacesClient.SharedInstance.LookUpPlaceId (placeId, PlaceResultHandler);

void PlaceResultHandler (Place place, NSError error)
{
	if (error != null) {
		Console.WriteLine ($"Look up place id query error: {error.LocalizedDescription}");
		return;
	}

	if (place == null) {
		Console.WriteLine ($"No place details for {placeId}");
		return;
	}

	Console.WriteLine ($"Place name: {place.Name}");
	Console.WriteLine ($"Place address: {place.FormattedAddress}");
	Console.WriteLine ($"Place id: {place.Id}");
	Console.WriteLine ($"Place attributions: {place.Attributions}");
}
```

## Display attributions in your app

When your app displays information obtained from `PlacesClient` `LookUpPlaceId`, the app must also display attributions. See this [Attribution's documentation][8] to learn more about this.

## More about place IDs

The place ID used in the Google Places API for iOS is the same identifier as used in the [Google Places API Web Service, Google Places API for Android and other Google APIs][10].

There are some circumstances that may cause a place to get a new place ID. For example, this may happen if a business moves to a new location.

When you request a place by specifying a place ID, you can be confident that you will always receive the same place in the response (if the place still exists). Note, however, that the response may contain a place ID that is different from the one in your request.

For more information, see the [place ID overview][6].

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://developers.google.com/places/ios-api/start) to see original Google documentation._</sub>

[1]: https://developers.google.com/places/ios-api/usage
[2]: https://console.developers.google.com/flows/enableapi?apiid=placesios&reusekey=true
[3]: https://console.developers.google.com/project/_/apiui/credential
[4]: https://support.google.com/googleapi
[5]: https://developers.google.com/places/ios-api/supported_types#table3
[6]: https://developers.google.com/places/ios-api/place-id
[7]: https://developer.apple.com/library/ios/documentation/Cocoa/Conceptual/URLLoadingSystem/URLLoadingSystem.html
[8]: https://developers.google.com/places/ios-api/attributions
[9]: https://developers.google.com/places/ios-api/supported_types
[10]: https://developers.google.com/places/
