using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Method
	{
		[XmlAttribute ("deprecated")]
		public string Deprecated;

		[XmlAttribute ("deprecated-version")]
		public string DeprecatedVersion;

		[XmlAttribute ("introspectable")]
		public bool Introspectable;

		[XmlAttribute ("moved-to")]
		public string MovedTo;

		[XmlAttribute ("name")]
		public string Name { get; set; }

		[XmlAttribute ("shadowed-by")]
		public string ShadowedBy;

		[XmlAttribute ("shadows")]
		public string Shadows;

		[XmlAttribute ("throws")]
		public bool Throws;

		[XmlAttribute ("version")]
		public string Version;

		[XmlAttribute ("identifier", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string CIdentifier { get; set; }

		[XmlElement ("doc")]
		public Documentation Doc { get; set; }

		[XmlElement("doc-deprecated")]
		public Documentation DocDeprecated { get; set; }

		[XmlElement("return-value")]
		public ReturnValue ReturnValue { get; set; }

		[XmlArray ("parameters")]
		[XmlArrayItem ("parameter", Type = typeof (Parameter))]
		[XmlArrayItem ("instance-parameter", Type = typeof (InstanceParameter))]
		public List<Parameter> Parameters { get; set; }
	}
}