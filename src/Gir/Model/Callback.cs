using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Callback
	{
		[XmlAttribute ("deprecated")]
		public string Deprecated;

		[XmlAttribute ("deprecated-version")]
		public string DeprecatedVersion;

		[XmlAttribute ("introspectable")]
		public bool Introspectable;

		[XmlAttribute ("name")]
		public string Name { get; set; }

		[XmlAttribute ("throws")]
		public bool Throws;

		[XmlAttribute ("version")]
		public string Version;

		[XmlAttribute ("type", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string CType { get; set; }

		[XmlArray ("parameters")]
		[XmlArrayItem ("parameter", Type = typeof (Parameter))]
		[XmlArrayItem ("instance-parameter", Type = typeof (InstanceParameter))]
		public List<Parameter> Parameters { get; set; }

		[XmlElement ("return-value")]
		public ReturnValue ReturnValue { get; set; }
	}
}