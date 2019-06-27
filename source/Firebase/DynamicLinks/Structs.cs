using System;
using ObjCRuntime;

namespace Firebase.DynamicLinks
{
	[Native]
	public enum ShortDynamicLinkPathLength : long
	{
		Default = 0,
		Short,
		Unguessable
	}

	[Native]
	public enum DynamicLinkMatchType : ulong
	{
		None,
		Weak,
		Default,
		Unique
	}
}
