using Foundation;
using ObjCRuntime;

namespace Google.InstanceID
{
	[Static]
	interface Constants
	{
		// extern NSString *const kGGLInstanceIDRegisterAPNSOption;
		[Field ("kGGLInstanceIDRegisterAPNSOption", "__Internal")]
		NSString RegisterAPNSOption { get; }

		// extern NSString *const kGGLInstanceIDAPNSServerTypeSandboxOption;
		[Field ("kGGLInstanceIDAPNSServerTypeSandboxOption", "__Internal")]
		NSString APNSServerTypeSandboxOption { get; }

		// extern NSString *const kGGLInstanceIDScopeGCM;
		[Field ("kGGLInstanceIDScopeGCM", "__Internal")]
		NSString ScopeGCM { get; }
	}

	// typedef void (^GGLInstanceIDTokenHandler)(NSString *NSError *);
	public delegate void TokenDelegate (string token,NSError error);

	// typedef void (^GGLInstanceIDDeleteTokenHandler)(NSError *);
	public delegate void DeleteTokenDelegate (NSError error);

	// typedef void (^GGLInstanceIDHandler)(NSString *NSError *);
	public delegate void IdDelegate (string identity,NSError error);

	// typedef void (^GGLInstanceIDDeleteHandler)(NSError *);
	public delegate void DeleteIdDelegate (NSError error);

	// @interface GGLInstanceID : NSObject
	[BaseType (typeof(NSObject), Name = "GGLInstanceID")]
	partial interface InstanceId
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		InstanceId SharedInstance { get; }

		// -(void)startWithConfig:(GGLInstanceIDConfig *)config;
		[Export ("startWithConfig:")]
		void Start (Config config);

		// -(void)stopAllRequests;
		[Export ("stopAllRequests")]
		void StopAllRequests ();

		// -(void)tokenWithAuthorizedEntity:(NSString *)authorizedEntity scope:(NSString *)scope options:(NSDictionary *)options handler:(GGLInstanceIDTokenHandler)handler;
		[Export ("tokenWithAuthorizedEntity:scope:options:handler:")]
		void Token (string authorizedEntity, string scope, NSDictionary options, TokenDelegate handler);

		// -(void)deleteTokenWithAuthorizedEntity:(NSString *)authorizedEntity scope:(NSString *)scope handler:(GGLInstanceIDDeleteTokenHandler)handler;
		[Export ("deleteTokenWithAuthorizedEntity:scope:handler:")]
		void DeleteToken (string authorizedEntity, string scope, DeleteTokenDelegate handler);

		// -(void)getIDWithHandler:(GGLInstanceIDHandler)handler;
		[Export ("getIDWithHandler:")]
		void GetID (IdDelegate handler);

		// -(void)deleteIDWithHandler:(GGLInstanceIDDeleteHandler)handler;
		[Export ("deleteIDWithHandler:")]
		void DeleteID (DeleteIdDelegate handler);
	}

	interface IInstanceIdDelegate
	{

	}

	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "GGLInstanceIDDelegate")]
	partial interface InstanceIdDelegate
	{
		[Export ("onTokenRefresh")]
		void OnTokenRefresh ();
	}

	[BaseType (typeof(NSObject), Name = "GGLInstanceIDConfig")]
	partial interface Config : INSCopying, INSMutableCopying
	{
		// @property(nonatomic, readwrite, weak) id<GGLInstanceIDDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IInstanceIdDelegate Delegate { get; set; }

		// the log level for the GGLInstanceID library.
		// @property(nonatomic, readwrite, assign) GGLInstanceIDLogLevel logLevel;
		[Export ("logLevel")]
		LogLevel LogLevel { get; set; }

		//+ (instancetype)defaultConfig;
		[Static]
		[Export ("defaultConfig")]
		Config DefaultConfig { get; }
	}
}