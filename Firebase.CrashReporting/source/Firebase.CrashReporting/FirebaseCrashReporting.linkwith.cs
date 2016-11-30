using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseCrash",
                     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     Frameworks = "CoreTelephony SystemConfiguration",
                     LinkerFlags = "-lc++",
                     SmartLink = true,
                     ForceLoad = true)]
