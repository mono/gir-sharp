using System;
using System.Xml.Serialization;

namespace Gir
{
	public enum Scope
	{
		[XmlEnum("call")]
		Call,
		[XmlEnum("async")]
		Async,
		[XmlEnum("notified")]
		Notified
	}
}

