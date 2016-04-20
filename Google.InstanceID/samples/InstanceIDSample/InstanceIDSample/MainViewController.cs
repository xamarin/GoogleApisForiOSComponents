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

			buttonGenerateInstanceId.TouchUpInside += async (sender, e) => {

				buttonGenerateInstanceId.Enabled = false;
				buttonDeleteInstanceId.Enabled = false;

				try {

					// Create / Fetch the Instance ID
					var identity = await InstanceId.SharedInstance.GetIDAsync ();
					labelInstanceId.Text = identity;

					buttonGenerateInstanceId.Enabled = true;
					buttonDeleteInstanceId.Enabled = true;

				} catch (Exception ex) {

					buttonGenerateInstanceId.Enabled = true;
					buttonDeleteInstanceId.Enabled = false;

					var av = new UIAlertView ("Error", ex.Message, null, "OK");
					av.Show ();
				}
			};

			buttonDeleteInstanceId.TouchUpInside += async (sender, e) => {
				buttonGenerateInstanceId.Enabled = false;
				buttonDeleteInstanceId.Enabled = false;

				try {

					// Delete the Instance ID
					await InstanceId.SharedInstance.DeleteIDAsync ();

					labelInstanceId.Text = "No Instance ID";

					buttonGenerateInstanceId.Enabled = true;
					buttonDeleteInstanceId.Enabled = false;

				} catch (Exception ex) {

					buttonGenerateInstanceId.Enabled = true;
					buttonDeleteInstanceId.Enabled = true;

					var av = new UIAlertView ("Error", ex.Message, null, "OK");
					av.Show ();
				}
			};

//			buttonDeleteInstanceId.TouchUpInside += async (sender, e) => {
//				buttonGenerateInstanceId.Enabled = false;
//				buttonDeleteInstanceId.Enabled = false;
//
//				// Delete the Instance ID
//				InstanceId.SharedInstance.DeleteID (error => {
//					if (error != null) {
//						labelInstanceId.Text = "No Instance ID";
//
//						buttonGenerateInstanceId.Enabled = true;
//						buttonDeleteInstanceId.Enabled = false;
//					} else {
//						buttonGenerateInstanceId.Enabled = true;
//						buttonDeleteInstanceId.Enabled = true;
//
//						var av = new UIAlertView ("Error", error.LocalizedDescription, null, "OK");
//						av.Show ();
//					}
//				});
//
//			};

			InstanceId.SharedInstance.Start (Config.DefaultConfig);
		}
	}
}
