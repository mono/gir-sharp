using System;
using System.IO;

namespace Gir
{
	public class IndentWriter : IDisposable
	{
		TextWriter writer;
		int indent;

		public GenerationOptions Options { get; private set; }

		public static IndentWriter OpenWrite (string path, GenerationOptions opts)
		{
			var toStream = opts.RedirectStream ?? File.Open (path, FileMode.Create);
			var sw = new StreamWriter (toStream);

			return new IndentWriter (sw) {
				Options = opts,
			};
		}

		public IndentWriter WriteHeader ()
		{
			if (!Options.WriteHeader)
				return this;
			
			WriteLine ("using System;");
			// TODO: Uncomment this when we know exactly which namespaces to include.
			//foreach (var include in Options.UsingNamespaces) {
			//	if (include == Options.Namespace)
			//		continue;
			//	WriteLine ($"using {include};");
			//}
			WriteLine ();

			WriteLine ($"namespace {Options.Namespace}");
			WriteLine ("{");
			Indent ();

			return this;
		}

		public IndentWriter (TextWriter tw)
		{
			writer = tw;
		}

		public void Dispose ()
		{
			if (writer != null) {
				if (Options.WriteHeader) {
					Unindent ();
					WriteLine ("}");
				}

				writer?.Dispose ();
				writer = null;
			}
		}

		public IndentWriter WriteDocumentation (Documentation doc, string tag)
		{
			if (!Options.GenerateDocumentation)
				return this;

			var text = doc.Text.Split ('\n');
			if (text.Length == 1) {
				WriteIndent ();
				return Write ($"///<{tag}>").Write (text [0]).Write ($"</{tag}>").WriteLine ();
			}

			WriteLine ($"///<{tag}>");
			foreach (var line in text)
				WriteLine ("/// " + line);
			return WriteLine ($"///</{tag}>");
		}

		public IndentWriter WriteIndent ()
		{
			writer.Write (new string ('\t', indent));
			return this;
		}

		public IndentWriter Write (string s)
		{
			writer.Write (s);
			return this;
		}

		public IndentWriter WriteLine ()
		{
			writer.WriteLine ();
			return this;
		}

		public IndentWriter WriteLine (string s)
		{
			return WriteIndent ().Write (s).WriteLine ();
		}

		public IndentWriter WriteLineAndIndent (string s)
		{
			WriteLine (s);
			Indent ();
			return this;
		}

		public IndentWriter WriteLineAndUnindent (string s)
		{
			Unindent ();
			WriteLine (s);
			return this;
		}

		public IDisposable Indent ()
		{
			indent++;
			return new IndentDisposable (this);
		}

		public void Unindent ()
		{
			indent--;
		}

		class IndentDisposable : IDisposable
		{
			readonly IndentWriter writer;
			public IndentDisposable (IndentWriter writer)
			{
				this.writer = writer;
			}

			public void Dispose ()
			{
				writer.indent--;
			}
		}
	}
}
