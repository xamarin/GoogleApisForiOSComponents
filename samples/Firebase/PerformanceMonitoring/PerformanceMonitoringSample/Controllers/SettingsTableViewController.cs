using System;

using UIKit;
using Foundation;
using Firebase.RemoteConfig;

namespace PerformanceMonitoringSample
{
	public partial class SettingsTableViewController : UITableViewController
	{
		#region Fields

		string footer;
		RemoteConfig remoteConfig;

		#endregion

		#region Constructors

		public SettingsTableViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			remoteConfig = RemoteConfig.SharedInstance;
			footer = "Go to https://console.firebase.google.com/ in Remote Config section and change these settings.\n\n" +
				"Tap Fetch and the new settings will be downloaded.\n\n" +
				"This settings will be applied after you restart your app.\n\n" +
				"Go to https://components.xamarin.com/gettingstarted/firebaseiosperformancemonitoring to learn more.";
		}

		#endregion

		#region User Interaction

		partial void BtnCancel_Tapped (UIBarButtonItem sender)
		{
			DismissViewController (true, null);
		}

		partial void BtnFetch_Tapped (UIBarButtonItem sender)
		{
			UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
			remoteConfig.Fetch (30, HandleRemoteConfigFetchCompletionHandler);
		}

		#endregion

		#region TableView Data Source

		public override nint NumberOfSections (UITableView tableView) => 1;
		public override nint RowsInSection (UITableView tableView, nint section) => 2;
		public override string TitleForHeader (UITableView tableView, nint section) => "Firebase Performance Monitoring";
		public override string TitleForFooter (UITableView tableView, nint section) => footer;

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (SettingTableViewCell.Key, indexPath) as SettingTableViewCell;
			cell.SettingTitle = indexPath.Row == 0 ? "Instrumentation" : "Data Collection";
			cell.SettingEnabled = indexPath.Row == 0 ? remoteConfig ["perf_enable_auto"].BoolValue : remoteConfig ["perf_enable_manual"].BoolValue;

			return cell;
		}

		#endregion

		#region Internal Functionality

		void HandleRemoteConfigFetchCompletionHandler (RemoteConfigFetchStatus status, NSError error)
		{
			switch (status) {
			case RemoteConfigFetchStatus.Success:
				AppDelegate.ShowMessage ("Config Fetched!", "Settings will be updated", NavigationController, OkAction);
				break;

			case RemoteConfigFetchStatus.Throttled:
			case RemoteConfigFetchStatus.NoFetchYet:
			case RemoteConfigFetchStatus.Failure:
				AppDelegate.ShowMessage ("Config not fetched...", error.LocalizedDescription, NavigationController, null);
				break;
			}

			UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;

			void OkAction ()
			{
				remoteConfig.ActivateFetched ();

				var indexPaths = TableView.IndexPathsForVisibleRows;
				foreach (var indexPath in indexPaths) {
					var cell = TableView.CellAt (indexPath) as SettingTableViewCell;
					var enabled = indexPath.Row == 0 ? remoteConfig ["perf_enable_auto"].BoolValue : remoteConfig ["perf_enable_manual"].BoolValue;
					cell.SetEnabled (enabled, true);
				}
			}
		}

		#endregion
	}
}

