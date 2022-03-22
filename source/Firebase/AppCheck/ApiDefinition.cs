using System;
using Firebase.Core;
using Foundation;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Firebase.AppCheck {
	// typedef void (^)(FIRAppCheckToken *_Nullable token, NSError *_Nullable error)
	delegate void TokenCompletionHandler (AppCheckToken token, NSError error);

	// @interface FIRAppCheck : NSObject	
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAppCheck")]
	interface AppCheck {
		// extern NS_SWIFT_NAME(AppCheckTokenDidChange) const NSNotificationName FIRAppCheckAppCheckTokenDidChangeNotification __attribute__((swift_name("AppCheckTokenDidChange")));
		[Field ("FIRAppCheckAppCheckTokenDidChangeNotification", "__Internal")]
		NSString TokenDidChangeNotification { get; }

		// extern NS_SWIFT_NAME(AppCheckTokenNotificationKey) NSString *const kFIRAppCheckTokenNotificationKey __attribute__((swift_name("AppCheckTokenNotificationKey")));
		[Field ("kFIRAppCheckTokenNotificationKey", "__Internal")]
		NSString TokenNotificationKey { get; }

		// extern NS_SWIFT_NAME(AppCheckAppNameNotificationKey) NSString *const kFIRAppCheckAppNameNotificationKey __attribute__((swift_name("AppCheckAppNameNotificationKey")));
		[Field ("kFIRAppCheckAppNameNotificationKey", "__Internal")]
		NSString AppNameNotificationKey { get; }

		// +(instancetype _Nonnull)appCheck __attribute__((swift_name("appCheck()")));
		[Static]
		[Export ("appCheck")]
		AppCheck SharedInstance { get; }

		// +(instancetype _Nullable)appCheckWithApp:(FIRApp * _Nonnull)firebaseApp __attribute__((swift_name("appCheck(app:)")));
		[Static]
		[Export ("appCheckWithApp:")]
		[return: NullAllowed]
		AppCheck Create (App firebaseApp);

		// -(void)tokenForcingRefresh:(BOOL)forcingRefresh completion:(void (^ _Nonnull)(FIRAppCheckToken * _Nullable, NSError * _Nullable))handler __attribute__((swift_name("token(forcingRefresh:completion:)")));
		[Export ("tokenForcingRefresh:completion:")]
		void TokenForcingRefresh (bool forcingRefresh, TokenCompletionHandler handler);

		// +(void)setAppCheckProviderFactory:(id<FIRAppCheckProviderFactory> _Nullable)factory;
		[Static]
		[Export ("setAppCheckProviderFactory:")]
		void SetAppCheckProviderFactory ([NullAllowed] AppCheckProviderFactory factory);

		// @property (assign, nonatomic) BOOL isTokenAutoRefreshEnabled;
		[Export ("isTokenAutoRefreshEnabled")]
		bool IsTokenAutoRefreshEnabled { get; set; }
	}

	// @protocol FIRAppCheckProvider <NSObject>
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FIRAppCheckProvider")]
	interface AppCheckProvider {
		// @required -(void)getTokenWithCompletion:(void (^ _Nonnull)(FIRAppCheckToken * _Nullable, NSError * _Nullable))handler __attribute__((swift_name("getToken(completion:)")));
		[Abstract]
		[Export ("getTokenWithCompletion:")]
		void GetTokenWithCompletion (TokenCompletionHandler handler);
	}

	// @protocol FIRAppCheckProviderFactory <NSObject>
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FIRAppCheckProviderFactory")]
	interface AppCheckProviderFactory {
		// @required -(id<FIRAppCheckProvider> _Nullable)createProviderWithApp:(FIRApp * _Nonnull)app;
		[Abstract]
		[Export ("createProviderWithApp:")]
		[return: NullAllowed]
		AppCheckProvider CreateProviderWithApp (App app);
	}

	// @interface FIRAppCheckToken : NSObject	
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAppCheckToken")]
	interface AppCheckToken {
		// @property (readonly, nonatomic) NSString * _Nonnull token;
		[Export ("token")]
		string Token { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull expirationDate;
		[Export ("expirationDate")]
		NSDate ExpirationDate { get; }

		// -(instancetype _Nonnull)initWithToken:(NSString * _Nonnull)token expirationDate:(NSDate * _Nonnull)expirationDate;
		[Export ("initWithToken:expirationDate:")]
		NativeHandle Constructor (string token, NSDate expirationDate);
	}

	// @interface FIRAppCheckDebugProvider : NSObject <FIRAppCheckProvider>	
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAppCheckDebugProvider")]
	interface AppCheckDebugProvider : AppCheckProvider {
		// -(instancetype _Nullable)initWithApp:(FIRApp * _Nonnull)app;
		[Export ("initWithApp:")]
		NativeHandle Constructor (App app);

		// -(NSString * _Nonnull)localDebugToken;
		[Export ("localDebugToken")]
		string LocalDebugToken { get; }

		// -(NSString * _Nonnull)currentDebugToken;
		[Export ("currentDebugToken")]
		string CurrentDebugToken { get; }
	}

	// @interface FIRAppCheckDebugProviderFactory : NSObject <FIRAppCheckProviderFactory>
	[BaseType (typeof (NSObject), Name = "FIRAppCheckDebugProviderFactory")]
	interface AppCheckDebugProviderFactory : AppCheckProviderFactory {
	}

	// @interface FIRDeviceCheckProvider : NSObject <FIRAppCheckProvider>
	//[TV (11, 0), NoWatch, Mac (10, 15), iOS (11, 0)]	
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRDeviceCheckProvider")]
	interface DeviceCheckProvider : AppCheckProvider {
		// -(instancetype _Nullable)initWithApp:(FIRApp * _Nonnull)app;
		[Export ("initWithApp:")]
		NativeHandle Constructor (App app);
	}

	// @interface FIRAppAttestProvider : NSObject <FIRAppCheckProvider>
	//[NoTV, NoWatch, NoMac, iOS (14, 0)]	
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAppAttestProvider")]
	interface AppAttestProvider : AppCheckProvider {
		// -(instancetype _Nullable)initWithApp:(FIRApp * _Nonnull)app;
		[Export ("initWithApp:")]
		NativeHandle Constructor (App app);
	}

	// @interface FIRDeviceCheckProviderFactory : NSObject <FIRAppCheckProviderFactory>
	//[TV (11, 0), NoWatch, Mac (10, 15), iOS (11, 0)]
	[BaseType (typeof (NSObject), Name = "FIRDeviceCheckProviderFactory")]
	interface DeviceCheckProviderFactory : AppCheckProviderFactory {
	}
}
