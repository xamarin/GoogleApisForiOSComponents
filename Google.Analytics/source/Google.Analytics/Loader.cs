using System;

namespace Google.Analytics
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
			Google.Analytics.Loader.ForceLoad ();
		}
	}
}

