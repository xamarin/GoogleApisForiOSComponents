using System;
using System.Collections.Generic;

using Foundation;
using ObjCRuntime;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Firebase.AppDistribution
{
	// (void (^)(NSError *_Nullable error))completion
	delegate void ErrorHandler ([NullAllowed] NSError error);

	// (void (^)(FIRAppDistributionRelease *_Nullable release, NSError *_Nullable error))completion
	delegate void AppDistributionReleaseHandler ([NullAllowed] AppDistributionRelease release, [NullAllowed] NSError error);

	// @interface FIRAppDistribution : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAppDistribution")]
	interface AppDistribution
	{
		// NSString *const FIRAppDistributionErrorDomain
		[Field ("FIRAppDistributionErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// NSString *const FIRAppDistributionErrorDetailsKey
		[Field ("FIRAppDistributionErrorDetailsKey", "__Internal")]
		NSString ErrorDetailsKey { get; }

		// + (instancetype)appDistribution
		[Static]
		[Export("appDistribution")]
		AppDistribution SharedInstance { get; }

		// @property(nonatomic, readonly) BOOL isTesterSignedIn;
		[Export ("isTesterSignedIn")]
		bool IsTesterSignedIn { get; }

		// - (void)signInTesterWithCompletion: (void (^)(NSError *_Nullable error))completion
		[Export ("signInTesterWithCompletion:")]
		void SigInTester (ErrorHandler completion);

		// - (void)checkForUpdateWithCompletion: (void (^)(FIRAppDistributionRelease *_Nullable release, NSError *_Nullable error))completion;
		[Export ("checkForUpdateWithCompletion:")]
		void SigInTester (AppDistributionReleaseHandler completion);

		// - (void)signOutTester;
		[Export ("signOutTester:")]
		void SignOutTester ();
	}

	// @interface FIRAppDistributionRelease : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAppDistributionRelease")]
	interface Release
	{
		// @property(nonatomic, copy, readonly) NSString *displayVersion;
		[Export ("displayVersion")]
		string DisplayVersion { get; }

		// @property(nonatomic, copy, readonly) NSString *buildVersion;
		[Export ("buildVersion")]
		string BuildVersion { get; }

		// @property(nonatomic, copy, readonly) NSString *releaseNotes;
		[Export ("releaseNotes")]
		string ReleaseNotes { get; }

		// @property(nonatomic, strong, readonly) NSURL *downloadURL;
		[Export ("displayVersion")]
		NSURL DownloadUrl { get; }

		// @property(nonatomic, readonly) BOOL isExpired;
		[Export ("isExpired")]
		bool IsExpired { get; }
	}
}
