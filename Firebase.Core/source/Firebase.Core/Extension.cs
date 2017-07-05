using System;
using ObjCRuntime;

namespace Firebase.Core
{
	public partial class App
	{
		[Obsolete ("Use From method instead.")]
		public static App Get (string name)
		{
			return From (name);
		}
	}
}
