
#load "../common.cake"

var SDK_VERSION = "4_0_1";
var SDK_URL = string.Format ("https://developers.google.com/identity/sign-in/ios/sdk/google_signin_sdk_{0}.zip", SDK_VERSION);
var SDK_FILE = "GoogleSignInSDK.zip";
var SDK_PATH = "./externals/GoogleSignInSDK";

var TARGET = Argument ("t", Argument ("target", "Default"));

buildSpec = new BuildSpec () {

	Libs = new ISolutionBuilder [] { 
		new DefaultSolutionBuilder {
			SolutionPath = "source/Google.SignIn.sln",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Google.SignIn/bin/Release/Google.SignIn.dll",
				},
			}
		}
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/SignInExample/SignInExample.sln", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Google.iOS.SignIn.nuspec", BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

MyDependencies = new [] {"Google.Core"};

Task ("externals")
	.WithCriteria (!FileExists ("./externals/GoogleSignIn"))
	.Does (() => 
{
	if (!DirectoryExists ("./externals/"))
		CreateDirectory ("./externals");

	DownloadFile (SDK_URL, "./externals/" + SDK_FILE, new DownloadFileSettings
	{
		UserAgent = "curl/7.43.0"
	});

	Unzip ("./externals/" + SDK_FILE, SDK_PATH);

	CopyFile (SDK_PATH + "/GoogleAppUtilities.framework/GoogleAppUtilities", "./externals/GoogleAppUtilities");
	CopyFile (SDK_PATH + "/GoogleSignIn.framework/GoogleSignIn", "./externals/GoogleSignIn");
	CopyFile (SDK_PATH + "/GoogleSignInDependencies.framework/GoogleSignInDependencies", "./externals/GoogleSignInDependencies");

	CopyDirectory (SDK_PATH + "/GoogleSignIn.bundle", "./externals/GoogleSignIn.bundle");

	DeleteDirectory (SDK_PATH, true);
});

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	InvokeOtherGoogleModules (MyDependencies, "clean");
	RunMake ("./externals/", "clean");
	DeleteFiles ("../tmp-nugets/Xamarin.Google.iOS.SignIn*");
});


SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);