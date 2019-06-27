using System;
using System.IO;
using System.Collections.Generic;

using Foundation;

using Newtonsoft.Json;

namespace AuthSample
{
	public class CountriesManager
	{
		static Lazy<CountriesManager> lazy = new Lazy<CountriesManager> (() => new CountriesManager ());
		public static CountriesManager SharedInstance { get; } = lazy.Value;

		public Dictionary<string, string> Countries { get; private set; }
		public Dictionary<string, string> CountryFlags { get; private set; }
		public Dictionary<string, string> PhoneCodes { get; private set; }

		CountriesManager ()
		{
			GetDictionaries ();
		}

		void GetDictionaries ()
		{
			var path = NSBundle.MainBundle.PathForResource ("CountryNames", "json");
			Countries = GetDictionaryFromJsonFile (path);

			path = NSBundle.MainBundle.PathForResource ("CountryFlags", "json");
			CountryFlags = GetDictionaryFromJsonFile (path);

			path = NSBundle.MainBundle.PathForResource ("PhoneCodes", "json");
			PhoneCodes = GetDictionaryFromJsonFile (path);
		}

		Dictionary<string, string> GetDictionaryFromJsonFile (string pathToFile)
		{
			var jsonString = File.ReadAllText (pathToFile);
			return JsonConvert.DeserializeObject<Dictionary<string, string>> (jsonString);
		}
	}
}
