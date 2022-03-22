using System;

using UIKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;

using MLKit.Core;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace MLKit.FaceDetection {

	[Static]
	partial interface FaceContours {
		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeFace;
		[Field ("MLKFaceContourTypeFace", "__Internal")]
		NSString Face { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeLeftEyebrowTop;
		[Field ("MLKFaceContourTypeLeftEyebrowTop", "__Internal")]
		NSString LeftEyebrowTop { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeLeftEyebrowBottom;
		[Field ("MLKFaceContourTypeLeftEyebrowBottom", "__Internal")]
		NSString eftEyebrowBottom { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeRightEyebrowTop;
		[Field ("MLKFaceContourTypeRightEyebrowTop", "__Internal")]
		NSString RightEyebrowTop { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeRightEyebrowBottom;
		[Field ("MLKFaceContourTypeRightEyebrowBottom", "__Internal")]
		NSString RightEyebrowBottom { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeLeftEye;
		[Field ("MLKFaceContourTypeLeftEye", "__Internal")]
		NSString LeftEye { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeRightEye;
		[Field ("MLKFaceContourTypeRightEye", "__Internal")]
		NSString RightEye { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeUpperLipTop;
		[Field ("MLKFaceContourTypeUpperLipTop", "__Internal")]
		NSString UpperLipTop { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeUpperLipBottom;
		[Field ("MLKFaceContourTypeUpperLipBottom", "__Internal")]
		NSString UpperLipBottom { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeLowerLipTop;
		[Field ("MLKFaceContourTypeLowerLipTop", "__Internal")]
		NSString LowerLipTop { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeLowerLipBottom;
		[Field ("MLKFaceContourTypeLowerLipBottom", "__Internal")]
		NSString LowerLipBottom { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeNoseBridge;
		[Field ("MLKFaceContourTypeNoseBridge", "__Internal")]
		NSString NoseBridge { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeNoseBottom;
		[Field ("MLKFaceContourTypeNoseBottom", "__Internal")]
		NSString NoseBottom { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeLeftCheek;
		[Field ("MLKFaceContourTypeLeftCheek", "__Internal")]
		NSString LeftCheek { get; }

		// extern const MLKFaceContourType _Nonnull MLKFaceContourTypeRightCheek;
		[Field ("MLKFaceContourTypeRightCheek", "__Internal")]
		NSString RightCheek { get; }
	}

	// @interface MLKFaceContour : NSObject
	[BaseType (typeof (NSObject), Name = "MLKFaceContour")]
	[DisableDefaultCtor]
	interface FaceContour {
		// @property (readonly, nonatomic) MLKFaceContourType _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic) NSArray<MLKVisionPoint *> * _Nonnull points;
		[Export ("points")]
		VisionPoint [] Points { get; }
	}

	[Static]
	partial interface FaceLandmarks {
		// extern const MLKFaceLandmarkType _Nonnull MLKFaceLandmarkTypeMouthBottom;
		[Field ("MLKFaceLandmarkTypeMouthBottom", "__Internal")]
		NSString MouthBottom { get; }

		// extern const MLKFaceLandmarkType _Nonnull MLKFaceLandmarkTypeMouthRight;
		[Field ("MLKFaceLandmarkTypeMouthRight", "__Internal")]
		NSString MouthRight { get; }

		// extern const MLKFaceLandmarkType _Nonnull MLKFaceLandmarkTypeMouthLeft;
		[Field ("MLKFaceLandmarkTypeMouthLeft", "__Internal")]
		NSString MouthLeft { get; }

		// extern const MLKFaceLandmarkType _Nonnull MLKFaceLandmarkTypeLeftEar;
		[Field ("MLKFaceLandmarkTypeLeftEar", "__Internal")]
		NSString LeftEar { get; }

		// extern const MLKFaceLandmarkType _Nonnull MLKFaceLandmarkTypeRightEar;
		[Field ("MLKFaceLandmarkTypeRightEar", "__Internal")]
		NSString RightEar { get; }

		// extern const MLKFaceLandmarkType _Nonnull MLKFaceLandmarkTypeLeftEye;
		[Field ("MLKFaceLandmarkTypeLeftEye", "__Internal")]
		NSString LeftEye { get; }

		// extern const MLKFaceLandmarkType _Nonnull MLKFaceLandmarkTypeRightEye;
		[Field ("MLKFaceLandmarkTypeRightEye", "__Internal")]
		NSString RightEye { get; }

		// extern const MLKFaceLandmarkType _Nonnull MLKFaceLandmarkTypeLeftCheek;
		[Field ("MLKFaceLandmarkTypeLeftCheek", "__Internal")]
		NSString LeftCheek { get; }

		// extern const MLKFaceLandmarkType _Nonnull MLKFaceLandmarkTypeRightCheek;
		[Field ("MLKFaceLandmarkTypeRightCheek", "__Internal")]
		NSString RightCheek { get; }

		// extern const MLKFaceLandmarkType _Nonnull MLKFaceLandmarkTypeNoseBase;
		[Field ("MLKFaceLandmarkTypeNoseBase", "__Internal")]
		NSString NoseBase { get; }
	}

	// @interface MLKFaceLandmark : NSObject
	[BaseType (typeof (NSObject), Name = "MLKFaceLandmark")]
	[DisableDefaultCtor]
	interface FaceLandmark {
		// @property (readonly, nonatomic) MLKFaceLandmarkType _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic) MLKVisionPoint * _Nonnull position;
		[Export ("position")]
		VisionPoint Position { get; }
	}

	// @interface MLKFace : NSObject
	[BaseType (typeof (NSObject), Name = "MLKFace")]
	[DisableDefaultCtor]
	interface Face {
		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<MLKFaceLandmark *> * _Nonnull landmarks;
		[Export ("landmarks")]
		FaceLandmark [] Landmarks { get; }

		// @property (readonly, nonatomic) NSArray<MLKFaceContour *> * _Nonnull contours;
		[Export ("contours")]
		FaceContour [] Contours { get; }

		// @property (readonly, nonatomic) BOOL hasTrackingID;
		[Export ("hasTrackingID")]
		bool HasTrackingID { get; }

		// @property (readonly, nonatomic) NSInteger trackingID;
		[Export ("trackingID")]
		nint TrackingID { get; }

		// @property (readonly, nonatomic) BOOL hasHeadEulerAngleX;
		[Export ("hasHeadEulerAngleX")]
		bool HasHeadEulerAngleX { get; }

		// @property (readonly, nonatomic) CGFloat headEulerAngleX;
		[Export ("headEulerAngleX")]
		nfloat HeadEulerAngleX { get; }

		// @property (readonly, nonatomic) BOOL hasHeadEulerAngleY;
		[Export ("hasHeadEulerAngleY")]
		bool HasHeadEulerAngleY { get; }

		// @property (readonly, nonatomic) CGFloat headEulerAngleY;
		[Export ("headEulerAngleY")]
		nfloat HeadEulerAngleY { get; }

		// @property (readonly, nonatomic) BOOL hasHeadEulerAngleZ;
		[Export ("hasHeadEulerAngleZ")]
		bool HasHeadEulerAngleZ { get; }

		// @property (readonly, nonatomic) CGFloat headEulerAngleZ;
		[Export ("headEulerAngleZ")]
		nfloat HeadEulerAngleZ { get; }

		// @property (readonly, nonatomic) BOOL hasSmilingProbability;
		[Export ("hasSmilingProbability")]
		bool HasSmilingProbability { get; }

		// @property (readonly, nonatomic) CGFloat smilingProbability;
		[Export ("smilingProbability")]
		nfloat SmilingProbability { get; }

		// @property (readonly, nonatomic) BOOL hasLeftEyeOpenProbability;
		[Export ("hasLeftEyeOpenProbability")]
		bool HasLeftEyeOpenProbability { get; }

		// @property (readonly, nonatomic) CGFloat leftEyeOpenProbability;
		[Export ("leftEyeOpenProbability")]
		nfloat LeftEyeOpenProbability { get; }

		// @property (readonly, nonatomic) BOOL hasRightEyeOpenProbability;
		[Export ("hasRightEyeOpenProbability")]
		bool HasRightEyeOpenProbability { get; }

		// @property (readonly, nonatomic) CGFloat rightEyeOpenProbability;
		[Export ("rightEyeOpenProbability")]
		nfloat RightEyeOpenProbability { get; }

		// -(MLKFaceLandmark * _Nullable)landmarkOfType:(MLKFaceLandmarkType _Nonnull)type;
		[Export ("landmarkOfType:")]
		[return: NullAllowed]
		FaceLandmark LandmarkOfType (string type);

		// -(MLKFaceContour * _Nullable)contourOfType:(MLKFaceContourType _Nonnull)type;
		[Export ("contourOfType:")]
		[return: NullAllowed]
		FaceContour ContourOfType (string type);
	}

	// typedef void (^MLKFaceDetectionCallback)(NSArray<MLKFace *> * _Nullable, NSError * _Nullable);
	delegate void FaceDetectionCallback ([NullAllowed] Face [] faces, [NullAllowed] NSError error);

	// @interface MLKFaceDetector : NSObject
	[BaseType (typeof (NSObject), Name = "MLKFaceDetector")]
	[DisableDefaultCtor]
	interface FaceDetector {
		// +(instancetype _Nonnull)faceDetectorWithOptions:(MLKFaceDetectorOptions * _Nonnull)options __attribute__((swift_name("faceDetector(options:)")));
		[Static]
		[Export ("faceDetectorWithOptions:")]
		FaceDetector FaceDetectorWithOptions (FaceDetectorOptions options);

		// +(instancetype _Nonnull)faceDetector __attribute__((swift_name("faceDetector()")));
		[Static]
		[Export ("faceDetector")]
		FaceDetector DefaultInstance { get; }

		// -(void)processImage:(id<MLKCompatibleImage> _Nonnull)image completion:(MLKFaceDetectionCallback _Nonnull)completion __attribute__((swift_name("process(_:completion:)")));
		[Export ("processImage:completion:")]
		void ProcessImage (ICompatibleImage image, FaceDetectionCallback completion);

		// -(NSArray<MLKFace *> * _Nullable)resultsInImage:(id<MLKCompatibleImage> _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[Export ("resultsInImage:error:")]
		[return: NullAllowed]
		Face [] ResultsInImage (ICompatibleImage image, [NullAllowed] out NSError error);
	}

	// @interface MLKFaceDetectorOptions : NSObject
	[BaseType (typeof (NSObject), Name = "MLKFaceDetectorOptions")]
	interface FaceDetectorOptions {
		// @property (nonatomic) MLKFaceDetectorClassificationMode classificationMode;
		[Export ("classificationMode")]
		FaceClassificationMode ClassificationMode { get; set; }

		// @property (nonatomic) MLKFaceDetectorPerformanceMode performanceMode;
		[Export ("performanceMode")]
		FacePerformanceMode PerformanceMode { get; set; }

		// @property (nonatomic) MLKFaceDetectorLandmarkMode landmarkMode;
		[Export ("landmarkMode")]
		FaceLandmarkMode LandmarkMode { get; set; }

		// @property (nonatomic) MLKFaceDetectorContourMode contourMode;
		[Export ("contourMode")]
		FaceContourMode ContourMode { get; set; }

		// @property (nonatomic) CGFloat minFaceSize;
		[Export ("minFaceSize")]
		nfloat MinFaceSize { get; set; }

		// @property (getter = isTrackingEnabled, nonatomic) BOOL trackingEnabled;
		[Export ("trackingEnabled")]
		bool TrackingEnabled { [Bind ("isTrackingEnabled")] get; set; }
	}
}
