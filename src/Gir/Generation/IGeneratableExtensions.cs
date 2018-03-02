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
				if (!(gen is Interface) && member is ICallable callable)
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

			var (typesAndNames, names) = BuildParameters (callable.Parameters, appendInstanceParameters: true);
			writer.WriteLine ($"static extern {retType} {callable.CIdentifier} ({typesAndNames});");
			writer.WriteLine ();
		}

		static string GetReturnCSharpType (this ICallable callable, IndentWriter writer)
		{
			var retVal = callable.ReturnValue;
			if (retVal == null)
				return "void";

			// TODO: Handle marshalling.

			// Try getting the array return value, then the type one.
			var retSymbol = retVal.Array?.GetSymbol (writer.Options) ?? retVal.Type.GetSymbol (writer.Options);
			return retSymbol.CSharpType;
		}

		public static void GenerateCallableDefinition (this ICallable callable, IGeneratable gen, IndentWriter writer)
		{
			callable.ReturnValue.GenerateDocumentation (writer);

			writer.WriteIndent ();
			if (!string.IsNullOrEmpty (callable.GetModifiers (gen)) && !(gen is Interface))
				writer.Write (callable.GetModifiers (gen) + " ");

			var returnType = callable.GetReturnCSharpType (writer);

			// generate ReturnValue then Parameters
			var (typesAndNames, names) = BuildParameters (callable.Parameters, !callable.IsInstanceCallable);
			writer.Write (string.Format ("{0} {1} ({2});", returnType, callable.Name.ToCSharp (), typesAndNames));
			writer.WriteLine ();
		}

		public static void GenerateConstructor (this ICallable callable, IGeneratable parent, IndentWriter writer)
		{
			callable.ReturnValue.GenerateDocumentation (writer);

			var modifier = callable.GetModifiers (parent);

			var (typesAndNames, names) = BuildParameters (callable.Parameters, !callable.IsInstanceCallable);

			// FIXME, should check to see if it is deprecated
			writer.WriteLine ($"{modifier} {parent.Name} ({typesAndNames}) : base ({names})");
			writer.WriteLine ("{");
			writer.WriteLine ("}");
		}

		public static (string both, string names) BuildParameters (List<Parameter> parameters, bool appendInstanceParameters)
		{
			var typeAndName = new List<string> (parameters.Count);
			var parameterNames = new List<string> (parameters.Count);

			for (int i = 0; i < parameters.Count; ++i) {
				var parameter = parameters [i];
				if (!appendInstanceParameters && parameter is InstanceParameter) {
					continue;
				}

				// FIXME, Arrays don't have a 'Type' set
				typeAndName.Add(parameter.Type?.Name + " " + parameter.Name);
				parameterNames.Add(parameter.Name);
			}

			// PERF: Use an array as the string[] overload of Join is way more efficient than the IEnumerable<string> one.
			string parameterString = string.Join (", ", typeAndName.ToArray ());
			string baseParams = string.Join (", ", parameterNames.ToArray ());

			return (parameterString, baseParams);
		}

		static IEnumerable<IMemberGeneratable> GetMemberGeneratables (this IGeneratable gen)
		{
			return Utils.GetAllCollectionMembers<IMemberGeneratable> (gen);
		}
	}
}
