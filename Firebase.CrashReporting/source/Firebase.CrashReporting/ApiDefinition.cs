using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.CrashReporting
{
	// @interface FIRCrash : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRCrash")]
	interface CrashReporting
	{
		// + (FIRCrash *)sharedInstance NS_SWIFT_NAME(sharedInstance());
		[Static]
		[Export ("sharedInstance")]
		CrashReporting SharedInstance { get; }

		// @property(nonatomic, assign, getter=isCrashCollectionEnabled) BOOL crashCollectionEnabled;
		[Export ("crashCollectionEnabled")]
		bool CrashCollectionEnabled { get; set; }
	}
}
