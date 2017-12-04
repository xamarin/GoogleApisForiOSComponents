using System;
using ObjCRuntime;

namespace Google.Places
{
	[Native]
	public enum AutocompleteBoundsMode : ulong
	{
		Bias,
		Restrict
	}

	[Native]
	public enum PlacesAutocompleteTypeFilter : long
	{
		NoFilter,
		Geocode,
		Address,
		Establishment,
		Region,
		City
	}

	[Native]
	public enum PlacesOpenNowStatus : long
	{
		Yes,
		No,
		Unknown
	}

	[Native]
	public enum PlacesPriceLevel : long
	{
		Unknown = -1,
		Free = 0,
		Cheap = 1,
		Medium = 2,
		High = 3,
		Expensive = 4
	}

	[Native]
	public enum PlacesErrorCode : long
	{
		NetworkError = -1,
		ServerError = -2,
		InternalError = -3,
		KeyInvalid = -4,
		KeyExpired = -5,
		UsageLimitExceeded = -6,
		RateLimitExceeded = -7,
		DeviceRateLimitExceeded = -8,
		AccessNotConfigured = -9,
		IncorrectBundleIdentifier = -10,
		LocationError = -11
	}
}

namespace Google.Places.Picker
{
	[Native]
	public enum PlacePickerErrorCode : long
	{
		UnknownError = -1,
		InternalError = -2,
		InvalidConfig = -3,
		OverlappingCalls = -4
	}
}
