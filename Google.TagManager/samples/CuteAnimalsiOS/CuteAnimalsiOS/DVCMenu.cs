using System;
using MonoTouch.Dialog;
using Foundation;
using UIKit;
using ObjCRuntime;
using CoreGraphics;
using Google.Analytics;
using Google.TagManager;
using System.Threading.Tasks;

namespace CuteAnimalsiOS
{
	public class DVCMenu : DialogViewController, IContainerOpenerNotifier
	{
		// To get a Container ID, create an account on https://www.google.com/analytics/tag-manager/
		// then, create a Container and you will obtain an ID. You can create many Containers as you wish
		string tagManagerContainerId = "GTM-XXXX";
		UIBarButtonItem btnRefresh;

		public DVCMenu () : base (null)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Root = new RootElement ("");

			// Send an event to TagManager
			NavigationItem.LeftBarButtonItem = new UIBarButtonItem ("Send event", UIBarButtonItemStyle.Plain, (s, e) => {
				AppDelegate.Manager.DataLayer.PushValue (new NSString ("sendEvent"), "event");
			});

			// Refresh container
			btnRefresh = new UIBarButtonItem ("Refresh", UIBarButtonItemStyle.Plain, async (s, e) => {
				btnRefresh.Enabled = false;

				// Refresh the information within the Container
				AppDelegate.Container.Refresh ();

				// Give some time to Container to retrieve information from Tag Manager
				await Task.Delay (200);

				// Refresh UI
				AddAnimals ();
				btnRefresh.Enabled = true;
			}) {
				Enabled = false
			};
			NavigationItem.RightBarButtonItem = btnRefresh;

			// Open the container
			ContainerOpener.OpenContainer (tagManagerContainerId, AppDelegate.Manager, OpenType.PreferFresh, null, this);
		}

		// Refresh UI
		void AddAnimals ()
		{
			// Get your Container User-Defined Variables defined on Tag Manager
			var title = AppDelegate.Container.StringForKey ("Title");
			var adjective = AppDelegate.Container.StringForKey ("Adjective");
			Title = $"{adjective} {title}";

			// Create the new section with the new values retreived
			var section = new Section ($"{adjective} Animals") { 
				new StringElement ($"{adjective} Monkey Pictures!", () => {
					var categoryView = new DVCCategory ("Monkey", 8);
					NavigationController.PushViewController (categoryView, true);
				}),
				new StringElement ($"{adjective} Cat Pictures!", () => { 
					var categoryView = new DVCCategory ("Cat", 4);
					NavigationController.PushViewController (categoryView, true);
				}),
				new StringElement ($"{adjective} Bunny Pictures!", () => {
					var categoryView = new DVCCategory ("Bunny", 3);
					NavigationController.PushViewController (categoryView, true);
				}),
				new StringElement ($"{adjective} Lion Pictures!", () => { 
					var categoryView = new DVCCategory ("Lion", 4);
					NavigationController.PushViewController (categoryView, true);
				}),
				new StringElement ($"{adjective} Tiger Pictures!", () => { 
					var categoryView = new DVCCategory ("Tiger", 2);
					NavigationController.PushViewController (categoryView, true);
				}),
			}; 

			Root.Clear ();
			Root.Add (section);
		}

		#region IContainerOpenerNotifier

		public void ContainerAvailable (Container container)
		{
			// Note that ContainerAvailable may be called on any thread, so you may need to dispatch back to
			// your main thread.
			InvokeOnMainThread (() => {
				// If container is available, save it somewhere within your app
				AppDelegate.Container = container;

				// Refresh UI
				AddAnimals ();
				btnRefresh.Enabled = true;
			});
		}

		#endregion
	}
}

