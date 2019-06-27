using System;

namespace Google.MobileAds // was Google.MobileAds changing back to keep sample compiling.  Not sure if we will break this namespace or not
{
	public class Loader
	{
		static Loader ()
		{
			
		}

		public static void ForceLoad ()
		{
		}
	}
}

namespace ApiDefinition
{
	partial class Messaging
	{
		static Messaging ()
		{
			Google.MobileAds.Loader.ForceLoad ();
		}
	}
}



