using System.Xml.Serialization;

namespace Gir
{
    public partial class Member
    {
        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("value")]
        public string Value;

        [XmlAttribute("identifier", Namespace = "http://www.gtk.org/introspection/c/1.0")]
        public string CIdentifier;

        [XmlAttribute("nick", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
        public string GLibNick;

        [XmlElement("doc")]
        public Documentation Doc { get; set; }
    }
}