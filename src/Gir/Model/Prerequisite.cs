using System.Xml.Serialization;

namespace Gir
{
	public partial class Prerequisite
	{
		[XmlAttribute ("name")]
		public string Name;
	}
}