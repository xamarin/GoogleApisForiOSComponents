using System;
using System.Runtime.InteropServices;

using ObjCRuntime;
using CoreGraphics;

namespace Google.MobileAds {
	[StructLayout (LayoutKind.Sequential)]
	public struct AdSize {
		public CGSize Size;
		public uint Flags;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct VersionNumber {
		public nint MajorVersion;
		public nint MinorVersion;
		public nint PatchVersion;
	}
}
