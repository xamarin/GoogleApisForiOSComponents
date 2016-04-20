using System;
using ObjCRuntime;

[assembly: LinkWith ("libGAIFieldExporter.a", 
	LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.Simulator64 | LinkTarget.Arm64,
	ForceLoad = true,
	SmartLink = true)]
