using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

namespace Google.Cast
{
	[Static]
	interface Common
	{
		[Field ("kGCKFrameworkVersion", "__Internal")]
		NSString FrameworkVersion { get; }

		// extern NSString *const kGCKThreadException __attribute__((visibility("default")));
		[Field ("kGCKThreadException", "__Internal")]
		NSString ThreadException { get; }
	}

	// @interface GCKAdBreakClipInfo : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GCKAdBreakClipInfo")]
	interface AdBreakClipInfo : INSCopying
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull adBreakClipID;
		[Export ("adBreakClipID")]
		string AdBreakClipId { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval duration;
		[Export ("duration")]
		double Duration { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable title;
		[NullAllowed]
		[Export ("title")]
		string Title { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable clickThroughURL;
		[NullAllowed]
		[Export ("clickThroughURL", ArgumentSemantic.Copy)]
		NSUrl ClickThroughUrl { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable contentURL;
		[NullAllowed]
		[Export ("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable mimeType;
		[NullAllowed]
		[Export ("mimeType")]
		string MimeType { get; }

		// @property (readonly, nonatomic, strong) id _Nullable customData;
		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; }
	}

	// @interface GCKAdBreakInfo : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GCKAdBreakInfo")]
	interface AdBreakInfo : INSCopying
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull adBreakID;
		[Export ("adBreakID")]
		string AdBreakId { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval playbackPosition;
		[Export ("playbackPosition")]
		double PlaybackPosition { get; }

		// @property (readonly, assign, nonatomic) BOOL watched;
		[Export ("watched")]
		bool Watched { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSString *> * _Nonnull adBreakClipIDs;
		[Export ("adBreakClipIDs", ArgumentSemantic.Strong)]
		string [] AdBreakClipIds { get; }

		// -(instancetype _Nonnull)initWithPlaybackPosition:(NSTimeInterval)playbackPosition;
		[Export ("initWithPlaybackPosition:")]
		IntPtr Constructor (double playbackPosition);
	}

	// @interface GCKAdBreakStatus : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GCKAdBreakStatus")]
	interface AdBreakStatus : INSCopying
	{
		// @property (readonly, assign, nonatomic) NSTimeInterval currentAdBreakTime;
		[Export ("currentAdBreakTime")]
		double CurrentAdBreakTime { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval currentAdBreakClipTime;
		[Export ("currentAdBreakClipTime")]
		double CurrentAdBreakClipTime { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull adBreakID;
		[Export ("adBreakID")]
		string AdBreakId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull adBreakClipID;
		[Export ("adBreakClipID")]
		string AdBreakClipId { get; }
	}

	[BaseType (typeof (NSObject), Name = "GCKApplicationMetadata")]
	interface ApplicationMetadata : INSCopying
	{

		[Export ("applicationID", ArgumentSemantic.Copy)]
		string ApplicationId { get; }

		[Export ("applicationName", ArgumentSemantic.Copy)]
		string ApplicationName { get; }

		[NullAllowed]
		[Export ("images", ArgumentSemantic.Copy)]
		Image [] Images { get; }

		[NullAllowed]
		[Export ("namespaces", ArgumentSemantic.Copy)]
		string [] Namespaces { get; }

		[NullAllowed]
		[Export ("senderApplicationInfo", ArgumentSemantic.Copy)]
		SenderApplicationInfo SenderApplicationInfo { get; }

		[NullAllowed]
		[Export ("senderAppIdentifier")]
		string SenderAppIdentifier { get; }

		[NullAllowed]
		[Export ("senderAppLaunchURL")]
		NSUrl SenderAppLaunchUrl { get; }
	}

	[DisableDefaultCtor]
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

		[Obsolete ("Use SendTextMessage (string, out NSError) instead.")]
		[Export ("sendTextMessage:")]
		bool SendTextMessage (string message);

		// - (BOOL)sendTextMessage:(NSString *)message error:(GCKError **)error;
		[Export ("sendTextMessage:error:")]
		bool SendTextMessage (string message, out Error error);

		[Export ("generateRequestID")]
		nint GenerateRequestId ();

		[return: NullAllowed]
		[Export ("generateRequestNumber")]
		NSNumber GenerateRequestNumber ();

		[Export ("didConnect")]
		void DidConnect ();

		[Export ("didDisconnect")]
		void DidDisconnect ();
	}

	interface CastStateDidChangeDidChangeEventArgs
	{
		[Export ("kGCKNotificationKeyCastState")]
		CastState CastState { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKCastContext")]
	interface CastContext
	{

		// extern NSString *const _Nonnull kGCKNotificationKeyCastState __attribute__((visibility("default")));
		[Field ("kGCKNotificationKeyCastState", "__Internal")]
		NSString NotificationKeyCastState { get; }

		// extern NSString *const _Nonnull kGCKCastStateDidChangeNotification __attribute__((visibility("default")));
		[Notification (typeof (CastStateDidChangeDidChangeEventArgs))]
		[Field ("kGCKCastStateDidChangeNotification", "__Internal")]
		NSString CastStateDidChangeNotification { get; }

		// @property (readonly, assign, nonatomic) GCKCastState castState;
		[Export ("castState", ArgumentSemantic.Assign)]
		CastState CastState { get; }

		// @property (readonly, nonatomic, strong) GCKDiscoveryManager * _Nonnull discoveryManager;
		[Export ("discoveryManager", ArgumentSemantic.Strong)]
		DiscoveryManager DiscoveryManager { get; }

		// @property (readonly, nonatomic, strong) GCKSessionManager * _Nonnull sessionManager;
		[Export ("sessionManager", ArgumentSemantic.Strong)]
		SessionManager SessionManager { get; }

		// +(void)setSharedInstanceWithOptions:(GCKCastOptions * _Nonnull)options;
		[Static]
		[Export ("setSharedInstanceWithOptions:")]
		void SetSharedInstance (CastOptions options);

		// + (instancetype) sharedInstance
		[Static]
		[Export ("sharedInstance")]
		CastContext SharedInstance { get; }

		// +(BOOL) isSharedInstanceInitialized	
		[Static]
		[Export ("isSharedInstanceInitialized")]
		bool IsSharedInstanceInitialized { get; }

		// -(void)registerDeviceProvider:(GCKDeviceProvider * _Nonnull)deviceProvider;
		[Export ("registerDeviceProvider:")]
		void RegisterDeviceProvider (DeviceProvider deviceProvider);

		// -(void)unregisterDeviceProviderForCategory:(NSString * _Nonnull)category;
		[Export ("unregisterDeviceProviderForCategory:")]
		void UnregisterDeviceProviderForCategory (string category);

		////////////////////////////////////
		/// From Category CastContext_UI ///
		////////////////////////////////////

		// @property (nonatomic, strong, readwrite, GCK_NULLABLE) id<GCKUIImageCache> imageCache;
		[NullAllowed]
		[Export ("imageCache", ArgumentSemantic.Strong)]
		IUIImageCache ImageCache { get; set; }

		// @property(nonatomic, strong, readwrite, GCK_NULLABLE) id<GCKUIImagePicker> imagePicker;
		[NullAllowed]
		[Export ("imagePicker", ArgumentSemantic.Strong)]
		IUIImagePicker ImagePicker { get; set; }

		// @property(nonatomic, assign, readwrite) BOOL useDefaultExpandedMediaControls;
		[Export ("useDefaultExpandedMediaControls", ArgumentSemantic.Assign)]
		bool UseDefaultExpandedMediaControls { get; set; }

		// @property(nonatomic, strong, readonly) GCKUIExpandedMediaControlsViewController* defaultExpandedMediaControlsViewController;
		[Export ("defaultExpandedMediaControlsViewController", ArgumentSemantic.Assign)]
		UIExpandedMediaControlsViewController DefaultExpandedMediaControlsViewController { get; }
	}

	[Category]
	[BaseType (typeof (CastContext))]
	interface CastContext_UI
	{
		// - (void)presentCastDialog;
		[Export ("presentCastDialog")]
		void PresentCastDialog ();

		// - (GCKUICastContainerViewController *)createCastContainerControllerForViewController:(UIViewController*)viewController;
		[Export ("createCastContainerControllerForViewController:")]
		UICastContainerViewController CreateCastContainerController (UIViewController viewController);

		// - (GCKUIMiniMediaControlsViewController *)createMiniMediaControlsViewController;
		[Export ("createMiniMediaControlsViewController")]
		UIMiniMediaControlsViewController CreateMiniMediaControlsViewController ();

		// - (BOOL)presentCastInstructionsViewControllerOnce;
		[Export ("presentCastInstructionsViewControllerOnce")]
		bool PresentCastInstructionsViewControllerOnce ();

		// - (void)clearCastInstructionsShownFlag;
		[Export ("clearCastInstructionsShownFlag")]
		void ClearCastInstructionsShownFlag ();

		// - (void)presentDefaultExpandedMediaControls;
		[Export ("presentDefaultExpandedMediaControls")]
		void PresentDefaultExpandedMediaControls ();
	}

	// @interface GCKCastOptions : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GCKCastOptions")]
	interface CastOptions : INSCopying
	{
		// -(instancetype _Nonnull)initWithReceiverApplicationID:(NSString * _Nonnull)applicationID;
		[Export ("initWithReceiverApplicationID:")]
		IntPtr Constructor (string applicationId);

		// -(instancetype _Nonnull)initWithSupportedNamespaces:(NSArray<NSString *> * _Nonnull)namespaces;
		[Export ("initWithSupportedNamespaces:")]
		IntPtr Constructor (string [] namespaces);

		// @property (assign, readwrite, nonatomic) BOOL physicalVolumeButtonsWillControlDeviceVolume;
		[Export ("physicalVolumeButtonsWillControlDeviceVolume")]
		bool PhysicalVolumeButtonsWillControlDeviceVolume { get; set; }

		[Export ("disableDiscoveryAutostart")]
		bool DisableDiscoveryAutostart { get; set; }

		[Export ("suspendSessionsWhenBackgrounded")]
		bool SuspendSessionsWhenBackgrounded { get; set; }

		// @property (readwrite, copy, nonatomic) GCKLaunchOptions * _Nullable launchOptions;
		[NullAllowed]
		[Export ("launchOptions", ArgumentSemantic.Copy)]
		LaunchOptions LaunchOptions { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable sharedContainerIdentifier;
		[NullAllowed]
		[Export ("sharedContainerIdentifier")]
		string SharedContainerIdentifier { get; set; }
	}

	// @interface GCKCastSession : GCKSession
	[BaseType (typeof (Session), Name = "GCKCastSession")]
	interface CastSession
	{
		// @property (readonly, assign, nonatomic) GCKActiveInputStatus activeInputStatus;
		[Export ("activeInputStatus", ArgumentSemantic.Assign)]
		ActiveInputStatus ActiveInputStatus { get; }

		// @property (readonly, assign, nonatomic) GCKStandbyStatus standbyStatus;
		[Export ("standbyStatus", ArgumentSemantic.Assign)]
		StandbyStatus StandbyStatus { get; }

		// @property (readonly, copy, nonatomic) GCKApplicationMetadata * _Nullable applicationMetadata;
		[NullAllowed]
		[Export ("applicationMetadata", ArgumentSemantic.Copy)]
		ApplicationMetadata ApplicationMetadata { get; }

		// -(instancetype _Nonnull)initWithDevice:(GCKDevice * _Nonnull)device sessionID:(NSString * _Nullable)sessionID castOptions:(GCKCastOptions * _Nonnull)castOptions __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithDevice:sessionID:castOptions:")]
		IntPtr Constructor (Device device, [NullAllowed] string sessionId, CastOptions castOptions);

		// -(BOOL)addChannel:(GCKCastChannel * _Nonnull)channel;
		[Export ("addChannel:")]
		bool AddChannel (CastChannel channel);

		// -(BOOL)removeChannel:(GCKCastChannel * _Nonnull)channel;
		[Export ("removeChannel:")]
		bool RemoveChannel (CastChannel channel);

		// -(void)addDeviceStatusListener:(id<GCKCastDeviceStatusListener> _Nonnull)listener;
		[Export ("addDeviceStatusListener:")]
		void AddDeviceStatusListener (ICastDeviceStatusListener listener);

		// -(void)removeDeviceStatusListener:(id<GCKCastDeviceStatusListener> _Nonnull)listener;
		[Export ("removeDeviceStatusListener:")]
		void RemoveDeviceStatusListener (ICastDeviceStatusListener listener);

		// -(GCKRequest * _Nonnull)setDeviceVolume:(float)volume forMultizoneDevice:(GCKMultizoneDevice * _Nonnull)device;
		[Export ("setDeviceVolume:forMultizoneDevice:")]
		Request SetDeviceVolume (float volume, MultizoneDevice device);

		// -(GCKRequest * _Nonnull)setDeviceMuted:(BOOL)muted forMultizoneDevice:(GCKMultizoneDevice * _Nonnull)device;
		[Export ("setDeviceMuted:forMultizoneDevice:")]
		Request SetDeviceMuted (bool muted, MultizoneDevice device);

		// -(GCKRequest * _Nonnull)requestMultizoneStatus;
		[return: NullAllowed]
		[Export ("requestMultizoneStatus")]
		Request RequestMultizoneStatus ();
	}

	interface ICastDeviceStatusListener
	{
	}

	// @protocol GCKCastDeviceStatusListener <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKCastDeviceStatusListener")]
	interface CastDeviceStatusListener
	{
		// @optional -(void)castSession:(GCKCastSession * _Nonnull)castSession didReceiveActiveInputStatus:(GCKActiveInputStatus)activeInputStatus;
		[Export ("castSession:didReceiveActiveInputStatus:")]
		void DidReceiveActiveInputStatus (CastSession castSession, ActiveInputStatus activeInputStatus);

		// @optional -(void)castSession:(GCKCastSession * _Nonnull)castSession didReceiveStandbyStatus:(GCKStandbyStatus)standbyStatus;
		[Export ("castSession:didReceiveStandbyStatus:")]
		void DidReceiveStandbyStatus (CastSession castSession, StandbyStatus standbyStatus);

		// @optional -(void)castSession:(GCKCastSession * _Nonnull)castSession didReceiveMultizoneStatus:(GCKMultizoneStatus * _Nonnull)multizoneStatus;
		[Export ("castSession:didReceiveMultizoneStatus:")]
		void DidReceiveMultizoneStatus (CastSession castSession, MultizoneStatus multizoneStatus);

		// @optional -(void)castSession:(GCKCastSession * _Nonnull)castSession didAddMultizoneDevice:(GCKMultizoneDevice * _Nonnull)device;
		[Export ("castSession:didAddMultizoneDevice:")]
		void DidAddMultizoneDevice (CastSession castSession, MultizoneDevice device);

		// @optional -(void)castSession:(GCKCastSession * _Nonnull)castSession didUpdateMultizoneDevice:(GCKMultizoneDevice * _Nonnull)device;
		[Export ("castSession:didUpdateMultizoneDevice:")]
		void DidUpdateMultizoneDevice (CastSession castSession, MultizoneDevice device);

		// @optional -(void)castSession:(GCKCastSession * _Nonnull)castSession didRemoveMultizoneDeviceWithID:(NSString * _Nonnull)deviceID;
		[Export ("castSession:didRemoveMultizoneDeviceWithID:")]
		void DidRemoveMultizoneDevice (CastSession castSession, string deviceId);
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
		ushort ServicePort { get; }

		[Export ("deviceID", ArgumentSemantic.Copy)]
		string DeviceId { get; }

		[NullAllowed]
		[Export ("friendlyName", ArgumentSemantic.Copy)]
		string FriendlyName { get; set; }

		[NullAllowed]
		[Export ("manufacturer", ArgumentSemantic.Copy)]
		string Manufacturer { get; set; }

		[NullAllowed]
		[Export ("modelName", ArgumentSemantic.Copy)]
		string ModelName { get; set; }

		[NullAllowed]
		[Export ("icons", ArgumentSemantic.Copy)]
		Image [] Icons { get; set; }

		[Export ("status", ArgumentSemantic.Assign)]
		DeviceStatus Status { get; set; }

		[NullAllowed]
		[Export ("statusText", ArgumentSemantic.Copy)]
		string StatusText { get; set; }

		[NullAllowed]
		[Export ("deviceVersion", ArgumentSemantic.Copy)]
		string DeviceVersion { get; set; }

		[Export ("isOnLocalNetwork", ArgumentSemantic.Assign)]
		bool IsOnLocalNetwork { get; }

		// @property(nonatomic, assign, readonly) GCKDeviceType type;
		[Export ("type", ArgumentSemantic.Assign)]
		DeviceType Type { get; }

		// @property (nonatomic, copy, readonly) NSString* category;
		[Export ("category", ArgumentSemantic.Copy)]
		string Category { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull uniqueID;
		[Export ("uniqueID")]
		string UniqueID { get; }

		[Export ("isSameDeviceAs:")]
		bool SameDevice (Device device);

		[Export ("hasCapabilities:")]
		bool HasCapabilities (nint deviceCapabilities);

		[Export ("setAttribute:forKey:")]
		void SetAttribute (INSCoding attribute, string key);

		[return: NullAllowed]
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
		// @property (readonly, assign, nonatomic) BOOL ignoreAppStateNotifications;
		[Export ("ignoreAppStateNotifications")]
		bool IgnoreAppStateNotifications { get; }

		[Export ("connectionState", ArgumentSemantic.Assign)]
		ConnectionState ConnectionState { get; }

		[Export ("applicationConnectionState", ArgumentSemantic.Assign)]
		ConnectionState ApplicationConnectionState { get; }

		[Obsolete ("Use ConnectionState property instead.")]
		[Export ("isConnected", ArgumentSemantic.Assign)]
		bool IsConnected { get; }

		[Obsolete ("Use ApplicationConnectionState property instead.")]
		[Export ("isConnectedToApp", ArgumentSemantic.Assign)]
		bool IsConnectedToApp { get; }

		[Export ("isReconnecting", ArgumentSemantic.Assign)]
		bool IsReconnecting { get; }

		[Export ("reconnectTimeout", ArgumentSemantic.Assign)]
		double ReconnectTimeout { get; set; }

		[Export ("device", ArgumentSemantic.Assign)]
		Device Device { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Assign)]
		IDeviceManagerDelegate Delegate { get; set; }

		[Export ("deviceVolume", ArgumentSemantic.Assign)]
		float DeviceVolume { get; }

		[Export ("deviceMuted", ArgumentSemantic.Assign)]
		bool DeviceMuted { get; }

		[Export ("activeInputStatus", ArgumentSemantic.Assign)]
		ActiveInputStatus ActiveInputStatus { get; }

		[Export ("standbyStatus", ArgumentSemantic.Assign)]
		StandbyStatus StandbyStatus { get; }

		[NullAllowed]
		[Export ("applicationSessionID", ArgumentSemantic.Copy)]
		string ApplicationSessionID { get; }

		[NullAllowed]
		[Export ("applicationMetadata", ArgumentSemantic.Copy)]
		ApplicationMetadata ApplicationMetadata { get; }

		[NullAllowed]
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
		nint LaunchApplication (string applicationId, [NullAllowed] LaunchOptions launchOptions);

		[Obsolete ("Use LaunchApplication (string, LaunchingOptions) method instead.")]
		[Export ("launchApplication:relaunchIfRunning:")]
		nint LaunchApplication (string applicationId, bool relaunchIfRunning);

		[Export ("joinApplication:")]
		nint JoinApplication ([NullAllowed] string applicationId);

		[Export ("joinApplication:sessionID:")]
		nint JoinApplication (string applicationId, string sessionId);

		[Export ("leaveApplication")]
		bool LeaveApplication ();

		[Export ("stopApplication")]
		nint StopApplication ();

		[Export ("stopApplicationWithSessionID:")]
		nint StopApplication ([NullAllowed] string sessionId);

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
		void DidDisconnect (DeviceManager deviceManager, [NullAllowed] NSError error);

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
		void DidDisconnectFromApplication (DeviceManager deviceManager, [NullAllowed] NSError error);

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
		void DidReceiveApplicationMetadata (DeviceManager deviceManager, [NullAllowed] ApplicationMetadata metadata);

		[EventArgs ("DeviceManagerApplicationStatusTextReceived")]
		[EventName ("ApplicationStatusTextReceived")]
		[Export ("deviceManager:didReceiveApplicationStatusText:")]
		void DidReceiveApplicationStatusText (DeviceManager deviceManager, [NullAllowed] string status);

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

	// @interface GCKDeviceProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKDeviceProvider")]
	interface DeviceProvider
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull deviceCategory;
		[Export ("deviceCategory")]
		string DeviceCategory { get; }

		// @property (assign, readwrite, nonatomic) BOOL passiveScan;
		[Export ("passiveScan")]
		bool PassiveScan { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<GCKDevice *> * _Nonnull devices;
		[Export ("devices", ArgumentSemantic.Copy)]
		Device [] Devices { get; }

		// -(instancetype _Nonnull)initWithDeviceCategory:(NSString * _Nonnull)deviceCategory;
		[Export ("initWithDeviceCategory:")]
		IntPtr Constructor (string deviceCategory);

		// -(void)startDiscovery;
		[Export ("startDiscovery")]
		void StartDiscovery ();

		// -(void)stopDiscovery;
		[Export ("stopDiscovery")]
		void StopDiscovery ();

		// -(GCKSession * _Nonnull)createSessionForDevice:(GCKDevice * _Nonnull)device sessionID:(NSString * _Nullable)sessionID;
		[Export ("createSessionForDevice:sessionID:")]
		Session CreateSessionForDevice (Device device, [NullAllowed] string sessionId);
	}

	// @interface Protected (GCKDeviceProvider)
	[Category]
	[BaseType (typeof (DeviceProvider))]
	interface DeviceProvider_Protected
	{
		// -(void)notifyDidStartDiscovery;
		[Export ("notifyDidStartDiscovery")]
		void NotifyDidStartDiscovery ();

		// -(void)notifyDidPublishDevice:(GCKDevice * _Nonnull)device;
		[Export ("notifyDidPublishDevice:")]
		void NotifyDidPublishDevice (Device device);

		// -(void)notifyDidUnpublishDevice:(GCKDevice * _Nonnull)device;
		[Export ("notifyDidUnpublishDevice:")]
		void NotifyDidUnpublishDevice (Device device);

		// -(void)notifyDidUpdateDevice:(GCKDevice * _Nonnull)device;
		[Export ("notifyDidUpdateDevice:")]
		void NotifyDidUpdateDevice (Device device);

		// -(GCKDevice * _Nonnull)createDeviceWithID:(NSString * _Nonnull)deviceID ipAddress:(NSString * _Nonnull)ipAddress servicePort:(uint16_t)servicePort;
		[Export ("createDeviceWithID:ipAddress:servicePort:")]
		Device CreateDevice (string deviceId, string ipAddress, ushort servicePort);
	}

	[Obsolete ("Use DiscoveryManager class to discover Cast receivers.")]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKDeviceScanner")]
	interface DeviceScanner
	{

		[Obsolete]
		[Export ("init")]
		IntPtr Constructor ();

		//- (instancetype)initWithFilterCriteria:(GCKFilterCriteria *)filterCriteria;
		[Export ("initWithFilterCriteria:")]
		IntPtr Constructor ([NullAllowed] FilterCriteria filterCriteria);

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

	[Obsolete ("Use DiscoveryManager and DiscoveryManagerListener to discover Cast receivers.")]
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

	// @interface GCKDiscoveryManager : NSObject
	[BaseType (typeof (NSObject), Name = "GCKDiscoveryManager")]
	interface DiscoveryManager
	{
		// extern NSString *const _Nonnull kGCKKeyHasDiscoveredDevices __attribute__((visibility("default")));
		[Field ("kGCKKeyHasDiscoveredDevices", "__Internal")]
		NSString KeyHasDiscoveredDevices { get; }

		// @property (readonly, assign, nonatomic) GCKDiscoveryState discoveryState;
		[Export ("discoveryState", ArgumentSemantic.Assign)]
		DiscoveryState DiscoveryState { get; }

		// @property (readonly, assign, nonatomic) BOOL hasDiscoveredDevices;
		[Export ("hasDiscoveredDevices")]
		bool HasDiscoveredDevices { get; }

		// @property (assign, readwrite, nonatomic) BOOL passiveScan;
		[Export ("passiveScan")]
		bool PassiveScan { get; set; }

		[Export ("discoveryActive")]
		bool DiscoveryActive { get; }

		// @property (readonly, assign, nonatomic) NSUInteger deviceCount;
		[Export ("deviceCount")]
		nuint DeviceCount { get; }

		// -(void)addListener:(id<GCKDiscoveryManagerListener> _Nonnull)listener;
		[Export ("addListener:")]
		void AddListener (IDiscoveryManagerListener listener);

		// -(void)removeListener:(id<GCKDiscoveryManagerListener> _Nonnull)listener;
		[Export ("removeListener:")]
		void RemoveListener (IDiscoveryManagerListener listener);

		// -(void)startDiscovery;
		[Export ("startDiscovery")]
		void StartDiscovery ();

		// -(void)stopDiscovery;
		[Export ("stopDiscovery")]
		void StopDiscovery ();

		// -(BOOL)isDiscoveryActiveForDeviceCategory:(NSString * _Nonnull)deviceCategory;
		[Export ("isDiscoveryActiveForDeviceCategory:")]
		bool IsDiscoveryActiveForDeviceCategory (string deviceCategory);

		// -(GCKDevice * _Nonnull)deviceAtIndex:(NSUInteger)index;
		[Export ("deviceAtIndex:")]
		Device GetDevice (nuint index);

		// -(GCKDevice * _Nullable)deviceWithUniqueID:(NSString * _Nonnull)uniqueID;
		[return: NullAllowed]
		[Export ("deviceWithUniqueID:")]
		Device GetDevice (string uniqueID);
	}

	interface IDiscoveryManagerListener
	{
	}

	// @protocol GCKDiscoveryManagerListener <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject))]
	interface DiscoveryManagerListener
	{
		// @optional -(void)didStartDiscoveryForDeviceCategory:(NSString * _Nonnull)deviceCategory;
		[Export ("didStartDiscoveryForDeviceCategory:")]
		void DidStartDiscoveryForDeviceCategory (string deviceCategory);

		// @optional -(void)willUpdateDeviceList;
		[Export ("willUpdateDeviceList")]
		void WillUpdateDeviceList ();

		// @optional -(void)didUpdateDeviceList;
		[Export ("didUpdateDeviceList")]
		void DidUpdateDeviceList ();

		// @optional -(void)didInsertDevice:(GCKDevice * _Nonnull)device atIndex:(NSUInteger)index;
		[Export ("didInsertDevice:atIndex:")]
		void DidInsertDevice (Device device, nuint index);

		// @optional -(void)didUpdateDevice:(GCKDevice * _Nonnull)device atIndex:(NSUInteger)index;
		[Export ("didUpdateDevice:atIndex:")]
		void DidUpdateDevice (Device device, nuint index);

		// @optional -(void)didUpdateDevice:(GCKDevice * _Nonnull)device atIndex:(NSUInteger)index andMoveToIndex:(NSUInteger)newIndex;
		[Export ("didUpdateDevice:atIndex:andMoveToIndex:")]
		void DidUpdateDevice (Device device, nuint index, nuint newIndex);

		// @optional -(void)didRemoveDeviceAtIndex:(NSUInteger)index;
		[Export ("didRemoveDeviceAtIndex:")]
		void DidRemoveDevice (nuint index);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSError), Name = "GCKError")]
	interface Error
	{

		[Field ("kGCKErrorCustomDataKey", "__Internal")]
		NSString CustomDataKey { get; }

		[Field ("kGCKErrorDomain", "__Internal")]
		NSString Domain { get; }

		// +(GCKError * _Nonnull)errorWithCode:(GCKErrorCode)code;
		[Static]
		[Export ("errorWithCode:")]
		Error From (ErrorCode code);

		// +(GCKError * _Nonnull)errorWithCode:(GCKErrorCode)code customData:(id _Nullable)customData;
		[Static]
		[Export ("errorWithCode:customData:")]
		Error From (ErrorCode code, [NullAllowed] NSObject customData);

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

	// @interface GCKGameManagerChannel : GCKCastChannel
	[BaseType (typeof (CastChannel),
		   Name = "GCKGameManagerChannel",
		   Delegates = new string [] { "Delegate" },
		   Events = new Type [] { typeof (GameManagerChannelDelegate) })]
	interface GameManagerChannel
	{
		// @property (readwrite, nonatomic, weak) id<GCKGameManagerChannelDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IGameManagerChannelDelegate Delegate { get; set; }

		// @property (readonly, nonatomic, strong) GCKGameManagerState * _Nullable currentState;
		[NullAllowed]
		[Export ("currentState", ArgumentSemantic.Strong)]
		GameManagerState CurrentState { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable lastUsedPlayerID;
		[NullAllowed]
		[Export ("lastUsedPlayerID")]
		string LastUsedPlayerId { get; }

		// @property (readonly, assign, nonatomic) BOOL isInitialConnectionEstablished;
		[Export ("isInitialConnectionEstablished")]
		bool IsInitialConnectionEstablished { get; }

		// -(instancetype _Nonnull)initWithSessionID:(NSString * _Nonnull)castSessionID __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithSessionID:")]
		IntPtr Constructor (string castSessionId);

		// -(NSInteger)sendPlayerAvailableRequest:(id _Nullable)extraData;
		[Export ("sendPlayerAvailableRequest:")]
		nint SendPlayerAvailableRequest ([NullAllowed] NSObject extraData);

		// -(NSInteger)sendPlayerAvailableRequest:(id _Nullable)extraData playerID:(NSString * _Nonnull)playerID;
		[Export ("sendPlayerAvailableRequest:playerID:")]
		nint SendPlayerAvailableRequest ([NullAllowed] NSObject extraData, string playerId);

		// -(NSInteger)sendPlayerReadyRequest:(id _Nullable)extraData;
		[Export ("sendPlayerReadyRequest:")]
		nint SendPlayerReadyRequest ([NullAllowed] NSObject extraData);

		// -(NSInteger)sendPlayerReadyRequest:(id _Nullable)extraData playerID:(NSString * _Nonnull)playerID;
		[Export ("sendPlayerReadyRequest:playerID:")]
		nint SendPlayerReadyRequest ([NullAllowed] NSObject extraData, string playerId);

		// -(NSInteger)sendPlayerPlayingRequest:(id _Nullable)extraData;
		[Export ("sendPlayerPlayingRequest:")]
		nint SendPlayerPlayingRequest ([NullAllowed] NSObject extraData);

		// -(NSInteger)sendPlayerPlayingRequest:(id _Nullable)extraData playerID:(NSString * _Nonnull)playerID;
		[Export ("sendPlayerPlayingRequest:playerID:")]
		nint SendPlayerPlayingRequest ([NullAllowed] NSObject extraData, string playerId);

		// -(NSInteger)sendPlayerIdleRequest:(id _Nullable)extraData;
		[Export ("sendPlayerIdleRequest:")]
		nint SendPlayerIdleRequest ([NullAllowed] NSObject extraData);

		// -(NSInteger)sendPlayerIdleRequest:(id _Nullable)extraData playerID:(NSString * _Nonnull)playerID;
		[Export ("sendPlayerIdleRequest:playerID:")]
		nint SendPlayerIdleRequest ([NullAllowed] NSObject extraData, string playerId);

		// -(NSInteger)sendPlayerQuitRequest:(id _Nullable)extraData;
		[Export ("sendPlayerQuitRequest:")]
		nint SendPlayerQuitRequest ([NullAllowed] NSObject extraData);

		// -(NSInteger)sendPlayerQuitRequest:(id _Nullable)extraData playerID:(NSString * _Nonnull)playerID;
		[Export ("sendPlayerQuitRequest:playerID:")]
		nint SendPlayerQuitRequest ([NullAllowed] NSObject extraData, string playerId);

		// -(NSInteger)sendGameRequest:(id _Nullable)extraData;
		[Export ("sendGameRequest:")]
		nint SendGameRequest ([NullAllowed] NSObject extraData);

		// -(NSInteger)sendGameRequest:(id _Nullable)extraData playerID:(NSString * _Nonnull)playerID;
		[Export ("sendGameRequest:playerID:")]
		nint SendGameRequest ([NullAllowed] NSObject extraData, string playerId);

		// -(void)sendGameMessage:(id _Nullable)extraData;
		[Export ("sendGameMessage:")]
		void SendGameMessage ([NullAllowed] NSObject extraData);

		// -(void)sendGameMessage:(id _Nullable)extraData playerID:(NSString * _Nonnull)playerID;
		[Export ("sendGameMessage:playerID:")]
		void SendGameMessage ([NullAllowed] NSObject extraData, string playerIs);
	}

	interface IGameManagerChannelDelegate
	{
	}

	// @protocol GCKGameManagerChannelDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKGameManagerChannelDelegate")]
	interface GameManagerChannelDelegate
	{
		// @required -(void)gameManagerChannel:(GCKGameManagerChannel * _Nonnull)gameManagerChannel stateDidChangeTo:(GCKGameManagerState * _Nonnull)currentState from:(GCKGameManagerState * _Nonnull)previousState;
		[Abstract]
		[EventArgs ("GameManagerChannelStateChanged")]
		[EventName ("StateChanged")]
		[Export ("gameManagerChannel:stateDidChangeTo:from:")]
		void StateDidChange (GameManagerChannel gameManagerChannel, GameManagerState currentState, GameManagerState previousState);

		// @required -(void)gameManagerChannel:(GCKGameManagerChannel * _Nonnull)gameManagerChannel didReceiveGameMessage:(id _Nonnull)gameMessage forPlayerID:(NSString * _Nonnull)playerID;
		[Abstract]
		[EventArgs ("GameManagerChannelGameMessageReceived")]
		[EventName ("GameMessageReceived")]
		[Export ("gameManagerChannel:didReceiveGameMessage:forPlayerID:")]
		void DidReceiveGameMessage (GameManagerChannel gameManagerChannel, NSObject gameMessage, string playerId);

		// @required -(void)gameManagerChannel:(GCKGameManagerChannel * _Nonnull)gameManagerChannel requestDidSucceedWithID:(NSInteger)requestID result:(GCKGameManagerResult * _Nonnull)result;
		[Abstract]
		[EventArgs ("GameManagerChannelRequestSucceed")]
		[EventName ("RequestSucceed")]
		[Export ("gameManagerChannel:requestDidSucceedWithID:result:")]
		void RequestDidSucceed (GameManagerChannel gameManagerChannel, nint requestId, GameManagerResult result);

		// @required -(void)gameManagerChannel:(GCKGameManagerChannel * _Nonnull)gameManagerChannel requestDidFailWithID:(NSInteger)requestID error:(GCKError * _Nonnull)error;
		[Abstract]
		[EventArgs ("GameManagerChannelRequestFailed")]
		[EventName ("RequestFailed")]
		[Export ("gameManagerChannel:requestDidFailWithID:error:")]
		void RequestDidFail (GameManagerChannel gameManagerChannel, nint requestId, Error error);

		// @required -(void)gameManagerChannelDidConnect:(GCKGameManagerChannel * _Nonnull)gameManagerChannel;
		[Abstract]
		[EventArgs ("GameManagerChannelConnected")]
		[EventName ("Connected")]
		[Export ("gameManagerChannelDidConnect:")]
		void DidConnect (GameManagerChannel gameManagerChannel);

		// @required -(void)gameManagerChannel:(GCKGameManagerChannel * _Nonnull)gameManagerChannel didFailToConnectWithError:(GCKError * _Nonnull)error;
		[Abstract]
		[EventArgs ("GameManagerChannelConnectFailed")]
		[EventName ("ConnectFailed")]
		[Export ("gameManagerChannel:didFailToConnectWithError:")]
		void DidFailToConnect (GameManagerChannel gameManagerChannel, Error error);
	}

	// @interface GCKGameManagerResult : NSObject
	[BaseType (typeof (NSObject), Name = "GCKGameManagerResult")]
	interface GameManagerResult
	{
		// @property (readonly, assign, nonatomic) NSInteger requestID;
		[Export ("requestID")]
		nint RequestId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull playerID;
		[Export ("playerID")]
		string PlayerId { get; }

		// @property (readonly, copy, nonatomic) id _Nonnull extraData;
		[Export ("extraData", ArgumentSemantic.Copy)]
		NSObject ExtraData { get; }
	}

	// @interface GCKGameManagerState : NSObject
	[BaseType (typeof (NSObject), Name = "GCKGameManagerState")]
	interface GameManagerState
	{
		// @property (readonly, assign, nonatomic) GCKLobbyState lobbyState;
		[Export ("lobbyState", ArgumentSemantic.Assign)]
		LobbyState LobbyState { get; }

		// @property (readonly, assign, nonatomic) GCKGameplayState gameplayState;
		[Export ("gameplayState", ArgumentSemantic.Assign)]
		GameplayState GameplayState { get; }

		// @property (readonly, copy, nonatomic) id _Nullable gameData;
		[NullAllowed]
		[Export ("gameData", ArgumentSemantic.Copy)]
		NSObject GameData { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable gameStatusText;
		[NullAllowed]
		[Export ("gameStatusText")]
		string GameStatusText { get; }

		// @property (readonly, nonatomic, strong) NSArray<GCKPlayerInfo *> * _Nonnull players;
		[Export ("players", ArgumentSemantic.Strong)]
		PlayerInfo [] Players { get; }

		// @property (readonly, nonatomic) NSArray<GCKPlayerInfo *> * _Nonnull controllablePlayers;
		[Export ("controllablePlayers")]
		PlayerInfo [] ControllablePlayers { get; }

		// @property (readonly, nonatomic, strong) NSArray<GCKPlayerInfo *> * _Nonnull connectedPlayers;
		[Export ("connectedPlayers", ArgumentSemantic.Strong)]
		PlayerInfo [] ConnectedPlayers { get; }

		// @property (readonly, nonatomic, strong) NSArray<GCKPlayerInfo *> * _Nonnull connectedControllablePlayers;
		[Export ("connectedControllablePlayers", ArgumentSemantic.Strong)]
		PlayerInfo [] ConnectedControllablePlayers { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable applicationName;
		[NullAllowed]
		[Export ("applicationName")]
		string ApplicationName { get; }

		// @property (readonly, assign, nonatomic) NSInteger maxPlayers;
		[Export ("maxPlayers")]
		nint MaxPlayers { get; }

		// -(GCKPlayerInfo * _Nullable)getPlayer:(NSString * _Nonnull)playerID;
		[return: NullAllowed]
		[Export ("getPlayer:")]
		PlayerInfo GetPlayer (string playerId);

		// -(NSArray<GCKPlayerInfo *> * _Nonnull)getPlayersInState:(GCKPlayerState)playerState;
		[Export ("getPlayersInState:")]
		PlayerInfo [] GetPlayers (PlayerState playerState);

		// -(BOOL)hasLobbyStateChanged:(GCKGameManagerState * _Nonnull)otherState;
		[Export ("hasLobbyStateChanged:")]
		bool HasLobbyStateChanged (GameManagerState otherState);

		// -(BOOL)hasGameplayStateChanged:(GCKGameManagerState * _Nonnull)otherState;
		[Export ("hasGameplayStateChanged:")]
		bool HasGameplayStateChanged (GameManagerState otherState);

		// -(BOOL)hasGameDataChanged:(GCKGameManagerState * _Nonnull)otherState;
		[Export ("hasGameDataChanged:")]
		bool HasGameDataChanged (GameManagerState otherState);

		// -(BOOL)hasGameStatusTextChanged:(GCKGameManagerState * _Nonnull)otherState;
		[Export ("hasGameStatusTextChanged:")]
		bool HasGameStatusTextChanged (GameManagerState otherState);

		// -(BOOL)hasPlayerChanged:(NSString * _Nonnull)playerId otherState:(GCKGameManagerState * _Nonnull)otherState;
		[Export ("hasPlayerChanged:otherState:")]
		bool HasPlayerChanged (string playerId, GameManagerState otherState);

		// -(BOOL)hasPlayerStateChanged:(NSString * _Nonnull)playerId otherState:(GCKGameManagerState * _Nonnull)otherState;
		[Export ("hasPlayerStateChanged:otherState:")]
		bool HasPlayerStateChanged (string playerId, GameManagerState otherState);

		// -(BOOL)hasPlayerDataChanged:(NSString * _Nonnull)playerId otherState:(GCKGameManagerState * _Nonnull)otherState;
		[Export ("hasPlayerDataChanged:otherState:")]
		bool HasPlayerDataChanged (string playerId, GameManagerState otherState);

		// -(NSArray<NSString *> * _Nonnull)getListOfChangedPlayers:(GCKGameManagerState * _Nonnull)otherState;
		[Export ("getListOfChangedPlayers:")]
		string [] GetListOfChangedPlayers (GameManagerState otherState);
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
		[return: NullAllowed]
		[Export ("parseJSON:")]
		NSObject ParseJson (string json);

		[Static]
		[return: NullAllowed]
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
		[NullAllowed]
		[Export ("languageCode", ArgumentSemantic.Copy)]
		string LanguageCode { get; set; }

		[Export ("relaunchIfRunning")]
		bool RelaunchIfRunning { get; set; }

		[Export ("initWithRelaunchIfRunning:")]
		IntPtr Constructor (bool relaunchIfRunning);

		[Export ("initWithLanguageCode:relaunchIfRunning:")]
		IntPtr Constructor ([NullAllowed] string languageCode, bool relaunchIfRunning);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKLogger")]
	interface Logger
	{

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		ILoggerDelegate Delegate { get; set; }

		// @property (readwrite, nonatomic, strong) GCKLoggerFilter * _Nullable filter;
		[NullAllowed]
		[Export ("filter", ArgumentSemantic.Strong)]
		LoggerFilter Filter { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL loggingEnabled;
		[Export ("loggingEnabled")]
		bool LoggingEnabled { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL fileLoggingEnabled;
		[Export ("fileLoggingEnabled")]
		bool FileLoggingEnabled { get; set; }

		// @property (assign, readwrite, nonatomic) unsigned long long maxLogFileSize;
		[Export ("maxLogFileSize")]
		ulong MaxLogFileSize { get; set; }

		// @property (assign, readwrite, nonatomic) NSUInteger maxLogFileCount;
		[Export ("maxLogFileCount")]
		nuint MaxLogFileCount { get; set; }

		// @property (assign, readwrite, nonatomic) GCKLoggerLevel minimumLevel;
		[Export ("minimumLevel", ArgumentSemantic.Assign)]
		LoggerLevel MinimumLevel { get; set; }

		[Static]
		[Export ("sharedInstance")]
		Logger SharedInstance { get; }

		[Internal]
		[Export ("logFromFunction:message:")]
		void _Log ([PlainString] string function, string message);
	}

	interface ILoggerDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKLoggerDelegate")]
	interface LoggerDelegate
	{
		[Export ("logFromFunction:message:")]
		void _Log (IntPtr function, string message);

		// @optional -(void)logMessage:(NSString * _Nonnull)message fromFunction:(NSString * _Nonnull)function;
		[Export ("logMessage:fromFunction:")]
		void LogMessage (string message, string function);
	}

	// @interface GCKLoggerFilter : NSObject
	[BaseType (typeof (NSObject), Name = "GCKLoggerFilter")]
	interface LoggerFilter
	{
		// @property (assign, readwrite, nonatomic) GCKLoggerLevel minimumLevel;
		[Export ("minimumLevel", ArgumentSemantic.Assign)]
		LoggerLevel MinimumLevel { get; set; }

		// -(void)setLoggingLevel:(GCKLoggerLevel)minimumLevel forClasses:(NSArray<NSString *> * _Nonnull)classNames;
		[Export ("setLoggingLevel:forClasses:")]
		void SetLoggingLevelForClasses (LoggerLevel minimumLevel, string [] classNames);

		// -(void)setLoggingLevel:(GCKLoggerLevel)minimumLevel forFunctions:(NSArray<NSString *> * _Nonnull)functionNames;
		[Export ("setLoggingLevel:forFunctions:")]
		void SetLoggingLevelForFunctions (LoggerLevel minimumLevel, string [] functionNames);

		// -(void)addMessagePatterns:(NSArray<NSString *> * _Nonnull)messagePatterns;
		[Export ("addMessagePatterns:")]
		void AddMessagePatterns (string [] messagePatterns);

		// -(void)reset;
		[Export ("reset")]
		void Reset ();
	}

	[Obsolete ("Use the RemoteMediaClient to control media playback.")]
	[BaseType (typeof (CastChannel),
		Name = "GCKMediaControlChannel",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (MediaControlChannelDelegate) })]
	interface MediaControlChannel
	{
		// extern NSString *const _Nonnull kGCKMediaDefaultReceiverApplicationID __attribute__((visibility("default")));
		[Field ("kGCKMediaDefaultReceiverApplicationID", "__Internal")]
		NSString DefaultReceiverApplicationID { get; }

		[NullAllowed]
		[Export ("mediaStatus", ArgumentSemantic.Strong)]
		MediaStatus MediaStatus { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval timeSinceLastMediaStatusUpdate;
		[Export ("timeSinceLastMediaStatusUpdate")]
		double TimeSinceLastMediaStatusUpdate { get; }

		[NullAllowed]
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

		[Internal]
		[Export ("loadMedia:autoplay:playPosition:activeTrackIDs:")]
		nint _LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSArray activeTrackIDs);

		[Internal]
		[Export ("loadMedia:autoplay:playPosition:activeTrackIDs:customData:")]
		nint _LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSArray activeTrackIDs, [NullAllowed] NSObject customData);

		[Internal]
		[Export ("setActiveTrackIDs:")]
		nint _SetActiveTrackIDs ([NullAllowed] NSArray activeTrackIDs);

		[Export ("setTextTrackStyle:")]
		nint SetTextTrackStyle ([NullAllowed] MediaTextTrackStyle textTrackStyle);

		[Export ("pause")]
		nint Pause ();

		[Export ("pauseWithCustomData:")]
		nint Pause ([NullAllowed] NSObject customData);

		[Export ("stop")]
		nint Stop ();

		[Export ("stopWithCustomData:")]
		nint Stop ([NullAllowed] NSObject customData);

		[Export ("play")]
		nint Play ();

		[Export ("playWithCustomData:")]
		nint Play ([NullAllowed] NSObject customData);

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
		nint QueueInsertItems (MediaQueueItem [] queueItems, nuint beforeItemID, [NullAllowed] NSObject customData);

		[Export ("queueInsertItem:beforeItemWithID:")]
		nint QueueInsertItem (MediaQueueItem item, nuint beforeItemID);

		[Export ("queueInsertAndPlayItem:beforeItemWithID:")]
		nint QueueInsertItemAndPlay (MediaQueueItem item, nuint beforeItemID);

		[Export ("queueInsertAndPlayItem:beforeItemWithID:playPosition:customData:")]
		nint QueueInsertItemAndPlay (MediaQueueItem item, nuint beforeItemID, double playPosition, [NullAllowed] NSObject customData);

		[Export ("queueUpdateItems:")]
		nint QueueUpdateItems (MediaQueueItem [] queueItems);

		[Export ("queueUpdateItems:customData:")]
		nint QueueUpdateItems (MediaQueueItem [] queueItems, [NullAllowed] NSObject customData);

		[Internal]
		[Export ("queueRemoveItemsWithIDs:")]
		nint _QueueRemoveItems (NSArray itemIDs);

		[Internal]
		[Export ("queueRemoveItemsWithIDs:customData:")]
		nint _QueueRemoveItems (NSArray itemIDs, [NullAllowed] NSObject customData);

		[Export ("queueRemoveItemWithID:")]
		nint QueueRemoveItem (nuint itemID);

		[Internal]
		[Export ("queueReorderItemsWithIDs:insertBeforeItemWithID:")]
		nint _QueueReorderItems (NSArray queueItemIDs, nuint beforeItemID);

		[Internal]
		[Export ("queueReorderItemsWithIDs:insertBeforeItemWithID:customData:")]
		nint _QueueReorderItems (NSArray queueItemIDs, nuint beforeItemID, [NullAllowed] NSObject customData);

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
		nint SetStreamVolume (float volume, [NullAllowed] NSObject customData);

		[Export ("setStreamMuted:")]
		nint SetStreamMuted (bool muted);

		[Export ("setStreamMuted:customData:")]
		nint SetStreamMuted (bool muted, [NullAllowed] NSObject customData);

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
		void DidFailToLoadMedia (MediaControlChannel mediaControlChannel, Error error);

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
		void RequestDidFail (MediaControlChannel mediaControlChannel, nint requestId, Error error);

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

		// @property (readonly, copy, nonatomic) NSArray<GCKAdBreakInfo *> * _Nullable adBreaks;
		[NullAllowed]
		[Export ("adBreaks", ArgumentSemantic.Copy)]
		AdBreakInfo [] AdBreaks { get; }

		// @property (readonly, copy, nonatomic) NSArray<GCKAdBreakClipInfo *> * _Nullable adBreakClips;
		[NullAllowed]
		[Export ("adBreakClips", ArgumentSemantic.Copy)]
		AdBreakClipInfo [] AdBreakClips { get; }

		[Export ("streamDuration", ArgumentSemantic.Assign)]
		double StreamDuration { get; }

		[NullAllowed]
		[Export ("mediaTracks", ArgumentSemantic.Copy)]
		MediaTrack [] MediaTracks { get; }

		[NullAllowed]
		[Export ("textTrackStyle", ArgumentSemantic.Copy)]
		MediaTextTrackStyle TextTrackStyle { get; }

		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; }

		[Export ("initWithContentID:streamType:contentType:metadata:streamDuration:mediaTracks:textTrackStyle:customData:")]
		IntPtr Constructor (string contentID, MediaStreamType streamType, string contentType, [NullAllowed] MediaMetadata metadata, double streamDuration, [NullAllowed] MediaTrack [] mediaTracks, [NullAllowed] MediaTextTrackStyle textTrackStyle, [NullAllowed] NSObject customData);

		[Obsolete ("Use MediaInformation (string, MediaStreamType, string, MediaMetadata, double, MediaTrack [], MediaTextTrackStyle, NSObject) constructor instead.")]
		[Export ("initWithContentID:streamType:contentType:metadata:streamDuration:customData:")]
		IntPtr Constructor (string contentID, MediaStreamType streamType, string contentType, [NullAllowed] MediaMetadata metadata, double streamDuration, [NullAllowed] NSObject customData);

		// -(GCKMediaTrack * _Nullable)mediaTrackWithID:(NSInteger)trackID;
		[return: NullAllowed]
		[Export ("mediaTrackWithID:")]
		MediaTrack GetMediaTrack (nint trackId);
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
		NSString Studio { get; }

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

		[return: NullAllowed]
		[Export ("objectForKey:")]
		NSObject ObjectForKey (string key);

		[Export ("setString:forKey:")]
		void SetString (string value, string Key);

		[return: NullAllowed]
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

		[return: NullAllowed]
		[Export ("dateForKey:")]
		NSDate DateForKey (string key);

		[return: NullAllowed]
		[Export ("dateAsStringForKey:")]
		string DateAsStringForKey (string key);
	}

	[BaseType (typeof (NSObject), Name = "GCKMediaQueueItem")]
	interface MediaQueueItem : INSCopying
	{
		// extern const NSUInteger kGCKMediaQueueInvalidItemID __attribute__((visibility("default")));
		[Field ("kGCKMediaQueueInvalidItemID", "__Internal")]
		nuint InvalidItemId { get; }

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
		[NullAllowed]
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
		[NullAllowed]
		[Export ("activeTrackIDs", ArgumentSemantic.Copy)]
		NSArray _ActiveTrackIDs { get; set; }

		//@property(nonatomic, copy, readwrite) id customData;
		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Copy)]
		NSObject CustomData { get; set; }

		[Export ("init")]
		IntPtr Constructor ();

		[Export ("initWithMediaQueueItem:")]
		IntPtr Constructor ([NullAllowed] MediaQueueItem item);

		[Export ("build")]
		MediaQueueItem Build ();
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

		// @property (readonly, assign, nonatomic) BOOL playingAd;
		[Export ("playingAd")]
		bool PlayingAd { get; }

		[Export ("idleReason", ArgumentSemantic.Assign)]
		MediaPlayerIdleReason IdleReason { get; }

		[Export ("playbackRate", ArgumentSemantic.Assign)]
		float PlaybackRate { get; }

		[NullAllowed]
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

		// @property (readonly, assign, nonatomic) BOOL queueHasCurrentItem;
		[Export ("queueHasCurrentItem")]
		bool QueueHasCurrentItem { get; }

		// @property (readonly, assign, nonatomic) GCKMediaQueueItem * _Nullable currentQueueItem;
		[NullAllowed]
		[Export ("currentQueueItem", ArgumentSemantic.Assign)]
		MediaQueueItem CurrentQueueItem { get; }

		// -(BOOL)queueHasNextItem;
		[Export ("queueHasNextItem")]
		bool QueueHasNextItem { get; }

		// @property (readonly, assign, nonatomic) GCKMediaQueueItem * _Nullable nextQueueItem;
		[NullAllowed]
		[Export ("nextQueueItem", ArgumentSemantic.Assign)]
		MediaQueueItem NextQueueItem { get; }

		// @property (readonly, assign, nonatomic) BOOL queueHasPreviousItem;
		[Export ("queueHasPreviousItem")]
		bool QueueHasPreviousItem { get; }

		// @property (readonly, assign, nonatomic) BOOL queueHasLoadingItem;
		[Export ("queueHasLoadingItem")]
		bool QueueHasLoadingItem { get; }

		[Export ("preloadedItemID", ArgumentSemantic.Assign)]
		nuint PreloadedItemID { get; }

		[Export ("loadingItemID", ArgumentSemantic.Assign)]
		nuint LoadingItemID { get; }

		[Internal]
		[NullAllowed]
		[Export ("activeTrackIDs", ArgumentSemantic.Assign)]
		NSArray _ActiveTrackIDs { get; }

		// @property (readonly, nonatomic, strong) GCKVideoInfo * _Nullable videoInfo;
		[NullAllowed]
		[Export ("videoInfo", ArgumentSemantic.Strong)]
		VideoInfo VideoInfo { get; }

		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; }

		// @property (readonly, nonatomic, strong) GCKAdBreakStatus * _Nullable adBreakStatus;
		[NullAllowed]
		[Export ("adBreakStatus", ArgumentSemantic.Strong)]
		AdBreakStatus AdBreakStatus { get; }

		[Export ("initWithSessionID:mediaInformation:")]
		IntPtr Constructor (nint mediaSessionID, [NullAllowed] MediaInformation mediaInformation);

		[Export ("isMediaCommandSupported:")]
		bool IsMediaCommandSupported (nint command);

		[Export ("queueItemCount")]
		nuint QueueItemCount { get; }

		[return: NullAllowed]
		[Export ("queueItemAtIndex:")]
		MediaQueueItem QueueItemAt (nuint index);

		[return: NullAllowed]
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

		[Export ("edgeType", ArgumentSemantic.Assign)]
		MediaTextTrackStyleEdgeType EdgeType { get; set; }

		[Export ("edgeColor", ArgumentSemantic.Copy)]
		Color EdgeColor { get; set; }

		[Export ("windowType", ArgumentSemantic.Assign)]
		MediaTextTrackStyleWindowType WindowType { get; set; }

		[Export ("windowColor", ArgumentSemantic.Copy)]
		Color WindowColor { get; set; }

		[Export ("windowRoundedCornerRadius")]
		nfloat WindowRoundedCornerRadius { get; set; }

		[NullAllowed]
		[Export ("fontFamily", ArgumentSemantic.Copy)]
		string FontFamily { get; set; }

		[Export ("fontGenericFamily", ArgumentSemantic.Assign)]
		MediaTextTrackStyleFontGenericFamily FontGenericFamily { get; set; }

		[Export ("fontStyle", ArgumentSemantic.Assign)]
		MediaTextTrackStyleFontStyle FontStyle { get; set; }

		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKMediaTrack")]
	interface MediaTrack : INSCopying, INSCoding
	{

		[Export ("initWithIdentifier:contentIdentifier:contentType:type:textSubtype:name:languageCode:customData:")]
		IntPtr Constructor (nint identifier, [NullAllowed] string contentIdentifier, string contentType, MediaTrackType type, MediaTextTrackSubtype textSubtype, [NullAllowed] string name, [NullAllowed] string languageCode, [NullAllowed] NSObject customData);

		[Export ("identifier")]
		nint Identifier { get; }

		[NullAllowed]
		[Export ("contentIdentifier", ArgumentSemantic.Copy)]
		string ContentIdentifier { get; }

		[Export ("contentType", ArgumentSemantic.Copy)]
		string ContentType { get; }

		[Export ("type", ArgumentSemantic.Assign)]
		MediaTrackType Type { get; }

		[Export ("textSubtype", ArgumentSemantic.Assign)]
		MediaTextTrackSubtype TextSubtype { get; }

		[NullAllowed]
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[NullAllowed]
		[Export ("languageCode", ArgumentSemantic.Copy)]
		string LanguageCode { get; }

		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Retain)]
		NSObject CustomData { get; }
	}

	// @interface GCKMultizoneDevice : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKMultizoneDevice")]
	interface MultizoneDevice : INSCopying
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull deviceID;
		[Export ("deviceID")]
		string DeviceId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull friendlyName;
		[Export ("friendlyName")]
		string FriendlyName { get; }

		// @property (assign, readwrite, nonatomic) NSInteger capabilities;
		[Export ("capabilities")]
		nint Capabilities { get; set; }

		// @property (assign, readwrite, nonatomic) float volumeLevel;
		[Export ("volumeLevel")]
		float VolumeLevel { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL muted;
		[Export ("muted")]
		bool Muted { get; set; }

		// -(instancetype _Nonnull)initWithJSONObject:(id _Nonnull)JSONObject;
		[Export ("initWithJSONObject:")]
		IntPtr Constructor (NSObject JSONObject);

		// -(instancetype _Nonnull)initWithDeviceID:(NSString * _Nonnull)deviceID friendlyName:(NSString * _Nonnull)friendlyName capabilities:(NSInteger)capabilities volumeLevel:(float)volume muted:(BOOL)muted;
		[Export ("initWithDeviceID:friendlyName:capabilities:volumeLevel:muted:")]
		IntPtr Constructor (string deviceId, string friendlyName, nint capabilities, float volume, bool muted);
	}

	// @interface GCKMultizoneStatus : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GCKMultizoneStatus")]
	interface MultizoneStatus : INSCopying
	{
		// @property (readwrite, copy, nonatomic) NSArray<GCKMultizoneDevice *> * _Nonnull devices;
		[Export ("devices", ArgumentSemantic.Copy)]
		MultizoneDevice [] Devices { get; set; }

		// -(instancetype _Nonnull)initWithJSONObject:(id _Nonnull)JSONObject;
		[Export ("initWithJSONObject:")]
		IntPtr Constructor (NSObject JSONObject);

		// -(instancetype _Nonnull)initWithDevices:(NSArray<GCKMultizoneDevice *> * _Nonnull)devices;
		[Export ("initWithDevices:")]
		IntPtr Constructor (MultizoneDevice [] devices);
	}

	// @interface GCKPlayerInfo : NSObject
	[BaseType (typeof (NSObject), Name = "GCKPlayerInfo")]
	interface PlayerInfo
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull playerID;
		[Export ("playerID")]
		string PlayerId { get; }

		// @property (readonly, assign, nonatomic) GCKPlayerState playerState;
		[Export ("playerState", ArgumentSemantic.Assign)]
		PlayerState PlayerState { get; }

		// @property (readonly, copy, nonatomic) id _Nullable playerData;
		[NullAllowed]
		[Export ("playerData", ArgumentSemantic.Copy)]
		NSObject PlayerData { get; }

		// @property (readonly, assign, nonatomic) BOOL isConnected;
		[Export ("isConnected")]
		bool IsConnected { get; }

		// @property (readonly, assign, nonatomic) BOOL isControllable;
		[Export ("isControllable")]
		bool IsControllable { get; }
	}

	// @interface GCKRemoteMediaClient : NSObject
	[BaseType (typeof (NSObject), Name = "GCKRemoteMediaClient")]
	interface RemoteMediaClient
	{
		// @property (readonly, assign, nonatomic) BOOL connected;
		[Export ("connected")]
		bool Connected { get; }

		// @property (readonly, nonatomic, strong) GCKMediaStatus * _Nullable mediaStatus;
		[NullAllowed]
		[Export ("mediaStatus", ArgumentSemantic.Strong)]
		MediaStatus MediaStatus { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval timeSinceLastMediaStatusUpdate;
		[Export ("timeSinceLastMediaStatusUpdate")]
		double TimeSinceLastMediaStatusUpdate { get; }

		// -(void)addListener:(id<GCKRemoteMediaClientListener> _Nonnull)listener;
		[Export ("addListener:")]
		void AddListener (IRemoteMediaClientListener listener);

		// -(void)removeListener:(id<GCKRemoteMediaClientListener> _Nonnull)listener;
		[Export ("removeListener:")]
		void RemoveListener (IRemoteMediaClientListener listener);

		// @property (readwrite, nonatomic, weak) id<GCKRemoteMediaClientAdInfoParserDelegate> _Nullable adInfoParserDelegate;
		[NullAllowed]
		[Export ("adInfoParserDelegate", ArgumentSemantic.Weak)]
		IRemoteMediaClientAdInfoParserDelegate AdInfoParserDelegate { get; set; }

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo;
		[Export ("loadMedia:")]
		Request LoadMedia (MediaInformation mediaInfo);

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo autoplay:(BOOL)autoplay;
		[Export ("loadMedia:autoplay:")]
		Request LoadMedia (MediaInformation mediaInfo, bool autoplay);

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo autoplay:(BOOL)autoplay playPosition:(NSTimeInterval)playPosition;
		[Export ("loadMedia:autoplay:playPosition:")]
		Request LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition);

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo autoplay:(BOOL)autoplay playPosition:(NSTimeInterval)playPosition customData:(id _Nullable)customData;
		[Export ("loadMedia:autoplay:playPosition:customData:")]
		Request LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo autoplay:(BOOL)autoplay playPosition:(NSTimeInterval)playPosition activeTrackIDs:(NSArray<NSNumber *> * _Nullable)activeTrackIDs;
		[Internal]
		[Export ("loadMedia:autoplay:playPosition:activeTrackIDs:")]
		Request _LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSArray activeTrackIDs);

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo autoplay:(BOOL)autoplay playPosition:(NSTimeInterval)playPosition activeTrackIDs:(NSArray<NSNumber *> * _Nullable)activeTrackIDs customData:(id _Nullable)customData;
		[Internal]
		[Export ("loadMedia:autoplay:playPosition:activeTrackIDs:customData:")]
		Request _LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSArray activeTrackIDs, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)setActiveTrackIDs:(NSArray<NSNumber *> * _Nullable)activeTrackIDs;
		[Internal]
		[Export ("setActiveTrackIDs:")]
		Request _SetActiveTrackIDs ([NullAllowed] NSArray activeTrackIDs);

		// -(GCKRequest * _Nonnull)setTextTrackStyle:(GCKMediaTextTrackStyle * _Nullable)textTrackStyle;
		[Export ("setTextTrackStyle:")]
		Request SetTextTrackStyle ([NullAllowed] MediaTextTrackStyle textTrackStyle);

		// -(GCKRequest * _Nonnull)pause;
		[Export ("pause")]
		Request Pause ();

		// -(GCKRequest * _Nonnull)pauseWithCustomData:(id _Nullable)customData;
		[Export ("pauseWithCustomData:")]
		Request Pause ([NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)stop;
		[Export ("stop")]
		Request Stop ();

		// -(GCKRequest * _Nonnull)stopWithCustomData:(id _Nullable)customData;
		[Export ("stopWithCustomData:")]
		Request Stop ([NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)play;
		[Export ("play")]
		Request Play ();

		// -(GCKRequest * _Nonnull)playWithCustomData:(id _Nullable)customData;
		[Export ("playWithCustomData:")]
		Request Play ([NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)seekToTimeInterval:(NSTimeInterval)position;
		[Export ("seekToTimeInterval:")]
		Request SeekTo (double position);

		// -(GCKRequest * _Nonnull)seekToTimeInterval:(NSTimeInterval)position resumeState:(GCKMediaResumeState)resumeState;
		[Export ("seekToTimeInterval:resumeState:")]
		Request SeekTo (double position, MediaResumeState resumeState);

		// -(GCKRequest * _Nonnull)seekToTimeInterval:(NSTimeInterval)position resumeState:(GCKMediaResumeState)resumeState customData:(id _Nullable)customData;
		[Export ("seekToTimeInterval:resumeState:customData:")]
		Request SeekTo (double position, MediaResumeState resumeState, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueLoadItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems startIndex:(NSUInteger)startIndex repeatMode:(GCKMediaRepeatMode)repeatMode;
		[Export ("queueLoadItems:startIndex:repeatMode:")]
		Request QueueLoadItems (MediaQueueItem [] queueItems, nuint startIndex, MediaRepeatMode repeatMode);

		// -(GCKRequest * _Nonnull)queueLoadItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems startIndex:(NSUInteger)startIndex repeatMode:(GCKMediaRepeatMode)repeatMode customData:(id _Nullable)customData;
		[Export ("queueLoadItems:startIndex:repeatMode:customData:")]
		Request QueueLoadItems (MediaQueueItem [] queueItems, nuint startIndex, MediaRepeatMode repeatMode, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueLoadItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems startIndex:(NSUInteger)startIndex playPosition:(NSTimeInterval)playPosition repeatMode:(GCKMediaRepeatMode)repeatMode customData:(id _Nullable)customData;
		[Export ("queueLoadItems:startIndex:playPosition:repeatMode:customData:")]
		Request QueueLoadItems (MediaQueueItem [] queueItems, nuint startIndex, double playPosition, MediaRepeatMode repeatMode, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueInsertItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems beforeItemWithID:(NSUInteger)beforeItemID;
		[Export ("queueInsertItems:beforeItemWithID:")]
		Request QueueInsertItems (MediaQueueItem [] queueItems, nuint beforeItemId);

		// -(GCKRequest * _Nonnull)queueInsertItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems beforeItemWithID:(NSUInteger)beforeItemID customData:(id _Nullable)customData;
		[Export ("queueInsertItems:beforeItemWithID:customData:")]
		Request QueueInsertItems (MediaQueueItem [] queueItems, nuint beforeItemId, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueInsertItem:(GCKMediaQueueItem * _Nonnull)item beforeItemWithID:(NSUInteger)beforeItemID;
		[Export ("queueInsertItem:beforeItemWithID:")]
		Request QueueInsertItem (MediaQueueItem item, nuint beforeItemId);

		// -(GCKRequest * _Nonnull)queueInsertAndPlayItem:(GCKMediaQueueItem * _Nonnull)item beforeItemWithID:(NSUInteger)beforeItemID;
		[Export ("queueInsertAndPlayItem:beforeItemWithID:")]
		Request QueueInsertAndPlayItem (MediaQueueItem item, nuint beforeItemId);

		// -(GCKRequest * _Nonnull)queueInsertAndPlayItem:(GCKMediaQueueItem * _Nonnull)item beforeItemWithID:(NSUInteger)beforeItemID playPosition:(NSTimeInterval)playPosition customData:(id _Nullable)customData;
		[Export ("queueInsertAndPlayItem:beforeItemWithID:playPosition:customData:")]
		Request QueueInsertAndPlayItem (MediaQueueItem item, nuint beforeItemId, double playPosition, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueUpdateItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems;
		[Export ("queueUpdateItems:")]
		Request QueueUpdateItems (MediaQueueItem [] queueItems);

		// -(GCKRequest * _Nonnull)queueUpdateItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems customData:(id _Nullable)customData;
		[Export ("queueUpdateItems:customData:")]
		Request QueueUpdateItems (MediaQueueItem [] queueItems, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueRemoveItemsWithIDs:(NSArray<NSNumber *> * _Nonnull)itemIDs;
		[Internal]
		[Export ("queueRemoveItemsWithIDs:")]
		Request _QueueRemoveItems (NSArray itemIds);

		// -(GCKRequest * _Nonnull)queueRemoveItemsWithIDs:(NSArray<NSNumber *> * _Nonnull)itemIDs customData:(id _Nullable)customData;
		[Internal]
		[Export ("queueRemoveItemsWithIDs:customData:")]
		Request _QueueRemoveItems (NSArray itemIds, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueRemoveItemWithID:(NSUInteger)itemID;
		[Export ("queueRemoveItemWithID:")]
		Request QueueRemoveItem (nuint itemId);

		// -(GCKRequest * _Nonnull)queueReorderItemsWithIDs:(NSArray<NSNumber *> * _Nonnull)queueItemIDs insertBeforeItemWithID:(NSUInteger)beforeItemID;
		[Internal]
		[Export ("queueReorderItemsWithIDs:insertBeforeItemWithID:")]
		Request _QueueReorderItems (NSArray queueItemIds, nuint beforeItemId);

		// -(GCKRequest * _Nonnull)queueReorderItemsWithIDs:(NSArray<NSNumber *> * _Nonnull)queueItemIDs insertBeforeItemWithID:(NSUInteger)beforeItemID customData:(id _Nullable)customData;
		[Internal]
		[Export ("queueReorderItemsWithIDs:insertBeforeItemWithID:customData:")]
		Request _QueueReorderItems (NSArray queueItemIds, nuint beforeItemId, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueMoveItemWithID:(NSUInteger)itemID beforeItemWithID:(NSUInteger)beforeItemID;
		[Export ("queueMoveItemWithID:beforeItemWithID:")]
		Request QueueMoveItem (nuint itemId, nuint beforeItemId);

		// -(GCKRequest * _Nonnull)queueJumpToItemWithID:(NSUInteger)itemID;
		[Export ("queueJumpToItemWithID:")]
		Request QueueJumpToItem (nuint itemId);

		// -(GCKRequest * _Nonnull)queueJumpToItemWithID:(NSUInteger)itemID customData:(id _Nullable)customData;
		[Export ("queueJumpToItemWithID:customData:")]
		Request QueueJumpToItem (nuint itemId, NSObject customData);

		// -(GCKRequest * _Nonnull)queueJumpToItemWithID:(NSUInteger)itemID playPosition:(NSTimeInterval)playPosition customData:(id _Nullable)customData;
		[Export ("queueJumpToItemWithID:playPosition:customData:")]
		Request QueueJumpToItem (nuint itemId, double playPosition, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueNextItem;
		[Export ("queueNextItem")]
		Request QueueNextItem ();

		// -(GCKRequest * _Nonnull)queuePreviousItem;
		[Export ("queuePreviousItem")]
		Request QueuePreviousItem ();

		// -(GCKRequest * _Nonnull)queueSetRepeatMode:(GCKMediaRepeatMode)repeatMode;
		[Export ("queueSetRepeatMode:")]
		Request QueueSetRepeatMode (MediaRepeatMode repeatMode);

		// -(GCKRequest * _Nonnull)setStreamVolume:(float)volume;
		[Export ("setStreamVolume:")]
		Request SetStreamVolume (float volume);

		// -(GCKRequest * _Nonnull)setStreamVolume:(float)volume customData:(id _Nullable)customData;
		[Export ("setStreamVolume:customData:")]
		Request SetStreamVolume (float volume, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)setStreamMuted:(BOOL)muted;
		[Export ("setStreamMuted:")]
		Request SetStreamMuted (bool muted);

		// -(GCKRequest * _Nonnull)setStreamMuted:(BOOL)muted customData:(id _Nullable)customData;
		[Export ("setStreamMuted:customData:")]
		Request SetStreamMuted (bool muted, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)requestStatus;
		[Export ("requestStatus")]
		Request RequestStatus ();

		// -(NSTimeInterval)approximateStreamPosition;
		[Export ("approximateStreamPosition")]
		double ApproximateStreamPosition { get; }
	}

	interface IRemoteMediaClientListener
	{
	}

	// @protocol GCKRemoteMediaClientListener <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKRemoteMediaClientListener")]
	interface RemoteMediaClientListener
	{
		// @optional -(void)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client didStartMediaSessionWithID:(NSInteger)sessionID;
		[Export ("remoteMediaClient:didStartMediaSessionWithID:")]
		void DidStartMediaSession (RemoteMediaClient client, nint sessionId);

		// @optional -(void)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client didUpdateMediaStatus:(GCKMediaStatus * _Nonnull)mediaStatus;
		[Export ("remoteMediaClient:didUpdateMediaStatus:")]
		void DidUpdateMediaStatus (RemoteMediaClient client, MediaStatus mediaStatus);

		// @optional -(void)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client didUpdateMediaMetadata:(GCKMediaMetadata * _Nonnull)mediaMetadata;
		[Export ("remoteMediaClient:didUpdateMediaMetadata:")]
		void DidUpdateMediaMetadata (RemoteMediaClient client, MediaMetadata mediaMetadata);

		// @optional -(void)remoteMediaClientDidUpdateQueue:(GCKRemoteMediaClient * _Nonnull)client;
		[Export ("remoteMediaClientDidUpdateQueue:")]
		void DidUpdateQueue (RemoteMediaClient client);

		// @optional -(void)remoteMediaClientDidUpdatePreloadStatus:(GCKRemoteMediaClient * _Nonnull)client;
		[Export ("remoteMediaClientDidUpdatePreloadStatus:")]
		void DidUpdatePreloadStatus (RemoteMediaClient client);
	}

	interface IRemoteMediaClientAdInfoParserDelegate
	{
	}

	// @protocol GCKRemoteMediaClientAdInfoParserDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKRemoteMediaClientAdInfoParserDelegate")]
	interface RemoteMediaClientAdInfoParserDelegate
	{
		// @optional -(BOOL)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client shouldSetPlayingAdInMediaStatus:(GCKMediaStatus * _Nonnull)mediaStatus;
		[Export ("remoteMediaClient:shouldSetPlayingAdInMediaStatus:")]
		bool ShouldSetPlayingAdInMediaStatus (RemoteMediaClient client, MediaStatus mediaStatus);

		// @optional -(NSArray<GCKAdBreakInfo *> * _Nullable)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client shouldSetAdBreaksInMediaStatus:(GCKMediaStatus * _Nonnull)mediaStatus;
		[return: NullAllowed]
		[Export ("remoteMediaClient:shouldSetAdBreaksInMediaStatus:")]
		AdBreakInfo [] ShouldSetAdBreaksInMediaStatus (RemoteMediaClient client, MediaStatus mediaStatus);
	}

	// @interface Protected (GCKRemoteMediaClient)
	[Category]
	[BaseType (typeof (RemoteMediaClient))]
	interface RemoteMediaClient_Protected
	{
		// -(void)notifyDidStartMediaSession;
		[Export ("notifyDidStartMediaSession")]
		void NotifyDidStartMediaSession ();

		// -(void)notifyDidUpdateMediaStatus;
		[Export ("notifyDidUpdateMediaStatus")]
		void NotifyDidUpdateMediaStatus ();

		// -(void)notifyDidUpdateQueue;
		[Export ("notifyDidUpdateQueue")]
		void NotifyDidUpdateQueue ();

		// -(void)notifyDidUpdatePreloadStatus;
		[Export ("notifyDidUpdatePreloadStatus")]
		void NotifyDidUpdatePreloadStatus ();

		// -(void)notifyDidUpdateMetadata;
		[Export ("notifyDidUpdateMetadata")]
		void NotifyDidUpdateMetadata ();
	}

	// @interface GCKRequest : NSObject
	[BaseType (typeof (NSObject),
		   Name = "GCKRequest",
		   Delegates = new string [] { "Delegate" },
		   Events = new Type [] { typeof (RequestDelegate) })]
	interface Request
	{
		// @property (readwrite, nonatomic, weak) id<GCKRequestDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IRequestDelegate Delegate { get; set; }

		// @property (readonly, assign, nonatomic) GCKRequestID requestID;
		[Export ("requestID")]
		nint RequestId { get; }

		// @property (readonly, copy, nonatomic) GCKError * _Nullable error;
		[NullAllowed]
		[Export ("error", ArgumentSemantic.Copy)]
		Error Error { get; }

		// @property (readonly, assign, nonatomic) BOOL inProgress;
		[Export ("inProgress")]
		bool InProgress { get; }

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// -(void)complete
		[Export ("complete")]
		void Complete ();

		// -(void)failWithError:
		[Export ("failWithError")]
		void Fail (Error error);

		// -(void)abortWithReason
		[Export ("abortWithReason")]
		void Abort (RequestAbortReason reason);

		// +(GCKRequest *) applicationRequest
		[Export ("applicationRequest")]
		Request ApplicationRequest ();

		// -(BOOL)external
		[Export ("external")]
		bool External { get; }
	}

	interface IRequestDelegate
	{
	}

	// @protocol GCKRequestDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKRequestDelegate")]
	interface RequestDelegate
	{
		// @optional -(void)requestDidComplete:(GCKRequest * _Nonnull)request;
		[EventArgs ("RequestCompleted")]
		[EventName ("Completed")]
		[Export ("requestDidComplete:")]
		void DidComplete (Request request);

		// @optional -(void)request:(GCKRequest * _Nonnull)request didFailWithError:(GCKError * _Nonnull)error;
		[EventArgs ("RequestFailed")]
		[EventName ("Failed")]
		[Export ("request:didFailWithError:")]
		void DidFail (Request request, Error error);

		// @optional -(void)request:(GCKRequest * _Nonnull)request didAbortWithReason:(GCKRequestAbortReason)abortReason;
		[EventArgs ("RequestAborted")]
		[EventName ("Aborted")]
		[Export ("request:didAbortWithReason:")]
		void DidAbort (Request request, RequestAbortReason abortReason);
	}

	[BaseType (typeof (NSObject), Name = "GCKSenderApplicationInfo")]
	interface SenderApplicationInfo : INSCopying
	{

		[Export ("platform", ArgumentSemantic.Assign)]
		SenderApplicationInfoPlatform Platform { get; }

		[NullAllowed]
		[Export ("appIdentifier", ArgumentSemantic.Copy)]
		string AppIdentifier { get; }

		[NullAllowed]
		[Export ("launchURL", ArgumentSemantic.Strong)]
		NSUrl LaunchUrl { get; }
	}

	// @interface GCKSession : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKSession")]
	interface Session
	{
		// @property (readonly, nonatomic, strong) GCKDevice * _Nonnull device;
		[Export ("device", ArgumentSemantic.Strong)]
		Device Device { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sessionID;
		[NullAllowed]
		[Export ("sessionID")]
		string SessionId { get; }

		// @property (readonly, assign, nonatomic) GCKConnectionState connectionState;
		[Export ("connectionState", ArgumentSemantic.Assign)]
		ConnectionState ConnectionState { get; }

		// @property (readonly, assign, nonatomic) BOOL suspended;
		[Export ("suspended")]
		bool Suspended { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable deviceStatusText;
		[NullAllowed]
		[Export ("deviceStatusText")]
		string DeviceStatusText { get; }

		// @property (readonly, copy, nonatomic) GCKSessionTraits * _Nonnull traits;
		[Export ("traits", ArgumentSemantic.Copy)]
		SessionTraits Traits { get; }

		// @property (readonly, assign, nonatomic) float currentDeviceVolume;
		// -(void)setDeviceVolume:(float)volume;
		[Export ("currentDeviceVolume")]
		float DeviceVolume { get; [Bind ("setDeviceVolume:")] set; }

		// @property (readonly, assign, nonatomic) BOOL currentDeviceMuted;
		// -(void)setDeviceMuted:(BOOL)muted;
		[Export ("currentDeviceMuted")]
		bool DeviceMuted { get; [Bind ("setDeviceMuted:")] set; }

		// @property (readonly, nonatomic, strong) GCKRemoteMediaClient * _Nullable remoteMediaClient;
		[NullAllowed]
		[Export ("remoteMediaClient", ArgumentSemantic.Strong)]
		RemoteMediaClient RemoteMediaClient { get; }

		// @property (readonly, nonatomic, strong) GCKMediaMetadata * _Nullable mediaMetadata;
		[NullAllowed]
		[Export ("mediaMetadata", ArgumentSemantic.Strong)]
		MediaMetadata MediaMetadata { get; }

		// -(instancetype _Nonnull)initWithDevice:(GCKDevice * _Nonnull)device traits:(GCKSessionTraits * _Nonnull)traits sessionID:(NSString * _Nullable)sessionID;
		[Export ("initWithDevice:traits:sessionID:")]
		IntPtr Constructor (Device device, SessionTraits traits, [NullAllowed] string sessionId);
	}

	// @interface Protected (GCKSession)
	[Category]
	[BaseType (typeof (Session))]
	interface Session_Protected
	{
		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)endAndStopCasting:(BOOL)stopCasting;
		[Export ("endAndStopCasting:")]
		void End (bool stopCasting);

		// -(void)suspendWithReason:(GCKConnectionSuspendReason)reason;
		[Export ("suspendWithReason:")]
		void Suspend (ConnectionSuspendReason reason);

		// -(void)resume;
		[Export ("resume")]
		void Resume ();

		// -(void)notifyDidStartWithSessionID:(NSString * _Nonnull)sessionID;
		[Export ("notifyDidStartWithSessionID:")]
		void NotifyDidStart (string sessionId);

		// -(void)notifyDidFailToStartWithError:(NSError * _Nonnull)error;
		[Export ("notifyDidFailToStartWithError:")]
		void NotifyDidFailToStart (NSError error);

		// -(void)notifyDidResume;
		[Export ("notifyDidResume")]
		void NotifyDidResume ();

		// -(void)notifyDidSuspendWithReason:(GCKConnectionSuspendReason)reason;
		[Export ("notifyDidSuspendWithReason:")]
		void NotifyDidSuspend (ConnectionSuspendReason reason);

		// -(void)notifyDidEndWithError:(NSError * _Nullable)error;
		[Export ("notifyDidEndWithError:")]
		void NotifyDidEnd ([NullAllowed] NSError error);

		// -(void)notifyDidReceiveDeviceVolume:(float)volume muted:(BOOL)muted;
		[Export ("notifyDidReceiveDeviceVolume:muted:")]
		void NotifyDidReceiveDeviceVolume (float volume, bool muted);

		// -(void)notifyDidReceiveDeviceStatus:(NSString * _Nullable)statusText;
		[Export ("notifyDidReceiveDeviceStatus:")]
		void NotifyDidReceiveDeviceStatus ([NullAllowed] string statusText);
	}

	// @interface GCKSessionManager : NSObject
	[BaseType (typeof (NSObject), Name = "GCKSessionManager")]
	interface SessionManager
	{
		// @property (readonly, nonatomic, strong) GCKSession * _Nullable currentSession;
		[NullAllowed]
		[Export ("currentSession", ArgumentSemantic.Strong)]
		Session CurrentSession { get; }

		// @property (readonly, nonatomic, strong) GCKCastSession * _Nullable currentCastSession;
		[NullAllowed]
		[Export ("currentCastSession", ArgumentSemantic.Strong)]
		CastSession CurrentCastSession { get; }

		// @property (readonly, assign, nonatomic) GCKConnectionState connectionState;
		[Export ("connectionState", ArgumentSemantic.Assign)]
		ConnectionState ConnectionState { get; }

		// -(BOOL)startSessionWithDevice:(GCKDevice * _Nonnull)device;
		[Export ("startSessionWithDevice:")]
		bool StartSession (Device device);

		// -(BOOL)suspendSessionWithReason:(GCKConnectionSuspendReason)reason;
		[Export ("suspendSessionWithReason:")]
		bool SuspendSession (ConnectionSuspendReason reason);

		// -(BOOL)endSession;
		[Export ("endSession")]
		bool EndSession ();

		// -(BOOL)endSessionAndStopCasting:(BOOL)stopCasting;
		[Export ("endSessionAndStopCasting:")]
		bool EndSession (bool stopCasting);

		// -(BOOL)hasConnectedSession;
		[Export ("hasConnectedSession")]
		bool HasConnectedSession { get; }

		// -(BOOL)hasConnectedCastSession;
		[Export ("hasConnectedCastSession")]
		bool HasConnectedCastSession { get; }

		// -(void)addListener:(id<GCKSessionManagerListener> _Nonnull)listener;
		[Export ("addListener:")]
		void AddListener (ISessionManagerListener listener);

		// -(void)removeListener:(id<GCKSessionManagerListener> _Nonnull)listener;
		[Export ("removeListener:")]
		void RemoveListener (ISessionManagerListener listener);
	}

	interface ISessionManagerListener
	{
	}

	// @protocol GCKSessionManagerListener <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKSessionManagerListener")]
	interface SessionManagerListener
	{
		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager willStartSession:(GCKSession * _Nonnull)session;
		[Export ("sessionManager:willStartSession:")]
		void WillStartSession (SessionManager sessionManager, Session session);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didStartSession:(GCKSession * _Nonnull)session;
		[Export ("sessionManager:didStartSession:")]
		void DidStartSession (SessionManager sessionManager, Session session);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager willStartCastSession:(GCKCastSession * _Nonnull)session;
		[Export ("sessionManager:willStartCastSession:")]
		void WillStartCastSession (SessionManager sessionManager, CastSession session);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didStartCastSession:(GCKCastSession * _Nonnull)session;
		[Export ("sessionManager:didStartCastSession:")]
		void DidStartCastSession (SessionManager sessionManager, CastSession session);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager willEndSession:(GCKSession * _Nonnull)session;
		[Export ("sessionManager:willEndSession:")]
		void WillEndSession (SessionManager sessionManager, Session session);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didEndSession:(GCKSession * _Nonnull)session withError:(NSError * _Nullable)error;
		[Export ("sessionManager:didEndSession:withError:")]
		void DidEndSession (SessionManager sessionManager, Session session, [NullAllowed] NSError error);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager willEndCastSession:(GCKCastSession * _Nonnull)session;
		[Export ("sessionManager:willEndCastSession:")]
		void WillEndCastSession (SessionManager sessionManager, CastSession session);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didEndCastSession:(GCKCastSession * _Nonnull)session withError:(NSError * _Nullable)error;
		[Export ("sessionManager:didEndCastSession:withError:")]
		void DidEndCastSession (SessionManager sessionManager, CastSession session, [NullAllowed] NSError error);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didFailToStartSession:(GCKSession * _Nonnull)session withError:(NSError * _Nonnull)error;
		[Export ("sessionManager:didFailToStartSession:withError:")]
		void DidFailToStartSession (SessionManager sessionManager, Session session, NSError error);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didFailToStartCastSession:(GCKCastSession * _Nonnull)session withError:(NSError * _Nonnull)error;
		[Export ("sessionManager:didFailToStartCastSession:withError:")]
		void DidFailToStartCastSession (SessionManager sessionManager, CastSession session, NSError error);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didSuspendSession:(GCKSession * _Nonnull)session withReason:(GCKConnectionSuspendReason)reason;
		[Export ("sessionManager:didSuspendSession:withReason:")]
		void DidSuspendSession (SessionManager sessionManager, Session session, ConnectionSuspendReason reason);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didSuspendCastSession:(GCKCastSession * _Nonnull)session withReason:(GCKConnectionSuspendReason)reason;
		[Export ("sessionManager:didSuspendCastSession:withReason:")]
		void DidSuspendCastSession (SessionManager sessionManager, CastSession session, ConnectionSuspendReason reason);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager willResumeSession:(GCKSession * _Nonnull)session;
		[Export ("sessionManager:willResumeSession:")]
		void WillResumeSession (SessionManager sessionManager, Session session);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didResumeSession:(GCKSession * _Nonnull)session;
		[Export ("sessionManager:didResumeSession:")]
		void DidResumeSession (SessionManager sessionManager, Session session);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager willResumeCastSession:(GCKCastSession * _Nonnull)session;
		[Export ("sessionManager:willResumeCastSession:")]
		void WillResumeCastSession (SessionManager sessionManager, CastSession session);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didResumeCastSession:(GCKCastSession * _Nonnull)session;
		[Export ("sessionManager:didResumeCastSession:")]
		void DidResumeCastSession (SessionManager sessionManager, CastSession session);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager session:(GCKSession * _Nonnull)session didUpdateDevice:(GCKDevice * _Nonnull)device;
		[Export ("sessionManager:session:didUpdateDevice:")]
		void DidUpdateDevice (SessionManager sessionManager, Session session, Device device);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager session:(GCKSession * _Nonnull)session didReceiveDeviceVolume:(float)volume muted:(BOOL)muted;
		[Export ("sessionManager:session:didReceiveDeviceVolume:muted:")]
		void DidReceiveDeviceVolume (SessionManager sessionManager, Session session, float volume, bool muted);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager castSession:(GCKCastSession * _Nonnull)session didReceiveDeviceVolume:(float)volume muted:(BOOL)muted;
		[Export ("sessionManager:castSession:didReceiveDeviceVolume:muted:")]
		void DidReceiveDeviceVolume (SessionManager sessionManager, CastSession session, float volume, bool muted);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager session:(GCKSession * _Nonnull)session didReceiveDeviceStatus:(NSString * _Nullable)statusText;
		[Export ("sessionManager:session:didReceiveDeviceStatus:")]
		void DidReceiveDeviceStatus (SessionManager sessionManager, Session session, [NullAllowed] string statusText);

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager castSession:(GCKCastSession * _Nonnull)session didReceiveDeviceStatus:(NSString * _Nullable)statusText;
		[Export ("sessionManager:castSession:didReceiveDeviceStatus:")]
		void DidReceiveDeviceStatus (SessionManager sessionManager, CastSession session, [NullAllowed] string statusText);
	}

	// @interface GCKSessionTraits : NSObject <NSCopying, NSCoding>
	[BaseType (typeof (NSObject), Name = "GCKSessionTraits")]
	interface SessionTraits : INSCopying, INSCoding
	{
		// @property (readonly, assign, nonatomic) float minimumVolume;
		[Export ("minimumVolume")]
		float MinimumVolume { get; }

		// @property (readonly, assign, nonatomic) float maximumVolume;
		[Export ("maximumVolume")]
		float MaximumVolume { get; }

		// @property (readonly, assign, nonatomic) float volumeIncrement;
		[Export ("volumeIncrement")]
		float VolumeIncrement { get; }

		// @property (readonly, assign, nonatomic) BOOL supportsMuting;
		[Export ("supportsMuting")]
		bool SupportsMuting { get; }

		// -(instancetype _Nonnull)initWithMinimumVolume:(float)minimumVolume maximumVolume:(float)maximumVolume volumeIncrement:(float)volumeIncrement supportsMuting:(BOOL)supportsMuting __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithMinimumVolume:maximumVolume:volumeIncrement:supportsMuting:")]
		IntPtr Constructor (float minimumVolume, float maximumVolume, float volumeIncrement, bool supportsMuting);

		// -(BOOL)isFixedVolume;
		[Export ("isFixedVolume")]
		bool IsFixedVolume { get; }
	}

	// @interface GCKUIButton : UIButton
	[BaseType (typeof (UIButton), Name = "GCKUIButton")]
	interface GCKUIButton
	{
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (assign, readwrite, nonatomic) UIControlState applicationState;
		[Export ("applicationState", ArgumentSemantic.Assign)]
		UIControlState ApplicationState { get; set; }
	}

	// @interface GCKUICastButton : UIButton
	[BaseType (typeof (UIButton), Name = "GCKUICastButton")]
	interface UICastButton
	{
		// @property (assign, readwrite, nonatomic) BOOL triggersDefaultCastDialog;
		[Export ("triggersDefaultCastDialog")]
		bool TriggersDefaultCastDialog { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// -(void)setInactiveIcon:(UIImage * _Nonnull)inactiveIcon activeIcon:(UIImage * _Nonnull)activeIcon animationIcons:(NSArray<UIImage *> * _Nonnull)animationIcons;
		[Export ("setInactiveIcon:activeIcon:animationIcons:")]
		void SetInactiveIcon (UIImage inactiveIcon, UIImage activeIcon, UIImage [] animationIcons);
	}

	// @interface GCKUICastContainerViewController : UIViewController
	[BaseType (typeof (UIViewController), Name = "GCKUICastContainerViewController")]
	interface UICastContainerViewController
	{
		[Export ("initWithNibName:bundle:")]
		IntPtr Constructor (string nibName, NSBundle bundle);

		// @property (readonly, nonatomic, strong) UIViewController * _Nullable contentViewController;
		[NullAllowed]
		[Export ("contentViewController", ArgumentSemantic.Strong)]
		UIViewController ContentViewController { get; }

		// @property (readonly, nonatomic, strong) GCKUIMiniMediaControlsViewController * _Nullable miniMediaControlsViewController;
		[NullAllowed]
		[Export ("miniMediaControlsViewController", ArgumentSemantic.Strong)]
		UIMiniMediaControlsViewController MiniMediaControlsViewController { get; }

		// @property (assign, readwrite, nonatomic) BOOL miniMediaControlsItemEnabled;
		[Export ("miniMediaControlsItemEnabled")]
		bool MiniMediaControlsItemEnabled { get; set; }
	}

	// @interface GCKUIDeviceVolumeController : NSObject
	[BaseType (typeof (NSObject), Name = "GCKUIDeviceVolumeController")]
	interface UIDeviceVolumeController
	{
		// extern const UIControlState GCKUIControlStateMuteOff __attribute__((visibility("default")));
		[Internal]
		[Field ("GCKUIControlStateMuteOff", "__Internal")]
		IntPtr _MuteOff { get; }

		// extern const UIControlState GCKUIControlStateMuteOn __attribute__((visibility("default")));
		[Internal]
		[Field ("GCKUIControlStateMuteOn", "__Internal")]
		IntPtr _MuteOn { get; }

		// @property (readwrite, nonatomic, weak) UIButton * _Nullable volumeUpButton;
		[NullAllowed]
		[Export ("volumeUpButton", ArgumentSemantic.Weak)]
		UIButton VolumeUpButton { get; set; }

		// @property (readwrite, nonatomic, weak) UIButton * _Nullable volumeDownButton;
		[NullAllowed]
		[Export ("volumeDownButton", ArgumentSemantic.Weak)]
		UIButton VolumeDownButton { get; set; }

		// @property (readwrite, nonatomic, weak) UISlider * _Nullable volumeSlider;
		[NullAllowed]
		[Export ("volumeSlider", ArgumentSemantic.Weak)]
		UISlider VolumeSlider { get; set; }

		// @property (readwrite, nonatomic, weak) UISwitch * _Nullable muteSwitch;
		[NullAllowed]
		[Export ("muteSwitch", ArgumentSemantic.Weak)]
		UISwitch MuteSwitch { get; set; }

		// @property (readwrite, nonatomic, weak) GCKUIButton * _Nullable muteToggleButton;
		[NullAllowed]
		[Export ("muteToggleButton", ArgumentSemantic.Weak)]
		GCKUIButton MuteToggleButton { get; set; }

		// -(void)setVolume:(float)volume;
		[Export ("setVolume:")]
		void SetVolume (float volume);

		// -(void)setMuted:(BOOL)muted;
		[Export ("setMuted:")]
		void SetMuted (bool muted);

		// -(void)volumeUp;
		[Export ("volumeUp")]
		void VolumeUp ();

		// -(void)volumeDown;
		[Export ("volumeDown")]
		void VolumeDown ();

		// -(void)toggleMuted;
		[Export ("toggleMuted")]
		void ToggleMuted ();
	}

	// @interface GCKUIExpandedMediaControlsViewController : UIViewController <GCKUIMediaButtonBarProtocol>
	[BaseType (typeof (UIViewController), Name = "GCKUIExpandedMediaControlsViewController")]
	interface UIExpandedMediaControlsViewController : UIMediaButtonBarProtocol
	{
		[Export ("initWithNibName:bundle:")]
		IntPtr Constructor (string nibName, NSBundle bundle);
	}

	interface IUIImageCache
	{
	}

	// @protocol GCKUIImageCache <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKUIImageCache")]
	interface UIImageCache
	{
		// @required -(void)fetchImageForURL:(NSURL * _Nonnull)imageURL completion:(void (^ _Nonnull)(UIImage * _Nullable))completion;
		[Abstract]
		[Export ("fetchImageForURL:completion:")]
		void Completion (NSUrl imageUrl, Action<UIImage> completion);
	}

	// @interface GCKUIImageHints : NSObject <NSCopying, NSCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKUIImageHints")]
	interface UIImageHints : INSCopying, INSCoding
	{
		// @property (readonly, assign, nonatomic) GCKMediaMetadataImageType imageType;
		[Export ("imageType", ArgumentSemantic.Assign)]
		MediaMetadataImageType ImageType { get; }

		// @property (readonly, assign, nonatomic) CGSize imageSize;
		[Export ("imageSize", ArgumentSemantic.Assign)]
		CGSize ImageSize { get; }

		// @property (readonly, copy, nonatomic) NSObject<NSCoding> * _Nullable customData;
		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Copy)]
		INSCoding CustomData { get; }

		// -(instancetype _Nonnull)initWithImageType:(GCKMediaMetadataImageType)imageType imageSize:(CGSize)imageSize;
		[Export ("initWithImageType:imageSize:")]
		IntPtr Constructor (MediaMetadataImageType imageType, CGSize imageSize);

		// -(instancetype _Nonnull)initWithImageType:(GCKMediaMetadataImageType)imageType imageSize:(CGSize)imageSize customData:(NSObject<NSCoding> * _Nullable)customData;
		[Export ("initWithImageType:imageSize:customData:")]
		IntPtr Constructor (MediaMetadataImageType imageType, CGSize imageSize, [NullAllowed] INSCoding customData);
	}

	interface IUIImagePicker
	{
	}

	// @protocol GCKUIImagePicker <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKUIImagePicker")]
	interface UIImagePicker
	{
		// @required -(GCKImage * _Nullable)getImageWithHints:(GCKUIImageHints * _Nonnull)imageHints fromMetadata:(const GCKMediaMetadata * _Nonnull)metadata;
		[Abstract]
		[return: NullAllowed]
		[Export ("getImageWithHints:fromMetadata:")]
		Image GetImage (UIImageHints imageHints, MediaMetadata metadata);
	}

	interface IUIMediaButtonBarProtocol
	{
	}

	// @protocol GCKUIMediaButtonBarProtocol <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKUIMediaButtonBarProtocol")]
	interface UIMediaButtonBarProtocol
	{
		// @required -(NSUInteger)buttonCount;
		[Abstract]
		[Export ("buttonCount")]
		nuint GetButtonCount ();

		// @required -(void)setButtonType:(GCKUIMediaButtonType)buttonType atIndex:(NSUInteger)index;
		[Abstract]
		[Export ("setButtonType:atIndex:")]
		void SetButtonType (UIMediaButtonType buttonType, nuint index);

		// @required -(GCKUIMediaButtonType)buttonTypeAtIndex:(NSUInteger)index;
		[Abstract]
		[Export ("buttonTypeAtIndex:")]
		UIMediaButtonType GetButtonType (nuint index);

		// @required -(void)setCustomButton:(UIButton * _Nullable)customButton atIndex:(NSUInteger)index;
		[Abstract]
		[Export ("setCustomButton:atIndex:")]
		void SetCustomButton ([NullAllowed] UIButton customButton, nuint index);

		// @required -(UIButton * _Nullable)customButtonAtIndex:(NSUInteger)index;
		[Abstract]
		[return: NullAllowed]
		[Export ("customButtonAtIndex:")]
		UIButton GetCustomButton (nuint index);
	}

	// typedef NSString * _Nonnull (^GCKUIValueFormatter)(const id _Nonnull);
	delegate string UIMediaControllerValueFormatterHandler (NSObject value);

	// @interface GCKUIMediaController : NSObject
	[BaseType (typeof (NSObject),
		   Name = "GCKUIMediaController",
		   Delegates = new string [] { "Delegate" },
		   Events = new Type [] { typeof (UIMediaControllerDelegate) })]
	interface UIMediaController
	{
		// extern const UIControlState GCKUIControlStateRepeatOff __attribute__((visibility("default")));
		[Internal]
		[Field ("GCKUIControlStateRepeatOff", "__Internal")]
		IntPtr _RepeatOff { get; }

		// extern const UIControlState GCKUIControlStateRepeatAll __attribute__((visibility("default")));
		[Internal]
		[Field ("GCKUIControlStateRepeatAll", "__Internal")]
		IntPtr _RepeatAll { get; }

		// extern const UIControlState GCKUIControlStateRepeatSingle __attribute__((visibility("default")));
		[Internal]
		[Field ("GCKUIControlStateRepeatSingle", "__Internal")]
		IntPtr _RepeatSingle { get; }

		// extern const UIControlState GCKUIControlStatePlay __attribute__((visibility("default")));
		[Internal]
		[Field ("GCKUIControlStatePlay", "__Internal")]
		IntPtr _Play { get; }

		// extern const UIControlState GCKUIControlStatePause __attribute__((visibility("default")));
		[Internal]
		[Field ("GCKUIControlStatePause", "__Internal")]
		IntPtr _Pause { get; }

		// extern const UIControlState GCKUIControlStateShuffle __attribute__((visibility("default")));
		[Internal]
		[Field ("GCKUIControlStateShuffle", "__Internal")]
		IntPtr _Shuffle { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IUIMediaControllerDelegate Delegate { get; set; }

		// @property (readonly, nonatomic, strong) GCKSession * _Nullable session;
		[NullAllowed]
		[Export ("session", ArgumentSemantic.Strong)]
		Session Session { get; }

		// @property (readonly, assign, nonatomic) BOOL mediaLoaded;
		[Export ("mediaLoaded")]
		bool MediaLoaded { get; }

		// @property (readonly, assign, nonatomic) BOOL hasCurrentQueueItem;
		[Export ("hasCurrentQueueItem")]
		bool HasCurrentQueueItem { get; }

		// @property (readonly, assign, nonatomic) BOOL hasLoadingQueueItem;
		[Export ("hasLoadingQueueItem")]
		bool HasLoadingQueueItem { get; }

		// @property (readonly, assign, nonatomic) GCKMediaPlayerState lastKnownPlayerState;
		[Export ("lastKnownPlayerState", ArgumentSemantic.Assign)]
		MediaPlayerState LastKnownPlayerState { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval lastKnownStreamPosition;
		[Export ("lastKnownStreamPosition")]
		double LastKnownStreamPosition { get; }

		// @property (readwrite, nonatomic, weak) UIButton * _Nullable playButton;
		[NullAllowed]
		[Export ("playButton", ArgumentSemantic.Weak)]
		UIButton PlayButton { get; set; }

		// @property (readwrite, nonatomic, weak) UIButton * _Nullable pauseButton;
		[NullAllowed]
		[Export ("pauseButton", ArgumentSemantic.Weak)]
		UIButton PauseButton { get; set; }

		// @property (readwrite, nonatomic, weak) GCKUIButton * _Nullable playPauseToggleButton;
		[NullAllowed]
		[Export ("playPauseToggleButton", ArgumentSemantic.Weak)]
		GCKUIButton PlayPauseToggleButton { get; set; }

		// @property (readwrite, nonatomic, strong) GCKUIPlayPauseToggleController* playPauseToggleController;
		[NullAllowed]
		[Export ("playPauseToggleController")]
		UIPlayPauseToggleController PlayPauseToggleController { get; set; }

		// @property (readwrite, nonatomic, weak) UIButton * _Nullable stopButton;
		[NullAllowed]
		[Export ("stopButton", ArgumentSemantic.Weak)]
		UIButton StopButton { get; set; }

		// @property (readwrite, nonatomic, weak) GCKUIButton * _Nullable forward30SecondsButton;
		[NullAllowed]
		[Export ("forward30SecondsButton", ArgumentSemantic.Weak)]
		GCKUIButton Forward30SecondsButton { get; set; }

		// @property (readwrite, nonatomic, weak) GCKUIButton * _Nullable rewind30SecondsButton;
		[NullAllowed]
		[Export ("rewind30SecondsButton", ArgumentSemantic.Weak)]
		GCKUIButton Rewind30SecondsButton { get; set; }

		// @property (readwrite, nonatomic, weak) UIButton * _Nullable pauseQueueButton;
		[NullAllowed]
		[Export ("pauseQueueButton", ArgumentSemantic.Weak)]
		UIButton PauseQueueButton { get; set; }

		// @property (readwrite, nonatomic, weak) UIButton * _Nullable nextButton;
		[NullAllowed]
		[Export ("nextButton", ArgumentSemantic.Weak)]
		UIButton NextButton { get; set; }

		// @property (readwrite, nonatomic, weak) UIButton * _Nullable previousButton;
		[NullAllowed]
		[Export ("previousButton", ArgumentSemantic.Weak)]
		UIButton PreviousButton { get; set; }

		// @property (readwrite, nonatomic, weak) GCKUIButton * _Nullable repeatModeButton;
		[NullAllowed]
		[Export ("repeatModeButton", ArgumentSemantic.Weak)]
		GCKUIButton RepeatModeButton { get; set; }

		// @property (readwrite, nonatomic, weak) UISlider * _Nullable streamPositionSlider;
		[NullAllowed]
		[Export ("streamPositionSlider", ArgumentSemantic.Weak)]
		UISlider StreamPositionSlider { get; set; }

		// @property (readwrite, nonatomic, weak) UIProgressView * _Nullable streamProgressView;
		[NullAllowed]
		[Export ("streamProgressView", ArgumentSemantic.Weak)]
		UIProgressView StreamProgressView { get; set; }

		// @property (readwrite, nonatomic, weak) UILabel * _Nullable streamPositionLabel;
		[NullAllowed]
		[Export ("streamPositionLabel", ArgumentSemantic.Weak)]
		UILabel StreamPositionLabel { get; set; }

		// @property (readwrite, nonatomic, weak) UILabel * _Nullable streamDurationLabel;
		[NullAllowed]
		[Export ("streamDurationLabel", ArgumentSemantic.Weak)]
		UILabel StreamDurationLabel { get; set; }

		// @property (readwrite, nonatomic, weak) UILabel * _Nullable streamTimeRemainingLabel;
		[NullAllowed]
		[Export ("streamTimeRemainingLabel", ArgumentSemantic.Weak)]
		UILabel StreamTimeRemainingLabel { get; set; }

		// @property(nonatomic, strong, readwrite, GCK_NULLABLE) GCKUIStreamPositionController* streamPositionController;
		[NullAllowed]
		[Export ("streamPositionController")]
		UIStreamPositionController StreamPositionController { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL displayTimeRemainingAsNegativeValue;
		[Export ("displayTimeRemainingAsNegativeValue")]
		bool DisplayTimeRemainingAsNegativeValue { get; set; }

		// @property (readwrite, nonatomic, weak) UIButton * _Nullable tracksButton;
		[NullAllowed]
		[Export ("tracksButton", ArgumentSemantic.Weak)]
		UIButton TracksButton { get; set; }

		// @property (readwrite, nonatomic, weak) UILabel * _Nullable smartSubtitleLabel;
		[NullAllowed]
		[Export ("smartSubtitleLabel", ArgumentSemantic.Weak)]
		UILabel SmartSubtitleLabel { get; set; }

		// @property (readwrite, nonatomic, weak) UIActivityIndicatorView * _Nullable mediaLoadingIndicator;
		[NullAllowed]
		[Export ("mediaLoadingIndicator", ArgumentSemantic.Weak)]
		UIActivityIndicatorView MediaLoadingIndicator { get; set; }

		// -(void)bindLabel:(UILabel * _Nonnull)label toMetadataKey:(NSString * _Nonnull)key;
		[Export ("bindLabel:toMetadataKey:")]
		void BindLabel (UILabel label, string key);

		// -(void)bindLabel:(UILabel * _Nonnull)label toMetadataKey:(NSString * _Nonnull)key withFormatter:(GCKUIValueFormatter _Nonnull)formatter;
		[Export ("bindLabel:toMetadataKey:withFormatter:")]
		void BindLabel (UILabel label, string key, UIMediaControllerValueFormatterHandler formatter);

		// -(void)bindTextView:(UITextView * _Nonnull)textView toMetadataKey:(NSString * _Nonnull)key;
		[Export ("bindTextView:toMetadataKey:")]
		void BindTextView (UITextView textView, string key);

		// -(void)bindTextView:(UITextView * _Nonnull)textView toMetadataKey:(NSString * _Nonnull)key withFormatter:(GCKUIValueFormatter _Nonnull)formatter;
		[Export ("bindTextView:toMetadataKey:withFormatter:")]
		void BindTextView (UITextView textView, string key, UIMediaControllerValueFormatterHandler formatter);

		// -(void)bindImageView:(UIImageView * _Nonnull)imageView toImageHints:(GCKUIImageHints * _Nonnull)imageHints;
		[Export ("bindImageView:toImageHints:")]
		void BindImageView (UIImageView imageView, UIImageHints imageHints);

		// -(void)unbindView:(UIView * _Nonnull)view;
		[Export ("unbindView:")]
		void UnbindView (UIView view);

		// -(void)unbindAllViews;
		[Export ("unbindAllViews")]
		void UnbindAllViews ();

		// -(GCKMediaRepeatMode)cycleRepeatMode;
		[Export ("cycleRepeatMode")]
		MediaRepeatMode CycleRepeatMode { get; }

		// -(void)selectTracks;
		[Export ("selectTracks")]
		void SelectTracks ();
	}

	interface IUIMediaControllerDelegate
	{
	}

	// @protocol GCKUIMediaControllerDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKUIMediaControllerDelegate")]
	interface UIMediaControllerDelegate
	{
		// @optional -(void)mediaController:(GCKUIMediaController * _Nonnull)mediaController didUpdatePlayerState:(GCKMediaPlayerState)playerState lastStreamPosition:(NSTimeInterval)streamPosition;
		[EventArgs ("UIMediaControllerPlayerStateUpdated")]
		[EventName ("PlayerStateUpdated")]
		[Export ("mediaController:didUpdatePlayerState:lastStreamPosition:")]
		void DidUpdatePlayerState (UIMediaController mediaController, MediaPlayerState playerState, double streamPosition);

		// @optional -(void)mediaController:(GCKUIMediaController * _Nonnull)mediaController didBeginPreloadForItemID:(NSUInteger)itemID;
		[EventArgs ("UIMediaControllerPreloadBegan")]
		[EventName ("PreloadBegan")]
		[Export ("mediaController:didBeginPreloadForItemID:")]
		void DidBeginPreload (UIMediaController mediaController, nuint itemID);

		// @optional -(void)mediaController:(GCKUIMediaController * _Nonnull)mediaController didUpdateMediaStatus:(GCKMediaStatus * _Nonnull)mediaStatus;
		[EventArgs ("UIMediaControllerMediaStatusUpdated")]
		[EventName ("MediaStatusUpdated")]
		[Export ("mediaController:didUpdateMediaStatus:")]
		void DidUpdateMediaStatus (UIMediaController mediaController, MediaStatus mediaStatus);
	}

	// @interface GCKUIMediaTrackSelectionViewController : UITabBarController
	[BaseType (typeof (UITabBarController), Name = "GCKUIMediaTrackSelectionViewController")]
	interface UIMediaTrackSelectionViewController
	{
		[Export ("initWithNibName:bundle:")]
		IntPtr Constructor (string nibName, NSBundle bundle);

		// @property (readwrite, nonatomic, weak) id<GCKUIMediaTrackSelectionViewControllerDelegate> _Nullable selectionDelegate;
		[NullAllowed]
		[Export ("selectionDelegate", ArgumentSemantic.Weak)]
		IUIMediaTrackSelectionViewControllerDelegate SelectionDelegate { get; set; }

		// @property (readwrite, nonatomic, strong) GCKMediaInformation * _Nullable mediaInfo;
		[NullAllowed]
		[Export ("mediaInfo", ArgumentSemantic.Strong)]
		MediaInformation MediaInfo { get; set; }

		// @property (readwrite, copy, nonatomic) NSArray<NSNumber *> * _Nullable selectedTrackIDs;
		[Internal]
		[NullAllowed]
		[Export ("selectedTrackIDs", ArgumentSemantic.Copy)]
		NSArray _SelectedTrackIds { get; set; }
	}

	[BaseType (typeof(UIViewController), Name = "GCKUIPlayPauseToggleController")]
	interface UIPlayPauseToggleController
	{
		// @property(nonatomic, assign, readwrite) BOOL inputEnabled;
		[Export ("inputEnabled")]
		bool InputEnabled { get; set; }

		// @property(nonatomic, assign, readwrite) GCKUIPlayPauseState playPauseState;
		[Export ("playPauseState")]
		PlayPauseState PlayPauseState { get; set; }
	}

	[BaseType(typeof(UIViewController), Name = "GCKUIStreamPositionController")]
	interface UIStreamPositionController
	{
		// @property (nonatomic, assign, readwrite) NSTimeInterval streamPosition;
		[Export ("streamPosition")]
		double StreamPosition { get; set; }

		// @property (nonatomic, assign, readwrite) NSTimeInterval streamDuration;
		[Export ("streamDuration")]
		double StreamDuration { get; set; }

		// @property (nonatomic, assign, readwrite) BOOL inputEnabled;
		[Export ("inputEnabled")]
		bool InputEnabled { get; set; }
	}

	interface IUIMediaTrackSelectionViewControllerDelegate
	{
	}

	// @protocol GCKUIMediaTrackSelectionViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject), Name = "GCKUIMediaTrackSelectionViewControllerDelegate")]
	interface UIMediaTrackSelectionViewControllerDelegate
	{
		// @required -(void)didSelectMediaTracks:(NSArray<NSNumber *> * _Nonnull)mediaTrackIDs;
		[Abstract]
		[Export ("didSelectMediaTracks:")]
		void DidSelectMediaTracks (NSNumber [] mediaTrackIDs);
	}

	// @interface GCKUIMiniMediaControlsViewController : UIViewController <GCKUIMediaButtonBarProtocol>
	[BaseType (typeof (UIViewController),
		   Name = "GCKUIMiniMediaControlsViewController",
		   Delegates = new string [] { "Delegate" },
	           Events = new Type [] { typeof (UIMiniMediaControlsViewControllerDelegate) })]
	interface UIMiniMediaControlsViewController : UIMediaButtonBarProtocol
	{
		[Export ("initWithNibName:bundle:")]
		IntPtr Constructor (string nibName, NSBundle bundle);

		// @property (readwrite, nonatomic, weak) id<GCKUIMiniMediaControlsViewControllerDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IUIMiniMediaControlsViewControllerDelegate Delegate { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL thumbnailEnabled;
		[Export ("thumbnailEnabled")]
		bool ThumbnailEnabled { get; set; }

		// @property (readonly, assign, nonatomic) BOOL active;
		[Export ("active")]
		bool Active { get; }

		// @property (readonly, assign, nonatomic) CGFloat minHeight;
		[Export ("minHeight")]
		nfloat MinHeight { get; }
	}

	interface IUIMiniMediaControlsViewControllerDelegate
	{
	}

	// @protocol GCKUIMiniMediaControlsViewControllerDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKUIMiniMediaControlsViewControllerDelegate")]
	interface UIMiniMediaControlsViewControllerDelegate
	{
		// @required -(void)miniMediaControlsViewController:(GCKUIMiniMediaControlsViewController * _Nonnull)miniMediaControlsViewController shouldAppear:(BOOL)shouldAppear;
		[Abstract]
		[EventArgs ("UIMiniMediaControlsViewControllerShouldAppear")]
		[Export ("miniMediaControlsViewController:shouldAppear:")]
		void ShouldAppear (UIMiniMediaControlsViewController miniMediaControlsViewController, bool shouldItAppear);
	}

	// @interface GCKUIStyle : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKUIStyle")]
	interface UIStyle
	{
		// +(GCKUIStyle * _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		UIStyle SharedInstance { get; }

		// -(void)applyStyle;
		[Export ("applyStyle")]
		void ApplyStyle ();

		// The GCKUIStyleAttributesCastViews class is non-external
		//// @property (readonly, nonatomic, strong) GCKUIStyleAttributesCastViews * _Nonnull castViews;
		//[Export ("castViews", ArgumentSemantic.Strong)]
		//UIStyleAttributesCastViews CastViews { get; }
	}

	// @interface GCKUIStyleAttributes : NSObject
	[BaseType (typeof (NSObject), Name = "GCKUIStyleAttributes")]
	interface UIStyleAttributes
	{
		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull closedCaptionsImage;
		[Export ("closedCaptionsImage", ArgumentSemantic.Strong)]
		UIImage ClosedCaptionsImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull forward30SecondsImage;
		[Export ("forward30SecondsImage", ArgumentSemantic.Strong)]
		UIImage Forward30SecondsImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull rewind30SecondsImage;
		[Export ("rewind30SecondsImage", ArgumentSemantic.Strong)]
		UIImage Rewind30SecondsImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull volumeImage;
		[Export ("volumeImage", ArgumentSemantic.Strong)]
		UIImage VolumeImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull muteOffImage;
		[Export ("muteOffImage", ArgumentSemantic.Strong)]
		UIImage MuteOffImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull muteOnImage;
		[Export ("muteOnImage", ArgumentSemantic.Strong)]
		UIImage MuteOnImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull pauseImage;
		[Export ("pauseImage", ArgumentSemantic.Strong)]
		UIImage PauseImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull playImage;
		[Export ("playImage", ArgumentSemantic.Strong)]
		UIImage PlayImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull skipNextImage;
		[Export ("skipNextImage", ArgumentSemantic.Strong)]
		UIImage SkipNextImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull skipPreviousImage;
		[Export ("skipPreviousImage", ArgumentSemantic.Strong)]
		UIImage SkipPreviousImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull audioTrackImage;
		[Export ("audioTrackImage", ArgumentSemantic.Strong)]
		UIImage AudioTrackImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull subtitlesTrackImage;
		[Export ("subtitlesTrackImage", ArgumentSemantic.Strong)]
		UIImage SubtitlesTrackImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIImage * _Nonnull stopImage;
		[Export ("stopImage", ArgumentSemantic.Strong)]
		UIImage StopImage { get; set; }

		// @property (readwrite, nonatomic, strong) UIFont * _Nonnull bodyTextFont;
		[Export ("bodyTextFont", ArgumentSemantic.Strong)]
		UIFont BodyTextFont { get; set; }

		// @property (readwrite, nonatomic, strong) UIFont * _Nonnull headingTextFont;
		[Export ("headingTextFont", ArgumentSemantic.Strong)]
		UIFont HeadingTextFont { get; set; }

		// @property (readwrite, nonatomic, strong) UIFont * _Nonnull captionTextFont;
		[Export ("captionTextFont", ArgumentSemantic.Strong)]
		UIFont CaptionTextFont { get; set; }

		// @property (readwrite, nonatomic, strong) UIColor * _Nonnull bodyTextColor;
		[Export ("bodyTextColor", ArgumentSemantic.Strong)]
		UIColor BodyTextColor { get; set; }

		// @property (readwrite, nonatomic, strong) UIColor * _Nonnull bodyTextShadowColor;
		[Export ("bodyTextShadowColor", ArgumentSemantic.Strong)]
		UIColor BodyTextShadowColor { get; set; }

		// @property (readwrite, nonatomic, strong) UIColor * _Nonnull headingTextColor;
		[Export ("headingTextColor", ArgumentSemantic.Strong)]
		UIColor HeadingTextColor { get; set; }

		// @property (readwrite, nonatomic, strong) UIColor * _Nonnull headingTextShadowColor;
		[Export ("headingTextShadowColor", ArgumentSemantic.Strong)]
		UIColor HeadingTextShadowColor { get; set; }

		// @property (readwrite, nonatomic, strong) UIColor * _Nonnull captionTextColor;
		[Export ("captionTextColor", ArgumentSemantic.Strong)]
		UIColor CaptionTextColor { get; set; }

		// @property (readwrite, nonatomic, strong) UIColor * _Nonnull captionTextShadowColor;
		[Export ("captionTextShadowColor", ArgumentSemantic.Strong)]
		UIColor CaptionTextShadowColor { get; set; }

		// @property (readwrite, nonatomic, strong) UIColor * _Nonnull backgroundColor;
		[Export ("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (readwrite, nonatomic, strong) UIColor * _Nonnull iconTintColor;
		[Export ("iconTintColor", ArgumentSemantic.Strong)]
		UIColor IconTintColor { get; set; }

		// @property (assign, readwrite, nonatomic) CGSize bodyTextShadowOffset;
		[Export ("bodyTextShadowOffset", ArgumentSemantic.Assign)]
		CGSize BodyTextShadowOffset { get; set; }

		// @property (assign, readwrite, nonatomic) CGSize captionTextShadowOffset;
		[Export ("captionTextShadowOffset", ArgumentSemantic.Assign)]
		CGSize CaptionTextShadowOffset { get; set; }

		// @property (assign, readwrite, nonatomic) CGSize headingTextShadowOffset;
		[Export ("headingTextShadowOffset", ArgumentSemantic.Assign)]
		CGSize HeadingTextShadowOffset { get; set; }
	}

	// @interface GCKUIUtils : NSObject
	[BaseType (typeof (NSObject), Name = "GCKUIUtils")]
	interface UIUtils
	{
		// +(UIViewController * _Nullable)currentViewController;
		[Static]
		[NullAllowed]
		[Export ("currentViewController")]
		UIViewController CurrentViewController { get; }

		// +(NSString * _Nonnull)timeIntervalAsString:(NSTimeInterval)timeInterval;
		[Static]
		[Export ("timeIntervalAsString:")]
		string ConvertTimeIntervalToString (double timeInterval);
	}

	// @interface GCKVideoInfo : NSObject
	[BaseType (typeof (NSObject), Name = "GCKVideoInfo")]
	interface VideoInfo
	{
		// @property (readonly, assign, nonatomic) NSUInteger width;
		[Export ("width")]
		nuint Width { get; }

		// @property (readonly, assign, nonatomic) NSUInteger height;
		[Export ("height")]
		nuint Height { get; }

		// @property (readonly, assign, nonatomic) GCKVideoInfoHDRType hdrType;
		[Export ("hdrType", ArgumentSemantic.Assign)]
		VideoInfoHdrType HdrType { get; }
	}

	[Category]
	[BaseType (typeof (NSDictionary), Name = "GCKTypedValueLookup")]
	interface TypedValueLookup
	{
		[return: NullAllowed]
		[Export ("gck_stringForKey:withDefaultValue:")]
		string GetString (string key, [NullAllowed] string defaultValue);

		[return: NullAllowed]
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

		[return: NullAllowed]
		[Export ("gck_dictionaryForKey:")]
		NSDictionary GetDictionary (string key);

		[return: NullAllowed]
		[Export ("gck_arrayForKey:")]
		NSObject [] GetArray (string key);

		// - (NSURL *GCK_NULLABLE_TYPE)gck_urlForKey:(NSString *)key;
		[return: NullAllowed]
		[Export ("gck_urlForKey:")]
		NSUrl GetUrl (string key);

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

	// @interface GCKAdditions (NSTimer)
	[Category]
	[BaseType (typeof (NSTimer))]
	interface NSTimer_GCKAdditions
	{
		// +(NSTimer * _Nonnull)gck_scheduledTimerWithTimeInterval:(NSTimeInterval)interval weakTarget:(id _Nonnull)target selector:(SEL _Nonnull)selector userInfo:(id _Nullable)userInfo repeats:(BOOL)repeats;
		[Static]
		[Export ("gck_scheduledTimerWithTimeInterval:weakTarget:selector:userInfo:repeats:")]
		NSTimer Gck_scheduledTimerWithTimeInterval (double interval, NSObject target, Selector selector, [NullAllowed] NSObject userInfo, bool repeats);
	}
}