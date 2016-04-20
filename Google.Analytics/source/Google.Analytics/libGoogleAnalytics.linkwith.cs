using System;
using ObjCRuntime;

[assembly: LinkWith ("libGoogleAnalytics.a", 
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, 
	Frameworks = "CoreData SystemConfiguration",
	LinkerFlags = "-lsqlite3",
	IsCxx = true,
	ForceLoad = true,
	SmartLink = true)]