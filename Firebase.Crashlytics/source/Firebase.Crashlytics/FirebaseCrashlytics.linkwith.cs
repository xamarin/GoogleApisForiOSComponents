using System;
using ObjCRuntime;

[assembly: LinkWith ("Crashlytics",
                     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     Frameworks = "Security SystemConfiguration",
                     LinkerFlags = "-lz -lc++",
                     SmartLink = true,
                     ForceLoad = true)]

[assembly: LinkWith ("Fabric",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     Frameworks = "UIKit",
		     SmartLink = true,
		     ForceLoad = true)]
