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

		// -(FIRVisionImageLabeler * _Nonnull)onDeviceImageLabelerWithOptions:(FIRVisionOnDeviceImageLabelerOptions * _Nonnull)options __attribute__((swift_name("onDeviceImageLabeler(options:)")));
		[Export ("onDeviceImageLabelerWithOptions:")]
		VisionImageLabeler GetOnDeviceImageLabeler (VisionOnDeviceImageLabelerOptions options);

		// -(FIRVisionImageLabeler * _Nonnull)onDeviceImageLabeler;
		[Export ("onDeviceImageLabeler")]
		VisionImageLabeler GetOnDeviceImageLabeler ();

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

		// -(FIRVisionImageLabeler * _Nonnull)cloudImageLabelerWithOptions:(FIRVisionCloudImageLabelerOptions * _Nonnull)options __attribute__((swift_name("cloudImageLabeler(options:)")));
		[Export ("cloudImageLabelerWithOptions:")]
		VisionImageLabeler GetCloudImageLabeler (VisionCloudImageLabelerOptions options);

		// -(FIRVisionImageLabeler * _Nonnull)cloudImageLabeler;
		[Export ("cloudImageLabeler")]
		VisionImageLabeler GetCloudImageLabeler ();
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

		// @property (readonly, nonatomic) NSData * _Nullable rawData;
		[NullAllowed]
		[Export ("rawData")]
		NSData RawData { get; }

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

	// @interface FIRVisionCloudImageLabelerOptions : NSObject
	[BaseType (typeof(NSObject), Name = "FIRVisionCloudImageLabelerOptions")]
	interface VisionCloudImageLabelerOptions
	{
		// @property (nonatomic) float confidenceThreshold;
		[Export ("confidenceThreshold")]
		float ConfidenceThreshold { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable APIKeyOverride;
		[NullAllowed]
		[Export ("APIKeyOverride")]
		string ApiKeyOverride { get; set; }
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
		[BindAs (typeof (float?))]
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
	delegate void VisionCloudLandmarkDetectionCallbackHandler ([NullAllowed] VisionCloudLandmark [] landmarks, [NullAllowed] NSError error);

	// @interface FIRVisionCloudLandmarkDetector : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionCloudLandmarkDetector")]
	interface VisionCloudLandmarkDetector {
		// -(void)detectInImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionCloudLandmarkDetectionCompletion _Nonnull)completion;
		[Async]
		[Export ("detectInImage:completion:")]
		void Detect (VisionImage image, VisionCloudLandmarkDetectionCallbackHandler completion);
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
		[BindAs (typeof (float?))]
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
		[BindAs (typeof (float))]
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
		[BindAs (typeof (float))]
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
		[BindAs (typeof (float))]
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
		VisionFaceLandmark GetLandmark ([BindAs (typeof (FaceLandmarkType))] NSString type);

		// -(nullable FIRVisionFaceContour *)contourOfType:(FIRFaceContourType) type;
		[return: NullAllowed]
		[Export ("contourOfType:")]
		VisionFaceContour GetContour ([BindAs (typeof (FaceContourType))] NSString type);
	}

	// @interface FIRVisionFaceContour : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionFaceContour")]
	interface VisionFaceContour {
		// @property (readonly, nonatomic) FIRFaceContourType _Nonnull type;
		[BindAs (typeof (FaceLandmarkType))]
		[Export ("type")]
		NSString Type { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionPoint *> * _Nonnull points;
		[Export ("points")]
		VisionPoint [] Points { get; }
	}

	// typedef void (^FIRVisionFaceDetectionCallback)(NSArray<FIRVisionFace *> * _Nullable, NSError * _Nullable);
	delegate void VisionFaceDetectionCallbackHandler ([NullAllowed] VisionFace [] faces, [NullAllowed] NSError error);

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

	// @interface FIRVisionFaceLandmark : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionFaceLandmark")]
	interface VisionFaceLandmark {
		// @property (readonly, nonatomic) FIRFaceLandmarkType _Nonnull type;
		[BindAs (typeof (FaceLandmarkType))]
		[Export ("type")]
		NSString Type { get; }

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

	// @interface FIRVisionImageLabel : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRVisionImageLabel")]
	interface VisionImageLabel
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed]
		[BindAs (typeof (float))]
		[Export ("confidence")]
		NSNumber Confidence { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable entityID;
		[NullAllowed]
		[Export ("entityID")]
		string EntityId { get; }
	}

	// typedef void (^FIRVisionImageLabelerCallback)(NSArray<FIRVisionImageLabel *> * _Nullable, NSError * _Nullable);
	delegate void VisionImageLabelerCallbackHandler ([NullAllowed] VisionImageLabel [] labels, [NullAllowed] NSError error);

	// @interface FIRVisionImageLabeler : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionImageLabeler")]
	interface VisionImageLabeler
	{
		// @property (readonly, nonatomic) FIRVisionImageLabelerType type;
		[Export ("type")]
		VisionImageLabelerType Type { get; }

		// -(void)processImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionImageLabelerCallback _Nonnull)completion __attribute__((swift_name("process(_:completion:)")));
		[Async]
		[Export ("processImage:completion:")]
		void ProcessImage (VisionImage image, VisionImageLabelerCallbackHandler completion);
	}

	// @interface FIRVisionImageMetadata : NSObject
	[BaseType (typeof (NSObject), Name = "FIRVisionImageMetadata")]
	interface VisionImageMetadata {
		// @property (nonatomic) FIRVisionDetectorImageOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		VisionDetectorImageOrientation Orientation { get; set; }
	}

	// @interface FIRVisionLatitudeLongitude : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionLatitudeLongitude")]
	interface VisionLatitudeLongitude {
		// @property (nonatomic) NSNumber * _Nullable latitude;
		[BindAs (typeof (double?))]
		[NullAllowed]
		[Export ("latitude", ArgumentSemantic.Assign)]
		NSNumber Latitude { get; set; }

		// @property (nonatomic) NSNumber * _Nullable longitude;
		[BindAs (typeof (double?))]
		[NullAllowed]
		[Export ("longitude", ArgumentSemantic.Assign)]
		NSNumber Longitude { get; set; }

		// -(instancetype _Nonnull)initWithLatitude:(NSNumber * _Nullable)latitude longitude:(NSNumber * _Nullable)longitude __attribute__((objc_designated_initializer));
		[Internal]
		[DesignatedInitializer]
		[Export ("initWithLatitude:longitude:")]
		IntPtr _InitWithLatitudeAndLongitude ([NullAllowed] NSNumber latitude, [NullAllowed] NSNumber longitude);
	}

	// @interface FIRVisionOnDeviceImageLabelerOptions : NSObject
	[BaseType (typeof(NSObject), Name = "FIRVisionOnDeviceImageLabelerOptions")]
	interface VisionOnDeviceImageLabelerOptions
	{
		// @property (nonatomic) float confidenceThreshold;
		[Export ("confidenceThreshold")]
		float ConfidenceThreshold { get; set; }
	}

	// @interface FIRVisionPoint : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionPoint")]
	interface VisionPoint {
		// @property (readonly, nonatomic) NSNumber * _Nonnull x;
		[BindAs (typeof (float))]
		[Export ("x")]
		NSNumber X { get; }

		// @property (readonly, nonatomic) NSNumber * _Nonnull y;
		[BindAs (typeof (float))]
		[Export ("y")]
		NSNumber Y { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable z;
		[BindAs (typeof (float?))]
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
		[BindAs (typeof (float?))]
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
		[BindAs (typeof (float?))]
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
		[BindAs (typeof (float?))]
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

namespace Firebase.MLKit.Vision.AutoML {
	// @interface FIRAutoMLLocalModel : FIRLocalModel
	[DisableDefaultCtor]
	[BaseType (typeof(Common.LocalModel), Name = "FIRAutoMLLocalModel")]
	interface AutoMLLocalModel
	{
		// -(instancetype _Nonnull)initWithManifestPath:(NSString * _Nonnull)manifestPath __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithManifestPath:")]
		IntPtr Constructor (string manifestPath);
	}

	// @interface FIRAutoMLRemoteModel : FIRRemoteModel
	[DisableDefaultCtor]
	[BaseType (typeof(Common.RemoteModel), Name = "FIRAutoMLRemoteModel")]
	interface AutoMLRemoteModel
	{
		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithName:")]
		IntPtr Constructor (string name);
	}

	// @interface AutoML (FIRVision)
	[Category]
	[BaseType (typeof(VisionApi))]
	interface Vision_AutoML
	{
		// -(FIRVisionImageLabeler * _Nonnull)onDeviceAutoMLImageLabelerWithOptions:(FIRVisionOnDeviceAutoMLImageLabelerOptions * _Nonnull)options __attribute__((swift_name("onDeviceAutoMLImageLabeler(options:)")));
		[Export ("onDeviceAutoMLImageLabelerWithOptions:")]
		VisionImageLabeler GetOnDeviceAutoMLImageLabeler (VisionOnDeviceAutoMLImageLabelerOptions options);
	}

	// @interface FIRVisionOnDeviceAutoMLImageLabelerOptions : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRVisionOnDeviceAutoMLImageLabelerOptions")]
	interface VisionOnDeviceAutoMLImageLabelerOptions
	{
		// @property (nonatomic) float confidenceThreshold;
		[Export ("confidenceThreshold")]
		float ConfidenceThreshold { get; set; }

		// -(instancetype _Nonnull)initWithLocalModel:(FIRAutoMLLocalModel * _Nonnull)localModel;
		[Export ("initWithLocalModel:")]
		IntPtr Constructor (AutoMLLocalModel localModel);

		// -(instancetype _Nonnull)initWithRemoteModel:(FIRAutoMLRemoteModel * _Nonnull)remoteModel;
		[Export ("initWithRemoteModel:")]
		IntPtr Constructor (AutoMLRemoteModel remoteModel);
	}
}

namespace Firebase.MLKit.Vision.ObjectDetection {
	// @interface ObjectDetection (FIRVision)
	[Category]
	[BaseType (typeof(VisionApi))]
	interface VisionApi_ObjectDetection
	{
		// -(FIRVisionObjectDetector * _Nonnull)objectDetectorWithOptions:(FIRVisionObjectDetectorOptions * _Nonnull)options __attribute__((swift_name("objectDetector(options:)")));
		[Export ("objectDetectorWithOptions:")]
		VisionObjectDetector GetObjectDetector (VisionObjectDetectorOptions options);

		// -(FIRVisionObjectDetector * _Nonnull)objectDetector;
		[Export ("objectDetector")]
		VisionObjectDetector GetObjectDetector ();
	}

	// @interface FIRVisionObject : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRVisionObject")]
	interface VisionObject
	{
		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) FIRVisionObjectCategory classificationCategory;
		[Export ("classificationCategory")]
		VisionObjectCategory ClassificationCategory { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable trackingID;
		[NullAllowed]
		[BindAs (typeof (ulong?))]
		[Export ("trackingID")]
		NSNumber TrackingId { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed]
		[BindAs (typeof(float?))]
		[Export ("confidence")]
		NSNumber Confidence { get; }
	}

	// typedef void (^FIRVisionObjectDetectionCallback)(NSArray<FIRVisionObject *> * _Nullable, NSError * _Nullable);
	delegate void VisionObjectDetectionCallbackHandler ([NullAllowed] VisionObject [] objects, [NullAllowed] NSError error);

	// @interface FIRVisionObjectDetector : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRVisionObjectDetector")]
	interface VisionObjectDetector
	{
		// -(void)processImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionObjectDetectionCallback _Nonnull)completion __attribute__((swift_name("process(_:completion:)")));
		[Async]
		[Export ("processImage:completion:")]
		void ProcessImage (VisionImage image, VisionObjectDetectionCallbackHandler completion);

		// -(NSArray<FIRVisionObject *> * _Nullable)resultsInImage:(FIRVisionImage * _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[return: NullAllowed]
		[Export ("resultsInImage:error:")]
		VisionObject [] GetResultsInImage (VisionImage image, [NullAllowed] out NSError error);
	}

	// @interface FIRVisionObjectDetectorOptions : NSObject
	[BaseType (typeof(NSObject), Name = "FIRVisionObjectDetectorOptions")]
	interface VisionObjectDetectorOptions
	{
		// @property (nonatomic) BOOL shouldEnableClassification;
		[Export ("shouldEnableClassification")]
		bool ShouldEnableClassification { get; set; }

		// @property (nonatomic) BOOL shouldEnableMultipleObjects;
		[Export ("shouldEnableMultipleObjects")]
		bool ShouldEnableMultipleObjects { get; set; }

		// @property (nonatomic) FIRVisionObjectDetectorMode detectorMode;
		[Export ("detectorMode", ArgumentSemantic.Assign)]
		VisionObjectDetectorMode DetectorMode { get; set; }
	}
}
