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
	public enum PanoramaSource : ulong {
		Default = 0,
		Outside
	}

	[Native]
	public enum LengthKind : ulong
	{
		Geodesic,
		Rhumb,
		Projected
	}

	[Native]
	public enum CollisionBehavior : long {
		Required,
		RequiredAndHidesOptional,
		OptionalAndHidesLowerPriority
	}
}
