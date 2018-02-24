using System;
using System.Xml.Serialization;

namespace Gir
{
    public partial class ReturnValue
    {
        [XmlAttribute("nullable")]
        public bool Nullable;

        [XmlAttribute("transfer-ownership")]
        public TransferOwnership TransferOwnership;

        [XmlElement("doc")]
        public Documentation Doc { get; set; }

        [XmlElement("type")]
        public Type Type;
    }
}
