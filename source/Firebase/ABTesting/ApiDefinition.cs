using Foundation;
using ObjCRuntime;
using System;

namespace Firebase.ABTesting {
	// @interface FIRExperimentController : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRExperimentController")]
	interface ExperimentController {
		// +(FIRExperimentController * _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		ExperimentController SharedInstance { get; }

		// -(void)updateExperimentsWithServiceOrigin:(NSString * _Nonnull)origin events:(FIRLifecycleEvents * _Nonnull)events policy:(ABTExperimentPayloadExperimentOverflowPolicy)policy lastStartTime:(NSTimeInterval)lastStartTime payloads:(NSArray<NSData *> * _Nonnull)payloads completionHandler:(void (^ _Nullable)(NSError * _Nullable))completionHandler;
		[Export ("updateExperimentsWithServiceOrigin:events:policy:lastStartTime:payloads:completionHandler:")]
		void UpdateExperiments (string origin, LifecycleEvents events, NSObject policy, double lastStartTime, NSData [] payloads, [NullAllowed] Action<NSError> completionHandler);

		// -(NSTimeInterval)latestExperimentStartTimestampBetweenTimestamp:(NSTimeInterval)timestamp andPayloads:(NSArray<NSData *> * _Nonnull)payloads;
		[Export ("latestExperimentStartTimestampBetweenTimestamp:andPayloads:")]
		double GetLatestExperimentStartTimestampBetweenTimestamp (double timestamp, NSData [] payloads);

		// -(void)validateRunningExperimentsForServiceOrigin:(NSString * _Nonnull)origin runningExperimentPayloads:(NSArray<ABTExperimentPayload *> * _Nonnull)payloads;
		[Export ("validateRunningExperimentsForServiceOrigin:runningExperimentPayloads:")]
		void ValidateRunningExperiments (string origin, NSObject [] payloads);

		// -(void)activateExperiment:(ABTExperimentPayload * _Nonnull)experimentPayload forServiceOrigin:(NSString * _Nonnull)origin;
		[Export ("activateExperiment:forServiceOrigin:")]
		void ActivateExperiment (NSObject experimentPayload, string origin);
	}

	[Static]
	interface DefaultLifecycleEventNames {
		// extern NSString *const _Nonnull FIRSetExperimentEventName;
		[Field ("FIRSetExperimentEventName", "__Internal")]
		NSString SetExperiment { get; }

		// extern NSString *const _Nonnull FIRActivateExperimentEventName;
		[Field ("FIRActivateExperimentEventName", "__Internal")]
		NSString ActivateExperiment { get; }

		// extern NSString *const _Nonnull FIRClearExperimentEventName;
		[Field ("FIRClearExperimentEventName", "__Internal")]
		NSString ClearExperiment { get; }

		// extern NSString *const _Nonnull FIRTimeoutExperimentEventName;
		[Field ("FIRTimeoutExperimentEventName", "__Internal")]
		NSString TimeoutExperiment { get; }

		// extern NSString *const _Nonnull FIRExpireExperimentEventName;
		[Field ("FIRExpireExperimentEventName", "__Internal")]
		NSString ExpireExperiment { get; }
	}

	// @interface FIRLifecycleEvents : NSObject
	[BaseType (typeof (NSObject), Name = "FIRLifecycleEvents")]
	interface LifecycleEvents {
		// @property (copy, nonatomic) NSString * _Nonnull setExperimentEventName;
		[Advice ("You can use the default event name 'DefaultLifecycleEventNames.SetExperiment'.")]
		[Export ("setExperimentEventName", ArgumentSemantic = ArgumentSemantic.Copy)]
		NSString SetExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull activateExperimentEventName;
		[Advice ("You can use the default event name 'DefaultLifecycleEventNames.ActivateExperiment'.")]
		[Export ("activateExperimentEventName", ArgumentSemantic = ArgumentSemantic.Copy)]
		NSString ActivateExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull clearExperimentEventName;
		[Advice ("You can use the default event name 'DefaultLifecycleEventNames.ClearExperiment'.")]
		[Export ("clearExperimentEventName", ArgumentSemantic = ArgumentSemantic.Copy)]
		NSString ClearExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull timeoutExperimentEventName;
		[Advice ("You can use the default event name 'DefaultLifecycleEventNames.TimeoutExperiment'.")]
		[Export ("timeoutExperimentEventName", ArgumentSemantic = ArgumentSemantic.Copy)]
		NSString TimeoutExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull expireExperimentEventName;
		[Advice ("You can use the default event name 'DefaultLifecycleEventNames.ExpireExperiment'.")]
		[Export ("expireExperimentEventName", ArgumentSemantic = ArgumentSemantic.Copy)]
		NSString ExpireExperimentEventName { get; set; }
	}
}
