Instance ID provides a unique ID per instance of your Android and iOS apps.

## Key features

In addition to providing unique IDs for authentication, Instance ID can generate security tokens for use with other services. Other features include:

### Generate Security Tokens

Instance ID provides a simple API to generate security tokens that authorize third parties to access your app's server side managed resources. Use these tokens now to authorize push messages for your apps via Google Cloud Messaging.


### Confirm app device is active

The Instance ID server can tell you when the device on which your app is installed was last used. Use this to decide whether to keep data from your app or send a push message to reengage with your users.


### Identify and track apps

Instance ID is unique across all app instances across the world, so your database can use it to uniquely identify and track app instances. Your server-side code can verify, via the Instance ID cloud service, that an Instance ID is genuine and is the same ID as the original app that registered with your server. For privacy, your app can delete an Instance ID so it is no longer associated with any history in the database. The next time your app calls Instance ID it will get an entirely new Instance ID with no relationship to its previous one.


## Instance ID lifecycle

The Instance ID service issues an InstanceID when your app comes online. The InstanceID is backed by a public/private key pair with the private key stored on the local device and the public key registered with the Instance ID service.

Your app can request a fresh InstanceID whenever needed using the `GetID (..)` method. Your app can store it on your server if you have one that supports your app.

Your app can request tokens from the Instance ID service as needed using the `GetToken (..)` method, and like InstanceID, your app can also store tokens on your own server. All tokens issued to your app belong to the app's InstanceID.

Tokens are unique and secure, but your app or the Instance ID service may need to refresh tokens in the event of a security issue or when a user uninstalls and reinstalls your app during device restoration. Your app must implement a listener to respond to token refresh requests from the Instance ID service.

![InstanceIDLifecycle](https://developers.google.com/instance-id/guides/images/iid-lifecycle.png)