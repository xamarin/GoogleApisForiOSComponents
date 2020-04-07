using System;
namespace Firebase.MLKit.Vision
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
			Firebase.Installations.Loader.ForceLoad();
			Firebase.InstanceID.Loader.ForceLoad ();
			Firebase.MLKit.Common.Loader.ForceLoad ();
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
			Firebase.MLKit.Vision.Loader.ForceLoad ();
		}
	}
}
