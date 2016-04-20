//
//  GeometryUtils.m
//  libGoogleMapsExporter
//
//  Created by Alex Soto on 9/9/13.
//  Copyright (c) 2013 Alex Soto. All rights reserved.
//

#import "GeometryUtils.h"

@implementation GeometryUtils

+ (GMSMapPoint) projectWithCoordinate:(CLLocationCoordinate2D)coordinate {
    return GMSProject(coordinate);
}

+ (CLLocationCoordinate2D) unprojectWithMapPoint:(GMSMapPoint)point {
    return GMSUnproject(point);
}

+ (GMSMapPoint) mapPointInterpolateWithMapPoint:(GMSMapPoint)a andMapPoint:(GMSMapPoint)b andT:(double)t {
    return GMSMapPointInterpolate(a,b,t);
}

+ (double) mapPointDistanceFromPoint:(GMSMapPoint)a andMapPoint:(GMSMapPoint)b {
    return GMSMapPointDistance(a,b);
}

+ (BOOL) geometryContainsLocation:(CLLocationCoordinate2D)point path:(GMSPath *)path geodesic:(BOOL)geodesic {
    return GMSGeometryContainsLocation(point, path, geodesic);
}

+ (BOOL) geometryIsLocationOnPath:(CLLocationCoordinate2D)point path:(GMSPath *)path geodesic:(BOOL)geodesic tolerance:(CLLocationDistance)tolerance {
    return GMSGeometryIsLocationOnPathTolerance(point, path, geodesic, tolerance);
}

+ (BOOL) geometryIsLocationOnPath:(CLLocationCoordinate2D)point path:(GMSPath *)path geodesic:(BOOL)geodesic {
    return GMSGeometryIsLocationOnPath(point, path, geodesic);
}

+ (CLLocationDistance) geometryDistance:(CLLocationCoordinate2D)from to:(CLLocationCoordinate2D)to {
    return GMSGeometryDistance(from, to);
}

+ (CLLocationDistance) geometryLength:(GMSPath *)path {
    return GMSGeometryLength(path);
}

+ (double) geometryArea:(GMSPath *)path {
    return GMSGeometryArea(path);
}

+ (double) geometrySignedArea:(GMSPath *)path {
    return GMSGeometrySignedArea(path);
}

+ (CLLocationDirection) geometryHeading:(CLLocationCoordinate2D)from to:(CLLocationCoordinate2D)to {
    return GMSGeometryHeading(from, to);
}

+ (CLLocationCoordinate2D) geometryOffset:(CLLocationCoordinate2D)from distance:(CLLocationDistance)distance heading:(CLLocationDirection)heading {
    return GMSGeometryOffset(from, distance, heading);
}

+ (CLLocationCoordinate2D) geometryInterpolate:(CLLocationCoordinate2D)from to:(CLLocationCoordinate2D)to fraction:(double)fraction {
    return GMSGeometryInterpolate(from, to, fraction);
}

+ (NSArray *) styleSpansFrom:(GMSPath *)path andStyles:(NSArray *)styles andLengths:(NSArray *)lengths andLenghtKind:(GMSLengthKind)lengthKind {
    return GMSStyleSpans(path, styles, lengths, lengthKind);
}

+ (NSArray *) styleSpansFrom:(GMSPath *)path andStyles:(NSArray *)styles andLengths:(NSArray *)lengths andLenghtKind:(GMSLengthKind)lengthKind andLengthOffset:(double)lengthOffset {
    return GMSStyleSpansOffset(path, styles, lengths, lengthKind, lengthOffset);
}

@end
