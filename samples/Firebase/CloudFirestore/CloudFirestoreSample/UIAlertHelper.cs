using System;
using UIKit;
using System.Collections.Generic;

namespace CloudFirestoreSample
{
	public class UIAlertHelper
	{
		public delegate void UIAlertControllerTextFieldResultHandler (bool alertCanceled, string [] textfieldInputs);

		/// <summary>
		/// Shows a simple alert with a single button.
		/// </summary>
		/// <param name="title">The title of the alert.</param>
		/// <param name="message">Message to show to user.</param>
		/// <param name="fromViewController">From which view the alert will be presented.</param>
		/// <param name="okAction">Action to be done when user press the Ok button.</param>
		public static void ShowMessage (string title, string message, UIViewController fromViewController, string okTitle, Action okAction = null)
		{
			var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
			alert.AddAction (UIAlertAction.Create (okTitle, UIAlertActionStyle.Default, HandleAction));

			fromViewController.PresentViewController (alert, true, null);

			void HandleAction (UIAlertAction obj) => okAction?.Invoke ();
		}

		/// <summary>
		/// Shows an alert with custom buttons.
		/// </summary>
		/// <param name="title">The title of the alert.</param>
		/// <param name="message">Message to show to user.</param>
		/// <param name="fromViewController">From which view the alert will be presented.</param>
		/// <param name="cancelTitle">Title for Cancel button. Pass null if you don't want a Cancel button.</param>
		/// <param name="cancelAction">Action to be done when user press the Cancel button. Pass null if action no needed</param>
		/// <param name="destructiveTitle">Title for Destructive button. Pass null if you don't want a Destructive button.</param>
		/// <param name="destructiveAction">Action to be done when user press the Destructive button. Pass null if action no needed.</param>
		/// <param name="otherTitles">Title for custom buttons.</param>
		/// <param name="otherActions">Actions for custom buttons.</param>
		public static void ShowMessage (string title, string message, UIViewController fromViewController,
						string cancelTitle, Action cancelAction,
						string destructiveTitle, Action destructiveAction,
						string [] otherTitles, Action [] otherActions)
		{
			if (string.IsNullOrWhiteSpace (cancelTitle) &&
			    string.IsNullOrWhiteSpace (destructiveTitle) &&
			    otherTitles == null) {
				ShowMessage (title, message, fromViewController, "Ok");
				return;
			}

			if (otherTitles != null &&
			    otherActions != null &&
			    otherTitles.Length != otherActions.Length)
				throw new ArgumentException ("otherTitles and otherActions arrays have different sizes");

			var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);

			if (!string.IsNullOrWhiteSpace (destructiveTitle))
				alert.AddAction (UIAlertAction.Create (destructiveTitle, UIAlertActionStyle.Destructive, (obj) => {
					destructiveAction?.Invoke ();
				}));

			if (!string.IsNullOrWhiteSpace (cancelTitle))
				alert.AddAction (UIAlertAction.Create (cancelTitle, UIAlertActionStyle.Cancel, (obj) => {
					cancelAction?.Invoke ();
				}));

			if (otherTitles != null && otherActions != null) {
				for (int i = 0; i < otherTitles.Length; i++) {
					var otherTitle = otherTitles [i];
					var otherAction = otherActions [i];
					alert.AddAction (UIAlertAction.Create (otherTitle, UIAlertActionStyle.Default, (obj) => {
						otherAction?.Invoke ();
					}));
				}
			}

			fromViewController.PresentViewController (alert, true, null);
		}

		/// <summary>
		/// Shows an alert with Textfields.
		/// For iOS 7 or before, an alert with a Textfield will be shown.
		/// </summary>
		/// <param name="title">The title of the alert.</param>
		/// <param name="message">Message to show to user.</param>
		/// <param name="fromViewController">From which view the alert will be presented.</param>
		/// <param name="okTitle">Title for Ok button.</param>
		/// <param name="placeholders">
		/// Placeholders to be shown in textfields. A Textfield will be added for each placeholder
		/// If null or an empty array is passed, a simple alert will be shown.
		/// </param>
		/// <param name="result">
		/// Action to be done when user press one button of alert. 
		/// Will return all inputs from Textfields in order that were shown or null if Cancel button was tapped.
		/// </param>
		public static void ShowMessage (string title, string message, UIViewController fromViewController, 
		                                string okTitle, string [] placeholders, UIAlertControllerTextFieldResultHandler result)
		{
			if (string.IsNullOrWhiteSpace (okTitle))
				okTitle = "Ok";

			if (placeholders == null || placeholders.Length == 0) {
				ShowMessage (title, message, fromViewController, okTitle);
				return;
			}

			var alert = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);

			foreach (var placeholder in placeholders) {
				alert.AddTextField ((textField) => {
					textField.Placeholder = placeholder;
					textField.TextAlignment = UITextAlignment.Center;
				});
			}

			alert.AddAction (UIAlertAction.Create (okTitle, UIAlertActionStyle.Default, (obj) => {
				var textfields = alert.TextFields;
				var inputs = new string [textfields.Length];

				for (int i = 0; i < textfields.Length; i++)
					inputs [i] = textfields [i].Text;

				result?.Invoke (false, inputs);
			}));

			alert.AddAction (UIAlertAction.Create ("Cancel", UIAlertActionStyle.Cancel, (obj) => {
				result?.Invoke (true, null);
			}));

			fromViewController.PresentViewController (alert, true, null);
		}
	}
}
