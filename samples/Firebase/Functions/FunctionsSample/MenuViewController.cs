using System;
using MonoTouch.Dialog;
using UIKit;
using Foundation;
using ObjCRuntime;

namespace FunctionsSample
{
	public class MenuViewController : DialogViewController
	{
		public MenuViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			Root = new RootElement ("Firebase Functions Sample") {
				new Section ("Select your function") {
					new StringElement ("Password Authentication", () => OpenViewController (new UserViewController ())) {
						Alignment = UITextAlignment.Center
					}
				}
			};
		}

		void OpenViewController (UIViewController viewController)
		{
			NavigationController.PushViewController (viewController, true);
		}
	}
}
