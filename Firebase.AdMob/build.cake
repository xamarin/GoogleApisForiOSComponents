
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/AdMobSample/AdMobSample.sln", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Firebase.iOS.AdMob.nuspec", BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

MyDependencies = new [] { "Firebase.Analytics", "Google.MobileAds" };

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	InvokeOtherGoogleModules (MyDependencies, "clean");
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Google.iOS.Core*");
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
