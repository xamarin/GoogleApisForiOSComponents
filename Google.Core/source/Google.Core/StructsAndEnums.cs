using System;

namespace Google.Core
{
	public enum ErrorCode
	{
		Succeeded = 0,
		UnknownFailure = -1,
		NoOp = -2,
		InvalidPlistFile = -100,
		AdMobSubspecConfigFailed = -101,
		AnalyticsSubspecConfigFailed = -102,
		AppInviteSubspecConfigFailed = -103,
		CloudMessagingSubspecConfigFailed = -104,
		SignInSubspecConfigFailed = -105,
		MissingExpectedSubspec = -106,
		InvalidAppID = -107
	}

}

