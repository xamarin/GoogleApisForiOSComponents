using System;

using Foundation;
using UIKit;

namespace CloudFirestoreSample
{
	public partial class NoteTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString (nameof (NoteTableViewCell));

		public string Title {
			get => LblTitle.Text;
			set => LblTitle.Text = value;
		}

		public string Subtitle {
			get => LblSubtitle.Text;
			set => LblSubtitle.Text = value;
		}

		public string Preview {
			get => LblPreview.Text;
			set => LblPreview.Text = value;
		}

		protected NoteTableViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
