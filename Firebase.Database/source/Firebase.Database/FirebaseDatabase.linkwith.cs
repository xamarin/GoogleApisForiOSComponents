using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseDatabase",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     Frameworks = "CFNetwork Security SystemConfiguration",
		     LinkerFlags = "-ObjC -lc++ -licucore",
		     ForceLoad = true,
		     SmartLink = true)]
