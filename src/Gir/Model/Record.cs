using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Record
	{
		[XmlAttribute("deprecated")]
		public bool Deprecated;

		[XmlAttribute("deprecated-version")]
		public string DeprecatedVersion;

		[XmlAttribute("disguised")]
		public bool Disguised;

		[XmlAttribute("foreign")]
		public bool Foreign;

		[XmlAttribute("introspectable")]
		public bool Introspectable;

		[XmlAttribute("name")]
		public string Name;

		[XmlAttribute("version")]
		public string Version;

		[XmlAttribute("symbol-prefix", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string CSymbolPrefix;

		[XmlAttribute("type", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string CType { get; set; }

		[XmlAttribute("get-type", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public string GLibGetType;

		[XmlAttribute("is-gtype-struct-for", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public string GLibIsGTypeStructFor;

		[XmlAttribute("type-name", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public string GLibTypeName;

		[XmlElement("doc")]
		public Documentation Doc { get; set; }

		[XmlElement("field")]
		public List<Field> Fields;

		[XmlElement("union")]
		public List<Union> Unions;

		[XmlElement("constructor")]
		public List<Constructor> Constructors;

		[XmlElement("method")]
		public List<Method> Methods;

		[XmlElement("function")]
		public List<Function> Function;
	}
}