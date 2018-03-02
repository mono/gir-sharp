using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class ParserTests : GenerationTestBase
	{
		[Test]
		public void CanLoadGirFiles ()
		{
			foreach (var repo in ParseAllGirFiles ()) {
				// Should not throw.
			}
		}
	}
}
