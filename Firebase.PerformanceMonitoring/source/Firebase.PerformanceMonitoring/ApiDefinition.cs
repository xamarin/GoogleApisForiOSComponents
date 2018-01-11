using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.PerformanceMonitoring
{
	interface IPerformanceAttributable {}

	// @protocol FIRPerformanceAttributable <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject), Name = "FIRPerformanceAttributable")]
	interface PerformanceAttributable
	{
		// @required @property (readonly, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull attributes;
		[Abstract]
		[Export ("attributes")]
		NSDictionary<NSString,NSString> Attributes { get; }

		// @required -(void)setValue:(NSString * _Nonnull)value forAttribute:(NSString * _Nonnull)attribute;
		[Abstract]
		[Export ("setValue:forAttribute:")]
		void SetValue (string value,string attribute);

		// @required -(NSString * _Nullable)valueForAttribute:(NSString * _Nonnull)attribute;
		[Abstract]
		[Export ("valueForAttribute:")]
		[return: NullAllowed]
		string GetValue (string attribute);

		// @required -(void)removeAttribute:(NSString * _Nonnull)attribute;
		[Abstract]
		[Export ("removeAttribute:")]
		void RemoveAttribute (string attribute);
	}

	interface IHttpMetric {}

	// @interface FIRHTTPMetric : NSObject <FIRPerformanceAttributable>
	[BaseType (typeof (NSObject), Name = "FIRHTTPMetric")]
	[DisableDefaultCtor]
	interface HttpMetric : PerformanceAttributable
	{
		// -(instancetype _Nullable)initWithURL:(NSURL * _Nonnull)URL HTTPMethod:(FIRHTTPMethod)httpMethod;
		[Export ("initWithURL:HTTPMethod:")]
		IntPtr Constructor (NSUrl URL,HttpMethod httpMethod);

		// @property (assign, nonatomic) NSInteger responseCode;
		[Export ("responseCode")]
		nint ResponseCode { get; set; }

		// @property (assign, nonatomic) long requestPayloadSize;
		[Export ("requestPayloadSize")]
		nint RequestPayloadSize { get; set; }

		// @property (assign, nonatomic) long responsePayloadSize;
		[Export ("responsePayloadSize")]
		nint ResponsePayloadSize { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable responseContentType;
		[NullAllowed, Export ("responseContentType")]
		string ResponseContentType { get; set; }

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)stop;
		[Export ("stop")]
		void Stop ();
	}

	// @interface FIRTrace : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRTrace")]
	interface Trace : PerformanceAttributable
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
