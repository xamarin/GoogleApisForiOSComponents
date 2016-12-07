using System;
using ObjCRuntime;

namespace Firebase.Analytics
{
	[Obsolete ("Use -FIRDebugEnabled and -FIRDebugDisabled flags.")]
	[Native]
	public enum LogLevel : long
	{
		Error = 0,
		Warning,
		Info,
		Debug,
		Assert,
		Max = Assert
	}
}
