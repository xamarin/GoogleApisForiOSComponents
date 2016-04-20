using System;

namespace GoogleCast
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
			GoogleCast.Loader.ForceLoad ();
		}
	}
}

