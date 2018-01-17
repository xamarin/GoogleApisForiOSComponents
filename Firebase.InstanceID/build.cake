#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Libs = new ISolutionBuilder [] { 
		new DefaultSolutionBuilder {
			SolutionPath = "source/Firebase.InstanceID.sln",
			BuildsOn = BuildPlatforms.Mac,
			Configuration = "Release", 
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Firebase.InstanceID/bin/Release/Firebase.InstanceID.dll",
				},
			}
		}
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Firebase.iOS.InstanceID.nuspec", BuildsOn = BuildPlatforms.Mac, RequireLicenseAcceptance = true},
	},
};

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Firebase.iOS.InstanceID*");
});


SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);