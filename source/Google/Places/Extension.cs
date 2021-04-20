using System;
using System.Runtime.InteropServices;
using CoreLocation;
using Foundation;

namespace Google.Places {
	public partial class AutocompleteFilter {
		// extern id<GMSPlaceLocationBias,GMSPlaceLocationRestriction> _Nonnull GMSPlaceRectangularLocationOption (CLLocationCoordinate2D northEastBounds, CLLocationCoordinate2D southWestBounds);
		[DllImport ("__Internal", EntryPoint = "GMSPlaceRectangularLocationOption")]
		internal extern static NSObject _PlaceRectangularLocationOption (CLLocationCoordinate2D northEastBounds, CLLocationCoordinate2D southWestBounds);
		public static NSObject PlaceRectangularLocationOption (CLLocationCoordinate2D northEastBounds, CLLocationCoordinate2D southWestBounds)
			=> _PlaceRectangularLocationOption (northEastBounds, southWestBounds);
	}
}
