using System;

namespace Google.TagManager
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
			Firebase.Installations.Loader.ForceLoad ();
			Firebase.Analytics.Loader.ForceLoad ();
			Google.Analytics.Loader.ForceLoad ();
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
			Google.TagManager.Loader.ForceLoad ();
		}
	}
}

