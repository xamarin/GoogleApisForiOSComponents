using System;
using ObjCRuntime;

[assembly: LinkWith ("gpg", 
    LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, 
    SmartLink = true, 
    Frameworks = "AddressBook AssetsLibrary CoreData CoreLocation CoreMotion CoreText MediaPlayer QuartzCore Security SystemConfiguration CoreTelephony",
    LinkerFlags = "-ObjC -lc++ -lz",
    ForceLoad = true)]
