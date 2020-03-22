using System;

using AVFoundation;
using UIKit;
using Foundation;
using Firebase.MLKit;
using Firebase.MLKit.Vision;
using System.Threading.Tasks;
using Firebase.Core;
using CoreGraphics;
using System.Text;

namespace MLKitSample {
	public partial class ViewController : UIViewController, IUIImagePickerControllerDelegate {

		#region Class Variables

		ApiResource currentApiResource;
		nint currentModelIndex;
		Model currentModelName;
		VisionApi vision;

		#endregion

		#region Constructors

		protected ViewController (IntPtr handle) : base (handle)
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
			AnalizeImage ();
		}

		#endregion

		#region User Interactions

		partial void BtnCamera_Clicked (NSObject sender)
		{
			CheckCameraPermission ();
		}

		#endregion

		#region Segue

		[Action ("prepareForUnwind:")]
		public void PrepareForUnwind (UIStoryboardSegue segue)
		{
			InitializeComponents ();
			AnalizeImage ();
		}

		#endregion

		#region Private Functionality

		void InitializeComponents ()
		{
			GetSelectedUserData ();
			SetModelImage ();
			TxtData.Text = string.Empty;
		}

		void GetSelectedUserData ()
		{
			currentApiResource = (ApiResource)(int)NSUserDefaults.StandardUserDefaults.IntForKey (Constants.SelectedApiResource);
			currentModelIndex = NSUserDefaults.StandardUserDefaults.IntForKey (Constants.SelectedModel);
		}

		void SetModelImage ()
		{
			currentModelName = currentApiResource == ApiResource.OnDevice ? AvailableModels.OnDevice [currentModelIndex] : AvailableModels.OnCloud [currentModelIndex];
			ImgSample.Image = UIImage.FromFile ($"{currentModelName}.png");
		}

		void CheckCameraPermission ()
		{
			string message;
			var status = AVCaptureDevice.GetAuthorizationStatus (AVAuthorizationMediaType.Video);

			switch (status) {
			case AVAuthorizationStatus.NotDetermined:
				message = "Let's take a photo to be tested by the MLKit API!";
				AppDelegate.ShowMessage ("Camera Access", message, NavigationController, "Let's do this!", AskForCameraPermission);
				break;
			case AVAuthorizationStatus.Restricted:
			case AVAuthorizationStatus.Denied:
				message = "Open App Settings and grant for camera access to take a photo and test the MLKit API";
				AppDelegate.ShowMessage ("Camera Access Denied", message, NavigationController, "Open App Settings", OpenAppSettings);
				break;
			case AVAuthorizationStatus.Authorized:
				OpenCamera ();
				break;
			default:
				break;
			}
		}

		void AskForCameraPermission ()
		{
			AVCaptureDevice.RequestAccessForMediaType (AVAuthorizationMediaType.Video, (accessGranted) => InvokeOnMainThread (CheckCameraPermission));
		}

		void OpenCamera ()
		{
			var imagePickerController = new UIImagePickerController {
				Delegate = this,
				AllowsEditing = false,
				SourceType = UIImagePickerControllerSourceType.Camera
			};

			PresentViewController (imagePickerController, true, null);
		}

		void OpenAppSettings ()
		{
			var sharedApplication = UIApplication.SharedApplication;
			var url = new NSUrl (UIApplication.OpenSettingsUrlString);

			if (sharedApplication.CanOpenUrl (url))
				if (UIDevice.CurrentDevice.CheckSystemVersion (10, 0))
					sharedApplication.OpenUrl (url, new NSDictionary (), null);
				else
					sharedApplication.OpenUrl (url);
		}

		void AnalizeImage ()
		{
			vision = VisionApi.Create ();

			switch (currentModelName.ToString ()) {
			case nameof (Model.TextRecognition):
				UseTextRecognitionModel ();
				break;
			case nameof (Model.FaceDetection):
				UseFaceDetectionModel ();
				break;
			case nameof (Model.BarcodeScanning):
				UseBarcodeScanningModel ();
				break;
			case nameof (Model.LandmarkRecognition):
				UseLandmarkRecognitionModel ();
				break;
			default:
				TxtData.Text = "Model not supported";
				break;
			}
		}

		void UseTextRecognitionModel ()
		{
			VisionTextRecognizer textRecognizer;

			if (currentApiResource == ApiResource.OnDevice) {
				textRecognizer = vision.GetOnDeviceTextRecognizer ();
			} else {
				// To provide language hints to assist with language detection:
				// See https://cloud.google.com/vision/docs/languages for supported languages
				var options = new VisionCloudTextRecognizerOptions { LanguageHints = new []{ "es" } }; 
				textRecognizer = vision.GetCloudTextRecognizer (options);
			}

			var image = new VisionImage (ImgSample.Image);
			textRecognizer.ProcessImage (image, HandleVisionTextRecognitionCallback);

			void HandleVisionTextRecognitionCallback (VisionText text, NSError error)
			{
				TxtData.Text = error?.Description ?? text?.Text;
			}
		}

		void UseFaceDetectionModel ()
		{
			var faceDetector = vision.GetFaceDetector ();
			var image = new VisionImage (ImgSample.Image);
			faceDetector.ProcessImage (image, HandleVisionFaceDetectionCallback);

			void HandleVisionFaceDetectionCallback (VisionFace [] faces, NSError error)
			{
				if (error != null) {
					TxtData.Text = error.Description;
					return;
				}

				if (faces == null || faces.Length == 0) {
					TxtData.Text = "No faces were found.";
					return;
				}

				var imageSize = ImgSample.Image.Size;

				UIGraphics.BeginImageContextWithOptions (imageSize, false, 0);
				var context = UIGraphics.GetCurrentContext ();
				context.SetStrokeColor (UIColor.Red.CGColor);
				context.SetLineWidth (10);

				ImgSample.Image.Draw (CGPoint.Empty);

				foreach (var face in faces) {
					context.AddRect (face.Frame);
					context.DrawPath (CGPathDrawingMode.Stroke);
				}

				var newImage = UIGraphics.GetImageFromCurrentImageContext ();
				UIGraphics.EndImageContext ();

				ImgSample.Image = newImage;
			}
		}

		void UseBarcodeScanningModel ()
		{
			var options = new VisionBarcodeDetectorOptions (VisionBarcodeFormat.All);
			var barcodeDetector = vision.GetBarcodeDetector (options);
			var image = new VisionImage (ImgSample.Image);
			barcodeDetector.Detect (image, HandleVisionBarcodeDetectionCallback);

			void HandleVisionBarcodeDetectionCallback (VisionBarcode [] barcodes, NSError error)
			{
				if (error != null) {
					TxtData.Text = error.Description;
					return;
				}

				if (barcodes == null || barcodes.Length == 0) {
					TxtData.Text = "No barcodes were found.";
					return;
				}
				
				var stringBuilder = new StringBuilder ();

				foreach (var barcode in barcodes) {
					stringBuilder.AppendLine ($"Raw Value: {barcode.RawValue}");
					stringBuilder.AppendLine ($"Display Value: {barcode.DisplayValue}");
					stringBuilder.AppendLine ($"Format: {barcode.Format}");
					stringBuilder.AppendLine ($"Value Type: {barcode.ValueType}");
					stringBuilder.AppendLine ();
				}

				TxtData.Text = stringBuilder.ToString ();
			}
		}

		void UseLandmarkRecognitionModel ()
		{
			var options = new VisionCloudDetectorOptions {
				ModelType = VisionCloudModelType.Stable,
				MaxResults = 5
			};
			var landmarkDetector = vision.GetCloudLandmarkDetector (options);
			var image = new VisionImage (ImgSample.Image);
			landmarkDetector.Detect (image, HandleVisionCloudLandmarkDetectionCallback);

			void HandleVisionCloudLandmarkDetectionCallback (VisionCloudLandmark [] landmarks, NSError error)
			{
				if (error != null) {
					TxtData.Text = error.Description;
					return;
				}

				if (landmarks == null || landmarks.Length == 0) {
					TxtData.Text = "No landmarks were found.";
					return;
				}

				var stringBuilder = new StringBuilder ();

				foreach (var landmark in landmarks) {
					stringBuilder.AppendLine ($"Landmark: {landmark.Landmark}");
					stringBuilder.AppendLine ($"Entity Id: {landmark.EntityId}");
					stringBuilder.AppendLine ($"Confidence: {landmark.Confidence}");
					stringBuilder.AppendLine ();
				}

				TxtData.Text = stringBuilder.ToString ();
			}
		}

		#endregion

		#region UIImage Picker Controller Delegate

		[Export ("imagePickerController:didFinishPickingMediaWithInfo:")]
		public void FinishedPickingMedia (UIImagePickerController picker, NSDictionary info)
		{
			var photo = info [UIImagePickerController.OriginalImage] as UIImage;
			ImgSample.Image = photo;

			picker.DismissViewController (true, null);

			TxtData.Text = string.Empty;
			AnalizeImage ();
		}

		[Export ("imagePickerControllerDidCancel:")]
		public void Canceled (UIImagePickerController picker)
		{
			picker.DismissViewController (true, null);
		}

		#endregion
	}
}
