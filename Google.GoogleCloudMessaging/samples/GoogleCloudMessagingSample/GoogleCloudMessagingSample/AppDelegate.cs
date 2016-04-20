using Foundation;
using UIKit;
using Google.InstanceID;
using System;
using Google.GoogleCloudMessaging;

namespace InstanceIDSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate, IInstanceIdDelegate, IReceiverDelegate
	{
		public override UIWindow Window {
			get;
			set;
		}

		public Google.Core.Configuration Configuration { get; set; }

		NSData DeviceToken { get; set; }

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{                   
			Log ("Finished Launching");

			Log ("Starting GCM");

			// Configure our core Google 
			NSError err;
			Google.Core.Context.SharedInstance.Configure (out err);
			if (err != null)
				Console.WriteLine ("Failed to configure Google: {0}", err.LocalizedDescription);
			Configuration = Google.Core.Context.SharedInstance.Configuration;

			// Configure and Start GCM
			var gcmConfig = Google.GoogleCloudMessaging.Config.DefaultConfig;
			gcmConfig.ReceiverDelegate = this;

			Service.SharedInstance.Start (gcmConfig);

			Log ("Started GCM");

			Log ("Registering for Remote Notifications");

			// Register for remote notifications
			var notTypes = UIUserNotificationType.Sound | UIUserNotificationType.Alert | UIUserNotificationType.Badge;
			var settings = UIUserNotificationSettings.GetSettingsForTypes (notTypes, null);
			UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);
			UIApplication.SharedApplication.RegisterForRemoteNotifications ();

			return true;
		}

		public override void FailedToRegisterForRemoteNotifications (UIApplication application, NSError error)
		{
			Log ("Failed to register for remote notifications {0}", error.LocalizedDescription);
		}

		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{          
			Log ("Registered for Remote Notifications: {0}", deviceToken.Description);

			// Save our token in memory for future calls to GCM
			DeviceToken = deviceToken;

			Log ("Starting Instance ID");

			// Configure and start Instance ID
			var config = Google.InstanceID.Config.DefaultConfig;
			config.Delegate = this;
			InstanceId.SharedInstance.Start (config);

			Log ("Started Instance ID");

			// Get a GCM token
			GetToken ();
		}

		[Export ("onTokenRefresh")]
		public void OnTokenRefresh ()
		{
			Log ("Token Refreshed on Server");

			// Token was refreshed, get it again
			GetToken ();
		}

		void GetToken ()
		{            
			// Register APNS Token to GCM
			var options = new NSMutableDictionary ();
			options.SetValueForKey (DeviceToken, Constants.RegisterAPNSOption);
			options.SetValueForKey (new NSNumber (true), Constants.APNSServerTypeSandboxOption);

			Log ("Get Token");

			// Get our token
			InstanceId.SharedInstance.Token (
				Configuration.GcmSenderId,
				Constants.ScopeGCM,
				options,
				(token, error) => Log ("GCM Registration ID: " + token));
		}

		public override void DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
		{
			// Handle the notification here

			Log ("Received Remote Notification");

			// Notify GCM we received the message
			Service.SharedInstance.AppDidReceiveMessage (userInfo);
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
			// Connect to the GCM server to receive non-APNS notifications
			Service.SharedInstance.Connect (error => {
				if (error != null) {
					Log ("Could not connect to GCM: {0}", error.LocalizedDescription);
				} else {
					Log ("Connected to GCM");
				}
			});
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Disconnect from GCM when we go to background so we'll 
			// begin receiving APNS messages again
			Service.SharedInstance.Disconnect ();
			Log ("Disconnected");
		}

		// We can use this to delete our regsitration with GCM
		public void DeleteToken ()
		{
			Log ("Deleting Token");

			InstanceId.SharedInstance.DeleteToken (
				Configuration.GcmSenderId,
				Constants.ScopeGCM,
				error => {
					// Callback, non-null error if there was a problem
					if (error != null)
						Log ("Deleted Token");
					else
						Log ("Error deleting token");
				});            
		}

		int messageId = 1;

		// We can send upstream messages back to GCM
		public void SendUpstreamMessage ()
		{            
			var msg = new NSDictionary ();
			msg.SetValueForKey (new NSString ("1234"), new NSString ("userId"));
			msg.SetValueForKey (new NSString ("hello world"), new NSString ("msg"));

			var to = Configuration.GcmSenderId + "@gcm.googleapis.com";

			Log ("Sending Message to: {0}", to);
			Service.SharedInstance.SendMessage (msg, to, (messageId++).ToString ());
		}

		// Implement some messages to receive notifications about upstream message callbacks
		[Export ("didDeleteMessagesOnServer")]
		public void DidDeleteMessagesOnServer ()
		{
			Log ("Did Delete Messages on Server");
		}

		[Export ("didSendDataMessageWithID:")]
		public void DidSendDataMessage (string messageID)
		{
			Log ("Did Send Message: {0}", messageId);
		}

		[Export ("willSendDataMessageWithID:error:")]
		public void WillSendDataMessage (string messageID, NSError error)
		{
			Log ("Will Send Message: {0}", messageId);
		}

		public static event Action<string> LoggedMessage;

		static void Log (string messageFormat, params object[] args)
		{
			var msg = string.Format (messageFormat, args);

			Console.WriteLine (msg);

			var evt = LoggedMessage;
			if (evt != null)
				evt (msg);
		}
	}
}


