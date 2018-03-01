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
			public string CustomGeneratedAssemblyName;
			public string OutputDirectory = "generated";

			public string GeneratedAssemblyName => CustomGeneratedAssemblyName ?? GenerationRepository.Namespace.Name;
			public string IncludeSearchDirectory = GetDefaultSearchDirectory ();

			public Repository GenerationRepository;
			public IEnumerable<Repository> AllRepositories;

			public string custom_dir = "";
			public string glue_filename = "";
			public string glue_includes = "";
			public string gluelib_name = "";

			static string GetDefaultSearchDirectory ()
			{
				// if (IsLinux)
				return "/usr/share/gir-1.0/";
			}
		}

		public static int Main(string[] args)
		{
			if (args.Length < 1) {
				Console.WriteLine("Usage: gir.exe <file.gir>");
				return 0;
			}

			var opt = new OptionSet();
			foreach (string arg in args) {
				ParseArg(opt, arg);
			}

			//GenerationInfo gen_info = null;
			//if (dir != "" || assembly_name != "" || glue_filename != "" || glue_includes != "" || gluelib_name != "")
			//gen_info = new GenerationInfo(dir, custom_dir, assembly_name, glue_filename, glue_includes, gluelib_name);

			var genOpts = new GenerationOptions(opt.OutputDirectory, opt.AllRepositories, opt.GenerationRepository, false);
			
			foreach (IGeneratable gen in opt.GenerationRepository.GetGeneratables ()) {
				gen.Generate(genOpts);
			}

			genOpts.Statistics.ReportStatistics();
			return 0;
		}

		const string customOutputDir = "--outdir=";
		const string customAssemblyNameArg = "--assembly-name=";
		const string customIncludeDirArg = "--include-dir=";

		static void ParseArg(OptionSet opt, string arg)
		{
			string filename = arg;
			if (arg.StartsWith(customOutputDir)) {
				opt.OutputDirectory = arg.Substring(customOutputDir.Length);
				return;
			}
			if (arg.StartsWith("--customdir=")) {
				opt.custom_dir = arg.Substring(12);
				return;
			}
			if (arg.StartsWith(customAssemblyNameArg)) {
				opt.CustomGeneratedAssemblyName = arg.Substring(customAssemblyNameArg.Length);
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
			if (arg.StartsWith(customIncludeDirArg)) {
				opt.IncludeSearchDirectory = arg.Substring(customIncludeDirArg.Length);
				return;
			}

			opt.AllRepositories = Parser.Parse(filename, opt.IncludeSearchDirectory, out opt.GenerationRepository);
		}
	}
}
