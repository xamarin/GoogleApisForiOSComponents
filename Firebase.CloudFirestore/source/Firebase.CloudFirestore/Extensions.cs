using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using Foundation;

namespace Firebase.CloudFirestore
{
	class CloudFirestoreHelper
	{
		public static NSObject [] GetNSObjects (object [] objects)
		{
			if (objects == null)
				return null;

			var nsObjects = new NSObject [objects.Length];

			for (int i = 0; i < objects.Length; i++)
				nsObjects [i] = NSObject.FromObject (objects [i]);

			return nsObjects;
		}
	}

	public partial class Firestore
	{
		public delegate NSObject FirestoreUpdateHandler (Transaction transaction, out NSError error);

		public void RunTransaction (FirestoreUpdateHandler updateHandler, TransactionCompletionHandler completion)
		{
			_RunTransaction (InternalUpdateHandler, completion);

			NSObject InternalUpdateHandler (Transaction transaction, IntPtr pError)
			{
				if (updateHandler == null)
					return null;

				var result = updateHandler (transaction, out NSError error);

				if (error != null)
					Marshal.WriteIntPtr (pError, error.Handle);

				return result;
			}
		}

		public Task<NSObject> RunTransactionAsync (FirestoreUpdateHandler updateHandler)
		{
			var tcs = new TaskCompletionSource<NSObject> ();
			RunTransaction (updateHandler, (result_, error_) => {
				if (error_ != null)
					tcs.SetException (new NSErrorException (error_));
				else
					tcs.SetResult (result_);
			});
			return tcs.Task;
		}
	}
}
