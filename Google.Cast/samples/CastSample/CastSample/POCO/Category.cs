using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace CastSample
{
	public class Category
	{
		public string Name { get; set; }

		[JsonProperty ("mp4")]
		public string Mp4BaseUrl { get; set; }

		[JsonProperty ("images")]
		public string ImagesBaseUrl { get; set; }

		[JsonProperty ("tracks")]
		public string TracksBaseUrl { get; set; }

		public List<Video> Videos { get; set; }
	}
}
