using System;

using ObjCRuntime;

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

	[Native]
	public enum VisionFaceDetectorClassification : ulong {
		None = 1,
		All
	}

	[Native]
	public enum VisionFaceDetectorMode : ulong {
		Fast = 1,
		Accurate
	}

	[Native]
	public enum VisionFaceDetectorLandmark : ulong {
		None = 1,
		All
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
	public enum ResultCoordinateSpace : long  {
		ExifCoordinateSpace = 1,
		CoordinateSpace = 2
	}

	[Native]
	public enum DetectorError : long  {
		DetectorInvalidInput = -301
	}

	[Native]
	public enum ImageOrientation : long  {
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
	public enum DetectorFaceModeOption : long  {
		FastMode = 200,
		AccurateMode = 201
	}

	[Native]
	public enum DetectorFaceLandmark : long  {
		None = 1 << 0,
		All = 1 << 1
	}

	[Native]
	public enum DetectorFaceClassification : long  {
		None = 1 << 0,
		All = 1 << 1
	}

	[Native]
	public enum BarcodeFeatureEmailType : long  {
		Unknown = 0,
		Work = 1,
		Home = 2
	}

	[Native]
	public enum BarcodeFeaturePhoneType : long  {
		Unknown = 0,
		Work = 1,
		Home = 2,
		Fax = 3,
		Mobile = 4
	}

	[Native]
	public enum BarcodeFeatureWiFiEncryptionType : long  {
		Unknown = 0,
		Open = 1,
		Wpa = 2,
		Wep = 3
	}

	[Native]
	public enum BarcodeFeatureAddressType : long  {
		Unknown = 0,
		Work = 1,
		Home = 2
	}

	[Native]
	public enum DetectorBarcodeValueFormat : long  {
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
	public enum DetectorBarcodeFormat : long  {
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
