using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using MonoTouch.Dialog;

namespace AppIndexingSample
{
	partial class MainViewController : DialogViewController
	{
		public MainViewController (IntPtr handle) : base (handle)
		{
		}

		public MainViewController () : base (UITableViewStyle.Plain, new RootElement ("Gizmos"), true)
		{
		}

		Gizmo SelectedGizmo { get; set; }

		public override void ViewDidLoad ()
		{
			var s = new Section ();
			foreach (var gizmo in Gizmos.All) {
				s.Add (new StyledStringElement (gizmo.Name, () => {
					SelectedGizmo = gizmo;
					PerformSegue ("Details", this);
				}));
			}
			Root.Add (s);
		}

		public void Select (Gizmo gizmo)
		{
			SelectedGizmo = gizmo;
			PerformSegue ("Details", this);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			var vc = segue.DestinationViewController as DetailsViewController;
			vc.Gizmo = SelectedGizmo;
		}
	}
}