using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebasePerformanceMonitoring",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     Frameworks = "CoreTelephony SystemConfiguration",
                     LinkerFlags = "-lc++",
		     ForceLoad = true,
		     SmartLink = true)]
