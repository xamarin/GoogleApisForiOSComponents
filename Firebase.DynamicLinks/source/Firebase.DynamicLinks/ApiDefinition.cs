using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.DynamicLinks
{
	// @interface FIRDynamicLink : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRDynamicLink")]
	interface DynamicLink
	{
		// @property (readonly, copy, nonatomic) NSURL * _Nullable url;
		[NullAllowed]
		[Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		// @property (readonly, assign, nonatomic) FIRDynamicLinkMatchConfidence matchConfidence;
		[Export ("matchConfidence", ArgumentSemantic.Assign)]
		DynamicLinkMatchConfidence MatchConfidence { get; }
	}

	// typedef void (^FIRDynamicLinkResolverHandler)(NSURL * _Nullable url, NSError * _Nullable error);
	delegate void DynamicLinkResolverHandler ([NullAllowed] NSUrl url, [NullAllowed] NSError error);

	// typedef void (^FIRDynamicLinkUniversalLinkHandler)(FIRDynamicLink * _Nullable dynamicLink, NSError* _Nullable error);
	delegate void DynamicLinkUniversalLinkHandler ([NullAllowed] DynamicLink dynamicLink, [NullAllowed] NSError error);

	// @interface FIRDynamicLinks : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRDynamicLinks")]
	interface DynamicLinks
	{
		// +(instancetype _Nullable)dynamicLinks;
		[Static]
		[NullAllowed]
		[Export ("dynamicLinks")]
		DynamicLinks SharedInstance { get; }

		// -(BOOL)shouldHandleDynamicLinkFromCustomSchemeURL:(NSURL * _Nonnull)url;
		[Export ("shouldHandleDynamicLinkFromCustomSchemeURL:")]
		bool ShouldHandleDynamicLinkFromCustomSchemeUrl (NSUrl url);

		// -(FIRDynamicLink * _Nullable)dynamicLinkFromCustomSchemeURL:(NSURL * _Nonnull)url;
		[return: NullAllowed]
		[Export ("dynamicLinkFromCustomSchemeURL:")]
		DynamicLink FromCustomSchemeUrl (NSUrl url);

		// -(FIRDynamicLink * _Nullable)dynamicLinkFromUniversalLinkURL:(NSURL * _Nonnull)url;
		[return: NullAllowed]
		[Export ("dynamicLinkFromUniversalLinkURL:")]
		DynamicLink FromUniversalLinkUrl (NSUrl url);

		// -(BOOL)handleUniversalLink:(NSURL * _Nonnull)url completion:(FIRDynamicLinkUniversalLinkHandler _Nonnull)completion;
		[Export ("handleUniversalLink:completion:")]
		bool HandleUniversalLink (NSUrl url, DynamicLinkUniversalLinkHandler completion);

		// -(void)resolveShortLink:(NSURL * _Nonnull)url completion:(FIRDynamicLinkResolverHandler _Nonnull)completion;
		[Export ("resolveShortLink:completion:")]
		void ResolveShortLink (NSUrl url, DynamicLinkResolverHandler completion);

		// -(BOOL)matchesShortLinkFormat:(NSURL * _Nonnull)url;
		[Export ("matchesShortLinkFormat:")]
		bool MatchesShortLinkFormat (NSUrl url);
	}
}

