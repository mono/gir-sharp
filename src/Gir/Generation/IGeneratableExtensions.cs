using System;
using System.Collections.Generic;
using System.IO;

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

		public static void GenerateMembers (this IGeneratable gen, IndentWriter writer)
		{
			foreach (var member in gen.GetMemberGeneratables())
			{
				member.Generate(gen, writer);
			}
		}

		static IEnumerable<IMemberGeneratable> GetMemberGeneratables (this IGeneratable gen)
		{
			return Utils.GetAllCollectionMembers<IMemberGeneratable>(gen);
		}
	}
}
