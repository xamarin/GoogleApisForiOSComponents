using System;
using System.Runtime.InteropServices;

using Foundation;
using CoreGraphics;
using ObjCRuntime;
using UIKit;

namespace Google.Maps
{
	public partial class Constants
	{
		public static double EarthRadius { get { return 6371009.0; } }

		static CGRect? groundOverlayDefaultAnchor = null;

		public static CGRect GroundOverlayDefaultAnchor {
			get {
				if (groundOverlayDefaultAnchor != null)
					return groundOverlayDefaultAnchor.Value;
	
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSGroundOverlayDefaultAnchor");
				groundOverlayDefaultAnchor = (CGRect)Marshal.PtrToStructure (ptr, typeof(CGRect));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return groundOverlayDefaultAnchor.Value;
			}
		}

		static CGPoint? markerDefaultGroundAnchor = null;

		public static CGPoint MarkerDefaultGroundAnchor {
			get {
				if (markerDefaultGroundAnchor != null)
					return markerDefaultGroundAnchor.Value;

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSMarkerDefaultGroundAnchor");
				markerDefaultGroundAnchor = (CGPoint)Marshal.PtrToStructure (ptr, typeof(CGPoint));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return markerDefaultGroundAnchor.Value;
			}
		}

		static CGPoint? markerDefaultInfoWindowAnchor = null;

		public static CGPoint MarkerDefaultInfoWindowAnchor {
			get {
				if (markerDefaultInfoWindowAnchor != null)
					return markerDefaultInfoWindowAnchor.Value;
	
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSMarkerDefaultInfoWindowAnchor");
				markerDefaultInfoWindowAnchor = (CGPoint)Marshal.PtrToStructure (ptr, typeof(CGPoint));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return markerDefaultInfoWindowAnchor.Value;
			}
		}

		static UIImage tileLayerNoTile = null;

		public static UIImage TileLayerNoTile {
			get {
				if (tileLayerNoTile != null)
					return tileLayerNoTile;
	
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSTileLayerNoTile");
				tileLayerNoTile = Runtime.GetNSObject<UIImage> (ptr);
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return tileLayerNoTile;
			}
		}
	}
}

