﻿using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Google.SignIn
{
	// typedef void (^GIDAuthenticationHandler)(GIDAuthentication *authentication, NSError *error);
	delegate void AuthenticationHandler (Authentication authentication, NSError error);

	// typedef void (^GIDAccessTokenHandler)(NSString *, NSError *);
	delegate void AccessTokenHandler (string accessToken, NSError error);

	// @interface GIDAuthentication : NSObject <NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "GIDAuthentication")]
	interface Authentication : INSSecureCoding
	{
		// @property (readonly, nonatomic) NSString * clientID;
		[Export ("clientID")]
		string ClientId { get; }

		// @property (readonly, nonatomic) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, nonatomic) NSDate * accessTokenExpirationDate;
		[Export ("accessTokenExpirationDate")]
		NSDate AccessTokenExpirationDate { get; }

		// @property (readonly, nonatomic) NSString * refreshToken;
		[Export ("refreshToken")]
		string RefreshToken { get; }

		// @property (readonly, nonatomic) NSString * idToken;
		[Export ("idToken")]
		string IdToken { get; }

		// @property(nonatomic, readonly) NSDate *idTokenExpirationDate;
		[Export ("idTokenExpirationDate")]
		NSDate IdTokenExpirationDate { get; }

		//		// -(id<GTMFetcherAuthorizationProtocol>)fetcherAuthorizer;
		//		[Export ("fetcherAuthorizer")]
		//		IFetcherAuthorizationProtocol FetcherAuthorizer { get; }

		// - (void)getTokensWithHandler:(GIDAuthenticationHandler)handler;
		[Export ("getTokensWithHandler:")]
		void GetTokens (AuthenticationHandler handler);

		// - (void)refreshTokensWithHandler:(GIDAuthenticationHandler)handler;
		[Export ("refreshTokensWithHandler:")]
		void RefreshTokens (AuthenticationHandler handler);
	}

	// @interface GIDGoogleUser : NSObject <NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "GIDGoogleUser")]
	interface GoogleUser : INSSecureCoding
	{
		// @property (readonly, nonatomic) NSString * userID;
		[Export ("userID")]
		string UserId { get; }

		// @property (readonly, nonatomic) GIDProfileData * profile;
		[Export ("profile")]
		ProfileData Profile { get; }

		// @property (readonly, nonatomic) GIDAuthentication * authentication;
		[Export ("authentication")]
		Authentication Authentication { get; }

		// @property(nonatomic, readonly) NSArray *grantedScopes;
		[Export ("grantedScopes")]
		string [] GrantedScopes { get; }

		// @property (readonly, nonatomic) NSString * hostedDomain;
		[Export ("hostedDomain")]
		string HostedDomain { get; }

		// @property (readonly, nonatomic) NSString * serverAuthCode;
		[Export ("serverAuthCode")]
		string ServerAuthCode { get; }
	}

	// @interface GIDProfileData : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "GIDProfileData")]
	interface ProfileData : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; }

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property(nonatomic, readonly) NSString *givenName;
		[Export ("givenName")]
		string GivenName { get; }

		// @property(nonatomic, readonly) NSString *familyName;
		[Export ("familyName")]
		string FamilyName { get; }

		// @property (readonly, nonatomic) BOOL hasImage;
		[Export ("hasImage")]
		bool HasImage { get; }

		// -(NSURL *)imageURLWithDimension:(NSUInteger)dimension;
		[Export ("imageURLWithDimension:")]
		NSUrl GetImageUrl (nuint dimension);
	}

	interface ISignInDelegate
	{

	}

	// @protocol GIDSignInDelegate
#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GIDSignInDelegate")]
	interface SignInDelegate
	{
		// @required -(void)signIn:(GIDSignIn *)signIn didSignInForUser:(GIDGoogleUser *)user withError:(NSError *)error;
		[Abstract]
		[EventArgs ("SignInDelegate")]
		[EventName ("SignedIn")]
		[Export ("signIn:didSignInForUser:withError:")]
		void DidSignIn (SignIn signIn, GoogleUser user, NSError error);

		// @optional -(void)signIn:(GIDSignIn *)signIn didDisconnectWithUser:(GIDGoogleUser *)user withError:(NSError *)error;
		[EventArgs ("SignInDelegate")]
		[EventName ("Disconnected")]
		[Export ("signIn:didDisconnectWithUser:withError:")]
		void DidDisconnect (SignIn signIn, GoogleUser user, NSError error);
	}

	// @interface GIDSignIn : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject),
		Name = "GIDSignIn",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (SignInDelegate) })]
	interface SignIn
	{
		// extern NSString *const kGIDSignInErrorDomain;
		[Field ("kGIDSignInErrorDomain", "__Internal")]
		NSString SignInErrorDomainKey { get; }

		// @property (readonly, nonatomic) GIDGoogleUser * currentUser;
		[Export ("currentUser")]
		GoogleUser CurrentUser { get; }

		// @property (nonatomic, weak) id<GIDSignInDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		ISignInDelegate Delegate { get; set; }

		// @property (nonatomic, weak) UIViewController * presentingViewController;
		[Export ("presentingViewController", ArgumentSemantic.Weak)]
		UIViewController PresentingViewController { get; set; }

		// @property (copy, nonatomic) NSString * clientID;
		[Export ("clientID")]
		string ClientId { get; set; }

		// @property (copy, nonatomic) NSArray * scopes;
		[Export ("scopes", ArgumentSemantic.Copy)]
		string [] Scopes { get; set; }

		// @property (assign, nonatomic) BOOL shouldFetchBasicProfile;
		[Export ("shouldFetchBasicProfile")]
		bool ShouldFetchBasicProfile { get; set; }

		// @property (copy, nonatomic) NSString * language;
		[Export ("language")]
		string Language { get; set; }

		// @property(nonatomic, copy) NSString *loginHint;
		[Export ("loginHint")]
		string LoginHint { get; set; }

		// @property (copy, nonatomic) NSString * serverClientID;
		[Export ("serverClientID")]
		string ServerClientId { get; set; }

		// @property (copy, nonatomic) NSString * openIDRealm;
		[Export ("openIDRealm")]
		string OpenIdRealm { get; set; }

		// @property(nonatomic, copy) NSString *hostedDomain;
		[Export ("hostedDomain")]
		string HostedDomain { get; set; }

		// +(GIDSignIn *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		SignIn SharedInstance { get; }

		// -(BOOL)handleURL:(NSURL *)url;
		[Export ("handleURL:")]
		bool HandleUrl (NSUrl url);
		
		// -(BOOL)hasPreviousSignIn;
		[Export ("hasPreviousSignIn")]
		bool HasPreviousSignIn { get; }

		// -(void)restorePreviousSignIn;
		[Export ("restorePreviousSignIn")]
		void RestorePreviousSignIn ();

		// -(void)signIn;
		[Export ("signIn")]
		void SignInUser ();

		// -(void)signOut;
		[Export ("signOut")]
		void SignOutUser ();

		// -(void)disconnect;
		[Export ("disconnect")]
		void DisconnectUser ();
	}

	// @interface GIDSignInButton : UIControl
	[BaseType (typeof (UIControl), Name = "GIDSignInButton")]
	interface SignInButton
	{
		// @property (assign, nonatomic) GIDSignInButtonStyle style;
		[Export ("style", ArgumentSemantic.Assign)]
		ButtonStyle Style { get; set; }

		// @property (assign, nonatomic) GIDSignInButtonColorScheme colorScheme;
		[Export ("colorScheme", ArgumentSemantic.Assign)]
		ButtonColorScheme ColorScheme { get; set; }
	}
}

