using System.IO;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class GenerationOptionsTests : GenerationTestBase
	{
		[Test]
		public void GenerateDocumentationWhenCompatFalse()
		{
			var gir = GetGIRFile("Pango-1.0");
			var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Repository));
			var repo = (Repository)serializer.Deserialize(gir);

			var sw = new MemoryStream();
			var opts = new GenerationOptions("", repo.Namespace)
			{
				RedirectStream = sw,
			};

			repo.GetGeneratables().First(x => x.Name == "Alignment").Generate(opts);

			var result = Encoding.UTF8.GetString(sw.ToArray());

			Assert.AreEqual(@"namespace Pango
{
	///<summary>
	/// A #PangoAlignment describes how to align the lines of a #PangoLayout within the
	/// available space. If the #PangoLayout is set to justify
	/// using pango_layout_set_justify(), this only has effect for partial lines.
	///</summary>
	public enum Alignment
	{
		///<summary>Put all available space on the right</summary>
		Left = 0,
		///<summary>Center the line within the available space</summary>
		Center = 1,
		///<summary>Put all available space on the left</summary>
		Right = 2,
	}
}
", result);
		}

		[Test]
		public void GenerateNoDocumentationWhenCompatTrue()
		{
			var gir = GetGIRFile("Pango-1.0");
			var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Repository));
			var repo = (Repository)serializer.Deserialize(gir);

			var sw = new MemoryStream();
			var opts = new GenerationOptions("", repo.Namespace, true)
			{
				RedirectStream = sw,
			};

			repo.GetGeneratables().First(x => x.Name == "Alignment").Generate(opts);

			var result = Encoding.UTF8.GetString(sw.ToArray());

			Assert.AreEqual(@"namespace Pango
{
	public enum Alignment
	{
		Left = 0,
		Center = 1,
		Right = 2,
	}
}
", result);
		}
	}
}
