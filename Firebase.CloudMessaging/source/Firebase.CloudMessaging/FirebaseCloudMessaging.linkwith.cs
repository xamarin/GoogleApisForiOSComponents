using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseMessaging",
	LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
        Frameworks = "AddressBook SystemConfiguration",
        LinkerFlags = "-lsqilte3",
        SmartLink = true,
	ForceLoad = true)]
