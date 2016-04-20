using ObjCRuntime;

[assembly: LinkWith ("libGIPNSURL+FIFE.a", LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true,
	ForceLoad = true)]