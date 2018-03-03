using System.Xml.Serialization;

namespace Gir
{
	[XmlInclude (typeof (InstanceParameter))]
	public partial class Parameter : ITypeOrArray
	{
		[XmlAttribute ("allow-none")]
		public bool AllowNone;

		[XmlAttribute ("caller-allocates")]
		public bool CallerAllocates;

		[XmlAttribute ("closure")]
		public int Closure;

		[XmlAttribute ("destroy")]
		public int Destroy;

		[XmlAttribute ("direction")]
		public Direction Direction;

		[XmlAttribute ("name")]
		public string Name;

		[XmlAttribute ("nullable")]
		public bool Nullable;

		[XmlAttribute ("optional")]
		public bool Optional;

		[XmlAttribute ("skip")]
		public bool Skip;

		[XmlAttribute ("transfer-ownership")]
		public TransferOwnership TransferOwnership;

		[XmlElement ("doc")]
		public Documentation Doc { get; set; }

		[XmlElement ("type")]
		public Type Type { get; set; }

		[XmlElement ("array")]
		public Array Array { get; set; }

		[XmlElement ("varargs")]
		public Varargs Varargs { get; set; }

		public bool IsPointer => Type.CType.EndsWith ("*", System.StringComparison.Ordinal);

		public bool IsArray => Type.Array != null;
	}
}
