using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Constructor
	{
		[XmlAttribute("deprecated")]
		public bool Deprecated;

		[XmlAttribute("deprecated-version")]
		public string DeprecatedVersion;

		[XmlAttribute("introspectable")]
		public bool Introspectable;

		[XmlAttribute("name")]
		public string Name;

		[XmlAttribute("shadowed-by")]
		public string ShadowedBy;

		[XmlAttribute("shadows")]
		public string Shadows;

		[XmlAttribute("throws")]
		public bool Throws;

		[XmlAttribute("version")]
		public string Version;

		[XmlAttribute("identifier", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string CIdentifier;

		[XmlElement("doc")]
		public Documentation Doc { get; set; }

		[XmlElement("return-value")]
		public ReturnValue ReturnValue;

		[XmlArray("parameters")]
		[XmlArrayItem("parameter", Type = typeof(Parameter))]
		[XmlArrayItem("instance-parameter", Type = typeof(InstanceParameter))]
		public List<Parameter> Parameters;
	}
}
