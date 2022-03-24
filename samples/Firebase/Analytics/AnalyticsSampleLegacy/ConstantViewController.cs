using System;
using System.Reflection;
using MonoTouch.Dialog;

using UIKit;
using Foundation;

using Firebase.Analytics;

namespace AnalyticsSample
{
	public class ConstantViewController : DialogViewController
	{
		public event EventHandler<ConstantEventArgs> ConstantSelected;
		int sectionIndex;
		LogEventConstantNameType type;

		public ConstantViewController (LogEventConstantNameType type, int sectionIndex) : base (UITableViewStyle.Grouped, null, true)
		{
			this.type = type;
			this.sectionIndex = sectionIndex;
			var title = type == LogEventConstantNameType.Event ? "Event Names Constants" : "Parameter Names Constants";
			var typeToApplyReflection = type == LogEventConstantNameType.Event ? typeof (EventNamesConstants) : typeof (ParameterNamesConstants);
			var constantSection = new Section ("Select a constant");

			var properties = typeToApplyReflection.GetProperties (BindingFlags.Public | BindingFlags.Static);
			foreach (var property in properties) {
				constantSection.Add (new StringElement (property.Name, () => {
					ReturnValueOfSelectedConstant (property);
					ClearEvent (ConstantSelected);
					NavigationController.PopViewController (true);
				}));
			}

			Root = new RootElement (title) { constantSection };
		}

		public void ReturnValueOfSelectedConstant (PropertyInfo property)
		{
			if (ConstantSelected == null)
				return;

			var constantArgs = new ConstantEventArgs { 
				Key = new NSString (property.Name),
				Value = property.GetValue (null) as NSString,
				SectionIndex = sectionIndex,
				Type = type
			};

			ConstantSelected (this, constantArgs);
		}

		void ClearEvent<T> (EventHandler<T> eventToClear) where T : EventArgs
		{
			var eventList = eventToClear.GetInvocationList ();
			foreach (var anEvent in eventList)
				eventToClear -= (EventHandler<T>)anEvent;
		}
	}

	public class ConstantEventArgs : EventArgs
	{
		public NSString Key { get; set; }
		public NSString Value { get; set; }
		public int SectionIndex { get; set; }
		public LogEventConstantNameType Type { get; set; }
	}
}
