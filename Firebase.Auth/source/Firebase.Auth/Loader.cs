using System;
namespace Firebase.Auth
{
	public class Loader
	{
		static  Loader ()
		{
			Firebase.Analytics.Loader.ForceLoad ();
			Firebase.InstanceID.Loader.ForceLoad ();
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
			Firebase.Auth.Loader.ForceLoad ();
		}
	}
}
