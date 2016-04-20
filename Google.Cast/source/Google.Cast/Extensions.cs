using System;
using System.Runtime.InteropServices;

using ObjCRuntime;
using Foundation;

namespace Google.Cast
{
	public class MediaCommon
	{
		public static double InvalidTimeInterval {
			get { return double.NaN; }
		}
	}

	public partial class MediaQueueItem
	{
		public nuint[] ActiveTrackIDs {
			get {
				if (_ActiveTrackIDs == null)
					return null;

				var activeTrackIds = _ActiveTrackIDs;
				var items = new nuint[activeTrackIds.Count];

				for (nuint i = 0; i < activeTrackIds.Count; i++)
					items [i] = activeTrackIds.GetItem<NSNumber> (i).NUIntValue;

				return items;
			}
		}

		public MediaQueueItem (MediaInformation mediaInformation, bool autoplay, double startTime, double preloadTime, nuint[] activeTrackIDs, NSObject customData)
		{
			var activeTracksIdsObjC = NSArray.FromObjects (activeTrackIDs);
			Handle = _InitWithMediaInformation (mediaInformation, autoplay, startTime, preloadTime, activeTracksIdsObjC, customData);
		}

		[DesignatedInitializer]
		public MediaQueueItem (MediaInformation mediaInformation, bool autoplay, double startTime, double playbackDuration, double preloadTime, nuint[] activeTrackIDs, NSObject customData)
		{
			var activeTracksIdsObjC = NSArray.FromObjects (activeTrackIDs);
			Handle = _InitWithMediaInformation (mediaInformation, autoplay, startTime, playbackDuration, preloadTime, activeTracksIdsObjC, customData);
		}
	}

	public partial class MediaQueueItemBuilder
	{
		public nuint[] ActiveTrackIDs {
			get {
				if (_ActiveTrackIDs == null)
					return null;

				var activeTrackIds = _ActiveTrackIDs;
				var items = new nuint[activeTrackIds.Count];

				for (nuint i = 0; i < activeTrackIds.Count; i++)
					items [i] = activeTrackIds.GetItem<NSNumber> (i).NUIntValue;               

				return items;               
			}
			set {
				_ActiveTrackIDs = value != null ? NSArray.FromObjects (value) : null;
			}
		}
	}

	public partial class MediaControlChannel
	{

		public nint QueueRemoveItems (nuint[] itemIDs)
		{
			var arr = NSArray.FromObjects (itemIDs);            
			return QueueRemoveItems (arr);
		}

		public nint QueueRemoveItems (nuint[] itemIDs, NSObject customData)
		{
			var arr = NSArray.FromObjects (itemIDs);
			return QueueRemoveItems (arr, customData);
		}

		public nint QueueReorderItems (nuint[] queueItemIDs, nuint beforeItemID)
		{
			//var arr = NSArray.FromObjects (queueItemIDs);
			return QueueReorderItems (queueItemIDs, beforeItemID);
		}

		public nint QueueReorderItems (nuint[] queueItemIDs, nuint beforeItemID, NSObject customData)
		{
			//var arr = NSArray.FromObjects (queueItemIDs);
			return QueueReorderItems (queueItemIDs, beforeItemID, customData);
		}
	}

	public partial class Logger
	{
		private static bool? loggingEnabled = null;

		public static bool LoggingEnabled {
			get {
				if (loggingEnabled != null)
					return loggingEnabled.Value;

				IntPtr mainLibPtr = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (mainLibPtr, "GCKAnalyticsLoggingEnabled");

				loggingEnabled = Convert.ToBoolean (Marshal.ReadByte (ptr));
				Dlfcn.dlclose (mainLibPtr);

				return loggingEnabled.Value;
			}
			set {
				loggingEnabled = value;

				IntPtr mainLibPtr = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (mainLibPtr, "GCKAnalyticsLoggingEnabled");

				Marshal.WriteByte (ptr, Convert.ToByte (loggingEnabled));
				Dlfcn.dlclose (mainLibPtr);
			}
		}


		public void Log (string function, params string[] message)
		{
			if (message == null)
				throw new ArgumentNullException ("Message");

			var pNativeArr = Marshal.AllocHGlobal ((message.Length - 1) * IntPtr.Size);

			for (int i = 1; i < message.Length; i++)
				Marshal.WriteIntPtr (pNativeArr, (i - 1) * IntPtr.Size, ((NSString)message [i]).Handle);

			_Log (message [0], pNativeArr);
			Marshal.FreeHGlobal (pNativeArr);
		}
	}

	public partial class MediaControlChannel
	{

		public nint LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, nint[] activeTrackIDs)
		{
			if (activeTrackIDs == null || activeTrackIDs.Length == 0) {
				NSNumber[] numbers = null;
				return LoadMedia (mediaInfo, autoplay, playPosition, numbers);
			}

			var integers = new NSNumber[activeTrackIDs.Length];

			for (int i = 0; i < activeTrackIDs.Length; i++)
				integers [i] = new NSNumber (activeTrackIDs [i]);

			return LoadMedia (mediaInfo, autoplay, playPosition, integers);
		}

		public nint LoadMedia (MediaInformation mediaInfo, bool autoplay, double playPosition, nint[] activeTrackIDs, NSObject customData)
		{
			if (activeTrackIDs == null) {
				NSNumber[] numbers = null;
				return LoadMedia (mediaInfo, autoplay, playPosition, numbers, customData);
			}

			var integers = new NSNumber[activeTrackIDs.Length];

			for (int i = 0; i < activeTrackIDs.Length; i++)
				integers [i] = new NSNumber (activeTrackIDs [i]);

			return LoadMedia (mediaInfo, autoplay, playPosition, integers, customData);
		}

		public nint SetActiveTrackIDs (nint[] activeTrackIDs)
		{
			var integers = new NSNumber[activeTrackIDs.Length];

			for (int i = 0; i < activeTrackIDs.Length; i++)
				integers [i] = new NSNumber (activeTrackIDs [i]);

			return SetActiveTrackIDs (integers);
		}
	}
}