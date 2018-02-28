using System.Xml.Serialization;

namespace Gir
{
	public partial class Alias : IDocumented
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("type", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string CType { get; set; }

		[XmlElement("doc")]
		public Documentation Doc { get; set; }

		[XmlElement("type")]
		public Type Type;
	}
}