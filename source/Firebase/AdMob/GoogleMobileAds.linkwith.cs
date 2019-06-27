using ObjCRuntime;

[assembly: LinkWith ("libGoogleMobileAds.a",
	LinkTarget.ArmV7 | LinkTarget.Simulator,
	LinkerFlags = "-ObjC",
	SmartLink = true,
	ForceLoad = true)]
