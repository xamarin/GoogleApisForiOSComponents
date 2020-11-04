using System;

using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Firebase.Crashlytics {
	// @interface FIRCrashlytics : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRCrashlytics")]
	interface Crashlytics
	{
		// extern double FirebaseCrashlyticsVersionNumber;
		[Field ("FirebaseCrashlyticsVersionNumber", "__Internal")]
		double CurrentVersionNumber { get; }

		// extern const unsigned char [] FirebaseCrashlyticsVersionString;
		[Internal]
		[Field ("FirebaseCrashlyticsVersionString", "__Internal")]
		IntPtr _CurrentVersion { get; }

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
		void CheckForUnsentReports (Action<bool> completion);

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
		IntPtr Constructor (string name, string reason);

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
		IntPtr Constructor (string symbol, string file, nint line);

		// + (instancetype)stackFrameWithAddress:(NSUInteger)address;
		[Static]
		[Export ("stackFrameWithAddress:address")]
		StackFrame Create (nuint address);

		// +(instancetype _Nonnull)stackFrameWithSymbol:(NSString * _Nonnull)symbol file:(NSString * _Nonnull)file line:(NSInteger)line __attribute__((availability(swift, unavailable)));
		[Static]
		[Export ("stackFrameWithSymbol:file:line:")]
		StackFrame Create (string symbol, string file, nint line);
	}
}
