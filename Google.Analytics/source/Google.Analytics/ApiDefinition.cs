using System;
using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

namespace Google.Analytics
{
	// Custom Class to export all the constants inside Google Analytics SDK
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GAIFieldExporter")]
	interface GaiConstants
	{

		[Static]
		[Export ("kGAIHitTypeGlobal")]
		NSString HitType { get; }

		[Static]
		[Export ("kGAITrackingIdGlobal")]
		NSString TrackingId { get; }

		[Static]
		[Export ("kGAIClientIdGlobal")]
		NSString ClientId { get; }

		[Static]
		[Export ("kGAIDataSourceGlobal")]
		NSString DataSource { get; }

		[Static]
		[Export ("kGAIAnonymizeIpGlobal")]
		NSString AnonymizeIp { get; }

		[Static]
		[Export ("kGAISessionControlGlobal")]
		NSString SessionControl { get; }

		[Static]
		[Export ("kGAIDeviceModelVersionGlobal")]
		NSString DeviceModelVersion { get; }

		[Static]
		[Export ("kGAIScreenResolutionGlobal")]
		NSString ScreenResolution { get; }

		[Static]
		[Export ("kGAIViewportSizeGlobal")]
		NSString ViewportSize { get; }

		[Static]
		[Export ("kGAIEncodingGlobal")]
		NSString Encoding { get; }

		[Static]
		[Export ("kGAIScreenColorsGlobal")]
		NSString ScreenColors { get; }

		[Static]
		[Export ("kGAILanguageGlobal")]
		NSString Language { get; }

		[Static]
		[Export ("kGAIJavaEnabledGlobal")]
		NSString JavaEnabled { get; }

		[Static]
		[Export ("kGAIFlashVersionGlobal")]
		NSString FlashVersion { get; }

		[Static]
		[Export ("kGAINonInteractionGlobal")]
		NSString NonInteraction { get; }

		[Static]
		[Export ("kGAIReferrerGlobal")]
		NSString Referrer { get; }

		[Static]
		[Export ("kGAILocationGlobal")]
		NSString Location { get; }

		[Static]
		[Export ("kGAIHostnameGlobal")]
		NSString Hostname { get; }

		[Static]
		[Export ("kGAIPageGlobal")]
		NSString Page { get; }

		[Static]
		[Export ("kGAIDescriptionGlobal")] [New]
		NSString Description { get; }

		[Static]
		[Export ("kGAIScreenNameGlobal")]
		NSString ScreenName { get; }

		[Static]
		[Export ("kGAITitleGlobal")]
		NSString Title { get; }

		[Static]
		[Export ("kGAIAdMobHitIdGlobal")]
		NSString AdMobHitId { get; }

		[Static]
		[Export ("kGAIAppNameGlobal")]
		NSString AppName { get; }

		[Static]
		[Export ("kGAIAppVersionGlobal")]
		NSString AppVersion { get; }

		[Static]
		[Export ("kGAIAppIdGlobal")]
		NSString AppId { get; }

		[Static]
		[Export ("kGAIAppInstallerIdGlobal")]
		NSString AppInstallerId { get; }

		[Static]
		[Export ("kGAIEventCategoryGlobal")]
		NSString EventCategory { get; }

		[Static]
		[Export ("kGAIEventActionGlobal")]
		NSString EventAction { get; }

		[Static]
		[Export ("kGAIEventLabelGlobal")]
		NSString EventLabel { get; }

		[Static]
		[Export ("kGAIEventValueGlobal")]
		NSString EventValue { get; }

		[Static]
		[Export ("kGAISocialNetworkGlobal")]
		NSString SocialNetwork { get; }

		[Static]
		[Export ("kGAISocialActionGlobal")]
		NSString SocialAction { get; }

		[Static]
		[Export ("kGAISocialTargetGlobal")]
		NSString SocialTarget { get; }

		[Static]
		[Export ("kGAITransactionIdGlobal")]
		NSString TransactionId { get; }

		[Static]
		[Export ("kGAITransactionAffiliationGlobal")]
		NSString TransactionAffiliation { get; }

		[Static]
		[Export ("kGAITransactionRevenueGlobal")]
		NSString TransactionRevenue { get; }

		[Static]
		[Export ("kGAITransactionShippingGlobal")]
		NSString TransactionShipping { get; }

		[Static]
		[Export ("kGAITransactionTaxGlobal")]
		NSString TransactionTax { get; }

		[Static]
		[Export ("kGAICurrencyCodeGlobal")]
		NSString CurrencyCode { get; }

		[Static]
		[Export ("kGAIItemPriceGlobal")]
		NSString ItemPrice { get; }

		[Static]
		[Export ("kGAIItemQuantityGlobal")]
		NSString ItemQuantity { get; }

		[Static]
		[Export ("kGAIItemSkuGlobal")]
		NSString ItemSku { get; }

		[Static]
		[Export ("kGAIItemNameGlobal")]
		NSString ItemName { get; }

		[Static]
		[Export ("kGAIItemCategoryGlobal")]
		NSString ItemCategory { get; }

		[Static]
		[Export ("kGAICampaignSourceGlobal")]
		NSString CampaignSource { get; }

		[Static]
		[Export ("kGAICampaignMediumGlobal")]
		NSString CampaignMedium { get; }

		[Static]
		[Export ("kGAICampaignNameGlobal")]
		NSString CampaignName { get; }

		[Static]
		[Export ("kGAICampaignKeywordGlobal")]
		NSString CampaignKeyword { get; }

		[Static]
		[Export ("kGAICampaignContentGlobal")]
		NSString CampaignContent { get; }

		[Static]
		[Export ("kGAICampaignIdGlobal")]
		NSString CampaignId { get; }

		[Static]
		[Export ("kGAICampaignAdNetworkClickIdGlobal")]
		NSString CampaignAdNetworkClickId { get; }

		[Static]
		[Export ("kGAICampaignAdNetworkIdGlobal")]
		NSString CampaignAdNetworkId { get; }

		[Static]
		[Export ("kGAITimingCategoryGlobal")]
		NSString TimingCategory { get; }

		[Static]
		[Export ("kGAITimingVarGlobal")]
		NSString TimingVar { get; }

		[Static]
		[Export ("kGAITimingValueGlobal")]
		NSString TimingValue { get; }

		[Static]
		[Export ("kGAITimingLabelGlobal")]
		NSString TimingLabel { get; }

		[Static]
		[Export ("kGAIExDescriptionGlobal")]
		NSString ExDescription { get; }

		[Static]
		[Export ("kGAIExFatalGlobal")]
		NSString ExFatal { get; }

		[Static]
		[Export ("kGAISampleRateGlobal")]
		NSString SampleRate { get; }

		[Static]
		[Export ("kGAIIdfaGlobal")]
		NSString Idfa { get; }

		[Static]
		[Export ("kGAIAdTargetingEnabledGlobal")]
		NSString AdTargetingEnabled { get; }

		[Obsolete ("Use ScreenView property instead")]
		[Static]
		[Export ("kGAIAppViewGlobal")]
		NSString AppView { get; }

		[Static]
		[Export ("kGAIScreenViewGlobal")]
		NSString ScreenView { get; }

		[Static]
		[Export ("kGAIEventGlobal")]
		NSString Event { get; }

		[Static]
		[Export ("kGAISocialGlobal")]
		NSString Social { get; }

		[Static]
		[Export ("kGAITransactionGlobal")]
		NSString Transaction { get; }

		[Static]
		[Export ("kGAIItemGlobal")]
		NSString Item { get; }

		[Static]
		[Export ("kGAIExceptionGlobal")]
		NSString Exception { get; }

		[Static]
		[Export ("kGAITimingGlobal")]
		NSString Timing { get; }

		[Static]
		[Export ("kGAIProductGlobal")]
		NSString Product { get; }

		[Static]
		[Export ("kGAIVersionGlobal")]
		NSString Version { get; }

		[Static]
		[Export ("kGAIErrorDomainGlobal")]
		NSString ErrorDomain { get; }
	}

	// Custom Class to export all the constants inside GAIEcommerceFields
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GAIEcommerceFieldExporter")]
	interface EcommerceConstants
	{

		[Static]
		[Export ("kGAIProductIdGlobal")]
		NSString ProductId { get; }

		[Static]
		[Export ("kGAIProductNameGlobal")]
		NSString ProductName { get; }

		[Static]
		[Export ("kGAIProductBrandGlobal")]
		NSString ProductBrand { get; }

		[Static]
		[Export ("kGAIProductCategoryGlobal")]
		NSString ProductCategory { get; }

		[Static]
		[Export ("kGAIProductVariantGlobal")]
		NSString ProductVariant { get; }

		[Static]
		[Export ("kGAIProductPriceGlobal")]
		NSString ProductPrice { get; }

		[Static]
		[Export ("kGAIProductQuantityGlobal")]
		NSString ProductQuantity { get; }

		[Static]
		[Export ("kGAIProductCouponCodeGlobal")]
		NSString ProductCouponCode { get; }

		[Static]
		[Export ("kGAIProductPositionGlobal")]
		NSString ProductPosition { get; }

		[Static]
		[Export ("kGAIProductActionGlobal")]
		NSString ProductAction { get; }

		[Static]
		[Export ("kGAIPADetailGlobal")]
		NSString PADetail { get; }

		[Static]
		[Export ("kGAIPAClickGlobal")]
		NSString PAClick { get; }

		[Static]
		[Export ("kGAIPAAddGlobal")]
		NSString PAAdd { get; }

		[Static]
		[Export ("kGAIPARemoveGlobal")]
		NSString PARemove { get; }

		[Static]
		[Export ("kGAIPACheckoutGlobal")]
		NSString PACheckout { get; }

		[Static]
		[Export ("kGAIPACheckoutOptionGlobal")]
		NSString PACheckoutOption { get; }

		[Static]
		[Export ("kGAIPAPurchaseGlobal")]
		NSString PAPurchase { get; }

		[Static]
		[Export ("kGAIPARefundGlobal")]
		NSString PARefund { get; }

		[Static]
		[Export ("kGAIPATransactionIdGlobal")]
		NSString PATransactionId { get; }

		[Static]
		[Export ("kGAIPAAffiliationGlobal")]
		NSString PAAffiliation { get; }

		[Static]
		[Export ("kGAIPARevenueGlobal")]
		NSString PARevenue { get; }

		[Static]
		[Export ("kGAIPATaxGlobal")]
		NSString PATax { get; }

		[Static]
		[Export ("kGAIPAShippingGlobal")]
		NSString PAShipping { get; }

		[Static]
		[Export ("kGAIPACouponCodeGlobal")]
		NSString PACouponCode { get; }

		[Static]
		[Export ("kGAICheckoutStepGlobal")]
		NSString CheckoutStep { get; }

		[Static]
		[Export ("kGAICheckoutOptionGlobal")]
		NSString CheckoutOption { get; }

		[Static]
		[Export ("kGAIProductActionListGlobal")]
		NSString ProductActionList { get; }

		[Static]
		[Export ("kGAIProductListSourceGlobal")]
		NSString ProductListSource { get; }

		[Static]
		[Export ("kGAIImpressionNameGlobal")]
		NSString ImpressionName { get; }

		[Static]
		[Export ("kGAIImpressionListSourceGlobal")]
		NSString ImpressionListSource { get; }

		[Static]
		[Export ("kGAIImpressionProductGlobal")]
		NSString ImpressionProduct { get; }

		[Static]
		[Export ("kGAIImpressionProductIdGlobal")]
		NSString ImpressionProductId { get; }

		[Static]
		[Export ("kGAIImpressionProductNameGlobal")]
		NSString ImpressionProductName { get; }

		[Static]
		[Export ("kGAIImpressionProductBrandGlobal")]
		NSString ImpressionProductBrand { get; }

		[Static]
		[Export ("kGAIImpressionProductCategoryGlobal")]
		NSString ImpressionProductCategory { get; }

		[Static]
		[Export ("kGAIImpressionProductVariantGlobal")]
		NSString ImpressionProductVariant { get; }

		[Static]
		[Export ("kGAIImpressionProductPositionGlobal")]
		NSString ImpressionProductPosition { get; }

		[Static]
		[Export ("kGAIImpressionProductPriceGlobal")]
		NSString ImpressionProductPrice { get; }

		[Static]
		[Export ("kGAIPromotionIdGlobal")]
		NSString PromotionId { get; }

		[Static]
		[Export ("kGAIPromotionNameGlobal")]
		NSString PromotionName { get; }

		[Static]
		[Export ("kGAIPromotionCreativeGlobal")]
		NSString PromotionCreative { get; }

		[Static]
		[Export ("kGAIPromotionPositionGlobal")]
		NSString PromotionPosition { get; }

		[Static]
		[Export ("kGAIPromotionActionGlobal")]
		NSString PromotionAction { get; }

		[Static]
		[Export ("kGAIPromotionViewGlobal")]
		NSString PromotionView { get; }

		[Static]
		[Export ("kGAIPromotionClickGlobal")]
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
