using System;

using UIKit;
using Foundation;

namespace MLKitVisionSample {
	public partial class SettingsViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate {
		#region Class Variables

		NSUserDefaults standardUserDefaults;
		nint selectedModelIndex;
		ApiResource selectedApiResource;

		#endregion

		#region Constructors

		public SettingsViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			standardUserDefaults = NSUserDefaults.StandardUserDefaults;

			selectedApiResource = (ApiResource)(int)standardUserDefaults.IntForKey (Constants.SelectedApiResource);
			selectedModelIndex = standardUserDefaults.IntForKey (Constants.SelectedModel);

			SgmApi.SelectedSegment = (int)selectedApiResource;
			SgmApi.ValueChanged += SgmApi_ValueChanged;
		}

		#endregion

		#region User Interactions

		void SgmApi_ValueChanged (object sender, EventArgs e)
		{
			selectedApiResource = (ApiResource)(int)SgmApi.SelectedSegment;
			selectedModelIndex = 0;
			AvailableModelsTable.ReloadSections (NSIndexSet.FromIndex (0), UITableViewRowAnimation.Automatic);
		}

		partial void BtnSave_Clicked (NSObject sender)
		{
			NSUserDefaults.StandardUserDefaults.SetInt ((int)selectedApiResource, Constants.SelectedApiResource);
			NSUserDefaults.StandardUserDefaults.SetInt (selectedModelIndex, Constants.SelectedModel);

			PerformSegue (Constants.PrepareForUnwind, sender);
		}

		#endregion

		#region UITableView Data Source

		[Export ("numberOfSectionsInTableView:")]
		public nint NumberOfSections (UITableView tableView) => 1;

		public nint RowsInSection (UITableView tableView, nint section)
		{
			return selectedApiResource == ApiResource.OnDevice ? AvailableModels.OnDevice.Length : AvailableModels.OnCloud.Length;
		}

		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var availableFeatures = selectedApiResource == ApiResource.OnDevice ? AvailableModels.OnDevice : AvailableModels.OnCloud;

			var cell = tableView.DequeueReusableCell (Constants.CellKey);
			cell.TextLabel.Text = availableFeatures [indexPath.Row].ToString ();
			cell.Accessory = selectedModelIndex == indexPath.Row ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;

			return cell;
		}

		#endregion

		#region UITableView Delegate

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var visibleCells = tableView.VisibleCells;

			foreach (var visibleCell in visibleCells)
				visibleCell.Accessory = UITableViewCellAccessory.None;

			tableView.CellAt (indexPath).Accessory = UITableViewCellAccessory.Checkmark;
			selectedModelIndex = indexPath.Row;
		}

		#endregion
	}
}

