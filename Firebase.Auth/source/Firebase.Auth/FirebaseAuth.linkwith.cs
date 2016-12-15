using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseAuth",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     Frameworks = "Security",
		     LinkerFlags = "-ObjC -lc++ -lsqlite3 -lz",
		     ForceLoad = true,
		     SmartLink = true)]

[assembly: LinkWith ("GoogleNetworkingUtilities",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     Frameworks = "Security",
		     ForceLoad = true,
		     SmartLink = true)]
