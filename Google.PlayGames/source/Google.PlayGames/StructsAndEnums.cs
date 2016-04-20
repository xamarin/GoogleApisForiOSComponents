using System;
using ObjCRuntime;

namespace Google.Play.GameServices
{
    [Native]
    public enum AchievementType : long
    {
        Unknown = -1,
        Standard,
        Incremental
    }

    [Native]
    public enum AchievementState : long
    {
        Unknown = -1,
        Hidden,
        Revealed,
        Unlocked
    }

    [Native]
    public enum AppStateLoadStatus : long
    {
        UnknownError = -1,
        Success,
        NotFound
    }

    [Native]
    public enum AppStateWriteStatus : long
    {
        UnknownError = -1,
        Success,
        BadKeyDataOrVersion,
        KeysQuotaExceeded,
        NotFound,
        Conflict,
        SizeExceeded
    }

    public enum DataSource 
    {
        CacheOrNetwork,
        Network,
    }

    [Native]
    public enum LauncherType : long
    {
        Unknown = -1,
        PlayerProfile,
        PlayerPicker,
        TurnBasedMatchList,
        QuestList,
        SnapshotList,
        Leaderboard,
        LeaderboardList,
        AchievementList,
        RTMPInviteFlow,
        RTMPInvitesList,
        RTMPWaitingRoom,
        Settings
    }

    [Native]
    public enum LeaderboardTimeScope : long
    {
        Unknown = -1,
        Today = 1,
        ThisWeek = 2,
        AllTime = 3
    }

    [Native]
    public enum LeaderboardOrder : long
    {
        Unknown = -1,
        LargerIsBetter,
        SmallerIsBetter,
    }

    [Native]
    public enum PushNotificationEnvironment : long
    {
        Unknown,
        Production,
        Sandbox
    }

    [Native]
    public enum QuestState : long
    {
        Upcoming,
        Open,
        Accepted,
        Completed,
        Expired,
        Failed
    }

    [Native]
    public enum QuestMilestoneState : long
    {
        NotStarted,
        NotCompleted,
        CompletedNotClaimed,
        Claimed
    }

    [Native]
    public enum RealTimeDataMode : long
    {
        Unreliable,
        Reliable
    }

    [Native]
    public enum RealTimeParticipantStatus : long
    {
        Invited,
        Joined,
        Declined,
        Left,
        ConnectionEstablished
    }

    [Native]
    public enum RealTimeRoomCreationResult : long
    {
        Success,
        FailedMissingCreationData,
        FailedMissingDelegate,
        FailedInvalidVariant,
        FailedInvalidAutoMatchCount,
        FailedInvalidPlayerCount,
        FailedRoomNotInviting,
        FailedMultiplayerNotEnabled,
        FailedNotSignedIn,
        FailedNotOnline,
        FailedUnknown
    }

    [Native]
    public enum RealTimeRoomStatus : long
    {
        Inviting,
        Connecting,
        AutoMatching,
        Active,
        Deleted
    }

    [Native]
    public enum RevisionStatus : long
    {
        Unknown = -1,
        OK,
        Deprecated,
        Invalid
    }

    [Native]
    public enum SnapshotConflictPolicy : long
    {
        Manual,
        LongestPlaytime,
        BaseWins,
        RemoteWins
    }

    [Native]
    public enum ToastPlacement : long
    {
        Top,
        Bottom,
        Center
    }

    [Native]
    public enum TurnBasedMatchCreationResult : long
    {
        Success,
        FailedMissingCreationData,
        FailedInvalidVariant,
        FailedInvalidAutoMatchCount,
        FailedInvalidPlayerCount,
        FailedRoomNotInviting,
        FailedMultiplayerNotEnabled,
        FailedNotSignedIn,
        FailedNotOnline,
        FailedUnknown
    }

    [Native]
    public enum TurnBasedMatchStatus : long
    {
        AutoMatching,
        Active,
        Complete,
        Canceled,
        Expired,
        Deleted
    }

    [Native]
    public enum TurnBasedUserMatchStatus : long
    {
        Invited,
        AwaitingTurn,
        Turn,
        MatchCompleted
    }

    [Native]
    public enum TurnBasedParticipantStatus : long
    {
        Unknown = -1,
        NotInvited,
        Invited,
        Joined,
        Declined,
        Left,
        Finished,
        Unresponsive,
    }

    [Native]
    public enum TurnBasedParticipantResultStatus : long
    {
        Uninitialized = -1,
        Win,
        Loss,
        Tie,
        None,
        Disconnect,
        Disagreed
    }
}