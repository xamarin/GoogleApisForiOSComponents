using System;
namespace Firebase.RemoteConfig
{
	public partial class RemoteConfigValue
	{
		public string StringValue => NSStringValue.ToString ();
	}

	public partial class RemoteConfig
	{
		public RemoteConfigValue this [string key] => GetConfigValue (key);
	}
}
