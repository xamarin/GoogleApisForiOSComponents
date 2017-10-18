using System;

using UIKit;

namespace GooglePlacesSample
{
	public partial class PlacePickerViewController : UIViewController
	{
		public PlacePickerViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void BtnPopover_TouchUpInside (UIButton sender)
		{
			throw new NotImplementedException ();
		}

		partial void BtnNavigation_TouchUpInside (UIButton sender)
		{
			throw new NotImplementedException ();
		}

		partial void BtnModel_TouchUpInside (UIButton sender)
		{
			throw new NotImplementedException ();
		}
	}
}

