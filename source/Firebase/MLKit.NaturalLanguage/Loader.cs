using System;
namespace Firebase.MLKit.NaturalLanguage
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.Core.Loader.ForceLoad ();
			Firebase.InstanceID.Loader.ForceLoad ();
			Firebase.MLKit.Common.Loader.ForceLoad ();
			Firebase.ABTesting.Loader.ForceLoad ();
			Firebase.RemoteConfig.Loader.ForceLoad ();
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
			Firebase.MLKit.NaturalLanguage.Loader.ForceLoad ();
		}
	}
}
