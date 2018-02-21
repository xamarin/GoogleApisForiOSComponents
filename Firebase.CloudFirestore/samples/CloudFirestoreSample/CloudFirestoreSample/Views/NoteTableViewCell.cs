using System;

using Foundation;
using UIKit;

namespace CloudFirestoreSample
{
	public partial class NoteTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString (nameof (NoteTableViewCell));

		protected NoteTableViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
