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

		public static void GenerateDocumentation (this IDocumented gen, IndentWriter writer)
		{
			writer.WriteDocumentation(gen.Doc);
		}

		public static void GenerateMembers (this IGeneratable gen, IndentWriter writer)
		{
			var array = gen.GetMemberGeneratables().ToArray ();
			for (int i = 0; i < array.Length; ++i) {
				var member = array[i];

				if (member is IDocumented doc)
					doc.GenerateDocumentation(writer);
				member.Generate(gen, writer);

				if (i != array.Length - 1 && member.NewlineAfterGeneration (writer.Options))
					writer.WriteLine();
			}
		}

		static IEnumerable<IMemberGeneratable> GetMemberGeneratables (this IGeneratable gen)
		{
			return Utils.GetAllCollectionMembers<IMemberGeneratable>(gen);
		}
	}
}
