using System;
using Foundation;
using System.Json;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.IO;

namespace CollectAllTheStars
{
	public class CloudData
	{
		public CloudData ()
		{
			Worlds = new List<World> ();
		}

		public List<World> Worlds { get; set; }
	}

	public class World
	{
		public World ()
		{
			Levels = new List<Level> ();
		}

		public int Number { get; set; }

		public List<Level> Levels { get; set; }
	}

	public class Level
	{
		public Level ()
		{
			Number = 1;
			Stars = 0;
		}

		public int Number { get; set; }

		public int Stars { get; set; }
	}

	public class StarInventory
	{
		public CloudData Cloud { get; private set; }

		public StarInventory ()
		{           
			Cloud = new CloudData ();
		}

		protected StarInventory (CloudData cloudData)
		{
			Cloud = cloudData;
		}

		public static StarInventory FromCloudData (NSData savedData)
		{            
			var serializer = new DataContractJsonSerializer (typeof(CloudData));
			var cloud = (CloudData)serializer.ReadObject (savedData.AsStream ());

			return new StarInventory (cloud);
		}

		public NSData GetCloudData ()
		{
			var serializer = new DataContractJsonSerializer (typeof(CloudData));
			NSData data = null;

			using (var ms = new MemoryStream ()) {
				serializer.WriteObject (ms, Cloud);
				ms.Flush ();

				data = NSData.FromStream (ms);
			}

			return data;
		}

		public int GetStars (int world, int level)
		{
			var cloudWorld = Cloud.Worlds.FirstOrDefault (w => w.Number == world);

			if (cloudWorld == null)
				return 0;

			var cloudLevel = cloudWorld.Levels.FirstOrDefault (l => l.Number == level);

			if (cloudLevel == null)
				return 0;

			return cloudLevel.Stars;
		}

		public void SetStars (int world, int level, int stars)
		{
			var cloudWorld = Cloud.Worlds.FirstOrDefault (w => w.Number == world);

			// If no world exists, add it with the level to the # of stars requested
			if (cloudWorld == null) {
				Cloud.Worlds.Add (new World {
					Levels = new List<Level> {
						new Level {
							Number = level,
							Stars = stars
						}
					}
				});
				return;
			}

			// If we found a world but no level, just add the level with the # stars
			var cloudLevel = cloudWorld.Levels.FirstOrDefault (l => l.Number == level);

			if (cloudLevel == null) {
				cloudWorld.Levels.Add (new Level {
					Number = level,
					Stars = stars                    
				});
				return;
			}

			// If we made it here, world and level both exist, set the stars
			cloudLevel.Stars = stars;
		}
	}
}

