using System;
using System.Collections.Generic;

using Foundation;

namespace Firebase.InstanceID
{
	// typedef void (^FIRInstanceIDTokenHandler)(NSString * _Nullable, NSError * _Nullable);
	delegate void InstanceIdTokenHandler ([NullAllowed] string token, [NullAllowed] NSError error);

	// typedef void (^FIRInstanceIDDeleteTokenHandler)(NSError * _Nullable);
	delegate void InstanceIdDeleteTokenHandler ([NullAllowed] NSError error);

	// typedef void (^FIRInstanceIDHandler)(NSString * _Nullable, NSError * _Nullable);
	delegate void InstanceIdHandler ([NullAllowed] string identity, [NullAllowed] NSError error);

	// typedef void (^FIRInstanceIDDeleteHandler)(NSError * _Nullable);
	delegate void InstanceIdDeleteHandler ([NullAllowed] NSError error);

	// @interface FIRInstanceID : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRInstanceID")]
	interface InstanceId
	{
		// extern NSString *const _Nonnull kFIRInstanceIDScopeFirebaseMessaging;
		[Field ("kFIRInstanceIDScopeFirebaseMessaging", "__Internal")]
		NSString ScopeFirebaseMessaging { get; }

		// extern NSString *const _Nonnull kFIRInstanceIDTokenRefreshNotification;
		[Notification]
		[Field ("kFIRInstanceIDTokenRefreshNotification", "__Internal")]
		NSString TokenRefreshNotification { get; }

		// +(instancetype _Nonnull)instanceID;
		[Static]
		[Export ("instanceID")]
		InstanceId SharedInstance { get; }

		// -(NSString * _Nullable)token;
		[Export ("token")]
		string Token { get; }

		// -(void)tokenWithAuthorizedEntity:(NSString * _Nonnull)authorizedEntity scope:(NSString * _Nonnull)scope options:(NSDictionary * _Nullable)options handler:(FIRInstanceIDTokenHandler _Nonnull)handler;
		[Async]
		[Export ("tokenWithAuthorizedEntity:scope:options:handler:")]
		void GetToken (string authorizedEntity, string scope, [NullAllowed] NSDictionary options, InstanceIdTokenHandler handler);

		[Async]
		[Wrap ("GetToken (authorizedEntity, scope, options == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (options.Values), System.Linq.Enumerable.ToArray (options.Keys), options.Keys.Count), handler)")]
		void GetToken (string authorizedEntity, string scope, Dictionary<object, object> options, InstanceIdTokenHandler handler);

		// -(void)deleteTokenWithAuthorizedEntity:(NSString * _Nonnull)authorizedEntity scope:(NSString * _Nonnull)scope handler:(FIRInstanceIDDeleteTokenHandler _Nonnull)handler;
		[Async]
		[Export ("deleteTokenWithAuthorizedEntity:scope:handler:")]
		void DeleteToken (string authorizedEntity, string scope, InstanceIdDeleteTokenHandler handler);

		// -(void)getIDWithHandler:(FIRInstanceIDHandler _Nonnull)handler;
		[Async]
		[Export ("getIDWithHandler:")]
		void GetId (InstanceIdHandler handler);

		// -(void)deleteIDWithHandler:(FIRInstanceIDDeleteHandler _Nonnull)handler;
		[Async]
		[Export ("deleteIDWithHandler:")]
		void DeleteId (InstanceIdDeleteHandler handler);
	}
}
