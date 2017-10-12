using ObjCRuntime;

[assembly: LinkWith("GooglePlaces",
    LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
    SmartLink = true,
    ForceLoad = true)]

[assembly: LinkWith("GooglePlacePicker",
    LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
    SmartLink = true,
    ForceLoad = true)]
