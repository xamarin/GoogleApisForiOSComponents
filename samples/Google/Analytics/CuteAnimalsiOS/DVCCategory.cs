using System;
using MonoTouch.Dialog;
using Foundation;
using UIKit;
using CoreGraphics;
using Google.Analytics;

namespace CuteAnimalsiOS
{
	public class DVCCategory : DialogViewController
	{
		public string Category;

		public DVCCategory (string category, int numberOfPics) : base (null, true)
		{
			Category = category;
			var section = new Section ();

			for (int picNumber = 1; picNumber <= numberOfPics; picNumber++) {
				var picNo = picNumber;
				var picName = string.Format ("{0} {1}", category, picNumber);
				section.Add (new StringElement (picName, () => {
					var animalView = new AnimalViewController (Category, picNo);
					NavigationController.PushViewController (animalView, true);
				}));
			}

			Root = new RootElement (Category) {
				section
			};
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			// This screen name value will remain set on the tracker and sent with
			// hits until it is set to a new value or to null.
			Gai.SharedInstance.DefaultTracker.Set (GaiConstants.ScreenName, Category + " Category View");

			Gai.SharedInstance.DefaultTracker.Send (DictionaryBuilder.CreateScreenView ().Build ());
		}
	}
}

