using System;

namespace Firebase.AppDistribution
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
	partial class AppDistribution
	{
		static AppDistribution ()
		{
			Firebase.AppDistribution.Loader.ForceLoad ();
		}
	}
}
