using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

namespace Google.Cast
{
	[DisableDefaultCtor]
	[Protocol]
	[BaseType (typeof (NSObject))]
	interface Constants
	{

		[Static, Field ("kGCKFrameworkVersion", "__Internal")]
		NSString FrameworkVersion { get; }
	}

	[BaseType (typeof (NSObject), Name = "GCKApplicationMetadata")]
	interface ApplicationMetadata : INSCopying
	{

		[Export ("applicationID", ArgumentSemantic.Copy)]
		string ApplicationId { get; }

		[Export ("applicationName", ArgumentSemantic.Copy)]
		string ApplicationName { get; }

		[Export ("images", ArgumentSemantic.Copy)]
		Image [] Images { get; }

		[Export ("namespaces", ArgumentSemantic.Copy)]
		string [] Namespaces { get; }

		[Export ("senderApplicationInfo", ArgumentSemantic.Copy)]
		SenderApplicationInfo SenderApplicationInfo { get; }

		[Export ("senderAppIdentifier")]
		string SenderAppIdentifier { get; }

		[Export ("senderAppLaunchURL")]
		NSUrl SenderAppLaunchUrl { get; }
	}

	[BaseType (typeof (NSObject), Name = "GCKCastChannel")]
	interface CastChannel
	{

		[Field ("kGCKInvalidRequestID", "__Internal")]
		nint InvalidRequestID { get; }

		[Export ("protocolNamespace", ArgumentSemantic.Copy)]
		string ProtocolNamespace { get; }

		[Export ("deviceManager", ArgumentSemantic.Weak)]
		DeviceManager DeviceManager { get; }

		[Export ("isConnected", ArgumentSemantic.Assign)]
		bool IsConnected { get; }

		[Export ("initWithNamespace:")]
		IntPtr Constructor (string protocolNamespace);

		[Export ("didReceiveTextMessage:")]
		void DidReceiveTextMessage (string message);

		[Export ("sendTextMessage:")]
		bool SendTextMessage (string message);

		// - (BOOL)sendTextMessage:(NSString *)message error:(GCKError **)error;
		[Export ("sendTextMessage:error:")]
		bool SendTextMessage (string message, out Error error);

		[Export ("generateRequestID")]
		int GenerateRequestId ();

		[Export ("generateRequestNumber")]
		NSNumber GenerateRequestNumber ();

		[Export ("didConnect")]
		void DidConnect ();

		[Export ("didDisconnect")]
		void DidDisconnect ();
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKCastContext")]
	interface CastContext
	{

		[Static]
		[Export ("sharedInstance")]
		CastContext SharedInstance { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKColor")]
	interface Color : INSCopying, INSCoding
	{

		[Export ("red")]
		nfloat Red { get; }

		[Export ("green")]
		nfloat Green { get; }

		[Export ("blue")]
		nfloat Blue { get; }

		[Export ("alpha")]
		nfloat Alpha { get; }

		[Export ("initWithRed:green:blue:alpha:")]
		IntPtr Constructor (nfloat red, nfloat green, nfloat blue, nfloat alpha);

		[Export ("initWithRed:green:blue:")]
		IntPtr Constructor (nfloat red, nfloat green, nfloat blue);

		[Export ("initWithUIColor:")]
		IntPtr Constructor (UIColor color);

		[Export ("initWithCGColor:")]
		IntPtr Constructor (CGColor color);

		[Export ("initWithCSSString:")]
		IntPtr Constructor (string cssString);

		[Export ("CSSString")]
		string CSSString { get; }

		[Static]
		[Export ("black")]
		Color GetBlack ();

		[Static]
		[Export ("red")]
		Color GetRed ();

		[Static]
		[Export ("green")]
		Color GetGreen ();

		[Static]
		[Export ("blue")]
		Color GetBlue ();

		[Static]
		[Export ("cyan")]
		Color GetCyan ();

		[Static]
		[Export ("magenta")]
		Color GetMagenta ();

		[Static]
		[Export ("yellow")]
		Color GetYellow ();

		[Static]
		[Export ("white")]
		Color GetWhite ();
	}

	[BaseType (typeof (NSObject), Name = "GCKDevice")]
	interface Device : INSCopying, INSCoding
	{

		[Obsolete ("Use GCKDeviceCapability.VideoOut instead.")]
		[Field ("kGCKDeviceCapabilityVideoOut", "__Internal")]
		nint CapabilityVideoOut { get; }

		[Obsolete ("Use GCKDeviceCapability.VideoIn instead.")]
		[Field ("kGCKDeviceCapabilityVideoIn", "__Internal")]
		nint CapabilityVideoIn { get; }

		[Obsolete ("Use GCKDeviceCapability.AudioOut instead.")]
		[Field ("kGCKDeviceCapabilityAudioOut", "__Internal")]
		nint CapabilityAudioOut { get; }

		[Obsolete ("Use GCKDeviceCapability.AudioIn instead.")]
		[Field ("kGCKDeviceCapabilityAudioIn", "__Internal")]
		nint CapabilityAudioIn { get; }

		[Export ("ipAddress", ArgumentSemantic.Copy)]
		string IpAddress { get; }

		[Export ("servicePort", ArgumentSemantic.Assign)]
		nuint ServicePort { get; }

		[Export ("deviceID", ArgumentSemantic.Copy)]
		string DeviceId { get; set; }

		[Export ("friendlyName", ArgumentSemantic.Copy)]
		string FriendlyName { get; set; }

		[Export ("manufacturer", ArgumentSemantic.Copy)]
		string Manufacturer { get; set; }

		[Export ("modelName", ArgumentSemantic.Copy)]
		string ModelName { get; set; }

		[Export ("icons", ArgumentSemantic.Copy)]
		Image [] Icons { get; set; }

		[Export ("status")]
		DeviceStatus Status { get; }

		[Export ("statusText", ArgumentSemantic.Copy)]
		string StatusText { get; set; }

		[Export ("deviceVersion", ArgumentSemantic.Copy)]
		string DeviceVersion { get; set; }

		[Export ("isOnLocalNetwork")]
		bool IsOnLocalNetwork { get; }

		[Export ("initWithIPAddress:servicePort:")]
		IntPtr Constructor (string ipAddress, uint servicePort);

		[Export ("isSameDeviceAs:")]
		bool SameDevice (Device device);

		[Export ("hasCapabilities:")]
		bool HasCapabilities (nint deviceCapabilities);

		[Export ("setAttribute:forKey:")]
		void SetAttribute (INSCoding attribute, string key);

		[Export ("attributeForKey:")]
		INSCoding GetAttribute (string key);

		[Export ("removeAttributeForKey:")]
		void RemoveAttribute (string key);

		// - (void)removeAllAttributes;
		[Export ("removeAllAttributes")]
		void RemoveAllAttributes ();
	}


	[BaseType (typeof (NSObject),
		Name = "GCKDeviceManager",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (DeviceManagerDelegate) })]
	interface DeviceManager
	{

		[Export ("connectionState")]
		ConnectionState ConnectionState { get; }

		[Export ("applicationConnectionState")]
		ConnectionState ApplicationConnectionState { get; }

		[Obsolete ("Use ConnectionState property instead")]
		[Export ("isConnected", ArgumentSemantic.Assign)]
		bool IsConnected { get; }

		[Obsolete ("Use ApplicationConnectionState property instead")]
		[Export ("isConnectedToApp", ArgumentSemantic.Assign)]
		bool IsConnectedToApp { get; }

		[Export ("isReconnecting", ArgumentSemantic.Assign)]
		bool IsReconnecting { get; }

		[Export ("reconnectTimeout", ArgumentSemantic.Assign)]
		double ReconnectTimeout { get; set; }

		[Export ("device")]
		Device Device { get; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		IDeviceManagerDelegate Delegate { get; set; }

		[Export ("deviceVolume", ArgumentSemantic.Assign)]
		float DeviceVolume { get; }

		[Export ("deviceMuted", ArgumentSemantic.Assign)]
		bool DeviceMuted { get; }

		[Export ("activeInputStatus", ArgumentSemantic.Assign)]
		ActiveInputStatus ActiveInputStatus { get; }

		[Export ("standbyStatus", ArgumentSemantic.Assign)]
		StandbyStatus StandbyStatus { get; }

		[Export ("applicationSessionID", ArgumentSemantic.Copy)]
		string ApplicationSessionID { get; }

		[Export ("applicationMetadata", ArgumentSemantic.Copy)]
		ApplicationMetadata ApplicationMetadata { get; }

		[Export ("applicationStatusText", ArgumentSemantic.Copy)]
		string ApplicationStatusText { get; }

		[Export ("initWithDevice:clientPackageName:")]
		IntPtr Constructor (Device device, string clientPackageName);

		[Export ("initWithDevice:clientPackageName:ignoreAppStateNotifications:")]
		IntPtr Constructor (Device device, string clientPackageName, bool ignoreAppStateNotifications);

		[Export ("connect")]
		void Connect ();

		[Export ("disconnect")]
		void Disconnect ();

		[Export ("disconnectWithLeave:")]
		void Disconnect (bool leaveApp);

		[Export ("addChannel:")]
		bool AddChannel (CastChannel channel);

		[Export ("removeChannel:")]
		bool RemoveChannel (CastChannel channel);

		[Export ("launchApplication:")]
		nint LaunchApplication (string applicationId);

		[Export ("launchApplication:withLaunchOptions:")]
		nint LaunchApplication (string applicationId, LaunchOptions launchOptions);

		[Obsolete ("Use LaunchApplication (string, LaunchingOptions) method instead.")]
		[Export ("launchApplication:relaunchIfRunning:")]
		nint LaunchApplication (string applicationId, bool relaunchIfRunning);

		[Export ("joinApplication:")]
		nint JoinApplication (string applicationId);

		[Export ("joinApplication:sessionID:")]
		nint JoinApplication (string applicationId, string sessionId);

		[Export ("leaveApplication")]
		bool LeaveApplication ();

		[Export ("stopApplication")]
		nint StopApplication ();

		[Export ("stopApplicationWithSessionID:")]
		nint StopApplication (string sessionId);

		[Export ("setVolume:")]
		nint SetVolume (float volume);

		[Export ("setMuted:")]
		nint SetMuted (bool muted);

		[Export ("requestDeviceStatus")]
		nint RequestDeviceStatus ();
	}

	interface IDeviceManagerDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject), Name = "GCKDeviceManagerDelegate")]
	interface DeviceManagerDelegate
	{

		[EventArgs ("DeviceManagerConnected")]
		[EventName ("Connected")]
		[Export ("deviceManagerDidConnect:")]
		void DidConnect (DeviceManager deviceManager);

		[EventArgs ("DeviceManagerConnectionFailed")]
		[EventName ("ConnectionFailed")]
		[Export ("deviceManager:didFailToConnectWithError:")]
		void DidFailToConnect (DeviceManager deviceManager, NSError error);

		[EventArgs ("DeviceManagerDisconnected")]
		[EventName ("Disconnected")]
		[Export ("deviceManager:didDisconnectWithError:")]
		void DidDisconnect (DeviceManager deviceManager, NSError error);

		[EventArgs ("DeviceManagerConnectionSuspended")]
		[EventName ("ConnectionSuspended")]
		[Export ("deviceManager:didSuspendConnectionWithReason:")]
		void DidSuspendConnection (DeviceManager deviceManager, ConnectionSuspendReason reason);

		[EventArgs ("DeviceManagerRejoined")]
		[EventName ("Rejoined")]
		[Export ("deviceManager:rejoinedApplication:")]
		void RejoinedApplication (DeviceManager deviceManager, bool rejoined);

		[EventArgs ("DeviceManagerConnectToCastApplication")]
		[EventName ("ConnectedToCastApplication")]
		[Export ("deviceManager:didConnectToCastApplication:sessionID:launchedApplication:")]
		void DidConnectToCastApplication (DeviceManager deviceManager, ApplicationMetadata applicationMetadata, string sessionId, bool launchedApplication);

		[EventArgs ("DeviceManagerConnectionToApplicationFailed")]
		[EventName ("ConnectionToApplicationFailed")]
		[Export ("deviceManager:didFailToConnectToApplicationWithError:")]
		void DidFailToConnectToApplication (DeviceManager deviceManager, NSError error);

		[EventArgs ("DeviceManagerDisconnectedFromApplication")]
		[EventName ("DisconnectedFromApplication")]
		[Export ("deviceManager:didDisconnectFromApplicationWithError:")]
		void DidDisconnectFromApplication (DeviceManager deviceManager, NSError error);

		[EventArgs ("DeviceManagerApplicationStopped")]
		[EventName ("ApplicationStopped")]
		[Export ("deviceManagerDidStopApplication:")]
		void DidStopApplication (DeviceManager deviceManager);

		[EventArgs ("DeviceManagerStopApplicationFailed")]
		[EventName ("StopApplicationFailed")]
		[Export ("deviceManager:didFailToStopApplicationWithError:")]
		void DidFailToStopApplication (DeviceManager deviceManager, NSError error);

		[EventArgs ("DeviceManagerApplicationMetadataReceived")]
		[EventName ("ApplicationMetadataReceived")]
		[Export ("deviceManager:didReceiveApplicationMetadata:")]
		void DidReceiveApplicationMetadata (DeviceManager deviceManager, ApplicationMetadata metadata);

		[EventArgs ("DeviceManagerApplicationStatusTextReceived")]
		[EventName ("ApplicationStatusTextReceived")]
		[Export ("deviceManager:didReceiveApplicationStatusText:")]
		void DidReceiveApplicationStatusText (DeviceManager deviceManager, string status);

		[EventArgs ("DeviceManagerVolumeChanged")]
		[EventName ("VolumeChanged")]
		[Export ("deviceManager:volumeDidChangeToLevel:isMuted:")]
		void VolumeDidChange (DeviceManager deviceManager, float volumeLevel, bool isMuted);

		[EventArgs ("DeviceManagerActiveInputStatusReceived")]
		[EventName ("ActiveInputStatusReceived")]
		[Export ("deviceManager:didReceiveActiveInputStatus:")]
		void DidReceiveActiveInputStatus (DeviceManager deviceManager, ActiveInputStatus status);

		[EventArgs ("DeviceManagerStandbyStatusReceived")]
		[EventName ("StandbyStatusReceived")]
		[Export ("deviceManager:didReceiveStandbyStatus:")]
		void DidReceiveStandbyStatus (DeviceManager deviceManager, StandbyStatus status);

		[EventArgs ("DeviceManagerRequestFailed")]
		[EventName ("RequestFailed")]
		[Export ("deviceManager:request:didFailWithError:")]
		void DidFailRequest (DeviceManager deviceManager, nint requestId, NSError error);

		[EventArgs ("DeviceManagerPaired")]
		[EventName ("Paired")]
		[Export ("deviceManagerDidPair:withGuestModeDevice:")]
		void DidPair (DeviceManager deviceManager, Device guestModeDevice);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKDeviceScanner")]
	interface DeviceScanner
	{

		[Obsolete]
		[Export ("init")]
		IntPtr Constructor ();

		//- (instancetype)initWithFilterCriteria:(GCKFilterCriteria *)filterCriteria;
		[Export ("initWithFilterCriteria:")]
		IntPtr Constructor (FilterCriteria filterCriteria);

		[Export ("devices", ArgumentSemantic.Copy)]
		Device [] Devices { get; }

		[Export ("hasDiscoveredDevices", ArgumentSemantic.Assign)]
		bool HasDiscoveredDevices { get; }

		[Export ("scanning", ArgumentSemantic.Assign)]
		bool Scanning { get; }

		[Export ("filterCriteria", ArgumentSemantic.Copy)]
		FilterCriteria FilterCriteria { get; set; }

		[Export ("passiveScan", ArgumentSemantic.Assign)]
		bool PassiveScan { get; set; }

		[Export ("startScan")]
		void StartScan ();

		[Export ("stopScan")]
		void StopScan ();

		[Export ("addListener:")]
		void AddListener (IDeviceScannerListener listener);

		[Export ("removeListener:")]
		void RemoveListener (IDeviceScannerListener listener);
	}

	interface IDeviceScannerListener
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject), Name = "GCKDeviceScannerListener")]
	interface DeviceScannerListener
	{

		[Export ("deviceDidComeOnline:")]
		void DeviceDidComeOnline (Device device);

		[Export ("deviceDidGoOffline:")]
		void DeviceDidGoOffline (Device device);

		[Export ("deviceDidChange:")]
		void DeviceDidChange (Device device);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSError), Name = "GCKError")]
	interface Error
	{

		[Field ("kGCKErrorCustomDataKey", "__Internal")]
		NSString CustomDataKey { get; }

		[Field ("kGCKErrorDomain", "__Internal")]
		NSString Domain { get; }

		[Static]
		[Export ("enumDescriptionForCode:")]
		string EnumDescriptionForCode (ErrorCode code);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKFilterCriteria")]
	interface FilterCriteria : INSCopying, INSCoding
	{

		[Static]
		[Export ("criteriaForAvailableApplicationWithID:")]
		FilterCriteria FromAvailableApplication ([NullAllowed] string applicationId);

		[Obsolete ("Use FromRunningApplication (string []) method")]
		[Static]
		[Export ("criteriaForRunningApplicationWithID:supportedNamespaces:")]
		FilterCriteria FromRunningApplication ([NullAllowed] string applicationId, [NullAllowed] string [] supportedNamespaces);

		[Static]
		[Export ("criteriaForRunningApplicationWithSupportedNamespaces:")]
		FilterCriteria FromRunningApplication ([NullAllowed] string [] supportedNamespaces);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKFrameworkResources")]
	interface FrameworkResources
	{
		[Static]
		[Export ("sharedInstance")]
		FrameworkResources SharedInstance { get; }

		[Export ("bundle")]
		NSBundle Bundle { get; }

		[Export ("imageNamed:")]
		UIImage GetImage (string name);

		[Export ("imageNamed:withRenderingMode:")]
		UIImage GetImage (string name, UIImageRenderingMode renderingMode);

		[Export ("storyboardNamed:")]
		UIStoryboard GetStoryboard (string name);

		[Export ("nibNamed:owner:replacementObjects:")]
		UIStoryboard GetNib (string name, NSObject owner, [NullAllowed] NSDictionary objects);
	}

	[BaseType (typeof (CastChannel),
		Name = "GCKGenericChannel",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (GenericChannelDelegate) })]
	interface GenericChannel
	{

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IGenericChannelDelegate Delegate { get; set; }

		[Export ("initWithNamespace:")]
		IntPtr Constructor (string protocolNamespace);
	}

	interface IGenericChannelDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKGenericChannelDelegate")]
	interface GenericChannelDelegate
	{

		[Abstract]
		[EventArgs ("GenericChannelTextMessageReceived")]
		[EventName ("TextMessageReceived")]
		[Export ("castChannel:didReceiveTextMessage:withNamespace:")]
		void DidReceiveTextMessage (GenericChannel channel, string message, string protocolNamespace);

		[EventArgs ("GenericChannelDelegateConnected")]
		[EventName ("Connected")]
		[Export ("castChannelDidConnect:")]
		void DidConnect (GenericChannel channel);

		[EventArgs ("GenericChannelDelegateDisconnected")]
		[EventName ("Disconnected")]
		[Export ("castChannelDidDisconnect:")]
		void DidDisconnect (GenericChannel channel);
	}

	[BaseType (typeof (NSObject), Name = "GCKImage")]
	interface Image : INSCopying, INSCoding
	{

		[Export ("URL", ArgumentSemantic.Strong)]
		NSUrl Url { get; }

		[Export ("width", ArgumentSemantic.Assign)]
		nint Width { get; }

		[Export ("height", ArgumentSemantic.Assign)]
		nint Height { get; }

		[Export ("initWithURL:width:height:")]
		IntPtr Constructor (NSUrl url, nint width, nint height);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKJSONUtils")]
	interface JsonUtils
	{

		[Static]
		[Export ("parseJSON:")]
		NSObject ParseJson (string json);

		[Static]
		[Export ("parseJSON:error:")]
		NSObject ParseJson (string json, out NSError error);

		[Static]
		[Export ("writeJSON:")]
		string WriteJson (NSObject obj);

		[Static]
		[Export ("isJSONString:equivalentTo:")]
		bool JsonEquals (string actualJson, string expectedJson);

		[Static]
		[Export ("isJSONObject:equivalentTo:")]
		bool JsonEquals (NSObject actualJson, NSObject expectedJson);
	}

	[BaseType (typeof (NSObject), Name = "GCKLaunchOptions")]
	interface LaunchOptions : INSCopying, INSCoding
	{

		[Export ("languageCode", ArgumentSemantic.Copy)]
		string LanguageCode { get; set; }

		[Export ("relaunchIfRunning")]
		bool relaunchIfRunning { get; set; }

		[Export ("initWithRelaunchIfRunning:")]
		IntPtr Constructor (bool relaunchIfRunning);

		[Export ("initWithLanguageCode:relaunchIfRunning:")]
		IntPtr Constructor (string languageCode, bool relaunchIfRunning);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKLogger")]
	interface Logger
	{

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		ILoggerDelegate Delegate { get; set; }

		[Static]
		[Export ("sharedInstance")]
		Logger SharedInstance { get; }

		[Internal]
		[Export ("logFromFunction:message:", IsVariadic = true)]
		void _Log (IntPtr function, string first, IntPtr subsequent);
	}

	interface ILoggerDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKLoggerDelegate")]
	interface LoggerDelegate
	{

		[Abstract]
		[Export ("logFromFunction:message:")]
		void Log (IntPtr function, string message);
	}


	[BaseType (typeof (CastChannel),
		Name = "GCKMediaControlChannel",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (MediaControlChannelDelegate) })]
	interface MediaControlChannel
	{

		[Field ("kGCKMediaDefaultReceiverApplicationID", "__Internal")]
		NSString DefaultReceiverApplicationID { get; }

		[Export ("mediaStatus", ArgumentSemantic.Strong)]
		MediaStatus MediaStatus { get; }

		[Export ("lastError", ArgumentSemantic.Copy)]
		Error LastError { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IMediaControlChannelDelegate Delegate { get; set; }

		[Export ("loadMedia:")]
		nint LoadMedia (MediaInformation mediaInfo);

		[Export ("loadMedia:autoplay:")]
		nint LoadMedia (MediaInformation mediaInfo, bool autoplay);

		[Export ("loadMedia:autoplay:playPosition:")]
		nint LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition);

		[Export ("loadMedia:autoplay:playPosition:customData:")]
		nint LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSObject customData);

		[Export ("loadMedia:autoplay:playPosition:activeTrackIDs:")]
		nint LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSNumber [] activeTrackIDs);

		[Export ("loadMedia:autoplay:playPosition:activeTrackIDs:customData:")]
		nint LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSNumber [] activeTrackIDs, [NullAllowed] NSObject customData);

		[Export ("setActiveTrackIDs:")]
		nint SetActiveTrackIDs (NSNumber [] activeTrackIDs);

		[Export ("setTextTrackStyle:")]
		nint SetTextTrackStyle (MediaTextTrackStyle textTrackStyle);

		[Export ("pause")]
		nint Pause ();

		[Export ("pauseWithCustomData:")]
		nint Pause (NSObject customData);

		[Export ("stop")]
		nint Stop ();

		[Export ("stopWithCustomData:")]
		nint Stop (NSObject customData);

		[Export ("play")]
		nint Play ();

		[Export ("playWithCustomData:")]
		nint Play (NSObject customData);

		[Export ("seekToTimeInterval:")]
		nint Seek (double position);

		[Export ("seekToTimeInterval:resumeState:")]
		nint Seek (double position, MediaControlChannelResumeState resumeState);

		[Export ("seekToTimeInterval:resumeState:customData:")]
		nint Seek (double position, MediaControlChannelResumeState resumeState, NSObject customData);

		[Export ("queueLoadItems:startIndex:repeatMode:")]
		nint QueueLoadItems (MediaQueueItem [] queueItems, nuint startIndex, MediaRepeatMode repeatMode);

		[Export ("queueLoadItems:startIndex:repeatMode:customData:")]
		nint QueueLoadItems (MediaQueueItem [] queueItems, nuint startIndex, MediaRepeatMode repeatMode, [NullAllowed] NSObject customData);

		[Export ("queueLoadItems:startIndex:playPosition:repeatMode:customData:")]
		nint QueueLoadItems (MediaQueueItem [] queueItems, nuint startIndex, double playPosition, MediaRepeatMode repeatMode, [NullAllowed] NSObject customData);

		[Export ("queueInsertItems:beforeItemWithID:")]
		nint QueueInsertItems (MediaQueueItem [] queueItems, nuint beforeItemID);

		[Export ("queueInsertItems:beforeItemWithID:customData:")]
		nint QueueInsertItems (MediaQueueItem [] queueItems, nuint beforeItemID, NSObject customData);

		[Export ("queueInsertItem:beforeItemWithID:")]
		nint QueueInsertItem (MediaQueueItem item, nuint beforeItemID);

		[Export ("queueInsertAndPlayItem:beforeItemWithID:")]
		nint QueueInsertItemAndPlay (MediaQueueItem item, nuint beforeItemID);

		[Export ("queueInsertAndPlayItem:beforeItemWithID:playPosition:customData:")]
		nint QueueInsertItemAndPlay (MediaQueueItem item, nuint beforeItemID, double playPosition, [NullAllowed] NSObject customData);

		[Export ("queueUpdateItems:")]
		nint QueueUpdateItems (MediaQueueItem [] queueItems);

		[Export ("queueUpdateItems:customData:")]
		nint QueueUpdateItems (MediaQueueItem [] queueItems, NSObject customData);

		[Export ("queueRemoveItemsWithIDs:")]
		nint QueueRemoveItems (NSArray itemIDs);

		[Export ("queueRemoveItemsWithIDs:customData:")]
		nint QueueRemoveItems (NSArray itemIDs, NSObject customData);

		[Export ("queueRemoveItemWithID:")]
		nint QueueRemoveItem (nuint itemID);

		[Export ("queueReorderItemsWithIDs:insertBeforeItemWithID:")]
		nint QueueReorderItems (NSNumber [] queueItemIDs, nuint beforeItemID);

		[Export ("queueReorderItemsWithIDs:insertBeforeItemWithID:customData:")]
		nint QueueReorderItems (NSNumber [] queueItemIDs, nuint beforeItemID, NSObject customData);

		[Export ("queueMoveItemWithID:beforeItemWithID:")]
		nint QueueMoveItem (nuint itemID, nuint beforeItemID);

		[Export ("queueJumpToItemWithID:")]
		nint QueueJumpToItem (nuint itemID);

		[Export ("queueJumpToItemWithID:customData:")]
		nint QueueJumpToItem (nuint itemID, [NullAllowed] NSObject customData);

		[Export ("queueJumpToItemWithID:playPosition:customData:")]
		nint QueueJumpToItem (nuint itemID, double playPosition, [NullAllowed] NSObject customData);

		[Export ("queueNextItem")]
		nint QueueNextItem ();

		[Export ("queuePreviousItem")]
		nint QueuePreviousItem ();

		[Export ("queueSetRepeatMode:")]
		nint QueueSetRepeatMode (MediaRepeatMode repeatMode);

		[Export ("setStreamVolume:")]
		nint SetStreamVolume (float volume);

		[Export ("setStreamVolume:customData:")]
		nint SetStreamVolume (float volume, NSObject customData);

		[Export ("setStreamMuted:")]
		nint SetStreamMuted (bool muted);

		[Export ("setStreamMuted:customData:")]
		nint SetStreamMuted (bool muted, NSObject customData);

		[Export ("requestStatus")]
		nint RequestStatus ();

		[Export ("approximateStreamPosition")]
		double ApproximateStreamPosition ();

		[Export ("cancelRequestWithID:")]
		bool CancelRequest (nint requestId);
	}

	interface IMediaControlChannelDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject), Name = "GCKMediaControlChannelDelegate")]
	interface MediaControlChannelDelegate
	{

		[EventArgs ("MediaControlChannelLoadCompleted")]
		[EventName ("LoadCompleted")]
		[Export ("mediaControlChannel:didCompleteLoadWithSessionID:")]
		void DidCompleteLoad (MediaControlChannel mediaControlChannel, nint sessionId);

		[EventArgs ("MediaControlChannelLoadMediaFailed")]
		[EventName ("LoadMediaFailed")]
		[Export ("mediaControlChannel:didFailToLoadMediaWithError:")]
		void DidFailToLoadMedia (MediaControlChannel mediaControlChannel, NSError error);

		[EventArgs ("MediaControlChannelStatusUpdated")]
		[EventName ("StatusUpdated")]
		[Export ("mediaControlChannelDidUpdateStatus:")]
		void DidUpdateStatus (MediaControlChannel mediaControlChannel);

		[EventArgs ("MediaControlChannelMetadataUpdated")]
		[EventName ("MetadataUpdated")]
		[Export ("mediaControlChannelDidUpdateMetadata:")]
		void DidUpdateMetadata (MediaControlChannel mediaControlChannel);

		[EventArgs ("MediaControlChannelRequestCompleted")]
		[EventName ("RequestCompleted")]
		[Export ("mediaControlChannel:requestDidCompleteWithID:")]
		void RequestDidComplete (MediaControlChannel mediaControlChannel, nint requestId);

		[EventArgs ("MediaControlChannelRequestReplaced")]
		[EventName ("RequestReplaced")]
		[Export ("mediaControlChannel:didReplaceRequestWithID:")]
		void RequestDidReplace (MediaControlChannel mediaControlChannel, nint requestId);

		[EventArgs ("MediaControlChannelRequestCancelled")]
		[EventName ("RequestCancelled")]
		[Export ("mediaControlChannel:didCancelRequestWithID:")]
		void RequestDidCancel (MediaControlChannel mediaControlChannel, nint requestId);

		[EventArgs ("MediaControlChannelRequestFailed")]
		[EventName ("RequestFailed")]
		[Export ("mediaControlChannel:requestDidFailWithID:error:")]
		void RequestDidFail (MediaControlChannel mediaControlChannel, nint requestId, NSError error);

		//- (void)mediaControlChannelDidUpdateQueue:(GCKMediaControlChannel *)mediaControlChannel;
		[EventArgs ("MediaControlChannelQueueUpdated")]
		[EventName ("QueueUpdated")]
		[Export ("mediaControlChannelDidUpdateQueue:")]
		void DidUpdateQueue (MediaControlChannel mediaControlChannel);

		//- (void)mediaControlChannelDidUpdatePreloadStatus:(GCKMediaControlChannel *)mediaControlChannel;
		[EventArgs ("MediaControlChannelPreloadStatusUpdated")]
		[EventName ("PreloadStatusUpdated")]
		[Export ("mediaControlChannelDidUpdatePreloadStatus:")]
		void DidUpdatePreloadStatus (MediaControlChannel mediaControlChannel);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKMediaInformation")]
	interface MediaInformation : INSCopying
	{

		[Export ("contentID", ArgumentSemantic.Copy)]
		string ContentID { get; }

		[Export ("streamType", ArgumentSemantic.Assign)]
		MediaStreamType StreamType { get; }

		[Export ("contentType", ArgumentSemantic.Copy)]
		string ContentType { get; }

		[Export ("metadata", ArgumentSemantic.Strong)]
		MediaMetadata Metadata { get; }

		[Export ("streamDuration", ArgumentSemantic.Assign)]
		double StreamDuration { get; }

		[Export ("mediaTracks", ArgumentSemantic.Copy)]
		MediaTrack [] MediaTracks { get; }

		[Export ("textTrackStyle", ArgumentSemantic.Copy)]
		MediaTextTrackStyle TextTrackStyle { get; }

		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; }

		[Export ("initWithContentID:streamType:contentType:metadata:streamDuration:mediaTracks:textTrackStyle:customData:")]
		IntPtr Constructor (string contentID, MediaStreamType streamType, string contentType, MediaMetadata metadata, double streamDuration, MediaTrack [] mediaTracks, MediaTextTrackStyle textTrackStyle, [NullAllowed] NSObject customData);

		[Export ("initWithContentID:streamType:contentType:metadata:streamDuration:customData:")]
		IntPtr Constructor (string contentID, MediaStreamType streamType, string contentType, MediaMetadata metadata, double streamDuration, [NullAllowed] NSObject customData);
	}

	[DisableDefaultCtor]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKMetadataKey")]
	interface MetadataKey
	{

		[Field ("kGCKMetadataKeyCreationDate", "__Internal")]
		NSString CreationDate { get; }

		[Field ("kGCKMetadataKeyReleaseDate", "__Internal")]
		NSString ReleaseDate { get; }

		[Field ("kGCKMetadataKeyBroadcastDate", "__Internal")]
		NSString BroadcastDate { get; }

		[Field ("kGCKMetadataKeyTitle", "__Internal")]
		NSString Title { get; }

		[Field ("kGCKMetadataKeySubtitle", "__Internal")]
		NSString Subtitle { get; }

		[Field ("kGCKMetadataKeyArtist", "__Internal")]
		NSString Artist { get; }

		[Field ("kGCKMetadataKeyAlbumArtist", "__Internal")]
		NSString AlbumArtist { get; }

		[Field ("kGCKMetadataKeyAlbumTitle", "__Internal")]
		NSString AlbumTitle { get; }

		[Field ("kGCKMetadataKeyComposer", "__Internal")]
		NSString Composer { get; }

		[Field ("kGCKMetadataKeyDiscNumber", "__Internal")]
		NSString DiscNumber { get; }

		[Field ("kGCKMetadataKeyTrackNumber", "__Internal")]
		NSString TrackNumber { get; }

		[Field ("kGCKMetadataKeySeasonNumber", "__Internal")]
		NSString SeasonNumber { get; }

		[Field ("kGCKMetadataKeyEpisodeNumber", "__Internal")]
		NSString EpisodeNumber { get; }

		[Field ("kGCKMetadataKeySeriesTitle", "__Internal")]
		NSString SeriesTitle { get; }

		[Field ("kGCKMetadataKeyStudio", "__Internal")]
		NSString KeyStudio { get; }

		[Field ("kGCKMetadataKeyWidth", "__Internal")]
		NSString Width { get; }

		[Field ("kGCKMetadataKeyHeight", "__Internal")]
		NSString Height { get; }

		[Field ("kGCKMetadataKeyLocationName", "__Internal")]
		NSString LocationName { get; }

		[Field ("kGCKMetadataKeyLocationLatitude", "__Internal")]
		NSString LocationLatitude { get; }

		[Field ("kGCKMetadataKeyLocationLongitude", "__Internal")]
		NSString LocationLongitude { get; }
	}

	[BaseType (typeof (NSObject), Name = "GCKMediaMetadata")]
	interface MediaMetadata : INSCopying
	{

		[Export ("metadataType", ArgumentSemantic.Assign)]
		MediaMetadataType MetadataType { get; }

		[Export ("initWithMetadataType:")]
		IntPtr Constructor (MediaMetadataType metadataType);

		[Export ("images")]
		Image [] Images ();

		[Export ("removeAllMediaImages")]
		void RemoveAllMediaImages ();

		[Export ("addImage:")]
		void AddImage (Image image);

		[Export ("containsKey:")]
		bool ContainsKey (string key);

		[Export ("allKeys")]
		string [] AllKeys ();

		[Export ("objectForKey:")]
		NSObject ObjectForKey (string key);

		[Export ("setString:forKey:")]
		void SetString (string value, string Key);

		[Export ("stringForKey:")]
		string StringForKey (string key);

		[Export ("setInteger:forKey:")]
		void SetInteger (nint value, string Key);

		[Export ("integerForKey:")]
		nint IntegerForKey (string key);

		[Export ("integerForKey:defaultValue:")]
		int IntegerForKey (string key, nint defaultValue);

		[Export ("setDouble:forKey:")]
		void SetDouble (double value, string Key);

		[Export ("doubleForKey:")]
		double DoubleForKey (string key);

		[Export ("doubleForKey:defaultValue:")]
		double DoubleForKey (string key, double defaultValue);

		[Export ("setDate:forKey:")]
		void SetDate (NSDate value, string Key);

		[Export ("dateForKey:")]
		NSDate DateForKey (string key);

		[Export ("dateAsStringForKey:")]
		string DateAsStringForKey (string key);
	}

	[DisableDefaultCtor]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKMediaCommand")]
	interface MediaCommand
	{

		[Field ("kGCKMediaCommandPause", "__Internal")]
		nint Pause { get; }

		[Field ("kGCKMediaCommandSeek", "__Internal")]
		nint Seek { get; }

		[Field ("kGCKMediaCommandSetVolume", "__Internal")]
		nint SetVolume { get; }

		[Field ("kGCKMediaCommandToggleMute", "__Internal")]
		nint ToggleMute { get; }

		[Field ("kGCKMediaCommandSkipForward", "__Internal")]
		nint SkipForward { get; }

		[Field ("kGCKMediaCommandSkipBackward", "__Internal")]
		nint SkipBackward { get; }

		[Field ("kGCKMediaCommandQueueNext", "__Internal")]
		nint QueueNext { get; }

		[Field ("kGCKMediaCommandQueuePrevious", "__Internal")]
		nint QueuePrevious { get; }

	}

	[BaseType (typeof (NSObject), Name = "GCKMediaStatus")]
	interface MediaStatus : INSCopying
	{

		[Export ("mediaSessionID", ArgumentSemantic.Assign)]
		nint MediaSessionId { get; }

		[Export ("playerState", ArgumentSemantic.Assign)]
		MediaPlayerState PlayerState { get; }

		[Export ("idleReason", ArgumentSemantic.Assign)]
		MediaPlayerIdleReason IdleReason { get; }

		[Export ("playbackRate", ArgumentSemantic.Assign)]
		float PlaybackRate { get; }

		[Export ("mediaInformation", ArgumentSemantic.Strong)]
		MediaInformation MediaInformation { get; }

		[Export ("streamPosition", ArgumentSemantic.Assign)]
		double StreamPosition { get; }

		[Export ("volume", ArgumentSemantic.Assign)]
		float Volume { get; }

		[Export ("isMuted", ArgumentSemantic.Assign)]
		bool IsMuted { get; }

		[Export ("queueRepeatMode", ArgumentSemantic.Assign)]
		MediaRepeatMode QueueRepeatMode { get; }

		[Export ("currentItemID", ArgumentSemantic.Assign)]
		nuint CurrentItemID { get; }

		[Export ("preloadedItemID", ArgumentSemantic.Assign)]
		nuint PreloadedItemID { get; }

		[Export ("loadingItemID", ArgumentSemantic.Assign)]
		nuint LoadingItemID { get; }

		[Export ("activeTrackIDs", ArgumentSemantic.Assign)]
		NSNumber [] ActiveTrackIDs { get; }

		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; }

		[Export ("initWithSessionID:mediaInformation:")]
		IntPtr Constructor (nint mediaSessionID, MediaInformation mediaInformation);

		[Export ("isMediaCommandSupported:")]
		bool IsMediaCommandSupported (nint command);

		[Export ("queueItemCount")]
		nuint QueueItemCount { get; }

		[Export ("queueItemAtIndex:")]
		MediaQueueItem QueueItemAt (nuint index);

		[Export ("queueItemWithItemID:")]
		MediaQueueItem QueueItem (nuint itemID);

		// - (NSInteger)queueIndexForItemID:(NSUInteger)itemID;
		[Export ("queueIndexForItemID:")]
		nint QueueIndex (nuint itemID);
	}

	[BaseType (typeof (NSObject), Name = "GCKMediaTextTrackStyle")]
	interface MediaTextTrackStyle : INSCopying
	{

		[Static]
		[Export ("createDefault")]
		MediaTextTrackStyle CreateDefault ();

		[Export ("fontScale")]
		nfloat FontScale { get; set; }

		[Export ("foregroundColor", ArgumentSemantic.Copy)]
		Color ForegroundColor { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		Color BackgroundColor { get; set; }

		[Export ("edgeType")]
		MediaTextTrackStyleEdgeType EdgeType { get; set; }

		[Export ("edgeColor", ArgumentSemantic.Copy)]
		Color EdgeColor { get; set; }

		[Export ("windowType")]
		MediaTextTrackStyleWindowType WindowType { get; set; }

		[Export ("windowColor", ArgumentSemantic.Copy)]
		Color WindowColor { get; set; }

		[Export ("windowRoundedCornerRadius")]
		nfloat WindowRoundedCornerRadius { get; set; }

		[Export ("fontFamily", ArgumentSemantic.Copy)]
		string FontFamily { get; set; }

		[Export ("fontGenericFamily")]
		MediaTextTrackStyleFontGenericFamily FontGenericFamily { get; set; }

		[Export ("fontStyle")]
		MediaTextTrackStyleFontStyle FontStyle { get; set; }

		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKMediaTrack")]
	interface MediaTrack : INSCopying
	{

		[Export ("initWithIdentifier:contentIdentifier:contentType:type:textSubtype:name:languageCode:customData:")]
		IntPtr Constructor (nint identifier, string contentIdentifier, string contentType, MediaTrackType type, MediaTextTrackSubtype textSubtype, string name, string languageCode, NSObject customData);

		[Export ("identifier")]
		nint Identifier { get; }

		[Export ("contentIdentifier", ArgumentSemantic.Copy)]
		string ContentIdentifier { get; }

		[Export ("contentType", ArgumentSemantic.Copy)]
		string ContentType { get; }

		[Export ("type")]
		MediaTrackType Type { get; }

		[Export ("textSubtype")]
		MediaTextTrackSubtype TextSubtype { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("languageCode", ArgumentSemantic.Copy)]
		string LanguageCode { get; }

		[Export ("customData", ArgumentSemantic.Retain)]
		NSObject CustomData { get; }
	}

	[Category]
	[BaseType (typeof (NSDictionary), Name = "GCKTypedValueLookup")]
	interface TypedValueLookup
	{

		[Export ("gck_stringForKey:withDefaultValue:")]
		string GetString (string key, string defaultValue);

		[Export ("gck_stringForKey:")]
		string GetString (string key);

		[Export ("gck_integerForKey:withDefaultValue:")]
		nint GetNInteger (string key, nint defaultValue);

		[Export ("gck_integerForKey:")]
		nint GetNInteger (string key);

		[Export ("gck_uintegerForKey:withDefaultValue:")]
		nuint GetNUInteger (string key, nuint defaultValue);

		[Export ("gck_uintegerForKey:")]
		nuint GetNUInteger (string key);

		[Export ("gck_doubleForKey:withDefaultValue:")]
		double GetDouble (string key, double defaultValue);

		[Export ("gck_doubleForKey:")]
		double GetDouble (string key);

		[Export ("gck_boolForKey:withDefaultValue:")]
		bool GetBool (string key, bool defaultValue);

		[Export ("gck_boolForKey:")]
		bool GetBool (string key);

		[Export ("gck_dictionaryForKey:")]
		NSDictionary GetDictionary (string key);

		[Export ("gck_arrayForKey:")]
		NSObject [] GetArray (string key);

		[Export ("gck_setStringValue:forKey:")]
		void SetString (string value, string key);

		[Export ("gck_setIntegerValue:forKey:")]
		void SetNInt (nint value, string key);

		[Export ("gck_setUIntegerValue:forKey:")]
		void SetNUInt (nuint value, string key);

		[Export ("gck_setDoubleValue:forKey:")]
		void SetDouble (double value, string key);

		[Export ("gck_setBoolValue:forKey:")]
		void SetBool (bool value, string key);
	}

	[BaseType (typeof (NSObject), Name = "GCKSenderApplicationInfo")]
	interface SenderApplicationInfo : INSCopying
	{

		[Export ("platform", ArgumentSemantic.Assign)]
		SenderApplicationInfoPlatform Platform { get; }

		[Export ("appIdentifier", ArgumentSemantic.Copy)]
		string AppIdentifier { get; }

		[Export ("launchURL", ArgumentSemantic.Strong)]
		NSUrl LaunchUrl { get; }
	}

	[BaseType (typeof (NSObject), Name = "GCKMediaQueueItem")]
	interface MediaQueueItem : INSCopying
	{

		//@property(nonatomic, strong, readonly) GCKMediaInformation *mediaInformation;
		[Export ("mediaInformation", ArgumentSemantic.Strong)]
		MediaInformation MediaInformation { get; }

		//@property(nonatomic, readonly) NSUInteger itemID;
		[Export ("itemID", ArgumentSemantic.Assign)]
		nuint ItemID { get; }

		//@property(nonatomic, readonly) BOOL autoplay;
		[Export ("autoplay", ArgumentSemantic.Assign)]
		bool Autoplay { get; }

		// @property(nonatomic, readonly) NSTimeInterval playbackDuration;
		[Export ("playbackDuration")]
		double PlaybackDuration { get; }

		//@property(nonatomic, readonly) NSTimeInterval startTime;
		[Export ("startTime", ArgumentSemantic.Assign)]
		double StartTime { get; }

		//@property(nonatomic, readonly) NSTimeInterval preloadTime;
		[Export ("preloadTime", ArgumentSemantic.Assign)]
		double PreloadTime { get; }

		//@property(nonatomic, strong, readonly) NSArray *activeTrackIDs;
		[Internal]
		[Export ("activeTrackIDs", ArgumentSemantic.Strong)]
		NSArray _ActiveTrackIDs { get; }

		//@property(nonatomic, strong, readonly) id customData;
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; }

		// - (instancetype)initWithMediaInformation:(GCKMediaInformation *)mediaInformation autoplay:(BOOL)autoplay startTime:(NSTimeInterval)startTime preloadTime:(NSTimeInterval)preloadTime activeTrackIDs:(NSArray *)activeTrackIDs customData:(id)customData;
		[Internal]
		[Export ("initWithMediaInformation:autoplay:startTime:preloadTime:activeTrackIDs:customData:")]
		IntPtr _InitWithMediaInformation (MediaInformation mediaInformation, bool autoplay, double startTime, double preloadTime, [NullAllowed] NSArray activeTrackIDs, [NullAllowed] NSObject customData);

		// - (instancetype)initWithMediaInformation:(GCKMediaInformation *)mediaInformation autoplay:(BOOL)autoplay startTime:(NSTimeInterval)startTime playbackDuration:(NSTimeInterval)playbackDuration preloadTime:(NSTimeInterval)preloadTime activeTrackIDs:(NSArray *)activeTrackIDs customData:(id)customData;
		[Internal]
		[Export ("initWithMediaInformation:autoplay:startTime:playbackDuration:preloadTime:activeTrackIDs:customData:")]
		IntPtr _InitWithMediaInformation (MediaInformation mediaInformation, bool autoplay, double startTime, double playbackDuration, double preloadTime, [NullAllowed] NSArray activeTrackIDs, [NullAllowed] NSObject customData);

		// - (void)clearItemID;
		[Export ("clearItemID")]
		void ClearItemID ();

		// - (instancetype)mediaQueueItemModifiedWithBlock:(void (^)(GCKMediaQueueItemBuilder *builder))block;
		[Export ("mediaQueueItemModifiedWithBlock:")]
		MediaQueueItem MediaQueueItemModified (Action<MediaQueueItemBuilder> block);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKMediaQueueItemBuilder")]
	interface MediaQueueItemBuilder
	{
		//@property(nonatomic, copy, readwrite) GCKMediaInformation *mediaInformation;
		[Export ("mediaInformation", ArgumentSemantic.Copy)]
		MediaInformation MediaInformation { get; set; }

		//@property(nonatomic, readwrite) BOOL autoplay;
		[Export ("autoplay")]
		bool Autoplay { get; set; }

		//@property(nonatomic, readwrite) NSTimeInterval startTime;
		[Export ("startTime")]
		double StartTime { get; set; }

		//@property(nonatomic, readwrite) NSTimeInterval preloadTime;
		[Export ("preloadTime")]
		double PreloadTime { get; set; }

		/** The active track IDs for this item. */
		//@property(nonatomic, copy, readwrite) NSArray *activeTrackIDs;
		[Internal]
		[Export ("activeTrackIDs", ArgumentSemantic.Copy)]
		NSArray _ActiveTrackIDs { get; set; }

		/** The custom data associated with this item, if any. */
		//@property(nonatomic, copy, readwrite) id customData;
		[Export ("customData", ArgumentSemantic.Copy)]
		NSObject CustomData { get; set; }

		[Export ("init")]
		IntPtr Constructor ();

		[Export ("initWithMediaQueueItem:")]
		IntPtr Constructor (MediaQueueItem item);

		[Export ("build")]
		MediaQueueItem Build ();
	}

	[Category]
	[BaseType (typeof (UIImage))]
	interface UIImage_GCKAdditions
	{
		// - (UIImage *)gck_imageWithTintColor:(UIColor *)color;
		[Export ("gck_imageWithTintColor:")]
		UIImage GetImage (UIColor tintColor);

		// - (UIImage *)gck_imageScaledToFitSize:(CGSize)size;
		[Export ("gck_imageScaledToFitSize:")]
		UIImage GetScaledImageToFitSize (CGSize toSize);

		// - (UIImage *)gck_imageScaledToWidth:(CGFloat)width;
		[Export ("gck_imageScaledToWidth:")]
		UIImage GetScaledImageToWidth (nfloat toWidth);

		// - (UIImage *)gck_imageScaledToHeight:(CGFloat)height;
		[Export ("gck_imageScaledToHeight:")]
		UIImage GetScaledImageToHeight (nfloat toHeight);

		// - (UIImage *)gck_imageScaledToSize:(CGSize)size;
		[Export ("gck_imageScaledToSize:")]
		UIImage GetScaledImage (CGSize toSize);

	}
}