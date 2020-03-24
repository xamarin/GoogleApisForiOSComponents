using System;

using ObjCRuntime;
using Foundation;

namespace Firebase.MLKit.Vision {
	[Native]
	public enum VisionBarcodeValueType : long {
		Unknown,
		ContactInfo,
		Email,
		Isbn,
		Phone,
		Product,
		Sms,
		Text,
		Url,
		WiFi,
		GeographicCoordinates,
		CalendarEvent,
		DriversLicense
	}

	[Native]
	public enum VisionBarcodeAddressType : long {
		Unknown,
		Work,
		Home
	}

	[Native]
	public enum VisionBarcodeEmailType : long {
		Unknown,
		Work,
		Home
	}

	[Native]
	public enum VisionBarcodePhoneType : long {
		Unknown,
		Work,
		Home,
		Fax,
		Mobile
	}

	[Native]
	public enum VisionBarcodeWiFiEncryptionType : long {
		Unknown,
		Open,
		Wpa,
		Wep
	}

	[Native]
	public enum VisionBarcodeFormat : long {
		UnKnown = 0,
		All = 65535,
		Code128 = 1,
		Code39 = 2,
		Code93 = 4,
		CodaBar = 8,
		DataMatrix = 16,
		Ean13 = 32,
		Ean8 = 64,
		Itf = 128,
		QRCode = 256,
		Upca = 512,
		Upce = 1024,
		Pdf417 = 2048,
		Aztec = 4096
	}

	[Native]
	public enum VisionCloudModelType : long {
		Stable,
		Latest
	}

	[Native]
	public enum VisionCloudTextModelType : ulong {
		Sparse,
		Dense
	}

	[Native]
	public enum VisionDocumentTextBlockType : long {
		Unknown,
		Barcode,
		Picture,
		Ruler,
		Table,
		Text
	}

	public enum FaceContourType {
		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeAll;
		[Field ("FIRFaceContourTypeAll", "__Internal")]
		All,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeFace;
		[Field ("FIRFaceContourTypeFace", "__Internal")]
		Face,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeLeftEyebrowTop;
		[Field ("FIRFaceContourTypeLeftEyebrowTop", "__Internal")]
		LeftEyebrowTop,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeLeftEyebrowBottom;
		[Field ("FIRFaceContourTypeLeftEyebrowBottom", "__Internal")]
		LeftEyebrowBottom,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeRightEyebrowTop;
		[Field ("FIRFaceContourTypeRightEyebrowTop", "__Internal")]
		RightEyebrowTop,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeRightEyebrowBottom;
		[Field ("FIRFaceContourTypeRightEyebrowBottom", "__Internal")]
		RightEyebrowBottom,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeLeftEye;
		[Field ("FIRFaceContourTypeLeftEye", "__Internal")]
		LeftEye,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeRightEye;
		[Field ("FIRFaceContourTypeRightEye", "__Internal")]
		RightEye,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeUpperLipTop;
		[Field ("FIRFaceContourTypeUpperLipTop", "__Internal")]
		UpperLipTop,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeUpperLipBottom;
		[Field ("FIRFaceContourTypeUpperLipBottom", "__Internal")]
		UpperLipBottom,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeLowerLipTop;
		[Field ("FIRFaceContourTypeLowerLipTop", "__Internal")]
		LowerLipTop,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeLowerLipBottom;
		[Field ("FIRFaceContourTypeLowerLipBottom", "__Internal")]
		LowerLipBottom,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeNoseBridge;
		[Field ("FIRFaceContourTypeNoseBridge", "__Internal")]
		NoseBridge,

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeNoseBottom;
		[Field ("FIRFaceContourTypeNoseBottom", "__Internal")]
		NoseBottom
	}

	[Native]
	public enum VisionFaceDetectorClassificationMode : ulong {
		None = 1,
		All
	}

	[Native]
	public enum VisionFaceDetectorPerformanceMode : ulong {
		Fast = 1,
		Accurate
	}

	[Native]
	public enum VisionFaceDetectorLandmarkMode : ulong {
		None = 1,
		All
	}

	[Native]
	public enum VisionFaceDetectorContourMode : ulong {
		None = 1,
		All
	}

	public enum FaceLandmarkType {
		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeMouthBottom;
		[Field ("FIRFaceLandmarkTypeMouthBottom", "__Internal")]
		MouthBottom,

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeMouthRight;
		[Field ("FIRFaceLandmarkTypeMouthRight", "__Internal")]
		MouthRight,

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeMouthLeft;
		[Field ("FIRFaceLandmarkTypeMouthLeft", "__Internal")]
		MouthLeft,

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeLeftEar;
		[Field ("FIRFaceLandmarkTypeLeftEar", "__Internal")]
		LeftEar,

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeRightEar;
		[Field ("FIRFaceLandmarkTypeRightEar", "__Internal")]
		RightEar,

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeLeftEye;
		[Field ("FIRFaceLandmarkTypeLeftEye", "__Internal")]
		LeftEye,

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeRightEye;
		[Field ("FIRFaceLandmarkTypeRightEye", "__Internal")]
		RightEye,

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeLeftCheek;
		[Field ("FIRFaceLandmarkTypeLeftCheek", "__Internal")]
		LeftCheek,

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeRightCheek;
		[Field ("FIRFaceLandmarkTypeRightCheek", "__Internal")]
		RightCheek,

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeNoseBase;
		[Field ("FIRFaceLandmarkTypeNoseBase", "__Internal")]
		NoseBase
	}

	[Native]
	public enum VisionImageLabelerType : ulong
	{
		OnDevice,
		Cloud,
		OnDeviceAutoML
	}

	[Native]
	public enum VisionDetectorImageOrientation : ulong {
		TopLeft = 1,
		TopRight,
		BottomRight,
		BottomLeft,
		LeftTop,
		RightTop,
		RightBottom,
		LeftBottom
	}

	[Native]
	public enum VisionTextRecognizedBreakType : long {
		Unknown,
		LineWrap,
		Hyphen,
		LineBreak,
		Space,
		SureSpace
	}

	[Native]
	public enum VisionTextRecognizerType : long {
		OnDevice,
		Cloud
	}
}

namespace Firebase.MLKit.Vision.ObjectDetection {
	[Native]
	public enum VisionObjectCategory : long
	{
		Unknown,
		HomeGoods,
		FashionGoods,
		Food,
		Places,
		Plants
	}

	[Native]
	public enum VisionObjectDetectorMode : long
	{
		SingleImage,
		Stream
	}
}
