using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using System.Collections.Generic;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Firebase.RemoteConfig
{
	// typedef void (^FIRRemoteConfigFetchCompletion)(FIRRemoteConfigFetchStatus, NSError * _Nullable);
	delegate void RemoteConfigFetchCompletionHandler (RemoteConfigFetchStatus status, [NullAllowed] NSError error);

	// typedef void (^FIRRemoteConfigInitializationCompletion)(NSError * _Nullable);
	delegate void RemoteConfigInitializationCompletionHandler ([NullAllowed] NSError error);

	// typedef void (^FIRRemoteConfigFetchAndActivateCompletion)(FIRRemoteConfigFetchAndActivateStatus, NSError * _Nullable);
	delegate void RemoteConfigFetchAndActivateCompletionHandler (RemoteConfigFetchAndActivateStatus status, [NullAllowed] NSError error);

	// typedef void (^_Nullable)(BOOL changed, NSError *_Nullable error);
	delegate void RemoteConfigActivateCompletionHandler (bool changed, [NullAllowed] NSError error);

	// @interface FIRRemoteConfigValue : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRRemoteConfigValue")]
	interface RemoteConfigValue : INSCopying
	{
		// @property (readonly, nonatomic) NSString * _Nullable stringValue;
		[NullAllowed]
		[Export ("stringValue")]
		NSString NSStringValue { get; }

		// @property(nonatomic, readonly, nonnull) NSNumber *numberValue;
		[Export ("numberValue")]
		NSNumber NumberValue { get; }

		// @property (readonly, nonatomic) NSData * _Nonnull dataValue;
		[Export ("dataValue")]
		NSData DataValue { get; }

		// @property (readonly, nonatomic) BOOL boolValue;
		[Export ("boolValue")]
		bool BoolValue { get; }

		// @property (readonly, nonatomic) id _Nullable JSONValue __attribute__((swift_name("jsonValue")));
		[NullAllowed]
		[Export ("JSONValue")]
		NSObject JsonValue { get; }

		// @property (readonly, nonatomic) FIRRemoteConfigSource source;
		[Export ("source")]
		RemoteConfigSource Source { get; }
	}

	// @interface FIRRemoteConfigSettings : NSObject
	[BaseType (typeof (NSObject), Name = "FIRRemoteConfigSettings")]
	interface RemoteConfigSettings
	{
		// @property (assign, nonatomic) NSTimeInterval minimumFetchInterval;
		[Export ("minimumFetchInterval")]
		double MinimumFetchInterval { get; set; }

		// @property (assign, nonatomic) NSTimeInterval fetchTimeout;
		[Export ("fetchTimeout")]
		double FetchTimeout { get; set; }
	}

	// @interface FIRRemoteConfig : NSObject <NSFastEnumeration>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRRemoteConfig")]
	interface RemoteConfig
	{
		// extern NSString *const _Nonnull FIRNamespaceGoogleMobilePlatform;
		[Field ("FIRNamespaceGoogleMobilePlatform", "__Internal")]
		NSString GoogleMobilePlatformNamespace { get; }

		// extern NSString *const _Nonnull FIRRemoteConfigThrottledEndTimeInSecondsKey;
		[Field ("FIRRemoteConfigThrottledEndTimeInSecondsKey", "__Internal")]
		NSString ThrottledEndTimeInSecondsKey { get; }

		// extern NSString *const _Nonnull FIRRemoteConfigErrorDomain;
		[Field ("FIRRemoteConfigErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// @property(nonatomic, readonly, strong, nullable) NSDate *lastFetchTime;
		[NullAllowed]
		[Export ("lastFetchTime", ArgumentSemantic.Strong)]
		NSDate LastFetchTime { get; }

		// @property (readonly, assign, nonatomic) FIRRemoteConfigFetchStatus lastFetchStatus;
		[Export ("lastFetchStatus", ArgumentSemantic.Assign)]
		RemoteConfigFetchStatus LastFetchStatus { get; }

		// @property (readwrite, nonatomic, strong) FIRRemoteConfigSettings * _Nonnull configSettings;
		[Export ("configSettings", ArgumentSemantic.Strong)]
		RemoteConfigSettings ConfigSettings { get; set; }

		// +(FIRRemoteConfig * _Nonnull)remoteConfig;
		[Static]
		[Export ("remoteConfig")]
		RemoteConfig SharedInstance { get; }

		// +(FIRRemoteConfig * _Nonnull)remoteConfigWithApp:(FIRApp * _Nonnull)app __attribute__((swift_name("remoteConfig(app:)")));
		[Static]
		[Export ("remoteConfigWithApp:")]
		RemoteConfig Create (Core.App app);

		// -(void)ensureInitializedWithCompletionHandler:(FIRRemoteConfigInitializationCompletion _Nonnull)completionHandler;
		[Async]
		[Export ("ensureInitializedWithCompletionHandler:")]
		void EnsureInitialized (RemoteConfigInitializationCompletionHandler completionHandler);

		// -(void)fetchWithCompletionHandler:(FIRRemoteConfigFetchCompletion _Nullable)completionHandler;
		[Async]
		[Export ("fetchWithCompletionHandler:")]
		void Fetch ([NullAllowed] RemoteConfigFetchCompletionHandler completionHandler);

		// -(void)fetchWithExpirationDuration:(NSTimeInterval)expirationDuration completionHandler:(FIRRemoteConfigFetchCompletion _Nullable)completionHandler;
		[Async]
		[Export ("fetchWithExpirationDuration:completionHandler:")]
		void Fetch (double expirationDuration, [NullAllowed] RemoteConfigFetchCompletionHandler completionHandler);

		// -(void)fetchAndActivateWithCompletionHandler:(FIRRemoteConfigFetchAndActivateCompletion _Nullable)completionHandler;
		[Async]
		[Export ("fetchAndActivateWithCompletionHandler:")]
		void FetchAndActivate ([NullAllowed] RemoteConfigFetchAndActivateCompletionHandler completionHandler);

		// - (void)activateWithCompletion:(void (^_Nullable)(BOOL changed, NSError *_Nullable error))completion;
		[Async]
		[Export ("activateWithCompletion:")]
		void Activate ([NullAllowed] RemoteConfigActivateCompletionHandler completionHandler);

		[Wrap ("Activate (null)")]
		void Activate ();

		// - (nonnull FIRRemoteConfigValue *)objectForKeyedSubscript:(nonnull NSString *)key;
		[Export ("objectForKeyedSubscript:")]
		RemoteConfigValue GetObjectForKeyedSubscript (NSString key);

		// -(FIRRemoteConfigValue * _Nonnull)configValueForKey:(NSString * _Nullable)key;
		[Export ("configValueForKey:")]
		RemoteConfigValue GetConfigValue ([NullAllowed] string key);

		// -(FIRRemoteConfigValue * _Nonnull)configValueForKey:(NSString * _Nullable)key source:(FIRRemoteConfigSource)source;
		[Export ("configValueForKey:source:")]
		RemoteConfigValue GetConfigValue ([NullAllowed] string key, RemoteConfigSource source);

		// -(NSArray<NSString *> * _Nonnull)allKeysFromSource:(FIRRemoteConfigSource)source;
		[Export ("allKeysFromSource:")]
		string [] GetAllKeys (RemoteConfigSource source);

		// -(NSSet<NSString *> * _Nonnull)keysWithPrefix:(NSString * _Nullable)prefix;
		[Export ("keysWithPrefix:")]
		NSSet<NSString> GetKeys ([NullAllowed] string prefix);

		// -(void)setDefaults:(NSDictionary<NSString *,NSObject *> * _Nullable)defaults;
		[Export ("setDefaults:")]
		void SetDefaults ([NullAllowed] NSDictionary nsDefaults);

		[Wrap ("SetDefaults (defaults == null ? null : NSDictionary.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (defaults.Values), System.Linq.Enumerable.ToArray (defaults.Keys), defaults.Keys.Count))")]
		void SetDefaults (Dictionary<object, object> defaults);

		// -(void)setDefaultsFromPlistFileName:(NSString * _Nullable)fileName;
		[Export ("setDefaultsFromPlistFileName:")]
		void SetDefaults ([NullAllowed] string plistFileName);

		// -(FIRRemoteConfigValue * _Nullable)defaultValueForKey:(NSString * _Nullable)key;
		[return: NullAllowed]
		[Export ("defaultValueForKey:")]
		RemoteConfigValue GetDefaultValue ([NullAllowed] string key);
	}
}
