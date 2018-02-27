using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gir
{
	public static class IGeneratableExtensions
	{
		const string CSharpFileExtension = ".cs";

		public static IndentWriter GetWriter (this IGeneratable gen, GenerationOptions opts)
		{
			var path = Path.Combine(opts.DirectoryPath, gen.Name + CSharpFileExtension);
			return IndentWriter.OpenWrite(path, opts);
		}

		public static void GenerateMembers (this IGeneratable gen, GenerationOptions opts, IndentWriter writer)
		{
			var array = gen.GetMemberGeneratables().ToArray ();
			for (int i = 0; i < array.Length; ++i) {
				var member = array[i];
				member.Generate(opts, gen, writer);

				if (i != array.Length - 1 && member.NewlineAfterGeneration (opts))
					writer.WriteLine();
			}
		}

		static IEnumerable<IMemberGeneratable> GetMemberGeneratables (this IGeneratable gen)
		{
			return Utils.GetAllCollectionMembers<IMemberGeneratable>(gen);
		}
	}
}
