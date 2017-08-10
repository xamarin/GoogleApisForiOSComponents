using System;
using MonoTouch.Dialog;
namespace AuthSample
{
	public class PasswordContext
	{
		[Section]
		[Entry ("Your email")]
		public string Email { get; set; }

		[Password ("Your password")]
		public string Password { get; set; }

		[Section]
		[Alignment (UIKit.UITextAlignment.Center)]
		[OnTap ("Login")]
		public string Login { get; set; }

		[Section]
		[Alignment (UIKit.UITextAlignment.Center)]
		[OnTap ("RegisterNewAccount")]
		public string RegisterNewAccount { get; set; }

		[Alignment (UIKit.UITextAlignment.Center)]
		[Caption ("Forgot Password?")]
		[OnTap ("SendPasswordReset")]
		public string ForgotPassword { get; set; }

	}
}
