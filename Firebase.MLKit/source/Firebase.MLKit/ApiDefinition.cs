using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreMedia;

namespace Firebase.MLKit.ModelInterpreter {
	// @interface FIRCloudModelSource : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRCloudModelSource")]
	interface CloudModelSource {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull modelName;
		[Export ("modelName")]
		string ModelName { get; }

		// @property (readonly, nonatomic) BOOL enableModelUpdates;
		[Export ("enableModelUpdates")]
		bool EnableModelUpdates { get; }

		// @property (readonly, nonatomic) FIRModelDownloadConditions * _Nonnull initialConditions;
		[Export ("initialConditions")]
		ModelDownloadConditions InitialConditions { get; }

		// @property (readonly, nonatomic) FIRModelDownloadConditions * _Nonnull updateConditions;
		[Export ("updateConditions")]
		ModelDownloadConditions UpdateConditions { get; }

		// -(instancetype _Nonnull)initWithModelName:(NSString * _Nonnull)modelName enableModelUpdates:(BOOL)enableModelUpdates initialConditions:(FIRModelDownloadConditions * _Nonnull)initialConditions updateConditions:(FIRModelDownloadConditions * _Nullable)updateConditions __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithModelName:enableModelUpdates:initialConditions:updateConditions:")]
		IntPtr Constructor (string modelName, bool enableModelUpdates, ModelDownloadConditions initialConditions, [NullAllowed] ModelDownloadConditions updateConditions);
	}

	// @interface FIRLocalModelSource : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRLocalModelSource")]
	interface LocalModelSource {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull modelName;
		[Export ("modelName")]
		string ModelName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull path;
		[Export ("path")]
		string Path { get; }

		// -(instancetype _Nonnull)initWithModelName:(NSString * _Nonnull)modelName path:(NSString * _Nonnull)path __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithModelName:path:")]
		IntPtr Constructor (string modelName, string path);
	}

	// @interface FIRModelDownloadConditions : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelDownloadConditions")]
	interface ModelDownloadConditions : INSCopying {
		// @property (readonly, nonatomic) BOOL isWiFiRequired;
		[Export ("isWiFiRequired")]
		bool IsWiFiRequired { get; }

		// @property (readonly, nonatomic) BOOL canDownloadInBackground;
		[Export ("canDownloadInBackground")]
		bool CanDownloadInBackground { get; }

		// -(instancetype _Nonnull)initWithIsWiFiRequired:(BOOL)isWiFiRequired canDownloadInBackground:(BOOL)canDownloadInBackground __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithIsWiFiRequired:canDownloadInBackground:")]
		IntPtr Constructor (bool isWiFiRequired, bool canDownloadInBackground);
	}

	// @interface FIRModelInputOutputOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRModelInputOutputOptions")]
	interface ModelInputOutputOptions {
		// -(BOOL)setInputFormatForIndex:(NSUInteger)index type:(FIRModelElementType)type dimensions:(NSArray<NSNumber *> * _Nonnull)dimensions error:(NSError * _Nullable * _Nullable)error;
		[Internal]
		[Export ("setInputFormatForIndex:type:dimensions:error:")]
		bool _SetInputFormat (nuint index, ModelElementType type, NSArray dimensions, [NullAllowed] out NSError error);

		// -(BOOL)setOutputFormatForIndex:(NSUInteger)index type:(FIRModelElementType)type dimensions:(NSArray<NSNumber *> * _Nonnull)dimensions error:(NSError * _Nullable * _Nullable)error;
		[Internal]
		[Export ("setOutputFormatForIndex:type:dimensions:error:")]
		bool _SetOutputFormat (nuint index, ModelElementType type, NSArray dimensions, [NullAllowed] out NSError error);
	}

	// @interface FIRModelInputs : NSObject
	[BaseType (typeof (NSObject), Name = "FIRModelInputs")]
	interface ModelInputs {
		// -(BOOL)addInput:(id _Nonnull)input error:(NSError * _Nullable * _Nullable)error;
		[Internal]
		[Export ("addInput:error:")]
		bool _AddInput (NSObject input, [NullAllowed] out NSError error);
	}

	// typedef void (^FIRModelInterpreterRunCallback)(FIRModelOutputs * _Nullable, NSError * _Nullable);
	delegate void ModelInterpreterRunCallbackHandler ([NullAllowed] ModelOutputs outputs, [NullAllowed] NSError error);

	// typedef void (^FIRModelInterpreterInputOutputOpIndexCallback)(NSNumber * _Nullable, NSError * _Nullable);
	delegate void ModelInterpreterInputOutputOpIndexCallbackHandler ([NullAllowed] NSNumber index, [NullAllowed] NSError error);

	// @interface FIRModelInterpreter : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelInterpreter")]
	interface ModelInterpreter {
		// @property (getter = isStatsCollectionEnabled, nonatomic) BOOL statsCollectionEnabled;
		[Export ("statsCollectionEnabled")]
		bool StatsCollectionEnabled { [Bind ("isStatsCollectionEnabled")] get; set; }

		// +(instancetype _Nonnull)modelInterpreterWithOptions:(FIRModelOptions * _Nonnull)options;
		[Static]
		[Export ("modelInterpreterWithOptions:")]
		ModelInterpreter Create (ModelOptions options);

		// -(void)runWithInputs:(FIRModelInputs * _Nonnull)inputs options:(FIRModelInputOutputOptions * _Nonnull)options completion:(FIRModelInterpreterRunCallback _Nonnull)completion;
		[Async]
		[Export ("runWithInputs:options:completion:")]
		void Run (ModelInputs inputs, ModelInputOutputOptions options, ModelInterpreterRunCallbackHandler completion);

		// -(void)inputIndexForOp:(NSString * _Nonnull)opName completion:(FIRModelInterpreterInputOutputOpIndexCallback _Nonnull)completion;
		[Async]
		[Export ("inputIndexForOp:completion:")]
		void InputIndex (string opName, ModelInterpreterInputOutputOpIndexCallbackHandler completion);

		// -(void)outputIndexForOp:(NSString * _Nonnull)opName completion:(FIRModelInterpreterInputOutputOpIndexCallback _Nonnull)completion;
		[Async]
		[Export ("outputIndexForOp:completion:")]
		void OutputIndex (string opName, ModelInterpreterInputOutputOpIndexCallbackHandler completion);
	}

	// @interface FIRModelManager : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelManager")]
	interface ModelManager {
		// +(instancetype _Nonnull)modelManager;
		[Static]
		[Export ("modelManager")]
		ModelManager SharedInstance { get; }

		// -(BOOL)registerCloudModelSource:(FIRCloudModelSource * _Nonnull)cloudModelSource;
		[Export ("registerCloudModelSource:")]
		bool Register (CloudModelSource cloudModelSource);

		// -(BOOL)registerLocalModelSource:(FIRLocalModelSource * _Nonnull)localModelSource;
		[Export ("registerLocalModelSource:")]
		bool Register (LocalModelSource localModelSource);

		// -(FIRCloudModelSource * _Nullable)cloudModelSourceForModelName:(NSString * _Nonnull)modelName;
		[return: NullAllowed]
		[Export ("cloudModelSourceForModelName:")]
		CloudModelSource GetCloudModelSource (string modelName);

		// -(FIRLocalModelSource * _Nullable)localModelSourceForModelName:(NSString * _Nonnull)modelName;
		[return: NullAllowed]
		[Export ("localModelSourceForModelName:")]
		LocalModelSource GetLocalModelSource (string modelName);
	}

	// @interface FIRModelOptions : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelOptions")]
	interface ModelOptions {
		// @property (readonly, copy, nonatomic) NSString * _Nullable cloudModelName;
		[NullAllowed, Export ("cloudModelName")]
		string CloudModelName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable localModelName;
		[NullAllowed, Export ("localModelName")]
		string LocalModelName { get; }

		// -(instancetype _Nonnull)initWithCloudModelName:(NSString * _Nullable)cloudModelName localModelName:(NSString * _Nullable)localModelName __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithCloudModelName:localModelName:")]
		IntPtr Constructor ([NullAllowed] string cloudModelName, [NullAllowed] string localModelName);
	}

	// @interface FIRModelOutputs : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelOutputs")]
	interface ModelOutputs {
		// -(id _Nullable)outputAtIndex:(NSUInteger)index error:(NSError * _Nullable * _Nullable)error;
		[return: NullAllowed]
		[Export ("outputAtIndex:error:")]
		NSObject GetOutput (nuint index, [NullAllowed] out NSError error);
	}
}

namespace Firebase.MLKit.Vision {
	// @interface FIRVision : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVision")]
	interface Vision {
		// @property (getter = isStatsCollectionEnabled, nonatomic) BOOL statsCollectionEnabled;
		[Export ("statsCollectionEnabled")]
		bool StatsCollectionEnabled { [Bind ("isStatsCollectionEnabled")] get; set; }

		// +(instancetype _Nonnull)vision;
		[Static]
		[Export ("vision")]
		Vision Create ();

		// +(instancetype _Nonnull)visionForApp:(FIRApp * _Nonnull)app;
		[Static]
		[Export ("visionForApp:")]
		Vision Create (Core.App app);

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

	// @interface FIRVisionBarcodeDriverLicense : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeDriverLicense")]
	interface VisionBarcodeDriverLicense {
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

	// @interface FIRVisionBarcodeEmail : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeEmail")]
	interface VisionBarcodeEmail {
		// @property (readonly, nonatomic) NSString * _Nullable address;
		[NullAllowed, Export ("address")]
		string Address { get; }

		// @property (readonly, nonatomic) NSString * _Nullable body;
		[NullAllowed, Export ("body")]
		string Body { get; }

		// @property (readonly, nonatomic) NSString * _Nullable subject;
		[NullAllowed, Export ("subject")]
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

		// @property (readonly, nonatomic) NSString * _Nullable pronounciation;
		[NullAllowed, Export ("pronounciation")]
		string Pronounciation { get; }

		// @property (readonly, nonatomic) NSString * _Nullable suffix;
		[NullAllowed, Export ("suffix")]
		string Suffix { get; }
	}

	// @interface FIRVisionBarcodePhone : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodePhone")]
	interface VisionBarcodePhone {
		// @property (readonly, nonatomic) NSString * _Nullable number;
		[NullAllowed, Export ("number")]
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
		[NullAllowed, Export ("message")]
		string Message { get; }

		// @property (readonly, nonatomic) NSString * _Nullable phoneNumber;
		[NullAllowed, Export ("phoneNumber")]
		string PhoneNumber { get; }
	}

	// @interface FIRVisionBarcodeURLBookmark : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeURLBookmark")]
	interface VisionBarcodeUrlBookmark {
		// @property (readonly, nonatomic) NSString * _Nullable title;
		[NullAllowed, Export ("title")]
		string Title { get; }

		// @property (readonly, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export ("url")]
		string Url { get; }
	}

	// @interface FIRVisionBarcodeWiFi : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcodeWiFi")]
	interface VisionBarcodeWiFi {
		// @property (readonly, nonatomic) NSString * _Nullable ssid;
		[NullAllowed, Export ("ssid")]
		string Ssid { get; }

		// @property (readonly, nonatomic) NSString * _Nullable password;
		[NullAllowed, Export ("password")]
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
		[NullAllowed, Export ("addresses")]
		VisionBarcodeAddress [] Addresses { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionBarcodeEmail *> * _Nullable emails;
		[NullAllowed, Export ("emails")]
		VisionBarcodeEmail [] Emails { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodePersonName * _Nullable name;
		[NullAllowed, Export ("name")]
		VisionBarcodePersonName Name { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionBarcodePhone *> * _Nullable phones;
		[NullAllowed, Export ("phones")]
		VisionBarcodePhone [] Phones { get; }

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

	// @interface FIRVisionBarcode : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionBarcode")]
	interface VisionBarcode {
		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSString * _Nullable rawValue;
		[NullAllowed, Export ("rawValue")]
		string RawValue { get; }

		// @property (readonly, nonatomic) NSString * _Nullable displayValue;
		[NullAllowed, Export ("displayValue")]
		string DisplayValue { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeFormat format;
		[Export ("format")]
		VisionBarcodeFormat Format { get; }

		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nullable cornerPoints;
		[NullAllowed, Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeValueType valueType;
		[Export ("valueType")]
		VisionBarcodeValueType ValueType { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeEmail * _Nullable email;
		[NullAllowed, Export ("email")]
		VisionBarcodeEmail Email { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodePhone * _Nullable phone;
		[NullAllowed, Export ("phone")]
		VisionBarcodePhone Phone { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeSMS * _Nullable sms;
		[NullAllowed, Export ("sms")]
		VisionBarcodeSms Sms { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeURLBookmark * _Nullable URL;
		[NullAllowed, Export ("URL")]
		VisionBarcodeUrlBookmark Url { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeWiFi * _Nullable wifi;
		[NullAllowed, Export ("wifi")]
		VisionBarcodeWiFi Wifi { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeGeoPoint * _Nullable geoPoint;
		[NullAllowed, Export ("geoPoint")]
		VisionBarcodeGeoPoint GeoPoint { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeContactInfo * _Nullable contactInfo;
		[NullAllowed, Export ("contactInfo")]
		VisionBarcodeContactInfo ContactInfo { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeCalendarEvent * _Nullable calendarEvent;
		[NullAllowed, Export ("calendarEvent")]
		VisionBarcodeCalendarEvent CalendarEvent { get; }

		// @property (readonly, nonatomic) FIRVisionBarcodeDriverLicense * _Nullable driverLicense;
		[NullAllowed, Export ("driverLicense")]
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
		[NullAllowed, Export ("APIKeyOverride")]
		string ApiKeyOverride { get; set; }
	}

	// @interface FIRVisionCloudDocumentTextRecognizerOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRVisionCloudDocumentTextRecognizerOptions")]
	interface VisionCloudDocumentTextRecognizerOptions {
		// @property (nonatomic) NSArray<NSString *> * _Nullable languageHints;
		[NullAllowed, Export ("languageHints", ArgumentSemantic.Assign)]
		string [] LanguageHints { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable APIKeyOverride;
		[NullAllowed, Export ("APIKeyOverride")]
		string ApiKeyOverride { get; set; }
	}

	// @interface FIRVisionCloudLabel : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionCloudLabel")]
	interface VisionCloudLabel {
		// @property (readonly, copy, nonatomic) NSString * _Nullable entityId;
		[NullAllowed, Export ("entityId")]
		string EntityId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable label;
		[NullAllowed, Export ("label")]
		string Label { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed, Export ("confidence")]
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
		[NullAllowed, Export ("entityId")]
		string EntityId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable landmark;
		[NullAllowed, Export ("landmark")]
		string Landmark { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed, Export ("confidence")]
		NSNumber Confidence { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionLatitudeLongitude *> * _Nullable locations;
		[NullAllowed, Export ("locations")]
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
		[NullAllowed, Export ("languageHints", ArgumentSemantic.Assign)]
		string [] LanguageHints { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable APIKeyOverride;
		[NullAllowed, Export ("APIKeyOverride")]
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
		[NullAllowed, Export ("recognizedBreak")]
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
		[NullAllowed, Export ("recognizedBreak")]
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
		[NullAllowed, Export ("recognizedBreak")]
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
		[NullAllowed, Export ("recognizedBreak")]
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

	// typedef void (^FIRVisionFaceDetectionCallback)(NSArray<FIRVisionFace *> * _Nullable, NSError * _Nullable);
	delegate void VisionFaceDetectionCallbackHandler ([NullAllowed] VisionFace [] face, [NullAllowed] NSError error);

	// @interface FIRVisionFaceDetector : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRVisionFaceDetector")]
	interface VisionFaceDetector {
		// -(void)detectInImage:(FIRVisionImage * _Nonnull)image completion:(FIRVisionFaceDetectionCallback _Nonnull)completion;
		[Export ("detectInImage:completion:")]
		void Detect (VisionImage image, VisionFaceDetectionCallbackHandler completion);
	}

	// @interface FIRVisionFaceDetectorOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRVisionFaceDetectorOptions")]
	interface VisionFaceDetectorOptions {
		// extern const CGFloat FIRVisionFaceDetectionMinSize;
		[Field ("FIRVisionFaceDetectionMinSize", "__Internal")]
		nfloat VisionFaceDetectionMinSize { get; }

		// @property (nonatomic) FIRVisionFaceDetectorClassification classificationType;
		[Export ("classificationType", ArgumentSemantic.Assign)]
		VisionFaceDetectorClassification ClassificationType { get; set; }

		// @property (nonatomic) FIRVisionFaceDetectorMode modeType;
		[Export ("modeType", ArgumentSemantic.Assign)]
		VisionFaceDetectorMode ModeType { get; set; }

		// @property (nonatomic) FIRVisionFaceDetectorLandmark landmarkType;
		[Export ("landmarkType", ArgumentSemantic.Assign)]
		VisionFaceDetectorLandmark LandmarkType { get; set; }

		// @property (nonatomic) CGFloat minFaceSize;
		[Export ("minFaceSize")]
		nfloat MinFaceSize { get; set; }

		// @property (nonatomic) BOOL isTrackingEnabled;
		[Export ("isTrackingEnabled")]
		bool IsTrackingEnabled { get; set; }
	}

	[Static]
	partial interface FaceLandmarkTypes {
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
		[NullAllowed, Export ("metadata", ArgumentSemantic.Assign)]
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
		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

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
		[NullAllowed, Export ("latitude", ArgumentSemantic.Assign)]
		NSNumber Latitude { get; set; }

		// @property (nonatomic) NSNumber * _Nullable longitude;
		[NullAllowed, Export ("longitude", ArgumentSemantic.Assign)]
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
		[NullAllowed, Export ("z")]
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

		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nonnull cornerPoints;
		[Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		VisionTextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed, Export ("confidence")]
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

		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nonnull cornerPoints;
		[Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		VisionTextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed, Export ("confidence")]
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

		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nonnull cornerPoints;
		[Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }

		// @property (readonly, nonatomic) NSArray<FIRVisionTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		VisionTextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable confidence;
		[NullAllowed, Export ("confidence")]
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
		[NullAllowed, Export ("languageCode")]
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
		[Export ("processImage:completion:")]
		void ProcessImage (VisionImage image, VisionTextRecognitionCallbackHandler completion);
	}
}
