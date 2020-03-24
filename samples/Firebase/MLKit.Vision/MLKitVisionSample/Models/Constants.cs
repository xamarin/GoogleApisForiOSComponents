using System;

using Foundation;

namespace MLKitVisionSample {
	public static class Constants {
		public static NSString SelectedApiResource { get; } = new NSString ("ApiResource");
		public static NSString SelectedModel { get; } = new NSString ("SelectedModel");
		public static NSString PrepareForUnwind { get; } = new NSString ("PrepareForUnwind");
		public static NSString CellKey { get; } = new NSString ("AvailableResourceTableViewCell");
	}
}
