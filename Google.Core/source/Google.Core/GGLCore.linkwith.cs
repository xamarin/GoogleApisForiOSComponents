using System;
using ObjCRuntime;

[assembly: LinkWith ("GGLCore", 
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	Frameworks = "AddressBook AssetsLibrary CoreFoundation CoreLocation CoreMotion MessageUI SystemConfiguration",
	LinkerFlags = "-ObjC -lz -lstdc++ -lsqlite3",
	SmartLink = true,
	ForceLoad = true)]

[assembly: LinkWith ("GGLAnalytics",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true,
	ForceLoad = true)]

[assembly: LinkWith ("GGLSignIn",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true,
	ForceLoad = true)]
