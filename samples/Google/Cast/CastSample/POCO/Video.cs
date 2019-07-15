using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace CastSample
{
	public class Video
	{
		public string Title { get; set; }
		public string Subtitle { get; set; }

		[JsonProperty ("image-480x270")]
		public string ImageUrl { get; set; }

		[JsonProperty ("image-780x1200")]
		public string PosterUrl { get; set; }

		public string Studio { get; set; }
		public long Duration { get; set; }
		public List<Source> Sources { get; set; }
		public List<Track> Tracks { get; set; }
        }
}
