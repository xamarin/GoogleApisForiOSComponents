
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Libs = new ISolutionBuilder [] { 
		new DefaultSolutionBuilder {
			SolutionPath = "source/Google.Places.sln",
			Configuration = "Release", 
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Google.Places/bin/Release/Google.Places.dll",
				},
			}
		}
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/GooglePlacesSample/GooglePlacesSample.sln", Configuration = "Release", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Google.iOS.Places.nuspec", BuildsOn = BuildPlatforms.Mac },
	},

	Components = new [] {
		new Component { ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac },
	},
};

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Google.iOS.Places*");
});


SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);