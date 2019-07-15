using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using Foundation;
using UIKit;

namespace CastSample
{
	public class ImageFetcher : NSObject
	{
		public async Task DownloadImage (string imagePath, Uri url, UITableView tableView, NSIndexPath rowToReload)
		{
			var webClient = new WebClient ();
			byte [] bytes = null;

			// Start download data using DownloadDataTaskAsync
			try {
				bytes = await webClient.DownloadDataTaskAsync (url).ConfigureAwait (false);
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
				return;
			}

			// Save the image using writeAsync
			var fileStream = new FileStream (imagePath, FileMode.OpenOrCreate);
			await fileStream.WriteAsync (bytes, 0, bytes.Length).ConfigureAwait (false);

			// Reload Row
			InvokeOnMainThread (() => {
				tableView.ReloadRows (new [] { rowToReload }, UITableViewRowAnimation.Automatic);
			});

		}
	}
}
