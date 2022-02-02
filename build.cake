#addin nuget:?package=Cake.XCode&version=4.2.0
#addin nuget:?package=Cake.Xamarin.Build&version=4.1.1
#addin nuget:?package=Cake.FileHelpers&version=3.2.0

#load "poco.cake"
#load "components.cake"
#load "common.cake"

var TARGET = Argument ("t", Argument ("target", "build"));
var NAMES = Argument ("names", "");

var IS_LOCAL_BUILD = true;
var BACKSLASH = string.Empty;

var SOLUTION_PATH = "./Xamarin.Google.sln";
var EXTERNALS_PATH = new DirectoryPath ("./externals");

// Artifacts that need to be built from pods or be copied from pods
var ARTIFACTS_TO_BUILD = new List<Artifact> ();

var SOURCES_TARGETS = new List<string> ();
var SAMPLES_TARGETS = new List<string> ();

FilePath GetCakeToolPath ()
{
	var possibleExe = GetFiles ("./**/tools/Cake/Cake.exe").FirstOrDefault ();
	if (possibleExe != null)
		return possibleExe;
		
	var p = System.Diagnostics.Process.GetCurrentProcess ();	
	return new FilePath (p.Modules[0].FileName);
}

void BuildCake (string target)
{
	var cakeSettings = new CakeSettings { 
		ToolPath = GetCakeToolPath (),
		Arguments = new Dictionary<string, string> { { "target", target }, { "names", NAMES } },
		Verbosity = Verbosity.Diagnostic
	};

	// Run the script from the subfolder
	CakeExecuteScript ("./build.cake", cakeSettings);
}

// From Cake.Xamarin.Build, dumps out versions of things
// LogSystemInfo ();

Setup (context =>
{
	IS_LOCAL_BUILD = string.IsNullOrWhiteSpace (EnvironmentVariable ("AGENT_ID"));
	Information ($"Is a local build? {IS_LOCAL_BUILD}");
	BACKSLASH = IS_LOCAL_BUILD ? @"\" : @"\";
});

Task("build")
	.Does(() =>
{
	BuildCake ("nuget");
	BuildCake ("samples");
});

// Prepares the artifacts to be built.
// From CI will always build everything but, locally you can customize what
// you build, just to save some time when testing locally.
Task("prepare-artifacts")
	.IsDependeeOf("externals")
	.Does(() =>
{
	SetArtifactsDependencies ();
	SetArtifactsPodSpecs ();
	SetArtifactsExtraPodfileLines ();
	SetArtifactsSamples ();

	var orderedArtifactsForBuild = new List<Artifact> ();
	var orderedArtifactsForSamples = new List<Artifact> ();

	if (string.IsNullOrWhiteSpace (NAMES)) {
		var artifacts = ARTIFACTS.Values.Where (a => !a.Ignore);
		orderedArtifactsForBuild.AddRange (artifacts);
		orderedArtifactsForSamples.AddRange (artifacts);
	} else {
		var names = NAMES.Split (',');
		foreach (var name in names) {
			if (!(ARTIFACTS.ContainsKey (name) && ARTIFACTS [name] is Artifact artifact))
				throw new Exception($"The {name} component does not exist.");
			
			if (artifact.Ignore)
				continue;

			orderedArtifactsForBuild.Add (artifact);
			AddArtifactDependencies (orderedArtifactsForBuild, artifact.Dependencies);
			orderedArtifactsForSamples.Add (artifact);
		}

		orderedArtifactsForBuild = orderedArtifactsForBuild.Distinct ().ToList ();
		orderedArtifactsForSamples = orderedArtifactsForSamples.Distinct ().ToList ();
	}

	orderedArtifactsForBuild.Sort ((f, s) => s.BuildOrder.CompareTo (f.BuildOrder));
	orderedArtifactsForSamples.Sort ((f, s) => s.BuildOrder.CompareTo (f.BuildOrder));
	ARTIFACTS_TO_BUILD.AddRange (orderedArtifactsForBuild);

	Information ("Build order:");

	foreach (var artifact in ARTIFACTS_TO_BUILD) {
		SOURCES_TARGETS.Add($@"{artifact.ComponentGroup}{BACKSLASH}{artifact.CsprojName.Replace ('.', '_')}");
		Information (artifact.Id);
	}

	foreach (var artifact in orderedArtifactsForSamples)
		if (artifact.Samples != null)
			foreach (var sample in artifact.Samples)
				SAMPLES_TARGETS.Add($@"{artifact.ComponentGroup}{BACKSLASH}{sample.Replace ('.', '_')}");
});

Task ("externals")
	.WithCriteria (!DirectoryExists (EXTERNALS_PATH) || !string.IsNullOrWhiteSpace (NAMES))
	.Does (() => 
{
	EnsureDirectoryExists (EXTERNALS_PATH);

	Information ("////////////////////////////////////////");
	Information ("// Pods Repo Update Started           //");
	Information ("////////////////////////////////////////");
	
	Information ("\nUpdating Cocoapods repo...");
	CocoaPodRepoUpdate ();

	Information ("////////////////////////////////////////");
	Information ("// Pods Repo Update Ended             //");
	Information ("////////////////////////////////////////");

	if (string.IsNullOrWhiteSpace (NAMES)) {
		foreach (var artifact in ARTIFACTS_TO_BUILD) {
			UpdateVersionInCsproj (artifact);
			CreateAndInstallPodfile (artifact);
			BuildSdkOnPodfile (artifact);
		}
	} else {
		foreach (var artifact in ARTIFACTS_TO_BUILD) {
			UpdateVersionInCsproj (artifact);

			foreach (var podSpec in artifact.PodSpecs) {
				if (podSpec.FrameworkSource != FrameworkSource.Pods)
					continue;
				
				if (DirectoryExists (EXTERNALS_PATH.Combine ($"{podSpec.FrameworkName}.framework")))
					break;

				CreateAndInstallPodfile (artifact);
				BuildSdkOnPodfile (artifact);
			}
		}
	}

	// Call here custom methods created at custom_externals_download.cake file
	// to download frameworks and/or bundles for the artifact
	// if (ARTIFACTS_TO_BUILD.Contains (FIREBASE_CORE_ARTIFACT))
	// 	FirebaseCoreDownload ();
});

Task ("libs")
	.IsDependentOn("externals")
	.Does(() =>
{
	CleanVisualStudioSolution ();
	RestoreVisualStudioSolution ();

	foreach (var target in SOURCES_TARGETS)
		MSBuild(SOLUTION_PATH, c => {
			c.Configuration = "Release";
			c.Restore = true;
			c.MaxCpuCount = 0;
			c.Targets.Clear();
			c.Targets.Add($@"source{BACKSLASH}{target}");
		});
});

Task ("samples")
	.IsDependentOn("libs")
	.Does(() =>
{
	foreach (var target in SAMPLES_TARGETS)
		MSBuild(SOLUTION_PATH, c => {
			c.Configuration = "Release";
			c.Restore = true;
			c.MaxCpuCount = 0;
			c.Targets.Clear();
			c.Targets.Add($@"samples-using-source{BACKSLASH}{target}");
		});
});

Task ("nuget")
	.IsDependentOn("libs")
	.Does(() =>
{
	EnsureDirectoryExists("./output/");

	foreach (var target in SOURCES_TARGETS)
		MSBuild(SOLUTION_PATH, c => {
			c.Configuration = "Release";
			c.MaxCpuCount = 0;
			c.Targets.Clear();
			c.Targets.Add($@"source{BACKSLASH}{target}:Pack");
			c.Properties.Add("PackageOutputPath", new [] { "../../../output/" });
		});
});

Task ("clean")
	.Does (() => 
{
	CleanVisualStudioSolution ();

	var deleteDirectorySettings = new DeleteDirectorySettings {
		Recursive = true,
		Force = true
	};

	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", deleteDirectorySettings);

	if (DirectoryExists ("./output/"))
		DeleteDirectory ("./output", deleteDirectorySettings);
});

Teardown (context =>
{
	var artifacts = GetFiles ("./output/**/*");

	if (artifacts?.Count () <= 0)
		return;

	Information ($"Found Artifacts ({artifacts.Count ()})");
	foreach (var a in artifacts)
		Information ("{0}", a);
});

RunTarget (TARGET);
