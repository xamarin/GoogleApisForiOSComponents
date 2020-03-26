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
}
