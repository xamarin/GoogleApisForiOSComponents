using System;
using Foundation;
using ObjCRuntime;
using System.Runtime.InteropServices;
namespace Firebase.CloudFirestore
{
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
	}
}
