using System;

using UIKit;
using CoreGraphics;
using Foundation;
using CoreLocation;

using Google.Maps;

namespace GoogleMapsAdvSample
{
	public class GeocoderViewController : UIViewController
	{
		MapView mapView;
		Geocoder geocoder;

		public GeocoderViewController () : base ()
		{
			Title = "Geocoder";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-33.868, 151.2086, 12);
			mapView = MapView.FromCamera (CGRect.Empty, camera);
			geocoder = new Geocoder ();

			mapView.CoordinateLongPressed += (sender, e) => {
				// On a long press, reverse geocode this location.
				geocoder.ReverseGeocodeCord (e.Coordinate, (response, error) => {
					if (response != null && response.FirstResult != null) {
						var marker = new Marker () {
							Position = e.Coordinate,
							Title = response.FirstResult.AddressLine1,
							Snippet = response.FirstResult.AddressLine2,
							AppearAnimation = MarkerAnimation.Pop,
							Map = mapView
						};
					} else {
						Console.WriteLine (string.Format ("Could not reverse geocode point ({0},{1}): {2}", 
							e.Coordinate.Latitude, e.Coordinate.Longitude, error));
					}
				});
			};

			View = mapView;
		}
	}
}

