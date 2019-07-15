using System;
using ObjCRuntime;

[assembly: LinkWith ("libGTLPlusV1Private.a", LinkTarget.ArmV7 | LinkTarget.Simulator64 | LinkTarget.Simulator | LinkTarget.Arm64, SmartLink = true, ForceLoad = true)]
