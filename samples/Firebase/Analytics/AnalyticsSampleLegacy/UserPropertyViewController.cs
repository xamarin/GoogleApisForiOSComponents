using System;
using MonoTouch.Dialog;
using UIKit;
using Firebase.Analytics;

namespace AnalyticsSample
{
	public class UserPropertyViewController : DialogViewController
	{
		BindingContext context;
		UserPropertyContext userProperty;

		public UserPropertyViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			userProperty = new UserPropertyContext ();
			context = new BindingContext (this, userProperty, "User Properties");
			Root = context.Root;
		}

		public void PostUserProperty ()
		{
			context.Fetch ();

			if (string.IsNullOrWhiteSpace (userProperty.Name)) {
				AppDelegate.ShowMessage ("Empty Property Name", "Hey! We need a name to post!", this);
				return;
			}

			var value = string.IsNullOrWhiteSpace (userProperty.Value) ? userProperty.Value : null;
			Analytics.SetUserProperty (value, userProperty.Name);
			AppDelegate.ShowMessage ("User Property Posted!", string.Empty, this);
		}
	}
}
