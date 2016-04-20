//
//  GeometryUtils.h
//  libGoogleMapsExporter
//
//  Created by Alex Soto on 9/9/13.
//  Copyright (c) 2013 Alex Soto. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GoogleMaps/GoogleMaps.h>

@interface GeometryUtils : NSObject {
    
}

+ (GMSMapPoint) projectWithCoordinate:(CLLocationCoordinate2D)coordinate;

+ (CLLocationCoordinate2D) unprojectWithMapPoint:(GMSMapPoint)point;

+ (GMSMapPoint) mapPointInterpolateWithMapPoint:(GMSMapPoint)a andMapPoint:(GMSMapPoint)b andT:(double)t;

+ (double) mapPointDistanceFromPoint:(GMSMapPoint)a andMapPoint:(GMSMapPoint)b;

+ (BOOL) geometryContainsLocation:(CLLocationCoordinate2D)point path:(GMSPath *)path geodesic:(BOOL)geodesic;

+ (BOOL) geometryIsLocationOnPath:(CLLocationCoordinate2D)point path:(GMSPath *)path geodesic:(BOOL)geodesic tolerance:(CLLocationDistance)tolerance;

+ (BOOL) geometryIsLocationOnPath:(CLLocationCoordinate2D)point path:(GMSPath *)path geodesic:(BOOL)geodesic;

+ (CLLocationDistance) geometryDistance:(CLLocationCoordinate2D)from to:(CLLocationCoordinate2D)to;

+ (CLLocationDistance) geometryLength:(GMSPath *)path;

+ (double) geometryArea:(GMSPath *)path;

+ (double) geometrySignedArea:(GMSPath *)path;

+ (CLLocationDirection) geometryHeading:(CLLocationCoordinate2D)from to:(CLLocationCoordinate2D)to;

+ (CLLocationCoordinate2D) geometryOffset:(CLLocationCoordinate2D)from distance:(CLLocationDistance)distance heading:(CLLocationDirection)heading;

+ (CLLocationCoordinate2D) geometryInterpolate:(CLLocationCoordinate2D)from to:(CLLocationCoordinate2D)to fraction:(double)fraction;

+ (NSArray *) styleSpansFrom:(GMSPath *)path andStyles:(NSArray *)styles andLengths:(NSArray *)lengths andLenghtKind:(GMSLengthKind)lengthKind;

+ (NSArray *) styleSpansFrom:(GMSPath *)path andStyles:(NSArray *)styles andLengths:(NSArray *)lengths andLenghtKind:(GMSLengthKind)lengthKind andLengthOffset:(double)lengthOffset;

@end
