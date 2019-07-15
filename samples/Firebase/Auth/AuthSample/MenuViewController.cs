using System;
using MonoTouch.Dialog;
using UIKit;
using Foundation;
using ObjCRuntime;

namespace AuthSample
{
	public class MenuViewController : DialogViewController
	{
		public MenuViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			Root = new RootElement ("Firebase Auth Sample") {
				new Section ("Select your authentication method") {
					new StringElement ("Password Authentication", () => OpenViewController (new PasswordLoginViewController ())) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Phone Number Authentication", () => {
						if (Runtime.Arch == Arch.SIMULATOR) {
							AppDelegate.ShowMessage ("Hey!", "To see this auth in action, you must run the sample on a device.", NavigationController);
							return;
						}

						if (NSUserDefaults.StandardUserDefaults.StringForKey ("") == null)
							OpenViewController (new PhoneNumberViewController ());
						else {
							UIViewController [] viewControllers = { NavigationController.TopViewController, new PhoneNumberViewController (), new VerificationCodeViewController () };
							NavigationController.SetViewControllers (viewControllers, true);
						}
					}) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Google Sign-In", () => {
						var storyboard = UIStoryboard.FromName ("Main", NSBundle.MainBundle);
						var viewController = storyboard.InstantiateViewController ("SignInLoginViewControllerID") as SignInLoginViewController;
						OpenViewController (viewController); 
					}) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Facebook Login", () => { 
						var storyboard = UIStoryboard.FromName ("Main", NSBundle.MainBundle);
						var viewController = storyboard.InstantiateViewController ("FacebookLoginViewControllerID") as FacebookLoginViewController;
						OpenViewController (viewController);
					}) {
						Alignment = UITextAlignment.Center
					}
				}
			};
		}

		void OpenViewController (UIViewController viewController)
		{
			NavigationController.PushViewController (viewController, true);
		}
	}
}
