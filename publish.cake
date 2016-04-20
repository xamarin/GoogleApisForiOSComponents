#tool "XamarinComponent"
#addin "nuget:?package=Cake.Json"
#addin "nuget:?package=Cake.Xamarin"
#addin "nuget:?package=Cake.ExtendedNuGet"
#addin "nuget:?package=NuGet.Core&version=2.8.6"

// NOTE: COOKIE_JAR_PATH Environment variable should contain the .xamarin cookie file

var TARGET = Argument ("target", Argument ("t", "build"));

var NUGET_FORCE_PUSH = Argument ("nuget-force-push", "false").Equals ("true");
var NUGET_MAX_ATTEMPTS = 5;
var COMP_MAX_ATTEMPTS = 3;
var COMP_WAIT_BETWEEN = 2500;

var NUGET_API_KEY = Argument ("nuget-api-key", "");
var NUGET_PUBLISH_SOURCE = Argument ("nuget-publish-source", (string)null);
var NUGET_SEARCH_SOURCE = Argument ("nuget-search-source", "https://www.nuget.org/api/v2/");

var XAM_ACCT_EMAIL = Argument ("xamarin-account-email", "");
var XAM_ACCT_PWD = Argument ("xamarin-account-password", "");

var BUILD_INFO = DeserializeJsonFromFile<BuildInfo> ("./CI/output/buildinfo.json");


Helpers.CakeContext = Context;
// If more than this # of artifacts are found, abort publish
Helpers.ArtifactThresholdSafetyCount = 45;
Helpers.BuildGroups = BUILD_INFO.BuiltGroups;
Helpers.BuildNames = Argument ("names", Argument ("name", Argument ("n", "")))
	.Split (new [] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);


Task ("nuget").Does (() =>
{
	DirectoryPath currentDir = "./";

	var packages = Helpers.FilterFilesForBuildNames ("nupkg");

	foreach (var nupkg in packages) {

		FilePath pkg = nupkg.FullPath.Replace (MakeAbsolute (currentDir).FullPath, "./");

		// Check to see if your nuget source already has this package id + version
		if (!NUGET_FORCE_PUSH && IsNuGetPublished (nupkg, NUGET_SEARCH_SOURCE)) {
			Information ("Already Published: {0}", nupkg);
			continue;
		}

		Information ("nuget push {0} -Source {1} -ApiKey {2}",
			pkg.FullPath,
			NUGET_PUBLISH_SOURCE,
			NUGET_API_KEY);

		int attempts = 0;
		bool success = false;

		while (attempts < NUGET_MAX_ATTEMPTS) {
			attempts++;
			try {
				NuGetPush (pkg, new NuGetPushSettings {
					Source = NUGET_PUBLISH_SOURCE,
		    		ApiKey = NUGET_API_KEY
				});
				success = true;
				break;
			} catch { 
				Warning ("Attempt #{0} of {1} Failed", attempts, NUGET_MAX_ATTEMPTS);
			}
		}

		if (!success)
			throw new Exception ("Maximum # of attempts to publish package exceeded");
	}
});

Task ("component").Does (() => 
{
	var xams = Helpers.FilterFilesForBuildNames ("xam");

	var xamarinComponentExe = GetFiles ("./tools/**/xamarin-component.exe").FirstOrDefault ();

	foreach (var xam in xams) {
		Information ("Uploading Component: {0}", xam);

		int attempts = 0;
		bool success = false;

		while (attempts < COMP_MAX_ATTEMPTS) {
			attempts++;
			try {
				UploadComponent (xam, new XamarinComponentUploadSettings {
					Email = XAM_ACCT_EMAIL,
					Password = XAM_ACCT_PWD,
				});
				success = true;
				break;
			} catch {
				Warning ("Failed Component Upload Attempt #{0} of {1}", attempts, COMP_MAX_ATTEMPTS);
			}
		}

		if (!success)
			throw new Exception ("Maximum # of attempts to publish package exceeded");

		Information ("Waiting {0} ms between uploads...", COMP_WAIT_BETWEEN);
		System.Threading.Thread.Sleep (COMP_WAIT_BETWEEN);
	}
});

public class BuildInfo
{
	public List<BuildGroup> BuiltGroups { get; set; }
}

public class BuildGroup 
{
	public BuildGroup () 
	{
		Name = string.Empty;
	}

	public string Name { get; set; }
	public FilePath BuildScript { get; set; }
}

public class Helpers {
	public static ICakeContext CakeContext { get;set; }
	public static string[] BuildNames { get;set; }
	public static List<BuildGroup> BuildGroups { get;set; }
	public static int ArtifactThresholdSafetyCount { get;set; }

	public static List<FilePath> FilterFilesForBuildNames (string fileExtension)
	{
		var results = new List<FilePath> ();

		// If a filter was specified use it
		if (BuildNames != null && BuildNames.Any ()) {
			var groupsToPublish = BuildGroups.Where (bg => BuildNames.Any (n => n.ToLower () == bg.Name.ToLower ())).ToList ();

			foreach (var buildGroup in groupsToPublish) {
				FilePath buildScriptFilePath = buildGroup.BuildScript;

				var pattern = string.Format ("{0}/output/**/*.{1}",
					CakeContext.MakeAbsolute (buildScriptFilePath.GetDirectory ()).FullPath.TrimEnd ('/'),
					fileExtension.TrimStart ('.'));

				results.AddRange (CakeContext.GetFiles (pattern));
			}

		} else {
			// No name filters specified, so add all the nupkgs we can find
			results.AddRange (CakeContext.GetFiles ("./**/output/**/*." + fileExtension.TrimStart ('.')));
		}

		if (results.Count > ArtifactThresholdSafetyCount) {
			CakeContext.Error ("Suspiciously large number ({0}) of artifacts found, not publishing", results.Count);
			return new List<FilePath> ();
		}

		return results;
	}
}


RunTarget (TARGET);
