using System;

using UIKit;
using Firebase.CrashReporting;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace CrashReportingSample
{
	public partial class CrashViewController : UIViewController, IUITextFieldDelegate
	{
		
		public CrashViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			BtnCrash.TouchUpInside += BtnCrash_TouchUpInside;
			SwtLog.ValueChanged += SwtLog_ValueChanged;
			TxtLog.Delegate = this;
		}

		void BtnCrash_TouchUpInside (object sender, EventArgs e)
		{
			if (SwtLog.On)
				CrashReporting.Log (TxtLog.Text);

			// Create a Crash
			var crash = new NSObject ();
			crash.PerformSelector (new Selector ("doesNotRecognizeSelector"), crash, 0);
		}

		void SwtLog_ValueChanged (object sender, EventArgs e)
		{
			TxtLog.Enabled = SwtLog.On;
		}

		#region UITextField Delegate

		[Export ("textFieldShouldReturn:")]
		public bool ShouldReturn (UITextField textField)
		{
			textField.ResignFirstResponder ();
			return false;
		}

		#endregion
	}
}

