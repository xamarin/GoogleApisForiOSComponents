using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseCore",
                     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     Frameworks = "SystemConfiguration",
                     LinkerFlags = "-lc++",
                     SmartLink = true,
                     ForceLoad = true)]

[assembly: LinkWith ("GoogleToolboxForMac",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     Frameworks = "SystemConfiguration",
		     LinkerFlags = "-lz",
		     SmartLink = true,
		     ForceLoad = true)]

// Used by Firebase.Analytics
[assembly: LinkWith ("nanopb",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     SmartLink = true,
		     ForceLoad = true)]

// Used by Firebase.Auth, Firebase.Invites, Firebase.Storage and Google.SignIn
[assembly: LinkWith ("GTMSessionFetcher",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     Frameworks = "Security",
		     SmartLink = true,
		     ForceLoad = true)]

// Used by Firebase.CrashReporting, Firebase.Invites and Firebase.RemoteConfig
[assembly: LinkWith ("Protobuf",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     SmartLink = true,
		     ForceLoad = true)]

// Used by Firebase.Database and Firebase.CloudFirestore
[assembly: LinkWith ("leveldb-library",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     ForceLoad = true,
		     SmartLink = true)]
