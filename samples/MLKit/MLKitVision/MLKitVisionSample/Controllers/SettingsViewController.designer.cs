// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MLKitVisionSample {
	[Register ("SettingsViewController")]
	partial class SettingsViewController {
		[Outlet]
		UIKit.UITableView SettingsTable { get; set; }

		[Outlet]
		UIKit.UISegmentedControl SgmApi { get; set; }


		[Action ("BtnSave_Clicked:")]
		partial void BtnSave_Clicked (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (SettingsTable != null) {
				SettingsTable.Dispose ();
				SettingsTable = null;
			}

			if (SgmApi != null) {
				SgmApi.Dispose ();
				SgmApi = null;
			}
		}
	}
}
