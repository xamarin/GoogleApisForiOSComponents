using System;

namespace Firebase.AppCheck
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
	partial class AppCheck
	{
		static AppCheck ()
		{
			Firebase.AppCheck.Loader.ForceLoad ();
		}
	}
}
