using System;
using System.Collections.Generic;

using Foundation;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Firebase.Installations
{
	// typedef void (^FIRInstallationsIDHandler)(NSString * _Nullable, NSError * _Nullable);
	delegate void InstallationsIdHandler ([NullAllowed] string identifier, [NullAllowed] NSError error);

	// typedef void (^FIRInstallationsTokenHandler)(FIRInstallationsAuthTokenResult * _Nullable, NSError * _Nullable);
	delegate void InstallationsTokenHandler ([NullAllowed] InstallationsAuthTokenResult tokenResult, [NullAllowed] NSError error);

	interface InstallationIdChangedEventArgs
	{
		[Export ("kFIRInstallationIDDidChangeNotificationAppNameKey")]
		string AppName { get; set; }
	}
	
	// @interface FIRInstallations : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRInstallations")]
	interface Installations
	{
		// extern const NSNotificationName _Nonnull FIRInstallationIDDidChangeNotification;
		[Notification (typeof (InstallationIdChangedEventArgs))]
		[Field ("FIRInstallationIDDidChangeNotification", "__Internal")]
		NSString InstallationIdDidChangeNotification { get; }

		// extern NSString *const _Nonnull kFIRInstallationIDDidChangeNotificationAppNameKey;
		[Field ("kFIRInstallationIDDidChangeNotificationAppNameKey", "__Internal")]
		NSString InstallationIdDidChangeNotificationAppNameKey { get; }

		// +(FIRInstallations * _Nonnull)installations __attribute__((swift_name("installations()")));
		[Static]
		[Export ("installations")]
		Installations DefaultInstance { get; }

		// +(FIRInstallations * _Nonnull)installationsWithApp:(FIRApp * _Nonnull)application __attribute__((swift_name("installations(app:)")));
		[Static]
		[Export ("installationsWithApp:")]
		Installations From (Core.App application);

		// -(void)installationIDWithCompletion:(FIRInstallationsIDHandler _Nonnull)completion;
		[Async]
		[Export ("installationIDWithCompletion:")]
		void GetInstallationId (InstallationsIdHandler completion);

		// -(void)authTokenWithCompletion:(FIRInstallationsTokenHandler _Nonnull)completion;
		[Async]
		[Export ("authTokenWithCompletion:")]
		void GetAuthToken (InstallationsTokenHandler completion);

		// -(void)authTokenForcingRefresh:(BOOL)forceRefresh completion:(FIRInstallationsTokenHandler _Nonnull)completion;
		[Async]
		[Export ("authTokenForcingRefresh:completion:")]
		void GetAuthToken (bool forceRefresh, InstallationsTokenHandler completion);

		// -(void)deleteWithCompletion:(void (^ _Nonnull)(NSError * _Nullable))completion;
		[Async]
		[Export ("deleteWithCompletion:")]
		void Delete (Action<NSError> completion);
	}

	// @interface FIRInstallationsAuthTokenResult : NSObject
	[BaseType(typeof(NSObject), Name = "FIRInstallationsAuthTokenResult")]
	interface InstallationsAuthTokenResult
	{
		// @property (readonly, nonatomic) NSString * _Nonnull authToken;
		[Export("authToken")]
		string AuthToken { get; }

		// @property (readonly, nonatomic) NSDate * _Nonnull expirationDate;
		[Export("expirationDate")]
		NSDate ExpirationDate { get; }
	}
}
