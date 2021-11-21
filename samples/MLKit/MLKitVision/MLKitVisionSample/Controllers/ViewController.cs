using System;
using System.Collections.Generic;
using System.Text;

using AVFoundation;
using Foundation;
using CoreGraphics;
using UIKit;

using MLKit.Core;
using MLKit.BarcodeScanning;
using MLKit.FaceDetection;
using MLKit.TextRecognition;
using MLKit.DigitalInkRecognition;
using MLKit.ImageLabeling;
using MLKit.VisionKit;
using MLKit.ObjectDetection;

namespace MLKitVisionSample {
	public partial class ViewController : UIViewController, IUIImagePickerControllerDelegate {

		#region Class Variables

		VisionType currentVisionType;
		TextRecognitionScript currentTxtRecogScript;

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
			AnaylizeImage ();
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
			AnaylizeImage ();
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
			currentVisionType = (VisionType) (int) NSUserDefaults.StandardUserDefaults.IntForKey (nameof (VisionType));
			currentTxtRecogScript = (TextRecognitionScript) (int) NSUserDefaults.StandardUserDefaults.IntForKey (nameof (TextRecognitionScript));
		}

		void SetModelImage ()
		{
			ImgSample.Image = UIImage.FromFile ($"{currentVisionType}.png");
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

		void AnaylizeImage ()
		{
			switch (currentVisionType) {
			case VisionType.TextRecognition:
				UseTextRecognitionModel ();
				break;
			case VisionType.FaceDetection:
				UseFaceDetectionModel ();
				break;
			case VisionType.BarcodeScanning:
				UseBarcodeScanningModel ();
				break;
			case VisionType.DigitalInkRecognition:
				UseDigitalInkRecognitionModel ();
				break;
			case VisionType.ImageLabeling:
				UseImageLabeling ();
				break;
			case VisionType.ObjectDetectionAndTracking:
				UseObjectDetectionAndTracking ();
				break;
			default:
				TxtData.Text = "Model not supported";
				break;
			}
		}

		void UseTextRecognitionModel ()
		{
			System.Diagnostics.Debug.WriteLine ($"##### {currentTxtRecogScript}");

			CommonTextRecognizerOptions options = currentTxtRecogScript switch {
				TextRecognitionScript.Latin => new LatinTextRecognizerOptions (),
				TextRecognitionScript.Chinese => new ChineseTextRecognizerOptions (),
				TextRecognitionScript.Devanagari => new DevanagariTextRecognizerOptions (),
				TextRecognitionScript.Japanese => new JapaneseTextRecognizerOptions (),
				TextRecognitionScript.Korean => new KoreanTextRecognizerOptions (),
				_ => throw new NotImplementedException ()
			};

			var textRecognizer = TextRecognizer.TextRecognizerWithOptions (options);
			var image = new MLImage (ImgSample.Image);

			textRecognizer.ProcessImage (image, (text, err) => {
				TxtData.Text = err?.Description ?? text?.Text;
			});
		}

		void UseFaceDetectionModel ()
		{
			var options = new FaceDetectorOptions ();
			options.PerformanceMode = FacePerformanceMode.Accurate;
			options.LandmarkMode = FaceLandmarkMode.All;
			options.ClassificationMode = FaceClassificationMode.All;
			var faceDetector = FaceDetector.FaceDetectorWithOptions (options);

			var image = new MLImage (ImgSample.Image);

			faceDetector.ProcessImage (image, HandleFaceDetectorCallback);

			void HandleFaceDetectorCallback (Face [] faces, NSError error)
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
			var options = new BarcodeScannerOptions (BarcodeFormat.All);
			var barcodeScanner = BarcodeScanner.BarcodeScannerWithOptions (options);

			var image = new MLImage (ImgSample.Image);

			barcodeScanner.ProcessImage (image, HandleBarcodeScannerCallback);

			void HandleBarcodeScannerCallback (Barcode [] barcodes, NSError error)
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

		void UseDigitalInkRecognitionModel ()
		{
			strokes.Clear ();

			if (inkRecognizer == null) {
				var lang = "en-US";
				var identifier = DigitalInkRecognitionModelIdentifier.ModelIdentifierForLanguageTag (lang);
				var model = new DigitalInkRecognitionModel (identifier);
				var modelManager = ModelManager.DefaultInstance;
				var conditions = new ModelDownloadConditions (true, true);
				// This works on device, but downloads seems to fail on simulators
				modelManager.DownloadModel (model, conditions);

				var options = new DigitalInkRecognizerOptions (model);
				inkRecognizer = DigitalInkRecognizer.DigitalInkRecognizerWithOptions (options);
			}
		}

		void UseImageLabeling ()
		{
			var options = new ImageLabelerOptions ();
			options.ConfidenceThreshold = 0.7;
			var labeler = ImageLabeler.ImageLabelerWithOptions (options);

			var image = new MLImage (ImgSample.Image);

			labeler.ProcessImage (image, (labels, error) => {
				if (error != null) {
					TxtData.Text = error.Description;
					return;
				}

				if (labels == null || labels.Length == 0) {
					TxtData.Text = "No labels were found.";
					return;
				}

				var stringBuilder = new StringBuilder ();

				for (var i = 0; i < labels.Length; i++) {
					stringBuilder.AppendLine ($"Label: {i}");
					stringBuilder.AppendLine ($"Text: {labels [i].Text}");
					stringBuilder.AppendLine ($"Confidence: {labels [i].Confidence}");
					stringBuilder.AppendLine ($"Index: {labels [i].Index}");
					stringBuilder.AppendLine ();
				}

				TxtData.Text = stringBuilder.ToString ();
			});
		}

		void UseObjectDetectionAndTracking ()
		{
			var options = new ObjectDetectorOptions ();
			options.Mode = DetectorMode.SingleImage;
			options.ShouldEnableClassification = true;
			options.ShouldEnableMultipleObjects = true;
			var objectDetector = ObjectDetector.ObjectDetectorWithOptions (options);

			var image = new MLImage (ImgSample.Image);

			objectDetector.ProcessImage (image, (objects, error) => {
				if (error != null) {
					TxtData.Text = error.Description;
					return;
				}

				if (objects == null || objects.Length == 0) {
					TxtData.Text = "No objects were found.";
					return;
				}

				var imageSize = ImgSample.Image.Size;

				UIGraphics.BeginImageContextWithOptions (imageSize, false, 0);
				var context = UIGraphics.GetCurrentContext ();
				context.SetStrokeColor (UIColor.Red.CGColor);
				context.SetLineWidth (10);

				ImgSample.Image.Draw (CGPoint.Empty);

				var stringBuilder = new StringBuilder ();

				for (var i = 0; i < objects.Length; i++) {
					stringBuilder.AppendLine ($"Object: {i}");
					stringBuilder.AppendLine ($"Tracking ID: {objects [i].TrackingId?.Int32Value ?? 0}");

					foreach (var lbl in objects [i].Labels) {
						stringBuilder.AppendLine ($" - Text: {lbl.Text}");
						stringBuilder.AppendLine ($" - Confidence: {lbl.Confidence}");
						stringBuilder.AppendLine ($" - Index: {lbl.Index}");
					}

					stringBuilder.AppendLine ();

					context.AddRect (objects [i].Frame);
					context.DrawPath (CGPathDrawingMode.Stroke);
				}

				var newImage = UIGraphics.GetImageFromCurrentImageContext ();
				UIGraphics.EndImageContext ();

				ImgSample.Image = newImage;

				TxtData.Text = stringBuilder.ToString ();
			});
		}

		#endregion

		#region Digital Ink
		const int msPerTimeInterval = 1000;

		readonly List<Stroke> strokes = new List<Stroke> ();
		readonly List<StrokePoint> points = new List<StrokePoint> ();

		DigitalInkRecognizer inkRecognizer;
		CGPoint lastPoint = CGPoint.Empty;

		void DrawLine (CGPoint fromPoint, CGPoint toPoint)
		{
			UIGraphics.BeginImageContextWithOptions (ImgSample.Frame.Size, false, 0);
			var context = UIGraphics.GetCurrentContext ();

			context.MoveTo (fromPoint.X, fromPoint.Y);
			context.AddLineToPoint (toPoint.X, toPoint.Y);
			context.SetLineCap (CGLineCap.Round);
			context.SetBlendMode (CGBlendMode.Normal);
			context.SetLineWidth (10);
			context.SetStrokeColor (UIColor.Red.CGColor);

			ImgSample.Image.Draw (new CGRect (0, 0, ImgSample.Frame.Size.Width, ImgSample.Frame.Size.Height));

			context.StrokePath ();

			var newImage = UIGraphics.GetImageFromCurrentImageContext ();
			UIGraphics.EndImageContext ();

			ImgSample.Image = newImage;
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);

			if (currentVisionType != VisionType.DigitalInkRecognition)
				return;

			var touch = touches.AnyObject as UITouch;
			if (touch == null)
				return;

			lastPoint = touch.LocationInView (ImgSample);
			var t = touch.Timestamp;

			points.Add (new StrokePoint ((float) lastPoint.X, (float) lastPoint.Y, (int) (t * msPerTimeInterval)));

			DrawLine (lastPoint, lastPoint);
		}

		public override void TouchesMoved (NSSet touches, UIEvent evt)
		{
			base.TouchesMoved (touches, evt);

			if (currentVisionType != VisionType.DigitalInkRecognition)
				return;

			var touch = touches.AnyObject as UITouch;
			if (touch == null)
				return;

			var currentPoint = touch.LocationInView (ImgSample);
			var t = touch.Timestamp;

			points.Add (new StrokePoint ((float) currentPoint.X, (float) currentPoint.Y, (int) (t * msPerTimeInterval)));

			DrawLine (lastPoint, currentPoint);
			lastPoint = currentPoint;
		}

		public override void TouchesEnded (NSSet touches, UIEvent evt)
		{
			base.TouchesEnded (touches, evt);

			if (currentVisionType != VisionType.DigitalInkRecognition)
				return;

			var touch = touches.AnyObject as UITouch;
			if (touch == null)
				return;

			var currentPoint = touch.LocationInView (ImgSample);
			var t = touch.Timestamp;

			points.Add (new StrokePoint ((float) currentPoint.X, (float) currentPoint.Y, (int) (t * msPerTimeInterval)));

			DrawLine (lastPoint, currentPoint);
			lastPoint = currentPoint;

			strokes.Add (new Stroke (points.ToArray ()));
			points.Clear ();

			DoRecognition ();
		}

		void DoRecognition ()
		{
			var ink = new Ink (strokes.ToArray ());
			inkRecognizer.RecognizeInk (ink, (result, error) => {
				if (error != null) {
					TxtData.Text = error.Description;
					return;
				}

				var stringBuilder = new StringBuilder ();

				for (var i = 0; i < result.Candidates.Length; i++) {
					stringBuilder.AppendLine ($"Candiate: {i}");
					stringBuilder.AppendLine ($"Text: {result.Candidates [i].Text}");
					stringBuilder.AppendLine ($"Score: {result.Candidates [i].Score?.FloatValue.ToString () ?? "null"}");
					stringBuilder.AppendLine ();
				}

				TxtData.Text = stringBuilder.ToString ();
			});
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
			AnaylizeImage ();
		}

		[Export ("imagePickerControllerDidCancel:")]
		public void Canceled (UIImagePickerController picker)
		{
			picker.DismissViewController (true, null);
		}

		#endregion
	}
}
