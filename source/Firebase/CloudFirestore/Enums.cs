using System;
using ObjCRuntime;

namespace Firebase.CloudFirestore
{
	[Native]
	public enum DocumentChangeType : long
	{
		Added,
		Modified,
		Removed
	}

	[Native]
	public enum ServerTimestampBehavior : long
	{
		None,
		Estimate,
		Previous
	}

	[Native]
	public enum FirestoreErrorCode : long
	{
		Ok = 0,
		Cancelled = 1,
		Unknown = 2,
		InvalidArgument = 3,
		DeadlineExceeded = 4,
		NotFound = 5,
		AlreadyExists = 6,
		PermissionDenied = 7,
		ResourceExhausted = 8,
		FailedPrecondition = 9,
		Aborted = 10,
		OutOfRange = 11,
		Unimplemented = 12,
		Internal = 13,
		Unavailable = 14,
		DataLoss = 15,
		Unauthenticated = 16
	}

	[Native]
	public enum FirestoreSource : ulong
	{
		Default,
		Server,
		Cache
	}
}
