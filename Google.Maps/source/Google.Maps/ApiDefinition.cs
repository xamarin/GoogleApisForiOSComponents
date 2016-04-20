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
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GMSFieldExporter")]
	interface Constants
	{
		[Static, Export ("kGMSLayerCameraLatitudeKeyExported")]
		NSString LayerCameraLatitudeKey { get; }

		[Static, Export ("kGMSLayerCameraLongitudeKeyExported")]
		NSString LayerCameraLongitudeKey { get; }

		[Static, Export ("kGMSLayerCameraBearingKeyExported")]
		NSString LayerCameraBearingKey { get; }

		[Static, Export ("kGMSLayerCameraZoomLevelKeyExported")]
		NSString LayerCameraZoomLevelKey { get; }

		[Static, Export ("kGMSLayerCameraViewingAngleKeyExported")]
		NSString LayerCameraViewingAngleKey { get; }

		[Static, Export ("kGMSMaxZoomLevelExported")]
		float MaxZoomLevel { get; }

		[Static, Export ("kGMSMinZoomLevelExported")]
		float MinZoomLevel { get; }

		[Static, Export ("kGMSGroundOverlayDefaultAnchorExported")]
		CGRect GroundOverlayDefaultAnchor { get; }

		[Static, Export ("kGMSMarkerDefaultGroundAnchorExported")]
		CGPoint MarkerDefaultGroundAnchor { get; }

		[Static, Export ("kGMSMarkerDefaultInfoWindowAnchorExported")]
		CGPoint MarkerDefaultInfoWindowAnchor { get; }

		[Static, Export ("kGMSTileLayerNoTileExported")]
		UIImage TileLayerNoTile { get; }

		[Static, Export ("kGMSLayerPanoramaFOVKeyExported")]
		NSString LayerPanoramaFOVKey { get; }

		[Static, Export ("kGMSLayerPanoramaHeadingKeyExported")]
		NSString LayerPanoramaHeadingKey { get; }

		[Static, Export ("kGMSLayerPanoramaPitchKeyExported")]
		NSString LayerPanoramaPitchKey { get; }

		[Static, Export ("kGMSLayerPanoramaZoomKeyExported")]
		NSString LayerPanoramaZoomKey { get; }

		[Static, Export ("kGMSMarkerLayerLatitudeExported")]
		NSString MarkerLayerLatitude { get; }

		[Static, Export ("kGMSMarkerLayerLongitudeExported")]
		NSString MarkerLayerLongitude { get; }

		[Static, Export ("kGMSMarkerLayerRotationExported")]
		NSString MarkerLayerRotation { get; }

		[Static, Export ("kGMSEarthRadiusExported")]
		double EarthRadius { get; }

		[Static, Export ("kGMSAccessibilityCompassExported")]
		NSString AccessibilityCompass { get; }

		[Static, Export ("kGMSAccessibilityMyLocationExported")]
		NSString AccessibilityMyLocation { get; }

		[Static, Export ("kGMSEquatorProjectedMeterExported")]
		double EquatorProjectedMeter { get; }

		// extern NSString *const kGMSAutocompleteMatchAttribute;
		[Static, Export ("kGMSAutocompleteMatchAttributeExported")]
		NSString AutocompleteMatchAttribute { get; }

		// extern NSString *const kGMSPlacePickerErrorDomain;
		[Static, Export ("kGMSPlacePickerErrorDomainExported")]
		NSString PlacePickerErrorDomain { get; }

		// extern NSString *const kGMSPlacesErrorDomain;
		[Static, Export ("kGMSPlacesErrorDomainExported")]
		NSString PlacesErrorDomain { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject))]
	interface GeometryUtils
	{
		[Static, Export ("projectWithCoordinate:")]
		MapPoint Project (CLLocationCoordinate2D coordinate);

		[Static, Export ("unprojectWithMapPoint:")]
		CLLocationCoordinate2D Unproject (MapPoint point);

		[Static, Export ("mapPointInterpolateWithMapPoint:andMapPoint:andT:")]
		MapPoint MapPointInterpolate (MapPoint a, MapPoint b, double t);

		[Static, Export ("mapPointDistanceFromPoint:andMapPoint:")]
		double MapPointDistance (MapPoint a, MapPoint b);

		[Static, Export ("geometryContainsLocation:path:geodesic:")]
		bool ContainsLocation (CLLocationCoordinate2D point, Google.Maps.Path path, bool geodesic);

		[Static, Export ("geometryIsLocationOnPath:path:geodesic:tolerance:")]
		bool IsLocationOnPath (CLLocationCoordinate2D point, Google.Maps.Path path, bool geodesic, double tolerance);

		[Static, Export ("geometryIsLocationOnPath:path:geodesic:")]
		bool IsLocationOnPath (CLLocationCoordinate2D point, Google.Maps.Path path, bool geodesic);

		[Static, Export ("geometryDistance:to:")]
		double Distance (CLLocationCoordinate2D fromCoord, CLLocationCoordinate2D toCoord);

		[Static, Export ("geometryLength:")]
		double Length (Google.Maps.Path path);

		[Static, Export ("geometryArea:")]
		double Area (Google.Maps.Path path);

		[Static, Export ("geometrySignedArea:")]
		double SignedArea (Google.Maps.Path path);

		[Static, Export ("geometryHeading:to:")]
		double Heading (CLLocationCoordinate2D fromCoord, CLLocationCoordinate2D toCoord);

		[Static, Export ("geometryOffset:distance:heading:")]
		CLLocationCoordinate2D Offset (CLLocationCoordinate2D fromCoord, double distance, double heading);

		[Static, Export ("geometryInterpolate:to:fraction:")]
		CLLocationCoordinate2D Interpolate (CLLocationCoordinate2D fromCoord, CLLocationCoordinate2D toCoord, double fraction);

		[Static, Export ("styleSpansFrom:andStyles:andLengths:andLenghtKind:")]
		StyleSpan[] StyleSpans (Path path, StrokeStyle[] styles, NSNumber[] lengths, LengthKind lengthKind);

		[Static, Export ("styleSpansFrom:andStyles:andLengths:andLenghtKind:andLengthOffset:")]
		StyleSpan[] StyleSpans (Path path, StrokeStyle[] styles, NSNumber[] lengths, LengthKind lengthKind, double lengthOffset);
	}
	#endregion

	[BaseType (typeof(NSObject), Name = "GMSAddress")]
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

	interface IAutocompleteFetcherDelegate
	{
	}

	// @protocol GMSAutocompleteFetcherDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "GMSAutocompleteFetcherDelegate")]
	interface AutocompleteFetcherDelegate
	{
		// - (void)didAutocompleteWithPredictions:(NSArray *)predictions;
		[Abstract]
		[Export ("didAutocompleteWithPredictions:")]
		void DidAutocomplete (AutocompletePrediction predictions);

		// - (void)didFailAutocompleteWithError:(NSError *)error;
		[Abstract]
		[Export ("didFailAutocompleteWithError:")]
		void DidFailAutocomplete (NSError error);
	}

	// @interface GMSAutocompleteFetcher : NSObject
	[BaseType (typeof(NSObject), Name = "GMSAutocompleteFetcher")]
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
		void SourceTextHasChanged (string text);
	}

	// @interface GMSAutocompleteFilter : NSObject
	[BaseType (typeof(NSObject), Name = "GMSAutocompleteFilter")]
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
	[BaseType (typeof(NSObject), Name = "GMSAutocompleteMatchFragment")]
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
	[BaseType (typeof(NSObject), Name = "GMSAutocompletePrediction")]
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
		string[] Types { get; }
	}

	interface IAutocompleteResultsViewControllerDelegate
	{
	}

	// @protocol GMSAutocompleteResultsViewControllerDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "GMSAutocompleteResultsViewControllerDelegate")]
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
	[BaseType (typeof(UIViewController),
		Name = "GMSAutocompleteResultsViewController",
		Delegates = new string[] { "Delegate" },
		Events = new Type[] { typeof(AutocompleteResultsViewControllerDelegate) })]
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
	}

	interface IAutocompleteTableDataSourceDelegate
	{
	}

	[Model]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "GMSAutocompleteTableDataSourceDelegate")]
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
	[BaseType (typeof(NSObject),
		Name = "GMSAutocompleteTableDataSource",
		Delegates = new string[] { "Delegate" },
		Events = new Type[] { typeof(AutocompleteTableDataSourceDelegate) })]
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

		// - (void)sourceTextHasChanged:(NSString *)text;
		[Export ("sourceTextHasChanged:")]
		void SourceTextHasChanged (string text);
	}

	interface IAutocompleteViewControllerDelegate
	{
	}

	[Model]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "GMSAutocompleteViewControllerDelegate")]
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
	[BaseType (typeof(UIViewController),
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
	}

	[DisableDefaultCtor]
	[BaseType (typeof(CALayer), Name = "GMSCALayer")]
	interface Layer
	{
	}

	[BaseType (typeof(NSObject), Name = "GMSCameraPosition")]
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

	[BaseType (typeof(CameraPosition), Name = "GMSMutableCameraPosition")]
	interface MutableCameraPosition
	{

		[Export ("target", ArgumentSemantic.Assign)] [New]
		CLLocationCoordinate2D Target { get; set; }

		[Export ("zoom", ArgumentSemantic.Assign)] [New]
		float Zoom { get; set; }

		[Export ("bearing", ArgumentSemantic.Assign)] [New]
		double Bearing { get; set; }

		[Export ("viewingAngle", ArgumentSemantic.Assign)] [New]
		double ViewingAngle { get; set; }

	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GMSCameraUpdate")]
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

	[BaseType (typeof(Overlay), Name = "GMSCircle")]
	interface Circle
	{

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }

		[Export ("radius", ArgumentSemantic.Assign)]
		double Radius { get; set; }

		[Export ("strokeWidth", ArgumentSemantic.Assign)]
		nfloat StrokeWidth { get; set; }

		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[Export ("fillColor")]
		UIColor FillColor { get; set; }

		[Static, Export ("circleWithPosition:radius:")]
		Circle FromPosition (CLLocationCoordinate2D position, double radius);
	}

	[BaseType (typeof(NSObject), Name = "GMSCoordinateBounds")]
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

	delegate void ReverseGeocodeCallback (ReverseGeocodeResponse response,NSError error);

	[BaseType (typeof(NSObject), Name = "GMSGeocoder")]
	interface Geocoder
	{

		[Static, Export ("geocoder")]
		Geocoder SharedGeocoder { get; }

		[Export ("reverseGeocodeCoordinate:completionHandler:")]
		void ReverseGeocodeCord (CLLocationCoordinate2D coordinate, ReverseGeocodeCallback handler);
	}

	[BaseType (typeof(Overlay), Name = "GMSGroundOverlay")]
	interface GroundOverlay
	{

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }

		[Export ("anchor", ArgumentSemantic.Assign)]
		CGPoint Anchor { get; set; }

		[Export ("icon")]
		UIImage Icon { get; set; }

		// @property(nonatomic, assign) float opacity;
		[Export ("opacity", ArgumentSemantic.Assign)]
		float Opacity { get; set; }

		[Export ("bearing", ArgumentSemantic.Assign)]
		double Bearing { get; set; }

		[Export ("bounds")]
		CoordinateBounds Bounds { get; set; }

		[Static, Export ("groundOverlayWithBounds:icon:")]
		GroundOverlay GetGroundOverlay (CoordinateBounds bounds, UIImage icon);

		[Static, Export ("groundOverlayWithPosition:icon:zoomLevel:")]
		GroundOverlay GetGroundOverlay (CLLocationCoordinate2D position, UIImage icon, nfloat zoomLevel);
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GMSIndoorBuilding")]
	interface IndoorBuilding
	{
		[Export ("levels", ArgumentSemantic.Retain)] [PostGet ("Underground")]
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
	[BaseType (typeof(NSObject), Name = "GMSIndoorDisplayDelegate")]
	interface IndoorDisplayDelegate
	{
		[Export ("didChangeActiveBuilding:")]
		void DidChangeActiveBuilding (IndoorBuilding building);

		[Export ("didChangeActiveLevel:")]
		void DidChangeActiveLevel (IndoorLevel level);
	}

	[BaseType (typeof(NSObject), Name = "GMSIndoorDisplay")]
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
	[BaseType (typeof(NSObject), Name = "GMSIndoorLevel")]
	interface IndoorLevel
	{
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("shortName", ArgumentSemantic.Copy)]
		string ShortName { get; }
	}


	[BaseType (typeof(Layer), Name = "GMSMapLayer")]
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

	[BaseType (typeof(NSObject), Name = "GMSMapViewDelegate")]
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
	}

	[BaseType (typeof(UIView), Name = "GMSMapView",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof(MapViewDelegate) }
	)]
	interface MapView
	{

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
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

		[Export ("accessibilityElementsHidden", ArgumentSemantic.Assign)] [New]
		bool AccessibilityElementsHidden { get; set; }

		[Export ("layer", ArgumentSemantic.Retain)] [New]
		MapLayer Layer { get; }

		[Static]
		[Export ("mapWithFrame:camera:")]
		MapView FromCamera (CGRect frame, CameraPosition camera);

		[Export ("startRendering")] [Obsolete ("Available but deprecated")]
		void StartRendering ();

		[Export ("stopRendering")] [Obsolete ("Available but deprecated")]
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

	[BaseType (typeof(MapView))]
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

	[BaseType (typeof(Overlay), Name = "GMSMarker")]
	interface Marker
	{

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }

		[Export ("snippet", ArgumentSemantic.Copy)]
		string Snippet { get; set; }

		[Export ("icon")]
		UIImage Icon { get; set; }

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

		[Export ("userData")]
		NSObject UserData { get; set; }

		[Export ("layer", ArgumentSemantic.Retain)]
		MarkerLayer Layer { get; }

		[Export ("panoramaView")]
		PanoramaView PanoramaView { get; set; }

		[Static, Export ("markerWithPosition:")]
		Marker FromPosition (CLLocationCoordinate2D position);

		[Static, Export ("markerImageWithColor:")]
		UIImage MarkerImage (UIColor color);
	}

	[DisableDefaultCtor]
	[BaseType (typeof(CALayer), Name = "GMSMarkerLayer")]
	interface MarkerLayer
	{

		[Export ("latitude", ArgumentSemantic.Assign)]
		double Latitude { get; set; }

		[Export ("longitude", ArgumentSemantic.Assign)]
		double Longitude { get; set; }

		[Export ("rotation", ArgumentSemantic.Assign)]
		double Rotation { get; set; }

		[Export ("opacity", ArgumentSemantic.Assign)] [New]
		float Opacity { get; set; }
	}

	[BaseType (typeof(Path), Name = "GMSMutablePath")]
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
	[BaseType (typeof(NSObject), Name = "GMSOverlay")]
	interface Overlay : INSCopying
	{

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("map")]
		MapView Map { get; [NullAllowed] set; }

		[Export ("tappable", ArgumentSemantic.Assign)]
		bool Tappable { [Bind ("isTappable")] get; set; }

		[Export ("zIndex", ArgumentSemantic.Assign)]
		int ZIndex { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GMSPanorama")]
	interface Panorama
	{

		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		[Export ("panoramaID")]
		string PanoramaID { get; }

		[Export ("links")]
		PanoramaLink [] Links { get; }
	}

	[BaseType (typeof(NSObject), Name = "GMSPanoramaCamera")]
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
	[BaseType (typeof(NSObject), Name = "GMSPanoramaCameraUpdate")]
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
	[BaseType (typeof(CALayer), Name = "GMSPanoramaLayer")]
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

	[BaseType (typeof(NSObject), Name = "GMSPanoramaLink")]
	interface PanoramaLink
	{

		[Export ("heading", ArgumentSemantic.Assign)]
		nfloat Heading { get; set; }

		[Export ("panoramaID", ArgumentSemantic.Copy)]
		string PanoramaID { get; set; }
	}

	delegate void PanoramaCallback (Panorama panorama,NSError error);

	[BaseType (typeof(NSObject), Name = "GMSPanoramaService")]
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

	[BaseType (typeof(NSObject), Name = "GMSPanoramaViewDelegate")]
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

	[BaseType (typeof(UIView), Name = "GMSPanoramaView",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof(PanoramaViewDelegate) }
	)]
	interface PanoramaView
	{

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("panorama", ArgumentSemantic.Retain)][NullAllowed]
		Panorama Panorama { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
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

		[Export ("camera", ArgumentSemantic.Retain)][NullAllowed]
		PanoramaCamera Camera { get; set; }

		[Export ("layer", ArgumentSemantic.Retain)][New]
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

	[BaseType (typeof(NSObject), Name = "GMSPath")]
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
	[BaseType (typeof(NSObject), Name = "GMSPlace")]
	interface Place
	{
		// @property (readonly, copy, nonatomic) NSString * name;
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * placeID;
		[Export ("placeID", ArgumentSemantic.Copy)]
		string PlaceID { get; }

		// @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		// @property (readonly, nonatomic) GMSPlacesOpenNowStatus openNowStatus;
		[Export ("openNowStatus")]
		PlacesOpenNowStatus OpenNowStatus { get; }

		// @property (readonly, copy, nonatomic) NSString * phoneNumber;
		[Export ("phoneNumber", ArgumentSemantic.Copy)]
		string PhoneNumber { get; }

		// @property (readonly, copy, nonatomic) NSString * formattedAddress;
		[Export ("formattedAddress", ArgumentSemantic.Copy)]
		string FormattedAddress { get; }

		// @property (readonly, nonatomic) float rating;
		[Export ("rating", ArgumentSemantic.Copy)]
		float Rating { get; }

		// @property (readonly, nonatomic) GMSPlacesPriceLevel priceLevel;
		[Export ("priceLevel")]
		PlacesPriceLevel PriceLevel { get; }

		// @property (readonly, copy, nonatomic) NSArray * types;
		[Export ("types", ArgumentSemantic.Copy)]
		string[] Types { get; }

		// @property (readonly, copy, nonatomic) NSURL * website;
		[Export ("website", ArgumentSemantic.Copy)]
		NSUrl Website { get; }

		// @property (readonly, copy, nonatomic) NSAttributedString * attributions;
		[Export ("attributions", ArgumentSemantic.Copy)]
		NSAttributedString Attributions { get; }

		// @property(nonatomic, strong, readonly) GMSCoordinateBounds *viewport;
		[Export ("viewport", ArgumentSemantic.Strong)]
		CoordinateBounds Viewport { get; }
	}

	// @interface GMSPlaceLikelihood : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GMSPlaceLikelihood")]
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
	[BaseType (typeof(NSObject), Name = "GMSPlaceLikelihoodList")]
	interface PlaceLikelihoodList
	{
		// @property (copy, nonatomic) NSArray * likelihoods;
		[Export ("likelihoods", ArgumentSemantic.Copy)]
		PlaceLikelihood[] Likelihoods { get; set; }

		// @property (readonly, copy, nonatomic) NSAttributedString * attributions;
		[Export ("attributions", ArgumentSemantic.Copy)]
		NSAttributedString Attributions { get; }
	}

	// typedef void (^GMSPlaceResultCallback)(GMSPlace *NSError *);
	delegate void PlaceResultHandler (Place result,NSError error);

	// @interface GMSPlacePicker : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GMSPlacePicker")]
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
	[BaseType (typeof(NSObject), Name = "GMSPlacePickerConfig")]
	interface PlacePickerConfig
	{
		// @property (readonly, nonatomic, strong) GMSCoordinateBounds * viewport;
		[Export ("viewport", ArgumentSemantic.Strong)]
		CoordinateBounds Viewport { get; }

		// -(instancetype)initWithViewport:(GMSCoordinateBounds *)viewport;
		[Export ("initWithViewport:")]
		IntPtr Constructor (CoordinateBounds viewport);
	}

	// typedef void (^GMSPlaceLikelihoodListCallback)(GMSPlaceLikelihoodList *NSError *);
	delegate void PlaceLikelihoodListHandler (PlaceLikelihoodList likelihoodList,NSError error);

	// typedef void (^GMSAutocompletePredictionsCallback)(NSArray *NSError *);
	delegate void AutocompletePredictionsHandler (AutocompletePrediction[] results,NSError error);

	// @interface GMSPlacesClient : NSObject
	[BaseType (typeof(NSObject), Name = "GMSPlacesClient")]
	interface PlacesClient
	{
		// +(instancetype)sharedClient;
		[Static]
		[Export ("sharedClient")]
		PlacesClient SharedClient ();

		// -(void)reportDeviceAtPlaceWithID:(NSString *)placeID;
		[Export ("reportDeviceAtPlaceWithID:")]
		void ReportDeviceAtPlace (string placeID);

		// -(void)lookUpPlaceID:(NSString *)placeID callback:(GMSPlaceResultCallback)callback;
		[Export ("lookUpPlaceID:callback:")]
		void LookUpPlaceID (string placeID, PlaceResultHandler callback);

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

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject))]
	interface PlaceTypes
	{
		// -(NSString *)kGMSPlaceTypeAccountingExported;
		[Static]
		[Export ("kGMSPlaceTypeAccountingExported")]
		string Accounting { get; }
	
		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel1Exported;
		[Static]
		[Export ("kGMSPlaceTypeAdministrativeAreaLevel1Exported")]
		string AdministrativeAreaLevel1 { get; }
	
		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel2Exported;
		[Static]
		[Export ("kGMSPlaceTypeAdministrativeAreaLevel2Exported")]
		string AdministrativeAreaLevel2 { get; }
	
		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel3Exported;
		[Static]
		[Export ("kGMSPlaceTypeAdministrativeAreaLevel3Exported")]
		string AdministrativeAreaLevel3 { get; }
	
		// -(NSString *)kGMSPlaceTypeAirportExported;
		[Static]
		[Export ("kGMSPlaceTypeAirportExported")]
		string Airport { get; }
	
		// -(NSString *)kGMSPlaceTypeAmusementParkExported;
		[Static]
		[Export ("kGMSPlaceTypeAmusementParkExported")]
		string AmusementPark { get; }
	
		// -(NSString *)kGMSPlaceTypeAquariumExported;
		[Static]
		[Export ("kGMSPlaceTypeAquariumExported")]
		string Aquarium { get; }
	
		// -(NSString *)kGMSPlaceTypeArtGalleryExported;
		[Static]
		[Export ("kGMSPlaceTypeArtGalleryExported")]
		string ArtGallery { get; }
	
		// -(NSString *)kGMSPlaceTypeAtmExported;
		[Static]
		[Export ("kGMSPlaceTypeAtmExported")]
		string Atm { get; }
	
		// -(NSString *)kGMSPlaceTypeBakeryExported;
		[Static]
		[Export ("kGMSPlaceTypeBakeryExported")]
		string Bakery { get; }
	
		// -(NSString *)kGMSPlaceTypeBankExported;
		[Static]
		[Export ("kGMSPlaceTypeBankExported")]
		string Bank { get; }
	
		// -(NSString *)kGMSPlaceTypeBarExported;
		[Static]
		[Export ("kGMSPlaceTypeBarExported")]
		string Bar { get; }
	
		// -(NSString *)kGMSPlaceTypeBeautySalonExported;
		[Static]
		[Export ("kGMSPlaceTypeBeautySalonExported")]
		string BeautySalon { get; }
	
		// -(NSString *)kGMSPlaceTypeBicycleStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeBicycleStoreExported")]
		string BicycleStore { get; }
	
		// -(NSString *)kGMSPlaceTypeBookStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeBookStoreExported")]
		string BookStore { get; }
	
		// -(NSString *)kGMSPlaceTypeBowlingAlleyExported;
		[Static]
		[Export ("kGMSPlaceTypeBowlingAlleyExported")]
		string BowlingAlley { get; }
	
		// -(NSString *)kGMSPlaceTypeBusStationExported;
		[Static]
		[Export ("kGMSPlaceTypeBusStationExported")]
		string BusStation { get; }
	
		// -(NSString *)kGMSPlaceTypeCafeExported;
		[Static]
		[Export ("kGMSPlaceTypeCafeExported")]
		string Cafe { get; }
	
		// -(NSString *)kGMSPlaceTypeCampgroundExported;
		[Static]
		[Export ("kGMSPlaceTypeCampgroundExported")]
		string Campground { get; }
	
		// -(NSString *)kGMSPlaceTypeCarDealerExported;
		[Static]
		[Export ("kGMSPlaceTypeCarDealerExported")]
		string CarDealer { get; }
	
		// -(NSString *)kGMSPlaceTypeCarRentalExported;
		[Static]
		[Export ("kGMSPlaceTypeCarRentalExported")]
		string CarRental { get; }
	
		// -(NSString *)kGMSPlaceTypeCarRepairExported;
		[Static]
		[Export ("kGMSPlaceTypeCarRepairExported")]
		string CarRepair { get; }
	
		// -(NSString *)kGMSPlaceTypeCarWashExported;
		[Static]
		[Export ("kGMSPlaceTypeCarWashExported")]
		string CarWash { get; }
	
		// -(NSString *)kGMSPlaceTypeCasinoExported;
		[Static]
		[Export ("kGMSPlaceTypeCasinoExported")]
		string Casino { get; }
	
		// -(NSString *)kGMSPlaceTypeCemeteryExported;
		[Static]
		[Export ("kGMSPlaceTypeCemeteryExported")]
		string Cemetery { get; }
	
		// -(NSString *)kGMSPlaceTypeChurchExported;
		[Static]
		[Export ("kGMSPlaceTypeChurchExported")]
		string Church { get; }
	
		// -(NSString *)kGMSPlaceTypeCityHallExported;
		[Static]
		[Export ("kGMSPlaceTypeCityHallExported")]
		string CityHall { get; }
	
		// -(NSString *)kGMSPlaceTypeClothingStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeClothingStoreExported")]
		string ClothingStore { get; }
	
		// -(NSString *)kGMSPlaceTypeColloquialAreaExported;
		[Static]
		[Export ("kGMSPlaceTypeColloquialAreaExported")]
		string ColloquialArea { get; }
	
		// -(NSString *)kGMSPlaceTypeConvenienceStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeConvenienceStoreExported")]
		string ConvenienceStore { get; }
	
		// -(NSString *)kGMSPlaceTypeCountryExported;
		[Static]
		[Export ("kGMSPlaceTypeCountryExported")]
		string Country { get; }
	
		// -(NSString *)kGMSPlaceTypeCourthouseExported;
		[Static]
		[Export ("kGMSPlaceTypeCourthouseExported")]
		string Courthouse { get; }
	
		// -(NSString *)kGMSPlaceTypeDentistExported;
		[Static]
		[Export ("kGMSPlaceTypeDentistExported")]
		string Dentist { get; }
	
		// -(NSString *)kGMSPlaceTypeDepartmentStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeDepartmentStoreExported")]
		string DepartmentStore { get; }
	
		// -(NSString *)kGMSPlaceTypeDoctorExported;
		[Static]
		[Export ("kGMSPlaceTypeDoctorExported")]
		string Doctor { get; }
	
		// -(NSString *)kGMSPlaceTypeElectricianExported;
		[Static]
		[Export ("kGMSPlaceTypeElectricianExported")]
		string Electrician { get; }
	
		// -(NSString *)kGMSPlaceTypeElectronicsStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeElectronicsStoreExported")]
		string ElectronicsStore { get; }
	
		// -(NSString *)kGMSPlaceTypeEmbassyExported;
		[Static]
		[Export ("kGMSPlaceTypeEmbassyExported")]
		string Embassy { get; }
	
		// -(NSString *)kGMSPlaceTypeEstablishmentExported;
		[Static]
		[Export ("kGMSPlaceTypeEstablishmentExported")]
		string Establishment { get; }
	
		// -(NSString *)kGMSPlaceTypeFinanceExported;
		[Static]
		[Export ("kGMSPlaceTypeFinanceExported")]
		string Finance { get; }
	
		// -(NSString *)kGMSPlaceTypeFireStationExported;
		[Static]
		[Export ("kGMSPlaceTypeFireStationExported")]
		string FireStation { get; }
	
		// -(NSString *)kGMSPlaceTypeFloorExported;
		[Static]
		[Export ("kGMSPlaceTypeFloorExported")]
		string Floor { get; }
	
		// -(NSString *)kGMSPlaceTypeFloristExported;
		[Static]
		[Export ("kGMSPlaceTypeFloristExported")]
		string Florist { get; }
	
		// -(NSString *)kGMSPlaceTypeFoodExported;
		[Static]
		[Export ("kGMSPlaceTypeFoodExported")]
		string Food { get; }
	
		// -(NSString *)kGMSPlaceTypeFuneralHomeExported;
		[Static]
		[Export ("kGMSPlaceTypeFuneralHomeExported")]
		string FuneralHome { get; }
	
		// -(NSString *)kGMSPlaceTypeFurnitureStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeFurnitureStoreExported")]
		string FurnitureStore { get; }
	
		// -(NSString *)kGMSPlaceTypeGasStationExported;
		[Static]
		[Export ("kGMSPlaceTypeGasStationExported")]
		string GasStation { get; }
	
		// -(NSString *)kGMSPlaceTypeGeneralContractorExported;
		[Static]
		[Export ("kGMSPlaceTypeGeneralContractorExported")]
		string GeneralContractor { get; }
	
		// -(NSString *)kGMSPlaceTypeGeocodeExported;
		[Static]
		[Export ("kGMSPlaceTypeGeocodeExported")]
		string Geocode { get; }
	
		// -(NSString *)kGMSPlaceTypeGroceryOrSupermarketExported;
		[Static]
		[Export ("kGMSPlaceTypeGroceryOrSupermarketExported")]
		string GroceryOrSupermarket { get; }
	
		// -(NSString *)kGMSPlaceTypeGymExported;
		[Static]
		[Export ("kGMSPlaceTypeGymExported")]
		string Gym { get; }
	
		// -(NSString *)kGMSPlaceTypeHairCareExported;
		[Static]
		[Export ("kGMSPlaceTypeHairCareExported")]
		string HairCare { get; }
	
		// -(NSString *)kGMSPlaceTypeHardwareStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeHardwareStoreExported")]
		string HardwareStore { get; }
	
		// -(NSString *)kGMSPlaceTypeHealthExported;
		[Static]
		[Export ("kGMSPlaceTypeHealthExported")]
		string Health { get; }
	
		// -(NSString *)kGMSPlaceTypeHinduTempleExported;
		[Static]
		[Export ("kGMSPlaceTypeHinduTempleExported")]
		string HinduTemple { get; }
	
		// -(NSString *)kGMSPlaceTypeHomeGoodsStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeHomeGoodsStoreExported")]
		string HomeGoodsStore { get; }
	
		// -(NSString *)kGMSPlaceTypeHospitalExported;
		[Static]
		[Export ("kGMSPlaceTypeHospitalExported")]
		string Hospital { get; }
	
		// -(NSString *)kGMSPlaceTypeInsuranceAgencyExported;
		[Static]
		[Export ("kGMSPlaceTypeInsuranceAgencyExported")]
		string InsuranceAgency { get; }
	
		// -(NSString *)kGMSPlaceTypeIntersectionExported;
		[Static]
		[Export ("kGMSPlaceTypeIntersectionExported")]
		string Intersection { get; }
	
		// -(NSString *)kGMSPlaceTypeJewelryStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeJewelryStoreExported")]
		string JewelryStore { get; }
	
		// -(NSString *)kGMSPlaceTypeLaundryExported;
		[Static]
		[Export ("kGMSPlaceTypeLaundryExported")]
		string Laundry { get; }
	
		// -(NSString *)kGMSPlaceTypeLawyerExported;
		[Static]
		[Export ("kGMSPlaceTypeLawyerExported")]
		string Lawyer { get; }
	
		// -(NSString *)kGMSPlaceTypeLibraryExported;
		[Static]
		[Export ("kGMSPlaceTypeLibraryExported")]
		string Library { get; }
	
		// -(NSString *)kGMSPlaceTypeLiquorStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeLiquorStoreExported")]
		string LiquorStore { get; }
	
		// -(NSString *)kGMSPlaceTypeLocalGovernmentOfficeExported;
		[Static]
		[Export ("kGMSPlaceTypeLocalGovernmentOfficeExported")]
		string LocalGovernmentOffice { get; }
	
		// -(NSString *)kGMSPlaceTypeLocalityExported;
		[Static]
		[Export ("kGMSPlaceTypeLocalityExported")]
		string Locality { get; }
	
		// -(NSString *)kGMSPlaceTypeLocksmithExported;
		[Static]
		[Export ("kGMSPlaceTypeLocksmithExported")]
		string Locksmith { get; }
	
		// -(NSString *)kGMSPlaceTypeLodgingExported;
		[Static]
		[Export ("kGMSPlaceTypeLodgingExported")]
		string Lodging { get; }
	
		// -(NSString *)kGMSPlaceTypeMealDeliveryExported;
		[Static]
		[Export ("kGMSPlaceTypeMealDeliveryExported")]
		string MealDelivery { get; }
	
		// -(NSString *)kGMSPlaceTypeMealTakeawayExported;
		[Static]
		[Export ("kGMSPlaceTypeMealTakeawayExported")]
		string MealTakeaway { get; }
	
		// -(NSString *)kGMSPlaceTypeMosqueExported;
		[Static]
		[Export ("kGMSPlaceTypeMosqueExported")]
		string Mosque { get; }
	
		// -(NSString *)kGMSPlaceTypeMovieRentalExported;
		[Static]
		[Export ("kGMSPlaceTypeMovieRentalExported")]
		string MovieRental { get; }
	
		// -(NSString *)kGMSPlaceTypeMovieTheaterExported;
		[Static]
		[Export ("kGMSPlaceTypeMovieTheaterExported")]
		string MovieTheater { get; }
	
		// -(NSString *)kGMSPlaceTypeMovingCompanyExported;
		[Static]
		[Export ("kGMSPlaceTypeMovingCompanyExported")]
		string MovingCompany { get; }
	
		// -(NSString *)kGMSPlaceTypeMuseumExported;
		[Static]
		[Export ("kGMSPlaceTypeMuseumExported")]
		string Museum { get; }
	
		// -(NSString *)kGMSPlaceTypeNaturalFeatureExported;
		[Static]
		[Export ("kGMSPlaceTypeNaturalFeatureExported")]
		string NaturalFeature { get; }
	
		// -(NSString *)kGMSPlaceTypeNeighborhoodExported;
		[Static]
		[Export ("kGMSPlaceTypeNeighborhoodExported")]
		string Neighborhood { get; }
	
		// -(NSString *)kGMSPlaceTypeNightClubExported;
		[Static]
		[Export ("kGMSPlaceTypeNightClubExported")]
		string NightClub { get; }
	
		// -(NSString *)kGMSPlaceTypePainterExported;
		[Static]
		[Export ("kGMSPlaceTypePainterExported")]
		string Painter { get; }
	
		// -(NSString *)kGMSPlaceTypeParkExported;
		[Static]
		[Export ("kGMSPlaceTypeParkExported")]
		string Park { get; }
	
		// -(NSString *)kGMSPlaceTypeParkingExported;
		[Static]
		[Export ("kGMSPlaceTypeParkingExported")]
		string Parking { get; }
	
		// -(NSString *)kGMSPlaceTypePetStoreExported;
		[Static]
		[Export ("kGMSPlaceTypePetStoreExported")]
		string PetStore { get; }
	
		// -(NSString *)kGMSPlaceTypePharmacyExported;
		[Static]
		[Export ("kGMSPlaceTypePharmacyExported")]
		string Pharmacy { get; }
	
		// -(NSString *)kGMSPlaceTypePhysiotherapistExported;
		[Static]
		[Export ("kGMSPlaceTypePhysiotherapistExported")]
		string Physiotherapist { get; }
	
		// -(NSString *)kGMSPlaceTypePlaceOfWorshipExported;
		[Static]
		[Export ("kGMSPlaceTypePlaceOfWorshipExported")]
		string PlaceOfWorship { get; }
	
		// -(NSString *)kGMSPlaceTypePlumberExported;
		[Static]
		[Export ("kGMSPlaceTypePlumberExported")]
		string Plumber { get; }
	
		// -(NSString *)kGMSPlaceTypePointOfInterestExported;
		[Static]
		[Export ("kGMSPlaceTypePointOfInterestExported")]
		string PointOfInterest { get; }
	
		// -(NSString *)kGMSPlaceTypePoliceExported;
		[Static]
		[Export ("kGMSPlaceTypePoliceExported")]
		string Police { get; }
	
		// -(NSString *)kGMSPlaceTypePoliticalExported;
		[Static]
		[Export ("kGMSPlaceTypePoliticalExported")]
		string Political { get; }
	
		// -(NSString *)kGMSPlaceTypePostBoxExported;
		[Static]
		[Export ("kGMSPlaceTypePostBoxExported")]
		string PostBox { get; }
	
		// -(NSString *)kGMSPlaceTypePostOfficeExported;
		[Static]
		[Export ("kGMSPlaceTypePostOfficeExported")]
		string PostOffice { get; }
	
		// -(NSString *)kGMSPlaceTypePostalCodeExported;
		[Static]
		[Export ("kGMSPlaceTypePostalCodeExported")]
		string PostalCode { get; }
	
		// -(NSString *)kGMSPlaceTypePostalCodePrefixExported;
		[Static]
		[Export ("kGMSPlaceTypePostalCodePrefixExported")]
		string PostalCodePrefix { get; }
	
		// -(NSString *)kGMSPlaceTypePostalTownExported;
		[Static]
		[Export ("kGMSPlaceTypePostalTownExported")]
		string PostalTown { get; }
	
		// -(NSString *)kGMSPlaceTypePremiseExported;
		[Static]
		[Export ("kGMSPlaceTypePremiseExported")]
		string Premise { get; }
	
		// -(NSString *)kGMSPlaceTypeRealEstateAgencyExported;
		[Static]
		[Export ("kGMSPlaceTypeRealEstateAgencyExported")]
		string RealEstateAgency { get; }
	
		// -(NSString *)kGMSPlaceTypeRestaurantExported;
		[Static]
		[Export ("kGMSPlaceTypeRestaurantExported")]
		string Restaurant { get; }
	
		// -(NSString *)kGMSPlaceTypeRoofingContractorExported;
		[Static]
		[Export ("kGMSPlaceTypeRoofingContractorExported")]
		string RoofingContractor { get; }
	
		// -(NSString *)kGMSPlaceTypeRoomExported;
		[Static]
		[Export ("kGMSPlaceTypeRoomExported")]
		string Room { get; }
	
		// -(NSString *)kGMSPlaceTypeRouteExported;
		[Static]
		[Export ("kGMSPlaceTypeRouteExported")]
		string Route { get; }
	
		// -(NSString *)kGMSPlaceTypeRvParkExported;
		[Static]
		[Export ("kGMSPlaceTypeRvParkExported")]
		string RvPark { get; }
	
		// -(NSString *)kGMSPlaceTypeSchoolExported;
		[Static]
		[Export ("kGMSPlaceTypeSchoolExported")]
		string School { get; }
	
		// -(NSString *)kGMSPlaceTypeShoeStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeShoeStoreExported")]
		string ShoeStore { get; }
	
		// -(NSString *)kGMSPlaceTypeShoppingMallExported;
		[Static]
		[Export ("kGMSPlaceTypeShoppingMallExported")]
		string ShoppingMall { get; }
	
		// -(NSString *)kGMSPlaceTypeSpaExported;
		[Static]
		[Export ("kGMSPlaceTypeSpaExported")]
		string Spa { get; }
	
		// -(NSString *)kGMSPlaceTypeStadiumExported;
		[Static]
		[Export ("kGMSPlaceTypeStadiumExported")]
		string Stadium { get; }
	
		// -(NSString *)kGMSPlaceTypeStorageExported;
		[Static]
		[Export ("kGMSPlaceTypeStorageExported")]
		string Storage { get; }
	
		// -(NSString *)kGMSPlaceTypeStoreExported;
		[Static]
		[Export ("kGMSPlaceTypeStoreExported")]
		string Store { get; }
	
		// -(NSString *)kGMSPlaceTypeStreetAddressExported;
		[Static]
		[Export ("kGMSPlaceTypeStreetAddressExported")]
		string StreetAddress { get; }
	
		// -(NSString *)kGMSPlaceTypeSublocalityExported;
		[Static]
		[Export ("kGMSPlaceTypeSublocalityExported")]
		string Sublocality { get; }
	
		// -(NSString *)kGMSPlaceTypeSublocalityLevel1Exported;
		[Static]
		[Export ("kGMSPlaceTypeSublocalityLevel1Exported")]
		string SublocalityLevel1 { get; }
	
		// -(NSString *)kGMSPlaceTypeSublocalityLevel2Exported;
		[Static]
		[Export ("kGMSPlaceTypeSublocalityLevel2Exported")]
		string SublocalityLevel2 { get; }
	
		// -(NSString *)kGMSPlaceTypeSublocalityLevel3Exported;
		[Static]
		[Export ("kGMSPlaceTypeSublocalityLevel3Exported")]
		string SublocalityLevel3 { get; }
	
		// -(NSString *)kGMSPlaceTypeSublocalityLevel4Exported;
		[Static]
		[Export ("kGMSPlaceTypeSublocalityLevel4Exported")]
		string SublocalityLevel4 { get; }
	
		// -(NSString *)kGMSPlaceTypeSublocalityLevel5Exported;
		[Static]
		[Export ("kGMSPlaceTypeSublocalityLevel5Exported")]
		string SublocalityLevel5 { get; }
	
		// -(NSString *)kGMSPlaceTypeSubpremiseExported;
		[Static]
		[Export ("kGMSPlaceTypeSubpremiseExported")]
		string Subpremise { get; }
	
		// -(NSString *)kGMSPlaceTypeSubwayStationExported;
		[Static]
		[Export ("kGMSPlaceTypeSubwayStationExported")]
		string SubwayStation { get; }
	
		// -(NSString *)kGMSPlaceTypeSynagogueExported;
		[Static]
		[Export ("kGMSPlaceTypeSynagogueExported")]
		string Synagogue { get; }
	
		// -(NSString *)kGMSPlaceTypeTaxiStandExported;
		[Static]
		[Export ("kGMSPlaceTypeTaxiStandExported")]
		string TaxiStand { get; }
	
		// -(NSString *)kGMSPlaceTypeTrainStationExported;
		[Static]
		[Export ("kGMSPlaceTypeTrainStationExported")]
		string TrainStation { get; }
	
		// -(NSString *)kGMSPlaceTypeTransitStationExported;
		[Static]
		[Export ("kGMSPlaceTypeTransitStationExported")]
		string TransitStation { get; }
	
		// -(NSString *)kGMSPlaceTypeTravelAgencyExported;
		[Static]
		[Export ("kGMSPlaceTypeTravelAgencyExported")]
		string TravelAgency { get; }
	
		// -(NSString *)kGMSPlaceTypeUniversityExported;
		[Static]
		[Export ("kGMSPlaceTypeUniversityExported")]
		string University { get; }
	
		// -(NSString *)kGMSPlaceTypeVeterinaryCareExported;
		[Static]
		[Export ("kGMSPlaceTypeVeterinaryCareExported")]
		string VeterinaryCare { get; }
	
		// -(NSString *)kGMSPlaceTypeZooExported;
		[Static]
		[Export ("kGMSPlaceTypeZooExported")]
		string Zoo { get; }
	}

	[BaseType (typeof(Overlay), Name = "GMSPolygon")]
	interface Polygon
	{

		[Export ("path", ArgumentSemantic.Copy)]
		Path Path { get; set; }

		// @property(nonatomic, copy) NSArray *holes;
		[Export ("holes", ArgumentSemantic.Copy)]
		Path[] Holes { get; set; }

		[Export ("strokeWidth", ArgumentSemantic.Assign)]
		nfloat StrokeWidth { get; set; }

		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[Export ("fillColor")]
		UIColor FillColor { get; set; }

		[Export ("geodesic", ArgumentSemantic.Assign)]
		bool Geodesic { get; set; }

		[Static, Export ("polygonWithPath:")]
		Polygon FromPath (Path path);
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GMSStrokeStyle")]
	interface StrokeStyle
	{

		[Static, Export ("solidColor:")]
		StrokeStyle GetSolidColor (UIColor color);

		[Static, Export ("gradientFromColor:toColor:")]
		StrokeStyle GetGradient (UIColor fromColor, UIColor toColor);
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GMSStyleSpan")]
	interface StyleSpan
	{

		[Static, Export ("spanWithColor:")]
		StyleSpan FromSolidColor (UIColor color);

		[Static, Export ("spanWithColor:segments:")]
		StyleSpan FromSolidColor (UIColor color, double segments);

		[Static, Export ("spanWithStyle:")]
		StyleSpan FromStyle (StrokeStyle style);

		[Static, Export ("spanWithStyle:segments:")]
		StyleSpan FromStyle (StrokeStyle style, double segments);

		[Export ("style")]
		StrokeStyle Style { get; }

		[Export ("segments")]
		double Segments { get; }
	}

	[BaseType (typeof(Overlay), Name = "GMSPolyline")]
	interface Polyline
	{

		[Export ("path", ArgumentSemantic.Copy)]
		Path Path { get; set; }

		[Export ("strokeWidth", ArgumentSemantic.Assign)]
		nfloat StrokeWidth { get; set; }

		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[Export ("geodesic", ArgumentSemantic.Assign)]
		bool Geodesic { get; set; }

		[Static, Export ("polylineWithPath:")]
		Polyline FromPath (Google.Maps.Path path);

		[Export ("spans", ArgumentSemantic.Copy)] [NullAllowed]
		StyleSpan [] Spans { get; set; }
	}

	[BaseType (typeof(NSObject), Name = "GMSProjection")]
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

	[BaseType (typeof(NSObject), Name = "GMSReverseGeocodeResponse")]
	interface ReverseGeocodeResponse : INSCopying
	{

		[Export ("firstResult")]
		Address FirstResult { get; }

		[Export ("results")]
		Address [] Results { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GMSServices")]
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

	[BaseType (typeof(TileLayer), Name = "GMSSyncTileLayer")]
	interface SyncTileLayer
	{

		[Export ("tileForX:y:zoom:")]
		UIImage Tile (nuint x, nuint y, nuint zoom);
	}

	interface ITileReceiver
	{

	}

	[BaseType (typeof(NSObject), Name = "GMSTileReceiver")]
	[Model]
	[Protocol]
	interface TileReceiver
	{

		[Abstract]
		[Export ("receiveTileWithX:y:zoom:image:")]
		void ReceiveTile (nuint x, nuint y, nuint zoom, [NullAllowed] UIImage image);
	}

	[BaseType (typeof(NSObject), Name = "GMSTileLayer")]
	interface TileLayer
	{

		[Export ("requestTileForX:y:zoom:receiver:")]
		void RequestTile (nuint x, nuint y, nuint zoom, ITileReceiver receiver);

		[Export ("clearTileCache")]
		void ClearTileCache ();

		[Export ("map")]
		MapView Map { get; [NullAllowed] set; }

		[Export ("zIndex", ArgumentSemantic.Assign)]
		int ZIndex { get; set; }

		[Export ("tileSize", ArgumentSemantic.Assign)]
		nint TileSize { get; set; }

		[Export ("opacity", ArgumentSemantic.Assign)]
		float Opacity { get; set; }

		[Export ("fadeIn", ArgumentSemantic.Assign)]
		bool FadeIn { get; set; }
	}

	[BaseType (typeof(NSObject), Name = "GMSUISettings")]
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

	delegate NSUrl TileURLConstructor (uint x,uint y,uint zoom);

	[DisableDefaultCtor]
	[BaseType (typeof(TileLayer), Name = "GMSURLTileLayer")]
	interface UrlTileLayer
	{

		[Static, Export ("tileLayerWithURLConstructor:")]
		UrlTileLayer FromUrlConstructor (TileURLConstructor constructor);

		[Export ("userAgent", ArgumentSemantic.Copy)] [NullAllowed]
		string UserAgent { get; set; }
	}

	// @interface GMSUserAddedPlace : NSObject
	[BaseType (typeof(NSObject), Name = "GMSUserAddedPlace")]
	interface UserAddedPlace
	{
		// @property (copy, nonatomic) NSString * name;
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * address;
		[Export ("address", ArgumentSemantic.Copy)]
		string Address { get; set; }

		// @property (assign, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Coordinate { get; set; }

		// @property (copy, nonatomic) NSString * phoneNumber;
		[Export ("phoneNumber", ArgumentSemantic.Copy)]
		string PhoneNumber { get; set; }

		// @property (copy, nonatomic) NSArray * types;
		[Export ("types", ArgumentSemantic.Copy)]
		string[] Types { get; set; }

		// @property (copy, nonatomic) NSString * website;
		[Export ("website", ArgumentSemantic.Copy)]
		string Website { get; set; }
	}



}
