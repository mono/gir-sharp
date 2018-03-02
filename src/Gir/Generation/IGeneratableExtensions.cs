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
			var path = Path.Combine (opts.DirectoryPath, gen.Name + CSharpFileExtension);
			return IndentWriter.OpenWrite (path, opts);
		}

		public static void GenerateDocumentation (this IDocumented gen, IndentWriter writer)
		{
			if (gen.Doc is null)
				return;

			writer.WriteDocumentation (gen.Doc, gen is ReturnValue ? "returns" : "summary");
		}

		public static void GenerateMembers (this IGeneratable gen, IndentWriter writer, Func<IMemberGeneratable, bool> where = null)
		{
			var array = gen.GetMemberGeneratables ().Where (x => where == null || where (x)).ToArray ();
			for (int i = 0; i < array.Length; ++i) {
				var member = array [i];

				// Generate pinvoke signature for a method
				if (member is ICallable callable)
					callable.GenerateImport (gen, writer);

				// Generate documentation is a member supports it.
				if (member is IDocumented doc)
					doc.GenerateDocumentation (writer);

				// Call the main member generation implementation.
				member.Generate (gen, writer);

				if (i != array.Length - 1 && member.NewlineAfterGeneration (writer.Options))
					writer.WriteLine ();
			}
		}

		static void GenerateImport (this ICallable callable, IGeneratable parent, IndentWriter writer)
		{
			var retType = GetReturnCSharpType (callable, writer);

			var (typesAndNames, names) = BuildParameters (callable.Parameters);
			writer.WriteLine ($"static extern {retType} {callable.CIdentifier} ({typesAndNames})");
			writer.WriteLine ();
		}

		static string GetReturnCSharpType (this ICallable callable, IndentWriter writer)
		{
			// This can also be array
			return callable.ReturnValue?.Type?.GetSymbol (writer.Options).CSharpType ?? "void";
		}

		public static void GenerateCallableDefinition (this ICallable callable, IndentWriter writer)
		{
			callable.ReturnValue.GenerateDocumentation (writer);

			writer.WriteIndent ();
			if (!string.IsNullOrEmpty (callable.Modifiers))
				writer.Write (callable.Modifiers + " ");

			var returnType = callable.GetReturnCSharpType (writer);

			// generate ReturnValue then Parameters
			// FIXME, probably don't need the instance parameters?
			var (typesAndNames, names) = BuildParameters (callable.Parameters);
			writer.Write (string.Format ("{0} {1} ({2});", returnType, callable.Name.ToCSharp (), typesAndNames));
			writer.WriteLine ();
		}

		public static void GenerateConstructor (this ICallable callable, IGeneratable parent, IndentWriter writer)
		{
			callable.ReturnValue.GenerateDocumentation (writer);

			var modifier = "";
			if (parent is Class) {
				if (!(parent as Class).Abstract)
					modifier = "public ";
				else
					modifier = "protected ";
			}

			var (typesAndNames, names) = BuildParameters (callable.Parameters);

			// FIXME, should check to see if it is deprecated
			writer.WriteLine ($"{modifier}{parent.Name}({typesAndNames}) : base ({names})");
			writer.WriteLine ("{");
			writer.WriteLine ("}");
		}

		public static (string both, string names) BuildParameters (List<Parameter> parameters)
		{
			// FIXME, Arrays don't have a 'Type' set
			// PERF: Use an array as the string[] overload of Join is way more efficient than the IEnumerable<string> one.
			var typeAndName = new string [parameters.Count];
			var parameterNames = new string [parameters.Count];
			for (int i = 0; i < parameters.Count; ++i) {
				var parameter = parameters [i];
				typeAndName [i] = parameter.Type?.Name + " " + parameter.Name;
				parameterNames [i] = parameter.Name;
			}

			string parameterString = string.Join (", ", typeAndName);
			string baseParams = string.Join (", ", parameterNames);

			return (parameterString, baseParams);
		}

		static IEnumerable<IMemberGeneratable> GetMemberGeneratables (this IGeneratable gen)
		{
			return Utils.GetAllCollectionMembers<IMemberGeneratable> (gen);
		}
	}
}
