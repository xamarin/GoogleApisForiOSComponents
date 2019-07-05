using System;
using System.Runtime.InteropServices;

using ObjCRuntime;
using CoreGraphics;

namespace Google.MobileAds
{
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
		ReceivedInvalidResponse
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
