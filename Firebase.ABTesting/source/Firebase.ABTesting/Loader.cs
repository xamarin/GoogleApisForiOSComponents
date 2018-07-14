using System;

namespace Firebase.ABTesting
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
			Firebase.InstanceID.Loader.ForceLoad ();
			Firebase.Analytics.Loader.ForceLoad ();
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
			Firebase.ABTesting.Loader.ForceLoad ();
		}
	}
}
