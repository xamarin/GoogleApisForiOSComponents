using System;
using ObjCRuntime;

namespace Firebase.Invites
{
	[Native]
	public enum ReceivedInviteMatchType : ulong
	{
		Weak,
		Strong
	}

	[Native]
	public enum ErrorCode : long
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
