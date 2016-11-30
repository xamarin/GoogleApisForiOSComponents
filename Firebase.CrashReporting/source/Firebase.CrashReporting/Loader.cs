using System;

namespace Firebase.CrashReporting
{
	public class Loader
	{
		static Loader ()
		{
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
			Firebase.CrashReporting.Loader.ForceLoad ();
		}
	}
}
