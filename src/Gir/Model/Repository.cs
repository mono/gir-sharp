using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Gir
{
	[XmlRoot ("repository", Namespace = "http://www.gtk.org/introspection/core/1.0")]
	public partial class Repository
	{
		[XmlAttribute ("version")]
		public string Version { get; set; }

		[XmlElement ("include")]
		public List<Include> Includes { get; set; }

		[XmlElement ("package")]
		public Package Package { get; set; }

		[XmlElement ("include", Namespace = "http://www.gtk.org/introspection/c/1.0")]
		public CInclude CInclude { get; set; }

		[XmlElement ("namespace")]
		public Namespace Namespace { get; set; }

		public string GirName => $"{Namespace.Name}-{Namespace.Version}.gir";

		public override string ToString ()
		{
			return $"{Package.Name}";
		}
	}
}

