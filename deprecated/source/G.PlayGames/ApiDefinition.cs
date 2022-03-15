using Foundation;
using ObjCRuntime;
using UIKit;
using System;

#region "PlayGameServices"
namespace Google.Play.GameServices
{
	[Static]
	interface PlayGamesConstants
	{
		[Field ("GPGErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		[Field ("kGPGMultiplayerVariantDefault", "__Internal")]
		int MultiplayerVariantDefault { get; }

		[Field ("kGPGMultiplayerVariantMin", "__Internal")]
		int MultiplayerVariantMin { get; }

		[Field ("kGPGRealTimeMinPlayers", "__Internal")]
		int RealTimeMinPlayers { get; }

		[Field ("kGPGRealTimeMaxPlayers", "__Internal")]
		int RealTimeMaxPlayers { get; }

		[Field ("kGPGRealTimeInvalidReliableSendId", "__Internal")]
		int RealTimeInvalidReliableSendId { get; }

		[Field ("kGPGTurnBasedMinPlayers", "__Internal")]
		int TurnBasedMinPlayers { get; }

		[Field ("kGPGTurnBasedMaxPlayers", "__Internal")]
		int TurnBasedMaxPlayers { get; }

		[Field ("kGPGTurnBasedParticipantResultPlacingUninitialized", "__Internal")]
		int TurnBasedParticipantResultPlacingUninitialized { get; }
	}

	delegate void AchievementDidUnlockHandler (bool newlyUnlocked,NSError error);
	delegate void AchievementDidRevealHandler (AchievementState state,NSError error);
	delegate void AchievementDidIncrementHandler (bool newlyUnlocked,int currentSteps,NSError error);
	delegate void AchievementDidSetStepsHandler (bool newlyUnlocked,int currentSteps,NSError error);
	delegate void AchievementDidResetHandler (NSError error);
	delegate void AllAchievementsDidResetHandler (NSError error);

	[BaseType (typeof(NSObject), Name = "GPGAchievement")]
	interface Achievement
	{

		[Export ("initWithAchievementId:")]
		IntPtr Constructor (string achievementId);

		[Static]
		[Export ("achievementWithId:")]
		Achievement FromAchievementId (string achievementId);

		[Export ("achievementId", ArgumentSemantic.Copy)]
		string AchievementId { get; }

		[Export ("showsCompletionNotification", ArgumentSemantic.Assign)]
		bool ShowsCompletionNotification { get; set; }

		[Export ("unlockAchievementWithCompletionHandler:")]
		void UnlockAchievement (AchievementDidUnlockHandler completionHandler);

		[Export ("revealAchievementWithCompletionHandler:")]
		void RevealAchievement (AchievementDidRevealHandler completionHandler);

		[Export ("incrementAchievementNumSteps:completionHandler:")]
		void IncrementAchievement (nint steps, AchievementDidIncrementHandler completionHandler);

		[Export ("setSteps:completionHandler:")]
		void SetSteps (nint steps, AchievementDidSetStepsHandler completionHandler);

		[Export ("resetAchievementWithCompletionHandler:")]
		void ResetAchievement (AchievementDidResetHandler completionHandler);

		[Static]
		[Export ("resetAllAchievementsWithCompletionHandler:")]
		void ResetAllAchievements (AllAchievementsDidResetHandler completionHandler);
	}

	delegate void AchievementMetadataHandler (AchievementMetadata metadata,NSError error);
	delegate void AchievementAllMetadataHandler (AchievementMetadata[] metadata,NSError error);

	[BaseType (typeof(NSObject), Name = "GPGAchievementMetadata")]
	interface AchievementMetadata
	{

		[Export ("achievementId", ArgumentSemantic.Copy)]
		string AchievementId { get; }

		[Export ("state", ArgumentSemantic.Assign)]
		AchievementState State { get; }

		[Export ("type", ArgumentSemantic.Assign)]
		AchievementType AchType { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("achievementDescription", ArgumentSemantic.Copy)]
		string AchievementDescription { get; }

		[Export ("revealedIconUrl", ArgumentSemantic.Copy)]
		NSUrl RevealedIconUrl { get; }

		[Export ("unlockedIconUrl", ArgumentSemantic.Copy)]
		NSUrl UnlockedIconUrl { get; }

		[Export ("completedSteps", ArgumentSemantic.Assign)]
		int CompletedSteps { get; }

		[Export ("numberOfSteps", ArgumentSemantic.Assign)]
		int NumberOfSteps { get; }

		[Export ("formattedCompletedSteps", ArgumentSemantic.Copy)]
		string FormattedCompletedSteps { get; }

		[Export ("formattedNumberOfSteps", ArgumentSemantic.Copy)]
		string FormattedNumberOfSteps { get; }

		[Export ("lastUpdatedTimestamp", ArgumentSemantic.Assign)]
		long LastUpdatedTimestamp { get; }

		[Export ("progress", ArgumentSemantic.Assign)]
		nfloat Progress { get; }

		[Export ("experiencePoints", ArgumentSemantic.Assign)]
		int ExperiencePoints { get; }

		// @required + (void)metadataForAchievementId:(NSString *)achievementId completionHandler:(GPGAchievementMetadataBlock)completionHandler;
		[Static]
		[Export ("metadataForAchievementId:completionHandler:")]
		void MetadataForAchievementId (string achievementId, AchievementMetadataHandler completionHandler);

		[Static]
		[Export ("metadataForAchievementId:dataSource:completionHandler:")]
		void MetadataForAchievementId (string achievementId, DataSource dataSource, AchievementMetadataHandler completionHandler);

		// @required + (void)allMetadataWithCompletionHandler:(GPGAchievementAllMetadataBlock)completionHandler;
		[Static]
		[Export ("allMetadataWithCompletionHandler:")]
		void AllMetadata (AchievementAllMetadataHandler completionHandler);

		// @required + (void)allMetadataFromDataSource:(GPGDataSource)dataSource completionHandler:(GPGAchievementAllMetadataBlock)completionHandler;
		[Static]
		[Export ("allMetadataFromDataSource:completionHandler:")]
		void AllMetadata (DataSource dataSource, Action<NSArray, NSError> completionHandler);

	}


	//    [Obsolete]
	//    [BaseType (typeof (KeyedModel), Name = "GPGApplicationModel")]
	//    interface ApplicationModel {
	//
	//        [Field ("GPGModelGetAllAppStateKey", "__Internal")]
	//        NSString ModelGetAllAppStateKey { get; }
	//
	//        [Export ("initWithApplicationId:")]
	//        IntPtr Constructor (string applicationId);
	//
	//        [Obsolete]
	//        [Export ("appState", ArgumentSemantic.Strong)]
	//        AppStateModel AppState { get; }
	//    }

	[Obsolete]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "GPGAppStateListInfo")]
	interface AppStateListInfo
	{

		[Export ("dataIsStale", ArgumentSemantic.Assign)]
		bool DataIsStale { get; set; }

		[Export ("key", ArgumentSemantic.Copy)]
		NSNumber Key { get; set; }
	}

	delegate void AppStateListHandler (NSNumber key,NSData state,NSError error);
	delegate void AppStateListKeysHandler (NSData[] states,NSNumber maxKeyCount,NSError error);
	delegate void AppStateLoadResultHandler (AppStateLoadStatus status,NSError error);
	delegate void AppStateWriteResultHandler (AppStateWriteStatus status,NSError error);
	delegate NSData AppStateConflictHandler (NSNumber key,NSData localState,NSData remoteState);

	[Obsolete]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "GPGAppStateModel")]
	interface AppStateModel
	{

		[Export ("setStateData:forKey:")]
		void SetStateData (NSData state, NSNumber key);

		[Export ("stateDataForKey:")]
		NSData StateData (NSNumber key);

		[Export ("listStatesWithCompletionHandler:conflictHandler:")]
		void ListStates (AppStateListHandler completionHandler, AppStateConflictHandler conflictHandler);

		[Export ("listStateKeysWithCompletionHandler:")]
		void ListStateKeys (AppStateListKeysHandler completionHandler);

		[Export ("loadForKey:completionHandler:conflictHandler:")]
		void Load (NSNumber key, AppStateLoadResultHandler completionHandler, AppStateConflictHandler conflictHandler);

		[Export ("updateForKey:completionHandler:conflictHandler:")]
		void Update (NSNumber key, AppStateWriteResultHandler completionHandler, AppStateConflictHandler conflictHandler);

		[Export ("clearForKey:completionHandler:conflictHandler:")]
		void Clear (NSNumber key, AppStateWriteResultHandler completionHandler, AppStateConflictHandler conflictHandler);

		[Export ("deleteForKey:completionHandler:")]
		void Delete (NSNumber key, AppStateWriteResultHandler completionHandler);
	}

	delegate void EventListHandler (Event[] events,NSError error);
	delegate void EventOperationHandler (Event events,NSError error);

	[BaseType (typeof(NSObject), Name = "GPGEvent")]
	interface Event
	{

		[Export ("count")]
		ulong Count { get; }

		[Export ("eventDescription", ArgumentSemantic.Copy)]
		string EventDescription { get; }

		[Export ("eventId", ArgumentSemantic.Copy)]
		string EventId { get; }

		[Export ("imageUrl", ArgumentSemantic.Copy)]
		NSUrl ImageUrl { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("visible")]
		bool Visible { get; }

		[Static]
		[Export ("allEventsWithCompletionHandler:")]
		void AllEvents (EventListHandler completionHandler);

		[Static]
		[Export ("eventForId:completionHandler:")]
		void EventFromId (string eventId, EventOperationHandler completionHandler);

		[Export ("increment")]
		void Increment ();

		[Export ("incrementBy:")]
		void IncrementBy (ulong steps);

		[Export ("incrementWithCompletionHandler:")]
		void Increment (EventOperationHandler completionHandler);

		[Export ("incrementBy:completionHandler:")]
		void IncrementBy (ulong steps, EventOperationHandler completionHandler);
	}

	delegate void ModelDidLoadHandler (NSError error);

	[Obsolete]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "GPGKeyedModel")]
	interface KeyedModel
	{

		[Obsolete]
		[Export ("loadDataForKey:")]
		void LoadData (string key);

		[Obsolete]
		[Export ("loadDataForKey:completionHandler:")]
		void LoadData (string key, ModelDidLoadHandler completionHandler);

		[Obsolete]
		[Export ("reloadDataForKey:")]
		void ReloadData (string key);

		[Obsolete]
		[Export ("reloadDataForKey:completionHandler:")]
		void ReloadData (string key, ModelDidLoadHandler completionHandler);

		[Obsolete]
		[Export ("isLoadingDataForKey:")]
		bool IsLoadingData (string key);

		[Obsolete]
		[Export ("isDataLoadedForKey:")]
		bool IsDataLoaded (string key);

		[Obsolete]
		[Export ("errorFromLoadingDataForKey:")]
		NSError ErrorFromLoadingData (string key);
	}

	interface ILauncherDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "GPGLauncherDelegate")]
	interface LauncherDelegate
	{

		[Obsolete]
		[Export ("presentingViewControllerForLauncher")]
		UIViewController PresentingViewControllerForLauncher ();

		[Export ("launcherWillAppear")]
		void LauncherWillAppear ();

		[Export ("launcherDidAppear")]
		void LauncherDidAppear ();

		[Export ("launcherWillDisappear")]
		void LauncherWillDisappear ();

		[Export ("launcherDidDisappear")]
		void LauncherDidDisappear ();

		[Export ("launcherDismissed")]
		void LauncherDismissed ();
	}

	interface IPlayerPickerLauncherDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "GPGPlayerPickerLauncherDelegate")]
	interface PlayerPickerLauncherDelegate
	{

		[Abstract]
		[Export ("minPlayersForPlayerPickerLauncher")]
		int MinPlayers ();

		[Abstract]
		[Export ("maxPlayersForPlayerPickerLauncher")]
		int MaxPlayers ();

		[Abstract]
		[Export ("playerPickerLauncherDidPickPlayers:autoPickPlayerCount:")]
		void DidPickPlayers (Player[] players, int autoPickPlayerCount);
	}

	interface ITurnBasedMatchListLauncherDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "GPGTurnBasedMatchListLauncherDelegate")]
	interface TurnBasedMatchListLauncherDelegate
	{

		[Abstract]
		[Export ("turnBasedMatchListLauncherDidJoinMatch:")]
		void MatchJoined (TurnBasedMatch match);

		[Abstract]
		[Export ("turnBasedMatchListLauncherDidSelectMatch:")]
		void MatchSelected (TurnBasedMatch match);

		[Abstract]
		[Export ("turnBasedMatchListLauncherDidRematch:")]
		void DidRematch (TurnBasedMatch match);

		[Export ("turnBasedMatchListLauncherDidDeclineMatch:")]
		void MatchDeclined (TurnBasedMatch match);
	}

	interface IQuestListLauncherDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "GPGQuestListLauncherDelegate")]
	interface QuestListLauncherDelegate
	{

		[Abstract]
		[Export ("questListLauncherDidAcceptQuest:")]
		void QuestAccepted (Quest quest);

		[Abstract]
		[Export ("questListLauncherDidClaimRewardsForQuestMilestone:")]
		void RewardsClaimedForQuestMilestone (QuestMilestone milestone);

		[Export ("questListLauncherShouldShowQuest:")]
		bool ShouldShowQuest (Quest quest);
	}

	interface ISnapshotListLauncherDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "GPGSnapshotListLauncherDelegate")]
	interface SnapshotListLauncherDelegate
	{

		[Abstract]
		[Export ("snapshotListLauncherDidTapSnapshotMetadata:")]
		void SnapshotMetadataTapped (SnapshotMetadata snapshot);

		[Abstract]
		[Export ("snapshotListLauncherDidCreateNewSnapshot")]
		void NewSnapshotCreated ();

		[Export ("titleForSnapshotListLauncher")]
		string TitleForSnapshotListLauncher ();

		[Export ("shouldAllowCreateForSnapshotListLauncher")]
		bool ShouldAllowCreate ();

		[Export ("shouldAllowDeleteForSnapshotListLauncher")]
		bool ShouldAllowDelete ();

		[Export ("maxSaveSlotsForSnapshotListLauncher")]
		int MaxSaveSlots ();
	}


	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GPGLauncherController")]
	interface LauncherController
	{

		[NullAllowed]
		[Export ("launcherDelegate", ArgumentSemantic.Assign)]
		ILauncherDelegate LauncherDelegate { get; set; }

		[NullAllowed]
		[Export ("playerPickerLauncherDelegate", ArgumentSemantic.Assign)]
		IPlayerPickerLauncherDelegate PlayerPickerLauncherDelegate { get; set; }

		[NullAllowed]
		[Export ("turnBasedMatchListLauncherDelegate", ArgumentSemantic.Assign)]
		ITurnBasedMatchListLauncherDelegate TurnBasedMatchListLauncherDelegate { get; set; }

		[NullAllowed]
		[Export ("questListLauncherDelegate", ArgumentSemantic.Assign)]
		IQuestListLauncherDelegate QuestListLauncherDelegate { get; set; }

		[NullAllowed]
		[Export ("snapshotListLauncherDelegate", ArgumentSemantic.Assign)]
		ISnapshotListLauncherDelegate SnapshotListLauncherDelegate { get; set; }

		[Export ("presentingLauncherType", ArgumentSemantic.Assign)]
		LauncherType PresentingLauncherType { get; }

		[Static]
		[Export ("sharedInstance")]
		LauncherController SharedInstance { get; }

		[Export ("presentPlayerPicker")]
		void PresentPlayerPicker ();

		[Export ("presentTurnBasedMatchList")]
		void PresentTurnBasedMatchList ();

		[Export ("presentTurnBasedMatchListWithMatches:")]
		void PresentTurnBasedMatchList (TurnBasedMatch[] matches);

		[Export ("presentQuestList")]
		void PresentQuestList ();

		[Export ("presentQuestListWithQuestId:")]
		void PresentQuestList (string questId);

		[Export ("presentSnapshotList")]
		void PresentSnapshotList ();

		[Export ("presentLeaderboardWithLeaderboardId:")]
		void PresentLeaderboard (string leaderboardId);

		[Export ("presentLeaderboardWithLeaderboardId:andTimeScope:")]
		void PresentLeaderboard (string leaderboardId, LeaderboardTimeScope timeScope);

		[Export ("presentLeaderboardList")]
		void PresentLeaderboardList ();

		[Export ("presentAchievementList")]
		void PresentAchievementList ();

		[Export ("presentRealTimeInvitesWithRoomDataList:")]
		void PresentRealTimeInvites (RealTimeRoomData[] roomDataList);

		[Export ("presentRealTimeInviteWithMinPlayers:maxPlayers:exclusiveBitMask:variant:")]
		void PresentRealTimeInvite (int minPlayers, int maxPlayers, ulong exclusiveBitMask, int variant);

		[Export ("presentRealTimeInviteWithMinPlayers:maxPlayers:")]
		void PresentRealTimeInvite (int minPlayers, int maxPlayers);

		[Export ("presentRealTimeWaitingRoomWithConfig:")]
		void PresentRealTimeWaitingRoom (MultiplayerConfig config);

		[Export ("presentRealTimeWaitingRoomWithRoomData:")]
		void PresentRealTimeWaitingRoom (RealTimeRoomData roomData);

		[Export ("presentSettings")]
		void PresentSettings ();

		[Export ("dismissAnimated:completionHandler:")]
		void Dismiss (bool animated, Action completionHandler);
	}

	delegate void LeaderboardLoadScoresHandler (Score[] scores,NSError error);
	delegate void LeaderboardResetScoresHandler (NSError error);

	[BaseType (typeof(NSObject), Name = "GPGLeaderboard")]
	interface Leaderboard
	{

		[Export ("initWithLeaderboardId:")]
		IntPtr Constructor (string leaderboardId);

		[Static]
		[Export ("leaderboardWithId:")]
		Leaderboard FromLeaderboardId (string leaderboardId);

		[Export ("leaderboardId", ArgumentSemantic.Copy)]
		string LeaderboardId { get; }

		[Export ("personalWindow", ArgumentSemantic.Assign)]
		bool PersonalWindow { [Bind ("isPersonalWindow")] get; set; }

		[Export ("timeScope", ArgumentSemantic.Assign)]
		LeaderboardTimeScope TimeScope { get; set; }

		[Export ("social", ArgumentSemantic.Assign)]
		bool Social { [Bind ("isSocial")] get; set; }

		[Export ("loadScoresWithCompletionHandler:")]
		void LoadScores (LeaderboardLoadScoresHandler completionHandler);

		[Export ("loadScoresFromDataSource:completionHandler:")]
		void LoadScores (DataSource dataSource, LeaderboardLoadScoresHandler completionHandler);

		[Export ("loadNextPageOfScoresWithCompletionHandler:")]
		void LoadNextPageOfScores (LeaderboardLoadScoresHandler completionHandler);

		[Export ("loadPreviousPageOfScoresWithCompletionHandler:")]
		void LoadPreviousPageOfScores (LeaderboardLoadScoresHandler completionHandler);

		[Export ("resetScoreWithCompletionHandler:")]
		void ResetScore (LeaderboardResetScoresHandler completionHandler);

		[Export ("loading")]
		bool IsLoading { [Bind ("isLoading")] get; }

		[Export ("loadingPreviousPage", ArgumentSemantic.Assign)]
		bool IsLoadingPreviousPage { get; }

		[Export ("loadingNextPage", ArgumentSemantic.Assign)]
		bool IsLoadingNextPage { get; }

		[Export ("scores", ArgumentSemantic.Copy)]
		Score [] Scores { get; }

		[Export ("localPlayerScore", ArgumentSemantic.Retain)]
		LocalPlayerScore LocalPlayerScore { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("hasPreviousPage", ArgumentSemantic.Assign)]
		bool HasPreviousPage { get; }

		[Export ("hasNextPage", ArgumentSemantic.Assign)]
		bool HasNextPage { get; }
	}

	delegate void LeaderboardAllMetadataHandler (LeaderboardMetadata[] metadata,NSError error);
	delegate void LeaderboardMetadataHandler (LeaderboardMetadata metadata,NSError error);

	[BaseType (typeof(NSObject), Name = "GPGLeaderboardMetadata")]
	interface LeaderboardMetadata
	{

		[Export ("iconUrl", ArgumentSemantic.Copy)]
		NSUrl IconUrl { get; }

		[Export ("leaderboardId", ArgumentSemantic.Copy)]
		string LeaderboardId { get; }

		[Export ("order", ArgumentSemantic.Assign)]
		LeaderboardOrder Order { get; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; }

		[Static]
		[Export ("allMetadataWithCompletionHandler:")]
		void AllMetadata (LeaderboardAllMetadataHandler completionHandler);

		[Static]
		[Export ("allMetadataFromDataSource:completionHandler:")]
		void AllMetadata (DataSource dataSource, LeaderboardAllMetadataHandler completionHandler);

		[Static]
		[Export ("metadataForLeaderboardId:completionHandler:")]
		void MetadataForLeaderboardId (string leaderboardId, LeaderboardMetadataHandler completionHandler);

		[Static]
		[Export ("metadataForLeaderboardId:dataSource:completionHandler:")]
		void MetadataForLeaderboardId (string leaderboardId, DataSource dataSource, LeaderboardMetadataHandler completionHandler);
	}

	[BaseType (typeof(NSObject), Name = "GPGLocalPlayerRank")]
	interface LocalPlayerRank
	{

		[Export ("formattedRank", ArgumentSemantic.Copy)]
		string FormattedRank { get; }

		[Export ("formattedNumScores", ArgumentSemantic.Copy)]
		string FormattedNumScores { get; }

		[Export ("numScores", ArgumentSemantic.Assign)]
		long NumScores { get; }

		[Export ("rank", ArgumentSemantic.Assign)]
		long Rank { get; }
	}

	[BaseType (typeof(NSObject), Name = "GPGLocalPlayerScore")]
	interface LocalPlayerScore
	{

		[Export ("publicRank", ArgumentSemantic.Retain)]
		LocalPlayerRank PublicRank { get; }

		[Export ("leaderboardId", ArgumentSemantic.Copy)]
		string LeaderboardId { get; }

		[Export ("scoreString", ArgumentSemantic.Copy)]
		string ScoreString { get; }

		[Export ("scoreValue", ArgumentSemantic.Assign)]
		ulong ScoreValue { get; }

		[Export ("scoreTag", ArgumentSemantic.Copy)]
		string ScoreTag { get; }

		[Export ("socialRank", ArgumentSemantic.Retain)]
		LocalPlayerRank SocialRank { get; }

		[Export ("writeTimestamp", ArgumentSemantic.Assign)]
		long WriteTimestamp { get; }
	}

	interface IStatusDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "GPGStatusDelegate")]
	interface StatusDelegate
	{

		[Export ("didFinishGamesSignInWithError:")]
		void GamesSignInFinished (NSError error);

		[Export ("didFinishGamesSignOutWithError:")]
		void GamesSignOutFinished (NSError error);

		[Export ("didFinishGoogleAuthWithError:")]
		void GoogleAuthFinished (NSError error);

		[Export ("shouldReauthenticateWithError:")]
		bool ShouldReauthenticate (NSError error);

		[Export ("willReauthenticate:")]
		void WillReauthenticate (NSError error);

		[Export ("didDisconnectWithError:")]
		void Disconnected (NSError error);
	}

	interface ITurnBasedMatchDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "GPGTurnBasedMatchDelegate")]
	interface TurnBasedMatchDelegate
	{

		[Export ("didReceiveTurnBasedInviteForMatch:participant:fromPushNotification:")]
		void TurnBasedInviteReceived (TurnBasedMatch match, TurnBasedParticipant participant, bool fromPushNotification);

		[Export ("didReceiveTurnEventForMatch:participant:fromPushNotification:")]
		void TurnEventReceived (TurnBasedMatch match, TurnBasedParticipant participant, bool fromPushNotification);

		[Export ("matchEnded:participant:fromPushNotification:")]
		void MatchEnded (TurnBasedMatch match, TurnBasedParticipant participant, bool fromPushNotification);

		[Export ("failedToProcessMatchUpdate:error:")]
		void FailedToProcessMatchUpdate (TurnBasedMatch match, NSError error);
	}

	delegate void ReAuthenticationHandler (bool requiresKeychainWipe,NSError error);
	delegate void RevisionCheckHandler (RevisionStatus revisionStatus,NSError error);

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "GPGManager")]
	interface Manager
	{
		
		[Static]
		[Export ("sharedInstance")]
		Manager SharedInstance { get; }

		//        [Obsolete]
		//        [Export ("applicationModel", ArgumentSemantic.Strong)]
		//        ApplicationModel ApplicationModel { get; }

		[Obsolete]
		[Export ("applicationId")]
		string ApplicationId { get; }

		[Export ("signout")]
		void Signout ();

		[Export ("signIn")]
		void SignIn ();

		[Export ("signInWithClientID:silently:")]
		bool SignIn (string clientID, bool silently);

		[Export ("signInWithClientID:silently:withExtraScopes:")]
		bool SignIn (string clientID, bool silently, NSObject[] scopes);

		[Export ("tryHandleRemoteNotification:")]
		bool TryHandleRemoteNotification (NSDictionary userInfo);

		[Export ("tryHandleRemoteNotification:forActionWithIdentifier:completionHandler:")]
		bool TryHandleRemoteNotification (NSDictionary userInfo, string identifier, Action completionHandler);

		[Export ("registerDeviceToken:forEnvironment:")]
		void RegisterDeviceToken (NSData deviceTokenData, PushNotificationEnvironment environment);

		[Export ("unregisterCurrentDeviceToken")]
		void UnregisterCurrentDeviceToken ();

		[Introduced (PlatformName.iOS, 8, 0)]
		[Static]
		[Export ("registerForInteractiveGamesNotificationsWithType:")]
		void RegisterForInteractiveGamesNotifications (UIUserNotificationType type);

		[NullAllowed]
		[Export ("turnBasedMatchDelegate", ArgumentSemantic.Weak)]
		ITurnBasedMatchDelegate TurnBasedMatchDelegate { get; set; }

		[NullAllowed]
		[Export ("realTimeRoomDelegate", ArgumentSemantic.Weak)]
		IRealTimeRoomDelegate RealTimeRoomDelegate { get; set; }

		[NullAllowed]
		[Export ("statusDelegate", ArgumentSemantic.Weak)]
		IStatusDelegate StatusDelegate { get; set; }

		[NullAllowed]
		[Export ("questDelegate", ArgumentSemantic.Weak)]
		IQuestDelegate QuestDelegate { get; set; }

		[Export ("appStateEnabled", ArgumentSemantic.Assign)]
		bool AppStateEnabled { get; set; }

		[Export ("snapshotsEnabled", ArgumentSemantic.Assign)]
		bool SnapshotsEnabled { get; set; }

		[Export ("signedIn", ArgumentSemantic.Assign)]
		bool SignedIn { [Bind ("isSignedIn")] get; }

		[Export ("sdkTag", ArgumentSemantic.Assign)]
		nuint SdkTag { get; set; }

		[Obsolete]
		[Export ("validOrientationFlags", ArgumentSemantic.Assign)]
		nuint ValidOrientationFlags { get; set; }

		[Export ("welcomeBackOffset", ArgumentSemantic.Assign)]
		nuint WelcomeBackOffset { get; set; }

		[Export ("welcomeBackToastPlacement", ArgumentSemantic.Assign)]
		ToastPlacement WelcomeBackToastPlacement { get; set; }

		[Export ("achievementUnlockedOffset", ArgumentSemantic.Assign)]
		nuint AchievementUnlockedOffset { get; set; }

		[Export ("achievementUnlockedToastPlacement", ArgumentSemantic.Assign)]
		ToastPlacement AchievementUnlockedToastPlacement { get; set; }

		[Export ("questCompletedOffset", ArgumentSemantic.Assign)]
		nuint QuestCompletedOffset { get; set; }

		[Export ("questCompletedToastPlacement", ArgumentSemantic.Assign)]
		ToastPlacement QuestCompletedToastPlacement { get; set; }

		[Export ("refreshRevisionStatus:")]
		void RefreshRevisionStatus (RevisionCheckHandler revisionCheckHandler);

		[Export ("revisionStatus")]
		RevisionStatus RevisionStatus { get; }

		[Export ("revisionValid")]
		bool IsRevisionValid { [Bind ("isRevisionValid")] get; }
	}

	[BaseType (typeof(NSObject), Name = "GPGMultiplayerConfig")]
	interface MultiplayerConfig
	{

		[Export ("exclusiveBitMask", ArgumentSemantic.Assign)]
		ulong ExclusiveBitMask { get; set; }

		[Export ("invitedPlayerIds", ArgumentSemantic.Copy)]
		string [] InvitedPlayerIds { get; set; }

		[Export ("maxAutoMatchingPlayers", ArgumentSemantic.Assign)]
		int MaxAutoMatchingPlayers { get; set; }

		[Export ("minAutoMatchingPlayers", ArgumentSemantic.Assign)]
		int MinAutoMatchingPlayers { get; set; }

		[Export ("variant", ArgumentSemantic.Assign)]
		int Variant { get; set; }
	}

	delegate void GetPlayerHandler (Player player,NSError error);
	delegate void GetPlayersHandler (Player[] players,NSError error);

	[BaseType (typeof(NSObject), Name = "GPGPlayer")]
	interface Player
	{

		[Export ("imageUrl", ArgumentSemantic.Copy)]
		NSUrl ImageUrl { get; }

		[Export ("displayName", ArgumentSemantic.Copy)]
		string DisplayName { get; }

		[Export ("playerId", ArgumentSemantic.Copy)]
		string PlayerId { get; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; }

		[Export ("currentExperiencePoints", ArgumentSemantic.Assign)]
		long CurrentExperiencePoints { get; }

		[Export ("lastLevelUpTimestamp", ArgumentSemantic.Assign)]
		long LastLevelUpTimestamp { get; }

		[Export ("currentLevel", ArgumentSemantic.Copy)]
		PlayerLevel CurrentLevel { get; }

		[Export ("nextLevel", ArgumentSemantic.Copy)]
		PlayerLevel NextLevel { get; }

		[Static]
		[Export ("localPlayerWithCompletionHandler:")]
		void LocalPlayer (GetPlayerHandler completionHandler);

		[Static]
		[Export ("localPlayerFromDataSource:completionHandler:")]
		void LocalPlayer (DataSource dataSource, GetPlayerHandler completionHandler);

		[Static]
		[Export ("recentlyPlayedPlayersWithCompletionHandler:")]
		void RecentlyPlayedPlayers (GetPlayersHandler completionHandler);

		[Static]
		[Export ("recentlyPlayedPlayersFromDataSource:completionHandler:")]
		void RecentlyPlayedPlayers (DataSource dataSource, GetPlayersHandler completionHandler);

		[Static]
		[Export ("connectedPlayersWithCompletionHandler:")]
		void ConnectedPlayers (GetPlayersHandler completionHandler);

		[Static]
		[Export ("connectedPlayersFromDataSource:completionHandler:")]
		void ConnectedPlayers (DataSource dataSource, GetPlayersHandler completionHandler);
	}

	[BaseType (typeof(NSObject), Name = "GPGPlayerLevel")]
	interface PlayerLevel
	{

		[Export ("level", ArgumentSemantic.Assign)]
		int Level { get; }

		[Export ("minExperiencePoints", ArgumentSemantic.Assign)]
		ulong MinExperiencePoints { get; }

		[Export ("maxExperiencePoints", ArgumentSemantic.Assign)]
		ulong MaxExperiencePoints { get; }
	}

	// typedef void (^GPGPlayerStatsGetBlock)(GPGPlayerStats *playerStats, NSError *error);
	delegate void PlayerStatsGetHandler (PlayerStats playerStats,NSError error);

	// @interface GPGPlayerStats : NSObject
	[BaseType (typeof(NSObject), Name = "GPGPlayerStats")]
	interface PlayerStats
	{
		// @property(nonatomic, readonly, assign) float averageSessionLength;
		[Export ("averageSessionLength", ArgumentSemantic.Assign)]
		float AverageSessionLength { get; }

		// @property(nonatomic, readonly, assign) float churnProbability;
		[Export ("churnProbability", ArgumentSemantic.Assign)]
		float ChurnProbability { get; }

		// @property(nonatomic, readonly, assign) int64_t daysSinceLastPlayed;
		[Export ("daysSinceLastPlayed", ArgumentSemantic.Assign)]
		long DaysSinceLastPlayed { get; }

		// @property(nonatomic, readonly, assign) int64_t numberOfPurchases;
		[Export ("numberOfPurchases", ArgumentSemantic.Assign)]
		long NumberOfPurchases { get; }

		// @property(nonatomic, readonly, assign) int64_t numberOfSessions;
		[Export ("numberOfSessions", ArgumentSemantic.Assign)]
		long NumberOfSessions { get; }

		// @property(nonatomic, readonly, assign) float sessionPercentile;
		[Export ("sessionPercentile", ArgumentSemantic.Assign)]
		float SessionPercentile { get; }

		// @property(nonatomic, readonly, assign) float spendPercentile;
		[Export ("spendPercentile", ArgumentSemantic.Assign)]
		float SpendPercentile { get; }

		// + (void)playerStatsWithCompletionHandler:(GPGPlayerStatsGetBlock)completionHandler;
		[Static]
		[Export ("playerStatsWithCompletionHandler:")]
		void GetPlayerStats (PlayerStatsGetHandler completionHandler);

		// + (void)playerStatsFromDataSource:(GPGDataSource)dataSource completionHandler:(GPGPlayerStatsGetBlock)completionHandler;
		[Static]
		[Export ("playerStatsFromDataSource:completionHandler:")]
		void GetPlayerStats (DataSource dataSource, PlayerStatsGetHandler completionHandler);
	}

	interface IQuestDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "GPGQuestDelegate")]
	interface QuestDelegate
	{

		[Export ("didCompleteQuest:")]
		void QuestCompleted (Quest quest);
	}


	delegate void QuestFetchHandler (Quest quest,NSError error);
	delegate void QuestListHandler (Quest[] quest,NSError error);
	delegate void QuestCompletionHandler (NSError error);

	[BaseType (typeof(NSObject), Name = "GPGQuest")]
	interface Quest
	{

		[Export ("questId", ArgumentSemantic.Copy)]
		string QuestId { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("questDescription", ArgumentSemantic.Copy)]
		string QuestDescription { get; }

		[Export ("iconUrl", ArgumentSemantic.Copy)]
		NSUrl IconUrl { get; }

		[Export ("bannerUrl", ArgumentSemantic.Copy)]
		NSUrl BannerUrl { get; }

		[Export ("currentMilestone", ArgumentSemantic.Strong)]
		QuestMilestone CurrentMilestone { get; }

		[Export ("state", ArgumentSemantic.Assign)]
		QuestState State { get; }

		[Export ("startTimestamp", ArgumentSemantic.Assign)]
		long StartTimestamp { get; }

		[Export ("expirationTimestamp", ArgumentSemantic.Assign)]
		long ExpirationTimestamp { get; }

		[Export ("acceptedTimestamp", ArgumentSemantic.Assign)]
		long AcceptedTimestamp { get; }

		[Static]
		[Export ("fetchQuestWithId:completionHandler:")]
		void FetchQuest (string questId, QuestFetchHandler completionHandler);

		[Static]
		[Export ("allQuestsWithCompletionHandler:")]
		void AllQuests (QuestListHandler completionHandler);

		[Static]
		[Export ("allQuestsFromDataSource:completionHandler:")]
		void AllQuests (DataSource dataSource, QuestListHandler completionHandler);

		[Static]
		[Export ("questsForState:completionHandler:")]
		void AllQuests (QuestState withState, QuestListHandler completionHandler);

		[Export ("acceptWithCompletionHandler:")]
		void Accept (QuestCompletionHandler completionHandler);
	}

	[BaseType (typeof(NSObject), Name = "GPGQuestMilestone")]
	interface QuestMilestone
	{

		[Export ("questMilestoneId", ArgumentSemantic.Copy)]
		string QuestMilestoneId { get; }

		[Export ("questId", ArgumentSemantic.Copy)]
		string QuestId { get; }

		[Export ("eventId", ArgumentSemantic.Copy)]
		string EventId { get; }

		[Export ("state", ArgumentSemantic.Assign)]
		QuestMilestoneState State { get; }

		[Export ("currentCount", ArgumentSemantic.Assign)]
		nint CurrentCount { get; }

		[Export ("targetCount", ArgumentSemantic.Assign)]
		nint TargetCount { get; }

		[Export ("rewardData", ArgumentSemantic.Strong)]
		NSData RewardData { get; }

		[Export ("claimWithCompletionHandler:")]
		void Claim (QuestCompletionHandler completionHandler);
	}

	interface IRealTimeRoomDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "GPGRealTimeRoomDelegate")]
	interface RealTimeRoomDelegate
	{

		[Export ("didAcceptRealTimeInviteForRoom:")]
		void InviteAccepted (RealTimeRoomData roomData);

		[Export ("didDeclineRealTimeInviteForRoom:")]
		void InviteDeclined (RealTimeRoomData roomData);

		[Export ("didReceiveRealTimeInviteForRoom:")]
		void InviteReceived (RealTimeRoomData roomData);

		[Export ("room:didChangeStatus:")]
		void StatusChanged (RealTimeRoom fromRoom, RealTimeRoomStatus status);

		[Export ("room:didChangeConnectedSet:")]
		void ConnectedChanged (RealTimeRoom room, bool connected);

		[Export ("room:participant:didChangeStatus:")]
		void StatusChanged (RealTimeRoom room, RealTimeParticipant participant, RealTimeRoomStatus status);

		[Export ("room:didReceiveData:fromParticipant:dataMode:")]
		void DataReceived (RealTimeRoom room, NSData data, RealTimeParticipant participant, RealTimeDataMode dataMode);

		[Export ("room:didSendReliableId:results:")]
		void ReliableIdSent (RealTimeRoom room, int reliableId, RealTimeReliableMessageResult[] results);

		[Export ("room:didFailWithError:")]
		void Failed (RealTimeRoom room, NSError error);
	}

	[BaseType (typeof(NSObject), Name = "GPGRealTimeRoomCreationHandle")]
	interface RealTimeRoomCreationHandle
	{

		[Export ("cancel")]
		bool Cancel { get; }
	}

	[BaseType (typeof(NSObject), Name = "GPGRealTimeRoomModifyDetails")]
	interface RealTimeRoomModifyDetails
	{

		[Export ("lastUpdateTimestamp", ArgumentSemantic.Assign)]
		long LastUpdateTimestamp { get; }

		[Export ("participant", ArgumentSemantic.Strong)]
		RealTimeParticipant Participant { get; }
	}

	[BaseType (typeof(NSObject), Name = "GPGRealTimeReliableMessageResult")]
	interface RealTimeReliableMessageResult
	{

		[Export ("participant", ArgumentSemantic.Strong)]
		RealTimeParticipant Participant { get; }

		[Export ("success", ArgumentSemantic.UnsafeUnretained)]
		bool Success { get; }
	}

	[BaseType (typeof(NSObject), Name = "GPGRealTimeParticipant")]
	interface RealTimeParticipant
	{

		[Export ("canCommunicate")]
		bool CanCommunicate { get; }

		[Export ("sendReliableData:")]
		int SendReliableData (NSData data);

		[Export ("sendUnreliableData:")]
		void SendUnreliableData (NSData data);

		// @property (readonly, copy, nonatomic) NSURL * avatarUrl;
		[Export ("avatarUrl", ArgumentSemantic.Copy)]
		NSUrl AvatarUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * displayName;
		[Export ("displayName", ArgumentSemantic.Copy)]
		string DisplayName { get; }

		// @property (readonly, copy, nonatomic) NSString * participantId;
		[Export ("participantId", ArgumentSemantic.Copy)]
		string ParticipantId { get; }

		// @property (readonly, assign, nonatomic) BOOL isAutoMatchedPlayer;
		[Export ("isAutoMatchedPlayer", ArgumentSemantic.Assign)]
		bool IsAutoMatchedPlayer { get; }

		// @property (readonly, assign, nonatomic) BOOL isLocalParticipant;
		[Export ("isLocalParticipant", ArgumentSemantic.Assign)]
		bool IsLocalParticipant { get; }

		// @property (readonly, assign, nonatomic) GPGRealTimeParticipantStatus status;
		[Export ("status", ArgumentSemantic.Assign)]
		RealTimeParticipantStatus Status { get; }
	}

	delegate void RealTimeParticipantIteratorHandler (RealTimeParticipant participant);

	[BaseType (typeof(NSObject), Name = "GPGRealTimeRoom")]
	interface RealTimeRoom
	{

		[Export ("config", ArgumentSemantic.Strong)]
		MultiplayerConfig Config { get; }

		[Export ("participants", ArgumentSemantic.Copy)]
		RealTimeParticipant [] Participants { get; }

		[Export ("connectedParticipants", ArgumentSemantic.Copy)]
		RealTimeParticipant [] ConnectedParticipants { get; }

		[Export ("localParticipant", ArgumentSemantic.Strong)]
		RealTimeParticipant LocalParticipant { get; }

		[Export ("roomDescription", ArgumentSemantic.Copy)]
		string RoomDescription { get; }

		[Export ("roomID", ArgumentSemantic.Copy)]
		string RoomID { get; }

		[Export ("inConnectedSet", ArgumentSemantic.Assign)]
		bool InConnectedSet { get; }

		[Export ("creationDetails", ArgumentSemantic.Strong)]
		RealTimeRoomModifyDetails CreationDetails { get; }

		[Export ("status", ArgumentSemantic.Assign)]
		RealTimeRoomStatus Status { get; }

		[Export ("waitEstimateSeconds", ArgumentSemantic.Copy)]
		NSNumber WaitEstimateSeconds { get; }

		[Export ("findParticipantById:")]
		RealTimeParticipant FindParticipantById (string participantId);

		[Export ("enumerateParticipantsUsingBlock:")]
		void EnumerateParticipants (RealTimeParticipantIteratorHandler iterator);

		[Export ("enumerateOtherParticipantsUsingBlock:")]
		void EnumerateOtherParticipants (RealTimeParticipantIteratorHandler iterator);

		[Export ("enumerateConnectedParticipantsUsingBlock:")]
		void EnumerateConnectedParticipants (RealTimeParticipantIteratorHandler iterator);

		[Internal]
		[Export ("sendReliableData:toParticipants:")]
		int _SendReliableData (NSData data, NSArray participants);

		[Internal]
		[Export ("sendUnreliableData:toParticipants:")]
		void _SendUnreliableData (NSData data, NSArray participants);

		[Export ("sendReliableDataToAll:")]
		int SendReliableDataToAll (NSData data);

		[Export ("sendUnreliableDataToAll:")]
		void SendUnreliableDataToAll (NSData data);

		[Export ("sendReliableDataToOthers:")]
		int SendReliableDataToOthers (NSData data);

		[Export ("sendUnreliableDataToOthers:")]
		void SendUnreliableDataToOthers (NSData data);

		[Export ("leave")]
		void Leave ();
	}

	[BaseType (typeof(NSObject), Name = "GPGRealTimeRoomData")]
	interface RealTimeRoomData
	{

		[Export ("config", ArgumentSemantic.Strong)]
		MultiplayerConfig Config { get; }

		[Export ("creationDetails", ArgumentSemantic.Strong)]
		RealTimeRoomModifyDetails CreationDetails { get; }

		// @property (readonly, copy, nonatomic) NSArray * participants;
		[Export ("participants", ArgumentSemantic.Copy)]
		RealTimeParticipant [] Participants { get; }

		// @property (readonly, copy, nonatomic) NSString * roomDescription;
		[Export ("roomDescription", ArgumentSemantic.Copy)]
		string RoomDescription { get; }

		// @property (readonly, copy, nonatomic) NSString * roomID;
		[Export ("roomID", ArgumentSemantic.Copy)]
		string RoomID { get; }

		// @property (readonly, assign, nonatomic) GPGRealTimeRoomStatus status;
		[Export ("status", ArgumentSemantic.Assign)]
		RealTimeRoomStatus Status { get; }
	}

	delegate void ListRoomsHandler (RealTimeRoomData[] rooms,NSError error);
	delegate void RoomRequestHandler (RealTimeRoomData data,NSError error);
	delegate void RoomDismissHandler (NSError error);

	[BaseType (typeof(NSObject), Name = "GPGRealTimeRoomMaker")]
	interface RealTimeRoomMaker
	{

		[Static]
		[Export ("createRoomFromConfig:")]
		RealTimeRoomCreationResult CreateRoom (MultiplayerConfig config);

		[Static]
		[Export ("createRoomFromConfig:operationHandle:")]
		RealTimeRoomCreationResult CreateRoom (MultiplayerConfig config, out RealTimeRoomCreationHandle handle);

		[Static]
		[Export ("joinRoomFromData:")]
		RealTimeRoomCreationResult JoinRoom (RealTimeRoomData data);

		[Static]
		[Export ("joinRoomFromData:operationHandle:")]
		RealTimeRoomCreationResult JoinRoom (RealTimeRoomData data, out RealTimeRoomCreationHandle handle);

		[Static]
		[Export ("listRoomsWithMaxResults:completionHandler:")]
		void ListRooms (int maxResults, ListRoomsHandler completionHandler);

		[Static]
		[Export ("getRoomWithId:completionHandler:")]
		void GetRoom (string roomId, RoomRequestHandler completionHandler);

		[Static]
		[Export ("getRoomFromData:completionHandler:")]
		void GetRoom (RealTimeRoomData roomData, RoomRequestHandler completionHandler);

		[Static]
		[Export ("declineRoomFromData:completionHandler:")]
		void DeclineRoom (RealTimeRoomData data, RoomRequestHandler completionHandler);

		[Static]
		[Export ("dismissRoomFromData:completionHandler:")]
		void DismissRoom (RealTimeRoomData data, RoomDismissHandler completionHandler);

		[Static]
		[Export ("activeRoom")]
		RealTimeRoom ActiveRoom ();
	}

	delegate void ScoreReportScoreHandler (ScoreReport report,NSError error);
	delegate void ScoreBatchReportHandler (NSError error);

	[BaseType (typeof(NSObject), Name = "GPGScore")]
	interface Score
	{

		[Export ("initWithLeaderboardId:")]
		IntPtr Constructor (string leaderboardId);

		[Static]
		[Export ("scoreWithLeaderboardId:")]
		Score FromLeaderboardId (string leaderboardId);

		[Export ("leaderboardId", ArgumentSemantic.Copy)]
		string LeaderboardId { get; }

		[Export ("value", ArgumentSemantic.Assign)]
		long Value { get; set; }

		[Export ("scoreTag", ArgumentSemantic.Copy)]
		string ScoreTag { get; set; }

		[Export ("submitScoreWithCompletionHandler:")]
		void SubmitScore (ScoreReportScoreHandler completionHandler);

		[Static]
		[Export ("batchSubmitScores:completionHandler:")]
		void BatchSubmitScores (NSObject[] scores, ScoreReportScoreHandler completionHandler);

		[Obsolete]
		[Export ("avatarUrl", ArgumentSemantic.Copy)]
		NSUrl AvatarUrl { get; }

		[Obsolete]
		[Export ("displayName", ArgumentSemantic.Copy)]
		string DisplayName { get; }

		[Export ("formattedRank", ArgumentSemantic.Copy)]
		string FormattedRank { get; }

		[Export ("formattedScore", ArgumentSemantic.Copy)]
		string FormattedScore { get; }

		[Obsolete]
		[Export ("playerId", ArgumentSemantic.Copy)]
		string PlayerId { get; }

		[Export ("player", ArgumentSemantic.Strong)]
		Player Player { get; }

		[Export ("rank", ArgumentSemantic.Assign)]
		ulong Rank { get; }

		[Export ("timeSpan", ArgumentSemantic.Copy)]
		string TimeSpan { get; }

		[Export ("writeTimestamp", ArgumentSemantic.Assign)]
		long WriteTimestamp { get; }
	}

	[BaseType (typeof(NSObject), Name = "GPGScoreReport")]
	interface ScoreReport
	{

		[Export ("isHighScoreForLocalPlayerToday", ArgumentSemantic.Assign)]
		bool IsHighScoreForLocalPlayerToday { get; }

		[Export ("isHighScoreForLocalPlayerThisWeek", ArgumentSemantic.Assign)]
		bool IsHighScoreForLocalPlayerThisWeek { get; }

		[Export ("isHighScoreForLocalPlayerAllTime", ArgumentSemantic.Assign)]
		bool IsHighScoreForLocalPlayerAllTime { get; }

		[Export ("leaderboardId", ArgumentSemantic.Copy)]
		string LeaderboardId { get; }

		[Export ("reportedScoreValue", ArgumentSemantic.Assign)]
		long ReportedScoreValue { get; }

		[Export ("highScoreForLocalPlayerToday", ArgumentSemantic.Strong)]
		Score HighScoreForLocalPlayerToday { get; }

		[Export ("highScoreForLocalPlayerThisWeek", ArgumentSemantic.Strong)]
		Score HighScoreForLocalPlayerThisWeek { get; }

		[Export ("highScoreForLocalPlayerAllTime", ArgumentSemantic.Strong)]
		Score HighScoreForLocalPlayerAllTime { get; }
	}

	delegate void SnapshotListHandler (SnapshotMetadata[] snapshotMetadata,NSError error);
	delegate void SnapshotOpenHandler (SnapshotMetadata snapshot,string conflictId,SnapshotMetadata conflictingBase,SnapshotMetadata conflictingRemote,NSError error);
	delegate void SnapshotReadHandler (NSData data,NSError error);
	delegate void SnapshotDeleteHandler (NSError error);
	delegate void SnapshotCommitHandler (SnapshotMetadata snapshotMetadata,NSError error);

	[BaseType (typeof(NSObject), Name = "GPGSnapshotMetadata")]
	interface SnapshotMetadata
	{

		[Export ("fileName", ArgumentSemantic.Copy)]
		string FileName { get; }

		[Export ("snapshotDescription", ArgumentSemantic.Copy)]
		string SnapshotDescription { get; }

		[Export ("lastModifiedTimestamp", ArgumentSemantic.Assign)]
		long LastModifiedTimestamp { get; }

		[Export ("playedTime", ArgumentSemantic.Assign)]
		long PlayedTime { get; }

		[Export ("coverImageUrl", ArgumentSemantic.Strong)]
		NSUrl CoverImageUrl { get; }

		[Export ("isOpen", ArgumentSemantic.Assign)]
		bool IsOpen { get; }

		[Static]
		[Export ("listWithCompletionHandler:")]
		void List (SnapshotListHandler completionHandler);

		[Static]
		[Export ("openWithFileName:conflictPolicy:completionHandler:")]
		void Open (string fileName, SnapshotConflictPolicy conflictPolicy, SnapshotOpenHandler completionHandler);

		// @required - (void)commitWithMetadataChange:(GPGSnapshotMetadataChange *)metadataChange data:(id)data completionHandler:(GPGSnapshotCommitBlock)completionHandler;
		[Export ("commitWithMetadataChange:data:completionHandler:")]
		void Commit (SnapshotMetadataChange metadataChange, NSData data, SnapshotCommitHandler completionHandler);

		[Export ("resolveWithMetadataChange:conflictId:data:completionHandler:")]
		void Resolve (SnapshotMetadataChange metadataChange, string conflictId, NSData data, SnapshotCommitHandler completionHandler);

		[Export ("readWithCompletionHandler:")]
		void Read (SnapshotReadHandler completionHandler);

		[Export ("deleteWithCompletionHandler:")]
		void Delete (SnapshotDeleteHandler completionHandler);
	}

	[BaseType (typeof(NSObject), Name = "GPGSnapshotMetadataChangeCoverImage")]
	interface SnapshotMetadataChangeCoverImage
	{

		[Export ("initWithImage:")]
		IntPtr Constructor (UIImage image);
	}

	[BaseType (typeof(NSObject), Name = "GPGSnapshotMetadataChange")]
	interface SnapshotMetadataChange
	{

		// @property (copy, nonatomic) NSString * snapshotDescription;
		[Export ("snapshotDescription", ArgumentSemantic.Copy)]
		string SnapshotDescription { get; set; }

		// @property (assign, nonatomic) int64_t playedTime;
		[Export ("playedTime", ArgumentSemantic.Assign)]
		long PlayedTime { get; set; }

		// @property (nonatomic, strong) GPGSnapshotMetadataChangeCoverImage * coverImage;
		[Export ("coverImage", ArgumentSemantic.Strong)]
		SnapshotMetadataChangeCoverImage CoverImage { get; set; }
	}

	delegate void TurnBasedMatchCreateHandler (TurnBasedMatch match,NSError error);
	delegate void TurnBasedMatchGetHandler (TurnBasedMatch match,NSError error);
	delegate void TurnBasedMatchesHandler (TurnBasedMatch[] matches,NSError error);
	delegate void TurnBasedMatchListHandler (TurnBasedMatch[] matches,string pageToken,NSError error);
	delegate void TurnBasedMatchRematchHandler (TurnBasedMatch rematch,NSError error);
	delegate void TurnBasedMatchCompletionHandler (NSError error);

	[BaseType (typeof(NSObject), Name = "GPGTurnBasedMatch")]
	interface TurnBasedMatch
	{

		[Export ("matchConfig", ArgumentSemantic.Copy)]
		MultiplayerConfig MatchConfig { get; }

		[Export ("creationTimestamp", ArgumentSemantic.Assign)]
		long CreationTimestamp { get; }

		[Export ("creationParticipant", ArgumentSemantic.Copy)]
		TurnBasedParticipant CreationParticipant { get; }

		[Export ("data", ArgumentSemantic.Copy)]
		NSData Data { get; }

		[Export ("dataAvailable", ArgumentSemantic.Assign)]
		bool DataAvailable { get; }

		[Export ("inviterParticipant", ArgumentSemantic.Copy)]
		TurnBasedParticipant InviterParticipant { get; }

		[Export ("lastUpdateTimestamp", ArgumentSemantic.Assign)]
		long LastUpdateTimestamp { get; }

		[Export ("lastUpdateParticipant", ArgumentSemantic.Copy)]
		TurnBasedParticipant LastUpdateParticipant { get; }

		[Export ("matchDescription", ArgumentSemantic.Copy)]
		string MatchDescription { get; }

		[Export ("matchId", ArgumentSemantic.Copy)]
		string MatchId { get; }

		[Export ("matchNumber", ArgumentSemantic.Assign)]
		int MatchNumber { get; }

		[Export ("matchVersion", ArgumentSemantic.Assign)]
		int MatchVersion { get; }

		[Export ("participants", ArgumentSemantic.Copy)]
		TurnBasedParticipant [] Participants { get; }

		[Export ("pendingParticipant", ArgumentSemantic.Copy)]
		TurnBasedParticipant PendingParticipant { get; }

		[Export ("previousMatchData", ArgumentSemantic.Copy)]
		NSData PreviousMatchData { get; }

		[Export ("previousMatchDataAvailable", ArgumentSemantic.Assign)]
		bool PreviousMatchDataAvailable { get; }

		[Export ("rematchId", ArgumentSemantic.Copy)]
		string RematchId { get; }

		// @property (readonly, copy, nonatomic) NSArray * results;
		[Export ("results", ArgumentSemantic.Copy)]
		TurnBasedParticipantResult [] Results { get; }

		[Export ("status", ArgumentSemantic.UnsafeUnretained)]
		TurnBasedMatchStatus Status { get; }

		[Export ("userMatchStatus", ArgumentSemantic.UnsafeUnretained)]
		TurnBasedUserMatchStatus UserMatchStatus { get; }

		[Export ("canParticipantTakeTurn:")]
		bool CanParticipantTakeTurn (string participantId);

		[Export ("localParticipantId", ArgumentSemantic.Copy)]
		string LocalParticipantId { get; }

		[Export ("participantIdForPlayerId:")]
		string ParticipantIdFromPlayerId (string playerId);

		[Export ("localParticipant", ArgumentSemantic.Strong)]
		TurnBasedParticipant LocalParticipant { get; }

		[Export ("participantForId:")]
		TurnBasedParticipant ParticipantFromId (string participantId);

		[Export ("pendingPlayer", ArgumentSemantic.Strong)]
		Player PendingPlayer { get; }

		[Export ("myTurn")]
		bool IsMyTurn { [Bind ("isMyTurn")] get; }

		[Export ("myResult", ArgumentSemantic.Strong)]
		TurnBasedParticipantResult MyResult { get; }

		[Export ("resultForParticipantId:")]
		TurnBasedParticipantResult ResultFromParticipantId (string participantId);

		[Export ("statusForPlayerId:")]
		TurnBasedParticipantStatus StatusForPlayerId (string playerId);

		[Export ("myStatus")]
		TurnBasedParticipantStatus MyStatus { get; }

		[Static]
		[Export ("createMatchWithConfig:completionHandler:")]
		TurnBasedMatchCreationResult CreateMatch (MultiplayerConfig config, TurnBasedMatchCreateHandler completionHandler);

		[Static]
		[Export ("fetchMatchWithId:includeMatchData:completionHandler:")]
		void FetchMatch (string matchId, bool includeMatchData, TurnBasedMatchGetHandler completionHandler);

		[Static]
		[Export ("listForIncludeMatchData:maxCompletedMatches:maxResults:pageToken:completionHandler:")]
		void ListForIncludeMatchData (bool includeMatchData, int maxCompletedMatches, int maxResults, string pageToken, TurnBasedMatchListHandler completionHandler);

		[Static]
		[Export ("allMatchesWithCompletionHandler:")]
		void AllMatches (Action<NSArray, NSError> completionHandler);

		[Static]
		[Export ("allMatchesFromDataSource:completionHandler:")]
		void AllMatches (DataSource dataSource, TurnBasedMatchesHandler completionHandler);

		[Static]
		[Export ("matchesForMatchStatus:completionHandler:")]
		void Matches (TurnBasedMatchStatus status, TurnBasedMatchesHandler completionHandler);

		[Static]
		[Export ("matchesForMatchStatus:dataSource:completionHandler:")]
		void Matches (TurnBasedMatchStatus status, DataSource dataSource, TurnBasedMatchesHandler completionHandler);

		[Static]
		[Export ("matchesForUserMatchStatus:completionHandler:")]
		void Matches (TurnBasedUserMatchStatus status, TurnBasedMatchesHandler completionHandler);

		[Static]
		[Export ("matchesForUserMatchStatus:dataSource:completionHandler:")]
		void Matches (TurnBasedUserMatchStatus status, DataSource dataSource, TurnBasedMatchesHandler completionHandler);

		[Export ("cancelWithCompletionHandler:")]
		void Cancel (TurnBasedMatchCompletionHandler completionHandler);

		[Export ("declineWithCompletionHandler:")]
		void Decline (TurnBasedMatchCompletionHandler completionHandler);

		[Export ("dismissWithCompletionHandler:")]
		void Dismiss (TurnBasedMatchCompletionHandler completionHandler);

		[Export ("finishWithData:results:completionHandler:")]
		void Finish (NSData data, TurnBasedParticipantResult[] results, TurnBasedMatchCompletionHandler completionHandler);

		[Export ("joinWithCompletionHandler:")]
		void Join (TurnBasedMatchCompletionHandler completionHandler);

		[Export ("leaveOutOfTurnWithCompletionHandler:")]
		void LeaveOutOfTurn (TurnBasedMatchCompletionHandler completionHandler);

		[Export ("leaveDuringTurnWithNextParticipantId:completionHandler:")]
		void LeaveDuringTurn (string nextParticipantId, TurnBasedMatchCompletionHandler completionHandler);

		[Export ("rematchWithCompletionHandler:")]
		void Rematch (TurnBasedMatchRematchHandler completionHandler);

		[Export ("takeTurnWithNextParticipantId:data:results:completionHandler:")]
		void TakeTurn (string nextParticipantId, NSData data, TurnBasedParticipantResult[] results, TurnBasedMatchCompletionHandler completionHandler);
	}

	[BaseType (typeof(NSObject), Name = "GPGTurnBasedParticipant")]
	interface TurnBasedParticipant
	{

		[Export ("displayName", ArgumentSemantic.Copy)]
		string DisplayName { get; }

		[Export ("imageUrl", ArgumentSemantic.Copy)]
		NSUrl ImageUrl { get; }

		[Export ("participantId", ArgumentSemantic.Copy)]
		string ParticipantId { get; }

		[Export ("player", ArgumentSemantic.Retain)]
		Player Player { get; }

		[Export ("status", ArgumentSemantic.Assign)]
		TurnBasedParticipantStatus Status { get; }
	}

	[BaseType (typeof(NSObject), Name = "GPGTurnBasedParticipantResult")]
	interface TurnBasedParticipantResult
	{

		[Export ("participantId", ArgumentSemantic.Copy)]
		string ParticipantId { get; set; }

		[Export ("placing", ArgumentSemantic.Assign)]
		int Placing { get; set; }

		[Export ("result", ArgumentSemantic.Assign)]
		TurnBasedParticipantResultStatus Result { get; set; }

		[Export ("initWithParticipantId:")]
		IntPtr Constructor (string participantId);
	}
}
#endregion
