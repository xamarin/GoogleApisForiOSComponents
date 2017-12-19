using System;

using UIKit;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firebase.PerformanceMonitoring;
using Foundation;

namespace PerformanceMonitoringSample
{
	public partial class ImageViewController : UIViewController
	{
		#region Fields

		static object padlock = new object ();
		CancellationTokenSource cancellationTokenSource;
		CancellationToken cancellationToken;
		Trace trace;
		bool isDownloadFinished;
		bool downloadFailed;

		#endregion

		#region Properties

		public static string SegueId { get; } = nameof (ImageViewController);
		public string ImageUrl { get; set; }

		#endregion

		#region Constructors

		public ImageViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Controller Life Cycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			ActIndicator.BackgroundColor = UIColor.FromWhiteAlpha (0.5f, 0.3f);
			BtnDownloadRetry.Clicked += BtnDownloadRetry_Clicked;
			SgmDownloadTool.ValueChanged += SgmDownloadTool_ValueChanged;

			trace = Performance.StartTrace ("image_download");
			cancellationTokenSource = new CancellationTokenSource ();
			cancellationToken = cancellationTokenSource.Token;
		}

		public override void ViewWillDisappear (bool animated)
		{
			if (!isDownloadFinished) {
				cancellationTokenSource.Cancel ();
				trace.IncrementCounter ("cancelled");
			}

			trace.Stop ();
			base.ViewWillDisappear (animated);
		}

		#endregion

		#region User Interaction

		void BtnDownloadRetry_Clicked (object sender, EventArgs e)
		{
			BtnDownloadRetry.Enabled = false;
			ActIndicator.StartAnimating ();

			isDownloadFinished = false;
			cancellationTokenSource = new CancellationTokenSource ();
			cancellationToken = cancellationTokenSource.Token;

			if (downloadFailed) {
				downloadFailed = false;
				trace.IncrementCounter ("retry");
			}

			if (SgmDownloadTool.SelectedSegment == 0)
				DownloadImageUsingNSUrlSession ();
			else
				DownloadImageUsingHttpClient ();
		}

		void SgmDownloadTool_ValueChanged (object sender, EventArgs e)
		{
			if (SgmDownloadTool.SelectedSegment == 1) {
				var title = "Using HttpClient with Performance Monitoring";
				var message = "Performance Monitoring cannot collect network requests using HttpClient.\n" +
					"If you want to see network requests in your Firebase dashboard, please, download the image using NSUrlSession.";
				AppDelegate.ShowMessage (title, message, NavigationController);
			}
		}

		#endregion

		#region Internal Functionality

		void DownloadImageUsingHttpClient () => Task.Factory.StartNew (async () => {
			UIImage image = null;
			try {
				image = await DownloadManager.DownloadImageUsingHttpClient (ImageUrl, cancellationToken);
			} catch (Exception ex) when (ex is TaskCanceledException || ex is HttpRequestException) {
				downloadFailed = true;
				InvokeOnMainThread (() => AppDelegate.ShowMessage ("Image couldn't be downloaded...", ex.Message, NavigationController));
			}

			TryImageAssignment (image);
		}, cancellationToken);

		void DownloadImageUsingNSUrlSession () => Task.Factory.StartNew (async () => {
			UIImage image = null;
			try {
				image = await DownloadManager.DownloadImageUsingNSUrlSession (ImageUrl, cancellationToken);
			} catch (Exception ex) when (ex is TaskCanceledException || ex is NSErrorException) {
				downloadFailed = true;
				InvokeOnMainThread (() => AppDelegate.ShowMessage ("Image couldn't be downloaded...", ex.Message, NavigationController));
			}

			TryImageAssignment (image);
		}, cancellationToken);

		void TryImageAssignment (UIImage image)
		{
			if (cancellationTokenSource.IsCancellationRequested)
				return;

			lock (padlock)
				isDownloadFinished = true;

			if (downloadFailed) {
				image = UIImage.FromFile ("error.png");
				trace.IncrementCounter ("failed");
			} else {
				trace.IncrementCounter ("completed");
			}

			InvokeOnMainThread (() => {
				ImgPicture.Image = image;
				ActIndicator.StopAnimating ();
				BtnDownloadRetry.Title = downloadFailed ? "Retry" : "Download";
				BtnDownloadRetry.Enabled = true;
			});
		}

		#endregion
	}
}

