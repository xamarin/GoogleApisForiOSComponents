
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Libs = new ISolutionBuilder [] { 
		new DefaultSolutionBuilder {
			SolutionPath = "source/Google.AppIndexing.sln",
			BuildsOn = BuildPlatforms.Mac,
			Configuration = "Release", 
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Google.AppIndexing/bin/Release/Google.AppIndexing.dll",
				},
			}
		}
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/AppIndexingSample/AppIndexingSample.sln", Configuration = "Release|iPhone", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Google.iOS.AppIndexing.nuspec", BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Google.iOS.AppIndexing*");
});


SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);