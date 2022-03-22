using System;

using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Firebase.Crashlytics {
	delegate void HasUnsentReportsHandler (bool hasUnsentReports);
	delegate void CheckAndUpdateUnsentReportsHandler ([NullAllowed] CrashlyticsReport report);

	// @interface FIRCrashlytics : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRCrashlytics")]
	interface Crashlytics
	{
		// +(instancetype _Nonnull)crashlytics __attribute__((swift_name("crashlytics()")));
		[Static]
		[Export ("crashlytics")]
		Crashlytics SharedInstance { get; }

		// -(void)log:(NSString * _Nonnull)msg;
		[Export ("log:")]
		void Log (string message);

		// -(void)setCustomValue:(id _Nonnull)value forKey:(NSString * _Nonnull)key;
		[Export ("setCustomValue:forKey:")]
		void SetCustomValue (NSObject value, string key);

		// -(void)setCustomKeysAndValues:(NSDictionary * _Nonnull)keysAndValues;
		[Export ("setCustomKeysAndValues:")]
		void SetCustomKeysAndValues (NSDictionary<NSString, NSObject> keysAndValues);

		// -(void)setUserID:(NSString * _Nonnull)userID;
		[Export ("setUserID:")]
		void SetUserId (string userId);

		// -(void)recordError:(NSError * _Nonnull)error __attribute__((swift_name("record(error:)")));
		[Export ("recordError:")]
		void RecordError (NSError error);

		// -(void)recordExceptionModel:(FIRExceptionModel * _Nonnull)exceptionModel __attribute__((swift_name("record(exceptionModel:)")));
		[Export ("recordExceptionModel:")]
		void RecordExceptionModel (ExceptionModel exceptionModel);

		// -(BOOL)didCrashDuringPreviousExecution;
		[Export ("didCrashDuringPreviousExecution")]
		bool DidCrashDuringPreviousExecution { get; }

		// -(void)setCrashlyticsCollectionEnabled:(BOOL)enabled;
		[Export ("setCrashlyticsCollectionEnabled:")]
		void SetCrashlyticsCollectionEnabled (bool enabled);

		// -(BOOL)isCrashlyticsCollectionEnabled;
		[Export ("isCrashlyticsCollectionEnabled")]
		bool IsCrashlyticsCollectionEnabled { get; }

		// -(void)checkForUnsentReportsWithCompletion:(void (^ _Nonnull)(BOOL))completion __attribute__((swift_name("checkForUnsentReports(completion:)")));
		[Async]
		[Export ("checkForUnsentReportsWithCompletion:")]
		void CheckForUnsentReports (HasUnsentReportsHandler completion);

		// -(void)checkAndUpdateUnsentReportsWithCompletion:(void (^ _Nonnull)(FIRCrashlyticsReport * _Nullable))completion __attribute__((swift_name("checkAndUpdateUnsentReports(completion:)")));
		[Export ("checkAndUpdateUnsentReportsWithCompletion:")]
		void CheckAndUpdateUnsentReportsWithCompletion (CheckAndUpdateUnsentReportsHandler completionHandler);

		// -(void)sendUnsentReports;
		[Export ("sendUnsentReports")]
		void SendUnsentReports ();

		// -(void)deleteUnsentReports;
		[Export ("deleteUnsentReports")]
		void DeleteUnsentReports ();
	}

	// @interface FIRExceptionModel : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRExceptionModel")]
	interface ExceptionModel
	{
		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name reason:(NSString * _Nonnull)reason;
		[Export ("initWithName:reason:")]
		NativeHandle Constructor (string name, string reason);

		// +(instancetype _Nonnull)exceptionModelWithName:(NSString * _Nonnull)name reason:(NSString * _Nonnull)reason __attribute__((availability(swift, unavailable)));
		[Static]
		[Export ("exceptionModelWithName:reason:")]
		ExceptionModel Create (string name, string reason);

		// @property (copy, nonatomic) NSArray<FIRStackFrame *> * _Nonnull stackTrace;
		[Export ("stackTrace", ArgumentSemantic.Copy)]
		StackFrame [] StackTrace { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRStackFrame")]
	interface StackFrame
	{
		// -(instancetype _Nonnull)initWithSymbol:(NSString * _Nonnull)symbol file:(NSString * _Nonnull)file line:(NSInteger)line;
		[Export ("initWithSymbol:file:line:")]
		NativeHandle Constructor (string symbol, string file, nint line);

		// + (instancetype)stackFrameWithAddress:(NSUInteger)address;
		[Static]
		[Export ("stackFrameWithAddress:address")]
		StackFrame Create (nuint address);

		// +(instancetype _Nonnull)stackFrameWithSymbol:(NSString * _Nonnull)symbol file:(NSString * _Nonnull)file line:(NSInteger)line __attribute__((availability(swift, unavailable)));
		[Static]
		[Export ("stackFrameWithSymbol:file:line:")]
		StackFrame Create (string symbol, string file, nint line);
	}

	// @interface FIRCrashlyticsReport : NSObject	
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRCrashlyticsReport")]
	interface CrashlyticsReport {
		// @property (readonly, nonatomic) NSString * _Nonnull reportID;
		[Export ("reportID")]
		string ReportID { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull dateCreated;
		[Export ("dateCreated")]
		NSDate DateCreated { get; }

		// @property (readonly, nonatomic) BOOL hasCrash;
		[Export ("hasCrash")]
		bool HasCrash { get; }

		// -(void)log:(NSString * _Nonnull)msg;
		[Export ("log:")]
		void Log (string msg);

		// -(void)setCustomValue:(id _Nonnull)value forKey:(NSString * _Nonnull)key;
		[Export ("setCustomValue:forKey:")]
		void SetCustomValue (NSObject value, string key);

		// -(void)setCustomKeysAndValues:(NSDictionary * _Nonnull)keysAndValues;
		[Export ("setCustomKeysAndValues:")]
		void SetCustomKeysAndValues (NSDictionary<NSString, NSObject>  keysAndValues);

		// -(void)setUserID:(NSString * _Nonnull)userID;
		[Export ("setUserID:")]
		void SetUserID (string userID);
	}
}
