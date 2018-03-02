using System.Xml.Serialization;

namespace Gir
{
	public partial class Package
	{
		[XmlAttribute ("name")]
		public string Name { get; set; }
	}
}