using System;

namespace MLKit.Core {
	public class Loader {
		static Loader ()
		{

		}

		public static void ForceLoad ()
		{
			Firebase.Core.Loader.ForceLoad ();
		}
	}
}
