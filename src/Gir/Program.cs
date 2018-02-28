using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gir
{
	class MainClass
	{
		class OptionSet
		{
			public string OutputDirectory = "generated";
			public string custom_dir = "";
			public string GeneratedAssemblyName = "";
			public string glue_filename = "";
			public string glue_includes = "";
			public string gluelib_name = "";
			public string IncludeSearchDirectory = "/usr/share/gir-1.0/";
			public List<ISymbol> symbols = new List<ISymbol>();
			public List<IGeneratable> gens = new List<IGeneratable>();
			public Namespace GenerationNamespace;
		}

		public static int Main(string[] args)
		{
			if (args.Length < 2) {
				Console.WriteLine("Usage: gir.exe <file.gir>");
				return 0;
			}

			var opt = new OptionSet();
			foreach (string arg in args) {
				ParseArg(opt, arg);
			}

			// Now that everything is loaded, validate all the to-be-
			// generated generatables and then remove the invalid ones.
			var invalids = new List<IGeneratable>();
			foreach (IGeneratable gen in opt.gens) {
				//if (!gen.Validate())
				//invalids.Add(gen);
			}
			foreach (IGeneratable gen in invalids)
				opt.gens.Remove(gen);

			//GenerationInfo gen_info = null;
			//if (dir != "" || assembly_name != "" || glue_filename != "" || glue_includes != "" || gluelib_name != "")
			//gen_info = new GenerationInfo(dir, custom_dir, assembly_name, glue_filename, glue_includes, gluelib_name);

			var genOpts = new GenerationOptions(opt.OutputDirectory, opt.GenerationNamespace, false);
			genOpts.SymbolTable.AddTypes(opt.symbols);
			genOpts.SymbolTable.ProcessAliases();
			
			foreach (IGeneratable gen in opt.gens) {
				gen.Generate(genOpts);
			}

			genOpts.Statistics.ReportStatistics();
			return 0;
		}

		static void ParseArg(OptionSet opt, string arg)
		{
			string filename = arg;
			if (arg.StartsWith("--outdir=")) {
				opt.OutputDirectory = arg.Substring(9);
				return;
			}
			if (arg.StartsWith("--customdir=")) {
				opt.custom_dir = arg.Substring(12);
				return;
			}
			if (arg.StartsWith("--assembly-name=")) {
				opt.GeneratedAssemblyName = arg.Substring(16);
				return;
			}
			if (arg.StartsWith("--glue-filename=")) {
				opt.glue_filename = arg.Substring(16);
				return;
			}
			if (arg.StartsWith("--glue-includes=")) {
				opt.glue_includes = arg.Substring(16);
				return;
			}
			if (arg.StartsWith("--gluelib-name=")) {
				opt.gluelib_name = arg.Substring(15);
				return;
			}
			if (arg.StartsWith("--include-dir=")) {
				opt.IncludeSearchDirectory = arg.Substring(15);
				return;
			}

			var repositories = Parser.Parse(filename, opt.IncludeSearchDirectory, out var mainRepository);

			opt.GenerationNamespace = mainRepository.Namespace;
			opt.GeneratedAssemblyName = mainRepository.Namespace.Name;

			foreach (var repository in repositories) {
				opt.symbols.AddRange(repository.GetSymbols());
			}
			opt.gens.AddRange(mainRepository.GetGeneratables());
		}
	}
}
