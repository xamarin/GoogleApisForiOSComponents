﻿using System;

namespace Google.Core
{
	public class Loader
	{
		static Loader ()
		{
			Firebase.InstanceID.Loader.ForceLoad ();
			Firebase.Core.Loader.ForceLoad ();
			Firebase.Analytics.Loader.ForceLoad ();
		}

		public static void ForceLoad () {}
	}
}

namespace ApiDefinition
{
	partial class Messaging
	{
		static Messaging ()
		{
			Google.Core.Loader.ForceLoad ();
		}
	}
}
