using System;

#if __UNIFIED__
using UIKit;
using CoreGraphics;
#else
using MonoTouch.UIKit;
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
	public class BasicMapViewController : UIViewController
	{
		public BasicMapViewController () : base ()
		{
			Title = "Basic Map";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-33.868, 151.2086, 6);
			View = MapView.FromCamera (CGRect.Empty, camera);
		}
	}
}

