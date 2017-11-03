using System;

using UIKit;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firebase.PerformanceMonitoring;

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
			BtnRetry.Clicked += BtnRetry_Clicked;

			trace = Performance.StartTrace ("image_download");
			cancellationTokenSource = new CancellationTokenSource ();
			cancellationToken = cancellationTokenSource.Token;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			DownloadImage ();
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

		void BtnRetry_Clicked (object sender, EventArgs e)
		{
			trace.IncrementCounter ("retry");
			DownloadImage ();
		}

		#endregion

		#region Internal Functionality

		void DownloadImage ()
		{
			BtnRetry.Enabled = false;
			ActIndicator.StartAnimating ();

			Task.Factory.StartNew (async () => {
				UIImage image = null;
				try {
					image = await DownloadManager.DownloadImage (ImageUrl, cancellationToken);
				} catch (Exception ex) when (ex is TaskCanceledException || ex is HttpRequestException) {
					InvokeOnMainThread (() => AppDelegate.ShowMessage ("Image couldn't be downloaded...", ex.Message, NavigationController));
				}

				if (cancellationTokenSource.IsCancellationRequested)
					return;

				lock (padlock)
					isDownloadFinished = true;

				if (image == null) {
					image = UIImage.FromFile ("error.png");
					trace.IncrementCounter ("failed");
				} else {
					trace.IncrementCounter ("completed");
				}

				InvokeOnMainThread (() => {
					ImgPicture.Image = image;
					ActIndicator.StopAnimating ();
					BtnRetry.Enabled = true;
				});
			});
		}

		#endregion
	}
}

