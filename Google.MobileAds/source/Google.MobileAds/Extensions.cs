using System;
using System.Runtime.InteropServices;

using ObjCRuntime;
using Foundation;
using CoreGraphics;
using UIKit;

namespace Google.MobileAds
{
	public partial class AdSizeCons
	{
		public static string GetString (AdSize size)
		{
			return GetNSString (size);
		}
	}

	public partial class Request
	{
		public static readonly string GADGoogleAdMobNetworkName = "GoogleAdMobAds";
	}

	public partial class RequestError
	{
		private static string kGADErrorDomain;

		public static string ErrorDomain {
			get {
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				kGADErrorDomain = (string)Dlfcn.GetStringConstant (RTLD_MAIN_ONLY, "kGADErrorDomain");

				return kGADErrorDomain;
			}
			set {
				kGADErrorDomain = value;

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADErrorDomain");

				Marshal.WriteIntPtr (ptr, new NSString (kGADErrorDomain).Handle);
			}
		}
	}

	public partial class RequestError : NSError
	{
		public RequestError (NSString appDomain, nint code) : this (appDomain, code, null)
		{
		}
	}

	public partial class AdSizeCons
	{
		// Deprecated Macros
		[Obsolete ("Use GADAdSizeCons.Banner Instead")]
		public static readonly CGSize GAD_SIZE_320x50 = AdSizeCons.Banner.Size;

		[Obsolete ("Use GADAdSizeCons.MediumRectangle Instead")]
		public static readonly CGSize GAD_SIZE_300x250 = AdSizeCons.MediumRectangle.Size;

		[Obsolete ("Use ADAdSizeCons.FullBanner Instead")]
		public static readonly CGSize GAD_SIZE_468x60 = AdSizeCons.FullBanner.Size;

		[Obsolete ("Use AdSizeCons.Leaderboard Instead")]
		public static readonly CGSize GAD_SIZE_728x90 = AdSizeCons.Leaderboard.Size;

		[Obsolete ("Use ADAdSizeCons.Skyscraper Instead")]
		public static readonly CGSize GAD_SIZE_120x600 = AdSizeCons.Skyscraper.Size;
	}

}

namespace Google.MobileAds.DoubleClick
{
	public partial class BannerView : Google.MobileAds.BannerView
	{
		[Obsolete ("Use ValidAdSizes property.")]
		public void SetValidAdSizes (params AdSize[] sizes)
		{
			if (sizes == null)
				throw new ArgumentNullException ("sizes");

			var pNativeArr = Marshal.AllocHGlobal (sizes.Length * IntPtr.Size);
			for (int i = 1; i < sizes.Length; ++i) {
				IntPtr sizePtr = Marshal.AllocHGlobal (Marshal.SizeOf (sizes [i]));
				Marshal.StructureToPtr (sizes [i], sizePtr, false);
				Marshal.WriteIntPtr (pNativeArr, (i - 1) * IntPtr.Size, sizePtr);

				Marshal.FreeHGlobal (sizePtr);
			}

			// null termination
			Marshal.WriteIntPtr (pNativeArr, (sizes.Length - 1) * IntPtr.Size, IntPtr.Zero);

			SetValidAdSizes (sizes [0], pNativeArr);
			Marshal.FreeHGlobal (pNativeArr);
		}
	}
}