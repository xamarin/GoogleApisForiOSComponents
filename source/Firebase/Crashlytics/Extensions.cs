using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Firebase.Crashlytics {
	public partial class Crashlytics {
		public void LogCallerInformation (string message, string className = "", [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
		{
			var logBuilder = new StringBuilder ();

			if (!string.IsNullOrWhiteSpace (filePath)) {
				var filename = Path.GetFileName (filePath);
				logBuilder.Append ($"{filename}: ");
			}

			var isMemberNameEmpty = string.IsNullOrWhiteSpace (memberName);

			if (!string.IsNullOrWhiteSpace (className)) {
				logBuilder.Append ($"{className}");
				logBuilder.Append (isMemberNameEmpty ? " " : ".");
			}

			if (!isMemberNameEmpty)
				logBuilder.Append ($"{memberName} ");

			if (lineNumber > 0)
				logBuilder.Append ($"line {lineNumber} ");

			logBuilder.Append ($"$ {message}");
			Log (logBuilder.ToString ());
		}
	}
}
