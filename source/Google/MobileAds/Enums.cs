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

	[Native]
	public enum AdValuePrecision : long
	{
		Unknown = 0,
		Estimated = 1,
		PublisherProvided = 2,
		Precise = 3
	}

	[Native]
	public enum PresentationErrorCode : long
	{
		AdNotReady = 15,
		AdTooLarge = 16,
		Internal = 17,
		AdAlreadyUsed = 18
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
		InvalidRequest = 0,
		NoFill = 1,
		NetworkError = 2,
		ServerError = 3,
		OSVersionTooLow = 4,
		Timeout = 5,
		[Obsolete ("Use AdAlreadyUsed enum value instead.")]
		InterstitialAlreadyUsed = AdAlreadyUsed,
		MediationDataError = 7,
		MediationAdapterError = 8,
		MediationInvalidAdSize = 10,
		InternalError = 11,
		InvalidArgument = 12,
		ReceivedInvalidResponse = 13,
		[Obsolete ("Use AdAlreadyUsed enum value instead.")]
		RewardedAdAlreadyUsed = AdAlreadyUsed,
		[Obsolete ("Use NoFill enum value instead.")]
		MediationNoFill = NoFill,
		AdAlreadyUsed = 19,
		ApplicationIdentifierMissing = 20
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
		Required = 1,
		NotRequired = 2,
		Obtained = 3
	}

	[Native]
	public enum ConsentType : long
	{
		Unknown = 0,
		Personalized = 1,
		NonPersonalized = 2
	}

	[Native]
	public enum FormStatus : long
	{
		Unknown = 0,
		Available = 1,
		Unavailable = 2
	}

	[Native]
	public enum DebugGeography : long
	{
		Disabled = 0,
		Eea = 1,
		NotEea = 2
	}

	[Native]
	public enum RequestErrorCode : long
	{
		Internal = 1,
		InvalidAppID = 2,
		Network = 3,
		Misconfiguration = 4
	}

	[Native]
	public enum FormErrorCode : long
	{
		Internal = 5,
		AlreadyUsed = 6,
		Unavailable = 7,
		Timeout = 8
	}
}
