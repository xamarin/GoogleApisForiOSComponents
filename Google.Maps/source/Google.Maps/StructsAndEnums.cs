using System;
using System.Runtime.InteropServices;

using CoreLocation;
using ObjCRuntime;

namespace Google.Maps
{
	[Native]
	public enum MapViewType : ulong
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
	public enum FrameRate : ulong
	{
		PowerSave,
		Conservative,
		Maximum,
	}

	[Native]
	public enum MapViewPaddingAdjustmentBehavior : ulong
	{
		Always,
		Automatic,
		Never
	}

	[Native]
	public enum MarkerAnimation : ulong
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

	[Native]
	public enum LengthKind : ulong
	{
		Geodesic,
		Rhumb,
		Projected
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
