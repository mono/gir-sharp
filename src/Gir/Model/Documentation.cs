using System;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Documentation
	{
		[XmlText]
		public string Text;
	}
}
