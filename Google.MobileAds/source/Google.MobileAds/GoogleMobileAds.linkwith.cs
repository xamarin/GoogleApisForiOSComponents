using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleMobileAds",
	LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
	LinkerFlags = "-ObjC",
	Frameworks = "AudioToolbox AVFoundation CoreBluetooth CoreGraphics CoreMedia CoreTelephony EventKit EventKitUI MediaPlayer MessageUI QuartzCore StoreKit SystemConfiguration",
        WeakFrameworks = "AdSupport SafariServices",
	ForceLoad = true,
	SmartLink = true)]
