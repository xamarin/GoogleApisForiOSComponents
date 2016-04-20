using System;
using ObjCRuntime;

[assembly: LinkWith ("libGGLAppInvite.a", 
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	Frameworks = "AssetsLibrary CoreData CoreFoundation CoreGraphics CoreLocation CoreMotion MediaPlayer MessageUI MobileCoreServices QuartzCore",
	SmartLink = true, 
	ForceLoad = true)]
