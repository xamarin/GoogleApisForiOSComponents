using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.DynamicLinks
{
	// typedef void (^FIRDynamicLinkShortenerCompletion)(NSURL * _Nullable, NSArray<NSString *> * _Nullable, NSError * _Nullable);
	delegate void DynamicLinkShortenerCompletionHandle ([NullAllowed] NSUrl shortUrl, [NullAllowed] string [] warnings, [NullAllowed] NSError error);

	// @interface FIRDynamicLinkGoogleAnalyticsParameters : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDynamicLinkGoogleAnalyticsParameters")]
	interface DynamicLinkGoogleAnalyticsParameters
	{
		// @property (copy, nonatomic) NSString * _Nullable source;
		[NullAllowed]
		[Export ("source")]
		string Source { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable medium;
		[NullAllowed]
		[Export ("medium")]
		string Medium { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable campaign;
		[NullAllowed]
		[Export ("campaign")]
		string Campaign { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable term;
		[NullAllowed]
		[Export ("term")]
		string Term { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable content;
		[NullAllowed]
		[Export ("content")]
		string Content { get; set; }

		// +(instancetype _Nonnull)parametersWithSource:(NSString * _Nonnull)source medium:(NSString * _Nonnull)medium campaign:(NSString * _Nonnull)campaign;
		[Static]
		[Export ("parametersWithSource:medium:campaign:")]
		DynamicLinkGoogleAnalyticsParameters FromSource (string source, string medium, string campaign);

		// +(instancetype _Nonnull)parameters;
		[Static]
		[Export ("parameters")]
		DynamicLinkGoogleAnalyticsParameters Create ();

		// -(instancetype _Nonnull)initWithSource:(NSString * _Nonnull)source medium:(NSString * _Nonnull)medium campaign:(NSString * _Nonnull)campaign;
		[Export ("initWithSource:medium:campaign:")]
		IntPtr Constructor (string source, string medium, string campaign);
	}

	// @interface FIRDynamicLinkIOSParameters : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDynamicLinkIOSParameters")]
	interface DynamicLinkiOSParameters
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable bundleID;
		[NullAllowed]
		[Export ("bundleID")]
		string BundleId { get; }

		// @property (copy, nonatomic) NSString * _Nullable appStoreID;
		[NullAllowed]
		[Export ("appStoreID")]
		string AppStoreId { get; set; }

		// @property (nonatomic) NSURL * _Nullable fallbackURL;
		[NullAllowed]
		[Export ("fallbackURL", ArgumentSemantic.Assign)]
		NSUrl FallbackUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customScheme;
		[NullAllowed]
		[Export ("customScheme")]
		string CustomScheme { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable iPadBundleID;
		[NullAllowed]
		[Export ("iPadBundleID")]
		string IPadBundleId { get; set; }

		// @property (nonatomic) NSURL * _Nullable iPadFallbackURL;
		[NullAllowed]
		[Export ("iPadFallbackURL", ArgumentSemantic.Assign)]
		NSUrl IPadFallbackUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable minimumAppVersion;
		[NullAllowed]
		[Export ("minimumAppVersion")]
		string MinimumAppVersion { get; set; }

		// +(instancetype _Nonnull)parametersWithBundleID:(NSString * _Nonnull)bundleID;
		[Static]
		[Export ("parametersWithBundleID:")]
		DynamicLinkiOSParameters FromBundleId (string bundleId);

		// -(instancetype _Nonnull)initWithBundleID:(NSString * _Nonnull)bundleID;
		[Export ("initWithBundleID:")]
		IntPtr Constructor (string bundleId);
	}

	[BaseType (typeof (NSObject), Name = "FIRDynamicLinkItunesConnectAnalyticsParameters")]
	interface DynamicLinkiTunesConnectAnalyticsParameters
	{
		// @property (copy, nonatomic) NSString * _Nullable affiliateToken;
		[NullAllowed]
		[Export ("affiliateToken")]
		string AffiliateToken { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable campaignToken;
		[NullAllowed]
		[Export ("campaignToken")]
		string CampaignToken { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable providerToken;
		[NullAllowed]
		[Export ("providerToken")]
		string ProviderToken { get; set; }

		// +(instancetype _Nonnull)parameters;
		[Static]
		[Export ("parameters")]
		DynamicLinkiTunesConnectAnalyticsParameters Create ();
	}

	// @interface FIRDynamicLinkAndroidParameters : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDynamicLinkAndroidParameters")]
	interface DynamicLinkAndroidParameters
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable packageName;
		[NullAllowed]
		[Export ("packageName")]
		string PackageName { get; }

		// @property (nonatomic) NSURL * _Nullable fallbackURL;
		[NullAllowed]
		[Export ("fallbackURL", ArgumentSemantic.Assign)]
		NSUrl FallbackUrl { get; set; }

		// @property (nonatomic) NSInteger minimumVersion;
		[Export ("minimumVersion")]
		nint MinimumVersion { get; set; }

		// +(instancetype _Nonnull)parametersWithPackageName:(NSString * _Nonnull)packageName;
		[Static]
		[Export ("parametersWithPackageName:")]
		DynamicLinkAndroidParameters FromPackageName (string packageName);

		// -(instancetype _Nonnull)initWithPackageName:(NSString * _Nonnull)packageName;
		[Export ("initWithPackageName:")]
		IntPtr Constructor (string packageName);
	}

	// @interface FIRDynamicLinkSocialMetaTagParameters : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDynamicLinkSocialMetaTagParameters")]
	interface DynamicLinkSocialMetaTagParameters
	{
		// @property (copy, nonatomic) NSString * _Nullable title;
		[NullAllowed, Export ("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable descriptionText;
		[NullAllowed, Export ("descriptionText")]
		string DescriptionText { get; set; }

		// @property (nonatomic) NSURL * _Nullable imageURL;
		[NullAllowed, Export ("imageURL", ArgumentSemantic.Assign)]
		NSUrl ImageUrl { get; set; }

		// +(instancetype _Nonnull)parameters;
		[Static]
		[Export ("parameters")]
		DynamicLinkSocialMetaTagParameters Create ();
	}

	// @interface FIRDynamicLinkNavigationInfoParameters : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDynamicLinkNavigationInfoParameters")]
	interface DynamicLinkNavigationInfoParameters
	{
		// @property (getter = isForcedRedirectEnabled, nonatomic) BOOL forcedRedirectEnabled;
		[Export ("forcedRedirectEnabled")]
		bool ForcedRedirectEnabled { [Bind ("isForcedRedirectEnabled")] get; set; }

		// +(instancetype _Nonnull)parameters;
		[Static]
		[Export ("parameters")]
		DynamicLinkNavigationInfoParameters Create ();
	}

	// @interface FIRDynamicLinkOtherPlatformParameters : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDynamicLinkOtherPlatformParameters")]
	interface DynamicLinkOtherPlatformParameters
	{
		// @property (nonatomic) NSURL * _Nullable fallbackUrl;
		[NullAllowed, Export ("fallbackUrl", ArgumentSemantic.Assign)]
		NSUrl FallbackUrl { get; set; }

		// +(instancetype _Nonnull)parameters;
		[Static]
		[Export ("parameters")]
		DynamicLinkOtherPlatformParameters Create ();
	}

	// @interface FIRDynamicLinkComponentsOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDynamicLinkComponentsOptions")]
	interface DynamicLinkComponentsOptions
	{
		// @property (nonatomic) FIRShortDynamicLinkPathLength pathLength;
		[Export ("pathLength", ArgumentSemantic.Assign)]
		ShortDynamicLinkPathLength PathLength { get; set; }

		// +(instancetype _Nonnull)options;
		[Static]
		[Export ("options")]
		DynamicLinkComponentsOptions Create ();
	}

	// @interface FIRDynamicLinkComponents : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDynamicLinkComponents")]
	interface DynamicLinkComponents
	{
		// @property (nonatomic) FIRDynamicLinkGoogleAnalyticsParameters * _Nullable analyticsParameters;
		[NullAllowed]
		[Export ("analyticsParameters", ArgumentSemantic.Assign)]
		DynamicLinkGoogleAnalyticsParameters AnalyticsParameters { get; set; }

		// @property (nonatomic) FIRDynamicLinkSocialMetaTagParameters * _Nullable socialMetaTagParameters;
		[NullAllowed]
		[Export ("socialMetaTagParameters", ArgumentSemantic.Assign)]
		DynamicLinkSocialMetaTagParameters SocialMetaTagParameters { get; set; }

		// @property (nonatomic) FIRDynamicLinkIOSParameters * _Nullable iOSParameters;
		[NullAllowed]
		[Export ("iOSParameters", ArgumentSemantic.Assign)]
		DynamicLinkiOSParameters IOSParameters { get; set; }

		// @property (nonatomic) FIRDynamicLinkItunesConnectAnalyticsParameters * _Nullable iTunesConnectParameters;
		[NullAllowed]
		[Export ("iTunesConnectParameters", ArgumentSemantic.Assign)]
		DynamicLinkiTunesConnectAnalyticsParameters ITunesConnectParameters { get; set; }

		// @property (nonatomic) FIRDynamicLinkAndroidParameters * _Nullable androidParameters;
		[NullAllowed]
		[Export ("androidParameters", ArgumentSemantic.Assign)]
		DynamicLinkAndroidParameters AndroidParameters { get; set; }

		// @property (nonatomic) FIRDynamicLinkNavigationInfoParameters * _Nullable navigationInfoParameters;
		[NullAllowed]
		[Export ("navigationInfoParameters", ArgumentSemantic.Assign)]
		DynamicLinkNavigationInfoParameters NavigationInfoParameters { get; set; }

		// @property(nonatomic, nullable) FIRDynamicLinkOtherPlatformParameters *otherPlatformParameters;
		[NullAllowed]
		[Export ("otherPlatformParameters", ArgumentSemantic.Assign)]
		DynamicLinkOtherPlatformParameters OtherPlatformParameters { get; set; }

		// @property (nonatomic) FIRDynamicLinkComponentsOptions * _Nullable options;
		[NullAllowed]
		[Export ("options", ArgumentSemantic.Assign)]
		DynamicLinkComponentsOptions Options { get; set; }

		// @property (nonatomic) NSURL * _Nonnull link;
		[Export ("link", ArgumentSemantic.Assign)]
		NSUrl Link { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable domain;
		[NullAllowed]
		[Export ("domain")]
		string Domain { get; set; }

		// @property (readonly, nonatomic) NSURL * _Nullable url;
		[NullAllowed]
		[Export ("url")]
		NSUrl Url { get; }

		// +(instancetype _Nullable)componentsWithLink:(NSURL * _Nonnull)link domainURIPrefix:(NSString * _Nonnull)domainURIPrefix __attribute__((availability(swift, unavailable)));
		[Static]
		[return: NullAllowed]
		[Export ("componentsWithLink:domainURIPrefix:")]
		DynamicLinkComponents Create (NSUrl link, string domainUriPrefix);

		[Obsolete("Use the Create static method instead. This will be removed in future versions.")]
		[Static]
		[return: NullAllowed]
		[Wrap ("Create (link, domainUriPrefix)")]
		DynamicLinkComponents FromLink (NSUrl link, string domainUriPrefix);

		// -(instancetype _Nonnull)initWithLink:(NSURL * _Nonnull)link domain:(NSString * _Nonnull)domain;
		[Export ("initWithLink:domainURIPrefix:")]
		IntPtr Constructor (NSUrl link, string domainUriPrefix);

		// +(void)shortenURL:(NSURL * _Nonnull)url options:(FIRDynamicLinkComponentsOptions * _Nullable)options completion:(FIRDynamicLinkShortenerCompletion _Nonnull)completion;
		[Static]
		[Async (ResultTypeName = "DynamicLinkShortenerResult")]
		[Export ("shortenURL:options:completion:")]
		void GetShortenUrl (NSUrl url, [NullAllowed] DynamicLinkComponentsOptions options, DynamicLinkShortenerCompletionHandle completion);

		// -(void)shortenWithCompletion:(FIRDynamicLinkShortenerCompletion _Nonnull)completion;
		[Async (ResultTypeName = "DynamicLinkShortenerResult")]
		[Export ("shortenWithCompletion:")]
		void GetShortenUrl (DynamicLinkShortenerCompletionHandle completion);
	}

	// @interface FIRDynamicLink : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRDynamicLink")]
	interface DynamicLink
	{
		// @property (readonly, copy, nonatomic) NSURL * _Nullable url;
		[NullAllowed]
		[Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		// @property (readonly, assign, nonatomic) FIRDLMatchType matchType;
		[Export ("matchType", ArgumentSemantic.Assign)]
		DynamicLinkMatchType MatchType { get; }

		// @property(nonatomic, copy, readonly, nullable) NSString *minimumAppVersion;
		[NullAllowed]
		[Export ("minimumAppVersion")]
		string MinimumAppVersion { get; }
	}

	// typedef void (^FIRDynamicLinkResolverHandler)(NSURL * _Nullable url, NSError * _Nullable error);
	delegate void DynamicLinkResolverHandler ([NullAllowed] NSUrl url, [NullAllowed] NSError error);

	// typedef void (^FIRDynamicLinkUniversalLinkHandler)(FIRDynamicLink * _Nullable dynamicLink, NSError* _Nullable error);
	delegate void DynamicLinkUniversalLinkHandler ([NullAllowed] DynamicLink dynamicLink, [NullAllowed] NSError error);

	// void (^_Nullable)(NSString *diagnosticOutput, BOOL hasErrors)
	delegate void DynamicLinkDiagnosticOutputHandler (string diagnosticOutput, bool hasErrors);

	// @interface FIRDynamicLinks : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRDynamicLinks")]
	interface DynamicLinks
	{
		// +(instancetype _Nullable)dynamicLinks;
		[Static]
		[NullAllowed]
		[Export ("dynamicLinks")]
		DynamicLinks SharedInstance { get; }

		// -(BOOL)shouldHandleDynamicLinkFromCustomSchemeURL:(NSURL * _Nonnull)url;
		[Export ("shouldHandleDynamicLinkFromCustomSchemeURL:")]
		bool ShouldHandleDynamicLinkFromCustomSchemeUrl (NSUrl url);

		// -(FIRDynamicLink * _Nullable)dynamicLinkFromCustomSchemeURL:(NSURL * _Nonnull)url;
		[return: NullAllowed]
		[Export ("dynamicLinkFromCustomSchemeURL:")]
		DynamicLink FromCustomSchemeUrl (NSUrl url);

		// -(FIRDynamicLink * _Nullable)dynamicLinkFromUniversalLinkURL:(NSURL * _Nonnull)url;
		[return: NullAllowed]
		[Export ("dynamicLinkFromUniversalLinkURL:")]
		DynamicLink FromUniversalLinkUrl (NSUrl url);

		// -(BOOL)handleUniversalLink:(NSURL * _Nonnull)url completion:(FIRDynamicLinkUniversalLinkHandler _Nonnull)completion;
		[Async]
		[Export ("handleUniversalLink:completion:")]
		bool HandleUniversalLink (NSUrl url, DynamicLinkUniversalLinkHandler completion);

		// -(void)resolveShortLink:(NSURL * _Nonnull)url completion:(FIRDynamicLinkResolverHandler _Nonnull)completion;
		[Async]
		[Export ("resolveShortLink:completion:")]
		void ResolveShortLink (NSUrl url, DynamicLinkResolverHandler completion);

		// -(BOOL)matchesShortLinkFormat:(NSURL * _Nonnull)url;
		[Export ("matchesShortLinkFormat:")]
		bool MatchesShortLinkFormat (NSUrl url);

		// + (void)performDiagnosticsWithCompletion:(void (^_Nullable)(NSString *diagnosticOutput, BOOL hasErrors))completionHandler;
		[Static]
		[Async (ResultTypeName = "DynamicLinkDiagnosticOutputResult")]
		[Export ("performDiagnosticsWithCompletion:")]
		void PerformDiagnostics ([NullAllowed] DynamicLinkDiagnosticOutputHandler completion);
	}
}

