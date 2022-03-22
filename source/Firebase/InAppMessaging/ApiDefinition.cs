using System;
using System.Collections.Generic;

using Foundation;
using ObjCRuntime;
using UIKit;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Firebase.InAppMessaging
{
	// @interface FIRInAppMessaging : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRInAppMessaging")]
	interface InAppMessaging
	{
		// +(FIRInAppMessaging * _Nonnull)inAppMessaging __attribute__((swift_name("inAppMessaging()")));
		[Static]
		[Export ("inAppMessaging")]
		InAppMessaging SharedInstance{ get; }

		// @property (nonatomic) BOOL messageDisplaySuppressed;
		[Export ("messageDisplaySuppressed")]
		bool MessageDisplaySuppressed { get; set; }

		// @property (nonatomic) BOOL automaticDataCollectionEnabled;
		[Export ("automaticDataCollectionEnabled")]
		bool AutomaticDataCollectionEnabled { get; set; }

		// @property (nonatomic) id<FIRInAppMessagingDisplay> _Nonnull messageDisplayComponent;
		[Export ("messageDisplayComponent", ArgumentSemantic.Assign)]
		IInAppMessagingDisplay MessageDisplayComponent { get; set; }

		// -(void)triggerEvent:(NSString * _Nonnull)eventName;
		[Export ("triggerEvent:")]
		void TriggerEvent (string eventName);

		// @property (nonatomic, weak) id<FIRInAppMessagingDisplayDelegate> _Nullable delegate;
		[NullAllowed]
		[Export("delegate", ArgumentSemantic.Weak)]
		IInAppMessagingDisplayDelegate Delegate { get; set; }
	}

	// @interface FIRInAppMessagingActionButton : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRInAppMessagingActionButton")]
	interface InAppMessagingActionButton
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull buttonText;
		[Export ("buttonText")]
		string ButtonText { get; }

		// @property (readonly, copy, nonatomic) UIColor * _Nonnull buttonTextColor;
		[Export ("buttonTextColor", ArgumentSemantic.Copy)]
		UIColor ButtonTextColor { get; }

		// @property (readonly, copy, nonatomic) UIColor * _Nonnull buttonBackgroundColor;
		[Export ("buttonBackgroundColor", ArgumentSemantic.Copy)]
		UIColor ButtonBackgroundColor { get; }
	}

	// @interface FIRInAppMessagingImageData : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRInAppMessagingImageData")]
	interface InAppMessagingImageData
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull imageURL;
		[Export ("imageURL")]
		string ImageUrl { get; }

		// @property (readonly, nonatomic) NSData * _Nullable imageRawData;
		[NullAllowed]
		[Export ("imageRawData")]
		NSData ImageRawData { get; }

		// -(instancetype _Nonnull)initWithImageURL:(NSString * _Nonnull)imageURL imageData:(NSData * _Nonnull)imageData __attribute__((deprecated("")));
		[Export ("initWithImageURL:imageData:")]
		NativeHandle Constructor (string imageUrl, NSData imageData);
	}

	// @interface FIRInAppMessagingCampaignInfo : NSObject
	[DisableDefaultCtor]
	[BaseType(typeof(NSObject), Name = "FIRInAppMessagingCampaignInfo")]
	interface InAppMessagingCampaignInfo
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull messageID;
		[Export("messageID")]
		string MessageId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull campaignName;
		[Export("campaignName")]
		string CampaignName { get; }

		// @property (readonly, nonatomic) BOOL renderAsTestMessage;
		[Export("renderAsTestMessage")]
		bool RenderAsTestMessage { get; }
	}

	// @interface FIRInAppMessagingAction : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRInAppMessagingAction")]
	interface InAppMessagingAction
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable actionText;
		[NullAllowed]
		[Export ("actionText")]
		string ActionText { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable actionURL;
		[NullAllowed]
		[Export ("actionURL", ArgumentSemantic.Copy)]
		NSUrl ActionUrl { get; }

		// -(instancetype _Nonnull)initWithActionText:(NSString * _Nullable)actionText actionURL:(NSURL * _Nullable)actionURL;
		[Export ("initWithActionText:actionURL:")]
		NativeHandle Constructor ([NullAllowed] string actionText, [NullAllowed] NSUrl actionUrl);
	}

	// @interface FIRInAppMessagingDisplayMessage : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRInAppMessagingDisplayMessage")]
	interface InAppMessagingDisplayMessage
	{
		// @property (readonly, copy, nonatomic) FIRInAppMessagingCampaignInfo * _Nonnull campaignInfo;
		[Export ("campaignInfo", ArgumentSemantic.Copy)]
		InAppMessagingCampaignInfo CampaignInfo { get; }

		// @property (readonly, nonatomic) FIRInAppMessagingDisplayMessageType type;
		[Export ("type")]
		InAppMessagingDisplayMessageType Type { get; }

		// @property (readonly, nonatomic) FIRInAppMessagingDisplayTriggerType triggerType;
		[Export ("triggerType")]
		InAppMessagingDisplayTriggerType TriggerType { get; }

		// @property (readonly, nonatomic) NSDictionary * _Nullable appData;
		[NullAllowed]
		[Export ("appData")]
		NSDictionary AppData { get; }
	}

	// @interface FIRInAppMessagingCardDisplay : FIRInAppMessagingDisplayMessage
	[DisableDefaultCtor]
	[BaseType (typeof(InAppMessagingDisplayMessage), Name = "FIRInAppMessagingCardDisplay")]
	interface InAppMessagingCardDisplay
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable body;
		[NullAllowed]
		[Export ("body")]
		string Body { get; }

		// @property (readonly, copy, nonatomic) UIColor * _Nonnull textColor;
		[Export ("textColor", ArgumentSemantic.Copy)]
		UIColor TextColor { get; }

		// @property (readonly, copy, nonatomic) FIRInAppMessagingImageData * _Nonnull portraitImageData;
		[Export ("portraitImageData", ArgumentSemantic.Copy)]
		InAppMessagingImageData PortraitImageData { get; }

		// @property (readonly, copy, nonatomic) FIRInAppMessagingImageData * _Nullable landscapeImageData;
		[NullAllowed, Export ("landscapeImageData", ArgumentSemantic.Copy)]
		InAppMessagingImageData LandscapeImageData { get; }

		// @property (readonly, copy, nonatomic) UIColor * _Nonnull displayBackgroundColor;
		[Export ("displayBackgroundColor", ArgumentSemantic.Copy)]
		UIColor DisplayBackgroundColor { get; }

		// @property (readonly, nonatomic) FIRInAppMessagingActionButton * _Nonnull primaryActionButton;
		[Export ("primaryActionButton")]
		InAppMessagingActionButton PrimaryActionButton { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable primaryActionURL;
		[NullAllowed]
		[Export ("primaryActionURL")]
		NSUrl PrimaryActionUrl { get; }

		// @property (readonly, nonatomic) FIRInAppMessagingActionButton * _Nullable secondaryActionButton;
		[NullAllowed]
		[Export ("secondaryActionButton")]
		InAppMessagingActionButton SecondaryActionButton { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable secondaryActionURL;
		[NullAllowed]
		[Export ("secondaryActionURL")]
		NSUrl SecondaryActionUrl { get; }
	}

	// @interface FIRInAppMessagingModalDisplay : FIRInAppMessagingDisplayMessage
	[DisableDefaultCtor]
	[BaseType (typeof(InAppMessagingDisplayMessage), Name = "FIRInAppMessagingModalDisplay")]
	interface InAppMessagingModalDisplay
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly, copy, nonatomic) FIRInAppMessagingImageData * _Nullable imageData;
		[NullAllowed]
		[Export ("imageData", ArgumentSemantic.Copy)]
		InAppMessagingImageData ImageData { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable bodyText;
		[NullAllowed]
		[Export ("bodyText")]
		string BodyText { get; }

		// @property (readonly, nonatomic) FIRInAppMessagingActionButton * _Nullable actionButton;
		[NullAllowed]
		[Export ("actionButton")]
		InAppMessagingActionButton ActionButton { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable actionURL;
		[NullAllowed]
		[Export ("actionURL")]
		NSUrl ActionUrl { get; }

		// @property(nonatomic, copy, nonnull, readonly) UIColor *displayBackgroundColor;
		[Export ("displayBackgroundColor", ArgumentSemantic.Copy)]
		UIColor DisplayBackgroundColor { get; }

		// @property(nonatomic, copy, nonnull, readonly) UIColor *textColor;
		[Export ("textColor", ArgumentSemantic.Copy)]
		UIColor TextColor { get; }
	}

	// @interface FIRInAppMessagingBannerDisplay : FIRInAppMessagingDisplayMessage
	[DisableDefaultCtor]
	[BaseType (typeof(InAppMessagingDisplayMessage), Name = "FIRInAppMessagingBannerDisplay")]
	interface InAppMessagingBannerDisplay
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly, copy, nonatomic) FIRInAppMessagingImageData * _Nullable imageData;
		[NullAllowed]
		[Export ("imageData", ArgumentSemantic.Copy)]
		InAppMessagingImageData ImageData { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable bodyText;
		[NullAllowed]
		[Export ("bodyText")]
		string BodyText { get; }

		// @property (readonly, copy, nonatomic) UIColor * _Nonnull displayBackgroundColor;
		[Export ("displayBackgroundColor", ArgumentSemantic.Copy)]
		UIColor DisplayBackgroundColor { get; }

		// @property (nonatomic, copy, nonnull, readonly) UIColor * _Nonnull textColor;
		[Export ("textColor", ArgumentSemantic.Copy)]
		UIColor TextColor { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable actionURL;
		[NullAllowed]
		[Export ("actionURL")]
		NSUrl ActionUrl { get; }
	}

	// @interface FIRInAppMessagingImageOnlyDisplay : FIRInAppMessagingDisplayMessage
	[DisableDefaultCtor]
	[BaseType (typeof(InAppMessagingDisplayMessage), Name = "FIRInAppMessagingImageOnlyDisplay")]
	interface InAppMessagingImageOnlyDisplay
	{
		// @property (readonly, copy, nonatomic) FIRInAppMessagingImageData * _Nonnull imageData;
		[Export ("imageData", ArgumentSemantic.Copy)]
		InAppMessagingImageData ImageData { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable actionURL;
		[NullAllowed]
		[Export ("actionURL")]
		NSUrl ActionUrl { get; }
	}

	interface IInAppMessagingDisplayDelegate { }

	// @protocol FIRInAppMessagingDisplayDelegate <NSObject>
#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof(NSObject), Name = "FIRInAppMessagingDisplayDelegate")]
	interface InAppMessagingDisplayDelegate
	{
		// @optional -(void)messageDismissed:(FIRInAppMessagingDisplayMessage * _Nonnull)inAppMessage dismissType:(FIRInAppMessagingDismissType)dismissType;
		[Export ("messageDismissed:dismissType:")]
		void MessageDismissed (InAppMessagingDisplayMessage inAppMessage, InAppMessagingDismissType dismissType);

		// @optional -(void)messageClicked:(FIRInAppMessagingDisplayMessage * _Nonnull)inAppMessage withAction:(FIRInAppMessagingAction * _Nonnull)action;
		[Export ("messageClicked:withAction:")]
		void MessageClicked (InAppMessagingDisplayMessage inAppMessage, InAppMessagingAction action);

		// @optional -(void)impressionDetectedForMessage:(FIRInAppMessagingDisplayMessage * _Nonnull)inAppMessage;
		[Export ("impressionDetectedForMessage:")]
		void ImpressionDetected (InAppMessagingDisplayMessage inAppMessage);

		// @optional -(void)displayErrorForMessage:(FIRInAppMessagingDisplayMessage * _Nonnull)inAppMessage error:(NSError * _Nonnull)error;
		[Export ("displayErrorForMessage:error:")]
		void DisplayError (InAppMessagingDisplayMessage inAppMessage, NSError error);
	}

	interface IInAppMessagingDisplay { }

	[Protocol (Name = "FIRInAppMessagingDisplay")]
	interface InAppMessagingDisplay
	{
		// @required -(void)displayMessage:(FIRInAppMessagingDisplayMessage * _Nonnull)messageForDisplay displayDelegate:(id<FIRInAppMessagingDisplayDelegate> _Nonnull)displayDelegate;
		[Abstract]
		[Export ("displayMessage:displayDelegate:")]
		void DisplayMessage(InAppMessagingDisplayMessage messageForDisplay, IInAppMessagingDisplayDelegate displayDelegate);
	}
}
