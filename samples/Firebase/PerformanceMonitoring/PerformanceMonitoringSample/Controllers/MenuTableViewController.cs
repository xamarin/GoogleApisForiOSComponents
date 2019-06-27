using System;

using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceMonitoringSample
{
	public partial class MenuTableViewController : UITableViewController
	{
		#region Fields

		Dictionary<string, string> imagesInfo;
		string [] imagesKeys;

		#endregion

		#region Constructors

		protected MenuTableViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			Title = "Firebase Performance Monitoring Sample";

			imagesInfo = new Dictionary<string, string> {
				{ "The Forest", "https://static.pexels.com/photos/609769/pexels-photo-609769.jpeg" },
				{ "Starry Night", "https://static.pexels.com/photos/32237/pexels-photo.jpg" },
				{ "Autumn", "https://static.pexels.com/photos/33109/fall-autumn-red-season.jpg" },
				{ "The Lake", "https://static.pexels.com/photos/454880/pexels-photo-454880.jpeg" },
				{ "Orange", "https://static.pexels.com/photos/68899/pexels-photo-68899.jpeg" },
				{ "Peppers", "https://static.pexels.com/photos/372882/pexels-photo-372882.jpeg" },
				{ "Husky", "https://static.pexels.com/photos/245037/pexels-photo-245037.jpeg" },
				{ "Full Moon", "https://static.pexels.com/photos/158056/water-mountain-moon-river-158056.jpeg" },
				{ "The Castle", "https://static.pexels.com/photos/40735/neuschwanstein-castle-germany-disney-40735.jpeg" },
				{ "Hot-air Balloon", "https://static.pexels.com/photos/210012/pexels-photo-210012.jpeg" }
			};
			imagesKeys = imagesInfo.Keys.ToArray ();
		}

		#endregion

		#region UITableView Data Source

		public override nint NumberOfSections (UITableView tableView) => 1;
		public override nint RowsInSection (UITableView tableView, nint section) => imagesInfo.Count;
		public override string TitleForHeader (UITableView tableView, nint section) => "Images to download";

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("TitleTableViewCell", indexPath);
			cell.TextLabel.Text = imagesKeys [indexPath.Row];
			return cell;
		}

		#endregion

		#region Navigation

		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			if (segue.Identifier == nameof (ImageViewController)) {
				var imageViewController = segue.DestinationViewController as ImageViewController;
				var selectedIndexPath = TableView.IndexPathForSelectedRow;
				var imageKey = imagesKeys [selectedIndexPath.Row];

				imageViewController.Title = imageKey;
				imageViewController.ImageUrl = imagesInfo [imageKey];
			}

			base.PrepareForSegue (segue, sender);
		}

		#endregion
	}
}
