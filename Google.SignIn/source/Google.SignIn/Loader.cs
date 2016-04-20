using System;

namespace Google.SignIn
{
	public class Loader
	{
		static Loader ()
		{
			Google.Core.Loader.ForceLoad ();
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
			Google.SignIn.Loader.ForceLoad ();
		}
	}
}

