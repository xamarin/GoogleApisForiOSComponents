using System;

using Foundation;
using UIKit;

namespace PerformanceMonitoringSample
{
	public partial class SettingTableViewCell : UITableViewCell
	{
		#region Properties

		public static readonly NSString Key = new NSString ("SettingTableViewCell");

		public string SettingTitle {
			get => LblSetting.Text;
			set => LblSetting.Text = value;
		}

		public bool SettingEnabled {
			get => SwtEnabled.On;
			set => SwtEnabled.On = value;
		}

		#endregion

		#region Constructors

		protected SettingTableViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		#endregion

		#region Public Funtionality

		public void SetEnabled (bool value, bool animated)
		{
			SwtEnabled.SetState (value, animated);
		}

		#endregion
	}
}
