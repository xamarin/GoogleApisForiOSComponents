using System;

using UIKit;

namespace DynamicLinksSample
{
	public enum CompanyLogo
	{
		Xamarin,
		Firebase
	}


	public partial class ImageViewController : UIViewController
	{
		string filename;
		CompanyLogo companyLogo;
		public CompanyLogo CompanyLogo {
			get { return companyLogo; }
			set {
				companyLogo = value;
				filename = companyLogo == CompanyLogo.Xamarin ? "XamarinLogo.png" : "FirebaseLogo.png";
			}
		}

		public ImageViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			BackgroundImage.Image = UIImage.FromFile (filename);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

