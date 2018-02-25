using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Gir.Tests
{
	[TestFixture]
	public abstract class GenerationTestBase
	{
		IEnumerable<Stream> GetResourceStreams (string name = null)
		{
			var assembly = Assembly.GetExecutingAssembly();

			var names = assembly.GetManifestResourceNames();
			foreach (var resName in names) {
				if (string.IsNullOrEmpty (resName) || resName.EndsWith(name + ".gir", StringComparison.OrdinalIgnoreCase))
					yield return assembly.GetManifestResourceStream(resName);
			}
		}

		protected IEnumerable<Stream> GetAllGIRFiles()
		{
			return GetResourceStreams();
		}

		protected Stream GetGIRFile (string name)
		{
			return GetResourceStreams(name).Single();
		}
	}
}
