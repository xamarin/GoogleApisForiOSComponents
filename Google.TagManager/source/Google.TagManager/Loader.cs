﻿using System;

namespace Google.TagManager
{
	public class Loader
	{
		static Loader ()
		{
			Google.Analytics.Loader.ForceLoad ();
			Firebase.Analytics.Loader.ForceLoad ();
			Firebase.InstanceID.Loader.ForceLoad ();
		}

		public static void ForceLoad ()
		{
		}
	}
}

namespace ApiDefinition
{
	partial class Messaging
	{
		static Messaging ()
		{
			Google.TagManager.Loader.ForceLoad ();
		}
	}
}

