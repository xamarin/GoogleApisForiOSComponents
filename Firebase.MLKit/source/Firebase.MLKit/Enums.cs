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

namespace Google.MobileVision {
	[Native]
	public enum DetectorError : long {
		DetectorInvalidInput = -301
	}

	[Native]
	public enum ImageOrientation : long {
		TopLeft = 1,
		TopRight = 2,
		BottomRight = 3,
		BottomLeft = 4,
		LeftTop = 5,
		RightTop = 6,
		RightBottom = 7,
		LeftBottom = 8
	}

	[Native]
	public enum DetectorFaceModeOption : long {
		FastMode = 200,
		AccurateMode = 201,
		SelfieMode = 202
	}

	[Native]
	public enum DetectorFaceLandmark : long {
		None = 1 << 0,
		All = 1 << 1,
		Contour = 1 << 2
	}

	[Native]
	public enum DetectorFaceClassification : long {
		None = 1 << 0,
		All = 1 << 1
	}

	[Native]
	public enum BarcodeFeatureEmailType : long {
		Unknown = 0,
		Work = 1,
		Home = 2
	}

	[Native]
	public enum BarcodeFeaturePhoneType : long {
		Unknown = 0,
		Work = 1,
		Home = 2,
		Fax = 3,
		Mobile = 4
	}

	[Native]
	public enum BarcodeFeatureWiFiEncryptionType : long {
		Unknown = 0,
		Open = 1,
		Wpa = 2,
		Wep = 3
	}

	[Native]
	public enum BarcodeFeatureAddressType : long {
		Unknown = 0,
		Work = 1,
		Home = 2
	}

	[Native]
	public enum DetectorBarcodeValueFormat : long {
		ContactInfo = 1,
		Email = 2,
		Isbn = 3,
		Phone = 4,
		Product = 5,
		Sms = 6,
		Text = 7,
		Url = 8,
		WiFi = 9,
		GeographicCoordinates = 10,
		CalendarEvent = 11,
		DriversLicense = 12
	}

	[Native]
	public enum DetectorBarcodeFormat : long {
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
}

namespace Google.MobileVision {
	public enum DetectorType {
		// extern NSString *const GMVDetectorTypeFace;
		[Field ("GMVDetectorTypeFace", "__Internal")]
		Face,

		// extern NSString *const GMVDetectorTypeBarcode;
		[Field ("GMVDetectorTypeBarcode", "__Internal")]
		Barcode,

		// extern NSString *const GMVDetectorTypeText;
		[Field ("GMVDetectorTypeText", "__Internal")]
		Text,

		// extern NSString *const GMVDetectorTypeLabel;
		[Field ("GMVDetectorTypeLabel", "__Internal")]
		Label
	}

	public enum FeatureType {
		// extern NSString *const GMVFeatureTypeFace;
		[Field ("GMVFeatureTypeFace", "__Internal")]
		Face,

		// extern NSString *const GMVFeatureTypeBarcode;
		[Field ("GMVFeatureTypeBarcode", "__Internal")]
		Barcode,

		// extern NSString *const GMVFeatureTypeTextBlock;
		[Field ("GMVFeatureTypeTextBlock", "__Internal")]
		TextBlock,

		// extern NSString *const GMVFeatureTypeTextLine;
		[Field ("GMVFeatureTypeTextLine", "__Internal")]
		TextLine,

		// extern NSString *const GMVFeatureTypeTextElement;
		[Field ("GMVFeatureTypeTextElement", "__Internal")]
		TextElement,

		// extern NSString *const GMVFeatureTypeLabel;
		[Field ("GMVFeatureTypeLabel", "__Internal")]
		Label
	}
}
