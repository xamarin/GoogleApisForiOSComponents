using ObjCRuntime;

[assembly: LinkWith ("GoogleSignIn",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	LinkerFlags = "-ObjC -lsqlite3",
	Frameworks = "CoreText Security",
	WeakFrameworks = "SafariServices",
	SmartLink = true,
	ForceLoad = true)]

[assembly: LinkWith ("GoogleNetworkingUtilities",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true,
	ForceLoad = true)]

[assembly: LinkWith ("GoogleAppUtilities",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true,
	ForceLoad = true)]

[assembly: LinkWith ("GoogleAuthUtilities",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true,
	ForceLoad = true)]
