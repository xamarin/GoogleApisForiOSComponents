using System;
using ObjCRuntime;

namespace Google.AppInvite
{
	[Native]
	public enum ReceivedInviteMatchType : ulong
	{
		Weak,
		Strong
	}

	[Native]
	public enum InviteErrorCode : long
	{
		Unknown = -400,
		Canceled = -401,
		CanceledByUser = -402,
		LaunchError = -403,
		SignInError = -404,
		ServerError = -490,
		NetworkError = -491,
		SMSError = -492,
		InvalidParameters = -497
	}
}

