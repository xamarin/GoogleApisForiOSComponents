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

``` csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{
	...

	// You can get the GoogleService-Info.plist file at https://developers.google.com/mobile/add
	var googleServiceDictionary = NSDictionary.FromFile ("GoogleService-Info.plist");
	SignIn.SharedInstance.ClientID = googleServiceDictionary ["CLIENT_ID"].ToString ();

	...

	return true;
}
```

Next, you will need to override the `OpenUrl` method in your `AppDelegate` class or, if it already exists, add the code inside the method to the existing implementation:

``` csharp
// For iOS 9 or newer
public override bool OpenUrl (UIApplication app, NSUrl url, NSDictionary options)
{
	var openUrlOptions = new UIApplicationOpenUrlOptions (options);
	return SignIn.SharedInstance.HandleUrl (url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);
}

// For iOS 8 and older
public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
{
	return SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);
}
```

Signing In
----------

Google Sign-In provides a `SignInButton` to add to your views and handles starting the sign in process. You can add the button to your app in code or by using storyboards:

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

> ***Note:*** *The Sign-In SDK automatically acquires access tokens, but the access tokens will be refreshed only when you call `SignIn` or `SignInSilently` methods. To explicitly refresh the access token, call the `RefreshTokens` method. If you need the access token and want the SDK to automatically handle refreshing it, you can use the `GetAccessToken` method.*

The `SignInUserSilently` method attempts to sign in a previously authenticated user without interaction. This can be done in a `ViewDidLoad` method or `ViewDidAppear` of your `UIViewController`:

``` csharp
// Assign the SignIn Delegates to receive callbacks
SignIn.SharedInstance.UIDelegate = this;
SignIn.SharedInstance.Delegate = this;

// Sign the user in automatically
SignIn.SharedInstance.SignInUserSilently ();
```

> ***Note:*** *When users silently sign in, the Sign-In SDK automatically acquires access tokens and automatically refreshes them when necessary. If you need the access token and want the SDK to automatically handle refreshing it, you can use the `RefreshTokens` method. To explicitly refresh the access token, call the `RefreshAccessToken` method.*

If, in your project, the class that implements `ISignInUIDelegate` interface is not a subclass of `UIViewController`, you will need to implement the `WillDispatch`, `PresentViewController`, and `DismissViewController` methods of the `ISignInUIDelegate` interface. For example:

```csharp
[Export ("signInWillDispatch:error:")]
public void WillDispatch (SignIn signIn, NSError error)
{
	myActivityIndicator.StopAnimating ();
}

[Export ("signIn:presentViewController:")]
public void PresentViewController (SignIn signIn, UIViewController viewController)
{
	PresentViewController (viewController, true, null);
}

[Export ("signIn:dismissViewController:")]
public void DismissViewController (SignIn signIn, UIViewController viewController)
{
	DismissViewController (true, null);
}
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

Optionally, you can provide a `DidDisconnect` method to know when the sign out was completed and if it was successful:

```csharp
[Export ("signIn:didDisconnectWithUser:withError:")]
public void DidDisconnect (SignIn signIn, GoogleUser user, NSError error)
{
	// Perform any operations when the user disconnects from app here.
}
```

[1]: https://developers.google.com/mobile/add?platform=ios&cntapi=gcm
