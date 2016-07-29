using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseDynamicLinks",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     Frameworks = "AssetsLibrary CoreLocation CoreMotion MessageUI QuartzCore SafariServices",
		     ForceLoad = true,
		     SmartLink = true)]
