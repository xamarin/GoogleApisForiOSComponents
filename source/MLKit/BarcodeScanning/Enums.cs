using System;
using ObjCRuntime;

namespace MLKit.BarcodeScanning {
	[Flags]
	[Native]
	public enum BarcodeFormat : long {
		Unknown = 0x0,
		All = 0xffff,
		Code128 = 0x1,
		Code39 = 0x2,
		Code93 = 0x4,
		CodaBar = 0x8,
		DataMatrix = 0x10,
		Ean13 = 0x20,
		Ean8 = 0x40,
		Itf = 0x80,
		QrCode = 0x100,
		Upca = 0x200,
		Upce = 0x400,
		Pdf417 = 0x800,
		Aztec = 0x1000
	}

	[Native]
	public enum BarcodeValueType : long {
		Unknown = 0,
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
	public enum BarcodeAddressType : long {
		Unknown = 0,
		Work = 1,
		Home = 2
	}

	[Native]
	public enum BarcodeEmailType : long {
		Unknown = 0,
		Work = 1,
		Home = 2
	}

	[Native]
	public enum BarcodePhoneType : long {
		Unknown = 0,
		Work = 1,
		Home = 2,
		Fax = 3,
		Mobile = 4
	}

	[Native]
	public enum BarcodeWiFiEncryptionType : long {
		Unknown = 0,
		Open = 1,
		Wpa = 2,
		Wep = 3
	}
}
