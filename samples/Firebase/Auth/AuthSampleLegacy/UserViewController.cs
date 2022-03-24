using System;
using MonoTouch.Dialog;
using UIKit;
using Firebase.Auth;
using CoreGraphics;
using Foundation;
using System.Net;
using System.IO;
using Google.SignIn;
using System.Collections.Generic;
using Facebook.LoginKit;

namespace AuthSample
{
	public class UserViewController : DialogViewController
	{
		string authMethod;
		UIActivityIndicatorView indicatorView;

		EntryElement txtEmail;

		StyledStringElement lblEmailVerified;

		EntryElement txtPassword;
		EntryElement txtPasswordVerify;

		StringElement lblProvider;
		StringElement lblUid;
		EntryElement txtName;
		EntryElement txtPhotoUrl;
		UIViewElement imgPhotoContainer;
		UIImageView photo;

		string lastPhotoUrl;
		User user = Auth.DefaultInstance.CurrentUser;

		public UserViewController (string authMethod) : base (UITableViewStyle.Grouped, null)
		{
			this.authMethod = authMethod;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitializeContent ();
			CreateUI ();
		}

		void InitializeContent ()
		{
			if (authMethod == "Firebase") {
				txtEmail = new EntryElement ("Email", string.Empty, user.Email);

				lblEmailVerified = new StyledStringElement (string.Empty) {
					Alignment = UITextAlignment.Center,
					Font = UIFont.FromName ("System-Bold", 13),
					BackgroundColor = UIColor.White
				};

				txtPassword = new EntryElement ("Password", string.Empty, string.Empty, true);
				txtPasswordVerify = new EntryElement ("Password Verify", string.Empty, string.Empty, true);
			}

			lblProvider = new StringElement ("Provider", user.ProviderId);
			lblUid = new StringElement ("UID", user.Uid);
			txtName = new EntryElement ("Name", string.Empty, user.DisplayName);
			txtPhotoUrl = new EntryElement ("Photo Url", string.Empty, user.PhotoUrl?.AbsoluteString);
			photo = new UIImageView (new CGRect (0, 0, 128, 128)) {
				ContentMode = UIViewContentMode.ScaleAspectFit,
				Image = UIImage.FromFile ("user.png")
			};
			imgPhotoContainer = new UIViewElement (string.Empty, photo, true) {
				Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent
			};

			indicatorView = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge) {
				Frame = new CGRect (0, 0, 128, 128),
				BackgroundColor = UIColor.FromRGBA (127, 127, 127, 127),
				HidesWhenStopped = true,
				TranslatesAutoresizingMaskIntoConstraints = false
			};
		}

		void CreateUI ()
		{
			List<Section> sections = new List<Section> ();

			if (authMethod == "Firebase") {
				txtEmail.Value = user.Email;
				var emailSection = new Section {
					txtEmail,
					new StyledStringElement ("Update email", UpdateEmail) {
						Font = UIFont.FromName ("System-Bold", 13),
						Alignment = UITextAlignment.Center,
						BackgroundColor = UIColor.White
					}
				};

				var verificationEmailSection = new Section {
					lblEmailVerified
				};
				if (user.IsEmailVerified) {
					lblEmailVerified.Caption = "Email verified!";
					lblEmailVerified.TextColor = UIColor.Green;
				} else {
					lblEmailVerified.Caption = "Email needs verification!";
					lblEmailVerified.TextColor = UIColor.Red;
					verificationEmailSection.Add (
						new StyledStringElement ("Send verification email", SendVerifyEmail) {
							Font = UIFont.FromName ("System-Bold", 13),
							Alignment = UITextAlignment.Center,
							BackgroundColor = UIColor.White
						}
					);
				}

				var passwordSection = new Section {
					txtPassword,
					txtPasswordVerify,
					new StyledStringElement ("Update password", UpdatePassword) {
						Font = UIFont.FromName ("System-Bold", 13),
						Alignment = UITextAlignment.Center,
						BackgroundColor = UIColor.White
					}
				};

				sections.Add (emailSection);
				sections.Add (verificationEmailSection);
				sections.Add (passwordSection);
			}

			lblProvider.Value = user.ProviderId;
			lblUid.Value = user.Uid;
			txtName.Value = user.DisplayName;
			txtPhotoUrl.Value = user.PhotoUrl?.AbsoluteString;
			var userDataSection = new Section {
				lblProvider,
				lblUid,
				txtName,
				txtPhotoUrl,
				imgPhotoContainer,
				new StyledStringElement ("Update name and photo", UpdateNameAndPhoto) {
					Font = UIFont.FromName ("System-Bold", 13),
					Alignment = UITextAlignment.Center,
					BackgroundColor = UIColor.White
				}
			};

			var dangerSection = new Section {
				new StyledStringElement ("Logout", Logout) {
					Font = UIFont.FromName ("System-Bold", 13),
					Alignment = UITextAlignment.Center,
					TextColor = UIColor.Red,
					BackgroundColor = UIColor.White
				},
				new StyledStringElement ("Delete User", DeleteUser) {
					Font = UIFont.FromName ("System-Bold", 13),
					Alignment = UITextAlignment.Center,
					TextColor = UIColor.White,
					BackgroundColor = UIColor.Red
				}
			};

			sections.Add (userDataSection);
			sections.Add (dangerSection);
			View.Add (indicatorView);
			ApplyContraintsToIndicator ();

			Root = new RootElement ("Your information") {
				sections
			};

			if (PhotoExists (user.Uid) && lastPhotoUrl == user.PhotoUrl?.AbsoluteString)
				photo.Image = GetPhoto (user.Uid);
			else if (user.PhotoUrl != null) {
				DownloadPhoto (user.Uid, user.PhotoUrl.AbsoluteString);
				lastPhotoUrl = user.PhotoUrl.AbsoluteString;
			}
		}

		void UpdateEmail ()
		{
			var email = txtEmail.Value;

			if (string.IsNullOrWhiteSpace (email)) {
				AppDelegate.ShowMessage ("Hey!", "Youn need to type an email!", NavigationController);
				return;
			}

			indicatorView.StartAnimating ();
			View.EndEditing (true);

			user.UpdateEmail (email, (error) => {
				indicatorView.StopAnimating ();

				if (error != null) {
					AuthErrorCode errorCode;
					if (IntPtr.Size == 8) // 64 bits devices
						errorCode = (AuthErrorCode)((long)error.Code);
					else // 32 bits devices
						errorCode = (AuthErrorCode)((int)error.Code);

					// Posible error codes that UpdateEmail method could throw
					// Visit https://firebase.google.com/docs/auth/ios/errors for more information
					switch (errorCode) {
					case AuthErrorCode.EmailAlreadyInUse:
					case AuthErrorCode.InvalidEmail:
					case AuthErrorCode.RequiresRecentLogin:
					default:
						AppDelegate.ShowMessage ("Could not update the email!", error.LocalizedDescription, NavigationController);
						break;
					}
				} else {
					AppDelegate.ShowMessage ("Success!", "Email updated!", NavigationController);
				}
			});
		}

		void SendVerifyEmail ()
		{
			indicatorView.StartAnimating ();
			View.EndEditing (true);

			user.SendEmailVerification ((error) => {
				indicatorView.StopAnimating ();

				if (error != null) {
					AppDelegate.ShowMessage ("Could not send the email!", error.LocalizedDescription, NavigationController);
				} else {
					AppDelegate.ShowMessage ("Success!", $"Verification email sent to {user.Email}!", NavigationController);
				}
			});
		}

		void UpdatePassword ()
		{
			var password = txtPassword.Value;
			var passwordVerify = txtPasswordVerify.Value;

			if (string.IsNullOrWhiteSpace (password) ||
			    string.IsNullOrWhiteSpace (passwordVerify)) {
				AppDelegate.ShowMessage ("Hey!", "Seems that some information is missing...", NavigationController);
				return;
			}

			if (password != passwordVerify) {
				AppDelegate.ShowMessage ("Hey!", "Passwords don't match. Please, verify.", NavigationController);
				return;
			}

			indicatorView.StartAnimating ();
			View.EndEditing (true);

			user.UpdatePassword (password, (error) => {
				indicatorView.StopAnimating ();

				if (error != null) {
					AppDelegate.ShowMessage ("Could not update the password!", error.LocalizedDescription, NavigationController);
				} else {
					AppDelegate.ShowMessage ("Success!", "Password updated!", NavigationController);
					txtPassword.Value = string.Empty;
					txtPasswordVerify.Value = string.Empty;
					Root.Reload (txtPassword, UITableViewRowAnimation.None);
					Root.Reload (txtPasswordVerify, UITableViewRowAnimation.None);
				}
			});
		}

		void UpdateNameAndPhoto ()
		{
			var name = txtName.Value;
			var photoUrl = txtPhotoUrl.Value;

			if (string.IsNullOrWhiteSpace (name)) {
				AppDelegate.ShowMessage ("Hey!", "Please, enter a name...", NavigationController);
				return;
			}

			indicatorView.StartAnimating ();
			View.EndEditing (true);

			var changeRequest = user.ProfileChangeRequest ();
			changeRequest.DisplayName = name;
			changeRequest.PhotoUrl = new NSUrl (photoUrl);
			changeRequest.CommitChanges ((error) => {
				indicatorView.StopAnimating ();

				if (error != null) {
					AppDelegate.ShowMessage ("Could not update name and photo!", error.LocalizedDescription, NavigationController);
				} else {
					AppDelegate.ShowMessage ("Success!", "Name and photo updated!", NavigationController);

					if (PhotoExists (user.Uid) && lastPhotoUrl == user.PhotoUrl?.AbsoluteString)
						photo.Image = GetPhoto (user.Uid);
					else if (user.PhotoUrl != null) {
						DownloadPhoto (user.Uid, user.PhotoUrl.AbsoluteString);
						lastPhotoUrl = user.PhotoUrl.AbsoluteString;
					}
				}
			});
		}

		void Logout ()
		{
			NSError error;
			var signedOut = Auth.DefaultInstance.SignOut (out error);
			if (signedOut) {
				if (authMethod == "Google")
					SignIn.SharedInstance.SignOutUser ();
				else if (authMethod == "Facebook")
					new LoginManager ().LogOut ();

				NavigationController.PopToRootViewController (true);
			} else {
				AuthErrorCode errorCode;
				if (IntPtr.Size == 8) // 64 bits devices
					errorCode = (AuthErrorCode)((long)error.Code);
				else // 32 bits devices
					errorCode = (AuthErrorCode)((int)error.Code);

				// Posible error codes that SignOut method with credentials could throw
				// Visit https://firebase.google.com/docs/auth/ios/errors for more information
				switch (errorCode) {
				case AuthErrorCode.KeychainError:
				default:
					AppDelegate.ShowMessage ("Could not login!", error.LocalizedDescription, NavigationController);
					break;
				}
			}
		}

		void DeleteUser ()
		{
			user.Delete ((error) => {
				if (error != null) {
					AuthErrorCode errorCode;
					if (IntPtr.Size == 8) // 64 bits devices
						errorCode = (AuthErrorCode)((long)error.Code);
					else // 32 bits devices
						errorCode = (AuthErrorCode)((int)error.Code);

					// Posible error codes that Delete method could throw
					// Visit https://firebase.google.com/docs/auth/ios/errors for more information
					switch (errorCode) {
					case AuthErrorCode.RequiresRecentLogin:
					default:
						AppDelegate.ShowMessage ("Could delete the current user!", error.LocalizedDescription, NavigationController);
						break;
					}

					return;
				}

				if (authMethod == "Google")
					SignIn.SharedInstance.SignOutUser ();
				else if (authMethod == "Facebook")
					new LoginManager ().LogOut ();

				NavigationController.PopToRootViewController (true);
			});
		}

		bool PhotoExists (string userUid)
		{
			var tempPath = Path.GetTempPath ();
			var filename = $"{userUid}.png";
			var filePath = Path.Combine (tempPath, filename);

			return File.Exists (filePath);
		}

		UIImage GetPhoto (string userUid)
		{
			var tempPath = Path.GetTempPath ();
			var filename = $"{userUid}.png";
			var filePath = Path.Combine (tempPath, filename);

			return UIImage.FromFile (filePath);
		}

		void DownloadPhoto (string userUid, string url)
		{
			if (string.IsNullOrWhiteSpace (userUid) ||
			    string.IsNullOrWhiteSpace (url))
				return;

			var webClient = new WebClient ();
			webClient.DownloadDataCompleted += (sender, e) => {
				if (e.Error != null) {
					InvokeOnMainThread (() => {
						AppDelegate.ShowMessage ("Cannot update the photo...", e.Error.Message, NavigationController);
					});
					return;
				}

				var bytes = e.Result;
				var tempPath = Path.GetTempPath ();
				var filename = $"{userUid}.png";
				var filePath = Path.Combine (tempPath, filename);
				File.WriteAllBytes (filePath, bytes);

				InvokeOnMainThread (() => {
					photo.Image = GetPhoto (userUid);
					Root.Reload (imgPhotoContainer, UITableViewRowAnimation.None);
				});
			};
			webClient.DownloadDataAsync (new Uri (url));
		}

		void ApplyContraintsToIndicator ()
		{
			View.AddConstraint (NSLayoutConstraint.Create (indicatorView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, View, NSLayoutAttribute.Width, 1, 0));
			View.AddConstraint (NSLayoutConstraint.Create (indicatorView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, View, NSLayoutAttribute.Height, 1, 0));
			View.AddConstraint (NSLayoutConstraint.Create (indicatorView, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, View, NSLayoutAttribute.CenterX, 1, 0));
			View.AddConstraint (NSLayoutConstraint.Create (indicatorView, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, View, NSLayoutAttribute.CenterY, 1, 0));
		}
	}
}
