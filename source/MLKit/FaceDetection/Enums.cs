using System;
using ObjCRuntime;

namespace MLKit.FaceDetection {
	[Native]
	public enum FaceClassificationMode : long {
		None = 1,
		All = 2
	}

	[Native]
	public enum FacePerformanceMode : long {
		Fast = 1,
		Accurate = 2
	}

	[Native]
	public enum FaceLandmarkMode : long {
		None = 1,
		All = 2
	}

	[Native]
	public enum FaceContourMode : long {
		None = 1,
		All = 2
	}
}
