using System;

namespace Google.Core
{
	public enum ErrorCode
	{
		Succeeded = 0,
		UnknownFailure = -1,
		NoOp = -2,
		ConfigurationFailed = -3,
		AnalyticsSubspecConfigFailed = -102,
		SignInSubspecConfigFailed = -105,
		MissingExpectedSubspec = -106
	}

}

