using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleTagManager", 
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, 
	Frameworks = "AdSupport CoreTelephony JavaScriptCore SystemConfiguration UIKit",
	LinkerFlags = "-lsqlite3 -lz",
	ForceLoad = true,
	SmartLink = true)]

[assembly: LinkWith ("GoogleUtilities",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	Frameworks = "AddressBook CoreGraphics",
	LinkerFlags = "-lz",
	ForceLoad = true,
	SmartLink = true)]

[assembly: LinkWith ("GoogleSymbolUtilities",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	ForceLoad = true,
	SmartLink = true)]
