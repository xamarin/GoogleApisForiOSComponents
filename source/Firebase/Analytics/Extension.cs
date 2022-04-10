using System;
using System.Collections.Generic;
using Foundation;

namespace Firebase.Analytics
{
	public static class EventNamesConstants
	{
		public static NSString AddPaymentInfo { get; } = new NSString ("add_payment_info");
		public static NSString AddToCart { get; } = new NSString ("add_to_cart");
		public static NSString AddToWishlist { get; } = new NSString ("add_to_wishlist");
		public static NSString AdImpression { get; } = new NSString ("ad_impression");
		public static NSString AppOpen { get; } = new NSString ("app_open");
		public static NSString BeginCheckout { get; } = new NSString ("begin_checkout");
		public static NSString CampaignDetails { get; } = new NSString ("campaign_details");
		public static NSString CheckoutProgress { get; } = new NSString ("checkout_progress");
		public static NSString EarnVirtualCurrency { get; } = new NSString ("earn_virtual_currency");
		public static NSString EcommercePurchase { get; } = new NSString ("ecommerce_purchase");
		public static NSString GenerateLead { get; } = new NSString ("generate_lead");
		public static NSString JoinGroup { get; } = new NSString ("join_group");
		public static NSString LevelEnd { get; } = new NSString("level_end");
		public static NSString LevelStart { get; } = new NSString("level_start");
		public static NSString LevelUp { get; } = new NSString ("level_up");
		public static NSString Login { get; } = new NSString ("login");
		public static NSString PostScore { get; } = new NSString ("post_score");
		public static NSString PresentOffer { get; } = new NSString ("present_offer");
		public static NSString PurchaseRefund { get; } = new NSString ("purchase_refund");
		public static NSString RemoveFromCart { get; } = new NSString ("remove_from_cart");
		public static NSString ScreenView { get; } = new NSString ("screen_view");
		public static NSString Search { get; } = new NSString ("search");
		public static NSString SelectContent { get; } = new NSString ("select_content");
		public static NSString SetCheckoutOption { get; } = new NSString ("set_checkout_option");
		public static NSString Share { get; } = new NSString ("share");
		public static NSString SignUp { get; } = new NSString ("sign_up");
		public static NSString SpendVirtualCurrency { get; } = new NSString ("spend_virtual_currency");
		public static NSString TutorialBegin { get; } = new NSString ("tutorial_begin");
		public static NSString TutorialComplete { get; } = new NSString ("tutorial_complete");
		public static NSString UnlockAchievement { get; } = new NSString ("unlock_achievement");
		public static NSString ViewItem { get; } = new NSString ("view_item");
		public static NSString ViewItemList { get; } = new NSString ("view_item_list");
		public static NSString ViewSearchResults { get; } = new NSString ("view_search_results");
		public static NSString AddShippingInfo { get; } = new NSString ("add_shipping_info");
		public static NSString Purchase { get; } = new NSString ("purchase");
		public static NSString Refund { get; } = new NSString ("refund");
		public static NSString SelectItem { get; } = new NSString ("select_item");
		public static NSString SelectPromotion { get; } = new NSString ("select_promotion");
		public static NSString ViewCart { get; } = new NSString ("view_cart");
		public static NSString ViewPromotion { get; } = new NSString ("view_promotion");
	}

	public static class ParameterNamesConstants
	{
		public static NSString AchievementId { get; } = new NSString ("achievement_id");
		public static NSString AdFormat { get; } = new NSString ("ad_format");
		public static NSString AdNetworkClickId { get; } = new NSString ("aclid");
		public static NSString AdPlatform { get; } = new NSString ("ad_platform");
		public static NSString AdSource { get; } = new NSString ("ad_source");
		public static NSString AdUnitName { get; } = new NSString ("ad_unit_name");
		public static NSString Affiliation { get; } = new NSString ("affiliation");
		public static NSString Campaign { get; } = new NSString ("campaign");
		public static NSString Character { get; } = new NSString ("character");
		public static NSString CheckoutStep { get; } = new NSString ("checkout_step");
		public static NSString CheckoutOption { get; } = new NSString ("checkout_option");
		public static NSString Content { get; } = new NSString ("content");
		public static NSString ContentType { get; } = new NSString ("content_type");
		public static NSString Coupon { get; } = new NSString ("coupon");
		public static NSString Cp1 { get; } = new NSString ("cp1");
		public static NSString CreativeName { get; } = new NSString ("creative_name");
		public static NSString CreativeSlot { get; } = new NSString ("creative_slot");
		public static NSString Currency { get; } = new NSString ("currency");
		public static NSString Destination { get; } = new NSString ("destination");
		public static NSString EndDate { get; } = new NSString ("end_date");
		public static NSString FlightNumber { get; } = new NSString ("flight_number");
		public static NSString GroupId { get; } = new NSString ("group_id");
		public static NSString Index { get; } = new NSString ("index");
		public static NSString ItemBrand { get; } = new NSString ("item_brand");
		public static NSString ItemCategory { get; } = new NSString ("item_category");
		public static NSString ItemId { get; } = new NSString ("item_id");
		public static NSString ItemLocationId { get; } = new NSString ("item_location_id");
		public static NSString ItemName { get; } = new NSString ("item_name");
		public static NSString ItemList { get; } = new NSString ("item_list");
		public static NSString ItemVariant { get; } = new NSString ("item_variant");
		public static NSString Level { get; } = new NSString ("level");
		public static NSString Location { get; } = new NSString ("location");
		public static NSString Medium { get; } = new NSString ("medium");
		public static NSString NumberOfNights { get; } = new NSString ("number_of_nights");
		public static NSString NumberOfPassengers { get; } = new NSString ("number_of_passengers");
		public static NSString NumberOfRooms { get; } = new NSString ("number_of_rooms");
		public static NSString Origin { get; } = new NSString ("origin");
		public static NSString Price { get; } = new NSString ("price");
		public static NSString Quantity { get; } = new NSString ("quantity");
		public static NSString Score { get; } = new NSString ("score");
		public static NSString ScreenClass { get; } = new NSString ("screen_class");
		public static NSString ScreenName { get; } = new NSString ("screen_name");
		public static NSString SearchTerm { get; } = new NSString ("search_term");
		public static NSString Shipping { get; } = new NSString ("shipping");
		[Obsolete ("Use Method property instead.")]
		public static NSString SignUpMethod { get; } = new NSString ("sign_up_method");
		public static NSString Method { get; } = new NSString ("method");
		public static NSString Source { get; } = new NSString ("source");
		public static NSString StartDate { get; } = new NSString ("start_date");
		public static NSString Tax { get; } = new NSString ("tax");
		public static NSString Term { get; } = new NSString ("term");
		public static NSString TransactionId { get; } = new NSString ("transaction_id");
		public static NSString TravelClass { get; } = new NSString ("travel_class");
		public static NSString Value { get; } = new NSString ("value");
		public static NSString VirtualCurrencyName { get; } = new NSString ("virtual_currency_name");
		public static NSString LevelName { get; } = new NSString ("level_name");
		public static NSString Success { get; } = new NSString ("success");
		public static NSString ExtendSession { get; } = new NSString ("extend_session");
		public static NSString Discount { get; } = new NSString ("discount");
		public static NSString ItemCategory2 { get; } = new NSString ("item_category2");
		public static NSString ItemCategory3 { get; } = new NSString ("item_category3");
		public static NSString ItemCategory4 { get; } = new NSString ("item_category4");
		public static NSString ItemCategory5 { get; } = new NSString ("item_category5");
		public static NSString ItemListId { get; } = new NSString ("item_list_id");
		public static NSString ItemListName { get; } = new NSString ("item_list_name");
		public static NSString Items { get; } = new NSString ("items");
		public static NSString LocationId { get; } = new NSString ("location_id");
		public static NSString PaymentType { get; } = new NSString ("payment_type");
		public static NSString PromotionId { get; } = new NSString ("promotion_id");
		public static NSString PromotionName { get; } = new NSString ("promotion_name");
		public static NSString ShippingTier { get; } = new NSString ("shipping_tier");
	}

	public static class UserPropertyNamesConstants
	{
		public static NSString SignUpMethod { get; } = new NSString ("sign_up_method");
		public static NSString AllowAdPersonalizationSignals { get; } = new NSString ("allow_personalized_ads");
	}

	public partial class Analytics {
		public static void SetConsent (Dictionary<ConsentType, ConsentStatus> consentSettings)
		{
			var keys = new List<NSString> ();
			var values = new List<NSString> ();

			foreach (var kv in consentSettings) {
				keys.Add (global::Firebase.Analytics.ConsentTypeExtensions.GetConstant (kv.Key));
				values.Add (global::Firebase.Analytics.ConsentStatusExtensions.GetConstant (kv.Value));
			}

			_SetConsent (new NSDictionary<NSString, NSString> (keys.ToArray (), values.ToArray ()));
		}
	}
}

