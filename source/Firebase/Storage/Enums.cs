using System;
using ObjCRuntime;

namespace Firebase.Storage
{
	[Native]
	public enum StorageTaskStatus : long
	{
		Unknown,
		Resume,
		Progress,
		Pause,
		Success,
		Failure
	}

	[Native]
	public enum StorageErrorCode : long
	{
		Unknown = -13000,
		ObjectNotFound = -13010,
		BucketNotFound = -13011,
		ProjectNotFound = -13012,
		QuotaExceeded = -13013,
		Unauthenticated = -13020,
		Unauthorized = -13021,
		RetryLimitExceeded = -13030,
		NonMatchingChecksum = -13031,
		DownloadSizeExceeded = -13032,
		Cancelled = -13040,
		InvalidArgument = -13050
	}
}
