#addin nuget:?package=Cake.Incubator&version=1.2.0
#addin nuget:?package=Cake.Yaml&version=1.0.3
#addin nuget:?package=Cake.Json&version=1.0.2

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
var BUMP_DEPENDENCIES = Argument ("bump-dependencies", Argument ("bd", true));

public Dictionary<string, GoogleBase> CreateComponents ()
{
	var googleComponents = new Dictionary<string, GoogleBase> ();
	
	googleComponents ["Firebase.AdMob"] = GetComponent<Firebase.AdMob> ();
	googleComponents ["Firebase.Analytics"] = GetComponent<Firebase.Analytics> ();
	googleComponents ["Firebase.Auth"] = GetComponent<Firebase.Auth> ();
	googleComponents ["Firebase.CloudMessaging"] = GetComponent<Firebase.CloudMessaging> ();
	googleComponents ["Firebase.Core"] = GetComponent<Firebase.Core> ();
	googleComponents ["Firebase.CrashReporting"] = GetComponent<Firebase.CrashReporting> ();
	googleComponents ["Firebase.Database"] = GetComponent<Firebase.Database> ();
	googleComponents ["Firebase.DynamicLinks"] = GetComponent<Firebase.DynamicLinks> ();
	googleComponents ["Firebase.InstanceID"] = GetComponent<Firebase.InstanceID> ();
	googleComponents ["Firebase.Invites"] = GetComponent<Firebase.Invites> ();
	googleComponents ["Firebase.RemoteConfig"] = GetComponent<Firebase.RemoteConfig> ();
	googleComponents ["Firebase.Storage"] = GetComponent<Firebase.Storage> ();

	googleComponents ["Google.Analytics"] = GetComponent<Google.Analytics> ();
	googleComponents ["Google.AppIndexing"] = GetComponent<Google.AppIndexing> ();
	googleComponents ["Google.Cast"] = GetComponent<Google.Cast> ();
	googleComponents ["Google.Core"] = GetComponent<Google.Core> ();
	googleComponents ["Google.InstanceID"] = GetComponent<Google.InstanceID> ();
	googleComponents ["Google.Maps"] = GetComponent<Google.Maps> ();
	googleComponents ["Google.MobileAds"] = GetComponent<Google.MobileAds> ();
	googleComponents ["Google.PlayGames"] = GetComponent<Google.PlayGames> ();
	googleComponents ["Google.SignIn"] = GetComponent<Google.SignIn> ();
	googleComponents ["Google.TagManager"] = GetComponent<Google.TagManager> ();

	googleComponents ["Xamarin.Build.Download"] = GetComponent<XamarinBuildDownload> ();

	return googleComponents;
}

public T GetComponent<T> () where T : GoogleBase, new ()
{
	T component = new T ();

	FilePath nuspecPath = null;

	if (component is XamarinBuildDownload) {
		nuspecPath = GetFiles ($"./Firebase.Core/nuget/*.nuspec").ToList () [0];
		component.CurrentVersion = XmlPeek (nuspecPath, "/package/metadata/dependencies/group[@targetFramework='Xamarin.iOS10']/dependency[@id='Xamarin.Build.Download']/@version");
	} else {
		nuspecPath = GetFiles ($"./{component.Name}/nuget/*.nuspec").ToList () [0];
		component.CurrentVersion = XmlPeek (nuspecPath, "/package/metadata/version/text()");
	}

	component.NewVersion = component.CurrentVersion;
	
	return component;
}

public void UpdateComponentVersion (Dictionary<string, GoogleBase> components, string componentName, bool bumpDependencies)
{
	var message = $"Working on {componentName} component";
	Information ($"{new string ('/', message.Length + 6)}");
	Information ($"// {message} //");
	Information ($"{new string ('/', message.Length + 6)}\n");

	var component = components [componentName];

	var yamlPath = new FilePath ($"./{component.Name}/component/component.yaml");
	var nuspecPaths = GetFiles ($"./{component.Name}/nuget/*.nuspec");
	FilePath nuspecPath = new FilePath ($"./{component.Name}/nuget/NotFound.nuspec");;

	foreach (var path in nuspecPaths)
		nuspecPath = path;

	if (FileExists (yamlPath)) {
		Information ($"Updating version in component.yaml file of {component.Name} component");

		// var componentData = DeserializeYamlFromFile<Component> (yamlPath);

		// Temporary Workaround. Seems that YamlDotNet cannot deserialize an object within an object in version 3.8.0
		// This doesn't happen in version 4.x
		var jsonString = ConvertYamlToJsonFromFile (yamlPath);
		var componentData = DeserializeJson<Component> (jsonString);

		componentData.Version = component.NewVersion;
		
		var parts = componentData.Packages.iOSUnifiedPaths [0].Split ('=');
		parts [1] = component.NewVersion;
		componentData.Packages.iOSUnifiedPaths [0] = string.Join ("=", parts);

		SerializeYamlToFile (yamlPath, componentData);
	}

	if (FileExists (nuspecPath)) {
		Information ($"Updating version in .nuspec file of {component.Name} component\n");
		XmlPoke (nuspecPath, "/package/metadata/version", component.NewVersion);
	}

	foreach	(var name in component.BaseOf) {
		nuspecPath = GetFiles ($"./{name}/nuget/*.nuspec").ToList () [0];

		Information ($"Updating {component.Name} dependency version in .nuspec file of {name} component");

		if (FileExists (nuspecPath)) {
			var result = XmlPeek (nuspecPath, $"/package/metadata/dependencies/group[@targetFramework='Xamarin.iOS10']/dependency[@id='{component.NuGetId}']/@version");
			if (!string.IsNullOrWhiteSpace (result))
				XmlPoke (nuspecPath, $"/package/metadata/dependencies/group[@targetFramework='Xamarin.iOS10']/dependency[@id='{component.NuGetId}']/@version", component.NewVersion);
		}
	}

	if (!bumpDependencies)
		return;
	
	Information ($"\nBUMP_DEPENDENCIES was set to true! Starting bumping {component.Name} dependent components due {component.Name} version update...");

	foreach	(var name in component.BaseOf) {
		var dependentComponent = components [name];
		
		var versionParts = dependentComponent.CurrentVersion.Split ('.');
		var lastIndex = versionParts.Length - 1;
		versionParts [lastIndex] = (int.Parse (versionParts [lastIndex]) + 1).ToString ();
		
		dependentComponent.NewVersion = string.Join (".", versionParts);
		components [name] = dependentComponent;

		Information ($"\nBumping {dependentComponent.Name} component from version {dependentComponent.CurrentVersion} to {dependentComponent.NewVersion}...\n");
		UpdateComponentVersion (components, name, false);
	}
}

public string ConvertYamlToJsonFromFile (FilePath filename)
{
	object yaml = null;
	var deserializer = new Deserializer ();
	var serializer = new Serializer (SerializationOptions.JsonCompatible);

	using (var textReader = System.IO.File.OpenText (filename.FullPath)) {
		var eventReader = new EventReader (new MergingParser (new Parser (textReader)));
		yaml = deserializer.Deserialize (eventReader);
	}

	var stringBuilder = new StringBuilder ();
	using (var textWriter = new StringWriter (stringBuilder))
		serializer.Serialize (textWriter, yaml);

	return stringBuilder.ToString ();
}

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

	UpdateComponentVersion (components, COMPONENT_NAME, BUMP_DEPENDENCIES);

	components.Remove (updatedComponent.Name);

	Information ($"Component updated: {updatedComponent.Name}   {updatedComponent.CurrentVersion}   =>   {updatedComponent.NewVersion}\n");

	Information ("List of bumped components due update:");
	foreach (var pair in components)
		if (pair.Value.CurrentVersion != pair.Value.NewVersion)
			Information ($"{pair.Key,-26}{pair.Value.CurrentVersion,-11}=>{"",-3}{pair.Value.NewVersion}");
});

RunTarget (TARGET);