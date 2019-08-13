using System;
namespace Firebase.RemoteConfig
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
			Firebase.InstanceID.Loader.ForceLoad ();
			Firebase.ABTesting.Loader.ForceLoad ();
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
			Firebase.RemoteConfig.Loader.ForceLoad ();
		}
	}
}
