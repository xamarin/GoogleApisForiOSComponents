using System;
using MonoTouch.Dialog;
using Foundation;
using UIKit;
using CoreGraphics;
using Google.Analytics;
using System.Threading.Tasks;

namespace CuteAnimalsiOS
{
	public class DVCCategory : DialogViewController
	{
		string category;
		uint numberOfPics;
		UIBarButtonItem btnRefresh;

		public DVCCategory (string category, uint numberOfPics) : base (null, true)
		{
			this.category = category;
			this.numberOfPics = numberOfPics;

			Root = new RootElement ("");

			// Refresh container
			btnRefresh = new UIBarButtonItem ("Refresh", UIBarButtonItemStyle.Plain, async (s, e) => {
				btnRefresh.Enabled = false;

				// Refresh the information within the Container
				AppDelegate.Container.Refresh ();

				// Give some time to Container to retrieve information
				await Task.Delay (200);

				// Refresh UI
				AddAnimals ();
				btnRefresh.Enabled = true;
			});
			NavigationItem.RightBarButtonItem = btnRefresh;
			AddAnimals ();
		}

		// Refresh UI
		void AddAnimals ()
		{
			// Get your Container User-Defined Variables defined on Tag Manager
			var adjective = AppDelegate.Container.StringForKey ("Adjective");

			// Create the new section with the new values retreived
			var section = new Section ($"{adjective} {category}");

			for (uint picNumber = 1; picNumber <= numberOfPics; picNumber++) {
				var picNo = picNumber;
				string picName = $"{adjective} {category} {picNumber}";
				section.Add (new StringElement (picName, () => {
					var animalView = new AnimalViewController (category, picNo);
					NavigationController.PushViewController (animalView, true);
				}));
			}

			Root.Clear ();
			Root.Add (section);
		}
	}
}

