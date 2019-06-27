using System;

namespace Google.AppInvite
{
	public class Loader
	{
		static Loader ()
		{
			Google.Core.Loader.ForceLoad ();
			Google.SignIn.Loader.ForceLoad ();
		}

		public static void ForceLoad () {}
	}
}

namespace ApiDefinition
{
	partial class Messaging
	{
		static Messaging ()
		{
			Google.AppInvite.Loader.ForceLoad ();
		}
	}
}

