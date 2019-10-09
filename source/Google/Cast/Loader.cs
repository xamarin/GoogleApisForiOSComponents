using System;

namespace Google.Cast
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
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
			Google.Cast.Loader.ForceLoad ();
		}
	}
}

