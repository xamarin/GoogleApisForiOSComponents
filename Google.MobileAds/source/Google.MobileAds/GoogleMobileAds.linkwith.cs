using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleMobileAds",
	LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
	LinkerFlags = "-ObjC",
	Frameworks = "AdSupport AudioToolbox AVFoundation CoreGraphics CoreMedia CoreTelephony EventKit EventKitUI MediaPlayer MessageUI StoreKit SystemConfiguration",
	ForceLoad = true,
	SmartLink = true)]
