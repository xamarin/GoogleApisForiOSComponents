using System;

namespace Google.InstanceID
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
			Google.InstanceID.Loader.ForceLoad ();
		}
	}
}

