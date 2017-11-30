/////////////////////////////////////////////////////////////////////
// Objects used to update a Google Component with its dependencies //
/////////////////////////////////////////////////////////////////////

public abstract class GoogleBase
{
	public virtual string Name { get; }
	public virtual string NuGetId { get; }
	public string CurrentVersion { get; set; }
	public string NewVersion { get; set; }
	public bool Bumped { get; set; }
	public virtual string [] BaseOf { 
		get { return new string[] { }; }
	}
}

public abstract class Firebase
{
	public class AdMob : GoogleBase
	{
		public override string Name { 
			get { return "Firebase.AdMob"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.AdMob"; }
		}
	}

	public class Analytics : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.Analytics"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.Analytics"; }
		}
		public override string [] BaseOf  { 
			get { return new [] { new Firebase.AdMob ().Name, new Firebase.Auth ().Name, new Firebase.CloudMessaging ().Name, 
					new Firebase.CrashReporting ().Name, new Firebase.Database ().Name, new Firebase.DynamicLinks ().Name, 
					new Firebase.Invites ().Name, new Firebase.RemoteConfig ().Name, new Firebase.Storage ().Name, 
					new Google.Core ().Name, new Google.InstanceID ().Name, new Google.PlayGames ().Name,
					new Google.SignIn ().Name, new Google.TagManager ().Name };
			}
		}
	}

	public class Auth : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.Auth"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.Auth"; }
		}
	}

	public class CloudMessaging : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.CloudMessaging"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.CloudMessaging"; }
		}
	}

	public class Core : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.Core"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.Core"; }
		}
		public override string [] BaseOf  { 
			get { return new [] { new Firebase.AdMob ().Name, new Firebase.Analytics ().Name, new Firebase.Auth ().Name, 
					new Firebase.CloudMessaging ().Name, new Firebase.CrashReporting ().Name, new Firebase.Database ().Name, 
					new Firebase.DynamicLinks ().Name, new Firebase.Invites ().Name, new Firebase.RemoteConfig ().Name, 
					new Firebase.Storage ().Name, new Google.Core ().Name, new Google.InstanceID ().Name, 
					new Google.PlayGames ().Name, new Google.SignIn ().Name, new Google.TagManager ().Name };
			}
		}
	}

	public class CrashReporting : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.CrashReporting"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.CrashReporting"; }
		}
	}

	public class Database : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.Database"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.Database"; }
		}
	}

	public class DynamicLinks : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.DynamicLinks"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.DynamicLinks"; }
		}
		public override string [] BaseOf  { 
			get { return new [] { new Firebase.Invites ().Name }; }
		}
	}

	public class InstanceID : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.InstanceID"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.InstanceID"; }
		}
		public override string [] BaseOf  { 
			get { return new [] { new Firebase.AdMob ().Name, new Firebase.Analytics ().Name, new Firebase.Auth ().Name, 
					new Firebase.CloudMessaging ().Name, new Firebase.CrashReporting ().Name, new Firebase.Database ().Name, 
					new Firebase.DynamicLinks ().Name, new Firebase.Invites ().Name, new Firebase.RemoteConfig ().Name, 
					new Firebase.Storage ().Name, new Google.Core ().Name, new Google.InstanceID ().Name, 
					new Google.PlayGames ().Name, new Google.SignIn ().Name, new Google.TagManager ().Name };
			}
		}
	}

	public class Invites : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.Invites"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.Invites"; }
		}
	}

	public class RemoteConfig : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.RemoteConfig"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.RemoteConfig"; }
		}
	}

	public class Storage : GoogleBase
	{
		public override string Name  { 
			get { return "Firebase.Storage"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Firebase.iOS.Storage"; }
		}
	}
}

public abstract class Google
{
	public class Analytics : GoogleBase
	{
		public override string Name  { 
			get { return "Google.Analytics"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.Analytics"; }
		}
		public override string [] BaseOf  { 
			get { return new [] { new Google.TagManager ().Name }; }
		}
	}

	public class AppIndexing : GoogleBase
	{
		public override string Name  { 
			get { return "Google.AppIndexing"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.AppIndexing"; }
		}
	}

	public class Cast : GoogleBase
	{
		public override string Name  { 
			get { return "Google.Cast"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.Cast"; }
		}
	}

	public class Core : GoogleBase
	{
		public override string Name  { 
			get { return "Google.Core"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.Core"; }
		}
		public override string [] BaseOf  { 
			get { return new [] { new Firebase.Invites ().Name, new Google.InstanceID ().Name, new Google.PlayGames ().Name, new Google.SignIn ().Name }; }
		}
	}

	public class InstanceID : GoogleBase
	{
		public override string Name  { 
			get { return "Google.InstanceID"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.InstanceID"; }
		}
	}

	public class Maps : GoogleBase
	{
		public override string Name  { 
			get { return "Google.Maps"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.Maps"; }
		}
	}

	public class MobileAds : GoogleBase
	{
		public override string Name  { 
			get { return "Google.MobileAds"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.MobileAds"; }
		}
		public override string [] BaseOf  { 
			get { return new [] { new Firebase.AdMob ().Name }; }
		}
	}

	public class Places : GoogleBase
	{
		public override string Name  { 
			get { return "Google.Places"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.Places"; }
		}
	}

	public class PlayGames : GoogleBase
	{
		public override string Name  { 
			get { return "Google.PlayGames"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.PlayGames"; }
		}
	}

	public class SignIn : GoogleBase
	{
		public override string Name  { 
			get { return "Google.SignIn"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.SignIn"; }
		}
		public override string [] BaseOf  { 
			get { return new [] { new Firebase.Invites ().Name, new Google.PlayGames ().Name }; }
		}
	}

	public class TagManager : GoogleBase
	{
		public override string Name  { 
			get { return "Google.TagManager"; }
		}
		public override string NuGetId { 
			get { return "Xamarin.Google.iOS.TagManager"; }
		}
	}
}

public abstract class Xamarin
{
	public abstract class Build
	{
		public class Download : GoogleBase
		{
			public override string Name  { 
				get { return "Xamarin.Build.Download"; }
			}
			public override string NuGetId { 
				get { return "Xamarin.Build.Download"; }
			}
			public override string [] BaseOf  { 
					get { return new [] { new Firebase.AdMob ().Name, new Firebase.Analytics ().Name, new Firebase.Auth ().Name, 
							new Firebase.CloudMessaging ().Name, new Firebase.Core ().Name, new Firebase.CrashReporting ().Name,
							new Firebase.Database ().Name, new Firebase.DynamicLinks ().Name, new Firebase.InstanceID ().Name,
							new Firebase.Invites ().Name, new Firebase.RemoteConfig ().Name, new Firebase.Storage ().Name,
							new Google.Analytics ().Name, new Google.AppIndexing ().Name, new Google.Cast ().Name,
							new Google.Core ().Name, new Google.InstanceID ().Name, new Google.Maps ().Name,
							new Google.MobileAds ().Name, new Google.PlayGames ().Name, new Google.SignIn ().Name,
							new Google.TagManager ().Name };
				}
			}
		}
	}
}