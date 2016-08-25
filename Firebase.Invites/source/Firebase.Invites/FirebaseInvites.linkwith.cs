using ObjCRuntime;

[assembly: LinkWith ("FirebaseInvites",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true,
	ForceLoad = true,
    Frameworks = "CoreGraphics Security")]

[assembly: LinkWith ("GoogleParsingUtilities",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true,
	ForceLoad = true)]

[assembly: LinkWith ("GooglePlusUtilities",
	LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
	SmartLink = true,
	ForceLoad = true)]
