using System;
using System.Drawing;
using MonoTouch.Dialog;
using Foundation;
using UIKit;
using Google.Analytics;
using System.Threading.Tasks;

namespace CuteAnimalsiOS
{
	public class AnimalViewController : UIViewController
	{
		string animal;
		uint selectedIndex;
		UIImageView imageView;
		UIBarButtonItem btnRefresh;

		public AnimalViewController (string animal, uint selectedIndex)
		{
			this.animal = animal;
			this.selectedIndex = selectedIndex;
			var adjective = AppDelegate.Container.StringForKey ("Adjective");
			Title = $"{adjective} {animal} {selectedIndex} View";

			btnRefresh = new UIBarButtonItem ("Refresh", UIBarButtonItemStyle.Plain, async (s, e) => {
				btnRefresh.Enabled = false;

				// Refresh the information within the Container
				AppDelegate.Container.Refresh ();

				// Give some time to Container to retrieve information
				await Task.Delay (200);

				var adj = AppDelegate.Container.StringForKey ("Adjective");
				Title = $"{adj} {this.animal} {this.selectedIndex} View";
				btnRefresh.Enabled = true;
			});
			NavigationItem.RightBarButtonItem = btnRefresh;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;
			imageView = new UIImageView (View.Bounds) {
				ContentMode = UIViewContentMode.ScaleAspectFit,
				Image = UIImage.FromBundle ($"{animal}-{selectedIndex}.jpg")
			};

			View.AddSubview (imageView);
		}
	}
}