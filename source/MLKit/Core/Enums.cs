using System;
using ObjCRuntime;

namespace MLKit.Core {
	[Native]
	public enum ImageSourceType : long {
		ImageSourceTypeImage = 0,
		ImageSourceTypePixelBuffer = 1,
		ImageSourceTypeSampleBuffer = 2
	}
}
