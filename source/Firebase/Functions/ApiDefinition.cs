using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using Firebase.Core;

namespace Firebase.CloudFunctions
{
	// @interface FIRFunctions : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRFunctions")]
	interface CloudFunctions
	{
		// + (FIRFunctions *)functions;
        [Static]
        [Export("functions")]
        CloudFunctions DefaultInstance { get; }

		// + (FIRFunctions *)functionsForApp:(FIRAPP *)app;
		[Static]
		[Export("functionsForApp:")]
		CloudFunctions From (App app);

		//+ (FIRFunctions *) functionsForRegion:(NSString*) region;
        [Static]
        [Export("functionsForRegion:")]
		CloudFunctions From (string region);

		//+ (FIRFunctions *)functionsForApp:(FIRApp *)app region:(NSString*) region
        [Static]
        [Export("functionsForApp:region")]
		CloudFunctions From (App app, string region);

        //- (FIRHTTPSCallable *)HTTPSCallableWithName:(NSString *)name;
        [Export("HTTPSCallableWithName:")]
		HttpsCallable HttpsCallable (string name);

		//- (void)useFunctionsEmulatorOrigin:(NSString *)origin
		[Export("useFunctionsEmulatorOrigin:")]
		void UseFunctionsEmulatorOrigin(string origin);
	}

	// void (^)(FIRHTTPSCallableResult *_Nullable result, NSError *_Nullable error);
	delegate void HttpsCallableResultHandler ([NullAllowed] HttpsCallableResult result, [NullAllowed] NSError error);


    [DisableDefaultCtor]
    [BaseType (typeof (NSObject), Name = "FIRHTTPSCallable")]
	interface HttpsCallable
	{
		//- (void)callWithCompletion: (void (^)(FIRHTTPSCallableResult *_Nullable result, NSError *_Nullable error))completion;
		[Export("callWithCompletion:")]
        [Async]
		void Call (HttpsCallableResultHandler completion);

		//- (void)callWithObject:(nullable id)data completion:(void (^)(FIRHTTPSCallableResult* _Nullable result, NSError *_Nullable error))completion
        [Export("callWithObject:completion:")]
		[Async]
		void Call ([NullAllowed] NSObject data, HttpsCallableResultHandler completion);

		//@property(nonatomic, assign) NSTimeInterval timeoutInterval;
        [Export("timeoutInterval")]
        double TimeoutInterval { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRHTTPSCallableResult")]
	interface HttpsCallableResult
	{
		//@property(nonatomic, strong, readonly) id data;
		[Export("data")]
		NSObject Data { get; }
	}
}
