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
		// id  _Nullable (^ _Nonnull)(FIRTransaction * _Nonnull, NSError * _Nullable * _Nullable)
		public delegate NSObject TransactionUpdateHandler (Transaction transaction, ref NSError error);

		public void RunTransaction (TransactionUpdateHandler updateHandler, TransactionCompletionHandler completion)
		{
			_RunTransaction (InternalUpdateHandler, completion);

			NSObject InternalUpdateHandler (Transaction transaction, IntPtr pError)
			{
				if (updateHandler == null)
					return null;

				NSError error = null;
				var result = updateHandler (transaction, ref error);

				if (error != null)
					Marshal.WriteIntPtr (pError, error.Handle);

				return result;
			}
		}

		public Task<NSObject> RunTransactionAsync (TransactionUpdateHandler updateHandler)
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
