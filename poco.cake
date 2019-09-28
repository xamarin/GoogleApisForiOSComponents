enum ComponentGroup
{
	Firebase,
	Google
}

enum FrameworkSource
{
	Targets,
	Pods,
	Custom
}

struct Platform
{
	#region Properties

	public string Arch { get; private set; }
	public string Sdk { get; private set; } 

	public static Platform iOSSimulator { get; } = new Platform ("i386", "iphonesimulator");
	public static Platform iOSSimulator64 { get; } = new Platform ("x86_64", "iphonesimulator");
	public static Platform iOSArmV7 { get; } = new Platform ("armv7", "iphoneos");
	public static Platform iOSArmV7s { get; } = new Platform ("armv7s", "iphoneos");
	public static Platform iOSArm64 { get; } = new Platform ("arm64", "iphoneos");

	#endregion

	#region Constructors

	Platform (string arch, string sdk) {
		Arch = arch;
		Sdk = sdk;
	}

	#endregion

	#region Public Functionality

	public static Platform Create (string arch, string sdk) => new Platform (arch, sdk);
	public override string ToString () => $"{Arch} => {Sdk}";

	#endregion

	#region Operations

		public static bool operator == (Platform first, Platform second) =>
			string.Equals (first.ToString (), second.ToString ());

		public static bool operator != (Platform first, Platform second) =>
			!string.Equals (first.ToString (), second.ToString ());

		public override bool Equals (object obj) =>
			obj is Platform platform && this == platform;

		public override int GetHashCode () =>
			base.GetHashCode ();

	#endregion
}

class Repository
{
	// The url of the repo where the podspec lives.
	public string Url { get; private set; }
	// The name of the branch that the repo will use.
	public string Branch { get; private set; }
	// The name of the tag that the repo will use.
	// If null, Branch value will be used.
	public string Tag { get; private set; }
	// The name of the tag that the repo will use.
	// If null, Tag value will be used.
	public string Commit { get; private set; }

	public Repository (string url, string branch = null, string tag = null, string commit = null)
	{
		Url = url;
		Branch = branch;
		Tag = tag;
		Commit = commit;
	}
}

class PodSpec
{
	public enum PodSource {
		PodVersion,
		LocalPath,
		Repository
	}

	// The podspec name
	public string Name { get; private set; }
	// The podspec version if any, the component version otherwise. 
	public string Version { get; private set; }
	// The local path where the podspec lives in your machine.
	public FilePath LocalPath { get; private set; }
	// The repo data where the podspec is fetch.
	public Repository Repository { get; private set; }
	// Target used to build the Xcode Pods project.
	// If null, Name property value will be used.
	public string TargetName { get; private set; }
	// Overrides the default framework's name built with Pods project and Xcode.
	// If null, Name property value will be used.
	public string FrameworkName { get; private set; }
	// The desired subspec to be used.
	// If null, default subspecs defined within the podspec will be used.
	public string [] SubSpecs { get; private set; }
	// If true and when Subspecs property is not null, default subspecs
	// defined within the podspec will added to the Podfile. Otherwise,
	// only subSpecs specified in Subspecs will be used. False by default.
	public bool UseDefaultSubspecs { get; private set; }
	// Specify the source where the framework will be gotten.
	// From a .targets file by default.
	public FrameworkSource FrameworkSource { get; private set; }
	// If true, the podspec can be built using Xcode. True by default.
	public bool CanBeBuild { get; private set; }

	public PodSource Source { get; private set; }

	PodSpec () { }

	static PodSpec Create (string name, string version, FilePath localPath, Repository repository, string targetName, string frameworkName, FrameworkSource frameworkSource, string [] subSpecs, bool useDefaultSubspecs, bool canBeBuild, PodSource source)
	{
		return new PodSpec {
			Name = name,
			Version = version,
			LocalPath = localPath,
			Repository = repository,
			TargetName = targetName ?? name,
			FrameworkName = frameworkName ?? name,
			FrameworkSource = frameworkSource,
			SubSpecs = subSpecs,
			UseDefaultSubspecs = useDefaultSubspecs,
			CanBeBuild = canBeBuild,
			Source = source
		};
	}

	public static PodSpec Create (string name, string version, string targetName = null, string frameworkName = null, FrameworkSource frameworkSource = FrameworkSource.Pods, string [] subSpecs = null, bool useDefaultSubspecs = false, bool canBeBuild = true)
		=> Create (name, version, null, null, targetName ?? name, frameworkName ?? name, frameworkSource, subSpecs, useDefaultSubspecs, canBeBuild, PodSource.PodVersion);

	public static PodSpec Create (string name, FilePath localPath, string targetName = null, string frameworkName = null, FrameworkSource frameworkSource = FrameworkSource.Pods, string [] subSpecs = null, bool useDefaultSubspecs = false, bool canBeBuild = true)
		=> Create (name, null, localPath, null, targetName ?? name, frameworkName ?? name, frameworkSource, subSpecs, useDefaultSubspecs, canBeBuild, PodSource.LocalPath);

	public static PodSpec Create (string name, Repository repository, string targetName = null, string frameworkName = null, FrameworkSource frameworkSource = FrameworkSource.Pods, string [] subSpecs = null, bool useDefaultSubspecs = false, bool canBeBuild = true)
		=> Create (name, null, null, repository, targetName ?? name, frameworkName ?? name, frameworkSource, subSpecs, useDefaultSubspecs, canBeBuild, PodSource.Repository);

	public string [] BuildPodLines ()
	{
		var podLines = new List<string> ();
		var podLine = BuildBasePodLine ();
		
		if (SubSpecs == null) {
			podLines.Add (string.Format (podLine, Name));
			return podLines.ToArray ();
		}

		if (UseDefaultSubspecs)
			podLines.Add (string.Format (podLine, Name));

		foreach (var subSpec in SubSpecs)
			podLines.Add (string.Format (podLine, $"{Name}/{subSpec}"));

		return podLines.ToArray ();
	}

	string BuildBasePodLine ()
	{
		switch (Source) {
		case PodSource.PodVersion:
			return $"\tpod '{{0}}', '{Version}'";
		case PodSource.LocalPath:
			return $"\tpod '{{0}}', :path => '{LocalPath.FullPath}'";
		case PodSource.Repository:
			var pod = $"\tpod '{{0}}', :git => '{Repository.Url}'";
			
			if (!string.IsNullOrWhiteSpace (Repository.Branch))
				pod += $", :branch => '{Repository.Branch}'";
			else if (!string.IsNullOrWhiteSpace (Repository.Tag))
				pod += $", :tag => '{Repository.Tag}'";
			else if (!string.IsNullOrWhiteSpace (Repository.Commit))
				pod += $", :commit => '{Repository.Commit}'";

			return pod;
		}
		return null;
	}
}

class Artifact : IEquatable<Artifact>
{
	// The id of the component.
	public string Id { get; set; }
	// The version to be published on NuGet.
	public string NugetVersion { get; set; }
	// The minimun iOS supported version of the component.
	public string MinimunSupportedVersion { get; set; }
	// If it's a Firebase or Google component.
	public ComponentGroup ComponentGroup { get; set; }
	// The C# project name. This will have the Id property value if not specified.
	public string CsprojName { get; set; }
	// Other Google/Firebase components that make this component work.
	public Artifact [] Dependencies { get; set; }
	// The component build order.
	public int BuildOrder { get => Dependencies?.Length + 1 ?? 1; }
	// The specs used in the Podfile.
	public PodSpec [] PodSpecs { get; set; }
	// Extra code to be added to Podfile
	public string [] ExtraPodfileLines { get; set; }
	// The samples created to test the component.
	public string [] Samples { get; set; }

	public Artifact (string id, string nugetVersion, string minimunSupportedVersion, ComponentGroup componentType, string csprojName = null, Artifact [] dependencies = null, PodSpec [] podSpecs = null, string [] extraPodfileLines = null, string [] samples = null)
	{
		Id = id;
		NugetVersion = nugetVersion;
		MinimunSupportedVersion = minimunSupportedVersion;
		ComponentGroup = componentType;
		CsprojName = csprojName ?? id;
		Dependencies = dependencies;
		PodSpecs = podSpecs;
		ExtraPodfileLines = extraPodfileLines;
		Samples = samples;
	}

	public bool Equals (Artifact other)
	{
		if (Object.ReferenceEquals(other, null)) return false;
		if (Object.ReferenceEquals(this, other)) return true;

		return Id == other.Id;
	}

	public override int GetHashCode()
	{
		int hashCode = Id.GetHashCode();
		return hashCode ^ hashCode;
	}
}
