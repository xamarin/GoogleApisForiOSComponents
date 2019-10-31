using System;
namespace Firebase.MLKit.Common
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
			Firebase.InstanceID.Loader.ForceLoad ();
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
			Firebase.MLKit.Common.Loader.ForceLoad ();
		}
	}
}
