using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseAnalytics", 
                     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     Frameworks = "AddressBook AdSupport SafariServices StoreKit SystemConfiguration",
                     LinkerFlags = "-lc++ -lsqlite3 -lz",
                     ForceLoad = true,
                     SmartLink = true)]

[assembly: LinkWith ("GoogleSymbolUtilities",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     ForceLoad = true,
		     SmartLink = true)]

[assembly: LinkWith ("GoogleUtilities",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     ForceLoad = true,
		     SmartLink = true)]

[assembly: LinkWith ("GoogleInterchangeUtilities",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     ForceLoad = true,
		     SmartLink = true)]
