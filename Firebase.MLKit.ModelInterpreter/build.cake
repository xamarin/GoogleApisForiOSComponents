
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Libs = new ISolutionBuilder [] { 
		new DefaultSolutionBuilder {
			SolutionPath = "source/Firebase.MLKit.ModelInterpreter.sln",
			BuildsOn = BuildPlatforms.Mac,
			Configuration = "Release",
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Firebase.MLKit.ModelInterpreter/bin/Release/Firebase.MLKit.ModelInterpreter.dll",
				},
			}
		}
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/ModelInterpreterSample/ModelInterpreterSample.sln", Configuration = "Release", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Firebase.iOS.MLKit.ModelInterpreter.nuspec", BuildsOn = BuildPlatforms.Mac, RequireLicenseAcceptance = true },
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac },
	},
};

MyDependencies = new [] {"Firebase.MLKit.Common", "Firebase.InstanceID"};

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	InvokeOtherGoogleModules (MyDependencies, "clean");
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Firebase.iOS.MLKit.ModelInterpreter*");
});


SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
