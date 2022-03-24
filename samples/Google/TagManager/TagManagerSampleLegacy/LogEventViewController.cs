using System;
using System.Collections.Generic;

using MonoTouch.Dialog;
using UIKit;
using Foundation;

using Firebase.Analytics;

namespace TagManagerSample
{
	public enum LogEventConstantNameType
	{
		Event,
		Parameter
	}

	public class LogEventViewController : DialogViewController
	{
		Section eventKeySection;
		List<Section> parametersSections;
		Section actionsSection;

		Section customEventKeySection;
		List<Section> customParametersSections;
		Section customActionsSection;


		public LogEventViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			parametersSections = new List<Section> ();
			customParametersSections = new List<Section> ();

			CreateSections ();

			Root = new RootElement ("Log events") {
				eventKeySection,
				parametersSections [0],
				actionsSection,
				customEventKeySection,
				customParametersSections [0],
				customActionsSection
			};
		}

		// Create initial sections to post an event 
		void CreateSections ()
		{
			var deleteButton = new StyledStringElement ("Delete Last Parameter", () => DeleteLastParameter (false)) {
				TextColor = UIColor.Red,
				BackgroundColor = UIColor.White,
				Alignment = UITextAlignment.Center
			};
			var addButton = new StyledStringElement ("Add Parameter", () => AddParameter (false)) {
				TextColor = UIColor.Blue,
				BackgroundColor = UIColor.White,
				Alignment = UITextAlignment.Center
			};
			var logEventButton = new StyledStringElement ("Log Event", () => LogEvent (false)) {
				BackgroundColor = UIColor.White,
				Alignment = UITextAlignment.Center
			};

			eventKeySection = new Section ("Log events with constants") {
				new StringElement ("Event Key", () => OpenConstantViewController (LogEventConstantNameType.Event, 0))
			};
			parametersSections.Add (new Section {
				new StringElement ("Parameter Key", () => OpenConstantViewController (LogEventConstantNameType.Parameter, 0)),
				new EntryElement ("Parameter Value", "Your parameter value", string.Empty) {
					TextAlignment = UITextAlignment.Right
				}
			});
			actionsSection = new Section {
				deleteButton,
				addButton,
				logEventButton
			};

			var customDeleteButton = new StyledStringElement ("Delete Last Custom Parameter", () => DeleteLastParameter (true)) {
				TextColor = UIColor.Red,
				BackgroundColor = UIColor.White,
				Alignment = UITextAlignment.Center
			};
			var customAddButton = new StyledStringElement ("Add Custom Parameter", () => AddParameter (true)) {
				TextColor = UIColor.Blue,
				BackgroundColor = UIColor.White,
				Alignment = UITextAlignment.Center
			};
			var logCustomEventButton = new StyledStringElement ("Log Custom Event", () => LogEvent (true)) {
				BackgroundColor = UIColor.White,
				Alignment = UITextAlignment.Center
			};

			customEventKeySection = new Section ("Log custom events") {
				new EntryElement ("Event Key", "Your custom event name", "") {
					TextAlignment = UITextAlignment.Right
				}
			};
			customParametersSections.Add (new Section {
				new EntryElement ("Parameter Key", "Your custom paramater name", ""),
				new EntryElement ("Parameter Value", "Your parameter value", "") {
					TextAlignment = UITextAlignment.Right
				}
			});
			customActionsSection = new Section {
				customDeleteButton,
				customAddButton,
				logCustomEventButton
			};
		}

		// Push the ConstantViewController that list all the constants that has the selected class
		void OpenConstantViewController (LogEventConstantNameType type, int sectionIndex)
		{
			var constantViewController = new ConstantViewController (type, sectionIndex);
			constantViewController.ConstantSelected += ConstantViewController_ConstantSelected;
			NavigationController.PushViewController (constantViewController, true);
		}

		// Handle when a constant is selected in ConstantViewController and also refresh the section
		void ConstantViewController_ConstantSelected (object sender, ConstantEventArgs e)
		{
			if (e.Type == LogEventConstantNameType.Event) {
				(eventKeySection.Elements [0] as StringElement).Value = e.Value;
				Root.Reload (eventKeySection, UITableViewRowAnimation.None);
			} else {
				(parametersSections [e.SectionIndex] [0] as StringElement).Value = e.Value;
				Root.Reload (parametersSections [e.SectionIndex], UITableViewRowAnimation.None);
			}
		}

		// Remove last parameter section from view and remove it from list
		void DeleteLastParameter (bool isCustomParameter)
		{
			if (isCustomParameter) {
				if (customParametersSections.Count <= 1)
					return;
				
				var index = customParametersSections.Count - 1;
				Root.Remove (customParametersSections [index], UITableViewRowAnimation.Left);
				customParametersSections.RemoveAt (index);
			} else {
				if (parametersSections.Count <= 1)
					return;

				var index = parametersSections.Count - 1;
				Root.Remove (parametersSections [index], UITableViewRowAnimation.Left);
				parametersSections.RemoveAt (index);
			}
		}

		// Add a parameter section in view and add it to list
		void AddParameter (bool isCustomParameter)
		{
			if (isCustomParameter) {
				var customParameterSection = new Section {
					new EntryElement ("Parameter Key", "Your custom paramater name", string.Empty)  {
						TextAlignment = UITextAlignment.Right
					},
					new EntryElement ("Parameter Value", "Your parameter value", string.Empty)  {
						TextAlignment = UITextAlignment.Right
					}
				};
				customParametersSections.Add (customParameterSection);
				Root.Insert (1 + parametersSections.Count + 1 + customParametersSections.Count, customParameterSection);
			} else {
				var newIndex = parametersSections.Count;
				var parameterSection = new Section {
					new StringElement ("Parameter Key", () => OpenConstantViewController (LogEventConstantNameType.Parameter, newIndex)),
					new EntryElement ("Parameter Value", "Your parameter value", string.Empty) {
						TextAlignment = UITextAlignment.Right
					}
				};
				parametersSections.Add (parameterSection);
				Root.Insert (1 + newIndex, parameterSection);
			}
		}

		// Log event to Firebase server
		void LogEvent (bool isCustomEvent)
		{
			string eventKey;
			var parameters = new NSMutableDictionary<NSString, NSObject> ();

			if (isCustomEvent) {
				eventKey = (customEventKeySection.Elements [0] as EntryElement).Value;

				if (string.IsNullOrWhiteSpace (eventKey)) {
					AppDelegate.ShowMessage ("Missing Custom Event Key Name", "Please, write a name for event.", this);
					return;
				}

				foreach (var parameterSection in customParametersSections) {
					var parameterKey = new NSString ((parameterSection.Elements [0] as EntryElement).Value);
					var parameterValue = new NSString ((parameterSection.Elements [1] as EntryElement).Value);

					if (string.IsNullOrWhiteSpace (parameterKey) || string.IsNullOrWhiteSpace (parameterValue)) {
						AppDelegate.ShowMessage ("Missing Custom Parameter Key or Value", "Verify that you have written down all keys and values.", this);
						return;
					}

					parameters [parameterKey] = parameterValue;
				}
			} else {
				eventKey = (eventKeySection.Elements [0] as StringElement).Value;

				if (string.IsNullOrWhiteSpace (eventKey)) {
					AppDelegate.ShowMessage ("Missing Event Key Name", "Please, select a key constant.", this);
					return;
				}

				foreach (var parameterSection in parametersSections) {
					var parameterKey = new NSString ((parameterSection.Elements [0] as StringElement).Value);
					var parameterValue = new NSString ((parameterSection.Elements [1] as EntryElement).Value);

					if (string.IsNullOrWhiteSpace (parameterKey) || string.IsNullOrWhiteSpace (parameterValue)) {
						AppDelegate.ShowMessage ("Missing Parameter Key or Value", "Verify that you have selected all parameters keys and write down their values.", this);
						return;
					}

					parameters [parameterKey] = parameterValue;
				}
			}

			// Method that logs the event
			Analytics.LogEvent (eventKey, NSDictionary<NSString, NSObject>.FromObjectsAndKeys (parameters.Values, parameters.Keys, parameters.Values.Length));
			AppDelegate.ShowMessage ("Event Logged successful", string.Empty, this);
		}
	}
}
