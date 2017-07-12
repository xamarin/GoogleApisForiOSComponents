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
	public enum DynamicLinkMatchConfidence : ulong
	{
		Weak,
		Strong
	}
}
