using System;
using System.Runtime.InteropServices;
using Foundation;
using CoreFoundation;
using ObjCRuntime;

namespace MLKit.Core {
	public interface ILocalModelPath : INativeObject, IDisposable { }
	public interface ILocalModelManifestPath : INativeObject, IDisposable { }

	public class LocalModelPath : CFString, ILocalModelPath {
		public static LocalModelPath From (string path) => new LocalModelPath (path);
		public LocalModelPath (string path) : base (path) { }
	}

	public class LocalModelManifestPath : CFString, ILocalModelManifestPath {
		public static LocalModelManifestPath From (string path) => new LocalModelManifestPath (path);
		public LocalModelManifestPath (string path) : base (path) { }
	}
}
