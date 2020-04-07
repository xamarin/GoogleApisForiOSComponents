using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

using ObjCRuntime;

namespace Firebase.Crashlytics {
	public partial class Crashlytics {
		static string currentVersion;
		public static string CurrentVersion {
			get {
				if (currentVersion == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "FirebaseCrashlyticsVersionString");
					currentVersion = Marshal.PtrToStringAnsi (ptr);
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return currentVersion;
			}
		}

		public void LogCallerInformation (string message, string className = "", [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
		{
			var logBuilder = new StringBuilder ();

			if (!string.IsNullOrWhiteSpace (filePath)) {
				var filename = Path.GetFileName (filePath);
				logBuilder.Append ($"{filename}: ");
			}

			var isMemberNameEmpty = string.IsNullOrWhiteSpace (memberName);

			if (!string.IsNullOrWhiteSpace (className)) {
				logBuilder.Append ($"{className}");
				logBuilder.Append (isMemberNameEmpty ? " " : ".");
			}

			if (!isMemberNameEmpty)
				logBuilder.Append ($"{memberName} ");

			if (lineNumber > 0)
				logBuilder.Append ($"line {lineNumber} ");

			logBuilder.Append ($"$ {message}");
			Log (logBuilder.ToString ());
		}
	}
}
