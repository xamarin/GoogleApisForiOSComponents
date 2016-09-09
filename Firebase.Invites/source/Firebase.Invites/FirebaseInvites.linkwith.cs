using ObjCRuntime;

[assembly: LinkWith ("FirebaseInvites",
                     LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
		     Frameworks = "CoreGraphics Security",
		     LinkerFlags = "-ObjC",
		     SmartLink = true,
                     ForceLoad = true)]

[assembly: LinkWith ("GoogleParsingUtilities",
                     LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
                     SmartLink = true,
                     ForceLoad = true)]

[assembly: LinkWith ("GooglePlusUtilities",
                     LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
                     SmartLink = true,
                     ForceLoad = true)]
