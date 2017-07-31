///////////////////////////////////////////////
// Objects used to represent a *.nuspec file //
///////////////////////////////////////////////

public class NuspecFile
{
	[System.Xml.Serialization.XmlAttribute ("src")]
	public string Source { get; set; }

	[System.Xml.Serialization.XmlAttribute ("target")]
	public string Target { get; set; }
}

[XmlRoot ("dependency")]
public class Dependency
{
	[System.Xml.Serialization.XmlAttribute ("id")]
	public string Id { get; set; }

	[System.Xml.Serialization.XmlAttribute ("version")]
	public string Version { get; set; }
}


public class Group
{
	[System.Xml.Serialization.XmlAttribute ("targetFramework")]
	public string TargetFramework { get; set; }

	[System.Xml.Serialization.XmlElement ("dependency")]
	public List<Dependency> Dependencies { get; set; }
}

[XmlRoot ("metadata")]
public class Metadata
{
	[System.Xml.Serialization.XmlElement ("id")]
	public string Id { get; set; }

	[System.Xml.Serialization.XmlElement ("title")]
	public string Title { get; set; }

	[System.Xml.Serialization.XmlElement ("version")]
	public string Version { get; set; }

	[System.Xml.Serialization.XmlElement ("authors")]
	public string Authors { get; set; }

	[System.Xml.Serialization.XmlElement ("owners")]
	public string Owners { get; set; }

	[System.Xml.Serialization.XmlElement ("requireLicenseAcceptance", Type = typeof (bool))]
	public bool RequireLicenseAcceptance { get; set; }

	[System.Xml.Serialization.XmlElement ("description")]
	public string Description { get; set; }

	[System.Xml.Serialization.XmlElement ("copyright")]
	public string Copyright { get; set; }

	[System.Xml.Serialization.XmlElement ("projectUrl")]
	public string ProjectUrl { get; set; }

	[System.Xml.Serialization.XmlElement ("licenseUrl")]
	public string LicenseUrl { get; set; }

	[System.Xml.Serialization.XmlElement ("iconUrl")]
	public string IconUrl { get; set; }

	[System.Xml.Serialization.XmlArray ("dependencies")]
	[System.Xml.Serialization.XmlArrayItem ("group")]
	public List<Group> DependenciesGroups { get; set; }
}

[System.Xml.Serialization.XmlRoot ("package")]
public class Nuspec
{
	[System.Xml.Serialization.XmlElement ("metadata")]
	public Metadata Metadata { get; set; }

	[System.Xml.Serialization.XmlArray ("files")]
	[System.Xml.Serialization.XmlArrayItem ("file")]
	public List<NuspecFile> Files { get; set; }
}

public class NoEncodingStreamWriter : System.IO.StreamWriter
{
	public override System.Text.Encoding Encoding {
		get { return null; }
	}

	public NoEncodingStreamWriter (string path) : base (path)
	{
	}
}