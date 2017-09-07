using System;
using System.Runtime.InteropServices;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Google.Cast
{
	static class Helper
	{
		public static nuint [] GetNUint (NSArray nsArray)
		{
			var items = new nuint [nsArray.Count];

			for (nuint i = 0; (int)i < items.Length; i++)
				items [i] = nsArray.GetItem<NSNumber> (i).NUIntValue;

			return items;
		}
	}

	public partial class Common
	{
		[DllImport ("__Internal", EntryPoint = "GCKAssertMainThread")]
		static extern void _AssertMainThread (IntPtr function);

		public static void AssertMainThread (string function)
		{
			IntPtr pFunction;
			pFunction = Marshal.StringToHGlobalAnsi (function);
			_AssertMainThread (pFunction);

			Marshal.FreeHGlobal (pFunction);
		}
	}

	public partial class LaunchOptions
	{
		[Obsolete ("This property will be removed in next versions. Use RelaunchIfRunning property instead.")]
		public bool relaunchIfRunning {
			get { return RelaunchIfRunning; }
			set { RelaunchIfRunning = value; }
		}
	}

	public partial class Logger
	{
		private static bool? analyticsLoggingEnabled = null;

		public static bool AnalyticsLoggingEnabled {
			get {
				if (analyticsLoggingEnabled != null)
					return analyticsLoggingEnabled.Value;

				IntPtr mainLibPtr = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (mainLibPtr, "GCKAnalyticsLoggingEnabled");

				analyticsLoggingEnabled = Convert.ToBoolean (Marshal.ReadByte (ptr));
				Dlfcn.dlclose (mainLibPtr);

				return analyticsLoggingEnabled.Value;
			}
			set {
				analyticsLoggingEnabled = value;

				IntPtr mainLibPtr = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (mainLibPtr, "GCKAnalyticsLoggingEnabled");

				Marshal.WriteByte (ptr, Convert.ToByte (analyticsLoggingEnabled));
				Dlfcn.dlclose (mainLibPtr);
			}
		}

		public void Log (string function, string message)
		{
			_Log (function, message);
		}

		public void Log (string function, string format, params object [] args)
		{
			var message = string.Format (format, args);
			_Log (function, message);
		}
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

	public class MediaCommon
	{
		public static double InvalidTimeInterval {
			get { return double.NaN; }
		}
	}

	public partial class MediaControlChannel
	{
		// C# 7 YOLO, I <3 One liners
		//public nint LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, nuint [] activeTrackIDs)
		//=> _LoadMedia (mediaInfo, autoplay, playPosition, activeTrackIDs is null ? null : NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIDs);

		public nint LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, nuint [] activeTrackIDs)
		{
			NSArray activeTrackIDsArray = null;

			if (activeTrackIDs != null)
				activeTrackIDsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIDs);

			return _LoadMedia (mediaInfo, autoplay, playPosition, activeTrackIDsArray);
		}

		public nint LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, nuint [] activeTrackIDs, NSObject customData)
		{
			NSArray activeTrackIDsArray = null;

			if (activeTrackIDs != null)
				activeTrackIDsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIDs);

			return _LoadMedia (mediaInfo, autoplay, playPosition, activeTrackIDsArray, customData);
		}

		public nint SetActiveTrackIDs (nuint [] activeTrackIDs)
		{
			NSArray activeTrackIDsArray = null;

			for (int i = 0; i < activeTrackIDs.Length; i++)
				activeTrackIDsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIDs);

			return _SetActiveTrackIDs (activeTrackIDsArray);
		}

		public nint QueueRemoveItems (nuint [] itemIDs)
		{
			if (itemIDs == null)
				throw new ArgumentNullException (nameof (itemIDs));

			var arr = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), itemIDs);
			return _QueueRemoveItems (arr);
		}

		public nint QueueRemoveItems (nuint [] itemIDs, NSObject customData)
		{
			if (itemIDs == null)
				throw new ArgumentNullException (nameof (itemIDs));

			var arr = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), itemIDs);
			return _QueueRemoveItems (arr, customData);
		}

		public nint QueueReorderItems (nuint [] queueItemIDs, nuint beforeItemID)
		{
			if (queueItemIDs == null)
				throw new ArgumentNullException (nameof (queueItemIDs));

			var queueItemIDsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), queueItemIDs);
			return _QueueReorderItems (queueItemIDsArray, beforeItemID);
		}

		public nint QueueReorderItems (nuint [] queueItemIDs, nuint beforeItemID, NSObject customData)
		{
			if (queueItemIDs == null)
				throw new ArgumentNullException (nameof (queueItemIDs));

			var queueItemIDsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), queueItemIDs);
			return _QueueReorderItems (queueItemIDsArray, beforeItemID, customData);
		}
	}

	public partial class MediaQueueItem
	{
		public nuint [] ActiveTrackIDs {
			get {
				NSArray activeTracksIDsArray = _ActiveTrackIDs;

				nuint [] activeTracksIDs = null;

				if (activeTracksIDsArray != null)
					activeTracksIDs = Helper.GetNUint (activeTracksIDsArray);

				return activeTracksIDs;
			}
		}

		public MediaQueueItem (MediaInformation mediaInformation, bool autoplay, double startTime, double preloadTime, nuint [] activeTrackIDs, NSObject customData)
		{
			if (mediaInformation == null)
				throw new ArgumentNullException (nameof (mediaInformation));

			var activeTracksIdsObjC = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIDs);
			Handle = _InitWithMediaInformation (mediaInformation, autoplay, startTime, preloadTime, activeTracksIdsObjC, customData);
		}

		[DesignatedInitializer]
		public MediaQueueItem (MediaInformation mediaInformation, bool autoplay, double startTime, double playbackDuration, double preloadTime, nuint [] activeTrackIDs, NSObject customData)
		{
			if (mediaInformation == null)
				throw new ArgumentNullException (nameof (mediaInformation));

			var activeTracksIdsObjC = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIDs);
			Handle = _InitWithMediaInformation (mediaInformation, autoplay, startTime, playbackDuration, preloadTime, activeTracksIdsObjC, customData);
		}
	}

	public partial class MediaQueueItemBuilder
	{
		public nuint [] ActiveTrackIDs {
			get {
				NSArray activeTracksIDsArray = _ActiveTrackIDs;

				nuint [] activeTracksIDs = null;

				if (activeTracksIDsArray != null)
					activeTracksIDs = Helper.GetNUint (activeTracksIDsArray);

				return activeTracksIDs;
			}
			set {
				_ActiveTrackIDs = value != null ? NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), value) : null;
			}
		}
	}

	public partial class MediaStatus
	{
		nuint [] ActiveTrackIDs {
			get {
				NSArray activeTracksIDsArray = _ActiveTrackIDs;

				nuint [] activeTracksIDs = null;

				if (activeTracksIDsArray != null)
					activeTracksIDs = Helper.GetNUint (activeTracksIDsArray);

				return activeTracksIDs;
			}
		}
	}

	public partial class RemoteMediaClient
	{
		public Request LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, nuint [] activeTrackIDs)
		{
			if (mediaInfo == null)
				throw new ArgumentNullException (nameof (mediaInfo));

			NSArray activeTrackIDsArray = null;

			if (activeTrackIDs != null)
				activeTrackIDsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIDs);

			return _LoadMedia (mediaInfo, autoplay, playPosition, activeTrackIDsArray);
		}

		public Request LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, nuint [] activeTrackIDs, NSObject customData)
		{
			if (mediaInfo == null)
				throw new ArgumentNullException (nameof (mediaInfo));

			NSArray activeTrackIdsArray = null;

			if (activeTrackIDs != null)
				activeTrackIdsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIDs);

			return _LoadMedia (mediaInfo, autoplay, playPosition, activeTrackIdsArray, customData);
		}

		public Request SetActiveTrackIDs (nuint [] activeTrackIDs)
		{
			NSArray activeTrackIDsArray = null;

			if (activeTrackIDs != null)
				activeTrackIDsArray = NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), activeTrackIDs);

			return _SetActiveTrackIDs (activeTrackIDsArray);
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

		public Request QueueReorderItems (nuint [] 	queueItemIds, nuint beforeItemId)
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

	public partial class UIDeviceVolumeController
	{
		static UIControlState? muteOff;
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
					selectedTrackIds = Helper.GetNUint (selectedTrackIdsArray);

				return selectedTrackIds;
			}
			set {
				_SelectedTrackIds = value != null ? NSArray.FromNSObjects ((arg) => NSNumber.FromNUInt (arg), value) : null;
			}
		}
	}
}