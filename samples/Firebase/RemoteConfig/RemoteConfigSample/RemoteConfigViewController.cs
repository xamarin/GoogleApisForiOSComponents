using System;

using MonoTouch.Dialog;
using UIKit;

using Firebase.RemoteConfig;

namespace RemoteConfigSample
{
	public class RemoteConfigViewController : DialogViewController
	{
		public RemoteConfigViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			Root = new RootElement ("Firebase Remote Config");
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var btnFetch = new UIBarButtonItem ("Fetch", UIBarButtonItemStyle.Plain, FetchFromServer);
			btnFetch.TintColor = UIColor.White;
			NavigationItem.RightBarButtonItem = btnFetch;

			GenerateTimesTable ();
		}

		void GenerateTimesTable ()
		{
			Root.Clear ();

			// Get values from defaults or from values fetched from server
			var timesTable = RemoteConfig.SharedInstance ["times_table"].NumberValue.Int16Value;
			var timesTableLength = RemoteConfig.SharedInstance ["from_zero_to"].NumberValue.Int16Value;

			if (timesTable < 0 || timesTableLength < 0) {
				AppDelegate.ShowMessage ("Negative numbers!", "Times table or the length of table is a negative number.", NavigationController, null);
				return;
			}

			var timesSection = new Section ($"{timesTable} times table");

			for (int i = 0; i <= timesTableLength; i++)
				timesSection.Add (new StringElement ($"{timesTable} x {i} = {timesTable * i}"));

			Root.Add (timesSection);
		}

		void FetchFromServer (object sender, EventArgs e)
		{
			// CacheExpirationSeconds is set to CacheExpiration here, indicating that any previously
			// fetched and cached config would be considered expired because it would have been fetched
			// more than CacheExpiration seconds ago. Thus the next fetch would go to the server unless
			// throttling is in progress. The default expiration duration is 43200 (12 hours).
			RemoteConfig.SharedInstance.Fetch (10, (status, error) => {
				switch (status) {
				case RemoteConfigFetchStatus.Success:
					AppDelegate.ShowMessage ("Config Fetched!", "The table will be updated", NavigationController, () => {
						RemoteConfig.SharedInstance.ActivateFetched ();

						// Now that the values have been updated, you can generate the times table again
						GenerateTimesTable ();
					});
					break;

				case RemoteConfigFetchStatus.Throttled:
				case RemoteConfigFetchStatus.NoFetchYet:
				case RemoteConfigFetchStatus.Failure:
					AppDelegate.ShowMessage ("Config not fetched...", error.LocalizedDescription, NavigationController, null);
					break;
				}
			});
		}
	}
}
