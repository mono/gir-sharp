using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	public partial class VirtualMethod
	{
		[XmlAttribute ("deprecated")]
		public bool Deprecated;

		[XmlAttribute ("deprecated-version")]
		public string DeprecatedVersion;

		[XmlAttribute ("introspectable")]
		public bool Introspectable;

		[XmlAttribute ("invoker")]
		public string Invoker;

		[XmlAttribute ("name")]
		public string Name;

		[XmlAttribute ("throws")]
		public bool Throws;

		[XmlAttribute ("version")]
		public string Version;

		[XmlElement ("doc")]
		public Documentation Doc { get; set; }

		[XmlElement ("return-value")]
		public ReturnValue ReturnValue { get; set; }

		[XmlArray ("parameters")]
		[XmlArrayItem ("parameter", Type = typeof (Parameter))]
		[XmlArrayItem ("instance-parameter", Type = typeof (InstanceParameter))]
		public List<Parameter> Parameters { get; set; }

	}
}