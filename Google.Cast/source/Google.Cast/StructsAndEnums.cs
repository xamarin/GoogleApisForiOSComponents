using System;
using ObjCRuntime;

namespace Google.Cast
{
	[Native]
	public enum ActiveInputStatus : long
	{
		Unknown = -1,
		Inactive = 0,
		Active = 1
	}

	[Native]
	public enum CastState : ulong
	{
		NoDevicesAvailable = 0,
		NotConnected = 1,
		Connecting = 2,
		Connected = 3
	}

	[Native]
	public enum ConnectionState : long
	{
		Disconnected = 0,
		Connecting = 1,
		Connected = 2,
		Disconnecting = 3
	}

	[Native]
	public enum ConnectionSuspendReason : long
	{
		AppBackgrounded = 1,
		NetworkError = 2,
		NetworkNotReachable = 3
	}

	[Native]
	public enum DeviceCapability : long
	{
		VideoOut = 1 << 0,
		VideoIn = 1 << 1,
		AudioOut = 1 << 2,
		AudioIn = 1 << 3,
		MultizoneGroup = 1 << 5,
		MasterOrFixedVolume = 1 << 11,
		AttenuationOrFixedVolume = 1 << 12
	}

	[Native]
	public enum DeviceStatus : long
	{
		Unknown = -1,
		Idle = 0,
		Busy = 1,
	}

	[Native]
	public enum DeviceType : long
	{
		Generic = 0,
		Tv,
		Speaker,
		SpeakerGroup,
		NearbyUnpaired
	}

	[Native]
	public enum DiscoveryState : long
	{
		Stopped = 0,
		Running = 1
	}

	[Native]
	public enum ErrorCode : long
	{
		NoError = 0,
		NetworkError = 1,
		Timeout = 2,
		DeviceAuthenticationFailure = 3,
		InvalidRequest = 4,
		Cancelled = 5,
		Replaced = 6,
		NotAllowed = 7,
		DuplicateRequest = 8,
		InvalidState = 9,
		SendBufferFull = 10,
		MessageTooBig = 11,
		ChannelNotConnected = 12,
		DeviceAuthorizationFailure = 13,
		DeviceNotConnected = 14,
		ProtocolVersionMismatch = 15,
		MaxUsersConnected = 16,
		NetworkNotReachable = 17,
		ProtocolError = 18,
		ApplicationNotFound = 20,
		ApplicationNotRunning = 21,
		InvalidApplicationSessionId = 22,
		MediaLoadFailed = 30,
		InvalidMediaPlayerState = 31,
		NoMediaSession = 32,
		AuthenticationErrorReceived = 40,
		MalformedClientCertificate = 41,
		NotX509Certificate = 42,
		DeviceCertificateNotTrusted = 43,
		SslCertificateNotTrusted = 44,
		MalformedAuthenticationResponse = 45,
		DeviceCapabilityNotSupported = 46,
		CrlInvalid = 47,
		CrlCheckFailed = 48,
		AppDidEnterBackground = 91,
		Disconnected = 92,
		UnsupportedFeature = 93,
		Unknown = 99,
	}

	[Obsolete ("The Game Manager API is no longer supported and will be removed in a future release.")]
	[Native]
	public enum GameplayState : long
	{
		Unknown = 0,
		Loading = 1,
		Running = 2,
		Paused = 3,
		ShowingInfoScreen = 4
	}

	[Native]
	public enum LobbyState : long
	{
		Unknown = 0,
		Open = 1,
		Closed = 2
	}

	[Native]
	public enum LoggerLevel : long
	{
		None = 0,
		Verbose = 1,
		Debug = 2,
		Info = 3,
		Warning = 4,
		Error = 5,
		Assert = 6
	}

	[Native]
	public enum MediaMetadataImageType : long
	{
		Custom = 0,
		CastDialog = 1,
		MiniController = 2,
		Background = 3
	}

	[Native]
	public enum MediaMetadataType : long
	{
		Generic = 0,
		Movie = 1,
		TvShow = 2,
		MusicTrack = 3,
		Photo = 4,
		User = 100
	}

	[Native]
	public enum MediaPlayerState : long
	{
		Unknown = 0,
		Idle = 1,
		Playing = 2,
		Paused = 3,
		Buffering = 4,
		Loading = 5
	}

	[Native]
	public enum MediaPlayerIdleReason : long
	{
		None = 0,
		Finished = 1,
		Cancelled = 2,
		Interrupted = 3,
		Error = 4
	}

	[Native]
	public enum MediaRepeatMode : long
	{
		Unchanged = 0,
		Off = 1,
		Single = 2,
		All = 3,
		AllAndShuffle = 4
	}

	//////////////////
	/// Same enum in Objective-C
	////////////////// 

	[Native]
	public enum MediaControlChannelResumeState : long
	{
		Unchanged = 0,
		Play = 1,
		Pause = 2
	}

	// typedef GCKMediaControlChannelResumeState GCKMediaResumeState;
	[Native]
	public enum MediaResumeState : long
	{
		Unchanged = 0,
		Play = 1,
		Pause = 2
	}

	//////////////////
	//////////////////
	//////////////////

	[Native]
	public enum MediaStreamType : long
	{
		None = 0,
		Buffered = 1,
		Live = 2,
		Unknown = 99
	}

	[Native]
	public enum MediaTextTrackStyleEdgeType : long
	{
		Unknown = -1,
		None = 0,
		Outline = 1,
		DropShadow = 2,
		Raised = 3,
		Depressed = 4,
	}

	[Native]
	public enum MediaTextTrackStyleWindowType : long
	{
		Unknown = -1,
		None = 0,
		Normal = 1,
		RoundedCorners = 2,
	}

	[Native]
	public enum MediaTextTrackStyleFontGenericFamily : long
	{
		Unknown = -1,
		None = 0,
		SansSerif = 1,
		MonospacedSansSerif = 2,
		Serif = 3,
		MonospacedSerif = 4,
		Casual = 5,
		Cursive = 6,
		SmallCapitals = 7,
	}

	[Native]
	public enum MediaTextTrackStyleFontStyle : long
	{
		Unknown = -1,
		Normal = 0,
		Bold = 1,
		Italic = 2,
		BoldItalic = 3,
	}

	[Native]
	public enum MediaTrackType : long
	{
		Unknown = 0,
		Text = 1,
		Audio = 2,
		Video = 3,
	}

	[Native]
	public enum MediaTextTrackSubtype : long
	{
		Unknown = 0,
		Subtitles = 1,
		Captions = 3,
		Descriptions = 4,
		Chapters = 5,
		Metadata = 6,
	}

	[Obsolete ("The Game Manager API is no longer supported and will be removed in a future release.")]
	[Native]
	public enum PlayerState : long
	{
		Unknown = 0,
		Dropped = 1,
		Quit = 2,
		Available = 3,
		Ready = 4,
		Idle = 5,
		Playing = 6
	}

	[Native]
	public enum RequestAbortReason : long
	{
		Replaced = 1,
		Cancelled = 2
	}

	[Native]
	public enum SenderApplicationInfoPlatform : long
	{
		Android = 1,
		iOS = 2,
		Chrome = 3,
		OSX = 4
	}

	[Native]
	public enum StandbyStatus : long
	{
		Unknown = -1,
		Inactive = 0,
		Active = 1,
	}

	[Native]
	public enum UIMediaButtonType : long
	{
		None,
		PlayPauseToggle,
		SkipNext,
		SkipPrevious,
		Rewind30Seconds,
		Forward30Seconds,
		MuteToggle,
		ClosedCaptions,
		Stop,
		Custom
	}

	[Native]
	public enum UIPlayPauseState : long 
	{
		None = 0,
		Play = 1,
		Pause = 2
	}

	[Native]
	public enum VideoInfoHdrType : long
	{
		Unknown = -1,
		Sdr = 0,
		Dv = 1,
		Hdr = 2
	}
}
