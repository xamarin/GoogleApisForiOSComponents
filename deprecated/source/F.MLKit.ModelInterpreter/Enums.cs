using System;

using ObjCRuntime;

namespace Firebase.MLKit.ModelInterpreter {
	[Native]
	public enum ModelElementType : ulong {
		Unknown = 0,
		Float32,
		Int32,
		UInt8,
		Int64
	}
}
