using System;

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

	public struct AdSize
	{
		public CGSize Size;
		public uint Flags;
	}

	[Native]
	public enum SearchCallButtonColor : ulong
	{
		Light,
		Medium,
		Dark
	}

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