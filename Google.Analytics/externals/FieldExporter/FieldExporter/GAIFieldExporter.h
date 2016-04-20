//
//  GAEcommerceFieldExporter.h
//  GAFieldExporter
//
//  Created by Jonathan Dick on 2015-07-10.
//  Copyright (c) 2015 Xamarin. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "GAI.h"
#import "GAIFields.h"
#import "GAIEcommerceFields.h"

@interface GAIEcommerceFieldExporter : NSObject {
    
}

+ (NSString *) kGAIProductIdGlobal;
+ (NSString *) kGAIProductNameGlobal;
+ (NSString *) kGAIProductBrandGlobal;
+ (NSString *) kGAIProductCategoryGlobal;
+ (NSString *) kGAIProductVariantGlobal;
+ (NSString *) kGAIProductPriceGlobal;
+ (NSString *) kGAIProductQuantityGlobal;
+ (NSString *) kGAIProductCouponCodeGlobal;
+ (NSString *) kGAIProductPositionGlobal;
+ (NSString *) kGAIProductActionGlobal;
+ (NSString *) kGAIPADetailGlobal;
+ (NSString *) kGAIPAClickGlobal;
+ (NSString *) kGAIPAAddGlobal;
+ (NSString *) kGAIPARemoveGlobal;
+ (NSString *) kGAIPACheckoutGlobal;
+ (NSString *) kGAIPACheckoutOptionGlobal;
+ (NSString *) kGAIPAPurchaseGlobal;
+ (NSString *) kGAIPARefundGlobal;
+ (NSString *) kGAIPATransactionIdGlobal;
+ (NSString *) kGAIPAAffiliationGlobal;
+ (NSString *) kGAIPARevenueGlobal;
+ (NSString *) kGAIPATaxGlobal;
+ (NSString *) kGAIPAShippingGlobal;
+ (NSString *) kGAIPACouponCodeGlobal;
+ (NSString *) kGAICheckoutStepGlobal;
+ (NSString *) kGAICheckoutOptionGlobal;
+ (NSString *) kGAIProductActionListGlobal;
+ (NSString *) kGAIProductListSourceGlobal;
+ (NSString *) kGAIImpressionNameGlobal;
+ (NSString *) kGAIImpressionListSourceGlobal;
+ (NSString *) kGAIImpressionProductGlobal;
+ (NSString *) kGAIImpressionProductIdGlobal;
+ (NSString *) kGAIImpressionProductNameGlobal;
+ (NSString *) kGAIImpressionProductBrandGlobal;
+ (NSString *) kGAIImpressionProductCategoryGlobal;
+ (NSString *) kGAIImpressionProductVariantGlobal;
+ (NSString *) kGAIImpressionProductPositionGlobal;
+ (NSString *) kGAIImpressionProductPriceGlobal;
+ (NSString *) kGAIPromotionIdGlobal;
+ (NSString *) kGAIPromotionNameGlobal;
+ (NSString *) kGAIPromotionCreativeGlobal;
+ (NSString *) kGAIPromotionPositionGlobal;
+ (NSString *) kGAIPromotionActionGlobal;
+ (NSString *) kGAIPromotionViewGlobal;
+ (NSString *) kGAIPromotionClickGlobal;

@end

@interface GAIFieldExporter : NSObject {
    
}

+ (NSString *) kGAIHitTypeGlobal;
+ (NSString *) kGAITrackingIdGlobal;
+ (NSString *) kGAIClientIdGlobal;
+ (NSString *) kGAIAnonymizeIpGlobal;
+ (NSString *) kGAISessionControlGlobal;
+ (NSString *) kGAIDeviceModelVersionGlobal;
+ (NSString *) kGAIScreenResolutionGlobal;
+ (NSString *) kGAIViewportSizeGlobal;
+ (NSString *) kGAIEncodingGlobal;
+ (NSString *) kGAIScreenColorsGlobal;
+ (NSString *) kGAILanguageGlobal;
+ (NSString *) kGAIJavaEnabledGlobal;
+ (NSString *) kGAIFlashVersionGlobal;
+ (NSString *) kGAINonInteractionGlobal;
+ (NSString *) kGAIReferrerGlobal;
+ (NSString *) kGAILocationGlobal;
+ (NSString *) kGAIHostnameGlobal;
+ (NSString *) kGAIPageGlobal;
+ (NSString *) kGAIDescriptionGlobal;
+ (NSString *) kGAIScreenNameGlobal;
+ (NSString *) kGAITitleGlobal;
+ (NSString *) kGAIAppNameGlobal;
+ (NSString *) kGAIAppVersionGlobal;
+ (NSString *) kGAIAppIdGlobal;
+ (NSString *) kGAIAppInstallerIdGlobal;
+ (NSString *) kGAIEventCategoryGlobal;
+ (NSString *) kGAIEventActionGlobal;
+ (NSString *) kGAIEventLabelGlobal;
+ (NSString *) kGAIEventValueGlobal;
+ (NSString *) kGAISocialNetworkGlobal;
+ (NSString *) kGAISocialActionGlobal;
+ (NSString *) kGAISocialTargetGlobal;
+ (NSString *) kGAITransactionIdGlobal;
+ (NSString *) kGAITransactionAffiliationGlobal;
+ (NSString *) kGAITransactionRevenueGlobal;
+ (NSString *) kGAITransactionShippingGlobal;
+ (NSString *) kGAITransactionTaxGlobal;
+ (NSString *) kGAICurrencyCodeGlobal;
+ (NSString *) kGAIItemPriceGlobal;
+ (NSString *) kGAIItemQuantityGlobal;
+ (NSString *) kGAIItemSkuGlobal;
+ (NSString *) kGAIItemNameGlobal;
+ (NSString *) kGAIItemCategoryGlobal;
+ (NSString *) kGAICampaignSourceGlobal;
+ (NSString *) kGAICampaignMediumGlobal;
+ (NSString *) kGAICampaignNameGlobal;
+ (NSString *) kGAICampaignKeywordGlobal;
+ (NSString *) kGAICampaignContentGlobal;
+ (NSString *) kGAICampaignIdGlobal;
+ (NSString *) kGAICampaignAdNetworkClickIdGlobal;
+ (NSString *) kGAICampaignAdNetworkIdGlobal;
+ (NSString *) kGAITimingCategoryGlobal;
+ (NSString *) kGAITimingVarGlobal;
+ (NSString *) kGAITimingValueGlobal;
+ (NSString *) kGAITimingLabelGlobal;
+ (NSString *) kGAIExDescriptionGlobal;
+ (NSString *) kGAIExFatalGlobal;
+ (NSString *) kGAISampleRateGlobal;
+ (NSString *) kGAIIdfaGlobal;
+ (NSString *) kGAIAdTargetingEnabledGlobal;
+ (NSString *) kGAIAppViewGlobal;
+ (NSString *) kGAIEventGlobal;
+ (NSString *) kGAISocialGlobal;
+ (NSString *) kGAITransactionGlobal;
+ (NSString *) kGAIItemGlobal;
+ (NSString *) kGAIExceptionGlobal;
+ (NSString *) kGAITimingGlobal;
+ (NSString *) kGAIProductGlobal;
+ (NSString *) kGAIVersionGlobal;
+ (NSString *) kGAIErrorDomainGlobal;

@end
