using System;

namespace Google.Play.GameServices
{
	public class Loader
	{
		static Loader ()
		{
			Google.SignIn.Loader.ForceLoad ();
			Google.Core.Loader.ForceLoad ();
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

