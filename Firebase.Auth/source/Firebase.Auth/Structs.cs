using System;
using ObjCRuntime;

namespace Firebase.Auth
{
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
		VerifyEmail = 2
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
		MessagePayload = 17031,
		Sender = 17032,
		RecipientEmail = 17033,
		KeychainError = 17995,
		InternalError = 17999
	}
}
