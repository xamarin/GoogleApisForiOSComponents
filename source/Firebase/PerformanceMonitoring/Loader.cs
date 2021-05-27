using System;

namespace Firebase.PerformanceMonitoring
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
			Firebase.Installations.Loader.ForceLoad();
			Firebase.ABTesting.Loader.ForceLoad ();
			Firebase.RemoteConfig.Loader.ForceLoad ();
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
			Firebase.PerformanceMonitoring.Loader.ForceLoad ();
		}
	}
}
