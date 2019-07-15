using System;
using System.Runtime.InteropServices;

using Foundation;
using CoreGraphics;
using ObjCRuntime;
using UIKit;
using CoreLocation;
using static ObjCRuntime.Runtime;

namespace Google.Maps
{
	[Preserve (AllMembers = true)]
	public partial class Constants
	{
		public static double EarthRadius { get { return 6371009.0; } }

		static CGPoint? groundOverlayDefaultAnchor;

		public static CGPoint GroundOverlayDefaultAnchor {
			get {
				if (groundOverlayDefaultAnchor == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSGroundOverlayDefaultAnchor");
					groundOverlayDefaultAnchor = (CGPoint)Marshal.PtrToStructure (ptr, typeof (CGPoint));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return groundOverlayDefaultAnchor.Value;
			}
		}

		static CGPoint? markerDefaultGroundAnchor;

		public static CGPoint MarkerDefaultGroundAnchor {
			get {
				if (markerDefaultGroundAnchor == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSMarkerDefaultGroundAnchor");
					markerDefaultGroundAnchor = (CGPoint)Marshal.PtrToStructure (ptr, typeof (CGPoint));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return markerDefaultGroundAnchor.Value;
			}
		}

		static CGPoint? markerDefaultInfoWindowAnchor;

		public static CGPoint MarkerDefaultInfoWindowAnchor {
			get {
				if (markerDefaultInfoWindowAnchor == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSMarkerDefaultInfoWindowAnchor");
					markerDefaultInfoWindowAnchor = (CGPoint)Marshal.PtrToStructure (ptr, typeof (CGPoint));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return markerDefaultInfoWindowAnchor.Value;
			}
		}

		static UIImage tileLayerNoTile;

		public static UIImage TileLayerNoTile {
			get {
				if (tileLayerNoTile == null)
					tileLayerNoTile = GetNSObject<UIImage> (_TileLayerNoTile);

				return tileLayerNoTile;
			}
		}
	}

	public partial class GeometryUtils
	{
		// FOUNDATION_EXPORT GMSMapPoint GMSProject(CLLocationCoordinate2D coordinate);
		[DllImport ("__Internal", EntryPoint = "GMSProject")]
		extern internal static MapPoint _Project (CLLocationCoordinate2D coordinate);
		public static MapPoint Project (CLLocationCoordinate2D coordinate) => _Project (coordinate);

		// FOUNDATION_EXPORT CLLocationCoordinate2D GMSUnproject(GMSMapPoint point);
		[DllImport ("__Internal", EntryPoint = "GMSUnproject")]
		extern internal static CLLocationCoordinate2D _Unproject (MapPoint point);
		public static CLLocationCoordinate2D Unproject (MapPoint point) => _Unproject (point);

		// FOUNDATION_EXPORT GMSMapPoint GMSMapPointInterpolate(GMSMapPoint a, GMSMapPoint b, double t);
		[DllImport ("__Internal", EntryPoint = "GMSMapPointInterpolate")]
		extern internal static CLLocationCoordinate2D _MapPointInterpolate (MapPoint a, MapPoint b, double t);
		public static CLLocationCoordinate2D MapPointInterpolate (MapPoint a, MapPoint b, double t) => _MapPointInterpolate (a, b, t);

		// FOUNDATION_EXPORT double GMSMapPointDistance(GMSMapPoint a, GMSMapPoint b);
		[DllImport ("__Internal", EntryPoint = "GMSMapPointDistance")]
		extern internal static double _MapPointDistance (MapPoint a, MapPoint b);
		public static double MapPointDistance (MapPoint a, MapPoint b) => _MapPointDistance (a, b);

		// FOUNDATION_EXPORT BOOL GMSGeometryContainsLocation(CLLocationCoordinate2D point, GMSPath *path, BOOL geodesic);
		[DllImport ("__Internal", EntryPoint = "GMSGeometryContainsLocation")]
		extern internal static bool _ContainsLocation (CLLocationCoordinate2D point, IntPtr path, bool geodesic);
		public static bool ContainsLocation (CLLocationCoordinate2D point, Path path, bool geodesic) => _ContainsLocation (point, path.Handle, geodesic);

		// FOUNDATION_EXPORT BOOL GMSGeometryIsLocationOnPathTolerance(CLLocationCoordinate2D point, GMSPath *path, BOOL geodesic, CLLocationDistance tolerance);
		[DllImport ("__Internal", EntryPoint = "GMSGeometryIsLocationOnPathTolerance")]
		extern internal static bool _IsLocationOnPath (CLLocationCoordinate2D point, IntPtr path, bool geodesic, double tolerance);
		public static bool IsLocationOnPath (CLLocationCoordinate2D point, Path path, bool geodesic, double tolerance) => _IsLocationOnPath (point, path.Handle, geodesic, tolerance);

		// FOUNDATION_EXPORT BOOL GMSGeometryIsLocationOnPath(CLLocationCoordinate2D point, GMSPath *path, BOOL geodesic);
		[DllImport ("__Internal", EntryPoint = "GMSGeometryIsLocationOnPath")]
		extern internal static bool _IsLocationOnPath (CLLocationCoordinate2D point, IntPtr path, bool geodesic);
		public static bool IsLocationOnPath (CLLocationCoordinate2D point, Path path, bool geodesic) => _IsLocationOnPath (point, path.Handle, geodesic);

		// FOUNDATION_EXPORT CLLocationDistance GMSGeometryDistance(CLLocationCoordinate2D from, CLLocationCoordinate2D to);
		[DllImport ("__Internal", EntryPoint = "GMSGeometryDistance")]
		extern internal static double _Distance (CLLocationCoordinate2D fromCoord, CLLocationCoordinate2D toCoord);
		public static double Distance (CLLocationCoordinate2D fromCoord, CLLocationCoordinate2D toCoord) => _Distance (fromCoord, toCoord);

		// FOUNDATION_EXPORT CLLocationDistance GMSGeometryLength(GMSPath *path);
		[DllImport ("__Internal", EntryPoint = "GMSGeometryLength")]
		extern internal static double _Length (IntPtr path);
		public static double Length (Path path) => _Length (path.Handle);

		// FOUNDATION_EXPORT double GMSGeometryArea(GMSPath *path);
		[DllImport ("__Internal", EntryPoint = "GMSGeometryArea")]
		extern internal static double _Area (IntPtr path);
		public static double Area (Path path) => _Area (path.Handle);

		// FOUNDATION_EXPORT double GMSGeometrySignedArea(GMSPath *path);
		[DllImport ("__Internal", EntryPoint = "GMSGeometrySignedArea")]
		extern internal static double _SignedArea (IntPtr path);
		public static double SignedArea (Path path) => _SignedArea (path.Handle);

		// FOUNDATION_EXPORT CLLocationDirection GMSGeometryHeading(CLLocationCoordinate2D from, CLLocationCoordinate2D to);
		[DllImport ("__Internal", EntryPoint = "GMSGeometryHeading")]
		extern internal static double _Heading (CLLocationCoordinate2D fromCoord, CLLocationCoordinate2D toCoord);
		public static double Heading (CLLocationCoordinate2D fromCoord, CLLocationCoordinate2D toCoord) => _Heading (fromCoord, toCoord);

		// FOUNDATION_EXPORT CLLocationCoordinate2D GMSGeometryOffset(CLLocationCoordinate2D from, CLLocationDistance distance, CLLocationDirection heading);
		[DllImport ("__Internal", EntryPoint = "GMSGeometryOffset")]
		extern internal static CLLocationCoordinate2D _Offset (CLLocationCoordinate2D fromCoord, double distance, double heading);
		public static CLLocationCoordinate2D Offset (CLLocationCoordinate2D fromCoord, double distance, double heading) => _Offset (fromCoord, distance, heading);

		// FOUNDATION_EXPORT CLLocationCoordinate2D GMSGeometryInterpolate(CLLocationCoordinate2D from, CLLocationCoordinate2D to, double fraction);
		[DllImport ("__Internal", EntryPoint = "GMSGeometryInterpolate")]
		extern internal static CLLocationCoordinate2D _Interpolate (CLLocationCoordinate2D fromCoord, CLLocationCoordinate2D toCoord, double fraction);
		public static CLLocationCoordinate2D Interpolate (CLLocationCoordinate2D fromCoord, CLLocationCoordinate2D toCoord, double fraction) => _Interpolate (fromCoord, toCoord, fraction);

		// FOUNDATION_EXPORT GMS_NSArrayOf(GMSStyleSpan *) *GMSStyleSpans(GMSPath *path, GMS_NSArrayOf(GMSStrokeStyle *) *styles, GMS_NSArrayOf(NSNumber *) *lengths, GMSLengthKind lengthKind);
		[DllImport ("__Internal", EntryPoint = "GMSStyleSpans")]
		extern internal static IntPtr _StyleSpans (IntPtr path, IntPtr styles, IntPtr lengths, LengthKind lengthKind);

		public static StyleSpan [] StyleSpans (Path path, StrokeStyle [] styles, NSNumber [] lengths, LengthKind lengthKind)
		{
			var stylesArray = NSArray.FromNSObjects (styles);
			var lengthsArray = NSArray.FromNSObjects (lengths);
			var result = _StyleSpans (path.Handle, stylesArray.Handle, lengthsArray.Handle, lengthKind);
			var nsObjects = NSArray.ArrayFromHandle<NSObject> (result);
			var resultArray = new StyleSpan [nsObjects.Length];

			for (int i = 0; i < nsObjects.Length; i++)
				resultArray [i] = (StyleSpan)nsObjects [i];

			return resultArray;
		}

		// FOUNDATION_EXPORT GMS_NSArrayOf(GMSStyleSpan *) *GMSStyleSpansOffset(GMSPath *path, GMS_NSArrayOf(GMSStrokeStyle *) *styles, GMS_NSArrayOf(NSNumber *) *lengths, GMSLengthKind lengthKind, double lengthOffset);
		[DllImport ("__Internal", EntryPoint = "GMSStyleSpansOffset")]
		extern internal static IntPtr _StyleSpans (IntPtr path, IntPtr styles, IntPtr lengths, LengthKind lengthKind, double lengthOffset);

		public static StyleSpan [] StyleSpans (Path path, StrokeStyle [] styles, NSNumber [] lengths, LengthKind lengthKind, double lengthOffset)
		{
			var stylesArray = NSArray.FromNSObjects (styles);
			var lengthsArray = NSArray.FromNSObjects (lengths);
			var result = _StyleSpans (path.Handle, stylesArray.Handle, lengthsArray.Handle, lengthKind, lengthOffset);
			var nsObjects = NSArray.ArrayFromHandle<NSObject> (result);
			var resultArray = new StyleSpan [nsObjects.Length];

			for (int i = 0; i < nsObjects.Length; i++)
				resultArray [i] = (StyleSpan)nsObjects [i];

			return resultArray;
		}
	}
}

