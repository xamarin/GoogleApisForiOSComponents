using System;
namespace Firebase.Invites
{
	public class Loader
	{
		public Loader ()
		{
			Firebase.InstanceID.Loader.ForceLoad ();
			Firebase.Analytics.Loader.ForceLoad ();
			Google.Core.Loader.ForceLoad ();
			Google.SignIn.Loader.ForceLoad ();
			Firebase.DynamicLinks.Loader.ForceLoad ();
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
			Firebase.Invites.Loader.ForceLoad ();
		}
	}
}
