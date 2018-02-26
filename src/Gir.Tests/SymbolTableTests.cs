using Gir.Symbols;

using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class SymbolTableTests : GenerationTestBase
	{
		[Test]
		public void IsCreatedAndFilled ()
		{
			foreach (var stream in GetAllGIRFiles()) {
				var serializer = new System.Xml.Serialization.XmlSerializer (typeof(Repository));
				var repo = (Repository)serializer.Deserialize (stream);
				var table = new SymbolTable();
				table.AddType (repo.Namespace.GetGeneratables ());

				Assert.That (table.Count > 0, "Table shouldn't be empty");
			}
		}

		[Test]
		public void ContainsEnumerations ()
		{
			var gir = GetGIRFile("Pango-1.0");
			var serializer = new System.Xml.Serialization.XmlSerializer (typeof(Repository));
			var repo = (Repository)serializer.Deserialize (gir);
			var table = new SymbolTable ();
			table.AddType (repo.Namespace.GetGeneratables ());

			var alignmentGeneratable = table ["Alignment"];
			Assert.NotNull (alignmentGeneratable);
		}
	}
}
