using System;
using Foundation;
namespace Firebase.Database
{
	public partial class DatabaseReference
	{
		public void SetValue<T> (T value) where T : NSObject
		{
			if (!VerifyValidType (value))
				throw new InvalidOperationException ("Invalid parameter types");

			_SetValue (value);
		}

		public void SetValues (NSObject [] values)
		{
			if (values == null)
				_SetValue (null);

			var nsArray = VerifyArray (values);

			_SetValue (nsArray);
		}

		public void SetValues<T> (T [] values) where T : NSObject
		{
			if (values == null)
				_SetValue (null);

			var nsArray = VerifyArray (values);

			_SetValue (nsArray);
		}

		public void SetValue<T> (T value, DatabaseReferenceCompletionHandler completionHandler) where T : NSObject
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));

			if (!VerifyValidType (value))
				throw new InvalidOperationException ("Invalid parameter types");

			_SetValue (value, completionHandler);
		}

		public void SetValues (NSObject [] values, DatabaseReferenceCompletionHandler completionHandler)
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));

			if (values == null)
				_SetValue (null, completionHandler);

			var nsArray = VerifyArray (values);

			_SetValue (nsArray, completionHandler);
		}

		public void SetValue<T> (T value, NSObject priority) where T : NSObject
		{
			if (!VerifyValidType (value))
				throw new InvalidOperationException ("Invalid parameter types");

			_SetValue (value, priority);
		}

		public void SetValues (NSObject [] values, NSObject priority)
		{
			if (values == null)
				_SetValue (null, priority);

			var nsArray = VerifyArray (values);

			_SetValue (nsArray, priority);
		}

		public void SetValues<T> (T [] values, NSObject priority) where T : NSObject
		{
			if (values == null)
				_SetValue (null, priority);

			var nsArray = VerifyArray (values);

			_SetValue (nsArray, priority);
		}

		public void SetValue<T> (T value, NSObject priority, DatabaseReferenceCompletionHandler completionHandler) where T : NSObject
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));

			if (!VerifyValidType (value))
				throw new InvalidOperationException ("Invalid parameter types");

			_SetValue (value, priority, completionHandler);
		}

		public void SetValues (NSObject [] values, NSObject priority, DatabaseReferenceCompletionHandler completionHandler)
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));
			
			if (values == null)
				_SetValue (null, priority);

			var nsArray = VerifyArray (values);

			_SetValue (nsArray, priority, completionHandler);
		}

		public void SetValues<T> (T [] values, NSObject priority, DatabaseReferenceCompletionHandler completionHandler) where T : NSObject
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));

			if (values == null)
				_SetValue (null, priority);

			var nsArray = VerifyArray (values);

			_SetValue (nsArray, priority, completionHandler);
		}

		public void SetValueOnDisconnect<T> (T value) where T : NSObject
		{
			if (!VerifyValidType (value))
				throw new InvalidOperationException ("Invalid parameter types");

			_SetValueOnDisconnect (value);
		}

		public void SetValuesOnDisconnect (NSObject [] values)
		{
			if (values == null)
				_SetValueOnDisconnect (null);

			var nsArray = VerifyArray (values);

			_SetValueOnDisconnect (nsArray);
		}

		public void SetValuesOnDisconnect<T> (T [] values) where T : NSObject
		{
			if (values == null)
				_SetValueOnDisconnect (null);

			var nsArray = VerifyArray (values);

			_SetValueOnDisconnect (nsArray);
		}

		public void SetValueOnDisconnect<T> (T value, DatabaseReferenceCompletionHandler completionHandler) where T : NSObject
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));

			if (!VerifyValidType (value))
				throw new InvalidOperationException ("Invalid parameter types");

			_SetValueOnDisconnect (value, completionHandler);
		}

		public void SetValuesOnDisconnect (NSObject [] values, DatabaseReferenceCompletionHandler completionHandler)
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));

			if (values == null)
				_SetValueOnDisconnect (null, completionHandler);

			var nsArray = VerifyArray (values);

			_SetValueOnDisconnect (nsArray, completionHandler);
		}

		public void SetValuesOnDisconnect<T> (T [] values, DatabaseReferenceCompletionHandler completionHandler) where T : NSObject
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));

			if (values == null)
				_SetValueOnDisconnect (null, completionHandler);

			var nsArray = VerifyArray (values);

			_SetValueOnDisconnect (nsArray, completionHandler);
		}

		public void SetValueOnDisconnect<T> (T value, NSObject priority) where T : NSObject
		{
			if (priority == null)
				throw new ArgumentNullException (nameof (priority));

			if (!VerifyValidType (value))
				throw new InvalidOperationException ("Invalid parameter types");

			_SetValueOnDisconnect (value, priority);
		}

		public void SetValuesOnDisconnect (NSObject [] values, NSObject priority)
		{
			if (priority == null)
				throw new ArgumentNullException (nameof (priority));

			if (values == null)
				_SetValueOnDisconnect (null, priority);

			var nsArray = VerifyArray (values);

			_SetValueOnDisconnect (nsArray, priority);
		}

		public void SetValuesOnDisconnect<T> (T [] values, NSObject priority) where T : NSObject
		{
			if (priority == null)
				throw new ArgumentNullException (nameof (priority));

			if (values == null)
				_SetValueOnDisconnect (null, priority);

			var nsArray = VerifyArray (values);

			_SetValueOnDisconnect (nsArray, priority);
		}

		public void SetValueOnDisconnect<T> (T value, NSObject priority, DatabaseReferenceCompletionHandler completionHandler) where T : NSObject
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));

			if (!VerifyValidType (value))
				throw new InvalidOperationException ("Invalid parameter types");

			_SetValueOnDisconnect (value, priority, completionHandler);
		}

		public void SetValuesOnDisconnect (NSObject [] values, NSObject priority, DatabaseReferenceCompletionHandler completionHandler)
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));

			if (values == null)
				_SetValueOnDisconnect (null, priority, completionHandler);

			var nsArray = VerifyArray (values);

			_SetValueOnDisconnect (nsArray, priority, completionHandler);
		}

		public void SetValuesOnDisconnect<T> (T [] values, NSObject priority, DatabaseReferenceCompletionHandler completionHandler) where T : NSObject
		{
			if (completionHandler == null)
				throw new ArgumentNullException (nameof (completionHandler));

			if (values == null)
				_SetValueOnDisconnect (null, priority, completionHandler);

			var nsArray = VerifyArray (values);

			_SetValueOnDisconnect (nsArray, priority, completionHandler);
		}

		bool VerifyValidType<T> (T value) where T : NSObject
		{
			return value == null ||
				value is NSString ||
				value is NSNumber ||
				value is NSDictionary ||
				value is NSArray;
		}

		NSArray VerifyArray<T> (T [] values) where T : NSObject
		{
			if (values.Length > 0 && !VerifyValidType (values [0]))
				throw new InvalidOperationException ("Invalid parameter types");

			var nsArray = NSArray.FromNSObjects (values.Length, values);
			if (nsArray == null)
				throw new InvalidOperationException ("Invalid parameter types");

			return nsArray;
		}
	}

	public partial class DataSnapshot
	{
		public NSObject GetValue ()
		{
			var ret = _Value;
			if (ret == IntPtr.Zero)
				return null;

			var nsObject = ObjCRuntime.Runtime.GetNSObject<NSObject> (ret);
			return nsObject;
		}

		public T GetValue<T> () where T : NSObject
		{
			var ret = _Value;
			if (ret == IntPtr.Zero)
				return null;

			var nsObject = ObjCRuntime.Runtime.GetNSObject<T> (ret);
			return nsObject;
		}

		public NSObject [] GetValues ()
		{
			var ret = _Value;
			if (ret == IntPtr.Zero)
				return null;

			var objects = NSArray.ArrayFromHandle<NSObject> (ret);
			return objects;
		}

		public T [] GetValues<T> () where T : NSObject
		{
			var ret = _Value;
			if (ret == IntPtr.Zero)
				return null;

			var objects = NSArray.ArrayFromHandle<T> (ret);
			return objects;
		}
	}

	public partial class MutableData
	{
		public NSObject GetValue ()
		{
			var ret = _Value;
			if (ret == IntPtr.Zero)
				return null;

			var nsObject = ObjCRuntime.Runtime.GetNSObject<NSObject> (ret);
			return nsObject;
		}

		public T GetValue<T> () where T : NSObject
		{
			var ret = _Value;
			if (ret == IntPtr.Zero)
				return null;

			var nsObject = ObjCRuntime.Runtime.GetNSObject<T> (ret);
			return nsObject;
		}

		public NSObject [] GetValues ()
		{
			var ret = _Value;
			if (ret == IntPtr.Zero)
				return null;

			var objects = NSArray.ArrayFromHandle<NSObject> (ret);
			return objects;
		}

		public T [] GetValues<T> () where T : NSObject
		{
			var ret = _Value;
			if (ret == IntPtr.Zero)
				return null;

			var objects = NSArray.ArrayFromHandle<T> (ret);
			return objects;
		}

		public void SetValue<T> (T value) where T : NSObject
		{
			if (!VerifyValidType (value))
				throw new InvalidOperationException ("Invalid parameter types");
			
			_Value = value == null ? IntPtr.Zero : value.Handle;
		}

		public void SetValues (NSObject [] values)
		{
			if (values == null)
				_Value = IntPtr.Zero;

			var nsArray = VerifyArray (values);

			_Value = nsArray.Handle;
		}

		public void SetValues<T> (T [] values) where T : NSObject
		{
			if (values == null)
				_Value = IntPtr.Zero;

			var nsArray = VerifyArray (values);

			_Value = nsArray.Handle;
		}

		bool VerifyValidType<T> (T value) where T : NSObject
		{
			return value == null ||
				value is NSNull ||
				value is NSString ||
				value is NSNumber ||
				value is NSDictionary ||
				value is NSArray;
		}

		NSArray VerifyArray<T> (T [] values) where T : NSObject
		{
			if (values.Length > 0 && !VerifyValidType (values [0]))
				throw new InvalidOperationException ("Invalid parameter types");

			var nsArray = NSArray.FromNSObjects (values.Length, values);
			if (nsArray == null)
				throw new InvalidOperationException ("Invalid parameter types");

			return nsArray;
		}
	}
}
