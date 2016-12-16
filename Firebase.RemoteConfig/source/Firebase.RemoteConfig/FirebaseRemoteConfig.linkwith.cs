using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseRemoteConfig",
	LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
	LinkerFlags = "-lsqlite3 -lz",
	SmartLink = true,
	ForceLoad = true)]
