using System;
using System.Drawing;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

using Google.Cast;

namespace GoogleCastSample
{
    public class CastDeviceManagerDelegate : NSObject, IDeviceManagerDelegate
    {
        CastViewController viewCtrl;

        public CastDeviceManagerDelegate (CastViewController ctrl) 
        {
            viewCtrl = ctrl;
        }

        [Export ("deviceManagerDidConnect:")]
        public void DidConnect (DeviceManager deviceManager)
        {
            Console.WriteLine ("Connected!!");
            viewCtrl.UpdateButtonStates ();
            viewCtrl.DeviceManager.LaunchApplication (AppDelegate.ReceiverApplicationId);
        }

        [Export ("deviceManager:didConnectToCastApplication:sessionID:launchedApplication:")]
        public void DidConnectToCastApplication (DeviceManager deviceManager, ApplicationMetadata applicationMetadata, string sessionId, bool launchedApplication)
        {
            Console.WriteLine ("Application has launched");
            viewCtrl.MediaControlChannel = new MediaControlChannel ();
            viewCtrl.MediaControlChannel.Delegate = new MediaControlChannelDelegate ();
            viewCtrl.DeviceManager.AddChannel (viewCtrl.MediaControlChannel);
            viewCtrl.MediaControlChannel.RequestStatus ();

            viewCtrl.SessionId = sessionId;
        }

        [Export ("deviceManager:didFailToConnectToApplicationWithError:")]
        public void DidFailToConnectToApplication (DeviceManager deviceManager, NSError error)
        {
            ShowError (error);
            viewCtrl.DeviceDisconnected ();
            viewCtrl.UpdateButtonStates ();
        }

        [Export ("deviceManager:didFailToConnectWithError:")]
        public void DidFailToConnect (DeviceManager deviceManager, NSError error)
        {
            ShowError (error);
            viewCtrl.DeviceDisconnected ();
            viewCtrl.UpdateButtonStates ();
        }

        [Export ("deviceManager:didDisconnectWithError:")]
        public void DidDisconnect (DeviceManager deviceManager, NSError error)
        {
            Console.WriteLine ("Received notification that device disconnected");
            if (error != null)
                ShowError (error);

            viewCtrl.DeviceDisconnected ();
            viewCtrl.UpdateButtonStates ();
        }

        [Export ("deviceManager:didReceiveStatusForApplication:")]
        public void DidReceiveStatus (DeviceManager deviceManager, ApplicationMetadata applicationMetadata)
        {
            viewCtrl.AppMetadata = applicationMetadata;
        }

        void ShowError (NSError error)
        {
            InvokeOnMainThread (() => new UIAlertView ("Error:", error.Description, null, "Ok", null).Show());
        }
    }
}
