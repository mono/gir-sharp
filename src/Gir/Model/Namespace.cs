using System;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Namespace
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("version")]
		public string Version { get; set; }

		[XmlAttribute("shared-library")]
		public string SharedLibary { get; set; }

		[XmlAttribute("identifier-prefix", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string IdentifierPrefix { get; set; }

		[XmlAttribute("symbol-prefixes", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string SymbolPrefixes { get; set; }

		[XmlElement("alias")]
		public List<Alias> Aliases { get; set; }

		[XmlElement("record")]
		public List<Record> Records { get; set; }

		[XmlElement("class")]
		public List<Class> Classes { get; set; }

		[XmlElement("constant")]
		public List<Constant> Constants { get; set; }

		[XmlElement("interface")]
		public List<Interface> Interfaces { get; set; }

		[XmlElement("callback")]
		public List<Callback> Callbacks { get; set; }

		[XmlElement("function")]
		public List<Function> Functions { get; set; }

		[XmlElement("union")]
		public List<Union> Unions { get; set; }

		[XmlElement("enumeration")]
		public List<Enumeration> Enumerations { get; set; }

		[XmlElement("bitfield")]
		public List<Bitfield> Bitfields { get; set; }
	}
}

