using System;

using UIKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;

using MLKit.Core;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace MLKit.BarcodeScanning {
	// @interface MLKBarcodeScannerOptions : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeScannerOptions")]
	interface BarcodeScannerOptions {
		// @property (readonly, nonatomic) MLKBarcodeFormat formats;
		[Export ("formats")]
		BarcodeFormat Formats { get; }

		// -(instancetype _Nonnull)initWithFormats:(MLKBarcodeFormat)formats __attribute__((objc_designated_initializer));
		[Export ("initWithFormats:")]
		[DesignatedInitializer]
		NativeHandle Constructor (BarcodeFormat formats);
	}

	// @interface MLKBarcodeAddress : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeAddress")]
	[DisableDefaultCtor]
	interface BarcodeAddress {
		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable addressLines;
		[NullAllowed, Export ("addressLines")]
		string [] AddressLines { get; }

		// @property (readonly, nonatomic) MLKBarcodeAddressType type;
		[Export ("type")]
		BarcodeAddressType Type { get; }
	}

	// @interface MLKBarcodeCalendarEvent : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeCalendarEvent")]
	[DisableDefaultCtor]
	interface BarcodeCalendarEvent {
		// @property (readonly, nonatomic) NSString * _Nullable eventDescription;
		[NullAllowed, Export ("eventDescription")]
		string EventDescription { get; }

		// @property (readonly, nonatomic) NSString * _Nullable location;
		[NullAllowed, Export ("location")]
		string Location { get; }

		// @property (readonly, nonatomic) NSString * _Nullable organizer;
		[NullAllowed, Export ("organizer")]
		string Organizer { get; }

		// @property (readonly, nonatomic) NSString * _Nullable status;
		[NullAllowed, Export ("status")]
		string Status { get; }

		// @property (readonly, nonatomic) NSString * _Nullable summary;
		[NullAllowed, Export ("summary")]
		string Summary { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable start;
		[NullAllowed, Export ("start")]
		NSDate Start { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable end;
		[NullAllowed, Export ("end")]
		NSDate End { get; }
	}

	// @interface MLKBarcodeDriverLicense : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeDriverLicense")]
	[DisableDefaultCtor]
	interface BarcodeDriverLicense {
		// @property (readonly, nonatomic) NSString * _Nullable firstName;
		[NullAllowed, Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable middleName;
		[NullAllowed, Export ("middleName")]
		string MiddleName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable lastName;
		[NullAllowed, Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable gender;
		[NullAllowed, Export ("gender")]
		string Gender { get; }

		// @property (readonly, nonatomic) NSString * _Nullable addressCity;
		[NullAllowed, Export ("addressCity")]
		string AddressCity { get; }

		// @property (readonly, nonatomic) NSString * _Nullable addressState;
		[NullAllowed, Export ("addressState")]
		string AddressState { get; }

		// @property (readonly, nonatomic) NSString * _Nullable addressStreet;
		[NullAllowed, Export ("addressStreet")]
		string AddressStreet { get; }

		// @property (readonly, nonatomic) NSString * _Nullable addressZip;
		[NullAllowed, Export ("addressZip")]
		string AddressZip { get; }

		// @property (readonly, nonatomic) NSString * _Nullable birthDate;
		[NullAllowed, Export ("birthDate")]
		string BirthDate { get; }

		// @property (readonly, nonatomic) NSString * _Nullable documentType;
		[NullAllowed, Export ("documentType")]
		string DocumentType { get; }

		// @property (readonly, nonatomic) NSString * _Nullable licenseNumber;
		[NullAllowed, Export ("licenseNumber")]
		string LicenseNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nullable expiryDate;
		[NullAllowed, Export ("expiryDate")]
		string ExpiryDate { get; }

		// @property (readonly, nonatomic) NSString * _Nullable issuingDate;
		[NullAllowed, Export ("issuingDate")]
		string IssuingDate { get; }

		// @property (readonly, nonatomic) NSString * _Nullable issuingCountry;
		[NullAllowed, Export ("issuingCountry")]
		string IssuingCountry { get; }
	}

	// @interface MLKBarcodeEmail : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeEmail")]
	[DisableDefaultCtor]
	interface BarcodeEmail {
		// @property (readonly, nonatomic) NSString * _Nullable address;
		[NullAllowed, Export ("address")]
		string Address { get; }

		// @property (readonly, nonatomic) NSString * _Nullable body;
		[NullAllowed, Export ("body")]
		string Body { get; }

		// @property (readonly, nonatomic) NSString * _Nullable subject;
		[NullAllowed, Export ("subject")]
		string Subject { get; }

		// @property (readonly, nonatomic) MLKBarcodeEmailType type;
		[Export ("type")]
		BarcodeEmailType Type { get; }
	}

	// @interface MLKBarcodeGeoPoint : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeGeoPoint")]
	[DisableDefaultCtor]
	interface BarcodeGeoPoint {
		// @property (readonly, nonatomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; }

		// @property (readonly, nonatomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; }
	}

	// @interface MLKBarcodePersonName : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodePersonName")]
	[DisableDefaultCtor]
	interface BarcodePersonName {
		// @property (readonly, nonatomic) NSString * _Nullable formattedName;
		[NullAllowed, Export ("formattedName")]
		string FormattedName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable first;
		[NullAllowed, Export ("first")]
		string First { get; }

		// @property (readonly, nonatomic) NSString * _Nullable last;
		[NullAllowed, Export ("last")]
		string Last { get; }

		// @property (readonly, nonatomic) NSString * _Nullable middle;
		[NullAllowed, Export ("middle")]
		string Middle { get; }

		// @property (readonly, nonatomic) NSString * _Nullable prefix;
		[NullAllowed, Export ("prefix")]
		string Prefix { get; }

		// @property (readonly, nonatomic) NSString * _Nullable pronunciation;
		[NullAllowed, Export ("pronunciation")]
		string Pronunciation { get; }

		// @property (readonly, nonatomic) NSString * _Nullable suffix;
		[NullAllowed, Export ("suffix")]
		string Suffix { get; }
	}

	// @interface MLKBarcodePhone : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodePhone")]
	[DisableDefaultCtor]
	interface BarcodePhone {
		// @property (readonly, nonatomic) NSString * _Nullable number;
		[NullAllowed, Export ("number")]
		string Number { get; }

		// @property (readonly, nonatomic) MLKBarcodePhoneType type;
		[Export ("type")]
		BarcodePhoneType Type { get; }
	}

	// @interface MLKBarcodeSMS : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeSMS")]
	[DisableDefaultCtor]
	interface BarcodeSMS {
		// @property (readonly, nonatomic) NSString * _Nullable message;
		[NullAllowed, Export ("message")]
		string Message { get; }

		// @property (readonly, nonatomic) NSString * _Nullable phoneNumber;
		[NullAllowed, Export ("phoneNumber")]
		string PhoneNumber { get; }
	}

	// @interface MLKBarcodeURLBookmark : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeURLBookmark")]
	[DisableDefaultCtor]
	interface BarcodeUrlBookmark {
		// @property (readonly, nonatomic) NSString * _Nullable title;
		[NullAllowed, Export ("title")]
		string Title { get; }

		// @property (readonly, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export ("url")]
		string Url { get; }
	}

	// @interface MLKBarcodeWiFi : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeWiFi")]
	[DisableDefaultCtor]
	interface BarcodeWiFi {
		// @property (readonly, nonatomic) NSString * _Nullable ssid;
		[NullAllowed, Export ("ssid")]
		string Ssid { get; }

		// @property (readonly, nonatomic) NSString * _Nullable password;
		[NullAllowed, Export ("password")]
		string Password { get; }

		// @property (readonly, nonatomic) MLKBarcodeWiFiEncryptionType type;
		[Export ("type")]
		BarcodeWiFiEncryptionType Type { get; }
	}

	// @interface MLKBarcodeContactInfo : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeContactInfo")]
	[DisableDefaultCtor]
	interface BarcodeContactInfo {
		// @property (readonly, nonatomic) NSArray<MLKBarcodeAddress *> * _Nullable addresses;
		[NullAllowed, Export ("addresses")]
		BarcodeAddress [] Addresses { get; }

		// @property (readonly, nonatomic) NSArray<MLKBarcodeEmail *> * _Nullable emails;
		[NullAllowed, Export ("emails")]
		BarcodeEmail [] Emails { get; }

		// @property (readonly, nonatomic) MLKBarcodePersonName * _Nullable name;
		[NullAllowed, Export ("name")]
		BarcodePersonName Name { get; }

		// @property (readonly, nonatomic) NSArray<MLKBarcodePhone *> * _Nullable phones;
		[NullAllowed, Export ("phones")]
		BarcodePhone [] Phones { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable urls;
		[NullAllowed, Export ("urls")]
		string [] Urls { get; }

		// @property (readonly, nonatomic) NSString * _Nullable jobTitle;
		[NullAllowed, Export ("jobTitle")]
		string JobTitle { get; }

		// @property (readonly, nonatomic) NSString * _Nullable organization;
		[NullAllowed, Export ("organization")]
		string Organization { get; }
	}

	// @interface MLKBarcode : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcode")]
	[DisableDefaultCtor]
	interface Barcode {
		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSString * _Nullable rawValue;
		[NullAllowed, Export ("rawValue")]
		string RawValue { get; }

		// @property (readonly, nonatomic) NSData * _Nullable rawData;
		[NullAllowed, Export ("rawData")]
		NSData RawData { get; }

		// @property (readonly, nonatomic) NSString * _Nullable displayValue;
		[NullAllowed, Export ("displayValue")]
		string DisplayValue { get; }

		// @property (readonly, nonatomic) MLKBarcodeFormat format;
		[Export ("format")]
		BarcodeFormat Format { get; }

		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nullable cornerPoints;
		[NullAllowed, Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }

		// @property (readonly, nonatomic) MLKBarcodeValueType valueType;
		[Export ("valueType")]
		BarcodeValueType ValueType { get; }

		// @property (readonly, nonatomic) MLKBarcodeEmail * _Nullable email;
		[NullAllowed, Export ("email")]
		BarcodeEmail Email { get; }

		// @property (readonly, nonatomic) MLKBarcodePhone * _Nullable phone;
		[NullAllowed, Export ("phone")]
		BarcodePhone Phone { get; }

		// @property (readonly, nonatomic) MLKBarcodeSMS * _Nullable sms;
		[NullAllowed, Export ("sms")]
		BarcodeSMS Sms { get; }

		// @property (readonly, nonatomic) MLKBarcodeURLBookmark * _Nullable URL;
		[NullAllowed, Export ("URL")]
		BarcodeUrlBookmark URL { get; }

		// @property (readonly, nonatomic) MLKBarcodeWiFi * _Nullable wifi;
		[NullAllowed, Export ("wifi")]
		BarcodeWiFi Wifi { get; }

		// @property (readonly, nonatomic) MLKBarcodeGeoPoint * _Nullable geoPoint;
		[NullAllowed, Export ("geoPoint")]
		BarcodeGeoPoint GeoPoint { get; }

		// @property (readonly, nonatomic) MLKBarcodeContactInfo * _Nullable contactInfo;
		[NullAllowed, Export ("contactInfo")]
		BarcodeContactInfo ContactInfo { get; }

		// @property (readonly, nonatomic) MLKBarcodeCalendarEvent * _Nullable calendarEvent;
		[NullAllowed, Export ("calendarEvent")]
		BarcodeCalendarEvent CalendarEvent { get; }

		// @property (readonly, nonatomic) MLKBarcodeDriverLicense * _Nullable driverLicense;
		[NullAllowed, Export ("driverLicense")]
		BarcodeDriverLicense DriverLicense { get; }
	}

	// typedef void (^MLKBarcodeScanningCallback)(NSArray<MLKBarcode *> * _Nullable, NSError * _Nullable);
	delegate void BarcodeScanningCallback ([NullAllowed] Barcode [] barcodes, [NullAllowed] NSError error);

	// @interface MLKBarcodeScanner : NSObject
	[BaseType (typeof (NSObject), Name = "MLKBarcodeScanner")]
	[DisableDefaultCtor]
	interface BarcodeScanner {
		// +(instancetype _Nonnull)barcodeScannerWithOptions:(MLKBarcodeScannerOptions * _Nonnull)options __attribute__((swift_name("barcodeScanner(options:)")));
		[Static]
		[Export ("barcodeScannerWithOptions:")]
		BarcodeScanner BarcodeScannerWithOptions (BarcodeScannerOptions options);

		// +(instancetype _Nonnull)barcodeScanner __attribute__((swift_name("barcodeScanner()")));
		[Static]
		[Export ("barcodeScanner")]
		BarcodeScanner DefaultInstance { get; }

		// -(void)processImage:(id<MLKCompatibleImage> _Nonnull)image completion:(MLKBarcodeScanningCallback _Nonnull)completion __attribute__((swift_name("process(_:completion:)")));
		[Export ("processImage:completion:")]
		void ProcessImage (ICompatibleImage image, BarcodeScanningCallback completion);

		// -(NSArray<MLKBarcode *> * _Nullable)resultsInImage:(id<MLKCompatibleImage> _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[Export ("resultsInImage:error:")]
		[return: NullAllowed]
		Barcode [] ResultsInImage (ICompatibleImage image, [NullAllowed] out NSError error);
	}
}
