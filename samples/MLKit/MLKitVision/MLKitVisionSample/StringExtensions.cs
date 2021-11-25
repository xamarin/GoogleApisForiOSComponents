using System.Text;
using UIKit;

namespace MLKitVisionSample {
	public static class StringExtensions {
		public static string GetTitle (this string value)
		{
			if (string.IsNullOrWhiteSpace (value))
				return value;

			var sb = new StringBuilder ();
			foreach (var c in value) {
				if (sb.Length > 0 && char.IsUpper (c)) {
					sb.Append (' ');
				}

				sb.Append (c);
			}

			return sb.ToString ();
		}
	}
}
