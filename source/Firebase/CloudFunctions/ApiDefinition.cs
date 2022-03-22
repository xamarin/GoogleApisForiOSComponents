﻿using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using Firebase.Core;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Firebase.CloudFunctions
{
	// @interface FIRFunctions : NSObject
	[DisableDefaultCtor]
	[BaseType(typeof(NSObject), Name = "FIRFunctions")]
	interface CloudFunctions
	{
		// + (FIRFunctions *)functions;
		[Static]
		[Export("functions")]
		CloudFunctions DefaultInstance { get; }

		// + (FIRFunctions *)functionsForApp:(FIRAPP *)app;
		[Static]
		[Export("functionsForApp:")]
		CloudFunctions From(App app);

		// + (instancetype)functionsForApp:(FIRApp *)app customDomain:(NSString *)customDomain
		[Static]
		[Export("functionsForApp:customDomain:")]
		CloudFunctions FromCustomDomain(App app, string customDomain);
				
		//+ (FIRFunctions *)functionsForCustomDomain:(NSString*) customDomain
		[Static]
		[Export ("functionsForCustomDomain:")]
		CloudFunctions FromCustomDomain (string customDomain);

		//+ (FIRFunctions *)functionsForApp:(FIRApp *)app region:(NSString*) region
		[Static]
		[Export("functionsForApp:region:")]
		CloudFunctions FromRegion(App app, string region);

		//+ (FIRFunctions *) functionsForRegion:(NSString*) region;
		[Static]
		[Export ("functionsForRegion:")]
		CloudFunctions FromRegion (string region);

		//- (FIRHTTPSCallable *)HTTPSCallableWithName:(NSString *)name;
		[Export("HTTPSCallableWithName:")]
		HttpsCallable HttpsCallable(string name);

		// @property(nonatomic, readonly, nullable) NSString *emulatorOrigin;
		[Export("emulatorOrigin")]
		string EmulatorOrigin { get; }

		//- (void)useFunctionsEmulatorOrigin:(NSString *)origin
		[Export("useFunctionsEmulatorOrigin:")]
		void UseFunctionsEmulatorOrigin(string origin);

		//- (void)useEmulatorWithHost:(NSString *)host port:(NSInteger) port;
		[Export ("useEmulatorWithHost:port:")]
		void UseEmulatorOriginWithHost (string host, uint port);
	}

	// void (^)(FIRHTTPSCallableResult *_Nullable result, NSError *_Nullable error);
	delegate void HttpsCallableResultHandler([NullAllowed] HttpsCallableResult result, [NullAllowed] NSError error);


	[DisableDefaultCtor]
	[BaseType(typeof(NSObject), Name = "FIRHTTPSCallable")]
	interface HttpsCallable
	{
		//- (void)callWithCompletion: (void (^)(FIRHTTPSCallableResult *_Nullable result, NSError *_Nullable error))completion;
		[Export("callWithCompletion:")]
		[Async]
		void Call(HttpsCallableResultHandler completion);

		//- (void)callWithObject:(nullable id)data completion:(void (^)(FIRHTTPSCallableResult* _Nullable result, NSError *_Nullable error))completion
		[Export("callWithObject:completion:")]
		[Async]
		void Call([NullAllowed] NSObject data, HttpsCallableResultHandler completion);

		//@property(nonatomic, assign) NSTimeInterval timeoutInterval;
		[Export("timeoutInterval")]
		double TimeoutInterval { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType(typeof(NSObject), Name = "FIRHTTPSCallableResult")]
	interface HttpsCallableResult
	{
		//@property(nonatomic, strong, readonly) id data;
		[Export("data")]
		NSObject Data { get; }
	}
}
