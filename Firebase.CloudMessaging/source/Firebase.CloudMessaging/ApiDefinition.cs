using System;

using UIKit;
using Foundation;
using ObjCRuntime;

namespace Firebase.CloudMessaging
{
	// typedef void(^FIRMessagingFCMTokenFetchCompletion)(NSString * _Nullable FCMToken, NSError* _Nullable error) FIR_SWIFT_NAME(MessagingFCMTokenFetchCompletion);
	delegate void MessagingFcmTokenFetchCompletionHandler([NullAllowed] string fcmToken, [NullAllowed] NSError error);

	// typedef void(^FIRMessagingDeleteFCMTokenCompletion)(NSError * _Nullable error) FIR_SWIFT_NAME(MessagingDeleteFCMTokenCompletion);
	delegate void MessagingDeleteFcmTokenCompletionHandler([NullAllowed] NSError error);

	[Obsolete ("Please listen for the Messaging.ConnectionStateChangedNotification NSNotification instead.")]
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
		// - (void)messaging:(nonnull FIRMessaging *)messaging didRefreshRegistrationToken:(nonnull NSString *)fcmToken FIR_SWIFT_NAME(messaging(_:didRefreshRegistrationToken:));
		[Abstract]
		[Export("messaging:didRefreshRegistrationToken:")]
		void DidRefreshRegistrationToken(Messaging messaging, string fcmToken);

		// - (void)messaging:(nonnull FIRMessaging *)messaging didReceiveMessage:(nonnull FIRMessagingRemoteMessage *)remoteMessage FIR_SWIFT_NAME(messaging(_:didReceive:) __IOS_AVAILABLE(10.0);
		[Introduced (PlatformName.iOS, 10, 0, 0)]
		[Export("messaging:didReceiveMessage:")]
		void DidReceiveMessage(Messaging messaging, RemoteMessage remoteMessage);

		// - (void)applicationReceivedRemoteMessage:(nonnull FIRMessagingRemoteMessage *)remoteMessage;
		[Obsolete ("Use DidReceiveMessage method instead.")]
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

		// extern NSString *const _Nonnull FIRMessagingConnectionStateChangedNotification;
		[Notification]
		[Field("FIRMessagingConnectionStateChangedNotification", "__Internal")]
		NSString ConnectionStateChangedNotification { get; }

		// extern NSString *const _Nonnull FIRMessagingRegistrationTokenRefreshedNotification;
		[Notification]
		[Field("FIRMessagingRegistrationTokenRefreshedNotification", "__Internal")]
		NSString RegistrationTokenRefreshedNotification { get; }

		// @property(nonatomic, weak, nullable) id<FIRMessagingDelegate> delegate;
		[NullAllowed]
		[Export("delegate", ArgumentSemantic.Weak)]
		IMessagingDelegate Delegate { get; set; }

		// @property(nonatomic, weak, nullable) id<FIRMessagingDelegate> remoteMessageDelegate;
		[Obsolete ("Use Delegate property instead.")]
		[Introduced (PlatformName.iOS, 10, 0)]
		[NullAllowed]
		[Export ("remoteMessageDelegate", ArgumentSemantic.Weak)]
		IMessagingDelegate RemoteMessageDelegate { get; set; }

		// @property(nonatomic) BOOL shouldEstablishDirectChannel;
		[Export("shouldEstablishDirectChannel")]
		bool ShouldEstablishDirectChannel { get; set; }

		// @property(nonatomic, readonly) BOOL isDirectChannelEstablished;
		[Export("isDirectChannelEstablished")]
		bool IsDirectChannelEstablished { get; }

		// +(instancetype _Nonnull)messaging;
		[Static]
		[Export ("messaging")]
		Messaging SharedInstance { get; }

		// @property(nonatomic, copy, nullable) NSData *APNSToken FIR_SWIFT_NAME(apnsToken);
		[NullAllowed]
		[Export("APNSToken", ArgumentSemantic.Copy)]
		NSData ApnsToken { get; set; }

		// - (void)setAPNSToken:(nonnull NSData *)apnsToken type:(FIRMessagingAPNSTokenType)type;
		[Export("setAPNSToken:type:")]
		void SetApnsToken(NSData apnsToken, ApnsTokenType type);

		// @property(nonatomic, readonly, nullable) NSString *FCMToken FIR_SWIFT_NAME(fcmToken);
		[NullAllowed]
		[Export("FCMToken")]
		string FcmToken { get; }

		// - (void)retrieveFCMTokenForSenderID:(nonnull NSString *)senderID completion:(nonnull FIRMessagingFCMTokenFetchCompletion) completion FIR_SWIFT_NAME(retrieveFCMToken(forSenderID:completion:));
		[Export("retrieveFCMTokenForSenderID:completion:")]
		void RetrieveFcmToken(string senderId, MessagingFcmTokenFetchCompletionHandler completion);

		// - (void)deleteFCMTokenForSenderID:(nonnull NSString *)senderID completion:(nonnull FIRMessagingDeleteFCMTokenCompletion) completion FIR_SWIFT_NAME(deleteFCMToken(forSenderID:completion:));
		[Export("deleteFCMTokenForSenderID:completion:")]
		void DeleteFcmToken(string senderId, MessagingDeleteFcmTokenCompletionHandler completion);

		// -(void)connectWithCompletion:(FIRMessagingConnectCompletion _Nonnull)handler;
		[Obsolete ("Use the ShouldEstablishDirectChannel property instead.")]
		[Export ("connectWithCompletion:")]
		void Connect (ConnectCompletionHandler handler);

		// -(void)disconnect;
		[Obsolete("Use the ShouldEstablishDirectChannel property instead.")]
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

