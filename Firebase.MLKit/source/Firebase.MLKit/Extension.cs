using System;
using Foundation;
namespace Firebase.MLKit.ModelInterpreter {
	public partial class ModelInputOutputOptions {
		public bool SetInputFormat (nuint index, ModelElementType type, nuint [] dimensions, out NSError error)
		{
			var nsDimensions = NSArray.FromNSObjects ((d) => NSNumber.FromNUInt (d), dimensions);
			return _SetInputFormat (index, type, nsDimensions, out error);
		}

		public bool SetOutputFormat (nuint index, ModelElementType type, nuint [] dimensions, out NSError error)
		{
			var nsDimensions = NSArray.FromNSObjects ((d) => NSNumber.FromNUInt (d), dimensions);
			return _SetOutputFormat (index, type, nsDimensions, out error);
		}
	}

	public partial class ModelInputs {
		public bool AddInput (NSData input, out NSError error)
		{
			if (input == null)
				throw new ArgumentNullException (nameof (input));

			return _AddInput (input, out error);
		}

		public bool AddInput (NSArray input, out NSError error)
		{
			if (input == null)
				throw new ArgumentNullException (nameof (input));

			return _AddInput (input, out error);
		}

		public bool AddInput (NSNumber [] input, out NSError error)
		{
			if (input == null)
				throw new ArgumentNullException (nameof (input));

			return _AddInput (NSArray.FromNSObjects (input), out error);
		}

		public bool AddInput (float [] input, out NSError error)
		{
			if (input == null)
				throw new ArgumentNullException (nameof (input));

			var nsInput = NSArray.FromNSObjects ((i) => NSNumber.FromFloat (i), input);
			return _AddInput (nsInput, out error);
		}

		public bool AddInput (int [] input, out NSError error)
		{
			if (input == null)
				throw new ArgumentNullException (nameof (input));

			var nsInput = NSArray.FromNSObjects ((i) => NSNumber.FromInt32 (i), input);
			return _AddInput (nsInput, out error);
		}

		public bool AddInput (long [] input, out NSError error)
		{
			if (input == null)
				throw new ArgumentNullException (nameof (input));

			var nsInput = NSArray.FromNSObjects<long> ((i) => NSNumber.FromLong ((nint)i), input);
			return _AddInput (nsInput, out error);
		}

		public bool AddInput (nuint [] input, out NSError error)
		{
			if (input == null)
				throw new ArgumentNullException (nameof (input));

			var nsInput = NSArray.FromNSObjects ((i) => NSNumber.FromNUInt (i), input);
			return _AddInput (nsInput, out error);
		}
	}
}
