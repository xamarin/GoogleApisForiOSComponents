using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Google.InstanceID;

namespace InstanceIDSample
{
	partial class MainViewController : UIViewController
	{
		public MainViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            textView.Text = string.Empty;

            AppDelegate.LoggedMessage += (string msg) => {
                textView.Text = textView.Text + Environment.NewLine + msg;

                textView.ScrollRangeToVisible (new NSRange (textView.Text.Length - 1, 1));
            };
        }
	}
}
