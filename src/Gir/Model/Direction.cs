using System.Xml.Serialization;

namespace Gir
{
	public enum Direction
	{
		[XmlEnum ("out")]
		Out,
		[XmlEnum ("in")]
		In,
		[XmlEnum ("inout")]
		InOut
	}
}

