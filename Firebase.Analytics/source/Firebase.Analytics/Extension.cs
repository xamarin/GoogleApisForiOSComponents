using System;
using Foundation;

namespace Firebase.Analytics
{
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
	}

	public static class EventNamesConstants
	{
		static NSString addPaymentInfo = new NSString ("add_payment_info");
		public static NSString AddPaymentInfo { get; } = addPaymentInfo;

		static NSString addToCart = new NSString ("add_to_cart");
		public static NSString AddToCart { get; } = addToCart;

		static NSString addToWishlist = new NSString ("add_to_wishlist");
		public static NSString AddToWishlist { get; } = addToWishlist;

		static NSString appOpen = new NSString ("app_open");
		public static NSString AppOpen { get; } = appOpen;

		static NSString beginCheckout = new NSString ("begin_checkout");
		public static NSString BeginCheckout { get; } = beginCheckout;

		static NSString earnVirtualCurrency = new NSString ("earn_virtual_currency");
		public static NSString EarnVirtualCurrency { get; } = earnVirtualCurrency;

		static NSString ecommercePurchase = new NSString ("ecommerce_purchase");
		public static NSString EcommercePurchase { get; } = ecommercePurchase;

		static NSString generateLead = new NSString ("generate_lead");
		public static NSString GenerateLead { get; } = generateLead;

		static NSString joinGroup = new NSString ("join_group");
		public static NSString JoinGroup { get; } = joinGroup;

		static NSString levelUp = new NSString ("level_up");
		public static NSString LevelUp { get; } = levelUp;

		static NSString login = new NSString ("login");
		public static NSString Login { get; } = login;

		static NSString postScore = new NSString ("post_score");
		public static NSString PostScore { get; } = postScore;

		static NSString presentOffer = new NSString ("present_offer");
		public static NSString PresentOffer { get; } = presentOffer;

		static NSString purchaseRefund = new NSString ("purchase_refund");
		public static NSString PurchaseRefund { get; } = purchaseRefund;

		static NSString search = new NSString ("search");
		public static NSString Search { get; } = search;

		static NSString selectContent = new NSString ("select_content");
		public static NSString SelectContent { get; } = selectContent;

		static NSString share = new NSString ("share");
		public static NSString Share { get; } = share;

		static NSString signUp = new NSString ("sign_up");
		public static NSString SignUp { get; } = signUp;

		static NSString spendVirtualCurrency = new NSString ("spend_virtual_currency");
		public static NSString SpendVirtualCurrency { get; } = spendVirtualCurrency;

		static NSString tutorialBegin = new NSString ("tutorial_begin");
		public static NSString TutorialBegin { get; } = tutorialBegin;

		static NSString tutorialComplete = new NSString ("tutorial_complete");
		public static NSString TutorialComplete { get; } = tutorialComplete;

		static NSString unlockAchievement = new NSString ("unlock_achievement");
		public static NSString UnlockAchievement { get; } = unlockAchievement;

		static NSString viewItem = new NSString ("view_item");
		public static NSString ViewItem { get; } = viewItem;

		static NSString viewItemList = new NSString ("view_item_list");
		public static NSString ViewItemList { get; } = viewItemList;

		static NSString viewSearchResults = new NSString ("view_search_results");
		public static NSString ViewSearchResults { get; } = viewSearchResults;
	}

	public static class ParameterNamesConstants
	{
		static NSString achievementId = new NSString ("achievement_id");
		public static NSString AchievementId { get; } = achievementId;

		static NSString character = new NSString ("character");
		public static NSString Character { get; } = character;

		static NSString contentType = new NSString ("content_type");
		public static NSString ContentType { get; } = contentType;

		static NSString coupon = new NSString ("coupon");
		public static NSString Coupon { get; } = coupon;

		static NSString currency = new NSString ("currency");
		public static NSString Currency { get; } = currency;

		static NSString destination = new NSString ("destination");
		public static NSString Destination { get; } = destination;

		static NSString endDate = new NSString ("end_date");
		public static NSString EndDate { get; } = endDate;

		static NSString flightNumber = new NSString ("flight_number");
		public static NSString FlightNumber { get; } = flightNumber;

		static NSString groupId = new NSString ("group_id");
		public static NSString GroupId { get; } = groupId;

		static NSString itemCategory = new NSString ("item_category");
		public static NSString ItemCategory { get; } = itemCategory;

		static NSString itemId = new NSString ("item_id");
		public static NSString ItemId { get; } = itemId;

		static NSString itemLocationId = new NSString ("item_location_id");
		public static NSString ItemLocationId { get; } = itemLocationId;

		static NSString itemName = new NSString ("item_name");
		public static NSString ItemName { get; } = itemName;

		static NSString level = new NSString ("level");
		public static NSString Level { get; } = level;

		static NSString location = new NSString ("location");
		public static NSString Location { get; } = location;

		static NSString numberOfNights = new NSString ("number_of_nights");
		public static NSString NumberOfNights { get; } = numberOfNights;

		static NSString numberOfPassengers = new NSString ("number_of_passengers");
		public static NSString NumberOfPassengers { get; } = numberOfPassengers;

		static NSString numberOfRooms = new NSString ("number_of_rooms");
		public static NSString NumberOfRooms { get; } = numberOfRooms;

		static NSString origin = new NSString ("origin");
		public static NSString Origin { get; } = origin;

		static NSString price = new NSString ("price");
		public static NSString Price { get; } = price;

		static NSString quantity = new NSString ("quantity");
		public static NSString Quantity { get; } = quantity;

		static NSString score = new NSString ("score");
		public static NSString Score { get; } = score;

		static NSString searchTerm = new NSString ("search_term");
		public static NSString SearchTerm { get; } = searchTerm;

		static NSString shipping = new NSString ("shipping");
		public static NSString Shipping { get; } = shipping;

		static NSString signUpMethod = new NSString ("sign_up_method");
		public static NSString SignUpMethod { get; } = signUpMethod;

		static NSString startDate = new NSString ("start_date");
		public static NSString StartDate { get; } = startDate;

		static NSString tax = new NSString ("tax");
		public static NSString Tax { get; } = tax;

		static NSString transactionId = new NSString ("transaction_id");
		public static NSString TransactionId { get; } = transactionId;

		static NSString travelClass = new NSString ("travel_class");
		public static NSString TravelClass { get; } = travelClass;

		static NSString value = new NSString ("value");
		public static NSString Value { get; } = value;

		static NSString virtualCurrencyName = new NSString ("virtual_currency_name");
		public static NSString VirtualCurrencyName { get; } = virtualCurrencyName;
	}

	public static class UserPropertyNamesConstants
	{
		static NSString signUpMethod = new NSString ("sign_up_method");
		public static NSString SignUpMethod { get; } = signUpMethod;
	}
}

