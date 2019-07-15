using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using ObjCRuntime;
using Foundation;
using System.Linq;

namespace Firebase.Storage
{
	public partial class Storage
	{
		static string currentVersion;
		public static string CurrentVersion {
			get {
				if (currentVersion == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "FIRStorageVersionString");
					currentVersion = Marshal.PtrToStringAnsi (ptr);
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return currentVersion;
			}
		}
	}

	public partial class StorageMetadata
	{
		public StorageMetadata (Dictionary<object, object> dictionary) : this (NSDictionary.FromObjectsAndKeys (dictionary.Values.ToArray (), dictionary.Keys.ToArray (), dictionary.Keys.Count))
		{
		}
	}

	public partial class StorageTaskSnapshot
	{
		public StorageTask GetTask ()
		{
			var task = Runtime.GetNSObject<StorageTask> (_Task);
			return task;
		}

		public T GetTask<T> () where T : StorageTask
		{
			var task = Runtime.GetNSObject<T> (_Task);
			return task;
		}
	}
}
