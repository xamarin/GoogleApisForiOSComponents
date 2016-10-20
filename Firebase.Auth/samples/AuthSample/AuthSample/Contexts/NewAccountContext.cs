using System;
using MonoTouch.Dialog;
namespace AuthSample
{
	public class NewAccountContext
	{
		[Section]
		[Entry ("Your email")]
		public string Email { get; set; }

		[Password ("Your password")]
		public string Password { get; set; }

		[Password ("Your password again")]
		public string PasswordVerify { get; set; }

		[Section]
		[Alignment (UIKit.UITextAlignment.Center)]
		[OnTap ("RegisterNewAccount")]
		public string RegisterNewAccount { get; set; }
	}
}
