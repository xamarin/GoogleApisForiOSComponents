using System;
using System.Runtime.InteropServices;
using ObjCRuntime;
namespace Firebase.Auth
{
	public partial class Auth
	{
		static string currentVersion;
		public static string CurrentVersion { 
			get {
				if (currentVersion == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "FirebaseAuthVersionStr");
					currentVersion = Marshal.PtrToStringAnsi (ptr);
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return currentVersion;
			}
		}
	}
}
