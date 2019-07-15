// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace StorageSample
{
	[Register ("NoteCell")]
	partial class NoteCell
	{
		[Outlet]
		UIKit.UILabel LblDate { get; set; }

		[Outlet]
		UIKit.UILabel LblPreview { get; set; }

		[Outlet]
		UIKit.UILabel LblTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LblTitle != null) {
				LblTitle.Dispose ();
				LblTitle = null;
			}

			if (LblDate != null) {
				LblDate.Dispose ();
				LblDate = null;
			}

			if (LblPreview != null) {
				LblPreview.Dispose ();
				LblPreview = null;
			}
		}
	}
}
