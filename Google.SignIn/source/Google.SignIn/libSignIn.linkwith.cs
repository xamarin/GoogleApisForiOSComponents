using ObjCRuntime;

[assembly: LinkWith ("libSignIn.a", LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	LinkerFlags = "-ObjC -lsqlite3",
	Frameworks = "CoreText Security StoreKit",
	WeakFrameworks = "SafariServices",
	SmartLink = true, 
	ForceLoad = true)]
