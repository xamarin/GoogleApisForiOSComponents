using System;
using MonoTouch.Dialog;
using Foundation;
using UIKit;
using ObjCRuntime;
using CoreGraphics;
using Google.Analytics;

namespace CuteAnimalsiOS
{
	public class DVCMenu : DialogViewController
	{
		public DVCMenu () : base (null)
		{
			Root = new RootElement ("Cute Animals") {
				new Section () {
					new StringElement ("Cute Monkey Pictures!", () => {
						var categoryView = new DVCCategory ("Monkey", 8);
						NavigationController.PushViewController (categoryView, true);
					}),
					new StringElement ("Cute Cat Pictures!", () => {
						var categoryView = new DVCCategory ("Cat", 4);
						NavigationController.PushViewController (categoryView, true);
					}),
					new StringElement ("Cute Bunny Pictures!", () => {
						var categoryView = new DVCCategory ("Bunny", 3);
						NavigationController.PushViewController (categoryView, true);
					}),
					new StringElement ("Cute Lion Pictures!", () => {
						var categoryView = new DVCCategory ("Lion", 4);
						NavigationController.PushViewController (categoryView, true);
					}),
					new StringElement ("Cute Tiger Pictures!", () => {
						var categoryView = new DVCCategory ("Tiger", 2);
						NavigationController.PushViewController (categoryView, true);
					}),
				}
			};
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Create a GA event and dispatch it to GA.
			NavigationItem.LeftBarButtonItem = new UIBarButtonItem ("Dispatch", UIBarButtonItemStyle.Plain, (s, e) => {
				var gaEvent = DictionaryBuilder.CreateEvent ("UI", "buttonPress", "dispatch", null).Build ();
				Gai.SharedInstance.DefaultTracker.Send (gaEvent);
				Gai.SharedInstance.Dispatch ();
				Console.WriteLine ("Event Sent, Check Google's GA Event Console");
			});

			// Create a Crash
			NavigationItem.RightBarButtonItem = new UIBarButtonItem ("Crash", UIBarButtonItemStyle.Plain, (s, e) => {
				var obj = new NSObject ();
				obj.PerformSelector (new Selector ("doesNotRecognizeSelector"), obj, 0);
			});
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			// This screen name value will remain set on the tracker and sent with
			// hits until it is set to a new value or to null.
			Gai.SharedInstance.DefaultTracker.Set (GaiConstants.ScreenName, "Main Menu");

			Gai.SharedInstance.DefaultTracker.Send (DictionaryBuilder.CreateScreenView ().Build ());
		}
	}
}

