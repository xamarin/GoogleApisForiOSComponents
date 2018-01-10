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

	[Obsolete ("Use DynamicLinkMatchType enum instead.")]
	[Native]
	public enum DynamicLinkMatchConfidence : ulong
	{
		Weak,
		Strong
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
