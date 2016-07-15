using System;
using ObjCRuntime;

namespace Firebase.Analytics
{
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
