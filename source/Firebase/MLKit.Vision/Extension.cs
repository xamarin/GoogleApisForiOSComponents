using System;

using Foundation;

namespace Firebase.MLKit.Vision {
	public partial class VisionLatitudeLongitude : NSObject {
		public VisionLatitudeLongitude (double latitude, double longitude) : this (NSNumber.FromDouble (latitude), NSNumber.FromDouble (longitude))
		{
		}

		public VisionLatitudeLongitude (NSNumber latitude, NSNumber longitude) : base (NSObjectFlag.Empty)
		{
			Handle = _InitWithLatitudeAndLongitude (latitude, longitude);
		}
	}
}
