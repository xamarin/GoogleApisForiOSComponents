using System;
using System.Runtime.InteropServices;

using ObjCRuntime;
using CoreGraphics;

namespace Google.MobileAds
{
	[StructLayout (LayoutKind.Sequential)]
	public struct AdSize
	{
		public CGSize Size;
		public uint Flags;
	}
}
