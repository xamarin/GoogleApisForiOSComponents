using System;
using System.Runtime.InteropServices;

using CoreLocation;
using ObjCRuntime;

namespace Google.Maps
{
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
