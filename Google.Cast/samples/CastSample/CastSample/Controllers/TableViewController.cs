using System;

using UIKit;
using Google.Cast;
using CoreGraphics;
using Foundation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace CastSample
{
	public partial class TableViewController : UITableViewController, ISessionManagerListener
	{
		#region Fields

		SessionManager sessionManager;
		List<Category> categories;
		MediaListModel mediaListModel;
		ImageFetcher imageFetcher;

		#endregion

		#region Constructors

		protected TableViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			InitializeComponents ();

			categories = new List<Category> ();

			// Model that download the information used to build
			// Cast Media Information to be sent to Cast Device.
			mediaListModel = new MediaListModel ();
			mediaListModel.MediaListFetched += MediaListModel_MediaListFetched;
			mediaListModel.FetchMediaListFailed += MediaListModel_FetchMediaListFailed;

			// Combines the steps of connecting to a device, 
			// launching (or joining), connecting to a receiver 
			// application, and initializing a media control channel
			// if appropriate.
			sessionManager = CastContext.SharedInstance.SessionManager;
			sessionManager.AddListener (this);

			imageFetcher = new ImageFetcher ();
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			mediaListModel.FetchMediaList ();
		}

		#endregion

		#region Media List Events

		void MediaListModel_MediaListFetched (object sender, MediaListEventArgs e)
		{
			categories = e.Categories;
			TableView.ReloadData ();
		}

		void MediaListModel_FetchMediaListFailed (object sender, MediaListEventArgs e)
		{
			ShowMessage ("Could not download videos", e.Error.LocalizedDescription);
		}

		#endregion

		#region Session Manager Delegate

		[Export ("sessionManager:didStartSession:")]
		public void DidStartSession (SessionManager sessionManager, Session session)
		{
			Console.WriteLine ("Session Started.");
		}

		[Export ("sessionManager:didResumeSession:")]
		public void DidResumeSession (SessionManager sessionManager, Session session)
		{
			Console.WriteLine ("Session Resumed.");
		}

		[Export ("sessionManager:didEndSession:withError:")]
		public void DidEndSession (SessionManager sessionManager, Session session, NSError error)
		{
			Console.WriteLine ("Session Ended.");
		}

		[Export ("sessionManager:didFailToStartSession:withError:")]
		public void DidFailToStartSession (SessionManager sessionManager, Session session, NSError error)
		{
			Console.WriteLine ("Session Failed");
		}

		#endregion

		#region TableView Data Source

		public override nint NumberOfSections (UITableView tableView)
		{
			return categories.Count;
		}

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return categories [(int)section].Name;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return categories [(int)section].Videos.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (MediaCell.Key, indexPath) as MediaCell;

			var category = categories [indexPath.Section];
			var video = category.Videos [indexPath.Row];
			var imagePaths = video.ImageUrl.Split ('/', '\\');
			var imageName = imagePaths [imagePaths.Length - 1];

			var imagePath = Path.Combine (Path.GetTempPath (), imageName);

			if (File.Exists (imagePath)) {
				cell.Thumbnail = UIImage.FromFile (imagePath);
			} else {
				var url = new Uri ($"{category.ImagesBaseUrl}{video.ImageUrl}");
				imageFetcher.DownloadImage (imagePath, url, tableView, indexPath);
			}

			cell.Title = video.Title;
			cell.Studio = video.Studio;

			return cell;
		}

		#endregion

		#region TableView Delegate

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var mediaInformation = BuildMediaInformation (indexPath.Section, indexPath.Row);
			PlayVideoRemotely (mediaInformation);
		}

		#endregion

		#region Internal Functionality

		// Reproduces the video on Cast device.
		void PlayVideoRemotely (MediaInformation mediaInformation)
		{
			var castSession = CastContext.SharedInstance.SessionManager.CurrentCastSession;

			// Make sure that we are connected to a Cast device.
			if (castSession == null) {
				ShowMessage ("Connect to a device", "Tap the upper-right button to cast your media to your TV and Speakers.\n" +
				             "If the button doesn't appear, it means that there is no Cast device to connect.");
				return;
			}

			// Play video on Cast device.
			castSession.RemoteMediaClient.LoadMedia (mediaInformation, true);

			NavigationItem.BackBarButtonItem = new UIBarButtonItem ("", UIBarButtonItemStyle.Plain, null, null);
			(UIApplication.SharedApplication.Delegate as AppDelegate).CastControlBarsEnabled = false;

			// Allow the app to manage every manageable aspect of a
			// cast session, with the exception of receiver volume control
			// and session lifecycle (connect/stop casting). 
			// It also provides all the status information about the
			// media session (artwork, title, subtitle, and so forth).
			CastContext.SharedInstance.PresentDefaultExpandedMediaControls ();
		}

		// Builds all the information to be sent to Cast device.
		MediaInformation BuildMediaInformation (int categoryIndexSelected, int videoIndexSelected)
		{
			var category = categories [categoryIndexSelected];
			var video = category.Videos [videoIndexSelected];

			var metadata = new MediaMetadata (MediaMetadataType.Movie);
			metadata.SetString (video.Title, MetadataKey.Title);
			metadata.SetString (video.Subtitle, MetadataKey.Subtitle);
			metadata.SetString (video.Studio, MetadataKey.Studio);

			var imageUrl = new NSUrl ($"{category.ImagesBaseUrl}{video.ImageUrl}");
			metadata.AddImage (new Image (imageUrl, 480, 720));

			var posterUrl = new NSUrl ($"{category.ImagesBaseUrl}{video.PosterUrl}");
			metadata.AddImage (new Image (posterUrl, 780, 1200));

			string videoUrl = string.Empty;

			var tracks = new List<MediaTrack> ();
			video.Tracks = video.Tracks ?? new List<Track> ();

			foreach (var track in video.Tracks)
				tracks.Add (new MediaTrack (
					int.Parse (track.Id),
					$"{category.TracksBaseUrl}{track.ContentId}",
					track.Type,
					MediaTrackType.Text,
					MediaTextTrackSubtype.Captions,
					track.Name,
					track.Language,
					null));

			foreach (var source in video.Sources) {
				if (!source.Type.Equals ("mp4"))
					continue;

				videoUrl = $"{category.Mp4BaseUrl}{source.Url}";
			}

			var mediaInformation = new MediaInformation (videoUrl, 
			                                             MediaStreamType.Buffered, 
			                                             "video/mp4", metadata, 
			                                             video.Duration, 
			                                             tracks.ToArray (), 
			                                             null, 
			                                             null);

			return mediaInformation;
		}

		void InitializeComponents ()
		{
			// Note: Remember that you need to repeat these steps to 
			// add the Cast button in ALL view controllers of your project.

			// Cast button to allow the user to select a Cast device.
			var btnCast = new UICastButton (new CGRect (0, 0, 24, 24)) { TintColor = UIColor.White };
			NavigationItem.RightBarButtonItem = new UIBarButtonItem (btnCast);
		}

		void ShowMessage (string title, string message)
		{
			var alertView = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
			var btnOk = UIAlertAction.Create ("Got it!", UIAlertActionStyle.Cancel, null);

			alertView.AddAction (btnOk);

			PresentViewController (alertView, true, null);
		}

		#endregion
	}
}
