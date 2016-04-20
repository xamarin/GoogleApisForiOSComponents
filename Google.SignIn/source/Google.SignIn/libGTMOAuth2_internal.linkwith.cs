using System;
using ObjCRuntime;

[assembly: LinkWith ("libGTMOAuth2_internal.a", LinkTarget.ArmV7 | LinkTarget.Simulator64 | LinkTarget.Simulator | LinkTarget.Arm64, SmartLink = true, ForceLoad = true)]
