using System;

using UIKit;
using Google.Places;
using Foundation;

namespace GooglePlacesSample
{
	public partial class AutocompleteBaseViewController : UIViewController, IAutocompleteViewControllerDelegate
	{
		#region Properties

		public ColorTheme ColorTheme { get; set; }
		public bool PushAutocomplete { get; set; }

		#endregion

		#region Constructors

		protected AutocompleteBaseViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			if (ColorTheme == ColorTheme.Default)
				SgmColors.Hidden = true;
		}

		#endregion

		#region User Interactions

		partial void SgmColors_ValueChanged (UISegmentedControl sender) => ColorTheme = (ColorTheme)(int)sender.SelectedSegment;

		partial void BtnShow_TouchUpInside (UIButton sender)
		{
			if (ColorTheme == ColorTheme.Default) {
				var autocompleteViewController = new AutocompleteViewController { Delegate = this };

				if (PushAutocomplete)
					NavigationController.PushViewController (autocompleteViewController, true);
				else
					PresentViewController (autocompleteViewController, true, null);
			} else {
				var autocompleteViewController = new StyledAutocompleteViewController { Delegate = this };
				ApplyCustomTheme (autocompleteViewController);
				PresentViewController (autocompleteViewController, true, null);
			}
		}

		#endregion

		#region AutocompleteViewController Delegate

		public void DidAutocomplete (AutocompleteViewController viewController, Place place)
		{
			if (PushAutocomplete)
				NavigationController.PopViewController (true);
			else
				viewController.DismissViewController (true, null);
			
			LblInformation.Text = $"{place.Description}\n\n{place.Attributions?.Description}";
		}

		public void DidFailAutocomplete (AutocompleteViewController viewController, NSError error)
		{
			if (PushAutocomplete)
				NavigationController.PopViewController (true);
			else
				viewController.DismissViewController (true, null);
			
			LblInformation.Text = $"Error: {error.LocalizedDescription}";
		}

		public void WasCancelled (AutocompleteViewController viewController)
		{
			if (PushAutocomplete)
				NavigationController.PopViewController (true);
			else
				viewController.DismissViewController (true, null);
			
			LblInformation.Text = "Autocompleted was cancelled";
		}

		#endregion

		#region Internal Functionality

		void ApplyCustomTheme (AutocompleteViewController autocompleteViewController)
		{
			// WhiteOnBlack Theme
			var backgroundColor = UIColor.FromWhiteAlpha (.25f, 1);
			var selectedTableCellBackgroundColor = UIColor.FromWhiteAlpha (.35f, 1);
			var primaryTextColor = UIColor.White;
			var highlightColor = UIColor.FromRGBA (.75f, 1, .75f, 1);
			var secondaryColor = UIColor.FromWhiteAlpha (1, .5f);
			var tintColor = UIColor.White;
			var searchBarTintColor = tintColor;
			var separatorColor = UIColor.FromRGBA (.5f, .75f, .5f, .3f);

			// BlueColors Theme
			if (ColorTheme == ColorTheme.BlueColors) {
				backgroundColor = UIColor.FromRGBA (225f / 255f, 241f / 255f, 252f / 255f, 1);
				selectedTableCellBackgroundColor = UIColor.FromRGBA (213f / 255f, 219f / 255f, 230f / 255f, 1);
				primaryTextColor = UIColor.FromWhiteAlpha (.5f, 1);
				highlightColor = UIColor.FromRGBA (76f / 255f, 175f / 255f, 248f / 255f, 1);
				secondaryColor = UIColor.FromWhiteAlpha (.5f, .65f);
				tintColor = UIColor.FromRGBA (0, 142f / 255f, 248f / 255f, 1);
				searchBarTintColor = tintColor;
				separatorColor = UIColor.FromWhiteAlpha (.5f, .65f);
			}

			var placeHolderColor = searchBarTintColor.ColorWithAlpha (searchBarTintColor.CGColor.Alpha * .75f);

			// Use UIAppearance proxies to change the appearance of UI controls in
			// GMSAutocompleteViewController. Here we use appearanceWhenContainedIn
			// to localise changes to just this part of the Demo app. This will 
			// generally not be necessary in a real application as you will probably 
			// want the same theme to apply to all elements in your app.
			UIActivityIndicatorView.AppearanceWhenContainedIn (typeof (StyledAutocompleteViewController))
			                       .Color = primaryTextColor;
			UITableViewCell.AppearanceWhenContainedIn (typeof (StyledAutocompleteViewController))
				       .BackgroundColor = selectedTableCellBackgroundColor;

			autocompleteViewController.TableCellBackgroundColor = backgroundColor;
			autocompleteViewController.TableCellSeparatorColor = separatorColor;
			autocompleteViewController.PrimaryTextColor = primaryTextColor;
			autocompleteViewController.PrimaryTextHighlightColor = highlightColor;
			autocompleteViewController.SecondaryTextColor = secondaryColor;
			autocompleteViewController.TintColor = tintColor;
		}

		#endregion
	}

	public enum ColorTheme
	{
		Default = -1,
		WhiteOnBlack = 0,
		BlueColors = 1,
	}
}

