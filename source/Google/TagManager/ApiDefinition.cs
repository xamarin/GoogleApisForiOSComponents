using System;
using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Google.TagManager
{
	interface ICustomFunction
	{
	}

	[Protocol]
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "TAGCustomFunction")]
	interface CustomFunction
	{
		// - (NSObject*)executeWithParameters:(NSDictionary*)parameters;
		[Abstract]
		[Export ("executeWithParameters:")]
		NSObject Execute (NSDictionary parameters);
	}
}
