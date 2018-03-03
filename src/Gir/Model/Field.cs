using System.Xml.Serialization;

namespace Gir
{
	public partial class Field
	{
		[XmlAttribute ("bits")]
		public int Bits;

		[XmlAttribute ("introspectable")]
		public bool Introspectable;

		[XmlAttribute ("name")]
		public string Name { get; set; }

		[XmlAttribute ("private")]
		public bool Private;

		[XmlAttribute ("readable")]
		public bool Readable;

		[XmlAttribute ("writable")]
		public bool Writable;

		[XmlElement ("doc")]
		public Documentation Doc { get; set; }

		[XmlElement ("type")]
		public Type Type { get; set; }

		[XmlElement ("callback")]
		public Callback Callback { get; set; }

		[XmlElement("array")]
		public Array Array { get; set; }
	}
}
