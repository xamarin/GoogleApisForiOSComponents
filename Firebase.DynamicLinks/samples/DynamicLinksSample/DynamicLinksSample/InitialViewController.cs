using System;

using UIKit;

namespace DynamicLinksSample
{
	public partial class InitialViewController : UIViewController
	{
		public InitialViewController () : base ("InitialViewController", null)
		{
		}

		public InitialViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			BtnLink1.TouchUpInside += Btn_TouchUpInside;
			BtnLink2.TouchUpInside += Btn_TouchUpInside;
			BtnLink3.TouchUpInside += Btn_TouchUpInside;
			LblCopied.Alpha = 0;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		void Btn_TouchUpInside (object sender, EventArgs e)
		{
			var button = sender as UIButton;
			UIPasteboard.General.String = button.TitleLabel.Text;
			LblCopied.Alpha = 1;
			UIView.Animate (0.5, 1.5, UIViewAnimationOptions.TransitionNone, () => LblCopied.Alpha = 0, null);
		}
	}
}


