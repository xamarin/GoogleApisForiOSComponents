# Get Started with Firebase MLKit for iOS

Use machine learning in your apps to solve real-world problems.

ML Kit is a mobile SDK that brings Google's machine learning expertise to Android and iOS apps in a powerful yet easy-to-use package. Whether you're new or experienced in machine learning, you can implement the functionality you need in just a few lines of code. There's no need to have deep knowledge of neural networks or model optimization to get started. On the other hand, if you are an experienced ML developer, ML Kit provides convenient APIs that help you use your custom TensorFlow Lite models in your mobile apps.

## Table of Content

- [Get Started with Firebase MLKit for iOS](#get-started-with-firebase-mlkit-for-ios)
	- [Table of Content](#table-of-content)
	- [Add Firebase to your app](#add-firebase-to-your-app)
	- [Configure Analytics in your app](#configure-analytics-in-your-app)
- [Text Recognition](#text-recognition)
	- [Choose between on-device and Cloud APIs](#choose-between-on-device-and-cloud-apis)
- [Recognize Text in Images with ML Kit on iOS](#recognize-text-in-images-with-ml-kit-on-ios)
	- [Input image guidelines](#input-image-guidelines)
	- [Recognize text in images](#recognize-text-in-images)
		- [1. Run the text recognizer](#1-run-the-text-recognizer)
		- [2. Extract text from blocks of recognized text](#2-extract-text-from-blocks-of-recognized-text)
		- [Tips to improve real-time performance](#tips-to-improve-real-time-performance)
	- [Recognize text in images of documents](#recognize-text-in-images-of-documents)
		- [1. Run the text recognizer](#1-run-the-text-recognizer-1)
		- [2. Extract text from blocks of recognized text](#2-extract-text-from-blocks-of-recognized-text-1)
- [Face Detection](#face-detection)
	- [Key capabilities](#key-capabilities)
- [Face Detection Concepts Overview](#face-detection-concepts-overview)
- [Detect Faces with ML Kit on iOS](#detect-faces-with-ml-kit-on-ios)
	- [Input image guidelines](#input-image-guidelines-1)
	- [1. Configure the face detector](#1-configure-the-face-detector)
	- [2. Run the face detector](#2-run-the-face-detector)
	- [3. Get information about detected faces](#3-get-information-about-detected-faces)
- [Barcode Scanning](#barcode-scanning)
	- [Key capabilities](#key-capabilities-1)
- [Scan Barcodes with ML Kit on iOS](#scan-barcodes-with-ml-kit-on-ios)
	- [Input image guidelines](#input-image-guidelines-2)
	- [1. Configure the barcode detector](#1-configure-the-barcode-detector)
	- [2. Run the barcode detector](#2-run-the-barcode-detector)
	- [3. Get information from barcodes](#3-get-information-from-barcodes)
	- [Tips to improve real-time performance](#tips-to-improve-real-time-performance-1)
- [Image Labeling](#image-labeling)
	- [Choose between on-device and Cloud APIs](#choose-between-on-device-and-cloud-apis-1)
		- [Example on-device labels](#example-on-device-labels)
		- [Example cloud labels](#example-cloud-labels)
	- [Google Knowledge Graph entity IDs](#google-knowledge-graph-entity-ids)
- [Label Images with ML Kit on iOS](#label-images-with-ml-kit-on-ios)
	- [On-device image labeling](#on-device-image-labeling)
		- [1. Configure the image labeler](#1-configure-the-image-labeler)
		- [2. Run the image labeler](#2-run-the-image-labeler)
		- [3. Get information about labeled objects](#3-get-information-about-labeled-objects)
		- [Tips to improve real-time performance](#tips-to-improve-real-time-performance-2)
	- [Cloud image labeling](#cloud-image-labeling)
		- [1. Configure the image labeler](#1-configure-the-image-labeler-1)
		- [2. Run the image labeler](#2-run-the-image-labeler-1)
		- [3. Get information about labeled objects](#3-get-information-about-labeled-objects-1)
- [Landmark Recognition](#landmark-recognition)
	- [Key capabilities](#key-capabilities-2)
- [Recognize Landmarks with ML Kit on iOS](#recognize-landmarks-with-ml-kit-on-ios)
	- [Configure the landmark detector](#configure-the-landmark-detector)
	- [Run the landmark detector](#run-the-landmark-detector)
	- [Get information about the recognized landmarks](#get-information-about-the-recognized-landmarks)
- [Protect your ML Kit iOS app's Cloud credentials](#protect-your-ml-kit-ios-apps-cloud-credentials)

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

If you want to use the Cloud-based model, and you have not already enabled the Cloud-based APIs for your project, do so now:

1. Open the ML Kit APIs page of the Firebase console.
2. If you have not already upgraded your project to a Blaze plan, click **Upgrade** to do so. (You will be prompted to upgrade only if your project isn't on the Blaze plan.)
	
	Only Blaze-level projects can use Cloud-based APIs.

3. If Cloud-based APIs aren't already enabled, click **Enable Cloud-based APIs.**

> ![note_icon] *Before you deploy to production an app that uses a Cloud API, you should take some additional steps to [prevent and mitigate the effect of unauthorized API access.][4]*

If you want to use only the on-device model, you can skip these steps.

## Configure Analytics in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Visual Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
App.Configure ();
```

---

# Text Recognition

With ML Kit's text recognition APIs, you can recognize text in any Latin-based language (and more, with Cloud-based text recognition).

Text recognition can automate tedious data entry for credit cards, receipts, and business cards. With the Cloud-based API, you can also extract text from documents, which you can use to increase accessibility or translate documents. Apps can even keep track of real-world objects, such as by reading the numbers on trains.

## Choose between on-device and Cloud APIs

|  | On-device | Cloud |
|--|-----------|-------|
| **Pricing** | Free | Free for first 1000 uses of this feature per month: see [Pricing][1] |
| **Ideal use cases** | Real-time processing—ideal for a camera or video feed <br /> Recognizing sparse text in images | High-accuracy text recognition <br /> Recognizing sparse text in images <br /> Recognizing densely-spaced text in documents <br /><br /> See the [Cloud Vision API demo][2] |
| **Language support** | Recognizes Latin characters | Recognizes and identifies a broad range of languages and special characters |

# Recognize Text in Images with ML Kit on iOS

You can use ML Kit to recognize text in images. ML Kit has both a general-purpose API suitable for recognizing text in images, such as the text of a street sign, and an API optimized for recognizing the text of documents. The general-purpose API has both on-device and cloud-based models. Document text recognition is available only as a cloud-based model. See the [overview][3] for a comparison of the cloud and on-device models.

## Input image guidelines

* For ML Kit to accurately recognize text, input images must contain text that is represented by sufficient pixel data. Ideally, for Latin text, each character should be at least 16x16 pixels. For Chinese, Japanese, and Korean text (only supported by the cloud-based APIs), each character should be 24x24 pixels. For all languages, there is generally no accuracy benefit for characters to be larger than 24x24 pixels.
	
	So, for example, a 640x480 image might work well to scan a business card that occupies the full width of the image. To scan a document printed on letter-sized paper, a 720x1280 pixel image might be required.

* Poor image focus can hurt text recognition accuracy. If you aren't getting acceptable results, try asking the user to recapture the image.
* If you are recognizing text in a real-time application, you might also want to consider the overall dimensions of the input images. Smaller images can be processed faster, so to reduce latency, capture images at lower resolutions (keeping in mind the above accuracy requirements) and ensure that the text occupies as much of the image as possible.

## Recognize text in images

To recognize text in an image using either an on-device or cloud-based model, run the text recognizer as described below.

### 1. Run the text recognizer

Pass the image as a `UIImage` or a `CMSampleBuffer` to the `VisionTextRecognizer`'s `ProcessImage` method:

1. Get an instance of `VisionTextRecognizer` by calling either `GetOnDeviceTextRecognizer` or `GetCloudTextRecognizer`:

	```csharp
	var vision = VisionApi.Create ();
	var textRecognizer = vision.GetOnDeviceTextRecognizer ();
	```

	To use the cloud model:

	> ![note_icon] _Use of ML Kit to access Cloud ML functionality is subject to the [Google Cloud Platform License Agreement][5] and [Service Specific Terms][6], and billed accordingly. For billing information, see the Firebase [Pricing][1] page._

	```csharp
	var vision = VisionApi.Create ();
	var textRecognizer = vision.GetOnDeviceTextRecognizer ();

	// Or, to provide language hints to assist with language detection:
	// See https://cloud.google.com/vision/docs/languages for supported languages
	var options = new VisionCloudTextRecognizerOptions { LanguageHints = new []{ "es" } }; 
	var textRecognizer = vision.GetCloudTextRecognizer (options);
	```

2. Create a `VisionImage` object using a `UIImage` or a `CMSampleBuffer`.

	To use a `UIImage`:

	1. If necessary, rotate the image so that its `ImageOrientation` property is `Up`.
	2. Create a `VisionImage` object using the correctly-rotated `UIImage`. Do not specify any rotation metadata—the default value, `TopLeft`, must be used.

	```csharp
	var image = new VisionImage (anImage);
	```

	To use a `CMSampleBuffer`:

	1. Create a `VisionImageMetadata` object that specifies the orientation of the image data contained in the `CMSampleBuffer` buffer.
	
		For example, if you are using image data captured from the device's back-facing camera:

		```csharp
		var metadata = new VisionImageMetadata ();

		// Using back-facing camera
		var devicePosition = AVCaptureDevicePosition.Back;

		var deviceOrientation = UIDevice.CurrentDevice.Orientation;

		switch (deviceOrientation) {
		case UIDeviceOrientation.Portrait:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.LeftTop : VisionDetectorImageOrientation.RightTop;
			break;
		case UIDeviceOrientation.LandscapeLeft:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.BottomLeft : VisionDetectorImageOrientation.TopLeft;
			break;
		case UIDeviceOrientation.PortraitUpsideDown:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.RightBottom : VisionDetectorImageOrientation.LeftBottom;
			break;
		case UIDeviceOrientation.LandscapeRight:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.TopRight : VisionDetectorImageOrientation.BottomRight;
			break;
		case UIDeviceOrientation.FaceUp:
		case UIDeviceOrientation.FaceDown:
		case UIDeviceOrientation.Unknown:
			metadata.Orientation = VisionDetectorImageOrientation.LeftTop;
			break;
		}
		```

	2. Create a `VisionImage` object using the `CMSampleBuffer` object and the rotation metadata:

		```csharp
		var image = new VisionImage (buffer);
		image.Metadata = metadata;
		```

3. Then, pass the image to the `ProcessImage` method:

	```csharp
	textRecognizer.ProcessImage (image, HandleVisionTextRecognitionCallback);

	void HandleVisionTextRecognitionCallback (VisionText text, NSError error)
	{
		Console.WriteLine (error?.Description ?? text?.Text);
	}

	// or using async / await

	try {
		var text = await textRecognizer.ProcessImageAsync (image);
		Console.WriteLine (text.Text);
	} catch (NSErrorException ex) {
		Console.WriteLine (ex.Error.Description);
	}
	```

### 2. Extract text from blocks of recognized text

If the text recognition operation succeeds, it will return a `VisionText` object. A `VisionText` object contains the full text recognized in the image and zero or more `VisionTextBlock` objects.

Each `VisionTextBlock` represents a rectangular block of text, which contain zero or more `VisionTextLine` objects.

Each `VisionTextLine` object contains zero or more `VisionTextElement` objects, which represent words and word-like entities (dates, numbers, and so on).

For each `VisionTextBlock`, `VisionTextLine`, and `VisionTextElement` object, you can get the text recognized in the region and the bounding coordinates of the region.

For example:

```csharp
foreach (var block in text.Blocks) {
	var blockText = block.Text;
	var blockConfidence = block.Confidence.Value;
	var blockLanguage = block.RecognizedLanguages;
	var blockCornerPoints = block.CornerPoints;
	var blockFrame = block.Frame;

	foreach (var line in block.Lines) {
		var lineText = line.Text;
		var lineConfidence = line.Confidence.Value;
		var lineLanguage = line.RecognizedLanguages;
		var lineCornerPoints = line.CornerPoints;
		var lineFrame = line.Frame;

		foreach (var element in line.Elements) {
			var elementText = element.Text;
			var elementConfidence = element.Confidence.Value;
			var elementLanguage = element.RecognizedLanguages;
			var elementCornerPoints = element.CornerPoints;
			var elementFrame = element.Frame;
		}
	}
}
```

### Tips to improve real-time performance

If you want use the on-device model to recognize text in a real-time application, follow these guidelines to achieve the best framerates:

* Throttle calls to the text recognizer. If a new video frame becomes available while the text recognizer is running, drop the frame.
* Consider capturing images at a lower resolution. However, also keep in mind this API's image dimension requirements.

## Recognize text in images of documents

To recognize the text of a document, configure and run the cloud-based document text recognizer as described below.

> ![note_icon] _Use of ML Kit to access Cloud ML functionality is subject to the [Google Cloud Platform License Agreement][5] and [Service Specific Terms][6], and billed accordingly. For billing information, see the Firebase [Pricing][1] page._

The document text recognition API, described below, provides an interface that is intended to be more convenient for working with images of documents. However, if you prefer the interface provided by the sparse text API, you can use it instead to scan documents by configuring the cloud text recognizer to use the dense text model.

To use the document text recognition API:

### 1. Run the text recognizer

Pass the image as a `UIImage` or a `CMSampleBuffer` to the `VisionDocumentTextRecognizer`'s `ProcessImage` method:

1. Get an instance of `VisionDocumentTextRecognizer` by calling `GetCloudDocumentTextRecognizer`:

	```csharp
	var vision = VisionApi.Create ();
	var textRecognizer = vision.GetCloudDocumentTextRecognizer ();

	// Or, to provide language hints to assist with language detection:
	// See https://cloud.google.com/vision/docs/languages for supported languages
	var options = new VisionCloudDocumentTextRecognizerOptions { LanguageHints = new [] { "es" } };
	var textRecognizer = vision.GetCloudDocumentTextRecognizer (options);
	```

2. Create a `VisionImage` object using a `UIImage` or a `CMSampleBuffer`.

	To use a `UIImage`:

	1. If necessary, rotate the image so that its `ImageOrientation` property is `Up`.
	2. Create a `VisionImage` object using the correctly-rotated `UIImage`. Do not specify any rotation metadata—the default value, `TopLeft`, must be used.

	```csharp
	var image = new VisionImage (anImage);
	```

	To use a `CMSampleBuffer`:

	1. Create a `VisionImageMetadata` object that specifies the orientation of the image data contained in the `CMSampleBuffer` buffer.
	
		For example, if you are using image data captured from the device's back-facing camera:

		```csharp
		var metadata = new VisionImageMetadata ();

		// Using back-facing camera
		var devicePosition = AVCaptureDevicePosition.Back;

		var deviceOrientation = UIDevice.CurrentDevice.Orientation;

		switch (deviceOrientation) {
		case UIDeviceOrientation.Portrait:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.LeftTop : VisionDetectorImageOrientation.RightTop;
			break;
		case UIDeviceOrientation.LandscapeLeft:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.BottomLeft : VisionDetectorImageOrientation.TopLeft;
			break;
		case UIDeviceOrientation.PortraitUpsideDown:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.RightBottom : VisionDetectorImageOrientation.LeftBottom;
			break;
		case UIDeviceOrientation.LandscapeRight:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.TopRight : VisionDetectorImageOrientation.BottomRight;
			break;
		case UIDeviceOrientation.FaceUp:
		case UIDeviceOrientation.FaceDown:
		case UIDeviceOrientation.Unknown:
			metadata.Orientation = VisionDetectorImageOrientation.LeftTop;
			break;
		}
		```

	2. Create a `VisionImage` object using the `CMSampleBuffer` object and the rotation metadata:

		```csharp
		var image = new VisionImage (buffer);
		image.Metadata = metadata;
		```

3. Then, pass the image to the `ProcessImage` method:

	```csharp
	textRecognizer.ProcessImage (image, HandleVisionDocumentTextRecognitionCallback);

	void HandleVisionDocumentTextRecognitionCallback (VisionDocumentText text, NSError error)
	{
		Console.WriteLine (error?.Description ?? text?.Text);
	}

	// or using async / await

	try {
		var text = await textRecognizer.ProcessImageAsync (image);
		Console.WriteLine (text.Text);
	} catch (NSErrorException ex) {
		Console.WriteLine (ex.Error.Description);
	}
	```

### 2. Extract text from blocks of recognized text

If the text recognition operation succeeds, it will return a `VisionDocumentText` object. A `VisionDocumentText` object contains the full text recognized in the image and a hierarchy of objects that reflect the structure of the recognized document:

* `VisionDocumentTextBlock`
* `VisionDocumentTextParagraph`
* `VisionDocumentTextWord`
* `VisionDocumentTextSymbol`

For each `VisionDocumentTextBlock`, `VisionDocumentTextParagraph`, `VisionDocumentTextWord`, and `VisionDocumentTextSymbol` object, you can get the text recognized in the region and the bounding coordinates of the region.

For example:

```csharp
foreach (var block in text.Blocks) {
	var blockText = block.Text;
	var blockConfidence = block.Confidence.Value;
	var blockLanguage = block.RecognizedLanguages;
	var blockRecognizedBreak = block.RecognizedBreak;
	var blockFrame = block.Frame;

	foreach (var paragraph in block.Paragraphs) {
		var paragraphText = paragraph.Text;
		var paragraphConfidence = paragraph.Confidence;
		var paragraphLanguage = paragraph.RecognizedLanguages;
		var paragraphRecognizedBreak = paragraph.RecognizedBreak;
		var paragraphFrame = paragraph.Frame;

		foreach (var word in paragraph.Words) {
			var wordText = word.Text;
			var wordConfidence = word.Confidence;
			var wordLanguage = word.RecognizedLanguages;
			var wordRecognizedBreak = word.RecognizedBreak;
			var wordFrame = word.Frame;

			foreach (var symbol in word.Symbols) {
				var symbolText = symbol.Text;
				var symbolConfidence = symbol.Confidence;
				var symbolLanguage = symbol.RecognizedLanguages;
				var symbolRecognizedBreak = symbol.RecognizedBreak;
				var symbolFrame = symbol.Frame;
			}
		}
	}
}
```

---

# Face Detection

With ML Kit's face detection API, you can detect faces in an image, identify key facial features, and get the contours of detected faces.

With face detection, you can get the information you need to perform tasks like embellishing selfies and portraits, or generating avatars from a user's photo. Because ML Kit can perform face detection in real time, you can use it in applications like video chat or games that respond to the player's expressions.

## Key capabilities

| | |
|-------|-------|
| **Recognize and locate facial features** | Get the coordinates of the eyes, ears, cheeks, nose, and mouth of every face detected. |
| **Get the contours of facial features** | Get the contours of detected faces and their eyes, eyebrows, lips, and nose. |
| **Recognize facial expressions** | Determine whether a person is smiling or has their eyes closed. |
| **Track faces across video frames** | Get an identifier for each individual person's face that is detected. This identifier is consistent across invocations, so you can, for example, perform image manipulation on a particular person in a video stream. |
| **Process video frames in real time** | Face detection is performed on the device, and is fast enough to be used in real-time applications, such as video manipulation. |

# Face Detection Concepts Overview

Face detection is the process of automatically locating human faces in visual media (digital images or video). A face that is detected is reported at a position with an associated size and orientation. Once a face is detected, it can be searched for landmarks such as the eyes and nose.

To learn more about this, please, read the following [documentation][7].

# Detect Faces with ML Kit on iOS

You can use ML Kit to detect faces in images and video.

## Input image guidelines

For ML Kit to accurately detect faces, input images must contain faces that are represented by sufficient pixel data. In general, each face you want to detect in an image should be at least 100x100 pixels. If you want to detect the contours of faces, ML Kit requires higher resolution input: each face should be at least 200x200 pixels.

If you are detecting faces in a real-time application, you might also want to consider the overall dimensions of the input images. Smaller images can be processed faster, so to reduce latency, capture images at lower resolutions (keeping in mind the above accuracy requirements) and ensure that the subject's face occupies as much of the image as possible.

Poor image focus can hurt accuracy. If you aren't getting acceptable results, try asking the user to recapture the image.

The orientation of a face relative to the camera can also affect what facial features ML Kit detects. See [Face Detection Concepts][7].

## 1. Configure the face detector

Before you apply face detection to an image, if you want to change any of the face detector's default settings, specify those settings with a `VisionFaceDetectorOptions` object. You can change the following settings:

| Settings | Value |
|----------|-------|
| **PerformanceMode** | **Fast** (default) / **Accurate** <br /><br /> Favor speed or accuracy when detecting faces. |
| **LandmarkMode**    | **None** (default) / **All** <br /><br /> Whether to attempt to detect the facial "landmarks"—eyes, ears, nose, cheeks, mouth—of all detected faces. |
| **ContourMode** | **None** (default) / **All** <br /><br /> Whether to detect the contours of facial features. Contours are detected for only the most prominent face in an image. |
| **ClassificationMode** | **None** (default) / **All** <br /><br /> Whether or not to classify faces into categories such as "smiling", and "eyes open". |
| **MinFaceSize** | **CGFloat** (default: 0.1) <br /><br /> The minimum size, relative to the image, of faces to detect. |
| **IsTrackingEnabled** | **False** (default) / **True** <br /><br /> Whether or not to assign faces an ID, which can be used to track faces across images. <br /><br /> Note that when contour detection is enabled, only one face is detected, so face tracking doesn't produce useful results. For this reason, and to improve detection speed, don't enable both contour detection and face tracking.

For example, build a `VisionFaceDetectorOptions` object like one of the following examples:

```csharp
// High-accuracy landmark detection and face classification
var options = new VisionFaceDetectorOptions {
	PerformanceMode = VisionFaceDetectorPerformanceMode.Accurate,
	LandmarkMode = VisionFaceDetectorLandmarkMode.All,
	ClassificationMode = VisionFaceDetectorClassificationMode.All
};

// Real-time contour detection of multiple faces
var options = new VisionFaceDetectorOptions {
	ContourMode = VisionFaceDetectorContourMode.All
};
```

## 2. Run the face detector

To detect faces in an image, pass the image as a `UIImage` or a `CMSampleBuffer` to the `VisionFaceDetector`'s `ProcessImage` method:

1. Get an instance of VisionFaceDetector:

	```csharp
	var vision = VisionApi.Create ();
	var faceDetector = vision.GetFaceDetector ();
	```

2. Create a `VisionImage` object using a `UIImage` or a `CMSampleBuffer`.

	To use a `UIImage`:

	1. If necessary, rotate the image so that its `ImageOrientation` property is `Up`.
	2. Create a `VisionImage` object using the correctly-rotated `UIImage`. Do not specify any rotation metadata—the default value, `TopLeft`, must be used.

	```csharp
	var image = new VisionImage (anImage);
	```

	To use a `CMSampleBuffer`:

	1. Create a `VisionImageMetadata` object that specifies the orientation of the image data contained in the `CMSampleBuffer` buffer.
	
		For example, if you are using image data captured from the device's back-facing camera:

		```csharp
		var metadata = new VisionImageMetadata ();

		// Using back-facing camera
		var devicePosition = AVCaptureDevicePosition.Back;

		var deviceOrientation = UIDevice.CurrentDevice.Orientation;

		switch (deviceOrientation) {
		case UIDeviceOrientation.Portrait:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.LeftTop : VisionDetectorImageOrientation.RightTop;
			break;
		case UIDeviceOrientation.LandscapeLeft:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.BottomLeft : VisionDetectorImageOrientation.TopLeft;
			break;
		case UIDeviceOrientation.PortraitUpsideDown:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.RightBottom : VisionDetectorImageOrientation.LeftBottom;
			break;
		case UIDeviceOrientation.LandscapeRight:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.TopRight : VisionDetectorImageOrientation.BottomRight;
			break;
		case UIDeviceOrientation.FaceUp:
		case UIDeviceOrientation.FaceDown:
		case UIDeviceOrientation.Unknown:
			metadata.Orientation = VisionDetectorImageOrientation.LeftTop;
			break;
		}
		```

	2. Create a `VisionImage` object using the `CMSampleBuffer` object and the rotation metadata:

		```csharp
		var image = new VisionImage (buffer);
		image.Metadata = metadata;
		```

3. Then, pass the image to the `ProcessImage` method:

	```csharp
	faceDetector.ProcessImage (image, HandleVisionFaceDetectionCallback);

	void HandleVisionFaceDetectionCallback (VisionFace [] faces, NSError error)
	{
		if (error != null) {
			Console.WriteLine (error.Description);
			return;
		}

		if (faces == null || faces.Length == 0) {
			Console.WriteLine ("No faces were found.");
			return;
		}

		Console.WriteLine ("Faces were found.");
	}

	// or using async / await

	try {
		var faces = await faceDetector.ProcessImageAsync (image);
		Console.WriteLine (faces != null || faces.Length == 0 ? "No faces were found." : "Faces were found");
	} catch (NSErrorException ex) {
		Console.WriteLine (ex.Error.Description);
	}
	```

## 3. Get information about detected faces

If the face detection operation succeeds, the face detector passes an array of `VisionFace` objects to the completion handler. Each `VisionFace` object represents a face that was detected in the image. For each face, you can get its bounding coordinates in the input image, as well as any other information you configured the face detector to find. For example:

```csharp
foreach (var face in faces) {
	// Boundaries of face in image
	var frame = face.Frame;
	if (face.HasHeadEulerAngleY) {
		var rotY = face.HeadEulerAngleY; // Head is rotated to the right rotY degrees
	}
	if (face.HasHeadEulerAngleZ) {
		var rotY = face.HeadEulerAngleZ; // Head is rotated upward rotZ degrees
	}
	// If landmark detection was enabled (mouth, ears, eyes, cheeks, and
	// nose available):
	if (face.GetLandmark (FaceLandmarkType.LeftEye) is VisionFaceLandmark leftEye) {
		var leftEyePosition = leftEye.Position;
	}
	// If contour detection was enabled:
	if (face.GetContour (FaceContourType.LeftEye) is VisionFaceContour leftEyeContour) {
		var leftEyePoints = leftEyeContour.Points;
	}
	if (face.GetContour (FaceContourType.UpperLipBottom) is VisionFaceContour upperLipBottomContour) {
		var upperLipBottomPoints = upperLipBottomContour.Points;
	}
	// If classification was enabled:
	if (face.HasSmilingProbability) {
		var smilingProbability = face.SmilingProbability;
	}
	if (face.HasRightEyeOpenProbability) {
		var rightEyeOpenProbability = face.RightEyeOpenProbability;
	}
	// If face tracking was enabled:
	if (face.HasTrackingId) {
		var trackingId = face.TrackingId;
	}
}
```

---

# Barcode Scanning

With ML Kit's barcode scanning API, you can read data encoded using most standard barcode formats.

Barcodes are a convenient way to pass information from the real world to your app. In particular, when using 2D formats such as QR code, you can encode structured data such as contact information or WiFi network credentials. Because ML Kit can automatically recognize and parse this data, your app can respond intelligently when a user scans a barcode.

## Key capabilities

|  |  |
|-------|-------|
| **Reads most standard formats** | Linear formats: Codabar, Code 39, Code 93, Code 128, EAN-8, EAN-13, ITF, UPC-A, UPC-E <br /><br /> 2D formats: Aztec, Data Matrix, PDF417, QR Code |
| **Automatic format detection** | Scan for all supported barcode formats at once, without having to specify the format you're looking for. Or, boost scanning speed by restricting the detector to only the formats you're interested in. |
| **Extracts structured data** | Structured data stored using one of the supported 2D formats are automatically parsed. Supported information types include URLs, contact information, calendar events, email addresses, phone numbers, SMS message prompts, ISBNs, WiFi connection information, geographic location, and AAMVA-standard driver information. |
| **Works with any orientation** | Barcodes are recognized and scanned regardless of their orientation: right-side-up, upside-down, or sideways. |

# Scan Barcodes with ML Kit on iOS

You can use ML Kit to recognize and decode barcodes.

## Input image guidelines

* For ML Kit to accurately read barcodes, input images must contain barcodes that are represented by sufficient pixel data. In general, the smallest meaningful unit of the barcode should be at least 2 pixels wide (and for 2-dimensional codes, 2 pixels tall).

	For example, EAN-13 barcodes are made up of bars and spaces that are 1, 2, 3, or 4 units wide, so an EAN-13 barcode image ideally has bars and spaces that are at least 2, 4, 6, and 8 pixels wide. Because an EAN-13 barcode is 95 units wide in total, the barcode should be at least 190 pixels wide.

	Denser formats, such as PDF417, need greater pixel dimensions for ML Kit to reliably read them. For example, a PDF417 code can have up to 34 17-unit wide "words" in a single row, which would ideally be at least 1156 pixels wide.

* Poor image focus can hurt scanning accuracy. If you aren't getting acceptable results, try asking the user to recapture the image.

* If you are scanning barcodes in a real-time application, you might also want to consider the overall dimensions of the input images. Smaller images can be processed faster, so to reduce latency, capture images at lower resolutions (keeping in mind the above accuracy requirements) and ensure that the barcode occupies as much of the image as possible.

## 1. Configure the barcode detector

If you know which barcode formats you expect to read, you can improve the speed of the barcode detector by configuring it to only detect those formats.

For example, to detect only Aztec code and QR codes, build a `VisionBarcodeDetectorOptions` object as in the following example:

```csharp
var options = new VisionBarcodeDetectorOptions (VisionBarcodeFormat.All);
```

The following formats are supported:

* Code128
* Code39
* Code93
* CodaBar
* EAN13
* EAN8
* ITF
* UPCA
* UPCE
* QRCode
* PDF417
* Aztec
* DataMatrix

> ![note_icon] **_Note:_** _For a Data Matrix code to be recognized, the code must intersect the center point of the input image. Consequently, only one Data Matrix code can be recognized in an image._

## 2. Run the barcode detector

To scan barcodes in an image, pass the image as a `UIImage` or a `CMSampleBuffer` to the `VisionBarcodeDetector`'s `Detect` method:

1. Get an instance of VisionFaceDetector:

	```csharp
	var vision = VisionApi.Create ();
	var faceDetector = vision.GetBarcodeDetector (options);
	```

2. Create a `VisionImage` object using a `UIImage` or a `CMSampleBuffer`.

	To use a `UIImage`:

	1. If necessary, rotate the image so that its `ImageOrientation` property is `Up`.
	2. Create a `VisionImage` object using the correctly-rotated `UIImage`. Do not specify any rotation metadata—the default value, `TopLeft`, must be used.

	```csharp
	var image = new VisionImage (anImage);
	```

	To use a `CMSampleBuffer`:

	1. Create a `VisionImageMetadata` object that specifies the orientation of the image data contained in the `CMSampleBuffer` buffer.
	
		For example, if you are using image data captured from the device's back-facing camera:

		```csharp
		var metadata = new VisionImageMetadata ();

		// Using back-facing camera
		var devicePosition = AVCaptureDevicePosition.Back;

		var deviceOrientation = UIDevice.CurrentDevice.Orientation;

		switch (deviceOrientation) {
		case UIDeviceOrientation.Portrait:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.LeftTop : VisionDetectorImageOrientation.RightTop;
			break;
		case UIDeviceOrientation.LandscapeLeft:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.BottomLeft : VisionDetectorImageOrientation.TopLeft;
			break;
		case UIDeviceOrientation.PortraitUpsideDown:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.RightBottom : VisionDetectorImageOrientation.LeftBottom;
			break;
		case UIDeviceOrientation.LandscapeRight:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.TopRight : VisionDetectorImageOrientation.BottomRight;
			break;
		case UIDeviceOrientation.FaceUp:
		case UIDeviceOrientation.FaceDown:
		case UIDeviceOrientation.Unknown:
			metadata.Orientation = VisionDetectorImageOrientation.LeftTop;
			break;
		}
		```

	2. Create a `VisionImage` object using the `CMSampleBuffer` object and the rotation metadata:

		```csharp
		var image = new VisionImage (buffer);
		image.Metadata = metadata;
		```

3. Then, pass the image to the `Detect` method:

	```csharp
	barcodeDetector.Detect (image, HandleVisionBarcodeDetectionCallback);

	void HandleVisionBarcodeDetectionCallback (VisionBarcode [] barcodes, NSError error)
	{
		if (error != null) {
			Console.WriteLine (error.Description);
			return;
		}

		if (barcodes == null || barcodes.Length == 0) {
			Console.WriteLine ("No barcodes were found.");
			return;
		}
		
		Console.WriteLine ("Barcodes were found.");
	}

	// or using async / await

	try {
		var barcodes = await barcodeDetector.DetectAsync (image);
		Console.WriteLine (barcodes != null || barcodes.Length == 0 ? "No barcodes were found." : "Barcodes were found");
	} catch (NSErrorException ex) {
		Console.WriteLine (ex.Error.Description);
	}
	```

## 3. Get information from barcodes

If the barcode recognition operation succeeds, the detector returns an array of `VisionBarcode` objects. Each `VisionBarcode` object represents a barcode that was detected in the image. For each barcode, you can get its bounding coordinates in the input image, as well as the raw data encoded by the barcode. Also, if the barcode detector was able to determine the type of data encoded by the barcode, you can get an object containing parsed data.

For example:

```csharp
foreach (var barcode in barcodes) {
	var corners = barcode.CornerPoints;
	var displayValue = barcode.DisplayValue;
	var rawValue = barcode.RawValue;
	var valueType = barcode.ValueType;

	switch (valueType) {
	case VisionBarcodeValueType.WiFi:
		var ssid = barcode.Wifi.Ssid;
		var password = barcode.Wifi.Password;
		var encryptionType = barcode.Wifi.Type;
		break;
	case VisionBarcodeValueType.Url:
		var title = barcode.Url.Title;
		var url = barcode.Url.Url;
		break;
	default:
		// See API reference for all supported value types
		break;
	}
}
```

## Tips to improve real-time performance

If you want to scan barcodes in a real-time application, follow these guidelines to achieve the best framerates:

* Throttle calls to the detector. If a new video frame becomes available while the detector is running, drop the frame.

* If you are using the output of the detector to overlay graphics on the input image, first get the result from ML Kit, then render the image and overlay in a single step. By doing so, you render to the display surface only once for each input frame.

* If you use the Camera2 API, capture images in `ImageFormat.YUV_420_888` format.

	If you use the older Camera API, capture images in `ImageFormat.NV21` format.

* Consider capturing images at a lower resolution. However, also keep in mind this API's image dimension requirements.

---

# Image Labeling

With ML Kit's image labeling APIs, you can recognize entities in an image without having to provide any additional contextual metadata, using either an on-device API or a cloud-based API.

Image labeling gives you insight into the content of images. When you use the API, you get a list of the entities that were recognized: people, things, places, activities, and so on. Each label found comes with a score that indicates the confidence the ML model has in its relevance. With this information, you can perform tasks such as automatic metadata generation and content moderation.

## Choose between on-device and Cloud APIs

|  | On-device | Cloud |
|--|-----------|-------|
| **Pricing** | Free | Free for first 1000 uses of this feature per month: see [Pricing][1] |
| **Label coverage** | 400+ labels that cover the most commonly-found concepts in photos. See below. | 10,000+ labels in many categories. See below. <br /><br /> Also, try the [Cloud Vision API demo][2] to see what labels can be found for an image you provide. |
| **Knowledge Graph entity ID support** | ![available_icon] | ![available_icon] |

### Example on-device labels

The device-based API supports 400+ labels, such as the following examples:

| Category   | Example labels                       |
|------------|--------------------------------------|
| People     | Crowd <br /> Selfie <br /> Smile     |
| Activities | Dancing <br /> Eating <br /> Surfing |
| Things     | Car <br /> Piano <br /> Receipt      |
| Animals    | Bird <br /> Cat <br /> Dog           |
| Plants     | Flower <br /> Fruit <br /> Vegetable |
| Places     | Beach <br /> Lake <br /> Mountain    |

### Example cloud labels

The cloud-based API supports 10,000+ labels, such as the following examples:

| Category | Example labels | Category | Example labels
| ---------|----------------|----------|---------------
| Arts & entertainment | Sculpture <br /> Musical Instrument <br /> Dance | Astronomical objects | Comet <br /> Galaxy <br /> Star |
| Business & industrial | Restaurant <br /> Factory <br /> Airline | Colors | Red <br /> Green <br /> Blue |
| Design | Floral <br /> Pattern <br /> Wood Stain | Drink | Coffee <br /> Tea <br /> Milk |
| Events | Meeting <br /> Picnic <br /> Vacation |  Fictional characters | Santa Claus <br /> Superhero <br /> Mythical creature |
| Food | Casserole <br /> Fruit <br /> Potato chip | Home & garden | Laundry basket <br /> Dishwasher <br /> Fountain |
| Activities | Wedding <br /> Dancing <br /> Motorsport | Materials | Ceramic <br /> Textile <br /> Fiber |
| Media | Newsprint <br /> Document <br /> Sign | Modes of transport | Aircraft <br /> Motorcycle <br /> Subway |
| Occupations | Actor <br /> Florist <br /> Police | Organisms | Plant <br /> Animal <br /> Fungus |
| Organizations | Government <br /> Club <br /> College | Places | Airport <br /> Mountain <br /> Tent |
| Technology | Robot <br /> Computer <br /> Solar panel | Things | Bicycle <br /> Pipe <br /> Doll |

## Google Knowledge Graph entity IDs

In addition the text description of each label that ML Kit returns, it also returns the label's Google Knowledge Graph entity ID. This ID is a string that uniquely identifies the entity represented by the label, and is the same ID used by the [Knowledge Graph Search API][8]. You can use this string to identify an entity across languages, and independently of the formatting of the text description.

# Label Images with ML Kit on iOS

You can use ML Kit to label objects recognized in an image, using either an on-device model or a cloud model.

## On-device image labeling

To use the on-device image labeling model, configure and run the the image labeler as described below.

### 1. Configure the image labeler

By default, the on-device image labeler returns only labels that have a confidence score of 0.5 or greater. If you want to change this setting, create a `VisionLabelDetectorOptions` object as in the following example:

```csharp
var options = new VisionLabelDetectorOptions (.6f);
```

### 2. Run the image labeler

To recognize and label entities in an image, pass the image as a `UIImage` or a `CMSampleBuffer` to the `VisionLabelDetector`'s `Detect` method:

1. Get an instance of `VisionLabelDetector`:

	```csharp
	var vision = VisionApi.Create ();
	var labelDetector = vision.GetLabelDetector (options);
	```

2. Create a `VisionImage` object using a `UIImage` or a `CMSampleBuffer`.

	To use a `UIImage`:

	1. If necessary, rotate the image so that its `ImageOrientation` property is `Up`.
	2. Create a `VisionImage` object using the correctly-rotated `UIImage`. Do not specify any rotation metadata—the default value, `TopLeft`, must be used.

	```csharp
	var image = new VisionImage (anImage);
	```

	To use a `CMSampleBuffer`:

	1. Create a `VisionImageMetadata` object that specifies the orientation of the image data contained in the `CMSampleBuffer` buffer.
	
		For example, if you are using image data captured from the device's back-facing camera:

		```csharp
		var metadata = new VisionImageMetadata ();

		// Using back-facing camera
		var devicePosition = AVCaptureDevicePosition.Back;

		var deviceOrientation = UIDevice.CurrentDevice.Orientation;

		switch (deviceOrientation) {
		case UIDeviceOrientation.Portrait:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.LeftTop : VisionDetectorImageOrientation.RightTop;
			break;
		case UIDeviceOrientation.LandscapeLeft:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.BottomLeft : VisionDetectorImageOrientation.TopLeft;
			break;
		case UIDeviceOrientation.PortraitUpsideDown:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.RightBottom : VisionDetectorImageOrientation.LeftBottom;
			break;
		case UIDeviceOrientation.LandscapeRight:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.TopRight : VisionDetectorImageOrientation.BottomRight;
			break;
		case UIDeviceOrientation.FaceUp:
		case UIDeviceOrientation.FaceDown:
		case UIDeviceOrientation.Unknown:
			metadata.Orientation = VisionDetectorImageOrientation.LeftTop;
			break;
		}
		```

	2. Create a `VisionImage` object using the `CMSampleBuffer` object and the rotation metadata:

		```csharp
		var image = new VisionImage (buffer);
		image.Metadata = metadata;
		```

3. Then, pass the image to the `Detect` method:

	```csharp
	labelDetector.Detect (image, HandleVisionLabelDetectionCallback);

	void HandleVisionLabelDetectionCallback (VisionLabel [] labels, NSError error)
	{
		if (error != null) {
			Console.WriteLine (error.Description);
			return;
		}

		if (labels == null || labels.Length == 0) {
			Console.WriteLine ("No labels were found.");
			return;
		}

		Console.WriteLine ("Labels were found.");
	}

	// or using async / await

	try {
		var labels = await labelDetector.DetectAsync (image);
		Console.WriteLine (labels != null || labels.Length == 0 ? "No labels were found." : "Labels were found");
	} catch (NSErrorException ex) {
		Console.WriteLine (ex.Error.Description);
	}
	```

### 3. Get information about labeled objects

If image labeling succeeds, an array of `VisionLabel` objects will be passed to the completion handler. From each object, you can get information about a feature recognized in the image.

For example:

```csharp
foreach (var label in labels) {
	var labelText = label.Label;
	var entityId = label.EntityId;
	var confidence = label.Confidence;
}
```

### Tips to improve real-time performance

If you want to label images in a real-time application, follow these guidelines to achieve the best framerates:

* Throttle calls to the image labeler. If a new video frame becomes available while the image labeler is running, drop the frame.

## Cloud image labeling

To use the Cloud-based image labeling model, configure and run the the image labeler as described below.

> ![note_icon] _Use of ML Kit to access Cloud ML functionality is subject to the [Google Cloud Platform License Agreement][5] and [Service Specific Terms][6], and billed accordingly. For billing information, see the Firebase [Pricing][1] page._

### 1. Configure the image labeler

By default, the Cloud detector uses the stable version of the model and returns up to 10 results. If you want to change either of these settings, specify them with a `VisionCloudDetectorOptions` object as in the following example:

```csharp
var options = new VisionCloudDetectorOptions {
	ModelType = VisionCloudModelType.Latest,
	MaxResults = 5
};
```

In the next step, pass the VisionCloudDetectorOptions object when you create the Cloud detector object.

### 2. Run the image labeler

To recognize and label entities in an image, pass the image as a UIImage or a CMSampleBufferRef to the `VisionCloudLabelDetector`'s `Detect` method:

1. Get an instance of `VisionCloudLabelDetector`:

```csharp
var vision = VisionApi.Create ();
var labelDetector = vision.GetCloudLabelDetector (options);
```

2. Create a `VisionImage` object using a `UIImage` or a `CMSampleBuffer`.

	To use a `UIImage`:

	1. If necessary, rotate the image so that its `ImageOrientation` property is `Up`.
	2. Create a `VisionImage` object using the correctly-rotated `UIImage`. Do not specify any rotation metadata—the default value, `TopLeft`, must be used.

	```csharp
	var image = new VisionImage (anImage);
	```

	To use a `CMSampleBuffer`:

	1. Create a `VisionImageMetadata` object that specifies the orientation of the image data contained in the `CMSampleBuffer` buffer.
	
		For example, if you are using image data captured from the device's back-facing camera:

		```csharp
		var metadata = new VisionImageMetadata ();

		// Using back-facing camera
		var devicePosition = AVCaptureDevicePosition.Back;

		var deviceOrientation = UIDevice.CurrentDevice.Orientation;

		switch (deviceOrientation) {
		case UIDeviceOrientation.Portrait:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.LeftTop : VisionDetectorImageOrientation.RightTop;
			break;
		case UIDeviceOrientation.LandscapeLeft:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.BottomLeft : VisionDetectorImageOrientation.TopLeft;
			break;
		case UIDeviceOrientation.PortraitUpsideDown:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.RightBottom : VisionDetectorImageOrientation.LeftBottom;
			break;
		case UIDeviceOrientation.LandscapeRight:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.TopRight : VisionDetectorImageOrientation.BottomRight;
			break;
		case UIDeviceOrientation.FaceUp:
		case UIDeviceOrientation.FaceDown:
		case UIDeviceOrientation.Unknown:
			metadata.Orientation = VisionDetectorImageOrientation.LeftTop;
			break;
		}
		```

	2. Create a `VisionImage` object using the `CMSampleBuffer` object and the rotation metadata:

		```csharp
		var image = new VisionImage (buffer);
		image.Metadata = metadata;
		```

3. Then, pass the image to the `Detect` method:

	```csharp
	labelDetector.Detect (image, HandleVisionCloudLabelDetectionCompletion);

	void HandleVisionCloudLabelDetectionCompletion (VisionCloudLabel [] labels, NSError error)
	{
		if (error != null) {
			Console.WriteLine (error.Description);
			return;
		}

		if (labels == null || labels.Length == 0) {
			Console.WriteLine ("No labels were found.");
			return;
		}

		Console.WriteLine ("Labels were found.");
	}

	// or using async / await

	try {
		var labels = await labelDetector.DetectAsync (image);
		Console.WriteLine (labels != null || labels.Length == 0 ? "No labels were found." : "Labels were found");
	} catch (NSErrorException ex) {
		Console.WriteLine (ex.Error.Description);
	}
	```

### 3. Get information about labeled objects

If image labeling succeeds, an array of `VisionCloudLabel` objects will be passed to the completion handler. From each object, you can get information about an entity recognized in the image. This information doesn't contain frame or other location data.

For example:

```csharp
foreach (var label in labels) {
	var labelText = label.Label;
	var entityId = label.EntityId;
	var confidence = label.Confidence;
}
```

---

# Landmark Recognition

With ML Kit's landmark recognition API, you can recognize well-known landmarks in an image.

When you pass an image to this API, you get the landmarks that were recognized in it, along with each landmark's geographic coordinates and the region of the image the landmark was found. You can use this information to automatically generate image metadata, create individualized experiences for users based on the content they share, and more.

## Key capabilities

|  |  |
|-------|-------|
| **Recognizes well-known landmarks** | Get the name and geographic coordinates of natural and constructed landmarks, as well as the region of the image the landmark was found. |
| **Get Google Knowledge Graph entity IDs** | A Knowledge Graph entity ID is a string that uniquely identifies the landmark that was recognized, and is the same ID used by the [Knowledge Graph Search API][8]. You can use this string to identify an entity across languages, and independently of the formatting of the text description. |
| **Low-volume use free** | Free for first 1000 uses of this feature per month: see [Pricing][1]. |

# Recognize Landmarks with ML Kit on iOS

You can use ML Kit to recognize well-known landmarks in an image.

> ![note_icon] _Use of ML Kit to access Cloud ML functionality is subject to the [Google Cloud Platform License Agreement][5] and [Service Specific Terms][6], and billed accordingly. For billing information, see the Firebase [Pricing][1] page._

## Configure the landmark detector

By default, the Cloud detector uses the stable version of the model and returns up to 10 results. If you want to change either of these settings, specify them with a `VisionCloudDetectorOptions` object as in the following example:

```csharp
var options = new VisionCloudDetectorOptions {
	ModelType = VisionCloudModelType.Latest,
	MaxResults = 20
};
```

In the next step, pass the VisionCloudDetectorOptions object when you create the Cloud detector object.

## Run the landmark detector

To recognize and label entities in an image, pass the image as a `UIImage` or a `CMSampleBuffer` to the `VisionCloudLandmarkDetector's`'s `Detect` method:

1. Get an instance of `VisionCloudLandmarkDetector's`:

	```csharp
	var vision = VisionApi.Create ();
	var landmarkDetector = vision.GetCloudLandmarkDetector (options);
	```

2. Create a `VisionImage` object using a `UIImage` or a `CMSampleBuffer`.

	To use a `UIImage`:

	1. If necessary, rotate the image so that its `ImageOrientation` property is `Up`.
	2. Create a `VisionImage` object using the correctly-rotated `UIImage`. Do not specify any rotation metadata—the default value, `TopLeft`, must be used.

	```csharp
	var image = new VisionImage (anImage);
	```

	To use a `CMSampleBuffer`:

	1. Create a `VisionImageMetadata` object that specifies the orientation of the image data contained in the `CMSampleBuffer` buffer.
	
		For example, if you are using image data captured from the device's back-facing camera:

		```csharp
		var metadata = new VisionImageMetadata ();

		// Using back-facing camera
		var devicePosition = AVCaptureDevicePosition.Back;

		var deviceOrientation = UIDevice.CurrentDevice.Orientation;

		switch (deviceOrientation) {
		case UIDeviceOrientation.Portrait:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.LeftTop : VisionDetectorImageOrientation.RightTop;
			break;
		case UIDeviceOrientation.LandscapeLeft:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.BottomLeft : VisionDetectorImageOrientation.TopLeft;
			break;
		case UIDeviceOrientation.PortraitUpsideDown:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.RightBottom : VisionDetectorImageOrientation.LeftBottom;
			break;
		case UIDeviceOrientation.LandscapeRight:
			metadata.Orientation = devicePosition == AVCaptureDevicePosition.Front ? VisionDetectorImageOrientation.TopRight : VisionDetectorImageOrientation.BottomRight;
			break;
		case UIDeviceOrientation.FaceUp:
		case UIDeviceOrientation.FaceDown:
		case UIDeviceOrientation.Unknown:
			metadata.Orientation = VisionDetectorImageOrientation.LeftTop;
			break;
		}
		```

	2. Create a `VisionImage` object using the `CMSampleBuffer` object and the rotation metadata:

		```csharp
		var image = new VisionImage (buffer);
		image.Metadata = metadata;
		```

3. Then, pass the image to the `Detect` method:

	```csharp
	landmarkDetector.Detect (image, HandleVisionCloudLandmarkDetectionCallback);

	void HandleVisionCloudLandmarkDetectionCallback (VisionCloudLandmark [] landmarks, NSError error)
	{
		if (error != null) {
			Console.WriteLine (error.Description);
			return;
		}

		if (landmarks == null || landmarks.Length == 0) {
			Console.WriteLine ("No landmarks were found.");
			return;
		}

		Console.WriteLine ("Landmarks were found.");
	}

	// or using async / await

	try {
		var landmarks = await landmarkDetector.DetectAsync (image);
		Console.WriteLine (landmarks != null || landmarks.Length == 0 ? "No landmarks were found." : "Landmarks were found");
	} catch (NSErrorException ex) {
		Console.WriteLine (ex.Error.Description);
	}
	```

## Get information about the recognized landmarks

If landmark recognition succeeds, an array of `VisionCloudLandmark` objects will be passed to the completion handler. From each object, you can get information about a landmark recognized in the image.

For example:

```csharp
foreach (var landmark in landmarks) {
	var landmarkDesc = landmark.Landmark;
	var boundingPoly = landmark.Frame;
	var entityId =  landmark.EntityId;

	foreach (var location in landmark.Locations) {
		// A landmark can have multiple locations: for example, the location the image
		// was taken, and the location of the landmark depicted.
		var latitude = location.Latitude;
		var longitude = location.Longitude;
	}

	var confidence = landmark.Confidence;
}
```

---

# Protect your ML Kit iOS app's Cloud credentials

If your iOS app uses one of ML Kit's cloud APIs, before you launch your app in production, you should take some additional steps to prevent unauthorized API access.

Read this [document][9] to learn more about this.

[1]: https://firebase.google.com/pricing
[2]: https://cloud.google.com/vision/docs/drag-and-drop
[3]: https://firebase.google.com/docs/ml-kit/recognize-text
[4]: https://firebase.google.com/docs/ml-kit/ios/secure-api-key
[5]: https://cloud.google.com/terms/
[6]: https://cloud.google.com/terms/service-terms
[7]: https://firebase.google.com/docs/ml-kit/face-detection-concepts
[8]: https://developers.google.com/knowledge-graph/
[9]: https://firebase.google.com/docs/ml-kit/ios/secure-api-key
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
[available_icon]: https://cdn3.iconfinder.com/data/icons/flat-actions-icons-9/512/Tick_Mark-24.png
