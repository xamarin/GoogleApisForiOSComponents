using System;
using System.Collections.Generic;

using AVFoundation;
using CoreGraphics;
using CoreMedia;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Firebase.MLKit.Vision {
	// @interface FIRVision : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVision")]
	interface VisionApi {
		// @property (getter = isStatsCollectionEnabled, nonatomic) BOOL statsCollectionEnabled;
		[Export ("statsCollectionEnabled")]
		bool StatsCollectionEnabled { [Bind ("isStatsCollectionEnabled")] get; set; }

		// This method is not finding the default instance of Firebase.Core.App
		// but, if I pass the default instance to Create (App) overload method,
		// it works properly. Need to investigate this.
		//// +(instancetype _Nonnull)vision;
		//[Static]
		//[Export ("vision")]
		//VisionApi Create ();

		// +(instancetype _Nonnull)vision;
		[Static]
		[Wrap ("Create (Firebase.Core.App.DefaultInstance)")]
		VisionApi Create ();
		
		// +(instancetype _Nonnull)visionForApp:(FIRApp * _Nonnull)app;
		[Static]
		[Export ("visionForApp:")]
		VisionApi Create (Core.App app);

		// -(FIRVisionBarcodeDetector * _Nonnull)barcodeDetectorWithOptions:(FIRVisionBarcodeDetectorOptions * _Nonnull)options;
		[Export ("barcodeDetectorWithOptions:")]
		VisionBarcodeDetector GetBarcodeDetector (VisionBarcodeDetectorOptions options);

		// -(FIRVisionBarcodeDetector * _Nonnull)barcodeDetector;
		[Export ("barcodeDetector")]
		VisionBarcodeDetector GetBarcodeDetector ();

		// -(FIRVisionFaceDetector * _Nonnull)faceDetectorWithOptions:(FIRVisionFaceDetectorOptions * _Nonnull)options;
		[Export ("faceDetectorWithOptions:")]
		VisionFaceDetector GetFaceDetector (VisionFaceDetectorOptions options);

		// -(FIRVisionFaceDetector * _Nonnull)faceDetector;
		[Export ("faceDetector")]
		VisionFaceDetector GetFaceDetector ();

		// -(FIRVisionLabelDetector * _Nonnull)labelDetectorWithOptions:(FIRVisionLabelDetectorOptions * _Nonnull)options;
		[Export ("labelDetectorWithOptions:")]
		VisionLabelDetector GetLabelDetector (VisionLabelDetectorOptions options);

		// -(FIRVisionLabelDetector * _Nonnull)labelDetector;
		[Export ("labelDetector")]
		VisionLabelDetector GetLabelDetector ();

		// -(FIRVisionTextRecognizer * _Nonnull)onDeviceTextRecognizer;
		[Export ("onDeviceTextRecognizer")]
		VisionTextRecognizer GetOnDeviceTextRecognizer ();

		// -(FIRVisionTextRecognizer * _Nonnull)cloudTextRecognizerWithOptions:(FIRVisionCloudTextRecognizerOptions * _Nonnull)options;
		[Export ("cloudTextRecognizerWithOptions:")]
		VisionTextRecognizer GetCloudTextRecognizer (VisionCloudTextRecognizerOptions options);

		// -(FIRVisionTextRecognizer * _Nonnull)cloudTextRecognizer;
		[Export ("cloudTextRecognizer")]
		VisionTextRecognizer GetCloudTextRecognizer ();

		// -(FIRVisionDocumentTextRecognizer * _Nonnull)cloudDocumentTextRecognizerWithOptions:(FIRVisionCloudDocumentTextRecognizerOptions * _Nonnull)options;
		[Export ("cloudDocumentTextRecognizerWithOptions:")]
		VisionDocumentTextRecognizer GetCloudDocumentTextRecognizer (VisionCloudDocumentTextRecognizerOptions options);

		// -(FIRVisionDocumentTextRecognizer * _Nonnull)cloudDocumentTextRecognizer;
		[Export ("cloudDocumentTextRecognizer")]
		VisionDocumentTextRecognizer GetCloudDocumentTextRecognizer ();

		// -(FIRVisionCloudLandmarkDetector * _Nonnull)cloudLandmarkDetectorWithOptions:(FIRVisionCloudDetectorOptions * _Nonnull)options;
		[Export ("cloudLandmarkDetectorWithOptions:")]
		VisionCloudLandmarkDetector GetCloudLandmarkDetector (VisionCloudDetectorOptions options);

		// -(FIRVisionCloudLandmarkDetector * _Nonnull)cloudLandmarkDetector;
		[Export ("cloudLandmarkDetector")]
		VisionCloudLandmarkDetector GetCloudLandmarkDetector ();

		// -(FIRVisionCloudLabelDetector * _Nonnull)cloudLabelDetectorWithOptions:(FIRVisionCloudDetectorOptions * _Nonnull)options;
		[Export ("cloudLabelDetectorWithOptions:")]
		VisionCloudLabelDetector GetCloudLabelDetector (VisionCloudDetectorOptions options);

		// -(FIRVisionCloudLabelDetector * _Nonnull)cloudLabelDetector;
		[Export ("cloudLabelDetector")]
		VisionCloudLabelDetector GetCloudLabelDetector ();
	}

	// @interface FIRVisionBarcodeAddress : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeAddress")]
	interface VisionBarcodeAddress {
		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable addressLines;
		[NullAllowed]
		[Export ("addressLines")]
		string [] AddressLines { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeAddressType type;
		[Export ("type")]
		VisionBarcodeAddressType Type { get; }
	}

	// @interface FIRVisionBarcodeCalendarEvent : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeCalendarEvent")]
	interface VisionBarcodeCalendarEvent {
		// @property (readonly, nonatomic) NSString * _Nullable eventDescription;
		[NullAllowed]
		[Export ("eventDescription")]
		string EventDescription { get; }

		// @property (readonly, nonatomic) NSString * _Nullable location;
		[NullAllowed]
		[Export ("location")]
		string Location { get; }

		// @property (readonly, nonatomic) NSString * _Nullable organizer;
		[NullAllowed]
		[Export ("organizer")]
		string Organizer { get; }

		// @property (readonly, nonatomic) NSString * _Nullable status;
		[NullAllowed]
		[Export ("status")]
		string Status { get; }

		// @property (readonly, nonatomic) NSString * _Nullable summary;
		[NullAllowed]
		[Export ("summary")]
		string Summary { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable start;
		[NullAllowed]
		[Export ("start")]
		NSDate Start { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable end;
		[NullAllowed]
		[Export ("end")]
		NSDate End { get; }
	}

	// @interface FIRVisionBarcodeDriverLicense : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeDriverLicense")]
	interface VisionBarcodeDriverLicense {
		// @property (readonly, nonatomic) NSString * _Nullable firstName;
		[NullAllowed]
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable middleName;
		[NullAllowed]
		[Export ("middleName")]
		string MiddleName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable lastName;
		[NullAllowed]
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable gender;
		[NullAllowed]
		[Export ("gender")]
		string Gender { get; }

		// @property (readonly, nonatomic) NSString * _Nullable addressCity;
		[NullAllowed]
		[Export ("addressCity")]
		string AddressCity { get; }

		// @property (readonly, nonatomic) NSString * _Nullable addressState;
		[NullAllowed]
		[Export ("addressState")]
		string AddressState { get; }

		// @property (readonly, nonatomic) NSString * _Nullable addressStreet;
		[NullAllowed]
		[Export ("addressStreet")]
		string AddressStreet { get; }

		// @property (readonly, nonatomic) NSString * _Nullable addressZip;
		[NullAllowed]
		[Export ("addressZip")]
		string AddressZip { get; }

		// @property (readonly, nonatomic) NSString * _Nullable birthDate;
		[NullAllowed]
		[Export ("birthDate")]
		string BirthDate { get; }

		// @property (readonly, nonatomic) NSString * _Nullable documentType;
		[NullAllowed]
		[Export ("documentType")]
		string DocumentType { get; }

		// @property (readonly, nonatomic) NSString * _Nullable licenseNumber;
		[NullAllowed]
		[Export ("licenseNumber")]
		string LicenseNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nullable expiryDate;
		[NullAllowed]
		[Export ("expiryDate")]
		string ExpiryDate { get; }

		// @property (readonly, nonatomic) NSString * _Nullable issuingDate;
		[NullAllowed]
		[Export ("issuingDate")]
		string IssuingDate { get; }

		// @property (readonly, nonatomic) NSString * _Nullable issuingCountry;
		[NullAllowed]
		[Export ("issuingCountry")]
		string IssuingCountry { get; }
	}

	// @interface FIRVisionBarcodeEmail : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeEmail")]
	interface VisionBarcodeEmail {
		// @property (readonly, nonatomic) NSString * _Nullable address;
		[NullAllowed]
		[Export ("address")]
		string Address { get; }

		// @property (readonly, nonatomic) NSString * _Nullable body;
		[NullAllowed]
		[Export ("body")]
		string Body { get; }

		// @property (readonly, nonatomic) NSString * _Nullable subject;
		[NullAllowed]
		[Export ("subject")]
		string Subject { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeEmailType type;
		[Export ("type")]
		VisionBarcodeEmailType Type { get; }
	}

	// @interface FIRVisionBarcodeGeoPoint : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeGeoPoint")]
	interface VisionBarcodeGeoPoint {
		// @property (readonly, nonatomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; }

		// @property (readonly, nonatomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; }
	}

	// @interface FIRVisionBarcodePersonName : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodePersonName")]
	interface VisionBarcodePersonName {
		// @property (readonly, nonatomic) NSString * _Nullable formattedName;
		[NullAllowed]
		[Export ("formattedName")]
		string FormattedName { get; }

		// @property (readonly, nonatomic) NSString * _Nullable first;
		[NullAllowed]
		[Export ("first")]
		string First { get; }

		// @property (readonly, nonatomic) NSString * _Nullable last;
		[NullAllowed]
		[Export ("last")]
		string Last { get; }

		// @property (readonly, nonatomic) NSString * _Nullable middle;
		[NullAllowed]
		[Export ("middle")]
		string Middle { get; }

		// @property (readonly, nonatomic) NSString * _Nullable prefix;
		[NullAllowed]
		[Export ("prefix")]
		string Prefix { get; }

		// @property (readonly, nonatomic) NSString * _Nullable pronounciation;
		[NullAllowed]
		[Export ("pronounciation")]
		string Pronounciation { get; }

		// @property (readonly, nonatomic) NSString * _Nullable suffix;
		[NullAllowed]
		[Export ("suffix")]
		string Suffix { get; }
	}

	// @interface FIRVisionBarcodePhone : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodePhone")]
	interface VisionBarcodePhone {
		// @property (readonly, nonatomic) NSString * _Nullable number;
		[NullAllowed]
		[Export ("number")]
		string Number { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodePhoneType type;
		[Export ("type")]
		VisionBarcodePhoneType Type { get; }
	}

	// @interface FIRVisionBarcodeSMS : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeSMS")]
	interface VisionBarcodeSms {
		// @property (readonly, nonatomic) NSString * _Nullable message;
		[NullAllowed]
		[Export ("message")]
		string Message { get; }

		// @property (readonly, nonatomic) NSString * _Nullable phoneNumber;
		[NullAllowed]
		[Export ("phoneNumber")]
		string PhoneNumber { get; }
	}

	// @interface FIRVisionBarcodeURLBookmark : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeURLBookmark")]
	interface VisionBarcodeUrlBookmark {
		// @property (readonly, nonatomic) NSString * _Nullable title;
		[NullAllowed]
		[Export ("title")]
		string Title { get; }

		// @property (readonly, nonatomic) NSString * _Nullable url;
		[NullAllowed]
		[Export ("url")]
		string Url { get; }
	}

	// @interface FIRVisionBarcodeWiFi : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeWiFi")]
	interface VisionBarcodeWiFi {
		// @property (readonly, nonatomic) NSString * _Nullable ssid;
		[NullAllowed]
		[Export ("ssid")]
		string Ssid { get; }

		// @property (readonly, nonatomic) NSString * _Nullable password;
		[NullAllowed]
		[Export ("password")]
		string Password { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeWiFiEncryptionType type;
		[Export ("type")]
		VisionBarcodeWiFiEncryptionType Type { get; }
	}

	// @interface FIRVisionBarcodeContactInfo : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeContactInfo")]
	interface VisionBarcodeContactInfo {
		// @property (readonly, nonatomic) NSArray<FIRVisionBarcodeAddress *> * _Nullable addresses;
		[NullAllowed]
		[Export ("addresses")]
		VisionBarcodeAddress [] Addresses { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionBarcodeEmail *> * _Nullable emails;
		[NullAllowed]
		[Export ("emails")]
		VisionBarcodeEmail [] Emails { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodePersonName * _Nullable name;
		[NullAllowed]
		[Export ("name")]
		VisionBarcodePersonName Name { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionBarcodePhone *> * _Nullable phones;
		[NullAllowed]
		[Export ("phones")]
		VisionBarcodePhone [] Phones { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable urls;
		[NullAllowed]
		[Export ("urls")]
		string [] Urls { get; }

		// @property (readonly, nonatomic) NSString * _Nullable jobTitle;
		[NullAllowed]
		[Export ("jobTitle")]
		string JobTitle { get; }

		// @property (readonly, nonatomic) NSString * _Nullable organization;
		[NullAllowed]
		[Export ("organization")]
		string Organization { get; }
	}

	// @interface FIRVisionBarcode : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcode")]
	interface VisionBarcode {
		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSString * _Nullable rawValue;
		[NullAllowed]
		[Export ("rawValue")]
		string RawValue { get; }

		// @property (readonly, nonatomic) NSString * _Nullable displayValue;
		[NullAllowed]
		[Export ("displayValue")]
		string DisplayValue { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeFormat format;
		[Export ("format")]
		VisionBarcodeFormat Format { get; }

		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nullable cornerPoints;
		[NullAllowed]
		[Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeValueType valueType;
		[Export ("valueType")]
		VisionBarcodeValueType ValueType { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeEmail * _Nullable email;
		[NullAllowed]
		[Export ("email")]
		VisionBarcodeEmail Email { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodePhone * _Nullable phone;
		[NullAllowed]
		[Export ("phone")]
		VisionBarcodePhone Phone { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeSMS * _Nullable sms;
		[NullAllowed]
		[Export ("sms")]
		VisionBarcodeSms Sms { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeURLBookmark * _Nullable URL;
		[NullAllowed]
		[Export ("URL")]
		VisionBarcodeUrlBookmark Url { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeWiFi * _Nullable wifi;
		[NullAllowed]
		[Export ("wifi")]
		VisionBarcodeWiFi Wifi { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeGeoPoint * _Nullable geoPoint;
		[NullAllowed]
		[Export ("geoPoint")]
		VisionBarcodeGeoPoint GeoPoint { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeContactInfo * _Nullable contactInfo;
		[NullAllowed]
		[Export ("contactInfo")]
		VisionBarcodeContactInfo ContactInfo { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeCalendarEvent * _Nullable calendarEvent;
		[NullAllowed]
		[Export ("calendarEvent")]
		VisionBarcodeCalendarEvent CalendarEvent { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeDriverLicense * _Nullable driverLicense;
		[NullAllowed]
		[Export ("driverLicense")]
		VisionBarcodeDriverLicense DriverLicense { get; }
	}

	// typedef void (^FIRVisionBarcodeDetectionCallback)(NSArray<FIRVisionBarcode *> * _Nullable, NSError * _Nullable);
	delegate void VisionBarcodeDetectionCallbackHandler ([NullAllowed] VisionBarcode [] barcodes, [NullAllowed] NSError error);

	// @interface FIRVisionBarcodeDetector : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeDetector")]
	interface VisionBarcodeDetector {
		// -(void)detectInImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionBarcodeDetectionCallback _Nonnull)completion;
		[Async]
		[Export ("detectInImage:completion:")]
		void Detect (VisionImage image, VisionBarcodeDetectionCallbackHandler completion);
	}

	// @interface FIRVisionBarcodeDetectorOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeDetectorOptions")]
	interface VisionBarcodeDetectorOptions {
		// @property (readonly, nonatomic) FIRVisionBarcodeFormat formats;
		[Export ("formats")]
		VisionBarcodeFormat Formats { get; }

		// -(instancetype _Nonnull)initWithFormats:(FIRVisionBarcodeFormat)formats __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithFormats:")]
		IntPtr Constructor (VisionBarcodeFormat formats);
	}

	// @interface FIRVisionCloudDetectorOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRVisionCloudDetectorOptions")]
	interface VisionCloudDetectorOptions {
		// @property (nonatomic) FIRVisionCloudModelType modelType;
		[Export ("modelType", ArgumentSemantic.Assign)]
		VisionCloudModelType ModelType { get; set; }

		// @property (nonatomic) NSUInteger maxResults;
		[Export ("maxResults")]
		nuint MaxResults { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable APIKeyOverride;
		[NullAllowed]
		[Export ("APIKeyOverride")]
		string ApiKeyOverride { get; set; }
	}

	// @interface FIRVisionCloudDocumentTextRecognizerOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRVisionCloudDocumentTextRecognizerOptions")]
	interface VisionCloudDocumentTextRecognizerOptions {
		// @property (nonatomic) NSArray<NSString *> * _Nullable languageHints;
		[NullAllowed]
		[Export ("languageHints", ArgumentSemantic.Assign)]
		string [] LanguageHints { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable APIKeyOverride;
		[NullAllowed]
		[Export ("APIKeyOverride")]
		string ApiKeyOverride { get; set; }
	}

	// @interface FIRVisionCloudLabel : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionCloudLabel")]
	interface VisionCloudLabel {
		// @property (readonly, copy, nonatomic) NSString * _Nullable entityId;
		[NullAllowed]
		[Export ("entityId")]
		string EntityId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable label;
		[NullAllowed]
		[Export ("label")]
		string Label { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed]
		[Export ("confidence")]
		NSNumber Confidence { get; }
	}

	// typedef void (^FIRVisionCloudLabelDetectionCompletion)(NSArray<FIRVisionCloudLabel *> * _Nullable, NSError * _Nullable);
	delegate void VisionCloudLabelDetectionCompletionHandler ([NullAllowed] VisionCloudLabel [] labels, [NullAllowed] NSError error);

	// @interface FIRVisionCloudLabelDetector : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionCloudLabelDetector")]
	interface VisionCloudLabelDetector {
		// -(void)detectInImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionCloudLabelDetectionCompletion _Nonnull)completion;
		[Async]
		[Export ("detectInImage:completion:")]
		void Detect (VisionImage image, VisionCloudLabelDetectionCompletionHandler completion);
	}

	// @interface FIRVisionCloudLandmark : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionCloudLandmark")]
	interface VisionCloudLandmark {
		// @property (readonly, copy, nonatomic) NSString * _Nullable entityId;
		[NullAllowed]
		[Export ("entityId")]
		string EntityId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable landmark;
		[NullAllowed]
		[Export ("landmark")]
		string Landmark { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed]
		[Export ("confidence")]
		NSNumber Confidence { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionLatitudeLongitude *> * _Nullable locations;
		[NullAllowed]
		[Export ("locations")]
		VisionLatitudeLongitude [] Locations { get; }
	}

	// typedef void (^FIRVisionCloudLandmarkDetectionCompletion)(NSArray<FIRVisionCloudLandmark *> * _Nullable, NSError * _Nullable);
	delegate void VisionCloudLandmarkDetectionCompletionHandler ([NullAllowed] VisionCloudLandmark [] landmarks, [NullAllowed] NSError error);

	// @interface FIRVisionCloudLandmarkDetector : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionCloudLandmarkDetector")]
	interface VisionCloudLandmarkDetector {
		// -(void)detectInImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionCloudLandmarkDetectionCompletion _Nonnull)completion;
		[Async]
		[Export ("detectInImage:completion:")]
		void Detect (VisionImage image, VisionCloudLandmarkDetectionCompletionHandler completion);
	}

	// @interface FIRVisionCloudTextRecognizerOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRVisionCloudTextRecognizerOptions")]
	interface VisionCloudTextRecognizerOptions {
		// @property (nonatomic) FIRVisionCloudTextModelType modelType;
		[Export ("modelType", ArgumentSemantic.Assign)]
		VisionCloudTextModelType ModelType { get; set; }

		// @property (nonatomic) NSArray<NSString *> * _Nullable languageHints;
		[NullAllowed]
		[Export ("languageHints", ArgumentSemantic.Copy)]
		string [] LanguageHints { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable APIKeyOverride;
		[NullAllowed]
		[Export ("APIKeyOverride")]
		string ApiKeyOverride { get; set; }
	}

	// @interface FIRVisionDocumentText : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionDocumentText")]
	interface VisionDocumentText {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionDocumentTextBlock *> * _Nonnull blocks;
		[Export ("blocks")]
		VisionDocumentTextBlock [] Blocks { get; }
	}

	// @interface FIRVisionDocumentTextBlock : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionDocumentTextBlock")]
	interface VisionDocumentTextBlock {
		// @property (readonly, nonatomic) FIRVisionDocumentTextBlockType type;
		[Export ("type")]
		VisionDocumentTextBlockType Type { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionDocumentTextParagraph *> * _Nonnull paragraphs;
		[Export ("paragraphs")]
		VisionDocumentTextParagraph [] Paragraphs { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSNumber * _Nonnull confidence;
		[Export ("confidence")]
		NSNumber Confidence { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		VisionTextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) FIRVisionTextRecognizedBreak * _Nullable recognizedBreak;
		[NullAllowed]
		[Export ("recognizedBreak")]
		VisionTextRecognizedBreak RecognizedBreak { get; }
	}

	// @interface FIRVisionDocumentTextParagraph : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionDocumentTextParagraph")]
	interface VisionDocumentTextParagraph {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionDocumentTextWord *> * _Nonnull words;
		[Export ("words")]
		VisionDocumentTextWord [] Words { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSNumber * _Nonnull confidence;
		[Export ("confidence")]
		NSNumber Confidence { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		VisionTextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) FIRVisionTextRecognizedBreak * _Nullable recognizedBreak;
		[NullAllowed]
		[Export ("recognizedBreak")]
		VisionTextRecognizedBreak RecognizedBreak { get; }
	}

	// typedef void (^FIRVisionDocumentTextRecognitionCallback)(FIRVisionDocumentText * _Nullable, NSError * _Nullable);
	delegate void VisionDocumentTextRecognitionCallbackHandler ([NullAllowed] VisionDocumentText text, [NullAllowed] NSError error);

	// @interface FIRVisionDocumentTextRecognizer : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionDocumentTextRecognizer")]
	interface VisionDocumentTextRecognizer {
		// -(void)processImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionDocumentTextRecognitionCallback _Nonnull)completion;
		[Async]
		[Export ("processImage:completion:")]
		void ProcessImage (VisionImage image, VisionDocumentTextRecognitionCallbackHandler completion);
	}

	// @interface FIRVisionDocumentTextSymbol : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionDocumentTextSymbol")]
	interface VisionDocumentTextSymbol {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSNumber * _Nonnull confidence;
		[Export ("confidence")]
		NSNumber Confidence { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		VisionTextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) FIRVisionTextRecognizedBreak * _Nullable recognizedBreak;
		[NullAllowed]
		[Export ("recognizedBreak")]
		VisionTextRecognizedBreak RecognizedBreak { get; }
	}

	// @interface FIRVisionDocumentTextWord : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionDocumentTextWord")]
	interface VisionDocumentTextWord {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionDocumentTextSymbol *> * _Nonnull symbols;
		[Export ("symbols")]
		VisionDocumentTextSymbol [] Symbols { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSNumber * _Nonnull confidence;
		[Export ("confidence")]
		NSNumber Confidence { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		VisionTextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) FIRVisionTextRecognizedBreak * _Nullable recognizedBreak;
		[NullAllowed]
		[Export ("recognizedBreak")]
		VisionTextRecognizedBreak RecognizedBreak { get; }
	}

	// @interface FIRVisionFace : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionFace")]
	interface VisionFace {
		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) BOOL hasTrackingID;
		[Export ("hasTrackingID")]
		bool HasTrackingId { get; }

		// @property (readonly, nonatomic) NSInteger trackingID;
		[Export ("trackingID")]
		nint TrackingId { get; }

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

		// -(FIRVisionFaceLandmark * _Nullable)landmarkOfType:(FIRFaceLandmarkType _Nonnull)type;
		[return: NullAllowed]
		[Export ("landmarkOfType:")]
		VisionFaceLandmark GetLandmark (string type);
	}

	[Static]
	interface FaceContourType {
		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeAll;
		[Field ("FIRFaceContourTypeAll", "__Internal")]
		NSString All { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeFace;
		[Field ("FIRFaceContourTypeFace", "__Internal")]
		NSString Face { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeLeftEyebrowTop;
		[Field ("FIRFaceContourTypeLeftEyebrowTop", "__Internal")]
		NSString LeftEyebrowTop { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeLeftEyebrowBottom;
		[Field ("FIRFaceContourTypeLeftEyebrowBottom", "__Internal")]
		NSString LeftEyebrowBottom { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeRightEyebrowTop;
		[Field ("FIRFaceContourTypeRightEyebrowTop", "__Internal")]
		NSString RightEyebrowTop { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeRightEyebrowBottom;
		[Field ("FIRFaceContourTypeRightEyebrowBottom", "__Internal")]
		NSString RightEyebrowBottom { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeLeftEye;
		[Field ("FIRFaceContourTypeLeftEye", "__Internal")]
		NSString LeftEye { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeRightEye;
		[Field ("FIRFaceContourTypeRightEye", "__Internal")]
		NSString RightEye { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeUpperLipTop;
		[Field ("FIRFaceContourTypeUpperLipTop", "__Internal")]
		NSString UpperLipTop { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeUpperLipBottom;
		[Field ("FIRFaceContourTypeUpperLipBottom", "__Internal")]
		NSString UpperLipBottom { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeLowerLipTop;
		[Field ("FIRFaceContourTypeLowerLipTop", "__Internal")]
		NSString LowerLipTop { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeLowerLipBottom;
		[Field ("FIRFaceContourTypeLowerLipBottom", "__Internal")]
		NSString LowerLipBottom { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeNoseBridge;
		[Field ("FIRFaceContourTypeNoseBridge", "__Internal")]
		NSString NoseBridge { get; }

		// extern const FIRFaceContourType _Nonnull FIRFaceContourTypeNoseBottom;
		[Field ("FIRFaceContourTypeNoseBottom", "__Internal")]
		NSString NoseBottom { get; }
	}

	// @interface FIRVisionFaceContour : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionFaceContour")]
	interface VisionFaceContour {
		// @property (readonly, nonatomic) FIRFaceContourType _Nonnull type;
		[Export ("type")]
		NSString Type { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionPoint *> * _Nonnull points;
		[Export ("points")]
		VisionPoint [] Points { get; }
	}

	// typedef void (^FIRVisionFaceDetectionCallback)(NSArray<FIRVisionFace *> * _Nullable, NSError * _Nullable);
	delegate void VisionFaceDetectionCallbackHandler ([NullAllowed] VisionFace [] face, [NullAllowed] NSError error);

	// @interface FIRVisionFaceDetector : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionFaceDetector")]
	interface VisionFaceDetector {
		// -(void)processImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionFaceDetectionCallback _Nonnull)completion;
		[Async]
		[Export ("processImage:completion:")]
		void ProcessImage (VisionImage image, VisionFaceDetectionCallbackHandler completion);

		// -(NSArray<FIRVisionFace *> * _Nullable)resultsInImage:(FIRVisionImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[return: NullAllowed]
		[Export ("resultsInImage:error:")]
		VisionFace [] GetResults (VisionImage image, [NullAllowed] out NSError error);
	}

	// @interface FIRVisionFaceDetectorOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRVisionFaceDetectorOptions")]
	interface VisionFaceDetectorOptions {
		// @property (nonatomic) FIRVisionFaceDetectorClassificationMode classificationMode;
		[Export ("classificationMode", ArgumentSemantic.Assign)]
		VisionFaceDetectorClassificationMode ClassificationMode { get; set; }

		// @property (nonatomic) FIRVisionFaceDetectorPerformanceMode performanceMode;
		[Export ("performanceMode", ArgumentSemantic.Assign)]
		VisionFaceDetectorPerformanceMode PerformanceMode { get; set; }

		// @property (nonatomic) FIRVisionFaceDetectorLandmarkMode landmarkMode;
		[Export ("landmarkMode", ArgumentSemantic.Assign)]
		VisionFaceDetectorLandmarkMode LandmarkMode { get; set; }

		// @property (nonatomic) FIRVisionFaceDetectorContourMode contourMode;
		[Export ("contourMode", ArgumentSemantic.Assign)]
		VisionFaceDetectorContourMode ContourMode { get; set; }

		// @property (nonatomic) CGFloat minFaceSize;
		[Export ("minFaceSize")]
		nfloat MinFaceSize { get; set; }

		// @property (getter = isTrackingEnabled, nonatomic) BOOL trackingEnabled;
		[Export ("trackingEnabled")]
		bool TrackingEnabled { [Bind ("isTrackingEnabled")] get; set; }
	}

	[Static]
	interface FaceLandmarkTypes {
		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeMouthBottom;
		[Field ("FIRFaceLandmarkTypeMouthBottom", "__Internal")]
		NSString MouthBottom { get; }

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeMouthRight;
		[Field ("FIRFaceLandmarkTypeMouthRight", "__Internal")]
		NSString MouthRight { get; }

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeMouthLeft;
		[Field ("FIRFaceLandmarkTypeMouthLeft", "__Internal")]
		NSString MouthLeft { get; }

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeLeftEar;
		[Field ("FIRFaceLandmarkTypeLeftEar", "__Internal")]
		NSString LeftEar { get; }

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeRightEar;
		[Field ("FIRFaceLandmarkTypeRightEar", "__Internal")]
		NSString RightEar { get; }

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeLeftEye;
		[Field ("FIRFaceLandmarkTypeLeftEye", "__Internal")]
		NSString LeftEye { get; }

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeRightEye;
		[Field ("FIRFaceLandmarkTypeRightEye", "__Internal")]
		NSString RightEye { get; }

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeLeftCheek;
		[Field ("FIRFaceLandmarkTypeLeftCheek", "__Internal")]
		NSString LeftCheek { get; }

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeRightCheek;
		[Field ("FIRFaceLandmarkTypeRightCheek", "__Internal")]
		NSString RightCheek { get; }

		// extern const FIRFaceLandmarkType _Nonnull FIRFaceLandmarkTypeNoseBase;
		[Field ("FIRFaceLandmarkTypeNoseBase", "__Internal")]
		NSString NoseBase { get; }
	}

	// @interface FIRVisionFaceLandmark : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionFaceLandmark")]
	interface VisionFaceLandmark {
		// @property (readonly, nonatomic) FIRFaceLandmarkType _Nonnull type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, nonatomic) FIRVisionPoint * _Nonnull position;
		[Export ("position")]
		VisionPoint Position { get; }
	}

	// @interface FIRVisionImage : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionImage")]
	interface VisionImage {
		// @property (nonatomic) FIRVisionImageMetadata * _Nullable metadata;
		[NullAllowed]
		[Export ("metadata", ArgumentSemantic.Assign)]
		VisionImageMetadata Metadata { get; set; }

		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithImage:")]
		IntPtr Constructor (UIImage image);

		// -(instancetype _Nonnull)initWithBuffer:(CMSampleBufferRef _Nonnull)sampleBuffer __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithBuffer:")]
		IntPtr Constructor (CMSampleBuffer sampleBuffer);
	}

	// @interface FIRVisionImageMetadata : NSObject
	[BaseType (typeof (NSObject), Name = "FIRVisionImageMetadata")]
	interface VisionImageMetadata {
		// @property (nonatomic) FIRVisionDetectorImageOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		VisionDetectorImageOrientation Orientation { get; set; }
	}

	// @interface FIRVisionLabel : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionLabel")]
	interface VisionLabel {
		// @property (readonly, nonatomic) float confidence;
		[Export ("confidence")]
		float Confidence { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull entityID;
		[Export ("entityID")]
		string EntityId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull label;
		[Export ("label")]
		string Label { get; }
	}

	// typedef void (^FIRVisionLabelDetectionCallback)(NSArray<FIRVisionLabel *> * _Nullable, NSError * _Nullable);
	delegate void VisionLabelDetectionCallbackHandler ([NullAllowed] VisionLabel [] lables, [NullAllowed] NSError error);

	// @interface FIRVisionLabelDetector : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionLabelDetector")]
	interface VisionLabelDetector {
		// -(void)detectInImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionLabelDetectionCallback _Nonnull)completion;
		[Async]
		[Export ("detectInImage:completion:")]
		void Detect (VisionImage image, VisionLabelDetectionCallbackHandler completion);
	}

	// @interface FIRVisionLabelDetectorOptions : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionLabelDetectorOptions")]
	interface VisionLabelDetectorOptions {
		// @property (readonly, nonatomic) float confidenceThreshold;
		[Export ("confidenceThreshold")]
		float ConfidenceThreshold { get; }

		// -(instancetype _Nonnull)initWithConfidenceThreshold:(float)confidenceThreshold __attribute__((objc_designated_initializer));
		[Export ("initWithConfidenceThreshold:")]
		[DesignatedInitializer]
		IntPtr Constructor (float confidenceThreshold);
	}

	// @interface FIRVisionLatitudeLongitude : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionLatitudeLongitude")]
	interface VisionLatitudeLongitude {
		// @property (nonatomic) NSNumber * _Nullable latitude;
		[NullAllowed]
		[Export ("latitude", ArgumentSemantic.Assign)]
		NSNumber Latitude { get; set; }

		// @property (nonatomic) NSNumber * _Nullable longitude;
		[NullAllowed]
		[Export ("longitude", ArgumentSemantic.Assign)]
		NSNumber Longitude { get; set; }

		// -(instancetype _Nonnull)initWithLatitude:(NSNumber * _Nullable)latitude longitude:(NSNumber * _Nullable)longitude __attribute__((objc_designated_initializer));
		[Export ("initWithLatitude:longitude:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] NSNumber latitude, [NullAllowed] NSNumber longitude);
	}

	// @interface FIRVisionPoint : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionPoint")]
	interface VisionPoint {
		// @property (readonly, nonatomic) NSNumber * _Nonnull x;
		[Export ("x")]
		NSNumber X { get; }

		// @property (readonly, nonatomic) NSNumber * _Nonnull y;
		[Export ("y")]
		NSNumber Y { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable z;
		[NullAllowed]
		[Export ("z")]
		NSNumber Z { get; }
	}

	// @interface FIRVisionText : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionText")]
	interface VisionText {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextBlock *> * _Nonnull blocks;
		[Export ("blocks")]
		VisionTextBlock [] Blocks { get; }
	}

	// @interface FIRVisionTextBlock : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionTextBlock")]
	interface VisionTextBlock {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextLine *> * _Nonnull lines;
		[Export ("lines")]
		VisionTextLine [] Lines { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		VisionTextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nonnull cornerPoints;
		[Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed]
		[Export ("confidence")]
		NSNumber Confidence { get; }
	}

	// @interface FIRVisionTextElement : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionTextElement")]
	interface VisionTextElement {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		VisionTextRecognizedLanguage [] RecognizedLanguages { get; }
		
		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nonnull cornerPoints;
		[Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed]
		[Export ("confidence")]
		NSNumber Confidence { get; }
	}

	// @interface FIRVisionTextLine : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionTextLine")]
	interface VisionTextLine {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextElement *> * _Nonnull elements;
		[Export ("elements")]
		VisionTextElement [] Elements { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		VisionTextRecognizedLanguage [] RecognizedLanguages { get; }
		
		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nonnull cornerPoints;
		[Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed]
		[Export ("confidence")]
		NSNumber Confidence { get; }
	}

	// @interface FIRVisionTextRecognizedBreak : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionTextRecognizedBreak")]
	interface VisionTextRecognizedBreak {
		// @property (readonly, nonatomic) FIRVisionTextRecognizedBreakType type;
		[Export ("type")]
		VisionTextRecognizedBreakType Type { get; }

		// @property (readonly, nonatomic) BOOL isPrefix;
		[Export ("isPrefix")]
		bool IsPrefix { get; }
	}

	// @interface FIRVisionTextRecognizedLanguage : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionTextRecognizedLanguage")]
	interface VisionTextRecognizedLanguage {
		// @property (readonly, nonatomic) NSString * _Nullable languageCode;
		[NullAllowed]
		[Export ("languageCode")]
		string LanguageCode { get; }
	}

	// typedef void (^FIRVisionTextRecognitionCallback)(FIRVisionText * _Nullable, NSError * _Nullable);
	delegate void VisionTextRecognitionCallbackHandler ([NullAllowed] VisionText text, [NullAllowed] NSError error);

	// @interface FIRVisionTextRecognizer : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionTextRecognizer")]
	interface VisionTextRecognizer {
		// @property (readonly, nonatomic) FIRVisionTextRecognizerType type;
		[Export ("type")]
		VisionTextRecognizerType Type { get; }

		// -(void)processImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionTextRecognitionCallback _Nonnull)completion;
		[Async]
		[Export ("processImage:completion:")]
		void ProcessImage (VisionImage image, VisionTextRecognitionCallbackHandler completion);
	}
}

namespace Google.MobileVision {
	// @interface GMVDetector : NSObject
	[BaseType (typeof (NSObject), Name = "GMVDetector")]
	interface Detector {
		// +(GMVDetector *)detectorOfType:(NSString *)type options:(NSDictionary *)options;
		[Static]
		[return: NullAllowed]
		[Export ("detectorOfType:options:")]
		Detector Create (string type, [NullAllowed] NSDictionary options);

		[Static]
		[return: NullAllowed]
		[Wrap ("Create (type, options == null ? null : NSDictionary.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (options.Values), System.Linq.Enumerable.ToArray (options.Keys), options.Keys.Count))")]
		Detector Create (string type, [NullAllowed] Dictionary<object, object> options);

		// -(NSArray<__kindof GMVFeature *> *)featuresInImage:(UIImage *)image options:(NSDictionary *)options;
		[return: NullAllowed]
		[Export ("featuresInImage:options:")]
		Feature [] GetFeatures (UIImage image, [NullAllowed] NSDictionary nsOptions);

		[return: NullAllowed]
		[Wrap ("GetFeatures (image, options == null ? null : NSDictionary.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (options.Values), System.Linq.Enumerable.ToArray (options.Keys), options.Keys.Count))")]
		Feature [] GetFeatures (UIImage image, [NullAllowed] Dictionary<object, object> options);

		// -(NSArray<__kindof GMVFeature *> *)featuresInBuffer:(CMSampleBufferRef)sampleBuffer options:(NSDictionary *)options;
		[return: NullAllowed]
		[Export ("featuresInBuffer:options:")]
		Feature [] GetFeatures (CMSampleBuffer sampleBuffer, [NullAllowed] NSDictionary options);

		[return: NullAllowed]
		[Wrap ("GetFeatures (sampleBuffer, options == null ? null : NSDictionary.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (options.Values), System.Linq.Enumerable.ToArray (options.Keys), options.Keys.Count))")]
		Feature [] GetFeatures (CMSampleBuffer sampleBuffer, [NullAllowed] Dictionary<object, object> options);
	}

	[Static]
	interface DetectorConstants {
		// extern NSString *const GMVDetectorTypeFace;
		[Field ("GMVDetectorTypeFace", "__Internal")]
		NSString FaceType { get; }

		// extern NSString *const GMVDetectorTypeBarcode;
		[Field ("GMVDetectorTypeBarcode", "__Internal")]
		NSString BarcodeType { get; }

		// extern NSString *const GMVDetectorTypeText;
		[Field ("GMVDetectorTypeText", "__Internal")]
		NSString TextType { get; }

		// extern NSString *const GMVDetectorTypeLabel;
		[Field ("GMVDetectorTypeLabel", "__Internal")]
		NSString LabelType { get; }

		// extern const float kGMVDetectorLabelScoreThresholdDefaultValue;
		[Field ("kGMVDetectorLabelScoreThresholdDefaultValue", "__Internal")]
		float LabelScoreThresholdDefaultValue { get; }

		// extern NSString *const GMVDetectorLabelScoreThreshold;
		[Field ("GMVDetectorLabelScoreThreshold", "__Internal")]
		NSString LabelScoreThreshold { get; }

		// extern NSString *const GMVDetectorBarcodeFormats;
		[Field ("GMVDetectorBarcodeFormats", "__Internal")]
		NSString BarcodeFormats { get; }

		// extern NSString *const GMVDetectorFaceMode;
		[Field ("GMVDetectorFaceMode", "__Internal")]
		NSString FaceMode { get; }

		// extern NSString *const GMVDetectorFaceTrackingEnabled;
		[Field ("GMVDetectorFaceTrackingEnabled", "__Internal")]
		NSString FaceTrackingEnabled { get; }

		// extern NSString *const GMVDetectorFaceMinSize;
		[Field ("GMVDetectorFaceMinSize", "__Internal")]
		NSString FaceMinSize { get; }

		// extern NSString *const GMVDetectorFaceClassificationType;
		[Field ("GMVDetectorFaceClassificationType", "__Internal")]
		NSString FaceClassificationType { get; }

		// extern NSString *const GMVDetectorFaceLandmarkType;
		[Field ("GMVDetectorFaceLandmarkType", "__Internal")]
		NSString FaceLandmarkType { get; }

		// extern NSString *const GMVDetectorImageOrientation;
		[Field ("GMVDetectorImageOrientation", "__Internal")]
		NSString ImageOrientation { get; }
	}

	[Static]
	interface FeatureTypes {
		// extern NSString *const GMVFeatureTypeFace;
		[Field ("GMVFeatureTypeFace", "__Internal")]
		NSString Face { get; }

		// extern NSString *const GMVFeatureTypeBarcode;
		[Field ("GMVFeatureTypeBarcode", "__Internal")]
		NSString Barcode { get; }

		// extern NSString *const GMVFeatureTypeTextBlock;
		[Field ("GMVFeatureTypeTextBlock", "__Internal")]
		NSString TextBlock { get; }

		// extern NSString *const GMVFeatureTypeTextLine;
		[Field ("GMVFeatureTypeTextLine", "__Internal")]
		NSString TextLine { get; }

		// extern NSString *const GMVFeatureTypeTextElement;
		[Field ("GMVFeatureTypeTextElement", "__Internal")]
		NSString TextElement { get; }

		// extern NSString *const GMVFeatureTypeLabel;
		[Field ("GMVFeatureTypeLabel", "__Internal")]
		NSString Label { get; }
	}

	// @interface GMVFeature : NSObject
	[BaseType (typeof (NSObject), Name = "GMVFeature")]
	interface Feature {
		// @property (readonly, assign, atomic) CGRect bounds;
		[Export ("bounds", ArgumentSemantic.Assign)]
		CGRect Bounds { get; }

		// @property (readonly, copy, atomic) NSString * type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, assign, atomic) BOOL hasTrackingID;
		[Export ("hasTrackingID")]
		bool HasTrackingId { get; }

		// @property (readonly, assign, atomic) NSUInteger trackingID;
		[Export ("trackingID")]
		nuint TrackingId { get; }
	}

	// @interface GMVBarcodeFeatureEmail : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeatureEmail")]
	interface BarcodeFeatureEmail {
		// @property (readonly, copy, atomic) NSString * address;
		[Export ("address")]
		string Address { get; }

		// @property (readonly, copy, atomic) NSString * body;
		[Export ("body")]
		string Body { get; }

		// @property (readonly, copy, atomic) NSString * subject;
		[Export ("subject")]
		string Subject { get; }

		// @property (readonly, assign, atomic) GMVBarcodeFeatureEmailType type;
		[Export ("type", ArgumentSemantic.Assign)]
		BarcodeFeatureEmailType Type { get; }
	}

	// @interface GMVBarcodeFeaturePhone : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeaturePhone")]
	interface BarcodeFeaturePhone {
		// @property (readonly, copy, atomic) NSString * number;
		[Export ("number")]
		string Number { get; }

		// @property (readonly, assign, atomic) GMVBarcodeFeaturePhoneType type;
		[Export ("type", ArgumentSemantic.Assign)]
		BarcodeFeaturePhoneType Type { get; }
	}

	// @interface GMVBarcodeFeatureSMS : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeatureSMS")]
	interface BarcodeFeatureSms {
		// @property (readonly, copy, atomic) NSString * message;
		[Export ("message")]
		string Message { get; }

		// @property (readonly, copy, atomic) NSString * phoneNumber;
		[Export ("phoneNumber")]
		string PhoneNumber { get; }
	}

	// @interface GMVBarcodeFeatureURLBookmark : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeatureURLBookmark")]
	interface BarcodeFeatureUrlBookmark {
		// @property (readonly, copy, atomic) NSString * title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly, copy, atomic) NSString * url;
		[Export ("url")]
		string Url { get; }
	}

	// @interface GMVBarcodeFeatureWiFi : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeatureWiFi")]
	interface BarcodeFeatureWiFi {
		// @property (readonly, copy, atomic) NSString * ssid;
		[Export ("ssid")]
		string Ssid { get; }

		// @property (readonly, copy, atomic) NSString * password;
		[Export ("password")]
		string Password { get; }

		// @property (readonly, assign, atomic) GMVBarcodeFeatureWiFiEncryptionType type;
		[Export ("type", ArgumentSemantic.Assign)]
		BarcodeFeatureWiFiEncryptionType Type { get; }
	}

	// @interface GMVBarcodeFeatureGeoPoint : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeatureGeoPoint")]
	interface BarcodeFeatureGeoPoint {
		// @property (readonly, assign, atomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; }

		// @property (readonly, assign, atomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; }
	}

	// @interface GMVBarcodeFeatureAddress : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeatureAddress")]
	interface BarcodeFeatureAddress {
		// @property (readonly, copy, atomic) NSArray<NSString *> * addressLines;
		[Export ("addressLines", ArgumentSemantic.Copy)]
		string [] AddressLines { get; }

		// @property (readonly, assign, atomic) GMVBarcodeFeatureAddressType type;
		[Export ("type", ArgumentSemantic.Assign)]
		BarcodeFeatureAddressType Type { get; }
	}

	// @interface GMVBarcodeFeaturePersonName : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeaturePersonName")]
	interface BarcodeFeaturePersonName {
		// @property (readonly, copy, atomic) NSString * formattedName;
		[Export ("formattedName")]
		string FormattedName { get; }

		// @property (readonly, copy, atomic) NSString * first;
		[Export ("first")]
		string First { get; }

		// @property (readonly, copy, atomic) NSString * last;
		[Export ("last")]
		string Last { get; }

		// @property (readonly, copy, atomic) NSString * middle;
		[Export ("middle")]
		string Middle { get; }

		// @property (readonly, copy, atomic) NSString * prefix;
		[Export ("prefix")]
		string Prefix { get; }

		// @property (readonly, copy, atomic) NSString * pronounciation;
		[Export ("pronounciation")]
		string Pronounciation { get; }

		// @property (readonly, copy, atomic) NSString * suffix;
		[Export ("suffix")]
		string Suffix { get; }
	}

	// @interface GMVBarcodeFeatureContactInfo : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeatureContactInfo")]
	interface BarcodeFeatureContactInfo {
		// @property (readonly, copy, atomic) NSArray<GMVBarcodeFeatureAddress *> * addresses;
		[Export ("addresses", ArgumentSemantic.Copy)]
		BarcodeFeatureAddress [] Addresses { get; }

		// @property (readonly, copy, atomic) NSArray<GMVBarcodeFeatureEmail *> * emails;
		[Export ("emails", ArgumentSemantic.Copy)]
		BarcodeFeatureEmail [] Emails { get; }

		// @property (readonly, atomic, strong) GMVBarcodeFeaturePersonName * name;
		[Export ("name", ArgumentSemantic.Strong)]
		BarcodeFeaturePersonName Name { get; }

		// @property (readonly, copy, atomic) NSArray<GMVBarcodeFeaturePhone *> * phones;
		[Export ("phones", ArgumentSemantic.Copy)]
		BarcodeFeaturePhone [] Phones { get; }

		// @property (readonly, copy, atomic) NSArray<NSString *> * urls;
		[Export ("urls", ArgumentSemantic.Copy)]
		string [] Urls { get; }

		// @property (readonly, copy, atomic) NSString * jobTitle;
		[Export ("jobTitle")]
		string JobTitle { get; }

		// @property (readonly, copy, atomic) NSString * organization;
		[Export ("organization")]
		string Organization { get; }
	}

	// @interface GMVBarcodeFeatureCalendarEvent : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeatureCalendarEvent")]
	interface BarcodeFeatureCalendarEvent {
		// @property (readonly, copy, atomic) NSString * eventDescription;
		[Export ("eventDescription")]
		string EventDescription { get; }

		// @property (readonly, copy, atomic) NSString * location;
		[Export ("location")]
		string Location { get; }

		// @property (readonly, copy, atomic) NSString * organizer;
		[Export ("organizer")]
		string Organizer { get; }

		// @property (readonly, copy, atomic) NSString * status;
		[Export ("status")]
		string Status { get; }

		// @property (readonly, copy, atomic) NSString * summary;
		[Export ("summary")]
		string Summary { get; }

		// @property (readonly, atomic, strong) NSDate * start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSDate Start { get; }

		// @property (readonly, atomic, strong) NSDate * end;
		[Export ("end", ArgumentSemantic.Strong)]
		NSDate End { get; }
	}

	// @interface GMVBarcodeFeatureDriverLicense : NSObject
	[BaseType (typeof (NSObject), Name = "GMVBarcodeFeatureDriverLicense")]
	interface BarcodeFeatureDriverLicense {
		// @property (readonly, copy, atomic) NSString * firstName;
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, copy, atomic) NSString * middleName;
		[Export ("middleName")]
		string MiddleName { get; }

		// @property (readonly, copy, atomic) NSString * lastName;
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, copy, atomic) NSString * gender;
		[Export ("gender")]
		string Gender { get; }

		// @property (readonly, copy, atomic) NSString * addressCity;
		[Export ("addressCity")]
		string AddressCity { get; }

		// @property (readonly, copy, atomic) NSString * addressState;
		[Export ("addressState")]
		string AddressState { get; }

		// @property (readonly, copy, atomic) NSString * addressStreet;
		[Export ("addressStreet")]
		string AddressStreet { get; }

		// @property (readonly, copy, atomic) NSString * addressZip;
		[Export ("addressZip")]
		string AddressZip { get; }

		// @property (readonly, copy, atomic) NSString * birthDate;
		[Export ("birthDate")]
		string BirthDate { get; }

		// @property (readonly, copy, atomic) NSString * documentType;
		[Export ("documentType")]
		string DocumentType { get; }

		// @property (readonly, copy, atomic) NSString * licenseNumber;
		[Export ("licenseNumber")]
		string LicenseNumber { get; }

		// @property (readonly, copy, atomic) NSString * expiryDate;
		[Export ("expiryDate")]
		string ExpiryDate { get; }

		// @property (readonly, copy, atomic) NSString * issuingDate;
		[Export ("issuingDate")]
		string IssuingDate { get; }

		// @property (readonly, copy, atomic) NSString * issuingCountry;
		[Export ("issuingCountry")]
		string IssuingCountry { get; }
	}

	// @interface GMVBarcodeFeature : GMVFeature
	[BaseType (typeof (Feature), Name = "GMVBarcodeFeature")]
	interface BarcodeFeature {
		// @property (readonly, copy, atomic) NSString * rawValue;
		[Export ("rawValue")]
		string RawValue { get; }

		// @property (readonly, copy, atomic) NSString * displayValue;
		[Export ("displayValue")]
		string DisplayValue { get; }

		// @property (readonly, assign, atomic) GMVDetectorBarcodeFormat format;
		[Export ("format", ArgumentSemantic.Assign)]
		DetectorBarcodeFormat Format { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * cornerPoints;
		[BindAs (typeof (CGPoint []))]
		[Export ("cornerPoints", ArgumentSemantic.Copy)]
		NSValue [] CornerPoints { get; }

		// @property (readonly, assign, atomic) GMVDetectorBarcodeValueFormat valueFormat;
		[Export ("valueFormat", ArgumentSemantic.Assign)]
		DetectorBarcodeValueFormat ValueFormat { get; }

		// @property (readonly, atomic, strong) GMVBarcodeFeatureEmail * email;
		[Export ("email", ArgumentSemantic.Strong)]
		BarcodeFeatureEmail Email { get; }

		// @property (readonly, atomic, strong) GMVBarcodeFeaturePhone * phone;
		[Export ("phone", ArgumentSemantic.Strong)]
		BarcodeFeaturePhone Phone { get; }

		// @property (readonly, atomic, strong) GMVBarcodeFeatureSMS * sms;
		[Export ("sms", ArgumentSemantic.Strong)]
		BarcodeFeatureSms Sms { get; }

		// @property (readonly, atomic, strong) GMVBarcodeFeatureURLBookmark * url;
		[Export ("url", ArgumentSemantic.Strong)]
		BarcodeFeatureUrlBookmark Url { get; }

		// @property (readonly, atomic, strong) GMVBarcodeFeatureWiFi * wifi;
		[Export ("wifi", ArgumentSemantic.Strong)]
		BarcodeFeatureWiFi Wifi { get; }

		// @property (readonly, atomic, strong) GMVBarcodeFeatureGeoPoint * geoPoint;
		[Export ("geoPoint", ArgumentSemantic.Strong)]
		BarcodeFeatureGeoPoint GeoPoint { get; }

		// @property (readonly, atomic, strong) GMVBarcodeFeatureContactInfo * contactInfo;
		[Export ("contactInfo", ArgumentSemantic.Strong)]
		BarcodeFeatureContactInfo ContactInfo { get; }

		// @property (readonly, atomic, strong) GMVBarcodeFeatureCalendarEvent * calendarEvent;
		[Export ("calendarEvent", ArgumentSemantic.Strong)]
		BarcodeFeatureCalendarEvent CalendarEvent { get; }

		// @property (readonly, atomic, strong) GMVBarcodeFeatureDriverLicense * driverLicense;
		[Export ("driverLicense", ArgumentSemantic.Strong)]
		BarcodeFeatureDriverLicense DriverLicense { get; }
	}

	// @interface GMVTextElementFeature : GMVFeature
	[BaseType (typeof (Feature), Name = "GMVTextElementFeature")]
	interface TextElementFeature {
		// @property (readonly, copy, atomic) NSString * value;
		[Export ("value")]
		string Value { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * cornerPoints;
		[BindAs (typeof (CGPoint []))]
		[Export ("cornerPoints", ArgumentSemantic.Copy)]
		NSValue [] CornerPoints { get; }
	}

	// @interface GMVTextLineFeature : GMVFeature
	[BaseType (typeof (Feature), Name = "GMVTextLineFeature")]
	interface TextLineFeature {
		// @property (readonly, copy, atomic) NSString * value;
		[Export ("value")]
		string Value { get; }

		// @property (readonly, copy, atomic) NSString * language;
		[Export ("language")]
		string Language { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * cornerPoints;
		[BindAs (typeof (CGPoint []))]
		[Export ("cornerPoints", ArgumentSemantic.Copy)]
		NSValue [] CornerPoints { get; }

		// @property (readonly, copy, atomic) NSArray<GMVTextElementFeature *> * elements;
		[Export ("elements", ArgumentSemantic.Copy)]
		TextElementFeature [] Elements { get; }
	}

	// @interface GMVTextBlockFeature : GMVFeature
	[BaseType (typeof (Feature), Name = "GMVTextBlockFeature")]
	interface TextBlockFeature {
		// @property (readonly, copy, atomic) NSString * value;
		[Export ("value")]
		string Value { get; }

		// @property (readonly, copy, atomic) NSString * language;
		[Export ("language")]
		string Language { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * cornerPoints;
		[BindAs (typeof (CGPoint []))]
		[Export ("cornerPoints", ArgumentSemantic.Copy)]
		NSValue [] CornerPoints { get; }

		// @property (readonly, copy, atomic) NSArray<GMVTextLineFeature *> * lines;
		[Export ("lines", ArgumentSemantic.Copy)]
		TextLineFeature [] Lines { get; }
	}

	// @interface GMVFaceContour : NSObject
	[BaseType (typeof (NSObject), Name = "GMVFaceContour")]
	interface FacialContour {
		// @property (readonly, copy, atomic) NSArray<NSValue *> * allPoints;
		[BindAs (typeof (CGPoint []))]
		[Export ("allPoints", ArgumentSemantic.Copy)]
		NSValue [] AllPoints { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * faceContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("faceContour", ArgumentSemantic.Copy)]
		NSValue [] FaceContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * topLeftEyebrowContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("topLeftEyebrowContour", ArgumentSemantic.Copy)]
		NSValue [] TopLeftEyebrowContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * bottomLeftEyebrowContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("bottomLeftEyebrowContour", ArgumentSemantic.Copy)]
		NSValue [] BottomLeftEyebrowContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * topRightEyebrowContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("topRightEyebrowContour", ArgumentSemantic.Copy)]
		NSValue [] TopRightEyebrowContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * bottomRightEyebrowContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("bottomRightEyebrowContour", ArgumentSemantic.Copy)]
		NSValue [] BottomRightEyebrowContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * leftEyeContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("leftEyeContour", ArgumentSemantic.Copy)]
		NSValue [] LeftEyeContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * rightEyeContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("rightEyeContour", ArgumentSemantic.Copy)]
		NSValue [] RightEyeContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * topUpperLipContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("topUpperLipContour", ArgumentSemantic.Copy)]
		NSValue [] TopUpperLipContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * bottomUpperLipContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("bottomUpperLipContour", ArgumentSemantic.Copy)]
		NSValue [] BottomUpperLipContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * topLowerLipContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("topLowerLipContour", ArgumentSemantic.Copy)]
		NSValue [] TopLowerLipContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * bottomLowerLipContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("bottomLowerLipContour", ArgumentSemantic.Copy)]
		NSValue [] BottomLowerLipContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * noseBridgeContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("noseBridgeContour", ArgumentSemantic.Copy)]
		NSValue [] NoseBridgeContour { get; }

		// @property (readonly, copy, atomic) NSArray<NSValue *> * bottomNoseContour;
		[BindAs (typeof (CGPoint []))]
		[Export ("bottomNoseContour", ArgumentSemantic.Copy)]
		NSValue [] BottomNoseContour { get; }
	}

	// @interface GMVFaceFeature : GMVFeature
	[BaseType (typeof (Feature), Name = "GMVFaceFeature")]
	interface FaceFeature {
		// @property (readonly, assign, atomic) BOOL hasHeadEulerAngleY;
		[Export ("hasHeadEulerAngleY")]
		bool HasHeadEulerAngleY { get; }

		// @property (readonly, assign, atomic) CGFloat headEulerAngleY;
		[Export ("headEulerAngleY")]
		nfloat HeadEulerAngleY { get; }

		// @property (readonly, assign, atomic) BOOL hasHeadEulerAngleZ;
		[Export ("hasHeadEulerAngleZ")]
		bool HasHeadEulerAngleZ { get; }

		// @property (readonly, assign, atomic) CGFloat headEulerAngleZ;
		[Export ("headEulerAngleZ")]
		nfloat HeadEulerAngleZ { get; }

		// @property (atomic, assign, readonly) BOOL hasHeadEulerAngleX;
		[Export ("hasHeadEulerAngleX")]
		bool HasHeadEulerAngleX { get; }

		// @property (atomic, assign, readonly) CGFloat headEulerAngleX;
		[Export ("headEulerAngleX")]
		nfloat HeadEulerAngleX { get; }

		// @property (readonly, assign, atomic) BOOL hasMouthPosition;
		[Export ("hasMouthPosition")]
		bool HasMouthPosition { get; }

		// @property (readonly, assign, atomic) CGPoint mouthPosition;
		[Export ("mouthPosition", ArgumentSemantic.Assign)]
		CGPoint MouthPosition { get; }

		// @property (readonly, assign, atomic) BOOL hasBottomMouthPosition;
		[Export ("hasBottomMouthPosition")]
		bool HasBottomMouthPosition { get; }

		// @property (readonly, assign, atomic) CGPoint bottomMouthPosition;
		[Export ("bottomMouthPosition", ArgumentSemantic.Assign)]
		CGPoint BottomMouthPosition { get; }

		// @property (readonly, assign, atomic) BOOL hasRightMouthPosition;
		[Export ("hasRightMouthPosition")]
		bool HasRightMouthPosition { get; }

		// @property (readonly, assign, atomic) CGPoint rightMouthPosition;
		[Export ("rightMouthPosition", ArgumentSemantic.Assign)]
		CGPoint RightMouthPosition { get; }

		// @property (readonly, assign, atomic) BOOL hasLeftMouthPosition;
		[Export ("hasLeftMouthPosition")]
		bool HasLeftMouthPosition { get; }

		// @property (readonly, assign, atomic) CGPoint leftMouthPosition;
		[Export ("leftMouthPosition", ArgumentSemantic.Assign)]
		CGPoint LeftMouthPosition { get; }

		// @property (readonly, assign, atomic) BOOL hasLeftEarPosition;
		[Export ("hasLeftEarPosition")]
		bool HasLeftEarPosition { get; }

		// @property (readonly, assign, atomic) CGPoint leftEarPosition;
		[Export ("leftEarPosition", ArgumentSemantic.Assign)]
		CGPoint LeftEarPosition { get; }

		// @property (readonly, assign, atomic) BOOL hasRightEarPosition;
		[Export ("hasRightEarPosition")]
		bool HasRightEarPosition { get; }

		// @property (readonly, assign, atomic) CGPoint rightEarPosition;
		[Export ("rightEarPosition", ArgumentSemantic.Assign)]
		CGPoint RightEarPosition { get; }

		// @property (readonly, assign, atomic) BOOL hasLeftEyePosition;
		[Export ("hasLeftEyePosition")]
		bool HasLeftEyePosition { get; }

		// @property (readonly, assign, atomic) CGPoint leftEyePosition;
		[Export ("leftEyePosition", ArgumentSemantic.Assign)]
		CGPoint LeftEyePosition { get; }

		// @property (readonly, assign, atomic) BOOL hasRightEyePosition;
		[Export ("hasRightEyePosition")]
		bool HasRightEyePosition { get; }

		// @property (readonly, assign, atomic) CGPoint rightEyePosition;
		[Export ("rightEyePosition", ArgumentSemantic.Assign)]
		CGPoint RightEyePosition { get; }

		// @property (readonly, assign, atomic) BOOL hasLeftCheekPosition;
		[Export ("hasLeftCheekPosition")]
		bool HasLeftCheekPosition { get; }

		// @property (readonly, assign, atomic) CGPoint leftCheekPosition;
		[Export ("leftCheekPosition", ArgumentSemantic.Assign)]
		CGPoint LeftCheekPosition { get; }

		// @property (readonly, assign, atomic) BOOL hasRightCheekPosition;
		[Export ("hasRightCheekPosition")]
		bool HasRightCheekPosition { get; }

		// @property (readonly, assign, atomic) CGPoint rightCheekPosition;
		[Export ("rightCheekPosition", ArgumentSemantic.Assign)]
		CGPoint RightCheekPosition { get; }

		// @property (readonly, assign, atomic) BOOL hasNoseBasePosition;
		[Export ("hasNoseBasePosition")]
		bool HasNoseBasePosition { get; }

		// @property (readonly, assign, atomic) CGPoint noseBasePosition;
		[Export ("noseBasePosition", ArgumentSemantic.Assign)]
		CGPoint NoseBasePosition { get; }

		// @property (readonly, assign, atomic) BOOL hasSmilingProbability;
		[Export ("hasSmilingProbability")]
		bool HasSmilingProbability { get; }

		// @property (readonly, assign, atomic) CGFloat smilingProbability;
		[Export ("smilingProbability")]
		nfloat SmilingProbability { get; }

		// @property (readonly, assign, atomic) BOOL hasLeftEyeOpenProbability;
		[Export ("hasLeftEyeOpenProbability")]
		bool HasLeftEyeOpenProbability { get; }

		// @property (readonly, assign, atomic) CGFloat leftEyeOpenProbability;
		[Export ("leftEyeOpenProbability")]
		nfloat LeftEyeOpenProbability { get; }

		// @property (readonly, assign, atomic) BOOL hasRightEyeOpenProbability;
		[Export ("hasRightEyeOpenProbability")]
		bool HasRightEyeOpenProbability { get; }

		// @property (readonly, assign, atomic) CGFloat rightEyeOpenProbability;
		[Export ("rightEyeOpenProbability")]
		nfloat RightEyeOpenProbability { get; }

		// @property (atomic, copy, readonly) GMVFaceContour* contour;
		[Export ("contour", ArgumentSemantic.Copy)]
		FacialContour Contour { get; }
	}

	// @interface GMVLabelFeature : GMVFeature
	[BaseType (typeof (Feature), Name = "GMVLabelFeature")]
	interface LabelFeature {
		// @property (readonly, copy, atomic) NSString * MID;
		[Export ("MID")]
		string Mid { get; }

		// @property (readonly, copy, atomic) NSString * labelDescription;
		[Export ("labelDescription")]
		string LabelDescription { get; }

		// @property (readonly, assign, atomic) float score;
		[Export ("score")]
		float Score { get; }
	}

	// @interface GMVUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMVUtility")]
	interface Utility {
		// +(UIImage *)sampleBufferTo32RGBA:(CMSampleBufferRef)sampleBuffer;
		[Static]
		[Export ("sampleBufferTo32RGBA:")]
		UIImage ConvertSampleBufferTo32Rgba (CMSampleBuffer sampleBuffer);

		// +(NSData *)anySampleBufferFormatTo32RGBA:(CMSampleBufferRef)sampleBuffer;
		[Static]
		[Export ("anySampleBufferFormatTo32RGBA:")]
		NSData ConvertAnySampleBufferFormatTo32Rgba (CMSampleBuffer sampleBuffer);

		// +(GMVImageOrientation)imageOrientationFromOrientation:(UIDeviceOrientation)deviceOrientation withCaptureDevicePosition:(AVCaptureDevicePosition)position defaultDeviceOrientation:(UIDeviceOrientation)defaultOrientation;
		[Static]
		[Export ("imageOrientationFromOrientation:withCaptureDevicePosition:defaultDeviceOrientation:")]
		ImageOrientation GetImageOrientation (UIDeviceOrientation deviceOrientation, AVCaptureDevicePosition position, UIDeviceOrientation defaultOrientation);

		// +(UIImage *)imageFromData:(NSData *)data width:(size_t)width height:(size_t)height;
		[Static]
		[Export ("imageFromData:width:height:")]
		UIImage GetImage (NSData data, nuint width, nuint height);
	}
}
