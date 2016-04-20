

Configuring your App
--------------------

Google provides an easy to use configuration web tool to generate a config file for your app:  

1. Open [Google's configuration tool][1] to create a config file for your app.
2. Enter your app's name and iOS Bundle ID and click continue
3. Click *Enable Sign-In*
4. Click *continue* to generate the configuration files
5. Click *Download Google-Service-Info.plist*
6. Add `GoogleService-Info.plist` to your Xamarin.iOS app project and set the *Build Action* to `BundleResource`
7. In your Xamarin.iOS app project's `Info.plist` file, add the following URL Types:
  - Role: `Editor` URL Schemes: `your.app.bundle.id` 
  - Role: `Editor` URL Schemes: `value of REVERSED_CLIENT_ID from GoogleService-Info.plist`
  

Setup your AppDelegate
----------------------

In order for Sign-In to work properly, you must tell the SDK about some of your application lifecycle events.

In your `AppDelegate.cs`, in the `FinishedLaunching (..)` override, you should add the following code to the start of the method:

// ClientID can be found in the GoogleService-Info.plist file
// You can get the GoogleService-Info.plist file at https://developers.google.com/mobile/add
``` csharp
string clientId = "ClientID";

NSError configureError;
Context.SharedInstance.Configure (out configureError);
if (configureError != null) {
	// If something went wrong, assign the clientID manually
	Console.WriteLine ("Error configuring the Google context: {0}", configureError);
	SignIn.SharedInstance.ClientID = clientId;
}
```

Next, add the following override to your AppDelegate class (or if it already exists, add the code inside the method to the existing implementation:

``` csharp
public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
{
	return SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);
}
```


Signing In
----------

Google Sign-In provides a `SignInButton` to add to your views and handles starting the sign in process.  You can add the button to your app in code or by using storyboards:

``` csharp
SignInButton = new SignInButton ();
SignInButton.Frame = new CGRect (20, 100, 150, 44);
View.AddSubview (SignInButton);

// Assign the SignIn Delegates to receive callbacks
SignIn.SharedInstance.UIDelegate = this;
SignIn.SharedInstance.Delegate = this;
```

You also must implement `ISignInDelegate` as well as `ISignInUIDelegate` and provide a `DidSignIn` method to know when the sign-in completed and if it was successful:

``` csharp
public void DidSignIn (SignIn signIn, GoogleUser user, NSError error)
{
	if (user != null && error == null)
		// Disable the SignInButton
}
```

The `SignInUserSilently` method attempts to sign in a previously authenticated user without interaction.  This can be done in a `ViewDidLoad` method or `ViewDidAppear` of your `UIViewController`:

``` csharp
// Assign the SignIn Delegates to receive callbacks
SignIn.SharedInstance.UIDelegate = this;
SignIn.SharedInstance.Delegate = this;

// Sign the user in automatically
SignIn.SharedInstance.SignInUserSilently ();
```

Signing Out and Disconnecting 
----------

To sign out a user simply call the `SignOutUser` method on the `SignIn` object:

``` csharp
SignOutButton.TouchUpInside += (sender, e) => {
	SignIn.SharedInstance.SignOutUser ();

	SignInButton.Enabled = true;
	SignOutButton.Enabled = false;
};
```

To completely disconnect the current user from the app and revoke previous authentication call the `DisconnectUser` method on the `SignIn` object.


[1]: https://developers.google.com/mobile/add?platform=ios&cntapi=gcm
