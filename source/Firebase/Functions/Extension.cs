using System;
using System.Runtime.InteropServices;
using ObjCRuntime;
namespace Firebase.Functions
{
	public partial class Functions {
		static string currentVersion;
		public static string CurrentVersion { 
			get {
				if (currentVersion == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "FirebaseFunctionsVersionStr");
					currentVersion = Marshal.PtrToStringAnsi (ptr);
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return currentVersion;
			}
		}
	}
}
