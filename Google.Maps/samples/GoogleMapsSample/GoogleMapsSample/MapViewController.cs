using System;

#if __UNIFIED__
using UIKit;
using CoreLocation;
using CoreGraphics;

#else
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreLocation;

// Type Mappings Unified to monotouch.dll
using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;

using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

using Google.Maps;

namespace GoogleMapsSample
{
	public class MapViewController : UIViewController
	{
		MapView mapView;

		public override void LoadView ()
		{
			base.LoadView ();

			CameraPosition camera = CameraPosition.FromCamera (37.797865, -122.402526, 6);

			mapView = MapView.FromCamera (CGRect.Empty, camera);
			mapView.MyLocationEnabled = true;

			var xamMarker = new Marker () {
				Title = "Xamarin HQ",
				Snippet = "Where the magic happens.",
				Position = new CLLocationCoordinate2D (37.797865, -122.402526),
				Map = mapView
			};

			mapView.SelectedMarker = xamMarker;

			View = mapView;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{	
			base.ViewWillDisappear (animated);
		}
	}
}

