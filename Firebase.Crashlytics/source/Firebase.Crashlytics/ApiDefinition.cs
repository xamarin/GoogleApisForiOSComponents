using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.Crashlytics {
	// @interface Answers : NSObject
	[BaseType (typeof (NSObject))]
	interface Answers {
		// +(void)logSignUpWithMethod:(NSString * _Nullable)signUpMethodOrNil success:(NSNumber * _Nullable)signUpSucceededOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logSignUpWithMethod:success:customAttributes:")]
		void LogSignUp ([NullAllowed] string signUpMethod, [NullAllowed] NSNumber signUpSucceeded, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logLoginWithMethod:(NSString * _Nullable)loginMethodOrNil success:(NSNumber * _Nullable)loginSucceededOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logLoginWithMethod:success:customAttributes:")]
		void LogLogin ([NullAllowed] string loginMethod, [NullAllowed] NSNumber loginSucceeded, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logShareWithMethod:(NSString * _Nullable)shareMethodOrNil contentName:(NSString * _Nullable)contentNameOrNil contentType:(NSString * _Nullable)contentTypeOrNil contentId:(NSString * _Nullable)contentIdOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logShareWithMethod:contentName:contentType:contentId:customAttributes:")]
		void LogShare ([NullAllowed] string shareMethod, [NullAllowed] string contentName, [NullAllowed] string contentType, [NullAllowed] string contentId, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logInviteWithMethod:(NSString * _Nullable)inviteMethodOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logInviteWithMethod:customAttributes:")]
		void LogInvite ([NullAllowed] string inviteMethod, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logPurchaseWithPrice:(NSDecimalNumber * _Nullable)itemPriceOrNil currency:(NSString * _Nullable)currencyOrNil success:(NSNumber * _Nullable)purchaseSucceededOrNil itemName:(NSString * _Nullable)itemNameOrNil itemType:(NSString * _Nullable)itemTypeOrNil itemId:(NSString * _Nullable)itemIdOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logPurchaseWithPrice:currency:success:itemName:itemType:itemId:customAttributes:")]
		void LogPurchase ([NullAllowed] NSDecimalNumber itemPrice, [NullAllowed] string currency, [NullAllowed] NSNumber purchaseSucceeded, [NullAllowed] string itemName, [NullAllowed] string itemType, [NullAllowed] string itemId, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logLevelStart:(NSString * _Nullable)levelNameOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logLevelStart:customAttributes:")]
		void LogLevelStart ([NullAllowed] string levelName, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logLevelEnd:(NSString * _Nullable)levelNameOrNil score:(NSNumber * _Nullable)scoreOrNil success:(NSNumber * _Nullable)levelCompletedSuccesfullyOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logLevelEnd:score:success:customAttributes:")]
		void LogLevelEnd ([NullAllowed] string levelName, [NullAllowed] NSNumber score, [NullAllowed] NSNumber levelCompletedSuccesfully, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logAddToCartWithPrice:(NSDecimalNumber * _Nullable)itemPriceOrNil currency:(NSString * _Nullable)currencyOrNil itemName:(NSString * _Nullable)itemNameOrNil itemType:(NSString * _Nullable)itemTypeOrNil itemId:(NSString * _Nullable)itemIdOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logAddToCartWithPrice:currency:itemName:itemType:itemId:customAttributes:")]
		void LogAddToCart ([NullAllowed] NSDecimalNumber itemPrice, [NullAllowed] string currency, [NullAllowed] string itemName, [NullAllowed] string itemType, [NullAllowed] string itemId, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logStartCheckoutWithPrice:(NSDecimalNumber * _Nullable)totalPriceOrNil currency:(NSString * _Nullable)currencyOrNil itemCount:(NSNumber * _Nullable)itemCountOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logStartCheckoutWithPrice:currency:itemCount:customAttributes:")]
		void LogStartCheckout ([NullAllowed] NSDecimalNumber totalPrice, [NullAllowed] string currency, [NullAllowed] NSNumber itemCount, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logRating:(NSNumber * _Nullable)ratingOrNil contentName:(NSString * _Nullable)contentNameOrNil contentType:(NSString * _Nullable)contentTypeOrNil contentId:(NSString * _Nullable)contentIdOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logRating:contentName:contentType:contentId:customAttributes:")]
		void LogRating ([NullAllowed] NSNumber rating, [NullAllowed] string contentName, [NullAllowed] string contentType, [NullAllowed] string contentId, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logContentViewWithName:(NSString * _Nullable)contentNameOrNil contentType:(NSString * _Nullable)contentTypeOrNil contentId:(NSString * _Nullable)contentIdOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logContentViewWithName:contentType:contentId:customAttributes:")]
		void LogContentView ([NullAllowed] string contentName, [NullAllowed] string contentType, [NullAllowed] string contentId, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logSearchWithQuery:(NSString * _Nullable)queryOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logSearchWithQuery:customAttributes:")]
		void LogSearch ([NullAllowed] string query, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);

		// +(void)logCustomEventWithName:(NSString * _Nonnull)eventName customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export ("logCustomEventWithName:customAttributes:")]
		void LogCustomEvent (string eventName, [NullAllowed] NSDictionary<NSString, NSObject> customAttributes);
	}

	// @interface CLSReport : NSObject <CLSCrashReport>
	[BaseType (typeof (NSObject), Name = "CLSReport")]
	[DisableDefaultCtor]
	interface Report {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * _Nonnull customKeys;
		[Export ("customKeys", ArgumentSemantic.Copy)]
		NSDictionary CustomKeys { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull bundleVersion;
		[Export ("bundleVersion")]
		string BundleVersion { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull bundleShortVersionString;
		[Export ("bundleShortVersionString")]
		string BundleShortVersionString { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull dateCreated;
		[Export ("dateCreated", ArgumentSemantic.Copy)]
		NSDate DateCreated { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull OSVersion;
		[Export ("OSVersion")]
		string OSVersion { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull OSBuildVersion;
		[Export ("OSBuildVersion")]
		string OSBuildVersion { get; }

		// @property (readonly, assign, nonatomic) BOOL isCrash;
		[Export ("isCrash")]
		bool IsCrash { get; }

		// -(void)setObjectValue:(id _Nullable)value forKey:(NSString * _Nonnull)key;
		[Export ("setObjectValue:forKey:")]
		void SetObjectValue ([NullAllowed] NSObject value, string key);

		// @property (copy, nonatomic) NSString * _Nullable userIdentifier;
		[NullAllowed]
		[Export ("userIdentifier")]
		string UserIdentifier { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable userName;
		[NullAllowed]
		[Export ("userName")]
		string UserName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable userEmail;
		[NullAllowed]
		[Export ("userEmail")]
		string UserEmail { get; set; }
	}

	// @interface CLSStackFrame : NSObject
	[BaseType (typeof (NSObject), Name = "CLSStackFrame")]
	interface StackFrame {
		// +(instancetype _Nonnull)stackFrame;
		[Static]
		[Export ("stackFrame")]
		StackFrame Create ();

		// +(instancetype _Nonnull)stackFrameWithAddress:(NSUInteger)address;
		[Static]
		[Export ("stackFrameWithAddress:")]
		StackFrame Create (nuint address);

		// +(instancetype _Nonnull)stackFrameWithSymbol:(NSString * _Nonnull)symbol;
		[Static]
		[Export ("stackFrameWithSymbol:")]
		StackFrame Create (string symbol);

		// @property (copy, nonatomic) NSString * _Nullable symbol;
		[NullAllowed, Export ("symbol")]
		string Symbol { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable rawSymbol;
		[NullAllowed, Export ("rawSymbol")]
		string RawSymbol { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable library;
		[NullAllowed, Export ("library")]
		string Library { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable fileName;
		[NullAllowed, Export ("fileName")]
		string FileName { get; set; }

		// @property (assign, nonatomic) uint32_t lineNumber;
		[Export ("lineNumber")]
		uint LineNumber { get; set; }

		// @property (assign, nonatomic) uint64_t offset;
		[Export ("offset")]
		ulong Offset { get; set; }

		// @property (assign, nonatomic) uint64_t address;
		[Export ("address")]
		ulong Address { get; set; }
	}

	// @interface Crashlytics : NSObject
	[BaseType (typeof (NSObject))]
	interface Crashlytics {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull APIKey;
		[Export ("APIKey")]
		string ApiKey { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// @property (assign, nonatomic) BOOL debugMode;
		[Export ("debugMode")]
		bool DebugMode { get; set; }

		// @property (assign, nonatomic) id<CrashlyticsDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Assign)]
		ICrashlyticsDelegate Delegate { get; set; }

		// +(Crashlytics * _Nonnull)startWithAPIKey:(NSString * _Nonnull)apiKey;
		[Static]
		[Export ("startWithAPIKey:")]
		Crashlytics Start (string apiKey);

		// +(Crashlytics * _Nonnull)startWithAPIKey:(NSString * _Nonnull)apiKey delegate:(id<CrashlyticsDelegate> _Nullable)delegate;
		[Static]
		[Export ("startWithAPIKey:delegate:")]
		Crashlytics Start (string apiKey, [NullAllowed] ICrashlyticsDelegate aDelegate);

		// +(Crashlytics * _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		Crashlytics SharedInstance { get; }

		// -(void)crash;
		[Export ("crash")]
		void Crash ();

		// -(void)throwException;
		[Export ("throwException")]
		void ThrowException ();

		// -(void)setUserIdentifier:(NSString * _Nullable)identifier;
		[Export ("setUserIdentifier:")]
		void SetUserIdentifier ([NullAllowed] string identifier);

		// -(void)setUserName:(NSString * _Nullable)name;
		[Export ("setUserName:")]
		void SetUserName ([NullAllowed] string name);

		// -(void)setUserEmail:(NSString * _Nullable)email;
		[Export ("setUserEmail:")]
		void SetUserEmail ([NullAllowed] string email);

		// -(void)setObjectValue:(id _Nullable)value forKey:(NSString * _Nonnull)key;
		[Export ("setObjectValue:forKey:")]
		void SetObjectValue ([NullAllowed] NSObject value, string key);

		// -(void)setIntValue:(int)value forKey:(NSString * _Nonnull)key;
		[Export ("setIntValue:forKey:")]
		void SetIntValue (int value, string key);

		// -(void)setBoolValue:(BOOL)value forKey:(NSString * _Nonnull)key;
		[Export ("setBoolValue:forKey:")]
		void SetBoolValue (bool value, string key);

		// -(void)setFloatValue:(float)value forKey:(NSString * _Nonnull)key;
		[Export ("setFloatValue:forKey:")]
		void SetFloatValue (float value, string key);

		// -(void)recordCustomExceptionName:(NSString * _Nonnull)name reason:(NSString * _Nullable)reason frameArray:(NSArray<CLSStackFrame *> * _Nonnull)frameArray;
		[Export ("recordCustomExceptionName:reason:frameArray:")]
		void RecordCustomExceptionName (string name, [NullAllowed] string reason, StackFrame [] frameArray);

		// -(void)recordError:(NSError * _Nonnull)error;
		[Export ("recordError:")]
		void RecordError (NSError error);

		// -(void)recordError:(NSError * _Nonnull)error withAdditionalUserInfo:(NSDictionary<NSString *,id> * _Nullable)userInfo;
		[Export ("recordError:withAdditionalUserInfo:")]
		void RecordError (NSError error, [NullAllowed] NSDictionary<NSString, NSObject> userInfo);

		// -(void)logEvent:(NSString * _Nonnull)eventName __attribute__((deprecated("Please refer to Answers +logCustomEventWithName:")));
		[Export ("logEvent:")]
		void LogEvent (string eventName);
	}

	interface ICrashlyticsDelegate { }

	delegate void DidDetectReportForLastExecutionCompletionHandler (bool submit);

	// @protocol CrashlyticsDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface CrashlyticsDelegate {
		// @optional -(void)crashlyticsDidDetectReportForLastExecution:(CLSReport * _Nonnull)report completionHandler:(void (^ _Nonnull)(BOOL))completionHandler;
		[Export ("crashlyticsDidDetectReportForLastExecution:completionHandler:")]
		void DidDetectReportForLastExecution (Report report, DidDetectReportForLastExecutionCompletionHandler completionHandler);

		// @optional -(void)crashlyticsDidDetectReportForLastExecution:(CLSReport * _Nonnull)report;
		[Export ("crashlyticsDidDetectReportForLastExecution:")]
		void DidDetectReportForLastExecution (Report report);

		// @optional -(BOOL)crashlyticsCanUseBackgroundSessions:(Crashlytics * _Nonnull)crashlytics;
		[Export ("crashlyticsCanUseBackgroundSessions:")]
		bool CanUseBackgroundSessions (Crashlytics crashlytics);
	}
}

namespace Fabric {
	// @interface Fabric : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface Fabric {
		// +(instancetype _Nonnull)with:(NSArray * _Nonnull)kitClasses;
		[Internal]
		[Static]
		[Export ("with:")]
		Fabric _With (NSArray kitClasses);

		// +(instancetype _Nonnull)sharedSDK;
		[Static]
		[Export ("sharedSDK")]
		Fabric SharedSdk { get; }

		// @property (assign, nonatomic) BOOL debug;
		[Export ("debug")]
		bool Debug { get; set; }
	}
}
