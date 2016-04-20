using System;
using ObjCRuntime;

namespace Google.TagManager
{
	public enum ContainerCallbackRefreshType
	{
		Saved,
		Network
	}

	public enum ContainerCallbackRefreshFailure
	{
		NoSavedContainer,
		IoError,
		NoNetwork,
		NetworkError,
		ServerError,
		UnknownError
	}

	public enum OpenType
	{
		PreferNonDefault,
		PreferFresh
	}

	public enum LoggerLogLevelType
	{
		Verbose,
		Debug,
		Info,
		Warning,
		Error,
		None
	}

	public enum RefreshMode
	{
		Standard,
		DefaultContainer
	}

	[Native]
	public enum DispatchResult : ulong
	{
		NoData,
		Good,
		Error
	}
}
