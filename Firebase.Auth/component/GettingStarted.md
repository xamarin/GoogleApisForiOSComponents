# Firebase Auth on iOS

You can use Firebase Authentication to allow users to sign in to your app using one or more sign-in methods, including email address and password sign-in, and federated identity providers such as Google Sign-in and Facebook Login. This tutorial gets you started with Firebase Authentication by showing you how to add email address and password sign-in to your app.

## Table of content

- [Add Firebase to your app](#add-firebase-to-your-app)
- [Configure Auth in your app](#configure-auth-in-your-app)
- [Authenticate with Firebase using Password-Based Accounts](#authenticate-with-firebase-using-password-based-accounts)
	- [Create an account](#create-an-account)
	- [Sign in a user with an email address and password](#sign-in-a-user-with-an-email-address-and-password)
- [Authenticate with Firebase on iOS using a Phone Number](#authenticate-with-firebase-on-ios-using-a-phone-number)
	- [Security concerns](#security-concerns)
	- [Enable Phone Number sign-in for your Firebase project](#enable-phone-number-sign-in-for-your-firebase-project)
	- [Start receiving APNs notifications](#start-receiving-apns-notifications)
	- [Send a verification code to the user's phone](#send-a-verification-code-to-the-user-s-phone)
	- [Sign in the user with the verification code](#sign-in-the-user-with-the-verification-code)
- [Authenticate Using Google Sign-In](#authenticate-using-google-sign-in)
- [Authenticate Using Facebook Login](#authenticate-using-facebook-login)
- [Authenticate with Firebase Anonymously](#authenticate-with-firebase-anonymously)
	- [Convert an anonymous account to a permanent account](#convert-an-anonymous-account-to-a-permanent-account)
- [Authenticate with Firebase Using a Custom Authentication System](#authenticate-with-firebase-using-a-custom-authentication-system)
- [Authenticate Using Twitter Login](#authenticate-using-twitter-login)
- [Authenticate Using GitHub](#authenticate-using-github)
- [Manage Users in Firebase](#manage-users-in-firebase)
	- [Sign out a user](#sign-out-a-user)
	- [Get the currently signed-in user](#get-the-currently-signed-in-user)
	- [Get a user's profile](#get-a-user-s-profile)
	- [Get a user's provider-specific profile information](#get-a-user-s-provider-specific-profile-information)
	- [Update a user's profile](#update-a-user-s-profile)
	- [Set a user's email address](#set-a-user-s-email-address)
	- [Send a user a verification email](#send-a-user-a-verification-email)
	- [Set a user's password](#set-a-user-s-password)
	- [Send a password reset email](#send-a-password-reset-email)
	- [Delete a user](#delete-a-user)
	- [Re-authenticate a user](#re-authenticate-a-user)
- [Link Multiple Auth Providers to an Account](#link-multiple-auth-providers-to-an-account)
	- [Link auth provider credentials to a user account](#link-auth-provider-credentials-to-a-user-account)
	- [Unlink an auth provider from a user account](#unlink-an-auth-provider-from-a-user-account)
- [Known issues](#known-issues)

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure Auth in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
App.Configure ();
```

## Authenticate with Firebase using Password-Based Accounts

You can use Firebase Authentication to let your users authenticate with Firebase using their email addresses and passwords, and to manage your app's password-based accounts.

### Create an account

Create a new account by passing the new user's email address and password to `Auth.CreateUser` instance method (don't forget to import `Firebase.Auth` namespace):

```csharp
Auth.DefaultInstance.CreateUser (email, password, (user, error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);
	
		// Posible error codes that CreateUser method could throw
		switch (errorCode) {
		case AuthErrorCode.InvalidEmail:
		case AuthErrorCode.EmailAlreadyInUse:
		case AuthErrorCode.OperationNotAllowed:
		case AuthErrorCode.WeakPassword:
		default:
			// Print error
			break;
		}
	} else {
		// Do your magic to handle authentication result
	}
});
```

If the new account was successfully created, the user is signed in, and you can get the user's account data from the user object that's passed to the callback method.

_**Note:**_ _To protect your project from abuse, Firebase limits the number of new email/password and anonymous sign-ups that your application can have from the same IP address in a short period of time. You can request and schedule temporary changes to this quota from the Firebase console._

### Sign in a user with an email address and password

When a user signs in to your app, pass the user's email address and password to `Auth.SignIn` instance method (don't forget to import `Firebase.Auth` namespace):

```csharp
Auth.DefaultInstance.SignIn (email, password, (user, error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that SignIn method with email and password could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.OperationNotAllowed:
		case AuthErrorCode.InvalidEmail:
		case AuthErrorCode.UserDisabled:
		case AuthErrorCode.WrongPassword:
		default:
			// Print error
			break;
		}
	} else {
		// Do your magic to handle authentication result
	}
});
```

If the user successfully signs in, you can get the user's account data from the user object that's passed to the callback method.

## Authenticate with Firebase on iOS using a Phone Number

You can use Firebase Authentication to sign in a user by sending an SMS message to the user's phone. The user signs in using a one-time code contained in the SMS message.

Phone number sign-in requires a physical device and won't work on a simulator.

This document describes how to implement a phone number sign-in flow using the Firebase SDK.

> _**Note:**_ _Phone numbers that end users provide for authentication will be sent and stored by Google to improve our spam and abuse prevention across Google services, including but not limited to Firebase. Developers should ensure they have appropriate end-user consent prior to using the Firebase Authentication phone number sign-in service._

### Security concerns

Authentication using only a phone number, while convenient, is less secure than the other available methods, because possession of a phone number can be easily transferred between users. Also, on devices with multiple user profiles, any user that can receive SMS messages can sign in to an account using the device's phone number.

If you use phone number based sign-in in your app, you should offer it alongside more secure sign-in methods, and inform users of the security tradeoffs of using phone number sign-in.

### Enable Phone Number sign-in for your Firebase project

To sign in users by SMS, you must first enable the Phone Number sign-in method for your Firebase project:

1. In the [Firebase console][1], open the **Authentication** section.
2. On the **Sign-in Method** page, enable the **Phone Number** sign-in method.

Firebase's phone number sign-in request quota is high enough that most apps won't be affected. However, if you need to sign in a very high volume of users with phone authentication, you might need to upgrade your pricing plan. See the [pricing][14] page.

### Start receiving APNs notifications

To use phone number authentication, your app must be able to receive APNs notifications from Firebase. When you sign in a user with their phone number for the first time on a device, Firebase Authentication sends a silent push notification to the device to verify that the phone number sign-in request comes from your app. (For this reason, phone number sign-in cannot be used on a simulator.)

To enable APNs notifications for use with Firebase Authentication:

1. In Visual Studio, enable push notifications for your project by opening **Entitlements.plist** and enabling **Push Notifications**.
2. Upload your APNs authentication key to Firebase. If you don't already have an APNs authentication key, see [Configuring APNs with FCM][15].
	1. Inside your project in the Firebase console, select the gear icon, select **Project Settings**, and then select the **Cloud Messaging** tab.
	2. In **APNs authentication key** under **iOS app configuration**, click the **Upload** button.
	3. Browse to the location where you saved your key, select it, and click **Open**. Add the key ID for the key (available in **Certificates**, **Identifiers** & **Profiles** in the [Apple Developer Member Center][16]) and click **Upload**.

If you already have an APNs certificate, you can upload the certificate instead.

#### Receive notifications without swizzling

Firebase Authentication uses method swizzling to automatically obtain your app's APNs token and to handle the silent push notifications that Firebase sends to your app during verification.

If you prefer not to use swizzling, you can disable it by adding the flag **FirebaseAppDelegateProxyEnabled** to your app's Info.plist file and setting it to **No**. Note that setting this flag to **No** also disables swizzling for other Firebase products, including Firebase Cloud Messaging.

If you disable swizzling, you must explicitly pass the APNs device token and push notifications to Firebase Authentication.

To obtain the APNs device token, implement the `AppDelegate`'s `RegisteredForRemoteNotifications` method, and in it, pass the device token to `Auth`'s `SetApnsToken` method:

```csharp
public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
{
	// Pass device token to auth
	Auth.DefaultInstance.SetApnsToken (deviceToken, AuthApnsTokenType.Production); // Production if you are ready to release your app, otherwise, use Sandbox.

	// Further handling of the device token if needed by the app
	// ...
}
```

To handle push notifications, in the `AppDelegate`'s `DidReceiveRemoteNotification` method, check for Firebase auth related notifications by calling `Auth`'s `CanHandleNotification` method:

```csharp
public override void DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
{
	// Pass notification to auth and check if they can handle it.
	if (Auth.DefaultInstance.CanHandleNotification (userInfo)) {
		completionHandler (UIBackgroundFetchResult.NoData);
		return;
	}

	// This notification is not auth related, developer should handle it.
}
```

### Send a verification code to the user's phone

To initiate phone number sign-in, present the user an interface that prompts them to provide their phone number, and then call `VerifyPhoneNumber` to request that Firebase send an authentication code to the user's phone by SMS:

1. Get the user's phone number.

    Legal requirements vary, but as a best practice and to set expectations for your users, you should inform them that if they use phone sign-in, they might receive an SMS message for verification and standard rates apply.

2. Call `VerifyPhoneNumber`, passing to it the user's phone number:

	```csharp
	PhoneAuthProvider.DefaultInstance.VerifyPhoneNumber (phoneNumber, (verificationId, error) => {
		if (error != null) {
			Console.WriteLine (error.LocalizedDescription);
			return;
		}

		// Sign in using the verificationID and the code sent to the user
		// ...
	});
	```
	
	When you call `VerifyPhoneNumber`, Firebase sends a silent push notification to your app. After your app receives the notification, Firebase sends an SMS message containing an authentication code to the specified phone number and passes a verification ID to your completion function. You will need both the verification code and the verification ID to sign in the user.

3. Save the verification ID and restore it when your app loads. By doing so, you can ensure that you still have a valid verification ID if your app is terminated before the user completes the sign-in flow (for example, while switching to the SMS app).

	You can persist the verification ID any way you want. A simple way is to save the verification ID with the NSUserDefaults object:

	```csharp
	NSUserDefaults.StandardUserDefaults.SetString (verificationId, "authVerificationID");	
	```

	Then, you can restore the saved value:

	```csharp
	var verificationId = NSUserDefaults.StandardUserDefaults.StringForKey ("AuthVerificationID");
	```

If the call to `VerifyPhoneNumber` succeeds, you can prompt the user to type the verification code when they receive it in the SMS message.

> _**Note:**_ _To prevent abuse, Firebase enforces a limit on the number of SMS messages that can be sent to a single phone number within a period of time. If you exceed this limit, phone number verification requests might be throttled. If you encounter this issue during development, use a different phone number for testing, or try the request again later._

### Sign in the user with the verification code

After the user provides your app with the verification code from the SMS message, sign the user in by creating a `PhoneAuthCredential` object from the verification code and verification ID and passing that object to `SignIn (AuthCredential, AuthResultHandler)` method.

1. Get the verification code from the user.
2. Create a `PhoneAuthCredential` object from the verification code and verification ID:

	```csharp
	var credential = PhoneAuthProvider.DefaultInstance.GetCredential (verificationId, verificationCode);
	```

3. Sign in the user with the PhoneAuthCredential object:

	```csharp
	Auth.DefaultInstance.SignIn (credential, (user, error) => {
		if (error != null) {
			Console.WriteLine (error.LocalizedDescription);
			return;
		}

		// User is signed in
		// ...
	});
	```

## Authenticate Using Google Sign-In

You can let your users authenticate with Firebase using their Google Accounts by integrating Google Sign-In into your app. To be able to use this authentication, please, first integrate [Google Sign-In for iOS][3] to your app.

Once you have integrated Sign-In into your app, follow these steps to complete your integration with Firebase:

* If you haven't yet connected your app to your Firebase project, do so from the [Firebase console][1].
* Enable Google Sign-In in the Firebase console:
  * In the [Firebase console][1], open the **Auth** section.
  * On the **Sign in method** tab, enable the **Google** sign-in method and click **Save**.
* In your code, in `ISignInDelegate.DidSignIn` method, get a Google ID token and Google access token from the `Authentication` object and exchange them for a Firebase credential and, finally, authenticate with Firebase using the credential:

```csharp
public void DidSignIn (SignIn signIn, GoogleUser user, NSError error)
{
	if (error == null && user != null) {
		// Get Google ID token and Google access token and exchange them for a Firebase credential
		var authentication = user.Authentication;
		var credential = GoogleAuthProvider.GetCredential (authentication.IdToken, authentication.AccessToken);
		
		// Authenticate with Firebase using the credential
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		Auth.DefaultInstance.SignIn (credential, (user, error) => {
			if (error != null) {
				AuthErrorCode errorCode;
				if (IntPtr.Size == 8) // 64 bits devices
					errorCode = (AuthErrorCode)((long)error.Code);
				else // 32 bits devices
					errorCode = (AuthErrorCode)((int)error.Code);

				// Posible error codes that SignIn method with credentials could throw
				switch (errorCode) {
				case AuthErrorCode.InvalidCredential:
				case AuthErrorCode.InvalidEmail:
				case AuthErrorCode.OperationNotAllowed:
				case AuthErrorCode.EmailAlreadyInUse:
				case AuthErrorCode.UserDisabled:
				case AuthErrorCode.WrongPassword:
				default:
					// Print error
					break;
				}
			} else {
				// Do your magic to handle authentication result
			}
		});
	} else {
		// Print error
	}
}
```

## Authenticate Using Facebook Login

You can let your users authenticate with Firebase using their Facebook accounts by integrating Facebook Login into your app. To be able to use this authentication, please, first integrate [Facebook iOS SDK][4] to your app.

Once you have integrated Facebook into your app, follow these steps to complete your integration with Firebase:

* If you haven't yet connected your app to your Firebase project, do so from the [Firebase console][1].
* On the [Facebook for Developers][5] site, get the **App ID** and an **App Secret** for your app.
* Enable Facebook Login:
  * In the [Firebase console][1], open the Auth section.
  * On the **Sign in method** tab, enable the **Facebook** sign-in method and specify the **App ID** and **App Secret** you got from Facebook.
  * Then, make sure your **OAuth redirect URI** (e.g. `my-app-12345.firebaseapp.com/__/auth/handler`) is listed as one of your **OAuth redirect URIs** in your Facebook app's settings page on the [Facebook for Developers][6] site in the **Products** > **Facebook Login** > **Settings**.
* In your code, after a user successfully signs in, in your `Completed` event or in your `DidComplete` method, get an access token for the signed-in user and exchange it for a Firebase credential and, finally, authenticate with Firebase using the credential:

```csharp
BtnLogin.Completed += (object sender, LoginButtonCompletedEventArgs e) => {
	if (e.Error != null) {
		// Handle if there was an error
	}

	if (e.Result.IsCancelled) {
		// Handle if the user cancelled the login request
	}

	// Get access token for the signed-in user and exchange it for a Firebase credential
	var credential = FacebookAuthProvider.GetCredential (AccessToken.CurrentAccessToken.TokenString);

	// Authenticate with Firebase using the credential
	Auth.DefaultInstance.SignIn (credential, (user, error) => {
		if (error != null) {
			AuthErrorCode errorCode;
			if (IntPtr.Size == 8) // 64 bits devices
				errorCode = (AuthErrorCode)((long)error.Code);
			else // 32 bits devices
				errorCode = (AuthErrorCode)((int)error.Code);

			// Posible error codes that SignIn method with credentials could throw
			// Visit https://firebase.google.com/docs/auth/ios/errors for more information
			switch (errorCode) {
			case AuthErrorCode.InvalidCredential:
			case AuthErrorCode.InvalidEmail:
			case AuthErrorCode.OperationNotAllowed:
			case AuthErrorCode.EmailAlreadyInUse:
			case AuthErrorCode.UserDisabled:
			case AuthErrorCode.WrongPassword:
			default:
				// Print error
				break;
			}
		} else {
			// Do your magic to handle authentication result
		}
	});
};
```

## Authenticate with Firebase Anonymously

You can use Firebase Authentication to create and use temporary anonymous accounts to authenticate with Firebase. These temporary anonymous accounts can be used to allow users who haven't yet signed up to your app to to work with data protected by security rules. If an anonymous user decides to sign up to your app, you can link their sign-in credentials to the anonymous account so that they can continue to work with their protected data in future sessions.

Follow these steps to complete your integration with Firebase:

* If you haven't yet connected your app to your Firebase project, do so from the [Firebase console][1].
* Enable anonymous auth in the Firebase console:
  * In the [Firebase console][1], open the **Auth** section.
  * On the **Sign in method** tab, enable the **Anonymous** sign-in method and click **Save**.
* When a signed-out user uses an app feature that requires authentication with Firebase, sign in the user anonymously by using `Auth.SignInAnonymously` instance method:

```csharp
Auth.DefaultInstance.SignInAnonymously ((user, error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that SignInAnonymously method could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.OperationNotAllowed:
		default:
			// Print error
			break;
		}
	} else {
		// Do your magic to handle authentication result
	}
});
```

After a successful login, you can get the anonymous user's account data from the `User` object:

```csharp
bool isAnonymous = user.IsAnonymous;
string uid = user.Uid;
```

### Convert an anonymous account to a permanent account

When an anonymous user signs up to your app, you might want to allow them to continue their work with their new account—for example, you might want to make the items the user added to their shopping cart before they signed up available in their new account's shopping cart. To do so, complete the following steps:

1. When the user signs up, complete the sign-in flow for the user's authentication provider up to, but not including, calling one of the `Auth.SignIn` methods.
2. Get an `AuthCredential` for the new authentication provider
3. Pass the `AuthCredential` object to the sign-in user's `Link` method:

```csharp
user.Link (credential, (user, error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that Link method could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.ProviderAlreadyLinked:
		case AuthErrorCode.CredentialAlreadyInUse:
		case AuthErrorCode.OperationNotAllowed:
		case AuthErrorCode.EmailAlreadyInUse:
		case AuthErrorCode.InvalidEmail:
		case AuthErrorCode.RequiresRecentLogin:
		case AuthErrorCode.WeakPassword:
		default:
			// Print error
			break;
		}
	} else {
		// Do your magic to handle link result
	}
});
```

## Authenticate with Firebase Using a Custom Authentication System

You can integrate Firebase Authentication with a custom authentication system by modifying your authentication server to produce custom signed tokens when a user successfully signs in. Your app receives this token and uses it to authenticate with Firebase.

Follow these steps to complete your integration with Firebase:

* Get your project's server keys:
  * Go to the [Credentials page][6] of the Google API Console and select your project.
  * Click **Create credentials** > **Service account key**. Select **New service account**, type any name, select **JSON** as the key type, and click **Create**.
  * The new service account's public/private key pair is automatically saved on your computer. Copy this file to your authentication server.
* When users sign in to your app, send their sign-in credentials (for example, their username and password) to your authentication server. Your server checks the credentials and returns a [custom token][5] if they are valid.
* After you receive the custom token from your authentication server, pass it to `SignIn` method to sign in the user:

```csharp
Auth.DefaultInstance.SignIn (customToken, (user, error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that SignIn method with custom token could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.InvalidCredential:
		case AuthErrorCode.InvalidEmail:
		case AuthErrorCode.OperationNotAllowed:
		case AuthErrorCode.EmailAlreadyInUse:
		case AuthErrorCode.UserDisabled:
		case AuthErrorCode.WrongPassword:
		default:
			// Print error
			break;
		}
	} else {
		// Do your magic to handle authentication result
	}
});
```

## Authenticate Using Twitter Login

You can let your users authenticate with Firebase using their Twitter accounts by integrating Twitter Login into your app. To be able to use this authentication, please, add [Xamarin.Auth NuGet][7] to your project and follow Xamarin.Auth [Getting Started][8] guide to integrate it into your app.

Once you have integrated Xamarin.Auth into your app, follow these steps to complete your integration with Firebase:

* [Register your app][9] as a developer application on Twitter and get your app's **API Key** and **API Secret**.
* Enable Twitter Login in the Firebase console:
  * In the [Firebase console][1], open the **Auth** section.
  * On the **Sign in method** tab, enable the **Twitter** sign-in method and specify the **API Key** and **API Secret** you got from Twitter.
  * Then, make sure your Firebase **OAuth redirect URI** (e.g. `my-app-12345.firebaseapp.com/__/auth/handler`) is set as your **Callback URL** in your app's settings page on your [Twitter app's config][9].
* After a user successfully signs in, in your implementation of `Completed`, exchange the Twitter auth token and Twitter auth token secret for a Firebase credential:

```csharp
// Exchange the Twitter auth token and Twitter auth token secret for a Firebase credential
var credential = TwitterAuthProvider.GetCredential (token, secret);

// Authenticate with Firebase using the credential
Auth.DefaultInstance.SignIn (credential, (user, error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that SignIn method with credentials could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.InvalidCredential:
		case AuthErrorCode.InvalidEmail:
		case AuthErrorCode.OperationNotAllowed:
		case AuthErrorCode.EmailAlreadyInUse:
		case AuthErrorCode.UserDisabled:
		case AuthErrorCode.WrongPassword:
		default:
			// Print error
			break;
		}
	} else {
		// Do your magic to handle authentication result
	}
});
```

***Optional:*** Add an email address to the user's profile. When users sign in to your app with Twitter, their email addresses aren't accessible to Firebase. If you want to add email addresses to the profiles of users that sign in with Twitter, prompt users to provide their email addresses, and then call `UpdateEmail` method as in the following example:

```csharp
user.UpdateEmail (email, (error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that UpdateEmail method could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.EmailAlreadyInUse:
		case AuthErrorCode.InvalidEmail:
		case AuthErrorCode.RequiresRecentLogin:
		default:
			// Print error
			break;
		}
	} else {
		// Do your magic to handle successful update
	}
});
```

## Authenticate Using GitHub

You can let your users authenticate with Firebase using their GitHub accounts by integrating GitHub authentication into your app. To be able to use this authentication, please, add [Xamarin.Auth NuGet][7] to your project and follow Xamarin.Auth [Getting Started][8] guide to integrate it into your app.

Once you have integrated Xamarin.Auth into your app, follow these steps to complete your integration with Firebase:

* [Register your app][10] as a developer application on GitHub and get your app's OAuth 2.0 **Client ID** and **Client Secret**.
* Enable GitHub authentication in the Firebase console:
  * In the [Firebase console][1], open the **Auth** section.
  * On the **Sign in method** tab, enable the **GitHub** sign-in method and specify the OAuth 2.0 **Client ID** and **Client Secret** you got from GitHub.
  * Then, make sure your Firebase **OAuth redirect URI** (e.g. `my-app-12345.firebaseapp.com/__/auth/handler`) is set as your **Authorization callback URL** in your app's settings page on your [GitHub app's config][11].
* After a user successfully signs in with GitHub, in your implementation of `Completed`, exchange the OAuth 2.0 access token from GitHub for a Firebase credential:

```csharp
// Exchange the OAuth 2.0 access token from GitHub for a Firebase credential
var credential = GitHubAuthProvider.GetCredential (token);

// Authenticate with Firebase using the credential
Auth.DefaultInstance.SignIn (credential, (user, error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that SignIn method with credentials could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.InvalidCredential:
		case AuthErrorCode.InvalidEmail:
		case AuthErrorCode.OperationNotAllowed:
		case AuthErrorCode.EmailAlreadyInUse:
		case AuthErrorCode.UserDisabled:
		case AuthErrorCode.WrongPassword:
		default:
			// Print error
			break;
		}

		return;
	}
	
	// Do your magic to handle authentication result
});
```

## Manage Users in Firebase

### Sign out a user

To sign out a user, just call `SignOut` method:

```csharp
NSError error;
var signedOut = Auth.DefaultInstance.SignOut (out error);

if (!signedOut) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)error.Code);
	
	// Posible error codes that SignOut method with credentials could throw
	// Visit https://firebase.google.com/docs/auth/ios/errors for more information
	switch (errorCode) {
	case AuthErrorCode.KeychainError:
	default:
		// Print error
		break;
	}
}

// Do your magic to handle successful signout
```

### Get the currently signed-in user

The recommended way to get the current user is by setting a listener on the Auth object:

```csharp
var listenerHandle = Auth.DefaultInstance.AddAuthStateDidChangeListener ((auth, user) => {
	if (user != null) {
		// User is signed in.
	} else {
		// No user is signed in.
	}
});
```

To remove the listener, pass the `listenerHandle` to `RemoveAuthStateDidChangeListener`:

```csharp
Auth.DefaultInstance.RemoveAuthStateDidChangeListener (listenerHandle);
```

By using a listener, you ensure that the Auth object isn't in an intermediate state—such as initialization—when you get the current user.

You can also get the currently signed-in user by using the currentUser property. If a user isn't signed in, `CurrentUser` is `null`:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
if (user != null) {
	// User is signed in.
} else {
	// No user is signed in.
}
```

***Note***: `CurrentUser` might also be `null` because the auth object has not finished initializing. If you use a listener to keep track of the user's sign-in status, you don't need to handle this case.

### Get a user's profile

To get a user's profile information, use the properties of an instance of `User`. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
string providerId = user.ProviderId;
string name = user.DisplayName;
string email = user.Email;
NSUrl photoUrl = user.PhotoUrl;

// The user's ID, unique to the Firebase project. Do NOT use this value to
// authenticate with your backend server, if you have one. Use
// GetToken method instead.
string uid = user.UID;
```

### Get a user's provider-specific profile information

To get the profile information retrieved from the sign-in providers linked to a user, use the ProviderData property. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
foreach (var profile in user.ProviderData) {
	string providerId = profile.ProviderId;
	string name = profile.DisplayName;
	string email = profile.Email;
	NSUrl photoUrl = profile.PhotoUrl;
}
```

### Update a user's profile

You can update a user's basic profile information—the user's display name and profile photo Url—with the `UserProfileChangeRequest` class. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
var changeRequest = user.ProfileChangeRequest ();
changeRequest.DisplayName = name;
changeRequest.PhotoUrl = new NSUrl (photoUrl);
changeRequest.CommitChanges ((error) => {
	if (error != null) {
		// An error happened.
	} else {
		// Profile updated.
	}
});
```

### Set a user's email address

You can set a user's email address with the `UpdateEmail` method. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
user.UpdateEmail (email, (error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that UpdateEmail method could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.EmailAlreadyInUse:
		case AuthErrorCode.InvalidEmail:
		case AuthErrorCode.RequiresRecentLogin:
		default:
			// Print error
			break;
		}
	} else {
		// Email updated.
	}
});
```

***Important***: To set a user's password, the user must have signed in recently. See **Re-authenticate a user** section.

### Send a user a verification email

You can send an address verification email to a user with the `SendEmailVerification` method. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
user.SendEmailVerification ((error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that SendEmailVerification method could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.UserNotFound:
		default:
			// Print error
			break;
		}
	} else {
		// Email sent.
	}
});
```

You can customize the email template that is used in Authentication section of the [Firebase console][1], on the Email Templates page. See [Email Templates][12] in Firebase Help Center.

### Set a user's password

You can set a user's password with the `UpdatePassword` method. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
user.UpdatePassword (password, (error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that UpdatePassword method could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.OperationNotAllowed:
		case AuthErrorCode.RequiresRecentLogin:
		case AuthErrorCode.WeakPassword:
		default:
			// Print error
			break;
		}
	} else {
		// Password updated.
	}
});
```

***Important***: To set a user's password, the user must have signed in recently. See **Re-authenticate a user** section.

### Send a password reset email

You can send a password reset email to a user with the `SendPasswordReset` method. For example:

```csharp
Auth.DefaultInstance.SendPasswordReset (email, (error) => {
	if (error != null)
		// An error happened.
	else
		// Password reset email sent.
});
```

You can customize the email template that is used in Authentication section of the [Firebase console][1], on the Email Templates page. See [Email Templates][12] in Firebase Help Center.

You can also send password reset emails from the Firebase console.

### Delete a user

You can delete a user account with the `Delete` method. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
user.Delete ((error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that Delete method could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.RequiresRecentLogin:
		default:
			// Print error
			break;
		}
	} else {
		// Account deleted.
	}
});
```

You can also delete users from the Authentication section of the [Firebase console][1], on the Users page.

***Important***: To set a user's password, the user must have signed in recently. See [Re-authenticate a user](#Re-authenticate-a-user) section.

### Re-authenticate a user

Some security-sensitive actions (such as **deleting an account**, **setting a primary email address**, and **changing a password**) require that the user has recently signed in. If you perform one of these actions, and the user signed in too long ago, the action fails with the `AuthErrorCode.RequiresRecentLogin` error. When this happens, re-authenticate the user by getting new sign-in credentials from the user and passing the credentials to `Reauthenticate` method. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
AuthCredential *credential;

// Prompt the user to re-provide their sign-in credentials

user.Reauthenticate (credential, (error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that Reauthenticate method could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.InvalidCredential:
		case AuthErrorCode.InvalidEmail:
		case AuthErrorCode.WrongPassword:
		case AuthErrorCode.UserMismatch:
		case AuthErrorCode.OperationNotAllowed:
		case AuthErrorCode.EmailAlreadyInUse:
		case AuthErrorCode.UserDisabled:
		default:
			// Print error
			break;
		}
	} else {
		// User re-authenticated.
	}
});
```

## Link Multiple Auth Providers to an Account

You can allow users to sign in to your app using multiple authentication providers by linking auth provider credentials to an existing user account. Users are identifiable by the same Firebase user ID regardless of the authentication provider they used to sign in. For example, a user who signed in with a password can link a Google account and sign in with either method in the future. Or, an anonymous user can link a Facebook account and then, later, sign in with Facebook to continue using your app.

### Link auth provider credentials to a user account

To link auth provider credentials to an existing user account:

1. Sign in the user using any authentication provider or method.
2. Complete the sign-in flow for the new authentication provider up to, but not including, calling one of the `SignIn` methods.
3. Get a `AuthCredential` for the new authentication provider.
4. Pass the `AuthCredential` object to the signed-in user's `Link` method:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
user.Link (credential, (user, error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that Link method could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.ProviderAlreadyLinked:
		case AuthErrorCode.CredentialAlreadyInUse:
		case AuthErrorCode.OperationNotAllowed:
		case AuthErrorCode.EmailAlreadyInUse:
		case AuthErrorCode.InvalidEmail:
		case AuthErrorCode.RequiresRecentLogin:
		case AuthErrorCode.WeakPassword:
		default:
			// Print error
			break;
		}
	} else {
		// Do your magic to handle link result
	}
});
```

The call to `Link` will fail if the credentials are already linked to another user account. In this situation, you must handle merging the accounts and associated data as appropriate for your app:

```csharp
var previousUser = Auth.DefaultInstance.CurrentUser;
Auth.DefaultInstance.SignIn (credential, (user, error) => {
	// ...
});
var currentUser = Auth.DefaultInstance.CurrentUser;

// Merge previousUser and currentUser accounts and data
// ...
```

If the call to `Link` succeeds, the user can now sign in using any linked authentication provider and access the same Firebase data.

### Unlink an auth provider from a user account

You can unlink an auth provider from an account, so that the user can no longer sign in with that provider.

To unlink an auth provider from a user account, pass the provider ID to the `Unlink` method. You can get the provider IDs of the auth providers linked to a user from the `ProviderData` property.

```csharp
var user = Auth.DefaultInstance.CurrentUser;
user.Unlink (providerId, (user, error) => {
	if (error != null) {
		AuthErrorCode errorCode;
		if (IntPtr.Size == 8) // 64 bits devices
			errorCode = (AuthErrorCode)((long)error.Code);
		else // 32 bits devices
			errorCode = (AuthErrorCode)((int)error.Code);

		// Posible error codes that Unlink method could throw
		// Visit https://firebase.google.com/docs/auth/ios/errors for more information
		switch (errorCode) {
		case AuthErrorCode.NoSuchProvider:
		case AuthErrorCode.RequiresRecentLogin:
		default:
			AppDelegate.ShowMessage ("Could delete the current user!", error.LocalizedDescription, NavigationController);
			break;
		}
	} else {
		// Provider unlinked from account
	}
});
```

## Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][13])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/auth/ios/manage-users) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://components.xamarin.com/gettingstarted/googleiossignin
[4]: https://components.xamarin.com/gettingstarted/facebookios
[5]: https://developers.facebook.com/
[6]: https://console.developers.google.com/apis/credentials
[7]: https://www.nuget.org/packages/xamarin.auth
[8]: https://components.xamarin.com/gettingstarted/xamarin.auth
[9]: https://apps.twitter.com/
[10]: https://github.com/settings/applications/new
[11]: https://github.com/settings/developers
[12]: https://support.google.com/firebase/answer/7000714
[13]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
[14]: https://firebase.google.com/pricing/
[15]: https://firebase.google.com/docs/cloud-messaging/ios/certs
[16]: https://developer.apple.com/membercenter/index.action