# Firebase Auth on iOS

You can use Firebase Authentication to allow users to sign in to your app using one or more sign-in methods, including email address and password sign-in, and federated identity providers such as Google Sign-in and Facebook Login. This tutorial gets you started with Firebase Authentication by showing you how to add email address and password sign-in to your app.

## Table of content

- [Firebase Auth on iOS](#firebase-auth-on-ios)
	- [Table of content](#table-of-content)
	- [Add Firebase to your app](#add-firebase-to-your-app)
	- [Configure Auth in your app](#configure-auth-in-your-app)
	- [Listen for authentication state](#listen-for-authentication-state)
	- [Sign up new users](#sign-up-new-users)
	- [Sign in existing users](#sign-in-existing-users)
	- [Get user information](#get-user-information)
- [Manage Users in Firebase](#manage-users-in-firebase)
	- [Create a user](#create-a-user)
	- [Get the currently signed-in user](#get-the-currently-signed-in-user)
	- [Sign out a user](#sign-out-a-user)
	- [Get a user's profile](#get-a-users-profile)
	- [Get a user's provider-specific profile information](#get-a-users-provider-specific-profile-information)
	- [Update a user's profile](#update-a-users-profile)
		- [Set a user's email address](#set-a-users-email-address)
	- [Send a user a verification email](#send-a-user-a-verification-email)
	- [Set a user's password](#set-a-users-password)
	- [Send a password reset email](#send-a-password-reset-email)
	- [Delete a user](#delete-a-user)
		- [Re-authenticate a user](#re-authenticate-a-user)
	- [Import user accounts](#import-user-accounts)
	- [Authenticate with Firebase using Password-Based Accounts](#authenticate-with-firebase-using-password-based-accounts)
		- [Create an account](#create-an-account)
	- [Sign in a user with an email address and password](#sign-in-a-user-with-an-email-address-and-password)
- [Authenticate Using Google Sign-In](#authenticate-using-google-sign-in)
- [Authenticate Using Facebook Login](#authenticate-using-facebook-login)
- [Authenticate Using Twitter Login](#authenticate-using-twitter-login)
- [Authenticate Using GitHub](#authenticate-using-github)
- [Authenticate with Firebase on iOS using a Phone Number](#authenticate-with-firebase-on-ios-using-a-phone-number)
	- [Security concerns](#security-concerns)
	- [1. Enable Phone Number sign-in for your Firebase project](#1-enable-phone-number-sign-in-for-your-firebase-project)
	- [2. Enable app verification](#2-enable-app-verification)
		- [Start receiving silent notifications](#start-receiving-silent-notifications)
		- [Set up reCAPTCHA verification](#set-up-recaptcha-verification)
	- [3. Send a verification code to the user's phone](#3-send-a-verification-code-to-the-users-phone)
	- [4. Sign in the user with the verification code](#4-sign-in-the-user-with-the-verification-code)
	- [Appendix: Using phone sign-in without swizzling](#appendix-using-phone-sign-in-without-swizzling)
- [Authenticate with Firebase Using a Custom Authentication System](#authenticate-with-firebase-using-a-custom-authentication-system)
- [Authenticate with Firebase Anonymously](#authenticate-with-firebase-anonymously)
- [Passing State in Email Actions](#passing-state-in-email-actions)
	- [Passing state/continue URL in email actions](#passing-statecontinue-url-in-email-actions)
	- [Configuring Firebase Dynamic Links](#configuring-firebase-dynamic-links)
	- [Handling email actions in a web application](#handling-email-actions-in-a-web-application)
	- [Handling email actions in a mobile application](#handling-email-actions-in-a-mobile-application)
	- [Convert an anonymous account to a permanent account](#convert-an-anonymous-account-to-a-permanent-account)
- [Link Multiple Auth Providers to an Account](#link-multiple-auth-providers-to-an-account)
	- [Link auth provider credentials to a user account](#link-auth-provider-credentials-to-a-user-account)
	- [Unlink an auth provider from a user account](#unlink-an-auth-provider-from-a-user-account)
- [Create custom email action handlers](#create-custom-email-action-handlers)
- [Extend Firebase Authentication with Cloud Functions](#extend-firebase-authentication-with-cloud-functions)
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

## Listen for authentication state

For each of your app's views that need information about the signed-in user, attach a listener to the `Auth` object. This listener gets called whenever the user's sign-in state changes.

Attach the listener in the view controller's `ViewWillAppear` method:

```csharp
var handle = Auth.DefaultInstance.AddAuthStateDidChangeListener (HandleAuthStateDidChangeListener);

void HandleAuthStateDidChangeListener (Auth auth, User user)
{
	// ...
}
```

And detach the listener in the view controller's `ViewWillDisappear` method:

```csharp
Auth.DefaultInstance.RemoveAuthStateDidChangeListener (handle);
```

## Sign up new users

Create a form that allows new users to register with your app using their email address and a password. When a user completes the form, validate the email address and password provided by the user, then pass them to the `CreateUser` method:

```csharp
Auth.DefaultInstance.CreateUser (email, password, HandleAuthResult);

void HandleAuthResult (User user, NSError error)
{
	// ...
}

// async/await version

try {
	User user = await Auth.DefaultInstance.CreateUserAsync (email, password);
} catch (NSErrorException ex) {
	// ...
}
```

## Sign in existing users

Create a form that allows existing users to sign in using their email address and password. When a user completes the form, call the `SignIn` method:

```csharp
Auth.DefaultInstance.SignIn (email, password, HandleAuthResult);

void HandleAuthResult (User user, NSError error)
{
	// ...
}

// async/await version

try {
	User user = await Auth.DefaultInstance.SignInAsync (email, password);
} catch (NSErrorException ex) {
	// ...
}
```

## Get user information

After a user signs in successfully, you can get information about the user. For example, in your authentication state listener:

```csharp
if (user != null) {
	// The user's ID, unique to the Firebase project.
	// Do NOT use this value to authenticate with your backend server,
	// if you have one. Use GetToken method instead.
	var uid = user.Uid;
	var email = user.Email;
	var photoUrl = user.PhotoUrl;
}
```

---

# Manage Users in Firebase

## Create a user

You create a new user in your Firebase project by calling the `CreateUser` method or by signing in a user for the first time using a federated identity provider, such as [Google Sign-In](#authenticate-using-google-sign-in) or [Facebook Login](#authenticate-using-facebook-login).

You can also create new password-authenticated users from the Authentication section of the [Firebase console][1], on the Users page.

## Get the currently signed-in user

The recommended way to get the current user is by setting a listener on the Auth object:

```csharp
var handle = Auth.DefaultInstance.AddAuthStateDidChangeListener (HandleAuthStateDidChangeListener);

void HandleAuthStateDidChangeListener (Auth auth, User user)
{
	// ...
}
```

To remove the listener, pass the `handle` to `RemoveAuthStateDidChangeListener`:

```csharp
Auth.DefaultInstance.RemoveAuthStateDidChangeListener (handle);
```

By using a listener, you ensure that the Auth object isn't in an intermediate state—such as initialization—when you get the current user.

You can also get the currently signed-in user by using the `CurrentUser` property. If a user isn't signed in, `CurrentUser` is `null`:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
if (user != null) {
	// User is signed in.
} else {
	// No user is signed in.
}
```

**_Note_**: _`CurrentUser` might also be `null` because the auth object has not finished initializing. If you use a listener to keep track of the user's sign-in status, you don't need to handle this case._

## Sign out a user

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

## Get a user's profile

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

## Get a user's provider-specific profile information

To get the profile information retrieved from the sign-in providers linked to a user, use the `ProviderData` property. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
foreach (var profile in user.ProviderData) {
	string providerId = profile.ProviderId;
	string name = profile.DisplayName;
	string email = profile.Email;
	NSUrl photoUrl = profile.PhotoUrl;
}
```

## Update a user's profile

You can update a user's basic profile information—the user's display name and profile photo Url—with the `UserProfileChangeRequest` class. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
var changeRequest = user.ProfileChangeRequest ();
changeRequest.DisplayName = name;
changeRequest.PhotoUrl = new NSUrl (photoUrl);

changeRequest.CommitChanges (HandleUserProfileChange);

void HandleUserProfileChange (NSError error)
{
	if (error != null) {
		// An error happened.
		return;
	}

	// Profile updated.
}

// async/await version

try {
	await changeRequest.CommitChangesAsync ();
	// Profile updated.
} catch (NSErrorException ex) {
	// An error happened.
}

```

### Set a user's email address

You can set a user's email address with the `UpdateEmail` method. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
user.UpdateEmail (email, HandleUserProfileChange);

void HandleUserProfileChange (NSError error)
{
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

		return;
	}

	// Email updated.
}

// async/await version

try {
	await user.UpdateEmailAsync (email);
	// Email updated.
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

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
}

```

> ![note_icon] **_Important_**: _To set a user's password, the user must have signed in recently. See [Re-authenticate a user](#re-authenticate-a-user) section._

## Send a user a verification email

You can send an address verification email to a user with the `SendEmailVerification` method. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
user.SendEmailVerification (HandleSendEmailVerification);

void HandleSendEmailVerification (NSError error)
{
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

		return;
	}

	// Email sent.
}

// async/await version
try {
	await user.SendEmailVerificationAsync ();
	// Email sent.
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

	// Posible error codes that SendEmailVerification method could throw
	// Visit https://firebase.google.com/docs/auth/ios/errors for more information
	switch (errorCode) {
	case AuthErrorCode.UserNotFound:
	default:
		// Print error
		break;
	}
}
```

You can customize the email template that is used in Authentication section of the [Firebase console][1], on the Email Templates page. See [Email Templates][12] in Firebase Help Center.

It is also possible to pass state via a [continue URL](#passing-state-in-email-actions) to redirect back to the app when sending a verification email.

Additionally you can localize the verification email by updating the language code on the Auth instance before sending the email. For example:

```csharp
Auth.DefaultInstance.LanguageCode = "es";

// To apply the default app language instead of explicitly setting it.
Auth.DefaultInstance.UseAppLanguage ();
```

## Set a user's password

You can set a user's password with the `UpdatePassword` method. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
user.UpdatePassword (password, HandleUserProfileChange);

void HandleUserProfileChange (NSError error)
{
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

		return;
	}

	// Password updated.
}

//async/await version

try {
	await user.UpdatePasswordAsync (password);
	// Password updated.
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

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
}
```

> ![note_icon] **_Important_**: _To set a user's password, the user must have signed in recently. See [Re-authenticate a user](#re-authenticate-a-user) section._

## Send a password reset email

You can send a password reset email to a user with the `SendPasswordReset` method. For example:

```csharp
Auth.DefaultInstance.SendPasswordReset (email, HandleSendPasswordReset);

void HandleSendPasswordReset (NSError error)
{
	if (error != null) {
		// An error happened.
	} else {
		// Password reset email sent.
	}
}

// async/await version

try {
	await Auth.DefaultInstance.SendPasswordReset (email);
	// Password reset email sent.
} catch (NSErrorException ex) {
	// An error happened.
}
```

You can customize the email template that is used in Authentication section of the [Firebase console][1], on the Email Templates page. See [Email Templates][12] in Firebase Help Center.

It is also possible to pass state via a [continue URL](#passing-state-in-email-actions) to redirect back to the app when sending a verification email.

Additionally you can localize the verification email by updating the language code on the Auth instance before sending the email. For example:

```csharp
Auth.DefaultInstance.LanguageCode = "es";

// To apply the default app language instead of explicitly setting it.
Auth.DefaultInstance.UseAppLanguage ();
```

You can also send password reset emails from the Firebase console.

## Delete a user

You can delete a user account with the `Delete` method. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
user.Delete (HandleUserProfileChange);

void HandleUserProfileChange (NSError error)
{
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

		return;
	} 

	// Account deleted.
}

// async/await version

try {
	await user.DeleteAsync ();
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

	// Posible error codes that Delete method could throw
	// Visit https://firebase.google.com/docs/auth/ios/errors for more information
	switch (errorCode) {
	case AuthErrorCode.RequiresRecentLogin:
	default:
		// Print error
		break;
	}
}
```

You can also delete users from the Authentication section of the [Firebase console][1], on the Users page.

> ![note_icon] **_Important_**: _To set a user's password, the user must have signed in recently. See [Re-authenticate a user](#re-authenticate-a-user) section._

### Re-authenticate a user

Some security-sensitive actions (such as **deleting an account**, **setting a primary email address**, and **changing a password**) require that the user has recently signed in. If you perform one of these actions, and the user signed in too long ago, the action fails with the `AuthErrorCode.RequiresRecentLogin` error. When this happens, re-authenticate the user by getting new sign-in credentials from the user and passing the credentials to `Reauthenticate` method. For example:

```csharp
var user = Auth.DefaultInstance.CurrentUser;
AuthCredential credential;

// Prompt the user to re-provide their sign-in credentials

user.Reauthenticate (credential, HandleUserProfileChange);

void HandleUserProfileChange (NSError error)
{
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

		return;
	}

	// User re-authenticated.
}

// async/await version

try {
	await user.ReauthenticateAsync (credential);
	// User re-authenticated.
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

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
}
```

## Import user accounts

You can import user accounts from a file into your Firebase project by using the Firebase CLI's `auth:import` command. For example:

```
firebase auth:import users.json --hash-algo=scrypt --rounds=8 --mem-cost=14
```

---

## Authenticate with Firebase using Password-Based Accounts

You can use Firebase Authentication to let your users authenticate with Firebase using their email addresses and passwords, and to manage your app's password-based accounts.

### Create an account

When a new user signs up using your app's sign-up form, complete any new account validation steps that your app requires, such as verifying that the new account's password was correctly typed and meets your complexity requirements.

Create a new account by passing the new user's email address and password to `Auth.CreateUser` instance method (don't forget to import `Firebase.Auth` namespace):

```csharp
Auth.DefaultInstance.CreateUser (email, password, HandleAuthResult);

void HandleAuthResult (User user, NSError error)
{
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

		return;
	}
	// Do your magic to handle authentication result
}

// async/await version

try {
	User user = await Auth.DefaultInstance.CreateUserAsync (email, password);
	// Do your magic to handle authentication result
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

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
}
```

If the new account was successfully created, the user is signed in, and you can get the user's account data from the user object that's passed to the callback method.

> ![note_icon] _**Note:**_ _To protect your project from abuse, Firebase limits the number of new email/password and anonymous sign-ups that your application can have from the same IP address in a short period of time. You can request and schedule temporary changes to this quota from the [Firebase console][1]._

## Sign in a user with an email address and password

When a user signs in to your app, pass the user's email address and password to `Auth.SignIn` instance method (don't forget to import `Firebase.Auth` namespace):

```csharp
Auth.DefaultInstance.SignIn (email, password, HandleAuthResult);

void HandleAuthResult (User user, NSError error)
{
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

		return;
	}

	// Do your magic to handle authentication result
}

// async/await version

try {
	User user = await Auth.DefaultInstance.SignInAsync (email, password);
	// Do your magic to handle authentication result
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

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
}
```

If the user successfully signs in, you can get the user's account data from the user object that's passed to the callback method.

---

# Authenticate Using Google Sign-In

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
		Auth.DefaultInstance.SignIn (credential, HandleAuthResult);
	} else {
		// Print error
	}

	void HandleAuthResult (User user, NSError error)
	{
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

			return;
		}

		// Do your magic to handle authentication result
	}
}
```

---

# Authenticate Using Facebook Login

You can let your users authenticate with Firebase using their Facebook accounts by integrating Facebook Login into your app. To be able to use this authentication, please, first integrate [Facebook iOS SDK][4] to your app.

Once you have integrated Facebook into your app, follow these steps to complete your integration with Firebase:

* If you haven't yet connected your app to your Firebase project, do so from the [Firebase console][1].
* On the [Facebook for Developers][5] site, get the **App ID** and an **App Secret** for your app.
* Enable Facebook Login:
  * In the [Firebase console][1], open the Auth section.
  * On the **Sign in method** tab, enable the **Facebook** sign-in method and specify the **App ID** and **App Secret** you got from Facebook.
  * Then, make sure your **OAuth redirect URI** (e.g. `my-app-12345.firebaseapp.com/__/auth/handler`) is listed as one of your **OAuth redirect URIs** in your Facebook app's settings page on the [Facebook for Developers][5] site in the **Products** > **Facebook Login** > **Settings**.
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
	Auth.DefaultInstance.SignIn (credential, HandleAuthResult);

	void HandleAuthResult (User user, NSError error)
	{
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

			return;
		}

		// Do your magic to handle authentication result
	}
};
```

---

# Authenticate Using Twitter Login

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
Auth.DefaultInstance.SignIn (credential, HandleAuthResult);

void HandleAuthResult (User user, NSError error)
{
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

		return;
	}

	// Do your magic to handle authentication result
}
```

***Optional:*** Add an email address to the user's profile. When users sign in to your app with Twitter, their email addresses aren't accessible to Firebase. If you want to add email addresses to the profiles of users that sign in with Twitter, prompt users to provide their email addresses, and then call `UpdateEmail` method as in the following example:

```csharp
user.UpdateEmail (email, HandleUserProfileChange);

void HandleUserProfileChange (NSError error)
{
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

		return;
	}

	// Email updated.
}
```

---

# Authenticate Using GitHub

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
Auth.DefaultInstance.SignIn (credential, HandleAuthResult);

void HandleAuthResult (User user, NSError error)
{
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

		return;
	}

	// Do your magic to handle authentication result
}
```

---

# Authenticate with Firebase on iOS using a Phone Number

You can use Firebase Authentication to sign in a user by sending an SMS message to the user's phone. The user signs in using a one-time code contained in the SMS message.

Phone number sign-in requires a physical device and won't work on a simulator.

This document describes how to implement a phone number sign-in flow using the Firebase SDK.

> ![note_icon] _**Note:**_ _Phone numbers that end users provide for authentication will be sent and stored by Google to improve our spam and abuse prevention across Google services, including but not limited to Firebase. Developers should ensure they have appropriate end-user consent prior to using the Firebase Authentication phone number sign-in service._

## Security concerns

Authentication using only a phone number, while convenient, is less secure than the other available methods, because possession of a phone number can be easily transferred between users. Also, on devices with multiple user profiles, any user that can receive SMS messages can sign in to an account using the device's phone number.

If you use phone number based sign-in in your app, you should offer it alongside more secure sign-in methods, and inform users of the security tradeoffs of using phone number sign-in.

## 1. Enable Phone Number sign-in for your Firebase project

To sign in users by SMS, you must first enable the Phone Number sign-in method for your Firebase project:

1. In the [Firebase console][1], open the **Authentication** section.
2. On the **Sign-in Method** page, enable the **Phone Number** sign-in method.

Firebase's phone number sign-in request quota is high enough that most apps won't be affected. However, if you need to sign in a very high volume of users with phone authentication, you might need to upgrade your pricing plan. See the [pricing][14] page.

## 2. Enable app verification

To use phone number authentication, Firebase must be able to verify that phone number sign-in requests are coming from your app. There are two ways Firebase Authentication accomplishes this:

* **Silent APNs notifications:** When you sign in a user with their phone number for the first time on a device, Firebase Authentication sends a token to the device using a silent push notification. If your app successfully receives the notification from Firebase, phone number sign-in can proceed.

	For iOS 8.0 and newer, silent notifications do not require explicit user consent and is therefore unaffected by a user declining to receive APNs notifications in the app. Thus, the app does not need to request user permission to receive push notifications when implementing Firebase phone number auth.

* **reCAPTCHA verification**: In the event that sending or receiving a silent push notification is not possible, such as when the user has disabled background refresh for your app, or when testing your app on an iOS simulator, Firebase Authentication uses reCAPTCHA verification to complete the phone sign-in flow. The reCAPTCHA challenge can often be completed without the user having to solve anything.

When silent push notifications are properly configured, only a very small percentage of users will experience the reCAPTCHA flow. Nonetheless, you should ensure that phone number sign-in functions correctly whether or not silent push notifications are available.

> ![note_icon] To ensure that both scenarios are working correctly, test your app on a physical iOS device with background app refresh both enabled and disabled. When background app refresh is disabled, you should be able to successfully sign in after completing the reCAPTCHA challenge. You can also test the reCAPTCHA flow by running your app on an iOS simulator, which always uses the reCAPTCHA flow.

### Start receiving silent notifications

To enable APNs notifications for use with Firebase Authentication:

1. In Visual Studio, enable push notifications for your project by opening **Entitlements.plist** and enabling **Push Notifications**.
2. Upload your APNs authentication key to Firebase. If you don't already have an APNs authentication key, see [Configuring APNs with FCM][15].
	1. Inside your project in the Firebase console, select the gear icon, select **Project Settings**, and then select the **Cloud Messaging** tab.
	2. In **APNs authentication key** under **iOS app configuration**, click the **Upload** button.
	3. Browse to the location where you saved your key, select it, and click **Open**. Add the key ID for the key (available in **Certificates**, **Identifiers** & **Profiles** in the [Apple Developer Member Center][16]) and click **Upload**.

If you already have an APNs certificate, you can upload the certificate instead.

### Set up reCAPTCHA verification

To enable the Firebase SDK to use reCAPTCHA verification:

1. Add custom URL schemes to your project:
    
	1. Open your **Info.plist**: Select the **Advance** tab, and expand the URL Types section.
	2. Click the **Add URL Type** button, and add a **URL scheme** for your **reversed client ID**. To find this value, open the **GoogleService-Info.plist** configuration file, and look for the **REVERSED_CLIENT_ID** key. Copy the value of that key, and paste it into the **URL Schemes** box on the configuration page. Leave the other fields blank.

2. **Optional:** If you want to customize the way your app presents the `SFSafariViewController` or `UIWebView` when displaying the reCAPTCHA to the user, create a custom class that conforms to the IAuthUIDelegate interface, and pass it to `VerifyPhoneNumber (string, IAuthUIDelegate, VerificationResultHandler)` overload method.

## 3. Send a verification code to the user's phone

To initiate phone number sign-in, present the user an interface that prompts them to provide their phone number, and then call `VerifyPhoneNumber` method to request that Firebase send an authentication code to the user's phone by SMS:

1. Get the user's phone number.

    Legal requirements vary, but as a best practice and to set expectations for your users, you should inform them that if they use phone sign-in, they might receive an SMS message for verification and standard rates apply.

2. Call `VerifyPhoneNumber`, passing to it the user's phone number:

	```csharp
	PhoneAuthProvider.DefaultInstance.VerifyPhoneNumber (phoneNumber, HandleVerificationResult);

	void HandleVerificationResult (string verificationId, NSError error)
	{
		if (error != null) {
			Console.WriteLine (error.LocalizedDescription);
			return;
		}

		// Sign in using the verificationID and the code sent to the user
		// ...
	}

	// async/await version

	try {
		string verificationId = await PhoneAuthProvider.DefaultInstance.VerifyPhoneNumberAsync (phoneNumber);

		// Sign in using the verificationID and the code sent to the user
		// ...
	} catch (NSErrorException ex) {
		Console.WriteLine (ex.Error.LocalizedDescription);
	}
	```
	
	When you call `VerifyPhoneNumber`, Firebase sends a silent push notification to your app or issues a reCAPTCHA challenge to the user. After your app receives the notification or the user completes the reCAPTCHA challenge, Firebase sends an SMS message containing an authentication code to the specified phone number and passes a verification ID to your completion function. You will need both the verification code and the verification ID to sign in the user.

	The SMS message sent by Firebase can also be localized by specifying the auth language via the languageCode property on your Auth instance:

	```csharp
	Auth.DefaultInstance.LanguageCode = "es";
	```

3. Save the verification ID and restore it when your app loads. By doing so, you can ensure that you still have a valid verification ID if your app is terminated before the user completes the sign-in flow (for example, while switching to the SMS app).

	You can persist the verification ID any way you want. A simple way is to save the verification ID with the `NSUserDefaults` object:

	```csharp
	NSUserDefaults.StandardUserDefaults.SetString (verificationId, "authVerificationID");	
	```

	Then, you can restore the saved value:

	```csharp
	var verificationId = NSUserDefaults.StandardUserDefaults.StringForKey ("AuthVerificationID");
	```

If the call to `VerifyPhoneNumber` succeeds, you can prompt the user to type the verification code when they receive it in the SMS message.

> ![note_icon] _**Note:**_ _To prevent abuse, Firebase enforces a limit on the number of SMS messages that can be sent to a single phone number within a period of time. If you exceed this limit, phone number verification requests might be throttled. If you encounter this issue during development, use a different phone number for testing, or try the request again later._

## 4. Sign in the user with the verification code

After the user provides your app with the verification code from the SMS message, sign the user in by creating a `PhoneAuthCredential` object from the verification code and verification ID and passing that object to `SignIn (AuthCredential, AuthResultHandler)` method.

1. Get the verification code from the user.
2. Create a `PhoneAuthCredential` object from the verification code and verification ID:

	```csharp
	var credential = PhoneAuthProvider.DefaultInstance.GetCredential (verificationId, verificationCode);
	```

3. Sign in the user with the `PhoneAuthCredential` object:

	```csharp
	Auth.DefaultInstance.SignIn (credential, HandleAuthResult);

	void HandleAuthResult (User user, NSError error)
	{
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

			return;
		}

		// Do your magic to handle authentication result
	}
	```

## Appendix: Using phone sign-in without swizzling

Firebase Authentication uses method swizzling to automatically obtain your app's APNs token and to handle the silent push notifications that Firebase sends to your app, and to automatically intercept the custom scheme redirect from the reCAPTCHA verification page during verification.

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

To handle the custom scheme redirect URL, implement the `OpenUrl (UIApplication, NSUrl, string, NSObject)` overload method for devices running iOS 8 and older, and the `OpenUrl (UIApplication, NSUrl, NSDictionary)` overload method for devices running iOS 9 and newer, and in them, pass the URL to `Auth`'s `CanHandleURrl` method:

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
	if (Auth.DefaultInstance.CanHandleUrl (url)) {
		return true;
	}

	// URL not auth related, developer should handle it.
}
```

---

# Authenticate with Firebase Using a Custom Authentication System

You can integrate Firebase Authentication with a custom authentication system by modifying your authentication server to produce custom signed tokens when a user successfully signs in. Your app receives this token and uses it to authenticate with Firebase.

Follow these steps to complete your integration with Firebase:

* Get your project's server keys:
  * Go to the [Service Accounts][6] page in your project's settings.
  * Click _Generate New Private Key_ at the bottom of the _Firebase Admin SDK section of the Service Accounts_ page
  * The new service account's public/private key pair is automatically saved on your computer. Copy this file to your authentication server.
* When users sign in to your app, send their sign-in credentials (for example, their username and password) to your authentication server. Your server checks the credentials and returns a [custom token][17] if they are valid.
* After you receive the custom token from your authentication server, pass it to `SignIn` method to sign in the user:

```csharp
Auth.DefaultInstance.SignIn (credential, HandleAuthResult);

void HandleAuthResult (User user, NSError error)
{
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

		return;
	}

	// Do your magic to handle authentication result
}
```

---

# Authenticate with Firebase Anonymously

You can use Firebase Authentication to create and use temporary anonymous accounts to authenticate with Firebase. These temporary anonymous accounts can be used to allow users who haven't yet signed up to your app to to work with data protected by security rules. If an anonymous user decides to sign up to your app, you can [link their sign-in credentials to the anonymous account](#link-multiple-auth-providers-to-an-account) so that they can continue to work with their protected data in future sessions.

Follow these steps to complete your integration with Firebase:

* If you haven't yet connected your app to your Firebase project, do so from the [Firebase console][1].
* Enable anonymous auth in the Firebase console:
  * In the [Firebase console][1], open the **Auth** section.
  * On the **Sign in method** tab, enable the **Anonymous** sign-in method and click **Save**.
* When a signed-out user uses an app feature that requires authentication with Firebase, sign in the user anonymously by using `Auth.SignInAnonymously` instance method:

```csharp
Auth.DefaultInstance.SignInAnonymously (HandleAuthResultHandler);

void HandleAuthResultHandler (User user, NSError error)
{
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

		return;
	}

	// Do your magic to handle authentication result
}

// async/await version

try {
	User user = await Auth.DefaultInstance.SignInAnonymouslyAsync ();
	// Do your magic to handle authentication result
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

	// Posible error codes that SignInAnonymously method could throw
	// Visit https://firebase.google.com/docs/auth/ios/errors for more information
	switch (errorCode) {
	case AuthErrorCode.OperationNotAllowed:
	default:
		// Print error
		break;
	}
}
```

After a successful login, you can get the anonymous user's account data from the `User` object:

```csharp
bool isAnonymous = user.IsAnonymous;
string uid = user.Uid;
```

---

# Passing State in Email Actions

You can pass state via a continue URL when sending email actions for password resets or verifying a user's email. This provides the user the ability to be returned to the app after the action is completed. In addition, you can specify whether to handle the email action link directly from a mobile application when it is installed instead of a web page.

This can be extremely useful in the following common scenarios:

* A user, not currently logged in, may be trying to access content that requires the user to be signed in. However, the user might have forgotten their password and therefore trigger the reset password flow. At the end of the flow, the user expects to go back to the section of the app they were trying to access.
* An application may only offer access to verified accounts. For example, a newsletter app may require the user to verify their email before subscribing. The user would go through the email verification flow and expect to be returned to the app to complete their subscription.
* In general, when a user begins a password reset or email verification flow on an iOS app they expect to complete the flow within the app; the ability to pass state via continue URL makes this possible.

Having the ability to pass state via a continue URL is a powerful feature that Firebase Auth provides and which can significantly enhance the user experience.

## Passing state/continue URL in email actions

In order to securely pass a continue URL, the domain for the URL will need to be whitelisted in the [Firebase console][1]. This is done in the **Authentication** section by adding this domain to the list of **OAuth redirect domains** if it is not already there.

A `ActionCodeSettings` instance needs to be provided when sending a password reset email or a verification email. This interface takes the following parameters:

| Parameter                        | Type   | Description |
|----------------------------------|--------|-------------|
| **Url**                          | String | Sets the link (state/continue URL) which has different meanings in different contexts:<br /><ul><li>When the link is handled in the web action widgets, this is the deep link in the **continueUrl** query parameter.</li><br /><li>When the link is handled in the app directly, this is the **continueUrl** query parameter in the deep link of the Dynamic Link.</li></ul> |
| **IOSBundleID**                  | String | Sets the iOS bundle ID. This will try to open the link in an iOS app if it is installed. The iOS app needs to be registered in the Console. If no Bundle ID is provided, the value of this field is set to the bundle ID of the App's main bundle. |
| **AndroidPackageName**           | String | Sets the Android package name. This will try to open the link in an android app if it is installed. |
| **AndroidInstallIfNotAvailable** | Bool   | Specifies whether to install the Android app if the device supports it and the app is not already installed. If this field is provided without a packageName, an error is thrown explaining that the |packageName must be provided in conjunction with this field. |
| **AndroidMinimumVersion**        | String | The minimum version of the app that is supported in this flow. If minimumVersion is specified, and an older version of the app is installed, the user is taken to the Play Store to upgrade the app. The Android app needs to be registered in the Console. |
| **HandleCodeInApp**              | Bool   | Whether the email action link will be opened in a mobile app or a web link first. The default is false. When set to true, the action code link will be be sent as a Universal Link or Android App Link and will be opened by the app if installed. In the false case, the code will be sent to the web widget first and then on continue will redirect to the app if installed. |

The following example illustrates how to send an email verification link that will open in a mobile app first as a Firebase Dynamic Link (iOS app `com.example.ios` or Android app `com.example.android` where the app will install if not already installed and the minimum version is `12`). The deep link will contain the continue URL payload `https://www.example.com/?email=user@example.com`.

```csharp
var user = Auth.DefaultInstance.CurrentUser;

var actionCodeSettings = new ActionCodeSettings { 
	HandleCodeInApp = true,
	Url = new NSUrl ($"https://www.example.com/?email={user.Email}"),
	IOSBundleId = NSBundle.MainBundle.BundleIdentifier
};
actionCodeSettings.SetAndroidPackageName ("com.example.android", true, "12");

user.SendEmailVerification (actionCodeSettings,HandleSendEmailVerification);

void HandleSendEmailVerification (NSError error)
{
	if (error != null) {
		// Error occurred. Inspect error.code and handle error.
		return;
	}

	// Email verification sent.
}

// async/await version

try {
	await user.SendEmailVerificationAsync (actionCodeSettings);
	// Email verification sent.
} catch (NSErrorException ex) {
	// Error occurred. Inspect error.code and handle error.
}
```

## Configuring Firebase Dynamic Links

Firebase Auth uses [Firebase Dynamic Links][18] when sending a link that is meant to be opened in a mobile application. In order to use this feature, Dynamic Links need to be configured in the Firebase Console.

1. Enable Firebase Dynamic Links:

	1. In the [Firebase console][1], open the **Dynamic Links** section.
	2. If you have not yet accepted the Dynamic Links terms, select **Get Started**. Go back to the main Dynamic Links dashboard.
	3. Take note of your **Dynamic Link Domain**. It should look as follows: **abc123.app.goo.gl**. This will needed when configuring the Android or iOS app to intercept the incoming link.

2. Configuring iOS applications:

	1. If you plan on handling these links from your iOS appliction, the iOS bundle ID needs to be specified in the Firebase Console project settings. In addition, the App Store ID and the Apple Developer Team ID also need to be specified.
	2. You will also need to configure the FDL universal link domain as an Associated Domain in your application capabilities.
	3. If you plan to distribute your application to iOS versions 8 and under, you will need to set your iOS bundle ID as a custom scheme for incoming URLs.

## Handling email actions in a web application

You can specify whether you want to handle the action code link from a web application first and then redirect to another web page or mobile application after successful completion, provided the mobile application is available. This is done by setting `HandleCodeInApp` to `false` in the `ActionCodeSettings` object. While an iOS bundle ID or Android package name are not required, providing them will allow the user to redirect back to the specified app on email action code completion.

The web URL used here, is the one configured in the email action templates section. A default one is provisioned for all projects. Refer to [customizing email handlers](#create–custom-email-action-handlers) to learn more on how to customize the email action handler.

In this case, the link within the `continueURL` query parameter will be an FDL link whose payload is the `URL` specified in the ActionCodeSettings object. While you can intercept and handle the incoming link from your app without any additional dependency, we recommend using the FDL client library to parse the deep link for you.

## Handling email actions in a mobile application

You can specify whether you want to handle the action code link within your mobile application first, provided it is installed. With Android applications, you also have the ability to specify via the `AndroidInstallIfNotAvailable` that the app is to be installed if the device supports it and it is not already installed. If the link is clicked from a device that does not support the mobile application, it is opened from a web page instead. This is done by setting handleCodeInApp to true in the FIRActionCodeSettings (Obj-C) or ActionCodeSettings (Swift) object. The mobile application's Android package name or iOS bundle ID will also need to be specified.The fallback web URL used here, when no mobile app is available, is the one configured in the email action templates section. A default one is provisioned for all projects. Refer to [customizing email handlers](#create–custom-email-action-handlers) to learn more on how to customize the email action handler.

In this case, the mobile app link sent to the user will be an FDL link whose payload is the action code URL, configured in the Console, with the query parameters `oobCode`, `mode`, `apiKey` and `continueUrl`. The latter will be the original URL specified in the `ActionCodeSettings` object. While you can intercept and handle the incoming link from your app without any additional dependency, we recommend using the FDL client library to parse the deep link for you. The action code can be applied directly from a mobile application similar to how it is handled from the web flow described in the [customizing email handlers](#create–custom-email-action-handlers) section.

---

## Convert an anonymous account to a permanent account

When an anonymous user signs up to your app, you might want to allow them to continue their work with their new account—for example, you might want to make the items the user added to their shopping cart before they signed up available in their new account's shopping cart. To do so, complete the following steps:

1. When the user signs up, complete the sign-in flow for the user's authentication provider up to, but not including, calling one of the `Auth.SignIn` methods.
2. Get an `AuthCredential` for the new authentication provider
3. Pass the `AuthCredential` object to the sign-in user's `Link` method:

```csharp
user.Link (credential, HandleAuthResult);

void HandleAuthResult (User user, NSError error)
{
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

		return;
	}

	// Do your magic to handle link result
}

// async/await version

try {
	User user = user.Link (credential, HandleAuthResult);
	// Do your magic to handle link result
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

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
}
```

If the call to `Link` succeeds, the user's new account can access the anonymous account's Firebase data.

> ![note_icon] This technique can also be used to [link any two accounts](#link-multiple-auth-providers-to-an-account).

---

# Link Multiple Auth Providers to an Account

You can allow users to sign in to your app using multiple authentication providers by linking auth provider credentials to an existing user account. Users are identifiable by the same Firebase user ID regardless of the authentication provider they used to sign in. For example, a user who signed in with a password can link a Google account and sign in with either method in the future. Or, an anonymous user can link a Facebook account and then, later, sign in with Facebook to continue using your app.

## Link auth provider credentials to a user account

To link auth provider credentials to an existing user account:

1. Sign in the user using any authentication provider or method.
2. Complete the sign-in flow for the new authentication provider up to, but not including, calling one of the `SignIn` methods.
3. Get a `AuthCredential` for the new authentication provider.
4. Pass the `AuthCredential` object to the signed-in user's `Link` method:

```csharp
var currentUser = Auth.DefaultInstance.CurrentUser;
currentUser.Link (credential, HandleAuthResultHandler);

void HandleAuthResultHandler (User user, NSError error)
{
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

		return;
	}

	// Do your magic to handle link result
}

// async/await version

var currentUser = Auth.DefaultInstance.CurrentUser;

try {
	User user = currentUser.LinkAsync (credential);
	// Do your magic to handle link result
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

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
}
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

## Unlink an auth provider from a user account

You can unlink an auth provider from an account, so that the user can no longer sign in with that provider.

To unlink an auth provider from a user account, pass the provider ID to the `Unlink` method. You can get the provider IDs of the auth providers linked to a user from the `ProviderData` property.

```csharp
var currentUser  = Auth.DefaultInstance.CurrentUser;
currentUser .Unlink (providerId, HandleAuthResult);

void HandleAuthResult (User user, NSError error)
{
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
			// Print error
			break;
		}
	} 

	// Provider unlinked from account
}

// async/await version

try {
	User user = currentUser.UnlinkAsync (providerId);
	// Provider unlinked from account
} catch (NSErrorException ex) {
	AuthErrorCode errorCode;
	if (IntPtr.Size == 8) // 64 bits devices
		errorCode = (AuthErrorCode)((long)ex.Error.Code);
	else // 32 bits devices
		errorCode = (AuthErrorCode)((int)ex.Error.Code);

	// Posible error codes that Unlink method could throw
	// Visit https://firebase.google.com/docs/auth/ios/errors for more information
	switch (errorCode) {
	case AuthErrorCode.NoSuchProvider:
	case AuthErrorCode.RequiresRecentLogin:
	default:
		// Print error
		break;
	}
}

```

---

# Create custom email action handlers

Some user management actions, such as updating a user's email address and resetting a user's password, result in emails being sent to the user. These emails contain links that recipients can open to complete or cancel the user management action. By default, user management emails link to the default action handler, which is a web page hosted at a URL in your project's Firebase Hosting domain.

To learn more about this, please, read the following [documentation][19].

---

# Extend Firebase Authentication with Cloud Functions

You can trigger a function in response to the creation and deletion of user accounts via Firebase Authentication. For example, you could send a welcome email to a user who has just created an account in your app.

To learn more about this, please, read the following [documentation][20].

---

# Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][13])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/auth/ios/manage-users) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://components.xamarin.com/gettingstarted/googleiossignin
[4]: https://components.xamarin.com/gettingstarted/facebookios
[5]: https://developers.facebook.com/
[6]: https://console.firebase.google.com/u/0/project/_/settings/serviceaccounts/adminsdk
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
[17]: https://firebase.google.com/docs/auth/admin/create-custom-tokens
[18]: https://components.xamarin.com/view/firebaseiosdynamiclinks
[19]: https://firebase.google.com/docs/auth/custom-email-handler
[20]: https://firebase.google.com/docs/auth/ios/account-linking
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
