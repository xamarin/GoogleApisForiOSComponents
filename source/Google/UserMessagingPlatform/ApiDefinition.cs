using System;
using System.Collections.Generic;

using CoreGraphics;
using Foundation;
using ObjCRuntime;
using StoreKit;
using UIKit;

namespace Google.UserMessagingPlatform
{
	// typedef void (^UMPConsentFormLoadCompletionHandler)(UMPConsentForm * _Nullable, NSError * _Nullable);
    delegate void ConsentFormLoadCompletionHandler([NullAllowed] ConsentForm consentForm, [NullAllowed] NSError error);

	// typedef void (^UMPConsentFormPresentCompletionHandler)(NSError * _Nullable);
    delegate void ConsentFormPresentCompletionHandler([NullAllowed] NSError error);

	// typedef void (^UMPConsentInformationUpdateCompletionHandler)(NSError * _Nullable);
    delegate void ConsentInformationUpdateCompletionHandler([NullAllowed] NSError error);

	// @interface UMPConsentForm
	[DisableDefaultCtor]
	[BaseType(typeof(NSObject), Name = "UMPConsentForm")]    
	interface ConsentForm
	{
		// +(void)loadWithCompletionHandler:(UMPConsentFormLoadCompletionHandler _Nonnull)completionHandler;
		[Static]
		[Export ("loadWithCompletionHandler:")]
		void LoadWithCompletionHandler (ConsentFormLoadCompletionHandler completionHandler);

		// -(void)presentFromViewController:(id)viewController completionHandler:(UMPConsentFormPresentCompletionHandler _Nullable)completionHandler;
		[Export ("presentFromViewController:completionHandler:")]
		void PresentFromViewController (NSObject viewController, [NullAllowed] ConsentFormPresentCompletionHandler completionHandler);
	}

	// @interface UMPConsentInformation : NSObject
	[BaseType (typeof(NSObject), Name = "UMPConsentInformation")]
	interface ConsentInformation
	{
		// @property (readonly, nonatomic, class) UMPConsentInformation * _Nonnull sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		ConsentInformation SharedInstance { get; }

		// extern NSString *const _Nonnull UMPVersionString;
		[Field ("UMPVersionString", "__Internal")]
		NSString UMPVersionString { get; }

		// extern NSErrorDomain  _Nonnull const UMPErrorDomain;
		[Field ("UMPErrorDomain", "__Internal")]
		NSString UMPErrorDomain { get; }

		// @property (readonly, nonatomic) UMPConsentStatus consentStatus;
		[Export ("consentStatus")]
		ConsentStatus ConsentStatus { get; }

		// @property (readonly, nonatomic) UMPConsentType consentType;
		[Export ("consentType")]
		ConsentType ConsentType { get; }

		// @property (readonly, nonatomic) UMPFormStatus formStatus;
		[Export ("formStatus")]
		FormStatus FormStatus { get; }

		// -(void)requestConsentInfoUpdateWithParameters:(id)parameters completionHandler:(UMPConsentInformationUpdateCompletionHandler _Nonnull)handler;
		[Export ("requestConsentInfoUpdateWithParameters:completionHandler:")]
		void RequestConsentInfoUpdateWithParameters (NSObject parameters, ConsentInformationUpdateCompletionHandler handler);

		// -(void)reset;
		[Export ("reset")]
		void Reset ();
	}

	// @interface UMPDebugSettings : NSObject <NSCopying>
	[BaseType (typeof(NSObject), Name = "UMPDebugSettings")]
	interface DebugSettings : INSCopying
	{
		// @property (nonatomic) NSArray<NSString *> * _Nullable testDeviceIdentifiers;
		[NullAllowed, Export ("testDeviceIdentifiers", ArgumentSemantic.Assign)]
		string[] TestDeviceIdentifiers { get; set; }

		// @property (nonatomic) UMPDebugGeography geography;
		[Export ("geography", ArgumentSemantic.Assign)]
		DebugGeography Geography { get; set; }
	}

	// @interface UMPRequestParameters : NSObject
	[BaseType (typeof(NSObject), Name = "UMPRequestParameters")]
	interface RequestParameters
	{
		// @property (nonatomic) BOOL tagForUnderAgeOfConsent;
		[Export ("tagForUnderAgeOfConsent")]
		bool TagForUnderAgeOfConsent { get; set; }

		// @property (copy, nonatomic) UMPDebugSettings * _Nullable debugSettings;
		[NullAllowed, Export ("debugSettings", ArgumentSemantic.Copy)]
		DebugSettings DebugSettings { get; set; }
	}
}