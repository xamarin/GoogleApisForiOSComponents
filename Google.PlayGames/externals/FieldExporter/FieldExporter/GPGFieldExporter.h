//
//  FieldExporter.h
//  FieldExporter
//
//  Created by Jonathan Dick on 2015-07-10.
//  Copyright (c) 2015 Xamarin. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <gpg/GooglePlayGames.h>

@interface GPGFieldExporter : NSObject {
    
}

+ (int) kGPGMultiplayerVariantDefaultExported;
+ (int) kGPGMultiplayerVariantMinExported;
+ (int) kGPGRealTimeMinPlayersExported;
+ (int) kGPGRealTimeMaxPlayersExported;
+ (int) kGPGRealTimeInvalidReliableSendIdExported;
+ (int) kGPGTurnBasedMinPlayersExported;
+ (int) kGPGTurnBasedMaxPlayersExported;
+ (int) kGPGTurnBasedParticipantResultPlacingUninitializedExported;

@end
