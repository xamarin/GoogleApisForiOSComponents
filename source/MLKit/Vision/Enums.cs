using System;
using ObjCRuntime;

namespace MLKit.Vision {
	[Native]
	public enum DetectorMode : long {
		SingleImage = 0,
		Stream = 1
	}
}
