using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using ObjCRuntime;
using Foundation;
using System.Linq;

namespace Firebase.Storage
{
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
