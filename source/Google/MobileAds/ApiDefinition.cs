using System;
using System.Collections.Generic;

using CoreGraphics;
using Foundation;
using ObjCRuntime;
using StoreKit;
using UIKit;

namespace Google.MobileAds {
	#region CustomLib
	// This is a custom class created by me and is not part of Google Admob lib
	// But it is necesary for this binding to work
	[Static]
	interface AdSizeCons {
		[Internal]
		[Field ("kGADAdSizeBanner", "__Internal")]
		IntPtr _Banner { get; }

		[Internal]
		[Field ("kGADAdSizeLargeBanner", "__Internal")]
		IntPtr _LargeBanner { get; }

		[Internal]
		[Field ("kGADAdSizeMediumRectangle", "__Internal")]
		IntPtr _MediumRectangle { get; }

		[Internal]
		[Field ("kGADAdSizeFullBanner", "__Internal")]
		IntPtr _FullBanner { get; }

		[Internal]
		[Field ("kGADAdSizeLeaderboard", "__Internal")]
		IntPtr _Leaderboard { get; }

		[Internal]
		[Field ("kGADAdSizeSkyscraper", "__Internal")]
		IntPtr _Skyscraper { get; }

		[Internal]
		[Field ("kGADAdSizeSmartBannerPortrait", "__Internal")]
		IntPtr _SmartBannerPortrait { get; }

		[Internal]
		[Field ("kGADAdSizeSmartBannerLandscape", "__Internal")]
		IntPtr _SmartBannerLandscape { get; }

		[Internal]
		[Field ("kGADAdSizeFluid", "__Internal")]
		IntPtr _Fluid { get; }

		[Internal]
		[Field ("kGADAdSizeInvalid", "__Internal")]
		IntPtr _Invalid { get; }
	}
	#endregion

	// typedef void (^GADInitializationCompletionHandler)(GADInitializationStatus * _Nonnull);
	delegate void InitializationCompletionHandler (InitializationStatus status);

	// @interface GADMobileAds : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GADMobileAds")]
	interface MobileAds {
		// + (GADMobileAds *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		MobileAds SharedInstance { get; }

		// @property(nonatomic, nonnull, readonly) NSString *sdkVersion;
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		// @property(nonatomic, assign) float applicationVolume;
		[Export ("applicationVolume", ArgumentSemantic.Assign)]
		float ApplicationVolume { get; set; }

		// @property(nonatomic, assign) BOOL applicationMuted;
		[Export ("applicationMuted", ArgumentSemantic.Assign)]
		bool ApplicationMuted { get; set; }

		// @property(nonatomic, readonly, strong) GADAudioVideoManager *audioVideoManager;
		[Export ("audioVideoManager", ArgumentSemantic.Strong)]
		AudioVideoManager AudioVideoManager { get; }

		// @property(nonatomic, readonly, strong) GADRequestConfiguration *requestConfiguration;
		[Export ("requestConfiguration", ArgumentSemantic.Strong)]
		RequestConfiguration RequestConfiguration { get; }

		// @property (readonly, nonatomic) GADInitializationStatus * _Nonnull initializationStatus;
		[Export ("initializationStatus")]
		InitializationStatus InitializationStatus { get; }

		// - (BOOL)isSDKVersionAtLeastMajor:(NSInteger)major minor:(NSInteger)minor patch:(NSInteger)patch;
		[Export ("isSDKVersionAtLeastMajor:minor:patch:")]
		bool IsSdkVersionAtLeast (nint major, nint minor, nint patch);

		[Obsolete ("Use IsSdkVersionAtLeast method instead. This will be removed in future versions.")]
		[Wrap ("IsSdkVersionAtLeast (major, minor, patch)")]
		bool IsSDKVersionAtLeast (nint major, nint minor, nint patch);

		// -(void)startWithCompletionHandler:(GADInitializationCompletionHandler _Nullable)completionHandler;
		[Async]
		[Export ("startWithCompletionHandler:")]
		void Start ([NullAllowed] InitializationCompletionHandler completionHandler);

		// -(void)disableAutomatedInAppPurchaseReporting;
		[Export ("disableAutomatedInAppPurchaseReporting")]
		void DisableTheAutomatedInAppPurchaseReporting ();

		// -(void)enableAutomatedInAppPurchaseReporting;
		[Export ("enableAutomatedInAppPurchaseReporting")]
		void EnableTheAutomatedInAppPurchaseReporting();

		// -(void)disableSDKCrashReporting;
		[Export ("disableSDKCrashReporting")]
		void DisableSdkCrashReporting ();

		// -(void)disableMediationInitialization;
		[Export ("disableMediationInitialization")]
		void DisableMediationInitialization ();

		// + (void)configureWithApplicationID:(NSString *)applicationID;
		[Obsolete ("Use MobileAds.SharedInstance.Start method instead.")]
		[Static]
		[Export ("configureWithApplicationID:")]
		void Configure (string applicationId);

		// +(void)disableAutomatedInAppPurchaseReporting;
		[Obsolete ("Use MobileAds.SharedInstance.DisableTheAutomatedInAppPurchaseReporting method instead.")]
		[Static]
		[Export ("disableAutomatedInAppPurchaseReporting")]
		void DisableAutomatedInAppPurchaseReporting ();

		// +(void)disableSDKCrashReporting;
		[Obsolete("Use MobileAds.SharedInstance.DisableSdkCrashReporting method instead.")]
		[Static]
		[Export ("disableSDKCrashReporting")]
		void DisableSDKCrashReporting ();
	}

	// @interface GADMultipleAdsAdLoaderOptions : GADAdLoaderOptions
	[BaseType (typeof (AdLoaderOptions), Name = "GADMultipleAdsAdLoaderOptions")]
	interface MultipleAdsAdLoaderOptions {
		// @property(nonatomic) NSInteger numberOfAds;
		[Export ("numberOfAds")]
		nint NumberOfAds { get; set; }
	}

	interface IAdNetworkExtras {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAdNetworkExtras")]
	interface AdNetworkExtras {

	}

	// @interface GADAdReward : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GADAdReward")]
	interface AdReward {
		// @property(nonatomic, readonly, nonnull) NSString *type;
		[Export ("type")]
		string Type { get; }

		// @property(nonatomic, readonly, nonnull) NSDecimalNumber *amount;
		[Export ("amount")]
		NSDecimalNumber Amount { get; }

		// -(instancetype)initWithRewardType:(NSString *)rewardType rewardAmount:(NSDecimalNumber *)rewardAmount __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithRewardType:rewardAmount:")]
		IntPtr Constructor (string rewardType, NSDecimalNumber rewardAmount);
	}

	[BaseType (typeof (UIView),
		Name = "GADBannerView",
		Delegates = new string [] { "Delegate", "AdSizeDelegate", "AppEventDelegate" },
		Events = new Type [] { typeof (BannerViewDelegate), typeof (AdSizeDelegate), typeof(AppEventDelegate) })]
	interface BannerView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (AdSize size, CGPoint origin);

		[Export ("initWithAdSize:")]
		IntPtr Constructor (AdSize size);

		[NullAllowed]
		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitId { get; set; }

		[Obsolete ("Use AdUnitId property instead. This will be removed in future versions.")]
		[NullAllowed]
		[Wrap ("AdUnitId")]
		string AdUnitID { get; set; }

		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		[Export ("adSize", ArgumentSemantic.Assign)]
		AdSize AdSize { get; set; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IBannerViewDelegate Delegate { get; set; }

		[NullAllowed]
		[Export ("appEventDelegate", ArgumentSemantic.Weak)]
		IAppEventDelegate AppEventDelegate { get; set; }

		[Obsolete]
		[NullAllowed]
		[Export ("inAppPurchaseDelegate", ArgumentSemantic.Weak)]
		IInAppPurchaseDelegate InAppPurchaseDelegate { get; set; }

		// @property(nonatomic, weak, GAD_NULLABLE) IBOutlet id<GADAdSizeDelegate> adSizeDelegate;
		[NullAllowed]
		[Export ("adSizeDelegate", ArgumentSemantic.Weak)]
		IAdSizeDelegate AdSizeDelegate { get; set; }

		[Export ("loadRequest:")]
		void LoadRequest ([NullAllowed] Request request);

		[Export ("autoloadEnabled", ArgumentSemantic.Assign)]
		bool AutoloadEnabled { [Bind ("isAutoloadEnabled")] get; set; }

		// @property (readonly, nonatomic) GADResponseInfo * _Nullable responseInfo;
		[NullAllowed]
		[Export ("responseInfo")]
		ResponseInfo ResponseInfo { get; }

		// @property (copy, nonatomic) GADPaidEventHandler _Nullable paidEventHandler;
		[NullAllowed]
		[Export ("paidEventHandler", ArgumentSemantic.Copy)]
		PaidEventHandler PaidEventHandler { get; set; }

		[Obsolete]
		[Export ("hasAutoRefreshed", ArgumentSemantic.Assign)]
		bool HasAutoRefreshed { get; }

		[Obsolete ("Use ResponseInfo.AdNetworkClassName.")]
		[NullAllowed]
		[Export ("mediatedAdView", ArgumentSemantic.Weak)]
		UIView MediatedAdView { get; }

		[Obsolete ("Use ResponseInfo.AdNetworkClassName.")]
		[NullAllowed]
		[Export ("adNetworkClassName")]
		string AdNetworkClassName { get; }
	}

	interface IBannerViewDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADBannerViewDelegate")]
	interface BannerViewDelegate {

		[EventArgs ("BannerViewE")]
		[EventName ("AdReceived")]
		[Export ("adViewDidReceiveAd:")]
		void DidReceiveAd (BannerView view);

		[EventArgs ("BannerViewError")]
		[EventName ("ReceiveAdFailed")]
		[Export ("adView:didFailToReceiveAdWithError:")]
		void DidFailToReceiveAd (BannerView view, RequestError error);

		[EventArgs ("BannerViewE")]
		[EventName ("ImpressionRecorded")]
		[Export ("adViewDidRecordImpression:")]
		void DidRecordImpression (BannerView view);

		[EventArgs ("BannerViewE")]
		[Export ("adViewWillPresentScreen:")]
		void WillPresentScreen (BannerView adView);

		[EventArgs ("BannerViewE")]
		[Export ("adViewWillDismissScreen:")]
		void WillDismissScreen (BannerView adView);

		[EventArgs ("BannerViewE")]
		[EventName ("ScreenDismissed")]
		[Export ("adViewDidDismissScreen:")]
		void DidDismissScreen (BannerView adView);

		[EventArgs ("BannerViewE")]
		[Export ("adViewWillLeaveApplication:")]
		void WillLeaveApplication (BannerView adView);
	}

	[BaseType (typeof (NSObject), Name = "GADExtras")]
	interface Extras : AdNetworkExtras {

		[NullAllowed]
		[Export ("additionalParameters", ArgumentSemantic.Copy)]
		NSDictionary AdditionalParameters { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject),
		Name = "GADInterstitial",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (InterstitialDelegate) })]
	interface Interstitial {

		[Export ("initWithAdUnitID:")]
		IntPtr Constructor (string adUnitID);

		[Export ("adUnitID")]
		string AdUnitId { get; }

		[Obsolete ("Use AdUnitId property instead. This will be removed in future versions.")]
		[Wrap ("AdUnitId")]
		string AdUnitID { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IInterstitialDelegate Delegate { get; set; }

		[Obsolete]
		[NullAllowed]
		[Export ("inAppPurchaseDelegate", ArgumentSemantic.Weak)]
		IInAppPurchaseDelegate InAppPurchaseDelegate { get; set; }

		[Export ("loadRequest:")]
		void LoadRequest ([NullAllowed] Request request);

		[Export ("isReady")]
		bool IsReady { get; }

		[Export ("hasBeenUsed")]
		bool HasBeenUsed { get; }

		// @property (readonly, nonatomic) GADResponseInfo * _Nullable responseInfo;
		[NullAllowed]
		[Export ("responseInfo")]
		ResponseInfo ResponseInfo { get; }

		// @property (copy, nonatomic) GADPaidEventHandler _Nullable paidEventHandler;
		[NullAllowed]
		[Export ("paidEventHandler", ArgumentSemantic.Copy)]
		PaidEventHandler PaidEventHandler { get; set; }

		[Export ("presentFromRootViewController:")]
		void Present ([NullAllowed] UIViewController rootViewController);

		[Obsolete ("Use Present method instead. This will be removed in future versions.")]
		[Wrap ("Present (rootViewController)")]
		void PresentFromRootViewController ([NullAllowed] UIViewController rootViewController);

		// -(BOOL)canPresentFromRootViewController:(UIViewController * _Nonnull)rootViewController error:(NSError * _Nullable * _Nullable)error;
		[Export ("canPresentFromRootViewController:error:")]
		bool CanPresent (UIViewController rootViewController, [NullAllowed] out NSError error);

		[Obsolete ("Use ResponseInfo.AdNetworkClassName.")]
		[NullAllowed]
		[Export("adNetworkClassName")]
		string AdNetworkClassName { get; }
	}

	interface IInterstitialDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADInterstitialDelegate")]
	interface InterstitialDelegate {

		[EventArgs ("InterstitialE")]
		[EventName ("AdReceived")]
		[Export ("interstitialDidReceiveAd:")]
		void DidReceiveAd (Interstitial ad);

		[EventArgs ("InterstitialDidFailToReceiveAdWithError")]
		[EventName ("ReceiveAdFailed")]
		[Export ("interstitial:didFailToReceiveAdWithError:")]
		void DidFailToReceiveAd (Interstitial sender, RequestError error);

		[EventArgs ("InterstitialE")]
		[Export ("interstitialWillPresentScreen:")]
		void WillPresentScreen (Interstitial ad);

		// - (void)interstitialDidFailToPresentScreen:(GADInterstitial *)ad;
		[EventArgs ("InterstitialE")]
		[EventName ("FailedToPresentScreen")]
		[Export ("interstitialDidFailToPresentScreen:")]
		void DidFailToPresentScreen (Interstitial ad);

		[EventArgs ("InterstitialE")]
		[Export ("interstitialWillDismissScreen:")]
		void WillDismissScreen (Interstitial ad);

		[EventArgs ("InterstitialE")]
		[EventName ("ScreenDismissed")]
		[Export ("interstitialDidDismissScreen:")]
		void DidDismissScreen (Interstitial ad);

		[EventArgs ("InterstitialE")]
		[Export ("interstitialWillLeaveApplication:")]
		void WillLeaveApplication (Interstitial ad);
	}

	// @interface GADMediaContent : NSObject
	[BaseType (typeof (NSObject), Name = "GADMediaContent")]
	interface MediaContent {
		// @property (readonly, nonatomic) GADVideoController * _Nonnull videoController;
		[Export ("videoController")]
		VideoController VideoController { get; }

		// @property (readonly, nonatomic) BOOL hasVideoContent;
		[Export ("hasVideoContent")]
		bool HasVideoContent { get; }

		// @property(nonatomic, readonly) CGFloat aspectRatio;
		[Export ("aspectRatio")]
		nfloat AspectRatio { get; }

		// @property (readonly, nonatomic) NSTimeInterval duration;
		[Export("duration")]
		double Duration { get; }

		// @property (readonly, nonatomic) NSTimeInterval currentTime;
		[Export("currentTime")]
		double CurrentTime { get; }

		/// 
		/// From GADMediaContent (NativeAd) category
		/// 

		// @property (nonatomic) UIImage * _Nullable mainImage;
		[NullAllowed]
		[Export ("mainImage", ArgumentSemantic.Assign)]
		UIImage MainImage { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GADRequest")]
	interface Request : INSCopying {
		[Field ("kGADSimulatorID", "__Internal")]
		NSString SimulatorId { get; }

		[Static]
		[Export ("request")]
		Request GetDefaultRequest ();

		[Export ("registerAdNetworkExtras:")]
		void RegisterAdNetworkExtras (IAdNetworkExtras extras);

		[Export ("adNetworkExtrasFor:")]
		IAdNetworkExtras AdNetworkExtrasFor ([NullAllowed] Class aClass);

		[Export ("removeAdNetworkExtrasFor:")]
		void RemoveAdNetworkExtrasFor (Class aClass);

		[Obsolete ("Use MobileAds.SharedInstance.SdkVersion")]
		[Static]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		[Obsolete ("Use MobileAds.SharedInstance.RequestConfiguration.TestDeviceIdentifiers.")]
		[NullAllowed]
		[Export ("testDevices", ArgumentSemantic.Copy)]
		string [] TestDevices { get; set; }

		[Export ("setLocationWithLatitude:longitude:accuracy:")]
		void SetLocation (nfloat latitude, nfloat longitude, nfloat accuracyInMeters);

		[NullAllowed]
		[Export ("keywords", ArgumentSemantic.Copy)]
		string [] Keywords { get; set; }

		[NullAllowed]
		[Export ("contentURL", ArgumentSemantic.Copy)]
		string ContentUrl { get; set; }

		[NullAllowed]
		[Export ("neighboringContentURLStrings", ArgumentSemantic.Copy)]
		string[] NeighboringContentUrlStrings { get; set; }

		[NullAllowed]
		[Export ("requestAgent", ArgumentSemantic.Copy)]
		string RequestAgent { get; set; }

		[Export ("gender", ArgumentSemantic.Assign)]
		Gender Gender { get; set; }

		[NullAllowed]
		[Export ("birthday", ArgumentSemantic.Copy)]
		NSDate Birthday { get; set; }

		[Obsolete ("Use the Birthday property instead.")]
		[Export ("setBirthdayWithMonth:day:year:")]
		void SetBirthday (nint m, nint d, nint y);

		[Obsolete ("Use SetLocation (nfloat, nfloat, nfloat) overload method instead.")]
		[Export ("setLocationWithDescription:")]
		void SetLocation (string locationDescription);

		[Obsolete ("Use MobileAds.SharedInstance.RequestConfiguration.Tag method instead.")]
		[Export ("tagForChildDirectedTreatment:")]
		void Tag (bool forChildDirectedTreatment);
	}

	[Static]
	interface MaxAdContentRatingConstants
	{
		// GAD_EXTERN GADMaxAdContentRating _Nonnull const GADMaxAdContentRatingGeneral;
		[Field("GADMaxAdContentRatingGeneral", "__Internal")]
		NSString General { get; }

		// GAD_EXTERN GADMaxAdContentRating _Nonnull const GADMaxAdContentRatingParentalGuidance;
		[Field("GADMaxAdContentRatingParentalGuidance", "__Internal")]
		NSString ParentalGuidance { get; }

		// GAD_EXTERN GADMaxAdContentRating _Nonnull const GADMaxAdContentRatingTeen;
		[Field("GADMaxAdContentRatingTeen", "__Internal")]
		NSString Teen { get; }

		// GAD_EXTERN GADMaxAdContentRating _Nonnull const GADMaxAdContentRatingMatureAudience;
		[Field("GADMaxAdContentRatingMatureAudience", "__Internal")]
		NSString MatureAudience { get; }
	}

	// @interface GADRequestConfiguration : NSObject
	[BaseType (typeof (NSObject), Name = "GADRequestConfiguration")]
	interface RequestConfiguration {
		// @property(nonatomic, strong, nullable) GADMaxAdContentRating maxAdContentRating;
		[NullAllowed]
		[Export ("maxAdContentRating", ArgumentSemantic.Strong)]
		string MaxAdContentRating { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nullable testDeviceIdentifiers;
		[NullAllowed, Export ("testDeviceIdentifiers", ArgumentSemantic.Copy)]
		string[] TestDeviceIdentifiers { get; set; }

		// -(void)tagForUnderAgeOfConsent:(BOOL)underAgeOfConsent;
		[Export ("tagForUnderAgeOfConsent:")]
		void TagForUnderAgeOfConsent (bool underAgeOfConsent);

		// -(void)tagForChildDirectedTreatment:(BOOL)childDirectedTreatment;
		[Export ("tagForChildDirectedTreatment:")]
		void TagForChildDirectedTreatment (bool childDirectedTreatment);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSError), Name = "GADRequestError")]
	interface RequestError {
		// extern NSString *const kGADErrorDomain __attribute__((visibility("default")));
		[Internal]
		[Field ("kGADErrorDomain", "__Internal")]
		NSString _ErrorDomain { get; }

		[Static]
		[Wrap ("_ErrorDomain.ToString ()")]
		string ErrorDomain { get; }

		[Export ("initWithDomain:code:userInfo:")]
		IntPtr Constructor (NSString appDomain, nint code, NSDictionary userInfo);
	}

	// @interface GADAdNetworkResponseInfo : NSObject
	[BaseType (typeof(NSObject), Name = "GADAdNetworkResponseInfo")]
	interface AdNetworkResponseInfo
	{
		// @property(nonatomic, readonly, nonnull) NSString *adNetworkClassName;        
		[Export ("responseIdentifier")]
		string AdNetworkClassName { get; }

		// @property(nonatomic, readonly, nonnull) NSDictionary<NSString *, id> *credentials;       
		[Export ("credentials")]
		NSDictionary<NSString, NSObject> Credentials { get; }

		// @property(nonatomic, readonly, nullable) NSError *error;
		[NullAllowed]
		[Export ("error")]
		NSError Error { get; }

		// @property(nonatomic, readonly) NSTimeInterval latency;       
		[Export ("latency")]
		double Latency { get; }

		// @property(nonatomic, readonly, nonnull) NSDictionary<NSString *, id> *dictionaryRepresentation;
		[Export ("dictionaryRepresentation")]
		NSDictionary<NSString, NSObject> DictionaryRepresentation { get; }
	}

	// @interface GADResponseInfo : NSObject
	[BaseType (typeof(NSObject), Name = "GADResponseInfo")]
	interface ResponseInfo
	{
		// extern NSString *const _Nonnull GADGoogleAdNetworkClassName;
		[Field ("GADGoogleAdNetworkClassName", "__Internal")]
		NSString GoogleAdNetworkClassName { get; }

		// extern NSString *const _Nonnull GADCustomEventAdNetworkClassName;
		[Field ("GADCustomEventAdNetworkClassName", "__Internal")]
		NSString CustomEventAdNetworkClassName { get; }

		// extern NSString * _Nonnull GADErrorUserInfoKeyResponseInfo;
		[Field ("GADErrorUserInfoKeyResponseInfo", "__Internal")]
		NSString ErrorUserInfoKey { get; }

		// @property (readonly, nonatomic) NSString * _Nullable responseIdentifier;
		[NullAllowed]
		[Export ("responseIdentifier")]
		string ResponseIdentifier { get; }

		// @property (nonatomic, readonly, nullable) NSString *adNetworkClassName;
		[NullAllowed]
		[Export ("adNetworkClassName")]
		string AdNetworkClassName { get; }

		// @property(nonatomic, readonly, nonnull) NSArray<GADAdNetworkResponseInfo *> *adNetworkInfoArray;     
		[Export ("adNetworkInfoArray")]
		AdNetworkResponseInfo[] AdNetworkInfo { get; }

		// @property(nonatomic, readonly, nonnull) NSDictionary<NSString *, id> *dictionaryRepresentation;
		[Export ("dictionaryRepresentation")]
		NSDictionary<NSString, NSObject> DictionaryRepresentation { get; }
	}

	// @interface GADRewardBasedVideoAd : NSObject
	[Obsolete ("Use RewardedAd instead. Google AdMob publishers, follow instructions here: " +
		   "https://googlemobileadssdk.page.link/admob-ios-rewarded-migration. " +
		   "Google Ad Manager publishers, follow instructions here: " +
		   "https://googlemobileadssdk.page.link/admanager-ios-rewarded-migration.")]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject),
		Name = "GADRewardBasedVideoAd",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (RewardBasedVideoAdDelegate) })]
	interface RewardBasedVideoAd {
		// @property (nonatomic, weak) id<GADRewardBasedVideoAdDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IRewardBasedVideoAdDelegate Delegate { get; set; }

		// @property (readonly, getter = isReady, assign, nonatomic) BOOL ready;
		[Export ("ready")]
		bool IsReady { [Bind ("isReady")] get; }

		// @property(nonatomic, readonly, copy, GAD_NULLABLE) NSString *adNetworkClassName;
		[NullAllowed]
		[Export ("adNetworkClassName")]
		string AdNetworkClassName { get; }

		// @property(nonatomic, copy, GAD_NULLABLE) NSString *userIdentifier;
		[NullAllowed]
		[Export ("userIdentifier")]
		string UserIdentifier { get; }

		// @property (nonatomic, copy, nullable) NSString* customRewardString;
		[NullAllowed]
		[Export ("customRewardString")]
		string CustomRewardString { get; set; }

		// @property (readonly, nonatomic) NSDictionary<GADAdMetadataKey,id> * _Nullable adMetadata;
		[NullAllowed, Export ("adMetadata")]
		NSDictionary<NSString, NSObject> AdMetadata { get; }

		// +(GADRewardBasedVideoAd *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		RewardBasedVideoAd SharedInstance { get; }

		// -(void)loadRequest:(GADRequest *)request withAdUnitID:(NSString *)adUnitID;
		[Export ("loadRequest:withAdUnitID:")]
		void LoadRequest (Request request, string adUnitId);

		// -(void)presentFromRootViewController:(UIViewController *)viewController;
		[Export ("presentFromRootViewController:")]
		void Present (UIViewController fromRootViewController);

		[Obsolete ("Use Present method instead. This will be removed in future versions.")]
		[Wrap ("Present (viewController)")]
		void PresentFromRootViewController (UIViewController viewController);
	}

	interface IRewardBasedVideoAdDelegate {
	}

	// @protocol GADRewardBasedVideoAdDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADRewardBasedVideoAdDelegate")]
	interface RewardBasedVideoAdDelegate {
		// - (void)rewardBasedVideoAd:(GADRewardBasedVideoAd *)rewardBasedVideoAd didRewardUserWithReward:(GADAdReward*)reward;
		[Abstract]
		[EventArgs ("RewardBasedVideoAdReward")]
		[EventName ("UserRewarded")]
		[Export ("rewardBasedVideoAd:didRewardUserWithReward:")]
		void DidRewardUser (RewardBasedVideoAd rewardBasedVideoAd, AdReward reward);

		// @optional -(void)rewardBasedVideoAd:(GADRewardBasedVideoAd *)rewardBasedVideoAd didFailToLoadwithError:(NSError *)error;
		[EventArgs ("RewardBasedVideoAdError")]
		[EventName ("FailedToLoad")]
		[Export ("rewardBasedVideoAd:didFailToLoadWithError:")]
		void DidFailToLoad (RewardBasedVideoAd rewardBasedVideoAd, NSError error);

		// @optional -(void)rewardBasedVideoAdDidReceiveAd:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[EventName ("AdReceived")]
		[Export ("rewardBasedVideoAdDidReceiveAd:")]
		void DidReceiveAd (RewardBasedVideoAd rewardBasedVideoAd);

		// @optional -(void)rewardBasedVideoAdDidOpen:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[EventName ("Opened")]
		[Export ("rewardBasedVideoAdDidOpen:")]
		void DidOpen (RewardBasedVideoAd rewardBasedVideoAd);

		// @optional -(void)rewardBasedVideoAdDidStartPlaying:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[EventName ("PlayingStarted")]
		[Export ("rewardBasedVideoAdDidStartPlaying:")]
		void DidStartPlaying (RewardBasedVideoAd rewardBasedVideoAd);

		// - (void)rewardBasedVideoAdDidCompletePlaying:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[EventName ("PlayingCompleted")]
		[Export ("rewardBasedVideoAdDidCompletePlaying:")]
		void DidCompletePlaying (RewardBasedVideoAd rewardBasedVideoAd);

		// @optional -(void)rewardBasedVideoAdDidClose:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[EventName ("Closed")]
		[Export ("rewardBasedVideoAdDidClose:")]
		void DidClose (RewardBasedVideoAd rewardBasedVideoAd);

		// @optional -(void)rewardBasedVideoAdWillLeaveApplication:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[Export ("rewardBasedVideoAdWillLeaveApplication:")]
		void WillLeaveApplication (RewardBasedVideoAd rewardBasedVideoAd);

		// @optional -(void)rewardBasedVideoAdMetadataDidChange:(GADRewardBasedVideoAd * _Nonnull)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[EventName ("MetadataChanged")]
		[Export ("rewardBasedVideoAdMetadataDidChange:")]
		void MetadataDidChange (RewardBasedVideoAd rewardBasedVideoAd);
	}

	// typedef void (^GADRewardedAdLoadCompletionHandler)(GADRequestError * _Nullable);
	delegate void RewardedAdLoadCompletionHandler ([NullAllowed] RequestError error);

	// @interface GADRewardedAd : NSObject
	[BaseType (typeof (NSObject),
		Name = "GADRewardedAd",
		Delegates = new [] { "AdMetadataDelegate" },
		Events = new [] { typeof (RewardedAdMetadataDelegate) })]
	interface RewardedAd {
		// -(instancetype _Nonnull)initWithAdUnitID:(NSString * _Nonnull)adUnitID;
		[Export ("initWithAdUnitID:")]
		IntPtr Constructor (string adUnitId);

		// -(void)loadRequest:(GADRequest * _Nullable)request completionHandler:(GADRewardedAdLoadCompletionHandler _Nullable)completionHandler;
		[Async]
		[Export ("loadRequest:completionHandler:")]
		void LoadRequest ([NullAllowed] Request request, [NullAllowed] RewardedAdLoadCompletionHandler completionHandler);

		// @property (readonly, nonatomic) NSString * _Nonnull adUnitID;
		[Export ("adUnitID")]
		string AdUnitId { get; }

		// @property (readonly, getter = isReady, nonatomic) BOOL ready;
		[Export ("isReady")]
		bool IsReady { get; }

		// @property (readonly, nonatomic) GADResponseInfo * _Nullable responseInfo;
		[NullAllowed]
		[Export ("responseInfo")]
		ResponseInfo ResponseInfo { get; }

		// @property (readonly, nonatomic) GADAdReward * _Nullable reward;
		[NullAllowed]
		[Export ("reward")]
		AdReward Reward { get; }

		// @property (nonatomic, nullable) GADServerSideVerificationOptions *serverSideVerificationOptions;
		[NullAllowed]
		[Export ("serverSideVerificationOptions")]
		ServerSideVerificationOptions ServerSideVerificationOptions { get; set; }

		// @property (readonly, nonatomic) NSDictionary<GADAdMetadataKey,id> * _Nullable adMetadata;
		[NullAllowed]
		[Export ("adMetadata")]
		NSDictionary<NSString, NSObject> AdMetadata { get; }

		// @property (nonatomic, weak) id<GADRewardedAdMetadataDelegate> _Nullable adMetadataDelegate;
		[NullAllowed]
		[Export ("adMetadataDelegate", ArgumentSemantic.Weak)]
		IRewardedAdMetadataDelegate AdMetadataDelegate { get; set; }

		// @property (copy, nonatomic) GADPaidEventHandler _Nullable paidEventHandler;
		[NullAllowed]
		[Export ("paidEventHandler", ArgumentSemantic.Copy)]
		PaidEventHandler PaidEventHandler { get; set; }

		// -(BOOL)canPresentFromRootViewController:(UIViewController * _Nonnull)rootViewController error:(NSError * _Nullable * _Nullable)error;
		[Export ("canPresentFromRootViewController:error:")]
		bool CanPresent (UIViewController rootViewController, [NullAllowed] out NSError error);

		// -(void)presentFromRootViewController:(UIViewController * _Nonnull)viewController delegate:(id<GADRewardedAdDelegate> _Nonnull)delegate;
		[Export ("presentFromRootViewController:delegate:")]
		void Present (UIViewController viewController, IRewardedAdDelegate @delegate);

		// @property (readonly, copy, nonatomic) NSString * _Nullable adNetworkClassName;
		[Obsolete ("Use ResponseInfo.AdNetworkClassName.")]
		[NullAllowed]
		[Export ("adNetworkClassName")]
		string AdNetworkClassName { get; }
	}

	interface IRewardedAdDelegate { }

	// @protocol GADRewardedAdDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADRewardedAdDelegate")]
	interface RewardedAdDelegate {
		// @required -(void)rewardedAd:(GADRewardedAd * _Nonnull)rewardedAd userDidEarnReward:(GADAdReward * _Nonnull)reward;
		[Abstract]
		[Export ("rewardedAd:userDidEarnReward:")]
		void UserDidEarnReward (RewardedAd rewardedAd, AdReward reward);

		// @optional -(void)rewardedAd:(GADRewardedAd * _Nonnull)rewardedAd didFailToPresentWithError:(NSError * _Nonnull)error;
		[Export ("rewardedAd:didFailToPresentWithError:")]
		void DidFailToPresent (RewardedAd rewardedAd, NSError error);

		// @optional -(void)rewardedAdDidPresent:(GADRewardedAd * _Nonnull)rewardedAd;
		[Export ("rewardedAdDidPresent:")]
		void DidPresent (RewardedAd rewardedAd);

		// @optional -(void)rewardedAdDidDismiss:(GADRewardedAd * _Nonnull)rewardedAd;
		[Export ("rewardedAdDidDismiss:")]
		void DidDismiss (RewardedAd rewardedAd);
	}

	interface IRewardedAdMetadataDelegate { }

	// @protocol GADRewardedAdMetadataDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADRewardedAdMetadataDelegate")]
	interface RewardedAdMetadataDelegate {
		// @optional -(void)rewardedAdMetadataDidChange:(GADRewardedAd * _Nonnull)rewardedAd;
		[EventArgs ("RewardedAdMetadataChanged")]
		[EventName ("Changed")]
		[Export ("rewardedAdMetadataDidChange:")]
		void DidChange (RewardedAd rewardedAd);
	}

	interface IAdSizeDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAdSizeDelegate")]
	interface AdSizeDelegate {

		[Abstract]
		[EventArgs ("AdSizeDelegateSize")]
		[Export ("adView:willChangeAdSizeTo:")]
		void WillChangeAdSizeTo (BannerView view, AdSize size);
	}

	// typedef void (^GADPaidEventHandler)(GADAdValue * _Nonnull);
	delegate void PaidEventHandler (AdValue value);

	// @interface GADAdValue : NSObject <NSCopying>
	[BaseType(typeof(NSObject), Name = "GADAdValue")]
	interface AdValue : INSCopying
	{
		// @property (readonly, nonatomic) GADAdValuePrecision precision;
		[Export("precision")]
		AdValuePrecision Precision { get; }

		// @property (readonly, nonatomic) NSDecimalNumber * _Nonnull value;
		[Export("value")]
		NSDecimalNumber Value { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull currencyCode;
		[Export("currencyCode")]
		string CurrencyCode { get; }
	}

	interface IAppEventDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAppEventDelegate")]
	interface AppEventDelegate {
		[EventArgs ("AppEventDidReceiveAppEvent")]
		[Export ("adView:didReceiveAppEvent:withInfo:")]
		void AdViewDidReceiveAppEvent (BannerView banner, string name, [NullAllowed] string info);

		[EventArgs ("AppEventDidReceiveAppEvent")]
		[Export ("interstitial:didReceiveAppEvent:withInfo:")]
		void InterstitialDidReceiveAppEvent (Interstitial interstitial, string name, [NullAllowed] string info);
	}

	// typedef void (^GADAppOpenAdLoadCompletionHandler)(GADAppOpenAd * _Nullable, NSError * _Nullable);
	delegate void AppOpenAdLoadCompletionHandler ([NullAllowed] AppOpenAd appOpenAd, [NullAllowed] NSError error);

	interface IFullScreenContentDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADFullScreenContentDelegate")]
	interface FullScreenContentDelegate {
		[Export ("ad:didFailToPresentFullScreenContentWithError:")]
		void DidFailToPresentFullScreenContent (FullScreenPresentingAd ad, NSError error);

		[Export ("adDidPresentFullScreenContent:")]
		void DidPresentFullScreenContent (FullScreenPresentingAd ad);

		[Export ("adDidDismissFullScreenContent:")]
		void DidDismissFullScreenContent (FullScreenPresentingAd ad);
	}

	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADFullScreenPresentingAd")]
	interface FullScreenPresentingAd {
		[NullAllowed]
		[Export ("fullScreenContentDelegate", ArgumentSemantic.Weak)]
		IFullScreenContentDelegate Delegate { get; set; }
	}

	// @interface GADAppOpenAd : GADFullScreenPresentingAd
	[DisableDefaultCtor]
	[BaseType (typeof (FullScreenPresentingAd), Name = "GADAppOpenAd")]
	interface AppOpenAd {
		// +(void)loadWithAdUnitID:(NSString * _Nonnull)adUnitID request:(GADRequest * _Nullable)request orientation:(UIInterfaceOrientation)orientation completionHandler:(GADAppOpenAdLoadCompletionHandler _Nonnull)completionHandler;
		[Async]
		[Static]
		[Export ("loadWithAdUnitID:request:orientation:completionHandler:")]
		void Load (string adUnitId, [NullAllowed] Request request, UIInterfaceOrientation orientation, AppOpenAdLoadCompletionHandler completionHandler);

		// @property (nonatomic, readonly, nonnull) GADResponseInfo* responseInfo;
		[Export ("responseInfo")]
		ResponseInfo ResponseInfo { get; }

		// @property (nonatomic, nullable, copy) GADPaidEventHandler paidEventHandler;
		[NullAllowed]
		[Export ("paidEventHandler", ArgumentSemantic.Copy)]
		PaidEventHandler PaidEventHandler { get; set; }

		// - (BOOL) canPresentFromRootViewController:(nonnull UIViewController *)rootViewController	error:(NSError* _Nullable __autoreleasing *_Nullable)error;
		[Export ("canPresentFromRootViewController:error:")]
		bool CanPresent (UIViewController rootViewController, [NullAllowed] out NSError error);

		// - (void) presentFromRootViewController:(nonnull UIViewController *)rootViewController;
		[Export ("presentFromRootViewController:")]
		void PresentFromRootViewController ([NullAllowed] UIViewController rootViewController);
	}

	interface ISwipeableBannerViewDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADSwipeableBannerViewDelegate")]
	interface SwipeableBannerViewDelegate {
		[Export ("adViewDidActivateAd:"), EventArgs ("SwipeableBannerViewDelegateInfo")]
		void DidActivateAd (BannerView banner);

		[Export ("adViewDidDeactivateAd:"), EventArgs ("SwipeableBannerViewDelegateInfo")]
		void DidDeactivateAd (BannerView banner);
	}

	// @interface GADAudioVideoManager : NSObject
	[BaseType (typeof (NSObject),
		   Name = "GADAudioVideoManager",
		   Delegates = new string [] { "Delegate" },
		   Events = new Type [] { typeof (AudioVideoManagerDelegate) })]
	interface AudioVideoManager {
		// @property(nonatomic, weak, nullable) id<GADAudioVideoManagerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAudioVideoManagerDelegate Delegate { get; set; }

		// @property(nonatomic, assign) BOOL audioSessionIsApplicationManaged;
		[Export ("audioSessionIsApplicationManaged")]
		bool AudioSessionIsApplicationManaged { get; set; }
	}

	interface IAudioVideoManagerDelegate {
	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAudioVideoManagerDelegate")]
	interface AudioVideoManagerDelegate {
		// - (void)audioVideoManagerWillPlayVideo:(GADAudioVideoManager *)audioVideoManager;
		[EventArgs ("AudioVideoManagerWillPlayVideo")]
		[Export ("audioVideoManagerWillPlayVideo:")]
		void WillPlayVideo (AudioVideoManager audioVideoManager);

		// - (void)audioVideoManagerDidPauseAllVideo:(GADAudioVideoManager *)audioVideoManager;
		[EventArgs ("AudioVideoManagerAllVideoPaused")]
		[EventName ("AllVideoPaused")]
		[Export ("audioVideoManagerDidPauseAllVideo:")]
		void DidPauseAllVideo (AudioVideoManager audioVideoManager);

		// - (void)audioVideoManagerWillPlayAudio:(GADAudioVideoManager *)audioVideoManager;
		[EventArgs ("AudioVideoManagerWillPlayAudio")]
		[Export ("audioVideoManagerWillPlayAudio:")]
		void WillPlayAudio (AudioVideoManager audioVideoManager);

		// - (void)audioVideoManagerDidStopPlayingAudio:(GADAudioVideoManager *)audioVideoManager;
		[EventArgs ("AudioVideoManagerPlayingAudioStopped")]
		[EventName ("PlayingAudioStopped")]
		[Export ("audioVideoManagerDidStopPlayingAudio:")]
		void DidStopPlayingAudio (AudioVideoManager audioVideoManager);
	}

	#region Search

	// @interface GADServerSideVerificationOptions : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GADServerSideVerificationOptions")]
	interface ServerSideVerificationOptions : INSCopying {
		// @property (copy, nonatomic) NSString * _Nullable userIdentifier;
		[NullAllowed]
		[Export ("userIdentifier")]
		string UserIdentifier { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customRewardString;
		[NullAllowed]
		[Export ("customRewardString")]
		string CustomRewardString { get; set; }
	}

	[BaseType (typeof (BannerView), Name = "GADSearchBannerView")]
	interface SearchBannerView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (AdSize size, CGPoint origin);

		[Export ("initWithAdSize:")]
		IntPtr Constructor (AdSize size);

		// @property(nonatomic, weak) IBOutlet id<GADAdSizeDelegate> adSizeDelegate;
		[New]
		[NullAllowed]
		[Export ("adSizeDelegate", ArgumentSemantic.Weak)]
		IAdSizeDelegate AdSizeDelegate { get; set; }
	}

	// @interface GADUnifiedNativeAd : NSObject
	[BaseType (typeof (NSObject),
		   Name = "GADUnifiedNativeAd",
		   Delegates = new [] { "Delegate", "UnconfirmedClickDelegate" },
		   Events = new [] { typeof (UnifiedNativeAdDelegate), typeof (UnifiedNativeAdUnconfirmedClickDelegate) })]
	interface UnifiedNativeAd {
		// @property (readonly, copy, nonatomic) NSString * _Nullable headline;
		[NullAllowed]
		[Export ("headline")]
		string Headline { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable callToAction;
		[NullAllowed]
		[Export ("callToAction")]
		string CallToAction { get; }

		// @property (readonly, nonatomic, strong) GADNativeAdImage * _Nullable icon;
		[NullAllowed]
		[Export ("icon", ArgumentSemantic.Strong)]
		NativeAdImage Icon { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable body;
		[NullAllowed]
		[Export ("body")]
		string Body { get; }

		// @property (readonly, nonatomic, strong) NSArray<GADNativeAdImage *> * _Nullable images;
		[NullAllowed]
		[Export ("images", ArgumentSemantic.Strong)]
		NativeAdImage [] Images { get; }

		// @property (readonly, copy, nonatomic) NSDecimalNumber * _Nullable starRating;
		[NullAllowed]
		[Export ("starRating", ArgumentSemantic.Copy)]
		NSDecimalNumber StarRating { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable store;
		[NullAllowed]
		[Export ("store")]
		string Store { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable price;
		[NullAllowed]
		[Export ("price")]
		string Price { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable advertiser;
		[NullAllowed]
		[Export ("advertiser")]
		string Advertiser { get; }

		// @property(nonatomic, readonly, nonnull) GADMediaContent *mediaContent;
		[Export ("mediaContent")]
		MediaContent MediaContent { get; }

		// @property (nonatomic, weak) id<GADUnifiedNativeAdDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IUnifiedNativeAdDelegate Delegate { get; set; }

		// @property (nonatomic, weak) UIViewController * _Nullable rootViewController;
		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable extraAssets;
		[NullAllowed]
		[Export ("extraAssets", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ExtraAssets { get; }

		// @property (readonly, nonatomic) GADResponseInfo * _Nonnull responseInfo;
		[Export ("responseInfo")]
		ResponseInfo ResponseInfo { get; }

		// @property (copy, nonatomic) GADPaidEventHandler _Nullable paidEventHandler;
		[NullAllowed]
		[Export ("paidEventHandler", ArgumentSemantic.Copy)]
		PaidEventHandler PaidEventHandler { get; set; }

		// @property(nonatomic, readonly, getter=isCustomMuteThisAdAvailable) BOOL customMuteThisAdAvailable;
		[Export ("isCustomMuteThisAdAvailable")]
		bool IsCustomMuteThisAdAvailable { get; }

		// @property(nonatomic, readonly, nullable) NSArray<GADMuteThisAdReason *> *muteThisAdReasons;
		[NullAllowed]
		[Export ("muteThisAdReasons")]
		MuteThisAdReason [] MuteThisAdReasons { get; }

		// -(void)registerAdView:(UIView * _Nonnull)adView clickableAssetViews:(NSDictionary<GADUnifiedNativeAssetIdentifier,UIView *> * _Nonnull)clickableAssetViews nonclickableAssetViews:(NSDictionary<GADUnifiedNativeAssetIdentifier,UIView *> * _Nonnull)nonclickableAssetViews;
		[Export ("registerAdView:clickableAssetViews:nonclickableAssetViews:")]
		void RegisterAdView (UIView adView, NSDictionary<NSString, UIView> nsClickableAssetViews, NSDictionary<NSString, UIView> nsNonclickableAssetViews);

		[Wrap ("RegisterAdView (adView, NSDictionary<NSString, UIView>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (clickableAssetViews.Values), System.Linq.Enumerable.ToArray (clickableAssetViews.Keys), clickableAssetViews.Keys.Count), NSDictionary<NSString, UIView>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (nonclickableAssetViews.Values), System.Linq.Enumerable.ToArray (nonclickableAssetViews.Keys), nonclickableAssetViews.Keys.Count))")]
		void RegisterAdView (UIView adView, Dictionary<string, UIView> clickableAssetViews, Dictionary<string, UIView> nonclickableAssetViews);

		// -(void)unregisterAdView;
		[Export ("unregisterAdView")]
		void UnregisterAdView ();

		// - (void)muteThisAdWithReason:(nullable GADMuteThisAdReason *)reason;
		[Export ("muteThisAdWithReason:")]
		void MuteThisAd (MuteThisAdReason reason);

		// @property (readonly, nonatomic, strong) GADVideoController * _Nullable videoController;
		[Obsolete ("Use the MediaContent.VideoController property instead.")]
		[NullAllowed]
		[Export ("videoController", ArgumentSemantic.Strong)]
		VideoController VideoController { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable adNetworkClassName;
		[Obsolete ("Use ResponseInfo.AdNetworkClassName.")]
		[NullAllowed]
		[Export ("adNetworkClassName")]
		string AdNetworkClassName { get; }

		///
		/// From UnifiedNativeAd_ConfirmationClick Category
		///

		// @property (nonatomic, weak) id<GADUnifiedNativeAdUnconfirmedClickDelegate> _Nullable unconfirmedClickDelegate;
		[NullAllowed]
		[Export ("unconfirmedClickDelegate", ArgumentSemantic.Weak)]
		IUnifiedNativeAdUnconfirmedClickDelegate UnconfirmedClickDelegate { get; set; }

		// -(void)registerClickConfirmingView:(UIView * _Nullable)view;
		[Export ("registerClickConfirmingView:")]
		void RegisterClickConfirmingView ([NullAllowed] UIView view);

		// -(void)cancelUnconfirmedClick;
		[Export ("cancelUnconfirmedClick")]
		void CancelUnconfirmedClick ();

		///
		/// From UnifiedNativeAd_CustomClickGesture Category
		///

		// - (void)enableCustomClickGestures;
		[Export ("enableCustomClickGestures")]
		void EnableCustomClickGestures ();

		// - (void)recordCustomClickGesture;
		[Export ("recordCustomClickGesture")]
		void RecordCustomClickGesture ();
	}

	interface IUnifiedNativeAdLoaderDelegate { }

	// @protocol GADUnifiedNativeAdLoaderDelegate <GADAdLoaderDelegate>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADUnifiedNativeAdLoaderDelegate")]
	interface UnifiedNativeAdLoaderDelegate : AdLoaderDelegate {
		// @required -(void)adLoader:(GADAdLoader * _Nonnull)adLoader didReceiveUnifiedNativeAd:(GADUnifiedNativeAd * _Nonnull)nativeAd;
		[Abstract]
		[Export ("adLoader:didReceiveUnifiedNativeAd:")]
		void DidReceiveUnifiedNativeAd (AdLoader adLoader, UnifiedNativeAd nativeAd);
	}

	// @interface GADUnifiedNativeAdView : UIView
	[BaseType (typeof (UIView), Name = "GADUnifiedNativeAdView")]
	interface UnifiedNativeAdView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, strong) GADUnifiedNativeAd * _Nullable nativeAd;
		[NullAllowed]
		[Export ("nativeAd", ArgumentSemantic.Strong)]
		UnifiedNativeAd NativeAd { get; set; }

		// @property (nonatomic, weak) UIView * _Nullable headlineView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("headlineView", ArgumentSemantic.Weak)]
		UIView HeadlineView { get; set; }

		// @property (nonatomic, weak) UIView * _Nullable callToActionView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("callToActionView", ArgumentSemantic.Weak)]
		UIView CallToActionView { get; set; }

		// @property (nonatomic, weak) UIView * _Nullable iconView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("iconView", ArgumentSemantic.Weak)]
		UIView IconView { get; set; }

		// @property (nonatomic, weak) UIView * _Nullable bodyView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("bodyView", ArgumentSemantic.Weak)]
		UIView BodyView { get; set; }

		// @property (nonatomic, weak) UIView * _Nullable storeView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("storeView", ArgumentSemantic.Weak)]
		UIView StoreView { get; set; }

		// @property (nonatomic, weak) UIView * _Nullable priceView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("priceView", ArgumentSemantic.Weak)]
		UIView PriceView { get; set; }

		// @property (nonatomic, weak) UIView * _Nullable imageView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("imageView", ArgumentSemantic.Weak)]
		UIView ImageView { get; set; }

		// @property (nonatomic, weak) UIView * _Nullable starRatingView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("starRatingView", ArgumentSemantic.Weak)]
		UIView StarRatingView { get; set; }

		// @property (nonatomic, weak) UIView * _Nullable advertiserView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("advertiserView", ArgumentSemantic.Weak)]
		UIView AdvertiserView { get; set; }

		// @property (nonatomic, weak) GADMediaView * _Nullable mediaView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("mediaView", ArgumentSemantic.Weak)]
		MediaView MediaView { get; set; }

		// @property (nonatomic, weak) GADAdChoicesView * _Nullable adChoicesView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("adChoicesView", ArgumentSemantic.Weak)]
		AdChoicesView AdChoicesView { get; set; }
	}

	[Static]
	interface UnifiedNativeAdAssetIdentifiers {
		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativeHeadlineAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativeHeadlineAsset", "__Internal")]
		NSString HeadlineAsset { get; }

		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativeCallToActionAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativeCallToActionAsset", "__Internal")]
		NSString CallToActionAsset { get; }

		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativeIconAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativeIconAsset", "__Internal")]
		NSString IconAsset { get; }

		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativeBodyAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativeBodyAsset", "__Internal")]
		NSString BodyAsset { get; }

		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativeStoreAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativeStoreAsset", "__Internal")]
		NSString StoreAsset { get; }

		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativePriceAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativePriceAsset", "__Internal")]
		NSString PriceAsset { get; }

		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativeImageAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativeImageAsset", "__Internal")]
		NSString ImageAsset { get; }

		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativeStarRatingAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativeStarRatingAsset", "__Internal")]
		NSString StarRatingAsset { get; }

		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativeAdvertiserAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativeAdvertiserAsset", "__Internal")]
		NSString AdvertiserAsset { get; }

		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativeMediaViewAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativeMediaViewAsset", "__Internal")]
		NSString MediaViewAsset { get; }

		// extern const GADUnifiedNativeAssetIdentifier _Nonnull GADUnifiedNativeAdChoicesViewAsset __attribute__((visibility("default")));
		[Field ("GADUnifiedNativeAdChoicesViewAsset", "__Internal")]
		NSString AdChoicesViewAsset { get; }
	}

	interface IUnifiedNativeAdDelegate { }

	// @protocol GADUnifiedNativeAdDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADUnifiedNativeAdDelegate")]
	interface UnifiedNativeAdDelegate {
		// @optional -(void)nativeAdDidRecordImpression:(GADUnifiedNativeAd * _Nonnull)nativeAd;
		[EventArgs ("UnifiedNativeAd")]
		[EventName ("ImpressionRecorded")]
		[Export ("nativeAdDidRecordImpression:")]
		void DidRecordImpression (UnifiedNativeAd nativeAd);

		// @optional -(void)nativeAdDidRecordClick:(GADUnifiedNativeAd * _Nonnull)nativeAd;
		[EventArgs ("UnifiedNativeAd")]
		[EventName ("ClickRecorded")]
		[Export ("nativeAdDidRecordClick:")]
		void DidRecordClick (UnifiedNativeAd nativeAd);

		// @optional -(void)nativeAdWillPresentScreen:(GADUnifiedNativeAd * _Nonnull)nativeAd;
		[EventArgs ("UnifiedNativeAd")]
		[Export ("nativeAdWillPresentScreen:")]
		void WillPresentScreen (UnifiedNativeAd nativeAd);

		// @optional -(void)nativeAdWillDismissScreen:(GADUnifiedNativeAd * _Nonnull)nativeAd;
		[EventArgs ("UnifiedNativeAd")]
		[Export ("nativeAdWillDismissScreen:")]
		void WillDismissScreen (UnifiedNativeAd nativeAd);

		// @optional -(void)nativeAdDidDismissScreen:(GADUnifiedNativeAd * _Nonnull)nativeAd;
		[EventArgs ("UnifiedNativeAd")]
		[EventName ("ScreenDismissed")]
		[Export ("nativeAdDidDismissScreen:")]
		void DidDismissScreen (UnifiedNativeAd nativeAd);

		// @optional -(void)nativeAdWillLeaveApplication:(GADUnifiedNativeAd * _Nonnull)nativeAd;
		[EventArgs ("UnifiedNativeAd")]
		[Export ("nativeAdWillLeaveApplication:")]
		void WillLeaveApplication (UnifiedNativeAd nativeAd);

		// @optional -(void)nativeAdIsMuted:(GADUnifiedNativeAd *)nativeAd;
		[EventArgs ("UnifiedNativeAd")]
		[Export ("nativeAdIsMuted:")]
		void IsMuted (UnifiedNativeAd nativeAd);
	}

	interface IUnifiedNativeAdUnconfirmedClickDelegate { }

	// @protocol GADUnifiedNativeAdUnconfirmedClickDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADUnifiedNativeAdUnconfirmedClickDelegate")]
	interface UnifiedNativeAdUnconfirmedClickDelegate {
		// @required -(void)nativeAd:(GADUnifiedNativeAd * _Nonnull)nativeAd didReceiveUnconfirmedClickOnAssetID:(GADUnifiedNativeAssetIdentifier _Nonnull)assetID;
		[EventArgs ("UnifiedNativeAdUnconfirmedClickReceived")]
		[EventName ("UnconfirmedClickReceived")]
		[Abstract]
		[Export ("nativeAd:didReceiveUnconfirmedClickOnAssetID:")]
		void DidReceiveUnconfirmedClick (UnifiedNativeAd nativeAd, string assetId);

		// @required -(void)nativeAdDidCancelUnconfirmedClick:(GADUnifiedNativeAd * _Nonnull)nativeAd;
		[EventArgs ("UnifiedNativeAdUnconfirmedClickCancelled")]
		[EventName ("UnconfirmedClickCancelled")]
		[Abstract]
		[Export ("nativeAdDidCancelUnconfirmedClick:")]
		void DidCancelUnconfirmedClick (UnifiedNativeAd nativeAd);
	}

	// @interface GADVideoController : NSObject
	[BaseType (typeof (NSObject),
		   Name = "GADVideoController",
		   Delegates = new string [] { "Delegate" },
		   Events = new Type [] { typeof (VideoControllerDelegate) })]
	interface VideoController {
		// @property (nonatomic, weak, GAD_NULLABLE) id<GADVideoControllerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IVideoControllerDelegate Delegate { get; set; }

		// - (void)setMute:(BOOL)mute;
		[Export ("setMute:")]
		void SetMute (bool mute);

		// - (void)play;
		[Export ("play")]
		void Play ();

		// - (void)pause;
		[Export ("pause")]
		void Pause ();

		// - (void) stop;
		[Export ("stop")]
		void Stop ();

		// - (BOOL)customControlsEnabled;
		[Export ("customControlsEnabled")]
		bool IsCustomControlsEnabled { get; }

		// - (BOOL)clickToExpandEnabled;
		[Export ("clickToExpandEnabled")]
		bool IsClickToExpandEnabled { get; }

		// - (BOOL)hasVideoContent;
		[Export ("hasVideoContent")]
		bool HasVideoContent ();

		// - (double)aspectRatio;
		[Export ("aspectRatio")]
		double AspectRatio { get; }
	}

	interface IVideoControllerDelegate {
	}

	// @protocol GADVideoControllerDelegate<NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADVideoControllerDelegate")]
	interface VideoControllerDelegate {
		// - (void)videoControllerDidPlayVideo:(GADVideoController *)videoController;
		[EventArgs ("VideoControllerVideoPlayed")]
		[EventName ("VideoPlayed")]
		[Export ("videoControllerDidPlayVideo:")]
		void DidPlayVideo (VideoController videoController);

		// - (void)videoControllerDidPauseVideo:(GADVideoController *)videoController;
		[EventArgs ("VideoControllerVideoPaused")]
		[EventName ("VideoPaused")]
		[Export ("videoControllerDidPauseVideo:")]
		void DidPauseVideo (VideoController videoController);

		// - (void)videoControllerDidEndVideoPlayback:(GADVideoController*)videoController;
		[EventArgs ("VideoControllerVideoPlaybackEnded")]
		[EventName ("VideoPlaybackEnded")]
		[Export ("videoControllerDidEndVideoPlayback:")]
		void DidEndVideoPlayback (VideoController videoController);

		// - (void)videoControllerDidMuteVideo:(GADVideoController *)videoController;
		[EventArgs ("VideoControllerVideoMuted")]
		[EventName ("VideoMuted")]
		[Export ("videoControllerDidMuteVideo:")]
		void DidMuteVideo (VideoController videoController);

		// - (void)videoControllerDidUnmuteVideo:(GADVideoController *)videoController;
		[EventArgs ("VideoControllerVideoUnuted")]
		[EventName ("VideoUnuted")]
		[Export ("videoControllerDidUnmuteVideo:")]
		void DidUnmuteVideo (VideoController videoController);
	}

	// @interface GADVideoOptions : GADAdLoaderOptions
	[BaseType (typeof (AdLoaderOptions), Name = "GADVideoOptions")]
	interface VideoOptions {
		// @property(nonatomic, assign) BOOL startMuted;
		[Export ("startMuted", ArgumentSemantic.Assign)]
		bool StartMuted { get; set; }

		// @property(nonatomic, assign) BOOL customControlsRequested;
		[Export ("customControlsRequested", ArgumentSemantic.Assign)]
		bool CustomControlsRequested { get; set; }

		//@property(nonatomic, assign) BOOL clickToExpandRequested;
		[Export ("clickToExpandRequested", ArgumentSemantic.Assign)]
		bool ClickToExpandRequested { get; set; }
	}

	#endregion

	#region Loading

	// @interface GADAdChoicesView : UIView
	[BaseType (typeof (UIView), Name = "GADAdChoicesView")]
	interface AdChoicesView {
	}

	// @interface GADAdLoaderOptions : NSObject
	[BaseType (typeof (NSObject), Name = "GADAdLoaderOptions")]
	interface AdLoaderOptions {
	}

	// @interface GADAdLoader : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GADAdLoader")]
	interface AdLoader {
		// @property (nonatomic, weak) id<GADAdLoaderDelegate> __nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAdLoaderDelegate Delegate { get; set; }

		// @property(nonatomic, readonly) NSString *adUnitID;
		[Export ("adUnitID")]
		string AdUnitId { get; }

		[Obsolete ("Use AdUnitId property instead. This will be removed in future versions")]
		[Wrap ("AdUnitId")]
		string AdUnitID { get; }

		// @property(nonatomic, getter=isLoading, readonly) BOOL loading;
		[Export ("isLoading")]
		bool IsLoading { get; }

		// -(instancetype)initWithAdUnitID:(NSString *)adUnitID rootViewController:(UIViewController *)rootViewController adTypes:(NSArray *)adTypes options:(NSArray *)options;
		[Export ("initWithAdUnitID:rootViewController:adTypes:options:")]
		IntPtr Constructor (string adUnitID, [NullAllowed] UIViewController rootViewController, NSString [] adTypes, [NullAllowed] AdLoaderOptions [] options);

		// -(void)loadRequest:(GADRequest *)request;
		[Export ("loadRequest:")]
		void LoadRequest ([NullAllowed] Request request);
	}

	[Obsolete ("Use AdLoaderAdType enum instead. This will be removed in future versions.")]
	[Static]
	interface AdLoaderType {
		//// extern NSString *const kGADAdLoaderAdTypeNativeAppInstall;
		//[Field ("kGADAdLoaderAdTypeNativeAppInstall", "__Internal")]
		//NSString NativeAppInstall { get; }

		//// extern NSString *const kGADAdLoaderAdTypeNativeContent;
		//[Field ("kGADAdLoaderAdTypeNativeContent", "__Internal")]
		//NSString NativeContent { get; }

		// extern NSString *const kGADAdLoaderAdTypeNativeCustomTemplate;
		[Field("kGADAdLoaderAdTypeNativeCustomTemplate", "__Internal")]
		NSString NativeCustomTemplate { get; }

		// extern NSString *const kGADAdLoaderAdTypeDFPBanner;
		[Field ("kGADAdLoaderAdTypeDFPBanner", "__Internal")]
		NSString DfpBanner { get; }

		// AD_EXTERN GADAdLoaderAdType const kGADAdLoaderAdTypeUnifiedNative;
		[Field ("kGADAdLoaderAdTypeUnifiedNative", "__Internal")]
		NSString UnifiedNative { get; }
	}

	interface IAdLoaderDelegate {
	}

	// @protocol GADAdLoaderDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAdLoaderDelegate")]
	interface AdLoaderDelegate {
		// @required -(void)adLoader:(GADAdLoader *)adLoader didFailToReceiveAdWithError:(GADRequestError *)error;
		[Abstract]
		[Export ("adLoader:didFailToReceiveAdWithError:")]
		void DidFailToReceiveAd (AdLoader adLoader, RequestError error);

		// @optional - (void)adLoaderDidFinishLoading:(GADAdLoader *)adLoader;
		[Export ("adLoaderDidFinishLoading:")]
		void DidFinishLoading (AdLoader adLoader);
	}

	#region Loading.Formats

	// @interface GADNativeAd : NSObject
	[BaseType (typeof (NSObject),
		   Name = "GADNativeAd",
		   Delegates = new string [] { "Delegate" },
		   Events = new Type [] { typeof (NativeAdDelegate) })]
	interface NativeAd {
		// @property (nonatomic, weak) id<GADNativeAdDelegate> __nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		// @property (nonatomic, weak) UIViewController * __nullable rootViewController;
		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		// @property (readonly, copy, nonatomic) NSDictionary * extraAssets;
		[NullAllowed]
		[Export ("extraAssets", ArgumentSemantic.Copy)]
		NSDictionary ExtraAssets { get; }

		// @property(nonatomic, readonly, nonnull) GADResponseInfo *responseInfo;
		[Export ("responseInfo")]
		ResponseInfo ResponseInfo { get; }

		// @property (readonly, copy, nonatomic) NSString * adNetworkClassName;
		[Obsolete ("Use ResponseInfo.AdNetworkClassName.")]
		[NullAllowed]
		[Export ("adNetworkClassName")]
		string AdNetworkClassName { get; }
	}

	interface INativeAdDelegate {
	}

	// @protocol GADNativeAdDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADNativeAdDelegate")]
	interface NativeAdDelegate {

		// @optional -(void)nativeAdDidRecordImpression:(GADNativeAd *)nativeAd;
		[EventArgs ("NativeAd")]
		[EventName ("ImpressionRecorded")]
		[Export ("nativeAdDidRecordImpression:")]
		void DidRecordImpression (NativeAd nativeAd);

		// @optional -(void)nativeAdDidRecordClick:(GADNativeAd *)nativeAd;
		[EventArgs ("NativeAd")]
		[EventName ("ClickRecorded")]
		[Export ("nativeAdDidRecordClick:")]
		void DidRecordClick (NativeAd nativeAd);

		// @optional -(void)nativeAdWillPresentScreen:(GADNativeAd *)nativeAd;
		[EventArgs ("NativeAd")]
		[Export ("nativeAdWillPresentScreen:")]
		void WillPresentScreen (NativeAd nativeAd);

		// @optional -(void)nativeAdWillDismissScreen:(GADNativeAd *)nativeAd;
		[EventArgs ("NativeAd")]
		[Export ("nativeAdWillDismissScreen:")]
		void WillDismissScreen (NativeAd nativeAd);

		// @optional -(void)nativeAdDidDismissScreen:(GADNativeAd *)nativeAd;
		[EventArgs ("NativeAd")]
		[EventName ("ScreenDismissed")]
		[Export ("nativeAdDidDismissScreen:")]
		void DidDismissScreen (NativeAd nativeAd);

		// @optional -(void)nativeAdWillLeaveApplication:(GADNativeAd *)nativeAd;
		[EventArgs ("NativeAd")]
		[Export ("nativeAdWillLeaveApplication:")]
		void WillLeaveApplication (NativeAd nativeAd);
	}

	// @interface GADNativeAdImage : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GADNativeAdImage")]
	interface NativeAdImage {
		// -(instancetype)initWithImage:(UIImage *)image;
		[Export ("initWithImage:")]
		IntPtr Constructor (UIImage image);

		// -(instancetype)initWithURL:(NSURL *)URL scale:(CGFloat)scale;
		[Export ("initWithURL:scale:")]
		IntPtr Constructor (NSUrl url, nfloat scale);

		// @property (readonly, nonatomic, strong) UIImage * image;
		[NullAllowed]
		[Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; }

		// @property (readonly, nonatomic, strong) NSURL * imageURL;
		[NullAllowed]
		[Export ("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageUrl { get; }

		// @property (readonly, assign, nonatomic) CGFloat scale;
		[Export ("scale")]
		nfloat Scale { get; }
	}

	[BaseType (typeof (AdLoaderOptions), Name = "GADNativeAdViewAdOptions")]
	interface NativeAdViewAdOptions {
		// @property(nonatomic, assign) GADAdChoicesPosition preferredAdChoicesPosition;
		[Export ("preferredAdChoicesPosition", ArgumentSemantic.Assign)]
		AdChoicesPosition PreferredAdChoicesPosition { get; set; }
	}

	interface INativeAppInstallAdLoaderDelegate {
	}

	// typedef void (^GADNativeAdCustomClickHandler)(NSString* assetID);
	delegate void NativeAdCustomClickHandle (string assetId);

	// @interface GADNativeCustomTemplateAd : GADNativeAd
	[BaseType (typeof (NativeAd), Name = "GADNativeCustomTemplateAd")]
	interface NativeCustomTemplateAd {
		// extern NSString *const GADNativeCustomTemplateAdMediaViewKey;
		[Internal]
		[Field ("GADNativeCustomTemplateAdMediaViewKey", "__Internal")]
		NSString _MediaViewKey { get; }

		// @property (readonly, nonatomic) NSString * templateID;
		[Export ("templateID")]
		string TemplateId { get; }

		[Obsolete ("Use the TemplateId property instead. This will be removed in future versions.")]
		[Wrap ("TemplateId")]
		string TemplateID { get; }

		// @property (readonly, nonatomic) NSArray * availableAssetKeys;
		[Export ("availableAssetKeys")]
		string [] AvailableAssetKeys { get; }

		// @property(nonatomic, readonly, strong) GADVideoController *videoController;
		[Export ("videoController")]
		VideoController VideoController { get; }

		// @property(nonatomic, readonly, strong, GAD_NULLABLE) GADMediaView *mediaView;
		[NullAllowed]
		[Export ("mediaView")]
		MediaView MediaView { get; }

		// @property(atomic, copy) GADNativeAdCustomClickHandler customClickHandler;
		[NullAllowed]
		[Export ("customClickHandler", ArgumentSemantic.Copy)]
		NativeAdCustomClickHandle CustomClickHandler { get; }

		// @property (readonly, nonatomic) GADDisplayAdMeasurement * _Nullable displayAdMeasurement;
		[NullAllowed]
		[Export ("displayAdMeasurement")]
		DisplayAdMeasurement DisplayAdMeasurement { get; }

		// -(GADNativeAdImage *)imageForKey:(NSString *)key;
		[return: NullAllowed]
		[Export ("imageForKey:")]
		NativeAdImage ImageForKey (string key);

		// -(NSString *)stringForKey:(NSString *)key;
		[return: NullAllowed]
		[Export ("stringForKey:")]
		string StringForKey (string key);

		// - (void)performClickOnAssetWithKey:(NSString *)assetKey;
		[Export ("performClickOnAssetWithKey:")]
		void PerformClickOnAssetWithKey (string assetKey);

		// - (void)recordImpression;
		[Export ("recordImpression")]
		void RecordImpression ();

		// -(void)performClickOnAssetWithKey:(NSString *)assetKey customClickHandler:(dispatch_block_t)customClickHandler;
		[Obsolete ("Use PerformClickOnAssetWithKey (string) method instead.")]
		[Export ("performClickOnAssetWithKey:customClickHandler:")]
		void PerformClickOnAssetWithKey (string assetKey, [NullAllowed] Action customClickHandler);
	}

	// @interface GADNativeExpressAdView : UIView
	[Obsolete]
	[DisableDefaultCtor]
	[BaseType (typeof (UIView),
		   Name = "GADNativeExpressAdView",
		   Delegates = new string [] { "Delegate" },
		   Events = new Type [] { typeof (NativeExpressAdViewDelegate) })]
	interface NativeExpressAdView {
		// -(instancetype)initWithAdSize:(id)adSize origin:(CGPoint)origin;
		[return: NullAllowed]
		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (AdSize adSize, CGPoint origin);

		// -(instancetype)initWithAdSize:(id)adSize;
		[return: NullAllowed]
		[Export ("initWithAdSize:")]
		IntPtr Constructor (AdSize adSize);

		// @property(nonatomic, strong, readonly) GADVideoController *videoController;
		[Export ("videoController")]
		VideoController VideoController { get; set; }

		// @property (copy, nonatomic) NSString * adUnitID;
		[NullAllowed]
		[Export("adUnitID")]
		string AdUnitId { get; set; }

		[Obsolete ("Use AdUnitId property instead. This will be removed in future versions.")]
		[NullAllowed]
		[Wrap ("AdUnitId")]
		string AdUnitID { get; set; }

		// @property (nonatomic, weak) UIViewController * _Nullable rootViewController __attribute__((iboutlet));
		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		// @property (assign, nonatomic) int adSize;
		[Export ("adSize")]
		int AdSize { get; set; }

		// @property(nonatomic, weak) IBOutlet id<GADNativeExpressAdViewDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeExpressAdViewDelegate Delegate { get; set; }

		// @property (getter = isAutoloadEnabled, assign, nonatomic) BOOL autoloadEnabled;
		[Export ("autoloadEnabled")]
		bool AutoloadEnabled { [Bind ("isAutoloadEnabled")] get; set; }

		// - (void)setAdOptions:(NSArray *)adOptions;
		[Export ("setAdOptions:")]
		void SetAdOptions (AdLoaderOptions [] adOptions);

		// -(void)loadRequest:(id)request;
		[return: NullAllowed]
		[Export ("loadRequest:")]
		void LoadRequest (Request request);

		// @property (readonly, nonatomic, weak) NSString * _Nullable adNetworkClassName;
		[NullAllowed]
		[Export ("adNetworkClassName", ArgumentSemantic.Weak)]
		string AdNetworkClassName { get; }
	}

	interface INativeExpressAdViewDelegate {
	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADNativeExpressAdViewDelegate")]
	interface NativeExpressAdViewDelegate {
		// @optional -(void)nativeExpressAdViewDidReceiveAd:(GADNativeExpressAdView *)nativeExpressAdView;
		[EventArgs ("NativeExpressAdView")]
		[EventName ("AdReceived")]
		[Export ("nativeExpressAdViewDidReceiveAd:")]
		void DidReceiveAd (NativeExpressAdView nativeExpressAdView);

		// @optional -(void)nativeExpressAdView:(GADNativeExpressAdView *)nativeExpressAdView didFailToReceiveAdWithError:(GADRequestError *)error;
		[EventArgs ("NativeExpressAdViewError")]
		[EventName ("ReceiveAdFailed")]
		[Export ("nativeExpressAdView:didFailToReceiveAdWithError:")]
		void DidFailToReceiveAd (NativeExpressAdView nativeExpressAdView, RequestError error);

		// @optional -(void)nativeExpressAdViewWillPresentScreen:(GADNativeExpressAdView *)nativeExpressAdView;
		[EventArgs ("NativeExpressAdView")]
		[Export ("nativeExpressAdViewWillPresentScreen:")]
		void WillPresentScreen (NativeExpressAdView nativeExpressAdView);

		// @optional -(void)nativeExpressAdViewWillDismissScreen:(GADNativeExpressAdView *)nativeExpressAdView;
		[EventArgs ("NativeExpressAdView")]
		[Export ("nativeExpressAdViewWillDismissScreen:")]
		void WillDismissScreen (NativeExpressAdView nativeExpressAdView);

		// @optional -(void)nativeExpressAdViewDidDismissScreen:(GADNativeExpressAdView *)nativeExpressAdView;
		[EventArgs ("NativeExpressAdView")]
		[EventName ("ScreenDismissed")]
		[Export ("nativeExpressAdViewDidDismissScreen:")]
		void DidDismissScreen (NativeExpressAdView nativeExpressAdView);

		// @optional -(void)nativeExpressAdViewWillLeaveApplication:(GADNativeExpressAdView *)nativeExpressAdView;
		[EventArgs ("NativeExpressAdView")]
		[Export ("nativeExpressAdViewWillLeaveApplication:")]
		void WillLeaveApplication (NativeExpressAdView nativeExpressAdView);
	}

	interface INativeCustomTemplateAdLoaderDelegate {
	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADNativeCustomTemplateAdLoaderDelegate")]
	interface NativeCustomTemplateAdLoaderDelegate : AdLoaderDelegate {
		// @required -(NSArray *)nativeCustomTemplateIDsForAdLoader:(GADAdLoader *)adLoader;
		[Abstract]
		[Export ("nativeCustomTemplateIDsForAdLoader:")]
		string [] NativeCustomTemplateIDs (AdLoader adLoader);

		// @required -(void)adLoader:(GADAdLoader *)adLoader didReceiveNativeCustomTemplateAd:(GADNativeCustomTemplateAd *)nativeCustomTemplateAd;
		[Abstract]
		[Export ("adLoader:didReceiveNativeCustomTemplateAd:")]
		void DidReceiveNativeCustomTemplateAd (AdLoader adLoader, NativeCustomTemplateAd nativeCustomTemplateAd);
	}

	#endregion

	#region Loading.Options

	// @interface GADNativeAdImageAdLoaderOptions : GADAdLoaderOptions
	[BaseType (typeof (AdLoaderOptions), Name = "GADNativeAdImageAdLoaderOptions")]
	interface NativeAdImageAdLoaderOptions {
		// @property (assign, nonatomic) BOOL disableImageLoading;
		[Export ("disableImageLoading")]
		bool DisableImageLoading { get; set; }

		// @property (assign, nonatomic) BOOL shouldRequestMultipleImages;
		[Export ("shouldRequestMultipleImages")]
		bool ShouldRequestMultipleImages { get; set; }

		// @property (assign, nonatomic) GADNativeAdImageAdLoaderOptionsOrientation preferredImageOrientation;
		[Obsolete ("Use the NativeAdMediaAdLoaderOptions.MediaAspectRatio property instead.")]
		[Export ("preferredImageOrientation", ArgumentSemantic.Assign)]
		NativeAdImageAdLoaderOptionsOrientation PreferredImageOrientation { get; set; }
	}

	// @interface GADNativeAdMediaAdLoaderOptions : GADAdLoaderOptions
	[BaseType (typeof (AdLoaderOptions), Name = "GADNativeAdMediaAdLoaderOptions")]
	interface NativeAdMediaAdLoaderOptions {
		// @property (assign, nonatomic) GADMediaAspectRatio mediaAspectRatio;
		[Export ("mediaAspectRatio", ArgumentSemantic.Assign)]
		MediaAspectRatio MediaAspectRatio { get; set; }
	}

	#endregion

	#endregion

	#region Mediation

	interface ICustomEventBanner {

	}

	[Protocol (Name = "GADCustomEventBanner")]
	interface CustomEventBanner {
		[Abstract]
		[Export ("requestBannerAd:parameter:label:request:")]
		void RequestBannerAd (AdSize adSize, [NullAllowed] string serverParameter, [NullAllowed] string serverLabel, CustomEventRequest request);

		[Abstract]
		[return: NullAllowed]
		[Export ("delegate")]
		ICustomEventBannerDelegate GetDelegate ();

		[Abstract]
		[Export ("setDelegate:")]
		void SetDelegate ([NullAllowed] ICustomEventBannerDelegate aDelegate);
	}

	interface ICustomEventBannerDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomEventBannerDelegate")]
	interface CustomEventBannerDelegate {

		[Abstract]
		[Export ("customEventBanner:didReceiveAd:")]
		void DidReceiveAd (ICustomEventBanner customEvent, UIView view);

		[Abstract]
		[Export ("customEventBanner:didFailAd:")]
		void DidFailAd (ICustomEventBanner customEvent, [NullAllowed] NSError error);

		[Abstract]
		[Export ("customEventBannerWasClicked:")]
		void DidClickInAd (ICustomEventBanner customEvent);

		[Abstract]
		[Export ("viewControllerForPresentingModalView")]
		UIViewController ViewControllerForPresentingModalView ();

		[Abstract]
		[Export ("customEventBannerWillPresentModal:")]
		void WillPresentModal (ICustomEventBanner customEvent);

		[Abstract]
		[Export ("customEventBannerWillDismissModal:")]
		void WillDismissModal (ICustomEventBanner customEvent);

		[Abstract]
		[Export ("customEventBannerDidDismissModal:")]
		void DidDismissModal (ICustomEventBanner customEvent);

		[Abstract]
		[Export ("customEventBannerWillLeaveApplication:")]
		void WillLeaveApplication (ICustomEventBanner customEvent);
	}

	[BaseType (typeof (NSObject), Name = "GADCustomEventExtras")]
	interface CustomEventExtras : AdNetworkExtras {

		[Export ("setExtras:forLabel:")]
		[PostGet ("AllExtras")]
		void SetExtras ([NullAllowed] NSDictionary extras, string label);

		[return: NullAllowed]
		[Export ("extrasForLabel:")]
		NSDictionary ExtrasForLabel (string label);

		[Export ("removeAllExtras")]
		[PostGet ("AllExtras")]
		void RemoveAllExtras ();

		[Export ("allExtras")]
		NSDictionary AllExtras { get; }
	}

	interface ICustomEventInterstitial {

	}

	[Protocol (Name = "GADCustomEventInterstitial")]
	interface CustomEventInterstitial {

		[Abstract]
		[return: NullAllowed]
		[Export ("delegate")]
		ICustomEventInterstitialDelegate GetDelegate ();

		[Abstract]
		[Export ("setDelegate:")]
		void SetDelegate ([NullAllowed] ICustomEventInterstitialDelegate aDelegate);

		[Abstract]
		[Export ("requestInterstitialAdWithParameter:label:request:")]
		void RequestInterstitialAd ([NullAllowed] string serverParameter, [NullAllowed] string serverLabel, CustomEventRequest request);

		[Abstract]
		[Export ("presentFromRootViewController:")]
		void PresentFromRootViewController ([NullAllowed] UIViewController rootViewController);
	}

	interface ICustomEventInterstitialDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomEventInterstitialDelegate")]
	interface CustomEventInterstitialDelegate {
		[Export ("customEventInterstitialDidReceiveAd:")]
		void DidReceiveAd (ICustomEventInterstitial customEvent);

		[Export ("customEventInterstitial:didFailAd:")]
		void DidFailAd (ICustomEventInterstitial customEvent, [NullAllowed] NSError error);

		[Export ("customEventInterstitialWasClicked:")]
		void DidClickAd (ICustomEventInterstitial customEvent);

		[Export ("customEventInterstitialWillPresent:")]
		void WillPresent (ICustomEventInterstitial customEvent);

		[Export ("customEventInterstitialWillDismiss:")]
		void WillDismiss (ICustomEventInterstitial customEvent);

		[Export ("customEventInterstitialDidDismiss:")]
		void DidDismiss (ICustomEventInterstitial customEvent);

		[Export ("customEventInterstitialWillLeaveApplication:")]
		void WillLeaveApplication (ICustomEventInterstitial customEvent);
	}

	interface ICustomEventNativeAd {
	}

	// @protocol GADCustomEventNativeAd <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomEventNativeAd")]
	interface CustomEventNativeAd {
		// @required -(void)requestNativeAdWithParameter:(NSString *)serverParameter request:(GADCustomEventRequest *)request adTypes:(NSArray *)adTypes options:(NSArray *)options rootViewController:(UIViewController *)rootViewController;
		[Abstract]
		[Export ("requestNativeAdWithParameter:request:adTypes:options:rootViewController:")]
		void Request (string serverParameter, CustomEventRequest request, NSString [] adTypes, NSNumber [] options, UIViewController rootViewController);

		// - (BOOL)handlesUserClicks;
		[Abstract]
		[Export ("handlesUserClicks")]
		bool HandlesUserClicks ();

		// - (BOOL)handlesUserImpressions;
		[Abstract]
		[Export ("handlesUserImpressions")]
		bool HandlesUserImpressions ();

		// @required @property (nonatomic, weak) id<GADCustomEventNativeAdDelegate> _Nullable delegate;
		[Abstract]
		[return: NullAllowed]
		[Export ("delegate")]
		ICustomEventNativeAdDelegate GetDelegate ();

		[Abstract]
		[Export ("setDelegate:")]
		void SetDelegate ([NullAllowed] ICustomEventNativeAdDelegate aDelegate);
	}

	interface ICustomEventNativeAdDelegate {
	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomEventNativeAdDelegate")]
	interface CustomEventNativeAdDelegate {
		// @required -(void)customEventNativeAd:(id<GADCustomEventNativeAd>)customEventNativeAd didFailToLoadWithError:(NSError *)error;
		[Abstract]
		[Export ("customEventNativeAd:didFailToLoadWithError:")]
		void DidFailToLoad (ICustomEventNativeAd customEventNativeAd, NSError error);

		// - (void)customEventNativeAd:(id<GADCustomEventNativeAd>)customEventNativeAd didReceiveMediatedUnifiedNativeAd:(id<GADMediatedUnifiedNativeAd>) mediatedUnifiedNativeAd;
		[Abstract]
		[Export ("customEventNativeAd:didReceiveMediatedUnifiedNativeAd:")]
		void DidReceiveMediatedUnifiedNativeAd (ICustomEventNativeAd customEventNativeAd, Mediation.IMediatedUnifiedNativeAd mediatedUnifiedNativeAd);
	}

	[BaseType (typeof (NSObject), Name = "GADCustomEventRequest")]
	interface CustomEventRequest {
		[Obsolete ("Use Request.Gender property instead.")]
		[Export ("userGender", ArgumentSemantic.Assign)]
		Gender UserGender { get; }

		[Obsolete ("Use Request.Birthday property instead.")]
		[NullAllowed]
		[Export ("userBirthday", ArgumentSemantic.Copy)]
		NSDate UserBirthday { get; }

		[Export ("userHasLocation", ArgumentSemantic.Assign)]
		bool UserHasLocation { get; }

		[Export ("userLatitude", ArgumentSemantic.Assign)]
		nfloat UserLatitude { get; }

		[Export ("userLongitude", ArgumentSemantic.Assign)]
		nfloat UserLongitude { get; }

		[Export ("userLocationAccuracyInMeters", ArgumentSemantic.Assign)]
		nfloat UserLocationAccuracyInMeters { get; }

		[NullAllowed]
		[Export ("userLocationDescription", ArgumentSemantic.Copy)]
		string UserLocationDescription { get; }

		[NullAllowed]
		[Export ("userKeywords", ArgumentSemantic.Copy)]
		NSObject [] UserKeywords { get; }

		[NullAllowed]
		[Export ("additionalParameters", ArgumentSemantic.Copy)]
		NSDictionary AdditionalParameters { get; }

		[Export ("isTesting", ArgumentSemantic.Assign)]
		bool IsTesting { get; }
	}

	interface IDebugOptionsViewControllerDelegate {
	}

	// @protocol GADDebugOptionsViewControllerDelegate<NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADDebugOptionsViewControllerDelegate")]
	interface DebugOptionsViewControllerDelegate {
		// - (void)debugOptionsViewControllerDidDismiss:(GADDebugOptionsViewController*)controller;
		[Abstract]
		[EventArgs ("DebugOptionsViewControllerDismissed")]
		[EventName ("Dismissed")]
		[Export ("debugOptionsViewControllerDidDismiss:")]
		void DidDismiss (DebugOptionsViewController controller);
	}

	// @interface GADDebugOptionsViewController : UIViewController
	[DisableDefaultCtor]
	[BaseType (typeof (UIViewController), Name = "GADDebugOptionsViewController")]
	interface DebugOptionsViewController {
		// + (instancetype)debugOptionsViewControllerWithAdUnitID:(NSString*)adUnitID;
		[Static]
		[Export ("debugOptionsViewControllerWithAdUnitID:")]
		DebugOptionsViewController GetInstance (string adUnitId);

		// @property(nonatomic, weak, GAD_NULLABLE) IBOutlet id<GADDebugOptionsViewControllerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IDebugOptionsViewControllerDelegate Delegate { get; set; }
	}

	interface IDelayedAdRenderingDelegate { }

	// @protocol GADDelayedAdRenderingDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADDelayedAdRenderingDelegate")]
	interface DelayedAdRenderingDelegate {
		// @required -(BOOL)adLoader:(GADAdLoader * _Nonnull)adLoader shouldDelayRenderingWithResumeHandler:(dispatch_block_t _Nonnull)resumeHandler;
		[Abstract]
		[Export ("adLoader:shouldDelayRenderingWithResumeHandler:")]
		bool ShouldDelayRendering (AdLoader adLoader, Action resumeHandler);
	}

	// @interface GADDelayedAdRenderingOptions : GADAdLoaderOptions
	[BaseType (typeof (AdLoaderOptions), Name = "GADDelayedAdRenderingOptions")]
	interface DelayedAdRenderingOptions {
		// @property (nonatomic, weak) id<GADDelayedAdRenderingDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IDelayedAdRenderingDelegate Delegate { get; set; }
	}

	// @interface GADDisplayAdMeasurement : NSObject
	[BaseType (typeof (NSObject), Name = "GADDisplayAdMeasurement")]
	interface DisplayAdMeasurement {
		// @property (nonatomic, weak) UIView * _Nullable view;
		[NullAllowed]
		[Export ("view", ArgumentSemantic.Weak)]
		UIView View { get; set; }

		// -(BOOL)startWithError:(NSError * _Nullable * _Nullable)error;
		[Export ("startWithError:")]
		bool Start ([NullAllowed] out NSError error);
	}

	// @interface GADDynamicHeightSearchRequest : GADRequest
	[BaseType (typeof (Request), Name = "GADDynamicHeightSearchRequest")]
	interface DynamicHeightSearchRequest {
		// @property (copy, nonatomic) NSString * query;
		[NullAllowed]
		[Export ("query")]
		string Query { get; set; }

		// @property (assign, nonatomic) NSInteger adPage;
		[Export ("adPage")]
		nint AdPage { get; set; }

		// @property (assign, nonatomic) BOOL adTestEnabled;
		[Export ("adTestEnabled")]
		bool AdTestEnabled { get; set; }

		// @property (copy, nonatomic) NSString * channel;
		[NullAllowed]
		[Export ("channel")]
		string Channel { get; set; }

		// @property (copy, nonatomic) NSString * hostLanguage;
		[NullAllowed]
		[Export ("hostLanguage")]
		string HostLanguage { get; set; }

		// @property (copy, nonatomic) NSString * locationExtensionTextColor;
		[NullAllowed]
		[Export ("locationExtensionTextColor")]
		string LocationExtensionTextColor { get; set; }

		// @property (assign, nonatomic) CGFloat locationExtensionFontSize;
		[Export ("locationExtensionFontSize")]
		nfloat LocationExtensionFontSize { get; set; }

		// @property (assign, nonatomic) BOOL clickToCallExtensionEnabled;
		[Export ("clickToCallExtensionEnabled")]
		bool ClickToCallExtensionEnabled { get; set; }

		// @property (assign, nonatomic) BOOL locationExtensionEnabled;
		[Export ("locationExtensionEnabled")]
		bool LocationExtensionEnabled { get; set; }

		// @property (assign, nonatomic) BOOL plusOnesExtensionEnabled;
		[Export ("plusOnesExtensionEnabled")]
		bool PlusOnesExtensionEnabled { get; set; }

		// @property (assign, nonatomic) BOOL sellerRatingsExtensionEnabled;
		[Export ("sellerRatingsExtensionEnabled")]
		bool SellerRatingsExtensionEnabled { get; set; }

		// @property (assign, nonatomic) BOOL siteLinksExtensionEnabled;
		[Export ("siteLinksExtensionEnabled")]
		bool SiteLinksExtensionEnabled { get; set; }

		// @property (copy, nonatomic) NSString * CSSWidth;
		[NullAllowed]
		[Export ("CSSWidth")]
		string CssWidth { get; set; }

		// @property (assign, nonatomic) NSInteger numberOfAds;
		[Export ("numberOfAds")]
		nint NumberOfAds { get; set; }

		// @property (copy, nonatomic) NSString * fontFamily;
		[Export ("fontFamily")]
		string FontFamily { get; set; }

		// @property (copy, nonatomic) NSString * attributionFontFamily;
		[NullAllowed]
		[Export ("attributionFontFamily")]
		string AttributionFontFamily { get; set; }

		// @property (assign, nonatomic) CGFloat annotationFontSize;
		[Export ("annotationFontSize")]
		nfloat AnnotationFontSize { get; set; }

		// @property (assign, nonatomic) CGFloat attributionFontSize;
		[Export ("attributionFontSize")]
		nfloat AttributionFontSize { get; set; }

		// @property (assign, nonatomic) CGFloat descriptionFontSize;
		[Export ("descriptionFontSize")]
		nfloat DescriptionFontSize { get; set; }

		// @property (assign, nonatomic) CGFloat domainLinkFontSize;
		[Export ("domainLinkFontSize")]
		nfloat DomainLinkFontSize { get; set; }

		// @property (assign, nonatomic) CGFloat titleFontSize;
		[Export ("titleFontSize")]
		nfloat TitleFontSize { get; set; }

		// @property (copy, nonatomic) NSString * adBorderColor;
		[NullAllowed]
		[Export ("adBorderColor")]
		string AdBorderColor { get; set; }

		// @property (copy, nonatomic) NSString * adSeparatorColor;
		[NullAllowed]
		[Export ("adSeparatorColor")]
		string AdSeparatorColor { get; set; }

		// @property (copy, nonatomic) NSString * annotationTextColor;
		[NullAllowed]
		[Export ("annotationTextColor")]
		string AnnotationTextColor { get; set; }

		// @property (copy, nonatomic) NSString * attributionTextColor;
		[NullAllowed]
		[Export ("attributionTextColor")]
		string AttributionTextColor { get; set; }

		// @property (copy, nonatomic) NSString * backgroundColor;
		[NullAllowed]
		[Export ("backgroundColor")]
		string BackgroundColor { get; set; }

		// @property (copy, nonatomic) NSString * borderColor;
		[NullAllowed]
		[Export ("borderColor")]
		string BorderColor { get; set; }

		// @property (copy, nonatomic) NSString * domainLinkColor;
		[NullAllowed]
		[Export ("domainLinkColor")]
		string DomainLinkColor { get; set; }

		// @property (copy, nonatomic) NSString * textColor;
		[NullAllowed]
		[Export ("textColor")]
		string TextColor { get; set; }

		// @property (copy, nonatomic) NSString * titleLinkColor;
		[NullAllowed]
		[Export ("titleLinkColor")]
		string TitleLinkColor { get; set; }

		// @property (copy, nonatomic) NSString * adBorderCSSSelections;
		[NullAllowed]
		[Export ("adBorderCSSSelections")]
		string AdBorderCssSelections { get; set; }

		// @property (assign, nonatomic) CGFloat adjustableLineHeight;
		[Export ("adjustableLineHeight")]
		nfloat AdjustableLineHeight { get; set; }

		// @property (assign, nonatomic) CGFloat attributionBottomSpacing;
		[Export ("attributionBottomSpacing")]
		nfloat AttributionBottomSpacing { get; set; }

		// @property (copy, nonatomic) NSString * borderCSSSelections;
		[NullAllowed]
		[Export ("borderCSSSelections")]
		string BorderCssSelections { get; set; }

		// @property (assign, nonatomic) BOOL titleUnderlineHidden;
		[Export ("titleUnderlineHidden")]
		bool TitleUnderlineHidden { get; set; }

		// @property (assign, nonatomic) BOOL boldTitleEnabled;
		[Export ("boldTitleEnabled")]
		bool BoldTitleEnabled { get; set; }

		// @property (assign, nonatomic) CGFloat verticalSpacing;
		[Export ("verticalSpacing")]
		nfloat VerticalSpacing { get; set; }

		// @property (assign, nonatomic) BOOL detailedAttributionExtensionEnabled;
		[Export ("detailedAttributionExtensionEnabled")]
		bool DetailedAttributionExtensionEnabled { get; set; }

		// @property (assign, nonatomic) BOOL longerHeadlinesExtensionEnabled;
		[Export ("longerHeadlinesExtensionEnabled")]
		bool LongerHeadlinesExtensionEnabled { get; set; }

		// -(void)setAdvancedOptionValue:(id)value forKey:(NSString *)key;
		[Export ("setAdvancedOptionValue:forKey:")]
		void SetAdvancedOptionValue (NSObject value, string key);
	}

	[Obsolete]
	[BaseType (typeof (NSObject), Name = "GADDefaultInAppPurchase")]
	interface DefaultInAppPurchase {
		[Static]
		[Export ("enableDefaultPurchaseFlowWithDelegate:")]
		void EnableDefaultPurchaseFlow (IDefaultInAppPurchaseDelegate aDelegate);

		[Static]
		[Export ("disableDefaultPurchaseFlow")]
		void DisableDefaultPurchaseFlow ();

		[Export ("productID", ArgumentSemantic.Copy)]
		string ProductId { get; }

		[Export ("quantity", ArgumentSemantic.Assign)]
		nint Quantity { get; }

		[Export ("paymentTransaction", ArgumentSemantic.Strong)]
		SKPaymentTransaction PaymentTransaction { get; }

		[Export ("finishTransaction")]
		void FinishTransaction ();
	}

	[Obsolete]
	[BaseType (typeof (NSObject), Name = "GADInAppPurchase")]
	interface InAppPurchase {
		[Export ("productID", ArgumentSemantic.Copy)]
		string ProductId { get; }

		[Export ("quantity", ArgumentSemantic.Assign)]
		nint Quantity { get; }

		[Export ("reportPurchaseStatus:")]
		void ReportPurchaseStatus (InAppPurchaseStatus purchaseStatus);
	}

	interface IDefaultInAppPurchaseDelegate {

	}

	[Obsolete]
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADDefaultInAppPurchaseDelegate")]
	interface DefaultInAppPurchaseDelegate {
		[Abstract]
		[Export ("userDidPayForPurchase:")]
		void DidPayForPurchase (DefaultInAppPurchase defaultInAppPurchase);

		[Export ("shouldStartPurchaseForProductID:quantity:")]
		void ShouldStartPurchase (string productID, nint quantity);
	}

	interface IInAppPurchaseDelegate {

	}

	[Obsolete]
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADInAppPurchaseDelegate")]
	interface InAppPurchaseDelegate {
		[Export ("didReceiveInAppPurchase:")]
		[EventArgs ("InAppPurchaseDelegateDidRecieve")]
		void DidReceiveInAppPurchase (InAppPurchase purchase);
	}

	// @interface GADAdapterStatus : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GADAdapterStatus")]
	interface AdapterStatus : INSCopying {
		// @property (readonly, nonatomic) GADAdapterInitializationState state;
		[Export ("state")]
		AdapterInitializationState State { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull description;
		[Export ("description")]
		string Description { get; }

		// @property (readonly, nonatomic) NSTimeInterval latency;
		[Export ("latency")]
		double Latency { get; }
	}

	// @interface GADInitializationStatus : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GADInitializationStatus")]
	interface InitializationStatus : INSCopying {
		// @property (readonly, nonatomic) NSDictionary<NSString *,GADAdapterStatus *> * _Nonnull adapterStatusesByClassName;
		[Export ("adapterStatusesByClassName")]
		NSDictionary<NSString, AdapterStatus> AdapterStatusesByClassName { get; }
	}

	// typedef void (^GADInstreamAdLoadCompletionHandler)(GADInstreamAd * _Nullable, NSError * _Nullable);
	delegate void InstreamAdLoadCompletionHandler ([NullAllowed] InstreamAd instreamAd, [NullAllowed] NSError error);

	// @interface GADInstreamAd : NSObject
	[Obsolete]
	[BaseType (typeof(NSObject), Name = "GADInstreamAd")]
	interface InstreamAd
	{
		// +(void)loadAdWithAdUnitID:(NSString * _Nonnull)adUnitID request:(GADRequest * _Nullable)request mediaAspectRatio:(GADMediaAspectRatio)mediaAspectRatio completionHandler:(GADInstreamAdLoadCompletionHandler _Nonnull)completionHandler;
		[Static]
		[Export ("loadAdWithAdUnitID:request:mediaAspectRatio:completionHandler:")]
		void LoadAd (string adUnitId, [NullAllowed] Request request, MediaAspectRatio mediaAspectRatio, InstreamAdLoadCompletionHandler completionHandler);

		// +(void)loadAdWithAdTag:(NSString * _Nonnull)adTag completionHandler:(GADInstreamAdLoadCompletionHandler _Nonnull)completionHandler;
		[Static]
		[Export ("loadAdWithAdTag:completionHandler:")]
		void LoadAd (string adTag, InstreamAdLoadCompletionHandler completionHandler);

		// @property (readonly, nonatomic) GADMediaContent * _Nonnull mediaContent;
		[Export ("mediaContent")]
		MediaContent MediaContent { get; }

		// @property (readonly, nonatomic) GADResponseInfo * _Nonnull responseInfo;
		[Export ("responseInfo")]
		ResponseInfo ResponseInfo { get; }

		// @property (copy, nonatomic) GADPaidEventHandler _Nullable paidEventHandler;
		[NullAllowed]
		[Export ("paidEventHandler", ArgumentSemantic.Copy)]
		PaidEventHandler PaidEventHandler { get; set; }
	}

	// @interface GADInstreamAdView : UIView
	[BaseType (typeof(UIView), Name = "GADInstreamAdView")]
	interface InstreamAdView
	{
		// @property (nonatomic) GADInstreamAd * _Nullable ad;
		[NullAllowed]
		[Export ("ad", ArgumentSemantic.Assign)]
		InstreamAd Ad { get; set; }
	}

	// @interface GADMuteThisAdReason : NSObject
	[BaseType (typeof (NSObject), Name = "GADMuteThisAdReason")]
	interface MuteThisAdReason {
		// @property(nonatomic, readonly, nonnull) NSString *reasonDescription;
		[Export ("reasonDescription")]
		string ReasonDescription { get; }
	}

	#endregion

	// @interface GADMediaView : UIView
	[BaseType (typeof (UIView), Name = "GADMediaView")]
	interface MediaView {
		// @property (nonatomic, nullable) GADMediaContent* mediaContent;
		[NullAllowed]
		[Export ("mediaContent")]
		MediaContent MediaContent { get; set; }
	}

	// @interface GADNativeMuteThisAdLoaderOptions : GADAdLoaderOptions
	[BaseType (typeof (AdLoaderOptions), Name = "GADNativeMuteThisAdLoaderOptions")]
	interface NativeMuteThisAdLoaderOptions {
		// @property(nonatomic) BOOL customMuteThisAdRequested;
		[Export ("customMuteThisAdRequested", ArgumentSemantic.Assign)]
		bool CustomMuteThisAdRequested { get; set; }
	}
}

namespace Google.MobileAds.DoubleClick {
	#region DoubleClick

	interface IBannerAdLoaderDelegate { }

	// @protocol DFPBannerAdLoaderDelegate<GADAdLoaderDelegate>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "DFPBannerAdLoaderDelegate")]
	interface BannerAdLoaderDelegate : Google.MobileAds.AdLoaderDelegate {
		// - (NSArray<NSValue *> *)validBannerSizesForAdLoader:(GADAdLoader *)adLoader;
		[Abstract]
		[Export ("validBannerSizesForAdLoader:")]
		NSValue [] ValidBannerSizes (Google.MobileAds.AdLoader adLoader);

		// - (void)adLoader:(GADAdLoader *)adLoader didReceiveDFPBannerView:(DFPBannerView *)bannerView;
		[Abstract]
		[Export ("adLoader:didReceiveDFPBannerView:")]
		void DidReceiveBannerView (Google.MobileAds.AdLoader adLoader, BannerView bannerView);
	}

	[BaseType (typeof (Google.MobileAds.BannerView),
		Name = "DFPBannerView",
		Delegates = new string [] { "AdSizeDelegate", "AppEventDelegate" },
		Events = new Type [] { typeof (Google.MobileAds.AdSizeDelegate), typeof(Google.MobileAds.AppEventDelegate) })]
	interface BannerView {

		[Export ("initWithFrame:")]
		
		IntPtr Constructor (CGRect frame);

		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (AdSize size, CGPoint origin);

		[Export ("initWithAdSize:")]
		IntPtr Constructor (AdSize size);

		[New]
		[NullAllowed]
		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitID { get; set; }

		[NullAllowed]
		[Export ("appEventDelegate", ArgumentSemantic.Weak)]
		IAppEventDelegate AppEventDelegate { get; set; }

		[New]
		[NullAllowed]
		[Export ("adSizeDelegate", ArgumentSemantic.Weak)]
		IAdSizeDelegate AdSizeDelegate { get; set; }

		[NullAllowed]
		[Export ("validAdSizes", ArgumentSemantic.Copy)]
		NSValue [] ValidAdSizes { get; set; }

		[Export ("enableManualImpressions")]
		bool EnableManualImpressions { get; set; }

		// @property(nonatomic, readonly, nonnull) GADVideoController *videoController;
		[Export ("videoController")]
		Google.MobileAds.VideoController VideoController { get; }

		[Export ("recordImpression")]
		void RecordImpression ();

		[Export ("resize:")]
		void Resize (AdSize size);

		// - (void)setAdOptions:(NSArray *)adOptions;
		[Export ("setAdOptions:")]
		void SetAdOptions (AdLoaderOptions [] adOptions);

		[Internal]
		[Export ("setValidAdSizesWithSizes:", IsVariadic = true)]
		void SetValidAdSizes (AdSize firstSize, IntPtr sizesPtr);
	}

	// @interface DFPBannerViewOptions : GADAdLoaderOptions
	[BaseType (typeof (AdLoaderOptions), Name = "DFPBannerViewOptions")]
	interface BannerViewOptions {
		// @property(nonatomic, weak, GAD_NULLABLE) id<GADAppEventDelegate> appEventDelegate;
		[NullAllowed]
		[Export ("appEventDelegate", ArgumentSemantic.Weak)]
		Google.MobileAds.IAppEventDelegate AppEventDelegate { get; set; }

		// @property(nonatomic, weak, GAD_NULLABLE) id<GADAdSizeDelegate> adSizeDelegate;
		[NullAllowed]
		[Export ("adSizeDelegate", ArgumentSemantic.Weak)]
		Google.MobileAds.IAdSizeDelegate AdSizeDelegate { get; set; }

		// @property(nonatomic, assign) BOOL enableManualImpressions;
		[Export ("enableManualImpressions", ArgumentSemantic.Assign)]
		bool EnableManualImpressions { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (Google.MobileAds.Interstitial),
		Name = "DFPInterstitial")]
	interface Interstitial {
		// -(instancetype _Nonnull)initWithAdUnitID:(NSString * _Nonnull)adUnitID __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithAdUnitID:")]
		IntPtr Constructor (string adUnitID);

		[NullAllowed]
		[Export ("appEventDelegate", ArgumentSemantic.Weak)]
		IAppEventDelegate AppEventDelegate { get; set; }
	}

	[BaseType (typeof (Google.MobileAds.Request), Name = "DFPRequest")]
	interface Request {
		[New]
		[Field ("kDFPSimulatorID", "__Internal")]
		NSString SimulatorId { get; }

		[New]
		[Static]
		[Export ("request")]
		Request GetDefaultRequest ();

		[NullAllowed]
		[Export ("publisherProvidedID", ArgumentSemantic.Copy)]
		string PublisherProvidedID { get; set; }

		[NullAllowed]
		[Export ("categoryExclusions", ArgumentSemantic.Copy)]
		string [] CategoryExclusions { get; set; }

		[NullAllowed]
		[Export ("customTargeting", ArgumentSemantic.Copy)]
		NSDictionary CustomTargeting { get; set; }
	}

	#endregion
}

namespace Google.MobileAds.Mediation {
	interface IMediatedUnifiedNativeAd { }

	// @protocol GADMediatedUnifiedNativeAd <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADMediatedUnifiedNativeAd")]
	interface MediatedUnifiedNativeAd {
		// @required @property (readonly, copy, nonatomic) NSString * _Nullable headline;
		[Abstract]
		[NullAllowed]
		[Export ("headline")]
		string Headline { get; }

		// @required @property (readonly, nonatomic) NSArray<GADNativeAdImage *> * _Nullable images;
		[Abstract]
		[NullAllowed]
		[Export ("images")]
		NativeAdImage [] Images { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable body;
		[Abstract]
		[NullAllowed]
		[Export ("body")]
		string Body { get; }

		// @required @property (readonly, nonatomic) GADNativeAdImage * _Nullable icon;
		[Abstract]
		[NullAllowed]
		[Export ("icon")]
		NativeAdImage Icon { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable callToAction;
		[Abstract]
		[NullAllowed]
		[Export ("callToAction")]
		string CallToAction { get; }

		// @required @property (readonly, copy, nonatomic) NSDecimalNumber * _Nullable starRating;
		[Abstract]
		[NullAllowed]
		[Export ("starRating", ArgumentSemantic.Copy)]
		NSDecimalNumber StarRating { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable store;
		[Abstract]
		[NullAllowed]
		[Export ("store")]
		string Store { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable price;
		[Abstract]
		[NullAllowed]
		[Export ("price")]
		string Price { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable advertiser;
		[Abstract]
		[NullAllowed]
		[Export ("advertiser")]
		string Advertiser { get; }

		// @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable extraAssets;
		[Abstract]
		[NullAllowed]
		[Export ("extraAssets", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ExtraAssets { get; }

		// @optional @property (readonly, nonatomic) UIView * _Nullable adChoicesView;
		[return: NullAllowed]
		[Export ("adChoicesView")]
		UIView GetAdChoicesView ();

		// @optional @property (readonly, nonatomic) UIView * _Nullable mediaView;
		[return: NullAllowed]
		[Export ("mediaView")]
		UIView GetMediaView ();

		// @optional @property (readonly, assign, nonatomic) BOOL hasVideoContent;
		[Export ("hasVideoContent")]
		bool HasVideoContent ();

		// @optional @property (readonly, nonatomic) CGFloat mediaContentAspectRatio;
		[Export ("mediaContentAspectRatio")]
		nfloat GetMediaContentAspectRatio ();

		// @optional @property (readonly, nonatomic) NSTimeInterval duration;
		[Export ("duration")]
		double GetDuration ();

		// @optional @property (readonly, nonatomic) NSTimeInterval currentTime;
		[Export ("currentTime")]
		double GetCurrentTime ();

		// @optional -(void)didRenderInView:(UIView * _Nonnull)view clickableAssetViews:(NSDictionary<GADUnifiedNativeAssetIdentifier,UIView *> * _Nonnull)clickableAssetViews nonclickableAssetViews:(NSDictionary<GADUnifiedNativeAssetIdentifier,UIView *> * _Nonnull)nonclickableAssetViews viewController:(UIViewController * _Nonnull)viewController;
		[Export ("didRenderInView:clickableAssetViews:nonclickableAssetViews:viewController:")]
		void DidRenderInView (UIView view, NSDictionary<NSString, UIView> clickableAssetViews, NSDictionary<NSString, UIView> nonclickableAssetViews, UIViewController viewController);

		// @optional -(void)didRecordImpression;
		[Export ("didRecordImpression")]
		void DidRecordImpression ();

		// @optional -(void)didRecordClickOnAssetWithName:(GADUnifiedNativeAssetIdentifier _Nonnull)assetName view:(UIView * _Nonnull)view viewController:(UIViewController * _Nonnull)viewController;
		[Export ("didRecordClickOnAssetWithName:view:viewController:")]
		void DidRecordClick (string assetName, UIView view, UIViewController viewController);

		// @optional -(void)didUntrackView:(UIView * _Nullable)view;
		[Export ("didUntrackView:")]
		void DidUntrackView ([NullAllowed] UIView view);
	}
}

namespace Google.MobileAds.Consent {
	// typedef void (^UMPConsentFormLoadCompletionHandler)(UMPConsentForm * _Nullable, NSError * _Nullable);
    delegate void ConsentFormLoadCompletionHandler([NullAllowed] ConsentForm consentForm, [NullAllowed] NSError error);

	// typedef void (^UMPConsentFormPresentCompletionHandler)(NSError * _Nullable);
    delegate void ConsentFormPresentCompletionHandler([NullAllowed] NSError error);

	// typedef void (^UMPConsentInformationUpdateCompletionHandler)(NSError * _Nullable);
    delegate void ConsentInformationUpdateCompletionHandler([NullAllowed] NSError error);

	// @interface UMPConsentForm
	[DisableDefaultCtor]
	[BaseType(typeof(NSObject), Name = "UMPConsentForm")]    
	interface ConsentForm
	{
		// +(void)loadWithCompletionHandler:(UMPConsentFormLoadCompletionHandler _Nonnull)completionHandler;
		[Static]
		[Export ("loadWithCompletionHandler:")]
		void LoadWithCompletionHandler (ConsentFormLoadCompletionHandler completionHandler);

		// -(void)presentFromViewController:(id)viewController completionHandler:(UMPConsentFormPresentCompletionHandler _Nullable)completionHandler;
		[Export ("presentFromViewController:completionHandler:")]
		void PresentFromViewController (NSObject viewController, [NullAllowed] ConsentFormPresentCompletionHandler completionHandler);
	}

	// @interface UMPConsentInformation : NSObject
	[BaseType (typeof(NSObject), Name = "UMPConsentInformation")]
	interface ConsentInformation
	{
		// @property (readonly, nonatomic, class) UMPConsentInformation * _Nonnull sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		ConsentInformation SharedInstance { get; }

		// extern NSString *const _Nonnull UMPVersionString;
		[Field ("UMPVersionString", "__Internal")]
		NSString UMPVersionString { get; }

		// extern NSErrorDomain  _Nonnull const UMPErrorDomain;
		[Field ("UMPErrorDomain", "__Internal")]
		NSString UMPErrorDomain { get; }

		// @property (readonly, nonatomic) UMPConsentStatus consentStatus;
		[Export ("consentStatus")]
		ConsentStatus ConsentStatus { get; }

		// @property (readonly, nonatomic) UMPConsentType consentType;
		[Export ("consentType")]
		ConsentType ConsentType { get; }

		// @property (readonly, nonatomic) UMPFormStatus formStatus;
		[Export ("formStatus")]
		FormStatus FormStatus { get; }

		// -(void)requestConsentInfoUpdateWithParameters:(id)parameters completionHandler:(UMPConsentInformationUpdateCompletionHandler _Nonnull)handler;
		[Export ("requestConsentInfoUpdateWithParameters:completionHandler:")]
		void RequestConsentInfoUpdateWithParameters (NSObject parameters, ConsentInformationUpdateCompletionHandler handler);

		// -(void)reset;
		[Export ("reset")]
		void Reset ();
	}

	// @interface UMPDebugSettings : NSObject <NSCopying>
	[BaseType (typeof(NSObject), Name = "UMPDebugSettings")]
	interface DebugSettings : INSCopying
	{
		// @property (nonatomic) NSArray<NSString *> * _Nullable testDeviceIdentifiers;
		[NullAllowed, Export ("testDeviceIdentifiers", ArgumentSemantic.Assign)]
		string[] TestDeviceIdentifiers { get; set; }

		// @property (nonatomic) UMPDebugGeography geography;
		[Export ("geography", ArgumentSemantic.Assign)]
		DebugGeography Geography { get; set; }
	}

	// @interface UMPRequestParameters : NSObject
	[BaseType (typeof(NSObject), Name = "UMPRequestParameters")]
	interface RequestParameters
	{
		// @property (nonatomic) BOOL tagForUnderAgeOfConsent;
		[Export ("tagForUnderAgeOfConsent")]
		bool TagForUnderAgeOfConsent { get; set; }

		// @property (copy, nonatomic) UMPDebugSettings * _Nullable debugSettings;
		[NullAllowed, Export ("debugSettings", ArgumentSemantic.Copy)]
		DebugSettings DebugSettings { get; set; }
	}
}