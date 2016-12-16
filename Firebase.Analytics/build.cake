
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Libs = new ISolutionBuilder [] { 
		new DefaultSolutionBuilder {
			SolutionPath = "source/Firebase.Analytics.sln",
			BuildsOn = BuildPlatforms.Mac,
			Configuration = "Release",
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Firebase.Analytics/bin/Release/Firebase.Analytics.dll",
				},
			}
		}
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/AnalyticsSample/AnalyticsSample.sln", Configuration = "Release|iPhone", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Firebase.iOS.Analytics.nuspec", BuildsOn = BuildPlatforms.Mac },
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac },
	},
};

MyDependencies = new [] {"Firebase.InstanceID"};

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	InvokeOtherGoogleModules (MyDependencies, "clean");
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Firebase.iOS.Analytics*");
});


SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
