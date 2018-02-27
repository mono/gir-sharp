using System;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Field
	{
		[XmlAttribute("bits")]
		public int Bits;

		[XmlAttribute("introspectable")]
		public bool Introspectable;

		[XmlAttribute("name")]
		public string Name;

		[XmlAttribute("private")]
		public bool Private;

		[XmlAttribute("readable")]
		public bool Readable;

		[XmlAttribute("writable")]
		public bool Writable;

		[XmlElement("doc")]
		public Documentation Doc;

		[XmlElement("type")]
		public Type Type;
	}
}
