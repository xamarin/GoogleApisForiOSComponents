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
		NetworkError = 2
	}

	[Native]
	public enum DeviceStatus : long
	{
		Unknown = -1,
		Idle = 0,
		Busy = 1,
	}

	[Native]
	public enum DeviceCapability : long
	{
		VideoOut = 1 << 0,
		VideoIn = 1 << 1,
		AudioOut = 1 << 2,
		AudioIn = 1 << 3,
		MultizoneGroup = 1 << 5
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
		ApplicationNotFound = 20,
		ApplicationNotRunning = 21,
		InvalidApplicationSessionId = 22,
		MediaLoadFailed = 30,
		InvalidMediaPlayerState = 31,
		NoMediaSession = 32,
		AppDidEnterBackground = 91,
		Disconnected = 92,
		Unknown = 99,
	}

	[Native]
	public enum MediaControlChannelResumeState : long
	{
		Unchanged = 0,
		Play = 1,
		Pause = 2
	}

	[Native]
	public enum MediaStreamType : long
	{
		None = 0,
		Buffered = 1,
		Live = 2,
		Unknown = 99
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
		Buffering = 4
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
	public enum MediaRepeatMode : long
	{
		Unchanged = 0,
		Off = 1,
		Single = 2,
		All = 3,
		AllAndShuffle = 4
	}
}
