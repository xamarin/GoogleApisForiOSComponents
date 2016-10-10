using System;
using MonoTouch.Dialog;
using UIKit;
using Foundation;

namespace DynamicLinksSample
{
	public class MenuViewController : DialogViewController
	{
		public MenuViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			Root = new RootElement ("Menu") {
				new Section {
					new StringElement ("First View Controller", () => PushViewController (CompanyLogo.Xamarin)),
					new StringElement ("Second View Controller", () => PushViewController (CompanyLogo.Firebase))
				}
			};
		}

		void PushViewController (CompanyLogo companyLogo)
		{
			var imageViewController = UIStoryboard.FromName ("Main", NSBundle.MainBundle).InstantiateViewController ("ImageViewControllerId") as ImageViewController;
			imageViewController.CompanyLogo = companyLogo;
			NavigationController.PushViewController (imageViewController, true);
		}
	}
}
