using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gir
{
	public static class IGeneratableExtensions
	{
		const string CSharpFileExtension = ".cs";

		public static IndentWriter GetWriter(this IGeneratable gen, GenerationOptions opts)
		{
			var path = Path.Combine(opts.DirectoryPath, gen.Name + CSharpFileExtension);
			return IndentWriter.OpenWrite(path, opts);
		}

		public static void GenerateDocumentation(this IDocumented gen, IndentWriter writer)
		{
			if (gen.Doc is null)
				return;

			writer.WriteDocumentation(gen.Doc, gen is ReturnValue ? "returns" : "summary");
		}

		public static void GenerateMembers(this IGeneratable gen, IndentWriter writer, Func<IMemberGeneratable, bool> where = null)
		{
			var array = gen.GetMemberGeneratables().Where(x => where == null || where(x)).ToArray();
			for (int i = 0; i < array.Length; ++i) {
				var member = array[i];

				// Always generate documentation
				if (member is IDocumented doc)
					doc.GenerateDocumentation(writer);
				member.Generate(gen, writer);

				if (i != array.Length - 1 && member.NewlineAfterGeneration(writer.Options))
					writer.WriteLine();
			}
		}

		static IEnumerable<IMemberGeneratable> GetMemberGeneratables(this IGeneratable gen)
		{
			return Utils.GetAllCollectionMembers<IMemberGeneratable>(gen);
		}

		static string GetReturnCSharpType(this ICallable callable, IndentWriter writer)
		{
			// This can also be array
			return callable.ReturnValue?.Type?.GetSymbol(writer.Options).CSharpType ?? "void";
		}

		public static void GenerateCallableDefinition(this ICallable callable, IndentWriter writer)
		{
			callable.ReturnValue.GenerateDocumentation(writer);

			writer.WriteIndent();
			if (!string.IsNullOrEmpty(callable.Modifiers))
				writer.Write(callable.Modifiers + " ");

			var returnType = callable.GetReturnCSharpType(writer);

			// generate ReturnValue then Parameters
			writer.Write(string.Format("{0} {1} {2}", returnType, callable.Name, "PARAMS"));
			writer.WriteLine();
		}

		public static void GenerateConstructor(this ICallable callable, IGeneratable parent, IndentWriter writer)
		{
			callable.ReturnValue.GenerateDocumentation(writer);

			var modifier = "";
			if (parent is Class) {
				if (!(parent as Class).Abstract)
					modifier = "public ";
				else
					modifier = "protected ";
			}

			var (typesAndNames, names) = BuildParameters(callable.Parameters);

			// FIXME, should check to see if it is deprecated
			writer.WriteLine($"{modifier}{parent.Name}({typesAndNames}) : base ({names})");
			writer.WriteLine("{");
			writer.WriteLine("}");
		}

		public static (string both, string names) BuildParameters(List<Parameter> parameters)
		{
			var typeAndName = new Dictionary<string, string>();
			foreach (var parameter in parameters)
				typeAndName.Add(parameter.Type.Name, parameter.Name);

			var sb = new StringBuilder();
			foreach (var pair in typeAndName) {
				sb.AppendFormat("{0} {1}, ", pair.Key, pair.Value);
			}
			string parameterString = sb.ToString();
			parameterString = parameterString.Substring(0, parameterString.Length - 2);

			string baseParams = string.Join(", ", typeAndName.Values);

			return (parameterString, baseParams);
		}
	}
}
