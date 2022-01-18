using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace MLKit.TextRecognition {
	// @interface MLKTextRecognizerOptions : MLKCommonTextRecognizerOptions
	[BaseType (typeof (CommonTextRecognizerOptions), Name = "MLKDevanagariTextRecognizerOptions")]
	interface DevanagariTextRecognizerOptions {
	}
}
