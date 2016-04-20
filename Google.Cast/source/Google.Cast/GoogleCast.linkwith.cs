using System;
using System.Reflection;

using ObjCRuntime;
using Foundation;

[assembly: LinkWith ("GoogleCast", 
	LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, 
	Frameworks = "Accelerate AudioToolbox AVFoundation CFNetwork CoreBluetooth CoreText MediaPlayer Security SystemConfiguration UIKit", 
	LinkerFlags = "-ObjC -lc++",
	SmartLink = true,
	ForceLoad = true)]