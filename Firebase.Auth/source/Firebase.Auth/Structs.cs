using System;
using ObjCRuntime;

namespace Firebase.Auth
{
	[Native]
	public enum AuthApnsTokenType : long
	{
		Unknown,
		Sandbox,
		Production
	}

	[Native]
	public enum ActionDataKey : long
	{
		EmailKey = 0,
		FromEmailKey = 1
	}

	[Native]
	public enum ActionCodeOperation : long
	{
		Unknown = 0,
		PasswordReset = 1,
		VerifyEmail = 2,
		RecoverEmail = 3,
		EmailLink = 4
	}

	[Native]
	public enum AuthErrorCode : long
	{
		InvalidCustomToken = 17000,
		CustomTokenMismatch = 17002,
		InvalidCredential = 17004,
		UserDisabled = 17005,
		OperationNotAllowed = 17006,
		EmailAlreadyInUse = 17007,
		InvalidEmail = 17008,
		WrongPassword = 17009,
		TooManyRequests = 17010,
		UserNotFound = 17011,
		AccountExistsWithDifferentCredential = 17012,
		RequiresRecentLogin = 17014,
		ProviderAlreadyLinked = 17015,
		NoSuchProvider = 17016,
		InvalidUserToken = 17017,
		NetworkError = 17020,
		UserTokenExpired = 17021,
		InvalidAPIKey = 17023,
		UserMismatch = 17024,
		CredentialAlreadyInUse = 17025,
		WeakPassword = 17026,
		AppNotAuthorized = 17028,
		ExpiredActionCode = 17029,
		InvalidActionCode = 17030,
		InvalidMessagePayload = 17031,
		[Obsolete ("Use InvalidMessagePayload instead, this will be removed in future versions.")]
		MessagePayload = InvalidMessagePayload,
		InvalidSender = 17032,
		[Obsolete ("Use InvalidSender instead, this will be removed in future versions.")]
		Sender = InvalidSender,
		InvalidRecipientEmail = 17033,
		[Obsolete ("Use InvalidRecipientEmail instead, this will be removed in future versions.")]
		RecipientEmail = InvalidRecipientEmail,
		MissingEmail = 17034,
		MissingIosBundleID = 17036,
		MissingAndroidPackageName = 17037,
		UnauthorizedDomain = 17038,
		InvalidContinueUri = 17039,
		MissingContinueURI = 17040,
		MissingPhoneNumber = 17041,
		InvalidPhoneNumber = 17042,
		MissingVerificationCode = 17043,
		InvalidVerificationCode = 17044,
		MissingVerificationID = 17045,
		InvalidVerificationID = 17046,
		MissingAppCredential = 17047,
		InvalidAppCredential = 17048,
		SessionExpired = 17051,
		QuotaExceeded = 17052,
		MissingAppToken = 17053,
		NotificationNotForwarded = 17054,
		AppNotVerified = 17055,
		CaptchaCheckFailed = 17056,
		WebContextAlreadyPresented = 17057,
		WebContextCancelled = 17058,
		AppVerificationUserInteractionFailure = 17059,
		InvalidClientId = 17060,
		WebNetworkRequestFailed = 17061,
		WebInternalError = 17062,
		NullUser = 17067,
		KeychainError = 17995,
		InternalError = 17999
	}
}
