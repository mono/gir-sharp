using System.IO;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class BitFieldGenerationTests : GenerationTestBase
	{
		[Test]
		public void GenerateDocumentationWhenCompatFalse()
		{
			var gir = GetGIRFile("Pango-1.0");
			var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Repository));
			var repo = (Repository)serializer.Deserialize(gir);

			var sw = new MemoryStream();
			var opts = new GenerationOptions("", repo.Namespace) {
				RedirectStream = sw,
			};

			repo.GetGeneratables().First(x => x.Name == "FontMask").Generate(opts);

			var result = Encoding.UTF8.GetString(sw.ToArray());

			Assert.AreEqual(@"namespace Pango
{
	///<summary>
	/// The bits in a #PangoFontMask correspond to fields in a
	/// #PangoFontDescription that have been set.
	///</summary>
	[Flags]
	public enum FontMask
	{
		///<summary>the font family is specified.</summary>
		Family = 1,
		///<summary>the font style is specified.</summary>
		Style = 2,
		///<summary>the font variant is specified.</summary>
		Variant = 4,
		///<summary>the font weight is specified.</summary>
		Weight = 8,
		///<summary>the font stretch is specified.</summary>
		Stretch = 16,
		///<summary>the font size is specified.</summary>
		Size = 32,
		///<summary>the font gravity is specified (Since: 1.16.)</summary>
		Gravity = 64,
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
			var opts = new GenerationOptions("", repo.Namespace, true) {
				RedirectStream = sw,
			};

			repo.GetGeneratables().First(x => x.Name == "FontMask").Generate(opts);

			var result = Encoding.UTF8.GetString(sw.ToArray());

			Assert.AreEqual(@"namespace Pango
{
	[Flags]
	public enum FontMask
	{
		Family = 1,
		Style = 2,
		Variant = 4,
		Weight = 8,
		Stretch = 16,
		Size = 32,
		Gravity = 64,
	}
}
", result);
		}
	}
}
