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
	[Register ("FacebookLoginViewController")]
	partial class FacebookLoginViewController
	{
		[Outlet]
		Facebook.LoginKit.LoginButton BtnLogin { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnLogin != null) {
				BtnLogin.Dispose ();
				BtnLogin = null;
			}
		}
	}
}
