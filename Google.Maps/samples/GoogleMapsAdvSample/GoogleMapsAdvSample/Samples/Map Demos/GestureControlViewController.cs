using System;

#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
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
	public class GestureControlViewController : UIViewController
	{
		MapView mapView;
		UISwitch zoomSwitch;

		public GestureControlViewController () : base ()
		{
			Title = "Gesture Control";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-25.5605, 133.605097, 3);
			mapView = MapView.FromCamera (CGRect.Empty, camera);
			mapView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

			View = new UIView (CGRect.Empty);
			View.AddSubview (mapView);

			var holder = new UIView (new CGRect (0, 0, 0, 59)) {
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleBottomMargin,
				BackgroundColor = UIColor.FromRGBA (1.0f, 1.0f, 1.0f, 0.8f)
			};

			View.AddSubview (holder);

			// Zoom Label
			var label = new UILabel (new CGRect (16, 16, 200, 29)) {
				Text = "Zooming?",
				Font = UIFont.SystemFontOfSize (18.0f),
				TextAlignment = UITextAlignment.Left,
				BackgroundColor = UIColor.Clear
			};
			label.Layer.ShadowColor = UIColor.White.CGColor;
			label.Layer.ShadowOffset = new CGSize (0.0f, 1.0f);
			label.Layer.ShadowOpacity = 1.0f;
			label.Layer.ShadowRadius = 0.0f;
			holder.AddSubview (label);

			// Control zooming.
			zoomSwitch = new UISwitch (new CGRect (-90, 16, 0, 0)) {
				AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin
			};
			zoomSwitch.ValueChanged += (sender, e) => mapView.Settings.ZoomGestures = zoomSwitch.On;
			zoomSwitch.On = true;
			holder.AddSubview (zoomSwitch);
		}
	}
}

