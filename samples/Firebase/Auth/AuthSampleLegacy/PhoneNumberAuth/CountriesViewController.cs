using System;
using System.IO;
using System.Collections.Generic;

using UIKit;
using Foundation;

using MonoTouch.Dialog;
using Newtonsoft.Json;
using System.Linq;
using CoreImage;
using AuthSample;

namespace AuthSample
{
	public class CountriesViewController : DialogViewController
	{
		public event EventHandler<CountrySelectedEventArgs> CountrySelected;

		CountriesManager countriesManager;

		public CountriesViewController () : base (UITableViewStyle.Grouped, null, true)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitializeComponents ();
		}

		void InitializeComponents ()
		{
			countriesManager = CountriesManager.SharedInstance;
			var countriesSection = new Section ();

			foreach (var country in countriesManager.Countries) {
				var flag = countriesManager.CountryFlags [country.Key];
				countriesSection.Add (new StringElement ($"{country.Key} - {flag} {country.Value}", CountryTapped));
			}

			Root = new RootElement ("Countries") {
				countriesSection
			};
		}

		Dictionary<string, string> GetDictionaryFromJsonFile (string pathToFile)
		{
			var jsonString = File.ReadAllText (pathToFile);
			return JsonConvert.DeserializeObject<Dictionary<string, string>> (jsonString);
		}

		void CountryTapped ()
		{
			if (CountrySelected != null) {
				var index = TableView.IndexPathForSelectedRow.Row;
				var countryCode = countriesManager.Countries.Keys.ToArray () [index];

				var e = new CountrySelectedEventArgs (countriesManager.Countries [countryCode], countryCode, countriesManager.CountryFlags [countryCode], countriesManager.PhoneCodes [countryCode]);

				CountrySelected (this, e);
			}

			NavigationController.PopViewController (true);
		}
	}

	public class CountrySelectedEventArgs : EventArgs
	{
		public string CountryName { get; private set; }
		public string CountryCode { get; private set; }
		public string CountryFlag { get; private set; }
		public string PhoneCode { get; private set; }

		public CountrySelectedEventArgs (string countryName, string countryCode, string countryFlag, string phoneCode)
		{
			CountryName = countryName;
			CountryCode = countryCode;
			CountryFlag = countryFlag;
			PhoneCode = phoneCode;
		}
	}
}
