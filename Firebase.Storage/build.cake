
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Libs = new ISolutionBuilder [] { 
		new DefaultSolutionBuilder {
			SolutionPath = "source/Firebase.Storage.sln",
			BuildsOn = BuildPlatforms.Mac,
			Configuration = "Release", 
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Firebase.Storage/bin/Release/Firebase.Storage.dll",
				},
			}
		}
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/StorageSample/StorageSample.sln", Configuration = "Release", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Firebase.iOS.Storage.nuspec", BuildsOn = BuildPlatforms.Mac, RequireLicenseAcceptance = true},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

// "Firebase.InstanceID" implied from Firebase.Analytics
MyDependencies = new [] {"Firebase.Analytics", "Firebase.Auth", "Firebase.Database"};

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	InvokeOtherGoogleModules (MyDependencies, "clean");
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Firebase.iOS.Storage*");
});


SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
