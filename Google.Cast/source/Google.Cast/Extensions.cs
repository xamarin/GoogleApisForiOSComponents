using System;
using System.Runtime.InteropServices;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Google.Cast
{
	static class Helper
	{
		public static nuint [] GetNUintArray (NSArray nsArray)
		{
			var items = new nuint [nsArray.Count];

			for (nuint i = 0; (int)i < items.Length; i++)
				items [i] = nsArray.GetItem<NSNumber> (i).NUIntValue;

			return items;
		}
	}

	public partial class DiscoveryCriteria : NSObject
	{
		public DiscoveryCriteria (string [] namespaces) : base (NSObjectFlag.Empty)
		{
			NSString [] nsNamespaces = new NSString [namespaces.Length];

			for (int i = 0; i < namespaces.Length; i++)
				nsNamespaces [i] = new NSString (namespaces [i]);

			var nsSet = new NSSet<NSString> (nsNamespaces);
			Handle = _InitWithNamespaces (nsSet);
		}

		public DiscoveryCriteria (NSSet<NSString> namespaces) : base (NSObjectFlag.Empty) => Handle = _InitWithNamespaces (namespaces);
	}

	[Obsolete ("Implement ILoggerDelegate interface and override LogMessage method instead.")]
	public class LoggerHandler : NSObject, ILoggerDelegate
	{
		public delegate void UserLogImplementation (string function, string message);
		UserLogImplementation implementation;

		public LoggerHandler (UserLogImplementation implementation)
		{
			this.implementation = implementation;
		}

		public void _Log (IntPtr function, string message)
		{
			var func = Marshal.PtrToStringAnsi (function);

			if (implementation != null)
				implementation (func, message);
		}

		public void SetLogImplementation (UserLogImplementation implementation)
		{
			this.implementation = implementation;
		}
	}

	public partial class MediaCommon
	{
		// GCK_EXTERN BOOL GCKIsValidTimeInterval(NSTimeInterval timeInterval);
		[DllImport ("__Internal", EntryPoint = "GCKIsValidTimeInterval")]
		extern internal static bool _IsValidTimeInterval (double timeInterval);
		public static bool IsValidTimeInterval (double timeInterval) => _IsValidTimeInterval (timeInterval);
	}

	public enum MediaInformationBuilderParameterType
	{
		IsContentId,
		IsEntity
	}

	public partial class MediaInformationBuilder : NSObject
	{
		[Advice ("Pass a contenId or entity value as the first param and specify the information kind with the second param.")]
		public MediaInformationBuilder (string contentIdOrEntity, MediaInformationBuilderParameterType parameterType) : base (NSObjectFlag.Empty)
		{
			if (contentIdOrEntity == null)
				throw new ArgumentNullException (nameof (contentIdOrEntity));

			if (parameterType == MediaInformationBuilderParameterType.IsContentId) {
				Handle = _InitWithContentId (contentIdOrEntity);
			} else {
				Handle = _InitWithEntity (contentIdOrEntity);
			}
		}
	}

	public partial class MediaLoadOptions
	{
		public nuint [] ActiveTrackIds {
			get {
				NSArray activeTracksIdsArray = _ActiveTrackIds;

				nuint [] activeTracksIds = null;

				if (activeTracksIdsArray != null)
					activeTracksIds = Helper.GetNUintArray (activeTracksIdsArray);

				return activeTracksIds;
			}
			set {
				_ActiveTrackIds = value != null ? NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), value) : null;
			}
		}
	}

	public partial class MediaQueueItem : NSObject
	{
		public nuint [] ActiveTrackIds {
			get {
				NSArray activeTracksIdsArray = _ActiveTrackIds;

				nuint [] activeTracksIds = null;

				if (activeTracksIdsArray != null)
					activeTracksIds = Helper.GetNUintArray (activeTracksIdsArray);

				return activeTracksIds;
			}
		}

		public MediaQueueItem (MediaInformation mediaInformation, bool autoplay, double startTime, double preloadTime, nuint [] activeTrackIds, NSObject customData) : base (NSObjectFlag.Empty)
		{
			if (mediaInformation == null)
				throw new ArgumentNullException (nameof (mediaInformation));

			var activeTracksIdsObjC = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIds);
			Handle = _InitWithMediaInformation (mediaInformation, autoplay, startTime, preloadTime, activeTracksIdsObjC, customData);
		}

		[DesignatedInitializer]
		public MediaQueueItem (MediaInformation mediaInformation, bool autoplay, double startTime, double playbackDuration, double preloadTime, nuint [] activeTrackIds, NSObject customData) : base (NSObjectFlag.Empty)
		{
			if (mediaInformation == null)
				throw new ArgumentNullException (nameof (mediaInformation));

			var activeTracksIdsObjC = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIds);
			Handle = _InitWithMediaInformation (mediaInformation, autoplay, startTime, playbackDuration, preloadTime, activeTracksIdsObjC, customData);
		}
	}

	public partial class MediaQueueItemBuilder
	{
		public nuint [] ActiveTrackIds {
			get {
				NSArray activeTracksIdsArray = _ActiveTrackIds;

				nuint [] activeTracksIds = null;

				if (activeTracksIdsArray != null)
					activeTracksIds = Helper.GetNUintArray (activeTracksIdsArray);

				return activeTracksIds;
			}
			set {
				_ActiveTrackIds = value != null ? NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), value) : null;
			}
		}
	}

	public partial class MediaStatus
	{
		nuint [] ActiveTrackIds {
			get {
				NSArray activeTracksIdsArray = _ActiveTrackIds;

				nuint [] activeTracksIds = null;

				if (activeTracksIdsArray != null)
					activeTracksIds = Helper.GetNUintArray (activeTracksIdsArray);

				return activeTracksIds;
			}
		}
	}

	public partial class RemoteMediaClient
	{
		[Obsolete ("Use LoadMedia (MediaInformation, MediaLoadOptions) overloaded method instead.")]
		public Request LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, nuint [] activeTrackIds)
		{
			if (mediaInfo == null)
				throw new ArgumentNullException (nameof (mediaInfo));

			NSArray activeTrackIdsArray = null;

			if (activeTrackIds != null)
				activeTrackIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIds);

			return _LoadMedia (mediaInfo, autoplay, playPosition, activeTrackIdsArray);
		}

		[Obsolete ("Use LoadMedia (MediaInformation, MediaLoadOptions) overloaded method instead.")]
		public Request LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, nuint [] activeTrackIds, NSObject customData)
		{
			if (mediaInfo == null)
				throw new ArgumentNullException (nameof (mediaInfo));

			NSArray activeTrackIdsArray = null;

			if (activeTrackIds != null)
				activeTrackIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIds);

			return _LoadMedia (mediaInfo, autoplay, playPosition, activeTrackIdsArray, customData);
		}

		public Request SetActiveTrackIds (nuint [] activeTrackIds)
		{
			NSArray activeTrackIdsArray = null;

			if (activeTrackIds != null)
				activeTrackIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIds);

			return _SetActiveTrackIds (activeTrackIdsArray);
		}

		public Request QueueFetchItems (nuint [] queueItemIds)
		{
			if (queueItemIds == null)
				throw new ArgumentNullException (nameof (queueItemIds));

			NSArray queueItemIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), queueItemIds);

			return _QueueFetchItems (queueItemIdsArray);
		}

		public Request QueueRemoveItems (nuint [] itemIds)
		{
			if (itemIds == null)
				throw new ArgumentNullException (nameof (itemIds));

			NSArray itemIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), itemIds);

			return _QueueRemoveItems (itemIdsArray);
		}

		public Request QueueRemoveItems (nuint [] itemIds, NSObject customData)
		{
			if (itemIds == null)
				throw new ArgumentNullException (nameof (itemIds));

			NSArray itemIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), itemIds);

			return _QueueRemoveItems (itemIdsArray, customData);
		}

		public Request QueueReorderItems (nuint [] queueItemIds, nuint beforeItemId)
		{
			if (queueItemIds == null)
				throw new ArgumentNullException (nameof (queueItemIds));

			NSArray queueItemIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), queueItemIds);

			return _QueueReorderItems (queueItemIdsArray, beforeItemId);
		}

		public Request QueueReorderItems (nuint [] queueItemIds, nuint beforeItemId, NSObject customData)
		{
			if (queueItemIds == null)
				throw new ArgumentNullException (nameof (queueItemIds));

			NSArray queueItemIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), queueItemIds);

			return _QueueReorderItems (queueItemIdsArray, beforeItemId, customData);
		}
	}

	public static partial class RemoteMediaClient_Protected
	{
		public static void NotifyDidReceiveQueueItemIds (this RemoteMediaClient instance, nuint [] itemIds)
		{
			if (itemIds == null)
				throw new ArgumentNullException (nameof (itemIds));

			NSArray itemIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), itemIds);

			_NotifyDidReceiveQueueItemIds (instance, itemIdsArray);
		}

		public static void NotifyDidInsertQueueItems (this RemoteMediaClient instance, nuint [] itemIds, nuint beforeItemId)
		{
			if (itemIds == null)
				throw new ArgumentNullException (nameof (itemIds));

			NSArray itemIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), itemIds);

			_NotifyDidInsertQueueItems (instance, itemIdsArray, beforeItemId);
		}

		public static void NotifyDidUpdateQueueItems (this RemoteMediaClient instance, nuint [] itemIds)
		{
			if (itemIds == null)
				throw new ArgumentNullException (nameof (itemIds));

			NSArray itemIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), itemIds);

			_NotifyDidUpdateQueueItems (instance, itemIdsArray);
		}

		public static void NotifyDidRemoveQueueItems (this RemoteMediaClient instance, nuint [] itemIds)
		{
			if (itemIds == null)
				throw new ArgumentNullException (nameof (itemIds));

			NSArray itemIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), itemIds);

			_NotifyDidRemoveQueueItems (instance, itemIdsArray);
		}
	}

	public partial class UIDeviceVolumeController
	{
		static UIControlState? muteOff;

		[Obsolete ("Use MuteOffState property with UIMultistateButton class.")]
		public static UIControlState MuteOff {
			get {
				if (muteOff == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "GCKUIControlStateMuteOff");
					muteOff = (UIControlState)Marshal.PtrToStructure (ptr, typeof (UIControlState));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return muteOff.Value;
			}
		}

		static UIControlState? muteOn;

		[Obsolete ("Use MuteOnState property with UIMultistateButton class.")]
		public static UIControlState MuteOn {
			get {
				if (muteOn == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "GCKUIControlStateMuteOn");
					muteOn = (UIControlState)Marshal.PtrToStructure (ptr, typeof (UIControlState));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return muteOn.Value;
			}
		}
	}

	public partial class UIMediaController
	{
		static UIControlState? repeatOff;

		[Obsolete ("Use RepeatOffState property with UIMultistateButton class.")]
		public static UIControlState RepeatOff {
			get {
				if (repeatOff == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "GCKUIControlStateRepeatOff");
					repeatOff = (UIControlState)Marshal.PtrToStructure (ptr, typeof (UIControlState));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return repeatOff.Value;
			}
		}

		static UIControlState? repeatAll;

		[Obsolete ("Use RepeatAllState property with UIMultistateButton class.")]
		public static UIControlState RepeatAll {
			get {
				if (repeatAll == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "GCKUIControlStateRepeatAll");
					repeatAll = (UIControlState)Marshal.PtrToStructure (ptr, typeof (UIControlState));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return repeatAll.Value;
			}
		}

		static UIControlState? repeatSingle;

		[Obsolete ("Use RepeatSingleState property with UIMultistateButton class.")]
		public static UIControlState RepeatSingle {
			get {
				if (repeatSingle == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "GCKUIControlStateRepeatSingle");
					repeatSingle = (UIControlState)Marshal.PtrToStructure (ptr, typeof (UIControlState));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return repeatSingle.Value;
			}
		}

		static UIControlState? play;

		[Obsolete ("Use PlayState property with UIMultistateButton class.")]
		public static UIControlState Play {
			get {
				if (play == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "GCKUIControlStatePlay");
					play = (UIControlState)Marshal.PtrToStructure (ptr, typeof (UIControlState));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return play.Value;
			}
		}

		static UIControlState? pause;

		[Obsolete ("Use PauseState property with UIMultistateButton class.")]
		public static UIControlState Pause {
			get {
				if (pause == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "GCKUIControlStatePause");
					pause = (UIControlState)Marshal.PtrToStructure (ptr, typeof (UIControlState));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return pause.Value;
			}
		}

		static UIControlState? shuffle;

		[Obsolete ("Use ShuffleState property with UIMultistateButton class.")]
		public static UIControlState Shuffle {
			get {
				if (shuffle == null) {
					IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
					IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "GCKUIControlStateShuffle");
					shuffle = (UIControlState)Marshal.PtrToStructure (ptr, typeof (UIControlState));
					Dlfcn.dlclose (RTLD_MAIN_ONLY);
				}

				return shuffle.Value;
			}
		}
	}

	public partial class UIMediaTrackSelectionViewController
	{
		nuint [] SelectedTrackIds {
			get {
				NSArray selectedTrackIdsArray = _SelectedTrackIds;

				nuint [] selectedTrackIds = null;

				if (selectedTrackIdsArray != null)
					selectedTrackIds = Helper.GetNUintArray (selectedTrackIdsArray);

				return selectedTrackIds;
			}
			set {
				_SelectedTrackIds = value != null ? NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), value) : null;
			}
		}
	}
}