using System;

namespace Google.Cast
{
	public class Loader
	{
		static Loader ()
		{
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

