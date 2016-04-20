Configuring APNS
----------------

To allow Google to send APNS notifications on your behalf, you will need to export your Developer and/or your Production APNS certificates from the Apple Developer portal as .p12 files.

For more information on this process, see [Apple's Documentation][2].



Configuring your App
--------------------

Google provides an easy to use configuration web tool to generate a config file for your app:  

1. Open [Google's configuration tool][1] to create a config file for your app.
2. Enter your app's name and iOS Bundle ID and click continue
3. Upload your Developer APNS .p12 certificate.  You may also want to upload your production .p12 certificate at this time as well.
3. Click *Enable Cloud Messaging*
4. Click *continue* to generate the configuration files
5. Click *Download Google-Service-Info.plist*
6. Add `GoogleService-Info.plist` to your Xamarin.iOS app project and set the *Build Action* to `BundleResource`
7. Note the *Sender ID* value.  You will use this in your code as the `GCM_SENDER_ID` value.



Setting up your AppDelegate
---------------------------

Your `AppDelegate` will contain most of the GCM related code.

In your `FinishedLaunching` method you should start GCM and request to register for remote notifications:

```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{                   
    // Configure and Start GCM
	var gcmConfig = Google.GoogleCloudMessaging.Config.DefaultConfig;
	gcmConfig.ReceiverDelegate = this;
	Service.SharedInstance.Start (gcmConfig);
    
	// Register for remote notifications
	var notTypes = UIUserNotificationType.Sound | UIUserNotificationType.Alert | UIUserNotificationType.Badge;
	var settings = UIUserNotificationSettings.GetSettingsForTypes (notTypes, null);
	UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);
	UIApplication.SharedApplication.RegisterForRemoteNotifications ();

	// Your user code, if any, here

	return true;
}
```

Since in the code above the GCM Config's delegate was set to `this` (the AppDelegate), you should also implement `IReceiverDelegate` in your `AppDelegate` class:

Next, add an override for handling the registration for remote notifications:

```csharp
public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
{          
	// Save our token in memory for future calls to GCM
	DeviceToken = deviceToken;

	// Configure and start Instance ID
	var config = Google.InstanceID.Config.DefaultConfig;
	InstanceId.SharedInstance.Start (config);

	// Get a GCM token
	GetToken ();
}
```

In this method, you will save the `deviceToken` to a variable for later use, as well as configure and start InstanceID which is needed to obtain a GCM Registration Token.

Finally, this method calls `GetToken()` to actually request a GCM Registration token, which is defined as:

```csharp
void GetToken ()
{
	// Register APNS Token to GCM
	var options = new NSDictionary ();
	options.SetValueForKey (DeviceToken, Constants.RegisterAPNSOption);
	options.SetValueForKey (new NSNumber(true), Constants.APNSServerTypeSandboxOption);

	// Get our token
	InstanceId.SharedInstance.Token (
		GCM_SENDER_ID,
		Constants.ScopeGCM,
		options,
		(token, error) => Log ("GCM Registration ID: " + token));
}
```

If the `error` value is null in the callback that was passed into the `Token()` method, you should have a valid GCM Registration token which you will then use on your server to send messages to this device.


### Receiving Notifications

Notifications (both APNS and from GCM) will occur inside of the `DidReceiveRemoteNotification` override.  When you receive a message you should inform GCM that you successfully received it:

```csharp
public override void DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
{
	// Your own notification handling logic here
	
	// Notify GCM we received the message
	Service.SharedInstance.AppDidReceiveMessage (userInfo);
}
```



### Connecting to GCM Servers Directly

When your application is in the foreground you should connect directly to GCM's servers:

```csharp
public override void OnActivated (UIApplication application)
{
	Service.SharedInstance.Connect (error => {
		if (error != null)
			Console.WriteLine ("Could not connect to GCM: {0}", error.LocalizedDescription);
		else
			Console.WriteLine ("Connected to GCM");
	});
}
```

It's also important to disconnect from the GCM Server when your application enters the background so you can continue to receive APNS notifications instead:

```csharp
public override void DidEnterBackground (UIApplication application)
{
	Service.SharedInstance.Disconnect ();
}
```


### Unregistering from GCM

It's possible to unregister from GCM by deleting your token:

```csharp
public void DeleteToken ()
{
	InstanceId.SharedInstance.DeleteToken (
	GCM_SENDER_ID,
	Constants.ScopeGCM,
	error => {
		// Callback, non-null error if there was a problem
		if (error != null)
			Console.WriteLine ("Deleted Token");
		else 
			Console.WriteLine ("Error deleting token");
	});
}
```

### Sending Upstream Messages

One of the advantages to being directly connected to GCM's Servers when your app is in the foreground is the ability to send upstream messages back to the server:

```csharp
int messageId = 1;

// We can send upstream messages back to GCM
public void SendUpstreamMessage ()
{            
    var msg = new NSDictionary ();
    msg.SetValueForKey (new NSString ("1234"), new NSString ("userId"));
    msg.SetValueForKey (new NSString ("hello world"), new NSString ("msg"));

    var to = GCM_SENDER_ID + "@gcm.googleapis.com";

    Service.SharedInstance.SendMessage (msg, to, (messageId++).ToString ());
}
```

### Handling Callbacks for Upstream Messages

Since you implemented `IReceiverDelegate` in your AppDelegate, you can add some methods to be invoked as callbacks for upstream messages:

```csharp
[Export ("didDeleteMessagesOnServer")]
public void DidDeleteMessagesOnServer ()
{
	// ...
}

[Export ("didSendDataMessageWithID:")]
public void DidSendDataMessage (string messageID)
{
	// ...
}

[Export ("willSendDataMessageWithID:error:")]
public void WillSendDataMessage (string messageID, NSError error)
{
	// ...
}
```


[1]: https://developers.google.com/mobile/add?platform=ios&cntapi=signin
[2]: https://developer.apple.com/library/ios/documentation/IDEs/Conceptual/AppDistributionGuide/ConfiguringPushNotifications/ConfiguringPushNotifications.html