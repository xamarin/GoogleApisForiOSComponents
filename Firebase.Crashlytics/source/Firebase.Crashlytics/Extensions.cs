using System;
using System.Runtime.InteropServices;
using Foundation;

namespace Firebase.Crashlytics {
	public class Logging {
		// extern void CLSLog (NSString * _Nonnull format, ...) __attribute__((format(NSString, 1, 2)));
		[DllImport ("__Internal", EntryPoint = "CLSLog")]
		static extern void _Log (IntPtr format, IntPtr varArgs);

		// extern void CLSNSLog (NSString * _Nonnull format, ...) __attribute__((format(NSString, 1, 2)));
		[DllImport ("__Internal", EntryPoint = "CLSNSLog")]
		static extern void _NSLog (IntPtr format, IntPtr varArgs);

		public static void Log (string message)
		{
			var pMessage = NSString.CreateNative (message);
			_Log (pMessage, IntPtr.Zero);
			NSString.ReleaseNative (pMessage);
		}

		[Advice ("It is not recommended for Release builds.")]
		public static void NSLog (string message)
		{
			var pMessage = NSString.CreateNative (message);
			_NSLog (pMessage, IntPtr.Zero);
			NSString.ReleaseNative (pMessage);
		}
	}
}
