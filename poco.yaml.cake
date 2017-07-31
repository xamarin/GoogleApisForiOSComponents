/////////////////////////////////////////////////////
// Objects used to represent a component.yaml file //
/////////////////////////////////////////////////////

// public abstract class PathsBase
// {
// 	[YamlMember(Alias = "ios-unified")]
// 	public List<string> iOSUnifiedPaths { get; set; }

// 	[YamlMember(Alias = "ios")]
// 	public List<string> iOSPaths { get; set; }

// 	[YamlMember(Alias = "android")]
// 	public List<string> AndroidPaths { get; set; }
// }

// public class Libraries : PathsBase
// {	
// }

// public class Packages : PathsBase
// {	
// }

// public class AdditionalFile
// {
// 	[YamlMember(Alias = "source")]
// 	public string SourcePath { get; set; }

// 	[YamlMember(Alias = "destination")]
// 	public string DestinationPath { get; set; }
// }

// public class NuGetInstaller
// {
// 	[YamlMember(Alias = "project")]
// 	public string ProjectName { get; set; }

// 	[YamlMember(Alias = "packages")]
// 	public List<string> PackagesNames { get; set; }
// }

// public class Sample
// {
// 	[YamlMember(Alias = "name")]
// 	public string Name { get; set; }

// 	[YamlMember(Alias = "path")]
// 	public string Path { get; set; }

// 	[YamlMember(Alias = "removeProjects")]
// 	public List<string> ProjectsToRemove { get; set; }

// 	[YamlMember(Alias = "installNuGets")]
// 	public NuGetInstaller NuGetsToInstall { get; set; }

//	[YamlMember(Alias = "removeFiles")]
//	public List<string> FilesToRemove { get; set; }

// 	[YamlMember(Alias = "removeNodes")]
// 	public List<string> NodesToRemove { get; set; }
// }

// public class Component 
// {
// 	[YamlMember(Alias = "version")]
// 	public string Version { get; set; }
	
// 	[YamlMember(Alias = "name")]
// 	public string Name { get; set; }
	
// 	[YamlMember(Alias = "id")]
// 	public string Id { get; set; }
	
// 	[YamlMember(Alias = "publisher")]
// 	public string Publisher { get; set; }

// 	[YamlMember(Alias = "license")]
// 	public string LicensePath { get; set; }
	
// 	[YamlMember(Alias = "publisher-url")]
// 	public string PublisherUrl { get; set; }

// 	[YamlMember(Alias = "src-url")]
// 	public string SourceUrl { get; set; }

// 	[YamlMember(Alias = "summary")]
// 	public string Summary { get; set; }

// 	[YamlMember(Alias = "icons")]
// 	public List<string> IconsPath { get; set; }

// 	[YamlMember(Alias = "docs-url")]
// 	public string DocsUrl { get; set; }

// 	[YamlMember(Alias = "libraries")]
// 	public Libraries Libraries { get; set; }
	
// 	[YamlMember(Alias = "is_shell")]
// 	public bool IsShell { get; set; }
	
// 	[YamlMember(Alias = "packages")]
// 	public Packages Packages { get; set; }
	
// 	[YamlMember(Alias = "samples")]
// 	public List<Sample> Samples { get; set; }
	
// 	[YamlMember(Alias = "local-nuget-repo")]
// 	public string LocalNuGetRepoPath { get; set; }
	
// 	[YamlMember(Alias = "no_build")]
// 	public bool NoBuild { get; set; }

// 	[YamlMember(Alias = "additional-files")]
// 	public List<AdditionalFile> AdditionalFiles { get; set; }
// }

///////////////////////////////////////////////////////////
// Temporary objects with JsonProperty attribute used to //
// represent a component.yaml file due YamlDotNet bug in //
// v3.8.0						 //
///////////////////////////////////////////////////////////

public abstract class PathsBase
{
	[JsonProperty ("ios-unified")]
	[YamlMember(Alias = "ios-unified")]
	public List<string> iOSUnifiedPaths { get; set; }

	[JsonProperty ("ios")]
	[YamlMember(Alias = "ios")]
	public List<string> iOSPaths { get; set; }

	[JsonProperty ("android")]
	[YamlMember(Alias = "android")]
	public List<string> AndroidPaths { get; set; }
}

public class Libraries : PathsBase
{	
}

public class Packages : PathsBase
{	
}

public class AdditionalFile
{
	[JsonProperty ("source")]
	[YamlMember(Alias = "source")]
	public string SourcePath { get; set; }

	[JsonProperty ("destination")]
	[YamlMember(Alias = "destination")]
	public string DestinationPath { get; set; }
}

public class NuGetInstaller
{
	[JsonProperty ("project")]
	[YamlMember(Alias = "project")]
	public string ProjectName { get; set; }

	[JsonProperty ("packages")]
	[YamlMember(Alias = "packages")]
	public List<string> PackagesNames { get; set; }
}

public class Sample
{
	[YamlMember(Alias = "name")]
	public string Name { get; set; }

	[YamlMember(Alias = "path")]
	public string Path { get; set; }

	[JsonProperty ("removeProjects")]
	[YamlMember(Alias = "removeProjects")]
	public List<string> ProjectsToRemove { get; set; }

	[JsonProperty ("installNuGets")]
	[YamlMember(Alias = "installNuGets")]
	public List<NuGetInstaller> NuGetsToInstall { get; set; }

	[JsonProperty ("removeFiles")]
	[YamlMember(Alias = "removeFiles")]
	public List<string> FilesToRemove { get; set; }

	[JsonProperty ("removeNodes")]
	[YamlMember(Alias = "removeNodes")]
	public List<string> NodesToRemove { get; set; }
}

public class Component 
{
	[YamlMember(Alias = "version")]
	public string Version { get; set; }
	
	[YamlMember(Alias = "name")]
	public string Name { get; set; }
	
	[YamlMember(Alias = "id")]
	public string Id { get; set; }
	
	[YamlMember(Alias = "publisher")]
	public string Publisher { get; set; }
	
	[JsonProperty ("publisher-url")]
	[YamlMember(Alias = "publisher-url")]
	public string PublisherUrl { get; set; }

	[YamlMember(Alias = "license")]
	public string LicensePath { get; set; }

	[JsonProperty ("src-url")]
	[YamlMember(Alias = "src-url")]
	public string SourceUrl { get; set; }

	[YamlMember(Alias = "summary")]
	public string Summary { get; set; }

	[JsonProperty ("icons")]
	[YamlMember(Alias = "icons")]
	public List<string> IconsPath { get; set; }

	[JsonProperty ("docs-url")]
	[YamlMember(Alias = "docs-url")]
	public string DocsUrl { get; set; }

	[YamlMember(Alias = "libraries")]
	public Libraries Libraries { get; set; }
	
	[JsonProperty ("is_shell")]
	[YamlMember(Alias = "is_shell")]
	public bool IsShell { get; set; }
	
	[YamlMember(Alias = "packages")]
	public Packages Packages { get; set; }
	
	[YamlMember(Alias = "samples")]
	public List<Sample> Samples { get; set; }
	
	[JsonProperty ("local-nuget-repo")]
	[YamlMember(Alias = "local-nuget-repo")]
	public string LocalNuGetRepoPath { get; set; }
	
	[JsonProperty ("no_build")]
	[YamlMember(Alias = "no_build")]
	public bool NoBuild { get; set; }

	[JsonProperty ("additional-files")]
	[YamlMember(Alias = "additional-files")]
	public List<AdditionalFile> AdditionalFiles { get; set; }
}