using System;
using ObjCRuntime;

namespace Firebase.AppDistribution
{
	[Native]
    public enum Error : uint {
		Unknown = 0,
		AuthenticationFailure = 1,
		AuthenticationCancelled = 2,
		NetworkFailure = 3,
    }
}
