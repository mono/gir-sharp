using System;
using System.IO;

namespace Gir
{
	public static class Parser
	{
		public static Repository Parse(string fileName)
		{
			using (var fs = File.OpenRead(fileName)) {
				return Parse(fs);
			}
		}

		public static Repository Parse(Stream s)
		{
			var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Repository));
			return (Repository)serializer.Deserialize(s);
		}
	}
}
