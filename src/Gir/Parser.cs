using System;
using System.IO;

namespace Gir
{
	public class Parser
	{
		readonly string fileName;

		public Parser(string fileName)
		{
			this.fileName = fileName;
		}

		public Repository Parse ()
		{
			using (var fs = File.OpenRead (fileName))
			{
				var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Repository));
				return (Repository)serializer.Deserialize(fs);
			}
		}
	}
}
