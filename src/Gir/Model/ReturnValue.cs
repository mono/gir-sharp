using System.Xml.Serialization;

namespace Gir
{
	public partial class ReturnValue : IDocumented
	{
		[XmlAttribute ("nullable")]
		public bool Nullable;

		[XmlAttribute ("transfer-ownership")]
		public TransferOwnership TransferOwnership;

		[XmlElement ("doc")]
		public Documentation Doc { get; set; }

		[XmlElement ("type")]
		public Type Type { get; set;  }

		[XmlElement ("array")]
		public Array Array { get; set; }
	}
}
