using System;

using UIKit;
using Foundation;
using System.Linq;

namespace MLKitVisionSample {
	public partial class SettingsViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate {
		#region Class Variables

		readonly VisionType [] types;
		readonly TextRecognitionScript [] scripts;

		NSUserDefaults standardUserDefaults;

		VisionType selectedType;
		TextRecognitionScript selectedScript;

		#endregion

		#region Constructors

		public SettingsViewController (IntPtr handle) : base (handle)
		{
			types = Enum.GetValues (typeof (VisionType)).Cast<VisionType> ().ToArray ();
			scripts = Enum.GetValues (typeof (TextRecognitionScript)).Cast<TextRecognitionScript> ().ToArray ();
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			standardUserDefaults = NSUserDefaults.StandardUserDefaults;

			selectedType = (VisionType) (int) standardUserDefaults.IntForKey (nameof (VisionType));
			selectedScript = (TextRecognitionScript) (int) standardUserDefaults.IntForKey (nameof (TextRecognitionScript));

			SettingsTable.ReloadSections (NSIndexSet.FromNSRange (new NSRange (0, 2)), UITableViewRowAnimation.Automatic);
		}

		#endregion

		#region User Interactions

		partial void BtnSave_Clicked (NSObject sender)
		{
			NSUserDefaults.StandardUserDefaults.SetInt ((int) selectedType, nameof (VisionType));
			NSUserDefaults.StandardUserDefaults.SetInt ((int) selectedScript, nameof (TextRecognitionScript));

			PerformSegue (Constants.PrepareForUnwind, sender);
		}

		#endregion

		#region UITableView Data Source

		[Export ("numberOfSectionsInTableView:")]
		public nint NumberOfSections (UITableView tableView) => 2;

		public nint RowsInSection (UITableView tableView, nint section)
		{
			return (int) section switch {
				0 => types.Length,
				1 => scripts.Length,
				_ => 0
			};
		}

		[Export ("tableView:titleForHeaderInSection:")]
		public string TitleForHeader (UITableView tableView, nint section)
		{
			return (int) section switch {
				0 => nameof (VisionType).GetTitle (),
				1 => nameof (TextRecognitionScript).GetTitle (),
				_ => string.Empty
			};
		}

		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (Constants.CellKey);

			if (indexPath.Section == 0) {
				cell.TextLabel.Text = types [indexPath.Row].ToString ().GetTitle ();
				cell.Accessory = (int) selectedType == indexPath.Row ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
			} else if (indexPath.Section == 1) {
				cell.TextLabel.Text = scripts [indexPath.Row].ToString ().GetTitle ();
				cell.Accessory = (int) selectedScript == indexPath.Row ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
			} else {
				cell.TextLabel.Text = string.Empty;
				cell.Accessory = UITableViewCellAccessory.None;
			}

			return cell;
		}

		#endregion

		#region UITableView Delegate

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var visibleCells = tableView.VisibleCells
				.Where (i => tableView.IndexPathForCell (i).Section == indexPath.Section)
				.ToList ();

			foreach (var visibleCell in visibleCells)
				visibleCell.Accessory = UITableViewCellAccessory.None;

			tableView.CellAt (indexPath).Accessory = UITableViewCellAccessory.Checkmark;

			if (indexPath.Section == 0) {
				selectedType = types [indexPath.Row];
			} else if (indexPath.Section == 1) {
				selectedScript = scripts [indexPath.Row];
			}
		}

		#endregion
	}
}

