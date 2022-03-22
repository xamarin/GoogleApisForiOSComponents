using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace MLKit.TextRecognition {
	// @interface MLKTextRecognizerOptions : MLKCommonTextRecognizerOptions
	[BaseType (typeof (CommonTextRecognizerOptions), Name = "MLKTextRecognizerOptions")]
	interface LatinTextRecognizerOptions {
	}
}
