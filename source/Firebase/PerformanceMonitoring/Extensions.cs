using System;

using Foundation;

namespace Firebase.PerformanceMonitoring
{
	public partial class HttpMetric
	{
		public HttpMetric (string url, HttpMethod httpMethod) : this (new NSUrl (url), httpMethod)
		{
		}
	}
}
