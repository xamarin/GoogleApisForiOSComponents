using System;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreLocation;
using CoreGraphics;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;

using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

using Google.Maps;

namespace GoogleMapsAdvSample
{
	public class CameraViewController : UIViewController
	{
		MapView mapView;
		NSTimer timer;

		public CameraViewController () : base ()
		{
			Title = "Camera";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-37.809487, 144.965699, 20, 0, 0);
			mapView = MapView.FromCamera (CGRect.Empty, camera);
			mapView.Settings.ZoomGestures = false;
			mapView.Settings.ScrollGestures = false;
			mapView.Settings.RotateGestures = false;
			mapView.Settings.TiltGestures = false;

			View = mapView;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			#if __UNIFIED__
			timer = NSTimer.CreateScheduledTimer (1/30, this, new ObjCRuntime.Selector ("MoveCamera"), null, true);
			#else
			timer = NSTimer.CreateScheduledTimer (1/30, this, new MonoTouch.ObjCRuntime.Selector ("MoveCamera"), null, true);
			#endif
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
			timer.Invalidate ();
		}

		[Export ("MoveCamera")]
		void MoveCamera ()
		{
			var camera = mapView.Camera;
			var zoom = Math.Max (camera.Zoom - 0.1f, 17.5f);
			var newCamera = CameraPosition.FromCamera (camera.Target, zoom, camera.Bearing + 10, camera.ViewingAngle + 10);
			mapView.Animate (newCamera);
		}
	}
}

