using System;

using UIKit;
using Foundation;
using ObjCRuntime;

namespace Firebase.CloudMessaging
{
	// typedef void(^FIRMessagingConnectCompletion)(NSError* __nullable error);
	delegate void ConnectCompletionHandler ([NullAllowed] NSError error);

	// @interface FIRMessagingMessageInfo : NSObject
	[BaseType (typeof (NSObject), Name = "FIRMessagingMessageInfo")]
	interface MessageInfo
	{
		// @property (readonly, assign, nonatomic) FIRMessagingMessageStatus status;
		[Export ("status", ArgumentSemantic.Assign)]
		MessageStatus Status { get; }
	}

	// @interface FIRMessagingRemoteMessage : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRMessagingRemoteMessage")]
	interface RemoteMessage
	{
		// @property(nonatomic, readonly, strong, nonnull) NSDictionary *appData;
		[Export ("appData", ArgumentSemantic.Strong)]
		NSDictionary AppData { get; }
	}

	interface IMessagingDelegate
	{
	}

	// @protocol FIRMessagingDelegate <NSObject>
	[Introduced (PlatformName.iOS, 10, 0)]
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FIRMessagingDelegate")]
	interface MessagingDelegate
	{
		// - (void)applicationReceivedRemoteMessage:(nonnull FIRMessagingRemoteMessage *)remoteMessage;
		[Abstract]
		[Export ("applicationReceivedRemoteMessage:")]
		void ApplicationReceivedRemoteMessage (RemoteMessage remoteMessage);
	}

	// @interface FIRMessaging : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRMessaging")]
	interface Messaging
	{
		// extern NSString *const _Nonnull FIRMessagingSendSuccessNotification;
		[Notification]
		[Field ("FIRMessagingSendSuccessNotification", "__Internal")]
		NSString SendSuccessNotification { get; }

		// extern NSString *const _Nonnull FIRMessagingSendErrorNotification;
		[Notification]
		[Field ("FIRMessagingSendErrorNotification", "__Internal")]
		NSString SendErrorNotification { get; }

		// extern NSString *const _Nonnull FIRMessagingMessagesDeletedNotification;
		[Notification]
		[Field ("FIRMessagingMessagesDeletedNotification", "__Internal")]
		NSString MessagesDeletedNotification { get; }

		// @property(nonatomic, weak, nullable) id<FIRMessagingDelegate> remoteMessageDelegate;
		[Introduced (PlatformName.iOS, 10, 0)]
		[NullAllowed]
		[Export ("remoteMessageDelegate", ArgumentSemantic.Weak)]
		IMessagingDelegate RemoteMessageDelegate { get; set; }

		// +(instancetype _Nonnull)messaging;
		[Static]
		[Export ("messaging")]
		Messaging SharedInstance { get; }

		// -(void)connectWithCompletion:(FIRMessagingConnectCompletion _Nonnull)handler;
		[Export ("connectWithCompletion:")]
		void Connect (ConnectCompletionHandler handler);

		// -(void)disconnect;
		[Export ("disconnect")]
		void Disconnect ();

		// -(void)subscribeToTopic:(NSString * _Nonnull)topic;
		[Export ("subscribeToTopic:")]
		void Subscribe (string topic);

		// -(void)unsubscribeFromTopic:(NSString * _Nonnull)topic;
		[Export ("unsubscribeFromTopic:")]
		void Unsubscribe (string topic);

		// -(void)sendMessage:(NSDictionary * _Nonnull)message to:(NSString * _Nonnull)receiver withMessageID:(NSString * _Nonnull)messageID timeToLive:(int64_t)ttl;
		[Export ("sendMessage:to:withMessageID:timeToLive:")]
		void SendMessage (NSDictionary message, string receiver, string messageId, long ttl);

		// -(FIRMessagingMessageInfo * _Nonnull)appDidReceiveMessage:(NSDictionary * _Nonnull)message;
		[Export ("appDidReceiveMessage:")]
		MessageInfo AppDidReceiveMessage (NSDictionary message);
	}
}

