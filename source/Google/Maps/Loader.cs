using System;

namespace Google.Maps
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
			Google.Maps.Loader.ForceLoad ();
		}
	}
}

