using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Interface : IGeneratable
	{
        [XmlAttribute("name")]
		public string Name { get; set; }

        [XmlAttribute("version")]
        public string Version;

        [XmlAttribute("symbol-prefix", Namespace = "http://www.gtk.org/introspection/c/1.0")]
        public string CSymbolPrefix;

        [XmlAttribute("type", Namespace = "http://www.gtk.org/introspection/c/1.0")]
        public string CType;

        [XmlAttribute("get-type", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
        public string GLibGetType;

        [XmlAttribute("type-name", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
        public string GLibTypeName;

        [XmlAttribute("type-struct", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
        public string GLibTypeStruct;

        [XmlElement("doc")]
        public Documentation Doc { get; set; }

        [XmlElement("prerequisite")]
        public List<Prerequisite> Prerequisites;

        [XmlElement("property")]
        public List<Property> Properties;

        [XmlElement("method")]
        public List<Method> Methods;

        [XmlElement("virtual-method")]
        public List<VirtualMethod> VirtualMethods;

        [XmlElement("function")]
        public List<Function> Functions;

        [XmlElement("signal", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
        public List<Signal> Signals;

	}
}