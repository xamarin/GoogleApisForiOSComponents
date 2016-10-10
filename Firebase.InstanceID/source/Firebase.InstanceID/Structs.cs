using System;
using ObjCRuntime;

namespace Firebase.InstanceID
{
	[Native]
	public enum Error : ulong
	{
		Unknown = 0,
		Authentication = 1,
		NoAccess = 2,
		Timeout = 3,
		Network = 4,
		OperationInProgress = 5,
		InvalidRequest = 7
	}

	[Native]
	public enum ApnsTokenType : long
	{
		Unknown,
		Sandbox,
		Prod
	}
}
