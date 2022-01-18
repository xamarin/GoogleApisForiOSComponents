using System;
using ObjCRuntime;

namespace MLKit.ObjectDetection {
	[Native]
	public enum DetectedObjectLabelIndex : long {
		FashionGood = 0,
		HomeGood = 1,
		Food = 2,
		Place = 3,
		Plant = 4
	}
}
