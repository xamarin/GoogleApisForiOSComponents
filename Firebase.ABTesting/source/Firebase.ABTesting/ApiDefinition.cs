using Foundation;
using ObjCRuntime;

namespace Firebase.ABTesting {
	// @interface FIRExperimentController : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRExperimentController")]
	interface ExperimentController {
		// +(FIRExperimentController * _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		ExperimentController SharedInstance { get; }

		// -(void)updateExperimentsWithServiceOrigin:(NSString * _Nonnull)origin events:(FIRLifecycleEvents * _Nonnull)events policy:(NSObject * _Nonnull)policy lastStartTime:(NSTimeInterval)lastStartTime payloads:(NSArray<NSData *> * _Nonnull)payloads;
		[Export ("updateExperimentsWithServiceOrigin:events:policy:lastStartTime:payloads:")]
		void UpdateExperiments (string origin, LifecycleEvents events, NSObject policy, double lastStartTime, NSData [] payloads);

		// -(NSTimeInterval)latestExperimentStartTimestampBetweenTimestamp:(NSTimeInterval)timestamp andPayloads:(NSArray<NSData *> * _Nonnull)payloads;
		[Export ("latestExperimentStartTimestampBetweenTimestamp:andPayloads:")]
		double GetLatestExperimentStartTimestampBetweenTimestamp (double timestamp, NSData [] payloads);
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
		[Export ("activateExperimentEventName", ArgumentSemantic = ArgumentSemantic.Copy)]
		NSString ActivateExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull clearExperimentEventName;
		[Export ("clearExperimentEventName", ArgumentSemantic = ArgumentSemantic.Copy)]
		NSString ClearExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull timeoutExperimentEventName;
		[Export ("timeoutExperimentEventName", ArgumentSemantic = ArgumentSemantic.Copy)]
		NSString TimeoutExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull expireExperimentEventName;
		[Export ("expireExperimentEventName", ArgumentSemantic = ArgumentSemantic.Copy)]
		NSString ExpireExperimentEventName { get; set; }
	}
}
