using System;
using MonoTouch.Dialog;
using UIKit;

namespace TagManagerSample
{
	public class UserPropertyContext
	{
		[Section ("Set a user property", "Leave a blank value if you want to remove a registered user property")]

		[Entry ("Type a name")]
		public string Name;

		[Entry ("Type a value")]
		public string Value;

		[Section]

		[Alignment (UITextAlignment.Center)]
		[OnTap ("PostUserProperty")]
		public string PostUserProperty;
	}
}

