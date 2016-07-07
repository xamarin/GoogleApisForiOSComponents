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
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return kGADErrorDomain;
			}
			set {
				kGADErrorDomain = value;

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADErrorDomain");
				Marshal.WriteIntPtr (ptr, new NSString (kGADErrorDomain).Handle);
				Dlfcn.dlclose (RTLD_MAIN_ONLY);
			}
		}
	}

	public partial class RequestError : NSError
	{
		public RequestError (NSString appDomain, nint code) : this (appDomain, code, null)
		{
		}
	}

	[Preserve (AllMembers = true)]
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

		// GADAdSize GADAdSizeFromCGSize(CGSize size);
		[DllImport ("__Internal", EntryPoint = "GADAdSizeFromCGSize")]
		public static extern AdSize GetFromCGSize (CGSize size);

		// GADAdSize GADAdSizeFullWidthPortraitWithHeight(CGFloat height);
		[DllImport ("__Internal", EntryPoint = "GADAdSizeFullWidthPortraitWithHeight")]
		public static extern AdSize GetFullWidthPortrait (nfloat height);

		// GADAdSize GADAdSizeFullWidthLandscapeWithHeight (CGFloat height);
		[DllImport ("__Internal", EntryPoint = "GADAdSizeFullWidthLandscapeWithHeight")]
		public static extern AdSize GetFullWidthLandscape (nfloat height);

		// BOOL GADAdSizeEqualToSize(GADAdSize size1, GADAdSize size2);
		[DllImport ("__Internal", EntryPoint = "GADAdSizeEqualToSize")]
		public static extern bool Equals (AdSize size, AdSize toSize);

		// CGSize CGSizeFromGADAdSize(GADAdSize size);
		[DllImport ("__Internal", EntryPoint = "CGSizeFromGADAdSize")]
		public static extern CGSize GetCGSize (AdSize size);

		// BOOL IsGADAdSizeValid(GADAdSize size);
		[DllImport ("__Internal", EntryPoint = "IsGADAdSizeValid")]
		public static extern bool IsAdSizeValid (AdSize size);

		// NSString *NSStringFromGADAdSize(GADAdSize size);
		[DllImport ("__Internal", EntryPoint = "NSStringFromGADAdSize")]
		static extern IntPtr _GetNSString (AdSize size);

		// NSValue *NSValueFromGADAdSize(GADAdSize size);
		[DllImport ("__Internal", EntryPoint = "NSValueFromGADAdSize")]
		static extern IntPtr _GetNSValue (AdSize size);

		// GADAdSize GADAdSizeFromNSValue(NSValue *value);
		[DllImport ("__Internal", EntryPoint = "GADAdSizeFromNSValue")]
		public static extern AdSize _GetFromNSValue (IntPtr value);

		public static NSString GetNSString (AdSize size)
		{
			return Runtime.GetNSObject<NSString> (_GetNSString (size));
		}

		public static NSValue GetNSValue (AdSize size)
		{
			return Runtime.GetNSObject<NSValue> (_GetNSValue (size));
		}

		public static AdSize GetFromNSValue (NSValue value)
		{
			return _GetFromNSValue (value.Handle);
		}

		static AdSize? banner;
		public static AdSize Banner {
			get {
				if (banner == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADAdSizeBanner");
					banner = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return banner.Value;
			}
		}

		static AdSize? largeBanner;
		public static AdSize LargeBanner {
			get {
				if (largeBanner == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADAdSizeLargeBanner");
					largeBanner = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return largeBanner.Value;
			}
		}

		static AdSize? mediumRectangle;
		public static AdSize MediumRectangle {
			get {
				if (mediumRectangle == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADAdSizeMediumRectangle");
					mediumRectangle = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return mediumRectangle.Value;
			}
		}

		static AdSize? fullBanner;
		public static AdSize FullBanner {
			get {
				if (fullBanner == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADAdSizeFullBanner");
					fullBanner = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return fullBanner.Value;
			}
		}

		static AdSize? leaderboard;
		public static AdSize Leaderboard {
			get {
				if (leaderboard == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADAdSizeLeaderboard");
					leaderboard = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return leaderboard.Value;
			}
		}

		static AdSize? skyscraper;
		public static AdSize Skyscraper {
			get {
				if (skyscraper == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADAdSizeSkyscraper");
					skyscraper = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return skyscraper.Value;
			}
		}

		static AdSize? smartBannerPortrait;
		public static AdSize SmartBannerPortrait {
			get {
				if (smartBannerPortrait == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADAdSizeSmartBannerPortrait");
					smartBannerPortrait = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return smartBannerPortrait.Value;
			}
		}

		static AdSize? smartBannerLandscape;
		public static AdSize SmartBannerLandscape {
			get {
				if (smartBannerLandscape == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADAdSizeSmartBannerLandscape");
					smartBannerLandscape = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return smartBannerLandscape.Value;
			}
		}

		static AdSize? fluid;
		public static AdSize Fluid {
			get {
				if (fluid == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADAdSizeFluid");
					fluid = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return fluid.Value;
			}
		}

		static AdSize? invalid;
		public static AdSize Invalid {
			get {
				if (invalid == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADAdSizeInvalid");
					invalid = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return invalid.Value;
			}
		}
	}

}

namespace Google.MobileAds.DoubleClick
{
	public partial class BannerView : Google.MobileAds.BannerView
	{
		[Obsolete ("Use ValidAdSizes property.")]
		public void SetValidAdSizes (params AdSize [] sizes)
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