using System;
namespace Firebase.InAppMessaging {
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
			Firebase.Installations.Loader.ForceLoad ();
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
			Firebase.InAppMessaging.Loader.ForceLoad ();
		}
	}
}
