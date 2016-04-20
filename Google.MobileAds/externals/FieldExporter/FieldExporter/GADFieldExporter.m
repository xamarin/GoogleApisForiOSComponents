//
//  libAdmobExporter.m
//  libAdmobExporter
//
//  Created by Alex Soto on 01/10/12.
//  Copyright (c) 2012 Alex Soto. All rights reserved.
//

#import "GADFieldExporter.h"

@implementation GADFieldExporter

+ (GADAdSize)kGADAdSizeBannerGlobal
{
    return kGADAdSizeBanner;
}

+ (GADAdSize)kGADAdSizeLargeBannerGlobal
{
    return kGADAdSizeLargeBanner;
}

+ (GADAdSize)kGADAdSizeMediumRectangleGlobal
{
    return kGADAdSizeMediumRectangle;
}

+ (GADAdSize)kGADAdSizeFullBannerGlobal
{
    return kGADAdSizeFullBanner;
}

+ (GADAdSize)kGADAdSizeLeaderboardGlobal
{
    return kGADAdSizeLeaderboard;
}

+ (GADAdSize)kGADAdSizeSkyscraperGlobal
{
    return kGADAdSizeSkyscraper;
}

+ (GADAdSize)kGADAdSizeSmartBannerPortraitGlobal
{
    return kGADAdSizeSmartBannerPortrait;
}

+ (GADAdSize)kGADAdSizeSmartBannerLandscapeGlobal
{
    return kGADAdSizeSmartBannerLandscape;
}

+ (GADAdSize)kGADAdSizeInvalidGlobal
{
    return kGADAdSizeInvalid;
}

+ (GADAdSize)GADAdSizeFromCGSizeGlobal:(CGSize) size
{
    return GADAdSizeFromCGSize(size);
}

+ (GADAdSize)GADAdSizeFullWidthPortraitWithHeightGlobal:(CGFloat)height
{
    return GADAdSizeFullWidthPortraitWithHeight(height);
}	

+ (GADAdSize)GADAdSizeFullWidthLandscapeWithHeightGlobal:(CGFloat)height
{
    return GADAdSizeFullWidthLandscapeWithHeight(height);
}

+ (BOOL)GADAdSize:(GADAdSize)size1 equalToSizeGlobal:(GADAdSize)size2
{
    return GADAdSizeEqualToSize(size1, size2);
}

+ (CGSize)CGSizeFromGADAdSizeGlobal:(GADAdSize)size
{
    return CGSizeFromGADAdSize(size);
}

+ (BOOL)isGADAdSizeValidGlobal:(GADAdSize)size
{
    return IsGADAdSizeValid(size);
}

+ (NSString *)NSStringFromGADAdSizeGlobal:(GADAdSize)size
{
    return NSStringFromGADAdSize(size);
}

+ (NSValue *)NSValueFromGADAdSizeGlobal:(GADAdSize)size
{
    return NSValueFromGADAdSize(size);
}

+ (GADAdSize)GADAdSizeFromNSValueGlobal:(NSValue *)value
{
    return GADAdSizeFromNSValue(value);
}

@end
