
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Libs = new ISolutionBuilder [] { 
		new DefaultSolutionBuilder {
			SolutionPath = "source/Google.AppInvite.sln",
			BuildsOn = BuildPlatforms.Mac,
			Configuration = "Release", 
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Google.AppInvite/bin/Release/Google.AppInvite.dll",
				},
			}
		}
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/AppInviteSample/AppInviteSample.sln", Configuration = "Release|iPhone", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Google.iOS.AppInvite.nuspec", BuildsOn = BuildPlatforms.Mac, RequireLicenseAcceptance = true},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

MyDependencies = new [] {"Google.SignIn"}; // "Google.Core" implied from Google.SignIn

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	InvokeOtherGoogleModules (MyDependencies, "clean");
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Google.iOS.AppInvite*");
});


SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);