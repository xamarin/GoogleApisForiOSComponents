using System;
using System.Runtime.InteropServices;
using Foundation;

namespace Firebase.Core {
	public partial class App {
		// extern NSString * _Nonnull FIRFirebaseVersion () __attribute__((swift_name("FirebaseVersion()")));
		[DllImport ("__Internal", EntryPoint = "FIRFirebaseVersion")]
		extern internal static IntPtr _FIRFirebaseVersion ();

		static string firebaseVersion;
		public static string FirebaseVersion {
			get {
				if (firebaseVersion == null) {

					IntPtr verStrPtr = _FIRFirebaseVersion ();
					firebaseVersion = NSString.FromHandle (verStrPtr);
				}

				return firebaseVersion;
			}
		}
	}
}
