using System;
using ObjCRuntime;

[assembly: LinkWith ("FirebaseStorage",
                     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     Frameworks = "MobileCoreServices",
                     SmartLink = true,
                     ForceLoad = true)]
