using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseAnalytics", 
                     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     Frameworks = "AddressBook AdSupport CoreGraphics StoreKit SystemConfiguration",
                     LinkerFlags = "-ObjC -lc++ -lsqlite3 -lz",
                     ForceLoad = true,
                     SmartLink = true)]
