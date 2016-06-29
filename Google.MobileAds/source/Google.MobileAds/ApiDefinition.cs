using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using StoreKit;
using CoreGraphics;

namespace Google.MobileAds
{
	#region CustomLib
	// This is a custom class created by me and is not part of Google Admob lib
	// But it is necesary for this binding to work
	[Static]
	interface AdSizeCons
	{

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

	// @interface GADMobileAds : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GADMobileAds")]
	interface MobileAds
	{
		// + (GADMobileAds *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		MobileAds SharedInstance { get; }

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
	}

	interface IAdNetworkExtras
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAdNetworkExtras")]
	interface AdNetworkExtras
	{

	}

	// @interface GADAdReward : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GADAdReward")]
	interface AdReward
	{
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
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (BannerViewDelegate) })]
	interface BannerView
	{

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (AdSize size, CGPoint origin);

		[Export ("initWithAdSize:")]
		IntPtr Constructor (AdSize size);

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

		[NullAllowed]
		[Export ("inAppPurchaseDelegate", ArgumentSemantic.Weak)]
		IInAppPurchaseDelegate InAppPurchaseDelegate { get; set; }

		[Export ("loadRequest:")]
		void LoadRequest ([NullAllowed] Request request);

		[Export ("autoloadEnabled", ArgumentSemantic.Assign)]
		bool AutoloadEnabled { [Bind ("isAutoloadEnabled")] get; set; }

		[Export ("adNetworkClassName")]
		string AdNetworkClassName { get; }

		[Obsolete]
		[Export ("hasAutoRefreshed", ArgumentSemantic.Assign)]
		bool HasAutoRefreshed { get; }

		[Obsolete ("Use adNetworkClassName.")]
		[Export ("mediatedAdView", ArgumentSemantic.Weak)]
		UIView MediatedAdView { get; }
	}

	interface IBannerViewDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADBannerViewDelegate")]
	interface BannerViewDelegate : AdDelegate
	{

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
	interface Correlator
	{
		// -(void)reset;
		[Export ("reset")]
		void Reset ();
	}

	// @interface GADCorrelatorAdLoaderOptions : GADAdLoaderOptions
	[BaseType (typeof (AdLoaderOptions), Name = "GADCorrelatorAdLoaderOptions")]
	interface CorrelatorAdLoaderOptions
	{
		// @property (nonatomic, strong) GADCorrelator * correlator;
		[Export ("correlator", ArgumentSemantic.Strong)]
		Correlator Correlator { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GADExtras")]
	interface Extras : AdNetworkExtras
	{

		[Export ("additionalParameters", ArgumentSemantic.Copy)]
		NSDictionary AdditionalParameters { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject),
		Name = "GADInterstitial",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (InterstitialDelegate) })]
	interface Interstitial
	{

		[Export ("initWithAdUnitID:")]
		IntPtr Constructor (string adUnitID);

		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitID { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IInterstitialDelegate Delegate { get; set; }

		[NullAllowed]
		[Export ("inAppPurchaseDelegate", ArgumentSemantic.Weak)]
		IInAppPurchaseDelegate InAppPurchaseDelegate { get; set; }

		[Export ("loadRequest:")]
		void LoadRequest (Request request);

		[Export ("isReady", ArgumentSemantic.Assign)]
		bool IsReady { get; }

		[Export ("hasBeenUsed", ArgumentSemantic.Assign)]
		bool HasBeenUsed { get; }

		[Export ("adNetworkClassName", ArgumentSemantic.Copy)]
		string AdNetworkClassName { get; }

		[Export ("presentFromRootViewController:")]
		void PresentFromRootViewController ([NullAllowed] UIViewController rootViewController);
	}

	interface IInterstitialDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADInterstitialDelegate")]
	interface InterstitialDelegate : AdDelegate
	{

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
	interface Request : INSCopying
	{
		[Field ("kGADSimulatorID", "__Internal")]
		NSString SimulatorId { get; }

		[Static]
		[Export ("request")]
		Request GetDefaultRequest ();

		[Export ("registerAdNetworkExtras:")]
		void RegisterAdNetworkExtras (IAdNetworkExtras extras);

		[Export ("adNetworkExtrasFor:")]
		IAdNetworkExtras AdNetworkExtrasFor (Class clazz);

		[Export ("removeAdNetworkExtrasFor:")]
		void RemoveAdNetworkExtrasFor (Class clazz);

		[Static]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		[Export ("testDevices", ArgumentSemantic.Copy)]
		string [] TestDevices { get; set; }

		[Export ("gender", ArgumentSemantic.Assign)]
		Gender Gender { get; set; }

		[Export ("birthday", ArgumentSemantic.Copy)]
		NSDate Birthday { get; set; }

		[Export ("setLocationWithLatitude:longitude:accuracy:")]
		void SetLocation (nfloat latitude, nfloat longitude, nfloat accuracyInMeters);

		[Obsolete ("Use SetLocation (nfloat, nfloat, nfloat) method instead.")]
		[Export ("setLocationWithDescription:")]
		void SetLocation (string locationDescription);

		[Export ("tagForChildDirectedTreatment:")]
		void TagForChildDirectedTreatment (bool childDirectedTreatment);

		[NullAllowed]
		[Export ("keywords", ArgumentSemantic.Copy)]
		string [] Keywords { get; set; }

		[Export ("contentURL", ArgumentSemantic.Copy)]
		string ContentUrl { get; set; }

		[Export ("requestAgent", ArgumentSemantic.Copy)]
		string RequestAgent { get; set; }

		#region "Deprecated GAdRequest Methods"

		[Export ("setBirthdayWithMonth:day:year:")]
		void SetBirthday (nint m, nint d, nint y);

		#endregion

	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSError), Name = "GADRequestError")]
	interface RequestError
	{

		[Export ("initWithDomain:code:userInfo:")]
		IntPtr Constructor (NSString appDomain, nint code, NSDictionary userInfo);
	}

	// @interface GADRewardBasedVideoAd : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject),
		Name = "GADRewardBasedVideoAd",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (RewardBasedVideoAdDelegate) })]
	interface RewardBasedVideoAd
	{
		// @property (nonatomic, weak) id<GADRewardBasedVideoAdDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IRewardBasedVideoAdDelegate Delegate { get; set; }

		// @property (readonly, getter = isReady, assign, nonatomic) BOOL ready;
		[Export ("ready")]
		bool Ready { [Bind ("isReady")] get; }

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

	interface IRewardBasedVideoAdDelegate
	{
	}

	// @protocol GADRewardBasedVideoAdDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADRewardBasedVideoAdDelegate")]
	interface RewardBasedVideoAdDelegate
	{
		// @optional -(void)rewardBasedVideoAdDidReceiveAd:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[EventName ("ReceivedAd")]
		[Export ("rewardBasedVideoAdDidReceiveAd:")]
		void DidReceiveAd (RewardBasedVideoAd rewardBasedVideoAd);

		// @optional -(void)rewardBasedVideoAdDidOpen:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[EventName ("Opened")]
		[Export ("rewardBasedVideoAdDidOpen:")]
		void DidOpen (RewardBasedVideoAd rewardBasedVideoAd);

		[EventArgs ("RewardBasedVideoAd")]
		[EventName ("StartedPlaying")]
		// @optional -(void)rewardBasedVideoAdDidStartPlaying:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[Export ("rewardBasedVideoAdDidStartPlaying:")]
		void DidStartPlaying (RewardBasedVideoAd rewardBasedVideoAd);

		// @optional -(void)rewardBasedVideoAdDidClose:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[EventName ("Closed")]
		[Export ("rewardBasedVideoAdDidClose:")]
		void DidClose (RewardBasedVideoAd rewardBasedVideoAd);

		// @optional -(void)rewardBasedVideoAdWillLeaveApplication:(GADRewardBasedVideoAd *)rewardBasedVideoAd;
		[EventArgs ("RewardBasedVideoAd")]
		[Export ("rewardBasedVideoAdWillLeaveApplication:")]
		void WillLeaveApplication (RewardBasedVideoAd rewardBasedVideoAd);

		// @optional -(void)rewardBasedVideoAd:(GADRewardBasedVideoAd *)rewardBasedVideoAd didRewardUserWithReward:(GADAdReward *)reward;
		[EventArgs ("RewardBasedVideoAdReward")]
		[EventName ("RewardedUser")]
		[Export ("rewardBasedVideoAd:didRewardUserWithReward:")]
		void DidRewardUser (RewardBasedVideoAd rewardBasedVideoAd, AdReward reward);

		// @optional -(void)rewardBasedVideoAd:(GADRewardBasedVideoAd *)rewardBasedVideoAd didFailToLoadwithError:(NSError *)error;
		[EventArgs ("RewardBasedVideoAdError")]
		[EventName ("FailedToLoad")]
		[Export ("rewardBasedVideoAd:didFailToLoadWithError:")]
		void DidFailToLoad (RewardBasedVideoAd rewardBasedVideoAd, NSError error);
	}

	interface IAdSizeDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAdSizeDelegate")]
	interface AdSizeDelegate
	{

		[Abstract]
		[EventArgs ("AdSizeDelegateSize")]
		[Export ("adView:willChangeAdSizeTo:")]
		void WillChangeAdSizeTo (BannerView view, AdSize size);
	}

	interface IAppEventDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAppEventDelegate")]
	interface AppEventDelegate
	{

		[Export ("adView:didReceiveAppEvent:withInfo:")]
		void AdViewDidReceiveAppEvent (BannerView banner, string name, string info);

		[Export ("interstitial:didReceiveAppEvent:withInfo:")]
		void InterstitialDidReceiveAppEvent (Interstitial interstitial, string name, string info);
	}

	interface ISwipeableBannerViewDelegate
	{

	}

	[BaseType (typeof (NSObject), Name = "GADSwipeableBannerViewDelegate")]
	[Model]
	[Protocol]
	interface SwipeableBannerViewDelegate
	{
		[Export ("adViewDidActivateAd:"), EventArgs ("SwipeableBannerViewDelegateInfo")]
		void DidActivateAd (BannerView banner);

		[Export ("adViewDidDeactivateAd:"), EventArgs ("SwipeableBannerViewDelegateInfo")]
		void DidDeactivateAd (BannerView banner);
	}

	#region Search

	[BaseType (typeof (Request), Name = "GADSearchRequest")]
	interface SearchRequest
	{

		[Export ("query", ArgumentSemantic.Copy)]
		string Query { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		UIColor BackgroundColor { get; }

		[Export ("gradientFrom", ArgumentSemantic.Copy)]
		UIColor GradientFrom { get; }

		[Export ("gradientTo", ArgumentSemantic.Copy)]
		UIColor GradientTo { get; }

		[Export ("headerColor", ArgumentSemantic.Copy)]
		UIColor HeaderColor { get; set; }

		[Export ("descriptionTextColor", ArgumentSemantic.Copy)]
		UIColor DescriptionTextColor { get; set; }

		[Export ("anchorTextColor", ArgumentSemantic.Copy)]
		UIColor AnchorTextColor { get; set; }

		[Export ("fontFamily", ArgumentSemantic.Copy)]
		string FontFamily { get; set; }

		[Export ("headerTextSize", ArgumentSemantic.Assign)]
		nuint HeaderTextSize { get; set; }

		[Export ("borderColor", ArgumentSemantic.Copy)]
		UIColor BorderColor { get; set; }

		[Export ("borderType", ArgumentSemantic.Assign)]
		SearchBorderType BorderType { get; set; }

		[Export ("borderThickness", ArgumentSemantic.Assign)]
		nuint BorderThickness { get; set; }

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
	interface SearchBannerView
	{

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (AdSize size, CGPoint origin);

		[Export ("initWithAdSize:")]
		IntPtr Constructor (AdSize size);

		// @property(nonatomic, weak) IBOutlet id<GADAdSizeDelegate> adSizeDelegate;
		[NullAllowed]
		[Export ("adSizeDelegate", ArgumentSemantic.Weak)]
		IAdSizeDelegate AdSizeDelegate { get; set; }
	}

	#endregion

	#region Loading

	interface IAdDelegate
	{
	}

	// @protocol GADAdDelegate<NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAdDelegate")]
	interface AdDelegate
	{
		// @optional - (BOOL)ad:(id)ad shouldChangeAudioSessionToCategory:(NSString *)audioSessionCategory;
		[Export ("ad:shouldChangeAudioSessionToCategory:")]
		bool ShouldChangeAudioSessionToCategory (NSObject ad, string audioSessionCategory);
	}

	// @interface GADAdLoader : NSObject
	[BaseType (typeof (NSObject),
		Name = "GADAdLoader",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (AdLoaderDelegate) })]
	interface AdLoader
	{
		// @property (nonatomic, weak) id<GADAdLoaderDelegate> __nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAdLoaderDelegate Delegate { get; set; }

		// -(instancetype)initWithAdUnitID:(NSString *)adUnitID rootViewController:(UIViewController *)rootViewController adTypes:(NSArray *)adTypes options:(NSArray *)options;
		[Export ("initWithAdUnitID:rootViewController:adTypes:options:")]
		IntPtr Constructor (string adUnitID, UIViewController rootViewController, [NullAllowed] NSObject [] adTypes, [NullAllowed] AdLoaderOptions [] options);

		// -(void)loadRequest:(GADRequest *)request;
		[Export ("loadRequest:")]
		void LoadRequest (Request request);
	}

	[Static]
	interface AdLoaderType
	{
		// extern NSString *const kGADAdLoaderAdTypeNativeAppInstall;
		[Field ("kGADAdLoaderAdTypeNativeAppInstall", "__Internal")]
		NSString NativeAppInstall { get; }

		// extern NSString *const kGADAdLoaderAdTypeNativeContent;
		[Field ("kGADAdLoaderAdTypeNativeContent", "__Internal")]
		NSString NativeContent { get; }

		// extern NSString *const kGADAdLoaderAdTypeNativeCustomTemplate;
		[Field ("kGADAdLoaderAdTypeNativeCustomTemplate", "__Internal")]
		NSString NativeCustomTemplate { get; }
	}

	// @interface GADAdLoaderOptions : NSObject
	[BaseType (typeof (NSObject), Name = "GADAdLoaderOptions")]
	interface AdLoaderOptions
	{
	}

	interface IAdLoaderDelegate
	{
	}

	// @protocol GADAdLoaderDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADAdLoaderDelegate")]
	interface AdLoaderDelegate
	{
		// @required -(void)adLoader:(GADAdLoader *)adLoader didFailToReceiveAdWithError:(GADRequestError *)error;
		[Abstract]
		[EventArgs ("AdLoaderReceiveAdFailed")]
		[EventName ("ReceiveAdFailed")]
		[Export ("adLoader:didFailToReceiveAdWithError:")]
		void DidFailToReceiveAd (AdLoader adLoader, RequestError error);
	}

	#region Loading.Formats

	// @interface GADNativeAd : NSObject
	[BaseType (typeof (NSObject),
		   Name = "GADNativeAd",
		   Delegates = new string [] { "Delegate" },
		   Events = new Type [] { typeof (NativeAdDelegate) })]
	interface NativeAd
	{
		// @property (nonatomic, weak) id<GADNativeAdDelegate> __nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		// @property (nonatomic, weak) UIViewController * __nullable rootViewController;
		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		// @property (readonly, copy, nonatomic) NSDictionary * extraAssets;
		[Export ("extraAssets", ArgumentSemantic.Copy)]
		NSDictionary ExtraAssets { get; }

		// @property (readonly, copy, nonatomic) NSString * adNetworkClassName;
		[Export ("adNetworkClassName")]
		string AdNetworkClassName { get; }
	}

	interface INativeAdDelegate
	{
	}

	// @protocol GADNativeAdDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADNativeAdDelegate")]
	interface NativeAdDelegate
	{
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
	interface NativeAdImage
	{
		// -(instancetype)initWithImage:(UIImage *)image;
		[Export ("initWithImage:")]
		IntPtr Constructor (UIImage image);

		// -(instancetype)initWithURL:(NSURL *)URL scale:(CGFloat)scale;
		[Export ("initWithURL:scale:")]
		IntPtr Constructor (NSUrl url, nfloat scale);

		// @property (readonly, nonatomic, strong) UIImage * image;
		[Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; }

		// @property (readonly, nonatomic, strong) NSURL * imageURL;
		[Export ("imageURL", ArgumentSemantic.Strong)]
		NSUrl ImageUrl { get; }

		// @property (readonly, assign, nonatomic) CGFloat scale;
		[Export ("scale")]
		nfloat Scale { get; }
	}

	// @interface GADNativeAppInstallAd : GADNativeAd
	[BaseType (typeof (NativeAd), Name = "GADNativeAppInstallAd")]
	interface NativeAppInstallAd
	{
		// @property (readonly, copy, nonatomic) NSString * headline;
		[Export ("headline")]
		string Headline { get; }

		// @property (readonly, copy, nonatomic) NSString * callToAction;
		[Export ("callToAction")]
		string CallToAction { get; }

		// @property (readonly, nonatomic, strong) GADNativeAdImage * icon;
		[Export ("icon", ArgumentSemantic.Strong)]
		NativeAdImage Icon { get; }

		// @property (readonly, copy, nonatomic) NSString * body;
		[Export ("body")]
		string Body { get; }

		// @property (readonly, copy, nonatomic) NSString * store;
		[Export ("store")]
		string Store { get; }

		// @property (readonly, copy, nonatomic) NSString * price;
		[Export ("price")]
		string Price { get; }

		// @property (readonly, nonatomic, strong) NSArray * images;
		[Export ("images", ArgumentSemantic.Strong)]
		NativeAdImage [] Images { get; }

		// @property (readonly, copy, nonatomic) NSDecimalNumber * starRating;
		[Export ("starRating", ArgumentSemantic.Copy)]
		NSDecimalNumber StarRating { get; }
	}

	interface INativeAppInstallAdLoaderDelegate
	{
	}

	// @protocol GADNativeAppInstallAdLoaderDelegate <GADAdLoaderDelegate>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADNativeAppInstallAdLoaderDelegate")]
	interface NativeAppInstallAdLoaderDelegate : AdLoaderDelegate
	{
		// @required -(void)adLoader:(GADAdLoader *)adLoader didReceiveNativeAppInstallAd:(GADNativeAppInstallAd *)nativeAppInstallAd;
		[Abstract]
		[Export ("adLoader:didReceiveNativeAppInstallAd:")]
		void DidReceiveNativeAppInstallAd (AdLoader adLoader, NativeAppInstallAd nativeAppInstallAd);
	}

	// @interface GADNativeAppInstallAdView : UIView
	[BaseType (typeof (UIView), Name = "GADNativeAppInstallAdView")]
	interface NativeAppInstallAdView
	{
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, strong) GADNativeAppInstallAd * nativeAppInstallAd;
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
	}

	// @interface GADNativeContentAd : GADNativeAd
	[BaseType (typeof (NativeAd), Name = "GADNativeContentAd")]
	interface NativeContentAd
	{
		// @property (readonly, copy, nonatomic) NSString * headline;
		[Export ("headline")]
		string Headline { get; }

		// @property (readonly, copy, nonatomic) NSString * body;
		[Export ("body")]
		string Body { get; }

		// @property (readonly, copy, nonatomic) NSArray * images;
		[Export ("images", ArgumentSemantic.Copy)]
		NativeAdImage [] Images { get; }

		// @property (readonly, nonatomic, strong) NativeAdImage * logo;
		[Export ("logo", ArgumentSemantic.Strong)]
		NativeAdImage Logo { get; }

		// @property (readonly, copy, nonatomic) NSString * callToAction;
		[Export ("callToAction")]
		string CallToAction { get; }

		// @property (readonly, copy, nonatomic) NSString * advertiser;
		[Export ("advertiser")]
		string Advertiser { get; }
	}

	interface INativeContentAdLoaderDelegate
	{
	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADNativeContentAdLoaderDelegate")]
	interface NativeContentAdLoaderDelegate : AdLoaderDelegate
	{
		// @required -(void)adLoader:(GADAdLoader *)adLoader didReceiveNativeContentAd:(GADNativeContentAd *)nativeContentAd;
		[Abstract]
		[Export ("adLoader:didReceiveNativeContentAd:")]
		void DidReceiveNativeContentAd (AdLoader adLoader, NativeContentAd nativeContentAd);
	}

	// @interface GADNativeContentAdView : UIView
	[BaseType (typeof (UIView), Name = "GADNativeContentAdView")]
	interface NativeContentAdView
	{
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, strong) GADNativeContentAd * nativeContentAd;
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
	}

	// @interface GADNativeCustomTemplateAd : GADNativeAd
	[BaseType (typeof (NativeAd), Name = "GADNativeCustomTemplateAd")]
	interface NativeCustomTemplateAd
	{
		// @property (readonly, nonatomic) NSString * templateID;
		[Export ("templateID")]
		string TemplateID { get; }

		// @property (readonly, nonatomic) NSArray * availableAssetKeys;
		[Export ("availableAssetKeys")]
		string [] AvailableAssetKeys { get; }

		// -(GADNativeAdImage *)imageForKey:(NSString *)key;
		[Export ("imageForKey:")]
		NativeAdImage ImageForKey (string key);

		// -(NSString *)stringForKey:(NSString *)key;
		[Export ("stringForKey:")]
		string StringForKey (string key);

		// -(void)performClickOnAssetWithKey:(NSString *)assetKey customClickHandler:(dispatch_block_t)customClickHandler;
		[Export ("performClickOnAssetWithKey:customClickHandler:")]
		void PerformClickOnAssetWithKey (string assetKey, [NullAllowed] Action customClickHandler);

		// -(void)recordImpression;
		[Export ("recordImpression")]
		void RecordImpression ();
	}

	// @interface GADNativeExpressAdView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView),
		   Name = "GADNativeExpressAdView",
		   Delegates = new string [] { "Delegate" },
		   Events = new Type [] { typeof (NativeExpressAdViewDelegate) })]
	interface NativeExpressAdView
	{
		// -(instancetype)initWithAdSize:(id)adSize origin:(CGPoint)origin;
		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (NSObject adSize, CGPoint origin);

		// -(instancetype)initWithAdSize:(id)adSize;
		[Export ("initWithAdSize:")]
		IntPtr Constructor (NSObject adSize);

		// @property (copy, nonatomic) NSString * adUnitID;
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

		// -(void)loadRequest:(id)request;
		[Export ("loadRequest:")]
		void LoadRequest (Request request);

		// @property (getter = isAutoloadEnabled, assign, nonatomic) BOOL autoloadEnabled;
		[Export ("autoloadEnabled")]
		bool AutoloadEnabled { [Bind ("isAutoloadEnabled")] get; set; }

		// @property (readonly, nonatomic, weak) NSString * _Nullable adNetworkClassName;
		[Export ("adNetworkClassName", ArgumentSemantic.Weak)]
		string AdNetworkClassName { get; }
	}

	interface INativeExpressAdViewDelegate
	{
	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADNativeExpressAdViewDelegate")]
	interface NativeExpressAdViewDelegate
	{
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

	interface INativeCustomTemplateAdLoaderDelegate
	{
	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADNativeCustomTemplateAdLoaderDelegate")]
	interface NativeCustomTemplateAdLoaderDelegate : AdLoaderDelegate
	{
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
	interface NativeAdImageAdLoaderOptions
	{
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

	interface ICustomEventBanner
	{

	}

	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomEventBanner")]
	interface CustomEventBanner
	{
		[Abstract]
		[Export ("requestBannerAd:parameter:label:request:")]
		void RequestBannerAd (AdSize adSize, string serverParameter, string serverLabel, CustomEventRequest request);

		[Abstract]
		[NullAllowed]
		[Export ("delegate")]
		ICustomEventBannerDelegate GetDelegate ();

		[Abstract]
		[Export ("setDelegate:")]
		void SetDelegate ([NullAllowed] ICustomEventBannerDelegate aDelegate);
	}

	interface ICustomEventBannerDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomEventBannerDelegate")]
	interface CustomEventBannerDelegate
	{

		[Abstract]
		[Export ("customEventBanner:didReceiveAd:")]
		void DidReceiveAd (ICustomEventBanner customEvent, UIView view);

		[Abstract]
		[Export ("customEventBanner:didFailAd:")]
		void DidFailAd (ICustomEventBanner customEvent, NSError error);

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
	interface CustomEventExtras : AdNetworkExtras
	{

		[Export ("setExtras:forLabel:")]
		[PostGet ("AllExtras")]
		void SetExtras (NSDictionary extras, string label);

		[Export ("extrasForLabel:")]
		NSDictionary ExtrasForLabel (string label);

		[Export ("removeAllExtras")]
		[PostGet ("AllExtras")]
		void RemoveAllExtras ();

		[Export ("allExtras")]
		NSDictionary AllExtras { get; }
	}

	interface ICustomEventInterstitial
	{

	}

	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomEventInterstitial")]
	interface CustomEventInterstitial
	{

		[Abstract]
		[NullAllowed]
		[Export ("delegate")]
		ICustomEventInterstitialDelegate GetDelegate ();

		[Abstract]
		[Export ("setDelegate:")]
		void SetDelegate ([NullAllowed] ICustomEventInterstitialDelegate aDelegate);

		[Abstract]
		[Export ("requestInterstitialAdWithParameter:label:request:")]
		void RequestInterstitialAd (string serverParameter, string serverLabel, CustomEventRequest request);

		[Abstract]
		[Export ("presentFromRootViewController:")]
		void PresentFromRootViewController ([NullAllowed] UIViewController rootViewController);
	}

	interface ICustomEventInterstitialDelegate
	{

	}

	[BaseType (typeof (NSObject), Name = "GADCustomEventInterstitialDelegate")]
	[Model]
	[Protocol]
	interface CustomEventInterstitialDelegate
	{
		[Export ("customEventInterstitialDidReceiveAd:")]
		void DidReceiveAd (ICustomEventInterstitial customEvent);

		[Export ("customEventInterstitial:didFailAd:")]
		void DidFailAd (ICustomEventInterstitial customEvent, NSError error);

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

	interface ICustomEventNativeAd
	{
	}

	// @protocol GADCustomEventNativeAd <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomEventNativeAd")]
	interface CustomEventNativeAd
	{
		// @required -(void)requestNativeAdWithParameter:(NSString *)serverParameter request:(GADCustomEventRequest *)request adTypes:(NSArray *)adTypes options:(NSArray *)options rootViewController:(UIViewController *)rootViewController;
		[Abstract]
		[Export ("requestNativeAdWithParameter:request:adTypes:options:rootViewController:")]
		void Request (string serverParameter, CustomEventRequest request, NSString [] adTypes, NSNumber [] options, UIViewController rootViewController);

		// - (BOOL)handlesUserClicks;
		[Abstract]
		[Export ("handlesUserClicks")]
		bool HandlesUserClicks ();

		// @required @property (nonatomic, weak) id<GADCustomEventNativeAdDelegate> _Nullable delegate;
		[Abstract]
		[Export ("delegate")]
		ICustomEventNativeAdDelegate GetDelegate ();

		[Abstract]
		[Export ("setDelegate:")]
		void SetDelegate ([NullAllowed] ICustomEventNativeAdDelegate aDelegate);
	}

	interface ICustomEventNativeAdDelegate
	{
	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADCustomEventNativeAdDelegate")]
	interface CustomEventNativeAdDelegate
	{
		// @required -(void)customEventNativeAd:(id<GADCustomEventNativeAd>)customEventNativeAd didReceiveMediatedNativeAd:(id<GADMediatedNativeAd>)mediatedNativeAd;
		[Abstract]
		[Export ("customEventNativeAd:didReceiveMediatedNativeAd:")]
		void DidReceiveMediatedNativeAd (ICustomEventNativeAd customEventNativeAd, IMediatedNativeAd mediatedNativeAd);

		// @required -(void)customEventNativeAd:(id<GADCustomEventNativeAd>)customEventNativeAd didFailToLoadWithError:(NSError *)error;
		[Abstract]
		[Export ("customEventNativeAd:didFailToLoadWithError:")]
		void DidFailToLoad (ICustomEventNativeAd customEventNativeAd, NSError error);
	}

	[BaseType (typeof (NSObject), Name = "GADCustomEventRequest")]
	interface CustomEventRequest
	{

		[Export ("userGender", ArgumentSemantic.Assign)]
		Gender UserGender { get; }

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

		[Export ("userLocationDescription", ArgumentSemantic.Copy)]
		string UserLocationDescription { get; }

		[NullAllowed]
		[Export ("userKeywords", ArgumentSemantic.Copy)]
		NSObject [] UserKeywords { get; }

		[Export ("additionalParameters", ArgumentSemantic.Copy)]
		NSDictionary AdditionalParameters { get; }

		[Export ("isTesting", ArgumentSemantic.Assign)]
		bool IsTesting { get; }
	}

	// @interface GADDynamicHeightSearchRequest : GADRequest
	[BaseType (typeof (Request), Name = "GADDynamicHeightSearchRequest")]
	interface DynamicHeightSearchRequest
	{
		// @property (copy, nonatomic) NSString * query;
		[Export ("query")]
		string Query { get; set; }

		// @property (assign, nonatomic) NSInteger adPage;
		[Export ("adPage")]
		nint AdPage { get; set; }

		// @property (assign, nonatomic) BOOL adTestEnabled;
		[Export ("adTestEnabled")]
		bool AdTestEnabled { get; set; }

		// @property (copy, nonatomic) NSString * channel;
		[Export ("channel")]
		string Channel { get; set; }

		// @property (copy, nonatomic) NSString * hostLanguage;
		[Export ("hostLanguage")]
		string HostLanguage { get; set; }

		// @property (copy, nonatomic) NSString * locationExtensionTextColor;
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
		[Export ("CSSWidth")]
		string CssWidth { get; set; }

		// @property (assign, nonatomic) NSInteger numberOfAds;
		[Export ("numberOfAds")]
		nint NumberOfAds { get; set; }

		// @property (copy, nonatomic) NSString * fontFamily;
		[Export ("fontFamily")]
		string FontFamily { get; set; }

		// @property (copy, nonatomic) NSString * attributionFontFamily;
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
		[Export ("adBorderColor")]
		string AdBorderColor { get; set; }

		// @property (copy, nonatomic) NSString * adSeparatorColor;
		[Export ("adSeparatorColor")]
		string AdSeparatorColor { get; set; }

		// @property (copy, nonatomic) NSString * annotationTextColor;
		[Export ("annotationTextColor")]
		string AnnotationTextColor { get; set; }

		// @property (copy, nonatomic) NSString * attributionTextColor;
		[Export ("attributionTextColor")]
		string AttributionTextColor { get; set; }

		// @property (copy, nonatomic) NSString * backgroundColor;
		[Export ("backgroundColor")]
		string BackgroundColor { get; set; }

		// @property (copy, nonatomic) NSString * borderColor;
		[Export ("borderColor")]
		string BorderColor { get; set; }

		// @property (copy, nonatomic) NSString * domainLinkColor;
		[Export ("domainLinkColor")]
		string DomainLinkColor { get; set; }

		// @property (copy, nonatomic) NSString * textColor;
		[Export ("textColor")]
		string TextColor { get; set; }

		// @property (copy, nonatomic) NSString * titleLinkColor;
		[Export ("titleLinkColor")]
		string TitleLinkColor { get; set; }

		// @property (copy, nonatomic) NSString * adBorderCSSSelections;
		[Export ("adBorderCSSSelections")]
		string AdBorderCssSelections { get; set; }

		// @property (assign, nonatomic) CGFloat adjustableLineHeight;
		[Export ("adjustableLineHeight")]
		nfloat AdjustableLineHeight { get; set; }

		// @property (assign, nonatomic) CGFloat attributionBottomSpacing;
		[Export ("attributionBottomSpacing")]
		nfloat AttributionBottomSpacing { get; set; }

		// @property (copy, nonatomic) NSString * borderCSSSelections;
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

	[BaseType (typeof (NSObject), Name = "GADDefaultInAppPurchase")]
	interface DefaultInAppPurchase
	{
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

	[BaseType (typeof (NSObject), Name = "GADInAppPurchase")]
	interface InAppPurchase
	{
		[Export ("productID", ArgumentSemantic.Copy)]
		string ProductId { get; }

		[Export ("quantity", ArgumentSemantic.Assign)]
		nint Quantity { get; }

		[Export ("reportPurchaseStatus:")]
		void ReportPurchaseStatus (InAppPurchaseStatus purchaseStatus);
	}

	interface IDefaultInAppPurchaseDelegate
	{

	}

	[BaseType (typeof (NSObject), Name = "GADDefaultInAppPurchaseDelegate")]
	[Model]
	[Protocol]
	interface DefaultInAppPurchaseDelegate
	{
		[Abstract]
		[Export ("userDidPayForPurchase:")]
		void DidPayForPurchase (DefaultInAppPurchase defaultInAppPurchase);

		[Export ("shouldStartPurchaseForProductID:quantity:")]
		void ShouldStartPurchase (string productID, nint quantity);
	}

	interface IInAppPurchaseDelegate
	{

	}

	[BaseType (typeof (NSObject), Name = "GADInAppPurchaseDelegate")]
	[Model]
	[Protocol]
	interface InAppPurchaseDelegate
	{
		[Export ("didReceiveInAppPurchase:")]
		[EventArgs ("InAppPurchaseDelegateDidRecieve")]
		void DidReceiveInAppPurchase (InAppPurchase purchase);
	}

	interface IMediatedNativeAd
	{
	}

	// @protocol GADMediatedNativeAd <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADMediatedNativeAd")]
	interface MediatedNativeAd
	{
		// @required -(id<GADMediatedNativeAdDelegate>)mediatedNativeAdDelegate;
		[Abstract]
		[Export ("mediatedNativeAdDelegate")]
		IMediatedNativeAdDelegate GetMediatedNativeAdDelegate ();

		// @required -(NSDictionary *)extraAssets;
		[Abstract]
		[Export ("extraAssets")]
		NSDictionary ExtraAssets ();
	}

	interface IMediatedNativeAdDelegate
	{
	}

	// @protocol GADMediatedNativeAdDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADMediatedNativeAdDelegate")]
	interface MediatedNativeAdDelegate
	{
		// @optional -(void)mediatedNativeAd:(id<GADMediatedNativeAd>)mediatedNativeAd didRenderInView:(UIView *)view viewController:(UIViewController *)viewController;;
		[Export ("mediatedNativeAd:didRenderInView:viewController:")]
		void DidRenderInView (IMediatedNativeAd mediatedNativeAd, UIView view, UIViewController viewController);

		// @optional -(void)mediatedNativeAdDidRecordImpression:(id<GADMediatedNativeAd>)mediatedNativeAd;
		[Export ("mediatedNativeAdDidRecordImpression:")]
		void DidRecordImpression (IMediatedNativeAd mediatedNativeAd);

		// @optional -(void)mediatedNativeAd:(id<GADMediatedNativeAd>)mediatedNativeAd didRecordClickOnAssetWithName:(NSString *)assetName view:(UIView *)view viewController:(UIViewController *)viewController;
		[Export ("mediatedNativeAd:didRecordClickOnAssetWithName:view:viewController:")]
		void DidRecordClick (IMediatedNativeAd mediatedNativeAd, string assetName, UIView view, UIViewController viewController);
	}

	// @interface GADMediatedNativeAdNotificationSource : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GADMediatedNativeAdNotificationSource")]
	interface MediatedNativeAdNotificationSource
	{
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
	}

	interface IMediatedNativeAppInstallAd
	{
	}

	// @protocol GADMediatedNativeAppInstallAd <GADMediatedNativeAd>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADMediatedNativeAppInstallAd")]
	interface MediatedNativeAppInstallAd : MediatedNativeAd
	{
		// @required -(NSString *)headline;
		[Abstract]
		[Export ("headline")]
		string GetHeadline ();

		// @required -(NSArray *)images;
		[Abstract]
		[Export ("images")]
		NativeAdImage [] GetImages ();

		// @required -(NSString *)body;
		[Abstract]
		[Export ("body")]
		string GetBody ();

		// @required -(GADNativeAdImage *)icon;
		[Abstract]
		[Export ("icon")]
		NativeAdImage GetIcon ();

		// @required -(NSString *)callToAction;
		[Abstract]
		[Export ("callToAction")]
		string GetCallToAction ();

		// @required -(NSDecimalNumber *)starRating;
		[Abstract]
		[Export ("starRating")]
		NSDecimalNumber StarRating ();

		// @required -(NSString *)store;
		[Abstract]
		[Export ("store")]
		string GetStore ();

		// @required -(NSString *)price;
		[Abstract]
		[Export ("price")]
		string GetPrice ();
	}

	interface IMediatedNativeContentAd
	{
	}

	// @protocol GADMediatedNativeContentAd <GADMediatedNativeAd>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GADMediatedNativeContentAd")]
	interface MediatedNativeContentAd : MediatedNativeAd
	{
		// @required -(NSString *)headline;
		[Abstract]
		[Export ("headline")]
		string GetHeadline ();

		// @required -(NSString *)body;
		[Abstract]
		[Export ("body")]
		string GetBody ();

		// @required -(NSArray *)images;
		[Abstract]
		[Export ("images")]
		NativeAdImage [] GetImages ();

		// @required -(GADNativeAdImage *)logo;
		[Abstract]
		[Export ("logo")]
		NativeAdImage GetLogo ();

		// @required -(NSString *)callToAction;
		[Abstract]
		[Export ("callToAction")]
		string GetCallToAction ();

		// @required -(NSString *)advertiser;
		[Abstract]
		[Export ("advertiser")]
		string GetAdvertiser ();
	}

	#endregion
}

namespace Google.MobileAds.DoubleClick
{
	#region DoubleClick

	[BaseType (typeof (Google.MobileAds.BannerView),
		Name = "DFPBannerView",
		Delegates = new string [] { "AdSizeDelegate" },
		Events = new Type [] { typeof (Google.MobileAds.AdSizeDelegate) })]
	interface BannerView
	{

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (AdSize size, CGPoint origin);

		[Export ("initWithAdSize:")]
		IntPtr Constructor (AdSize size);

		[New]
		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitID { get; set; }

		[NullAllowed]
		[Export ("appEventDelegate", ArgumentSemantic.Weak)]
		IAppEventDelegate AppEventDelegate { get; set; }

		[NullAllowed]
		[Export ("adSizeDelegate", ArgumentSemantic.Weak)]
		IAdSizeDelegate AdSizeDelegate { get; set; }

		[Export ("validAdSizes", ArgumentSemantic.Copy)]
		NSValue [] ValidAdSizes { get; set; }

		// @property(nonatomic, strong) GADCorrelator *correlator;
		[Export ("correlator", ArgumentSemantic.Strong)]
		Google.MobileAds.Correlator Correlator { get; set; }

		[Export ("enableManualImpressions", ArgumentSemantic.Assign)]
		bool EnableManualImpressions { get; set; }

		[NullAllowed]
		[Export ("customRenderedBannerViewDelegate", ArgumentSemantic.Weak)]
		ICustomRenderedBannerViewDelegate CustomRenderedBannerViewDelegate { get; set; }

		[Export ("recordImpression")]
		void RecordImpression ();

		[Export ("resize:")]
		void Resize (AdSize size);

		[Internal]
		[Export ("setValidAdSizesWithSizes:", IsVariadic = true)]
		void SetValidAdSizes (AdSize firstSize, IntPtr sizesPtr);
	}

	[BaseType (typeof (NSObject), Name = "DFPCustomRenderedAd")]
	interface CustomRenderedAd
	{

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

	interface ICustomRenderedBannerViewDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "DFPCustomRenderedBannerViewDelegate")]
	interface CustomRenderedBannerViewDelegate
	{

		[Abstract]
		[EventArgs ("CustomRenderedBannerViewReceived")]
		[EventName ("CustomRenderedBannerAdReceived")]
		[Export ("bannerView:didReceiveCustomRenderedAd:")]
		void DidReceiveCustomRenderedBannerAd (BannerView bannerView, CustomRenderedAd customRenderedAd);
	}

	interface ICustomRenderedInterstitialDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "DFPCustomRenderedInterstitialDelegate")]
	interface CustomRenderedInterstitialDelegate
	{

		[Abstract]
		[EventArgs ("CustomRenderedInterstitialReceived")]
		[EventName ("CustomRenderedInterstitialReceived")]
		[Export ("interstitial:didReceiveCustomRenderedAd:")]
		void DidReceiveCustomRenderedInterstitial (Interstitial interstitial, CustomRenderedAd customRenderedAd);
	}

	[BaseType (typeof (Google.MobileAds.Interstitial),
		Name = "DFPInterstitial",
		Delegates = new string [] { "CustomRenderedInterstitialDelegate" },
		Events = new Type [] { typeof (CustomRenderedInterstitialDelegate) })]
	interface Interstitial
	{

		[New]
		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitID { get; }

		// @property(nonatomic, strong) GADCorrelator *correlator;
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
	interface Request
	{
		[New]
		[Field ("kDFPSimulatorID", "__Internal")]
		NSString SimulatorId { get; }
		
		[Export ("publisherProvidedID", ArgumentSemantic.Copy)]
		string PublisherProvidedID { get; set; }

		[Export ("categoryExclusions", ArgumentSemantic.Copy)]
		string [] CategoryExclusions { get; set; }

		[Export ("customTargeting", ArgumentSemantic.Copy)]
		NSDictionary CustomTargeting { get; set; }

		[Obsolete ("Set Google.MobileAds.Correlator objects on your ads instead. This method longer affects ad correlation.")]
		[Static]
		[Export ("updateCorrelator")]
		void UpdateCorrelator ();
	}

	#endregion
}