using System;

using UIKit;
using Google.Places.Picker;
using Foundation;
using Google.Places;

namespace GooglePlacesSample
{
	public partial class MyPlacePickerViewController : UIViewController, IPlacePickerViewControllerDelegate
	{
		#region Fields

		PlacePickerViewController placePickerViewController;

		#endregion

		#region Constructors

		public MyPlacePickerViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			var config = new PlacePickerConfig (null);
			placePickerViewController = new PlacePickerViewController (config) { Delegate = this };
		}

		#endregion

		#region User Interactions

		partial void BtnPopover_TouchUpInside (UIButton sender)
		{
			placePickerViewController.ModalPresentationStyle = UIModalPresentationStyle.Popover;
			PresentViewController (placePickerViewController, true, null);

			var presentationController = placePickerViewController.PopoverPresentationController;
			presentationController.SourceView = sender;
			presentationController.SourceRect = sender.Bounds;
		}

		partial void BtnNavigation_TouchUpInside (UIButton sender) => NavigationController.PushViewController (placePickerViewController, true);

		partial void BtnModel_TouchUpInside (UIButton sender)
		{
			placePickerViewController.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
			PresentViewController (placePickerViewController, true, null);
		}

		#endregion

		#region PlacePickerViewController Delegate

		public void DidPickPlace (PlacePickerViewController viewController, Place place)
		{
			if (viewController.NavigationController == NavigationController)
				NavigationController.PopViewController (true);
			else
				DismissViewController (true, null);
		}

		[Export ("placePickerDidCancel:")]
		void DidCancel (PlacePickerViewController viewController)
		{
			DismissViewController (true, null);
		}

		#endregion
	}
}

