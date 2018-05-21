using System;

namespace Firebase.Crashlytics {
	public class Loader {
		static Loader ()
		{
		}

		public static void ForceLoad () { }
	}
}

namespace ApiDefinition {
	partial class Messaging {
		static Messaging ()
		{
			Firebase.Core.Loader.ForceLoad ();
			Firebase.InstanceID.Loader.ForceLoad ();
			Firebase.Analytics.Loader.ForceLoad ();
			Firebase.Crashlytics.Loader.ForceLoad ();
		}
	}
}
