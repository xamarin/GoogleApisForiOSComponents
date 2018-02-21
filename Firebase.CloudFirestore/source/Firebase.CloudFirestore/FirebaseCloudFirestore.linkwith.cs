using ObjCRuntime;

[assembly: LinkWith ("FirebaseFirestore",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     Frameworks = "MobileCoreServices",
		     SmartLink = true,
		     ForceLoad = true)]

[assembly: LinkWith ("BoringSSL",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     SmartLink = true,
		     ForceLoad = true)]

[assembly: LinkWith ("gRPC",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     SmartLink = true,
		     ForceLoad = true)]

[assembly: LinkWith ("gRPC-Core",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     LinkerFlags = "-lc++ -lz",
		     SmartLink = true,
		     ForceLoad = true)]

[assembly: LinkWith ("gRPC-ProtoRPC",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     SmartLink = true,
		     ForceLoad = true)]

[assembly: LinkWith ("gRPC-RxLibrary",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     SmartLink = true,
		     ForceLoad = true)]
