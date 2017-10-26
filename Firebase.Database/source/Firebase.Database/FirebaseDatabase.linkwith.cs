using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseDatabase",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     Frameworks = "CFNetwork Security SystemConfiguration",
		     LinkerFlags = "-ObjC -lc++ -licucore",
		     ForceLoad = true,
		     SmartLink = true)]

[assembly: LinkWith ("leveldb-library",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     ForceLoad = true,
		     SmartLink = true)]
