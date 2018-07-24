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
			return IndentWriter.OpenWrite (path, opts).WriteHeader ();
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
				if (!(gen is Interface) && member is INativeCallable callable)
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

		static void GenerateImport (this INativeCallable callable, IGeneratable parent, IndentWriter writer)
		{
			var retType = GetReturnCSharpType (callable, writer);

			var parameters = BuildParameters (callable, writer.Options, appendInstanceParameters: true);

			// TODO: Better than using the constant string, insert a custom generatable which contains the import string as a constant.
			/* i.e.
static class <LibraryName>Constants
{
	public const string GLib = "libglib-2.0.so";
}
			 */
			//writer.WriteLine ($"[DllImport (\"{writer.Options.LibraryName}\", CallingConvention=CallingConvention.Cdecl)]");
			writer.WriteLine ($"static extern {retType} {callable.CIdentifier} ({parameters.MarshalTypesAndNames});");
			writer.WriteLine ();
		}

		public static string GetReturnCSharpType (this IMethodLike callable, IndentWriter writer)
		{
			var retVal = callable.ReturnValue;
			if (retVal == null)
				return "void";

			// TODO: Handle marshalling.

			// Try getting the array return value, then the type one.
			var retSymbol = retVal.Resolve (writer.Options);
			return retSymbol.CSharpType;
		}

		public static void GenerateCallableDefinition (this INativeCallable callable, IGeneratable gen, IndentWriter writer)
		{
			callable.ReturnValue.GenerateDocumentation (writer);

			writer.WriteIndent ();
			if (!string.IsNullOrEmpty (callable.GetModifiers (gen, writer.Options)) && !(gen is Interface))
				writer.Write (callable.GetModifiers (gen, writer.Options) + " ");

			var returnType = callable.GetReturnCSharpType (writer);

			// generate ReturnValue then Parameters
			var result = BuildParameters (callable, writer.Options, !callable.IsInstanceCallable (gen, writer.Options));
			writer.Write (string.Format ("{0} {1} ({2})", returnType, callable.Name.ToCSharp (), result.TypesAndNames));

			if (gen is Interface)
			{
				writer.Write(";");
				writer.WriteLine();
				return;
			}

			writer.WriteLine();
			writer.WriteLine("{");
			using (writer.Indent())
			{
				string prefix = returnType != "void" ? "return " : string.Empty;
				writer.WriteLine($"{prefix}{callable.CIdentifier} ({result.Names});");
			}
			writer.WriteLine("}");
		}

		public static void GenerateConstructor (this INativeCallable callable, IGeneratable parent, IndentWriter writer)
		{
			callable.ReturnValue.GenerateDocumentation (writer);

			var modifier = callable.GetModifiers (parent, writer.Options);

			var result = BuildParameters (callable, writer.Options, !callable.IsInstanceCallable (parent, writer.Options));

			// FIXME, should check to see if it is deprecated
			writer.WriteLine ($"{modifier} {parent.Name} ({result.TypesAndNames}) : base ({result.Names})");
			writer.WriteLine ("{");
			writer.WriteLine ("}");
		}

		public static ParametersResult BuildParameters(this IMethodLike callable, GenerationOptions opts, bool appendInstanceParameters)
		{
			var parameters = callable.Parameters;
			var marshalTypeAndName = new List<string>(parameters.Count);
			var typeAndName = new List<string> (parameters.Count);
			var parameterNames = new List<string> (parameters.Count);

			for (int i = 0; i < parameters.Count; ++i) {
				var parameter = parameters [i];
				if (!appendInstanceParameters) {
					if (parameter is InstanceParameter)
						continue;
					
					// HACK: Make this proper
					if (i == 0 && callable is Function)
						continue;
				}

				var symbol = parameter.Resolve(opts);
				marshalTypeAndName.Add(symbol.CSharpType + " " + parameter.Name);
				typeAndName.Add(symbol.CSharpType + (parameter.Array != null ? "[]" : "") + " " + parameter.Name);
				parameterNames.Add(parameter.Name);
			}

			// PERF: Use an array as the string[] overload of Join is way more efficient than the IEnumerable<string> one.
			string marshalParameterString = string.Join(", ", marshalTypeAndName.ToArray());
			string parameterString = string.Join (", ", typeAndName.ToArray ());
			string baseParams = string.Join (", ", parameterNames.ToArray ());

			return new ParametersResult(marshalParameterString, parameterString, baseParams);
		}

		static IEnumerable<IMemberGeneratable> GetMemberGeneratables (this IGeneratable gen)
		{
			return Utils.GetAllCollectionMembers<IMemberGeneratable> (gen);
		}
	}

	public class ParametersResult
	{
		public string MarshalTypesAndNames { get; }
		public string TypesAndNames { get; }
		public string Names { get; }

		public ParametersResult(string marshalTypesAndNames, string typesAndNames, string names)
		{
			MarshalTypesAndNames = marshalTypesAndNames;
			TypesAndNames = typesAndNames;
			Names = names;
		}
	}
}
