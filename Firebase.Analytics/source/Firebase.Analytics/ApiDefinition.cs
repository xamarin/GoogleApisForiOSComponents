using System;

using Foundation;
using ObjCRuntime;

namespace Firebase.Analytics
{
	// @interface FIRAnalytics : NSObject
	[BaseType (typeof (NSObject), Name = "FIRAnalytics")]
	interface Analytics
	{
		// +(void)logEventWithName:(NSString * _Nonnull)name parameters:(NSDictionary<NSString *,NSObject *> * _Nullable)parameters;
		[Static]
		[Export ("logEventWithName:parameters:")]
		void LogEvent (string name, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

		// +(void)setUserPropertyString:(NSString * _Nullable)value forName:(NSString * _Nonnull)name;
		[Static]
		[Export ("setUserPropertyString:forName:")]
		void SetUserProperty ([NullAllowed] string value, string name);

		// +(void)setUserID:(NSString * _Nullable)userID;
		[Static]
		[Export ("setUserID:")]
		void SetUserID ([NullAllowed] string userID);

		// This method comes from a category (FIRAnalytics+AppDelegate.h)
		// +(void)handleEventsForBackgroundURLSession:(NSString *)identifier completionHandler:(void (^)(void))completionHandler;
		[Static]
		[Export ("handleEventsForBackgroundURLSession:completionHandler:")]
		void HandleEventsForBackgroundUrlSession (string identifier, Action completionHandler);

		// This method comes from a category (FIRAnalytics+AppDelegate.h)
		// +(void)handleOpenURL:(NSURL *)url;
		[Static]
		[Export ("handleOpenURL:")]
		void HandleOpenUrl (NSUrl url);

		// This method comes from a category (FIRAnalytics+AppDelegate.h)
		// +(void)handleUserActivity:(id)userActivity;
		[Static]
		[Export ("handleUserActivity:")]
		void HandleUserActivity (NSObject userActivity);

		// + (void)setScreenName:(nullable NSString *)screenName screenClass:(nullable NSString *)screenClassOverride;
		[Static]
		[Export ("setScreenName:screenClass:")]
		void SetScreenNameAndClass ([NullAllowed] string screenName, [NullAllowed] string screenClassOverride);

		// + (NSString *)appInstanceID;
		[Export ("appInstanceID")]
		string AppInstanceId { get; }
	}


	#region Firebase.Core

	////@interface FIRAnalyticsConfiguration : NSObject
	//[DisableDefaultCtor]
	//[BaseType (typeof (NSObject), Name = "FIRAnalyticsConfiguration")]
	//interface AnalyticsConfiguration
	//{
	//	// +(FIRAnalyticsConfiguration *)sharedInstance;
	//	[Static]
	//	[Export ("sharedInstance")]
	//	AnalyticsConfiguration SharedInstance { get; }

	//	// -(void)setMinimumSessionInterval:(NSTimeInterval)minimumSessionInterval;
	//	[Export ("setMinimumSessionInterval:")]
	//	void SetMinimumSessionInterval (double minimumSessionInterval);

	//	// -(void)setSessionTimeoutInterval:(NSTimeInterval)sessionTimeoutInterval;
	//	[Export ("setSessionTimeoutInterval:")]
	//	void SetSessionTimeoutInterval (double sessionTimeoutInterval);

	//	// -(void)setAnalyticsCollectionEnabled:(BOOL)analyticsCollectionEnabled;
	//	[Export ("setAnalyticsCollectionEnabled:")]
	//	void SetAnalyticsCollectionEnabled (bool analyticsCollectionEnabled);
	//}

	//// typedef void (^FIRAppVoidBoolCallback)(BOOL);
	//delegate void AppVoidBoolHandler (bool success);

	//// @interface FIRApp : NSObject
	//[DisableDefaultCtor]
	//[BaseType (typeof (NSObject), Name = "FIRApp")]
	//interface App
	//{
	//	// +(void)configure;
	//	[Static]
	//	[Export ("configure")]
	//	void Configure ();

	//	// +(void)configureWithOptions:(FIROptions * _Nonnull)options;
	//	[Static]
	//	[Export ("configureWithOptions:")]
	//	void Configure (Options options);

	//	// +(void)configureWithName:(NSString * _Nonnull)name options:(FIROptions * _Nonnull)options;
	//	[Static]
	//	[Export ("configureWithName:options:")]
	//	void Configure (string name, Options options);

	//	// +(FIRApp * _Nullable)defaultApp;
	//	[Static]
	//	[Export ("defaultApp")]
	//	App DefaultInstance { get; }

	//	// +(FIRApp * _Nullable)appNamed:(NSString * _Nonnull)name;
	//	[Static]
	//	[return: NullAllowed]
	//	[Export ("appNamed:")]
	//	App From (string name);

	//	// +(NSDictionary * _Nullable)allApps;
	//	[Static]
	//	[return: NullAllowed]
	//	[NullAllowed, Export ("allApps")]
	//	NSDictionary GetAll ();

	//	// -(void)deleteApp:(FIRAppVoidBoolCallback _Nonnull)completion;
	//	[Export ("deleteApp:")]
	//	void Delete (AppVoidBoolHandler completion);

	//	// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
	//	[Export ("name")]
	//	string Name { get; }

	//	// @property (readonly, nonatomic) FIROptions * _Nonnull options;
	//	[Export ("options")]
	//	Options Options { get; }
	//}

	//// @interface FIRConfiguration : NSObject
	//[DisableDefaultCtor]
	//[BaseType (typeof (NSObject), Name = "FIRConfiguration")]
	//interface Configuration
	//{
	//	// +(FIRConfiguration *)sharedInstance;
	//	[Static]
	//	[Export ("sharedInstance")]
	//	Configuration SharedInstance { get; }

	//	// @property (readwrite, nonatomic) FIRAnalyticsConfiguration * analyticsConfiguration;
	//	[Export ("analyticsConfiguration", ArgumentSemantic.Strong)]
	//	AnalyticsConfiguration AnalyticsConfiguration { get; set; }

	//	// @property (assign, readwrite, nonatomic) FIRLogLevel logLevel;
	//	[Obsolete ("Use -FIRDebugEnabled and -FIRDebugDisabled flags or use SetLoggerLevel method.")]
	//	[Export ("logLevel", ArgumentSemantic.Assign)]
	//	LogLevel LogLevel { get; set; }

	//	// - (void)setLoggerLevel:(FIRLoggerLevel)loggerLevel;
	//	[Export ("setLoggerLevel:")]
	//	void SetLoggerLevel (LoggerLevel loggerLevel);
	//}

	//// @interface FIROptions : NSObject <NSCopying>
	//[DisableDefaultCtor]
	//[BaseType (typeof (NSObject), Name = "FIROptions")]
	//interface Options : INSCopying
	//{
	//	// +(FIROptions *)defaultOptions;
	//	[Static]
	//	[Export ("defaultOptions")]
	//	Options DefaultInstance { get; }

	//	// @property (readonly, copy, nonatomic) NSString * APIKey;
	//	[Export ("APIKey")]
	//	string ApiKey { get; }

	//	// @property (readonly, copy, nonatomic) NSString * clientID;
	//	[Export ("clientID")]
	//	string ClientId { get; }

	//	// @property (readonly, copy, nonatomic) NSString * trackingID;
	//	[Export ("trackingID")]
	//	string TrackingId { get; }

	//	// @property (readonly, copy, nonatomic) NSString * GCMSenderID;
	//	[Export ("GCMSenderID")]
	//	string GcmSenderId { get; }

	//	// @property(nonatomic, readonly, copy) NSString *projectID;
	//	[Export ("projectID")]
	//	string ProjectId { get; }

	//	// @property (readonly, copy, nonatomic) NSString * androidClientID;
	//	[Export ("androidClientID")]
	//	string AndroidClientId { get; }

	//	// @property (readonly, copy, nonatomic) NSString * googleAppID;
	//	[Export ("googleAppID")]
	//	string GoogleAppId { get; }

	//	// @property (readonly, copy, nonatomic) NSString * databaseURL;
	//	[Export ("databaseURL")]
	//	string DatabaseUrl { get; }

	//	// @property (readwrite, copy, nonatomic) NSString * deepLinkURLScheme;
	//	[Export ("deepLinkURLScheme")]
	//	string DeepLinkUrlScheme { get; set; }

	//	// @property (readonly, copy, nonatomic) NSString * storageBucket;
	//	[Export ("storageBucket")]
	//	string StorageBucket { get; }

	//	// -(instancetype)initWithGoogleAppID:(NSString *)googleAppID bundleID:(NSString *)bundleID GCMSenderID:(NSString *)GCMSenderID APIKey:(NSString *)APIKey clientID:(NSString *)clientID trackingID:(NSString *)trackingID androidClientID:(NSString *)androidClientID databaseURL:(NSString *)databaseURL storageBucket:(NSString *)storageBucket deepLinkURLScheme:(NSString *)deepLinkURLScheme;
	//	[Export ("initWithGoogleAppID:bundleID:GCMSenderID:APIKey:clientID:trackingID:androidClientID:databaseURL:storageBucket:deepLinkURLScheme:")]
	//	IntPtr Constructor (string googleAppId, string bundleId, string gcmSenderId, string ApiKey, string clientId, string trackingId, string androidClientId, string databaseUrl, string storageBucket, string deepLinkUrlScheme);

	//	// - (instancetype)initWithContentsOfFile:(NSString *)plistPath;
	//	[Export ("initWithContentsOfFile:")]
	//	IntPtr Constructor (string plistPath);
	//}

	#endregion
}
