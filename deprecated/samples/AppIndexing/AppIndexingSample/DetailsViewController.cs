using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AppIndexingSample
{
	partial class DetailsViewController : UIViewController
	{
		public DetailsViewController () : base ()
		{
		}

		public DetailsViewController (IntPtr handle) : base (handle)
		{
		}

		public Gizmo Gizmo { get; set; }

		public override void ViewDidLoad ()
		{
			NavigationItem.Title = Gizmo.Name + " Details";
			labelGizmo.Text = Gizmo.Name;
		}
	}
}
