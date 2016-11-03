// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DatabaseSample
{
	[Register ("NoteCell")]
	partial class NoteCell
	{
		[Outlet]
		UIKit.UILabel LblPreview { get; set; }

		[Outlet]
		UIKit.UILabel LblSubtitle { get; set; }

		[Outlet]
		UIKit.UILabel LblTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LblTitle != null) {
				LblTitle.Dispose ();
				LblTitle = null;
			}

			if (LblSubtitle != null) {
				LblSubtitle.Dispose ();
				LblSubtitle = null;
			}

			if (LblPreview != null) {
				LblPreview.Dispose ();
				LblPreview = null;
			}
		}
	}
}
