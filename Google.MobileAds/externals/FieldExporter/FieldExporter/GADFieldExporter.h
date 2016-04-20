//
//  libAdmobExporter.h
//  libAdmobExporter
//
//  Created by Alex Soto on 01/10/12.
//  Copyright (c) 2012 Alex Soto. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GoogleMobileAds/GADAdSize.h>
#import <CoreGraphics/CoreGraphics.h>

@interface GADFieldExporter : NSObject{
}

+ (GADAdSize)kGADAdSizeBannerGlobal;

+ (GADAdSize)kGADAdSizeLargeBannerGlobal;

+ (GADAdSize)kGADAdSizeMediumRectangleGlobal;

+ (GADAdSize)kGADAdSizeFullBannerGlobal;

+ (GADAdSize)kGADAdSizeLeaderboardGlobal;

+ (GADAdSize)kGADAdSizeSkyscraperGlobal;

+ (GADAdSize)kGADAdSizeSmartBannerPortraitGlobal;

+ (GADAdSize)kGADAdSizeSmartBannerLandscapeGlobal;

+ (GADAdSize)kGADAdSizeInvalidGlobal;

+ (GADAdSize)GADAdSizeFromCGSizeGlobal:(CGSize)size;

+ (GADAdSize)GADAdSizeFullWidthPortraitWithHeightGlobal:(CGFloat)height;

+ (GADAdSize)GADAdSizeFullWidthLandscapeWithHeightGlobal:(CGFloat)height;

+ (BOOL)GADAdSize:(GADAdSize)size1 equalToSizeGlobal:(GADAdSize)size2;

+ (CGSize)CGSizeFromGADAdSizeGlobal:(GADAdSize)size;

+ (BOOL)isGADAdSizeValidGlobal:(GADAdSize)size;

+ (NSString *)NSStringFromGADAdSizeGlobal:(GADAdSize)size;

+ (NSValue *)NSValueFromGADAdSizeGlobal:(GADAdSize)size;

+ (GADAdSize)GADAdSizeFromNSValueGlobal:(NSValue *)value;

@end
