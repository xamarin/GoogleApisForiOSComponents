using System;

using UIKit;
using CoreGraphics;

using Google.Maps;

namespace GoogleMapsAdvSample
{
	public class TrafficMapViewController : UIViewController
	{
		public TrafficMapViewController () : base ()
		{
			Title = "Traffic Map";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-33.868, 151.2086, 12);
			var mapView = MapView.FromCamera (CGRect.Empty, camera);
			mapView.TrafficEnabled = true;
			View = mapView;
		}

	}
}

