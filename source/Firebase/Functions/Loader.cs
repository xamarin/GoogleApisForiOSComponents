using System;
namespace Firebase.Functions
{
	public class Loader
	{
		static  Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
		}

		public static void ForceLoad () { }
	}
}

namespace ApiDefinition
{
	partial class Messaging
	{
		static Messaging ()
		{
			Firebase.Functions.Loader.ForceLoad ();
		}
	}
}
