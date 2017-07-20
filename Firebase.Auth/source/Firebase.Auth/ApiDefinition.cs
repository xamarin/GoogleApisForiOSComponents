using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.Auth
{
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

	// typedef void (^FIRSendPasswordResetCallback)(NSError * _Nullable);
	delegate void SendPasswordResetHandler ([NullAllowed] NSError error);

	// typedef void (^FIRConfirmPasswordResetCallback)(NSError * _Nullable);
	delegate void ConfirmPasswordResetHandler ([NullAllowed] NSError erorr);

	// typedef void (^FIRVerifyPasswordResetCodeCallback)(NSString * _Nullable, NSError * _Nullable);
	delegate void VerifyPasswordResetCodeHandler ([NullAllowed] string email, [NullAllowed] NSError error);

	// typedef void (^FIRApplyActionCodeCallback)(NSError * _Nullable);
	delegate void ApplyActionCodeHandler ([NullAllowed] NSError error);

	// @interface FIRActionCodeInfo : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRActionCodeInfo")]
	interface ActionCodeInfo
	{
		// @property (readonly, nonatomic) FIRActionCodeOperation operation;
		[Export ("operation")]
		ActionCodeOperation Operation { get; }

		// -(NSString * _Nonnull)dataForKey:(FIRActionDataKey)key;
		[Export ("dataForKey:")]
		string DataForKey (ActionDataKey key);
	}

	// typedef void (^FIRCheckActionCodeCallBack)(FIRActionCodeInfo * _Nullable, NSError * _Nullable);
	delegate void CheckActionCodeHandler ([NullAllowed] ActionCodeInfo info, [NullAllowed] NSError error);

	// @interface FIRAuth : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAuth")]
	interface Auth
	{
		// extern const double FirebaseAuthVersionNumber;
		[Field ("FirebaseAuthVersionNumber", "__Internal")]
		double CurrentVersionNumber { get; }

		// extern const unsigned char *const FirebaseAuthVersionString;
		[Internal]
		[Field ("FirebaseAuthVersionString", "__Internal")]
		IntPtr _CurrentVersion { get; }

		// extern NSString *const FIRAuthErrorDomain;
		[Field ("FIRAuthErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// extern NSString *const FIRAuthUpdatedCredentialKey;
		[Field ("FIRAuthUpdatedCredentialKey", "__Internal")]
		NSString UpdatedCredentialKey { get; }

		// extern NSString *const FIRAuthErrorNameKey;
		[Field ("FIRAuthErrorNameKey", "__Internal")]
		NSString ErrorNameKey { get; }

		// extern NSString *const FIRAuthErrorUserInfoEmailKey;
		[Field ("FIRAuthErrorUserInfoEmailKey", "__Internal")]
		NSString ErrorUserInfoEmailKey { get; }

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

		[NullAllowed]
		[Export ("APNSToken", ArgumentSemantic.Strong)]
		NSData ApnsToken { get; set; }

		// -(void)fetchProvidersForEmail:(NSString * _Nonnull)email completion:(FIRProviderQueryCallback _Nullable)completion;
		[Export ("fetchProvidersForEmail:completion:")]
		void FetchProviders (string email, [NullAllowed] ProviderQueryHandler completion);

		// -(void)signInWithEmail:(NSString * _Nonnull)email password:(NSString * _Nonnull)password completion:(FIRAuthResultCallback _Nullable)completion;
		[Export ("signInWithEmail:password:completion:")]
		void SignIn (string email, string password, [NullAllowed] AuthResultHandler completion);

		// -(void)signInWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRAuthResultCallback _Nullable)completion;
		[Export ("signInWithCredential:completion:")]
		void SignIn (AuthCredential credential, [NullAllowed] AuthResultHandler completion);

		// - (void)signInAndRetrieveDataWithCredential:(FIRAuthCredential *)credential completion:(nullable FIRAuthDataResultCallback) completion;
		[Export ("signInAndRetrieveDataWithCredential:completion:")]
		void SignInAndRetrieveData (AuthCredential credential, [NullAllowed] AuthDataResultHandler completion);

		// -(void)signInAnonymouslyWithCompletion:(FIRAuthResultCallback _Nullable)completion;
		[Export ("signInAnonymouslyWithCompletion:")]
		void SignInAnonymously ([NullAllowed] AuthResultHandler completion);

		// -(void)signInWithCustomToken:(NSString * _Nonnull)token completion:(FIRAuthResultCallback _Nullable)completion;
		[Export ("signInWithCustomToken:completion:")]
		void SignIn (string token, [NullAllowed] AuthResultHandler completion);

		// -(void)createUserWithEmail:(NSString * _Nonnull)email password:(NSString * _Nonnull)password completion:(FIRAuthResultCallback _Nullable)completion;
		[Export ("createUserWithEmail:password:completion:")]
		void CreateUser (string email, string password, [NullAllowed] AuthResultHandler completion);

		// -(void)confirmPasswordResetWithCode:(NSString * _Nonnull)code newPassword:(NSString * _Nonnull)newPassword completion:(FIRConfirmPasswordResetCallback _Nonnull)completion;
		[Export ("confirmPasswordResetWithCode:newPassword:completion:")]
		void ConfirmPasswordReset (string code, string newPassword, ConfirmPasswordResetHandler completion);

		// -(void)checkActionCode:(NSString * _Nonnull)code completion:(FIRCheckActionCodeCallBack _Nonnull)completion;
		[Export ("checkActionCode:completion:")]
		void CheckActionCode (string code, CheckActionCodeHandler completion);

		// -(void)verifyPasswordResetCode:(NSString * _Nonnull)code completion:(FIRVerifyPasswordResetCodeCallback _Nonnull)completion;
		[Export ("verifyPasswordResetCode:completion:")]
		void VerifyPasswordResetCode (string code, VerifyPasswordResetCodeHandler completion);

		// -(void)applyActionCode:(NSString * _Nonnull)code completion:(FIRApplyActionCodeCallback _Nonnull)completion;
		[Export ("applyActionCode:completion:")]
		void ApplyActionCode (string code, ApplyActionCodeHandler completion);

		// -(void)sendPasswordResetWithEmail:(NSString * _Nonnull)email completion:(FIRSendPasswordResetCallback _Nullable)completion;
		[Export ("sendPasswordResetWithEmail:completion:")]
		void SendPasswordReset (string email, [NullAllowed] SendPasswordResetHandler completion);

		// -(BOOL)signOut:(NSError * _Nullable * _Nullable)error;
		[Export ("signOut:")]
		bool SignOut ([NullAllowed] out NSError error);

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

		// -(void)setAPNSToken:(NSData * _Nonnull)token type:(FIRAuthAPNSTokenType)type;
		[Export ("setAPNSToken:type:")]
		void SetApnsToken (NSData token, AuthApnsTokenType type);

		// -(BOOL)canHandleNotification:(NSDictionary * _Nonnull)userInfo;
		[Export ("canHandleNotification:")]
		bool CanHandleNotification (NSDictionary userInfo);
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
		[NullAllowed, Export ("additionalUserInfo")]
		AdditionalUserInfo AdditionalUserInfo { get; }
	}

	// @interface FIREmailAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIREmailAuthProvider")]
	interface EmailAuthProvider
	{
		// extern NSString *const _Nonnull FIREmailAuthProviderID;
		[Field ("FIREmailAuthProviderID", "__Internal")]
		NSString Id { get; }

		// extern NSString *const _Nonnull FIREmailPasswordAuthProviderID __attribute__((deprecated("")));
		[Obsolete ("Use Id property instead.")]
		[Field ("FIREmailPasswordAuthProviderID", "__Internal")]
		NSString EmailPasswordAuthProviderId { get; }

		// +(FIRAuthCredential * _Nonnull)credentialWithEmail:(NSString * _Nonnull)email password:(NSString * _Nonnull)password;
		[Static]
		[Export ("credentialWithEmail:password:")]
		AuthCredential GetCredential (string email, string password);
	}

	// @interface FIRFacebookAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRFacebookAuthProvider")]
	interface FacebookAuthProvider
	{
		// extern NSString *const _Nonnull FIRFacebookAuthProviderID;
		[Field ("FIRFacebookAuthProviderID", "__Internal")]
		NSString Id { get; }

		// +(FIRAuthCredential * _Nonnull)credentialWithAccessToken:(NSString * _Nonnull)accessToken;
		[Static]
		[Export ("credentialWithAccessToken:")]
		AuthCredential GetCredential (string accessToken);
	}

	// @interface FIRGitHubAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRGitHubAuthProvider")]
	interface GitHubAuthProvider
	{
		// extern NSString *const _Nonnull FIRGitHubAuthProviderID;
		[Field ("FIRGitHubAuthProviderID", "__Internal")]
		NSString Id { get; }

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

		// +(FIRAuthCredential * _Nonnull)credentialWithIDToken:(NSString * _Nonnull)IDToken accessToken:(NSString * _Nonnull)accessToken;
		[Static]
		[Export ("credentialWithIDToken:accessToken:")]
		AuthCredential GetCredential (string idToken, string accessToken);
	}

	// @interface FIROAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIROAuthProvider")]
	interface OAuthProvider
	{
		// +(FIRAuthCredential * _Nonnull)credentialWithProviderID:(NSString * _Nonnull)providerID IDToken:(NSString * _Nonnull)IDToken accessToken:(NSString * _Nullable)accessToken;
		[Static]
		[Export ("credentialWithProviderID:IDToken:accessToken:")]
		AuthCredential GetCredential (string providerId, string IdToken, [NullAllowed] string accessToken);

		// +(FIRAuthCredential * _Nonnull)credentialWithProviderID:(NSString * _Nonnull)providerID accessToken:(NSString * _Nonnull)accessToken;
		[Static]
		[Export ("credentialWithProviderID:accessToken:")]
		AuthCredential GetCredential (string providerId, string accessToken);
	}

	// @interface FIRPhoneAuthCredential : FIRAuthCredential
	[DisableDefaultCtor]
	[BaseType (typeof (AuthCredential), Name = "FIRPhoneAuthCredential")]
	interface PhoneAuthCredential
	{
	}

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

		// +(instancetype _Nonnull)provider;
		[Static]
		[Export ("provider")]
		PhoneAuthProvider GetProvider ();

		// +(instancetype _Nonnull)providerWithAuth:(FIRAuth * _Nonnull)auth;
		[Static]
		[Export ("providerWithAuth:")]
		PhoneAuthProvider GetProvider (Auth auth);

		// -(void)verifyPhoneNumber:(NSString * _Nonnull)phoneNumber completion:(FIRVerificationResultCallback _Nullable)completion;
		[Export ("verifyPhoneNumber:completion:")]
		void VerifyPhoneNumber (string phoneNumber, [NullAllowed] VerificationResultHandler completion);

		// -(FIRPhoneAuthCredential * _Nonnull)credentialWithVerificationID:(NSString * _Nonnull)verificationID verificationCode:(NSString * _Nonnull)verificationCode;
		[Export ("credentialWithVerificationID:verificationCode:")]
		PhoneAuthCredential GetCredential (string verificationId, string verificationCode);
	}

	// @interface FIRTwitterAuthProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRTwitterAuthProvider")]
	interface TwitterAuthProvider
	{
		// extern NSString *const _Nonnull FIRTwitterAuthProviderID;
		[Field ("FIRTwitterAuthProviderID", "__Internal")]
		NSString Id { get; }

		// +(FIRAuthCredential * _Nonnull)credentialWithToken:(NSString * _Nonnull)token secret:(NSString * _Nonnull)secret;
		[Static]
		[Export ("credentialWithToken:secret:")]
		AuthCredential GetCredential (string token, string secret);
	}

	// typedef void (^FIRAuthTokenCallback)(NSString * _Nullable, NSError * _Nullable);
	delegate void AuthTokenHandler ([NullAllowed] string token, [NullAllowed] NSError error);

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

		// -(void)updateEmail:(NSString * _Nonnull)email completion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Export ("updateEmail:completion:")]
		void UpdateEmail (string email, [NullAllowed] UserProfileChangeHandler completion);

		// -(void)updatePassword:(NSString * _Nonnull)password completion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Export ("updatePassword:completion:")]
		void UpdatePassword (string password, [NullAllowed] UserProfileChangeHandler completion);

		// -(void)updatePhoneNumberCredential:(FIRPhoneAuthCredential * _Nonnull)phoneNumberCredential completion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Export ("updatePhoneNumberCredential:completion:")]
		void UpdatePhoneNumberCredential (PhoneAuthCredential phoneNumberCredential, [NullAllowed] UserProfileChangeHandler completion);

		// -(FIRUserProfileChangeRequest * _Nonnull)profileChangeRequest;
		[Export ("profileChangeRequest")]
		UserProfileChangeRequest ProfileChangeRequest ();

		// -(void)reloadWithCompletion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Export ("reloadWithCompletion:")]
		void Reload ([NullAllowed] UserProfileChangeHandler completion);

		// -(void)reauthenticateWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Export ("reauthenticateWithCredential:completion:")]
		void Reauthenticate (AuthCredential credential, [NullAllowed] UserProfileChangeHandler completion);

		// -(void)reauthenticateAndRetrieveDataWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRAuthDataResultCallback _Nullable)completion;
		[Export ("reauthenticateAndRetrieveDataWithCredential:completion:")]
		void ReauthenticateAndRetrieveData (AuthCredential credential, [NullAllowed] AuthDataResultHandler completion);

		// -(void)getIDTokenWithCompletion:(FIRAuthTokenCallback _Nullable)completion;
		[Export ("getIDTokenWithCompletion:")]
		void GetIdToken ([NullAllowed] AuthTokenHandler completion);

		// -(void)getTokenWithCompletion:(FIRAuthTokenCallback _Nullable)completion;
		[Obsolete ("Use GetIdToken (AuthTokenHandler) method instead.")]
		[Export ("getTokenWithCompletion:")]
		void GetToken ([NullAllowed] AuthTokenHandler completion);

		// -(void)getIDTokenForcingRefresh:(BOOL)forceRefresh completion:(FIRAuthTokenCallback _Nullable)completion;
		[Export ("getIDTokenForcingRefresh:completion:")]
		void GetIdToken (bool forceRefresh, [NullAllowed] AuthTokenHandler completion);

		// -(void)getTokenForcingRefresh:(BOOL)forceRefresh completion:(FIRAuthTokenCallback _Nullable)completion;
		[Obsolete ("Use GetIdToken (bool, AuthTokenHandler) method instead.")]
		[Export ("getTokenForcingRefresh:completion:")]
		void GetToken (bool forceRefresh, [NullAllowed] AuthTokenHandler completion);

		// -(void)linkWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRAuthResultCallback _Nullable)completion;
		[Export ("linkWithCredential:completion:")]
		void Link (AuthCredential credential, [NullAllowed] AuthResultHandler completion);

		// -(void)linkAndRetrieveDataWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRAuthDataResultCallback _Nullable)completion;
		[Export ("linkAndRetrieveDataWithCredential:completion:")]
		void LinkAndRetrieveData (AuthCredential credential, [NullAllowed] AuthDataResultHandler completion);

		// -(void)unlinkFromProvider:(NSString * _Nonnull)provider completion:(FIRAuthResultCallback _Nullable)completion;
		[Export ("unlinkFromProvider:completion:")]
		void Unlink (string providerId, [NullAllowed] AuthResultHandler completion);

		// -(void)sendEmailVerificationWithCompletion:(FIRSendEmailVerificationCallback _Nullable)completion;
		[Export ("sendEmailVerificationWithCompletion:")]
		void SendEmailVerification ([NullAllowed] SendEmailVerificationHandler completion);

		// -(void)deleteWithCompletion:(FIRUserProfileChangeCallback _Nullable)completion;
		[Export ("deleteWithCompletion:")]
		void Delete ([NullAllowed] UserProfileChangeHandler completion);
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
		[Export ("commitChangesWithCompletion:")]
		void CommitChanges ([NullAllowed] UserProfileChangeHandler completion);
	}

	interface IUserInfo
	{
	}

	// @protocol FIRUserInfo <NSObject>
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FIRUserInfo")]
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
}
