
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Libs = new ISolutionBuilder [] { 
		new DefaultSolutionBuilder {
			SolutionPath = "source/Firebase.Invites.sln",
			BuildsOn = BuildPlatforms.Mac,
			Configuration = "Release", 
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Firebase.Invites/bin/Release/Firebase.Invites.dll",
				},
			}
		}
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/InvitesSample/InvitesSample.sln", Configuration = "Release", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Firebase.iOS.Invites.nuspec", BuildsOn = BuildPlatforms.Mac, RequireLicenseAcceptance = true},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

// "Firebase.Analytics" implied from Google.SignIn
// "Firebase.InstanceID" implied from Firebase.Analytics
MyDependencies = new [] {"Firebase.DynamicLinks", "Google.SignIn"}; 

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	InvokeOtherGoogleModules (MyDependencies, "clean");
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Firebase.iOS.Invites*");
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
