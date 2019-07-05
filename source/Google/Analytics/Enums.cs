using System;
using ObjCRuntime;

namespace Google.Analytics
{
	[Native]
	public enum DispatchResult : ulong
	{
		NoData,
		Good,
		Error
	}

	public enum ErrorCode
	{
		NoError = 0,
		DatabaseError,
		NetworkError
	}

	[Native]
	public enum LogLevel : ulong
	{
		None = 0,
		Error = 1,
		Warning = 2,
		Info = 3,
		Verbose = 4
	}
}
