using System;
using MonoTouch.Dialog;
using UIKit;
using Foundation;

namespace CloudMessagingSample
{
	public class UserInfoViewController : DialogViewController
	{

		public UserInfoViewController (AppDelegate appDelegate) : base (UITableViewStyle.Grouped, null, true)
		{
			Root = new RootElement ("Notification Content");
			appDelegate.NotificationReceived += AppDelegate_NotificationReceived;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			AppDelegate.ShowMessage ("Hey!", "To see this sample in action, send a notification from Firebase Console", this, () => {
				AppDelegate.ConnectToFCM (this);
			});
		}

		void AppDelegate_NotificationReceived (object sender, UserInfoEventArgs e)
		{
			var notificationSection = new Section ();
			var apsDictionary = e.UserInfo ["aps"] as NSDictionary;

			string body;
			if (apsDictionary ["alert"] is NSDictionary) {
				var alertDictionary = apsDictionary ["alert"] as NSDictionary;

				if (alertDictionary.ContainsKey (new NSString ("title")))
					notificationSection.Caption = alertDictionary ["title"].ToString ();

				body = alertDictionary ["body"].ToString ();
			} else {
				body = apsDictionary ["alert"].ToString ();
			}

			notificationSection.Add (new StringElement ("Body", body));
			AddCustomData (e.UserInfo, notificationSection);
			Root.Add (notificationSection);
		}

		void AddCustomData (NSDictionary userInfo, Section notificationSection)
		{
			foreach (var key in userInfo.Keys) {
				if (key.ToString () == "aps" ||
				    key.ToString ().StartsWith ("gcm", StringComparison.InvariantCulture) ||
				    key.ToString ().StartsWith ("google", StringComparison.InvariantCulture))
					continue;

				notificationSection.Add (new StringElement (key.ToString (), userInfo [key].ToString ()));
			}
		}
	}

	public class UserInfoEventArgs : EventArgs
	{
		public NSDictionary UserInfo { get; set; }
	}
}
