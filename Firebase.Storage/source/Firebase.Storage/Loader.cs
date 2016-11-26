using System;
namespace Firebase.Storage
{
	public class Loader
	{
		static Loader ()
		{
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
			Firebase.InstanceID.Loader.ForceLoad ();
			Firebase.Analytics.Loader.ForceLoad ();
		}
	}
}
