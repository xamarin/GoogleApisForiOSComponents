using System;

using Foundation;
using UIKit;

namespace GooglePlacesSample
{
	public partial class MenuTableViewController : UITableViewController
	{
		#region Fields

		string [] titles;
		SampleInformation [] [] samples;

		#endregion

		#region Constructors

		public MenuTableViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			titles = new [] { "Autocomplete", "Programmatic APIs", "Google Licenses" };
			samples = SamplesGenerator.CreateSamples ();
		}

		#endregion

		#region UITableViewController Data Source

		public override nint NumberOfSections (UITableView tableView) => samples.Length;

		public override nint RowsInSection (UITableView tableView, nint section) => samples [section].Length;

		public override string TitleForHeader (UITableView tableView, nint section) => titles [section];

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var sampleInformation = samples [indexPath.Section] [indexPath.Row];

			var cell = tableView.DequeueReusableCell ("MenuTableViewCell", indexPath);
			cell.TextLabel.Text = sampleInformation.Title;
			return cell;
		}

		#endregion

		#region UITableViewController Delegate

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var sampleInformation = samples [indexPath.Section] [indexPath.Row];

			var viewController = Storyboard.InstantiateViewController (sampleInformation.StoryboardId);
			viewController.Title = sampleInformation.Title;

			switch (indexPath.Section) {
			case 0 when (viewController is AutocompleteBaseViewController autocompleteViewController):
				autocompleteViewController.ColorTheme = sampleInformation.ColorTheme;
				autocompleteViewController.PushAutocomplete = sampleInformation.PushAutocomplete;
				break;
			case 1:
				break;
			case 2:
				var licenseViewController = viewController as GoogleOpenSourceViewController;
				licenseViewController.OpenSourceLicense = (GoogleOpenSourceLicense)indexPath.Row;
				break;
			default:
				break;
			}

			ShowDetailViewController (new UINavigationController (viewController), this);
		}

		#endregion
	}
}
