using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseCore",
                     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     Frameworks = "SystemConfiguration",
                     LinkerFlags = "-lc++",
                     SmartLink = true,
                     ForceLoad = true)]

[assembly: LinkWith ("GoogleToolboxForMac",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     Frameworks = "SystemConfiguration",
		     LinkerFlags = "-lz",
		     SmartLink = true,
		     ForceLoad = true)]

[assembly: LinkWith ("nanopb",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     SmartLink = true,
		     ForceLoad = true)]

[assembly: LinkWith ("GTMSessionFetcher",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     Frameworks = "Security",
		     SmartLink = true,
		     ForceLoad = true)]

[assembly: LinkWith ("Protobuf",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     SmartLink = true,
		     ForceLoad = true)]
