using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleMobileAds",
	LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
	LinkerFlags = "-ObjC",
	Frameworks = "AudioToolbox AVFoundation CoreGraphics CoreMedia CoreMotion CoreTelephony CoreVideo GLKit MediaPlayer MessageUI MobileCoreServices OpenGLES StoreKit SystemConfiguration",
        WeakFrameworks = "AdSupport SafariServices",
	ForceLoad = true,
	SmartLink = true)]
// CoreBluetooth EventKit EventKitUI QuartzCore