using ObjCRuntime;

[assembly: LinkWith ("FirebaseInvites",
                     LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
		     Frameworks = "AddressBook AssetsLibrary CoreMotion MessageUI QuartzCore CoreGraphics Security",
		     LinkerFlags = "-ObjC -lc++",
		     SmartLink = true,
                     ForceLoad = true)]

[assembly: LinkWith ("GoogleAPIClientForREST",
                     LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
                     SmartLink = true,
                     ForceLoad = true)]
