using System.IO;

using Foundation;
using UIKit;

using Xamarin.iOS.Shared.ViewControllers;

namespace Xamarin.iOS.Shared.Helpers {
	public static class GoogleServiceInfoPlistHelper {
		public const string FileName = "GoogleService-Info.plist";

		public static bool FileExist() {
			string fileName = NSBundle.MainBundle.PathForResource (FileName, null);
			return File.Exists (fileName);
		}

		public static UIWindow CreateWindowWithFileNotFoundMessage () {
			UIWindow window = new UIWindow (UIScreen.MainScreen.Bounds) {
				RootViewController = new GoogleServiceInfoPlistNotFoundViewController ()
			};
			window.MakeKeyAndVisible ();
			return window;
		}
	}
}
