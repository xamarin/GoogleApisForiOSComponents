using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;
using SessionOptions = Foundation.NSDictionary<Foundation.NSString, Foundation.INSCoding>;

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

		[Field ("kGCKInvalidRequestID", "__Internal")]
		nint InvalidRequestId { get; }
	}

	// @interface GCKAdBreakClipVastAdsRequest : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "GCKAdBreakClipVastAdsRequest")]
	interface AdBreakClipVastAdsRequest : INSCopying, INSSecureCoding 
	{
		// @property(nonatomic, strong, readonly) NSURL *adTagUrl;
		[Export ("adTagUrl", ArgumentSemantic.Strong)]
		NSUrl AdTagUrl { get; }

		// @property(nonatomic, strong, readonly) NSString *adsResponse;
		[Export ("adsResponse", ArgumentSemantic.Strong)]
		string AdsResponse { get; }
	}

	// @interface GCKAdBreakClipInfo : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GCKAdBreakClipInfo")]
	interface AdBreakClipInfo : INSCopying, INSSecureCoding
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull adBreakClipID;
		[Export ("adBreakClipID", ArgumentSemantic.Strong)]
		string AdBreakClipId { get; }

		// @property (readonly, assign, nonatomic) NSTimeInterval duration;
		[Export ("duration")]
		double Duration { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable title;
		[NullAllowed]
		[Export ("title", ArgumentSemantic.Strong)]
		string Title { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable clickThroughURL;
		[NullAllowed]
		[Export ("clickThroughURL", ArgumentSemantic.Strong)]
		NSUrl ClickThroughUrl { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable contentURL;
		[NullAllowed]
		[Export ("contentURL", ArgumentSemantic.Strong)]
		NSUrl ContentUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable mimeType;
		[NullAllowed]
		[Export ("mimeType", ArgumentSemantic.Strong)]
		string MimeType { get; }

		// @property(nonatomic, strong, readonly, GCK_NULLABLE) NSString *contentID;
		[NullAllowed]
		[Export ("contentID", ArgumentSemantic.Strong)]
		string ContentId { get; }

		// @property(nonatomic, strong, readonly, GCK_NULLABLE) NSURL *posterURL;
		[NullAllowed]
		[Export ("posterURL", ArgumentSemantic.Strong)]
		NSUrl PosterUrl { get; }

		// @property(nonatomic, assign, readonly) NSTimeInterval whenSkippable;
		[Export ("whenSkippable")]
		double WhenSkippable { get; }

		// @property(nonatomic, assign, readonly) GCKHLSSegmentFormat hlsSegmentFormat;
		[Export ("hlsSegmentFormat")]
		HlsSegmentFormat HlsSegmentFormat { get; }

		// @property(nonatomic, strong, readonly, GCK_NULLABLE) GCKAdBreakClipVastAdsRequest *vastAdsRequest;
		[NullAllowed]
		[Export ("vastAdsRequest", ArgumentSemantic.Strong)]
		AdBreakClipVastAdsRequest VastAdsRequest { get; }

		// @property (readonly, nonatomic, strong) id _Nullable customData;
		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; }
	}

	// @interface GCKAdBreakInfo : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GCKAdBreakInfo")]
	interface AdBreakInfo : INSCopying, INSSecureCoding
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull adBreakID;
		[Export ("adBreakID", ArgumentSemantic.Strong)]
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

		// @property(nonatomic, assign, readonly) BOOL embedded;
		[Export ("embedded")]
		bool Embedded { get; }

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
		[Export ("adBreakID", ArgumentSemantic.Strong)]
		string AdBreakId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull adBreakClipID;
		[Export ("adBreakClipID", ArgumentSemantic.Strong)]
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
		nint InvalidRequestId { get; }

		[Export ("protocolNamespace", ArgumentSemantic.Copy)]
		string ProtocolNamespace { get; }

		[Export ("isConnected", ArgumentSemantic.Assign)]
		bool IsConnected { get; }

		// @property(nonatomic, assign, readonly) BOOL isWritable;
		[Export ("isWritable", ArgumentSemantic.Assign)]
		bool IsWritable { get; }

		[Export ("initWithNamespace:")]
		IntPtr Constructor (string protocolNamespace);

		[Export ("didReceiveTextMessage:")]
		void DidReceiveTextMessage (string message);

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

		// - (void)didChangeWritableState:(BOOL)isWritable;
		[Export ("didChangeWritableState:")]
		void DidChangeWritableState (bool isWritable);
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

		// + (BOOL)setSharedInstanceWithOptions:(GCKCastOptions *)options error:(GCKError* GCK_NULLABLE_TYPE * GCK_NULLABLE_TYPE)error;
		[Static]
		[Export ("setSharedInstanceWithOptions:error:")]
		void SetSharedInstance (CastOptions options, out NSError error);

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

		// GCK_EXTERN NSString *const kGCKExpandedMediaControlsTriggeredNotification;
		[Notification]
		[Field ("kGCKExpandedMediaControlsTriggeredNotification", "__Internal")]
		NSString ExpandedMediaControlsTriggeredNotification { get; }

		// GCK_EXTERN NSString *const kGCKUICastDialogWillShowNotification;
		[Notification]
		[Field ("kGCKUICastDialogWillShowNotification", "__Internal")]
		NSString UICastDialogWillShowNotification { get; }

		// GCK_EXTERN NSString *const kGCKUICastDialogDidHideNotification;
		[Notification]
		[Field ("kGCKUICastDialogDidHideNotification", "__Internal")]
		NSString UICastDialogDidHideNotification { get; }

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

		// - (BOOL) presentCastInstructionsViewControllerOnce GCK_DEPRECATED ("Use presentCastInstructionsViewControllerOnceWithCastButton:");
		[Obsolete ("Use PresentCastInstructionsViewControllerOnce overloaded method instead.")] 
		[Export ("presentCastInstructionsViewControllerOnce")]
		bool PresentCastInstructionsViewControllerOnce ();

		// -(BOOL)presentCastInstructionsViewControllerOnceWithCastButton:(GCKUICastButton * _Nonnull)castButton;
		[Export ("presentCastInstructionsViewControllerOnceWithCastButton:")]
		bool PresentCastInstructionsViewControllerOnce (UICastButton castButton);

		// - (void)clearCastInstructionsShownFlag;
		[Export ("clearCastInstructionsShownFlag")]
		void ClearCastInstructionsShownFlag ();

		// - (void)presentDefaultExpandedMediaControls;
		[Export ("presentDefaultExpandedMediaControls")]
		void PresentDefaultExpandedMediaControls ();
	}

	// @interface GCKCastOptions : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GCKCastOptions")]
	interface CastOptions : INSCopying, INSSecureCoding
	{
		// -(instancetype _Nonnull)initWithDiscoveryCriteria:(GCKDiscoveryCriteria * _Nonnull)discoveryCriteria;
		[Export ("initWithDiscoveryCriteria:")]
		IntPtr Constructor (DiscoveryCriteria discoveryCriteria);

		// -(instancetype _Nonnull)initWithReceiverApplicationID:(NSString * _Nonnull)applicationID;
		[Obsolete ("Use Constructor (DiscoveryCriteria) overload instead.")]
		[Export ("initWithReceiverApplicationID:")]
		IntPtr Constructor (string applicationId);

		// -(instancetype _Nonnull)initWithSupportedNamespaces:(NSArray<NSString *> * _Nonnull)namespaces;
		[Obsolete ("Use Constructor (DiscoveryCriteria) overload instead.")]
		[Export ("initWithSupportedNamespaces:")]
		IntPtr Constructor (string [] namespaces);

		// @property (assign, readwrite, nonatomic) BOOL physicalVolumeButtonsWillControlDeviceVolume;
		[Export ("physicalVolumeButtonsWillControlDeviceVolume")]
		bool PhysicalVolumeButtonsWillControlDeviceVolume { get; set; }

		// @property (nonatomic, assign, readwrite) BOOL disableDiscoveryAutostart;
		[Export ("disableDiscoveryAutostart")]
		bool DisableDiscoveryAutostart { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL disableAnalyticsLogging;
		[Export ("disableAnalyticsLogging")]
		bool DisableAnalyticsLogging { get; set; }

		// @property (readwrite, copy, nonatomic) GCKLaunchOptions * _Nullable launchOptions;
		[NullAllowed]
		[Export ("launchOptions", ArgumentSemantic.Copy)]
		LaunchOptions LaunchOptions { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable sharedContainerIdentifier;
		[NullAllowed]
		[Export ("sharedContainerIdentifier")]
		string SharedContainerIdentifier { get; set; }

		// @property(nonatomic, assign, readwrite) BOOL suspendSessionsWhenBackgrounded;
		[Export ("suspendSessionsWhenBackgrounded")]
		bool SuspendSessionsWhenBackgrounded { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL stopReceiverApplicationWhenEndingSession;
		[Export ("stopReceiverApplicationWhenEndingSession")]
		bool StopReceiverApplicationWhenEndingSession { get; set; }
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

		// -(instancetype _Nonnull)initWithDevice:(GCKDevice * _Nonnull)device sessionID:(NSString * _Nullable)sessionID sessionOptions:(GCKSessionOptions * _Nullable)sessionOptions castOptions:(GCKCastOptions * _Nonnull)castOptions;
		[Export ("initWithDevice:sessionID:sessionOptions:castOptions:")]
		IntPtr Constructor (Device device, [NullAllowed] string sessionId, [NullAllowed] SessionOptions sessionOptions, CastOptions castOptions);

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
	interface Color : INSCopying, INSSecureCoding
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

		// -(instancetype _Nonnull)initWithCGColor:(CGColorRef _Nonnull)color alpha:(CGFloat)alpha;
		[Export ("initWithCGColor:alpha:")]
		IntPtr Constructor (CGColor color, nfloat alpha);

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
	interface Device : INSCopying, INSSecureCoding
	{
		// extern NSString *const _Nonnull kGCKCastDeviceCategory __attribute__((visibility("default")));
		[Field ("kGCKCastDeviceCategory", "__Internal")]
		NSString CastDeviceCategory { get; }

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
		string UniqueId { get; }

		[Export ("isSameDeviceAs:")]
		bool SameDevice (Device device);

		[Export ("hasCapabilities:")]
		bool HasCapabilities (nint deviceCapabilities);

		[Export ("setAttribute:forKey:")]
		void SetAttribute (INSSecureCoding attribute, string key);

		[return: NullAllowed]
		[Export ("attributeForKey:")]
		INSSecureCoding GetAttribute (string key);

		[Export ("removeAttributeForKey:")]
		void RemoveAttribute (string key);

		// - (void)removeAllAttributes;
		[Export ("removeAllAttributes")]
		void RemoveAllAttributes ();

		// +(NSString * _Nonnull)deviceCategoryForDeviceUniqueID:(NSString * _Nonnull)deviceUniqueID;
		[Static]
		[Export ("deviceCategoryForDeviceUniqueID:")]
		string GetDeviceCategory (string deviceUniqueId);
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

		// -(GCKSession * _Nonnull)createSessionForDevice:(GCKDevice * _Nonnull)device sessionID:(NSString * _Nullable)sessionID sessionOptions:(GCKSessionOptions * _Nullable)sessionOptions;
		[Export ("createSessionForDevice:sessionID:sessionOptions:")]
		Session CreateSession (Device device, [NullAllowed] string sessionId, [NullAllowed] SessionOptions sessionOptions);

		// -(GCKSession * _Nonnull)createSessionForDevice:(GCKDevice * _Nonnull)device sessionID:(NSString * _Nullable)sessionID;
		[Obsolete ("Use CreateSession method instead.")]
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

	// @interface GCKDiscoveryCriteria : NSObject <NSCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKDiscoveryCriteria")]
	interface DiscoveryCriteria : INSCopying, INSSecureCoding
	{
		// extern NSString *const _Nonnull kGCKDefaultMediaReceiverApplicationID __attribute__((visibility("default")));
		[Field ("kGCKDefaultMediaReceiverApplicationID", "__Internal")]
		NSString DefaultMediaReceiverApplicationId { get; }

		// @property (readonly, nonatomic, strong) NSOrderedSet<NSString *> * _Nullable applicationIDs;
		[NullAllowed]
		[Export ("applicationIDs", ArgumentSemantic.Strong)]
		NSOrderedSet<NSString> ApplicationIds { get; }

		// @property (readonly, assign, nonatomic) BOOL hasApplicationIDs;
		[Export ("hasApplicationIDs")]
		bool HasApplicationIds { get; }

		// @property (readonly, nonatomic, strong) NSSet<NSString *> * _Nullable namespaces;
		[NullAllowed]
		[Export ("namespaces", ArgumentSemantic.Strong)]
		NSSet<NSString> Namespaces { get; }

		// @property (readonly, assign, nonatomic) BOOL hasNamespaces;
		[Export ("hasNamespaces")]
		bool HasNamespaces { get; }

		// @property (readonly, nonatomic, strong) NSSet<NSString *> * _Nonnull allSubtypes;
		[Export ("allSubtypes", ArgumentSemantic.Strong)]
		NSSet<NSString> AllSubtypes { get; }

		// -(instancetype _Nonnull)initWithApplicationID:(NSString * _Nonnull)applicationID;
		[Export ("initWithApplicationID:")]
		IntPtr Constructor (string applicationId);

		// -(instancetype _Nonnull)initWithNamespaces:(NSSet<NSString *> * _Nonnull)namespaces;
		[Internal]
		[Export ("initWithNamespaces:")]
		IntPtr _InitWithNamespaces (NSSet<NSString> namespaces);
	}

	// @interface GCKDiscoveryManager : NSObject
	[DisableDefaultCtor]
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

		// @property(nonatomic, assign, readonly) BOOL discoveryActive;
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
		Device GetDevice (string uniqueId);

		// -(void)findDeviceWithUniqueID:(NSString * _Nonnull)uniqueID timeout:(NSTimeInterval)timeout completion:(void (^ _Nonnull)(GCKDevice * _Nonnull))completion;
		[Async]
		[Export ("findDeviceWithUniqueID:timeout:completion:")]
		void FindDevice (string uniqueId, double timeout, Action<Device> completion);

		// -(void)cancelFindOperation;
		[Export ("cancelFindOperation")]
		void CancelFindOperation ();
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

		// @optional - (void)didRemoveDevice:(GCKDevice *)device atIndex:(NSUInteger)index;
		[Export ("didRemoveDevice:atIndex:")]
		void DidRemoveDevice (Device device, nuint index);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSError), Name = "GCKError")]
	interface Error
	{

		[Field ("kGCKErrorCustomDataKey", "__Internal")]
		NSString CustomDataKey { get; }

		// extern NSString *const _Nonnull kGCKErrorExtraInfoKey __attribute__((visibility("default")));
		[Field ("kGCKErrorExtraInfoKey", "__Internal")]
		NSString ExtraInfoKey { get; }

		[Field ("kGCKErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

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

		// @optional -(void)castChannel:(GCKCastChannel * _Nonnull)channel didChangeWritableState:(BOOL)writable;
		[EventArgs ("GenericChannelWritableStateChanged")]
		[EventName ("WritableStateChanged")]
		[Export ("castChannel:didChangeWritableState:")]
		void DidChangeWritableState (CastChannel channel, bool writable);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKImage")]
	interface Image : INSCopying, INSSecureCoding
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
	interface LaunchOptions : INSCopying, INSSecureCoding
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

		// @property (assign, readwrite, nonatomic) BOOL consoleLoggingEnabled;
		[Export ("consoleLoggingEnabled")]
		bool ConsoleLoggingEnabled { get; set; }

		// @property (nonatomic, assign, readwrite) NSUInteger maxLogFileSize;
		[Export ("maxLogFileSize")]
		nuint MaxLogFileSize { get; set; }

		// @property (assign, readwrite, nonatomic) NSUInteger maxLogFileCount;
		[Export ("maxLogFileCount")]
		nuint MaxLogFileCount { get; set; }

		// @property (assign, readwrite, nonatomic) GCKLoggerLevel minimumLevel;
		[Obsolete ("Specify minimum logging level in LoggerFilter class.")]
		[Export ("minimumLevel", ArgumentSemantic.Assign)]
		LoggerLevel MinimumLevel { get; set; }

		[Static]
		[Export ("sharedInstance")]
		Logger SharedInstance { get; }
	}

	interface ILoggerDelegate
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GCKLoggerDelegate")]
	interface LoggerDelegate
	{
		// @optional -(void)logMessage:(NSString * _Nonnull)message atLevel:(GCKLoggerLevel)level fromFunction:(NSString * _Nonnull)function location:(NSString * _Nonnull)location;
		[Export ("logMessage:atLevel:fromFunction:location:")]
		void LogMessage (string message, LoggerLevel level, string function, string location);

		// @optional -(void)logMessage:(NSString * _Nonnull)message fromFunction:(NSString * _Nonnull)function __attribute__((deprecated("Use -[GCKLoggerDelegate logMessage:atLevel:fromFunction:location:]")));
		[Obsolete ("Use LogMessage (string, LoggerLevel, string, string) overloaded method instead.")]
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

	[Static]
	interface MediaCommon
	{
		// extern const NSTimeInterval kGCKInvalidTimeInterval __attribute__((visibility("default")));
		[Field ("kGCKInvalidTimeInterval", "__Internal")]
		double InvalidTimeInterval { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKMediaInformation")]
	interface MediaInformation : INSCopying, INSSecureCoding
	{

		[Export ("contentID", ArgumentSemantic.Copy)]
		string ContentId { get; }

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

		// @property (readonly, copy, nonatomic) NSString * _Nullable entity;
		[NullAllowed]
		[Export ("entity")]
		string Entity { get; }

		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; }

		[Export ("initWithContentID:streamType:contentType:metadata:streamDuration:mediaTracks:textTrackStyle:customData:")]
		IntPtr Constructor (string contentId, MediaStreamType streamType, string contentType, [NullAllowed] MediaMetadata metadata, double streamDuration, [NullAllowed] MediaTrack [] mediaTracks, [NullAllowed] MediaTextTrackStyle textTrackStyle, [NullAllowed] NSObject customData);

		// -(GCKMediaTrack * _Nullable)mediaTrackWithID:(NSInteger)trackID;
		[return: NullAllowed]
		[Export ("mediaTrackWithID:")]
		MediaTrack GetMediaTrack (nint trackId);
	}

	// @interface GCKMediaInformationBuilder : NSObject
	[BaseType (typeof (NSObject), Name = "GCKMediaInformationBuilder")]
	interface MediaInformationBuilder
	{
		// @property (readwrite, copy, nonatomic) NSString * _Nonnull contentID;
		[Export ("contentID")]
		string ContentId { get; set; }

		// @property (assign, readwrite, nonatomic) GCKMediaStreamType streamType;
		[Export ("streamType", ArgumentSemantic.Assign)]
		MediaStreamType StreamType { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nonnull contentType;
		[Export ("contentType")]
		string ContentType { get; set; }

		// @property (readwrite, nonatomic, strong) GCKMediaMetadata * _Nullable metadata;
		[NullAllowed]
		[Export ("metadata", ArgumentSemantic.Strong)]
		MediaMetadata Metadata { get; set; }

		// @property (readwrite, copy, nonatomic) NSArray<GCKAdBreakInfo *> * _Nullable adBreaks;
		[NullAllowed]
		[Export ("adBreaks", ArgumentSemantic.Copy)]
		AdBreakInfo [] AdBreaks { get; set; }

		// @property (readwrite, copy, nonatomic) NSArray<GCKAdBreakClipInfo *> * _Nullable adBreakClips;
		[NullAllowed]
		[Export ("adBreakClips", ArgumentSemantic.Copy)]
		AdBreakClipInfo [] AdBreakClips { get; set; }

		// @property (assign, readwrite, nonatomic) NSTimeInterval streamDuration;
		[Export ("streamDuration")]
		double StreamDuration { get; set; }

		// @property (readwrite, copy, nonatomic) NSArray<GCKMediaTrack *> * _Nullable mediaTracks;
		[NullAllowed]
		[Export ("mediaTracks", ArgumentSemantic.Copy)]
		MediaTrack [] MediaTracks { get; set; }

		// @property (readwrite, copy, nonatomic) GCKMediaTextTrackStyle * _Nullable textTrackStyle;
		[NullAllowed]
		[Export ("textTrackStyle", ArgumentSemantic.Copy)]
		MediaTextTrackStyle TextTrackStyle { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable entity;
		[NullAllowed]
		[Export ("entity")]
		string Entity { get; set; }

		// @property (readwrite, nonatomic, strong) id _Nullable customData;
		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; set; }

		// -(instancetype _Nonnull)initWithContentID:(NSString * _Nonnull)contentID;
		[Internal]
		[Export ("initWithContentID:")]
		IntPtr _InitWithContentId (string contentId);

		// -(instancetype _Nonnull)initWithContentID:(NSString * _Nonnull)contentID entity:(NSString * _Nonnull)entity;
		[Export ("initWithContentID:entity:")]
		IntPtr Constructor (string contentID, string entity);

		// -(instancetype _Nonnull)initWithEntity:(NSString * _Nonnull)entity;
		[Internal]
		[Export ("initWithEntity:")]
		IntPtr _InitWithEntity (string entity);

		// -(instancetype _Nonnull)initWithMediaInformation:(GCKMediaInformation * _Nonnull)mediaInfo;
		[Export ("initWithMediaInformation:")]
		IntPtr Constructor (MediaInformation mediaInfo);

		// -(GCKMediaInformation * _Nonnull)build;
		[Export ("build")]
		MediaInformation Build ();
	}

	// @interface GCKMediaLoadOptions : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "GCKMediaLoadOptions")]
	interface MediaLoadOptions : INSCopying, INSSecureCoding
	{
		// @property (assign, readwrite, nonatomic) BOOL autoplay;
		[Export ("autoplay")]
		bool Autoplay { get; set; }

		// @property (assign, readwrite, nonatomic) NSTimeInterval playPosition;
		[Export ("playPosition")]
		double PlayPosition { get; set; }

		// @property (assign, readwrite, nonatomic) float playbackRate;
		[Export ("playbackRate")]
		float PlaybackRate { get; set; }

		// @property (readwrite, nonatomic, strong) NSArray<NSNumber *> * _Nullable activeTrackIDs;
		[NullAllowed]
		[Export ("activeTrackIDs", ArgumentSemantic.Strong)]
		NSArray _ActiveTrackIds { get; set; }

		// @property (readwrite, nonatomic, strong) id _Nullable customData;
		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; set; }
	}

	[Static]
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
	interface MediaMetadata : INSCopying, INSSecureCoding
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
		nuint ItemId { get; }

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
		NSArray _ActiveTrackIds { get; }

		//@property(nonatomic, strong, readonly) id customData;
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; }

		// - (instancetype)initWithMediaInformation:(GCKMediaInformation *)mediaInformation autoplay:(BOOL)autoplay startTime:(NSTimeInterval)startTime preloadTime:(NSTimeInterval)preloadTime activeTrackIDs:(NSArray *)activeTrackIDs customData:(id)customData;
		[Internal]
		[Export ("initWithMediaInformation:autoplay:startTime:preloadTime:activeTrackIDs:customData:")]
		IntPtr _InitWithMediaInformation (MediaInformation mediaInformation, bool autoplay, double startTime, double preloadTime, [NullAllowed] NSArray activeTrackIds, [NullAllowed] NSObject customData);

		// - (instancetype)initWithMediaInformation:(GCKMediaInformation *)mediaInformation autoplay:(BOOL)autoplay startTime:(NSTimeInterval)startTime playbackDuration:(NSTimeInterval)playbackDuration preloadTime:(NSTimeInterval)preloadTime activeTrackIDs:(NSArray *)activeTrackIDs customData:(id)customData;
		[Internal]
		[Export ("initWithMediaInformation:autoplay:startTime:playbackDuration:preloadTime:activeTrackIDs:customData:")]
		IntPtr _InitWithMediaInformation (MediaInformation mediaInformation, bool autoplay, double startTime, double playbackDuration, double preloadTime, [NullAllowed] NSArray activeTrackIds, [NullAllowed] NSObject customData);

		// - (void)clearItemID;
		[Export ("clearItemID")]
		void ClearItemId ();

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
		NSArray _ActiveTrackIds { get; set; }

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

	// @interface GCKMediaRequestItem : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "GCKMediaRequestItem")]
	interface MediaRequestItem : INSCopying, INSSecureCoding
	{
		// +(NSString * _Nonnull)mapHLSSegmentFormatToString:(GCKHLSSegmentFormat)hlsSegmentFormat;
		[Static]
		[Export ("mapHLSSegmentFormatToString:")]
		string MapHlsSegmentFormatToString (HlsSegmentFormat hlsSegmentFormat);

		// +(GCKHLSSegmentFormat)mapHLSSegmentFormatStringToEnum:(NSString * _Nonnull)hlsSegmentFormatString;
		[Static]
		[Export ("mapHLSSegmentFormatStringToEnum:")]
		HlsSegmentFormat MapHlsSegmentFormatStringToEnum (string hlsSegmentFormatString);

		// -(instancetype _Nonnull)initWithURL:(NSURL * _Nonnull)url protocolType:(GCKStreamingProtocolType)protocolType initialTime:(NSTimeInterval)initialTime hlsSegmentFormat:(GCKHLSSegmentFormat)hlsSegmentFormat;
		[Export ("initWithURL:protocolType:initialTime:hlsSegmentFormat:")]
		IntPtr Constructor (NSUrl url, StreamingProtocolType protocolType, double initialTime, HlsSegmentFormat hlsSegmentFormat);

		// -(instancetype _Nonnull)initWithURL:(NSURL * _Nonnull)url protocolType:(GCKStreamingProtocolType)protocolType;
		[Export ("initWithURL:protocolType:")]
		IntPtr Constructor (NSUrl url, StreamingProtocolType protocolType);

		// @property (readwrite, nonatomic, strong) NSURL * _Nonnull mediaURL;
		[Export ("mediaURL", ArgumentSemantic.Strong)]
		NSUrl MediaUrl { get; set; }

		// @property (assign, readwrite, nonatomic) GCKStreamingProtocolType protocolType;
		[Export ("protocolType", ArgumentSemantic.Assign)]
		StreamingProtocolType ProtocolType { get; set; }

		// @property (assign, readwrite, nonatomic) NSTimeInterval initialTime;
		[Export ("initialTime")]
		double InitialTime { get; set; }

		// @property (assign, readwrite, nonatomic) GCKHLSSegmentFormat hlsSegmentFormat;
		[Export ("hlsSegmentFormat", ArgumentSemantic.Assign)]
		HlsSegmentFormat HlsSegmentFormat { get; set; }
	}

	// @interface GCKMediaSeekOptions : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "GCKMediaSeekOptions")]
	interface MediaSeekOptions : INSCopying, INSSecureCoding
	{
		// @property (assign, readwrite, nonatomic) NSTimeInterval interval;
		[Export ("interval")]
		double Interval { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL relative;
		[Export ("relative")]
		bool Relative { get; set; }

		// @property (assign, readwrite, nonatomic) GCKMediaResumeState resumeState;
		[Export ("resumeState", ArgumentSemantic.Assign)]
		MediaResumeState ResumeState { get; set; }

		// @property (readwrite, nonatomic, strong) id _Nullable customData;
		[NullAllowed]
		[Export ("customData", ArgumentSemantic.Strong)]
		NSObject CustomData { get; set; }
	}

	[Static]
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
		nuint CurrentItemId { get; }

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
		nuint PreloadedItemId { get; }

		[Export ("loadingItemID", ArgumentSemantic.Assign)]
		nuint LoadingItemId { get; }

		[Internal]
		[NullAllowed]
		[Export ("activeTrackIDs", ArgumentSemantic.Assign)]
		NSArray _ActiveTrackIds { get; }

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
		IntPtr Constructor (nint mediaSessionId, [NullAllowed] MediaInformation mediaInformation);

		[Export ("isMediaCommandSupported:")]
		bool IsMediaCommandSupported (nint command);

		[Export ("queueItemCount")]
		nuint QueueItemCount { get; }

		[return: NullAllowed]
		[Export ("queueItemAtIndex:")]
		MediaQueueItem QueueItemAt (nuint index);

		[return: NullAllowed]
		[Export ("queueItemWithItemID:")]
		MediaQueueItem QueueItem (nuint itemId);

		// - (NSInteger)queueIndexForItemID:(NSUInteger)itemID;
		[Export ("queueIndexForItemID:")]
		nint QueueIndex (nuint itemId);
	}

	[BaseType (typeof (NSObject), Name = "GCKMediaTextTrackStyle")]
	interface MediaTextTrackStyle : INSCopying, INSSecureCoding
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
	interface MediaTrack : INSCopying, INSSecureCoding
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
	interface MultizoneDevice : INSCopying, INSSecureCoding
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
		IntPtr Constructor (NSObject JsonObject);

		// -(instancetype _Nonnull)initWithDeviceID:(NSString * _Nonnull)deviceID friendlyName:(NSString * _Nonnull)friendlyName capabilities:(NSInteger)capabilities volumeLevel:(float)volume muted:(BOOL)muted;
		[Export ("initWithDeviceID:friendlyName:capabilities:volumeLevel:muted:")]
		IntPtr Constructor (string deviceId, string friendlyName, nint capabilities, float volume, bool muted);
	}

	// @interface GCKMultizoneStatus : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "GCKMultizoneStatus")]
	interface MultizoneStatus : INSCopying, INSSecureCoding
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

	// @interface GCKOpenURLOptions : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "GCKOpenURLOptions")]
	interface OpenUrlOptions : INSCopying, INSSecureCoding
	{
		// @property (readwrite, copy, nonatomic) NSString * _Nullable deviceUniqueID;
		[NullAllowed]
		[Export ("deviceUniqueID")]
		string DeviceUniqueId { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable deviceFriendlyName;
		[NullAllowed]
		[Export ("deviceFriendlyName")]
		string DeviceFriendlyName { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable sessionID;
		[NullAllowed]
		[Export ("sessionID")]
		string SessionId { get; set; }

		// +(GCKOpenURLOptions * _Nullable)openURLOptionsFromURL:(NSURL * _Nonnull)url;
		[Static]
		[return: NullAllowed]
		[Export ("openURLOptionsFromURL:")]
		OpenUrlOptions Create (NSUrl url);

		// -(NSURLQueryItem * _Nonnull)asURLQueryItem;
		[Export ("asURLQueryItem")]
		NSUrlQueryItem AsUrlQueryItem ();
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

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo withOptions:(GCKMediaLoadOptions * _Nonnull)options;
		[Export ("loadMedia:withOptions:")]
		Request LoadMedia (MediaInformation mediaInfo, MediaLoadOptions options);

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo autoplay:(BOOL)autoplay __attribute__((deprecated("Use loadMedia:withOptions:")));
		[Obsolete ("Use LoadMedia (MediaInformation, MediaLoadOptions) overloaded method instead.")]
		[Export ("loadMedia:autoplay:")]
		Request LoadMedia (MediaInformation mediaInfo, bool autoplay);

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo autoplay:(BOOL)autoplay playPosition:(NSTimeInterval)playPosition;
		[Obsolete ("Use LoadMedia (MediaInformation, MediaLoadOptions) overloaded method instead.")]
		[Export ("loadMedia:autoplay:playPosition:")]
		Request LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition);

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo autoplay:(BOOL)autoplay playPosition:(NSTimeInterval)playPosition customData:(id _Nullable)customData;
		[Obsolete ("Use LoadMedia (MediaInformation, MediaLoadOptions) overloaded method instead.")]
		[Export ("loadMedia:autoplay:playPosition:customData:")]
		Request LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo autoplay:(BOOL)autoplay playPosition:(NSTimeInterval)playPosition activeTrackIDs:(NSArray<NSNumber *> * _Nullable)activeTrackIDs;
		[Internal]
		[Export ("loadMedia:autoplay:playPosition:activeTrackIDs:")]
		Request _LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSArray activeTrackIds);

		// -(GCKRequest * _Nonnull)loadMedia:(GCKMediaInformation * _Nonnull)mediaInfo autoplay:(BOOL)autoplay playPosition:(NSTimeInterval)playPosition activeTrackIDs:(NSArray<NSNumber *> * _Nullable)activeTrackIDs customData:(id _Nullable)customData;
		[Internal]
		[Export ("loadMedia:autoplay:playPosition:activeTrackIDs:customData:")]
		Request _LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, [NullAllowed] NSArray activeTrackIds, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)setPlaybackRate:(float)playbackRate;
		[Export ("setPlaybackRate:")]
		Request SetPlaybackRate (float playbackRate);

		// -(GCKRequest * _Nonnull)setPlaybackRate:(float)playbackRate customData:(id _Nullable)customData;
		[Export ("setPlaybackRate:customData:")]
		Request SetPlaybackRate (float playbackRate, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)setActiveTrackIDs:(NSArray<NSNumber *> * _Nullable)activeTrackIDs;
		[Internal]
		[Export ("setActiveTrackIDs:")]
		Request _SetActiveTrackIds ([NullAllowed] NSArray activeTrackIds);

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

		// -(GCKRequest * _Nonnull)seekWithOptions:(GCKMediaSeekOptions * _Nonnull)options;
		[Export ("seekWithOptions:")]
		Request Seek (MediaSeekOptions options);

		// -(GCKRequest * _Nonnull)seekToTimeInterval:(NSTimeInterval)position;
		[Obsolete ("Use Seek method instead.")]
		[Export ("seekToTimeInterval:")]
		Request SeekTo (double position);

		// -(GCKRequest * _Nonnull)seekToTimeInterval:(NSTimeInterval)position resumeState:(GCKMediaResumeState)resumeState;
		[Obsolete ("Use Seek method instead.")]
		[Export ("seekToTimeInterval:resumeState:")]
		Request SeekTo (double position, MediaResumeState resumeState);

		// -(GCKRequest * _Nonnull)seekToTimeInterval:(NSTimeInterval)position resumeState:(GCKMediaResumeState)resumeState customData:(id _Nullable)customData;
		[Obsolete ("Use Seek method instead.")]
		[Export ("seekToTimeInterval:resumeState:customData:")]
		Request SeekTo (double position, MediaResumeState resumeState, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueFetchItemIDs;
		[Export ("queueFetchItemIDs")]
		Request QueueFetchItemIds ();

		// -(GCKRequest * _Nonnull)queueFetchItemsForIDs:(NSArray<NSNumber *> * _Nonnull)queueItemIDs;
		[Internal]
		[Export ("queueFetchItemsForIDs:")]
		Request _QueueFetchItems (NSArray queueItemIds);

		// -(GCKRequest * _Nonnull)queueLoadItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems startIndex:(NSUInteger)startIndex repeatMode:(GCKMediaRepeatMode)repeatMode __attribute__((deprecated("Use queueLoadItems:withOptions:")));
		[Obsolete]
		[Export ("queueLoadItems:startIndex:repeatMode:")]
		Request QueueLoadItems (MediaQueueItem [] queueItems, nuint startIndex, MediaRepeatMode repeatMode);

		// -(GCKRequest * _Nonnull)queueLoadItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems startIndex:(NSUInteger)startIndex repeatMode:(GCKMediaRepeatMode)repeatMode customData:(id _Nullable)customData __attribute__((deprecated("Use queueLoadItems:withOptions:")));
		[Obsolete]
		[Export ("queueLoadItems:startIndex:repeatMode:customData:")]
		Request QueueLoadItems (MediaQueueItem [] queueItems, nuint startIndex, MediaRepeatMode repeatMode, [NullAllowed] NSObject customData);

		// -(GCKRequest * _Nonnull)queueLoadItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems startIndex:(NSUInteger)startIndex playPosition:(NSTimeInterval)playPosition repeatMode:(GCKMediaRepeatMode)repeatMode customData:(id _Nullable)customData __attribute__((deprecated("Use queueLoadItems:withOptions:")));
		[Obsolete]
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
		void DidUpdateMediaStatus (RemoteMediaClient client, [NullAllowed] MediaStatus mediaStatus);

		// @optional -(void)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client didUpdateMediaMetadata:(GCKMediaMetadata * _Nonnull)mediaMetadata;
		[Export ("remoteMediaClient:didUpdateMediaMetadata:")]
		void DidUpdateMediaMetadata (RemoteMediaClient client, [NullAllowed] MediaMetadata mediaMetadata);

		// @optional -(void)remoteMediaClientDidUpdateQueue:(GCKRemoteMediaClient * _Nonnull)client;
		[Export ("remoteMediaClientDidUpdateQueue:")]
		void DidUpdateQueue (RemoteMediaClient client);

		// @optional -(void)remoteMediaClientDidUpdatePreloadStatus:(GCKRemoteMediaClient * _Nonnull)client;
		[Export ("remoteMediaClientDidUpdatePreloadStatus:")]
		void DidUpdatePreloadStatus (RemoteMediaClient client);

		// @optional -(void)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client didReceiveQueueItemIDs:(NSArray<NSNumber *> * _Nonnull)queueItemIDs;
		[Export ("remoteMediaClient:didReceiveQueueItemIDs:")]
		void DidReceiveQueueItemIds (RemoteMediaClient client, NSNumber [] queueItemIds);

		// @optional -(void)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client didInsertQueueItemsWithIDs:(NSArray<NSNumber *> * _Nonnull)queueItemIDs beforeItemWithID:(GCKMediaQueueItemID)beforeItemID;
		[Export ("remoteMediaClient:didInsertQueueItemsWithIDs:beforeItemWithID:")]
		void DidInsertQueueItems (RemoteMediaClient client, NSNumber [] queueItemIds, nuint beforeItemId);

		// @optional -(void)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client didUpdateQueueItemsWithIDs:(NSArray<NSNumber *> * _Nonnull)queueItemIDs;
		[Export ("remoteMediaClient:didUpdateQueueItemsWithIDs:")]
		void DidUpdateQueueItems (RemoteMediaClient client, NSNumber [] queueItemIds);

		// @optional -(void)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client didRemoveQueueItemsWithIDs:(NSArray<NSNumber *> * _Nonnull)queueItemIDs;
		[Export ("remoteMediaClient:didRemoveQueueItemsWithIDs:")]
		void DidRemoveQueueItems (RemoteMediaClient client, NSNumber [] queueItemIds);

		// @optional -(void)remoteMediaClient:(GCKRemoteMediaClient * _Nonnull)client didReceiveQueueItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)queueItems;
		[Export ("remoteMediaClient:didReceiveQueueItems:")]
		void DidReceiveQueueItems (RemoteMediaClient client, MediaQueueItem [] queueItems);
	}

	interface IRemoteMediaClientAdInfoParserDelegate
	{
	}

	// @protocol GCKRemoteMediaClientAdInfoParserDelegate <NSObject>
	[Obsolete]
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

		// -(void)notifyDidReceiveQueueItemIDs:(NSArray<NSNumber *> * _Nonnull)itemIDs;
		[Internal]
		[Export ("notifyDidReceiveQueueItemIDs:")]
		void _NotifyDidReceiveQueueItemIds (NSArray itemIds);

		// -(void)notifyDidInsertQueueItemsWithIDs:(NSArray<NSNumber *> * _Nonnull)itemIDs beforeItemWithID:(GCKMediaQueueItemID)beforeItemID;
		[Internal]
		[Export ("notifyDidInsertQueueItemsWithIDs:beforeItemWithID:")]
		void _NotifyDidInsertQueueItems (NSArray itemIds, nuint beforeItemId);

		// -(void)notifyDidUpdateQueueItemsWithIDs:(NSArray<NSNumber *> * _Nonnull)itemIDs;
		[Internal]
		[Export ("notifyDidUpdateQueueItemsWithIDs:")]
		void _NotifyDidUpdateQueueItems (NSArray itemIds);

		// -(void)notifyDidRemoveQueueItemsWithIDs:(NSArray<NSNumber *> * _Nonnull)itemIDs;
		[Internal]
		[Export ("notifyDidRemoveQueueItemsWithIDs:")]
		void _NotifyDidRemoveQueueItems (NSArray itemIds);

		// -(void)notifyDidReceiveQueueItems:(NSArray<GCKMediaQueueItem *> * _Nonnull)items;
		[Export ("notifyDidReceiveQueueItems:")]
		void NotifyDidReceiveQueueItems (MediaQueueItem [] items);
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

		// @property(nonatomic, assign, readonly) BOOL external;
		[Export ("external")]
		bool External { get; }

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// +(GCKRequest *) applicationRequest
		[Static]
		[Export ("applicationRequest")]
		Request GetApplicationRequest ();

		// - (void)complete;
		[Export ("complete")]
		void Complete ();

		// - (void)failWithError:(GCKError *)error;
		[Export ("failWithError:")]
		void Fail (Error error);

		// - (void)abortWithReason:(GCKRequestAbortReason)reason;
		[Export ("abortWithReason:")]
		void Abort (RequestAbortReason reason);
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

		// @property (readonly, nonatomic, strong) GCKSessionOptions * _Nullable sessionOptions;
		[NullAllowed]
		[Export ("sessionOptions", ArgumentSemantic.Strong)]
		SessionOptions SessionOptions { get; }

		// @property (readonly, assign, nonatomic) GCKConnectionState connectionState;
		[Export ("connectionState", ArgumentSemantic.Assign)]
		ConnectionState ConnectionState { get; }

		// @property (readonly, assign, nonatomic) BOOL suspended;
		[Obsolete ("Session class no longer supports being in a suspended state. If needed, move this functionality to a subclass.")]
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
		[Export ("currentDeviceVolume")]
		float CurrentDeviceVolume { get; }

		// @property (readonly, assign, nonatomic) BOOL currentDeviceMuted;
		// -(void)setDeviceMuted:(BOOL)muted;
		[Export ("currentDeviceMuted")]
		bool CurrentDeviceMuted { get; }

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

		// -(instancetype _Nonnull)initWithDevice:(GCKDevice * _Nonnull)device traits:(GCKSessionTraits * _Nonnull)traits sessionID:(NSString * _Nullable)sessionID sessionOptions:(GCKSessionOptions * _Nullable)sessionOptions;
		[Export ("initWithDevice:traits:sessionID:sessionOptions:")]
		IntPtr Constructor (Device device, SessionTraits traits, [NullAllowed] string sessionId, [NullAllowed] SessionOptions sessionOptions);

		// - (GCKRequest*) setDeviceVolume:(float) volume;
		[Export ("setDeviceVolume:")]
		Request SetDeviceVolume (float volume);

		// - (GCKRequest *)setDeviceMuted:(BOOL)muted;
		[Export ("setDeviceMuted:")]
		Request SetDeviceMuted (bool muted);
	}

	// @interface Protected (GCKSession)
	[Category]
	[BaseType (typeof (Session))]
	interface Session_Protected
	{
		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)endWithAction:(GCKSessionEndAction)action;
		[Export ("endWithAction:")]
		void End (SessionEndAction action);

		// -(void)notifyDidStartWithSessionID:(NSString * _Nonnull)sessionID;
		[Export ("notifyDidStartWithSessionID:")]
		void NotifyDidStart (string sessionId);

		// -(void)notifyDidFailToStartWithError:(NSError * _Nonnull)error;
		[Export ("notifyDidFailToStartWithError:")]
		void NotifyDidFailToStart (NSError error);

		// -(void)notifyDidResume;
		[Obsolete ("Do not call")]
		[Export ("notifyDidResume")]
		void NotifyDidResume ();

		// -(void)notifyDidSuspendWithReason:(GCKConnectionSuspendReason)reason;
		[Obsolete ("Do not call")]
		[Export ("notifyDidSuspendWithReason:")]
		void NotifyDidSuspend (ConnectionSuspendReason reason);

		// -(void)notifyDidEndWithError:(NSError * _Nullable)error;
		[Export ("notifyDidEndWithError:willTryToResume:")]
		void NotifyDidEnd ([NullAllowed] NSError error, bool willTryToResume);

		// -(void)notifyDidReceiveDeviceVolume:(float)volume muted:(BOOL)muted;
		[Export ("notifyDidReceiveDeviceVolume:muted:")]
		void NotifyDidReceiveDeviceVolume (float volume, bool muted);

		// -(void)notifyDidReceiveDeviceStatus:(NSString * _Nullable)statusText;
		[Export ("notifyDidReceiveDeviceStatus:")]
		void NotifyDidReceiveDeviceStatus ([NullAllowed] string statusText);
	}

	// @interface GCKSessionManager : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKSessionManager")]
	interface SessionManager
	{
		// GCK_EXTERN NSString *const kGCKKeyConnectionState;
		[Field ("kGCKKeyConnectionState", "__Internal")]
		NSString KeyConnectionState { get; }

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

		// -(BOOL)startSessionWithDevice:(GCKDevice * _Nonnull)device sessionOptions:(GCKSessionOptions * _Nullable)options;
		[Export ("startSessionWithDevice:sessionOptions:")]
		bool StartSession (Device device, [NullAllowed] SessionOptions options);

		// -(BOOL)startSessionWithOpenURLOptions:(GCKOpenURLOptions * _Nonnull)openURLOptions sessionOptions:(GCKSessionOptions * _Nullable)sessionOptions;
		[Export ("startSessionWithOpenURLOptions:sessionOptions:")]
		bool StartSession (OpenUrlOptions openUrlOptions, [NullAllowed] SessionOptions sessionOptions);

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

		// -(void)setDefaultSessionOptions:(GCKSessionOptions * _Nullable)sessionOptions forDeviceCategory:(NSString * _Nonnull)category;
		[Export ("setDefaultSessionOptions:forDeviceCategory:")]
		void SetDefaultSessionOptions ([NullAllowed] SessionOptions sessionOptions, string category);

		// -(GCKSessionOptions * _Nullable)defaultSessionOptionsForDeviceCategory:(NSString * _Nonnull)category;
		[return: NullAllowed]
		[Export ("defaultSessionOptionsForDeviceCategory:")]
		SessionOptions GetDefaultSessionOptions (string category);

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

		// @optional -(void)sessionManager:(GCKSessionManager * _Nonnull)sessionManager didUpdateDefaultSessionOptionsForDeviceCategory:(NSString * _Nonnull)category;
		[Export ("sessionManager:didUpdateDefaultSessionOptionsForDeviceCategory:")]
		void DidUpdateDefaultSessionOptions (SessionManager sessionManager, string category);
	}

	// @interface GCKSessionTraits : NSObject <NSCopying, NSCoding>
	[BaseType (typeof (NSObject), Name = "GCKSessionTraits")]
	interface SessionTraits : INSCopying, INSSecureCoding
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
	[Obsolete ("Use UIMultistateButton class instead.")]
	[BaseType (typeof (UIMultistateButton), Name = "GCKUIButton")]
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

		// - (void)setAccessibilityLabel:(NSString *)label forCastState:(GCKCastState) state;
		[Export ("setAccessibilityLabel:forCastState:")]
		void SetAccessibilityLabel (string label, CastState state);
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

		// extern const NSUInteger GCKUIButtonStateMuteOff __attribute__((visibility("default")));
		[Field ("GCKUIButtonStateMuteOff", "__Internal")]
		nuint MuteOffState { get; }

		// extern const NSUInteger GCKUIButtonStateMuteOn __attribute__((visibility("default")));
		[Field ("GCKUIButtonStateMuteOn", "__Internal")]
		nuint MuteOnState { get; }

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
		UIMultistateButton MuteToggleButton { get; set; }

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

		// @property (assign, readwrite, nonatomic) BOOL hideStreamPositionControlsForLiveContent;
		[Export ("hideStreamPositionControlsForLiveContent")]
		bool HideStreamPositionControlsForLiveContent { get; set; }
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
	interface UIImageHints : INSCopying, INSSecureCoding
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
		INSSecureCoding CustomData { get; }

		// -(instancetype _Nonnull)initWithImageType:(GCKMediaMetadataImageType)imageType imageSize:(CGSize)imageSize;
		[Export ("initWithImageType:imageSize:")]
		IntPtr Constructor (MediaMetadataImageType imageType, CGSize imageSize);

		// -(instancetype _Nonnull)initWithImageType:(GCKMediaMetadataImageType)imageType imageSize:(CGSize)imageSize customData:(NSObject<NSCoding> * _Nullable)customData;
		[Export ("initWithImageType:imageSize:customData:")]
		IntPtr Constructor (MediaMetadataImageType imageType, CGSize imageSize, [NullAllowed] INSSecureCoding customData);
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

		// extern const NSUInteger GCKUIButtonStateRepeatOff __attribute__((visibility("default")));
		[Field ("GCKUIButtonStateRepeatOff", "__Internal")]
		nuint RepeatOffState { get; }

		// extern const NSUInteger GCKUIButtonStateRepeatAll __attribute__((visibility("default")));
		[Field ("GCKUIButtonStateRepeatAll", "__Internal")]
		nuint RepeatAllState { get; }

		// extern const NSUInteger GCKUIButtonStateRepeatSingle __attribute__((visibility("default")));
		[Field ("GCKUIButtonStateRepeatSingle", "__Internal")]
		nuint RepeatSingleState { get; }

		// extern const NSUInteger GCKUIButtonStateShuffle __attribute__((visibility("default")));
		[Field ("GCKUIButtonStateShuffle", "__Internal")]
		nuint ShuffleState { get; }

		// extern const NSUInteger GCKUIButtonStatePlay __attribute__((visibility("default")));
		[Field ("GCKUIButtonStatePlay", "__Internal")]
		nuint PlayState { get; }

		// extern const NSUInteger GCKUIButtonStatePause __attribute__((visibility("default")));
		[Field ("GCKUIButtonStatePause", "__Internal")]
		nuint PauseState { get; }

		// extern const NSUInteger GCKUIButtonStatePlayLive __attribute__((visibility("default")));
		[Field ("GCKUIButtonStatePlayLive", "__Internal")]
		nuint PlayLiveState { get; }

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
		UIMultistateButton PlayPauseToggleButton { get; set; }

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
		UIButton Forward30SecondsButton { get; set; }

		// @property (readwrite, nonatomic, weak) GCKUIButton * _Nullable rewind30SecondsButton;
		[NullAllowed]
		[Export ("rewind30SecondsButton", ArgumentSemantic.Weak)]
		UIButton Rewind30SecondsButton { get; set; }

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
		UIMultistateButton RepeatModeButton { get; set; }

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

		// @property (readwrite, nonatomic, strong) GCKUIPlaybackRateController * _Nullable playbackRateController;
		[NullAllowed]
		[Export ("playbackRateController", ArgumentSemantic.Strong)]
		UIPlaybackRateController PlaybackRateController { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL displayTimeRemainingAsNegativeValue;
		[Export ("displayTimeRemainingAsNegativeValue")]
		bool DisplayTimeRemainingAsNegativeValue { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL hideStreamPositionControlsForLiveContent;
		[Export ("hideStreamPositionControlsForLiveContent")]
		bool HideStreamPositionControlsForLiveContent { get; set; }

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
		void DidBeginPreload (UIMediaController mediaController, nuint itemId);

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
		void DidSelectMediaTracks (NSNumber [] mediaTrackIds);
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

	// @interface GCKUIMultistateButton : UIButton
	[BaseType (typeof (UIButton), Name = "GCKUIMultistateButton")]
	interface UIMultistateButton
	{
		// @property (assign, readwrite, nonatomic) NSUInteger buttonState;
		[Export ("buttonState")]
		nuint ButtonState { get; set; }

		// -(void)setImage:(UIImage * _Nonnull)image forButtonState:(NSUInteger)buttonState;
		[Export ("setImage:forButtonState:")]
		void SetImage (UIImage image, nuint buttonState);
	}

	// @interface GCKUIPlaybackRateController : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKUIPlaybackRateController")]
	interface UIPlaybackRateController
	{
		[DesignatedInitializer]
		[Export ("init")]
		IntPtr Constructor ();

		// @property (assign, readwrite, nonatomic) float playbackRate;
		[Export ("playbackRate")]
		float PlaybackRate { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL inputEnabled;
		[Export ("inputEnabled")]
		bool InputEnabled { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKUIPlayPauseToggleController")]
	interface UIPlayPauseToggleController
	{
		[DesignatedInitializer]
		[Export ("init")]
		IntPtr Constructor ();

		// @property(nonatomic, assign, readwrite) GCKUIPlayPauseState playPauseState;
		[Export ("playPauseState")]
		UIPlayPauseState PlayPauseState { get; set; }

		// @property(nonatomic, assign, readwrite) BOOL inputEnabled;
		[Export ("inputEnabled")]
		bool InputEnabled { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKUIStreamPositionController")]
	interface UIStreamPositionController
	{
		[DesignatedInitializer]
		[Export ("init")]
		IntPtr Constructor ();

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

		// @property (readonly, nonatomic, strong) GCKUIStyleAttributesCastViews * _Nonnull castViews;
		[Export ("castViews", ArgumentSemantic.Strong)]
		UIStyleAttributesCastViews CastViews { get; }
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

		// @property(nonatomic, strong, readwrite) UIFont *buttonTextFont;
		[Export ("buttonTextFont", ArgumentSemantic.Strong)]
		UIFont ButtonTextFont { get; set; }

		// @property(nonatomic, strong, readwrite) UIColor *buttonTextColor;
		[Export ("buttonTextColor", ArgumentSemantic.Strong)]
		UIColor ButtonTextColor { get; set; }

		// @property(nonatomic, strong, readwrite) UIColor *buttonTextShadowColor;
		[Export ("buttonTextShadowColor", ArgumentSemantic.Strong)]
		UIColor ButtonTextShadowColor { get; set; }

		// @property(nonatomic, assign, readwrite) CGSize buttonTextShadowOffset;
		[Export ("buttonTextShadowOffset", ArgumentSemantic.Assign)]
		CGSize ButtonTextShadowOffset { get; set; }

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

	// @interface GCKUIStyleAttributesInstructions : GCKUIStyleAttributes
	[BaseType (typeof (UIStyleAttributes), Name = "GCKUIStyleAttributesInstructions")]
	interface UIStyleAttributesInstructions
	{
	}

	// @interface GCKUIStyleAttributesGuestModePairingDialog : GCKUIStyleAttributes
	[BaseType (typeof (UIStyleAttributes), Name = "GCKUIStyleAttributesGuestModePairingDialog")]
	interface UIStyleAttributesGuestModePairingDialog
	{
	}

	// @interface GCKUIStyleAttributesTrackSelector : GCKUIStyleAttributes
	[BaseType (typeof (UIStyleAttributes), Name = "GCKUIStyleAttributesTrackSelector")]
	interface UIStyleAttributesTrackSelector
	{
	}

	// @interface GCKUIStyleAttributesMiniController : GCKUIStyleAttributes
	[BaseType (typeof (UIStyleAttributes), Name = "GCKUIStyleAttributesMiniController")]
	interface UIStyleAttributesMiniController
	{
	}

	// @interface GCKUIStyleAttributesExpandedController : GCKUIStyleAttributes
	[BaseType (typeof (UIStyleAttributes), Name = "GCKUIStyleAttributesExpandedController")]
	interface UIStyleAttributesExpandedController
	{
	}

	// @interface GCKUIStyleAttributesDeviceChooser : GCKUIStyleAttributes
	[BaseType (typeof (UIStyleAttributes), Name = "GCKUIStyleAttributesDeviceChooser")]
	interface UIStyleAttributesDeviceChooser
	{
	}

	// @interface GCKUIStyleAttributesConnectionController : GCKUIStyleAttributes
	[BaseType (typeof (UIStyleAttributes), Name = "GCKUIStyleAttributesConnectionController")]
	interface UIStyleAttributesConnectionController
	{
	}

	// @interface GCKUIStyleAttributesMediaControl : GCKUIStyleAttributes
	[BaseType (typeof (UIStyleAttributes), Name = "GCKUIStyleAttributesMediaControl")]
	interface UIStyleAttributesMediaControl
	{
		//@property (readonly, nonatomic, strong) GCKUIStyleAttributesExpandedController* expandedController;
		[Export ("expandedController", ArgumentSemantic.Strong)]
		UIStyleAttributesExpandedController ExpandedController { get; }

		//@property (readonly, nonatomic, strong) GCKUIStyleAttributesMiniController* miniController;
		[Export ("miniController", ArgumentSemantic.Strong)]
		UIStyleAttributesMiniController MiniController { get; }

		//@property (readonly, nonatomic, strong) GCKUIStyleAttributesTrackSelector* trackSelector;
		[Export ("trackSelector", ArgumentSemantic.Strong)]
		UIStyleAttributesTrackSelector TrackSelector { get; }
	}

	// @interface GCKUIStyleAttributesDeviceControl : GCKUIStyleAttributes
	[BaseType (typeof (UIStyleAttributes), Name = "GCKUIStyleAttributesDeviceControl")]
	interface UIStyleAttributesDeviceControl
	{
		// @property (readonly, nonatomic, strong) GCKUIStyleAttributesDeviceChooser* deviceChooser;
		[Export ("deviceChooser", ArgumentSemantic.Strong)]
		UIStyleAttributesDeviceChooser DeviceChooser { get; }

		// @property (readonly, nonatomic, strong) GCKUIStyleAttributesConnectionController* connectionController;
		[Export ("connectionController", ArgumentSemantic.Strong)]
		UIStyleAttributesConnectionController ConnectionController { get; }

		// @property (readonly, nonatomic, strong) GCKUIStyleAttributesGuestModePairingDialog* guestModePairingDialog;
		[Export ("guestModePairingDialog", ArgumentSemantic.Strong)]
		UIStyleAttributesGuestModePairingDialog GuestModePairingDialog { get; }
	}

	// @interface GCKUIStyleAttributesCastViews : GCKUIStyleAttributes
	[BaseType (typeof (UIStyleAttributes), Name = "GCKUIStyleAttributesCastViews")]
	interface UIStyleAttributesCastViews
	{
		// @property (readonly, nonatomic, strong) GCKUIStyleAttributesDeviceControl* deviceControl;
		[Export ("deviceControl", ArgumentSemantic.Strong)]
		UIStyleAttributesDeviceControl DeviceControl { get; }

		// @property(readonly, nonatomic, strong) GCKUIStyleAttributesMediaControl *mediaControl;
		[Export ("mediaControl", ArgumentSemantic.Strong)]
		UIStyleAttributesMediaControl MediaControl { get; }

		// @property(readonly, nonatomic, strong) GCKUIStyleAttributesInstructions *instructions;
		[Export ("instructions", ArgumentSemantic.Strong)]
		UIStyleAttributesInstructions Instructions { get; }
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
	interface VideoInfo : INSCopying, INSSecureCoding
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
	[BaseType (typeof (NSDictionary))]
	interface NSDictionary_GCKAdditions
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
	}

	// @interface GCKAdditions (NSMutableDictionary)
	[Category]
	[BaseType (typeof (NSMutableDictionary))]
	interface NSMutableDictionary_GCKAdditions
	{
		// -(void)gck_setStringValue:(NSString * _Nonnull)value forKey:(NSString * _Nonnull)key;
		[Export ("gck_setStringValue:forKey:")]
		void SetString (string value, string key);

		// -(void)gck_setIntegerValue:(NSInteger)value forKey:(NSString * _Nonnull)key;
		[Export ("gck_setIntegerValue:forKey:")]
		void SetNInt (nint value, string key);

		// -(void)gck_setUIntegerValue:(NSUInteger)value forKey:(NSString * _Nonnull)key;
		[Export ("gck_setUIntegerValue:forKey:")]
		void SetNUInt (nuint value, string key);

		// -(void)gck_setDoubleValue:(double)value forKey:(NSString * _Nonnull)key;
		[Export ("gck_setDoubleValue:forKey:")]
		void SetDouble (double value, string key);

		// -(void)gck_setBoolValue:(BOOL)value forKey:(NSString * _Nonnull)key;
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