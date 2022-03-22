using System;

using UIKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;

using MLKit.Core;
using MLKit.Vision;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace MLKit.ImageLabeling {
	// @interface MLKImageLabelerOptions : MLKCommonImageLabelerOptions
	[BaseType (typeof (CommonImageLabelerOptions), Name = "MLKImageLabelerOptions")]
	interface ImageLabelerOptions {
	}
}
