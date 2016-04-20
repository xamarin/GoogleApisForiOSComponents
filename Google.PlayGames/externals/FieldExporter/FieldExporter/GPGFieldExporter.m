//
//  FieldExporter.m
//  FieldExporter
//
//  Created by Jonathan Dick on 2015-07-10.
//  Copyright (c) 2015 Xamarin. All rights reserved.
//

#import "GPGFieldExporter.h"

@implementation GPGFieldExporter

+ (int) kGPGMultiplayerVariantDefaultExported {
    return kGPGMultiplayerVariantDefault;
}

+ (int) kGPGMultiplayerVariantMinExported {
    return kGPGMultiplayerVariantMin;
}

+ (int) kGPGRealTimeMinPlayersExported {
    return kGPGRealTimeMinPlayers;
}

+ (int) kGPGRealTimeMaxPlayersExported {
    return kGPGRealTimeMaxPlayers;
}

+ (int) kGPGRealTimeInvalidReliableSendIdExported {
    return kGPGRealTimeInvalidReliableSendId;
}

+ (int) kGPGTurnBasedMinPlayersExported {
    return kGPGTurnBasedMinPlayers;
}

+ (int) kGPGTurnBasedMaxPlayersExported {
    return kGPGTurnBasedMaxPlayers;
}

+ (int) kGPGTurnBasedParticipantResultPlacingUninitializedExported {
    return kGPGTurnBasedParticipantResultPlacingUninitialized;
}

@end
