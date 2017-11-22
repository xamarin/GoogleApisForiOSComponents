using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

using Foundation;

namespace Firebase.CrashReporting
{
	public partial class CrashReporting
	{
		// void FIRCrashLog (NSString * _Nonnull format, ...) __attribute__((format(NSString, 1, 2)));
		[DllImport ("__Internal", EntryPoint = "FIRCrashLogv")]
		static extern void _FIRCrashLogv (IntPtr format, IntPtr varArgs);

		static readonly Regex regex = new Regex (@"%\s*\d*\s*[*.#+-]*\s*\d*\s*[eEyYuUiIoOpPaAsSdDfFgGlLxXcC]?");

		public static void Log (string message)
		{
			var fixedMessage = message ?? throw new ArgumentNullException (nameof (message));

			if (regex.IsMatch (fixedMessage))
				fixedMessage = regex.Replace (fixedMessage, "%${0}");

			var pMessage = NSString.CreateNative (fixedMessage);
			_FIRCrashLogv (pMessage, IntPtr.Zero);
			NSString.ReleaseNative (pMessage);
		}

		public static void Configure ()
		{
			Loader.ForceLoad ();
		}
	}
}
