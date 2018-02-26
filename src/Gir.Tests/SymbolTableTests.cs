using System;
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class SymbolTableTests : GenerationTestBase
	{
		[Test]
		public void TestAliasMapping ()
		{
			var repo = ParseGirFile(GLib);
			var opts = GetOptions(repo);

			Assert.AreEqual(opts.SymbolTable["guint8"], opts.SymbolTable["GDateDay"]);
		}
	}
}
