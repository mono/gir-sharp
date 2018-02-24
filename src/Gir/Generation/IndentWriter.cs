using System;
using System.IO;

namespace Gir
{
	public class IndentWriter : IDisposable
	{
		TextWriter writer;
		int indent;

		public static IndentWriter OpenWrite (string path)
		{
			var fs = File.Open (path, FileMode.Create);
			var sw = new StreamWriter(fs);
			return new IndentWriter(sw);
		}

		public IndentWriter(TextWriter tw)
		{
			writer = tw;
		}

		public void Dispose ()
		{
			writer?.Dispose();
			writer = null;
		}

		public IndentWriter WriteDocumentation (Documentation doc)
		{
			var text = doc.Text.Split('\n');
			if (text.Length == 1)
			{
				WriteIndent();
				return Write("///<summary>").Write(text[0]).Write("</summary>").WriteLine ();
			}

			WriteLine("///<summary>");
			foreach (var line in text)
				WriteLine("/// " + line);
			return WriteLine("///</summary>");
		}

		public IndentWriter WriteIndent()
		{
			writer.Write(new String('\t', indent));
			return this;
		}

		public IndentWriter Write(string s)
		{
			writer.Write(s);
			return this;
		}

		public IndentWriter WriteLine()
		{
			writer.WriteLine();
			return this;
		}

		public IndentWriter WriteLine(string s)
		{
			return WriteIndent().Write(s).WriteLine ();
		}

		public IndentWriter WriteLineAndIndent(string s)
		{
			WriteLine(s);
			Indent();
			return this;
		}

		public IndentWriter WriteLineAndUnindent(string s)
		{
			Unindent();
			WriteLine(s);
			return this;
		}

		public void Indent()
		{
			indent++;
		}

		public void Unindent()
		{
			indent--;
		}
	}
}
