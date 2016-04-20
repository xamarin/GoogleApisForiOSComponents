using System;

namespace Google.Core
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
			Google.Core.Loader.ForceLoad ();
		}
	}
}



