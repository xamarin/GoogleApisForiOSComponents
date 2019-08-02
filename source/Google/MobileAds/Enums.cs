using System;
using System.Runtime.InteropServices;

using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace Google.MobileAds
{
	[Native]
	public enum AdFormat : long {
		Banner,
		Interstitial,
		Rewarded,
		Native
	}

	public enum AdLoaderAdType
	{
		// extern NSString *const kGADAdLoaderAdTypeNativeAppInstall;
		[Field ("kGADAdLoaderAdTypeNativeAppInstall", "__Internal")]
		NativeAppInstall,

		// extern NSString *const kGADAdLoaderAdTypeNativeContent;
		[Field ("kGADAdLoaderAdTypeNativeContent", "__Internal")]
		NativeContent,

		// extern NSString *const kGADAdLoaderAdTypeNativeCustomTemplate;
		[Field ("kGADAdLoaderAdTypeNativeCustomTemplate", "__Internal")]
		NativeCustomTemplate,

		// extern NSString *const kGADAdLoaderAdTypeDFPBanner;
		[Field ("kGADAdLoaderAdTypeDFPBanner", "__Internal")]
		DfpBanner,

		// AD_EXTERN GADAdLoaderAdType const kGADAdLoaderAdTypeUnifiedNative;
		[Field ("kGADAdLoaderAdTypeUnifiedNative", "__Internal")]
		UnifiedNative
	}

	//GADRequest file
	[Native]
	public enum Gender : long
	{
		Unknown,
		Male,
		Female
	}

	//GADRequestError file
	[Native]
	public enum ErrorCode : long
	{
		InvalidRequest,
		NoFill,
		NetworkError,
		ServerError,
		OSVersionTooLow,
		Timeout,
		InterstitialAlreadyUsed,
		MediationDataError,
		MediationAdapterError,
		MediationNoFill,
		MediationInvalidAdSize,
		InternalError,
		InvalidArgument,
		ReceivedInvalidResponse,
		RewardedAdAlreadyUsed
	}

	[Native]
	public enum SearchBorderType : ulong
	{
		None,
		Dashed,
		Dotted,
		Solid
	}

	[Native]
	public enum SearchCallButtonColor : ulong
	{
		Light,
		Medium,
		Dark
	}

	[Obsolete]
	[Native]
	public enum InAppPurchaseStatus : long
	{
		Error = 0,
		Successful = 1,
		Cancel = 2,
		InvalidProduct = 3
	}

	[Native]
	public enum MediaAspectRatio : long {
		Unknown = 0,
		Any = 1,
		Landscape = 2,
		Portrait = 3,
		Square = 4
	}

	[Native]
	public enum AdapterInitializationState : long {
		NotReady = 0,
		Ready = 1
	}

	[Native]
	public enum NativeAdImageAdLoaderOptionsOrientation : long
	{
		Any = 1,
		Portrait = 2,
		Landscape = 3
	}

	[Native]
	public enum AdChoicesPosition : long
	{
		TopRightCorner,
		TopLeftCorner,
		BottomRightCorner,
		BottomLeftCorner
	}
}

namespace Google.MobileAds.Consent {
	[Native]
	public enum ConsentStatus : long
	{
		Unknown = 0,
		NonPersonalized = 1,
		Personalized = 2
	}

	[Native]
	public enum DebugGeography : long
	{
		Disabled = 0,
		Eea = 1,
		NotEea = 2
	}
}
