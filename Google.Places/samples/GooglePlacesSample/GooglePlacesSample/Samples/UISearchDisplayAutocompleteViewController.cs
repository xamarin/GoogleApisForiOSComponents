using System;

using UIKit;

namespace GooglePlacesSample
{
	public partial class UISearchDisplayAutocompleteViewController : UIViewController
	{
		#region Constructors

		public UISearchDisplayAutocompleteViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			UISearchController t = new UISearchController ();

		}

		#endregion

	}
}

