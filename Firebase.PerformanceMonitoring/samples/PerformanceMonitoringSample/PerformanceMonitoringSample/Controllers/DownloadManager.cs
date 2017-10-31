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

		#endregion

		#region Constructors

		static DownloadManager ()
		{
			httpClient = new HttpClient ();
		}

		#endregion

		public static async Task<UIImage> DownloadImage (string imageUrl, CancellationToken ct)
		{
			ct.ThrowIfCancellationRequested ();

			var bytes = await httpClient.GetByteArrayAsync (imageUrl);
			var image = UIImage.LoadFromData (NSData.FromArray (bytes));

			ct.ThrowIfCancellationRequested ();

			return image;
		}
	}
}
