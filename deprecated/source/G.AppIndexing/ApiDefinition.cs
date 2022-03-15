using Foundation;
using ObjCRuntime;
using System;

namespace Google.AppIndexing
{
	//    @interface GSDDeepLink : NSObject
	//
	//    /**
	// * @method handleDeepLink:
	// * @abstract Handles a deep link and displays a back bar if the URL is valid.
	// * @param deeplinkURL The deeplink URL.
	// * @return The sanitized URL (with GSD specific query params removed).
	// */
	//    + (NSURL *)handleDeepLink:(NSURL *)deeplinkURL;
	//
	//    /**
	// * @method isDeepLinkFromGoogleSearch:
	// * @abstract Whether the deeplink URL has come from Google Search.
	// * @param deeplinkURL The deeplink URL. This should NOT be the sanitized URL returned from
	// *     handleDeepLink:
	// * @return A BOOL indicating whether the deeplink URL is coming from Google Search.
	// */
	//    + (BOOL)isDeepLinkFromGoogleSearch:(NSURL *)deepLinkURL;
	//
	//    /**
	// * @method isDeepLinkFromGoogleAppCrawler:
	// * @abstract Whether the deeplink URL has come from Google App Crawler.
	// * @param deeplinkURL The deeplink URL. This should NOT be the sanitized URL returned from
	// *     handleDeepLink:
	// * @return A BOOL indicating whether the deeplink URL is coming from Google App Crawler.
	// */
	//    + (BOOL)isDeepLinkFromGoogleAppCrawler:(NSURL *)deepLinkURL;
	//

	[BaseType (typeof(NSObject), Name = "GSDDeepLink")]
	interface DeepLink
	{
		// + (NSURL *)handleDeepLink:(NSURL *)deeplinkURL;
		[Static]
		[Export ("handleDeepLink:")]
		NSUrl HandleDeepLink (NSUrl deepLinkUrl);

		// + (BOOL)isDeepLinkFromGoogleSearch:(NSURL *)deepLinkURL;
		[Static]
		[Export ("isDeepLinkFromGoogleSearch:")]
		bool IsDeepLinkFromGoogleSearch (NSUrl deepLinkUrl);

		// + (BOOL)isDeepLinkFromGoogleAppCrawler:(NSURL *)deepLinkURL;
		[Static]
		[Export ("isDeepLinkFromGoogleAppCrawler:")]
		bool IsDeepLinkFromGoogleAppCrawler (NSUrl deepLinkUrl);
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GSDAppIndexing")]
	interface AppIndexing
	{
		// + (instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		AppIndexing SharedInstance { get; }

		// - (void)registerApp:(NSUInteger)iTunesID;
		[Export ("registerApp:")]
		void RegisterApp (nuint iTunesId);
	}
}