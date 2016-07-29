using System;
using ObjCRuntime;

namespace Firebase.DynamicLinks
{
	[Native]
	public enum DynamicLinkMatchConfidence : ulong
	{
		Weak,
		Strong
	}
}
