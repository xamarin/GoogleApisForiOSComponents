using System;

using Foundation;
using UIKit;

namespace DatabaseSample
{
	public partial class NoteCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("NoteCellID");

		public string TitleText {
			get { return LblTitle.Text; }
			set { LblTitle.Text = value; }
		}

		public string SubtitleText {
			get { return LblSubtitle.Text; }
			set { LblSubtitle.Text = value; }
		}

		public string PreviewText {
			get { return LblPreview.Text; }
			set { LblPreview.Text = value; }
		}

		protected NoteCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
