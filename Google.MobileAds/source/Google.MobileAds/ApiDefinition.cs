using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using StoreKit;
using CoreGraphics;
using System.Collections.Generic;

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

	[Static]
	interface NativeAppInstallConstants {
		// GAD_EXTERN NSString *const GADNativeAppInstallHeadlineAsset;
		[Field ("GADNativeAppInstallHeadlineAsset", "__Internal")]
		NSString HeadlineAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallCallToActionAsset;
		[Field ("GADNativeAppInstallCallToActionAsset", "__Internal")]
		NSString CallToActionAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallIconAsset;
		[Field ("GADNativeAppInstallIconAsset", "__Internal")]
		NSString IconAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallBodyAsset;
		[Field ("GADNativeAppInstallBodyAsset", "__Internal")]
		NSString BodyAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallStoreAsset;
		[Field ("GADNativeAppInstallStoreAsset", "__Internal")]
		NSString StoreAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallPriceAsset;
		[Field ("GADNativeAppInstallPriceAsset", "__Internal")]
		NSString PriceAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallImageAsset;
		[Field ("GADNativeAppInstallImageAsset", "__Internal")]
		NSString ImageAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallStarRatingAsset;
		[Field ("GADNativeAppInstallStarRatingAsset", "__Internal")]
		NSString StarRatingAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallAttributionIconAsset;
		[Field ("GADNativeAppInstallAttributionIconAsset", "__Internal")]
		NSString AttributionIconAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallAttributionTextAsset;
		[Field ("GADNativeAppInstallAttributionTextAsset", "__Internal")]
		NSString AttributionTextAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallMediaViewAsset;
		[Field ("GADNativeAppInstallMediaViewAsset", "__Internal")]
		NSString MediaViewAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallAdChoicesViewAsset;
		[Field ("GADNativeAppInstallAdChoicesViewAsset", "__Internal")]
		NSString AdChoicesViewAsset { get; }

		// GAD_EXTERN NSString *const GADNativeAppInstallBackgroundAsset;
		[Field ("GADNativeAppInstallBackgroundAsset", "__Internal")]
		NSString BackgroundAsset { get; }
	}

	[Static]
	interface NativeContentConstants {
		// GAD_EXTERN NSString *const GADNativeContentHeadlineAsset;
		[Field ("GADNativeContentHeadlineAsset", "__Internal")]
		NSString HeadlineAsset { get; }

		// GAD_EXTERN NSString *const GADNativeContentBodyAsset;
		[Field ("GADNativeContentBodyAsset", "__Internal")]
		NSString BodyAsset { get; }

		// GAD_EXTERN NSString *const GADNativeContentCallToActionAsset;
		[Field ("GADNativeContentCallToActionAsset", "__Internal")]
		NSString CallToActionAsset { get; }

		// GAD_EXTERN NSString *const GADNativeContentAdvertiserAsset;
		[Field ("GADNativeContentAdvertiserAsset", "__Internal")]
		NSString AdvertiserAsset { get; }

		// GAD_EXTERN NSString *const GADNativeContentImageAsset;
		[Field ("GADNativeContentImageAsset", "__Internal")]
		NSString ImageAsset { get; }

		// GAD_EXTERN NSString *const GADNativeContentLogoAsset;
		[Field ("GADNativeContentLogoAsset", "__Internal")]
		NSString LogoAsset { get; }

		// GAD_EXTERN NSString *const GADNativeContentAttributionIconAsset;
		[Field ("GADNativeContentAttributionIconAsset", "__Internal")]
		NSString AttributionIconAsset { get; }

		// GAD_EXTERN NSString *const GADNativeContentAttributionTextAsset;
		[Field ("GADNativeContentAttributionTextAsset", "__Internal")]
		NSString AttributionTextAsset { get; }

		// GAD_EXTERN NSString *const GADNativeContentMediaViewAsset;
		[Field ("GADNativeContentMediaViewAsset", "__Internal")]
		NSString MediaViewAsset { get; }

		// GAD_EXTERN NSString *const GADNativeContentAdChoicesViewAsset;
		[Field ("GADNativeContentAdChoicesViewAsset", "__Internal")]
		NSString AdChoicesViewAsset { get; }

		// GAD_EXTERN NSString *const GADNativeContentBackgroundAsset;
		[Field ("GADNativeContentBackgroundAsset", "__Internal")]
		NSString BackgroundAsset { get; }
	}

	// @interface GADMobileAds : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GADMobileAds")]
	interface MobileAds {
		// + (GADMobileAds *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		MobileAds SharedInstance { get; }

		// + (void)configureWithApplicationID:(NSString *)applicationID;
		[Static]
		[Export ("configureWithApplicationID:")]
		void Configure (string applicationId);

		// +(void)disableAutomatedInAppPurchaseReporting;
		[Static]
		[Export ("disableAutomatedInAppPurchaseReporting")]
		void DisableAutomatedInAppPurchaseReporting ();

		// +(void)disableSDKCrashReporting;
		[Static]
		[Export ("disableSDKCrashReporting")]
		void DisableSDKCrashReporting ();

		// @property(nonatomic, assign) float applicationVolume;
		[Export ("applicationVolume", ArgumentSemantic.Assign)]
		float ApplicationVolume { get; set; }

		// @property(nonatomic, assign) BOOL applicationMuted;
		[Export ("applicationMuted", ArgumentSemantic.Assign)]
		bool ApplicationMuted { get; set; }

		// @property(nonatomic, readonly, strong) GADAudioVideoManager *audioVideoManager;
		[Export ("audioVideoManager", ArgumentSemantic.Strong)]
		AudioVideoManager AudioVideoManager { get; }

		// - (BOOL)isSDKVersionAtLeastMajor:(NSInteger)major minor:(NSInteger)minor patch:(NSInteger)patch;
		[Export ("isSDKVersionAtLeastMajor:minor:patch:")]
		void IsSDKVersionAtLeast (nint major, nint minor, nint patch);
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
		// @property (readonly, copy, nonatomic) NSString * type;
		[Export ("type")]
		string Type { get; }

		// @property (readonly, copy, nonatomic) NSDecimalNumber * amount;
		[Export ("amount", ArgumentSemantic.Copy)]
		NSDecimalNumber Amount { get; }

		// -(instancetype)initWithRewardType:(NSString *)rewardType rewardAmount:(NSDecimalNumber *)rewardAmount __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithRewardType:rewardAmount:")]
		IntPtr Constructor (string rewardType, NSDecimalNumber rewardAmount);
	}

	[BaseType (typeof (UIView),
		Name = "GADBannerView",
		Delegates = new string [] { "Delegate", "AdSizeDelegate" },
		Events = new Type [] { typeof (BannerViewDelegate), typeof (AdSizeDelegate) })]
	interface BannerView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (AdSize size, CGPoint origin);

		[Export ("initWithAdSize:")]
		IntPtr Constructor (AdSize size);

		[NullAllowed]
		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitID { get; set; }

		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		[Export ("adSize", ArgumentSemantic.Assign)]
		AdSize AdSize { get; set; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IBannerViewDelegate Delegate { get; set; }

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

		[NullAllowed]
		[Export ("adNetworkClassName")]
		string AdNetworkClassName { get; }

		[Obsolete]
		[Export ("hasAutoRefreshed", ArgumentSemantic.Assign)]
		bool HasAutoRefreshed { get; }

		[Obsolete ("Use adNetworkClassName.")]
		[NullAllowed]
		[Export ("mediatedAdView", ArgumentSemantic.Weak)]
		UIView MediatedAdView { get; }
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

	// @interface GADCorrelator : NSObject
	[BaseType (typeof (NSObject), Name = "GADCorrelator")]
	interface Correlator {
		// -(void)reset;
		[Export ("reset")]
		void Reset ();
	}

	// @interface GADCorrelatorAdLoaderOptions : GADAdLoaderOptions
	[BaseType (typeof (AdLoaderOptions), Name = "GADCorrelatorAdLoaderOptions")]
	interface CorrelatorAdLoaderOptions {
		// @property (nonatomic, strong) GADCorrelator * correlator;
		[NullAllowed]
		[Export ("correlator", ArgumentSemantic.Strong)]
		Correlator Correlator { get; set; }
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

		[Export ("adUnitID", ArgumentSemantic.Copy)]
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

		[Export ("isReady", ArgumentSemantic.Assign)]
		bool IsReady { get; }

		[Export ("hasBeenUsed", ArgumentSemantic.Assign)]
		bool HasBeenUsed { get; }

		[Export ("adNetworkClassName", ArgumentSemantic.Copy)]
		string AdNetworkClassName { get; }

		[Export ("presentFromRootViewController:")]
		void PresentFromRootViewController ([NullAllowed] UIViewController rootViewController);
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

		[Static]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		[NullAllowed]
		[Export ("testDevices", ArgumentSemantic.Copy)]
		string [] TestDevices { get; set; }

		[Export ("gender", ArgumentSemantic.Assign)]
		Gender Gender { get; set; }

		[NullAllowed]
		[Export ("birthday", ArgumentSemantic.Copy)]
		NSDate Birthday { get; set; }

		[Export ("setLocationWithLatitude:longitude:accuracy:")]
		void SetLocation (nfloat latitude, nfloat longitude, nfloat accuracyInMeters);

		[Obsolete ("Use SetLocation (nfloat, nfloat, nfloat) method instead.")]
		[Export ("setLocationWithDescription:")]
		void SetLocation (string locationDescription);

		[Export ("tagForChildDirectedTreatment:")]
		void Tag (bool forChildDirectedTreatment);

		[Obsolete ("Please, use Tag method instead. This will be removed in future versions.")]
		[Wrap ("Tag (childDirectedTreatment)")]
		void TagForChildDirectedTreatment (bool childDirectedTreatment);

		[NullAllowed]
		[Export ("keywords", ArgumentSemantic.Copy)]
		string [] Keywords { get; set; }

		[NullAllowed]
		[Export ("contentURL", ArgumentSemantic.Copy)]
		string ContentUrl { get; set; }

		[NullAllowed]
		[Export ("requestAgent", ArgumentSemantic.Copy)]
		string RequestAgent { get; set; }

		#region "Deprecated GAdRequest Methods"

		[Export ("setBirthdayWithMonth:day:year:")]
		void SetBirthday (nint m, nint d, nint y);

		#endregion

	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSError), Name = "GADRequestError")]
	interface RequestError {

		[Export ("initWithDomain:code:userInfo:")]
		IntPtr Constructor (NSString appDomain, nint code, NSDictionary userInfo);
	}

	// @interface GADRewardBasedVideoAd : NSObject
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

		// +(GADRewardBasedVideoAd *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		RewardBasedVideoAd SharedInstance { get; }

		// -(void)loadRequest:(GADRequest *)request withAdUnitID:(NSString *)adUnitID;
		[Export ("loadRequest:withAdUnitID:")]
		void LoadRequest (Request request, string adUnitId);

		// -(void)presentFromRootViewController:(UIViewController *)viewController;
		[Export ("presentFromRootViewController:")]
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

	interface IAppEventDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAppEventDelegate")]
	interface AppEventDelegate {
		[Export ("adView:didReceiveAppEvent:withInfo:")]
		void AdViewDidReceiveAppEvent (BannerView banner, string name, [NullAllowed] string info);

		[Export ("interstitial:didReceiveAppEvent:withInfo:")]
		void InterstitialDidReceiveAppEvent (Interstitial interstitial, string name, [NullAllowed] string info);
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

	[BaseType (typeof (Request), Name = "GADSearchRequest")]
	interface SearchRequest {

		[NullAllowed]
		[Export ("query", ArgumentSemantic.Copy)]
		string Query { get; set; }

		[NullAllowed]
		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		UIColor BackgroundColor { get; }

		[NullAllowed]
		[Export ("gradientFrom", ArgumentSemantic.Copy)]
		UIColor GradientFrom { get; }

		[NullAllowed]
		[Export ("gradientTo", ArgumentSemantic.Copy)]
		UIColor GradientTo { get; }

		[NullAllowed]
		[Export ("headerColor", ArgumentSemantic.Copy)]
		UIColor HeaderColor { get; set; }

		[NullAllowed]
		[Export ("descriptionTextColor", ArgumentSemantic.Copy)]
		UIColor DescriptionTextColor { get; set; }

		[NullAllowed]
		[Export ("anchorTextColor", ArgumentSemantic.Copy)]
		UIColor AnchorTextColor { get; set; }

		[NullAllowed]
		[Export ("fontFamily", ArgumentSemantic.Copy)]
		string FontFamily { get; set; }

		[Export ("headerTextSize", ArgumentSemantic.Assign)]
		nuint HeaderTextSize { get; set; }

		[NullAllowed]
		[Export ("borderColor", ArgumentSemantic.Copy)]
		UIColor BorderColor { get; set; }

		[Export ("borderType", ArgumentSemantic.Assign)]
		SearchBorderType BorderType { get; set; }

		[Export ("borderThickness", ArgumentSemantic.Assign)]
		nuint BorderThickness { get; set; }

		[NullAllowed]
		[Export ("customChannels", ArgumentSemantic.Copy)]
		string CustomChannels { get; set; }

		[Export ("callButtonColor", ArgumentSemantic.Assign)]
		SearchCallButtonColor CallButtonColor { get; set; }

		[Export ("setBackgroundSolid:")]
		void SetBackgroundSolid (UIColor color);

		[Export ("setBackgroundGradientFrom:toColor:")]
		void SetBackgroundGradient (UIColor fromColor, UIColor toColor);
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

		// @property (readonly, nonatomic, strong) GADVideoController * _Nullable videoController;
		[NullAllowed]
		[Export ("videoController", ArgumentSemantic.Strong)]
		VideoController VideoController { get; }

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

		// @property (readonly, copy, nonatomic) NSString * _Nullable adNetworkClassName;
		[NullAllowed]
		[Export ("adNetworkClassName")]
		string AdNetworkClassName { get; }

		// -(void)registerAdView:(UIView * _Nonnull)adView clickableAssetViews:(NSDictionary<GADUnifiedNativeAssetIdentifier,UIView *> * _Nonnull)clickableAssetViews nonclickableAssetViews:(NSDictionary<GADUnifiedNativeAssetIdentifier,UIView *> * _Nonnull)nonclickableAssetViews;
		[Export ("registerAdView:clickableAssetViews:nonclickableAssetViews:")]
		void RegisterAdView (UIView adView, NSDictionary<NSString, UIView> clickableAssetViews, NSDictionary<NSString, UIView> nonclickableAssetViews);

		[Wrap ("RegisterAdView (adView, NSDictionary<NSString, UIView>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (clickableAssetViews.Values), System.Linq.Enumerable.ToArray (clickableAssetViews.Keys), clickableAssetViews.Keys.Count), NSDictionary<NSString, UIView>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (nonclickableAssetViews.Values), System.Linq.Enumerable.ToArray (nonclickableAssetViews.Keys), nonclickableAssetViews.Keys.Count))")]
		void RegisterAdView (UIView adView, Dictionary<string, UIView> clickableAssetViews, Dictionary<string, UIView> nonclickableAssetViews);

		// -(void)unregisterAdView;
		[Export ("unregisterAdView")]
		void UnregisterAdView ();

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

		// - (BOOL)hasVideoContent;
		[Export ("hasVideoContent")]
		bool HasVideoContent ();

		// - (double)aspectRatio;
		[Export ("aspectRatio")]
		double AspectRatio { get; }

		// - (BOOL)customControlsEnabled;
		[Export ("customControlsEnabled")]
		bool IsCustomControlsEnabled { get; }

		// - (BOOL)clickToExpandEnabled;
		[Export ("clickToExpandEnabled")]
		bool IsClickToExpandEnabled { get; }
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

	[Static]
	interface AdLoaderType {
		// extern NSString *const kGADAdLoaderAdTypeNativeAppInstall;
		[Field ("kGADAdLoaderAdTypeNativeAppInstall", "__Internal")]
		NSString NativeAppInstall { get; }

		// extern NSString *const kGADAdLoaderAdTypeNativeContent;
		[Field ("kGADAdLoaderAdTypeNativeContent", "__Internal")]
		NSString NativeContent { get; }

		// extern NSString *const kGADAdLoaderAdTypeNativeCustomTemplate;
		[Field ("kGADAdLoaderAdTypeNativeCustomTemplate", "__Internal")]
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

		// @property (readonly, copy, nonatomic) NSString * adNetworkClassName;
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

	// @interface GADNativeAppInstallAd : GADNativeAd
	[BaseType (typeof (NativeAd), Name = "GADNativeAppInstallAd")]
	interface NativeAppInstallAd {
		// @property (readonly, copy, nonatomic) NSString * headline;
		[NullAllowed]
		[Export ("headline")]
		string Headline { get; }

		// @property (readonly, copy, nonatomic) NSString * callToAction;
		[NullAllowed]
		[Export ("callToAction")]
		string CallToAction { get; }

		// @property (readonly, nonatomic, strong) GADNativeAdImage * icon;
		[NullAllowed]
		[Export ("icon", ArgumentSemantic.Strong)]
		NativeAdImage Icon { get; }

		// @property (readonly, copy, nonatomic) NSString * body;
		[NullAllowed]
		[Export ("body")]
		string Body { get; }

		// @property (readonly, copy, nonatomic) NSString * store;
		[NullAllowed]
		[Export ("store")]
		string Store { get; }

		// @property (readonly, copy, nonatomic) NSString * price;
		[NullAllowed]
		[Export ("price")]
		string Price { get; }

		// @property (readonly, nonatomic, strong) NSArray * images;
		[NullAllowed]
		[Export ("images", ArgumentSemantic.Strong)]
		NativeAdImage [] Images { get; }

		// @property (readonly, copy, nonatomic) NSDecimalNumber * starRating;
		[NullAllowed]
		[Export ("starRating", ArgumentSemantic.Copy)]
		NSDecimalNumber StarRating { get; }

		// @property(nonatomic, strong, readonly) GADVideoController *videoController;
		[Export ("videoController", ArgumentSemantic.Strong)]
		VideoController VideoController { get; }

		// - (void)registerAdView:(UIView *)adView assetViews:(NSDictionary<NSString *, UIView *> *)assetViews;
		[Obsolete ("Use RegisterAdView overloaded method instead.")]
		[Export ("registerAdView:assetViews:")]
		void RegisterAdView (UIView adView, NSDictionary<NSString, UIView> assetViews);

		// - (void)registerAdView:(UIView *)adView clickableAssetViews:(NSDictionary<GADNativeAppInstallAssetID, UIView*>*)clickableAssetViews nonclickableAssetViews:(NSDictionary<GADNativeAppInstallAssetID, UIView*>*)nonclickableAssetViews;
		[Export ("registerAdView:clickableAssetViews:nonclickableAssetViews:")]
		void RegisterAdView (UIView adView, NSDictionary<NSString, UIView> clickableAssetViews, NSDictionary<NSString, UIView> nonclickableAssetViews);

		// - (void)unregisterAdView;
		[Export ("unregisterAdView")]
		void UnregisterAdView ();
	}

	interface INativeAppInstallAdLoaderDelegate {
	}

	// @protocol GADNativeAppInstallAdLoaderDelegate <GADAdLoaderDelegate>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADNativeAppInstallAdLoaderDelegate")]
	interface NativeAppInstallAdLoaderDelegate : AdLoaderDelegate {
		// @required -(void)adLoader:(GADAdLoader *)adLoader didReceiveNativeAppInstallAd:(GADNativeAppInstallAd *)nativeAppInstallAd;
		[Abstract]
		[Export ("adLoader:didReceiveNativeAppInstallAd:")]
		void DidReceiveNativeAppInstallAd (AdLoader adLoader, NativeAppInstallAd nativeAppInstallAd);
	}

	// @interface GADNativeAppInstallAdView : UIView
	[BaseType (typeof (UIView), Name = "GADNativeAppInstallAdView")]
	interface NativeAppInstallAdView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, strong) GADNativeAppInstallAd * nativeAppInstallAd;
		[NullAllowed]
		[Export ("nativeAppInstallAd", ArgumentSemantic.Strong)]
		NativeAppInstallAd NativeAppInstallAd { get; set; }

		// @property (nonatomic, weak) UIView * __nullable headlineView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("headlineView", ArgumentSemantic.Weak)]
		UIView HeadlineView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable callToActionView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("callToActionView", ArgumentSemantic.Weak)]
		UIView CallToActionView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable iconView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("iconView", ArgumentSemantic.Weak)]
		UIView IconView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable bodyView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("bodyView", ArgumentSemantic.Weak)]
		UIView BodyView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable storeView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("storeView", ArgumentSemantic.Weak)]
		UIView StoreView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable priceView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("priceView", ArgumentSemantic.Weak)]
		UIView PriceView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable imageView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("imageView", ArgumentSemantic.Weak)]
		UIView ImageView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable starRatingView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("starRatingView", ArgumentSemantic.Weak)]
		UIView StarRatingView { get; set; }

		// @property(nonatomic, weak) UIView * __nullable mediaView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("mediaView", ArgumentSemantic.Weak)]
		UIView MediaView { get; set; }

		// @property(nonatomic, weak, GAD_NULLABLE) IBOutlet GADAdChoicesView *adChoicesView;
		[NullAllowed]
		[Export ("adChoicesView", ArgumentSemantic.Weak)]
		AdChoicesView AdChoicesView { get; set; }
	}

	// @interface GADNativeContentAd : GADNativeAd
	[BaseType (typeof (NativeAd), Name = "GADNativeContentAd")]
	interface NativeContentAd {
		// @property (readonly, copy, nonatomic) NSString * headline;
		[NullAllowed]
		[Export ("headline")]
		string Headline { get; }

		// @property (readonly, copy, nonatomic) NSString * body;
		[NullAllowed]
		[Export ("body")]
		string Body { get; }

		// @property (readonly, copy, nonatomic) NSArray * images;
		[NullAllowed]
		[Export ("images", ArgumentSemantic.Copy)]
		NativeAdImage [] Images { get; }

		// @property (readonly, nonatomic, strong) NativeAdImage * logo;
		[NullAllowed]
		[Export ("logo", ArgumentSemantic.Strong)]
		NativeAdImage Logo { get; }

		// @property (readonly, copy, nonatomic) NSString * callToAction;
		[NullAllowed]
		[Export ("callToAction")]
		string CallToAction { get; }

		// @property (readonly, copy, nonatomic) NSString * advertiser;
		[NullAllowed]
		[Export ("advertiser")]
		string Advertiser { get; }

		// @property(nonatomic, strong, readonly) GADVideoController *videoController;
		[Export ("videoController", ArgumentSemantic.Strong)]
		VideoController VideoController { get; }

		// - (void)registerAdView:(UIView *)adView assetViews:(NSDictionary<NSString *, UIView *> *)assetViews;
		[Obsolete ("Use RegisterAdView overloaded method instead.")]
		[Export ("registerAdView:assetViews:")]
		void RegisterAdView (UIView adView, NSDictionary<NSString, UIView> assetViews);

		// - (void)registerAdView:(UIView *)adView clickableAssetViews:(NSDictionary<GADNativeAppInstallAssetID, UIView*>*)clickableAssetViews nonclickableAssetViews:(NSDictionary<GADNativeAppInstallAssetID, UIView*>*)nonclickableAssetViews;
		[Export ("registerAdView:clickableAssetViews:nonclickableAssetViews:")]
		void RegisterAdView (UIView adView, NSDictionary<NSString, UIView> clickableAssetViews, NSDictionary<NSString, UIView> nonclickableAssetViews);

		// - (void)unregisterAdView;
		[Export ("unregisterAdView")]
		void UnregisterAdView ();
	}

	interface INativeContentAdLoaderDelegate {
	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADNativeContentAdLoaderDelegate")]
	interface NativeContentAdLoaderDelegate : AdLoaderDelegate {
		// @required -(void)adLoader:(GADAdLoader *)adLoader didReceiveNativeContentAd:(GADNativeContentAd *)nativeContentAd;
		[Abstract]
		[Export ("adLoader:didReceiveNativeContentAd:")]
		void DidReceiveNativeContentAd (AdLoader adLoader, NativeContentAd nativeContentAd);
	}

	// @interface GADNativeContentAdView : UIView
	[BaseType (typeof (UIView), Name = "GADNativeContentAdView")]
	interface NativeContentAdView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, strong) GADNativeContentAd * nativeContentAd;
		[NullAllowed]
		[Export ("nativeContentAd", ArgumentSemantic.Strong)]
		NativeContentAd NativeContentAd { get; set; }

		// @property (nonatomic, weak) UIView * __nullable headlineView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("headlineView", ArgumentSemantic.Weak)]
		UIView HeadlineView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable bodyView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("bodyView", ArgumentSemantic.Weak)]
		UIView BodyView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable imageView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("imageView", ArgumentSemantic.Weak)]
		UIView ImageView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable logoView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("logoView", ArgumentSemantic.Weak)]
		UIView LogoView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable callToActionView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("callToActionView", ArgumentSemantic.Weak)]
		UIView CallToActionView { get; set; }

		// @property (nonatomic, weak) UIView * __nullable advertiserView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("advertiserView", ArgumentSemantic.Weak)]
		UIView AdvertiserView { get; set; }

		// @property(nonatomic, weak, GAD_NULLABLE) IBOutlet GADMediaView *mediaView __attribute__((iboutlet));
		[NullAllowed]
		[Export ("mediaView", ArgumentSemantic.Weak)]
		MediaView MediaView { get; set; }

		// @property(nonatomic, weak, GAD_NULLABLE) IBOutlet GADAdChoicesView *adChoicesView;
		[NullAllowed]
		[Export ("adChoicesView", ArgumentSemantic.Weak)]
		AdChoicesView AdChoicesView { get; set; }
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
		string TemplateID { get; }

		// @property (readonly, nonatomic) NSArray * availableAssetKeys;
		[Export ("availableAssetKeys")]
		string [] AvailableAssetKeys { get; }

		// @property(nonatomic, readonly, strong) GADVideoController *videoController;
		[Export ("videoController", ArgumentSemantic.Strong)]
		VideoController VideoController { get; }

		// @property(nonatomic, readonly, strong, GAD_NULLABLE) GADMediaView *mediaView;
		[NullAllowed]
		[Export ("mediaView", ArgumentSemantic.Strong)]
		MediaView MediaView { get; }

		// @property(atomic, copy) GADNativeAdCustomClickHandler customClickHandler;
		[NullAllowed]
		[Export ("customClickHandler", ArgumentSemantic.Copy)]
		NativeAdCustomClickHandle CustomClickHandler { get; }

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
	[DisableDefaultCtor]
	[BaseType (typeof (UIView),
		   Name = "GADNativeExpressAdView",
		   Delegates = new string [] { "Delegate" },
		   Events = new Type [] { typeof (NativeExpressAdViewDelegate) })]
	interface NativeExpressAdView {
		// -(instancetype)initWithAdSize:(id)adSize origin:(CGPoint)origin;
		[NullAllowed]
		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (AdSize adSize, CGPoint origin);

		// -(instancetype)initWithAdSize:(id)adSize;
		[NullAllowed]
		[Export ("initWithAdSize:")]
		IntPtr Constructor (AdSize adSize);

		// @property(nonatomic, strong, readonly) GADVideoController *videoController;
		[Export ("videoController", ArgumentSemantic.Strong)]
		VideoController VideoController { get; set; }

		// @property (copy, nonatomic) NSString * adUnitID;
		[NullAllowed]
		[Export ("adUnitID")]
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
		[Export ("preferredImageOrientation", ArgumentSemantic.Assign)]
		NativeAdImageAdLoaderOptionsOrientation PreferredImageOrientation { get; set; }
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
		[NullAllowed]
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
		[NullAllowed]
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
		// @required -(void)customEventNativeAd:(id<GADCustomEventNativeAd>)customEventNativeAd didReceiveMediatedNativeAd:(id<GADMediatedNativeAd>)mediatedNativeAd;
		[Abstract]
		[Export ("customEventNativeAd:didReceiveMediatedNativeAd:")]
		void DidReceiveMediatedNativeAd (ICustomEventNativeAd customEventNativeAd, IMediatedNativeAd mediatedNativeAd);

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

		[Export ("userGender", ArgumentSemantic.Assign)]
		Gender UserGender { get; }

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

	interface IMediatedNativeAd {
	}

	// @protocol GADMediatedNativeAd <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADMediatedNativeAd")]
	interface MediatedNativeAd {
		// @required -(id<GADMediatedNativeAdDelegate>)mediatedNativeAdDelegate;
		[Abstract]
		[return: NullAllowed]
		[Export ("mediatedNativeAdDelegate")]
		IMediatedNativeAdDelegate GetMediatedNativeAdDelegate ();

		// @required -(NSDictionary *)extraAssets;
		[Abstract]
		[return: NullAllowed]
		[Export ("extraAssets")]
		NSDictionary ExtraAssets ();
	}

	interface IMediatedNativeAdDelegate {
	}

	// @protocol GADMediatedNativeAdDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADMediatedNativeAdDelegate")]
	interface MediatedNativeAdDelegate {
		// @optional -(void)mediatedNativeAd:(id<GADMediatedNativeAd>)mediatedNativeAd didRenderInView:(UIView *)view viewController:(UIViewController *)viewController;;
		[Export ("mediatedNativeAd:didRenderInView:viewController:")]
		void DidRenderInView (IMediatedNativeAd mediatedNativeAd, UIView view, UIViewController viewController);

		// @optional -(void)mediatedNativeAdDidRecordImpression:(id<GADMediatedNativeAd>)mediatedNativeAd;
		[Export ("mediatedNativeAdDidRecordImpression:")]
		void DidRecordImpression (IMediatedNativeAd mediatedNativeAd);

		// @optional -(void)mediatedNativeAd:(id<GADMediatedNativeAd>)mediatedNativeAd didRecordClickOnAssetWithName:(NSString *)assetName view:(UIView *)view viewController:(UIViewController *)viewController;
		[Export ("mediatedNativeAd:didRecordClickOnAssetWithName:view:viewController:")]
		void DidRecordClick (IMediatedNativeAd mediatedNativeAd, string assetName, UIView view, UIViewController viewController);

		// - (void)mediatedNativeAd:(id<GADMediatedNativeAd>)mediatedNativeAd didUntrackView:(UIView*)view;
		[Export ("mediatedNativeAd:didUntrackView:")]
		void DidUntrackView (IMediatedNativeAd mediatedNativeAd, [NullAllowed] UIView view);
	}

	// @interface GADMediatedNativeAdNotificationSource : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GADMediatedNativeAdNotificationSource")]
	interface MediatedNativeAdNotificationSource {

		// + (void)mediatedNativeAdDidRecordImpression:(id<GADMediatedNativeAd>)mediatedNativeAd;
		[Static]
		[Export ("mediatedNativeAdDidRecordImpression:")]
		void DidRecordImpression (IMediatedNativeAd mediatedNativeAd);

		// + (void)mediatedNativeAdDidRecordClick:(id<GADMediatedNativeAd>)mediatedNativeAd;
		[Static]
		[Export ("mediatedNativeAdDidRecordClick:")]
		void DidRecordClick (IMediatedNativeAd mediatedNativeAd);

		// +(void)mediatedNativeAdWillPresentScreen:(id<GADMediatedNativeAd>)mediatedNativeAd;
		[Static]
		[Export ("mediatedNativeAdWillPresentScreen:")]
		void WillPresentScreen (IMediatedNativeAd mediatedNativeAd);

		// +(void)mediatedNativeAdWillDismissScreen:(id<GADMediatedNativeAd>)mediatedNativeAd;
		[Static]
		[Export ("mediatedNativeAdWillDismissScreen:")]
		void WillDismissScreen (IMediatedNativeAd mediatedNativeAd);

		// +(void)mediatedNativeAdDidDismissScreen:(id<GADMediatedNativeAd>)mediatedNativeAd;
		[Static]
		[Export ("mediatedNativeAdDidDismissScreen:")]
		void DidDismissScreen (IMediatedNativeAd mediatedNativeAd);

		// +(void)mediatedNativeAdWillLeaveApplication:(id<GADMediatedNativeAd>)mediatedNativeAd;
		[Static]
		[Export ("mediatedNativeAdWillLeaveApplication:")]
		void WillLeaveApplication (IMediatedNativeAd mediatedNativeAd);

		// +(void)mediatedNativeAdDidPlayVideo:(id<GADMediatedNativeAd> _Nonnull)mediatedNativeAd;
		[Static]
		[Export ("mediatedNativeAdDidPlayVideo:")]
		void DidPlayVideo (IMediatedNativeAd mediatedNativeAd);

		// +(void)mediatedNativeAdDidPauseVideo:(id<GADMediatedNativeAd> _Nonnull)mediatedNativeAd;
		[Static]
		[Export ("mediatedNativeAdDidPauseVideo:")]
		void DidPauseVideo (IMediatedNativeAd mediatedNativeAd);

		// +(void)mediatedNativeAdDidEndVideoPlayback:(id<GADMediatedNativeAd> _Nonnull)mediatedNativeAd;
		[Static]
		[Export ("mediatedNativeAdDidEndVideoPlayback:")]
		void DidEndVideoPlayback (IMediatedNativeAd mediatedNativeAd);
	}

	interface IMediatedNativeAppInstallAd {
	}

	// @protocol GADMediatedNativeAppInstallAd <GADMediatedNativeAd>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADMediatedNativeAppInstallAd")]
	interface MediatedNativeAppInstallAd : MediatedNativeAd {
		// @required -(NSString *)headline;
		[Abstract]
		[return: NullAllowed]
		[Export ("headline")]
		string GetHeadline ();

		// @required -(NSArray *)images;
		[Abstract]
		[return: NullAllowed]
		[Export ("images")]
		NativeAdImage [] GetImages ();

		// @required -(NSString *)body;
		[Abstract]
		[return: NullAllowed]
		[Export ("body")]
		string GetBody ();

		// @required -(GADNativeAdImage *)icon;
		[Abstract]
		[return: NullAllowed]
		[Export ("icon")]
		NativeAdImage GetIcon ();

		// @required -(NSString *)callToAction;
		[Abstract]
		[return: NullAllowed]
		[Export ("callToAction")]
		string GetCallToAction ();

		// @required -(NSDecimalNumber *)starRating;
		[Abstract]
		[return: NullAllowed]
		[Export ("starRating")]
		NSDecimalNumber StarRating ();

		// @required -(NSString *)store;
		[Abstract]
		[return: NullAllowed]
		[Export ("store")]
		string GetStore ();

		// @required -(NSString *)price;
		[Abstract]
		[return: NullAllowed]
		[Export ("price")]
		string GetPrice ();

		// - (UIView *GAD_NULLABLE_TYPE)adChoicesView;
		[return: NullAllowed]
		[Export ("adChoicesView")]
		UIView GetAdChoicesView ();

		// @optional -(UIView * _Nullable)mediaView;
		[return: NullAllowed]
		[Export ("mediaView")]
		UIView GetMediaView ();

		// @optional -(BOOL)hasVideoContent;
		[Export ("hasVideoContent")]
		bool HasVideoContent ();
	}

	interface IMediatedNativeContentAd {
	}

	// @protocol GADMediatedNativeContentAd <GADMediatedNativeAd>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADMediatedNativeContentAd")]
	interface MediatedNativeContentAd : MediatedNativeAd {
		// @required -(NSString *)headline;
		[Abstract]
		[return: NullAllowed]
		[Export ("headline")]
		string GetHeadline ();

		// @required -(NSString *)body;
		[Abstract]
		[return: NullAllowed]
		[Export ("body")]
		string GetBody ();

		// @required -(NSArray *)images;
		[Abstract]
		[return: NullAllowed]
		[Export ("images")]
		NativeAdImage [] GetImages ();

		// @required -(GADNativeAdImage *)logo;
		[Abstract]
		[return: NullAllowed]
		[Export ("logo")]
		NativeAdImage GetLogo ();

		// @required -(NSString *)callToAction;
		[Abstract]
		[return: NullAllowed]
		[Export ("callToAction")]
		string GetCallToAction ();

		// @required -(NSString *)advertiser;
		[Abstract]
		[return: NullAllowed]
		[Export ("advertiser")]
		string GetAdvertiser ();

		// - (UIView *GAD_NULLABLE_TYPE)adChoicesView;
		[return: NullAllowed]
		[Export ("adChoicesView")]
		UIView GetAdChoicesView ();

		// @optional -(UIView * _Nullable)mediaView;
		[return: NullAllowed]
		[Export ("mediaView")]
		UIView GetMediaView ();

		// @optional -(BOOL)hasVideoContent;
		[Export ("hasVideoContent")]
		bool HasVideoContent ();
	}

	// @interface GADMediaView : UIView
	[BaseType (typeof (NSObject), Name = "GADMediaView")]
	interface MediaView {
	}

	#endregion
}

namespace Google.MobileAds.DoubleClick {
	#region DoubleClick

	interface IBannerAdLoaderDelegate {
	}

	// @protocol DFPBannerAdLoaderDelegate<GADAdLoaderDelegate>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADBannerAdLoaderDelegate")]
	interface BannerAdLoaderDelegate : Google.MobileAds.AdLoaderDelegate {
		// - (NSArray<NSValue *> *)validBannerSizesForAdLoader:(GADAdLoader *)adLoader;
		[Abstract]
		[Export ("validBannerSizesForAdLoader:")]
		NSValue [] ValidBannerSizes (Google.MobileAds.AdLoader adLoader);

		// - (void)adLoader:(GADAdLoader *)adLoader didReceiveDFPBannerView:(DFPBannerView *)bannerView;
		[Abstract]
		[Export ("adLoader:didReceiveDFPBannerView:")]
		NSValue [] DidReceiveBannerView (Google.MobileAds.AdLoader adLoader, BannerView bannerView);
	}

	[BaseType (typeof (Google.MobileAds.BannerView),
		Name = "DFPBannerView",
		Delegates = new string [] { "AdSizeDelegate" },
		Events = new Type [] { typeof (Google.MobileAds.AdSizeDelegate) })]
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

		// @property(nonatomic, strong) GADCorrelator *correlator;
		[NullAllowed]
		[Export ("correlator", ArgumentSemantic.Strong)]
		Google.MobileAds.Correlator Correlator { get; set; }

		[Export ("enableManualImpressions", ArgumentSemantic.Assign)]
		bool EnableManualImpressions { get; set; }

		[NullAllowed]
		[Export ("customRenderedBannerViewDelegate", ArgumentSemantic.Weak)]
		ICustomRenderedBannerViewDelegate CustomRenderedBannerViewDelegate { get; set; }

		// @property(nonatomic, strong, readonly) GADVideoController *videoController;
		[Export ("videoController", ArgumentSemantic.Strong)]
		Google.MobileAds.VideoController VideoController { get; }

		[Export ("recordImpression")]
		void RecordImpression ();

		[Export ("resize:")]
		void Resize (AdSize size);

		// - (void)setAdOptions:(NSArray *)adOptions;
		[Export ("setAdOptions:")]
		void SetAdOptions (Google.MobileAds.AdLoaderOptions [] adOptions);

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

	[BaseType (typeof (NSObject), Name = "DFPCustomRenderedAd")]
	interface CustomRenderedAd {

		[Export ("adHTML", ArgumentSemantic.Copy)]
		string AdHTML { get; }

		[Export ("adBaseURL", ArgumentSemantic.Copy)]
		NSUrl AdBaseURL { get; }

		[Export ("recordClick")]
		void RecordClick ();

		[Export ("recordImpression")]
		void RecordImpression ();

		[Export ("finishedRenderingAdView:")]
		void FinishedRenderingAdView (UIView view);
	}

	interface ICustomRenderedBannerViewDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomRenderedBannerViewDelegate")]
	interface CustomRenderedBannerViewDelegate {

		[Abstract]
		[EventArgs ("CustomRenderedBannerViewReceived")]
		[EventName ("CustomRenderedBannerAdReceived")]
		[Export ("bannerView:didReceiveCustomRenderedAd:")]
		void DidReceiveCustomRenderedBannerAd (BannerView bannerView, CustomRenderedAd customRenderedAd);
	}

	interface ICustomRenderedInterstitialDelegate {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomRenderedInterstitialDelegate")]
	interface CustomRenderedInterstitialDelegate {

		[Abstract]
		[EventArgs ("CustomRenderedInterstitialReceived")]
		[EventName ("CustomRenderedInterstitialReceived")]
		[Export ("interstitial:didReceiveCustomRenderedAd:")]
		void DidReceiveCustomRenderedInterstitial (Interstitial interstitial, CustomRenderedAd customRenderedAd);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (Google.MobileAds.Interstitial),
		Name = "DFPInterstitial",
		Delegates = new string [] { "CustomRenderedInterstitialDelegate" },
		Events = new Type [] { typeof (CustomRenderedInterstitialDelegate) })]
	interface Interstitial {
		[Export ("initWithAdUnitID:")]
		IntPtr Constructor (string adUnitID);

		[New]
		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitID { get; }

		// @property(nonatomic, strong) GADCorrelator *correlator;
		[NullAllowed]
		[Export ("correlator", ArgumentSemantic.Strong)]
		Google.MobileAds.Correlator Correlator { get; set; }

		[NullAllowed]
		[Export ("appEventDelegate", ArgumentSemantic.Weak)]
		IAppEventDelegate AppEventDelegate { get; set; }

		[NullAllowed]
		[Export ("customRenderedInterstitialDelegate", ArgumentSemantic.Weak)]
		ICustomRenderedInterstitialDelegate CustomRenderedInterstitialDelegate { get; set; }
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

		[Obsolete ("Set Google.MobileAds.Correlator objects on your ads instead. This method longer affects ad correlation.")]
		[Static]
		[Export ("updateCorrelator")]
		void UpdateCorrelator ();
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
		[NullAllowed]
		[Export ("adChoicesView")]
		UIView GetAdChoicesView ();

		// @optional @property (readonly, nonatomic) UIView * _Nullable mediaView;
		[NullAllowed]
		[Export ("mediaView")]
		UIView GetMediaView ();

		// @optional @property (readonly, assign, nonatomic) BOOL hasVideoContent;
		[Export ("hasVideoContent")]
		bool HasVideoContent ();

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
	// typedef void (^PACLoadCompletion)(NSError * _Nullable);
	delegate void LoadCompletionHandler ([NullAllowed] NSError error);

	// typedef void (^PACDismissCompletion)(NSError * _Nullable, BOOL);
	delegate void DismissCompletionHandler ([NullAllowed] NSError error, bool userPrefersAdFree);

	// @interface PACConsentForm : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "PACConsentForm")]
	interface ConsentForm {
		// @property (nonatomic) BOOL shouldOfferPersonalizedAds;
		[Export ("shouldOfferPersonalizedAds")]
		bool ShouldOfferPersonalizedAds { get; set; }

		// @property (nonatomic) BOOL shouldOfferNonPersonalizedAds;
		[Export ("shouldOfferNonPersonalizedAds")]
		bool ShouldOfferNonPersonalizedAds { get; set; }

		// @property (nonatomic) BOOL shouldOfferAdFree;
		[Export ("shouldOfferAdFree")]
		bool ShouldOfferAdFree { get; set; }

		// -(instancetype _Nullable)initWithApplicationPrivacyPolicyURL:(NSURL * _Nonnull)privacyPolicyURL __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithApplicationPrivacyPolicyURL:")]
		IntPtr Constructor (NSUrl privacyPolicyUrl);

		// -(void)loadWithCompletionHandler:(PACLoadCompletion _Nonnull)loadCompletion;
		[Async]
		[Export ("loadWithCompletionHandler:")]
		void Load (LoadCompletionHandler loadCompletion);

		// -(void)presentFromViewController:(UIViewController * _Nonnull)viewController dismissCompletion:(PACDismissCompletion _Nullable)completionHandler;
		[Async (ResultTypeName = "DismissCompletionResult")]
		[Export ("presentFromViewController:dismissCompletion:")]
		void Present (UIViewController viewController, [NullAllowed] DismissCompletionHandler completionHandler);
	}

	// @interface PACAdProvider : NSObject
	[BaseType (typeof (NSObject), Name = "PACAdProvider")]
	interface AdProvider {
		// @property (readonly, nonatomic) NSNumber * _Nonnull identifier;
		[Export ("identifier")]
		NSNumber Identifier { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSURL * _Nonnull privacyPolicyURL;
		[Export ("privacyPolicyURL")]
		NSUrl PrivacyPolicyUrl { get; }
	}

	// typedef void (^PACConsentInformationUpdateHandler)(NSError * _Nullable);
	delegate void ConsentInformationUpdateHandler ([NullAllowed] NSError error);

	// @interface PACConsentInformation : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "PACConsentInformation")]
	interface ConsentInformation {
		// extern NSString *const _Nonnull PACVersionString;
		[Field ("PACVersionString", "__Internal")]
		NSString VersionString { get; }

		// extern NSErrorDomain  _Nonnull const PACErrorDomain;
		[Field ("PACErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// extern NSString *const _Nonnull PACUserDefaultsRootKey;
		[Field ("PACUserDefaultsRootKey", "__Internal")]
		NSString UserDefaultsRootKey { get; }

		// @property (readonly, nonatomic, class) PACConsentInformation * _Nonnull sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		ConsentInformation SharedInstance { get; }

		// @property (nonatomic) PACConsentStatus consentStatus;
		[Export ("consentStatus", ArgumentSemantic.Assign)]
		ConsentStatus ConsentStatus { get; set; }

		// @property (getter = isTaggedForUnderAgeOfConsent, nonatomic) BOOL tagForUnderAgeOfConsent;
		[Export ("tagForUnderAgeOfConsent")]
		bool TagForUnderAgeOfConsent { [Bind ("isTaggedForUnderAgeOfConsent")] get; set; }

		// @property (readonly, getter = isRequestLocationInEEAOrUnknown, nonatomic) BOOL requestLocationInEEAOrUnknown;
		[Export ("isRequestLocationInEEAOrUnknown")]
		bool IsRequestLocationInEeaOrUnknown { get; }

		// @property (readonly, nonatomic) NSArray<PACAdProvider *> * _Nullable adProviders;
		[NullAllowed]
		[Export ("adProviders")]
		AdProvider [] AdProviders { get; }

		// @property (nonatomic) NSArray<NSString *> * _Nullable debugIdentifiers;
		[NullAllowed]
		[Export ("debugIdentifiers", ArgumentSemantic.Assign)]
		string [] DebugIdentifiers { get; set; }

		// @property (nonatomic) PACDebugGeography debugGeography;
		[Export ("debugGeography", ArgumentSemantic.Assign)]
		DebugGeography DebugGeography { get; set; }

		// -(void)reset;
		[Export ("reset")]
		void Reset ();

		// -(void)requestConsentInfoUpdateForPublisherIdentifiers:(NSArray<NSString *> * _Nonnull)publisherIdentifiers completionHandler:(PACConsentInformationUpdateHandler _Nonnull)handler;
		[Async]
		[Export ("requestConsentInfoUpdateForPublisherIdentifiers:completionHandler:")]
		void RequestConsentInfoUpdate (string [] publisherIdentifiers, ConsentInformationUpdateHandler handler);
	}
}