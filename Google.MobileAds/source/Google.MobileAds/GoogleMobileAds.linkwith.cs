using System;
using ObjCRuntime;

[assembly: LinkWith ("GoogleMobileAds",
                     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
                     LinkerFlags = "-ObjC",
                     Frameworks = "AudioToolbox AVFoundation CoreGraphics CoreMedia CoreMotion CoreTelephony CoreVideo GLKit MediaPlayer MessageUI MobileCoreServices OpenGLES Security StoreKit SystemConfiguration",
                     WeakFrameworks = "AdSupport JavaScriptCore SafariServices WebKit",
                     ForceLoad = true,
                     SmartLink = true)]
