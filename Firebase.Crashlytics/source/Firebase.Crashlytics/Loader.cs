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
			Firebase.Crashlytics.Loader.ForceLoad ();
		}
	}
}
