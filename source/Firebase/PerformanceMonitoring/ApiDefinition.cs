using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.PerformanceMonitoring
{
	// @interface FIRHTTPMetric : NSObject <FIRPerformanceAttributable>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRHTTPMetric")]
	interface HttpMetric : PerformanceAttributable
	{
		// -(instancetype _Nullable)initWithURL:(NSURL * _Nonnull)URL HTTPMethod:(FIRHTTPMethod)httpMethod;
		[Export ("initWithURL:HTTPMethod:")]
		IntPtr Constructor (NSUrl url, HttpMethod httpMethod);

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

	// @interface FIRPerformance : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRPerformance")]
	interface Performance {
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

	interface IPerformanceAttributable { }

	// @protocol FIRPerformanceAttributable <NSObject>
	[Protocol (Name = "FIRPerformanceAttributable")]
	interface PerformanceAttributable {
		// @required @property (readonly, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull attributes;
		[Abstract]
		[Export ("attributes")]
		NSDictionary<NSString, NSString> Attributes { get; }

		// @required -(void)setValue:(NSString * _Nonnull)value forAttribute:(NSString * _Nonnull)attribute;
		[Abstract]
		[Export ("setValue:forAttribute:")]
		void SetValue (string value, string attribute);

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

		// -(void)incrementMetric:(NSString * _Nonnull)metricName byInt:(int64_t)incrementValue;
		[Export ("incrementMetric:byInt:")]
		void IncrementMetric (string metricName, long incrementValue);

		// -(int64_t)valueForIntMetric:(NSString * _Nonnull)metricName;
		[Export ("valueForIntMetric:")]
		long GetIntValue (string metricName);

		// -(void)setIntValue:(int64_t)value forMetric:(NSString * _Nonnull)metricName;
		[Export ("setIntValue:forMetric:")]
		void SetIntValue (long value, string metricName);
	}
}
