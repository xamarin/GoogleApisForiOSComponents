using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleMaps", 
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true, 
	Frameworks = "Accelerate AVFoundation CoreBluetooth CoreData CoreLocation CoreText GLKit ImageIO OpenGLES QuartzCore Security SystemConfiguration CoreGraphics",
	LinkerFlags = "-ObjC -lz -licucore -lc++",
	IsCxx = true,
	ForceLoad = true)]