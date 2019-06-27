## Add your game to the Google Play Developer Console

Create an entry for your game in the Google Play Developer Console.  This enables Google Play games services for your application, and creates an OAuth 2.0 client ID, if you don't already have one.

1. Add an entry for your iOS game by following the steps described in [Setting Up Google Play Games Services][1].
2. Take note of your game's OAuth 2.0 [client ID][2]; you will need this later.
3. (Optional) Add achievements and leaderboards to your game by following the steps described in [Configuring Achievements and Leaderboards][3].
4. Add accounts for other members of your team to test your game by following the steps described in [Publishing Your Game Changes][4].

## Add a sign-in and sign-out button

In your view controller, add a sign-in button and a sign-out button.  Make sure your sign-in button conforms to the [Google+ branding guidelines][5].  To reduce your development effort, many of the built-in user-interfaces provided by Google Play games services already include a sign-out option so you don't need to add this manually.

```csharp
using Google.Play.GameServices;
...

const string CLIENT_ID = "123456789012.apps.googleusercontent.com";

UIButton signinButton;
UIButton signoutButton;

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	
	signinButton = new UIButton (new CGRect (93, 99, 125, 44));
	signinButton.SetTitle ("Sign In", UIControlState.Normal);
	signinButton.TouchUpInside += delegate {
		Manager.SharedInstance.SignIn (CLIENT_ID, false);
	};

	signoutButton = new UIButton (new CGRect (93, 299, 125, 44));
	signoutButton.SetTitle ("Sign Out", UIControlState.Normal);
	signoutButton.TouchUpInside += delegate {
		Manager.SharedInstance.Signout ();
	};
	
	Add (signinButton);
	Add (signoutButton);
	
}
```

When a player signs in to Google, the sign-in process sends them to the Google+ app, Chrome for iOS, or Mobile Safari (in that sequence).  After the player signs in, the app opens a URL that points back to your game and contains the information necessary to complete the sign-in process. Make sure your application can handle the URL that redirects back to your game.  Using the options provided in the Google Sign-In SDK, it is possible to selectively enable or disable redirection to Google first-party sign-in apps, Chrome/Safari, or in-app webviews.

Your app must be setup to accept a URL scheme.  You can do this by opening your app's `Info.plist` file, and navigating to the *Advanced* tab.

In the *URL Types* section, add two *URL Type*s:

- In one *URL type*, specify a unique string in the Identifier field, and specify your client ID in reversed order in the *URL Schemas* field.  For example, if your client ID for iOS is `CLIENT_ID_CODE.apps.googleusercontent.com`, then specify `com.googleusercontent.apps.CLIENT_ID_CODE` in the *URL Schemas* field.
- In the other *URL type*, specify a unique string in the Identifier field, and specify your app's bundle identifier (com.company.appname) in the *URL Schemas* field.

In your AppDelegate file, add `Google.SignIn` to libraries and override the `OpenUrl` method.  This method handles the URL that your application receives at the end of the authentication process:

```csharp
using Google.SignIn;
...

public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
{
	return SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);
}
```		

In some class of your app (where signin and singout buttons live for example), set `SignIn.SharedInstance.UIDelegate` property:

```csharp
SignIn.SharedInstance.UIDelegate = this;
```  

The class assigned to `UIDelegate` property must implement the `ISignInUIDelegate` interface.

You can now test your application and be able to sign in and out.  When testers sign in, they will be redirected to Google+, Chrome, or Safari to complete the sign-in process, and then redirected back to your application.

## Add a GPGStatusDelegate

Next, add the code to let your app know that when sign-in process is completed.

Make a class implements `IStatusDelegate` interface and assign it to `Manager.SharedInstance.StatusDelegate` property.  Also, Implement these `IStatusDelegate` methods: `GamesSignInFinished` (to handle completion of player sign-in) and `GamesSignOutFinished` (to handle completion of player sign-out):

```csharp
public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	
	Manager.SharedInstance.StatusDelegate = this;
}

[Export ("didFinishGamesSignInWithError:")]
public void GamesSignInFinished (NSError error)
{
	if (error != null) 
		Console.WriteLine ("ERROR signing in: {0}", error.LocalizedDescription);
	else 
		Console.WriteLine ("Finished with games sign in!");
	
	RefreshYourUI ();
}


[Export ("didFinishGamesSignOutWithError:")]
public virtual void GamesSignOutFinished (NSError error)
{
	if (error != null)
		Console.WriteLine ("ERROR signing out: {0}", error.LocalizedDescription);
	else
		Console.WriteLine ("Signed out!");
		
	RefreshYourUI ();
}
```

After you sign in or you sign out, refresh your UI to determine what button you should show:

```csharp	
void RefreshYourUI ()
{
	var signedIn = Manager.SharedInstance.SignedIn;
	signinButton.Hidden = signedIn;
	signoutButton.Hidden = !signedIn;
}
```

Now, when testers finish signing in, the sign-in button will be hidden. When they sign out, the sign-out button will be hidden and the sign-in button should re-appear.

## Automatically sign in returning players

You can also sign players in automatically, to avoid having them sign in every time they launch your game.  The `Google.Play.GameServices.Manager` will automatically sign the player in when you specify **true** in `Manager.SharedInstance.SignIn` method.  This call succeeds if all the following conditions are met:

- The player has authorized your application in the past;
- The player has not revoked access to your application; and
- The app is not requesting new scopes since the player last signed in.

Using this behavior, you can sign the player in automatically to your game by adding the `Manager.SharedInstance.SignIn` method to the end of your `ViewDidLoad` method, with silently param (second param) set to **true**.

```csharp
Manager.SharedInstance.SignIn (CLIENT_ID, true);
```

Run your application and notice that, unless you signed out when you last used your application, you are now signed in automatically.

## Add some interface refinements

When the application starts player sign-in automatically, there is a small delay between the time sign-in starts and completes.  Your game should disable the UI during this time. To do this, use the fact that the `Manager.SharedInstance.SignIn` method returns **true** if it is attempting to sign the player in automatically.  You could do something like this:

```
using Google.Play.GameServices;
...

const string CLIENT_ID = "123456789012.apps.googleusercontent.com";

UIButton signinButton;
UIButton signoutButton;
bool currentlySigningIn;

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	
	Manager.SharedInstance.StatusDelegate = this;
	
	signinButton = new UIButton (new CGRect (93, 99, 125, 44));
	signinButton.SetTitle ("Sign In", UIControlState.Normal);
	signinButton.TouchUpInside += delegate {
		Manager.SharedInstance.SignIn (CLIENT_ID, false);
	};

	signoutButton = new UIButton (new CGRect (93, 299, 125, 44));
	signoutButton.SetTitle ("Sign Out", UIControlState.Normal);
	signoutButton.TouchUpInside += delegate {
		Manager.SharedInstance.Signout ();
	};
	
	Add (signinButton);
	Add (signoutButton);
	
	currentlySigningIn = Manager.SharedInstance.SignIn (CLIENT_ID, true);
	RefreshYourUI ();
}

[Export ("didFinishGamesSignInWithError:")]
public void GamesSignInFinished (NSError error)
{
	if (error != null) 
		Console.WriteLine ("ERROR signing in: {0}", error.LocalizedDescription);
	else 
		Console.WriteLine ("Finished with games sign in!");
	
	currentlySigningIn = false;
	RefreshYourUI ();
}


[Export ("didFinishGamesSignOutWithError:")]
public virtual void GamesSignOutFinished (NSError error)
{
	if (error != null)
		Console.WriteLine ("ERROR signing out: {0}", error.LocalizedDescription);
	else
		Console.WriteLine ("Signed out!");
	
	currentlySigningIn = false;
	RefreshYourUI ();
}

void RefreshYourUI ()
{
	var signedIn = Manager.SharedInstance.SignedIn;
	signinButton.Hidden = signedIn;
	signoutButton.Hidden = !signedIn;
	
	signinButton.Enabled = !currentlySigningIn;
	signoutButton.Enabled = !currentlySigningIn;
}
```

## More with Play Games

* [Achievements][6]
* [Leaderboards][7]
* [Saved Games][8]
* [Real-time Multiplayer][9]
* [Turn-based Multiplayer][10]
* [Events and Quests][11]
* [Push Notifications][12]

[1]: https://developers.google.com/games/services/console/enabling
[2]: https://developers.google.com/games/services/console/enabling#client_id
[3]: https://developers.google.com/games/services/console/configuring#configuring_achievements_and_leaderboards
[4]: https://developers.google.com/games/services/console/testpub#enabling_accounts_for_testing
[5]: https://developers.google.com/+/branding-guidelines
[6]: https://developers.google.com/games/services/ios/achievements
[7]: https://developers.google.com/games/services/ios/leaderboards
[8]: https://developers.google.com/games/services/ios/savedgames
[9]: https://developers.google.com/games/services/ios/realtimeMultiplayer
[10]: https://developers.google.com/games/services/ios/turnbasedMultiplayer
[11]: https://developers.google.com/games/services/ios/quests
[12]: https://developers.google.com/games/services/ios/notifications