// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CrashReportingSample
{
	[Register ("CrashViewController")]
	partial class CrashViewController
	{
		[Outlet]
		UIKit.UIButton BtnCrash { get; set; }

		[Outlet]
		UIKit.UISwitch SwtLog { get; set; }

		[Outlet]
		UIKit.UITextField TxtLog { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnCrash != null) {
				BtnCrash.Dispose ();
				BtnCrash = null;
			}

			if (SwtLog != null) {
				SwtLog.Dispose ();
				SwtLog = null;
			}

			if (TxtLog != null) {
				TxtLog.Dispose ();
				TxtLog = null;
			}
		}
	}
}
