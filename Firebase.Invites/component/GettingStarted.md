# Send and Receive Firebase Invites from Your iOS App

## Prerequisites

Firebase Invites requires iOS 8 or newer. You can target iOS 7 in your app, but all Firebase Invites SDK calls will be no-ops if the app isn't running on iOS 8 or newer.

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.
5. Go to **Project settings**, in **General** tab select your recently created iOS bundle ID.
6. Set your App Store ID, you can find your App Store ID in your app’s URL. (e.g. https://itunes.apple.com/us/app/yourapp/id123456789, **123456789** is your App Store ID).
7. Set your Team ID, you can find your Team ID in the Apple Member Center under the [membership tab][3].
8. You must enable Firebase Dynamic Links to use Firebase Invites. In [Firebase console][1], in your project menu go to Dynamic Links tab, accept the terms of service if you are prompted to do so, copy Url link, paste it into your Navigation bar and add **/apple-app-site-association** (e.g https://app_code.app.goo.gl//apple-app-site-association)
9. Your app is connected if the apple-app-site-association file contains a reference to your app's App Store ID and bundle ID, for example:

```
{"applinks":{"apps":[],"details":[{"appID":"1234567890.com.example.ios","paths":["/*"]}]}}
```

If the details field is empty, double-check that you specified your Team ID.

If you haven't created a Dynamic Link follow this [documentation][3].

## Configure Invites in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Open `GoogleService-Info.plist` file and change `IS_SIGNIN_ENABLED` and `IS_APPINVITE_ENABLED` values to `Yes`.
4. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Analytics` namespace):

```csharp
App.Configure ();
```

## Google Sign-In

Users must be signed in with their Google Accounts to send invitations. Follow [Google Sign-In getting started][4] to integrate Sign-In into your 
app.

## iOS 10 and Privacy Enhancements

Apple has made several enhancements to both security and privacy in iOS 10 that will help the developer improve the security of their apps and ensure the end user's privacy. 

Apps running on iOS 10 (or later) must statically declare their intent to access specific features or user information by entering one or more **Privacy Keys** in your `Info.plist` files that explain to the user why the app wishes to gain access. If your app fails to provide the required keys will be silently terminated by the system when they attempt to access one of the restricted features or user information, **without any error!**

### Give your app access to your Contacts

Invites, before sending your invitation, access to your Contacts to show you a list with them so you can invite everyone to try your awesome app! To allow Invites to achieve this, you need to do the following steps in Xamarin Studio:

1. Open your `Info.plist` and go to **Source** tab.
2. Add a new entry and search for **Privacy - Contacts Usage Description**.
3. Add your message that will be displayed when Invites tries to access to your contacts as value.

## Handle incoming app invites

After you have configured your app, you must next enable your app to handle incoming app invites.

When a user selects an incoming app invite on their iOS device, if the user has not yet installed your app, they can choose to install your app from its iTunes App Store page. When the user opens your app for the first time, it's important for your app to provide a personalized onboarding experience to increase the likelihood they will become an engaged, long-term user of your app. To help you do this, the Invites SDK provides the deeplink and invitation ID associated with the app invite received by the user.

**_Note: If the Invites SDK indicates a weak match for a deeplink, it means that the match between the deeplink and the receiving device may not be perfect. In this case your app should reveal no personal information from the deeplink._**

```csharp
// Support for iOS 9 or later
public override bool OpenUrl (UIApplication app, NSUrl url, NSDictionary options)
{
	var openUrlOptions = new UIApplicationOpenUrlOptions (options);
	return OpenUrl (app, url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);
}

// Support for iOS 8 or before
public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
{
	// Handle App Invite requests
	var invite = Invites.HandleUrl (url, sourceApplication, annotation);

	if (invite != null) {
		var matchType = invite.MatchType == ReceivedInviteMatchType.Weak ? "Weak" : "Strong";
		var message = $"Deep link from {sourceApplication}\nInvite ID: {invite.InviteId}\nApp Url: {invite.DeepLink}\nMatch Type: {matchType}";
		System.Console.WriteLine ($"Depp-Link Data: {message}");

		return true;
	}

	// Handle Sign In
	return SignIn.SharedInstance.HandleUrl (url, sourceApplication, annotation);
}
```

## Enable your users to send app invites

Before a user can send Invites, the user must be signed in with their Google Account.

To send invitations, first declare a class that implements the IInviteDelegate interface:

```csharp
public class InviteViewController : DialogViewController, IInviteDelegate
```

Then, add a **Send Invitation** button to your app. You can add this button as an option in your main menu, or add this button alongside your deep-linkable content, so that users can send specific content along with the invitation. See the [Firebase Invites best practices][5].

When users tap your **Send Invitation** button, open the invitation dialog:

```csharp
// NOTE: You must have the App Store ID set in your developer console project
// in order for invitations to successfully be sent.
public void SendInvite ()
{
	// When you create the invitation dialog, you must specify the title
	// of the invitation dialog and the invitation message to send. 
	// You can also customize the image and deep link URL that 
	// get sent in the invitation
	var inviteDialog = Invites.GetInviteDialog ();
	inviteDialog.SetInviteDelegate (this);
	inviteDialog.SetTitle ("Invites Sample");
	
	// A message hint for the dialog. Note this manifests differently depending on the
    // received invitation type. For example, in an email invite this appears as the subject.
	inviteDialog.SetMessage ($"Try this out! {anUrl}");
	
	// These following values are optionals and are only sent via email
	inviteDialog.SetDeepLink ("app_url");
	inviteDialog.SetDescription ("A description of the app");
	inviteDialog.SetCustomImage ("The url of the image");
	inviteDialog.SetCallToActionText ("Button title of the invitations");
	
	// If you have an Android version of your app and you want to send
	// an invitation that can be opened on Android in addition to iOS
	var targetApp = new InvitesTargetApplication {
			AndroidClientId = "Android ID"
	};
	inviteDialog.SetOtherPlatformsTargetApplication (targetApp);

	inviteDialog.Open ();
}
```

If you want to learn more about Invitation parts, see the following [documentation][6].

After the user sends the invitation, your app calls `InviteFinished` method of `IInviteDelegate` interface:

```csharp
[Export ("inviteFinishedWithInvitations:error:")]
public void InviteFinished (string [] invitationIds, NSError error)
{
	if (error == null) {
		foreach (var id in invitationIds)
			System.Console.WriteLine (id);
	} else {
		System.Console.WriteLine (error.LocalizedDescription);
	}

}
```

### Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][7])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/invites/ios) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://firebase.google.com/docs/dynamic-links/ios#create-a-dynamic-link
[4]: https://components.xamarin.com/gettingstarted/googleiossignin
[5]: https://firebase.google.com/docs/invites/best-practices
[6]: https://firebase.google.com/docs/invites/ios#customize-the-invitation
[7]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689