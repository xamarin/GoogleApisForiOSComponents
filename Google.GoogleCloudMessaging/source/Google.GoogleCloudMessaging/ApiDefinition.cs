using Foundation;
using ObjCRuntime;

namespace Google.GoogleCloudMessaging
{

	[BaseType (typeof(NSObject), Name = "GCMConfig")]
	partial interface Config
	{
		[Export ("receiverDelegate", ArgumentSemantic.Weak)]
		IReceiverDelegate ReceiverDelegate { get; set; }

		[Export ("logLevel", ArgumentSemantic.Assign)]
		LogLevel LogLevel { get; set; }

		// @property(nonatomic, readwrite, assign) BOOL useNewRemoteNotificationCallback;
		[Export ("useNewRemoteNotificationCallback", ArgumentSemantic.Assign)]
		bool UseNewRemoteNotificationCallback { get; set; }

		[Static]
		[Export ("defaultConfig")]
		Config DefaultConfig { get; }
	}

	// typedef void (^GCMPubSubCompletion)(NSError *);
	public delegate void PubSubCompletion (NSError error);

	[BaseType (typeof(NSObject), Name = "GCMPubSub")]
	partial interface PubSub
	{
		[Static]
		[Export ("sharedInstance")]
		PubSub SharedInstance { get; }

		[Export ("subscribeWithToken:topic:options:handler:")]
		void Subscribe (string token, string topic, NSDictionary options, PubSubCompletion handler);

		[Export ("unsubscribeWithToken:topic:options:handler:")]
		void Unsubscribe (string token, string topic, NSDictionary options, PubSubCompletion handler);
	}

	interface IReceiverDelegate
	{
	}

	[Model, Protocol]
	[BaseType (typeof(NSObject), Name = "GCMReceiverDelegate")]
	partial interface ReceiverDelegate
	{
		[Export ("willSendDataMessageWithID:error:")]
		void WillSendDataMessage (string messageID, NSError error);

		[Export ("didSendDataMessageWithID:")]
		void DidSendDataMessage (string messageID);

		[Export ("didDeleteMessagesOnServer")]
		void DidDeleteMessagesOnServer ();
	}

	// typedef void (^GCMServiceConnectCompletion)(NSError *);
	public delegate void ServiceConnectCompletion (NSError error);

	[BaseType (typeof(NSObject), Name = "GCMService")]
	partial interface Service
	{
		[Static]
		[Export ("sharedInstance")]
		Service SharedInstance { get; }

		[Export ("startWithConfig:")]
		void Start (Config config);

		[Export ("teardown")]
		void Teardown ();

		[Export ("appDidReceiveMessage:")]
		bool AppDidReceiveMessage (NSDictionary message);

		[Export ("connectWithHandler:")]
		void Connect (ServiceConnectCompletion handler);

		[Export ("disconnect")]
		void Disconnect ();

		[Export ("sendMessage:to:withId:")]
		void SendMessage (NSDictionary message, string to, string msgId);

		[Export ("sendMessage:to:timeToLive:withId:")]
		void SendMessage (NSDictionary message, string to, long ttl, string msgId);
	}
}