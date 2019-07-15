using System;
using ObjCRuntime;

[assembly: LinkWith ("libGcmLib.a", 
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, 
	IsCxx = true,
	LinkerFlags = "-ObjC -lsqlite3",
	SmartLink = true)]
 