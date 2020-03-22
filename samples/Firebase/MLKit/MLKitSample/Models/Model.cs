using System;
namespace MLKitSample {
	public struct Model : IEquatable<Model> {
		readonly string model;

		public static Model TextRecognition { get; } = new Model ("TextRecognition");
		public static Model FaceDetection { get; } = new Model ("FaceDetection");
		public static Model BarcodeScanning { get; } = new Model ("BarcodeScanning");
		public static Model LandmarkRecognition { get; } = new Model ("LandmarkRecognition");

		Model (string model)
		{
			if (model == null) throw new ArgumentNullException (nameof (model));
			if (model.Length == 0) throw new ArgumentException ("Value cannot be empty.", nameof (model));

			this.model = model;
		}

		public static Model Create (string model)
		{
			return new Model (model);
		}

		public bool Equals (Model other)
		{
			return Equals (other.model);
		}

		internal bool Equals (string other)
		{
			return string.Equals (model, other, StringComparison.Ordinal);
		}

		public override bool Equals (object obj)
		{
			return obj is Model && Equals ((Model)obj);
		}

		public override int GetHashCode ()
		{
			return model == null ? 0 : model.GetHashCode ();
		}

		public override string ToString ()
		{
			return model ?? string.Empty;
		}

		public static bool operator == (Model left, Model right)
		{
			return left.Equals (right);
		}

		public static bool operator != (Model left, Model right)
		{
			return !(left == right);
		}
	}
}
