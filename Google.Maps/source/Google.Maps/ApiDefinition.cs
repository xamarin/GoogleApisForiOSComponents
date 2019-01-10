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
	}

	#endregion

	[BaseType (typeof (NSObject), Name = "GMSAddress")]
	interface Address : INSCopying
	{
		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		[NullAllowed]
		[Export ("thoroughfare", ArgumentSemantic.Copy)]
		string Thoroughfare { get; }

		[NullAllowed]
		[Export ("locality", ArgumentSemantic.Copy)]
		string Locality { get; }

		[NullAllowed]
		[Export ("subLocality", ArgumentSemantic.Copy)]
		string SubLocality { get; }

		[NullAllowed]
		[Export ("administrativeArea", ArgumentSemantic.Copy)]
		string AdministrativeArea { get; }

		[NullAllowed]
		[Export ("postalCode", ArgumentSemantic.Copy)]
		string PostalCode { get; }

		[NullAllowed]
		[Export ("country", ArgumentSemantic.Copy)]
		string Country { get; }

		[NullAllowed]
		[Export ("lines", ArgumentSemantic.Copy)]
		string [] Lines { get; }

		[Obsolete ("This method is obsolete and will be removed in a future release. Use the Lines property instead.")]
		[Export ("addressLine1")]
		string AddressLine1 { get; }

		[Obsolete ("This method is obsolete and will be removed in a future release. Use the Lines property instead.")]
		[Export ("addressLine2")]
		string AddressLine2 { get; }
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

	delegate void ReverseGeocodeCallback ([NullAllowed] ReverseGeocodeResponse response, [NullAllowed] NSError error);

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
		[NullAllowed]
		[Export ("firstResult")]
		Address FirstResult { get; }

		[NullAllowed]
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
		void DidChangeActiveBuilding ([NullAllowed] IndoorBuilding building);

		[Export ("didChangeActiveLevel:")]
		void DidChangeActiveLevel ([NullAllowed] IndoorLevel level);
	}

	[BaseType (typeof (NSObject), Name = "GMSIndoorDisplay")]
	interface IndoorDisplay
	{
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Assign)]
		IIndoorDisplayDelegate Delegate { get; set; }

		[NullAllowed]
		[Export ("activeBuilding", ArgumentSemantic.Retain)]
		IndoorBuilding ActiveBuilding { get; }

		[NullAllowed]
		[Export ("activeLevel", ArgumentSemantic.Retain)]
		IndoorLevel ActiveLevel { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSIndoorLevel")]
	interface IndoorLevel
	{
		[NullAllowed]
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[NullAllowed]
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

	// @interface GMSMapStyle : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSMapStyle")]
	interface MapStyle
	{
		// + (GMS_NULLABLE_INSTANCETYPE)styleWithJSONString:(NSString *)style error:(NSError* __autoreleasing GMS_NULLABLE_PTR*)error;
		[Static]
		[return: NullAllowed]
		[Export ("styleWithJSONString:error:")]
		MapStyle FromJson (string jsonStyle, [NullAllowed] NSError error);

		// (GMS_NULLABLE_INSTANCETYPE) styleWithContentsOfFileURL:(NSURL*)fileURL error:(NSError* __autoreleasing GMS_NULLABLE_PTR*)error;
		[Static]
		[return: NullAllowed]
		[Export ("styleWithContentsOfFileURL:error:")]
		MapStyle FromUrl (NSUrl fileUrl, [NullAllowed] NSError error);
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

		// - (void)mapView:(GMSMapView *)mapView didTapPOIWithPlaceID:(NSString*)placeID name:(NSString*)name location:(CLLocationCoordinate2D)location;
		[Export ("mapView:didTapPOIWithPlaceID:name:location:"), EventArgs ("GMSPoiWithPlaceIdEvent"), EventName ("PoiWithPlaceIdTapped")]
		void DidTapPoiWithPlaceId (MapView mapView, string placeId, string name, CLLocationCoordinate2D location);

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

		// - (void)mapView:(GMSMapView *)mapView didTapMyLocation:(CLLocationCoordinate2D)location;
		[Export ("mapView:didTapMyLocation:"), EventArgs ("GMSMyLocationTapped"), EventName ("MyLocationTapped")]
		void DidTapMyLocation (MapView mapView, CLLocationCoordinate2D location);

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
		Events = new Type [] { typeof (MapViewDelegate) } )]
	interface MapView
	{

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Assign)]
		IMapViewDelegate Delegate { get; set; }

		[Export ("camera", ArgumentSemantic.Copy)]
		CameraPosition Camera { get; set; }

		[Export ("projection")]
		Projection Projection { get; }

		[Export ("myLocationEnabled", ArgumentSemantic.Assign)]
		bool MyLocationEnabled { [Bind ("isMyLocationEnabled")] get; set; }

		[NullAllowed]
		[Export ("myLocation")]
		CLLocation MyLocation { get; }

		[NullAllowed]
		[Export ("selectedMarker")]
		Marker SelectedMarker { get; set; }

		[Export ("trafficEnabled", ArgumentSemantic.Assign)]
		bool TrafficEnabled { [Bind ("isTrafficEnabled")] get; set; }

		[Export ("mapType", ArgumentSemantic.Assign)]
		MapViewType MapType { get; set; }

		// @property(nonatomic, strong, nullable) GMSMapStyle *mapStyle;
		[NullAllowed]
		[Export ("mapStyle", ArgumentSemantic.Strong)]
		MapStyle MapStyle { get; set; }

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

		[Export("paddingAdjustmentBehavior", ArgumentSemantic.Assign)]
		MapViewPaddingAdjustmentBehavior PaddingAdjustmentBehavior { get; set; }

		[Export ("accessibilityElementsHidden", ArgumentSemantic.Assign)]
		[New]
		bool AccessibilityElementsHidden { get; set; }

		[Export ("layer", ArgumentSemantic.Retain)]
		[New]
		MapLayer Layer { get; }

		// @property(nonatomic, assign) GMSFrameRate preferredFrameRate;
		[Export ("preferredFrameRate", ArgumentSemantic.Assign)]
		FrameRate PreferredFrameRate { get; set; }

		// @property(nonatomic, nullable) GMSCoordinateBounds *cameraTargetBounds;
		[NullAllowed]
		[Export ("cameraTargetBounds", ArgumentSemantic.Strong)]
		CoordinateBounds CameraTargetBounds { get; set; }

		[Static]
		[Export ("mapWithFrame:camera:")]
		MapView FromCamera (CGRect frame, CameraPosition camera);

		[Obsolete ("This method is obsolete and will be removed in a future release.")]
		[Export ("startRendering")]
		void StartRendering ();

		[Obsolete ("This method is obsolete and will be removed in a future release.")]
		[Export ("stopRendering")]
		void StopRendering ();

		[Export ("clear")]
		void Clear ();

		[Export ("setMinZoom:maxZoom:")]
		void SetMinMaxZoom (float minZoom, float maxZoom);

		[return: NullAllowed]
		[Export ("cameraForBounds:insets:")]
		CameraPosition CameraForBounds (CoordinateBounds bounds, UIEdgeInsets insets);

		[Export ("moveCamera:")]
		void MoveCamera (CameraUpdate update);

		// - (BOOL)areEqualForRenderingPosition:(GMSCameraPosition *)position position:(GMSCameraPosition*)otherPosition;
		[Export ("areEqualForRenderingPosition:position:")]
		bool Equals (CameraPosition position, CameraPosition otherPosition);
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
		[NullAllowed]
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

		[New]
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
	[BaseType (typeof (OverlayLayer), Name = "GMSMarkerLayer")]
	interface MarkerLayer
	{

		[Export ("latitude", ArgumentSemantic.Assign)]
		double Latitude { get; set; }

		[Export ("longitude", ArgumentSemantic.Assign)]
		double Longitude { get; set; }

		[Export ("rotation", ArgumentSemantic.Assign)]
		double Rotation { get; set; }

		[New]
		[Export ("opacity", ArgumentSemantic.Assign)]
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

		// @property(nonatomic, strong, nullable) id userData;
		[NullAllowed]
		[Export ("userData", ArgumentSemantic.Strong)]
		NSObject UserData { get; set; }
	}

	// @interface GMSOverlayLayer : CALayer
	[DisableDefaultCtor]
	[BaseType (typeof (CALayer), Name = "GMSOverlayLayer")]
	interface OverlayLayer { }

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

	delegate void PanoramaCallback ([NullAllowed] Panorama panorama, [NullAllowed] NSError error);

	[BaseType (typeof (NSObject), Name = "GMSPanoramaService")]
	interface PanoramaService
	{
		[Export ("requestPanoramaNearCoordinate:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, PanoramaCallback callback);

		[Export ("requestPanoramaNearCoordinate:radius:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, nuint radius, PanoramaCallback callback);

		// - (void)requestPanoramaNearCoordinate:(CLLocationCoordinate2D)coordinate source:(GMSPanoramaSource)source callback:(GMSPanoramaCallback)callback;
		[Export ("requestPanoramaNearCoordinate:source:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, PanoramaSource source, PanoramaCallback callback);

		// - (void) requestPanoramaNearCoordinate:(CLLocationCoordinate2D)coordinate radius:(NSUInteger)radius source:(GMSPanoramaSource)source callback:(GMSPanoramaCallback)callback;
		[Export ("requestPanoramaNearCoordinate:radius:source:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, nuint radius, PanoramaSource source, PanoramaCallback callback);

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
		void DidMoveToPanorama (PanoramaView view, [NullAllowed] Panorama panorama);

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
		Events = new Type [] { typeof (PanoramaViewDelegate) })]
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

		// -(void)moveNearCoordinate:(CLLocationCoordinate2D)coordinate source:(GMSPanoramaSource)source;
		[Export ("moveNearCoordinate:source:")]
		void MoveNearCoordinate (CLLocationCoordinate2D coordinate, PanoramaSource source);

		// -(void)moveNearCoordinate:(CLLocationCoordinate2D)coordinate radius:(NSUInteger)radius source:(GMSPanoramaSource)source;
		[Export ("moveNearCoordinate:radius:source:")]
		void MoveNearCoordinate (CLLocationCoordinate2D coordinate, nuint radius, PanoramaSource source);

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

		// +(instancetype _Nonnull)panoramaWithFrame:(CGRect)frame nearCoordinate:(CLLocationCoordinate2D)coordinate source:(GMSPanoramaSource)source;
		[Static]
		[Export ("panoramaWithFrame:nearCoordinate:source:")]
		PanoramaView FromFrame (CGRect frame, CLLocationCoordinate2D coordinate, PanoramaSource source);

		// +(instancetype _Nonnull)panoramaWithFrame:(CGRect)frame nearCoordinate:(CLLocationCoordinate2D)coordinate radius:(NSUInteger)radius source:(GMSPanoramaSource)source;
		[Static]
		[Export ("panoramaWithFrame:nearCoordinate:radius:source:")]
		PanoramaView FromFrame (CGRect frame, CLLocationCoordinate2D coordinate, nuint radius, PanoramaSource source);
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

		[Static]
		[return: NullAllowed]
		[Export ("pathFromEncodedPath:")]
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

		// +(BOOL)provideAPIOptions:(NSArray<NSString *> * _Nonnull)APIOptions;
		[Static]
		[Export ("provideAPIOptions:")]
		bool ProvideApiOptions (string [] apiOptions);

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
		[return: NullAllowed]
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
}
