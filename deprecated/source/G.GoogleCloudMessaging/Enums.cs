using ObjCRuntime;

namespace Google.GoogleCloudMessaging
{
	public enum LogLevel : sbyte
	{
		Debug,
		Info,
		Error,
		Assert
	}

	[Native]
	public enum ServiceErrorCode : ulong
	{
		InvalidRequest = 0,
		Authentication = 1,
		NoAccess = 2,
		Timeout = 3,
		Network = 4,
		OperationInProgress = 5,
		Unknown = 7,
		MissingDeviceId = 501,
		UpstreamServiceNotAvailable = 1001,
		InvalidParameters = 1002,
		MissingTo = 1003,
		Save = 1004,
		SizeExceeded = 1005,
		AlreadyConnected = 2001,
		PubSubAlreadySubscribed = 3001,
		PubSubAlreadyUnsubscribed = 3002,
		PubSubInvalidTopic = 3003
	}
}