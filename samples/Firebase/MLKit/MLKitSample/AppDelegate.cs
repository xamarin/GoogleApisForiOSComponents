using Foundation;
using UIKit;

namespace MLKitSample {
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIResponder, IUIApplicationDelegate {

		[Export ("window")]
		public UIWindow Window { get; set; }

		[Export ("application:didFinishLaunchingWithOptions:")]
		public bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method
			Firebase.Core.App.Configure ();

			var instanceId = Firebase.InstanceID.InstanceId.SharedInstance;
			var remoteConfig = Firebase.RemoteConfig.RemoteConfig.SharedInstance;
			var installations = Firebase.Installations.Installations.DefaultInstance;
			var abTesting = Firebase.ABTesting.ExperimentController.SharedInstance;
			var common = new Firebase.MLKit.ModelInterpreter.CustomRemoteModel ("Dummy");
			var naturalLanguage = Firebase.MLKit.NaturalLanguage.NaturalLanguageApi.DefaultInstance;
			var vision = Firebase.MLKit.Vision.VisionApi.Create ();

			return true;
		}

		// UISceneSession Lifecycle

		[Export ("application:configurationForConnectingSceneSession:options:")]
		public UISceneConfiguration GetConfiguration (UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
		{
			// Called when a new scene session is being created.
			// Use this method to select a configuration to create the new scene with.
			return UISceneConfiguration.Create ("Default Configuration", connectingSceneSession.Role);
		}

		[Export ("application:didDiscardSceneSessions:")]
		public void DidDiscardSceneSessions (UIApplication application, NSSet<UISceneSession> sceneSessions)
		{
			// Called when the user discards a scene session.
			// If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
			// Use this method to release any resources that were specific to the discarded scenes, as they will not return.
		}
	}
}

