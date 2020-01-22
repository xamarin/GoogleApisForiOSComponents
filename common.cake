#load "poco.cake"

// Podfile basic structure
var PODFILE_BEGIN = new [] {
	"platform :ios, '{0}'",
	"install! 'cocoapods', :integrate_targets => false",
	"use_frameworks!",
};
var PODFILE_TARGET = new [] {
	"target 'XamarinGoogle' do",
};
var PODFILE_END = new [] {
	"end",
};

void AddArtifactDependencies (List<Artifact> list, Artifact [] dependencies)
{
	if (dependencies == null)
		return;
	
	list.AddRange (dependencies);

	foreach (var dependency in dependencies)
		AddArtifactDependencies (list, dependency.Dependencies);
}

void UpdateVersionInCsproj (Artifact artifact) 
{
	var componentGroup = artifact.ComponentGroup.ToString ();
	var csprojPath = $"./source/{componentGroup}/{artifact.CsprojName}/{artifact.CsprojName}.csproj";
	XmlPoke(csprojPath, "/Project/PropertyGroup/FileVersion", artifact.NugetVersion);
	XmlPoke(csprojPath, "/Project/PropertyGroup/PackageVersion", artifact.NugetVersion);
}

void CreateAndInstallPodfile (Artifact artifact)
{
	if (artifact.PodSpecs?.Length == 0)
		return;
	
	var podfile = new List<string> ();
	var podfileBegin = new List<string> (PODFILE_BEGIN);
	
	var minimunSupportedVersion = GetMinimunSupportedVersion (artifact);
	podfileBegin [0] = string.Format (podfileBegin [0], minimunSupportedVersion);
	podfile.AddRange (podfileBegin);

	if (artifact.ExtraPodfileLines != null)
		podfile.AddRange (artifact.ExtraPodfileLines);

	podfile.AddRange (PODFILE_TARGET);
	podfile.AddRange (GetPodfileLines (artifact));

	if (artifact.Dependencies != null)
		foreach (var dependency in artifact.Dependencies)
			podfile.AddRange (GetPodfileLines (dependency));

	if (podfile.Count == PODFILE_BEGIN.Length + PODFILE_TARGET.Length + (artifact.ExtraPodfileLines?.Length ?? 0))
		return;

	podfile.AddRange (PODFILE_END);

	var podfilePath = $"./externals/{artifact.Id}";
	EnsureDirectoryExists (podfilePath);

	FileWriteLines ($"{podfilePath}/Podfile", podfile.ToArray ());
	CocoaPodInstall (podfilePath);
}

string GetMinimunSupportedVersion (Artifact artifact)
{
	var version = artifact.MinimunSupportedVersion;

	if (artifact.Dependencies == null)
		return version;

	foreach (var dependency in artifact.Dependencies)
		if (string.Compare (version, dependency.MinimunSupportedVersion) == -1)
			version = dependency.MinimunSupportedVersion;

	return version;
}

List<string> GetPodfileLines (Artifact artifact)
{
	var podfileLines = new List<string> ();

	foreach (var podSpec in artifact.PodSpecs) {
		if (podSpec.FrameworkSource != FrameworkSource.Pods)
			continue;

		podfileLines.AddRange (podSpec.BuildPodLines ());
	}

	return podfileLines;
}

void BuildSdkOnPodfile (Artifact artifact)
{
	if (artifact.PodSpecs?.Length == 0)
		return;

	var baseArch = Platform.iOSArmV7;
	var platforms = new [] { baseArch, Platform.iOSArm64, Platform.iOSSimulator64, Platform.iOSSimulator };
	var podsProject = "./Pods/Pods.xcodeproj";
	var workingDirectory = (DirectoryPath)$"./externals/{artifact.Id}";

	var podSpecsToBuild = new List<PodSpec> ();

	foreach (var podSpec in artifact.PodSpecs)
	{
		if (podSpec.FrameworkSource != FrameworkSource.Pods)
			continue;

		var framework = $"{podSpec.FrameworkName}.framework";
		var paths = GetDirectories($"{workingDirectory}/Pods/**/{framework}");
		
		if (paths?.Count <= 0) {
			if (!podSpec.CanBeBuild)
				continue;

			podSpecsToBuild.Add (podSpec);
			// BuildXcodeFatFramework (podsProject, podSpec.TargetName, platforms, libraryTitle: podSpec.FrameworkName, workingDirectory: workingDirectory);
			// CopyDirectory ($"{workingDirectory}/{framework}", $"./externals/{framework}");
		} else {
			foreach (var path in paths)
				CopyDirectory (path, $"./externals/{framework}");
		}
	}

	BuildXcodeFatFramework (podsProject, podSpecsToBuild.ToArray (), platforms, workingDirectory: workingDirectory);

	foreach (var podSpec in podSpecsToBuild) {
		var framework = $"{podSpec.FrameworkName}.framework";
		CopyDirectory ($"{workingDirectory}/{framework}", $"./externals/{framework}");
	}
}

void CleanVisualStudioSolution ()
{
	MSBuild(SOLUTION_PATH, c => {
		c.Configuration = "Release";
		c.Restore = true;
		c.MaxCpuCount = 0;
		c.Targets.Add("Clean");
	});

	var deleteDirectorySettings = new DeleteDirectorySettings {
		Recursive = true,
		Force = true
	};

	var bins = GetDirectories("./**/bin");
	DeleteDirectories (bins, deleteDirectorySettings);

	var objs = GetDirectories("./**/obj");
	DeleteDirectories (objs, deleteDirectorySettings);
}

void RestoreVisualStudioSolution ()
{
	MSBuild(SOLUTION_PATH, c => {
		c.Restore = true;
		c.MaxCpuCount = 0;
		c.Targets.Clear();
		c.Targets.Add("Restore");
	});
	NuGetRestore (SOLUTION_PATH);
}

void BuildXcodeFatLibrary (FilePath xcodeProject, string target, Platform [] platforms, string libraryTitle = null, string librarySuffix = null, DirectoryPath workingDirectory = null)
{
	if (!IsRunningOnUnix())
	{
		Warning("{0} is not available on the current platform.", "xcodebuild");
		return;
	}

	libraryTitle = libraryTitle ?? target;
	workingDirectory = workingDirectory ?? Directory("./externals/");
	var libraryFile = (FilePath)(librarySuffix != null ? $"{libraryTitle}.{librarySuffix}" : $"{libraryTitle}");
	var archsFiles = new List<FilePath> ();

	var buildArch = new Action<string, string, FilePath>((sdk, arch, dest) => {
		if (FileExists(dest))
			return;

		XCodeBuild(new XCodeBuildSettings
		{
			Project = workingDirectory.CombineWithFilePath(xcodeProject).ToString(),
			Target = target,
			Sdk = sdk,
			Arch = arch,
			Configuration = "Release",
			Verbose = true
		});

		var outputPath = workingDirectory.Combine("build").Combine($"Release-{sdk}").Combine (target).CombineWithFilePath($"lib{libraryTitle}.a");
		CopyFile(outputPath, dest);
	});

	foreach (var platform in platforms) {
		var archFile = $"{libraryTitle}-{platform.Arch}";
		archsFiles.Add (archFile);
		buildArch (platform.Sdk, platform.Arch, workingDirectory.CombineWithFilePath (archFile));
	}
	
	RunLipoCreate (workingDirectory, libraryTitle, archsFiles.ToArray ());
}

void BuildXcodeFatFramework (FilePath xcodeProject, string target, Platform [] platforms, string libraryTitle = null, string librarySuffix = null, DirectoryPath workingDirectory = null)
{
	if (!IsRunningOnUnix ()) {
		Warning("{0} is not available on the current platform.", "xcodebuild");
		return;
	}

	libraryTitle = libraryTitle ?? target;
	workingDirectory = workingDirectory ?? Directory("./externals/");
	var libraryFile = (FilePath)(librarySuffix != null ? $"{libraryTitle}.{librarySuffix}" : $"{libraryTitle}");
	var fatFramework = (DirectoryPath)$"{libraryTitle}.framework";
	var fatFrameworkPath = workingDirectory.Combine (fatFramework);
	var archsPaths = new List<FilePath> ();

	var buildArch = new Action<string, string, DirectoryPath> ((sdk, arch, dest) => {
		if (DirectoryExists (dest))
			return;

		XCodeBuild (new XCodeBuildSettings {
			Project = workingDirectory.CombineWithFilePath (xcodeProject).ToString (),
			Target = target,
			Sdk = sdk,
			Arch = arch,
			Configuration = "Release",
			Verbose = true
		});

		var outputPath = workingDirectory.Combine ("build").Combine ($"Release-{sdk}").Combine (target).Combine (fatFramework);
		CopyDirectory (outputPath, dest);
	});

	foreach (var platform in platforms) {
		var archPath = (DirectoryPath)$"{libraryTitle}-{platform.Arch}.framework";
		archsPaths.Add (archPath.CombineWithFilePath (libraryTitle));
		buildArch (platform.Sdk, platform.Arch, workingDirectory.Combine (archPath));

		if (!DirectoryExists (fatFrameworkPath))
			CopyDirectory (workingDirectory.Combine (archPath), fatFrameworkPath);
	}
	
	RunLipoCreate (workingDirectory, fatFramework.CombineWithFilePath (libraryFile), archsPaths.ToArray ());

	if (libraryTitle != target && FileExists (fatFrameworkPath.CombineWithFilePath (target)))
		DeleteFile (fatFrameworkPath.CombineWithFilePath (target));
}

void BuildXcodeFatFramework (FilePath xcodeProject, PodSpec [] podSpecs, Platform [] platforms, DirectoryPath workingDirectory = null, Dictionary<string, string> buildSettings = null)
{
	if (!IsRunningOnUnix ()) {
		Warning("{0} is not available on the current platform.", "xcodebuild");
		return;
	}
	
	workingDirectory = workingDirectory ?? Directory("./externals/");

	foreach (var podSpec in podSpecs) {
		var target = podSpec.TargetName;
		var libraryTitle = podSpec.FrameworkName;
		var fatFramework = (DirectoryPath)$"{libraryTitle}.framework";
		
		foreach (var platform in platforms) {
			var sdk = platform.Sdk;
			var arch = platform.Arch;

			var platformFramework = (DirectoryPath)$"{libraryTitle}-{arch}.framework";
			var platformFrameworkPath = workingDirectory.Combine (platformFramework);

			if (DirectoryExists (platformFrameworkPath))
				continue;

			var buildPath = buildSettings != null && buildSettings.ContainsKey ("SYMROOT") ? 
				Directory (buildSettings ["SYMROOT"]) : workingDirectory.Combine ("build");

			XCodeBuild (new XCodeBuildSettings {
				Project = workingDirectory.CombineWithFilePath (xcodeProject).ToString (),
				Target = target,
				Sdk = sdk,
				Arch = arch,
				Configuration = "Release",
				Verbose = true,
				BuildSettings = buildSettings
			});

			var releasePath = buildPath.Combine ($"Release-{sdk}");

			foreach (var p in podSpecs) {
				var outputPath = releasePath.Combine (p.TargetName);
				var lt = p.FrameworkName;
				var ff = (DirectoryPath)$"{lt}.framework";
				var frameworkOutputPath = outputPath.Combine (ff);

				if (!DirectoryExists (frameworkOutputPath))
					continue;
				
				var fatFrameworkPath = workingDirectory.Combine (ff);

				if (!DirectoryExists (fatFrameworkPath))
					CopyDirectory (frameworkOutputPath, fatFrameworkPath);

				var pf = (DirectoryPath)$"{lt}-{arch}.framework";
				var pfp = workingDirectory.Combine (pf);

				CopyDirectory (frameworkOutputPath, pfp);
			}
		}

		var archPaths = new List<FilePath> ();
		var paths = GetFiles ($"{workingDirectory}/{libraryTitle}-*/{libraryTitle}");

		foreach (var path in paths)
			archPaths.Add (path);

		RunLipoCreate (workingDirectory, fatFramework.CombineWithFilePath (libraryTitle), archPaths.ToArray ());
	}
}

bool TargetExistsInXcodeProject (FilePath xcodeProject, string target, DirectoryPath workingDirectory = null)
{
	workingDirectory = workingDirectory ?? Directory("./externals/");

	var processSettings = new ProcessSettings { 
		Arguments = $"-project {workingDirectory.CombineWithFilePath (xcodeProject)} -list",
		RedirectStandardOutput = true
	};

	using(var process = StartAndReturnProcess("xcodebuild", processSettings))
	{
		process.WaitForExit();

		foreach (var line in process.GetStandardOutput ())
			if (line.Contains (target))
				return true;

		return false;
	}
}
