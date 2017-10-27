using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.PerformanceMonitoring
{
	// @interface FIRTrace : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRTrace")]
	interface Trace
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)stop;
		[Export ("stop")]
		void Stop ();

		// -(void)incrementCounterNamed:(NSString * _Nonnull)counterName;
		[Export ("incrementCounterNamed:")]
		void IncrementCounter (string counterName);

		// -(void)incrementCounterNamed:(NSString * _Nonnull)counterName by:(NSInteger)incrementValue;
		[Export ("incrementCounterNamed:by:")]
		void IncrementCounter (string counterName, nint incrementValue);
	}

	// @interface FIRPerformance : NSObject
	[BaseType (typeof (NSObject), Name = "FIRPerformance")]
	interface Performance
	{
		// @property (getter = isDataCollectionEnabled, assign, nonatomic) BOOL dataCollectionEnabled;
		[Export ("dataCollectionEnabled")]
		bool DataCollectionEnabled { [Bind ("isDataCollectionEnabled")] get; set; }

		// @property (getter = isInstrumentationEnabled, assign, nonatomic) BOOL instrumentationEnabled;
		[Export ("instrumentationEnabled")]
		bool InstrumentationEnabled { [Bind ("isInstrumentationEnabled")] get; set; }

		// +(instancetype _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		Performance SharedInstance { get; }

		// +(FIRTrace * _Nullable)startTraceWithName:(NSString * _Nonnull)name;
		[Static]
		[return: NullAllowed]
		[Export ("startTraceWithName:")]
		Trace StartTrace (string name);

		// -(FIRTrace * _Nullable)traceWithName:(NSString * _Nonnull)name;
		[Export ("traceWithName:")]
		[return: NullAllowed]
		Trace GetTrace (string name);
	}
}
