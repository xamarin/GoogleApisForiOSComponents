using System;
using ObjCRuntime;

namespace Firebase.Auth
{
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
		KeychainError = 17995,
		InternalError = 17999
	}
}
