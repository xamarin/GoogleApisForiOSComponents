using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Foundation;
using UIKit;
using System.Net;

namespace PerformanceMonitoringSample
{
	public class DownloadManager
	{
		#region Fields

		static HttpClient httpClient;
		static NSUrlSessionDataTaskRequest taskRequest;

		#endregion

		#region Constructors

		static DownloadManager ()
		{
			httpClient = new HttpClient ();
		}

		#endregion

		public static async Task<UIImage> DownloadImageUsingHttpClient (string imageUrl, CancellationToken ct)
		{
			ct.ThrowIfCancellationRequested ();

			var bytes = await httpClient.GetByteArrayAsync (imageUrl);
			var image = UIImage.LoadFromData (NSData.FromArray (bytes));

			ct.ThrowIfCancellationRequested ();

			return image;
		}

		public static async Task<UIImage> DownloadImageUsingNSUrlSession (string imageUrl, CancellationToken ct)
		{
			ct.ThrowIfCancellationRequested ();

			var request = new NSMutableUrlRequest (new NSUrl (imageUrl)) { HttpMethod = "GET" };
			taskRequest = await NSUrlSession.SharedSession.CreateDataTaskAsync (request);

			ct.ThrowIfCancellationRequested ();

			var urlResponse = taskRequest.Response as NSHttpUrlResponse;

			if (urlResponse?.StatusCode != 200) {
				ct.ThrowIfCancellationRequested ();
				return null;
			}

			var image = UIImage.LoadFromData (taskRequest.Data);

			ct.ThrowIfCancellationRequested ();

			return image;
		}
	}
}
