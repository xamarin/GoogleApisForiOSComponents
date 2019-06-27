using System;

using Foundation;
using UIKit;

namespace CloudFirestoreSample
{
	public partial class FolderTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString (nameof (FolderTableViewCell));

		protected FolderTableViewCell (IntPtr handle) : base (handle)
		{
		}
	}
}
