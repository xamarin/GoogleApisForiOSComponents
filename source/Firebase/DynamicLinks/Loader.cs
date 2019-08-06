using System;

namespace Firebase.DynamicLinks
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
		}

		public static void ForceLoad () { }
	}
}

namespace ApiDefinition
{
	partial class Messaging
	{
		static Messaging ()
		{
			Firebase.DynamicLinks.Loader.ForceLoad ();
		}
	}
}
