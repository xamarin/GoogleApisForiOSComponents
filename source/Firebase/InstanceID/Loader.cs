using System;
namespace Firebase.InstanceID
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
			Firebase.Installations.Loader.ForceLoad();
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
			Firebase.InstanceID.Loader.ForceLoad ();
		}
	}
}
