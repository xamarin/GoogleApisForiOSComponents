using Xamarin.iOS.Shared.Helpers;

namespace AnalyticsSample;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

		// You can download your GoogleService-Info.plist file following the next link:
		// https://firebase.google.com/docs/ios/setup
		if (!GoogleServiceInfoPlistHelper.FileExist ()) {
			Window = GoogleServiceInfoPlistHelper.CreateWindowWithFileNotFoundMessage ();
			return true;
		}

		var coreType = typeof (Firebase.Core.App);
		var installationsType = typeof (Firebase.Installations.Installations);
		var analyticsType = typeof (Firebase.Analytics.Analytics);
		Firebase.Core.App.Configure ();

		// create a UIViewController with a single UILabel
		var vc = new UIViewController ();
		vc.View!.AddSubview (new UILabel (Window!.Frame) {
			BackgroundColor = UIColor.White,
			TextColor = UIColor.Black,
			TextAlignment = UITextAlignment.Center,
			Lines = 0,
			Text = $"Hello, iOS!\nRunning {nameof (AnalyticsSample)} with .net6.0!"
		});
		Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		return true;
	}
}

