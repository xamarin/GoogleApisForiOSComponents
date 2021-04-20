using Foundation;
using UIKit;
using UserNotifications;

using Firebase.InstanceID;
using Firebase.Core;
using Firebase.CloudMessaging;
using System;

namespace CloudMessagingSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate, IUNUserNotificationCenterDelegate, IMessagingDelegate
	{
		public event EventHandler<UserInfoEventArgs> MessageReceived;

		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			(Window.RootViewController as UINavigationController).PushViewController (new UserInfoViewController (this), true);
			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

			App.Configure ();

			// Register your app for remote notifications.
			if (UIDevice.CurrentDevice.CheckSystemVersion (10, 0)) {
				// For iOS 10 display notification (sent via APNS)
				UNUserNotificationCenter.Current.Delegate = this;

				var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
				UNUserNotificationCenter.Current.RequestAuthorization (authOptions, (granted, error) => {
					Console.WriteLine (granted);
				});
			} else {
				// iOS 9 or before
				var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
				var settings = UIUserNotificationSettings.GetSettingsForTypes (allNotificationTypes, null);
				UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);
			}

			UIApplication.SharedApplication.RegisterForRemoteNotifications ();

			Messaging.SharedInstance.Delegate = this;

			InstanceId.SharedInstance.GetInstanceId (InstanceIdResultHandler);

			return true;
		}

		void InstanceIdResultHandler (InstanceIdResult result, NSError error)
		{
			if (error != null) {
				LogInformation (nameof (InstanceIdResultHandler), $"Error: {error.LocalizedDescription}");
				return;
			}

			LogInformation (nameof (InstanceIdResultHandler), $"Remote Instance Id token: {result.Token}");
		}

		[Export ("messaging:didReceiveRegistrationToken:")]
		public void DidReceiveRegistrationToken (Messaging messaging, string fcmToken)
		{
			// Monitor token generation: To be notified whenever the token is updated.

			LogInformation (nameof (DidReceiveRegistrationToken), $"Firebase registration token: {fcmToken}");

			// TODO: If necessary send token to application server.
			// Note: This callback is fired at each app startup and whenever a new token is generated.
		}

		// You'll need this method if you set "FirebaseAppDelegateProxyEnabled": NO in GoogleService-Info.plist
		//public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		//{
		//	Messaging.SharedInstance.ApnsToken = deviceToken;
		//}

		public override void DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
		{
			// Handle Notification messages in the background and foreground.
			// Handle Data messages for iOS 9 and below.

			// If you are receiving a notification message while your app is in the background,
			// this callback will not be fired till the user taps on the notification launching the application.
			// TODO: Handle data of notification

			// With swizzling disabled you must let Messaging know about the message, for Analytics
			//Messaging.SharedInstance.AppDidReceiveMessage (userInfo);

			HandleMessage (userInfo);

			// Print full message.
			LogInformation (nameof (DidReceiveRemoteNotification), userInfo);

			completionHandler (UIBackgroundFetchResult.NewData);
		}

		void HandleMessage (NSDictionary message)
		{
			if (MessageReceived == null)
				return;

			MessageType messageType;
			if (message.ContainsKey (new NSString ("aps")))
				messageType = MessageType.Notification;
			else
				messageType = MessageType.Data;

			var e = new UserInfoEventArgs (message, messageType);
			MessageReceived (this, e);
		}

		public static void ShowMessage (string title, string message, UIViewController fromViewController, Action actionForOk = null)
		{
			var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
			alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, (obj) => actionForOk?.Invoke ()));
			fromViewController.PresentViewController (alert, true, null);
		}

		void LogInformation (string methodName, object information) => Console.WriteLine ($"\nMethod name: {methodName}\nInformation: {information}");
	}
}


