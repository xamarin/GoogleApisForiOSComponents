// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace PerformanceMonitoringSample
{
    [Register ("SettingTableViewCell")]
    partial class SettingTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblSetting { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwtEnabled { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LblSetting != null) {
                LblSetting.Dispose ();
                LblSetting = null;
            }

            if (SwtEnabled != null) {
                SwtEnabled.Dispose ();
                SwtEnabled = null;
            }
        }
    }
}