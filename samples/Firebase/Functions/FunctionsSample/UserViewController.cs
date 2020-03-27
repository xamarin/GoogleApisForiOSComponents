using System;
using MonoTouch.Dialog;
using UIKit;
using Firebase.Auth;
using CoreGraphics;
using Foundation;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace FunctionsSample
{
	public class UserViewController : DialogViewController
	{
		StringElement lblProvider;
		EntryElement txtName;
		

		public UserViewController () : base (UITableViewStyle.Grouped, null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitializeContent ();
			CreateUI ();
		}

		void InitializeContent ()
		{
			lblProvider = new StringElement ("Provider", "LblProvider");
			txtName = new EntryElement ("Name", string.Empty, "TxtName");
		}

		void CreateUI ()
		{
			List<Section> sections = new List<Section> ();

			lblProvider.Value = "LblProvider";
			txtName.Value = "TxtName";
			var userDataSection = new Section {
				lblProvider,
				txtName
			};

			sections.Add (userDataSection);

			Root = new RootElement ("Your information") {
				sections
			};
		}
	}
}
