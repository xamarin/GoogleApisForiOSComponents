using MonoTouch.Dialog;
using UIKit;
using Foundation;
using Firebase.CloudFunctions;
using System;

namespace CloudFunctionsSample {
	public class MenuViewController : DialogViewController {
		EntryElement functionEntry;

		EntryElement dataEntry;

		public MenuViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			functionEntry = new EntryElement ("Function", "functionName", "helloWorld");
			dataEntry = new EntryElement ("Data", "sample data string", "");

			Root = new RootElement ("Firebase CloudFunctions Sample") {
				new Section ("Select your function") {
					functionEntry,
					dataEntry,
					new StringElement ("Call function", () => {
						NSObject data;
						if (string.IsNullOrEmpty(dataEntry.Value) == false)
						{
							data = FromObject(dataEntry.Value);
						}
						else
						{
							data = null;
						}
						CallFunction(functionEntry.Value, data);
			})
		    {
						Alignment = UITextAlignment.Center
					}
				}
			};
		}

		void OpenViewController (UIViewController viewController)
		{
			NavigationController.PushViewController (viewController, true);
		}

		private void CallFunction (string functionName, NSObject data)
		{
			var instance = CloudFunctions.DefaultInstance;

			var function = instance.HttpsCallable (functionName);

			if (data == null) {
				function.Call (OnFunctionCompletion);
			} else {
				function.Call (data, OnFunctionCompletion);
			}
		}

		private void OnFunctionCompletion (HttpsCallableResult result, NSError error)
		{
			Console.WriteLine ("Got result: " + result);
			if (error != null) {
				Console.WriteLine ("Domain: " + error.Domain + " Error: " + error.DebugDescription);
				if (error.Domain == CloudFunctions.CloudFunctionsErrorDomain) {
					CloudFunctionsErrorCode code = (CloudFunctionsErrorCode)(long)error.Code;
					Console.WriteLine ("Error Code: " + code);
				}
				AppDelegate.ShowMessage ("Error", error.DebugDescription, NavigationController);
			} else if (result != null) {
				Console.WriteLine ("Data: " + result.Data);
				AppDelegate.ShowMessage ("Data", result.Data.ToString (), NavigationController);
			}
		}
	}
}
