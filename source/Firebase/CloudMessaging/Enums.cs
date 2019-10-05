using System;
using ObjCRuntime;

namespace Firebase.CloudMessaging
{
	[Native]
	public enum ErrorCode : ulong
	{
		Unknown = 0,
		Authentication = 1,
		NoAccess = 2,
		Timeout = 3,
		Network = 4,
		OperationInProgress = 5,
		InvalidRequest = 7,
		InvalidTopicName = 8
	}

	[Native]
	public enum MessageStatus : long
	{
		Unknown,
		New
	}

	[Native]
	public enum ApnsTokenType : long
	{
		Unknown,
		Sandbox,
		Production
	}
}
