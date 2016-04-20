using System;
using System.Runtime.InteropServices;

using CoreLocation;
using ObjCRuntime;

namespace Google.Maps
{
	public enum MapViewType
	{
		/** Basic maps.  The default. */
		Normal = 1,

		/** Satellite maps with no labels. */
		Satellite,

		/** Terrain maps. */
		Terrain,

		/** Satellite maps with a transparent label overview. */
		Hybrid,

		/** No maps, no labels.  Display of traffic data is not supported. */
		None
	}

	[Native]
	public enum PlacesAutocompleteTypeFilter : long
	{
		NoFilter,
		Geocode,
		Address,
		Establishment,
		Region,
		City
	}

	public enum MarkerAnimation
	{
		None = 0,
		Pop
	}

	[Native]
	public enum GeocoderErrorCode : long
	{
		InvalidCoordinate = 1,
		ErrorInternal
	}

	public enum LengthKind
	{
		Geodesic,
		Rhumb,
		Projected
	}

	[Native]
	public enum PlacesOpenNowStatus : long
	{
		Yes,
		No,
		Unknown
	}

	[Native]
	public enum PlacesPriceLevel : long
	{
		Unknown = -1,
		Free = 0,
		Cheap = 1,
		Medium = 2,
		High = 3,
		Expensive = 4
	}

	[Native]
	public enum PlacePickerErrorCode : long
	{
		UnknownError = -1,
		InternalError = -2,
		InvalidConfig = -3,
		OverlappingCalls = -4
	}

	[Native]
	public enum PlacesErrorCode : long
	{
		NetworkError = -1,
		ServerError = -2,
		InternalError = -3,
		KeyInvalid = -4,
		KeyExpired = -5,
		UsageLimitExceeded = -6,
		RateLimitExceeded = -7,
		DeviceRateLimitExceeded = -8,
		AccessNotConfigured = -9,
		IncorrectBundleIdentifier = -10,
		LocationError = -11
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct VisibleRegion
	{

		public CLLocationCoordinate2D NearLeft;
		public CLLocationCoordinate2D NearRight;
		public CLLocationCoordinate2D FarLeft;
		public CLLocationCoordinate2D FarRight;

		public VisibleRegion (double nearLeftLatitude, double nearLeftLongitude, 
		                      double nearRightLatitude, double nearRightLongitude, 
		                      double farLeftLatitude, double farLeftLongitude, 
		                      double farRightLatitude, double farRightLongitude)
		{
			NearLeft = new CLLocationCoordinate2D (nearLeftLatitude, nearLeftLongitude);
			NearRight = new CLLocationCoordinate2D (nearRightLatitude, nearRightLongitude);
			FarLeft = new CLLocationCoordinate2D (farLeftLatitude, farLeftLongitude);
			FarRight = new CLLocationCoordinate2D (farRightLatitude, farRightLongitude);
		}
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct Orientation
	{
		public double Heading;
		public double Pitch;

		public Orientation (double heading, double pitch)
		{
			Heading = heading;
			Pitch = pitch;
		}
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct MapPoint
	{
		public double X;
		public double Y;

		public MapPoint (float x, float y)
		{
			X = x;
			Y = y;
		}
	}
}
