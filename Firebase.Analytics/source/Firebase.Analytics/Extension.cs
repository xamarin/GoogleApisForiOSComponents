using System;
using Foundation;

namespace Firebase.Analytics
{
	//public partial class App
	//{
	//	[Obsolete ("Use From method instead.")]
	//	public static App Get (string name)
	//	{
	//		return From (name);
	//	}
	//}

	public partial class Analytics
	{
		public static void LogEvent (NSString name, NSDictionary<NSString, NSObject> parameters)
		{
			if (name == null)
				throw new ArgumentNullException (nameof (name));

			LogEvent (name.ToString (), parameters);
		}

		public static void SetUserProperty (NSString value, NSString name)
		{
			if (name == null)
				throw new ArgumentNullException (nameof (name));

			SetUserProperty (value.ToString (), name.ToString ());
		}

		[Obsolete ("This will be removed in future versions, please use SetScreenNameAndClass method instead.")]
		public static void setScreenNameAndClass (string screenName, string screenClassOverride)
		{
			SetScreenNameAndClass (screenName, screenClassOverride);
		}
	}

	public static class EventNamesConstants
	{
		public static NSString AddPaymentInfo { get; } = new NSString ("add_payment_info");
		public static NSString AddToCart { get; } = new NSString ("add_to_cart");
		public static NSString AddToWishlist { get; } = new NSString ("add_to_wishlist");
		public static NSString AppOpen { get; } = new NSString ("app_open");
		public static NSString BeginCheckout { get; } = new NSString ("begin_checkout");
		public static NSString CampaignDetails { get; } = new NSString ("campaign_details");
		public static NSString CheckoutProgress { get; } = new NSString ("checkout_progress");
		public static NSString EarnVirtualCurrency { get; } = new NSString ("earn_virtual_currency");
		public static NSString EcommercePurchase { get; } = new NSString ("ecommerce_purchase");
		public static NSString GenerateLead { get; } = new NSString ("generate_lead");
		public static NSString JoinGroup { get; } = new NSString ("join_group");
		public static NSString LevelUp { get; } = new NSString ("level_up");
		public static NSString Login { get; } = new NSString ("login");
		public static NSString PostScore { get; } = new NSString ("post_score");
		public static NSString PresentOffer { get; } = new NSString ("present_offer");
		public static NSString PurchaseRefund { get; } = new NSString ("purchase_refund");
		public static NSString RemoveFromCart { get; } = new NSString ("remove_from_cart");
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
	}

	public static class ParameterNamesConstants
	{
		public static NSString AchievementId { get; } = new NSString ("achievement_id");
		public static NSString AdNetworkClickId { get; } = new NSString ("aclid");
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
		public static NSString SearchTerm { get; } = new NSString ("search_term");
		public static NSString Shipping { get; } = new NSString ("shipping");
		public static NSString SignUpMethod { get; } = new NSString ("sign_up_method");
		public static NSString Source { get; } = new NSString ("source");
		public static NSString StartDate { get; } = new NSString ("start_date");
		public static NSString Tax { get; } = new NSString ("tax");
		public static NSString Term { get; } = new NSString ("term");
		public static NSString TransactionId { get; } = new NSString ("transaction_id");
		public static NSString TravelClass { get; } = new NSString ("travel_class");
		public static NSString Value { get; } = new NSString ("value");
		public static NSString VirtualCurrencyName { get; } = new NSString ("virtual_currency_name");
	}

	public static class UserPropertyNamesConstants
	{
		public static NSString SignUpMethod { get; } = new NSString ("sign_up_method");
	}
}

