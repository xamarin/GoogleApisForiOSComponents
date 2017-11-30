
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Libs = new ISolutionBuilder [] { 
		new DefaultSolutionBuilder {
			SolutionPath = "source/Firebase.CloudFirestore.sln",
			Configuration = "Release", 
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Firebase.CloudFirestore/bin/Release/Firebase.CloudFirestore.dll",
				},
			}
		}
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/CloudFirestoreSample/CloudFirestoreSample.sln", Configuration = "Release", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Firebase.iOS.CloudFirestore.nuspec", BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

// "Firebase.Analytics" implied from Firebase.Auth
MyDependencies = new [] {"Firebase.Auth"};

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	InvokeOtherGoogleModules (MyDependencies, "clean");
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Firebase.iOS.CloudFirestore*");
});


SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
