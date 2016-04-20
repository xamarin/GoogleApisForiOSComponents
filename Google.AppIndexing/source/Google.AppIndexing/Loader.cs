using System;

namespace Google.AppIndexing
{
	public class Loader
	{
		static Loader ()
		{
			//Google.Core.Loader.ForceLoad ();
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
			Google.AppIndexing.Loader.ForceLoad ();
		}
	}
}

