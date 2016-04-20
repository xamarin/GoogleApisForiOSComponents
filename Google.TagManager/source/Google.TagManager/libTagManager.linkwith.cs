using System;
using ObjCRuntime;

[assembly: LinkWith ("libTagManager.a", 
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, 
	Frameworks = "CoreData SystemConfiguration",
	LinkerFlags = "-lsqlite3 -lz",
	ForceLoad = true,
	SmartLink = true)]
