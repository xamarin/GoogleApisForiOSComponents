using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleAppIndexing", 
	LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.Simulator64 | LinkTarget.Arm64, 
	Frameworks = "CoreText",
	WeakFrameworks = "SafariServices",
	ForceLoad = true,
	SmartLink = true)]