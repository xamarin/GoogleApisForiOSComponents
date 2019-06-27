using System;
using Foundation;
namespace DatabaseSample
{
	public static class ExtensionMethods
	{
		public static NSString ToNSString (this string str)
		{
			return new NSString (str);
		}
	}
}
