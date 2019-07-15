using System;

using UIKit;

using Google.Maps;
using Google.Places;

namespace GooglePlacesSample
{
	public partial class GoogleOpenSourceViewController : UIViewController
	{
		#region Properties

		public GoogleOpenSourceLicense OpenSourceLicense { get; set; }

		#endregion

		#region Constructors

		public GoogleOpenSourceViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			if (OpenSourceLicense == GoogleOpenSourceLicense.Maps)
				TxtLicense.Text = MapServices.OpenSourceLicenseInfo;
			else
				TxtLicense.Text = PlacesClient.OpenSourceLicenseInfo;
		}

		#endregion
	}

	public enum GoogleOpenSourceLicense
	{
		Maps,
		Places
	}
}
