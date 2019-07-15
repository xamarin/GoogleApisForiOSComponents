using System;

using Foundation;
using UIKit;

namespace DatabaseSample
{
	public partial class FolderCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("FolderCellID");

		protected FolderCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
