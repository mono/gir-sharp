using System;
using System.Xml.Serialization;

namespace Gir
{
	[Serializable]
	public partial class Include
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("version")]
		public string Version { get; set; }

		public string GirName => $"{Name}-{Version}.gir";
	}
}