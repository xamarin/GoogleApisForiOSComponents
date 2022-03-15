using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Google.AppInvite
{
	// @interface AppInvite (GGLContext)
	[Category]
	[BaseType (typeof(Google.Core.Context))]
	interface GGLContext_AppInvite
	{
		// @property (readonly, nonatomic, strong) GINInviteTargetApplication * targetApp;
		[Export ("targetApp", ArgumentSemantic.Strong)]
//		InviteTargetApplication TargetApp { get; }
		NSObject GetTargetApp ();
	}

// 	I do not see wherer this is needed at this time.
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const kGINInviteErrorDomain;
//		[Field ("kGINInviteErrorDomain")]
//		NSString kGINInviteErrorDomain { get; }
//	}

	interface IInviteDelegate {}

	// @protocol GINInviteDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name="GINInviteDelegate")]
	interface InviteDelegate
	{
		// @optional -(void)inviteFinishedWithInvitations:(NSArray *)invitationIds error:(NSError *)error;
		[Export ("inviteFinishedWithInvitations:error:")]
		void InviteFinished (string[] invitationIds, NSError error);
	}

	interface IInviteBuilder {}

	// @protocol GINInviteBuilder <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name="GINInviteBuilder")]
	interface InviteBuilder
	{
		// @required -(void)setInviteDelegate:(id<GINInviteDelegate>)inviteDelegate;
		[Abstract]
		[Export ("setInviteDelegate:")]
		void SetInviteDelegate (IInviteDelegate inviteDelegate);

		// @required -(void)setTitle:(NSString *)title;
		[Abstract]
		[Export ("setTitle:")]
		void SetTitle (string title);

		// @required -(void)setMessage:(NSString *)message;
		[Abstract]
		[Export ("setMessage:")]
		void SetMessage (string message);

		// @required -(void)setDeepLink:(NSString *)deepLink;
		[Abstract]
		[Export ("setDeepLink:")]
		void SetDeepLink (string deepLink);

		// @required -(void)setOtherPlatformsTargetApplication:(GINInviteTargetApplication *)targetApplication;
		[Abstract]
		[Export ("setOtherPlatformsTargetApplication:")]
		void SetOtherPlatformsTargetApplication (InviteTargetApplication targetApplication);

		// @required -(void)open;
		[Abstract]
		[Export ("open")]
		void Open ();
	}

	// @interface GINReceivedInvite : NSObject
	[BaseType (typeof(NSObject), Name="GINReceivedInvite")]
	interface ReceivedInvite
	{
		// @property (copy, nonatomic) NSString * inviteId;
		[Export ("inviteId")]
		string InviteId { get; set; }

		// @property (copy, nonatomic) NSString * deepLink;
		[Export ("deepLink")]
		string DeepLink { get; set; }

		// @property (assign, nonatomic) GINReceivedInviteMatchType matchType;
		[Export ("matchType", ArgumentSemantic.Assign)]
		ReceivedInviteMatchType MatchType { get; set; }
	}

	// @interface GINInvite : NSObject
	[BaseType (typeof(NSObject), Name="GINInvite")]
	interface Invite
	{
		// +(void)applicationDidFinishLaunching;
		[Static]
		[Export ("applicationDidFinishLaunching")]
		void ApplicationDidFinishLaunching ();

		// +(GINReceivedInvite *)handleURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;
		[Static]
		[Export ("handleURL:sourceApplication:annotation:")]
		ReceivedInvite HandleUrl (NSUrl url, string sourceApplication, [NullAllowed] NSObject annotation);

		// +(void)completeInvitation;
		[Static]
		[Export ("completeInvitation")]
		void CompleteInvitation ();

		// +(void)convertInvitation:(NSString *)invitationId;
		[Static]
		[Export ("convertInvitation:")]
		void ConvertInvitation (string invitationId);

		// +(id<GINInviteBuilder>)inviteDialog;
		[Static]
		[Export ("inviteDialog")]
		IInviteBuilder InviteDialog { get; }

		// +(void)closeActiveInviteDialog;
		[Static]
		[Export ("closeActiveInviteDialog")]
		void CloseActiveInviteDialog ();

		// +(void)setAPIKey:(NSString *)apiKey;
		[Static]
		[Export ("setAPIKey:")]
		void SetAPIKey (string apiKey);

		// +(void)setGoogleAnalyticsTrackingId:(NSString *)trackingId;
		[Static]
		[Export ("setGoogleAnalyticsTrackingId:")]
		void SetGoogleAnalyticsTrackingId (string trackingId);

		// +(void)setDefaultOtherPlatformsTargetApplication:(GINInviteTargetApplication *)targetApplication;
		[Static]
		[Export ("setDefaultOtherPlatformsTargetApplication:")]
		void SetDefaultOtherPlatformsTargetApplication (InviteTargetApplication targetApplication);
	}

	// @interface GINInviteTargetApplication : NSObject
	[BaseType (typeof(NSObject), Name="GINInviteTargetApplication")]
	interface InviteTargetApplication
	{
		// @property (copy, nonatomic) NSString * androidClientID;
		[Export ("androidClientID")]
		string AndroidClientID { get; set; }
	}


}

