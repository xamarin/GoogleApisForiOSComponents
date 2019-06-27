using System;
using ObjCRuntime;

[assembly: LinkWith ("libGGLInstanceIDLib.a", 
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, 
	Frameworks = "AddressBook Foundation",
	LinkerFlags = "-ObjC -lsqlite3",
	SmartLink = true, ForceLoad = true)]