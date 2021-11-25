using System;

using UIKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;

using MLKit.Core;
using MLKit.VisionKit;

namespace MLKit.ObjectDetection {
	[Static]
	interface DetectedObjectLabel {
		// extern const MLKDetectedObjectLabel _Nonnull MLKDetectedObjectLabelFashionGood;
		[Field ("MLKDetectedObjectLabelFashionGood", "__Internal")]
		NSString FashionGood { get; }

		// extern const MLKDetectedObjectLabel _Nonnull MLKDetectedObjectLabelHomeGood;
		[Field ("MLKDetectedObjectLabelHomeGood", "__Internal")]
		NSString HomeGood { get; }

		// extern const MLKDetectedObjectLabel _Nonnull MLKDetectedObjectLabelFood;
		[Field ("MLKDetectedObjectLabelFood", "__Internal")]
		NSString Food { get; }

		// extern const MLKDetectedObjectLabel _Nonnull MLKDetectedObjectLabelPlace;
		[Field ("MLKDetectedObjectLabelPlace", "__Internal")]
		NSString Place { get; }

		// extern const MLKDetectedObjectLabel _Nonnull MLKDetectedObjectLabelPlant;
		[Field ("MLKDetectedObjectLabelPlant", "__Internal")]
		NSString Plant { get; }
	}

	// @interface MLKObjectDetectorOptions : MLKCommonObjectDetectorOptions
	[BaseType (typeof (CommonObjectDetectorOptions), Name = "MLKObjectDetectorOptions")]
	interface ObjectDetectorOptions {
	}
}
