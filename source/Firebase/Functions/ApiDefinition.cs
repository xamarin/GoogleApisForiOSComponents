using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using Firebase.Core;

namespace Firebase.Functions
{
	// @interface FIRFunctions : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRFunctions")]
	interface Functions
	{
		// + (FIRFunctions *)functions;
        [Static]
        [Export("functions")]
        Functions DefaultInstance { get; }

		// + (FIRFunctions *)functionsForApp:(FIRAPP *)app;
		[Static]
		[Export("functionsForApp:")]
		Functions CreateForApp(App app);

		//+ (FIRFunctions *) functionsForRegion:(NSString*) region;
        [Static]
        [Export("functionsForRegion:")]
		Functions CreateForRegion(string region);

		//+ (FIRFunctions *)functionsForApp:(FIRApp *)app region:(NSString*) region
        [Static]
        [Export("functionsForApp:region")]
		Functions CreateForApp(App app, string region);

        //- (FIRHTTPSCallable *)HTTPSCallableWithName:(NSString *)name;
        [Export("HTTPSCallableWithName:")]
		HTTPSCallable HTTPSCallableWithName(string name);

		//- (void)useFunctionsEmulatorOrigin:(NSString *)origin
		[Export("useFunctionsEmulatorOrigin:")]
		void UseFunctionsEmulatorOrigin(string origin);
	}

	// void (^)(FIRHTTPSCallableResult *_Nullable result, NSError *_Nullable error);
	delegate void HTTPSCallableResultHandler ([NullAllowed] HTTPSCallableResult result, [NullAllowed] NSError error);


    [DisableDefaultCtor]
    [BaseType (typeof (NSObject), Name = "FIRHTTPSCallable")]
	interface HTTPSCallable
	{
		//- (void)callWithCompletion: (void (^)(FIRHTTPSCallableResult *_Nullable result, NSError *_Nullable error))completion;
		[Export("callWithCompletion:")]
        [Async]
		void CallWithCompletion(HTTPSCallableResultHandler completion);

		//- (void)callWithObject:(nullable id)data completion:(void (^)(FIRHTTPSCallableResult* _Nullable result, NSError *_Nullable error))completion
        [Export("callWithObject:completion:")]
		[Async]
		void CallWithObject([NullAllowed] NSObject data, HTTPSCallableResultHandler completion);

		//@property(nonatomic, assign) NSTimeInterval timeoutInterval;
        [Export("timeoutInterval")]
        double TimeoutInterval { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRHTTPSCallableResult")]
	interface HTTPSCallableResult
	{
		//@property(nonatomic, strong, readonly) id data;
		[Export("data")]
		NSObject Data { get; }
	}
}
