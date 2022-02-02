#addin nuget:?package=Cake.Incubator&version=3.0.0
#addin nuget:?package=Cake.Yaml&version=2.1.0
#addin nuget:?package=Cake.Json&version=3.0.1
#addin nuget:?package=Newtonsoft.Json&version=9.0.1
#addin nuget:?package=YamlDotNet&version=5.0.0

#load "poco.cake"
#load "poco.yaml.cake"
// #load "poco.xml.cake"

using System.Linq;

using YamlDotNet.Core;
using YamlDotNet.Serialization;
using Newtonsoft.Json;

var TARGET = Argument ("target", Argument ("t", Argument ("Target", "build")));
var COMPONENT_NAME = Argument ("component-name", Argument ("cn", Argument ("Component-name", "")));
var COMPONENT_VERSION = Argument ("component-version", Argument ("cv", Argument ("Component-version", "")));
var BUMP_DEPENDENTS = Argument ("bump-dependents", Argument ("bd", false));

// Creates a dictionary of components available in repo that are not deprecated.
public Dictionary<string, GoogleBase> CreateComponents ()
{
	var googleComponents = new Dictionary<string, GoogleBase> ();
	
	googleComponents ["Firebase.ABTesting"] = GetComponent<Firebase.ABTesting> ();
	googleComponents ["Firebase.AdMob"] = GetComponent<Firebase.AdMob> ();
	googleComponents ["Firebase.Analytics"] = GetComponent<Firebase.Analytics> ();
	googleComponents ["Firebase.Auth"] = GetComponent<Firebase.Auth> ();
	googleComponents ["Firebase.CloudFirestore"] = GetComponent<Firebase.CloudFirestore> ();
	googleComponents ["Firebase.CloudMessaging"] = GetComponent<Firebase.CloudMessaging> ();
	googleComponents ["Firebase.Core"] = GetComponent<Firebase.Core> ();
	googleComponents ["Firebase.Crashlytics"] = GetComponent<Firebase.Crashlytics> ();
	googleComponents ["Firebase.CrashReporting"] = GetComponent<Firebase.CrashReporting> ();
	googleComponents ["Firebase.Database"] = GetComponent<Firebase.Database> ();
	googleComponents ["Firebase.DynamicLinks"] = GetComponent<Firebase.DynamicLinks> ();
	googleComponents ["Firebase.CloudFunctions"] = GetComponent<Firebase.CloudFunctions> ();
	googleComponents ["Firebase.Invites"] = GetComponent<Firebase.Invites> ();
	googleComponents ["Firebase.PerformanceMonitoring"] = GetComponent<Firebase.PerformanceMonitoring> ();
	googleComponents ["Firebase.RemoteConfig"] = GetComponent<Firebase.RemoteConfig> ();
	googleComponents ["Firebase.Storage"] = GetComponent<Firebase.Storage> ();
	// googleComponents ["Firebase.AppDistribution"] = GetComponent<Firebase.AppDistribution> ();
	// googleComponents ["Firebase.AppCheck"] = GetComponent<Firebase.AppCheck> ();

	googleComponents ["Google.Analytics"] = GetComponent<Google.Analytics> ();
	googleComponents ["Google.Cast"] = GetComponent<Google.Cast> ();
	googleComponents ["Google.Maps"] = GetComponent<Google.Maps> ();
	googleComponents ["Google.MobileAds"] = GetComponent<Google.MobileAds> ();
	googleComponents ["Google.Places"] = GetComponent<Google.Places> ();
	googleComponents ["Google.SignIn"] = GetComponent<Google.SignIn> ();
	googleComponents ["Google.TagManager"] = GetComponent<Google.TagManager> ();

	// googleComponents ["MLKit.Core"] = GetComponent<MLKit.Core> ();
	// googleComponents ["MLKit.TextRecognition"] = GetComponent<MLKit.TextRecognition> ();
	// googleComponents ["MLKit.Vision"] = GetComponent<MLKit.Vision> ();
	// googleComponents ["MLKit.TextRecognition.Latin"] = GetComponent<MLKit.TextRecognition.Latin> ();
	// googleComponents ["MLKit.TextRecognition.Chinese"] = GetComponent<MLKit.TextRecognition.Chinese> ();
	// googleComponents ["MLKit.TextRecognition.Devanagari"] = GetComponent<MLKit.TextRecognition.Devanagari> ();
	// googleComponents ["MLKit.TextRecognition.Japanese"] = GetComponent<MLKit.TextRecognition.Japanese> ();
	// googleComponents ["MLKit.TextRecognition.Korean"] = GetComponent<MLKit.TextRecognition.Korean> ();
	// googleComponents ["MLKit.FaceDetection"] = GetComponent<MLKit.FaceDetection> ();
	// googleComponents ["MLKit.BarcodeScanning"] = GetComponent<MLKit.BarcodeScanning> ();
	// googleComponents ["MLKit.ImageLabeling"] = GetComponent<MLKit.ImageLabeling> ();
	// googleComponents ["MLKit.ObjectDetection"] = GetComponent<MLKit.ObjectDetection> ();

	googleComponents ["Xamarin.Build.Download"] = GetComponent<Xamarin.Build.Download> ();

	return googleComponents;
}

// Gets a component with its basic information.
public T GetComponent<T> () where T : GoogleBase, new ()
{
	T component = new T ();

	FilePath nuspecPath = null;

	// XBD doesn't have its own .nuspec file, we need to get 
	// the XBD version from one of the Firebase/Google .nuspec files.
	// Get the version with XPath.
	if (component is Xamarin.Build.Download) {
		nuspecPath = GetFiles ($"./Firebase.Core/nuget/*.nuspec").ToList () [0];
		component.CurrentVersion = XmlPeek (nuspecPath, "/package/metadata/dependencies/group[@targetFramework='Xamarin.iOS10']/dependency[@id='Xamarin.Build.Download']/@version");
	} else {
		nuspecPath = GetFiles ($"./{component.Name}/nuget/*.nuspec").ToList () [0];
		component.CurrentVersion = XmlPeek (nuspecPath, "/package/metadata/version/text()");
	}
	
	// Create the bumped version, in case we need to use it,
	// by incresing by one the last digit.
	var versionParts = component.CurrentVersion.Split ('.');
	var lastIndex = versionParts.Length - 1;
	versionParts [lastIndex] = (int.Parse (versionParts [lastIndex]) + 1).ToString ();
	component.NewVersion = string.Join (".", versionParts);

	return component;
}

// Updates versions inside of the component.yaml of the desired component
public void UpdateYamlVersions (GoogleBase component)
{
	var yamlPath = new FilePath ($"./{component.Name}/component/component.yaml");

	// Some components doesn't have a component.yaml file
	if (!FileExists (yamlPath))
		return;
	
	Information ($"Updating version in component.yaml file of {component.Name} component.");

	// Deserialize the component.yaml into an object
	var componentData = DeserializeYamlFromFile<Component> (yamlPath);

	// Update the main version of component.yaml
	componentData.Version = component.NewVersion;
	
	// Update the NuGet package version of component.yaml
	var parts = componentData.Packages.iOSUnifiedPaths [0].Split ('=');
	parts [1] = component.NewVersion;
	componentData.Packages.iOSUnifiedPaths [0] = string.Join ("=", parts);

	// Serialize the object into component.yaml file
	SerializeYamlToFile (yamlPath, componentData);
}

// Updates the main version of the .nuspec file of desired component
public void UpdateNuspecMainVersion (GoogleBase component)
{
	// XBD doesn't have its own .nuspec file, so, 
	// we cannot update a main version of .nuspec file.
	if (component is Xamarin.Build.Download)
		return;

	Information ($"Updating main version in .nuspec file of {component.Name} component.\n");

	// There is just one .nuspec file per component,
	// so we are safe to call the first result.
	var nuspecPath = GetFiles ($"./{component.Name}/nuget/*.nuspec").ToList () [0];	
	XmlPoke (nuspecPath, "/package/metadata/version", component.NewVersion);
}

// Updates the dependency version of the .nuspec file on dependent components
public void UpdateNuspecDependencyVersion (GoogleBase component)
{
	foreach	(var name in component.BaseOf) {
		Information ($"Updating {component.Name} dependency version in .nuspec file of {name} component.");
		
		// There is just one .nuspec file per component,
		// so we are safe to call the first result.
		var nuspecPath = GetFiles ($"./{name}/nuget/*.nuspec").ToList () [0];

		var result = XmlPeek (nuspecPath, $"/package/metadata/dependencies/group[@targetFramework='Xamarin.iOS10']/dependency[@id='{component.NuGetId}']/@version");
		if (!string.IsNullOrWhiteSpace (result))
			XmlPoke (nuspecPath, $"/package/metadata/dependencies/group[@targetFramework='Xamarin.iOS10']/dependency[@id='{component.NuGetId}']/@version", component.NewVersion);
	}
}

// This method is only called if we are updating XBD
// Updates XBD's version in all packages.config files of component's samples
public void UpdateSamplesPackagesConfigVersion (GoogleBase component)
{
	foreach	(var name in component.BaseOf) {
		// A component could have more than one sample, so, 
		// we need to iterate through all of sample's packages.config
		var packagesPaths = GetFiles ($"./{name}/samples/**/packages.config");

		foreach (var packagePath in packagesPaths) {
			Information ($"Updating {component.Name} version in packages.config file of {name} sample component.");
			XmlPoke (packagePath, $"/packages/package[@id='{component.Name}']/@version", component.NewVersion);
		}
	}
}

// This method is only called if we are updating XBD
// Updates XBD's version in all .csproj files of component's samples
public void UpdateCsprojVersion (GoogleBase component)
{
	// Xml .csproj has Namespaces, we need to pass the namespaces
	// to XPath to be able to find the desired node.
	var xmlPeekSettings = new XmlPeekSettings {
		Namespaces = new Dictionary<string, string> { { "Project", "http://schemas.microsoft.com/developer/msbuild/2003" } }
	};
	var xmlPokeSettings = new XmlPokeSettings {
		Namespaces = new Dictionary<string, string> { { "Project", "http://schemas.microsoft.com/developer/msbuild/2003" } }
	};
	
	foreach	(var name in component.BaseOf) {
		// A component could have more than one sample, so, 
		// we need to iterate through all of sample's .csproj
		var csprojPaths = GetFiles ($"./{name}/samples/**/*.csproj");

		foreach (var csprojPath in csprojPaths) {
			Information ($"Updating {component.Name} version in .csproj file of {name} sample component.");

			var result = XmlPeek (csprojPath, $"/Project:Project/Project:Import[contains(@Project, '{component.Name}.props')]/@Project", xmlPeekSettings);
			var parts = result.Split (new [] { component.CurrentVersion }, StringSplitOptions.RemoveEmptyEntries);
			var newValue = string.Join (component.NewVersion, parts);
			XmlPoke (csprojPath, $"/Project:Project/Project:Import[contains(@Project, '{component.Name}.props')]/@Project", newValue, xmlPokeSettings);

			result = XmlPeek (csprojPath, $"/Project:Project/Project:Import[contains(@Project, '{component.Name}.props')]/@Condition", xmlPeekSettings);
			parts = result.Split (new [] { component.CurrentVersion }, StringSplitOptions.RemoveEmptyEntries);
			newValue = string.Join (component.NewVersion, parts);
			XmlPoke (csprojPath, $"/Project:Project/Project:Import[contains(@Project, '{component.Name}.props')]/@Condition", newValue, xmlPokeSettings);

			result = XmlPeek (csprojPath, $"/Project:Project/Project:Import[contains(@Project, '{component.Name}.targets')]/@Project", xmlPeekSettings);
			parts = result.Split (new [] { component.CurrentVersion }, StringSplitOptions.RemoveEmptyEntries);
			newValue = string.Join (component.NewVersion, parts);
			XmlPoke (csprojPath, $"/Project:Project/Project:Import[contains(@Project, '{component.Name}.targets')]/@Project", newValue, xmlPokeSettings);

			result = XmlPeek (csprojPath, $"/Project:Project/Project:Import[contains(@Project, '{component.Name}.targets')]/@Condition", xmlPeekSettings);
			parts = result.Split (new [] { component.CurrentVersion }, StringSplitOptions.RemoveEmptyEntries);
			newValue = string.Join (component.NewVersion, parts);
			XmlPoke (csprojPath, $"/Project:Project/Project:Import[contains(@Project, '{component.Name}.targets')]/@Condition", newValue, xmlPokeSettings);
		}
	}
}

public void UpdateComponentVersion (Dictionary<string, GoogleBase> components, string componentName, bool bumpDependents)
{
	var message = $"Working on {componentName} component";
	Information ($"{new string ('/', message.Length + 6)}");
	Information ($"// {message} //");
	Information ($"{new string ('/', message.Length + 6)}\n");

	var component = components [componentName];

	UpdateYamlVersions (component);
	UpdateNuspecMainVersion (component);
	UpdateNuspecDependencyVersion (component);

	if (component is Xamarin.Build.Download) {
		UpdateSamplesPackagesConfigVersion (component);
		UpdateCsprojVersion (component);
	}

	if (!bumpDependents)
		return;
	
	Information ($"\nBUMP_DEPENDENTS was set to true! Starting bumping {component.Name} dependent components due {component.Name} version update...");

	foreach	(var name in component.BaseOf) {
		var dependentComponent = components [name];
		dependentComponent.Bumped = true;
		Information ($"\nBumping {dependentComponent.Name} component from version {dependentComponent.CurrentVersion} to {dependentComponent.NewVersion}...\n");
		UpdateComponentVersion (components, name, false);
	}
}

Task ("build").Does (() => 
{
	if (string.IsNullOrWhiteSpace (COMPONENT_NAME))
		throw new CakeException ("COMPONENT_NAME You must to specify a Component Name to update with -cn | --component-name | --Component-name.");

	if (string.IsNullOrWhiteSpace (COMPONENT_VERSION))
		throw new CakeException ("COMPONENT_VERSION You must to specify the new Component version with -cv | --component-version | --Component-version.");
	
	var components = CreateComponents();
	var updatedComponent = components [COMPONENT_NAME];
	updatedComponent.NewVersion = COMPONENT_VERSION;

	Information ($"Component to updated: {updatedComponent.Name}   {updatedComponent.CurrentVersion}   =>   {updatedComponent.NewVersion}\n");

	UpdateComponentVersion (components, COMPONENT_NAME, BUMP_DEPENDENTS);

	components.Remove (updatedComponent.Name);

	Information ($"Component updated: {updatedComponent.Name}   {updatedComponent.CurrentVersion}   =>   {updatedComponent.NewVersion}\n");

	Information ("List of bumped components due update:");
	foreach (var pair in components)
		if (pair.Value.Bumped)
			Information ($"{pair.Key,-31}{pair.Value.CurrentVersion,-11}=>{"",-3}{pair.Value.NewVersion}");
});

Task ("Default").IsDependentOn ("build");

RunTarget (TARGET);

// public T DeserializeXmlFromFile<T> (FilePath filename)
// {
// 	T result = default (T);
// 	// var serializer = new System.Xml.XmlSerializer (typeof (T));

// 	// A FileStream is needed to read the XML document.
// 	using (FileStream fileStream = new FileStream (filename.FullPath, FileMode.Open)) {
// 		var reader = XmlReader.Create (fileStream);
// 	// 	result = (T)serializer.Deserialize (reader);
// 	}

// 	return result;
// }

// public void SerializeXmlToFile<T> (FilePath filename, T instance)
// {
// 	var serializer = new XmlSerializer (typeof (T));
// 	var namespace = new XmlSerializerNamespaces ();
// 	namespace.Add ("", "");

// 	using (var textWriter = new StreamWriter (nuspec))
// 		serializer.Serialize (textWriter, instance, namespace);
// }

// public void AddNuGetCommentToFilesNode (FilePath filename)
// {
// 	XDocument xml = null;
// 	using (FileStream fileStream = new FileStream (filename.FullPath, FileMode.Open))
// 		xml = XDocument.Load (fileStream);

// 	var filesNode = xml.Root.Element ("files");

// 	foreach (var fileNode in filesNode.Elements ()) {
// 		if (!fileNode.Attribute ("target").Value.EndsWith ("targets", StringComparison.CurrentCulture))
// 			continue;
		
// 		fileNode.AddBeforeSelf (new XComment ("Add targets file for external native reference download"));
// 		break;
// 	}

// 	using (TextWriter textWriter = new NoEncodingStreamWriter (nuspec))
// 		xml.Save (tw);
// }
