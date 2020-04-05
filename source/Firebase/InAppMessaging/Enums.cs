using System;
using ObjCRuntime;

namespace Firebase.InAppMessaging
{
	[Native]
	public enum InAppMessagingDisplayMessageType : long
	{
		Modal,
		Banner,
		ImageOnly,
		Card
	}

	[Native]
	public enum InAppMessagingDisplayTriggerType : long
	{
		OnAppForeground,
		OnAnalyticsEvent
	}

	[Native]
	public enum InAppMessagingDismissType : long
	{
		TypeUserSwipe,
		TypeUserTapClose,
		TypeAuto,
		Unspecified
	}

	[Native]
	public enum InAppMessagingDisplayRenderErrorType : long
	{
		ImageDataInvalid,
		UnspecifiedError
	}
}
