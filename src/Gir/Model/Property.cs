using System;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Property
	{
		[XmlAttribute("construct")]
		public bool Construct;

		[XmlAttribute("construct-only")]
		public bool ConstructOnly;

		[XmlAttribute("deprecated")]
		public bool Deprecated;

		[XmlAttribute("deprecated-version")]
		public string DeprecatedVersion;

		[XmlAttribute("introspectable")]
		public bool Introspectable;

		[XmlAttribute("name")]
		public string Name;

		[XmlAttribute("readable")]
		public bool Readable;

		[XmlAttribute("transfer-ownership")]
		public TransferOwnership TransferOwnership;

		[XmlAttribute("version")]
		public string Version;

		[XmlAttribute("writable")]
		public bool Writable;

		[XmlElement("doc")]
		public Documentation Doc { get; set; }

		[XmlElement("type")]
		public Type Type;
	}
}
