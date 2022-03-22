using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreLocation;
using CoreAnimation;
using CoreGraphics;

#if !NET
using NativeHandle = System.IntPtr;
#endif

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

		[Field ("kGMSAccessiblityOutOfQuota", "__Internal")]
		NSString AccessiblityOutOfQuota { get; }

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
		NativeHandle Constructor (CLLocationCoordinate2D target, float zoom, double bearing, double viewingAngle);

		// -(instancetype _Nonnull)initWithTarget:(CLLocationCoordinate2D)target zoom:(float)zoom;
		[Export ("initWithTarget:zoom:")]
		NativeHandle Constructor (CLLocationCoordinate2D target, float zoom);

		// -(instancetype _Nonnull)initWithLatitude:(CLLocationDegrees)latitude longitude:(CLLocationDegrees)longitude zoom:(float)zoom;
		[Export ("initWithLatitude:longitude:zoom:")]
		NativeHandle Constructor (double latitude, double longitude, float zoom);

		// -(instancetype _Nonnull)initWithLatitude:(CLLocationDegrees)latitude longitude:(CLLocationDegrees)longitude zoom:(float)zoom bearing:(CLLocationDirection)bearing viewingAngle:(double)viewingAngle;
		[Export ("initWithLatitude:longitude:zoom:bearing:viewingAngle:")]
		NativeHandle Constructor (double latitude, double longitude, float zoom, double bearing, double viewingAngle);

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
		NativeHandle Constructor (CLLocationCoordinate2D coord1, CLLocationCoordinate2D coord2);

		[Export ("initWithRegion:")]
		NativeHandle Constructor (VisibleRegion region);

		[Export ("initWithPath:")]
		NativeHandle Constructor (Google.Maps.Path path);

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

		[Async]
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

		[Export ("position")]
		CLLocationCoordinate2D Position { get; set; }

		[Export ("anchor")]
		CGPoint Anchor { get; set; }

		[NullAllowed]
		[Export ("icon")]
		UIImage Icon { get; set; }

		// @property(nonatomic, assign) float opacity;
		[Export ("opacity")]
		float Opacity { get; set; }

		[Export ("bearing")]
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

#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
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
		[Export ("activeBuilding")]
		IndoorBuilding ActiveBuilding { get; }

		[NullAllowed]
		[Export ("activeLevel")]
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

		[Export ("cameraLatitude")]
		double CameraLatitude { get; set; }

		[Export ("cameraLongitude")]
		double CameraLongitude { get; set; }

		[Export ("cameraBearing")]
		double CameraBearing { get; set; }

		[Export ("cameraZoomLevel")]
		float CameraZoomLevel { get; set; }

		[Export ("cameraViewingAngle")]
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

#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSMapViewDelegate")]
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
		NativeHandle Constructor (CGRect frame);

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Assign)]
		IMapViewDelegate Delegate { get; set; }

		[Export ("camera", ArgumentSemantic.Copy)]
		CameraPosition Camera { get; set; }

		[Export ("projection")]
		Projection Projection { get; }

		[Export ("myLocationEnabled")]
		bool MyLocationEnabled { [Bind ("isMyLocationEnabled")] get; set; }

		[NullAllowed]
		[Export ("myLocation")]
		CLLocation MyLocation { get; }

		[NullAllowed]
		[Export ("selectedMarker")]
		Marker SelectedMarker { get; set; }

		[Export ("trafficEnabled")]
		bool TrafficEnabled { [Bind ("isTrafficEnabled")] get; set; }

		[Export ("mapType")]
		MapViewType MapType { get; set; }

		// @property(nonatomic, strong, nullable) GMSMapStyle *mapStyle;
		[NullAllowed]
		[Export ("mapStyle")]
		MapStyle MapStyle { get; set; }

		[Export ("minZoom")]
		float MinZoom { get; }

		[Export ("maxZoom")]
		float MaxZoom { get; }

		[Export ("buildingsEnabled")]
		bool BuildingsEnabled { [Bind ("isBuildingsEnabled")] get; set; }

		[Export ("indoorEnabled")]
		bool IndoorEnabled { [Bind ("isIndoorEnabled")] get; set; }

		[Export ("indoorDisplay")]
		IndoorDisplay IndoorDisplay { get; }

		[Export ("settings")]
		UISettings Settings { get; }

		[Export ("padding")]
		UIEdgeInsets Padding { get; set; }

		[Export ("paddingAdjustmentBehavior")]
		MapViewPaddingAdjustmentBehavior PaddingAdjustmentBehavior { get; set; }

		[Export ("accessibilityElementsHidden")]
		[New]
		bool AccessibilityElementsHidden { get; set; }

		[Export ("layer", ArgumentSemantic.Retain)]
		[New]
		MapLayer Layer { get; }

		// @property(nonatomic, assign) GMSFrameRate preferredFrameRate;
		[Export ("preferredFrameRate")]
		FrameRate PreferredFrameRate { get; set; }

		// @property(nonatomic, nullable) GMSCoordinateBounds *cameraTargetBounds;
		[NullAllowed]
		[Export ("cameraTargetBounds")]
		CoordinateBounds CameraTargetBounds { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame camera:(GMSCameraPosition * _Nonnull)camera;
		[Export ("initWithFrame:camera:")]
		NativeHandle Constructor (CGRect frame, CameraPosition camera);

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

		///
		/// From a category (GMSMapView+Premium.h)
		///

		// +(instancetype _Nonnull)mapWithFrame:(CGRect)frame mapID:(GMSMapID * _Nonnull)mapID camera:(GMSCameraPosition * _Nonnull)camera __attribute__((availability(swift, unavailable)));		
		[Static]
		[Export ("mapWithFrame:mapID:camera:")]
		MapView MapWithFrame (CGRect frame, MapId mapId, CameraPosition camera);

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame mapID:(GMSMapID * _Nonnull)mapID camera:(GMSCameraPosition * _Nonnull)camera;
		[Export ("initWithFrame:mapID:camera:")]
		NativeHandle Constructor (CGRect frame, MapId mapId, CameraPosition camera);
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

		[Export ("position")]
		CLLocationCoordinate2D Position { get; set; }

		[NullAllowed]
		[Export ("snippet", ArgumentSemantic.Copy)]
		string Snippet { get; set; }

		[NullAllowed]
		[Export ("icon")]
		UIImage Icon { get; set; }

		// @property(nonatomic, strong) UIView *iconView;
		[NullAllowed]
		[Export ("iconView")]
		UIView IconView { get; set; }

		// @property(nonatomic, assign) BOOL tracksViewChanges;
		[Export ("tracksViewChanges")]
		bool TracksViewChanges { get; set; }

		// @property(nonatomic, assign) BOOL tracksInfoWindowChanges;
		[Export ("tracksInfoWindowChanges")]
		bool TracksInfoWindowChanges { get; set; }

		[Export ("groundAnchor")]
		CGPoint GroundAnchor { get; set; }

		[Export ("infoWindowAnchor")]
		CGPoint InfoWindowAnchor { get; set; }

		[Export ("appearAnimation")]
		MarkerAnimation AppearAnimation { get; set; }

		[Export ("draggable")]
		bool Draggable { [Bind ("isDraggable")] get; set; }

		[Export ("flat")]
		bool Flat { [Bind ("isFlat")] get; set; }

		[Export ("rotation")]
		double Rotation { get; set; }

		[Export ("opacity")]
		float Opacity { get; set; }

		[Export ("layer")]
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

		///
		/// From a category (GMSMarker+Premium.h)
		///

		// @property (nonatomic) GMSCollisionBehavior collisionBehavior;
		[Export ("collisionBehavior", ArgumentSemantic.Assign)]
		CollisionBehavior CollisionBehavior { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (OverlayLayer), Name = "GMSMarkerLayer")]
	interface MarkerLayer
	{

		[Export ("latitude")]
		double Latitude { get; set; }

		[Export ("longitude")]
		double Longitude { get; set; }

		[Export ("rotation")]
		double Rotation { get; set; }

		[New]
		[Export ("opacity")]
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

		[Export ("tappable")]
		bool Tappable { [Bind ("isTappable")] get; set; }

		[Export ("zIndex")]
		int ZIndex { get; set; }

		// @property(nonatomic, strong, nullable) id userData;
		[NullAllowed]
		[Export ("userData")]
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
		string PanoramaId { get; }

		[Export ("links", ArgumentSemantic.Copy)]
		PanoramaLink [] Links { get; }
	}

	[BaseType (typeof (NSObject), Name = "GMSPanoramaCamera")]
	interface PanoramaCamera
	{

		[Export ("initWithOrientation:zoom:FOV:")]
		NativeHandle Constructor (Orientation orientation, float zoom, double fov);

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

		[Export ("FOV")]
		double Fov { get; }

		[Export ("zoom")]
		float Zoom { get; }

		[Export ("orientation")]
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

		[Export ("cameraHeading")]
		double CameraHeading { get; set; }

		[Export ("cameraPitch")]
		double CameraPitch { get; set; }

		[Export ("cameraZoom")]
		float CameraZoom { get; set; }

		[Export ("cameraFOV")]
		double CameraFOV { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GMSPanoramaLink")]
	interface PanoramaLink
	{

		[Export ("heading")]
		nfloat Heading { get; set; }

		[Export ("panoramaID", ArgumentSemantic.Copy)]
		string PanoramaId { get; set; }
	}

	delegate void PanoramaCallback ([NullAllowed] Panorama panorama, [NullAllowed] NSError error);

	[BaseType (typeof (NSObject), Name = "GMSPanoramaService")]
	interface PanoramaService
	{
		[Async]
		[Export ("requestPanoramaNearCoordinate:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, PanoramaCallback callback);

		[Async]
		[Export ("requestPanoramaNearCoordinate:radius:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, nuint radius, PanoramaCallback callback);

		// - (void)requestPanoramaNearCoordinate:(CLLocationCoordinate2D)coordinate source:(GMSPanoramaSource)source callback:(GMSPanoramaCallback)callback;
		[Async]
		[Export ("requestPanoramaNearCoordinate:source:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, PanoramaSource source, PanoramaCallback callback);

		// - (void) requestPanoramaNearCoordinate:(CLLocationCoordinate2D)coordinate radius:(NSUInteger)radius source:(GMSPanoramaSource)source callback:(GMSPanoramaCallback)callback;
		[Async]
		[Export ("requestPanoramaNearCoordinate:radius:source:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, nuint radius, PanoramaSource source, PanoramaCallback callback);

		[Async]
		[Export ("requestPanoramaWithID:callback:")]
		void RequestPanorama (string panoramaId, PanoramaCallback callback);
	}

	interface IPanoramaViewDelegate
	{

	}

#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSPanoramaViewDelegate")]
	interface PanoramaViewDelegate
	{

		[Export ("panoramaView:willMoveToPanoramaID:"), EventArgs ("GMSPanoramaWillMove")]
		void WillMoveToPanoramaId (PanoramaView view, string panoramaId);

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
		NativeHandle Constructor (CGRect frame);

		[NullAllowed]
		[Export ("panorama")]
		Panorama Panorama { get; set; }

		[NullAllowed]
		[Export ("delegate")]
		IPanoramaViewDelegate Delegate { get; set; }

		[Export ("setAllGesturesEnabled:")]
		void SetAllGesturesEnabled (bool enabled);

		[Export ("orientationGestures")]
		bool OrientationGestures { get; set; }

		[Export ("zoomGestures")]
		bool ZoomGestures { get; set; }

		[Export ("navigationGestures")]
		bool NavigationGestures { get; set; }

		[Export ("navigationLinksHidden")]
		bool NavigationLinksHidden { get; set; }

		[Export ("streetNamesHidden")]
		bool StreetNamesHidden { get; set; }

		[Export ("camera")]
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
		NativeHandle Constructor (Path path);

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

		[Export ("strokeWidth")]
		nfloat StrokeWidth { get; set; }

		[NullAllowed]
		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[NullAllowed]
		[Export ("fillColor")]
		UIColor FillColor { get; set; }

		[Export ("geodesic")]
		bool Geodesic { get; set; }

		[Static]
		[Export ("polygonWithPath:")]
		Polygon FromPath ([NullAllowed] Path path);
	}

	// @interface GMSPolygonLayer : GMSOverlayLayer
	[BaseType (typeof (OverlayLayer), Name = "GMSPolygonLayer")]
	interface PolygonLayer {
		// extern NSString *const _Nonnull kGMSPolygonLayerStrokeWidth;
		[Field ("kGMSPolygonLayerStrokeWidth", "__Internal")]
		NSString StrokeWidthKey { get; }

		// extern NSString *const _Nonnull kGMSPolygonLayerStrokeColor;
		[Field ("kGMSPolygonLayerStrokeColor", "__Internal")]
		NSString StrokeColorKey { get; }

		// extern NSString *const _Nonnull kGMSPolygonLayerFillColor;
		[Field ("kGMSPolygonLayerFillColor", "__Internal")]
		NSString FillColorKey { get; }

		// @property (assign, nonatomic) CGFloat strokeWidth;
		[Export ("strokeWidth")]
		nfloat StrokeWidth { get; set; }

		// @property (assign, nonatomic) CGColorRef _Nullable strokeColor;
		[NullAllowed]
		[Export ("strokeColor")]
		CGColor StrokeColor { get; set; }

		// @property (assign, nonatomic) CGColorRef _Nullable fillColor;
		[NullAllowed]
		[Export ("fillColor", ArgumentSemantic.Assign)]
		CGColor FillColor { get; set; }
	}

	[BaseType (typeof (Overlay), Name = "GMSPolyline")]
	interface Polyline
	{
		[NullAllowed]
		[Export ("path", ArgumentSemantic.Copy)]
		Path Path { get; set; }

		[Export ("strokeWidth")]
		nfloat StrokeWidth { get; set; }

		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[Export ("geodesic")]
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
		bool ProvideApiKey (string apiKey);

		// +(BOOL)provideAPIOptions:(NSArray<NSString *> * _Nonnull)APIOptions;
		[Static]
		[Export ("provideAPIOptions:")]
		bool ProvideApiOptions (string [] apiOptions);

		// + (void)setMetalRendererEnabled:(BOOL)enabled;
		[Static]
		[Export ("setMetalRendererEnabled:")]
		bool SetMetalRendererEnabled (bool enabled);

		// + (void)setAbnormalTerminationReportingEnabled:(BOOL)enabled;
		[Static]
		[Export ("setAbnormalTerminationReportingEnabled:")]
		bool AbnormalTerminationReportingEnabled (bool enabled);

		[Static]
		[Export ("openSourceLicenseInfo")]
		string OpenSourceLicenseInfo { get; }

		[Static]
		[Export ("SDKVersion")]
		string SdkVersion { get; }

		// +(NSString * _Nonnull)SDKLongVersion;
		[Static]
		[Export ("SDKLongVersion")]
		string SdkLongVersion { get; }
	}

	[DisableDefaultCtor]
	[BaseType(typeof(NSObject), Name = "GMSStrokeStyle")]
	interface StrokeStyle
	{
		// @property(nonatomic, strong, nullable) GMSStampStyle *stampStyle;
		[Export ("stampStyle")]
		StampStyle StampStyle { get; }

		[Static]
		[Export ("solidColor:")]
		StrokeStyle GetSolidColor (UIColor color);

		[Static]
		[Export ("gradientFromColor:toColor:")]
		StrokeStyle GetGradient (UIColor fromColor, UIColor toColor);
	}

	[DisableDefaultCtor]
	[BaseType(typeof(NSObject), Name = "GMSStyleSpan")]
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

#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSTileReceiver")]
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

		[Export ("zIndex")]
		int ZIndex { get; set; }

		[Export ("tileSize")]
		nint TileSize { get; set; }

		[Export ("opacity")]
		float Opacity { get; set; }

		[Export ("fadeIn")]
		bool FadeIn { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GMSUISettings")]
	interface UISettings
	{

		[Export ("setAllGesturesEnabled:")]
		void SetAllGesturesEnabled (bool enabled);

		[Export ("scrollGestures")]
		bool ScrollGestures { get; set; }

		[Export ("zoomGestures")]
		bool ZoomGestures { get; set; }

		[Export ("tiltGestures")]
		bool TiltGestures { get; set; }

		[Export ("rotateGestures")]
		bool RotateGestures { get; set; }

		[Export ("consumesGesturesInView")]
		bool ConsumesGesturesInView { get; set; }

		[Export ("compassButton")]
		bool CompassButton { get; set; }

		[Export ("myLocationButton")]
		bool MyLocationButton { get; set; }

		[Export ("indoorPicker")]
		bool IndoorPicker { get; set; }

		// @property (assign, nonatomic) BOOL allowScrollGesturesDuringRotateOrZoom;
		[Export ("allowScrollGesturesDuringRotateOrZoom")]
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


	// @interface GMSStampStyle : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSStampStyle")]	
	interface StampStyle {
		// @property (readonly, nonatomic) UIImage * _Nonnull stampImage;
		[Export ("stampImage")]
		UIImage StampImage { get; }
	}

	// @interface GMSTextureStyle : GMSStampStyle
	[BaseType (typeof (StampStyle), Name = "GMSTextureStyle")]
	interface TextureStyle {
		// +(instancetype _Nonnull)textureStyleWithImage:(UIImage * _Nonnull)image __attribute__((availability(swift, unavailable)));		
		[Static]
		[Export ("textureStyleWithImage:")]
		TextureStyle TextureStyleWithImage (UIImage image);

		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image __attribute__((objc_designated_initializer));
		[Export ("initWithImage:")]
		[DesignatedInitializer]
		NativeHandle Constructor (UIImage image);
	}

	#region Premium

	// @interface GMSMapID : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSMapID")]
	interface MapId : INSCopying {
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string identifier);

		// +(instancetype _Nonnull)mapIDWithIdentifier:(NSString * _Nonnull)identifier __attribute__((availability(swift, unavailable)));
		[Static]
		[Export ("mapIDWithIdentifier:")]
		MapId MapIdWithIdentifier (string identifier);
	}

	#endregion
}
