using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseInstanceID",
	LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
	SmartLink = true,
	ForceLoad = true)]
