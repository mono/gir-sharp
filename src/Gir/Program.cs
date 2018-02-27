using System;
using System.Collections.Generic;
using System.IO;

namespace Gir
{
	class MainClass
	{
		class OptionSet
		{
			public bool generate = false;
			public string dir = "generated";
			public string custom_dir = "";
			public string assembly_name = "";
			public string glue_filename = "";
			public string glue_includes = "";
			public string gluelib_name = "";
			public List<ISymbol> symbols = new List<ISymbol>();
			public List<IGeneratable> gens = new List<IGeneratable>();
			public Namespace ns;
		}

		public static int Main(string[] args)
		{
			if (args.Length < 2) {
				Console.WriteLine("Usage: gir.exe --generate <filename1...>");
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

			var genOpts = new GenerationOptions(opt.dir, opt.ns, false);
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
			if (arg == "--generate") {
				opt.generate = true;
				return;
			}
			if (arg == "--include") {
				opt.generate = false;
				return;
			}
			if (arg.StartsWith("-I:")) {
				opt.generate = false;
				filename = filename.Substring(3);
			} else if (arg.StartsWith("--outdir=")) {
				opt.generate = false;
				opt.dir = arg.Substring(9);
				return;
			} else if (arg.StartsWith("--customdir=")) {
				opt.generate = false;
				opt.custom_dir = arg.Substring(12);
				return;
			}
			if (arg.StartsWith("--assembly-name=")) {
				opt.generate = false;
				opt.assembly_name = arg.Substring(16);
				return;
			}
			if (arg.StartsWith("--glue-filename=")) {
				opt.generate = false;
				opt.glue_filename = arg.Substring(16);
				return;
			}
			if (arg.StartsWith("--glue-includes=")) {
				opt.generate = false;
				opt.glue_includes = arg.Substring(16);
				return;
			}
			if (arg.StartsWith("--gluelib-name=")) {
				opt.generate = false;
				opt.gluelib_name = arg.Substring(15);
				return;
			}

			var p = new Parser(filename);
			Repository repo = p.Parse();
			opt.ns = repo.Namespace;

			// No SymbolTable for now
			//table.AddTypes(curr_gens);
			//if (!generate)
			//{
			//	foreach (var gen in curr_gens)
			//		gen.Validate();
			//}
			opt.symbols.AddRange(repo.GetSymbols());
			if (opt.generate)
				opt.gens.AddRange(repo.GetGeneratables());
		}
	}
}
