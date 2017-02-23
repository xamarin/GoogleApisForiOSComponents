# Integrate Cast v3 into your iOS App

The mobile device or laptop is the sender which controls the playback, and the Google Cast device is the receiver which displays the content on the TV.

The sender framework refers to the Cast framework bundle, which consists of the class library binary and associated header files and resources. The sender app or Cast app refers to an app running on the sender. The receiver app refers to the HTML application running on the receiver.

Google Cast uses the delegation pattern to inform the sender app of events and to move between various states of the Cast app life cycle.

## App flow

The following steps describe the typical high-level execution flow for a sender iOS app:

* The Cast framework automatically starts device discovery based on the view controller lifecycle.
* When the user clicks on the Cast button, the framework presents the Cast dialog with the list of discovered Cast devices.
* When the user selects a Cast device, the framework attempts to launch the receiver app on the Cast device.
* The framework invokes callbacks in the sender app to confirm that the receiver app was launched.
* The framework creates a communication channel between the sender and receiver apps.
* The framework uses the communication channel to load and control media playback on the receiver.
* The framework synchronizes the media playback state between sender and receiver: when the user makes sender UI actions, the framework passes those media control requests to the receiver, and when the receiver sends media status updates, the framework updates the state of the sender UI.
* When the user clicks on the Cast button to disconnect from the Cast device, the framework will disconnect the sender app from the receiver.

## Initialize the Cast Context

The Cast framework has a global singleton object, the `CastContext`, which coordinates all of the framework's activities. This object must be initialized early in the application's lifecycle, typically in the `FinishedLaunching` method of the app delegate, so that automatic session resumption on sender app restart can trigger properly.

A `CastOptions` object must be supplied when initializing the `CastContext`. This class contains options that affect the behavior of the framework. The most important of these is the **Receiver Application ID**, which is used to filter discovery results and to launch the receiver app when a Cast session is started.

The `FinishedLaunching` method is also a good place to set up a **Logging Delegate** to receive the logging messages from the framework. These can be useful for debugging and troubleshooting:

```csharp
using Google.Cast;

...

// You can add your own app id here that you get by registering
// with the Google Cast SDK Developer Console https://cast.google.com/publish
public static readonly string ReceiverApplicationId = "A1B2C3D4";

public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{

	// Contains options that affect the behavior of the framework.
	var options = new CastOptions (ReceiverApplicationId);

	// CastContext coordinates all of the framework's activities.
	CastContext.SetSharedInstance (options);

	// Google Cast Logger
	Logger.SharedInstance.Delegate = this;

	...
	
	return true;
}

#region Logger Delegate

[Export ("logMessage:fromFunction:")]
void LogMessage (string message, string function)
{
	Console.WriteLine ($"{function} {message}");
}

#endregion
```

## The Cast UX Widgets

The Cast framework provides these widgets that comply with the Cast Design Checklist:

* [Introductory Overlay][1]: The `CastContext` class has a method, `PresentCastInstructionsViewControllerOnce`, which can be used to spotlight the **Cast button** the first time a Cast receiver is available. The Sender app can customize the text, position of the title text and the Dismiss button.
* [Cast Button][2]: The cast button is visible when a receiver is discovered that supports your app. When the user first clicks on the cast button, a cast dialog is displayed which lists the discovered devices. When the user clicks on the cast button while the device is connected, it displays the current media metadata (such as title, name of the recording studio and a thumbnail image) or allows the user to disconnect from the cast device.
* [Mini Controller][3]: When the user is casting content and has navigated away from the current content page or expanded controller to another screen in the sender app, the mini controller is displayed at the bottom of the screen to allow the user to see the currently casting media metadata and to control the playback.
* [Expanded Controller][4]: When the user is casting content, if they click on the media notification or mini controller, the expanded controller launches, which displays the currently playing media metadata and provides several buttons to control the media playback.

## Add a Cast Button

The framework provides a Cast button component as a `UIButton` subclass. It can be added to the app's title bar by wrapping it in a `UIBarButtonItem`. A typical `UIViewController` subclass can install a Cast button as follows:

```csharp
// Cast button to allow the user to select a Cast device.
var btnCast = new UICastButton (new CGRect (0, 0, 24, 24)) { TintColor = UIColor.White };
NavigationItem.RightBarButtonItem = new UIBarButtonItem (btnCast);
```

By default, tapping the button will open the Cast dialog that is provided by the framework.

`UICastButton` can also be added directly to the storyboard.

## Configure device discovery

In the framework, device discovery happens automatically. There is no need to explicitly start or stop the discovery process.

Discovery in the framework is managed by the class `DiscoveryManager`, which is a property of the `CastContext`. The framework provides a default Cast dialog component for device selection and control. The device list is ordered lexicographically by device friendly name.

## How Session Management Works

The Cast framework introduces the concept of a Cast session, the establishment of which combines the steps of connecting to a device, launching (or joining) a receiver app, connecting to that app, and initializing a media control channel, if appropriate.

Sessions are managed by the class `SessionManager`, which is a property of the `CastContext`. Individual sessions are represented by subclasses of the class `Session`: for example, `CastSession` represents sessions with Cast devices. You can access the currently active Cast session (if any), as the `CurrentCastSession` property of `SessionManager` class.

The `ISessionManagerListener` interface can be used to monitor session events, such as session creation, suspension, resumption, and termination. The framework automatically suspends sessions when the sender app is going into the background and attempts to resume them when the app returns to the foreground (or is relaunched after an abnormal/abrupt app termination while a session was active).

If the Cast dialog is being used, then sessions are created and torn down automatically in response to user gestures. Otherwise, the app can start and end sessions explicitly via methods on `SessionManager`.

If the app needs to do special processing in response to session lifecycle events, it can register one or more `ISessionManagerListener` instances with the `SessionManager`. `ISessionManagerListener` is an interface which defines callbacks for such events as session start, session end, and so on.

## Automatic Reconnection

The Cast framework adds reconnection logic to automatically handle reconnection in many subtle corner cases, such as:

* Recover from a temporary loss of WiFi
* Recover from device sleep
* Recover from backgrounding the app
* Recover if the app crashed

## How Media Control Works

If a Cast session is established with a receiver app that supports the media namespace, an instance of RemoteMediaClient will be created automatically by the framework; it can be accessed as the `RemoteMediaClient` property of the `CastSession` instance.

All methods on `RemoteMediaClient` which issue requests to the receiver will return a `Request` object which can be used to track that request. A `IRequestDelegate` can be assigned to this object to receive notifications about the eventual result of the operation.

It is expected that the instance of `RemoteMediaClient` may be shared by multiple parts of the app, and indeed some internal components of the framework such as the Cast dialog and mini media controls do share the instance. To that end, `RemoteMediaClient` supports the registration of multiple `IRemoteMediaClientListeners`, unlike `MediaControlChannel`, which only supported a single delegate.

## Set Media Metadata

The `MediaMetadata` class represents information about a media item you want to cast. The following example creates a new `MediaMetadata` instance of a movie and sets the title, subtitle, recording studio's name, and two images:

```csharp
var metadata = new MediaMetadata (MediaMetadataType.Movie);
metadata.SetString (video.Title, MetadataKey.Title);
metadata.SetString (video.Subtitle, MetadataKey.Subtitle);
metadata.SetString (video.Studio, MetadataKey.Studio);
metadata.AddImage (new Image (video.ImageUrl, 480, 720));
metadata.AddImage (new Image (video.PosterUrl, 780, 1200));
```

## Load media

To load a media item, create a `MediaInformation` instance using the media's metadata. Then get the current `CastSession` and use its `RemoteMediaClient` to load the media on the receiver app. You can then use `RemoteMediaClient` for controlling a media player app running on the receiver, such as for play, pause and stop:

```csharp
var mediaInformation = new MediaInformation (videoUrl, 
                                             MediaStreamType.Buffered, 
                                             "video/mp4", 
                                             metadata, 
                                             video.Duration, 
                                             null, 
                                             null, 
                                             null);

var castSession = CastContext.SharedInstance.SessionManager.CurrentCastSession;

// Make sure that we are connected to a Cast device.
if (castSession != null) {
	// Play video on Cast device.
	castSession.RemoteMediaClient.LoadMedia (mediaInformation, true);
}
```

### 4K Video Format

To determine what video format your media is, use the property `VideoInfo` of `MediaStatus` class to get the current instance of `VideoInfo`. This instance contains the type of HDR TV format and the height and width in pixels. Variants of 4K format are indicated in the hdrType property by enum values `VideoInfoHdrType`.

## Add Mini Controllers

According to the [Cast Design Checklist][5], a sender app should provide a persistent control known as the [mini controller][6] that should appear when the user navigates away from the current content page. The mini controller provides instant access and a visible reminder for the current Cast session.

The Cast framework provides a control bar, `UIMiniMediaControlsViewController`, which can be added to the scenes in which you want to show the mini controller.

There are two ways to add the mini controller to a sender app:

* Let the Cast framework manage the layout of the mini controller by wrapping your existing view controller with its own view controller.
* Manage the layout of the mini controller widget yourself by adding it to your existing view controller by providing a subview in the storyboard.

The first way is to use the `UICastContainerViewController` which wraps another view controller and adds a `UIMiniMediaControlsViewController` at the bottom. This approach is limited in that you cannot customize the animation and cannot configure the behavior of the container view controller.

This first way is typically done in the `FinishedLaunching` method of the app delegate:

```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{
	...
	
	var appStoryboard = UIStoryboard.FromName ("Main", null);
	var navigationController = appStoryboard.InstantiateViewController ("MainNavigation") as UINavigationController;
	var castContainer = CastContext.SharedInstance.CreateCastContainerController (navigationController);
	castContainer.MiniMediaControlsItemEnabled = true;
	
	...
}
```

Add this property to control the visibility of the mini controller:

```csharp
public bool CastControlBarsEnabled {
	get {
		var castContainer = Window.RootViewController as UICastContainerViewController;
		return castContainer.MiniMediaControlsItemEnabled;
	}
	set {
		var castContainer = Window.RootViewController as UICastContainerViewController;
		castContainer.MiniMediaControlsItemEnabled = value;
	}
}
```

The second way is to add the mini controller directly to your existing view controller by using `CreateMiniMediaControlsViewController` to create a `UIMiniMediaControlsViewController` instance and then adding it to the container view controller as a subview:

```csharp
using Google.Cast;

UIView MiniMediaControlsContainerView;
bool miniMediaControlsViewEnabled;
NSLayoutConstraint miniMediaControlsHeightConstraint;
UIMiniMediaControlsViewController miniMediaControlsViewController;

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	miniMediaControlsViewController = CastContext.SharedInstance.CreateMiniMediaControlsViewController ();
	miniMediaControlsViewController.ShouldAppear += (sender, e) => {
		UpdateControlBarsVisibility ();
	};
	AddChildViewController (miniMediaControlsViewController);
	
	miniMediaControlsViewController.View.Frame = MiniMediaControlsContainerView.Bounds;
	MiniMediaControlsContainerView.AddSubview (miniMediaControlsViewController.View);
	miniMediaControlsViewController.DidMoveToParentViewController (this);

	UpdateControlBarsVisibility ();
}
```

The `UIMiniMediaControlsViewController.ShouldAppear` event tells the host view controller when the mini controller should be visible:

```csharp
public override void ViewDidLoad ()
{
	...
	
	miniMediaControlsViewController.ShouldAppear += (sender, e) => {
		UpdateControlBarsVisibility ();
	};
	
	...
}

void UpdateControlBarsVisibility ()
{
	if (miniMediaControlsViewEnabled &&
	    miniMediaControlsViewController.Active) {
		miniMediaControlsHeightConstraint.Constant = miniMediaControlsViewController.MinHeight;
	} else {
		miniMediaControlsHeightConstraint.Constant = 0;
	}

	UIView.Animate (0.5, () => { View.LayoutIfNeeded () });
}

```

When your sender app is playing a video or audio live stream, the SDK automatically displays a play/stop button in place of the play/pause button in the mini controller.

See **Style the Widgets** section below for how your sender app can configure the appearance of the widgets across your app.

## Add Expanded Controller

The Google Cast Design Checklist requires a sender app to provide an expanded controller for the media being cast. The expanded controller is a full screen version of the mini controller.

The expanded controller is a full screen view which offers full control of the remote media playback. This view should allow a casting app to manage every manageable aspect of a cast session, with the exception of receiver volume control and session lifecycle (connect/stop casting). It also provides all the status information about the media session (artwork, title, subtitle, and so forth).

The functionality of this view is implemented by the `UIExpandedMediaControlsViewController` class.

The first thing you have to do is enable the default expanded controller in the cast context. Modify `FinishedLaunching` to enable the default expanded controller:

```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{
	...

	// Use Default Expanded Media Controls
	CastContext.SharedInstance.UseDefaultExpandedMediaControls = true;
	
	...
}
```

Add the following code in your controller to load the expanded controller when the user starts to cast a video:

```csharp
// Reproduces the video on Cast device.
void PlayVideoRemotely (MediaInformation mediaInformation)
{
	...
	
	NavigationItem.BackBarButtonItem = new UIBarButtonItem ("", UIBarButtonItemStyle.Plain, null, null);
	(UIApplication.SharedApplication.Delegate as AppDelegate).CastControlBarsEnabled = false;
	CastContext.SharedInstance.PresentDefaultExpandedMediaControls ();
	
	...
}
```

The expanded controller will also be launched automatically when the user taps the mini controller.

When your sender app is playing a video or audio live stream, the SDK automatically displays a play/stop button in place of the play/pause button in the expanded controller.

See **Style the Widgets** section below for how your sender app can configure the appearance of the widgets across your app.

## Handle Errors

It is very important for sender apps to handle all error callbacks and decide the best response for each stage of the Cast life cycle. The app can display error dialogs to the user or it can decide to end the Cast session.

## Logging

`Logger` class is a singleton used for logging by the framework. Use the `ILoggerDelegate` to customize how you handle log messages:

```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{
	...
	
	// Google Cast Logger
	Logger.SharedInstance.Delegate = this;
	
	...
}

#region Logger Delegate

[Export ("logMessage:fromFunction:")]
void LogMessage (string message, string function)
{
	Console.WriteLine ($"{function} {message}");
}

#endregion
```

> ***Note:*** *Don't forget to implement the `ILoggerDelegate` interface to your class.*

# Add Advanced Cast v3 Features to your iOS App

## Style the Widgets

You can customize [Cast widgets][7] by setting the colors, styling the buttons, text and thumbnail appearance, and by choosing the types of buttons to display

### Customize the Widgets

The Cast framework widgets supports the [Apple UIAppearance Protocol in UIKit][8] to change the appearance of the widgets across your app, such as the position or border of a button. Use this protocol to style the Cast framework widgets to match an existing apps styling.

### Choose Controller Buttons

Both the expanded controller class (`UIExpandedMediaControlsViewController`) and the mini controller class (`UIMiniMediaControlsViewController`) contain a button bar, and clients can configure which buttons are presented on those bars. This is achieved by both classes conforming to `IUIMediaButtonBarProtocol` interface.

The mini controller bar has 3 configurable slots for buttons:

```
SLOT  SLOT  SLOT
 1     2     3
```

The expanded controller bar has a permanent play/pause toggle button in the middle of the bar plus 4 configurable slots:

```
SLOT  SLOT  PLAY/PAUSE  SLOT  SLOT
 1     2      BUTTON     3     4
```

Your app can get a reference to the expanded controller with the `CastContext.DefaultExpandedMediaControlsViewController` property and can get a reference to the mini controller if using `CastContext.CreateMiniMediaControlsViewController` method.

Each slot can contain either a framework button, a custom button, or be empty. The list of framework control buttons are defined as:

| UIMediaButtonType    | Description                                                                                                                                                            |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **None**             | No button, results in empty space at a button position.                                                                                                                |
| **PlayPauseToggle**  | A default button that toggles between play and pause states.                                                                                                           |
| **SkipNext**         | A default "next" button. When tapped, playback moves to the next media item in the queue. It becomes disabled if there is no next media item in the queue.             |
| **SkipPrevious**     | A default "previous" button. When tapped, playback moves to the previous media item in the queue. It becomes disabled if there is no previous media item in the queue. |
| **Rewind30Seconds**  | A default "rewind 30 seconds" button. When tapped, playback skips 30 seconds back in the currently playing media item.                                                 |
| **Forward30Seconds** | A default "forward 30 seconds" button. When tapped, playback skips 30 seconds forward in the currently playing media item.                                             |
| **MuteToggle**       | A default "mute toggle" button. When tapped, the receiver's mute state is toggled.                                                                                     |
| **ClosedCaptions**   | A default "closed captions" button. When the button is tapped, the media tracks selection UI is displayed to the user.                                                 |
| **Stop**             | A default "stop" button. When the button is tapped, playback of the current media item is terminated on the receiver.                                                  |
| **Custom**           | A button created and managed by the client.                                                                                                                            |

Add a button as follows:

* To add a framework button to a bar requires only a call to `IUIMediaButtonBarProtocol.SetButtonType` method.
* To add a custom button to a bar, your app must call `IUIMediaButtonBarProtocol.SetButtonType` with buttonType parameter set to `UIMediaButtonType.Custom`, and then call `IUIMediaButtonBarProtocol.SetCustomButton` passing the `UIButton` with the same index.

## How Volume Control Works

The Cast framework automatically manages the volume for the sender app. The framework automatically synchronizes with the receiver volume for the supplied UI widgets. To sync a slider provided by the app, use `UIDeviceVolumeController`.

## Using Media Tracks

A media track can be an audio or video stream object, or a text object (subtitle or caption).

> ***Note:*** *Currently, the Styled and Default Media Receivers allow you to use only the text tracks with the API. To work with the audio and video tracks, you must develop a Custom Receiver.*

A `MediaTrack` object represents a track. It consists of a unique numeric identifier and other attributes such as a content ID and title. A `MediaTrack` instance can be created as follows:

```csharp
var track = new MediaTrack (1,
                            "https://some-url/caption_en.vtt",
                            "text/vtt",
                            MediaTrackType.Text,
                            MediaTextTrackSubtype.Captions,
                            "English Captions",
                            "en",
                            null);
```

A media item can have multiple tracks; for example, it can have multiple subtitles (each for a different language) or multiple alternative audio streams (for different languages). `MediaInformation` is the class that represents a media item. To associate a collection of `MediaTrack` objects with a media item, your app should update its `MediaTracks` property. Your app needs to make his association before it loads the media to the receiver, as in the following code:

```csharp
MediaTrack [] tracks = { track };

var mediaInformation = new MediaInformation ("https://some-url/", 
                                             MediaStreamType.None,
                                             "video/mp4",
                                             metadata,
                                             0,
                                             tracks,
                                             null,
                                             null);
```

Activate one or more tracks that were associated with the media item (after the media is loaded) by calling `RemoteMediaClient.SetActiveTrackIDs` method and passing the IDs of the tracks to be activated. For example, the following code activates the captions track created above:

```csharp
remoteMediaClient.SetActiveTrackIDs (new nuint [] { 1 });
```

To deactivate a track on the current media item, call `RemoteMediaClient.SetActiveTrackIDs` method with an empty array or `null`. The following code disables the captions track:

```csharp
remoteMediaClient.SetActiveTrackIDs (new nuint [] { });
// or
remoteMediaClient.SetActiveTrackIDs (null);
```

### Styling Text Tracks

The `MediaTextTrackStyle` class encapsulates the style information of a text track. A track style can be applied to the currently playing media item by calling `RemoteMediaClient.SetTextTrackStyle` method. The track style created in the code below turns text red (FF) at 50% opacity (80) and sets a serif font:

```csharp
var textTrackStyle = MediaTextTrackStyle.CreateDefault ();
textTrackStyle.ForegroundColor = new Color ("#FF000080");
textTrackStyle.FontFamily = "serif";
styleChangeRequest = remoteMediaClient.SetTextTrackStyle (textTrackStyle);
```

You can use the returned GCKRequest object for tracking this request.

```csharp
styleChangeRequest.Completed += (sender, e) => {
	var request = sender as Request;

	if (request == styleChangeRequest) {
		Console.WriteLine ("Style update completed.");
		styleChangeRequest = null;
	}
};
```

See **Status updates** section below for more information. Apps should allow users to update the style for text tracks, either using the settings provided by the system or by the app itself. There is a default style provided (in iOS 7 and later), which can be retrieved via the static method `MediaTextTrackStyle.CreateDefault`. The following text track style elements can be changed:

* Foreground (text) color and opacity
* Background color and opacity
* Edge type
* Edge Color
* Font Scale
* Font Family
* Font Style

### Receive Status Updates

When multiple senders are connected to the same receiver, it is important for each sender to be aware of the changes on the receiver even if those changes were initiated from other senders.

> ***Note:*** *this is important for all apps, not only those that explicitly support multiple senders, because some Cast devices have control inputs (remotes, buttons) that behave as virtual senders, affecting the status on the receiver.*

To this end, your app should register a `IRemoteMediaClientListener`. If the `MediaTextTrackStyle` of the current media changes, then all of the connected senders will be notified through both the `MediaControlChannelDelegate.DidUpdateMetadata` interface method or `MediaControlChannel.StatusUpdated` event and the `MediaControlChannelDelegate.DidUpdateStatus` interface method or `MediaControlChannel.MetadataUpdated` event. In this case, the receiver classes do not verify whether the new style is different from the previous one and notifies all the connected senders regardless. If, however, the list of active tracks is updated, only the `MediaControlChannelDelegate.DidUpdateStatus` interface method or `MediaControlChannel.MetadataUpdated` event in connected senders will be notified.

> ***Note:*** *The list of tracks associated with the currently loaded media cannot be changed. If needed, you have to update the tracks information on the MediaInformation object and reload the media.*

### Satisfy CORS Requirements

For adaptive media streaming, Google Cast requires the presence of CORS headers, but even simple mp4 media streams require CORS if they include Tracks. If you want to enable Tracks for any media, you must enable CORS for both your track streams and your media streams. So, if you do not have CORS headers available for your simple mp4 media on your server, and you then add a simple subtitle track, you will not be able to stream your media unless you update your server to include the appropriate CORS header. In addition, you need to allow at least the following headers: **Content-Type**, **Accept-Encoding**, and **Range**. Note that the last two headers are additional headers that you may not have needed previously.

## Add a Custom Channel

Cast v3.x retains the `CastChannel` and `GenericChannel` classes of Cast v2.x. The former class is meant to be subclassed to implement non-trivial channels that have associated state. The latter class is provided as an alternative to subclassing; it passes its received messages to a delegate so that they can be processed elsewhere.

In Cast v2.x, custom channels were enabled/disabled by registering/unregistering them with the `DeviceManager`. That class is deprecated in Cast SDK v3.x; channels must now be registered/unregistered with the `CastSession` instead, using its `AddChannel` and `RemoveChannel` methods.

The Cast framework provides two ways to create a channel to send custom messages to a receiver:

1. `CastChannel` class is meant to be subclassed to implement non-trivial channels that have associated state.
2. `GenericChannel` is provided as an alternative to subclassing; it passes its received messages to a delegate so that they can be processed elsewhere.

Channels must be registered/unregistered with the `CastSession` class, using its `AddChannel` and `RemoveChannel` methods.

Here is an example of a GCKCastChannel implementation:

```csharp
public class MyTextChannel : CastChannel
{
	public MyTextChannel (string protocolNamespace) : base (protocolNamespace)
	{
	}

	public override void DidReceiveTextMessage (string message)
	{
		Console.WriteLine ($"Received message: {message}");
	}
}
```

A channel can be registered at any time; if the session is not currently in a connected state, the channel will automatically become connected when the session itself is connected, provided that the channel's namespace is present in the receiver app metadata's list of supported namespaces.

Each custom channel is defined by a unique namespace and must start with the prefix `urn:x-cast:`, for example, `urn:x-cast:com.example.custom`. It is possible to have multiple custom channels, each with a unique namespace. The receiver app can also send and receive messages using the same namespace:

```csharp
var myTextChannel = new MyTextChannel ("urn:x-cast:com.google.cast.sample.helloworld");
castSession.AddChannel (myTextChannel);
myTextChannel.SendTextMessage ("Hello World!");
```

To provide logic that needs to execute when a particular channel becomes connected or disconnected, override the `DidConnect` and `DidDisconnect` methods if using `CastChannel`, or provide implementations for the `DidConnect` and `DidDisconnect` methods of the `IGenericChannelDelegate` interface or `Connected` and `Disconnected` events if using `GenericChannel`.

## Use Queueing

The Cast framework provides queueing APIs that support the creation of lists of content items, such as video or audio streams, to play sequentially on the Cast receiver. The queue of content items may be edited, reordered, updated, and so forth.

Review the [Google Cast Autoplay UX Guidelines][9] for best practices when designing an autoplay/queueing experience for Cast.

The Cast receiver classes maintain the queue and responds to operations on the queue as long as the queue has at least one item currently active (playing or paused). Senders can join the session and add items to the queue. The receiver maintains a session for queue items until the last item completes playback or the sender stops the playback and terminates the session, or until a sender loads a new queue on the receiver. By default, the receiver does not maintain any information about terminated queues. Once the last item in the queue finishes, the media session ends and the queue vanishes.

> ***Note:*** *The [styled media receiver][10] and [default media receiver][11] do not support a queue of images; only a queue of audio or video streams is supported in the styled and default receivers.*

### Create and Load Media Queue Items

In iOS, a media queue item is represented in the Cast framework as a `MediaQueueItem` instance. When you create a media queue item, if you are using the Media Player Library with adaptive content, you can set the preload time so that the player can begin buffering the media queue item before the item ahead of it in the queue finishes playing. Setting the item's autoplay attribute to true allows the receiver to play it automatically. For example, you can use a builder pattern to create your media queue item as follows:

```csharp
var builder = new MediaQueueItemBuilder {
	MediaInformation = mediaInformation,
	Autoplay = true,
	PreloadTime = NSUserDefaults.StandardUserDefaults.DoubleForKey (prefPreloadTimeKey)
};
MediaQueueItem newItem = builder.Build ();
```

Load an array of media queue items in the queue by using the appropriate `QueueLoadItems` method of the `RemoteMediaClient` class.

### Receive Media Queue Status Update

When the receiver loads a media queue item, it assigns a unique ID to the item which persists for the duration of the session (and the life of the queue). You can learn the status of the queue indicating which item is currently loaded (it might not be playing), loading, or preloaded. You can also get an ordered list of all the items in the queue. The `MediaStatus` class provides this status information:

* PreloadedItemID property - The ID of the item that is currently preloaded, if any.
* LoadingItemID property - The ID of the item that is currently loading,
* CurrentItemID property - The ID of the current queue item, if any.
* QueueItemCount property - Returns the number of items in the playback queue.
* QueueItemAt method - Returns the item at the specified index in the playback queue.

Use these members together with the other media status members to inform your app about the status of the queue and the items in the queue. In addition to media status updates from the receiver, you can listen for changes to the queue by implementing `IRemoteMediaClientListener.DidUpdateQueue` interface method.

> ***Note:*** *To provide the best user experience, the sender app must show the next autoplay item in the queue in the sender UI.*

### Edit the Queue

To work with the items in the queue, use the queue methods of `RemoteMediaClient`, you have several APIs. These let you load an array of items into a new queue, insert items into an existing queue, update the properties of items in the queue, make an item jump forward or backward in the queue, set the properties of the queue itself (for example, change the RepeatMode that selects the next item), remove items from the queue, and reorder the items in the queue.

## Supporting Autoplay

See [Autoplay & Queueing APIs][12].

## Override Image Selection and Caching

Various components of the framework (namely the Cast dialog, the mini controller, the expanded controller, and the `UIMediaController` if so configured) will display artwork for the currently casting media. The URLs to the image artwork are typically included in the `MediaMetadata` for the media, but the sender app may have an alternate source for the URLs. The `IUIImagePicker` interface defines a means for selecting an appropriate image for a given usage and desired size. It has a single method, `GetImage`, which takes a `UIImageHints` object and a `MediaMetadata` object as parameters, and returns a `Image` object as a result. The framework provides a default implementation of `IUIImagePicker` which always selects the first image in the list of images in the `MediaMetadata` object, but the app can provide an alternate implementation by setting the ImagePicker property of the `CastContext` singleton.

The `IUIImageCache` interface defines a means of caching images that are downloaded by the framework via HTTPS. The framework provides a default implementation of `UIImageCache` which stores downloaded image files in the app's cache directory, but the app can provide an alternate implementation by setting the ImageCache property of the CastContext singleton.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://developers.google.com/cast/docs/ios_sender_integrate) to see original Google documentation._</sub>

[1]: https://developers.google.com/cast/docs/design_checklist/cast-button#prompting
[2]: https://developers.google.com/cast/docs/design_checklist/cast-button#sender-cast-icon-available
[3]: https://developers.google.com/cast/docs/design_checklist/sender#sender-mini-controller
[4]: https://developers.google.com/cast/docs/design_checklist/sender#sender-control-elements
[5]: https://developers.google.com/cast/docs/design_checklist/sender#sender-mini-controller
[6]: https://developers.google.com/cast/docs/design_checklist/sender#mini-controller
[7]: https://developers.google.com/cast/docs/android_sender_integrate#the_cast_ux_widgets
[8]: https://developer.apple.com/reference/uikit/uiappearance
[9]: https://developers.google.com/cast/downloads/GoogleCastAutoplayUXGuidelines.pdf
[10]: https://developers.google.com/cast/docs/styled_receiver
[11]: https://developers.google.com/cast/docs/receiver_apps#default
[12]: https://developers.google.com/cast/docs/autoplay
