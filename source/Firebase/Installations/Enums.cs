using System;
using ObjCRuntime;

namespace Firebase.Installations
{
	[Native]
	public enum InstallationsErrorCode : ulong
	{
		Unknown = 0,
		Keychain = 1,
		ServerUnreachable = 2,
		InvalidConfiguration = 3
	}
}
