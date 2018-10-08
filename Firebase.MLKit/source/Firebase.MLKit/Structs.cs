using System;
using ObjCRuntime;

namespace Firebase.MLKit.ModelInterpreter {
	[Native]
	public enum ModelElementType : ulong {
		Unknown = 0,
		Float32,
		Int32,
		UInt8,
		Int64
	}
}

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
