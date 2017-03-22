using System;
using System.Runtime.InteropServices;
using Foundation;

namespace Firebase.CrashReporting
{
	public static class CrashReporting
	{
		// void FIRCrashLog (NSString * _Nonnull format, ...) __attribute__((format(NSString, 1, 2)));
		[DllImport ("__Internal", EntryPoint = "FIRCrashLogv")]
		static extern void _FIRCrashLogv (IntPtr format, IntPtr varArgs);

		public static void Log (string message)
		{
			if (message == null)
				throw new ArgumentNullException (nameof (message));

			var pMessage = NSString.CreateNative (message);
			_FIRCrashLogv (pMessage, IntPtr.Zero);
			NSString.ReleaseNative (pMessage);
		}
	}
}
