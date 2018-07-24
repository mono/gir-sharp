using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class ParserTests : GenerationTestBase
	{
		[TestCase (Library.Gtk2)]
		[TestCase (Library.Gtk3)]
		public void CanLoadGirFiles (Library library)
		{
			foreach (var repo in ParseAllGirFiles (library)) {
				// Should not throw.
			}
		}
	}
}
