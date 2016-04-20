## Before you Begin

Before using this component, you'll need the following:

- A Google [Tag Manager Account][1]
- A new Tag Manager [container and value collection macro/user-defined variable][2]

[1]: https://www.google.com/analytics/tag-manager/
[2]: https://support.google.com/tagmanager/answer/6103696?rd=1

## Adding a Default Container File to your Project

Google Tag Manager uses a default container on the first run of your application. The default container will be used until the app is able to retrieve a fresh container over the network.

To download and add a default container binary to your application, follow these steps:

1. Sign in to the Google Tag Manager web interface.
2. Select the Version of the container you'd like to download.
3. Click the Download button to retrieve the container binary.
4. The default filename should be the container ID (for example GTM-1234 without any extension)
5. Add the binary file to your Resources folder in your project.

Although using the binary file is recommended, if your container does not contain rules or tags, you may choose to use a simple property list or JSON file instead. The file should be located in tour Resources folder and should follow this naming convention: <Container_ID>.<plist|json>. For example, if your container ID is GTM-1234, you could specify your default container values in a property list file named GTM-1234.plist. If both a property list and JSON default container are present in the main bundle, the SDK will use the Property List as the default container.

## Opening a Container

Before retrieving values from a container, your application needs to open the container. Opening a container will load it from disk (if available), or will request it from the network (if needed).

The easiest way to open a container on iOS is by using `ContainerOpener.OpenContainer` method, as in the following example:

```csharp

...
using Google.TagManager;
...

public partial class AppDelegate : UIApplicationDelegate, IContainerOpenerNotifier
{
	Manager manager;
	Container container;

	// To get a Container ID, create an account on https://www.google.com/analytics/tag-manager/
	// then, create a Container and you will obtain an ID. You can create many Containers as you wish
	string tagManagerContainerId = "GTM-XXXX";

	public override bool FinishedLaunching (UIApplication app, NSDictionary options)
	{
		manager = Manager.GetInstance;
		// Optional: Change the LogLevel to Verbose to enable logging at VERBOSE and higher levels.
		manager.Logger.SetLogLevel (LoggerLogLevelType.Verbose);

		// Opens the container
		ContainerOpener.OpenContainer (tagManagerContainerId, manager, OpenType.PreferFresh, null, this);
		
		return true;
	}
}

#region IContainerOpenerNotifier
public void ContainerAvailable (Container container)
{
	// Note that ContainerAvailable may be called on any thread, so you may need to dispatch back to
	// your main thread.
	InvokeOnMainThread (() => {
		// If container is available, save it somewhere within your app
		AppDelegate.Container = container;

		// Refresh UI
		AddAnimals ();
		btnRefresh.Enabled = true;
	});
}
#endregion

```

## Getting Configuration Values from the Container

Once the container is open, configuration values may be retrieved using the `Container.<Type>ForKey` methods:

```csharp

// Retrieving a configuration value from a Tag Manager Container.
// Get the configuration value by key.
var title = container.StringForKey ("Title");

```

Requests made with a non-existent key will return a default value appropriate to the type requested:

```csharp

// Empty keys will return a default value depending on the type requested.
// Key does not exist. An empty string is returned.
var title = container.StringForKey ("Non-existent-key");

if (title.Equals ("")) { // Evaluates to true.

}

```

## Pushing Values to the DataLayer

The DataLayer is a map that enables runtime information about your app, such as touch events or screen views, to become available to Tag Manager macros and tags in a container.

For example, by pushing information about screen views into the DataLayer map, you can set up tags in the Tag Manager web interface to fire conversion pixels and tracking calls in response to those screenviews without needing to hard code them into your app.

Events are pushed to the DataLayer using the `Manager.DataLayer.Push` or `Manager.DataLayer.PushPushValue` methods:

```csharp
	
...
using Google.TagManager;
...

public override void ViewDidAppear (bool animated)
{
	...
	var dict = new NSDictionary ("event", "openScreen", "screenName", "Home Screen");
	
	// The container should have already been opened, otherwise events pushed to
    // the data layer will not fire tags in that container.
	manager.DataLayer.Push (dict);
	...
}

```

In the web interface, you can now create tags (like Google Analytics tags) to fire for each screen view by creating this rule: {{ event }} equals "openScreen". To pass the screen name to one of these tags, create a data layer macro that references the "screenName" key in the data layer. You can also create a tag (like an AdWords conversion pixel) to fire only for specific screen views, by creating a rule where {{ event }} equals "openScreen" && {{ screenName }} equals "ConfirmationScreen".