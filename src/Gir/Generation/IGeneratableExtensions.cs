using System;
using System.IO;

namespace Gir
{
	public static class IGeneratableExtensions
	{
		public static IndentWriter GetWriter (this IGeneratable gen, GenerationOptions opts)
		{
			var path = Path.Combine(opts.DirectoryPath, gen.Name + ".cs");
			return IndentWriter.OpenWrite(path, opts);
		}
	}
}
