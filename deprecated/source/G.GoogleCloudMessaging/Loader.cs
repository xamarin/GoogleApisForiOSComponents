using System;

namespace Google.GoogleCloudMessaging
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
			Google.GoogleCloudMessaging.Loader.ForceLoad ();
		}
	}
}

