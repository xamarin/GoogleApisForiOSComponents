using System;
using ObjCRuntime;

namespace Firebase.Core
{
	[Native]
	public enum LoggerLevel : long
	{
		Error = 3,
		Warning = 4,
		Notice = 5,
		Info = 6,
		Debug = 7,
		Min = Error,
		Max = Debug
	}
}
