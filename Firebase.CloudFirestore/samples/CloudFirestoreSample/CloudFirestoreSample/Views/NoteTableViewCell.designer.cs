// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CloudFirestoreSample
{
	[Register ("NoteTableViewCell")]
	partial class NoteTableViewCell
	{
		[Outlet]
		UIKit.UILabel LblPreview { get; set; }

		[Outlet]
		UIKit.UILabel LblSubtitle { get; set; }

		[Outlet]
		UIKit.UILabel LblTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LblPreview != null) {
				LblPreview.Dispose ();
				LblPreview = null;
			}

			if (LblSubtitle != null) {
				LblSubtitle.Dispose ();
				LblSubtitle = null;
			}

			if (LblTitle != null) {
				LblTitle.Dispose ();
				LblTitle = null;
			}
		}
	}
}
