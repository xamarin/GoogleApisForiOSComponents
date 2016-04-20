using System;
using ObjCRuntime;

[assembly: LinkWith ("libGSDK_Overload.a", LinkTarget.ArmV7 | LinkTarget.Simulator64 | LinkTarget.Simulator | LinkTarget.Arm64, SmartLink = true, ForceLoad = true)]
