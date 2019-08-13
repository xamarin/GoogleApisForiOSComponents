using System;
using ObjCRuntime;

namespace Firebase.RemoteConfig
{
	[Native]
	public enum RemoteConfigFetchStatus : long
	{
		NoFetchYet,
		Success,
		Failure,
		Throttled
	}

	[Native]
	public enum RemoteConfigFetchAndActivateStatus : long
	{
		SuccessFetchedFromRemote,
		SuccessUsingPreFetchedData,
		Error
	}

	[Native]
	public enum RemoteConfigError : long
	{
		Unknown = 8001,
		Throttled = 8002,
		InternalError = 8003
	}

	[Native]
	public enum RemoteConfigSource : long
	{
		Remote,
		Default,
		Static
	}
}
