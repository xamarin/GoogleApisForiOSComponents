using System;
using Foundation;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CastSample
{
	public class MediaListModel : NSObject
	{
		public event EventHandler<MediaListEventArgs> MediaListFetched;
		public event EventHandler<MediaListEventArgs> FetchMediaListFailed;

		public void FetchMediaList ()
		{
			var e = new MediaListEventArgs ();
			var filename = "Videos.json";

			if (!File.Exists (filename)) {
				var userInfo = NSDictionary.FromObjectAndKey (new NSString ("Videos.json file not found."), NSError.LocalizedDescriptionKey);
				e.Categories = null;
				e.Error = new NSError (new NSString (""), -1, userInfo);
				FetchMediaListFailed?.Invoke (this, e);

				return;
			}

			using (StreamReader reader = File.OpenText (filename)) {
				var jsonString = reader.ReadToEnd ();
				var categories = JsonConvert.DeserializeObject<List<Category>> (jsonString);

				e.Categories = categories;
				MediaListFetched?.Invoke (this, e);
			}
		}

		void ClearDelegatesOnEvent<T> (EventHandler<T> eventToClear) where T : EventArgs
		{
			if (eventToClear == null)
				return;

			var eventList = eventToClear.GetInvocationList ();
			foreach (var anEvent in eventList)
				eventToClear -= (EventHandler<T>)anEvent;
		}

		protected override void Dispose (bool disposing)
		{
			ClearDelegatesOnEvent (MediaListFetched);
			ClearDelegatesOnEvent (FetchMediaListFailed);

			base.Dispose (disposing);
		}
	}

	public class MediaListEventArgs : EventArgs
	{
		public List<Category> Categories { get; set; }
		public NSError Error { get; set; }
	}
}
