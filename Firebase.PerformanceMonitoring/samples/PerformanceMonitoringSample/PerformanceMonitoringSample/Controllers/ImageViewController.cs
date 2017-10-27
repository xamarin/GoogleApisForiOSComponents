using System;

using UIKit;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PerformanceMonitoringSample
{
	public partial class ImageViewController : UIViewController
	{
		#region Fields

		CancellationTokenSource cancellationTokenSource;
		CancellationToken cancellationToken;

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

			cancellationTokenSource = new CancellationTokenSource ();
			cancellationToken = cancellationTokenSource.Token;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			ActIndicator.StartAnimating ();

			Task.Factory.StartNew (async () => {
				var image = await DownloadManager.DownloadImage (ImageUrl, cancellationToken);
				InvokeOnMainThread (() => {
					ImgPicture.Image = image;
					ActIndicator.StopAnimating ();
				});
			});
		}

		public override void ViewWillDisappear (bool animated)
		{
			cancellationTokenSource.Cancel ();
			base.ViewWillDisappear (animated);
		}

		#endregion
	}
}

