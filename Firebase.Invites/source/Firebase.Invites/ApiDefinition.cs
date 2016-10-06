﻿using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.Invites
{
	// @interface FIRReceivedInvite : NSObject
	[BaseType (typeof (NSObject), Name = "FIRReceivedInvite")]
	interface ReceivedInvite
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull inviteId;
		[Export ("inviteId")]
		string InviteId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull deepLink;
		[Export ("deepLink")]
		string DeepLink { get; }

		// @property (readonly, assign, nonatomic) FIRReceivedInviteMatchType matchType;
		[Export ("matchType", ArgumentSemantic.Assign)]
		ReceivedInviteMatchType MatchType { get; }
	}

	interface IInviteDelegate
	{
	}

	// @protocol FIRInviteDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FIRInviteDelegate")]
	interface InviteDelegate
	{
		// @optional -(void)inviteFinishedWithInvitations:(NSArray * _Nonnull)invitationIds error:(NSError * _Nullable)error;
		[Export ("inviteFinishedWithInvitations:error:")]
		void InviteFinished (string [] invitationIds, [NullAllowed] NSError error);
	}

	interface IInviteBuilder
	{
	}

	// @protocol FIRInviteBuilder <NSObject>
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FIRInviteBuilder")]
	interface InviteBuilder
	{
		// @required -(void)setInviteDelegate:(id<FIRInviteDelegate> _Nonnull)inviteDelegate;
		[Abstract]
		[Export ("setInviteDelegate:")]
		void SetInviteDelegate (IInviteDelegate inviteDelegate);

		// @required -(void)setTitle:(NSString * _Nonnull)title;
		[Abstract]
		[Export ("setTitle:")]
		void SetTitle (string title);

		// @required -(void)setMessage:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("setMessage:")]
		void SetMessage (string message);

		// @required -(void)setDeepLink:(NSString * _Nonnull)deepLink;
		[Abstract]
		[Export ("setDeepLink:")]
		void SetDeepLink (string deepLink);

		// @required -(void)setOtherPlatformsTargetApplication:(FIRInvitesTargetApplication * _Nonnull)targetApplication;
		[Abstract]
		[Export ("setOtherPlatformsTargetApplication:")]
		void SetOtherPlatformsTargetApplication (InvitesTargetApplication targetApplication);

		// @required -(void)setDescription:(NSString * _Nonnull)description;
		[Abstract]
		[Export ("setDescription:")]
		void SetDescription (string description);

		// @required -(void)setCustomImage:(NSString * _Nonnull)imageURI;
		[Abstract]
		[Export ("setCustomImage:")]
		void SetCustomImage (string imageUri);

		// @required -(void)setCallToActionText:(NSString * _Nonnull)callToActionText;
		[Abstract]
		[Export ("setCallToActionText:")]
		void SetCallToActionText (string callToActionText);

		// @required -(void)setAndroidMinimumVersionCode:(NSInteger)versionCode;
		[Abstract]
		[Export ("setAndroidMinimumVersionCode:")]
		void SetAndroidMinimumVersionCode (nint versionCode);

		// @required -(void)open;
		[Abstract]
		[Export ("open")]
		void Open ();
	}

	// @interface FIRInvites : NSObject
	[BaseType (typeof (NSObject), Name = "FIRInvites")]
	interface Invites
	{
		// extern NSString *const kFIRInvitesErrorDomain;
		[Field ("kFIRInvitesErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// @property (nonatomic) FIRInvitesTargetApplication * _Nonnull targetApp;
		[Export ("targetApp", ArgumentSemantic.Assign)]
		InvitesTargetApplication TargetApp { get; set; }

		// +(void)applicationDidFinishLaunchingWithOptions:(NSDictionary * _Nullable)launchOptions;
		[Static]
		[Export ("applicationDidFinishLaunchingWithOptions:")]
		void ApplicationDidFinishLaunching ([NullAllowed] NSDictionary launchOptions);

		// +(void)applicationDidFinishLaunching __attribute__((deprecated("Call |applicationDidFinishLaunchingWithOptions:| instead.")));
		[Obsolete ("Call ApplicationDidFinishLaunching (NSDictionary) method instead.")]
		[Static]
		[Export ("applicationDidFinishLaunching")]
		void ApplicationDidFinishLaunching ();

		// +(id _Nullable)handleURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation;
		[Static]
		[return: NullAllowed]
		[Export ("handleURL:sourceApplication:annotation:")]
		ReceivedInvite HandleUrl (NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

		// +(void)completeInvitation __attribute__((deprecated("No longer need to call.")));
		[Obsolete ("No longer need to call.")]
		[Static]
		[Export ("completeInvitation")]
		void CompleteInvitation ();

		// +(void)convertInvitation:(NSString * _Nonnull)invitationId;
		[Static]
		[Export ("convertInvitation:")]
		void ConvertInvitation (string invitationId);

		// +(id<FIRInviteBuilder> _Nullable)inviteDialog;
		[Static]
		[NullAllowed, Export ("inviteDialog")]
		IInviteBuilder GetInviteDialog ();

		// +(void)closeActiveInviteDialog;
		[Static]
		[Export ("closeActiveInviteDialog")]
		void CloseActiveInviteDialog ();

		// +(void)setAPIKey:(NSString * _Nonnull)apiKey;
		[Static]
		[Export ("setAPIKey:")]
		void SetAPIKey (string apiKey);

		// +(void)setGoogleAnalyticsTrackingId:(NSString * _Nonnull)trackingId;
		[Static]
		[Export ("setGoogleAnalyticsTrackingId:")]
		void SetGoogleAnalyticsTrackingId (string trackingId);

		// +(void)setDefaultOtherPlatformsTargetApplication:(FIRInvitesTargetApplication * _Nonnull)targetApplication;
		[Static]
		[Export ("setDefaultOtherPlatformsTargetApplication:")]
		void SetDefaultOtherPlatformsTargetApplication (InvitesTargetApplication targetApplication);
	}

	// @interface FIRInvitesTargetApplication : NSObject
	[BaseType (typeof (NSObject), Name = "FIRInvitesTargetApplication")]
	interface InvitesTargetApplication
	{
		// @property (copy, nonatomic) NSString * androidClientID;
		[Export ("androidClientID")]
		string AndroidClientId { get; set; }
	}
}
