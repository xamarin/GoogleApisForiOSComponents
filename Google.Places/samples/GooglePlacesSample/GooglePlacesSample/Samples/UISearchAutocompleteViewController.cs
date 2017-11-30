using System;

using UIKit;
using Google.Places;
using Foundation;

namespace GooglePlacesSample
{
	public partial class UISearchAutocompleteViewController : UIViewController, IAutocompleteResultsViewControllerDelegate
	{
		#region Fields

		UISearchController searchController;
		AutocompleteResultsViewController autocompleteResultsViewController;

		#endregion

		#region Constructors

		public UISearchAutocompleteViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			autocompleteResultsViewController = new AutocompleteResultsViewController { Delegate = this };
			searchController = new UISearchController (autocompleteResultsViewController) {
				HidesNavigationBarDuringPresentation = false,
				DimsBackgroundDuringPresentation = false,
				SearchResultsUpdater = autocompleteResultsViewController
			};
			NavigationItem.TitleView = searchController.SearchBar;
			DefinesPresentationContext = true;
		}

		#endregion

		#region AutocompleteResultsViewController Delegate

		public void DidAutocomplete (AutocompleteResultsViewController resultsController, Place place)
		{
			searchController.Active = false;
			LblInformation.Text = $"{place.Description}\n\n{place.Attributions?.Description}";
		}

		public void DidFailAutocomplete (AutocompleteResultsViewController resultsController, NSError error)
		{
			searchController.Active = false;
			LblInformation.Text = $"Error: {error.LocalizedDescription}";
		}

		[Export ("didRequestAutocompletePredictionsForResultsController:")]
		public void DidRequestAutocompletePredictions (AutocompleteResultsViewController resultsController) => UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;

		[Export ("didUpdateAutocompletePredictionsForResultsController:")]
		public void DidUpdateAutocompletePredictions (AutocompleteResultsViewController resultsController) => UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;

		#endregion

	}
}

