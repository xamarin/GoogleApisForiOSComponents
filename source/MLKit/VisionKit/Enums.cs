using System;
using ObjCRuntime;

namespace MLKit.VisionKit {
	[Native]
	public enum DetectorMode : long {
		SingleImage = 0,
		Stream = 1
	}
}
