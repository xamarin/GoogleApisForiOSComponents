using System;
using ObjCRuntime;

[assembly: LinkWith ("gpg", 
	LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, 
	Frameworks = "AddressBook AssetsLibrary CoreData CoreLocation CoreTelephony CoreMotion CoreText MediaPlayer Security SystemConfiguration",
	LinkerFlags = "-ObjC -lc++ -lz",
	IsCxx = true,
	SmartLink = true,
	ForceLoad = true)]
