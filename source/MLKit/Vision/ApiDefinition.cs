using System;

using UIKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;

using MLKit.Core;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace MLKit.Vision {
	// @interface MLKCommonImageLabelerOptions : NSObject
	[BaseType (typeof (NSObject), Name = "MLKCommonImageLabelerOptions")]
	[DisableDefaultCtor]
	interface CommonImageLabelerOptions {
		// @property (nonatomic) NSNumber * _Nullable confidenceThreshold;
		[NullAllowed, Export ("confidenceThreshold", ArgumentSemantic.Assign)]
		NSNumber ConfidenceThreshold { get; set; }
	}

	// @interface MLKImageLabel : NSObject
	[BaseType (typeof (NSObject), Name = "MLKImageLabel")]
	[DisableDefaultCtor]
	interface ImageLabel {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSInteger index;
		[Export ("index")]
		nint Index { get; }

		// @property (readonly, nonatomic) float confidence;
		[Export ("confidence")]
		float Confidence { get; }
	}

	// typedef void (^MLKImageLabelingCallback)(NSArray<MLKImageLabel *> * _Nullable, NSError * _Nullable);
	delegate void ImageLabelingCallback ([NullAllowed] ImageLabel [] imageLabels, [NullAllowed] NSError error);

	// @interface MLKImageLabeler : NSObject
	[BaseType (typeof (NSObject), Name = "MLKImageLabeler")]
	[DisableDefaultCtor]
	interface ImageLabeler {
		// +(instancetype _Nonnull)imageLabelerWithOptions:(MLKCommonImageLabelerOptions * _Nonnull)options __attribute__((swift_name("imageLabeler(options:)")));
		[Static]
		[Export ("imageLabelerWithOptions:")]
		ImageLabeler ImageLabelerWithOptions (CommonImageLabelerOptions options);

		// -(void)processImage:(id<MLKCompatibleImage> _Nonnull)image completion:(MLKImageLabelingCallback _Nonnull)completion __attribute__((swift_name("process(_:completion:)")));
		[Export ("processImage:completion:")]
		void ProcessImage (ICompatibleImage image, ImageLabelingCallback completion);

		// -(NSArray<MLKImageLabel *> * _Nullable)resultsInImage:(id<MLKCompatibleImage> _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[Export ("resultsInImage:error:")]
		[return: NullAllowed]
		ImageLabel [] ResultsInImage (ICompatibleImage image, [NullAllowed] out NSError error);
	}

	// @interface MLKCommonObjectDetectorOptions : NSObject
	[BaseType (typeof (NSObject), Name = "MLKCommonObjectDetectorOptions")]
	[DisableDefaultCtor]
	interface CommonObjectDetectorOptions {
		// @property (nonatomic) BOOL shouldEnableClassification;
		[Export ("shouldEnableClassification")]
		bool ShouldEnableClassification { get; set; }

		// @property (nonatomic) BOOL shouldEnableMultipleObjects;
		[Export ("shouldEnableMultipleObjects")]
		bool ShouldEnableMultipleObjects { get; set; }

		// @property (nonatomic) MLKObjectDetectorMode detectorMode;
		[Export ("detectorMode")]
		DetectorMode Mode { get; set; }
	}

	// @interface MLKObject : NSObject
	[BaseType (typeof (NSObject), Name = "MLKObject")]
	[DisableDefaultCtor]
	interface VisionObject {
		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<MLKObjectLabel *> * _Nonnull labels;
		[Export ("labels")]
		ObjectLabel [] Labels { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable trackingID;
		[NullAllowed, Export ("trackingID")]
		NSNumber TrackingId { get; }
	}

	// typedef void (^MLKObjectDetectionCallback)(NSArray<MLKObject *> * _Nullable, NSError * _Nullable);
	delegate void ObjectDetectionCallback ([NullAllowed] VisionObject [] objects, [NullAllowed] NSError error);

	// @interface MLKObjectDetector : NSObject
	[BaseType (typeof (NSObject), Name = "MLKObjectDetector")]
	[DisableDefaultCtor]
	interface ObjectDetector {
		// +(instancetype _Nonnull)objectDetectorWithOptions:(MLKCommonObjectDetectorOptions * _Nonnull)options __attribute__((swift_name("objectDetector(options:)")));
		[Static]
		[Export ("objectDetectorWithOptions:")]
		ObjectDetector ObjectDetectorWithOptions (CommonObjectDetectorOptions options);

		// -(void)processImage:(id<MLKCompatibleImage> _Nonnull)image completion:(MLKObjectDetectionCallback _Nonnull)completion __attribute__((swift_name("process(_:completion:)")));
		[Export ("processImage:completion:")]
		void ProcessImage (ICompatibleImage image, ObjectDetectionCallback completion);

		// -(NSArray<MLKObject *> * _Nullable)resultsInImage:(id<MLKCompatibleImage> _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[Export ("resultsInImage:error:")]
		[return: NullAllowed]
		VisionObject [] ResultsInImage (ICompatibleImage image, [NullAllowed] out NSError error);
	}

	// @interface MLKObjectLabel : NSObject
	[BaseType (typeof (NSObject), Name = "MLKObjectLabel")]
	[DisableDefaultCtor]
	interface ObjectLabel {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSInteger index;
		[Export ("index")]
		nint Index { get; }

		// @property (readonly, nonatomic) float confidence;
		[Export ("confidence")]
		float Confidence { get; }
	}
}
