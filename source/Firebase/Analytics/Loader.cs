using System;

namespace Firebase.Analytics
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Installations.Loader.ForceLoad();
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
			Firebase.Analytics.Loader.ForceLoad ();
		}
	}
}
