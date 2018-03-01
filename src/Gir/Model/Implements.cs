using System;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Implements
	{
		[XmlAttribute("name")]
		public string Name;

		public override string ToString()
		{
			return Name;
		}
	}
}
