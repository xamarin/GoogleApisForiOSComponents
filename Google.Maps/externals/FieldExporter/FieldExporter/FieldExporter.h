//
//  GAFieldExporter.h
//  GAFieldExporter
//
//  Created by Jonathan Dick on 2015-07-10.
//  Copyright (c) 2015 Xamarin. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "GoogleMaps/GoogleMaps.h"

@interface GMSFieldExporter : NSObject {
    
}

+ (NSString *) kGMSLayerCameraLatitudeKeyExported;
+ (NSString *) kGMSLayerCameraLongitudeKeyExported;
+ (NSString *) kGMSLayerCameraBearingKeyExported;
+ (NSString *) kGMSLayerCameraZoomLevelKeyExported;
+ (NSString *) kGMSLayerCameraViewingAngleKeyExported;
+ (float) kGMSMaxZoomLevelExported;
+ (float) kGMSMinZoomLevelExported;
+ (CGPoint) kGMSGroundOverlayDefaultAnchorExported;
+ (CGPoint) kGMSMarkerDefaultGroundAnchorExported;
+ (CGPoint) kGMSMarkerDefaultInfoWindowAnchorExported;
+ (UIImage *) kGMSTileLayerNoTileExported;
+ (NSString *) kGMSLayerPanoramaFOVKeyExported;
+ (NSString *)kGMSLayerPanoramaHeadingKeyExported;
+ (NSString *) kGMSLayerPanoramaPitchKeyExported;
+ (NSString *) kGMSLayerPanoramaZoomKeyExported;
+ (NSString *) kGMSMarkerLayerLatitudeExported;
+ (NSString *) kGMSMarkerLayerLongitudeExported;
+ (NSString *) kGMSMarkerLayerRotationExported;
+ (double) kGMSEarthRadiusExported;
+ (NSString *) kGMSAccessibilityCompassExported;
+ (NSString *) kGMSAccessibilityMyLocationExported;
+ (double) kGMSEquatorProjectedMeterExported;

+ (NSString *) kGMSAutocompleteMatchAttributeExported;
+ (NSString *) kGMSPlacePickerErrorDomainExported;
+ (NSString *) kGMSPlacesErrorDomainExported;

@end
