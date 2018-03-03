using System.Xml.Serialization;

namespace Gir
{
	public partial class CInclude
	{
		[XmlAttribute ("name", Namespace = "http://www.gtk.org/introspection/core/1.0")]
		public string Name;
	}
}