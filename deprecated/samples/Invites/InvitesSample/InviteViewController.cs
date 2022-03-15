using System;
using MonoTouch.Dialog;
using UIKit;

using Firebase.Invites;
using Google.SignIn;
using Firebase.Analytics;
using Foundation;
using CoreGraphics;

namespace InvitesSample
{
	public class InviteViewController : DialogViewController, IInviteDelegate
	{
		EntryElement txtTitle;
		StyledStringElement lblMessage;
		UITextView txtMessage;
		EntryElement txtDeepLink;
		StyledStringElement lblDescription;
		EntryElement txtCustomImage;
		EntryElement txtCallToAction;
		EntryElement txtAndroidId;
		StringElement btnSendInvite;

		public InviteViewController () : base (UITableViewStyle.Grouped, null, false)
		{
			Root = CreateUI ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			txtMessage.Changed += Changed;
			TableView.KeyboardDismissMode = UIScrollViewKeyboardDismissMode.Interactive;
		}

		// NOTE: You must have the App Store ID set in your developer console project
		// in order for invitations to successfully be sent.
		public void SendInvite ()
		{
			if (string.IsNullOrWhiteSpace (txtTitle.Value) ||
			    string.IsNullOrWhiteSpace (txtMessage.Text)) {
				AppDelegate.ShowMessage ("Some information is missing…", "Please, fill all fields marked with *.", ParentViewController);
				return;
			}

			// When you create the invitation dialog, you must specify the title
			// of the invitation dialog and the invitation message to send. 
			// You can also customize the image and deep link URL that 
			// get sent in the invitation
			var inviteDialog = Invites.GetInviteDialog ();
			inviteDialog.SetInviteDelegate (this);
			inviteDialog.SetTitle (txtTitle.Value);
			inviteDialog.SetMessage (txtMessage.Text);

			if (!string.IsNullOrWhiteSpace (txtDeepLink.Value))
				inviteDialog.SetDeepLink (txtDeepLink.Value);

			if (!string.IsNullOrWhiteSpace (txtCustomImage.Value))
				inviteDialog.SetCustomImage (txtCustomImage.Value);

			if (!string.IsNullOrWhiteSpace (txtCallToAction.Value))
				inviteDialog.SetCallToActionText (txtCallToAction.Value);


			// If you have an Android version of your app and you want to send
			// an invitation that can be opened on Android in addition to iOS
			if (!string.IsNullOrWhiteSpace (txtAndroidId.Value)) {
				var targetApp = new InvitesTargetApplication { AndroidClientId = txtAndroidId.Value };
				inviteDialog.SetOtherPlatformsTargetApplication (targetApp);
			}

			inviteDialog.Open ();
		}

		// Invitations are sent by email or SMS.
		// After the user sends the invitation this method is called
		[Export ("inviteFinishedWithInvitations:error:")]
		public void InviteFinished (string [] invitationIds, NSError error)
		{
			if (error == null) {
				AppDelegate.ShowMessage ("Invitations sent!", string.Empty, ParentViewController);
				var ids = string.Join (", ", invitationIds);
				Console.WriteLine ($"Invitations sent to ids: {ids}");
			} else {
				AppDelegate.ShowMessage ("Something wrong happened…", error.LocalizedDescription, ParentViewController);
			}
		}

		void Changed (object sender, EventArgs e)
		{
			var textView = sender as UITextView;

			lblMessage.Value = textView.Text.Length <= 0 ? "Up to 100 characters" : textView.Text.Length.ToString ();
			Root.Reload (lblMessage, UITableViewRowAnimation.None);
		}

		RootElement CreateUI ()
		{
			txtTitle = new EntryElement ("*Title", "Your title", string.Empty);
			lblMessage = new StyledStringElement ("*Message", "Up to 100 characters") {
				BackgroundColor = UIColor.White,
			};
			txtMessage = new UITextView (new CGRect (0, 0, UIScreen.MainScreen.Bounds.Width, 80)) {
				TextAlignment = UITextAlignment.Justified,
				Font = UIFont.FromName ("System", 10)
			};
			txtDeepLink = new EntryElement ("Deep Link", "Your deep link", string.Empty);
			lblDescription = new StyledStringElement ("Description", "Up to 1000 characters") {
				BackgroundColor = UIColor.White
			};
			txtCustomImage = new EntryElement ("Custom Image", "An url image", string.Empty);
			txtCallToAction = new EntryElement ("Call To Action", "Invitation button title", string.Empty); ;
			txtAndroidId = new EntryElement ("Android Id", "Your android id", string.Empty); ;
			btnSendInvite = new StyledStringElement ("Send Invite", SendInvite) {
				Alignment = UITextAlignment.Center,
				TextColor = UIColor.Blue,
				BackgroundColor = UIColor.White
			};

			return new RootElement ("Firebase Invites") {
				new Section ("Invitation Info", "* Required Information") {
					txtTitle,
					lblMessage,
					new UIViewElement (string.Empty, txtMessage, false) {
						Flags = UIViewElement.CellFlags.DisableSelection
					},
					txtDeepLink,
					lblDescription,
					txtCustomImage,
					txtCallToAction,
					txtAndroidId
				},
				new Section {
					btnSendInvite
				},
				new Section {
					new StyledStringElement ("Sign Out", SignOut) {
						Alignment = UITextAlignment.Center,
						TextColor = UIColor.Red,
						BackgroundColor = UIColor.White
					},
					new StyledStringElement ("Disconnect", Disconnect) {
						Alignment = UITextAlignment.Center,
						TextColor = UIColor.Red,
						BackgroundColor = UIColor.White
					}
				}
			};
		}

		void SignOut ()
		{
			SignIn.SharedInstance.SignOutUser ();
			NavigationController.PopViewController (true);
		}

		void Disconnect ()
		{
			SignIn.SharedInstance.DisconnectUser ();
		}
	}
}
