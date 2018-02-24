using ObjCRuntime;

[assembly: LinkWith ("GoogleSignIn",
                     LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
                     LinkerFlags = "-ObjC -lsqlite3",
                     Frameworks = "CoreText Security",
                     WeakFrameworks = "SafariServices",
                     SmartLink = true,
                     ForceLoad = true)]

[assembly: LinkWith ("GTMOAuth2",
                     LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
                     Frameworks = "Security SystemConfiguration",
                     SmartLink = true,
                     ForceLoad = true)]
