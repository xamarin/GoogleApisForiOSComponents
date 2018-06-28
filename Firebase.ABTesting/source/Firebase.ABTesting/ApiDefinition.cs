using Foundation;

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

	// @interface FIRLifecycleEvents : NSObject
	[BaseType (typeof (NSObject), Name = "FIRLifecycleEvents")]
	interface LifecycleEvents {
		// extern NSString *const _Nonnull FIRSetExperimentEventName;
		[Field ("FIRSetExperimentEventName", "__Internal")]
		NSString DefaultSetExperimentEventName { get; }

		// extern NSString *const _Nonnull FIRActivateExperimentEventName;
		[Field ("FIRActivateExperimentEventName", "__Internal")]
		NSString DefaultActivateExperimentEventName { get; }

		// extern NSString *const _Nonnull FIRClearExperimentEventName;
		[Field ("FIRClearExperimentEventName", "__Internal")]
		NSString DefaultClearExperimentEventName { get; }

		// extern NSString *const _Nonnull FIRTimeoutExperimentEventName;
		[Field ("FIRTimeoutExperimentEventName", "__Internal")]
		NSString DefaultTimeoutExperimentEventName { get; }

		// extern NSString *const _Nonnull FIRExpireExperimentEventName;
		[Field ("FIRExpireExperimentEventName", "__Internal")]
		NSString DefaultExpireExperimentEventName { get; }

		// @property (copy, nonatomic) NSString * _Nonnull setExperimentEventName;
		[Export ("setExperimentEventName")]
		string SetExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull activateExperimentEventName;
		[Export ("activateExperimentEventName")]
		string ActivateExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull clearExperimentEventName;
		[Export ("clearExperimentEventName")]
		string ClearExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull timeoutExperimentEventName;
		[Export ("timeoutExperimentEventName")]
		string TimeoutExperimentEventName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull expireExperimentEventName;
		[Export ("expireExperimentEventName")]
		string ExpireExperimentEventName { get; set; }
	}
}
