using System;
using ObjCRuntime;

[assembly: LinkWith ("libProtocolBuffers.a", 
    LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator64 | LinkTarget.Arm64, 
    SmartLink = true)]
