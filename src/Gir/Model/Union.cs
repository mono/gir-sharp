using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Union
	{
		[XmlAttribute("name")]
		public string Name;

		[XmlAttribute("type", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string CType { get; set; }

		[XmlElement("doc")]
		public Documentation Doc { get; set; }

		[XmlElement("field")]
		public List<Field> Fields;

		[XmlElement("method")]
		public List<Method> Methods;

		[XmlElement("record")]
		public List<Record> Records;
	}
}