using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Signal
	{
		[XmlAttribute ("action")]
		public string Action;

		[XmlAttribute ("deprecated")]
		public string Deprecated;

		[XmlAttribute ("deprecated-version")]
		public string DeprecatedVersion;

		[XmlAttribute ("detailed")]
		public bool Detailed;

		[XmlAttribute ("introspectable")]
		public bool Introspectable;

		[XmlAttribute ("name")]
		public string Name { get; set; }

		[XmlAttribute ("no-hooks")]
		public bool NoHooks;

		[XmlAttribute ("no-recurse")]
		public bool NoRecurse;

		[XmlAttribute ("version")]
		public string Version;

		[XmlAttribute ("when")]
		public string When;

		[XmlElement ("doc", Namespace = "http://www.gtk.org/introspection/core/1.0")]
		public Documentation Doc { get; set; }

		[XmlElement ("return-value", Namespace = "http://www.gtk.org/introspection/core/1.0")]
		public ReturnValue ReturnValue { get; set; }

		[XmlArray ("parameters")]
		[XmlArrayItem ("parameter", Type = typeof (Parameter))]
		[XmlArrayItem ("instance-parameter", Type = typeof (InstanceParameter))]
		public List<Parameter> Parameters { get; set; }
	}
}