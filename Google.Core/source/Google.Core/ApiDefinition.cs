using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Google.Core
{
	// @interface GGLConfiguration : NSObject
	[BaseType (typeof(NSObject), Name = "GGLConfiguration")]
	interface Configuration
	{

		// @property (readonly, copy, nonatomic) NSString * apiKey;
		[Export ("apiKey")]
		string ApiKey { get; }

		// @property (readonly, copy, nonatomic) NSString * clientID;
		[Export ("clientID")]
		string ClientId { get; }

		// @property (readonly, copy, nonatomic) NSString * trackingID;
		[Export ("trackingID")]
		string TrackingId { get; }

		// @property (readonly, copy, nonatomic) NSString * googleAppID;
		[Export ("googleAppID")]
		string GoogleAppId { get; }

		// @property (readonly, nonatomic) BOOL isAnalyticsEnabled;
		[Export ("isAnalyticsEnabled")]
		bool IsAnalyticsEnabled { get; }

		// @property (readonly, nonatomic) BOOL isMeasurementEnabled;
		[Export ("isMeasurementEnabled")]
		bool IsMeasurementEnabled { get; }

		// @property (readonly, nonatomic) BOOL isSignInEnabled;
		[Export ("isSignInEnabled")]
		bool IsSignInEnabled { get; }

		// @property (readonly, copy, nonatomic) NSString * libraryVersionID;
		[Export ("libraryVersionID")]
		string LibraryVersionId { get; }
	}

	// @interface GGLContext : NSObject
	[BaseType (typeof(NSObject), Name = "GGLContext")]
	interface Context
	{
		// @property (readonly, nonatomic, strong) GGLConfiguration * configuration;
		[Export ("configuration", ArgumentSemantic.Strong)]
		Configuration Configuration { get; }

		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		Context SharedInstance { get; }

		// -(void)configureWithError:(NSError **)error;
		[Export ("configureWithError:")]
		void Configure (out NSError error);
	}

	// @interface GMRConfiguration : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GMRConfiguration")]
	interface MeasurementConfiguration
	{
		// + (GMRConfiguration *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		MeasurementConfiguration SharedInstance { get; }

		// - (void)setIsEnabled:(BOOL)isEnabled;
		[Export ("setIsEnabled:")]
		void SetIsEnabled (bool isEnabled);
	}
}

