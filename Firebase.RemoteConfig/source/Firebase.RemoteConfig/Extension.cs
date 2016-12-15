using System;
namespace Firebase.RemoteConfig
{
	public partial class RemoteConfigValue
	{
		public string StringValue {
			get {
				return NSStringValue.ToString ();
			}
		}
	}

	public partial class RemoteConfig
	{
		public RemoteConfigValue this [string key] {
			get {
				return GetConfigValue (key);
			}
		}
	}
}
