using System;
using System.Linq;
using MonoTouch.Dialog;
using UIKit;

namespace AnalyticsSample
{
	public class MainViewController : DialogViewController
	{
		public MainViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			Root = new RootElement ("Firebase Analytics") {
				new Section {
					new StringElement ("Log events", () => {
						NavigationController.PushViewController (new LogEventViewController (), true);
					}),
					new StringElement ("Set User Properties", () => {
						NavigationController.PushViewController (new UserPropertyViewController (), true);
					})
				}
			};
		}
	}
}
