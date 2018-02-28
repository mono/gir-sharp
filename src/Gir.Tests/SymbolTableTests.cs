using System;
using System.Linq;
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public class SymbolTableTests : GenerationTestBase
	{
		[Test]
		public void TestAliasMapping ()
		{
			var repo = ParseGirFile(GLib, out var mainRepository);
			var opts = GetOptions(repo, mainRepository);

			Assert.AreEqual(opts.SymbolTable["guint8"], opts.SymbolTable["GDateDay"]);
		}

		[TestCase(Gdk3, 3)]
		[TestCase(GLib, 0)]
		[TestCase(Gtk3, 5)]
		[TestCase(Pango, 3)]
		public void TestSymbolTableErrorsTracker(string girFile, int errorCount)
		{
			var repo = ParseGirFile(girFile, out var mainRepository);
			var opts = GetOptions(repo, mainRepository);

			var stats = opts.Statistics.Errors.ToArray ();

			// FUTURE: This should be 0.
			Assert.AreEqual(errorCount, stats.Length);
			foreach (var error in stats) {
				Console.WriteLine(error.Message);
			}
		}

		[Test]
		public void NoAliasTypeAfterProcessing ()
		{
			foreach (var tpl in ParseAllGirFiles ()) {
				var repo = tpl.Item2;
				var mainRepository = tpl.Item1;
				
				var opts = GetOptions(repo, mainRepository);

				Assert.AreEqual(0, opts.SymbolTable.OfType<Alias>().Count());
			}
		}

		[Test]
		public void VoidPointerWorks ()
		{
			var repo = ParseGirFile(GLib, out var mainRepository);
			var opts = GetOptions(repo, mainRepository);

			Assert.AreEqual("gpointer", opts.SymbolTable["void*"].CType);
		}
		
		[Test]
		public void CanResolveIncludedFiles ()
		{
			var repo = ParseGirFile(Gtk3, out var mainRepository);
			var opts = GetOptions(repo, mainRepository);

			Assert.NotNull(opts.SymbolTable["GdkPixbufError"]);
		}
	}
}
