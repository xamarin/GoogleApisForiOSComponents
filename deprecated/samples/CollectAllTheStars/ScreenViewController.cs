
using System;

using Foundation;
using UIKit;
using Google.Play.GameServices;
using System.Collections.Generic;
using CoreGraphics;
using Google.SignIn;

namespace CollectAllTheStars
{
	//    @interface GCATViewController () <GPGStatusDelegate, UIPickerViewDelegate,
	//    GPGSnapshotListLauncherDelegate, UIPickerViewDataSource, UIActionSheetDelegate>
	//    @property (nonatomic) BOOL currentlySigningIn;
	//    @property (nonatomic) int currentWorld;
	//    @property (nonatomic) int pickerSelectedRow;
	//    @property (nonatomic, strong) GCATModel *gameModel;
	//
	//
	public partial class ScreenViewController : UIViewController, IStatusDelegate, IUIPickerViewDelegate, ISnapshotListLauncherDelegate, IUIPickerViewDataSource, IUIActionSheetDelegate, ISignInUIDelegate
	{
		//static NSString kDeclinedGooglePreviously = "UserDidDeclineGoogleSignIn";

		const string CLIENT_ID = "1041063143217-rdc97s7jssl1k29c83b6oci04sihqkdi.apps.googleusercontent.com";

		public ScreenViewController () : base ("ScreenViewController", null)
		{
		}

		public bool CurrentlySigningIn { get; set; }

		public int CurrentWorld { get; set; }

		public int PickerSelectedRow { get; set; }

		public Model GameModel { get; set; }

		public List<UIButton> LevelButtons { get; set; } = new List<UIButton> ();

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SignIn.SharedInstance.UIDelegate = this;

			LevelButtons = new List<UIButton> {
				level1, level2, level3, level4, level5, level6,
				level7, level8, level9, level10, level11, level12
			};

			signinButton.TouchUpInside += delegate {
				Manager.SharedInstance.SignIn (CLIENT_ID, false);
			};

			signoutButton.TouchUpInside += delegate {
				Manager.SharedInstance.Signout ();
			};

			listButton.TouchUpInside += delegate {
				LauncherController.SharedInstance.PresentSnapshotList ();    
			};

			loadButton.TouchUpInside += delegate {
				loadFromTheCloud ();
			};

			saveButton.TouchUpInside += delegate {
				saveToTheCloud ();
			};

			changeButton.TouchUpInside += delegate {
				var menu = new UIActionSheet ("Choose World", null, "Done", "Cancel", null);

				menu.Clicked += (sender, e) => {

					if (e.ButtonIndex == 1) { //Done
						CurrentWorld = PickerSelectedRow + 1;
						refreshStarDisplay ();
					}
				};

				// Add the picker
				var pickerView = new UIPickerView (new CGRect (0, 185, 0, 0));
				pickerView.Delegate = this;
				pickerView.ShowSelectionIndicator = true;    // note this is default to NO

				//[pickerView selectRow:self.currentWorld - 1 inComponent:0 animated:YES];

				menu.AddSubview (pickerView);
				menu.ShowInView (View);
				menu.Bounds = new CGRect (0, 0, 320, 700);
			};

			foreach (var levelButton in LevelButtons) {
				levelButton.TouchUpInside += LevelButtonClicked;
			}

			CurrentWorld = 1;
			GameModel = new Model ();
			GameModel.ScreenViewController = this;

			Manager.SharedInstance.SnapshotsEnabled = true;
			Manager.SharedInstance.StatusDelegate = this;

			CurrentlySigningIn = Manager.SharedInstance.SignIn (CLIENT_ID, true);

			refreshButtons ();
		}

		void LevelButtonClicked (object sender, EventArgs e)
		{
			var button = (UIButton)sender;

			var levelNum = LevelButtons.IndexOf (button) + 1;
			var starNum = GameModel.GetStars (CurrentWorld, levelNum) + 1;

			if (starNum > 5)
				starNum = 0;

			GameModel.SetStars (CurrentWorld, levelNum, starNum);

			saveButton.SetTitle ("Save *", UIControlState.Normal);
			refreshStarDisplay ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			refreshButtons ();
			refreshStarDisplay ();
		}

		void startGoogleGamesSignIn ()
		{
			Manager.SharedInstance.SnapshotsEnabled = true;
			Manager.SharedInstance.SignIn (CLIENT_ID, false);
		}


		[Export ("didFinishGamesSignInWithError:")]
		public void GamesSignInFinished (NSError error)
		{
			if (error != null) {
				Console.WriteLine ("ERROR signing in: {0}", error.LocalizedDescription);
			} else {
				Console.WriteLine ("Finished with games sign in!");
				loadFromTheCloud ();
			}

			CurrentlySigningIn = false;
			refreshButtons ();
			refreshStarDisplay ();
		}


		[Export ("didFinishGamesSignOutWithError:")]
		public virtual void GamesSignOutFinished (NSError error)
		{
			if (error != null)
				Console.WriteLine ("ERROR signing out: {0}", error.LocalizedDescription);

			CurrentlySigningIn = false;
			refreshButtons ();
		}

		void refreshButtons ()
		{
			var signedIn = Manager.SharedInstance.SignedIn;

			foreach (var b in LevelButtons)
				b.Hidden = !signedIn;

			signinButton.Hidden = signedIn;
			signinLabel.Hidden = signedIn;
			signoutButton.Hidden = !signedIn;
			worldLabel.Hidden = !signedIn;
			changeButton.Hidden = !signedIn;
			loadButton.Hidden = !signedIn;
			saveButton.Hidden = !signedIn;
			listButton.Hidden = !signedIn;

			if (CurrentlySigningIn) {
				signinButton.Enabled = false;
				signinIndicator.StartAnimating ();
				signinLabel.Text = "Please wait...";
			} else {
				signinButton.Enabled = true;
				signinIndicator.StopAnimating ();
				signinLabel.Text = "Please Sign-In To Begin";
			}
			// Consider showing a "Loading" animation here as well.
		}



		public void AllDoneWithCloud ()
		{

		}

		//[Export ("snapshotListLauncherDidTapSnapshotMetadata:")]
		public void SnapshotMetadataTapped (SnapshotMetadata snapshot)
		{
			Console.WriteLine ("Selected snapshot metadata: {0}", snapshot.SnapshotDescription);
			GameModel.LoadSnapshot (snapshot);
		}

		//[Export ("snapshotListLauncherDidCreateNewSnapshot")]
		public void NewSnapshotCreated ()
		{
			Console.WriteLine ("New snapshot selected");
		}

		[Export ("maxSaveSlotsForSnapshotListLauncher")]
		public virtual int MaxSaveSlots ()
		{
			return 3;
		}

		[Export ("shouldAllowCreateForSnapshotListLauncher")]
		public virtual bool ShouldAllowCreate ()
		{
			// Make this YES if you want users to enable more than 1 save slot
			return false;
		}


		// In a real game, we'd probably want to save and load behind the scenes.
		// Here we're calling these explicitly through buttons so you can try out
		// different scenarios.
		void saveToTheCloud ()
		{
			View.BringSubviewToFront (saveIndicator);
			saveIndicator.StartAnimating ();

			loadButton.Enabled = false;
			saveButton.Enabled = false;
			listButton.Enabled = false;

			GameModel.SaveSnapshot (TakeScreenshot ());
		}

		void loadFromTheCloud ()
		{
			View.BringSubviewToFront (loadIndicator);
			loadIndicator.StartAnimating ();
			loadButton.Enabled = false;
			saveButton.Enabled = false;
			listButton.Enabled = false;

			GameModel.LoadSnapshot (null);
		}

		// Update our level buttons
		void refreshStarDisplay ()
		{
			char blackStar = (char)0x2605;
			char whitestar = (char)0x2606;

			for (int i = 0; i < LevelButtons.Count; i++) {
				int level = i + 1;
				int starCount = GameModel.GetStars (CurrentWorld, level);

				var blackStarText = PadString ("", blackStar, starCount);
				var starText = PadString (blackStarText, whitestar, 5);

				var buttonText = CurrentWorld + "-" + level + "\n" + starText;

				var button = LevelButtons [i];
				button.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
				button.TitleLabel.TextAlignment = UITextAlignment.Center;
				button.SetTitle (buttonText, UIControlState.Normal);
			}

			worldLabel.Text = "World " + CurrentWorld;
		}

		string PadString (string str, char padWith, int count)
		{
			var fstr = str;

			int i = 0;
			while (i < count) {
				i++;
				fstr = padWith.ToString () + str;
			}

			return fstr;
		}

		public nint GetComponentCount (UIPickerView pickerView)
		{
			return 1;
		}

		public nint GetRowsInComponent (UIPickerView pickerView, nint component)
		{
			return 20;
		}

		[Export ("pickerView:titleForRow:forComponent:")]
		public string GetTitle (UIKit.UIPickerView pickerView, System.nint row, System.nint component)
		{
			return string.Format ("World {0}", ((int)row + 1));
		}

		[Export ("pickerView:didSelectRow:inComponent:")]
		public void Selected (UIKit.UIPickerView pickerView, System.nint row, System.nint component)
		{
			PickerSelectedRow = (int)row;
		}

		UIImage TakeScreenshot ()
		{
			UIGraphics.BeginImageContext (View.Bounds.Size);
			View.Layer.RenderInContext (UIGraphics.GetCurrentContext ());
			var srcImage = UIGraphics.GetImageFromCurrentImageContext ();
			UIGraphics.EndImageContext ();

			UIGraphics.BeginImageContext (View.Frame.Size);
			srcImage.Draw (new CoreGraphics.CGPoint (0, -160));
			var croppedImage = UIGraphics.GetImageFromCurrentImageContext ();
			UIGraphics.EndImageContext ();

			return croppedImage;
		}
	}
}

