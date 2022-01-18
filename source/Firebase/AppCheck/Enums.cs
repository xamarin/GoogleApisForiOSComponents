using System;
using ObjCRuntime;

namespace Firebase.AppCheck
{
    [Native]
	public enum ErrorCode : long
	{
		Unknown = 0,
		ServerUnreachable = 1,
		InvalidConfiguration = 2,
		Keychain = 3,
		Unsupported = 4
	}
}
