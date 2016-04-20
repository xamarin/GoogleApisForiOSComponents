using System;
using ObjCRuntime;

[assembly: LinkWith ("libGTM_StringEncoding.a", LinkTarget.ArmV7 | LinkTarget.Simulator64 | LinkTarget.Simulator | LinkTarget.Arm64, SmartLink = true, ForceLoad = true)]
