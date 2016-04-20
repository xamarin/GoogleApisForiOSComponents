//
//  FieldExporter.m
//  FieldExporter
//
//  Created by Jonathan Dick on 2015-07-10.
//  Copyright (c) 2015 Xamarin. All rights reserved.
//

#import "FieldExporter.h"

@implementation GMSFieldExporter


+ (NSString *) kGMSLayerCameraLatitudeKeyExported {
    return kGMSLayerCameraLatitudeKey;
}

+ (NSString *) kGMSLayerCameraLongitudeKeyExported
{
    return kGMSLayerCameraLongitudeKey;
}

+ (NSString *) kGMSLayerCameraBearingKeyExported {
    return kGMSLayerCameraBearingKey;
}

+ (NSString *) kGMSLayerCameraZoomLevelKeyExported {
    return kGMSLayerCameraZoomLevelKey;
}

+ (NSString *) kGMSLayerCameraViewingAngleKeyExported {
    return kGMSLayerCameraViewingAngleKey;
}

+ (float) kGMSMaxZoomLevelExported {
    return kGMSMaxZoomLevel;
}

+ (float) kGMSMinZoomLevelExported {
    return kGMSMinZoomLevel;
}

+ (CGPoint) kGMSGroundOverlayDefaultAnchorExported {
    return kGMSGroundOverlayDefaultAnchor;
}

+ (CGPoint) kGMSMarkerDefaultGroundAnchorExported {
    return kGMSMarkerDefaultGroundAnchor;
}

+ (CGPoint) kGMSMarkerDefaultInfoWindowAnchorExported {
    return kGMSMarkerDefaultInfoWindowAnchor;    
}

+ (UIImage *) kGMSTileLayerNoTileExported {
    return kGMSTileLayerNoTile;
}

+ (NSString *) kGMSLayerPanoramaFOVKeyExported {
    return kGMSLayerPanoramaFOVKey;
}

+ (NSString *) kGMSLayerPanoramaHeadingKeyExported {
    return kGMSLayerPanoramaHeadingKey;
}

+ (NSString *) kGMSLayerPanoramaPitchKeyExported {
    return kGMSLayerPanoramaPitchKey;
}

+ (NSString *) kGMSLayerPanoramaZoomKeyExported {
    return kGMSLayerPanoramaZoomKey;
}

+ (NSString *) kGMSMarkerLayerLatitudeExported {
    return kGMSMarkerLayerLatitude;
}

+ (NSString *) kGMSMarkerLayerLongitudeExported {
    return kGMSMarkerLayerLongitude;
}

+ (NSString *) kGMSMarkerLayerRotationExported {
    return kGMSMarkerLayerRotation;
}

+ (double) kGMSEarthRadiusExported {
    return kGMSEarthRadius;
}

+ (NSString *) kGMSAccessibilityCompassExported {
    return kGMSAccessibilityCompass;
}
+ (NSString *) kGMSAccessibilityMyLocationExported {
    return kGMSAccessibilityMyLocation;
}

+ (double) kGMSEquatorProjectedMeterExported {
    return kGMSEquatorProjectedMeter;
}

+ (NSString *) kGMSAutocompleteMatchAttributeExported {
    return kGMSAutocompleteMatchAttribute;
}

+ (NSString *) kGMSPlacePickerErrorDomainExported {
    return kGMSPlacePickerErrorDomain;
}

+ (NSString *) kGMSPlacesErrorDomainExported {
    return kGMSPlacesErrorDomain;
}

@end
