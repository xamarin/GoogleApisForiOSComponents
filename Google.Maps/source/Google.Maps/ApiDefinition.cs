using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreLocation;
using CoreAnimation;
using CoreGraphics;

namespace Google.Maps
{
	#region CustomLib
	// This is a custom class created by me (dalexsoto) and is not part of Google Maps lib
	// But it is necesary for this binding to work

	[Static]
	interface Constants
	{
		[Field ("kGMSLayerCameraLatitudeKey", "__Internal")]
		NSString LayerCameraLatitudeKey { get; }

		[Field ("kGMSLayerCameraLongitudeKey", "__Internal")]
		NSString LayerCameraLongitudeKey { get; }

		[Field ("kGMSLayerCameraBearingKey", "__Internal")]
		NSString LayerCameraBearingKey { get; }

		[Field ("kGMSLayerCameraZoomLevelKey", "__Internal")]
		NSString LayerCameraZoomLevelKey { get; }

		[Field ("kGMSLayerCameraViewingAngleKey", "__Internal")]
		NSString LayerCameraViewingAngleKey { get; }

		[Field ("kGMSMaxZoomLevel", "__Internal")]
		float MaxZoomLevel { get; }

		[Field ("kGMSMinZoomLevel", "__Internal")]
		float MinZoomLevel { get; }

		[Internal]
		[Field ("kGMSGroundOverlayDefaultAnchor", "__Internal")]
		IntPtr _GroundOverlayDefaultAnchor { get; }

		[Internal]
		[Field ("kGMSMarkerDefaultGroundAnchor", "__Internal")]
		IntPtr _MarkerDefaultGroundAnchor { get; }

		[Internal]
		[Field ("kGMSMarkerDefaultInfoWindowAnchor", "__Internal")]
		IntPtr _MarkerDefaultInfoWindowAnchor { get; }

		[Internal]
		[Field ("kGMSTileLayerNoTile", "__Internal")]
		IntPtr _TileLayerNoTile { get; }

		[Field ("kGMSLayerPanoramaFOVKey", "__Internal")]
		NSString LayerPanoramaFOVKey { get; }

		[Field ("kGMSLayerPanoramaHeadingKey", "__Internal")]
		NSString LayerPanoramaHeadingKey { get; }

		[Field ("kGMSLayerPanoramaPitchKey", "__Internal")]
		NSString LayerPanoramaPitchKey { get; }

		[Field ("kGMSLayerPanoramaZoomKey", "__Internal")]
		NSString LayerPanoramaZoomKey { get; }

		[Field ("kGMSMarkerLayerLatitude", "__Internal")]
		NSString MarkerLayerLatitude { get; }

		[Field ("kGMSMarkerLayerLongitude", "__Internal")]
		NSString MarkerLayerLongitude { get; }

		[Field ("kGMSMarkerLayerRotation", "__Internal")]
		NSString MarkerLayerRotation { get; }

		[Field ("kGMSAccessibilityCompass", "__Internal")]
		NSString AccessibilityCompass { get; }

		[Field ("kGMSAccessibilityMyLocation", "__Internal")]
		NSString AccessibilityMyLocation { get; }

		[Field ("kGMSEquatorProjectedMeter", "__Internal")]
		double EquatorProjectedMeter { get; }

		// extern NSString *const kGMSAutocompleteMatchAttribute;
		[Field ("kGMSAutocompleteMatchAttribute", "__Internal")]
		NSString AutocompleteMatchAttribute { get; }

		// extern NSString *const kGMSPlacePickerErrorDomain;
		[Field ("kGMSPlacePickerErrorDomain", "__Internal")]
		NSString PlacePickerErrorDomain { get; }

		// extern NSString *const kGMSPlacesErrorDomain;
		[Field ("kGMSPlacesErrorDomain", "__Internal")]
		NSString PlacesErrorDomain { get; }
	}

	#endregion

	[BaseType (typeof (NSObject), Name = "GMSAddress")]
	interface Address : INSCopying
	{

		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		[Export ("thoroughfare", ArgumentSemantic.Copy)]
		string Thoroughfare { get; }

		[Export ("locality", ArgumentSemantic.Copy)]
		string Locality { get; }

		[Export ("subLocality", ArgumentSemantic.Copy)]
		string SubLocality { get; }

		[Export ("administrativeArea", ArgumentSemantic.Copy)]
		string AdministrativeArea { get; }

		[Export ("postalCode", ArgumentSemantic.Copy)]
		string PostalCode { get; }

		[Export ("country", ArgumentSemantic.Copy)]
		string Country { get; }

		[Export ("lines", ArgumentSemantic.Copy)]
		string [] Lines { get; }

		[Obsolete ("Use Lines property instead")]
		[Export ("addressLine1")]
		string AddressLine1 { get; }

		[Obsolete ("Use Lines property instead")]
		[Export ("addressLine2")]
		string AddressLine2 { get; }
	}

	// @interface GMSAddressComponent : NSObject
	[BaseType (typeof (NSObject), Name = "GMSAddressComponent")]
	interface AddressComponent
	{
		// @property(nonatomic, readonly, copy) NSString *type;
		[Export ("type")]
		string Type { get; }

		// @property(nonatomic, readonly, copy) NSString *name;
		[Export ("name")]
		string Name { get; }
	}

	interface IAutocompleteFetcherDelegate
	{
	}

	// @protocol GMSAutocompleteFetcherDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteFetcherDelegate")]
	interface AutocompleteFetcherDelegate
	{
		// - (void)didAutocompleteWithPredictions:(NSArray *)predictions;
		[Abstract]
		[Export ("didAutocompleteWithPredictions:")]
		void DidAutocomplete (AutocompletePrediction [] predictions);

		// - (void)didFailAutocompleteWithError:(NSError *)error;
		[Abstract]
		[Export ("didFailAutocompleteWithError:")]
		void DidFailAutocomplete (NSError error);
	}

	// @interface GMSAutocompleteFetcher : NSObject
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteFetcher")]
	interface AutocompleteFetcher
	{
		// - (instancetype)initWithBounds:(GMSCoordinateBounds * GMS_NULLABLE_PTR)bounds filter:(GMSAutocompleteFilter * GMS_NULLABLE_PTR)filter;
		[Export ("initWithBounds:filter:")]
		IntPtr Constructor ([NullAllowed] CoordinateBounds bounds, [NullAllowed] AutocompleteFilter filter);

		// @property(nonatomic, weak) id<GMSAutocompleteFetcherDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAutocompleteFetcherDelegate Delegate { get; set; }

		// @property(nonatomic, strong) GMSCoordinateBounds *autocompleteBounds;
		[NullAllowed]
		[Export ("autocompleteBounds", ArgumentSemantic.Strong)]
		CoordinateBounds AutocompleteBounds { get; set; }

		// @property(nonatomic, strong) GMSAutocompleteFilter *autocompleteFilter;
		[NullAllowed]
		[Export ("autocompleteFilter", ArgumentSemantic.Strong)]
		AutocompleteFilter AutocompleteFilter { get; set; }

		// - (void)sourceTextHasChanged:(NSString *)text;
		[Export ("sourceTextHasChanged:")]
		void SourceTextHasChanged ([NullAllowed] string text);
	}

	// @interface GMSAutocompleteFilter : NSObject
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteFilter")]
	interface AutocompleteFilter
	{
		// @property (assign, nonatomic) GMSPlacesAutocompleteTypeFilter type;
		[Export ("type", ArgumentSemantic.Assign)]
		PlacesAutocompleteTypeFilter Type { get; set; }

		// @property(nonatomic, copy) NSString *country;
		[NullAllowed]
		[Export ("country", ArgumentSemantic.Copy)]
		string Country { get; set; }
	}

	// @interface GMSAutocompleteMatchFragment : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteMatchFragment")]
	interface AutocompleteMatchFragment
	{
		// @property (readonly, nonatomic) NSUInteger offset;
		[Export ("offset")]
		nuint Offset { get; }

		// @property (readonly, nonatomic) NSUInteger length;
		[Export ("length")]
		nuint Length { get; }
	}

	// @interface GMSAutocompletePrediction : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSAutocompletePrediction")]
	interface AutocompletePrediction
	{

		// @property (readonly, copy, nonatomic) NSAttributedString * attributedFullText;
		[Export ("attributedFullText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedFullText { get; }

		// @property(nonatomic, copy, readonly) NSAttributedString *attributedPrimaryText;
		[Export ("attributedPrimaryText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedPrimaryText { get; }

		// @property(nonatomic, copy, readonly) NSAttributedString *attributedSecondaryText;
		[Export ("attributedSecondaryText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedSecondaryText { get; }

		// @property (readonly, copy, nonatomic) NSString * placeID;
		[Export ("placeID", ArgumentSemantic.Copy)]
		string PlaceID { get; }

		// @property (readonly, copy, nonatomic) NSArray * types;
		[Export ("types", ArgumentSemantic.Copy)]
		string [] Types { get; }
	}

	interface IAutocompleteResultsViewControllerDelegate
	{
	}

	// @protocol GMSAutocompleteResultsViewControllerDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteResultsViewControllerDelegate")]
	interface AutocompleteResultsViewControllerDelegate
	{
		// @required - (void)resultsController:(GMSAutocompleteResultsViewController *)resultsController didAutocompleteWithPlace:(GMSPlace *)place;
		[Abstract]
		[EventArgs ("AutocompleteResultsViewControllerAutocompleted")]
		[EventName ("Autocompleted")]
		[Export ("resultsController:didAutocompleteWithPlace:")]
		void DidAutocomplete (AutocompleteResultsViewController resultsController, Place place);

		// @required - (void)resultsController:(GMSAutocompleteResultsViewController *)resultsController didFailAutocompleteWithError:(NSError *)error;
		[Abstract]
		[EventArgs ("AutocompleteResultsViewControllerAutocompleteFailed")]
		[EventName ("AutocompleteFailed")]
		[Export ("resultsController:didFailAutocompleteWithError:")]
		void DidFailAutocomplete (AutocompleteResultsViewController resultsController, NSError error);

		// @optional - (BOOL)resultsController:(GMSAutocompleteResultsViewController *)resultsController didSelectPrediction:(GMSAutocompletePrediction *)prediction;
		[DefaultValue (true)]
		[DelegateName ("AutocompleteResultsViewControllerPredictionSelected")]
		[Export ("resultsController:didSelectPrediction:")]
		bool DidSelectPrediction (AutocompleteResultsViewController resultsController, AutocompletePrediction prediction);

		// @optional - (void)didUpdateAutocompletePredictionsForResultsController:(GMSAutocompleteResultsViewController *)resultsController;
		[EventArgs ("AutocompleteResultsViewControllerAutocompletePredictionsUpdated")]
		[EventName ("AutocompletePredictionsUpdated")]
		[Export ("didUpdateAutocompletePredictionsForResultsController:")]
		void DidUpdateAutocompletePredictions (AutocompleteResultsViewController resultsController);

		// @optional - (void)didRequestAutocompletePredictionsForResultsController:(GMSAutocompleteResultsViewController *)resultsController;
		[EventArgs ("AutocompleteResultsViewControllerAutocompletePredictionsRequested")]
		[EventName ("AutocompletePredictionsRequested")]
		[Export ("didRequestAutocompletePredictionsForResultsController:")]
		void DidRequestAutocompletePredictions (AutocompleteResultsViewController resultsController);
	}

	// @interface GMSAutocompleteResultsViewController : UIViewController <UISearchResultsUpdating>
	[BaseType (typeof (UIViewController),
		Name = "GMSAutocompleteResultsViewController",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (AutocompleteResultsViewControllerDelegate) })]
	interface AutocompleteResultsViewController : IUISearchResultsUpdating
	{
		// @property(nonatomic, weak) id<GMSAutocompleteResultsViewControllerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAutocompleteResultsViewControllerDelegate Delegate { get; set; }

		// @property(nonatomic, strong) GMSCoordinateBounds *autocompleteBounds;
		[NullAllowed]
		[Export ("autocompleteBounds", ArgumentSemantic.Strong)]
		CoordinateBounds AutocompleteBounds { get; set; }

		// @property(nonatomic, strong) GMSAutocompleteFilter *autocompleteFilter;
		[NullAllowed]
		[Export ("autocompleteFilter", ArgumentSemantic.Strong)]
		AutocompleteFilter AutocompleteFilter { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellBackgroundColor;
		[Export ("tableCellBackgroundColor", ArgumentSemantic.Strong)]
		UIColor TableCellBackgroundColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellSeparatorColor;
		[Export ("tableCellSeparatorColor", ArgumentSemantic.Strong)]
		UIColor TableCellSeparatorColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextColor;
		[Export ("primaryTextColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextHighlightColor;
		[Export ("primaryTextHighlightColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextHighlightColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *secondaryTextColor;
		[Export ("secondaryTextColor", ArgumentSemantic.Strong)]
		UIColor SecondaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *GMS_NULLABLE_PTR tintColor;
		[NullAllowed]
		[Export ("tintColor", ArgumentSemantic.Strong)]
		UIColor TintColor { get; set; }
	}

	interface IAutocompleteTableDataSourceDelegate
	{
	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteTableDataSourceDelegate")]
	interface AutocompleteTableDataSourceDelegate
	{
		// @required - (void)tableDataSource:(GMSAutocompleteTableDataSource *)tableDataSource didAutocompleteWithPlace:(GMSPlace *)place;
		[Abstract]
		[EventArgs ("AutocompleteTableDataSourceAutocompleted")]
		[EventName ("Autocompleted")]
		[Export ("tableDataSource:didAutocompleteWithPlace:")]
		void DidAutocomplete (AutocompleteTableDataSource tableDataSource, Place place);

		// @required - (void)tableDataSource:(GMSAutocompleteTableDataSource *)tableDataSource didFailAutocompleteWithError:(NSError *)error;
		[Abstract]
		[EventArgs ("AutocompleteTableDataSourceAutocompleteFailed")]
		[EventName ("AutocompleteFailed")]
		[Export ("tableDataSource:didFailAutocompleteWithError:")]
		void DidFailAutocomplete (AutocompleteTableDataSource tableDataSource, NSError error);

		// @optional - (BOOL)tableDataSource:(GMSAutocompleteTableDataSource *)tableDataSource didSelectPrediction:(GMSAutocompletePrediction *)prediction;
		[DefaultValue (true)]
		[DelegateName ("AutocompleteTableDataSourcePredictionSelected")]
		[Export ("tableDataSource:didSelectPrediction:")]
		bool DidSelectPrediction (AutocompleteTableDataSource tableDataSource, AutocompletePrediction prediction);

		// @optional - (void)didUpdateAutocompletePredictionsForTableDataSource: (GMSAutocompleteTableDataSource *)tableDataSource;
		[EventArgs ("AutocompleteTableDataSourceAutocompletePredictionsUpdated")]
		[EventName ("AutocompletePredictionsUpdated")]
		[Export ("didUpdateAutocompletePredictionsForTableDataSource:")]
		void DidUpdateAutocompletePredictions (AutocompleteTableDataSource tableDataSource);

		// @optional - (void)didRequestAutocompletePredictionsForTableDataSource:(GMSAutocompleteTableDataSource *)tableDataSource;
		[EventArgs ("AutocompleteTableDataSourceAutocompletePredictionsRequested")]
		[EventName ("AutocompletePredictionsRequested")]
		[Export ("didRequestAutocompletePredictionsForTableDataSource:")]
		void DidRequestAutocompletePredictions (AutocompleteTableDataSource tableDataSource);
	}

	// @interface GMSAutocompleteTableDataSource : NSObject <UITableViewDataSource, UITableViewDelegate>
	[BaseType (typeof (NSObject),
		Name = "GMSAutocompleteTableDataSource",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (AutocompleteTableDataSourceDelegate) })]
	interface AutocompleteTableDataSource : IUITableViewDataSource, IUITableViewDelegate
	{
		// @property(nonatomic, weak) IBOutlet id<GMSAutocompleteTableDataSourceDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAutocompleteTableDataSourceDelegate Delegate { get; set; }

		// @property(nonatomic, strong) GMSCoordinateBounds *autocompleteBounds;
		[NullAllowed]
		[Export ("autocompleteBounds", ArgumentSemantic.Strong)]
		CoordinateBounds AutocompleteBounds { get; set; }

		// @property(nonatomic, strong) GMSAutocompleteFilter *autocompleteFilter;
		[NullAllowed]
		[Export ("autocompleteFilter", ArgumentSemantic.Strong)]
		AutocompleteFilter AutocompleteFilter { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellBackgroundColor;
		[Export ("tableCellBackgroundColor", ArgumentSemantic.Strong)]
		UIColor TableCellBackgroundColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellSeparatorColor;
		[Export ("tableCellSeparatorColor", ArgumentSemantic.Strong)]
		UIColor TableCellSeparatorColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextColor;
		[Export ("primaryTextColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextHighlightColor;
		[Export ("primaryTextHighlightColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextHighlightColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *secondaryTextColor;
		[Export ("secondaryTextColor", ArgumentSemantic.Strong)]
		UIColor SecondaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *GMS_NULLABLE_PTR tintColor;
		[NullAllowed]
		[Export ("tintColor", ArgumentSemantic.Strong)]
		UIColor TintColor { get; set; }

		// - (void)sourceTextHasChanged:(NSString *)text;
		[Export ("sourceTextHasChanged:")]
		void SourceTextHasChanged ([NullAllowed] string text);
	}

	interface IAutocompleteViewControllerDelegate
	{
	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteViewControllerDelegate")]
	interface AutocompleteViewControllerDelegate
	{
		// @required - (void)viewController:(GMSAutocompleteViewController *)viewController didAutocompleteWithPlace:(GMSPlace *)place;
		[Abstract]
		[EventArgs ("AutocompleteViewControllerAutocompleted")]
		[EventName ("Autocompleted")]
		[Export ("viewController:didAutocompleteWithPlace:")]
		void DidAutocomplete (AutocompleteViewController viewController, Place place);

		// @required - (void)viewController:(GMSAutocompleteViewController *)viewController didFailAutocompleteWithError:(NSError *)error;
		[Abstract]
		[EventArgs ("AutocompleteViewControllerAutocompleteFailed")]
		[EventName ("AutocompleteFailed")]
		[Export ("viewController:didFailAutocompleteWithError:")]
		void DidFailAutocomplete (AutocompleteViewController viewController, NSError error);

		// @required - (void)wasCancelled:(GMSAutocompleteViewController *)viewController;
		[Abstract]
		[EventArgs ("AutocompleteViewControllerWasCancelled")]
		[Export ("wasCancelled:")]
		void WasCancelled (AutocompleteViewController viewController);

		// @optional - (BOOL)viewController:(GMSAutocompleteViewController *)viewController didSelectPrediction:(GMSAutocompletePrediction *)prediction;
		[DefaultValue (true)]
		[DelegateName ("AutocompleteViewControllerPredictionSelected")]
		[Export ("viewController:didSelectPrediction:")]
		bool DidSelectPrediction (AutocompleteViewController viewController, AutocompletePrediction prediction);

		// @optional - (void)didUpdateAutocompletePredictions:(GMSAutocompleteViewController *)viewController;
		[EventArgs ("AutocompleteViewControllerAutocompletePredictionsUpdated")]
		[EventName ("AutocompletePredictionsUpdated")]
		[Export ("didUpdateAutocompletePredictions:")]
		void DidUpdateAutocompletePredictions (AutocompleteViewController viewController);

		// @optional - (void)didRequestAutocompletePredictions:(GMSAutocompleteViewController *)viewController;
		[EventArgs ("AutocompleteViewControllerPredictionsRequested")]
		[EventName ("AutocompletePredictionsRequested")]
		[Export ("didRequestAutocompletePredictions:")]
		void DidRequestAutocompletePredictions (AutocompleteViewController viewController);
	}

	// @interface GMSAutocompleteViewController : UIViewController
	[BaseType (typeof (UIViewController),
		Name = "GMSAutocompleteViewController")]
	interface AutocompleteViewController
	{
		// @property(nonatomic, weak) IBOutlet id<GMSAutocompleteViewControllerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAutocompleteViewControllerDelegate Delegate { get; set; }

		// @property(nonatomic, strong) GMSCoordinateBounds *autocompleteBounds;
		[NullAllowed]
		[Export ("autocompleteBounds", ArgumentSemantic.Strong)]
		CoordinateBounds AutocompleteBounds { get; set; }

		// @property(nonatomic, strong) GMSAutocompleteFilter *autocompleteFilter;
		[NullAllowed]
		[Export ("autocompleteFilter", ArgumentSemantic.Strong)]
		AutocompleteFilter AutocompleteFilter { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellBackgroundColor;
		[Export ("tableCellBackgroundColor", ArgumentSemantic.Strong)]
		UIColor TableCellBackgroundColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellSeparatorColor;
		[Export ("tableCellSeparatorColor", ArgumentSemantic.Strong)]
		UIColor TableCellSeparatorColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextColor;
		[Export ("primaryTextColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextHighlightColor;
		[Export ("primaryTextHighlightColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextHighlightColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *secondaryTextColor;
		[Export ("secondaryTextColor", ArgumentSemantic.Strong)]
		UIColor SecondaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *GMS_NULLABLE_PTR tintColor;
		[NullAllowed]
		[Export ("tintColor", ArgumentSemantic.Strong)]
		UIColor TintColor { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (CALayer), Name = "GMSCALayer")]
	interface Layer
	{
	}

	[BaseType (typeof (NSObject), Name = "GMSCameraPosition")]
	interface CameraPosition : INSCopying, INSMutableCopying
	{

		[Export ("target")]
		CLLocationCoordinate2D Target { get; }

		[Export ("zoom")]
		float Zoom { get; }

		[Export ("bearing")]
		double Bearing { get; }

		[Export ("viewingAngle")]
		double ViewingAngle { get; }

		[Export ("initWithTarget:zoom:bearing:viewingAngle:")]
		IntPtr Constructor (CLLocationCoordinate2D target, float zoom, double bearing, double viewingAngle);

		[Static, Export ("cameraWithTarget:zoom:")]
		CameraPosition FromCamera (CLLocationCoordinate2D target, float zoom);

		[Static, Export ("cameraWithLatitude:longitude:zoom:")]
		CameraPosition FromCamera (double latitude, double longitude, float zoom);

		[Static, Export ("cameraWithTarget:zoom:bearing:viewingAngle:")]
		CameraPosition FromCamera (CLLocationCoordinate2D target, float zoom, double bearing, double viewingAngle);

		[Static, Export ("cameraWithLatitude:longitude:zoom:bearing:viewingAngle:")]
		CameraPosition FromCamera (double latitude, double longitude, float zoom, double bearing, double viewingAngle);

		[Static, Export ("zoomAtCoordinate:forMeters:perPoints:")]
		float ZoomAtCoordinate (CLLocationCoordinate2D coord, double meters, nfloat points);
	}

	[BaseType (typeof (CameraPosition), Name = "GMSMutableCameraPosition")]
	interface MutableCameraPosition
	{

		[Export ("target", ArgumentSemantic.Assign)]
		[New]
		CLLocationCoordinate2D Target { get; set; }

		[Export ("zoom", ArgumentSemantic.Assign)]
		[New]
		float Zoom { get; set; }

		[Export ("bearing", ArgumentSemantic.Assign)]
		[New]
		double Bearing { get; set; }

		[Export ("viewingAngle", ArgumentSemantic.Assign)]
		[New]
		double ViewingAngle { get; set; }

	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSCameraUpdate")]
	interface CameraUpdate
	{

		[Static, Export ("zoomIn")]
		CameraUpdate ZoomIn { get; }

		[Static, Export ("zoomOut")]
		CameraUpdate ZoomOut { get; }

		[Static, Export ("zoomBy:")]
		CameraUpdate ZoomByDelta (float delta);

		[Static, Export ("zoomTo:")]
		CameraUpdate ZoomToZoom (float zoom);

		[Static, Export ("setTarget:")]
		CameraUpdate SetTarget (CLLocationCoordinate2D target);

		[Static, Export ("setTarget:zoom:")]
		CameraUpdate SetTarget (CLLocationCoordinate2D target, float zoom);

		[Static, Export ("setCamera:")]
		CameraUpdate SetCamera (CameraPosition camera);

		[Static, Export ("fitBounds:")]
		CameraUpdate FitBounds (CoordinateBounds bounds);

		[Static, Export ("fitBounds:withPadding:")]
		CameraUpdate FitBounds (CoordinateBounds bounds, nfloat padding);

		[Static, Export ("fitBounds:withEdgeInsets:")]
		CameraUpdate FitBounds (CoordinateBounds bounds, UIEdgeInsets edgeInsets);

		[Static, Export ("scrollByX:Y:")]
		CameraUpdate Scroll (nfloat x, nfloat y);

		[Static, Export ("zoomBy:atPoint:")]
		CameraUpdate ZoomByZoom (float zoom, CGPoint point);
	}

	[BaseType (typeof (Overlay), Name = "GMSCircle")]
	interface Circle
	{

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }

		[Export ("radius", ArgumentSemantic.Assign)]
		double Radius { get; set; }

		[Export ("strokeWidth", ArgumentSemantic.Assign)]
		nfloat StrokeWidth { get; set; }

		[NullAllowed]
		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[NullAllowed]
		[Export ("fillColor")]
		UIColor FillColor { get; set; }

		[Static, Export ("circleWithPosition:radius:")]
		Circle FromPosition (CLLocationCoordinate2D position, double radius);
	}

	[BaseType (typeof (NSObject), Name = "GMSCoordinateBounds")]
	interface CoordinateBounds
	{

		[Export ("northEast")]
		CLLocationCoordinate2D NorthEast { get; }

		[Export ("southWest")]
		CLLocationCoordinate2D SouthWest { get; }

		[Export ("valid")]
		bool Valid { [Bind ("isValid")] get; }

		[Export ("initWithCoordinate:coordinate:")]
		IntPtr Constructor (CLLocationCoordinate2D coord1, CLLocationCoordinate2D coord2);

		[Export ("initWithRegion:")]
		IntPtr Constructor (VisibleRegion region);

		[Export ("initWithPath:")]
		IntPtr Constructor (Google.Maps.Path path);

		[Export ("includingCoordinate:")]
		CoordinateBounds Including (CLLocationCoordinate2D coordinate);

		[Export ("includingBounds:")]
		CoordinateBounds Including (CoordinateBounds bounds);

		[Export ("includingPath:")]
		CoordinateBounds Including (Google.Maps.Path path);

		[Export ("containsCoordinate:")]
		bool ContainsCoordinate (CLLocationCoordinate2D coordinate);

		[Export ("intersectsBounds:")]
		bool IntersectsBounds (CoordinateBounds bounds);
	}

	delegate void ReverseGeocodeCallback (ReverseGeocodeResponse response, NSError error);

	[BaseType (typeof (NSObject), Name = "GMSGeocoder")]
	interface Geocoder
	{

		[Static, Export ("geocoder")]
		Geocoder SharedGeocoder { get; }

		[Export ("reverseGeocodeCoordinate:completionHandler:")]
		void ReverseGeocodeCord (CLLocationCoordinate2D coordinate, ReverseGeocodeCallback handler);
	}

	[BaseType (typeof (NSObject), Name = "GMSReverseGeocodeResponse")]
	interface ReverseGeocodeResponse : INSCopying
	{

		[Export ("firstResult")]
		Address FirstResult { get; }

		[Export ("results")]
		Address [] Results { get; }
	}

	[BaseType (typeof (Overlay), Name = "GMSGroundOverlay")]
	interface GroundOverlay
	{

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }

		[Export ("anchor", ArgumentSemantic.Assign)]
		CGPoint Anchor { get; set; }

		[NullAllowed]
		[Export ("icon")]
		UIImage Icon { get; set; }

		// @property(nonatomic, assign) float opacity;
		[Export ("opacity", ArgumentSemantic.Assign)]
		float Opacity { get; set; }

		[Export ("bearing", ArgumentSemantic.Assign)]
		double Bearing { get; set; }

		[NullAllowed]
		[Export ("bounds")]
		CoordinateBounds Bounds { get; set; }

		[Static]
		[Export ("groundOverlayWithBounds:icon:")]
		GroundOverlay GetGroundOverlay ([NullAllowed] CoordinateBounds bounds, [NullAllowed] UIImage icon);

		[Static]
		[Export ("groundOverlayWithPosition:icon:zoomLevel:")]
		GroundOverlay GetGroundOverlay (CLLocationCoordinate2D position, [NullAllowed] UIImage icon, nfloat zoomLevel);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSIndoorBuilding")]
	interface IndoorBuilding
	{
		[Export ("levels", ArgumentSemantic.Retain)]
		[PostGet ("Underground")]
		IndoorLevel [] Levels { get; }

		[Export ("defaultLevelIndex", ArgumentSemantic.Assign)]
		nuint DefaultLevelIndex { get; }

		[Export ("underground", ArgumentSemantic.Assign)]
		bool Underground { [Bind ("isUnderground")] get; }
	}

	interface IIndoorDisplayDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSIndoorDisplayDelegate")]
	interface IndoorDisplayDelegate
	{
		[Export ("didChangeActiveBuilding:")]
		void DidChangeActiveBuilding (IndoorBuilding building);

		[Export ("didChangeActiveLevel:")]
		void DidChangeActiveLevel (IndoorLevel level);
	}

	[BaseType (typeof (NSObject), Name = "GMSIndoorDisplay")]
	interface IndoorDisplay
	{
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Assign)]
		IIndoorDisplayDelegate Delegate { get; set; }

		[Export ("activeBuilding", ArgumentSemantic.Retain)]
		IndoorBuilding ActiveBuilding { get; }

		[Export ("activeLevel", ArgumentSemantic.Retain)]
		IndoorLevel ActiveLevel { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSIndoorLevel")]
	interface IndoorLevel
	{
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("shortName", ArgumentSemantic.Copy)]
		string ShortName { get; }
	}


	[BaseType (typeof (Layer), Name = "GMSMapLayer")]
	interface MapLayer
	{

		[Export ("cameraLatitude", ArgumentSemantic.Assign)]
		double CameraLatitude { get; set; }

		[Export ("cameraLongitude", ArgumentSemantic.Assign)]
		double CameraLongitude { get; set; }

		[Export ("cameraBearing", ArgumentSemantic.Assign)]
		double CameraBearing { get; set; }

		[Export ("cameraZoomLevel", ArgumentSemantic.Assign)]
		float CameraZoomLevel { get; set; }

		[Export ("cameraViewingAngle", ArgumentSemantic.Assign)]
		double CameraViewingAngle { get; set; }
	}

	interface IMapViewDelegate
	{

	}

	[BaseType (typeof (NSObject), Name = "GMSMapViewDelegate")]
	[Model]
	[Protocol]
	interface MapViewDelegate
	{
		[Export ("mapView:willMove:"), EventArgs ("GMSWillMove"), EventName ("WillMove")]
		void WillMove (MapView mapView, bool gesture);

		[Export ("mapView:didChangeCameraPosition:"), EventArgs ("GMSCamera"), EventName ("CameraPositionChanged")]
		void DidChangeCameraPosition (MapView mapView, CameraPosition position);

		[Export ("mapView:idleAtCameraPosition:"), EventArgs ("GMSCamera"), EventName ("CameraPositionIdle")]
		void IdleAtCameraPosition (MapView mapView, CameraPosition position);

		[Export ("mapView:didTapAtCoordinate:"), EventArgs ("GMSCoord"), EventName ("CoordinateTapped")]
		void DidTapAtCoordinate (MapView mapView, CLLocationCoordinate2D coordinate);

		[Export ("mapView:didLongPressAtCoordinate:"), EventArgs ("GMSCoord"), EventName ("CoordinateLongPressed")]
		void DidLongPressAtCoordinate (MapView mapView, CLLocationCoordinate2D coordinate);

		[Export ("mapView:didTapMarker:"), DelegateName ("GMSTappedMarker"), DefaultValue (false)]
		bool TappedMarker (MapView mapView, Marker marker);

		[Export ("mapView:didTapInfoWindowOfMarker:"), EventArgs ("GMSMarkerEvent"), EventName ("InfoTapped")]
		void DidTapInfoWindowOfMarker (MapView mapView, Marker marker);

		// - (void)mapView:(GMSMapView *)mapView didLongPressInfoWindowOfMarker:(GMSMarker *)marker;
		[Export ("mapView:didLongPressInfoWindowOfMarker:"), EventArgs ("GMSMarkerEvent"), EventName ("InfoLongPressed")]
		void DidLongPressInfoWindowOfMarker (MapView mapView, Marker marker);

		[Export ("mapView:didTapOverlay:"), EventArgs ("GMSOverlayEvent"), EventName ("OverlayTapped")]
		void DidTapOverlay (MapView mapView, Overlay overlay);

		[Export ("mapView:markerInfoWindow:"), DelegateName ("GMSInfoFor"), DefaultValue (null)]
		UIView MarkerInfoWindow (MapView mapView, Marker marker);

		[Export ("mapView:markerInfoContents:"), DelegateName ("GMSInfoFor"), DefaultValue (null)]
		UIView MarkerInfoContents (MapView mapView, Marker marker);

		// - (void)mapView:(GMSMapView *)mapView didCloseInfoWindowOfMarker:(GMSMarker *)marker;
		[Export ("mapView:didCloseInfoWindowOfMarker:"), EventArgs ("GMSMarkerEvent"), EventName ("InfoClosed")]
		void DidCloseInfoWindowOfMarker (MapView mapView, Marker marker);

		[Export ("mapView:didBeginDraggingMarker:"), EventArgs ("GMSMarkerEvent"), EventName ("DraggingMarkerStarted")]
		void DidBeginDraggingMarker (MapView mapView, Marker marker);

		[Export ("mapView:didEndDraggingMarker:"), EventArgs ("GMSMarkerEvent"), EventName ("DraggingMarkerEnded")]
		void DidEndDraggingMarker (MapView mapView, Marker marker);

		[Export ("mapView:didDragMarker:"), EventArgs ("GMSMarkerEvent"), EventName ("DraggingMarker")]
		void DidDragMarker (MapView mapView, Marker marker);

		[Export ("didTapMyLocationButtonForMapView:"), DelegateName ("GMSDidTapMyLocation"), DefaultValue (false)]
		bool DidTapMyLocationButton (MapView mapView);

		// - (void)mapViewDidStartTileRendering:(GMSMapView *)mapView;
		[Export ("mapViewDidStartTileRendering:"), EventArgs ("GMSTileRendering"), EventName ("TileRenderingStarted")]
		void DidStartTileRendering (MapView mapView);

		// - (void)mapViewDidFinishTileRendering:(GMSMapView *)mapView;
		[Export ("mapViewDidFinishTileRendering:"), EventArgs ("GMSTileRendering"), EventName ("TileRenderingEnded")]
		void DidFinishTileRendering (MapView mapView);

		// - (void)mapViewSnapshotReady:(GMSMapView *)mapView;
		[Export ("mapViewSnapshotReady:"), EventArgs ("GMSSnapshotReady")]
		void SnapshotReady (MapView mapView);
	}

	[BaseType (typeof (UIView), Name = "GMSMapView",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (MapViewDelegate) }
	)]
	interface MapView
	{

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		IMapViewDelegate Delegate { get; set; }

		[Export ("camera", ArgumentSemantic.Copy)]
		CameraPosition Camera { get; set; }

		[Export ("projection")]
		Projection Projection { get; }

		[Export ("myLocationEnabled", ArgumentSemantic.Assign)]
		bool MyLocationEnabled { [Bind ("isMyLocationEnabled")] get; set; }

		[Export ("myLocation")]
		CLLocation MyLocation { get; }

		[Export ("selectedMarker")]
		Marker SelectedMarker { get; [NullAllowed] set; }

		[Export ("trafficEnabled", ArgumentSemantic.Assign)]
		bool TrafficEnabled { [Bind ("isTrafficEnabled")] get; set; }

		[Export ("mapType", ArgumentSemantic.Assign)]
		MapViewType MapType { get; set; }

		[Export ("minZoom", ArgumentSemantic.Assign)]
		float MinZoom { get; }

		[Export ("maxZoom", ArgumentSemantic.Assign)]
		float MaxZoom { get; }

		[Export ("buildingsEnabled", ArgumentSemantic.Assign)]
		bool BuildingsEnabled { [Bind ("isBuildingsEnabled")] get; set; }

		[Export ("indoorEnabled", ArgumentSemantic.Assign)]
		bool IndoorEnabled { [Bind ("isIndoorEnabled")] get; set; }

		[Export ("indoorDisplay", ArgumentSemantic.Retain)]
		IndoorDisplay IndoorDisplay { get; }

		[Export ("settings")]
		UISettings Settings { get; }

		[Export ("padding", ArgumentSemantic.Assign)]
		UIEdgeInsets Padding { get; set; }

		[Export ("accessibilityElementsHidden", ArgumentSemantic.Assign)]
		[New]
		bool AccessibilityElementsHidden { get; set; }

		[Export ("layer", ArgumentSemantic.Retain)]
		[New]
		MapLayer Layer { get; }

		// @property(nonatomic, assign) GMSFrameRate preferredFrameRate;
		[Export ("preferredFrameRate", ArgumentSemantic.Assign)]
		FrameRate PreferredFrameRate { get; set; }

		[Static]
		[Export ("mapWithFrame:camera:")]
		MapView FromCamera (CGRect frame, CameraPosition camera);

		[Export ("startRendering")]
		[Obsolete ("Available but deprecated")]
		void StartRendering ();

		[Export ("stopRendering")]
		[Obsolete ("Available but deprecated")]
		void StopRendering ();

		[Export ("clear")]
		void Clear ();

		[Export ("setMinZoom:maxZoom:")]
		void SetMinMaxZoom (float minZoom, float maxZoom);

		[Export ("cameraForBounds:insets:")]
		CameraPosition CameraForBounds (CoordinateBounds bounds, UIEdgeInsets insets);

		[Export ("moveCamera:")]
		void MoveCamera (CameraUpdate update);
	}

	[BaseType (typeof (MapView))]
	[Category]
	interface MapViewAnimation
	{

		[Export ("animateToCameraPosition:")]
		void Animate (CameraPosition cameraPosition);

		[Export ("animateToLocation:")]
		void Animate (CLLocationCoordinate2D location);

		[Export ("animateToZoom:")]
		void Animate (float zoom);

		[Export ("animateToBearing:")]
		void AnimateToBearing (double bearing);

		[Export ("animateToViewingAngle:")]
		void Animate (double viewingAngle);

		[Export ("animateWithCameraUpdate:")]
		void Animate (CameraUpdate cameraUpdate);
	}

	[BaseType (typeof (Overlay), Name = "GMSMarker")]
	interface Marker
	{

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }

		[NullAllowed]
		[Export ("snippet", ArgumentSemantic.Copy)]
		string Snippet { get; set; }

		[NullAllowed]
		[Export ("icon", ArgumentSemantic.Strong)]
		UIImage Icon { get; set; }

		// @property(nonatomic, strong) UIView *iconView;
		[Export ("iconView", ArgumentSemantic.Strong)]
		UIView IconView { get; set; }

		// @property(nonatomic, assign) BOOL tracksViewChanges;
		[Export ("tracksViewChanges", ArgumentSemantic.Assign)]
		bool TracksViewChanges { get; set; }

		// @property(nonatomic, assign) BOOL tracksInfoWindowChanges;
		[Export ("tracksInfoWindowChanges", ArgumentSemantic.Assign)]
		bool TracksInfoWindowChanges { get; set; }

		[Export ("groundAnchor", ArgumentSemantic.Assign)]
		CGPoint GroundAnchor { get; set; }

		[Export ("infoWindowAnchor", ArgumentSemantic.Assign)]
		CGPoint InfoWindowAnchor { get; set; }

		[Export ("appearAnimation", ArgumentSemantic.Assign)]
		MarkerAnimation AppearAnimation { get; set; }

		[Export ("draggable", ArgumentSemantic.Assign)]
		bool Draggable { [Bind ("isDraggable")] get; set; }

		[Export ("flat", ArgumentSemantic.Assign)]
		bool Flat { [Bind ("isFlat")] get; set; }

		[Export ("rotation", ArgumentSemantic.Assign)]
		double Rotation { get; set; }

		[Export ("opacity", ArgumentSemantic.Assign)]
		float Opacity { get; set; }

		[NullAllowed]
		[Export ("userData", ArgumentSemantic.Strong)]
		NSObject UserData { get; set; }

		[Export ("layer", ArgumentSemantic.Strong)]
		MarkerLayer Layer { get; }

		[NullAllowed]
		[Export ("panoramaView", ArgumentSemantic.Weak)]
		PanoramaView PanoramaView { get; set; }

		[Static]
		[Export ("markerWithPosition:")]
		Marker FromPosition (CLLocationCoordinate2D position);

		[Static]
		[Export ("markerImageWithColor:")]
		UIImage MarkerImage ([NullAllowed] UIColor color);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (CALayer), Name = "GMSMarkerLayer")]
	interface MarkerLayer
	{

		[Export ("latitude", ArgumentSemantic.Assign)]
		double Latitude { get; set; }

		[Export ("longitude", ArgumentSemantic.Assign)]
		double Longitude { get; set; }

		[Export ("rotation", ArgumentSemantic.Assign)]
		double Rotation { get; set; }

		[Export ("opacity", ArgumentSemantic.Assign)]
		[New]
		float Opacity { get; set; }
	}

	[BaseType (typeof (Path), Name = "GMSMutablePath")]
	interface MutablePath
	{

		[Export ("addCoordinate:")]
		void AddCoordinate (CLLocationCoordinate2D coord);

		[Export ("addLatitude:longitude:")]
		void AddLatLon (double latitude, double longitude);

		[Export ("insertCoordinate:atIndex:")]
		void InsertCoordinate (CLLocationCoordinate2D coord, nuint index);

		[Export ("replaceCoordinateAtIndex:withCoordinate:")]
		void ReplaceCoordinate (nuint index, CLLocationCoordinate2D coord);

		[Export ("removeCoordinateAtIndex:")]
		void RemoveCoordinate (nuint index);

		[Export ("removeLastCoordinate")]
		void RemoveLastCoordinate ();

		[Export ("removeAllCoordinates")]
		void RemoveAllCoordinates ();
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSOverlay")]
	interface Overlay : INSCopying
	{
		[NullAllowed]
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[NullAllowed]
		[Export ("map")]
		MapView Map { get; set; }

		[Export ("tappable", ArgumentSemantic.Assign)]
		bool Tappable { [Bind ("isTappable")] get; set; }

		[Export ("zIndex", ArgumentSemantic.Assign)]
		int ZIndex { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPanorama")]
	interface Panorama
	{

		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		[Export ("panoramaID")]
		string PanoramaID { get; }

		[Export ("links", ArgumentSemantic.Copy)]
		PanoramaLink [] Links { get; }
	}

	[BaseType (typeof (NSObject), Name = "GMSPanoramaCamera")]
	interface PanoramaCamera
	{

		[Export ("initWithOrientation:zoom:FOV:")]
		IntPtr Constructor (Orientation orientation, float zoom, double fov);

		[Static]
		[Export ("cameraWithOrientation:zoom:")]
		PanoramaCamera FromOrientation (Orientation orientation, float zoom);

		[Static]
		[Export ("cameraWithHeading:pitch:zoom:")]
		PanoramaCamera FromHeading (double heading, double pitch, float zoom);

		[Static]
		[Export ("cameraWithOrientation:zoom:FOV:")]
		PanoramaCamera FromOrientation (Orientation orientation, float zoom, double fov);

		[Static]
		[Export ("cameraWithHeading:pitch:zoom:FOV:")]
		PanoramaCamera FromHeading (double heading, double pitch, float zoom, double fov);

		[Export ("FOV", ArgumentSemantic.Assign)]
		double Fov { get; }

		[Export ("zoom", ArgumentSemantic.Assign)]
		float Zoom { get; }

		[Export ("orientation", ArgumentSemantic.Assign)]
		Orientation Orientation { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPanoramaCameraUpdate")]
	interface PanoramaCameraUpdate
	{

		[Static]
		[Export ("rotateBy:")]
		PanoramaCameraUpdate Rotate (nfloat deltaHeading);

		[Static]
		[Export ("setHeading:")]
		PanoramaCameraUpdate SetHeading (nfloat heading);

		[Static]
		[Export ("setPitch:")]
		PanoramaCameraUpdate SetPitch (nfloat pitch);

		[Static]
		[Export ("setZoom:")]
		PanoramaCameraUpdate SetZoom (nfloat zoom);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (CALayer), Name = "GMSPanoramaLayer")]
	interface PanoramaLayer
	{

		[Export ("cameraHeading", ArgumentSemantic.Assign)]
		double CameraHeading { get; set; }

		[Export ("cameraPitch", ArgumentSemantic.Assign)]
		double CameraPitch { get; set; }

		[Export ("cameraZoom", ArgumentSemantic.Assign)]
		float CameraZoom { get; set; }

		[Export ("cameraFOV", ArgumentSemantic.Assign)]
		double CameraFOV { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GMSPanoramaLink")]
	interface PanoramaLink
	{

		[Export ("heading", ArgumentSemantic.Assign)]
		nfloat Heading { get; set; }

		[Export ("panoramaID", ArgumentSemantic.Copy)]
		string PanoramaID { get; set; }
	}

	delegate void PanoramaCallback (Panorama panorama, NSError error);

	[BaseType (typeof (NSObject), Name = "GMSPanoramaService")]
	interface PanoramaService
	{
		[Export ("requestPanoramaNearCoordinate:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, PanoramaCallback callback);

		[Export ("requestPanoramaNearCoordinate:radius:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, nuint radius, PanoramaCallback callback);

		[Export ("requestPanoramaWithID:callback:")]
		void RequestPanorama (string panoramaID, PanoramaCallback callback);
	}

	interface IPanoramaViewDelegate
	{

	}

	[BaseType (typeof (NSObject), Name = "GMSPanoramaViewDelegate")]
	[Model]
	[Protocol]
	interface PanoramaViewDelegate
	{

		[Export ("panoramaView:willMoveToPanoramaID:"), EventArgs ("GMSPanoramaWillMove")]
		void WillMoveToPanoramaId (PanoramaView view, string panoramaID);

		[Export ("panoramaView:didMoveToPanorama:"), EventArgs ("GMSPanoramaDidMoveToPanorama")]
		void DidMoveToPanorama (PanoramaView view, Panorama panorama);

		[Export ("panoramaView:didMoveToPanorama:nearCoordinate:"), EventArgs ("GMSPanoramaDidMoveToPanoramaNearCoordinate")]
		void DidMoveToPanoramaNearCoordinate (PanoramaView view, Panorama panorama, CLLocationCoordinate2D coordinate);

		[Export ("panoramaView:error:onMoveNearCoordinate:"), EventArgs ("GMSPanoramaOnMoveNearCoordinate")]
		void OnMoveNearCoordinate (PanoramaView view, NSError error, CLLocationCoordinate2D coordinate);

		[Export ("panoramaView:error:onMoveToPanoramaID:"), EventArgs ("GMSPanoramaOnMoveToPanoramaID")]
		void OnMoveToPanoramaID (PanoramaView view, NSError error, string panoramaId);

		[Export ("panoramaView:didMoveCamera:"), EventArgs ("GMSPanoramaDidMoveCamera")]
		void DidMoveCamera (PanoramaView view, PanoramaCamera camera);

		[Export ("panoramaView:didTap:"), EventArgs ("GMSPanoramaDidTap")]
		void DidTap (PanoramaView view, CGPoint point);

		[Export ("panoramaView:didTapMarker:"), DelegateName ("GMSTappedPanoramaMarker"), DefaultValue (false)]
		bool TappedMarker (PanoramaView view, Marker marker);

		// - (void)panoramaViewDidStartRendering:(GMSPanoramaView *)panoramaView;
		[Export ("panoramaViewDidStartRendering:"), EventArgs ("GMSPanoramaViewRendering"), EventName ("RenderingStarted")]
		void DidStartRendering (PanoramaView panoramaView);

		// - (void)panoramaViewDidFinishRendering:(GMSPanoramaView *)panoramaView;
		[Export ("panoramaViewDidFinishRendering:"), EventArgs ("GMSPanoramaViewRendering"), EventName ("RenderingEnded")]
		void DidFinishRendering (PanoramaView panoramaView);
	}

	[BaseType (typeof (UIView), Name = "GMSPanoramaView",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (PanoramaViewDelegate) }
	)]
	interface PanoramaView
	{

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[NullAllowed]
		[Export ("panorama", ArgumentSemantic.Retain)]
		Panorama Panorama { get; set; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Assign)]
		IPanoramaViewDelegate Delegate { get; set; }

		[Export ("setAllGesturesEnabled:")]
		void SetAllGesturesEnabled (bool enabled);

		[Export ("orientationGestures", ArgumentSemantic.Assign)]
		bool OrientationGestures { get; set; }

		[Export ("zoomGestures", ArgumentSemantic.Assign)]
		bool ZoomGestures { get; set; }

		[Export ("navigationGestures", ArgumentSemantic.Assign)]
		bool NavigationGestures { get; set; }

		[Export ("navigationLinksHidden", ArgumentSemantic.Assign)]
		bool NavigationLinksHidden { get; set; }

		[Export ("streetNamesHidden", ArgumentSemantic.Assign)]
		bool StreetNamesHidden { get; set; }

		[Export ("camera", ArgumentSemantic.Strong)]
		PanoramaCamera Camera { get; set; }

		[Export ("layer", ArgumentSemantic.Retain)]
		[New]
		PanoramaLayer Layer { get; set; }

		[Export ("animateToCamera:animationDuration:")]
		void AnimateToCamera (PanoramaCamera camera, double duration);

		[Export ("updateCamera:animationDuration:")]
		void UpdateCamera (PanoramaCameraUpdate cameraUpdate, double duration);

		[Export ("moveNearCoordinate:")]
		void MoveNearCoordinate (CLLocationCoordinate2D coordinate);

		[Export ("moveNearCoordinate:radius:")]
		void MoveNearCoordinate (CLLocationCoordinate2D coordinate, nuint radius);

		[Export ("moveToPanoramaID:")]
		void MoveToPanoramaId (string panoramaId);

		[Export ("pointForOrientation:")]
		CGPoint PointForOrientation (Orientation orientation);

		[Export ("orientationForPoint:")]
		Orientation OrientationForPoint (CGPoint point);

		[Static]
		[Export ("panoramaWithFrame:nearCoordinate:")]
		PanoramaView FromFrame (CGRect frame, CLLocationCoordinate2D coordinate);

		[Static]
		[Export ("panoramaWithFrame:nearCoordinate:radius:")]
		PanoramaView FromFrame (CGRect frame, CLLocationCoordinate2D coordinate, nuint radius);
	}

	[BaseType (typeof (NSObject), Name = "GMSPath")]
	interface Path : INSCopying, INSMutableCopying
	{

		[Static, Export ("path")]
		Path GetPath { get; }

		[Export ("initWithPath:")]
		IntPtr Constructor (Path path);

		[Export ("count")]
		nuint Count { get; }

		[Export ("coordinateAtIndex:")]
		CLLocationCoordinate2D CoordinateAtIndex (nuint index);

		[Static, Export ("pathFromEncodedPath:")]
		Path FromEncodedPath (string encodedPath);

		[Export ("encodedPath")]
		string EncodedPath { get; }

		[Export ("pathOffsetByLatitude:longitude:")]
		Path PathOffsetByLatitude (double deltaLatitude, double deltaLongitude);

		// GMSPath (GMSPathLength) Category

		[Export ("segmentsForLength:kind:")]
		double SegmentsForLength (double length, LengthKind kind);

		[Export ("lengthOfKind:")]
		double LengthOfKind (LengthKind kind);
	}

	// @interface GMSPlace : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPlace")]
	interface Place
	{
		// @property (readonly, copy, nonatomic) NSString * name;
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * placeID;
		[Export ("placeID", ArgumentSemantic.Copy)]
		string PlaceID { get; }

		// @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Coordinate { get; }

		// @property (readonly, nonatomic) GMSPlacesOpenNowStatus openNowStatus;
		[Export ("openNowStatus", ArgumentSemantic.Assign)]
		PlacesOpenNowStatus OpenNowStatus { get; }

		// @property (readonly, copy, nonatomic) NSString * phoneNumber;
		[Export ("phoneNumber", ArgumentSemantic.Copy)]
		string PhoneNumber { get; }

		// @property (readonly, copy, nonatomic) NSString * formattedAddress;
		[Export ("formattedAddress", ArgumentSemantic.Copy)]
		string FormattedAddress { get; }

		// @property (readonly, nonatomic) float rating;
		[Export ("rating", ArgumentSemantic.Assign)]
		float Rating { get; }

		// @property (readonly, nonatomic) GMSPlacesPriceLevel priceLevel;
		[Export ("priceLevel", ArgumentSemantic.Assign)]
		PlacesPriceLevel PriceLevel { get; }

		// @property (readonly, copy, nonatomic) NSArray * types;
		[Export ("types", ArgumentSemantic.Copy)]
		string [] Types { get; }

		// @property (readonly, copy, nonatomic) NSURL * website;
		[Export ("website", ArgumentSemantic.Copy)]
		NSUrl Website { get; }

		// @property (readonly, copy, nonatomic) NSAttributedString * attributions;
		[Export ("attributions", ArgumentSemantic.Copy)]
		NSAttributedString Attributions { get; }

		// @property(nonatomic, strong, readonly) GMSCoordinateBounds *viewport;
		[Export ("viewport", ArgumentSemantic.Strong)]
		CoordinateBounds Viewport { get; }

		// @property(nonatomic, copy, readonly) GMS_NSArrayOf(GMSAddressComponent *) *GMS_NULLABLE_PTR addressComponents;
		[NullAllowed]
		[Export ("addressComponents", ArgumentSemantic.Copy)]
		AddressComponent [] AddressComponents { get; }
	}

	// @interface GMSPlaceLikelihood : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPlaceLikelihood")]
	interface PlaceLikelihood : INSCopying
	{
		// @property (readonly, nonatomic, strong) GMSPlace * place;
		[Export ("place", ArgumentSemantic.Strong)]
		Place Place { get; }

		// @property (readonly, assign, nonatomic) double likelihood;
		[Export ("likelihood")]
		double Likelihood { get; }

		// -(instancetype)initWithPlace:(GMSPlace *)place likelihood:(double)likelihood;
		[Export ("initWithPlace:likelihood:")]
		IntPtr Constructor (Place place, double likelihood);
	}

	// @interface GMSPlaceLikelihoodList : NSObject
	[BaseType (typeof (NSObject), Name = "GMSPlaceLikelihoodList")]
	interface PlaceLikelihoodList
	{
		// @property (copy, nonatomic) NSArray * likelihoods;
		[Export ("likelihoods", ArgumentSemantic.Copy)]
		PlaceLikelihood [] Likelihoods { get; set; }

		// @property (readonly, copy, nonatomic) NSAttributedString * attributions;
		[Export ("attributions", ArgumentSemantic.Copy)]
		NSAttributedString Attributions { get; }
	}

	// @interface GMSPlacePhotoMetadata : NSObject
	[BaseType (typeof (NSObject), Name = "GMSPlacePhotoMetadata")]
	interface PlacePhotoMetadata
	{
		// @property(nonatomic, readonly, copy) NSAttributedString* GMS_NULLABLE_PTR attributions;
		[Export ("attributions", ArgumentSemantic.Copy)]
		NSAttributedString Attributions { get; }

		// @property(nonatomic, readonly, assign) CGSize maxSize;
		[Export ("maxSize", ArgumentSemantic.Assign)]
		CGSize MaxSize { get; }
	}

	// @interface GMSPlacePhotoMetadataList : NSObject
	[BaseType (typeof (NSObject), Name = "GMSPlacePhotoMetadataList")]
	interface PlacePhotoMetadataList
	{
		// @property(nonatomic, readonly, copy) GMS_NSArrayOf(GMSPlacePhotoMetadata *) * results;
		[Export ("results", ArgumentSemantic.Copy)]
		PlacePhotoMetadata [] Results { get; }
	}

	// typedef void (^GMSPlaceResultCallback)(GMSPlace *NSError *);
	delegate void PlaceResultHandler (Place result, NSError error);

	// @interface GMSPlacePicker : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPlacePicker")]
	interface PlacePicker
	{
		// @property (readonly, copy, nonatomic) GMSPlacePickerConfig * config;
		[Export ("config", ArgumentSemantic.Copy)]
		PlacePickerConfig Config { get; }

		// -(instancetype)initWithConfig:(GMSPlacePickerConfig *)config;
		[Export ("initWithConfig:")]
		IntPtr Constructor (PlacePickerConfig config);

		// -(void)pickPlaceWithCallback:(GMSPlaceResultCallback)callback;
		[Export ("pickPlaceWithCallback:")]
		void PickPlaceWithCallback (PlaceResultHandler callback);
	}

	// @interface GMSPlacePickerConfig : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPlacePickerConfig")]
	interface PlacePickerConfig
	{
		// @property (readonly, nonatomic, strong) GMSCoordinateBounds * viewport;
		[Export ("viewport", ArgumentSemantic.Strong)]
		CoordinateBounds Viewport { get; }

		// -(instancetype)initWithViewport:(GMSCoordinateBounds *)viewport;
		[Export ("initWithViewport:")]
		IntPtr Constructor ([NullAllowed] CoordinateBounds viewport);
	}

	// typedef void (^GMSPlaceLikelihoodListCallback)(GMSPlaceLikelihoodList *NSError *);
	delegate void PlaceLikelihoodListHandler (PlaceLikelihoodList likelihoodList, NSError error);

	// typedef void (^GMSAutocompletePredictionsCallback)(NSArray *NSError *);
	delegate void AutocompletePredictionsHandler (AutocompletePrediction [] results, NSError error);

	// typedef void (^GMSPlacePhotoMetadataResultCallback)(GMSPlacePhotoMetadataList *GMS_NULLABLE_PTR photos, NSError *GMS_NULLABLE_PTR error);
	delegate void PlacePhotoMetadataResultHandler (PlacePhotoMetadataList photos, NSError error);

	// typedef void (^GMSPlacePhotoImageResultCallback)(UIImage *GMS_NULLABLE_PTR photo, NSError *GMS_NULLABLE_PTR error);
	delegate void PlacePhotoImageResultHandler (UIImage photo, NSError error);

	// @interface GMSPlacesClient : NSObject
	[BaseType (typeof (NSObject), Name = "GMSPlacesClient")]
	interface PlacesClient
	{
		// +(instancetype)sharedClient;
		[Static]
		[Export ("sharedClient")]
		PlacesClient SharedClient ();

		// + (BOOL)provideAPIKey:(NSString *)key;
		[Static]
		[Export ("provideAPIKey:")]
		bool ProvideApiKey (string key);

		// + (NSString *)openSourceLicenseInfo;
		[Static]
		[Export ("openSourceLicenseInfo")]
		string OpenSourceLicenseInfo { get; }

		// + (NSString *)SDKVersion;
		[Static]
		[Export ("SDKVersion")]
		string SdkVersion { get; }

		// -(void)reportDeviceAtPlaceWithID:(NSString *)placeID;
		[Export ("reportDeviceAtPlaceWithID:")]
		void ReportDeviceAtPlace (string placeID);

		// -(void)lookUpPlaceID:(NSString *)placeID callback:(GMSPlaceResultCallback)callback;
		[Export ("lookUpPlaceID:callback:")]
		void LookUpPlaceID (string placeID, PlaceResultHandler callback);

		// - (void)lookUpPhotosForPlaceID:(NSString *)placeID callback:(GMSPlacePhotoMetadataResultCallback)callback;
		[Export ("lookUpPhotosForPlaceID:callback:")]
		void LookUpPhotos (string placeID, PlacePhotoMetadataResultHandler callback);

		// - (void)loadPlacePhoto:(GMSPlacePhotoMetadata *)photo callback:(GMSPlacePhotoImageResultCallback)callback;
		[Export ("loadPlacePhoto:callback:")]
		void LoadPlacePhoto (PlacePhotoMetadata photo, PlacePhotoImageResultHandler callback);

		// - (void)loadPlacePhoto:(GMSPlacePhotoMetadata *)photo constrainedToSize:(CGSize)maxSize scale:(CGFloat)scale callback:(GMSPlacePhotoImageResultCallback)callback;
		[Export ("loadPlacePhoto:constrainedToSize:scale:callback:")]
		void LoadPlacePhoto (PlacePhotoMetadata photo, CGSize maxSize, nfloat scale, PlacePhotoImageResultHandler callback);

		// -(void)currentPlaceWithCallback:(GMSPlaceLikelihoodListCallback)callback;
		[Export ("currentPlaceWithCallback:")]
		void CurrentPlace (PlaceLikelihoodListHandler callback);

		// -(void)autocompleteQuery:(NSString *)query bounds:(GMSCoordinateBounds *)bounds filter:(GMSAutocompleteFilter *)filter callback:(GMSAutocompletePredictionsCallback)callback;
		[Export ("autocompleteQuery:bounds:filter:callback:")]
		void AutocompleteQuery (string query, CoordinateBounds bounds, AutocompleteFilter filter, AutocompletePredictionsHandler callback);

		// -(void)addPlace:(GMSUserAddedPlace *)place callback:(GMSPlaceResultCallback)callback;
		[Export ("addPlace:callback:")]
		void AddPlace (UserAddedPlace place, PlaceResultHandler callback);
	}

	[Static]
	interface PlaceTypes
	{
		// -(NSString *)kGMSPlaceTypeAccountingExported;
		[Field ("kGMSPlaceTypeAccounting", "__Internal")]
		NSString Accounting { get; }

		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel1Exported;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel1", "__Internal")]
		NSString AdministrativeAreaLevel1 { get; }

		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel2Exported;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel2", "__Internal")]
		NSString AdministrativeAreaLevel2 { get; }

		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel3Exported;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel3", "__Internal")]
		NSString AdministrativeAreaLevel3 { get; }

		// -(NSString *)kGMSPlaceTypeAirportExported;
		[Field ("kGMSPlaceTypeAirport", "__Internal")]
		NSString Airport { get; }

		// -(NSString *)kGMSPlaceTypeAmusementParkExported;
		[Field ("kGMSPlaceTypeAmusementPark", "__Internal")]
		NSString AmusementPark { get; }

		// -(NSString *)kGMSPlaceTypeAquariumExported;
		[Field ("kGMSPlaceTypeAquarium", "__Internal")]
		NSString Aquarium { get; }

		// -(NSString *)kGMSPlaceTypeArtGalleryExported;
		[Field ("kGMSPlaceTypeArtGallery", "__Internal")]
		NSString ArtGallery { get; }

		// -(NSString *)kGMSPlaceTypeAtmExported;
		[Field ("kGMSPlaceTypeAtm", "__Internal")]
		NSString Atm { get; }

		// -(NSString *)kGMSPlaceTypeBakeryExported;
		[Field ("kGMSPlaceTypeBakery", "__Internal")]
		NSString Bakery { get; }

		// -(NSString *)kGMSPlaceTypeBankExported;
		[Field ("kGMSPlaceTypeBank", "__Internal")]
		NSString Bank { get; }

		// -(NSString *)kGMSPlaceTypeBarExported;
		[Field ("kGMSPlaceTypeBar", "__Internal")]
		NSString Bar { get; }

		// -(NSString *)kGMSPlaceTypeBeautySalonExported;
		[Field ("kGMSPlaceTypeBeautySalon", "__Internal")]
		NSString BeautySalon { get; }

		// -(NSString *)kGMSPlaceTypeBicycleStoreExported;
		[Field ("kGMSPlaceTypeBicycleStore", "__Internal")]
		NSString BicycleStore { get; }

		// -(NSString *)kGMSPlaceTypeBookStoreExported;
		[Field ("kGMSPlaceTypeBookStore", "__Internal")]
		NSString BookStore { get; }

		// -(NSString *)kGMSPlaceTypeBowlingAlleyExported;
		[Field ("kGMSPlaceTypeBowlingAlley", "__Internal")]
		NSString BowlingAlley { get; }

		// -(NSString *)kGMSPlaceTypeBusStationExported;
		[Field ("kGMSPlaceTypeBusStation", "__Internal")]
		NSString BusStation { get; }

		// -(NSString *)kGMSPlaceTypeCafeExported;
		[Field ("kGMSPlaceTypeCafe", "__Internal")]
		NSString Cafe { get; }

		// -(NSString *)kGMSPlaceTypeCampgroundExported;
		[Field ("kGMSPlaceTypeCampground", "__Internal")]
		NSString Campground { get; }

		// -(NSString *)kGMSPlaceTypeCarDealerExported;
		[Field ("kGMSPlaceTypeCarDealer", "__Internal")]
		NSString CarDealer { get; }

		// -(NSString *)kGMSPlaceTypeCarRentalExported;
		[Field ("kGMSPlaceTypeCarRental", "__Internal")]
		NSString CarRental { get; }

		// -(NSString *)kGMSPlaceTypeCarRepairExported;
		[Field ("kGMSPlaceTypeCarRepair", "__Internal")]
		NSString CarRepair { get; }

		// -(NSString *)kGMSPlaceTypeCarWashExported;
		[Field ("kGMSPlaceTypeCarWash", "__Internal")]
		NSString CarWash { get; }

		// -(NSString *)kGMSPlaceTypeCasinoExported;
		[Field ("kGMSPlaceTypeCasino", "__Internal")]
		NSString Casino { get; }

		// -(NSString *)kGMSPlaceTypeCemeteryExported;
		[Field ("kGMSPlaceTypeCemetery", "__Internal")]
		NSString Cemetery { get; }

		// -(NSString *)kGMSPlaceTypeChurchExported;
		[Field ("kGMSPlaceTypeChurch", "__Internal")]
		NSString Church { get; }

		// -(NSString *)kGMSPlaceTypeCityHallExported;
		[Field ("kGMSPlaceTypeCityHall", "__Internal")]
		NSString CityHall { get; }

		// -(NSString *)kGMSPlaceTypeClothingStoreExported;
		[Field ("kGMSPlaceTypeClothingStore", "__Internal")]
		NSString ClothingStore { get; }

		// -(NSString *)kGMSPlaceTypeColloquialAreaExported;
		[Field ("kGMSPlaceTypeColloquialArea", "__Internal")]
		NSString ColloquialArea { get; }

		// -(NSString *)kGMSPlaceTypeConvenienceStoreExported;
		[Field ("kGMSPlaceTypeConvenienceStore", "__Internal")]
		NSString ConvenienceStore { get; }

		// -(NSString *)kGMSPlaceTypeCountryExported;
		[Field ("kGMSPlaceTypeCountry", "__Internal")]
		NSString Country { get; }

		// -(NSString *)kGMSPlaceTypeCourthouseExported;
		[Field ("kGMSPlaceTypeCourthouse", "__Internal")]
		NSString Courthouse { get; }

		// -(NSString *)kGMSPlaceTypeDentistExported;
		[Field ("kGMSPlaceTypeDentist", "__Internal")]
		NSString Dentist { get; }

		// -(NSString *)kGMSPlaceTypeDepartmentStoreExported;
		[Field ("kGMSPlaceTypeDepartmentStore", "__Internal")]
		NSString DepartmentStore { get; }

		// -(NSString *)kGMSPlaceTypeDoctorExported;
		[Field ("kGMSPlaceTypeDoctor", "__Internal")]
		NSString Doctor { get; }

		// -(NSString *)kGMSPlaceTypeElectricianExported;
		[Field ("kGMSPlaceTypeElectrician", "__Internal")]
		NSString Electrician { get; }

		// -(NSString *)kGMSPlaceTypeElectronicsStoreExported;
		[Field ("kGMSPlaceTypeElectronicsStore", "__Internal")]
		NSString ElectronicsStore { get; }

		// -(NSString *)kGMSPlaceTypeEmbassyExported;
		[Field ("kGMSPlaceTypeEmbassy", "__Internal")]
		NSString Embassy { get; }

		// -(NSString *)kGMSPlaceTypeEstablishmentExported;
		[Field ("kGMSPlaceTypeEstablishment", "__Internal")]
		NSString Establishment { get; }

		// -(NSString *)kGMSPlaceTypeFinanceExported;
		[Field ("kGMSPlaceTypeFinance", "__Internal")]
		NSString Finance { get; }

		// -(NSString *)kGMSPlaceTypeFireStationExported;
		[Field ("kGMSPlaceTypeFireStation", "__Internal")]
		NSString FireStation { get; }

		// -(NSString *)kGMSPlaceTypeFloorExported;
		[Field ("kGMSPlaceTypeFloor", "__Internal")]
		NSString Floor { get; }

		// -(NSString *)kGMSPlaceTypeFloristExported;
		[Field ("kGMSPlaceTypeFlorist", "__Internal")]
		NSString Florist { get; }

		// -(NSString *)kGMSPlaceTypeFoodExported;
		[Field ("kGMSPlaceTypeFood", "__Internal")]
		NSString Food { get; }

		// -(NSString *)kGMSPlaceTypeFuneralHomeExported;
		[Field ("kGMSPlaceTypeFuneralHome", "__Internal")]
		NSString FuneralHome { get; }

		// -(NSString *)kGMSPlaceTypeFurnitureStoreExported;
		[Field ("kGMSPlaceTypeFurnitureStore", "__Internal")]
		NSString FurnitureStore { get; }

		// -(NSString *)kGMSPlaceTypeGasStationExported;
		[Field ("kGMSPlaceTypeGasStation", "__Internal")]
		NSString GasStation { get; }

		// -(NSString *)kGMSPlaceTypeGeneralContractorExported;
		[Field ("kGMSPlaceTypeGeneralContractor", "__Internal")]
		NSString GeneralContractor { get; }

		// -(NSString *)kGMSPlaceTypeGeocodeExported;
		[Field ("kGMSPlaceTypeGeocode", "__Internal")]
		NSString Geocode { get; }

		// -(NSString *)kGMSPlaceTypeGroceryOrSupermarketExported;
		[Field ("kGMSPlaceTypeGroceryOrSupermarket", "__Internal")]
		NSString GroceryOrSupermarket { get; }

		// -(NSString *)kGMSPlaceTypeGymExported;
		[Field ("kGMSPlaceTypeGym", "__Internal")]
		NSString Gym { get; }

		// -(NSString *)kGMSPlaceTypeHairCareExported;
		[Field ("kGMSPlaceTypeHairCare", "__Internal")]
		NSString HairCare { get; }

		// -(NSString *)kGMSPlaceTypeHardwareStoreExported;
		[Field ("kGMSPlaceTypeHardwareStore", "__Internal")]
		NSString HardwareStore { get; }

		// -(NSString *)kGMSPlaceTypeHealthExported;
		[Field ("kGMSPlaceTypeHealth", "__Internal")]
		NSString Health { get; }

		// -(NSString *)kGMSPlaceTypeHinduTempleExported;
		[Field ("kGMSPlaceTypeHinduTemple", "__Internal")]
		NSString HinduTemple { get; }

		// -(NSString *)kGMSPlaceTypeHomeGoodsStoreExported;
		[Field ("kGMSPlaceTypeHomeGoodsStore", "__Internal")]
		NSString HomeGoodsStore { get; }

		// -(NSString *)kGMSPlaceTypeHospitalExported;
		[Field ("kGMSPlaceTypeHospital", "__Internal")]
		NSString Hospital { get; }

		// -(NSString *)kGMSPlaceTypeInsuranceAgencyExported;
		[Field ("kGMSPlaceTypeInsuranceAgency", "__Internal")]
		NSString InsuranceAgency { get; }

		// -(NSString *)kGMSPlaceTypeIntersectionExported;
		[Field ("kGMSPlaceTypeIntersection", "__Internal")]
		NSString Intersection { get; }

		// -(NSString *)kGMSPlaceTypeJewelryStoreExported;
		[Field ("kGMSPlaceTypeJewelryStore", "__Internal")]
		NSString JewelryStore { get; }

		// -(NSString *)kGMSPlaceTypeLaundryExported;
		[Field ("kGMSPlaceTypeLaundry", "__Internal")]
		NSString Laundry { get; }

		// -(NSString *)kGMSPlaceTypeLawyerExported;
		[Field ("kGMSPlaceTypeLawyer", "__Internal")]
		NSString Lawyer { get; }

		// -(NSString *)kGMSPlaceTypeLibraryExported;
		[Field ("kGMSPlaceTypeLibrary", "__Internal")]
		NSString Library { get; }

		// -(NSString *)kGMSPlaceTypeLiquorStoreExported;
		[Field ("kGMSPlaceTypeLiquorStore", "__Internal")]
		NSString LiquorStore { get; }

		// -(NSString *)kGMSPlaceTypeLocalGovernmentOfficeExported;
		[Field ("kGMSPlaceTypeLocalGovernmentOffice", "__Internal")]
		NSString LocalGovernmentOffice { get; }

		// -(NSString *)kGMSPlaceTypeLocalityExported;
		[Field ("kGMSPlaceTypeLocality", "__Internal")]
		NSString Locality { get; }

		// -(NSString *)kGMSPlaceTypeLocksmithExported;
		[Field ("kGMSPlaceTypeLocksmith", "__Internal")]
		NSString Locksmith { get; }

		// -(NSString *)kGMSPlaceTypeLodgingExported;
		[Field ("kGMSPlaceTypeLodging", "__Internal")]
		NSString Lodging { get; }

		// -(NSString *)kGMSPlaceTypeMealDeliveryExported;
		[Field ("kGMSPlaceTypeMealDelivery", "__Internal")]
		NSString MealDelivery { get; }

		// -(NSString *)kGMSPlaceTypeMealTakeawayExported;
		[Field ("kGMSPlaceTypeMealTakeaway", "__Internal")]
		NSString MealTakeaway { get; }

		// -(NSString *)kGMSPlaceTypeMosqueExported;
		[Field ("kGMSPlaceTypeMosque", "__Internal")]
		NSString Mosque { get; }

		// -(NSString *)kGMSPlaceTypeMovieRentalExported;
		[Field ("kGMSPlaceTypeMovieRental", "__Internal")]
		NSString MovieRental { get; }

		// -(NSString *)kGMSPlaceTypeMovieTheaterExported;
		[Field ("kGMSPlaceTypeMovieTheater", "__Internal")]
		NSString MovieTheater { get; }

		// -(NSString *)kGMSPlaceTypeMovingCompanyExported;
		[Field ("kGMSPlaceTypeMovingCompany", "__Internal")]
		NSString MovingCompany { get; }

		// -(NSString *)kGMSPlaceTypeMuseumExported;
		[Field ("kGMSPlaceTypeMuseum", "__Internal")]
		NSString Museum { get; }

		// -(NSString *)kGMSPlaceTypeNaturalFeatureExported;
		[Field ("kGMSPlaceTypeNaturalFeature", "__Internal")]
		NSString NaturalFeature { get; }

		// -(NSString *)kGMSPlaceTypeNeighborhoodExported;
		[Field ("kGMSPlaceTypeNeighborhood", "__Internal")]
		NSString Neighborhood { get; }

		// -(NSString *)kGMSPlaceTypeNightClubExported;
		[Field ("kGMSPlaceTypeNightClub", "__Internal")]
		NSString NightClub { get; }

		// -(NSString *)kGMSPlaceTypePainterExported;
		[Field ("kGMSPlaceTypePainter", "__Internal")]
		NSString Painter { get; }

		// -(NSString *)kGMSPlaceTypeParkExported;
		[Field ("kGMSPlaceTypePark", "__Internal")]
		NSString Park { get; }

		// -(NSString *)kGMSPlaceTypeParkingExported;
		[Field ("kGMSPlaceTypeParking", "__Internal")]
		NSString Parking { get; }

		// -(NSString *)kGMSPlaceTypePetStoreExported;
		[Field ("kGMSPlaceTypePetStore", "__Internal")]
		NSString PetStore { get; }

		// -(NSString *)kGMSPlaceTypePharmacyExported;
		[Field ("kGMSPlaceTypePharmacy", "__Internal")]
		NSString Pharmacy { get; }

		// -(NSString *)kGMSPlaceTypePhysiotherapistExported;
		[Field ("kGMSPlaceTypePhysiotherapist", "__Internal")]
		NSString Physiotherapist { get; }

		// -(NSString *)kGMSPlaceTypePlaceOfWorshipExported;
		[Field ("kGMSPlaceTypePlaceOfWorship", "__Internal")]
		NSString PlaceOfWorship { get; }

		// -(NSString *)kGMSPlaceTypePlumberExported;
		[Field ("kGMSPlaceTypePlumber", "__Internal")]
		NSString Plumber { get; }

		// -(NSString *)kGMSPlaceTypePointOfInterestExported;
		[Field ("kGMSPlaceTypePointOfInterest", "__Internal")]
		NSString PointOfInterest { get; }

		// -(NSString *)kGMSPlaceTypePoliceExported;
		[Field ("kGMSPlaceTypePolice", "__Internal")]
		NSString Police { get; }

		// -(NSString *)kGMSPlaceTypePoliticalExported;
		[Field ("kGMSPlaceTypePolitical", "__Internal")]
		NSString Political { get; }

		// -(NSString *)kGMSPlaceTypePostBoxExported;
		[Field ("kGMSPlaceTypePostBox", "__Internal")]
		NSString PostBox { get; }

		// -(NSString *)kGMSPlaceTypePostOfficeExported;
		[Field ("kGMSPlaceTypePostOffice", "__Internal")]
		NSString PostOffice { get; }

		// -(NSString *)kGMSPlaceTypePostalCodeExported;
		[Field ("kGMSPlaceTypePostalCode", "__Internal")]
		NSString PostalCode { get; }

		// -(NSString *)kGMSPlaceTypePostalCodePrefixExported;
		[Field ("kGMSPlaceTypePostalCodePrefix", "__Internal")]
		NSString PostalCodePrefix { get; }

		// -(NSString *)kGMSPlaceTypePostalTownExported;
		[Field ("kGMSPlaceTypePostalTown", "__Internal")]
		NSString PostalTown { get; }

		// -(NSString *)kGMSPlaceTypePremiseExported;
		[Field ("kGMSPlaceTypePremise", "__Internal")]
		NSString Premise { get; }

		// -(NSString *)kGMSPlaceTypeRealEstateAgencyExported;
		[Field ("kGMSPlaceTypeRealEstateAgency", "__Internal")]
		NSString RealEstateAgency { get; }

		// -(NSString *)kGMSPlaceTypeRestaurantExported;
		[Field ("kGMSPlaceTypeRestaurant", "__Internal")]
		NSString Restaurant { get; }

		// -(NSString *)kGMSPlaceTypeRoofingContractorExported;
		[Field ("kGMSPlaceTypeRoofingContractor", "__Internal")]
		NSString RoofingContractor { get; }

		// -(NSString *)kGMSPlaceTypeRoomExported;
		[Field ("kGMSPlaceTypeRoom", "__Internal")]
		NSString Room { get; }

		// -(NSString *)kGMSPlaceTypeRouteExported;
		[Field ("kGMSPlaceTypeRoute", "__Internal")]
		NSString Route { get; }

		// -(NSString *)kGMSPlaceTypeRvParkExported;
		[Field ("kGMSPlaceTypeRvPark", "__Internal")]
		NSString RvPark { get; }

		// -(NSString *)kGMSPlaceTypeSchoolExported;
		[Field ("kGMSPlaceTypeSchool", "__Internal")]
		NSString School { get; }

		// -(NSString *)kGMSPlaceTypeShoeStoreExported;
		[Field ("kGMSPlaceTypeShoeStore", "__Internal")]
		NSString ShoeStore { get; }

		// -(NSString *)kGMSPlaceTypeShoppingMallExported;
		[Field ("kGMSPlaceTypeShoppingMall", "__Internal")]
		NSString ShoppingMall { get; }

		// -(NSString *)kGMSPlaceTypeSpaExported;
		[Field ("kGMSPlaceTypeSpa", "__Internal")]
		NSString Spa { get; }

		// -(NSString *)kGMSPlaceTypeStadiumExported;
		[Field ("kGMSPlaceTypeStadium", "__Internal")]
		NSString Stadium { get; }

		// -(NSString *)kGMSPlaceTypeStorageExported;
		[Field ("kGMSPlaceTypeStorage", "__Internal")]
		NSString Storage { get; }

		// -(NSString *)kGMSPlaceTypeStoreExported;
		[Field ("kGMSPlaceTypeStore", "__Internal")]
		NSString Store { get; }

		// -(NSString *)kGMSPlaceTypeStreetAddressExported;
		[Field ("kGMSPlaceTypeStreetAddress", "__Internal")]
		NSString StreetAddress { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityExported;
		[Field ("kGMSPlaceTypeSublocality", "__Internal")]
		NSString Sublocality { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityLevel1Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel1", "__Internal")]
		NSString SublocalityLevel1 { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityLevel2Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel2", "__Internal")]
		NSString SublocalityLevel2 { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityLevel3Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel3", "__Internal")]
		NSString SublocalityLevel3 { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityLevel4Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel4", "__Internal")]
		NSString SublocalityLevel4 { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityLevel5Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel5", "__Internal")]
		NSString SublocalityLevel5 { get; }

		// -(NSString *)kGMSPlaceTypeSubpremiseExported;
		[Field ("kGMSPlaceTypeSubpremise", "__Internal")]
		NSString Subpremise { get; }

		// -(NSString *)kGMSPlaceTypeSubwayStationExported;
		[Field ("kGMSPlaceTypeSubwayStation", "__Internal")]
		NSString SubwayStation { get; }

		// -(NSString *)kGMSPlaceTypeSynagogueExported;
		[Field ("kGMSPlaceTypeSynagogue", "__Internal")]
		NSString Synagogue { get; }

		// -(NSString *)kGMSPlaceTypeTaxiStandExported;
		[Field ("kGMSPlaceTypeTaxiStand", "__Internal")]
		NSString TaxiStand { get; }

		// -(NSString *)kGMSPlaceTypeTrainStationExported;
		[Field ("kGMSPlaceTypeTrainStation", "__Internal")]
		NSString TrainStation { get; }

		// -(NSString *)kGMSPlaceTypeTransitStationExported;
		[Field ("kGMSPlaceTypeTransitStation", "__Internal")]
		NSString TransitStation { get; }

		// -(NSString *)kGMSPlaceTypeTravelAgencyExported;
		[Field ("kGMSPlaceTypeTravelAgency", "__Internal")]
		NSString TravelAgency { get; }

		// -(NSString *)kGMSPlaceTypeUniversityExported;
		[Field ("kGMSPlaceTypeUniversity", "__Internal")]
		NSString University { get; }

		// -(NSString *)kGMSPlaceTypeVeterinaryCareExported;
		[Field ("kGMSPlaceTypeVeterinaryCare", "__Internal")]
		NSString VeterinaryCare { get; }

		// -(NSString *)kGMSPlaceTypeZooExported;
		[Field ("kGMSPlaceTypeZoo", "__Internal")]
		NSString Zoo { get; }
	}

	[BaseType (typeof (Overlay), Name = "GMSPolygon")]
	interface Polygon
	{
		[NullAllowed]
		[Export ("path", ArgumentSemantic.Copy)]
		Path Path { get; set; }

		// @property(nonatomic, copy) NSArray *holes;
		[NullAllowed]
		[Export ("holes", ArgumentSemantic.Copy)]
		Path [] Holes { get; set; }

		[Export ("strokeWidth", ArgumentSemantic.Assign)]
		nfloat StrokeWidth { get; set; }

		[NullAllowed]
		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[NullAllowed]
		[Export ("fillColor")]
		UIColor FillColor { get; set; }

		[Export ("geodesic", ArgumentSemantic.Assign)]
		bool Geodesic { get; set; }

		[Static]
		[Export ("polygonWithPath:")]
		Polygon FromPath ([NullAllowed] Path path);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSStrokeStyle")]
	interface StrokeStyle
	{

		[Static]
		[Export ("solidColor:")]
		StrokeStyle GetSolidColor (UIColor color);

		[Static]
		[Export ("gradientFromColor:toColor:")]
		StrokeStyle GetGradient (UIColor fromColor, UIColor toColor);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSStyleSpan")]
	interface StyleSpan
	{

		[Static]
		[Export ("spanWithColor:")]
		StyleSpan FromSolidColor (UIColor color);

		[Static]
		[Export ("spanWithColor:segments:")]
		StyleSpan FromSolidColor (UIColor color, double segments);

		[Static]
		[Export ("spanWithStyle:")]
		StyleSpan FromStyle (StrokeStyle style);

		[Static]
		[Export ("spanWithStyle:segments:")]
		StyleSpan FromStyle (StrokeStyle style, double segments);

		[Export ("style")]
		StrokeStyle Style { get; }

		[Export ("segments")]
		double Segments { get; }
	}

	[BaseType (typeof (Overlay), Name = "GMSPolyline")]
	interface Polyline
	{
		[NullAllowed]
		[Export ("path", ArgumentSemantic.Copy)]
		Path Path { get; set; }

		[Export ("strokeWidth", ArgumentSemantic.Assign)]
		nfloat StrokeWidth { get; set; }

		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[Export ("geodesic", ArgumentSemantic.Assign)]
		bool Geodesic { get; set; }

		[Static, Export ("polylineWithPath:")]
		Polyline FromPath ([NullAllowed] Path path);

		[NullAllowed]
		[Export ("spans", ArgumentSemantic.Copy)]
		StyleSpan [] Spans { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GMSProjection")]
	interface Projection
	{

		[Export ("pointForCoordinate:")]
		CGPoint PointForCoordinate (CLLocationCoordinate2D coordinate);

		[Export ("coordinateForPoint:")]
		CLLocationCoordinate2D CoordinateForPoint (CGPoint point);

		[Export ("pointsForMeters:atCoordinate:")]
		nfloat PointsForMeters (double meters, CLLocationCoordinate2D coordinate);

		[Export ("containsCoordinate:")]
		bool ContainsCoordinate (CLLocationCoordinate2D coordinate);

		[Export ("visibleRegion")]
		VisibleRegion VisibleRegion { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSServices")]
	interface MapServices
	{

		[Static]
		[Export ("sharedServices")]
		MapServices SharedServices { get; }

		[Static]
		[Export ("provideAPIKey:")]
		bool ProvideAPIKey (string APIKey);

		[Static]
		[Export ("openSourceLicenseInfo")]
		string OpenSourceLicenseInfo { get; }

		[Static]
		[Export ("SDKVersion")]
		string SDKVersion { get; }
	}

	[BaseType (typeof (TileLayer), Name = "GMSSyncTileLayer")]
	interface SyncTileLayer
	{

		[Export ("tileForX:y:zoom:")]
		UIImage Tile (nuint x, nuint y, nuint zoom);
	}

	interface ITileReceiver
	{

	}

	[BaseType (typeof (NSObject), Name = "GMSTileReceiver")]
	[Model]
	[Protocol]
	interface TileReceiver
	{

		[Abstract]
		[Export ("receiveTileWithX:y:zoom:image:")]
		void ReceiveTile (nuint x, nuint y, nuint zoom, [NullAllowed] UIImage image);
	}

	[BaseType (typeof (NSObject), Name = "GMSTileLayer")]
	interface TileLayer
	{

		[Export ("requestTileForX:y:zoom:receiver:")]
		void RequestTile (nuint x, nuint y, nuint zoom, ITileReceiver receiver);

		[Export ("clearTileCache")]
		void ClearTileCache ();

		[NullAllowed]
		[Export ("map", ArgumentSemantic.Weak)]
		MapView Map { get; set; }

		[Export ("zIndex", ArgumentSemantic.Assign)]
		int ZIndex { get; set; }

		[Export ("tileSize", ArgumentSemantic.Assign)]
		nint TileSize { get; set; }

		[Export ("opacity", ArgumentSemantic.Assign)]
		float Opacity { get; set; }

		[Export ("fadeIn", ArgumentSemantic.Assign)]
		bool FadeIn { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GMSUISettings")]
	interface UISettings
	{

		[Export ("setAllGesturesEnabled:")]
		void SetAllGesturesEnabled (bool enabled);

		[Export ("scrollGestures", ArgumentSemantic.Assign)]
		bool ScrollGestures { get; set; }

		[Export ("zoomGestures", ArgumentSemantic.Assign)]
		bool ZoomGestures { get; set; }

		[Export ("tiltGestures", ArgumentSemantic.Assign)]
		bool TiltGestures { get; set; }

		[Export ("rotateGestures", ArgumentSemantic.Assign)]
		bool RotateGestures { get; set; }

		[Export ("consumesGesturesInView", ArgumentSemantic.Assign)]
		bool ConsumesGesturesInView { get; set; }

		[Export ("compassButton", ArgumentSemantic.Assign)]
		bool CompassButton { get; set; }

		[Export ("myLocationButton", ArgumentSemantic.Assign)]
		bool MyLocationButton { get; set; }

		[Export ("indoorPicker", ArgumentSemantic.Assign)]
		bool IndoorPicker { get; set; }

		// @property (assign, nonatomic) BOOL allowScrollGesturesDuringRotateOrZoom;
		[Export ("allowScrollGesturesDuringRotateOrZoom", ArgumentSemantic.Assign)]
		bool AllowScrollGesturesDuringRotateOrZoom { get; set; }
	}

	delegate NSUrl TileUrlConstructorHandler (nuint x, nuint y, nuint zoom);

	[DisableDefaultCtor]
	[BaseType (typeof (TileLayer), Name = "GMSURLTileLayer")]
	interface UrlTileLayer
	{

		[Static]
		[Export ("tileLayerWithURLConstructor:")]
		UrlTileLayer FromUrlConstructor (TileUrlConstructorHandler constructor);

		[NullAllowed]
		[Export ("userAgent", ArgumentSemantic.Copy)]
		string UserAgent { get; set; }
	}

	// @interface GMSUserAddedPlace : NSObject
	[BaseType (typeof (NSObject), Name = "GMSUserAddedPlace")]
	interface UserAddedPlace
	{
		// @property (copy, nonatomic) NSString * name;
		[NullAllowed]
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * address;
		[NullAllowed]
		[Export ("address", ArgumentSemantic.Copy)]
		string Address { get; set; }

		// @property (assign, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Coordinate { get; set; }

		// @property (copy, nonatomic) NSString * phoneNumber;
		[NullAllowed]
		[Export ("phoneNumber", ArgumentSemantic.Copy)]
		string PhoneNumber { get; set; }

		// @property (copy, nonatomic) NSArray * types;
		[NullAllowed]
		[Export ("types", ArgumentSemantic.Copy)]
		string [] Types { get; set; }

		// @property (copy, nonatomic) NSString * website;
		[NullAllowed]
		[Export ("website", ArgumentSemantic.Copy)]
		string Website { get; set; }
	}
}
