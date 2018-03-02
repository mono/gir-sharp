using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	public partial class Class
	{
		[XmlAttribute ("abstract")]
		public bool Abstract;

		[XmlAttribute ("name")]
		public string Name { get; set; }

		[XmlAttribute ("parent")]
		public string Parent;

		[XmlAttribute ("version")]
		public string Version;

		[XmlAttribute ("symbol-prefix", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string CSymbolPrefix;

		[XmlAttribute ("type", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public string CType { get; set; }

		[XmlAttribute ("fundamental", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public bool Fundamental;

		[XmlAttribute ("get-type", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public string GLibGetType;

		[XmlAttribute ("get-value-func", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public string GLibGetValueFunct;

		[XmlAttribute ("ref-func", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public string GLibRefFunc;

		[XmlAttribute ("set-value-func", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public string GLibSetValueFunc;

		[XmlAttribute ("type-name", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public string GLibTypeName;

		[XmlAttribute ("type-struct", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public string GLibTypeStruct;

		[XmlAttribute ("unref-func", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public string GLibUnrefFunc;

		[XmlElement ("doc")]
		public Documentation Doc { get; set; }

		[XmlElement ("implements")]
		public List<Implements> Implements;

		[XmlElement ("constructor")]
		public List<Constructor> Constructors;

		[XmlElement ("field")]
		public List<Field> Fields;

		[XmlElement ("property")]
		public List<Property> Properties;

		[XmlElement ("union")]
		public List<Union> Unions;

		[XmlElement ("method")]
		public List<Method> Methods;

		[XmlElement ("virtual-method")]
		public List<VirtualMethod> VirtualMethods;

		[XmlElement ("function")]
		public List<Function> Functions;

		[XmlElement ("signal", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
		public List<Signal> Signals;
	}
}