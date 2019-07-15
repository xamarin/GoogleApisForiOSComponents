using System;
namespace MLKitSample {
	public static class AvailableModels {
		public static Model [] OnDevice => new [] {
			Model.TextRecognition,
			Model.FaceDetection,
			Model.BarcodeScanning,
			Model.ImageLabeling
		};

		public static Model [] OnCloud => new [] {
			Model.TextRecognition,
			Model.ImageLabeling,
			Model.LandmarkRecognition
		};
	}
}
