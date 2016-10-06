using System;

namespace Google.Play.GameServices
{
	public class Loader
	{
		static Loader ()
		{
			Google.SignIn.Loader.ForceLoad ();
			Google.Core.Loader.ForceLoad ();
			Firebase.Analytics.Loader.ForceLoad ();
			Firebase.InstanceID.Loader.ForceLoad ();
		}

		public static void ForceLoad ()
		{
		}
	}
}

namespace ApiDefinition
{
	partial class Messaging
	{
		static Messaging ()
		{
			Google.Play.GameServices.Loader.ForceLoad ();
		}
	}
}

