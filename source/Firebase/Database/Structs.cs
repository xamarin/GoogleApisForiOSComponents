using System;
using ObjCRuntime;

namespace Firebase.Database
{
	[Native]
	public enum DataEventType : long
	{
		ChildAdded,
		ChildRemoved,
		ChildChanged,
		ChildMoved,
		Value
	}
}
