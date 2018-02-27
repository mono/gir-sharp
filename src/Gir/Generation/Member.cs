using System;
namespace Gir
{
	public partial class Member : IMemberGeneratable
	{
		public bool NewlineAfterGeneration(GenerationOptions opts)
		{
			return opts.GenerateDocumentation;
		}

		public void Generate(GenerationOptions opts, IGeneratable parent, IndentWriter writer)
		{
			writer.WriteDocumentation(Doc);

			string value = Value;
			// Make this smarter, probably pass in some options and key them.
			if (parent is Bitfield)
				value = HexFormat(value);

			writer.WriteLine(Name.ToCSharp() + " = " + value + ",");
		}

		string HexFormat(string text)
		{
			int value = int.Parse(text);

			// Maybe pad with leading zeroes based on the value?
			return string.Format("0x{0:X}", value);
		}
	}
}
