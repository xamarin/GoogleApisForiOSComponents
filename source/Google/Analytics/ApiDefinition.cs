using System;
using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Google.Analytics
{
	[Static]
	interface GaiConstants
	{
		[Field ("kGAIUseSecure", "__Internal")]
		NSString UseSecure { get; }

		[Field ("kGAIHitType", "__Internal")]
		NSString HitType { get; }

		[Field ("kGAITrackingId", "__Internal")]
		NSString TrackingId { get; }

		[Field ("kGAIClientId", "__Internal")]
		NSString ClientId { get; }

		[Field ("kGAIDataSource", "__Internal")]
		NSString DataSource { get; }

		[Field ("kGAIAnonymizeIp", "__Internal")]
		NSString AnonymizeIp { get; }

		[Field ("kGAISessionControl", "__Internal")]
		NSString SessionControl { get; }

		[Field ("kGAIDeviceModelVersion", "__Internal")]
		NSString DeviceModelVersion { get; }

		[Field ("kGAIScreenResolution", "__Internal")]
		NSString ScreenResolution { get; }

		[Field ("kGAIViewportSize", "__Internal")]
		NSString ViewportSize { get; }

		[Field ("kGAIEncoding", "__Internal")]
		NSString Encoding { get; }

		[Field ("kGAIScreenColors", "__Internal")]
		NSString ScreenColors { get; }

		[Field ("kGAILanguage", "__Internal")]
		NSString Language { get; }

		[Field ("kGAIJavaEnabled", "__Internal")]
		NSString JavaEnabled { get; }

		[Field ("kGAIFlashVersion", "__Internal")]
		NSString FlashVersion { get; }

		[Field ("kGAINonInteraction", "__Internal")]
		NSString NonInteraction { get; }

		[Field ("kGAIReferrer", "__Internal")]
		NSString Referrer { get; }

		[Field ("kGAILocation", "__Internal")]
		NSString Location { get; }

		[Field ("kGAIHostname", "__Internal")]
		NSString Hostname { get; }

		[Field ("kGAIPage", "__Internal")]
		NSString Page { get; }

		[Field ("kGAIDescription", "__Internal")]
		NSString Description { get; }

		[Field ("kGAIScreenName", "__Internal")]
		NSString ScreenName { get; }

		[Field ("kGAITitle", "__Internal")]
		NSString Title { get; }

		[Field ("kGAIAdMobHitId", "__Internal")]
		NSString AdMobHitId { get; }

		[Field ("kGAIAppName", "__Internal")]
		NSString AppName { get; }

		[Field ("kGAIAppVersion", "__Internal")]
		NSString AppVersion { get; }

		[Field ("kGAIAppId", "__Internal")]
		NSString AppId { get; }

		[Field ("kGAIAppInstallerId", "__Internal")]
		NSString AppInstallerId { get; }

		[Field ("kGAIUserId", "__Internal")]
		NSString UserId { get; }

		[Field ("kGAIEventCategory", "__Internal")]
		NSString EventCategory { get; }

		[Field ("kGAIEventAction", "__Internal")]
		NSString EventAction { get; }

		[Field ("kGAIEventLabel", "__Internal")]
		NSString EventLabel { get; }

		[Field ("kGAIEventValue", "__Internal")]
		NSString EventValue { get; }

		[Field ("kGAISocialNetwork", "__Internal")]
		NSString SocialNetwork { get; }

		[Field ("kGAISocialAction", "__Internal")]
		NSString SocialAction { get; }

		[Field ("kGAISocialTarget", "__Internal")]
		NSString SocialTarget { get; }

		[Field ("kGAITransactionId", "__Internal")]
		NSString TransactionId { get; }

		[Field ("kGAITransactionAffiliation", "__Internal")]
		NSString TransactionAffiliation { get; }

		[Field ("kGAITransactionRevenue", "__Internal")]
		NSString TransactionRevenue { get; }

		[Field ("kGAITransactionShipping", "__Internal")]
		NSString TransactionShipping { get; }

		[Field ("kGAITransactionTax", "__Internal")]
		NSString TransactionTax { get; }

		[Field ("kGAICurrencyCode", "__Internal")]
		NSString CurrencyCode { get; }

		[Field ("kGAIItemPrice", "__Internal")]
		NSString ItemPrice { get; }

		[Field ("kGAIItemQuantity", "__Internal")]
		NSString ItemQuantity { get; }

		[Field ("kGAIItemSku", "__Internal")]
		NSString ItemSku { get; }

		[Field ("kGAIItemName", "__Internal")]
		NSString ItemName { get; }

		[Field ("kGAIItemCategory", "__Internal")]
		NSString ItemCategory { get; }

		[Field ("kGAICampaignSource", "__Internal")]
		NSString CampaignSource { get; }

		[Field ("kGAICampaignMedium", "__Internal")]
		NSString CampaignMedium { get; }

		[Field ("kGAICampaignName", "__Internal")]
		NSString CampaignName { get; }

		[Field ("kGAICampaignKeyword", "__Internal")]
		NSString CampaignKeyword { get; }

		[Field ("kGAICampaignContent", "__Internal")]
		NSString CampaignContent { get; }

		[Field ("kGAICampaignId", "__Internal")]
		NSString CampaignId { get; }

		[Field ("kGAICampaignAdNetworkClickId", "__Internal")]
		NSString CampaignAdNetworkClickId { get; }

		[Field ("kGAICampaignAdNetworkId", "__Internal")]
		NSString CampaignAdNetworkId { get; }

		[Field ("kGAITimingCategory", "__Internal")]
		NSString TimingCategory { get; }

		[Field ("kGAITimingVar", "__Internal")]
		NSString TimingVar { get; }

		[Field ("kGAITimingValue", "__Internal")]
		NSString TimingValue { get; }

		[Field ("kGAITimingLabel", "__Internal")]
		NSString TimingLabel { get; }

		[Field ("kGAIExDescription", "__Internal")]
		NSString ExDescription { get; }

		[Field ("kGAIExFatal", "__Internal")]
		NSString ExFatal { get; }

		[Field ("kGAISampleRate", "__Internal")]
		NSString SampleRate { get; }

		[Field ("kGAIIdfa", "__Internal")]
		NSString Idfa { get; }

		[Field ("kGAIAdTargetingEnabled", "__Internal")]
		NSString AdTargetingEnabled { get; }

		[Obsolete ("Use ScreenView property instead")]
		[Field ("kGAIAppView", "__Internal")]
		NSString AppView { get; }

		[Field ("kGAIScreenView", "__Internal")]
		NSString ScreenView { get; }

		[Field ("kGAIEvent", "__Internal")]
		NSString Event { get; }

		[Field ("kGAISocial", "__Internal")]
		NSString Social { get; }

		[Field ("kGAITransaction", "__Internal")]
		NSString Transaction { get; }

		[Field ("kGAIItem", "__Internal")]
		NSString Item { get; }

		[Field ("kGAIException", "__Internal")]
		NSString Exception { get; }

		[Field ("kGAITiming", "__Internal")]
		NSString Timing { get; }

		[Field ("kGAIProduct", "__Internal")]
		NSString Product { get; }

		[Field ("kGAIVersion", "__Internal")]
		NSString Version { get; }

		[Field ("kGAIErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }
	}

	[Static]
	interface EcommerceConstants
	{

		[Field ("kGAIProductId", "__Internal")]
		NSString ProductId { get; }

		[Field ("kGAIProductName", "__Internal")]
		NSString ProductName { get; }

		[Field ("kGAIProductBrand", "__Internal")]
		NSString ProductBrand { get; }

		[Field ("kGAIProductCategory", "__Internal")]
		NSString ProductCategory { get; }

		[Field ("kGAIProductVariant", "__Internal")]
		NSString ProductVariant { get; }

		[Field ("kGAIProductPrice", "__Internal")]
		NSString ProductPrice { get; }

		[Field ("kGAIProductQuantity", "__Internal")]
		NSString ProductQuantity { get; }

		[Field ("kGAIProductCouponCode", "__Internal")]
		NSString ProductCouponCode { get; }

		[Field ("kGAIProductPosition", "__Internal")]
		NSString ProductPosition { get; }

		[Field ("kGAIProductAction", "__Internal")]
		NSString ProductAction { get; }

		[Field ("kGAIPADetail", "__Internal")]
		NSString PADetail { get; }

		[Field ("kGAIPAClick", "__Internal")]
		NSString PAClick { get; }

		[Field ("kGAIPAAdd", "__Internal")]
		NSString PAAdd { get; }

		[Field ("kGAIPARemove", "__Internal")]
		NSString PARemove { get; }

		[Field ("kGAIPACheckout", "__Internal")]
		NSString PACheckout { get; }

		[Field ("kGAIPACheckoutOption", "__Internal")]
		NSString PACheckoutOption { get; }

		[Field ("kGAIPAPurchase", "__Internal")]
		NSString PAPurchase { get; }

		[Field ("kGAIPARefund", "__Internal")]
		NSString PARefund { get; }

		[Field ("kGAIPATransactionId", "__Internal")]
		NSString PATransactionId { get; }

		[Field ("kGAIPAAffiliation", "__Internal")]
		NSString PAAffiliation { get; }

		[Field ("kGAIPARevenue", "__Internal")]
		NSString PARevenue { get; }

		[Field ("kGAIPATax", "__Internal")]
		NSString PATax { get; }

		[Field ("kGAIPAShipping", "__Internal")]
		NSString PAShipping { get; }

		[Field ("kGAIPACouponCode", "__Internal")]
		NSString PACouponCode { get; }

		[Field ("kGAICheckoutStep", "__Internal")]
		NSString CheckoutStep { get; }

		[Field ("kGAICheckoutOption", "__Internal")]
		NSString CheckoutOption { get; }

		[Field ("kGAIProductActionList", "__Internal")]
		NSString ProductActionList { get; }

		[Field ("kGAIProductListSource", "__Internal")]
		NSString ProductListSource { get; }

		[Field ("kGAIImpressionName", "__Internal")]
		NSString ImpressionName { get; }

		[Field ("kGAIImpressionListSource", "__Internal")]
		NSString ImpressionListSource { get; }

		[Field ("kGAIImpressionProduct", "__Internal")]
		NSString ImpressionProduct { get; }

		[Field ("kGAIImpressionProductId", "__Internal")]
		NSString ImpressionProductId { get; }

		[Field ("kGAIImpressionProductName", "__Internal")]
		NSString ImpressionProductName { get; }

		[Field ("kGAIImpressionProductBrand", "__Internal")]
		NSString ImpressionProductBrand { get; }

		[Field ("kGAIImpressionProductCategory", "__Internal")]
		NSString ImpressionProductCategory { get; }

		[Field ("kGAIImpressionProductVariant", "__Internal")]
		NSString ImpressionProductVariant { get; }

		[Field ("kGAIImpressionProductPosition", "__Internal")]
		NSString ImpressionProductPosition { get; }

		[Field ("kGAIImpressionProductPrice", "__Internal")]
		NSString ImpressionProductPrice { get; }

		[Field ("kGAIPromotionId", "__Internal")]
		NSString PromotionId { get; }

		[Field ("kGAIPromotionName", "__Internal")]
		NSString PromotionName { get; }

		[Field ("kGAIPromotionCreative", "__Internal")]
		NSString PromotionCreative { get; }

		[Field ("kGAIPromotionPosition", "__Internal")]
		NSString PromotionPosition { get; }

		[Field ("kGAIPromotionAction", "__Internal")]
		NSString PromotionAction { get; }

		[Field ("kGAIPromotionView", "__Internal")]
		NSString PromotionView { get; }

		[Field ("kGAIPromotionClick", "__Internal")]
		NSString PromotionClick { get; }
	}

	delegate void GaiCompletionHandler (DispatchResult result);

	[BaseType (typeof(NSObject), Name = "GAI")]
	interface Gai
	{

		[Export ("defaultTracker", ArgumentSemantic.Assign)] [NullAllowed]
		ITracker DefaultTracker { get; set; }

		[Export ("logger", ArgumentSemantic.Retain)] [NullAllowed]
		ILogger Logger { get; set; }

		[Export ("optOut", ArgumentSemantic.Assign)]
		bool OptOut { get; set; }

		[Export ("dispatchInterval", ArgumentSemantic.Assign)]
		double DispatchInterval { get; set; }

		[Export ("trackUncaughtExceptions", ArgumentSemantic.Assign)]
		bool TrackUncaughtExceptions { get; set; }

		[Export ("dryRun", ArgumentSemantic.Assign)]
		bool DryRun { get; set; }

		[Static]
		[Export ("sharedInstance")]
		Gai SharedInstance { get; }

		[Export ("trackerWithName:trackingId:")]
		ITracker GetTracker (string name, string trackingId);

		[Export ("trackerWithTrackingId:")]
		ITracker GetTracker (string trackingId);

		[Export ("removeTrackerByName:")]
		void RemoveTracker (string name);

		[Export ("dispatch")]
		void Dispatch ();

		[Export ("dispatchWithCompletionHandler:")]
		void Dispatch (GaiCompletionHandler completionHandler);
	}

	[BaseType (typeof(NSObject), Name = "GAIDictionaryBuilder")]
	interface DictionaryBuilder
	{

		[Export ("set:forKey:")]
		DictionaryBuilder Set ([NullAllowed] string value, [NullAllowed] string key);

		[Export ("setAll:")]
		DictionaryBuilder SetAll ([NullAllowed] NSDictionary parameters);

		[Export ("get:")]
		string Get ([NullAllowed] string paramName);

		[Export ("build")]
		NSMutableDictionary Build ();

		[Export ("setCampaignParametersFromUrl:")]
		DictionaryBuilder SetCampaignParameters (string urlString);

		[Obsolete ("Use CreateScreenView instead.")]
		[Static]
		[Export ("createAppView")]
		DictionaryBuilder CreateAppView ();

		[Static]
		[Export ("createScreenView")]
		DictionaryBuilder CreateScreenView ();

		[Static]
		[Export ("createEventWithCategory:action:label:value:")]
		DictionaryBuilder CreateEvent ([NullAllowed] string category, [NullAllowed] string action, [NullAllowed] string label, [NullAllowed] NSNumber number);

		[Static]
		[Export ("createExceptionWithDescription:withFatal:")]
		DictionaryBuilder CreateException ([NullAllowed] string description, [NullAllowed] NSNumber fatal);

		[Static]
		[Export ("createItemWithTransactionId:name:sku:category:price:quantity:currencyCode:")]
		DictionaryBuilder CreateItem ([NullAllowed] string transactionId, [NullAllowed] string name, [NullAllowed] string sku, [NullAllowed] string category, [NullAllowed] NSNumber price, [NullAllowed] NSNumber quantity, [NullAllowed] string currencyCode);

		[Static]
		[Export ("createSocialWithNetwork:action:target:")]
		DictionaryBuilder CreateSocial ([NullAllowed] string network, [NullAllowed] string action, [NullAllowed] string target);

		[Static]
		[Export ("createTimingWithCategory:interval:name:label:")]
		DictionaryBuilder CreateTiming ([NullAllowed] string category, [NullAllowed] NSNumber intervalMillis, [NullAllowed] string name, [NullAllowed] string label);

		[Static]
		[Export ("createTransactionWithId:affiliation:revenue:tax:shipping:currencyCode:")]
		DictionaryBuilder CreateTransaction ([NullAllowed] string transactionId, [NullAllowed] string affiliation, [NullAllowed] NSNumber revenue, [NullAllowed] NSNumber tax, [NullAllowed] NSNumber shipping, [NullAllowed] string currencyCode);

		[Export ("setProductAction:")]
		DictionaryBuilder SetProductAction (EcommerceProductAction productAction);

		[Export ("addProduct:")]
		DictionaryBuilder AddProduct (EcommerceProduct product);

		[Export ("addProductImpression:impressionList:impressionSource:")]
		DictionaryBuilder AddProductImpression (EcommerceProduct product, string name, string source);

		[Export ("addPromotion:")]
		DictionaryBuilder AddPromotion (EcommercePromotion promotion);
	}

	[BaseType (typeof(NSObject), Name = "GAIFields")]
	interface Fields
	{

		[Static]
		[Export ("contentGroupForIndex:")]
		string ContentGroup (nuint index);

		[Static]
		[Export ("customDimensionForIndex:")]
		string CustomDimension (nuint index);

		[Static]
		[Export ("customMetricForIndex:")]
		string CustomMetric (nuint index);
	}

	interface ILogger
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "GAILogger")]
	interface Logger
	{

		[Export ("logLevel")]
		LogLevel GetLogLevel ();

		[Export ("setLogLevel:")]
		void SetLogLevel (LogLevel logLevel);

		[Abstract]
		[Export ("verbose:")]
		void Verbose (string message);

		[Abstract]
		[Export ("info:")]
		void Info (string message);

		[Abstract]
		[Export ("warning:")]
		void Warning (string message);

		[Abstract]
		[Export ("error:")]
		void Error (string message);
	}

	[BaseType (typeof(UIViewController), Name = "GAITrackedViewController")]
	interface TrackedViewController
	{

		[Export ("tracker", ArgumentSemantic.Assign)] [NullAllowed]
		ITracker Tracker { get; set; }

		[Export ("screenName", ArgumentSemantic.Copy)] [NullAllowed]
		string ScreenName { get; set; }
	}

	interface ITracker
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "GAITracker")]
	interface Tracker
	{

		[Export ("name")]
		string GetName ();

		[Export ("allowIDFACollection")]
		bool GetAllowIdfaCollection ();

		[Export ("setAllowIDFACollection:")]
		void SetAllowIdfaCollection (bool allow);

		[Abstract]
		[Export ("set:value:")]
		void Set (string parameterName, [NullAllowed] string value);

		[Abstract]
		[Export ("get:")]
		string Get ([NullAllowed] string parameterName);

		[Abstract]
		[Export ("send:")]
		void Send ([NullAllowed] NSDictionary parameters);
	}

	[BaseType (typeof(NSObject), Name = "GAIEcommerceFields")]
	interface EcommerceFields
	{

		[Static]
		[Export ("productFieldForIndex:suffix:")]
		string ProductField (nuint index, string suffix);

		[Static]
		[Export ("impressionListForIndex:")]
		string ImpressionList (nuint index);

		[Static]
		[Export ("productImpressionForList:index:suffix:")]
		string ProductImpression (string list, nuint index, string suffix);

		[Static]
		[Export ("promotionForIndex:suffix:")]
		string Promotion (nuint index, string suffix);
	}

	[BaseType (typeof(NSObject), Name = "GAIEcommerceProduct")]
	interface EcommerceProduct
	{

		[Export ("setId:")]
		EcommerceProduct SetId (string productId);

		[Export ("setName:")]
		EcommerceProduct SetName (string productName);

		[Export ("setBrand:")]
		EcommerceProduct SetBrand (string productBrand);

		[Export ("setCategory:")]
		EcommerceProduct SetCategory (string productCategory);

		[Export ("setVariant:")]
		EcommerceProduct SetVariant (string productVariant);

		[Export ("setPrice:")]
		EcommerceProduct SetPrice (NSNumber productPrice);

		[Export ("setQuantity:")]
		EcommerceProduct SetQuantity (NSNumber productQuantity);

		[Export ("setCouponCode:")]
		EcommerceProduct SetCouponCode (string productCouponCode);

		[Export ("setPosition:")]
		EcommerceProduct SetPosition (NSNumber productPosition);

		[Export ("setCustomDimension:value:")]
		EcommerceProduct SetCustomDimension (nuint index, string value);

		[Export ("setCustomMetric:value:")]
		EcommerceProduct SetCustomMetric (nuint index, NSNumber value);

		[Export ("buildWithIndex:")]
		NSDictionary Build (nuint index);

		[Export ("buildWithListIndex:index:")]
		NSDictionary Build (nuint listIndex, nuint index);
	}

	[BaseType (typeof(NSObject), Name = "GAIEcommerceProductAction")]
	interface EcommerceProductAction
	{

		[Export ("setAction:")]
		EcommerceProductAction SetAction (string productAction);

		[Export ("setTransactionId:")]
		EcommerceProductAction SetTransactionId (string transactionId);

		[Export ("setAffiliation:")]
		EcommerceProductAction SetAffiliation (string affiliation);

		[Export ("setRevenue:")]
		EcommerceProductAction SetRevenue (NSNumber revenue);

		[Export ("setTax:")]
		EcommerceProductAction SetTax (NSNumber tax);

		[Export ("setShipping:")]
		EcommerceProductAction SetShipping (NSNumber shipping);

		[Export ("setCouponCode:")]
		EcommerceProductAction SetCouponCode (string couponCode);

		[Export ("setCheckoutStep:")]
		EcommerceProductAction SetCheckoutStep (NSNumber checkoutStep);

		[Export ("setCheckoutOption:")]
		EcommerceProductAction SetCheckoutOption (string checkoutOption);

		[Export ("setProductActionList:")]
		EcommerceProductAction SetProductActionList (string productActionList);

		[Export ("setProductListSource:")]
		EcommerceProductAction SetProductListSource (string productListSource);

		[Export ("build")]
		NSDictionary Build ();
	}

	[BaseType (typeof(NSObject), Name = "GAIEcommercePromotion")]
	interface EcommercePromotion
	{

		[Export ("setId:")]
		EcommercePromotion SetId (string pid);

		[Export ("setName:")]
		EcommercePromotion SetName (string name);

		[Export ("setCreative:")]
		EcommercePromotion SetCreative (string creative);

		[Export ("setPosition:")]
		EcommercePromotion SetPosition (string position);

		[Export ("buildWithIndex:")]
		NSDictionary Build (nuint index);
	}
}
