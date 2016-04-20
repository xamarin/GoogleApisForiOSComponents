Configuring your App
--------------------

Google provides an easy to use configuration web tool to generate a config file for your app:  

1. Open [Google's configuration tool][1] to create a config file for your app.
2. Enter your app's name and iOS Bundle ID and click continue
3. Enter your App Store ID and click *Enable App Invites*
   (If you don't have an App Store ID you can use one of our favorites - 1000846120 or 783488172)
4. Click *continue* to generate the configuration files
5. Click *Download Google-Service-Info.plist*
6. Add `GoogleService-Info.plist` to your Xamarin.iOS app project and set the *Build Action* to `BundleResource`
7. In your Xamarin.iOS app project's `Info.plist` file, add the following URL Types:
  - Identifier: `google` Role: `Editor` URL Schemes: `your.app.bundle.id` 
  - Identifier: `google` Role: `Editor` URL Schemes: `value of REVERSED_CLIENT_ID from GoogleService-Info.plist`
  

Setup your AppDelegate
----------------------

In order for App Invites to work properly, you must tell the SDK about some of your application lifecycle events.

In your `AppDelegate.cs`, in the `FinishedLaunching (..)` override, you should add the following code to the start of the method:

```csharp
NSError configureError;
Context.SharedInstance.Configure (out configureError);
if (configureError != null)
	Console.WriteLine ("Error configuring the Google context: {0}", configureError);
 
Invite.ApplicationDidFinishLaunching ();
```

Next, add the following override to your AppDelegate class (or if it already exists, add the code inside the method to the existing implementation:

```csharp
public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
{
	// Handle App Invite requests
	var invite = Invite.HandleUrl (url, sourceApplication, annotation);
	if (invite != null) {
		var message =string.Format ("Deep link from {0} \nInvite ID: {1}\nApp URL: {2}",
			sourceApplication, invite.InviteId, invite.DeepLink);
		new UIAlertView (@"Deep-link Data", message, null, "OK").Show ();
		return true;
	}
 
	return SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);
}
```


Signing In
----------

In order for app invites to work, your app's user must sign in to their Google account.  To do this, you should request a login in your View Controller.  This can be done in the `ViewDidLoad` override:

```csharp
// Sign the user in automatically
SignIn.SharedInstance.UIDelegate = this;
SignIn.SharedInstance.Delegate = this;
SignIn.SharedInstance.SignInUser ();
```
You also must implement `ISignInDelegate` as well as `ISignInUIDelegate` and provide a `DidSignIn` method to know when the sign-in completed and if it was successful:

```csharp
public void DidSignIn (SignIn signIn, GoogleUser user, NSError error)
{
	if (user != null && error == null)
		// Enable App Invite button
}
```
For more information on Google Sign-In please refer to the [Getting Started Guide][2]

Displaying the AppInvite UI
---------------------------

Once your user is signed in, you can display the AppInvite UI with the following code:

```csharp
var inviteDialog = Invite.InviteDialog;
inviteDialog.SetInviteDelegate (this);
 
// NOTE: You must have the App Store ID set in your developer console project
// in order for invitations to successfully be sent.
var message = string.Format ("Try this out!\n -{0}",
	SignIn.SharedInstance.CurrentUser.Profile.Name);
 
// A message hint for the dialog. Note this manifests differently depending on the
// received invation type. For example, in an email invite this appears as the subject.
inviteDialog.SetMessage (message);
 
// Title for the dialog, this is what the user sees before sending the invites.
inviteDialog.SetTitle ("App Invites Example");
inviteDialog.SetDeepLink ("app_url");
inviteDialog.Open ();
```

You can should also implement `IInviteDelegate` and optionally the `InviteFinished` method to be notified when the user has completed the AppInvite dialog:

```csharp
[Export ("inviteFinishedWithInvitations:error:")]
public virtual void InviteFinished (string[] invitationIds, NSError error)
{
	var message = error != null ? error.LocalizedDescription :
		string.Format ("{0} invites sent", invitationIds.Length);
 
	new UIAlertView ("Done", message, null, "OK").Show ();
}
```

[1]: https://developers.google.com/mobile/add?platform=ios&cntapi=appinvite
[2]: http://components.xamarin.com/gettingstarted/googleiosappinvite