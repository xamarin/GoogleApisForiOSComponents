using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Google.SignIn
{
	// typedef void (^GIDAuthenticationHandler)(GIDAuthentication *authentication, NSError *error);
	delegate void AuthenticationHandler (Authentication authentication,NSError error);

	// typedef void (^GIDAccessTokenHandler)(NSString *, NSError *);
	delegate void AccessTokenHandler (string accessToken,NSError error);

	// @interface GIDAuthentication : NSObject <NSCoding>
	[BaseType (typeof(NSObject), Name = "GIDAuthentication")]
	interface Authentication : INSCoding
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

		// -(void)getAccessTokenWithHandler:(GIDAccessTokenHandler)handler;
		[Obsolete ("Please use 'GetTokens' method")]
		[Export ("getAccessTokenWithHandler:")]
		void GetAccessToken (AccessTokenHandler handler);

		// -(void)refreshAccessTokenWithHandler:(GIDAccessTokenHandler)handler;
		[Obsolete ("Please use 'RefreshTokens' method")]
		[Export ("refreshAccessTokenWithHandler:")]
		void RefreshAccessToken (AccessTokenHandler handler);
	}

	// @interface GIDGoogleUser : NSObject <NSCoding>
	[BaseType (typeof(NSObject), Name = "GIDGoogleUser")]
	interface GoogleUser : INSCoding
	{
		// @property (readonly, nonatomic) NSString * userID;
		[Export ("userID")]
		string UserID { get; }

		// @property (readonly, nonatomic) GIDProfileData * profile;
		[Export ("profile")]
		ProfileData Profile { get; }

		// @property (readonly, nonatomic) GIDAuthentication * authentication;
		[Export ("authentication")]
		Authentication Authentication { get; }

		// @property (readonly, nonatomic) NSArray * accessibleScopes;
		[Export ("accessibleScopes")]
		string[] AccessibleScopes { get; }

		// @property (readonly, nonatomic) NSString * hostedDomain;
		[Export ("hostedDomain")]
		string HostedDomain { get; }

		// @property (readonly, nonatomic) NSString * serverAuthCode;
		[Export ("serverAuthCode")]
		string ServerAuthCode { get; }
	}

	// @interface GIDProfileData : NSObject <NSCoding>
	[BaseType (typeof(NSObject), Name = "GIDProfileData")]
	interface ProfileData : INSCoding
	{
		// @property (readonly, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; }

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

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
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "GIDSignInDelegate")]
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

	interface ISignInUIDelegate
	{

	}

	// @protocol GIDSignInUIDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "GIDSignInUIDelegate")]
	interface SignInUIDelegate
	{
		// @optional -(void)signInWillDispatch:(GIDSignIn *)signIn error:(NSError *)error;
		[Export ("signInWillDispatch:error:")]
		void WillDispatch (SignIn signIn, NSError error);

		// @optional -(void)signIn:(GIDSignIn *)signIn presentViewController:(UIViewController *)viewController;
		[Export ("signIn:presentViewController:")]
		void PresentViewController (SignIn signIn, UIViewController viewController);

		// @optional -(void)signIn:(GIDSignIn *)signIn dismissViewController:(UIViewController *)viewController;
		[Export ("signIn:dismissViewController:")]
		void DismissViewController (SignIn signIn, UIViewController viewController);
	}

	// @interface GIDSignIn : NSObject
	[BaseType (typeof(NSObject), 
		Name = "GIDSignIn",
		Delegates = new string[] { "Delegate" },
		Events = new Type[] { typeof(SignInDelegate) })]
	interface SignIn
	{
		// extern NSString *const kGIDSignInErrorDomain;
		[Field ("kGIDSignInErrorDomain", "__Internal")]
		NSString SignInErrorDomainKey { get; }

		// @property (readonly, nonatomic) GIDGoogleUser * currentUser;
		[Export ("currentUser")]
		GoogleUser CurrentUser { get; }

		// @property (nonatomic, weak) id<GIDSignInDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		ISignInDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<GIDSignInUIDelegate> uiDelegate;
		[NullAllowed, Export ("uiDelegate", ArgumentSemantic.Weak)]
		ISignInUIDelegate UIDelegate { get; set; }

		// @property (copy, nonatomic) NSString * clientID;
		[Export ("clientID")]
		string ClientID { get; set; }

		// @property (copy, nonatomic) NSArray * scopes;
		[Export ("scopes", ArgumentSemantic.Copy)]
		string[] Scopes { get; set; }

		// @property (assign, nonatomic) BOOL shouldFetchBasicProfile;
		[Export ("shouldFetchBasicProfile")]
		bool ShouldFetchBasicProfile { get; set; }

		// @property (assign, nonatomic) BOOL allowsSignInWithBrowser;
		[Export ("allowsSignInWithBrowser")]
		bool AllowsSignInWithBrowser { get; set; }

		// @property (assign, nonatomic) BOOL allowsSignInWithWebView;
		[Export ("allowsSignInWithWebView")]
		bool AllowsSignInWithWebView { get; set; }

		// @property (copy, nonatomic) NSString * language;
		[Export ("language")]
		string Language { get; set; }

		// @property (copy, nonatomic) NSString * serverClientID;
		[Export ("serverClientID")]
		string ServerClientID { get; set; }

		// @property (copy, nonatomic) NSString * openIDRealm;
		[Export ("openIDRealm")]
		string OpenIDRealm { get; set; }

		// @property(nonatomic, copy) NSString *hostedDomain;
		[Export ("hostedDomain")]
		string HostedDomain { get; set; }

		// +(GIDSignIn *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		SignIn SharedInstance { get; }

		// -(BOOL)handleURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;
		[Export ("handleURL:sourceApplication:annotation:")]
		bool HandleUrl (NSUrl url, string sourceApplication, [NullAllowed] NSObject annotation);

		// -(BOOL)hasAuthInKeychain;
		[Export ("hasAuthInKeychain")]
		bool HasAuthInKeychain { get; }

		// -(void)signInSilently;
		[Export ("signInSilently")]
		void SignInUserSilently ();

		// -(void)signIn;
		[Export ("signIn")]
		void SignInUser ();

		// -(void)signOut;
		[Export ("signOut")]
		void SignOutUser ();

		// -(void)disconnect;
		[Export ("disconnect")]
		void DisconnectUser ();

		// -(void)checkGoogleSignInAppInstalled:(void (^)(BOOL))callback;
		[Obsolete ("This method always calls back with |NO| on iOS 9 or above.")]
		[Export ("checkGoogleSignInAppInstalled:"), Async]
		void CheckGoogleSignInAppInstalled (Action<bool> callback);
	}

	// @interface GIDSignInButton : UIControl
	[BaseType (typeof(UIControl), Name = "GIDSignInButton")]
	interface SignInButton
	{
		// @property (assign, nonatomic) GIDSignInButtonStyle style;
		[Export ("style", ArgumentSemantic.Assign)]
		ButtonStyle Style { get; set; }

		// @property (assign, nonatomic) GIDSignInButtonColorScheme colorScheme;
		[Export ("colorScheme", ArgumentSemantic.Assign)]
		ButtonColorScheme ColorScheme { get; set; }

		// @property (nonatomic, weak) UIViewController * delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		UIViewController Delegate { get; set; }
	}

	// @interface GIDSignIn (UIViewController)
	[Category]
	[BaseType (typeof(UIViewController))]
	interface UIViewController_GIDSignIn
	{
		// -(void)gid_signInWithGoogle;
		[Export ("gid_signInWithGoogle")]
		void SignInWithGoogle ();
	}
}

