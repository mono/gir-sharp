using System;
using System.Xml.Serialization;

namespace Gir
{
	[Serializable]
	public partial class Documentation
	{
		[XmlText]
		public string Text;
	}
}
