using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.Auth
{
	// @interface FIRActionCodeSettings : NSObject
	[BaseType (typeof (NSObject), Name = "FIRActionCodeSettings")]
	interface ActionCodeSettings
	{
		// @property (copy, nonatomic) NSURL * _Nullable URL;
		[NullAllowed]
		[Export ("URL", ArgumentSemantic.Copy)]
		NSUrl Url { get; set; }

		// @property (assign, nonatomic) BOOL handleCodeInApp;
		[Export ("handleCodeInApp")]
		bool HandleCodeInApp { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable iOSBundleID;
		// -(void)setIOSBundleID:(NSString * _Nonnull)iOSBundleID;
		[NullAllowed]
		[Export ("iOSBundleID")]
		string IOSBundleId { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable androidPackageName;
		[NullAllowed]
		[Export ("androidPackageName")]
		string AndroidPackageName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable androidMinimumVersion;
		[NullAllowed]
		[Export ("androidMinimumVersion")]
		string AndroidMinimumVersion { get; }

		// @property (readonly, assign, nonatomic) BOOL androidInstallIfNotAvailable;
		[Export ("androidInstallIfNotAvailable")]
		bool AndroidInstallIfNotAvailable { get; }

		// @property (copy, nonatomic) NSString * _Nullable dynamicLinkDomain;
		[NullAllowed]
		[Export ("dynamicLinkDomain")]
		string DynamicLinkDomain { get; set; }

		// -(void)setAndroidPackageName:(NSString * _Nonnull)androidPackageName installIfNotAvailable:(BOOL)installIfNotAvailable minimumVersion:(NSString * _Nullable)minimumVersion;
		[Export ("setAndroidPackageName:installIfNotAvailable:minimumVersion:")]
		void SetAndroidPackageName (string androidPackageName, bool installIfNotAvailable, [NullAllowed] string minimumVersion);
	}

	// @interface FIRAdditionalUserInfo : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAdditionalUserInfo")]
	interface AdditionalUserInfo
	{
		// @property (readonly, nonatomic) NSString * _Nonnull providerID;
		[Export ("providerID")]
		string ProviderId { get; }

		// @property (readonly, nonatomic) NSDictionary<NSString *,NSObject *> * _Nullable profile;
		[NullAllowed]
		[Export ("profile")]
		NSDictionary<NSString, NSObject> Profile { get; }

		// @property (readonly, nonatomic) NSString * _Nullable username;
		[NullAllowed]
		[Export ("username")]
		string Username { get; }

		// @property (readonly, getter = isNewUser, nonatomic) BOOL newUser;
		[Export ("isNewUser")]
		bool IsNewUser { get; }
	}

	// typedef void (^FIRUserUpdateCallback)(NSError * _Nullable);
	delegate void UserUpdateHandler ([NullAllowed] NSError error);

	// typedef void (^FIRAuthStateDidChangeListenerBlock)(FIRAuth * _Nonnull, FIRUser * _Nullable);
	delegate void AuthStateDidChangeListenerHandler (Auth auth, [NullAllowed] User user);

	// typedef void (^FIRIDTokenDidChangeListenerBlock)(FIRAuth * _Nonnull, FIRUser * _Nullable);
	delegate void IdTokenDidChangeListenerHandler (Auth auth, [NullAllowed] User user);

	// typedef void (^FIRAuthDataResultCallback)(FIRAuthDataResult * _Nullable, NSError * _Nullable);
	delegate void AuthDataResultHandler ([NullAllowed] AuthDataResult authResult, [NullAllowed] NSError error);

	// typedef void (^FIRAuthResultCallback)(FIRUser * _Nullable, NSError * _Nullable);
	delegate void AuthResultHandler ([NullAllowed] User user, [NullAllowed] NSError error);

	// typedef void (^FIRProviderQueryCallback)(NSArray<NSString *> * _Nullable, NSError * _Nullable);
	delegate void ProviderQueryHandler ([NullAllowed] string [] providers, [NullAllowed] NSError error);

	// typedef void (^FIRSignInMethodQueryCallback)(NSArray<NSString *> * _Nullable, NSError * _Nullable);
	delegate void SignInMethodQueryHandler ([NullAllowed] string [] methods, [NullAllowed] NSError error);

	// typedef void (^FIRSendPasswordResetCallback)(NSError * _Nullable);
	delegate void SendPasswordResetHandler ([NullAllowed] NSError error);

	// typedef void (^FIRSendSignInLinkToEmailCallback)(NSError * _Nullable);
	delegate void SendSignInLinkToEmailHandler ([NullAllowed] NSError error);

	// typedef void (^FIRConfirmPasswordResetCallback)(NSError * _Nullable);
	delegate void ConfirmPasswordResetHandler ([NullAllowed] NSError erorr);

	// typedef void (^FIRVerifyPasswordResetCodeCallback)(NSString * _Nullable, NSError * _Nullable);
	delegate void VerifyPasswordResetCodeHandler ([NullAllowed] string email, [NullAllowed] NSError error);

	// typedef void (^FIRApplyActionCodeCallback)(NSError * _Nullable);
	delegate void ApplyActionCodeHandler ([NullAllowed] NSError error);

	// typedef void (^FIRAuthVoidErrorCallback)(NSError * _Nullable);
	delegate void AuthVoidErrorHandler ([NullAllowed] NSError error);

	// @interface FIRActionCodeInfo : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRActionCodeInfo")]
	interface ActionCodeInfo
	{
		// @property (readonly, nonatomic) FIRActionCodeOperation operation;
		[Export ("operation")]
		ActionCodeOperation Operation { get; }

		// -(NSString * _Nonnull)dataForKey:(FIRActionDataKey)key;
		[Obsolete ("Deprecated. Please directly use Email or PreviousEmail properties instead.")]
		[Export ("dataForKey:")]
		string DataForKey (ActionDataKey key);

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed]
		[Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable previousEmail;
		[NullAllowed]
		[Export ("previousEmail")]
		string PreviousEmail { get; }
	}

	// @interface FIRActionCodeURL : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRActionCodeURL")]
	interface ActionCodeUrl
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable APIKey;
		[NullAllowed]
		[Export ("APIKey")]
		string ApiKey { get; }

		// @property (readonly, nonatomic) FIRActionCodeOperation operation;
		[Export ("operation")]
		ActionCodeOperation Operation { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable code;
		[NullAllowed]
		[Export ("code")]
		string Code { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable continueURL;
		[NullAllowed]
		[Export ("continueURL", ArgumentSemantic.Copy)]
		NSUrl ContinueUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable languageCode;
		[NullAllowed]
		[Export ("languageCode")]
		string LanguageCode { get; }

		// +(instancetype _Nullable)actionCodeURLWithLink:(NSString * _Nonnull)link;
		[Static]
		[return: NullAllowed]
		[Export ("actionCodeURLWithLink:")]
		ActionCodeUrl Create (string link);
	}

	// typedef void (^FIRCheckActionCodeCallBack)(FIRActionCodeInfo * _Nullable, NSError * _Nullable);
	delegate void CheckActionCodeHandler ([NullAllowed] ActionCodeInfo info, [NullAllowed] NSError error);

	// @interface FIRAuth : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAuth")]
	interface Auth
	{
		// extern const double FirebaseAuthVersionNum;
		[Field ("FirebaseAuthVersionNum", "__Internal")]
		double CurrentVersionNumber { get; }

		// extern const char *const FirebaseAuthVersionStr;
		[Internal]
		[Field ("FirebaseAuthVersionStr", "__Internal")]
		IntPtr _CurrentVersion { get; }

		// extern NSString *const FIRAuthErrorDomain;
		[Field ("FIRAuthErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// extern NSString *const _Nonnull FIRAuthErrorUserInfoNameKey __attribute__((swift_name("AuthErrorUserInfoNameKey")));
		[Field ("FIRAuthErrorUserInfoNameKey", "__Internal")]
		NSString ErrorUserInfoNameKey { get; }

		// extern NSString *const FIRAuthErrorUserInfoEmailKey;
		[Field ("FIRAuthErrorUserInfoEmailKey", "__Internal")]
		NSString ErrorUserInfoEmailKey { get; }

		// extern NSString *const _Nonnull FIRAuthErrorUserInfoUpdatedCredentialKey __attribute__((swift_name("AuthErrorUserInfoUpdatedCredentialKey")));
		[Field ("FIRAuthErrorUserInfoUpdatedCredentialKey", "__Internal")]
		NSString ErrorUserInfoUpdatedCredentialKey { get; }

		// extern NSString *const _Nonnull FIRAuthErrorUserInfoMultiFactorResolverKey __attribute__((swift_name("AuthErrorUserInfoMultiFactorResolverKey")));
		[Field ("FIRAuthErrorUserInfoMultiFactorResolverKey", "__Internal")]
		NSString ErrorUserInfoMultiFactorResolverKey { get; }

		// extern NSString *const _Nonnull FIRAuthStateDidChangeNotification;
		[Notification]
		[Field ("FIRAuthStateDidChangeNotification", "__Internal")]
		NSString StateDidChangeNotification { get; }

		// +(FIRAuth * _Nullable)auth;
		[Static]
		[NullAllowed]
		[Export ("auth")]
		Auth DefaultInstance { get; }

		// +(FIRAuth * _Nullable)authWithApp:(FIRApp * _Nonnull)app;
		[Static]
		[Export ("authWithApp:")]
		[return: NullAllowed]
		Auth From (Firebase.Core.App app);

		// @property (readonly, nonatomic, weak) FIRApp * _Nullable app;
		[NullAllowed]
		[Export ("app", ArgumentSemantic.Weak)]
		Firebase.Core.App App { get; }

		// @property (readonly, nonatomic, strong) FIRUser * _Nullable currentUser;
		[NullAllowed]
		[Export ("currentUser", ArgumentSemantic.Strong)]
		User CurrentUser { get; }

		// @property (nonatomic, copy, nullable) NSString *languageCode;
		[NullAllowed]
		[Export ("languageCode")]
		string LanguageCode { get; set; }

		// @property (copy, nonatomic) FIRAuthSettings * _Nullable settings;
		[NullAllowed]
		[Export ("settings", ArgumentSemantic.Copy)]
		AuthSettings Settings { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable userAccessGroup;
		[NullAllowed]
		[Export ("userAccessGroup")]
		string UserAccessGroup { get; }

		[NullAllowed]
		[Export ("APNSToken", ArgumentSemantic.Strong)]
		NSData ApnsToken { get; set; }

		// -(void)updateCurrentUser:(FIRUser * _Nonnull)user completion:(FIRUserUpdateCallback _Nullable)completion;
		[Async]
		[Export ("updateCurrentUser:completion:")]
		void UpdateCurrentUser (User user, [NullAllowed] UserUpdateHandler completion);

		// -(void)fetchProvidersForEmail:(NSString * _Nonnull)email completion:(FIRProviderQueryCallback _Nullable)completion;
		[Obsolete ("Use the FetchSignInMethods method instead.")]
		[Async]
		[Export ("fetchProvidersForEmail:completion:")]
		void FetchProviders (string email, [NullAllowed] ProviderQueryHandler completion);

		// -(void)fetchSignInMethodsForEmail:(NSString * _Nonnull)email completion:(FIRSignInMethodQueryCallback _Nullable)completion;
		[Async]
		[Export ("fetchSignInMethodsForEmail:completion:")]
		void FetchSignInMethods (string email, [NullAllowed] SignInMethodQueryHandler completion);

		// -(void)signInWithEmail:(NSString * _Nonnull)email password:(NSString * _Nonnull)password completion:(nullable FIRAuthDataResultCallback)completion;
		[Async]
		[Export ("signInWithEmail:password:completion:")]
		void SignInWithPassword (string email, string password, [NullAllowed] AuthDataResultHandler completion);

		// -(void)signInWithEmail:(NSString * _Nonnull)email link:(NSString * _Nonnull)link completion:(FIRAuthDataResultCallback _Nullable)completion;
		[Async]
		[Export ("signInWithEmail:link:completion:")]
		void SignInWithLink (string email, string link, [NullAllowed] AuthDataResultHandler completion);

		// -(void)signInWithProvider:(id<FIRFederatedAuthProvider> _Nonnull)provider UIDelegate:(id<FIRAuthUIDelegate> _Nullable)UIDelegate completion:(FIRAuthDataResultCallback _Nullable)completion;
		[Async]
		[Export ("signInWithProvider:UIDelegate:completion:")]
		void SignInWithProvider (IFederatedAuthProvider provider, [NullAllowed] IAuthUIDelegate uiDelegate, [NullAllowed] AuthDataResultHandler completion);

		// - (void)signInAndRetrieveDataWithCredential:(FIRAuthCredential *)credential completion:(nullable FIRAuthDataResultCallback) completion;
		[Obsolete ("Please, use SignInWithCredential method instead.")]
		[Async]
		[Export ("signInAndRetrieveDataWithCredential:completion:")]
		void SignInAndRetrieveDataWithCredential (AuthCredential credential, [NullAllowed] AuthDataResultHandler completion);

		// - (void) signInWithCredential:(FIRAuthCredential*) credential completion:(nullable FIRAuthDataResultCallback) completion;
		[Async]
		[Export ("signInWithCredential:completion:")]
		void SignInWithCredential (AuthCredential credential, [NullAllowed] AuthDataResultHandler completion);

		// -(void)signInAnonymouslyWithCompletion:(FIRAuthResultCallback _Nullable)completion;
		[Async]
		[Export ("signInAnonymouslyWithCompletion:")]
		void SignInAnonymously ([NullAllowed] AuthDataResultHandler completion);

		// -(void)signInWithCustomToken:(NSString * _Nonnull)token completion:(FIRAuthResultCallback _Nullable)completion;
		[Async]
		[Export ("signInWithCustomToken:completion:")]
		void SignInWithCustomToken (string token, [NullAllowed] AuthDataResultHandler completion);

		// -(void)createUserWithEmail:(NSString * _Nonnull)email password:(NSString * _Nonnull)password completion:(FIRAuthResultCallback _Nullable)completion;
		[Async]
		[Export ("createUserWithEmail:password:completion:")]
		void CreateUser (string email, string password, [NullAllowed] AuthDataResultHandler completion);

		// -(void)confirmPasswordResetWithCode:(NSString * _Nonnull)code newPassword:(NSString * _Nonnull)newPassword completion:(FIRConfirmPasswordResetCallback _Nonnull)completion;
		[Async]
		[Export ("confirmPasswordResetWithCode:newPassword:completion:")]
		void ConfirmPasswordReset (string code, string newPassword, ConfirmPasswordResetHandler completion);

		// -(void)checkActionCode:(NSString * _Nonnull)code completion:(FIRCheckActionCodeCallBack _Nonnull)completion;
		[Async]
		[Export ("checkActionCode:completion:")]
		void CheckActionCode (string code, CheckActionCodeHandler completion);

		// -(void)verifyPasswordResetCode:(NSString * _Nonnull)code completion:(FIRVerifyPasswordResetCodeCallback _Nonnull)completion;
		[Async]
		[Export ("verifyPasswordResetCode:completion:")]
		void VerifyPasswordResetCode (string code, VerifyPasswordResetCodeHandler completion);

		// -(void)applyActionCode:(NSString * _Nonnull)code completion:(FIRApplyActionCodeCallback _Nonnull)completion;
		[Async]
		[Export ("applyActionCode:completion:")]
		void ApplyActionCode (string code, ApplyActionCodeHandler completion);

		// -(void)sendPasswordResetWithEmail:(NSString * _Nonnull)email completion:(FIRSendPasswordResetCallback _Nullable)completion;
		[Async]
		[Export ("sendPasswordResetWithEmail:completion:")]
		void SendPasswordReset (string email, [NullAllowed] SendPasswordResetHandler completion);

		// - (void)sendPasswordResetWithEmail:(NSString *)email actionCodeSettings:(FIRActionCodeSettings*) actionCodeSettings completion:(nullable FIRSendPasswordResetCallback) completion;
		[Async]
		[Export ("sendPasswordResetWithEmail:actionCodeSettings:completion:")]
		void SendPasswordReset (string email, ActionCodeSettings actionCodeSettings, [NullAllowed] SendPasswordResetHandler completion);

		// -(void)sendSignInLinkToEmail:(NSString * _Nonnull)email actionCodeSettings:(FIRActionCodeSettings * _Nonnull)actionCodeSettings completion:(FIRSendSignInLinkToEmailCallback _Nullable)completion;
		[Async]
		[Export ("sendSignInLinkToEmail:actionCodeSettings:completion:")]
		void SendSignInLink (string email, ActionCodeSettings actionCodeSettings, [NullAllowed] SendSignInLinkToEmailHandler completion);

		// -(BOOL)signOut:(NSError * _Nullable * _Nullable)error;
		[Export ("signOut:")]
		bool SignOut ([NullAllowed] out NSError error);

		// -(BOOL)isSignInWithEmailLink:(NSString * _Nonnull)link;
		[Export ("isSignInWithEmailLink:")]
		bool IsSignIn (string link);

		// -(FIRAuthStateDidChangeListenerHandle _Nonnull)addAuthStateDidChangeListener:(FIRAuthStateDidChangeListenerBlock _Nonnull)listener;
		[Export ("addAuthStateDidChangeListener:")]
		NSObject AddAuthStateDidChangeListener (AuthStateDidChangeListenerHandler listener);

		// -(void)removeAuthStateDidChangeListener:(FIRAuthStateDidChangeListenerHandle _Nonnull)listenerHandle;
		[Export ("removeAuthStateDidChangeListener:")]
		void RemoveAuthStateDidChangeListener (NSObject listenerHandler);

		// -(FIRIDTokenDidChangeListenerHandle _Nonnull)addIDTokenDidChangeListener:(FIRIDTokenDidChangeListenerBlock _Nonnull)listener;
		[Export ("addIDTokenDidChangeListener:")]
		NSObject AddIdTokenDidChangeListener (IdTokenDidChangeListenerHandler listener);

		// -(void)removeIDTokenDidChangeListener:(FIRIDTokenDidChangeListenerHandle _Nonnull)listenerHandle;
		[Export ("removeIDTokenDidChangeListener:")]
		void RemoveIdTokenDidChangeListener (NSObject listenerHandler);

		// - (void) useAppLanguage;
		[Export ("useAppLanguage")]
		void UseAppLanguage ();

		// - (BOOL)canHandleURL:(nonnull NSURL *)URL;
		[Export ("canHandleURL:")]
		bool CanHandleUrl (NSUrl url);

		// -(void)setAPNSToken:(NSData * _Nonnull)token type:(FIRAuthAPNSTokenType)type;
		[Export ("setAPNSToken:type:")]
		void SetApnsToken (NSData token, AuthApnsTokenType type);

		// -(BOOL)canHandleNotification:(NSDictionary * _Nonnull)userInfo;
		[Export ("canHandleNotification:")]
		bool CanHandleNotification (NSDictionary userInfo);

		// -(BOOL)useUserAccessGroup:(NSString * _Nullable)accessGroup error:(NSError * _Nullable * _Nullable)outError;
		[Export ("useUserAccessGroup:error:")]
		bool UseUserAccessGroup ([NullAllowed] string accessGroup, [NullAllowed] out NSError outError);

		// -(FIRUser * _Nullable)getStoredUserForAccessGroup:(NSString * _Nullable)accessGroup error:(NSError * _Nullable * _Nullable)outError;
		[return: NullAllowed]
		[Export ("getStoredUserForAccessGroup:error:")]
		User GetStoredUser([NullAllowed] string accessGroup, [NullAllowed] out NSError outError);
	}

	// @interface FIRAuthCredential : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAuthCredential")]
	interface AuthCredential
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull provider;
		[Export ("provider")]
		string Provider { get; }
	}

	// @interface FIRAuthDataResult : NSObject
	[BaseType (typeof (NSObject), Name = "FIRAuthDataResult")]
	[DisableDefaultCtor]
	interface AuthDataResult
	{
		// @property (readonly, nonatomic) FIRUser * _Nonnull user;
		[Export ("user")]
		User User { get; }

		// @property (readonly, nonatomic) FIRAdditionalUserInfo * _Nullable additionalUserInfo;
		[NullAllowed]
		[Export ("additionalUserInfo")]
		AdditionalUserInfo AdditionalUserInfo { get; }

		// @property (readonly, nonatomic) FIRAuthCredential * _Nullable credential;
		[NullAllowed]
		[Export ("credential")]
		AuthCredential Credential { get; }
	}

	// @interface FIRAuthSettings : NSObject
	[BaseType (typeof (NSObject), Name = "FIRAuthSettings")]
	interface AuthSettings {
		// @property (getter = isAppVerificationDisabledForTesting, assign, nonatomic) BOOL appVerificationDisabledForTesting;
		[Export ("appVerificationDisabledForTesting")]
		bool AppVerificationDisabledForTesting { [Bind ("isAppVerificationDisabledForTesting")] get; set; }
	}

	// @interface FIRAuthTokenResult : NSObject
	[BaseType (typeof (NSObject), Name = "FIRAuthTokenResult")]
	interface AuthTokenResult {
		// @property (readonly, nonatomic) NSString * _Nonnull token;
		[Export ("token")]
		string Token { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull expirationDate;
		[Export ("expirationDate")]
		NSDate ExpirationDate { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull authDate;
		[Export ("authDate")]
		NSDate AuthDate { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull issuedAtDate;
		[Export ("issuedAtDate")]
		NSDate IssuedAtDate { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull signInProvider;
		[Export ("signInProvider")]
		string SignInProvider { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull signInSecondFactor;
		[Export ("signInSecondFactor")]
		string SignInSecondFactor { get; }

		// @property (readonly, nonatomic) NSDictionary<NSString *,id> * _Nonnull claims;
		[Export ("claims")]
		NSDictionary<NSString, NSObject> Claims { get; }
	}

	interface IAuthUIDelegate
	{
	}

	// @protocol FIRAuthUIDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FIRAuthUIDelegate")]
	interface AuthUIDelegate
	{
		// @required -(void)presentViewController:(UIViewController * _Nonnull)viewControllerToPresent animated:(BOOL)flag completion:(void (^ _Nullable)(void))completion;
		[Abstract]
		[Export ("presentViewController:animated:completion:")]
		void PresentViewController (UIViewController viewControllerToPresent, bool flag, [NullAllowed] Action completion);

		// @required -(void)dismissViewControllerAnimated:(BOOL)flag completion:(void (^ _Nullable)(void))completion;
		[Abstract]
		[Export ("dismissViewControllerAnimated:completion:")]
		void DismissViewController (bool animated, [NullAllowed] Action completion);
	}

	// @interface FIREmailAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIREmailAuthProvider")]
	interface EmailAuthProvider
	{
		// extern NSString *const _Nonnull FIREmailAuthProviderID;
		[Field ("FIREmailAuthProviderID", "__Internal")]
		NSString Id { get; }

		// extern NSString *const _Nonnull FIREmailPasswordAuthSignInMethod;
		[Field ("FIREmailPasswordAuthSignInMethod", "__Internal")]
		NSString PasswordSignInMethod { get; }

		// +(FIRAuthCredential * _Nonnull)credentialWithEmail:(NSString * _Nonnull)email password:(NSString * _Nonnull)password;
		[Static]
		[Export ("credentialWithEmail:password:")]
		AuthCredential GetCredentialFromPassword (string email, string password);

		// +(FIRAuthCredential * _Nonnull)credentialWithEmail:(NSString * _Nonnull)email link:(NSString * _Nonnull)link;
		[Static]
		[Export ("credentialWithEmail:link:")]
		AuthCredential GetCredentialFromLink (string email, string link);
	}

	// @interface FIRFacebookAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRFacebookAuthProvider")]
	interface FacebookAuthProvider
	{
		// extern NSString *const _Nonnull FIRFacebookAuthProviderID;
		[Field ("FIRFacebookAuthProviderID", "__Internal")]
		NSString Id { get; }

		// extern NSString *const _Nonnull FIRFacebookAuthSignInMethod;
		[Field ("FIRFacebookAuthSignInMethod", "__Internal")]
		NSString SignInMethod { get; }

		// +(FIRAuthCredential * _Nonnull)credentialWithAccessToken:(NSString * _Nonnull)accessToken;
		[Static]
		[Export ("credentialWithAccessToken:")]
		AuthCredential GetCredential (string accessToken);
	}

	interface IFederatedAuthProvider { }

	// typedef void (^FIRAuthCredentialCallback)(FIRAuthCredential * _Nullable, NSError * _Nullable);
	delegate void AuthCredentialCallbackHandler ([NullAllowed] AuthCredential credential, [NullAllowed] NSError error);

	// @protocol FIRFederatedAuthProvider <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FIRFederatedAuthProvider")]
	interface FederatedAuthProvider {
		// @required -(void)getCredentialWithUIDelegate:(id<FIRAuthUIDelegate> _Nullable)UIDelegate completion:(FIRAuthCredentialCallback _Nullable)completion;
		[Abstract]
		[Export ("getCredentialWithUIDelegate:completion:")]
		void Completion ([NullAllowed] IAuthUIDelegate uiDelegate, [NullAllowed] AuthCredentialCallbackHandler completion);
	}

	// typedef void (^FIRGameCenterCredentialCallback)(FIRAuthCredential * _Nullable, NSError * _Nullable);
	delegate void GameCenterCredentialCallbackHandler ([NullAllowed] AuthCredential credential, [NullAllowed] NSError error);

	// @interface FIRGameCenterAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRGameCenterAuthProvider")]
	interface GameCenterAuthProvider {
		// extern NSString *const _Nonnull FIRGameCenterAuthProviderID __attribute__((swift_name("GameCenterAuthProviderID")));
		[Field ("FIRGameCenterAuthProviderID", "__Internal")]
		NSString Id { get; }

		// extern NSString *const _Nonnull FIRGameCenterAuthSignInMethod __attribute__((swift_name("GameCenterAuthSignInMethod")));
		[Field ("FIRGameCenterAuthSignInMethod", "__Internal")]
		NSString SignInMethod { get; }

		// +(void)getCredentialWithCompletion:(FIRGameCenterCredentialCallback _Nonnull)completion __attribute__((swift_name("getCredential(completion:)")));
		[Async]
		[Static]
		[Export ("getCredentialWithCompletion:")]
		void GetCredential (GameCenterCredentialCallbackHandler completion);
	}

	// @interface FIRGitHubAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRGitHubAuthProvider")]
	interface GitHubAuthProvider
	{
		// extern NSString *const _Nonnull FIRGitHubAuthProviderID;
		[Field ("FIRGitHubAuthProviderID", "__Internal")]
		NSString Id { get; }

		// extern NSString *const _Nonnull FIRGitHubAuthSignInMethod;
		[Field ("FIRGitHubAuthSignInMethod", "__Internal")]
		NSString SignInMethod { get; }

		// +(FIRAuthCredential * _Nonnull)credentialWithToken:(NSString * _Nonnull)token;
		[Static]
		[Export ("credentialWithToken:")]
		AuthCredential GetCredential (string token);
	}

	// @interface FIRGoogleAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRGoogleAuthProvider")]
	interface GoogleAuthProvider
	{
		// extern NSString *const _Nonnull FIRGoogleAuthProviderID;
		[Field ("FIRGoogleAuthProviderID", "__Internal")]
		NSString Id { get; }

		// extern NSString *const _Nonnull FIRGoogleAuthSignInMethod;
		[Field ("FIRGoogleAuthSignInMethod", "__Internal")]
		NSString SignInMethod { get; }

		// +(FIRAuthCredential * _Nonnull)credentialWithIDToken:(NSString * _Nonnull)IDToken accessToken:(NSString * _Nonnull)accessToken;
		[Static]
		[Export ("credentialWithIDToken:accessToken:")]
		AuthCredential GetCredential (string idToken, string accessToken);
	}

	// typedef void (^FIRMultiFactorSessionCallback)(FIRMultiFactorSession * _Nullable, NSError * _Nullable);
	delegate void MultiFactorSessionHandler ([NullAllowed] MultiFactorSession session, [NullAllowed] NSError error);

	// @interface FIRMultiFactor : NSObject
	[BaseType (typeof(NSObject), Name = "FIRMultiFactor")]
	interface MultiFactor
	{
		// extern NSString *const _Nonnull FIRPhoneMultiFactorID __attribute__((swift_name("PhoneMultiFactorID")));
		[Field ("FIRPhoneMultiFactorID", "__Internal")]
		NSString PhoneMultiFactorId { get; }

		// @property (readonly, nonatomic) NSArray<FIRMultiFactorInfo *> * _Nonnull enrolledFactors;
		[Export ("enrolledFactors")]
		MultiFactorInfo [] EnrolledFactors { get; }

		// -(void)getSessionWithCompletion:(FIRMultiFactorSessionCallback _Nullable)completion;
		[Export ("getSessionWithCompletion:")]
		void GetSession ([NullAllowed] MultiFactorSessionHandler completion);

		// -(void)enrollWithAssertion:(FIRMultiFactorAssertion * _Nonnull)assertion displayName:(NSString * _Nullable)displayName completion:(FIRAuthVoidErrorCallback _Nullable)completion;
		[Export ("enrollWithAssertion:displayName:completion:")]
		void Enroll (MultiFactorAssertion assertion, [NullAllowed] string displayName, [NullAllowed] AuthVoidErrorHandler completion);

		// -(void)unenrollWithInfo:(FIRMultiFactorInfo * _Nonnull)factorInfo completion:(FIRAuthVoidErrorCallback _Nullable)completion;
		[Export ("unenrollWithInfo:completion:")]
		void Unenroll (MultiFactorInfo factorInfo, [NullAllowed] AuthVoidErrorHandler completion);

		// -(void)unenrollWithFactorUID:(NSString * _Nonnull)factorUID completion:(FIRAuthVoidErrorCallback _Nullable)completion;
		[Export ("unenrollWithFactorUID:completion:")]
		void Unenroll (string factorUid, [NullAllowed] AuthVoidErrorHandler completion);
	}

	// @interface FIRMultiFactorAssertion : NSObject
	[BaseType (typeof(NSObject), Name = "FIRMultiFactorAssertion")]
	interface MultiFactorAssertion
	{
		// @property (readonly, nonatomic) NSString * _Nonnull factorID;
		[Export ("factorID")]
		string FactorId { get; }
	}

	// @interface FIRMultiFactorInfo : NSObject
	[BaseType (typeof(NSObject), Name = "FIRMultiFactorInfo")]
	interface MultiFactorInfo
	{
		// @property (readonly, nonatomic) NSString * _Nonnull UID;
		[Export ("UID")]
		string Uid { get; }

		// @property (readonly, nonatomic) NSString * _Nullable displayName;
		[NullAllowed]
		[Export ("displayName")]
		string DisplayName { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull enrollmentDate;
		[Export ("enrollmentDate")]
		NSDate EnrollmentDate { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull factorID;
		[Export ("factorID")]
		string FactorId { get; }
	}

	// @interface FIRMultiFactorResolver : NSObject
	[BaseType (typeof(NSObject), Name = "FIRMultiFactorResolver")]
	interface MultiFactorResolver
	{
		// @property (readonly, nonatomic) FIRMultiFactorSession * _Nonnull session;
		[Export ("session")]
		MultiFactorSession Session { get; }

		// @property (readonly, nonatomic) NSArray<FIRMultiFactorInfo *> * _Nonnull hints __attribute__((swift_name("hints")));
		[Export ("hints")]
		MultiFactorInfo [] Hints { get; }

		// @property (readonly, nonatomic) FIRAuth * _Nonnull auth;
		[Export ("auth")]
		Auth Auth { get; }

		// -(void)resolveSignInWithAssertion:(FIRMultiFactorAssertion * _Nonnull)assertion completion:(FIRAuthDataResultCallback _Nullable)completion;
		[Export ("resolveSignInWithAssertion:completion:")]
		void ResolveSignIn (MultiFactorAssertion assertion, [NullAllowed] AuthDataResultHandler completion);
	}

	// @interface FIRMultiFactorSession : NSObject
	[BaseType (typeof(NSObject), Name = "FIRMultiFactorSession")]
	interface MultiFactorSession
	{
	}

	// @interface FIROAuthCredential : FIRAuthCredential <NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (AuthCredential), Name = "FIROAuthCredential")]
	interface OAuthCredential : INSSecureCoding {
		// @property (readonly, nonatomic) NSString * _Nullable IDToken;
		[NullAllowed]
		[Export ("IDToken")]
		string IdToken { get; }

		// @property (readonly, nonatomic) NSString * _Nullable accessToken;
		[NullAllowed]
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, nonatomic) NSString * _Nullable secret;
		[NullAllowed]
		[Export ("secret")]
		string Secret { get; }
	}

	// @interface FIROAuthProvider : NSObject <FIRFederatedAuthProvider>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIROAuthProvider")]
	interface OAuthProvider : FederatedAuthProvider {
		// @property (copy, nonatomic) NSArray<NSString *> * _Nullable scopes;
		[NullAllowed]
		[Export ("scopes", ArgumentSemantic.Copy)]
		string [] Scopes { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable customParameters;
		[NullAllowed]
		[Export ("customParameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> CustomParameters { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull providerID;
		[Export ("providerID")]
		string Id { get; }

		// +(FIROAuthProvider * _Nonnull)providerWithProviderID:(NSString * _Nonnull)providerID;
		[Static]
		[Export ("providerWithProviderID:")]
		OAuthProvider Create (string providerId);

		// +(FIROAuthProvider * _Nonnull)providerWithProviderID:(NSString * _Nonnull)providerID auth:(FIRAuth * _Nonnull)auth;
		[Static]
		[Export ("providerWithProviderID:auth:")]
		OAuthProvider Create (string providerId, Auth auth);

		// +(FIROAuthCredential * _Nonnull)credentialWithProviderID:(NSString * _Nonnull)providerID IDToken:(NSString * _Nonnull)IDToken accessToken:(NSString * _Nullable)accessToken;
		[Static]
		[Export ("credentialWithProviderID:IDToken:accessToken:")]
		OAuthCredential GetCredential (string providerId, string IdToken, [NullAllowed] string accessToken);

		// +(FIROAuthCredential * _Nonnull)credentialWithProviderID:(NSString * _Nonnull)providerID accessToken:(NSString * _Nonnull)accessToken;
		[Static]
		[Export ("credentialWithProviderID:accessToken:")]
		OAuthCredential GetCredential (string providerId, string accessToken);

		// +(FIROAuthCredential * _Nonnull)credentialWithProviderID:(NSString * _Nonnull)providerID IDToken:(NSString * _Nonnull)IDToken rawNonce:(NSString * _Nullable)rawNonce accessToken:(NSString * _Nullable)accessToken;
		[Static]
		[Export ("credentialWithProviderID:IDToken:rawNonce:accessToken:")]
		OAuthCredential GetCredential (string providerId, string IdToken, [NullAllowed] string rawNonce, [NullAllowed] string accessToken);

		// +(FIROAuthCredential * _Nonnull)credentialWithProviderID:(NSString * _Nonnull)providerID IDToken:(NSString * _Nonnull)IDToken rawNonce:(NSString * _Nullable)rawNonce;
		[Static]
		[Export ("credentialWithProviderID:IDToken:rawNonce:")]
		OAuthCredential GetCredentialWithRawNonce (string providerId, string IdToken, [NullAllowed] string rawNonce);
	}

	// @interface FIRPhoneAuthCredential : FIRAuthCredential
	[DisableDefaultCtor]
	[BaseType (typeof (AuthCredential), Name = "FIRPhoneAuthCredential")]
	interface PhoneAuthCredential : INSSecureCoding { }

	// typedef void (^FIRVerificationResultCallback)(NSString * _Nullable, NSError * _Nullable);
	delegate void VerificationResultHandler ([NullAllowed] string verificationId, [NullAllowed] NSError error);

	// @interface FIRPhoneAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRPhoneAuthProvider")]
	interface PhoneAuthProvider
	{
		// extern NSString *const _Nonnull FIRPhoneAuthProviderID;
		[Field ("FIRPhoneAuthProviderID", "__Internal")]
		NSString Id { get; }

		// extern NSString *const _Nonnull FIRPhoneAuthSignInMethod;
		[Field ("FIRPhoneAuthSignInMethod", "__Internal")]
		NSString SignInMethod { get; }

		// +(instancetype _Nonnull)provider;
		[Static]
		[Export ("provider")]
		PhoneAuthProvider DefaultInstance { get; }

		// +(instancetype _Nonnull)providerWithAuth:(FIRAuth * _Nonnull)auth;
		[Static]
		[Export ("providerWithAuth:")]
		PhoneAuthProvider Create (Auth auth);

		[Obsolete ("Use Create static method instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("Create (auth)")]
		PhoneAuthProvider From (Auth auth);

		// - (void)verifyPhoneNumber:(NSString *)phoneNumber UIDelegate:(nullable id<FIRAuthUIDelegate>)UIDelegate completion:(nullable FIRVerificationResultCallback) completion;
		[Async]
		[Export ("verifyPhoneNumber:UIDelegate:completion:")]
		void VerifyPhoneNumber (string phoneNumber, [NullAllowed] IAuthUIDelegate uiDelegate, [NullAllowed] VerificationResultHandler completion);

		// -(void)verifyPhoneNumber:(NSString * _Nonnull)phoneNumber UIDelegate:(id<FIRAuthUIDelegate> _Nullable)UIDelegate multiFactorSession:(FIRMultiFactorSession * _Nullable)session completion:(FIRVerificationResultCallback _Nullable)completion;
		[Async]
		[Export ("verifyPhoneNumber:UIDelegate:multiFactorSession:completion:")]
		void VerifyPhoneNumber (string phoneNumber, [NullAllowed] IAuthUIDelegate uiDelegate, [NullAllowed] MultiFactorSession session, [NullAllowed] VerificationResultHandler completion);

		// -(void)verifyPhoneNumberWithMultiFactorInfo:(FIRPhoneMultiFactorInfo * _Nonnull)phoneMultiFactorInfo UIDelegate:(id<FIRAuthUIDelegate> _Nullable)UIDelegate multiFactorSession:(FIRMultiFactorSession * _Nullable)session completion:(FIRVerificationResultCallback _Nullable)completion;
		[Async]
		[Export ("verifyPhoneNumberWithMultiFactorInfo:UIDelegate:multiFactorSession:completion:")]
		void VerifyPhoneNumber (PhoneMultiFactorInfo phoneMultiFactorInfo, [NullAllowed] IAuthUIDelegate uiDelegate, [NullAllowed] MultiFactorSession session, [NullAllowed] VerificationResultHandler completion);

		// -(FIRPhoneAuthCredential * _Nonnull)credentialWithVerificationID:(NSString * _Nonnull)verificationID verificationCode:(NSString * _Nonnull)verificationCode;
		[Export ("credentialWithVerificationID:verificationCode:")]
		PhoneAuthCredential GetCredential (string verificationId, string verificationCode);
	}

	// @interface FIRPhoneMultiFactorAssertion : FIRMultiFactorAssertion
	[BaseType (typeof(MultiFactorAssertion), Name = "FIRPhoneMultiFactorAssertion")]
	interface PhoneMultiFactorAssertion
	{
	}
	
	// @interface FIRPhoneMultiFactorGenerator : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRPhoneMultiFactorGenerator")]
	interface PhoneMultiFactorGenerator
	{
		// +(FIRPhoneMultiFactorAssertion * _Nonnull)assertionWithCredential:(FIRPhoneAuthCredential * _Nonnull)phoneAuthCredential;
		[Static]
		[Export ("assertionWithCredential:")]
		PhoneMultiFactorAssertion GetAssertion (PhoneAuthCredential phoneAuthCredential);
	}
	
	// @interface FIRPhoneMultiFactorInfo : FIRMultiFactorInfo
	[BaseType (typeof(MultiFactorInfo), Name = "FIRPhoneMultiFactorInfo")]
	interface PhoneMultiFactorInfo
	{
		// @property (readonly, nonatomic) NSString * _Nonnull phoneNumber;
		[Export ("phoneNumber")]
		string PhoneNumber { get; }
	}

	// @interface FIRTwitterAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRTwitterAuthProvider")]
	interface TwitterAuthProvider
	{
		// extern NSString *const _Nonnull FIRTwitterAuthProviderID;
		[Field ("FIRTwitterAuthProviderID", "__Internal")]
		NSString Id { get; }

		// extern NSString *const _Nonnull FIRTwitterAuthSignInMethod;
		[Field ("FIRTwitterAuthSignInMethod", "__Internal")]
		NSString SignInMethod { get; }

		// +(FIRAuthCredential * _Nonnull)credentialWithToken:(NSString * _Nonnull)token secret:(NSString * _Nonnull)secret;
		[Static]
		[Export ("credentialWithToken:secret:")]
		AuthCredential GetCredential (string token, string secret);
	}

	// typedef void (^FIRAuthTokenCallback)(NSString * _Nullable, NSError * _Nullable);
	delegate void AuthTokenHandler ([NullAllowed] string token, [NullAllowed] NSError error);

	// typedef void (^FIRAuthTokenResultCallback)(FIRAuthTokenResult * _Nullable, NSError * _Nullable);
	delegate void AuthTokenResultHandler ([NullAllowed] AuthTokenResult tokenResult, [NullAllowed] NSError error);

	// typedef void (^FIRUserProfileChangeCallback)(NSError * _Nullable);
	delegate void UserProfileChangeHandler ([NullAllowed] NSError error);

	// typedef void (^FIRSendEmailVerificationCallback)(NSError * _Nullable);
	delegate void SendEmailVerificationHandler ([NullAllowed] NSError error);

	// @interface FIRUser : NSObject <FIRUserInfo>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRUser")]
	interface User : UserInfo
	{
		// @property (readonly, getter = isAnonymous, nonatomic) BOOL anonymous;
		[Export ("anonymous")]
		bool IsAnonymous { [Bind ("isAnonymous")] get; }

		// @property (readonly, getter = isEmailVerified, nonatomic) BOOL emailVerified;
		[Export ("emailVerified")]
		bool IsEmailVerified { [Bind ("isEmailVerified")] get; }

		// @property (readonly, nonatomic) NSString * _Nullable refreshToken;
		[NullAllowed]
		[Export ("refreshToken")]
		string RefreshToken { get; }

		// @property (readonly, nonatomic) NSArray<id<FIRUserInfo>> * _Nonnull providerData;
		[Export ("providerData")]
		IUserInfo [] ProviderData { get; }

		// @property (readonly, nonatomic) FIRUserMetadata * _Nonnull metadata;
		[Export ("metadata")]
		UserMetadata Metadata { get; }

		// @property (readonly, nonatomic) FIRMultiFactor * _Nonnull multiFactor;
		[Export("multiFactor")]
		MultiFactor MultiFactor { get; }

		// -(void)updateEmail:(NSString * _Nonnull)email completion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Async]
		[Export ("updateEmail:completion:")]
		void UpdateEmail (string email, [NullAllowed] UserProfileChangeHandler completion);

		// -(void)updatePassword:(NSString * _Nonnull)password completion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Async]
		[Export ("updatePassword:completion:")]
		void UpdatePassword (string password, [NullAllowed] UserProfileChangeHandler completion);

		// -(void)updatePhoneNumberCredential:(FIRPhoneAuthCredential * _Nonnull)phoneNumberCredential completion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Async]
		[Export ("updatePhoneNumberCredential:completion:")]
		void UpdatePhoneNumberCredential (PhoneAuthCredential phoneNumberCredential, [NullAllowed] UserProfileChangeHandler completion);

		// -(FIRUserProfileChangeRequest * _Nonnull)profileChangeRequest;
		[Export ("profileChangeRequest")]
		UserProfileChangeRequest ProfileChangeRequest ();

		// -(void)reloadWithCompletion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Async]
		[Export ("reloadWithCompletion:")]
		void Reload ([NullAllowed] UserProfileChangeHandler completion);

		// -(void)reauthenticateWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Async]
		[Export ("reauthenticateWithCredential:completion:")]
		void Reauthenticate (AuthCredential credential, [NullAllowed] UserProfileChangeHandler completion);

		// -(void)reauthenticateAndRetrieveDataWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRAuthDataResultCallback _Nullable)completion;
		[Obsolete ("Please, use Reauthenticate method instead.")]
		[Async]
		[Export ("reauthenticateAndRetrieveDataWithCredential:completion:")]
		void ReauthenticateAndRetrieveData (AuthCredential credential, [NullAllowed] AuthDataResultHandler completion);

		// -(void)reauthenticateWithProvider:(id<FIRFederatedAuthProvider> _Nonnull)provider UIDelegate:(id<FIRAuthUIDelegate> _Nullable)UIDelegate completion:(FIRAuthDataResultCallback _Nullable)completion __attribute__((swift_name("reauthenticate(with:uiDelegate:completion:)"))) __attribute__((availability(ios, introduced=8.0)));
		[iOS (8,0)]
		[Async]
		[Export ("reauthenticateWithProvider:UIDelegate:completion:")]
		void Reauthenticate (FederatedAuthProvider provider, [NullAllowed] AuthUIDelegate @delegate, [NullAllowed] AuthDataResultHandler completion);

		// -(void)getIDTokenResultWithCompletion:(FIRAuthTokenResultCallback _Nullable)completion;
		[Async]
		[Export ("getIDTokenResultWithCompletion:")]
		void GetIdTokenResult ([NullAllowed] AuthTokenResultHandler completion);

		// -(void)getIDTokenResultForcingRefresh:(BOOL)forceRefresh completion:(FIRAuthTokenResultCallback _Nullable)completion;
		[Async]
		[Export ("getIDTokenResultForcingRefresh:completion:")]
		void GetIdTokenResult (bool forceRefresh, [NullAllowed] AuthTokenResultHandler completion);

		// -(void)getIDTokenWithCompletion:(FIRAuthTokenCallback _Nullable)completion;
		[Async]
		[Export ("getIDTokenWithCompletion:")]
		void GetIdToken ([NullAllowed] AuthTokenHandler completion);

		// -(void)getIDTokenForcingRefresh:(BOOL)forceRefresh completion:(FIRAuthTokenCallback _Nullable)completion;
		[Async]
		[Export ("getIDTokenForcingRefresh:completion:")]
		void GetIdToken (bool forceRefresh, [NullAllowed] AuthTokenHandler completion);

		// -(void)linkAndRetrieveDataWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRAuthDataResultCallback _Nullable)completion;
		[Obsolete ("Please, use Link method instead.")]
		[Async]
		[Export ("linkAndRetrieveDataWithCredential:completion:")]
		void LinkAndRetrieveData (AuthCredential credential, [NullAllowed] AuthDataResultHandler completion);

		// -(void)linkWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRAuthDataResultCallback _Nullable)completion;
		[Async]
		[Export ("linkWithCredential:completion:")]
		void Link (AuthCredential credential, [NullAllowed] AuthDataResultHandler completion);

		// -(void)linkWithProvider:(id<FIRFederatedAuthProvider> _Nonnull)provider UIDelegate:(id<FIRAuthUIDelegate> _Nullable)UIDelegate completion:(FIRAuthDataResultCallback _Nullable)completion __attribute__((swift_name("link(with:uiDelegate:completion:)"))) __attribute__((availability(ios, introduced=8.0)));
		[iOS (8,0)]
		[Async]
		[Export ("linkWithProvider:UIDelegate:completion:")]
		void Link (FederatedAuthProvider provider, [NullAllowed] AuthUIDelegate @delegate, [NullAllowed] AuthDataResultHandler completion);

		// -(void)unlinkFromProvider:(NSString * _Nonnull)provider completion:(FIRAuthResultCallback _Nullable)completion;
		[Async]
		[Export ("unlinkFromProvider:completion:")]
		void Unlink (string providerId, [NullAllowed] AuthResultHandler completion);

		// -(void)sendEmailVerificationWithCompletion:(FIRSendEmailVerificationCallback _Nullable)completion;
		[Async]
		[Export ("sendEmailVerificationWithCompletion:")]
		void SendEmailVerification ([NullAllowed] SendEmailVerificationHandler completion);

		// - (void)sendEmailVerificationWithActionCodeSettings:(FIRActionCodeSettings *)actionCodeSettings completion:(nullable FIRSendEmailVerificationCallback)completion;
		[Async]
		[Export ("sendEmailVerificationWithActionCodeSettings:completion:")]
		void SendEmailVerification (ActionCodeSettings actionCodeSettings, [NullAllowed] SendEmailVerificationHandler completion);

		// -(void)deleteWithCompletion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Async]
		[Export ("deleteWithCompletion:")]
		void Delete ([NullAllowed] UserProfileChangeHandler completion);

		// -(void)sendEmailVerificationBeforeUpdatingEmail:(NSString * _Nonnull)email completion:(FIRAuthVoidErrorCallback _Nullable)completion;
		[Async]
		[Export ("sendEmailVerificationBeforeUpdatingEmail:completion:")]
		void SendEmailVerificationBeforeUpdatingEmail (string email, [NullAllowed] AuthVoidErrorHandler completion);

		// -(void)sendEmailVerificationBeforeUpdatingEmail:(NSString * _Nonnull)email actionCodeSettings:(FIRActionCodeSettings * _Nonnull)actionCodeSettings completion:(FIRAuthVoidErrorCallback _Nullable)completion;
		[Async]
		[Export ("sendEmailVerificationBeforeUpdatingEmail:actionCodeSettings:completion:")]
		void SendEmailVerificationBeforeUpdatingEmail (string email, ActionCodeSettings actionCodeSettings, [NullAllowed] AuthVoidErrorHandler completion);
	}

	// @interface FIRUserProfileChangeRequest : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRUserProfileChangeRequest")]
	interface UserProfileChangeRequest
	{
		// @property (copy, nonatomic) NSString * _Nullable displayName;
		[NullAllowed]
		[Export ("displayName")]
		string DisplayName { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable photoURL;
		[NullAllowed]
		[Export ("photoURL", ArgumentSemantic.Copy)]
		NSUrl PhotoUrl { get; set; }

		// -(void)commitChangesWithCompletion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Async]
		[Export ("commitChangesWithCompletion:")]
		void CommitChanges ([NullAllowed] UserProfileChangeHandler completion);
	}

	interface IUserInfo
	{
	}

	// @protocol FIRUserInfo <NSObject>
	[Protocol (Name = "FIRUserInfo")]
	interface UserInfo
	{
		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull providerID;
		[Abstract]
		[Export ("providerID")]
		string ProviderId { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull uid;
		[Abstract]
		[Export ("uid")]
		string Uid { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable displayName;
		[Abstract]
		[NullAllowed]
		[Export ("displayName")]
		string DisplayName { get; }

		// @required @property (readonly, copy, nonatomic) NSURL * _Nullable photoURL;
		[Abstract]
		[NullAllowed]
		[Export ("photoURL", ArgumentSemantic.Copy)]
		NSUrl PhotoUrl { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[Abstract]
		[NullAllowed]
		[Export ("email")]
		string Email { get; }

		// @required @property (readonly, nonatomic) NSString * _Nullable phoneNumber;
		[Abstract]
		[NullAllowed]
		[Export ("phoneNumber")]
		string PhoneNumber { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRUserMetadata")]
	interface UserMetadata
	{
		// @property (readonly, copy, nonatomic) NSDate * _Nullable lastSignInDate;
		[NullAllowed]
		[Export ("lastSignInDate", ArgumentSemantic.Copy)]
		NSDate LastSignInDate { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nullable creationDate;
		[NullAllowed]
		[Export ("creationDate", ArgumentSemantic.Copy)]
		NSDate CreationDate { get; }
	}
}
