using System;
using System.Runtime.InteropServices;
using ObjCRuntime;
namespace Firebase.CloudFunctions
{
	public partial class CloudFunctions {
		static string currentVersion;
		public static string CurrentVersion { 
			get {
				if (currentVersion == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "FirebaseCloudFunctionsVersionStr");
					currentVersion = Marshal.PtrToStringAnsi (ptr);
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return currentVersion;
			}
		}

		public const string CloudFunctionsErrorDomain = "com.firebase.functions";
		public const string CloudFunctionsErrorDetailsKey = "details";
	}
}
