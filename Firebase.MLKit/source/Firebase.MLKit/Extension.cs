using System;

using Foundation;

namespace Firebase.MLKit.Vision {
	public partial class VisionLatitudeLongitude : NSObject {
		public VisionLatitudeLongitude (double latitude, double longitude) : base (NSObjectFlag.Empty)
		{
			var nsLatitude = NSNumber.FromDouble (latitude);
			var nsLongitude = NSNumber.FromDouble (longitude);

			Handle = _InitWithLatitudeAndLongitude (nsLatitude, nsLongitude);
		}

		public VisionLatitudeLongitude (NSNumber latitude, NSNumber longitude) : base (NSObjectFlag.Empty)
		{
			Handle = _InitWithLatitudeAndLongitude (latitude, longitude);
		}
	}
}
