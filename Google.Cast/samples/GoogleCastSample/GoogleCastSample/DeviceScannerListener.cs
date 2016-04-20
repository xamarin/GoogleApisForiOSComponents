using System;
using System.Drawing;

using Foundation;
using UIKit;

using Google.Cast;

namespace GoogleCastSample
{
    public class DeviceScannerListener : NSObject, IDeviceScannerListener
    {
        CastViewController viewCtrl;
        public DeviceScannerListener (CastViewController ctrl)
        {
            viewCtrl = ctrl;
        }

        [Export ("deviceDidComeOnline:")]
        public void DeviceDidComeOnline (Device device)
        {
            Console.WriteLine ("Device found: {0}", device.FriendlyName);
            viewCtrl.UpdateButtonStates ();
        }

        [Export ("deviceDidGoOffline:")]
        public void DeviceDidGoOffline (Device device)
        {
            viewCtrl.UpdateButtonStates ();
        }
    }
}
