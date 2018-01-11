using System;
using ObjCRuntime;

namespace Firebase.PerformanceMonitoring
{
	[Native]
	public enum HttpMethod : long
	{
		Get,
		Put,
		Post,
		Delete,
		Head,
		Patch,
		Options,
		Trace,
		Connect
	}
}
