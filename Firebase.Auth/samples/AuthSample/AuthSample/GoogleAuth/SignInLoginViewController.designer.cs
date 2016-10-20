// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AuthSample
{
	[Register ("SignInLoginViewController")]
	partial class SignInLoginViewController
	{
		[Outlet]
		Google.SignIn.SignInButton BtnSignIn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnSignIn != null) {
				BtnSignIn.Dispose ();
				BtnSignIn = null;
			}
		}
	}
}
